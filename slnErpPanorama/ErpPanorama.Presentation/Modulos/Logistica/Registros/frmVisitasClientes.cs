using DevExpress.XtraEditors;
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

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmVisitasClientes : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<AgendaVisitaBE> mLista = new List<AgendaVisitaBE>();
        private List<AgendaVisitaDetalleBE> mListaDetalle = new List<AgendaVisitaDetalleBE>();
        #endregion
        public frmVisitasClientes()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
                mLista = new AgendaVisitaBL().ListaFechaVisitasProgramadas(Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue)); //  
                gcVisitas.DataSource = mLista;
        }

        private void frmVisitasClientes_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now.Date;  // DateTime.Now.AddMonths(-1);
            deHasta.EditValue = DateTime.Now.Date.AddDays(35);

            btnConsultar_Click(null,null);

        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            mLista = new AgendaVisitaBL().ListaFechaVisitasProgramadas(Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue)); //  
            gcVisitas.DataSource = mLista;
        }
    }
}