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
    public partial class frmCopiarPedido : DevExpress.XtraEditors.XtraForm
    {

        public int TipoCopia = 0;

        public frmCopiarPedido()
        {
            InitializeComponent();
        }

        private void frmCopiarPedido_Load(object sender, EventArgs e)
        {

        }

        private void btnCopiaDetalle_Click(object sender, EventArgs e)
        {
            TipoCopia = 1;
        }

        private void btnCopiaCabeceraDetalle_Click(object sender, EventArgs e)
        {
            TipoCopia = 2;
        }

        private void btnCopiaCabecera_Click(object sender, EventArgs e)
        {
            TipoCopia = 3;
        }

    }
}