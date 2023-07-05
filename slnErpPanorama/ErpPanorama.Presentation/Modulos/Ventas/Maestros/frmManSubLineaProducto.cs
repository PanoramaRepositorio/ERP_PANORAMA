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
    public partial class frmManSubLineaProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SubLineaProductoBE> mLista = new List<SubLineaProductoBE>();
        int IdLineaProducto = 0;

        #endregion

        #region "Eventos"

        public frmManSubLineaProducto()
        {
            InitializeComponent();
        }

        private void frmManSubLineaProducto_Load(object sender, EventArgs e)
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

                frmManSubLineaProductoEdit objManSubLineaProducto = new frmManSubLineaProductoEdit();
                objManSubLineaProducto.lstSubLineaProducto = mLista;
                objManSubLineaProducto.pOperacion = frmManSubLineaProductoEdit.Operacion.Nuevo;
                objManSubLineaProducto.IdLineaProducto = IdLineaProducto;
                objManSubLineaProducto.IdSubLineaProducto = 0;
                objManSubLineaProducto.StartPosition = FormStartPosition.CenterParent;
                objManSubLineaProducto.ShowDialog();
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
                        SubLineaProductoBE objE_SubLineaProducto = new SubLineaProductoBE();
                        objE_SubLineaProducto.IdSubLineaProducto = int.Parse(gvSubLineaProducto.GetFocusedRowCellValue("IdSubLineaProducto").ToString());
                        objE_SubLineaProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_SubLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_SubLineaProducto.IdEmpresa = Parametros.intEmpresaId;

                        SubLineaProductoBL objBL_SubLineaProducto = new SubLineaProductoBL();
                        objBL_SubLineaProducto.Elimina(objE_SubLineaProducto);
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

            //    List<ReporteSubLineaProductoBE> lstReporte = null;
            //    lstReporte = new ReporteSubLineaProductoBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(IdLineaProducto));

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptSubLineaProducto = new RptVistaReportes();
            //            objRptSubLineaProducto.VerRptSubLineaProducto(lstReporte);
            //            objRptSubLineaProducto.ShowDialog();
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
            string _fileName = "ListadoSubLineaProductoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSubLineaProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSubLineaProducto_DoubleClick(object sender, EventArgs e)
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

        private void Cargar()
        {
            mLista = new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, IdLineaProducto);
            gcSubLineaProducto.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvSubLineaProducto.RowCount > 0)
            {
                SubLineaProductoBE objSubLineaProducto = new SubLineaProductoBE();
                objSubLineaProducto.IdSubLineaProducto = int.Parse(gvSubLineaProducto.GetFocusedRowCellValue("IdSubLineaProducto").ToString());
                objSubLineaProducto.DescSubLineaProducto = gvSubLineaProducto.GetFocusedRowCellValue("DescSubLineaProducto").ToString();
                objSubLineaProducto.IdLineaProducto = int.Parse(gvSubLineaProducto.GetFocusedRowCellValue("IdLineaProducto").ToString());
                objSubLineaProducto.DescLineaProducto = gvSubLineaProducto.GetFocusedRowCellValue("DescLineaProducto").ToString();
                objSubLineaProducto.IdEmpresa = int.Parse(gvSubLineaProducto.GetFocusedRowCellValue("IdEmpresa").ToString());
                objSubLineaProducto.FlagEstado = Convert.ToBoolean(gvSubLineaProducto.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManSubLineaProductoEdit objManSubLineaProductoEdit = new frmManSubLineaProductoEdit();
                objManSubLineaProductoEdit.pOperacion = frmManSubLineaProductoEdit.Operacion.Modificar;
                objManSubLineaProductoEdit.IdSubLineaProducto = objSubLineaProducto.IdSubLineaProducto;
                objManSubLineaProductoEdit.pSubLineaProductoBE = objSubLineaProducto;
                objManSubLineaProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManSubLineaProductoEdit.ShowDialog();

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

            if (gvSubLineaProducto.GetFocusedRowCellValue("IdSubLineaProducto").ToString() == "")
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