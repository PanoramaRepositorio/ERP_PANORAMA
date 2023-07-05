using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
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
    public partial class frmListadoSala : DevExpress.XtraEditors.XtraForm
    {

        private List<ReservaSalaBE> mLista = new List<ReservaSalaBE>();

        public frmListadoSala()
        {
            InitializeComponent();
        }

        private void deDesde_EditValueChanged(object sender, EventArgs e)
        {
            mLista = new ReservaSalaBL().ListaFecha(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()));
            gcReservaSala.DataSource = mLista;
        }

        private void FrmListadoSala_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReservaNuevo frm = new frmReservaNuevo();
            //frm.pNumeroDescCliente = txtNumeroDocumento.Text;
            //frm.pFlagMultiSelect = false;
            frm.ShowDialog();
            deDesde_EditValueChanged(null, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            deDesde_EditValueChanged(null, null);
        }

        private void reservarSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReservaNuevo frm = new frmReservaNuevo();
            //frm.pNumeroDescCliente = txtNumeroDocumento.Text;
            //frm.pFlagMultiSelect = false;
            frm.ShowDialog();
            deDesde_EditValueChanged(null, null);
        }
    }
}
