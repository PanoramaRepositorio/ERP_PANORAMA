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

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<BultoBE> mLista = new List<BultoBE>();

        int IdSector = 0;
        int IdBloque = 0;
        
        #endregion

        #region "Eventos"

        public frmRegBulto()
        {
            InitializeComponent();
        }

        private void frmRegBulto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTriview();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
               if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin =="gcuba" || Parametros.strUsuarioLogin == "adavila" || Parametros.strUsuarioLogin == "gdavila")
                {
                    frmRegBultoGestionEdit objManBulto = new frmRegBultoGestionEdit();
                    objManBulto.pOperacion = frmRegBultoGestionEdit.Operacion.Nuevo;
                    objManBulto.IdBulto = 0;
                    objManBulto.StartPosition = FormStartPosition.CenterParent;
                    objManBulto.ShowDialog();
                    Cargar();
                }
                else
                {
                    XtraMessageBox.Show("No se puede agregar bultos, el ingreso debe ser por factura de compra o desde Anaquel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


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
                        BultoBE objE_Bulto = null;
                        objE_Bulto = new BultoBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(gvBulto.GetFocusedRowCellValue("IdBulto").ToString()), Parametros.intBULRecibido);
                        objE_Bulto.Usuario = Parametros.strUsuarioLogin;
                        objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Bulto.IdEmpresa = Parametros.intEmpresaId;

                        BultoBL objBL_Bulto = new BultoBL();
                        objBL_Bulto.Elimina(objE_Bulto);
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
            
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoSolicitudProductos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "SEC":
                    IdSector = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeViewBloque(e.Node);
                    break;
                case "BLQ":
                    IdBloque = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void gvBulto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumeroBulto_KeyDown(object sender, KeyEventArgs e)
        {
            CargarBusquedaNumeroBulto();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            CargarBusquedaCodigo();
        }

        #endregion

        #region "Metodos"

        private void CargaTriview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "ALMACEN BULTOS";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<SectorBE> lstSector = null;
            lstSector = new SectorBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos);
            foreach (var item in lstSector)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescSector;
                nuevoNodoChild.Tag = "SEC" + item.IdSector.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);
            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeViewBloque(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<BloqueBE> lstBloque = null;
            lstBloque = new BloqueBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos, IdSector);
            foreach (var item in lstBloque)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescBloque;
                nuevoNodoChild.Tag = "BLQ" + item.IdBloque.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            mLista = new BultoBL().ListaUbicacion(Parametros.intEmpresaId, Parametros.intAlmBultos, IdSector, IdBloque);
            gcBulto.DataSource = mLista;
        }

        private void CargarBusquedaNumeroBulto()
        {
            gcBulto.DataSource = mLista.Where(obj =>
                                                   obj.NumeroBulto.ToUpper().Contains(txtNumeroBulto.Text.ToUpper())).ToList();
        }

        private void CargarBusquedaCodigo()
        {
            gcBulto.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvBulto.RowCount > 0)
            {
                int IdBulto = int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString());

                frmRegBultoGestionEdit objManBultoEdit = new frmRegBultoGestionEdit();
                objManBultoEdit.pOperacion = frmRegBultoGestionEdit.Operacion.Modificar;
                objManBultoEdit.IdBulto = IdBulto;
                objManBultoEdit.SituacionBulto = Parametros.intBULRecibido;
                objManBultoEdit.StartPosition = FormStartPosition.CenterParent;
                objManBultoEdit.ShowDialog();

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

            if (gvBulto.GetFocusedRowCellValue("IdBulto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Bulto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        void Position_TreeView(string Sector, string Bloque)
        {
            //CargaTriview();

            TreeNodeCollection nodes;

            nodes = this.tvwDatos.Nodes;
            foreach (TreeNode n in nodes)
            {
                foreach (TreeNode tn in n.Nodes)
                {
                    if (tn.Text.Trim() == Sector.ToString().Trim())
                    {
                        this.tvwDatos.SelectedNode = tn;
                        nodes = this.tvwDatos.SelectedNode.Nodes;
                        foreach (TreeNode tn1 in nodes)
                        {
                            if (tn1.Text.Trim() == Bloque.ToString().Trim())
                            {
                                this.tvwDatos.SelectedNode = tn1;
                                this.tvwDatos.Focus();
                            }
                        }
                    }
                }
            }
        }



        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}