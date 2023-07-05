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
    public partial class frmEstablecerFecha : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public DateTime Fecha { get; set; }
        
        #endregion

        #region "Eventos"

        public frmEstablecerFecha()
        {
            InitializeComponent();
        }

        private void frmEstableerFecha_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            deFecha.SelectAll();
            deFecha.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
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