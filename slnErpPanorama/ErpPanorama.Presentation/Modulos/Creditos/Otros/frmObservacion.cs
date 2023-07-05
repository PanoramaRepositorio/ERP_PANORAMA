using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    public partial class frmObservacion : DevExpress.XtraEditors.XtraForm
    {

        public string strObservacion { get; set; }

        public frmObservacion()
        {
            InitializeComponent();
        }

        private void frmObservacion_Load(object sender, EventArgs e)
        {
            txtObservacion.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text.Trim().Length > 2)
            {
                strObservacion = txtObservacion.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //XtraMessageBox.Show("Ingresar observación para eliminar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txtObservacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnAceptar_Click(sender, e);    
            }
        }


    }
}