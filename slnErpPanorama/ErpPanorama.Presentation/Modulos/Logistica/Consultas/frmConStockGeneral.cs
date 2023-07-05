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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConStockGeneral : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProductoBE> lstProducto;

        #endregion

        #region "Eventos"

        public frmConStockGeneral()
        {
            InitializeComponent();
        }
        private void frmConStockGeneral_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProductos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;

            btnConsultar.Enabled = false;
            gcProducto.DataSource = new ProductoBL().StockGeneral(Parametros.intEmpresaId);
            lblTotalRegistros.Text = gvProducto.RowCount.ToString() + " Registros";

            btnConsultar.Enabled = true;
            Cursor = Cursors.Default;
        }

        public void InicializarModificar()
        {
            if (gvProducto.RowCount > 0)
            {
                ProductoBE objProducto = new ProductoBE();
                objProducto.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                objProducto.CodigoProveedor = gvProducto.GetFocusedRowCellValue("CodigoProveedor").ToString();

                frmManProductoEdit objManProductoEdit = new frmManProductoEdit();
                objManProductoEdit.pOperacion = frmManProductoEdit.Operacion.Modificar;
                objManProductoEdit.IdProducto = objProducto.IdProducto;
                objManProductoEdit.CodigoProveedor = objProducto.CodigoProveedor;
                objManProductoEdit.StartPosition = FormStartPosition.CenterParent;
                if(Parametros.intPerfilId== Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteCompras)
                    objManProductoEdit.btnGrabar.Enabled = true;
                else
                    objManProductoEdit.btnGrabar.Enabled = false;
                objManProductoEdit.ShowDialog();
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

        #endregion

        private void gvProducto_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvProducto.RowCount.ToString() + " Registros";
        }

        private void chkStock_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void detalleTransitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvProducto.GetFocusedRowCellValue("IdProducto").ToString();

            frmconStockTransitov2 objfrmconStockTransitov2 = new frmconStockTransitov2();
            objfrmconStockTransitov2.IdProdcuto= Int32.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
            objfrmconStockTransitov2.ShowDialog();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}