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
    public partial class frmEstablecerDescuento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public decimal Descuento { get; set; }
        public string DescMotivo { get; set; }

        #endregion

        #region "Eventos"

        public frmEstablecerDescuento()
        {
            InitializeComponent();
        }

        private void frmEstablecerDescuento_Load(object sender, EventArgs e)
        {
            txtPorDesc.SelectAll();
            txtPorDesc.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(txtPorDesc.EditValue) == 0)
            //{
            //    XtraMessageBox.Show("El Descuento no puede ser 0, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPorDesc.SelectAll();
            //    return;
            //}
            if(txtMotivo.Text.Trim().Length==0)
            {
                XtraMessageBox.Show("Ingrese el motivo del descuento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtMotivo.SelectAll();
                return;
            }

            this.DialogResult = DialogResult.OK;
            Descuento = Convert.ToDecimal(txtPorDesc.EditValue);
            DescMotivo = txtMotivo.Text.Trim();

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPorDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        #endregion

    }
}