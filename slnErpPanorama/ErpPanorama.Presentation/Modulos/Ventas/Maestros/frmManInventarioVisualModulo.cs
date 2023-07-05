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
    public partial class frmManInventarioVisualModulo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<InventarioVisualModuloBE> mLista = new List<InventarioVisualModuloBE>();

        int IdInventarioVisualBloque = 0;
        int IdTienda = 0;

        #endregion

        #region "Eventos"

        public frmManInventarioVisualModulo()
        {
            InitializeComponent();
        }

        private void frmManInventarioVisualModulo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTriview();
        }


        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "TIE":
                    IdTienda = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
                case "BLO":
                    IdTienda = Convert.ToInt32(e.Node.Parent.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    IdInventarioVisualBloque = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdInventarioVisualBloque == 0)
                {
                    XtraMessageBox.Show("Seleccione un Bloque.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManInventarioVisualModuloEdit objManInventarioVisualModulo = new frmManInventarioVisualModuloEdit();
                objManInventarioVisualModulo.lstInventarioVisualModulo = mLista;
                objManInventarioVisualModulo.pOperacion = frmManInventarioVisualModuloEdit.Operacion.Nuevo;
                objManInventarioVisualModulo.IdTienda = IdTienda;
                objManInventarioVisualModulo.IdInventarioVisualBloque = IdInventarioVisualBloque;
                objManInventarioVisualModulo.IdInventarioVisualModulo = 0;
                objManInventarioVisualModulo.StartPosition = FormStartPosition.CenterParent;
                objManInventarioVisualModulo.ShowDialog();
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
                        InventarioVisualModuloBE objE_InventarioVisualModulo = new InventarioVisualModuloBE();
                        objE_InventarioVisualModulo.IdInventarioVisualModulo = int.Parse(gvInventarioVisualModulo.GetFocusedRowCellValue("IdInventarioVisualModulo").ToString());
                        objE_InventarioVisualModulo.Usuario = Parametros.strUsuarioLogin;
                        objE_InventarioVisualModulo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InventarioVisualModulo.IdEmpresa = Parametros.intEmpresaId;

                        InventarioVisualModuloBL objBL_InventarioVisualModulo = new InventarioVisualModuloBL();
                        objBL_InventarioVisualModulo.Elimina(objE_InventarioVisualModulo);
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
            //Cargar();
            CargaTriview();
        }

        private void tlbMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteInventarioVisualModuloBE> lstReporte = null;
            //    lstReporte = new ReporteInventarioVisualModuloBL().Listado(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptInventarioVisualModulo = new RptVistaReportes();
            //            objRptInventarioVisualModulo.VerRptInventarioVisualModulo(lstReporte);
            //            objRptInventarioVisualModulo.ShowDialog();
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
            string _fileName = "ListadoInventarioVisualModulos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventarioVisualModulo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInventarioVisualModulo_DoubleClick(object sender, EventArgs e)
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

            List<TiendaBE> lstTienda = null;
            lstTienda = new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId);

            foreach (TiendaBE itemT in lstTienda)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = itemT.DescTienda;
                nuevoNodo.Tag = "TIE" + itemT.IdTienda.ToString();
                nuevoNodo.ImageIndex = 0;
                nuevoNodo.SelectedImageIndex = 0;
                tvwDatos.Nodes.Add(nuevoNodo);

                List<InventarioVisualBloqueBE> lstInventarioVisualBloque = null;
                lstInventarioVisualBloque = new InventarioVisualBloqueBL().ListaTodosActivoTienda(itemT.IdTienda);
                foreach (var item in lstInventarioVisualBloque)
                {
                    TreeNode nuevoNodoChild = new TreeNode();
                    nuevoNodoChild.ImageIndex = 1;
                    nuevoNodoChild.SelectedImageIndex = 1;
                    nuevoNodoChild.Text = item.DescBloque;
                    nuevoNodoChild.Tag = "BLO" + item.IdInventarioVisualBloque.ToString();
                    nuevoNodo.Nodes.Add(nuevoNodoChild);
                }
            }

            tvwDatos.ExpandAll();
        }

        private void Cargar()
        {
            mLista = new InventarioVisualModuloBL().ListaTodosActivo(IdTienda, IdInventarioVisualBloque);
            gcInventarioVisualModulo.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvInventarioVisualModulo.RowCount > 0)
            {
                InventarioVisualModuloBE objInventarioVisualModulo = new InventarioVisualModuloBE();
                objInventarioVisualModulo.IdTienda = int.Parse(gvInventarioVisualModulo.GetFocusedRowCellValue("IdTienda").ToString());
                objInventarioVisualModulo.IdInventarioVisualBloque = int.Parse(gvInventarioVisualModulo.GetFocusedRowCellValue("IdInventarioVisualBloque").ToString());
                objInventarioVisualModulo.IdInventarioVisualModulo = int.Parse(gvInventarioVisualModulo.GetFocusedRowCellValue("IdInventarioVisualModulo").ToString());
                objInventarioVisualModulo.DescModulo = gvInventarioVisualModulo.GetFocusedRowCellValue("DescModulo").ToString();
                objInventarioVisualModulo.FlagEstado = Convert.ToBoolean(gvInventarioVisualModulo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManInventarioVisualModuloEdit objManInventarioVisualModuloEdit = new frmManInventarioVisualModuloEdit();
                objManInventarioVisualModuloEdit.pOperacion = frmManInventarioVisualModuloEdit.Operacion.Modificar;
                objManInventarioVisualModuloEdit.IdTienda = IdTienda;
                objManInventarioVisualModuloEdit.IdInventarioVisualBloque = IdInventarioVisualBloque;
                objManInventarioVisualModuloEdit.IdInventarioVisualModulo = objInventarioVisualModulo.IdInventarioVisualModulo;
                objManInventarioVisualModuloEdit.pInventarioVisualModuloBE = objInventarioVisualModulo;
                objManInventarioVisualModuloEdit.StartPosition = FormStartPosition.CenterParent;
                objManInventarioVisualModuloEdit.ShowDialog();

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

            if (gvInventarioVisualModulo.GetFocusedRowCellValue("IdInventarioVisualModulo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una InventarioVisualModulo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}