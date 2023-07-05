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


namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPlanillaRH : DevExpress.XtraEditors.XtraForm
    {
        public frmRegPlanillaRH()
        {
            InitializeComponent();
        }

        private void frmRegPlanillaRH_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            try
            {
                PlanillaRHBE obj = new PlanillaRHBE();
                PlanillaRHBL obj1 = new PlanillaRHBL();
                obj.Dias = Int32.Parse(this.textEdit1.Text);
                this.gridControl1.DataSource = obj1.PlanillaRH(obj.Dias);
            }
            catch (Exception e53) {
                MessageBox.Show(e53.ToString());
            }
        }
    }
}