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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegCajaVacia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<CajaVaciaBE> mLista = new List<CajaVaciaBE>();

        int IdUbicacion = 0;
        int IdPiso = 0;

        #endregion

        #region "Eventos"

        public frmRegCajaVacia()
        {
            InitializeComponent();
        }

        private void frmRegCajaVacia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTriview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "UBI":
                    IdUbicacion = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    CargaTreeViewPiso(e.Node);
                    break;
                case "PIS":
                    IdPiso = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdUbicacion == 0)
                {
                    XtraMessageBox.Show("Seleccione una Ubicacion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IdPiso == 0)
                {
                    XtraMessageBox.Show("Seleccione un Piso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmRegCajaVaciaEdit objManCajaVacia = new frmRegCajaVaciaEdit();
                objManCajaVacia.pOperacion = frmRegCajaVaciaEdit.Operacion.Nuevo;
                objManCajaVacia.IdUbicacion = IdUbicacion;
                objManCajaVacia.IdPiso = IdPiso;
                objManCajaVacia.IdCajaVacia = 0;
                objManCajaVacia.StartPosition = FormStartPosition.CenterParent;
                objManCajaVacia.ShowDialog();
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
                        CajaVaciaBE objE_CajaVacia = new CajaVaciaBE();
                        objE_CajaVacia.IdCajaVacia = int.Parse(gvCajaVacia.GetFocusedRowCellValue("IdCajaVacia").ToString());
                        objE_CajaVacia.Usuario = Parametros.strUsuarioLogin;
                        objE_CajaVacia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CajaVacia.IdEmpresa = Parametros.intEmpresaId;

                        CajaVaciaBL objBL_CajaVacia = new CajaVaciaBL();
                        objBL_CajaVacia.Elimina(objE_CajaVacia);
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

                List<ReporteCajaVaciaBE> lstReporte = null;
                lstReporte = new ReporteCajaVaciaBL().Listado(Parametros.intEmpresaId,IdUbicacion,IdPiso);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCajaVacia = new RptVistaReportes();
                        objRptCajaVacia.VerRptCajaVacia(lstReporte);
                        objRptCajaVacia.ShowDialog();
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
            string _fileName = "ListadoCajaVacia";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCajaVacia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCajaVacia_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CajaVaciaBE objE_CajaVacia = null;
                objE_CajaVacia = new CajaVaciaBL().SeleccionaCodigo(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                if (objE_CajaVacia != null)
                {
                    Position_TreeView(objE_CajaVacia.DescUbicacion, objE_CajaVacia.DescPiso);
                    int rowHandle = GetRowHandleByColumnValue(gvCajaVacia, "CodigoProveedor", txtCodigo.Text.Trim());
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        gvCajaVacia.FocusedColumn = gvCajaVacia.Columns.ColumnByFieldName("CodigoProveedor");
                        gvCajaVacia.FocusedRowHandle = rowHandle;
                        gvCajaVacia.ShowEditor();
                    }

                }
                else
                {
                    XtraMessageBox.Show("El código de producto no existe en ninguna ubicación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region "Metodos"

        private int GetRowHandleByColumnValue(GridView view, string ColumnFieldName, object value)
        {
            int result = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
            for (int i = 0; i < view.RowCount; i++)
                if (view.GetDataRow(i)[ColumnFieldName].Equals(value))
                    return i;
            return result;
        }


        private void CargaTriview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "ALMACEN CAJAS VACIAS";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<UbicacionBE> lstUbicacion = null;
            lstUbicacion = new UbicacionBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId);
            foreach (var item in lstUbicacion)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescUbicacion;
                nuevoNodoChild.Tag = "UBI" + item.IdUbicacion.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);
            }

            tvwDatos.ExpandAll();
        }

        void CargaTreeViewPiso(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            List<PisoBE> lstPiso = null;
            lstPiso = new PisoBL().ListaTodosActivo(Parametros.intEmpresaId, IdUbicacion);
            foreach (var item in lstPiso)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 2;
                nuevoNodoChild.SelectedImageIndex = 2;
                nuevoNodoChild.Text = item.DescPiso;
                nuevoNodoChild.Tag = "PIS" + item.IdPiso.ToString();
                nodo.Nodes.Add(nuevoNodoChild);
            }
        }

        private void Cargar()
        {
            DataTable dtCajaVacia = new DataTable();
            dtCajaVacia = FuncionBase.ToDataTable(new CajaVaciaBL().ListaTodosActivo(Parametros.intEmpresaId, IdUbicacion, IdPiso));
            gcCajaVacia.DataSource = dtCajaVacia;

            //mLista = objServicio.CajaVacia_ListaTodosActivo(Parametros.intEmpresaId, IdUbicacion, IdPiso);
            //gcCajaVacia.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCajaVacia.RowCount > 0)
            {
                CajaVaciaBE objCajaVacia = new CajaVaciaBE();
                objCajaVacia.IdCajaVacia = int.Parse(gvCajaVacia.GetFocusedRowCellValue("IdCajaVacia").ToString());

                frmRegCajaVaciaEdit objManCajaVaciaEdit = new frmRegCajaVaciaEdit();
                objManCajaVaciaEdit.pOperacion = frmRegCajaVaciaEdit.Operacion.Modificar;
                objManCajaVaciaEdit.IdCajaVacia = objCajaVacia.IdCajaVacia;
                objManCajaVaciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManCajaVaciaEdit.ShowDialog();

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

            if (gvCajaVacia.GetFocusedRowCellValue("IdCajaVacia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una CajaVacia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        void Position_TreeView(string Ubicacion, string Piso)
        {
            CargaTriview();

            TreeNodeCollection nodes;

            nodes = this.tvwDatos.Nodes;
            foreach (TreeNode n in nodes)
            {
                foreach (TreeNode tn in n.Nodes)
                {
                    if (tn.Text.Trim() == Ubicacion.ToString().Trim())
                    {
                        this.tvwDatos.SelectedNode = tn;
                        nodes = this.tvwDatos.SelectedNode.Nodes;
                        foreach (TreeNode tn1 in nodes)
                        {
                            if (tn1.Text.Trim() == Piso.ToString().Trim())
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