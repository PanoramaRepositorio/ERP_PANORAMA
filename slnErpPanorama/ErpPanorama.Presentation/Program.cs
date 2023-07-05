using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ErpPanorama.Presentation.Inicio;
using DevExpress.Skins;

namespace ErpPanorama.Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var a = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (a.CompareInfo.Name.ToString() != Parametros.CurrentCultureERP)
            {
                Parametros.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.DisplayName;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Parametros.CurrentCultureERP);
            }
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            SkinManager.EnableMdiFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmIDE());
            //Application.Run(new ErpPanorama.Presentation.ClienteAPI.frmPrueba());

        }
    }
}
