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
    public partial class frmMensajeWindowsYESNO : DevExpress.XtraEditors.XtraForm
    {
        public string Titulo="";
        public string Mensaje="";

        public frmMensajeWindowsYESNO()
        {
            InitializeComponent();
        }

        private void frmMensajeWindowsYESNO_Load(object sender, EventArgs e)
        {
            if (Titulo.Length > 0) gcMensaje.Text = Titulo;
            if (Mensaje.Length > 0) lblMensaje.Text = Mensaje;
            btnAceptar.Focus();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}