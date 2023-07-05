using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConAlertaPopup : DevExpress.XtraEditors.XtraForm
    {
        public string Titulo { get; set;}
        public string Mensaje { get; set; }

        public frmConAlertaPopup()
        {
            InitializeComponent();
        }

        private void frmConAlertaPopup_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = Titulo;
            txtMensaje.Text = Mensaje;
            this.Focus();
        }
    }
}