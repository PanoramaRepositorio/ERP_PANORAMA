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
    public partial class frmProductoFoto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public string RutaImagen { get; set; }
        public Image Imagen;
        #endregion


        public frmProductoFoto()
        {
            InitializeComponent();
        }

        private void frmProductoFoto_Load(object sender, EventArgs e)
        {
            //picImage.Image = Image.FromFile("http://valiant.vis-hosting.com/imagen/44483_f.jpg");
            picImage.Image = Imagen;
        }
    }
}