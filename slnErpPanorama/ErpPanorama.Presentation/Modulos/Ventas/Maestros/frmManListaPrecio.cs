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
    public partial class frmManListaPrecio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<ListaPrecioBE> mLista = new List<ListaPrecioBE>();

        #endregion

        #region "Eventos"

        public frmManListaPrecio()
        {
            InitializeComponent();
        }

        private void frmManListaPrecio_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId; //Parametros.intIdPanoramaDistribuidores;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManListaPrecioEdit objManListaPrecio = new frmManListaPrecioEdit();
                objManListaPrecio.pOperacion = frmManListaPrecioEdit.Operacion.Nuevo;
                objManListaPrecio.IdListaPrecio = 0;
                objManListaPrecio.StartPosition = FormStartPosition.CenterParent;
                objManListaPrecio.ShowDialog();
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
                        ListaPrecioBE objE_ListaPrecio = new ListaPrecioBE();
                        objE_ListaPrecio.IdListaPrecio = int.Parse(gvListaPrecio.GetFocusedRowCellValue("IdListaPrecio").ToString());
                        objE_ListaPrecio.Usuario = Parametros.strUsuarioLogin;
                        objE_ListaPrecio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ListaPrecio.IdEmpresa = Parametros.intEmpresaId;

                        ListaPrecioBL objBL_ListaPrecio = new ListaPrecioBL();
                        objBL_ListaPrecio.Elimina(objE_ListaPrecio);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                //List<ErpPanoramaServicios.ReporteListaPrecioBE> lstReporte = null;
                //lstReporte = objServicio.ReporteListaPrecio_Listado(Parametros.intEmpresaId);

                //if (lstReporte != null)
                //{
                //    if (lstReporte.Count > 0)
                //    {
                //        RptVistaReportes objRptListaPrecio = new RptVistaReportes();
                //        objRptListaPrecio.VerRptListaPrecio(lstReporte);
                //        objRptListaPrecio.ShowDialog();
                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoListaPrecioes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvListaPrecio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvListaPrecio_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                Cargar();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ListaPrecioBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), 0);
            gcListaPrecio.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvListaPrecio.RowCount > 0)
            {
                ListaPrecioBE objListaPrecio = new ListaPrecioBE();

                objListaPrecio.IdEmpresa = int.Parse(gvListaPrecio.GetFocusedRowCellValue("IdEmpresa").ToString());
                objListaPrecio.IdTienda = int.Parse(gvListaPrecio.GetFocusedRowCellValue("IdTienda").ToString());
                objListaPrecio.IdListaPrecio = int.Parse(gvListaPrecio.GetFocusedRowCellValue("IdListaPrecio").ToString());
                objListaPrecio.DescListaPrecio = gvListaPrecio.GetFocusedRowCellValue("DescListaPrecio").ToString();
                objListaPrecio.FlagEstado = Convert.ToBoolean(gvListaPrecio.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManListaPrecioEdit objManListaPrecioEdit = new frmManListaPrecioEdit();
                objManListaPrecioEdit.pOperacion = frmManListaPrecioEdit.Operacion.Modificar;
                objManListaPrecioEdit.IdListaPrecio = objListaPrecio.IdListaPrecio;
                objManListaPrecioEdit.pListaPrecioBE = objListaPrecio;
                objManListaPrecioEdit.StartPosition = FormStartPosition.CenterParent;
                objManListaPrecioEdit.ShowDialog();

                //Cargar();
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

            if (gvListaPrecio.GetFocusedRowCellValue("IdListaPrecio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Linea Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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