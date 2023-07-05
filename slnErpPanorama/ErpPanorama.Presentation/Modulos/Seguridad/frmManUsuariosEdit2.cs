using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Criptografia;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Seguridad
{
    public partial class frmManUsuariosEdit2 : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public UsuarioBE pUsuarioBE { get; set; }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public UsuarioBE pUsuarioBE { get; set; }

        bool find = false;

        int _IdPerfil = 0;

        public int IdPerfil
        {
            get { return _IdPerfil; }
            set { _IdPerfil = value; }
        }

        int _IdUser = 0;

        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        int menuID = 0;
        int IdPersona = 0;


        #endregion

        #region "Eventos"

        public frmManUsuariosEdit2()
        {
            InitializeComponent();
        }

        private void frmManUsuariosEdit2_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            BSUtils.LoaderLook(cboPerfil, new PerfilBL().ListaTodosActivo(), "DescPerfil", "IdPerfil", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Usuario - Nuevo";
                txtPersona.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                this.Text = "Usuario - Modificar";
                txtUsuario.Text = pUsuarioBE.Usuario;
                IdPersona = pUsuarioBE.IdPersona;
                txtPersona.Text = pUsuarioBE.Descripcion;
                txtPassword.Text = objCrypto.DescifrarCadena(pUsuarioBE.Password);
                cboEmpresa.EditValue = pUsuarioBE.IdEmpresa;
                cboPerfil.EditValue = pUsuarioBE.IdPerfil;
                chkMaster.EditValue = pUsuarioBE.FlagMaster;
                chkAutorizaEliminaDocumentoVenta.EditValue = pUsuarioBE.FlagAutorizaEliminaDocumentoVenta;
                chkEstado.EditValue = pUsuarioBE.FlagEstado;

            }

            txtPassword.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                    objCrypto.Key = Parametros.Key;
                    objCrypto.IV = Parametros.IV;
                    string Password = "";
                    Password = objCrypto.CifrarCadena(this.txtPassword.Text.Trim());

                    UsuarioBL objBL_Usuario = new UsuarioBL();
                    UsuarioBE objUsuario = new UsuarioBE();

                    objUsuario.IdEmpresa = int.Parse(cboEmpresa.EditValue.ToString());
                    objUsuario.IdPerfil = int.Parse(cboPerfil.EditValue.ToString());
                    objUsuario.IdPersona = IdPersona;
                    objUsuario.Descripcion = txtPersona.Text.Trim();
                    objUsuario.Usuario = txtUsuario.Text.Trim();
                    objUsuario.Password = Password;
                    objUsuario.FlagMaster = chkMaster.Checked;
                    objUsuario.FlagAutorizaEliminaDocumentoVenta = chkAutorizaEliminaDocumentoVenta.Checked;
                    objUsuario.FlagEstado = chkEstado.Checked;
                    objUsuario.UsuarioCrea = Parametros.strUsuarioLogin;
                    objUsuario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUsuario.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Usuario.InsertaPorPerfil(objUsuario);
                    }
                    else if (pOperacion == Operacion.Modificar)
                    {
                        objUsuario.IdUser = pUsuarioBE.IdUser;
                        objBL_Usuario.Actualiza(objUsuario);

                        if (Convert.ToInt32(cboEmpresa.EditValue) != pUsuarioBE.IdEmpresa)
                        {
                            XtraMessageBox.Show("No se puede cambiar de empresa al usuario por esta opción, Ir a Personal y modificar Empresa \nSin embargo se grabará con la empresa a la que pertenece el personal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (Convert.ToInt32(cboPerfil.EditValue) != pUsuarioBE.IdPerfil)
                        {
                            objBL_Usuario.ActualizaPorPerfil(objUsuario);

                            XtraMessageBox.Show("El usuario cambió de perfil. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.TipoBusqueda = 1;
                frm.Title = "Búsqueda de Persona sin Usuario";
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (string.IsNullOrEmpty(cboEmpresa.Text))
            {
                XtraMessageBox.Show("Seleccione la empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEmpresa.Select();
                flag = true;
            }

            if (string.IsNullOrEmpty(cboPerfil.Text))
            {
                XtraMessageBox.Show("Seleccione el perfil", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPerfil.Select();
                flag = true;
            }

            if (IdPersona == 0)
            {
                XtraMessageBox.Show("Seleccione a una persona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBuscar.Select();
                flag = true;
            }

            if (txtPersona.Text.ToString() == "")
            {
                XtraMessageBox.Show("Seleccione descripción del Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBuscar.Select();
                flag = true;
            }

            if (txtUsuario.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese el Usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Select();
                flag = true;
            }

            if (txtPassword.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese la clave del usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                UsuarioBE objE_Usuario = new UsuarioBE(); //add 1708
                objE_Usuario = new UsuarioBL().SeleccionaUsuario(txtUsuario.Text.Trim());

                if (objE_Usuario != null)
                {
                    string msgEliminado = "";
                    if (!objE_Usuario.FlagEstado)
                        msgEliminado = "\nEl usuario se encuentra eliminado. [msg x Auditoria]";

                        XtraMessageBox.Show("El usuario ya Existe, Favor de Utilizar otro usuario." + msgEliminado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUsuario.Select();
                        flag = true;
                }
           
            }


            Cursor = Cursors.Default;
            return flag;
        }
        #endregion


    }
}