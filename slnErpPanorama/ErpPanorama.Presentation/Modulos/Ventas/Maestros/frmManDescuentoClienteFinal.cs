using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManDescuentoClienteFinal : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DescuentoClienteFinalBE> mLista = new List<DescuentoClienteFinalBE>();
        
        #endregion

        #region "Eventos"

        public frmManDescuentoClienteFinal()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClienteFinal_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDescuentoClienteFinalEdit objManDescuentoClienteFinal = new frmManDescuentoClienteFinalEdit();
                objManDescuentoClienteFinal.lstDescuentoClienteFinal = mLista;
                objManDescuentoClienteFinal.pOperacion = frmManDescuentoClienteFinalEdit.Operacion.Nuevo;
                objManDescuentoClienteFinal.IdDescuentoClienteFinal = 0;
                objManDescuentoClienteFinal.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteFinal.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        DescuentoClienteFinalBE objE_DescuentoClienteFinal = new DescuentoClienteFinalBE();
                        objE_DescuentoClienteFinal.IdDescuentoClienteFinal = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("IdDescuentoClienteFinal").ToString());
                        objE_DescuentoClienteFinal.Usuario = Parametros.strUsuarioLogin;
                        objE_DescuentoClienteFinal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DescuentoClienteFinal.IdEmpresa = Parametros.intEmpresaId;

                        DescuentoClienteFinalBL objBL_DescuentoClienteFinal = new DescuentoClienteFinalBL();
                        objBL_DescuentoClienteFinal.Elimina(objE_DescuentoClienteFinal);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ErpPanoramaServicios.ReporteDescuentoClienteFinalBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteDescuentoClienteFinal_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDescuentoClienteFinal = new RptVistaReportes();
            //            objRptDescuentoClienteFinal.VerRptDescuentoClienteFinal(lstReporte);
            //            objRptDescuentoClienteFinal.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDescuentoClienteFinales";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoClienteFinal.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescuentoClienteFinal_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDescuentoClienteFinal.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvDescuentoClienteFinal.RowCount > 0)
            {
                DescuentoClienteFinalBE objDescuentoClienteFinal = new DescuentoClienteFinalBE();
                objDescuentoClienteFinal.IdDescuentoClienteFinal = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("IdDescuentoClienteFinal").ToString());
                objDescuentoClienteFinal.IdClasificacionCliente = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("IdClasificacionCliente").ToString());
                objDescuentoClienteFinal.CantidadMinima = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("CantidadMinima").ToString());
                objDescuentoClienteFinal.CantidadMaxima = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("CantidadMaxima").ToString());
                objDescuentoClienteFinal.IdTipoPrecio = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("IdTipoPrecio").ToString());
                objDescuentoClienteFinal.PorDescuento = int.Parse(gvDescuentoClienteFinal.GetFocusedRowCellValue("PorDescuento").ToString());
                objDescuentoClienteFinal.FlagOpcional = Convert.ToBoolean(gvDescuentoClienteFinal.GetFocusedRowCellValue("FlagOpcional").ToString());
                objDescuentoClienteFinal.FlagEstado = Convert.ToBoolean(gvDescuentoClienteFinal.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManDescuentoClienteFinalEdit objManDescuentoClienteFinalEdit = new frmManDescuentoClienteFinalEdit();
                objManDescuentoClienteFinalEdit.pOperacion = frmManDescuentoClienteFinalEdit.Operacion.Modificar;
                objManDescuentoClienteFinalEdit.IdDescuentoClienteFinal = objDescuentoClienteFinal.IdDescuentoClienteFinal;
                objManDescuentoClienteFinalEdit.pDescuentoClienteFinalBE = objDescuentoClienteFinal;
                objManDescuentoClienteFinalEdit.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteFinalEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvDescuentoClienteFinal.GetFocusedRowCellValue("IdDescuentoClienteFinal").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione DescuentoClienteFinal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}