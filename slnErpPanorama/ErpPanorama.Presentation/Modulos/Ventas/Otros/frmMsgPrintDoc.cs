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
    public partial class frmMsgPrintDoc : DevExpress.XtraEditors.XtraForm
    {

        public int TipoFormatoPrint = 0;

        public frmMsgPrintDoc()
        {
            InitializeComponent();
        }

        private void btnContinuo_Click(object sender, EventArgs e)
        {
            TipoFormatoPrint = 1;
            Close();
        }

        private void btnDesglosable_Click(object sender, EventArgs e)
        {
            TipoFormatoPrint = 2;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}