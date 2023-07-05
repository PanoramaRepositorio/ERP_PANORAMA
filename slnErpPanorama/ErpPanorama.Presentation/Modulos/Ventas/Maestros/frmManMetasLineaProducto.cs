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
    public partial class frmManMetasLineaProducto : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<MetasLineaProductoBE> mLista = new List<MetasLineaProductoBE>();

        #endregion

        #region "Eventos"

        public frmManMetasLineaProducto()
        {
            InitializeComponent();
        }

        private void frmManMetasLineaProducto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMetasLineaProductoEdit objManMetasLineaProducto = new frmManMetasLineaProductoEdit();
                objManMetasLineaProducto.lstMetasLineaProducto = mLista;
                objManMetasLineaProducto.pOperacion = frmManMetasLineaProductoEdit.Operacion.Nuevo;
                objManMetasLineaProducto.IdMetasLineaProducto = 0;
                objManMetasLineaProducto.StartPosition = FormStartPosition.CenterParent;
                objManMetasLineaProducto.ShowDialog();
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
                        MetasLineaProductoBE objE_MetasLineaProducto = new MetasLineaProductoBE();
                        objE_MetasLineaProducto.IdMetasLineaProducto = int.Parse(gvMetasLineaProducto.GetFocusedRowCellValue("IdMetasLineaProducto").ToString());
                        objE_MetasLineaProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_MetasLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MetasLineaProducto.IdEmpresa = Parametros.intEmpresaId;

                        MetasLineaProductoBL objBL_MetasLineaProducto = new MetasLineaProductoBL();
                        objBL_MetasLineaProducto.Elimina(objE_MetasLineaProducto);
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
                //Cursor = Cursors.WaitCursor;

                //List<ReporteMetasLineaProductoBE> lstReporte = null;
                //lstReporte = new ReporteMetasLineaProductoBL().Listado(Parametros.intEmpresaId);

                //if (lstReporte != null)
                //{
                //    if (lstReporte.Count > 0)
                //    {
                //        RptVistaReportes objRptMetasLineaProducto = new RptVistaReportes();
                //        objRptMetasLineaProducto.VerRptMetasLineaProducto(lstReporte);
                //        objRptMetasLineaProducto.ShowDialog();
                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //Cursor = Cursors.Default;
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
            string _fileName = "ListadoMetasLineaProducto";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMetasLineaProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMetasLineaProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MetasLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMetasLineaProducto.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMetasLineaProducto.DataSource = mLista.Where(obj => obj.DescVendedor.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.NombreMes.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMetasLineaProducto.RowCount > 0)
            {
                MetasLineaProductoBE objMetasLineaProducto = new MetasLineaProductoBE();
                objMetasLineaProducto.IdMetasLineaProducto = int.Parse(gvMetasLineaProducto.GetFocusedRowCellValue("IdMetasLineaProducto").ToString());

                frmManMetasLineaProductoEdit objManMetasLineaProductoEdit = new frmManMetasLineaProductoEdit();
                objManMetasLineaProductoEdit.pOperacion = frmManMetasLineaProductoEdit.Operacion.Modificar;
                objManMetasLineaProductoEdit.IdMetasLineaProducto = objMetasLineaProducto.IdMetasLineaProducto;
                objManMetasLineaProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManMetasLineaProductoEdit.ShowDialog();

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

            if (gvMetasLineaProducto.GetFocusedRowCellValue("IdMetasLineaProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Unidad de Medida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}