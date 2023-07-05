using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusClienteTelefonos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ClienteBE> mLista = new List<ClienteBE>();
        public ClienteBE _Be { get; set; }

        public int IdCliente = 0;

        #endregion

        #region "Eventos"

        public frmBusClienteTelefonos()
        {
            InitializeComponent();
        }

        private void frmBusClienteTelefonos_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvTelefonos_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new ClienteBL().ListaTelefonos(IdCliente);
            gcTelefonos.DataSource = mLista;
        }

        private void Aceptar()
        {
            _Be = (ClienteBE)gvTelefonos.GetRow(gvTelefonos.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        #endregion

        
    }
}