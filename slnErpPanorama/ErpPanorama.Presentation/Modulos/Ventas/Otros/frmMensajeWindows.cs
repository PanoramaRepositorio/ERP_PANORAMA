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
    public partial class frmMensajeWindows : DevExpress.XtraEditors.XtraForm
    {
        public string Titulo="";
        public string Mensaje="";
        public int intImagen = 0; //0=Aceptar, 1=Eliminar
        public frmMensajeWindows()
        {
            InitializeComponent();
        }


        private void frmMensajeWindows_Load(object sender, EventArgs e)
        {
            if(intImagen == 1)
                btnAceptar.ImageOptions.Image = ErpPanorama.Presentation.Properties.Resources.Eliminar_16x16;

            if (Titulo.Length>0) gcMensaje.Text = Titulo;
            if(Mensaje.Length>0) lblMensaje.Text = Mensaje;
            btnAceptar.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}