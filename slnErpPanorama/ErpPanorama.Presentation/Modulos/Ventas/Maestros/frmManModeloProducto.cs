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
    public partial class frmManModeloProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ModeloProductoBE> mLista = new List<ModeloProductoBE>();

        int IdLineaProducto = 0;
        int IdSubLineaProducto = 0;
        string DescLineaProducto = "";

        #endregion

        #region "Eventos"

        public frmManModeloProducto()
        {
            InitializeComponent();
        }

        private void frmManModeloProducto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTriview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "LIN":
                    IdLineaProducto = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    DescLineaProducto = e.Node.Text;
                    CargaTreeViewSubLineaProducto(e.Node);
                    break;
                case "SLI":
                    IdSubLineaProducto = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdLineaProducto == 0)
                {
                    XtraMessageBox.Show("Seleccione una línea de producto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManModeloProductoEdit objManModeloProducto = new frmManModeloProductoEdit();
                objManModeloProducto.lstModeloProducto = mLista;
                objManModeloProducto.pOperacion = frmManModeloProductoEdit.Operacion.Nuevo;
                objManModeloProducto.IdLineaProducto = IdLineaProducto;
                objManModeloProducto.IdSubLineaProducto = IdSubLineaProducto;
                objManModeloProducto.IdModeloProducto = 0;
                objManModeloProducto.StartPosition = FormStartPosition.CenterParent;
                objManModeloProducto.ShowDialog();
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
                        ModeloProductoBE objE_ModeloProducto = new ModeloProductoBE();
                        objE_ModeloProducto.IdModeloProducto = int.Parse(gvModeloProducto.GetFocusedRowCellValue("IdModeloProducto").ToString());
                        objE_ModeloProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_ModeloProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ModeloProducto.IdEmpresa = Parametros.intEmpresaId;

                        ModeloProductoBL objBL_ModeloProducto = new ModeloProductoBL();
                        objBL_ModeloProducto.Elimina(objE_ModeloProducto);
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

                List<ReporteModeloProductoBE> lstReporte = null;
                lstReporte = new ReporteModeloProductoBL().Listado(Parametros.intEmpresaId,Convert.ToInt32(IdLineaProducto));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptModeloProducto = new RptVistaReportes();
                        objRptModeloProducto.VerRptModeloProducto(lstReporte);
                        objRptModeloProducto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            string _fileName = "ListadoModeloProductoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvModeloProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvModeloProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void CargaTriview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "LINEA DE PRODUCTOS";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<LineaProductoBE> lstLineaProducto = null;
            lstLineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);
            foreach (var item in lstLineaProducto)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 0;
                nuevoNodoChild.SelectedImageIndex = 0;
                nuevoNodoChild.Text = item.DescLineaProducto;
                nuevoNodoChild.Tag = "LIN" + item.IdLineaProducto.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);
            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeViewSubLineaProducto(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<SubLineaProductoBE> lstSubLineaProducto = null;
            lstSubLineaProducto = new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, IdLineaProducto);
            foreach (var item in lstSubLineaProducto)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescSubLineaProducto;
                nuevoNodoChild.Tag = "SLI" + item.IdSubLineaProducto.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, IdLineaProducto, IdSubLineaProducto);
            gcModeloProducto.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvModeloProducto.RowCount > 0)
            {
                ModeloProductoBE objModeloProducto = new ModeloProductoBE();
                objModeloProducto.IdModeloProducto = int.Parse(gvModeloProducto.GetFocusedRowCellValue("IdModeloProducto").ToString());
                objModeloProducto.DescModeloProducto = gvModeloProducto.GetFocusedRowCellValue("DescModeloProducto").ToString();
                objModeloProducto.IdLineaProducto = int.Parse(gvModeloProducto.GetFocusedRowCellValue("IdLineaProducto").ToString());
                objModeloProducto.DescLineaProducto = gvModeloProducto.GetFocusedRowCellValue("DescLineaProducto").ToString();
                objModeloProducto.IdSubLineaProducto = IdSubLineaProducto;
                objModeloProducto.IdEmpresa = int.Parse(gvModeloProducto.GetFocusedRowCellValue("IdEmpresa").ToString());
                objModeloProducto.FlagEstado = Convert.ToBoolean(gvModeloProducto.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManModeloProductoEdit objManModeloProductoEdit = new frmManModeloProductoEdit();
                objManModeloProductoEdit.pOperacion = frmManModeloProductoEdit.Operacion.Modificar;
                objManModeloProductoEdit.IdModeloProducto = objModeloProducto.IdModeloProducto;
                objManModeloProductoEdit.pModeloProductoBE = objModeloProducto;
                objManModeloProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManModeloProductoEdit.ShowDialog();

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

            if (gvModeloProducto.GetFocusedRowCellValue("IdModeloProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Modelo de Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion        

    }
}