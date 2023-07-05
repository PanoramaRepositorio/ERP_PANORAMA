using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Criptografia;
using System.Security.Principal;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.Text.RegularExpressions;

namespace ErpPanorama.Presentation.Modulos.Seguridad
{
    public partial class frmManCambioClave : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public UsuarioBE pUsuarioBE { get; set; }


        int IdPersona = 0;

        #endregion

        #region "Eventos"

        public frmManCambioClave()
        {
            InitializeComponent();
        }

        private void frmManCambioClave_Load(object sender, EventArgs e)
        {

            Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
            objCrypto.Key = Parametros.Key;
            objCrypto.IV = Parametros.IV;

            txtUsuario.Text = Parametros.strUsuarioLogin;
            IdPersona = Parametros.intPersonaId;

            txtPassword.Select();
                
                
                //txtPassword.Text = objCrypto.DescifrarCadena(pUsuarioBE.Password);

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
                    string NuevoPassword = objCrypto.CifrarCadena(this.txtNuevoPassword.Text.Trim());

                    UsuarioBE objE_Usuario = new UsuarioBL().LogOnUser(txtUsuario.Text.ToString().Trim(), Password);

                    if (objE_Usuario != null)
                    {
                        UsuarioBL objBL_Usuario = new UsuarioBL();
                        UsuarioBE objUsuario = new UsuarioBE();

                        //objUsuario.IdPersona = IdPersona;
                        objUsuario.IdUser = objE_Usuario.IdUser;
                        objUsuario.Password = NuevoPassword;
                        objUsuario.UsuarioCrea = Parametros.strUsuarioLogin;
                        objUsuario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objUsuario.IdEmpresa = Parametros.intEmpresaId;


                        objBL_Usuario.ActualizaPassword(objUsuario);
                        XtraMessageBox.Show("cambio de Password correctamente!\nCierre y vuelva a ingresar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se pudo cambiar, La contraseña es incorrecta!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

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

            if (txtNuevoPassword.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese la nueva clave del usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            if (txtConfirmarPassword.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese la confirmación de clave del usuario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            if (txtNuevoPassword.Text != txtConfirmarPassword.Text)
            {
                XtraMessageBox.Show("La nueva clave no coincide, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            if(txtNuevoPassword.Text.Length<8)
            {
                XtraMessageBox.Show("La Contraseña debe tener como mínimo 8 caracteres, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            var r = new Regex(@"^(?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9])\S{8,}$");

            if (!r.Match(txtNuevoPassword.Text).Success)
            {
                XtraMessageBox.Show("La Contraseña debe contener caracteres en Mayúscula, Minúscula y Número.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Select();
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



    }
}