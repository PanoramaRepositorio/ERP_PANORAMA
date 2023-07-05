using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmModificaPrecioPublicitario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public decimal PrecioUnitario { get; set; }
        
        #endregion

        #region "Eventos"

        public frmModificaPrecioPublicitario()
        {
            InitializeComponent();
        }

        private void frmModificaPrecioPublicitario_Load(object sender, EventArgs e)
        {
            txtPrecio.EditValue = PrecioUnitario;
            txtPorDesc.EditValue = 0;
            txtMultiplica.SelectAll();
            txtMultiplica.Focus();
        }

        private void txtMultiplica_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMultiplica.EditValue) > 0)
            {
                txtPrecio.EditValue = Convert.ToDecimal(txtPrecio.EditValue) * Convert.ToDecimal(txtMultiplica.EditValue);
            }
        }

        private void txtDivide_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtDivide.EditValue) > 0)
            {
                txtPrecio.EditValue = Convert.ToDecimal(txtPrecio.EditValue) / Convert.ToDecimal(txtDivide.EditValue);
            }
        }

        private void txtMultiplica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnAceptar.Focus();
            }
        }

        private void txtDivide_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnAceptar.Focus();
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PrecioUnitario = Convert.ToDecimal(txtPrecio.EditValue);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        
       

        #region "Metodos"

        #endregion

        
    }
}