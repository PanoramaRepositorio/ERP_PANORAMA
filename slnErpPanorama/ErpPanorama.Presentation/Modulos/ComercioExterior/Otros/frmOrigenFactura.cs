using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Otros
{
    public partial class frmOrigenFactura : DevExpress.XtraEditors.XtraForm
    {
        public bool bNacional { get; set; }
        public bool vNacional=false;

        public frmOrigenFactura()
        {
            InitializeComponent();
        }

        private void frmOrigenFactura_Load(object sender, EventArgs e)
        {
            
        }

        private void btnImportado_Click(object sender, EventArgs e)
        {
            bNacional = false;
            this.DialogResult = DialogResult.OK;
        }

        private void bntNacional_Click(object sender, EventArgs e)
        {
            bNacional = true;
            this.DialogResult = DialogResult.OK;
        }
    }
}