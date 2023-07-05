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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManBloque : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<BloqueBE> mLista = new List<BloqueBE>();

        int IdSector = 0;
        
        #endregion

        #region "Eventos"

        public frmManBloque()
        {
            InitializeComponent();
        }

        private void frmManBloque_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTriview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "SEC":
                    IdSector = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdSector == 0)
                {
                    XtraMessageBox.Show("Seleccione un sector.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManBloqueEdit objManBloque = new frmManBloqueEdit();
                objManBloque.lstBloque = mLista;
                objManBloque.pOperacion = frmManBloqueEdit.Operacion.Nuevo;
                objManBloque.IdSector = IdSector;
                objManBloque.IdBloque = 0;
                objManBloque.StartPosition = FormStartPosition.CenterParent;
                objManBloque.ShowDialog();
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
                        BloqueBE objE_Bloque = new BloqueBE();
                        objE_Bloque.IdBloque = int.Parse(gvBloque.GetFocusedRowCellValue("IdBloque").ToString());
                        objE_Bloque.Usuario = Parametros.strUsuarioLogin;
                        objE_Bloque.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Bloque.IdEmpresa = Parametros.intEmpresaId;

                        BloqueBL objBL_Bloque = new BloqueBL();
                        objBL_Bloque.Elimina(objE_Bloque);
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

                List<ReporteBloqueBE> lstReporte = null;
                lstReporte = new ReporteBloqueBL().Listado(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptBloque = new RptVistaReportes();
                        objRptBloque.VerRptBloque(lstReporte);
                        objRptBloque.ShowDialog();
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
            string _fileName = "ListadoBloques";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBloque.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvBloque_DoubleClick(object sender, EventArgs e)
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
            nuevoNodo.Text = "ALMACEN DE BULTOS";
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

        private void Cargar()
        {
            mLista = new BloqueBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos, IdSector);
            gcBloque.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvBloque.RowCount > 0)
            {
                BloqueBE objBloque = new BloqueBE();
                objBloque.IdAlmacen = int.Parse(gvBloque.GetFocusedRowCellValue("IdAlmacen").ToString());
                objBloque.IdTienda = int.Parse(gvBloque.GetFocusedRowCellValue("IdTienda").ToString());
                objBloque.IdSector = int.Parse(gvBloque.GetFocusedRowCellValue("IdSector").ToString());
                objBloque.IdBloque = int.Parse(gvBloque.GetFocusedRowCellValue("IdBloque").ToString());
                objBloque.DescBloque = gvBloque.GetFocusedRowCellValue("DescBloque").ToString();
                objBloque.FlagEstado = Convert.ToBoolean(gvBloque.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManBloqueEdit objManBloqueEdit = new frmManBloqueEdit();
                objManBloqueEdit.pOperacion = frmManBloqueEdit.Operacion.Modificar;
                objManBloqueEdit.IdSector = IdSector;
                objManBloqueEdit.IdBloque = objBloque.IdBloque;
                objManBloqueEdit.pBloqueBE = objBloque;
                objManBloqueEdit.StartPosition = FormStartPosition.CenterParent;
                objManBloqueEdit.ShowDialog();

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

            if (gvBloque.GetFocusedRowCellValue("IdBloque").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Bloque", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        

    }
}