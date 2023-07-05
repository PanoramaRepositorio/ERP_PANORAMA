using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmEstablecerNumero : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public string Serie { get; set; }
        public int Numero { get; set; }
        
        #endregion

        #region "Eventos"

        public frmEstablecerNumero()
        {
            InitializeComponent();
        }

        private void frmEstablecerNumero_Load(object sender, EventArgs e)
        {
            txtSerie.EditValue = Serie;
            txtNumero.SelectAll();
            txtNumero.Focus();
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtNumero.EditValue) == 0)
            {
                XtraMessageBox.Show("El Descuento no puede ser 0, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.SelectAll();
                return;
            }
            Serie = txtSerie.Text.Trim();
            this.DialogResult = DialogResult.OK;
            Numero = Convert.ToInt32(txtNumero.Text);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #region "Metodos"

        #endregion

        
    }
}