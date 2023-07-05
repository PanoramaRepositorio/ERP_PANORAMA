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

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConClasificacionProductos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProductoBE> lstProducto;
        int vProductosInactivos = 0;
        #endregion

        #region "Eventos"

        public frmConClasificacionProductos()
        {
            InitializeComponent();
        }

        private void frmConClasificacionProductos_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboFamilia, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            cboLinea.EditValue = Parametros.intNinguno;
            BSUtils.LoaderLook(cboMaterial, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            cboMaterial.EditValue = Parametros.intNinguno;
        }

        private void cboLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboSubLinea, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString())), "DescSubLineaProducto", "IdSubLineaProducto", false);
                cboSubLinea.EditValue = Parametros.intNinguno;
            }
        }

        private void cboSubLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSubLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboModelo, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString()), Convert.ToInt32(cboSubLinea.EditValue.ToString())), "DescModeloProducto", "IdModeloProducto", false);
                cboModelo.EditValue = Parametros.intNinguno;
            }
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
            btnConsultar.Enabled = false;
            int TipoReporte = 1;

            //gvProducto.Columns["CantidadCompra"].VisibleIndex = 17;

            //gvProducto.Columns["AlmacenCentral"].VisibleIndex = 18;
            //gvProducto.Columns["AlmacenTienda"].VisibleIndex = 19;
            //gvProducto.Columns["AlmacenOutlet"].VisibleIndex = 20;
            //gvProducto.Columns["AlmacenAndahuaylas"].VisibleIndex = 21;
            //gvProducto.Columns["AlmacenPrescott"].VisibleIndex = 22;
            //gvProducto.Columns["AlmacenAviacion"].VisibleIndex = 23;
            //gvProducto.Columns["AlmacenAviacion2"].VisibleIndex = 24;
            //gvProducto.Columns["AlmacenMegaPlaza"].VisibleIndex = 25;
            //gvProducto.Columns["AlmacenSanMiguel"].VisibleIndex = 28;
            //gvProducto.Columns["TotalStock"].VisibleIndex = 27;
            //gvProducto.Columns["Coleccion"].VisibleIndex = 39;



            //if (chkStock.Checked)
            //{
            //    TipoReporte = 1;
            //    //gvProducto.Columns[16].Visible = true;
            //    gvProducto.Columns[17].Visible = true;
            //    gvProducto.Columns[18].Visible = true;
            //    gvProducto.Columns[19].Visible = true;
            //    gvProducto.Columns[20].Visible = true;
            //    gvProducto.Columns[21].Visible = true;
            //    gvProducto.Columns[22].Visible = true;
            //    gvProducto.Columns[23].Visible = true;
            //    gvProducto.Columns[24].Visible = true;//ADD
            //    gvProducto.Columns[25].Visible = true;//ADD
            //    gvProducto.Columns[26].Visible = true;
            //    gvProducto.Columns[27].Visible = true;
            //    gvProducto.Columns[28].Visible = true;
            //    //gvProducto.Columns[39].Visible = true;
            //}
            //else
            //{
            //    //gvProducto.Columns[16].Visible = false;
            //    gvProducto.Columns[17].Visible = false;
            //    gvProducto.Columns[18].Visible = false;
            //    gvProducto.Columns[19].Visible = false;
            //    gvProducto.Columns[20].Visible = false;
            //    gvProducto.Columns[21].Visible = false;
            //    gvProducto.Columns[22].Visible = false;
            //    gvProducto.Columns[23].Visible = false;
            //    gvProducto.Columns[24].Visible = false;
            //    gvProducto.Columns[25].Visible = false;
            //    gvProducto.Columns[26].Visible = false;
            //    gvProducto.Columns[27].Visible = false;

            //}

            if (Convert.ToInt32(chkProductosInactivos.EditValue)==0)
            {
                vProductosInactivos = 1;
            }
            else
            {
                vProductosInactivos = 0;
            }

            gcProducto.DataSource = new ProductoBL().ListaJerarquica(Parametros.intEmpresaId, Convert.ToInt32(cboFamilia.EditValue), Convert.ToInt32(cboLinea.EditValue), Convert.ToInt32(cboSubLinea.EditValue), Convert.ToInt32(cboModelo.EditValue), Convert.ToInt32(cboMaterial.EditValue), TipoReporte);
            lblTotalRegistros.Text = gvProducto.RowCount.ToString() + " Registros";

            btnConsultar.Enabled = true;
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

        private void cboFamilia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboFamilia.EditValue != null)
            {
                BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivoFamilia(Parametros.intEmpresaId, Convert.ToInt32(cboFamilia.EditValue.ToString())), "DescLineaProducto", "IdLineaProducto", true);
            }
            
        }

        private void gvProducto_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvProducto.RowCount.ToString() + " Registros";
        }

        private void chkStock_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gcProducto_Click(object sender, EventArgs e)
        {

        }
    }
}