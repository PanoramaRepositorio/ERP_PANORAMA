using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using ErpPanorama.Presentation;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
namespace ErpPanorama.Presentation.Inicio
{
    public partial class frmCumple : DevExpress.XtraEditors.XtraForm
    {
        public frmCumple()
        {
            InitializeComponent();
        }

        private void frmCumple_Load(object sender, EventArgs e)
        {
            CumpleBE objCe = new CumpleBE();
            CumpleBL objcl = new CumpleBL();


            int cuenta = objcl.Mostrar().Count;
           // MessageBox.Show(cuenta.ToString());
                if (cuenta>0 ){
            this.gridControl1.DataSource = objcl.Mostrar();  
                }
        }
    }
}