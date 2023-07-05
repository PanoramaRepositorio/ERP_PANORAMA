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
    public partial class frmRegTrasladoBulto : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<BultoBE> mLista = new List<BultoBE>();

        int IdSector = 0;
        int IdBloque = 0;

        #endregion

        #region "Eventos"

        public frmRegTrasladoBulto()
        {
            InitializeComponent();
        }

        private void frmRegTrasladoBulto_Load(object sender, EventArgs e)
        {
            CargaTriview();
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

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaBultosRecibidos";
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

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroBulto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BultoBE objE_Bulto = null;
                objE_Bulto = new BultoBL().SeleccionaNumeroBulto(Parametros.intEmpresaId, txtNumeroBulto.Text.Trim(), Parametros.intBULRecibido);
                if (objE_Bulto != null)
                {
                    Position_TreeView(objE_Bulto.DescSector, objE_Bulto.DescBloque);
                }
                else
                {
                    XtraMessageBox.Show("El número de bulto no existe en ninguna ubicación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gvBulto_DoubleClick(object sender, EventArgs e)
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

        public void InicializarModificar()
        {
            if (gvBulto.RowCount > 0)
            {
                int IdBulto = int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString());

                frmRegBultoEdit objManBultoEdit = new frmRegBultoEdit();
                objManBultoEdit.pOperacion = frmRegBultoEdit.Operacion.Modificar;
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
        
    }
}