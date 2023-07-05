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
    public partial class frmConTicketsDespacho : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TicketDespachoBE> mLista = new List<TicketDespachoBE>();

        #endregion

        #region "Eventos"
        public frmConTicketsDespacho()
        {
            InitializeComponent();
        }

        private void frmConTicketsDespacho_Load(object sender, EventArgs e)
        {
            
            frmConTicketsDespachoPopUp frm = new frmConTicketsDespachoPopUp();
            frm.ShowDialog();
            //this.Close();
            //Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            //mLista = new TicketDespachoBL().ListaFecha(Parametros.intEmpresaId, DateTime.Now.Date);
            //gcLista.DataSource = mLista;
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Cargar();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value > 1)
            //{
            //    timer1.Enabled = true;
            //    timer1.Interval = Convert.ToInt32(1000) * Convert.ToInt32(numericUpDown1.Value);
            //    this.Text = "ACTIVO";
            //}
            //else
            //{
            //    timer1.Enabled = false;
            //    this.Text = "DETENIDO";
            //}
        }
    }
}