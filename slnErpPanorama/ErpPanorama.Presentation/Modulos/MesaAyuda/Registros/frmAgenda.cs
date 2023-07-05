using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmAgenda : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            schedulerControl1.Start = DateTime.Now.Date;
        }
    }
}