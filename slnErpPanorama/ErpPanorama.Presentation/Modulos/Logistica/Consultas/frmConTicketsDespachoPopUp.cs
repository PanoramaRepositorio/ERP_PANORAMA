using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConTicketsDespachoPopUp : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TicketDespachoBE> mLista = new List<TicketDespachoBE>();

        #endregion

        #region "Eventos"

        public frmConTicketsDespachoPopUp()
        {
            InitializeComponent();
        }

        private void frmConTicketsDespachoPopUp_Load(object sender, EventArgs e)
        {
            Cargar();
            //axWindowsMediaPlayer1.URL = @"C:\ERP_imagenes\Video1.mp4";
            lblMensaje.Text = new string(' ', 100)+ "BIENVENIDOS, NUESTROS HORARIOS DE ATENCIÓN SON DE LUNES A SABADO DE 9:00 A.M.  A 9:00 P.M. Y DOMINGOS DE 10:00 A.M. A 8:00 P.M." + new string(' ', 100); 
            picLogo.Image = Image.FromFile(@"C:\Program Files\ERP\Imagenes\logo.png");

            CargarPlayList();
            this.Focus();
        }
    #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new TicketDespachoBL().ListaFecha(Parametros.intEmpresaId, DateTime.Now.Date);
            gcLista.DataSource = mLista;

            
        }
        private void CargarPlayList()
        {
            ////var myPlayList = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlayList");
            ////OpenFileDialog open = new OpenFileDialog();
            ////open.Multiselect = true;
            ////open.Filter = "All Files|*.*";

            ////if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            ////{
            ////    foreach (string file in open.FileNames)
            ////    {
            ////        var mediaItem = axWindowsMediaPlayer1.newMedia(file);
            ////        myPlayList.appendItem(mediaItem);
            ////    }
            ////}

            ////axWindowsMediaPlayer1.currentPlaylist = myPlayList;

            //var myPlayList = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlayList");
            //string sourcePath = @"C:\Program Files\ERP\Videos";
            //if (System.IO.Directory.Exists(sourcePath))
            //{
            //    string[] files = System.IO.Directory.GetFiles(sourcePath);

            //    foreach (string file in files)
            //    {
            //        var mediaItem = axWindowsMediaPlayer1.newMedia(file);
            //        myPlayList.appendItem(mediaItem);
            //    }
            //}

            //axWindowsMediaPlayer1.currentPlaylist = myPlayList;



        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cargar();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 1)
            {
                timer1.Enabled = true;
                timer1.Interval = Convert.ToInt32(1000) * Convert.ToInt32(numericUpDown1.Value);
                this.Text = "ACTIVO";
            }
            else
            {
                timer1.Enabled = false;
                this.Text = "DETENIDO";
            }
        }

        private void frmConTicketsDespachoPopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            axWindowsMediaPlayer1.URL = "";
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = lblMensaje.Text.Substring(1, lblMensaje.Text.Length - 1) + lblMensaje.Text.Substring(0, 1);
            //gvLista.ViewCaption = DateTime.Now.ToLongTimeString();
            gvLista.ViewCaption = DateTime.Now.ToString("t");

        }
    }
}