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

namespace ErpPanorama.Presentation.Modulos.Seguridad
{
    public partial class frmManPerfil : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PerfilBE> mLista = new List<PerfilBE>();
        
        #endregion

        #region "Eventos"

        public frmManPerfil()
        {
            InitializeComponent();
        }

        private void frmManPerfil_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            ConfigurarGrilla();
            Cargar();
            this.Location = new Point(0, 0);
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPerfilEdit objManPerfil = new frmManPerfilEdit();
                objManPerfil.pOperacion = frmManPerfilEdit.Operacion.Nuevo;
                objManPerfil.IdPerfil = 0;
                objManPerfil.StartPosition = FormStartPosition.CenterParent;
                objManPerfil.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro? \nSi Elimina el PERFIL los Usuarios asociados también se eliminarán", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Parametros.strUsuarioLogin == "master")
                    {
                        if (!ValidarIngreso())
                        {
                            PerfilBE objE_Perfil = new PerfilBE();
                            objE_Perfil.IdPerfil = int.Parse(gvPerfil.GetFocusedRowCellValue("IdPerfil").ToString());
                            objE_Perfil.Usuario = Parametros.strUsuarioLogin;
                            objE_Perfil.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_Perfil.IdEmpresa = Parametros.intEmpresaId;

                            PerfilBL objBL_Perfil = new PerfilBL();
                            objBL_Perfil.Elimina(objE_Perfil);
                            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("UD. no tiene permiso para realizar esta acción.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string _fileName = "ListadoPerfiles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPerfil.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPerfil_DoubleClick(object sender, System.EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PerfilBL().ListaTodosActivo().ToList();
            gcPerfil.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPerfil.DataSource = mLista.Where(obj =>
                                                   obj.DescPerfil.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void ConfigurarGrilla()
        {
            gvPerfil.OptionsBehavior.Editable = false;
            gvPerfil.OptionsCustomization.AllowColumnMoving = false;
            gvPerfil.OptionsCustomization.AllowGroup = false;
            gvPerfil.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvPerfil.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvPerfil.OptionsView.ShowGroupPanel = false;
            gvPerfil.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            DevExpress.XtraGrid.Columns.GridColumn gcIdPerfil = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcFlagEstado = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdPerfil.Caption = "IdPerfil";
            gcIdPerfil.FieldName = "gcIdPerfil";
            gcIdPerfil.Name = "gcIdPerfil";
            gcIdPerfil.Visible = false;

            gcDescripcion.Caption = "Perfil";
            gcDescripcion.FieldName = "DescPerfil";
            gcDescripcion.Name = "gcDescripcion";
            gcDescripcion.Visible = true;
            gcDescripcion.VisibleIndex = 0;
            gcDescripcion.Width = 300;

            gcFlagEstado.Caption = "Estado";
            gcFlagEstado.FieldName = "FlagEstado";
            gcFlagEstado.Name = "gcFlagEstado";
            gcFlagEstado.Visible = true;
            gcFlagEstado.VisibleIndex = 2;
            gcFlagEstado.Width = 66;

            gvPerfil.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {             
                    gcIdPerfil,
                    gcDescripcion,
                    gcFlagEstado});

            gvPerfil.DoubleClick += new System.EventHandler(this.gvPerfil_DoubleClick);
        }

        public void InicializarModificar()
        {
            if (gvPerfil.RowCount > 0)
            {
                PerfilBE objPerfil = new PerfilBE();
                objPerfil.IdPerfil = int.Parse(gvPerfil.GetFocusedRowCellValue("IdPerfil").ToString());
                objPerfil.DescPerfil = gvPerfil.GetFocusedRowCellValue("DescPerfil").ToString();
                objPerfil.FlagEstado = Convert.ToBoolean(gvPerfil.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPerfilEdit objManPerfilEdit = new frmManPerfilEdit();
                objManPerfilEdit.pOperacion = frmManPerfilEdit.Operacion.Modificar;
                objManPerfilEdit.IdPerfil = objPerfil.IdPerfil;
                objManPerfilEdit.pPerfilBE = objPerfil;
                objManPerfilEdit.StartPosition = FormStartPosition.CenterScreen;
                //objManPerfilEdit.Location = new Point (0, 0);
                objManPerfilEdit.ShowDialog();

                txtDescripcion.Select();
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

            if (gvPerfil.GetFocusedRowCellValue("IdPerfil").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Perfil", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}