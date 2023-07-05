using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmEstablecerPrecio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public string Titulo;
        public decimal Precio { get; set; }

        #endregion

        #region "Eventos"


        public frmEstablecerPrecio()
        {
            InitializeComponent();
        }

        private void frmEstablecerPrecio_Load(object sender, EventArgs e)
        {
            if (Titulo.Length > 0) this.Text = Titulo;
            txtPrecio.Select();
            txtPrecio.SelectAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtPrecio.EditValue) == 0)
            {
                XtraMessageBox.Show("El Precio no puede ser 0, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.SelectAll();
                return;
            }

            this.DialogResult = DialogResult.OK;
            Precio = Convert.ToDecimal(txtPrecio.EditValue);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region "Métodos"

        #endregion
    }
}