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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManDescuentoClientePromocion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<DescuentoClientePromocionBE> mLista = new List<DescuentoClientePromocionBE>();

        #endregion

        #region "Eventos"

        public frmManDescuentoClientePromocion()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClientePromocion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDescuentoClientePromocionEdit objManDescuentoClientePromocion = new frmManDescuentoClientePromocionEdit();
                //objManDescuentoClientePromocion.pDescuentoClientePromocionBE = mLista;
                objManDescuentoClientePromocion.pOperacion = frmManDescuentoClientePromocionEdit.Operacion.Nuevo;
                objManDescuentoClientePromocion.IdDescuentoClientePromocion = 0;
                objManDescuentoClientePromocion.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClientePromocion.ShowDialog();
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
                        DescuentoClientePromocionBE objE_DescuentoClientePromocion = new DescuentoClientePromocionBE();
                        objE_DescuentoClientePromocion.IdDescuentoClientePromocion = int.Parse(gvDescuentoClientePromocion.GetFocusedRowCellValue("IdDescuentoClientePromocion").ToString());
                        objE_DescuentoClientePromocion.Usuario = Parametros.strUsuarioLogin;
                        objE_DescuentoClientePromocion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DescuentoClientePromocion.IdEmpresa = Parametros.intEmpresaId;

                        DescuentoClientePromocionBL objBL_DescuentoClientePromocion = new DescuentoClientePromocionBL();
                        objBL_DescuentoClientePromocion.Elimina(objE_DescuentoClientePromocion);
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

            //    List<ErpPanoramaServicios.ReporteDescuentoClientePromocionBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteDescuentoClientePromocion_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDescuentoClientePromocion = new RptVistaReportes();
            //            objRptDescuentoClientePromocion.VerRptDescuentoClientePromocion(lstReporte);
            //            objRptDescuentoClientePromocion.ShowDialog();
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
            string _fileName = "ListadoDescuentoClientePromocions";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoClientePromocion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescuentoClientePromocion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DescuentoClientePromocionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDescuentoClientePromocion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvDescuentoClientePromocion.RowCount > 0)
            {
                DescuentoClientePromocionBE objDescuentoClientePromocion = new DescuentoClientePromocionBE();
                objDescuentoClientePromocion.IdDescuentoClientePromocion = int.Parse(gvDescuentoClientePromocion.GetFocusedRowCellValue("IdDescuentoClientePromocion").ToString());
                objDescuentoClientePromocion.Descripcion = gvDescuentoClientePromocion.GetFocusedRowCellValue("Descripcion").ToString();
                objDescuentoClientePromocion.IdTipoCliente = int.Parse(gvDescuentoClientePromocion.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objDescuentoClientePromocion.FechaInicio = DateTime.Parse(gvDescuentoClientePromocion.GetFocusedRowCellValue("FechaInicio").ToString());
                objDescuentoClientePromocion.FechaFin = DateTime.Parse(gvDescuentoClientePromocion.GetFocusedRowCellValue("FechaFin").ToString());
                objDescuentoClientePromocion.Descuento = decimal.Parse(gvDescuentoClientePromocion.GetFocusedRowCellValue("Descuento").ToString());
                objDescuentoClientePromocion.Observacion = gvDescuentoClientePromocion.GetFocusedRowCellValue("Observacion").ToString();
                objDescuentoClientePromocion.FlagEstado = Convert.ToBoolean(gvDescuentoClientePromocion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManDescuentoClientePromocionEdit objManDescuentoClientePromocionEdit = new frmManDescuentoClientePromocionEdit();
                objManDescuentoClientePromocionEdit.pOperacion = frmManDescuentoClientePromocionEdit.Operacion.Modificar;
                objManDescuentoClientePromocionEdit.IdDescuentoClientePromocion = objDescuentoClientePromocion.IdDescuentoClientePromocion;
                objManDescuentoClientePromocionEdit.pDescuentoClientePromocionBE = objDescuentoClientePromocion;
                objManDescuentoClientePromocionEdit.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClientePromocionEdit.ShowDialog();

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

            if (gvDescuentoClientePromocion.GetFocusedRowCellValue("IdDescuentoClientePromocion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione DescuentoClientePromocion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarBusqueda()
        {
            gcDescuentoClientePromocion.DataSource = mLista.Where(obj =>
                                                   obj.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion

        private void AgregarCodigotoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}