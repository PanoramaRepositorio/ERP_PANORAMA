using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmCambiarCliente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdCambio { get; set; }
        
        #endregion

        #region "Eventos"


        public frmCambiarCliente()
        {
            InitializeComponent();
        }

        private void frmCambiarCliente_Load(object sender, EventArgs e)
        {
            txtNumeroDocumento.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtNumeroDocumento.Text == "")
            {
                XtraMessageBox.Show("Ingresar el número de documento del cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroDocumento.Focus();
                return;
            }

            if (txtDescCliente.Text == "")
            {
                XtraMessageBox.Show("Ingresar la descripción del cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroDocumento.Focus();
                return;
            }

            CambioBL objBL_Cambio = new CambioBL();
            objBL_Cambio.ActualizaCliente(IdCambio, 2218, txtNumeroDocumento.Text, txtDescCliente.Text);

            this.DialogResult = DialogResult.OK;
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