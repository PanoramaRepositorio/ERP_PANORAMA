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
    public partial class frmMensajeFE : DevExpress.XtraEditors.XtraForm
    {
        public string Titulo { get; set; }
        public string Mensaje { get; set; }


        public frmMensajeFE()
        {
            InitializeComponent();
        }

        private void frmMensajeFE_Load(object sender, EventArgs e)
        {
            this.Text = Titulo;

            
        }
    }
}