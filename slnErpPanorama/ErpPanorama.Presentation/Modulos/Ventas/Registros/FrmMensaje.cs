using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class FrmMensaje : SplashScreen
    {
        public FrmMensaje()
        {
            InitializeComponent();
         //   this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void SplashScreen1_Load(object sender, EventArgs e)
        {
           
        }

        private void FrmMensaje_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}