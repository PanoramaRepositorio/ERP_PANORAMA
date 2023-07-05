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
    public partial class frmManUsuarios : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<UsuarioBE> mLista = new List<UsuarioBE>();

        #endregion

        #region "Eventos"

        public frmManUsuarios()
        {
            InitializeComponent();
        }

        private void frmManUsuarios_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                //frmManUsuariosEdit objManUsuario = new frmManUsuariosEdit();
                //objManUsuario.pOperacion = frmManUsuariosEdit.Operacion.Nuevo;
                //objManUsuario.IdUser = 0;
                //objManUsuario.StartPosition = FormStartPosition.CenterParent;
                //objManUsuario.ShowDialog();
                //Cargar();


                frmManUsuariosEdit2 objManUsuario = new frmManUsuariosEdit2();
                objManUsuario.pOperacion = frmManUsuariosEdit2.Operacion.Nuevo;
                objManUsuario.IdUser = 0;
                objManUsuario.StartPosition = FormStartPosition.CenterParent;
                objManUsuario.ShowDialog();
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
                        UsuarioBE objE_Usuario = new UsuarioBE();
                        objE_Usuario.IdUser = int.Parse(gvUsuario.GetFocusedRowCellValue("IdUser").ToString());
                        objE_Usuario.Usuario = Parametros.strUsuarioLogin;
                        objE_Usuario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Usuario.IdEmpresa = Parametros.intEmpresaId;

                        UsuarioBL objBL_Usuario = new UsuarioBL();
                        objBL_Usuario.Elimina(objE_Usuario);
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

                List<ReporteAccesoUsuarioBE> lstReporte = null;
                lstReporte = new ReporteAccesoUsuarioBL().Listado();

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptAccesoUsuario = new RptVistaReportes();
                        objRptAccesoUsuario.VerRptAccesoUsuario(lstReporte);
                        objRptAccesoUsuario.ShowDialog();
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
            string _fileName = "ListadoUsuarios";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvUsuario.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvUSuario_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void accesopersonalizadostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvUsuario.RowCount > 0)
            {
                UsuarioBE objUsuario = new UsuarioBE();
                objUsuario.IdUser = int.Parse(gvUsuario.GetFocusedRowCellValue("IdUser").ToString());
                objUsuario.IdEmpresa = int.Parse(gvUsuario.GetFocusedRowCellValue("IdEmpresa").ToString());
                objUsuario.IdPersona = int.Parse(gvUsuario.GetFocusedRowCellValue("IdPersona").ToString());
                objUsuario.IdPerfil = int.Parse(gvUsuario.GetFocusedRowCellValue("IdPerfil").ToString());
                objUsuario.Descripcion = gvUsuario.GetFocusedRowCellValue("Descripcion").ToString();
                objUsuario.Usuario = gvUsuario.GetFocusedRowCellValue("Usuario").ToString();
                objUsuario.Password = gvUsuario.GetFocusedRowCellValue("Password").ToString();
                objUsuario.FlagMaster = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagMaster").ToString());
                objUsuario.FlagAutorizaEliminaDocumentoVenta = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagAutorizaEliminaDocumentoVenta").ToString());
                objUsuario.FlagEstado = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagEstado").ToString());


                frmManUsuariosEdit objManUsuarioEdit = new frmManUsuariosEdit();
                objManUsuarioEdit.pOperacion = frmManUsuariosEdit.Operacion.Modificar;
                objManUsuarioEdit.IdUser = objUsuario.IdUser;
                objManUsuarioEdit.IdPerfil = objUsuario.IdPerfil;
                objManUsuarioEdit.pUsuarioBE = objUsuario;
                objManUsuarioEdit.StartPosition = FormStartPosition.CenterParent;
                objManUsuarioEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista =  new UsuarioBL().ListaTodosActivo();
            gcUsuario.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcUsuario.DataSource = mLista.Where(obj =>obj.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvUsuario.RowCount > 0)
            {
                UsuarioBE objUsuario = new UsuarioBE();
                objUsuario.IdUser = int.Parse(gvUsuario.GetFocusedRowCellValue("IdUser").ToString());
                objUsuario.IdEmpresa = int.Parse(gvUsuario.GetFocusedRowCellValue("IdEmpresa").ToString());
                objUsuario.IdPersona = int.Parse(gvUsuario.GetFocusedRowCellValue("IdPersona").ToString());
                objUsuario.IdPerfil = int.Parse(gvUsuario.GetFocusedRowCellValue("IdPerfil").ToString());
                objUsuario.Descripcion = gvUsuario.GetFocusedRowCellValue("Descripcion").ToString();
                objUsuario.Usuario = gvUsuario.GetFocusedRowCellValue("Usuario").ToString();
                objUsuario.Password = gvUsuario.GetFocusedRowCellValue("Password").ToString();
                objUsuario.FlagMaster = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagMaster").ToString());
                objUsuario.FlagAutorizaEliminaDocumentoVenta = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagAutorizaEliminaDocumentoVenta").ToString());
                objUsuario.FlagEstado = Convert.ToBoolean(gvUsuario.GetFocusedRowCellValue("FlagEstado").ToString());

                if (objUsuario.IdUser == 1)
                {
                    frmManUsuariosEdit objManUsuarioEdit = new frmManUsuariosEdit();
                    objManUsuarioEdit.pOperacion = frmManUsuariosEdit.Operacion.Modificar;
                    objManUsuarioEdit.IdUser = objUsuario.IdUser;
                    objManUsuarioEdit.IdPerfil = objUsuario.IdPerfil;
                    objManUsuarioEdit.pUsuarioBE = objUsuario;
                    objManUsuarioEdit.StartPosition = FormStartPosition.CenterParent;
                    objManUsuarioEdit.ShowDialog();
                }
                else
                { 
                    frmManUsuariosEdit2 objManUsuarioEdit = new frmManUsuariosEdit2();
                    objManUsuarioEdit.pOperacion = frmManUsuariosEdit2.Operacion.Modificar;
                    objManUsuarioEdit.IdUser = objUsuario.IdUser;
                    objManUsuarioEdit.IdPerfil = objUsuario.IdPerfil;
                    objManUsuarioEdit.pUsuarioBE = objUsuario;
                    objManUsuarioEdit.StartPosition = FormStartPosition.CenterParent;
                    objManUsuarioEdit.ShowDialog();                
                }


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

            if (gvUsuario.GetFocusedRowCellValue("IdUser").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion
    }
}