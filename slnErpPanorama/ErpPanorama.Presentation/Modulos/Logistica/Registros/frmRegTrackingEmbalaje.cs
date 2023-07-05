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

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegTrackingEmbalaje : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoPedidoBE> mLista = new List<MovimientoPedidoBE>();

        #endregion

        #region "Eventos"
        public frmRegTrackingEmbalaje()
        {
            InitializeComponent();
        }

        private void frmRegTrackingEmbalaje_Load(object sender, EventArgs e)
        {

        }

        #endregion
        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoPedidoBL().ListaNumero(Parametros.intPeriodo, txtNumero.Text);
            gcPedido.DataSource = mLista;
        }
        #endregion

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //--
            }
        }
    }
}