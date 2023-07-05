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
    public partial class frmManDescuentoClienteMayorista : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<DescuentoClienteMayoristaBE> mLista = new List<DescuentoClienteMayoristaBE>();
        
        #endregion

        #region "Eventos"

        public frmManDescuentoClienteMayorista()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClienteMayorista_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDescuentoClienteMayoristaEdit objManDescuentoClienteMayorista = new frmManDescuentoClienteMayoristaEdit();
                objManDescuentoClienteMayorista.lstDescuentoClienteMayorista = mLista;
                objManDescuentoClienteMayorista.pOperacion = frmManDescuentoClienteMayoristaEdit.Operacion.Nuevo;
                objManDescuentoClienteMayorista.IdDescuentoClienteMayorista = 0;
                objManDescuentoClienteMayorista.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteMayorista.ShowDialog();
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
                        DescuentoClienteMayoristaBE objE_DescuentoClienteMayorista = new DescuentoClienteMayoristaBE();
                        objE_DescuentoClienteMayorista.IdDescuentoClienteMayorista = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdDescuentoClienteMayorista").ToString());
                        objE_DescuentoClienteMayorista.Usuario = Parametros.strUsuarioLogin;
                        objE_DescuentoClienteMayorista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DescuentoClienteMayorista.IdEmpresa = Parametros.intEmpresaId;

                        DescuentoClienteMayoristaBL objBL_DescuentoClienteMayorista = new DescuentoClienteMayoristaBL();
                        objBL_DescuentoClienteMayorista.Elimina(objE_DescuentoClienteMayorista);
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

            //    List<ErpPanoramaServicios.ReporteDescuentoClienteMayoristaBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteDescuentoClienteMayorista_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDescuentoClienteMayorista = new RptVistaReportes();
            //            objRptDescuentoClienteMayorista.VerRptDescuentoClienteMayorista(lstReporte);
            //            objRptDescuentoClienteMayorista.ShowDialog();
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
            string _fileName = "ListadoDescuentoClienteMayoristas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoClienteMayorista.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescuentoClienteMayorista_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DescuentoClienteMayoristaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboFormaPago.EditValue), Convert.ToInt32(cboLineaProducto.EditValue));
            gcDescuentoClienteMayorista.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvDescuentoClienteMayorista.RowCount > 0)
            {
                DescuentoClienteMayoristaBE objDescuentoClienteMayorista = new DescuentoClienteMayoristaBE();
                objDescuentoClienteMayorista.IdDescuentoClienteMayorista = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdDescuentoClienteMayorista").ToString());
                objDescuentoClienteMayorista.IdFormaPago = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdFormaPago").ToString());
                objDescuentoClienteMayorista.IdLineaProducto = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdLineaProducto").ToString());
                objDescuentoClienteMayorista.MontoMin = decimal.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("MontoMin").ToString());
                objDescuentoClienteMayorista.MontoMax = decimal.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("MontoMax").ToString());
                objDescuentoClienteMayorista.PorDescuento = decimal.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("PorDescuento").ToString());
                objDescuentoClienteMayorista.FlagPreVenta = Convert.ToBoolean(gvDescuentoClienteMayorista.GetFocusedRowCellValue("FlagPreVenta").ToString());
                objDescuentoClienteMayorista.FlagVenta = Convert.ToBoolean(gvDescuentoClienteMayorista.GetFocusedRowCellValue("FlagVenta").ToString());
                objDescuentoClienteMayorista.FlagEstado = Convert.ToBoolean(gvDescuentoClienteMayorista.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManDescuentoClienteMayoristaEdit objManDescuentoClienteMayoristaEdit = new frmManDescuentoClienteMayoristaEdit();
                objManDescuentoClienteMayoristaEdit.pOperacion = frmManDescuentoClienteMayoristaEdit.Operacion.Modificar;
                objManDescuentoClienteMayoristaEdit.IdDescuentoClienteMayorista = objDescuentoClienteMayorista.IdDescuentoClienteMayorista;
                objManDescuentoClienteMayoristaEdit.pDescuentoClienteMayoristaBE = objDescuentoClienteMayorista;
                objManDescuentoClienteMayoristaEdit.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteMayoristaEdit.ShowDialog();

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

            if (gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdDescuentoClienteMayorista").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione DescuentoClienteMayorista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
        
    }
}