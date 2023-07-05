using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Criptografia;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmAutorizacionUsuario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public bool Edita { get; set; }
        public string Usuario { get; set; }
        public int IdPersona { get; set; }
        public bool FlagMaster { get; set; }
        public bool FlagAutorizaEliminaDocumentoVenta { get; set; }
        public int IdPerfil { get; set; }
        public int vsn2 = 0;

        #endregion

        #region "Eventos"

        public frmAutorizacionUsuario()
        {
            InitializeComponent();
        }

        private void frmAutorizacionUsuario_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)

        {
            try
            {
                
                
                
                if (txtUsuario.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese el usuario.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Focus();
                    return;
                }
                if (txtContraseña.Text.Trim().Length == 0)
                {
                    XtraMessageBox.Show("Ingrese la contraseña.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtContraseña.Focus();
                    return;
                }

                Encrypt objCrypto = new Encrypt(Encrypt.CryptoProvider.Rijndael);
                objCrypto.Key = Parametros.Key;
                objCrypto.IV = Parametros.IV;

                string _password = objCrypto.CifrarCadena(txtContraseña.Text.ToString());
                UsuarioBE objE_Usuario = new UsuarioBL().LogOnUser(txtUsuario.Text.ToString().Trim(), _password);
                if (objE_Usuario != null)
                {
                    //if (vsn2==1 && objE_Usuario.IdPerfil==Parametros.intPerJefeRRHH)
                    Edita = true;
                    Usuario = txtUsuario.Text.ToLower();
                    IdPersona = objE_Usuario.IdPersona;
                    FlagMaster = objE_Usuario.FlagMaster;
                    FlagAutorizaEliminaDocumentoVenta = objE_Usuario.FlagAutorizaEliminaDocumentoVenta;


                    IdPerfil = objE_Usuario.IdPerfil;
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Usuario / Clave incorrecta.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Edita = false;
            this.Close();
        }


        #region "Metodos"

        #endregion

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}