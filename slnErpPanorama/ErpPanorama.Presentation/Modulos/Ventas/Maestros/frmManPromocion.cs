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
    public partial class frmManPromocion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<PromocionBE> mLista = new List<PromocionBE>();

        #endregion

        #region "Eventos"

        public frmManPromocion()
        {
            InitializeComponent();
        }

        private void frmManPromocion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromocionEdit objManPromocion = new frmManPromocionEdit();
                objManPromocion.pOperacion = frmManPromocionEdit.Operacion.Nuevo;
                objManPromocion.IdPromocion = 0;
                objManPromocion.StartPosition = FormStartPosition.CenterParent;
                objManPromocion.ShowDialog();
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
                        PromocionBE objE_Promocion = new PromocionBE();
                        objE_Promocion.IdPromocion = int.Parse(gvPromocion.GetFocusedRowCellValue("IdPromocion").ToString());
                        objE_Promocion.Usuario = Parametros.strUsuarioLogin;
                        objE_Promocion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Promocion.IdEmpresa = Parametros.intEmpresaId;

                        PromocionBL objBL_Promocion = new PromocionBL();
                        objBL_Promocion.Elimina(objE_Promocion);
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

            //    List<ErpPanoramaServicios.ReportePromocionBE> lstReporte = null;
            //    lstReporte = objServicio.ReportePromocion_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPromocion = new RptVistaReportes();
            //            objRptPromocion.VerRptPromocion(lstReporte);
            //            objRptPromocion.ShowDialog();
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
            string _fileName = "ListadoPromocion";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPromocion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PromocionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcPromocion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvPromocion.RowCount > 0)
            {
                PromocionBE objPromocion = new PromocionBE();
                objPromocion.IdPromocion = int.Parse(gvPromocion.GetFocusedRowCellValue("IdPromocion").ToString());
                objPromocion.IdFormaPago = int.Parse(gvPromocion.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocion.IdTipoCliente = int.Parse(gvPromocion.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocion.MontoMin = decimal.Parse(gvPromocion.GetFocusedRowCellValue("MontoMin").ToString());
                objPromocion.MontoMax = decimal.Parse(gvPromocion.GetFocusedRowCellValue("MontoMax").ToString());

                frmManPromocionEdit objManPromocionEdit = new frmManPromocionEdit();
                objManPromocionEdit.pOperacion = frmManPromocionEdit.Operacion.Modificar;
                objManPromocionEdit.IdPromocion = objPromocion.IdPromocion;
                objManPromocionEdit.pPromocionBE = objPromocion;
                objManPromocionEdit.StartPosition = FormStartPosition.CenterParent;
                objManPromocionEdit.ShowDialog();

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

            if (gvPromocion.GetFocusedRowCellValue("IdPromocion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Promocion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}