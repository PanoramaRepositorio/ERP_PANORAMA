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

namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    public partial class frmBuscarCompensado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public List<EstadoCuentaClientePagoBE> mListaPago = new List<EstadoCuentaClientePagoBE>();

        public int IdCliente { get; set; }
        public int IdEstadoCuentaCliente { get; set; }
        #endregion

        #region "Eventos"
        public frmBuscarCompensado()
        {
            InitializeComponent();
        }

        private void frmBuscarCompensado_Load(object sender, EventArgs e)
        {

            //mListaPago = new EstadoCuentaClientePagoBL().ListaHistorial(Parametros.intEmpresaId, IdEstadoCuentaCliente);
            gcEstadoCuentaCliente.DataSource = mListaPago;

            //Formato
            gcGrupoPago.Visible = true;
            gcGrupoPago.GroupIndex = 1;
            gvEstadoCuentaCliente.OptionsView.ShowGroupPanel = false;
            gvEstadoCuentaCliente.ExpandAllGroups();
        }

        #endregion

        #region "Métodos"
        #endregion
    }
}