using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRegAsignarConductorPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegAsignarConductorPedido()
        {
            InitializeComponent();
        }

        private void frmRegAsignarConductorPedido_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaConductor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = 0;// Parametros.intPersonaId;

            BSUtils.LoaderLook(cboCopiloto, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboCopiloto.EditValue = 0;

            BSUtils.LoaderLook(cboVehiculo, new VehiculoBL().ListaTodosActivo(0), "Placa", "IdVehiculo", true);
            cboVehiculo.EditValue = 0;
        }

        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                MovimientoPedidoBE objMovimientoPedido = new MovimientoPedidoBE();
                objMovimientoPedido.IdPedido = IdPedido;
                objMovimientoPedido.IdConductor = Convert.ToInt32(cboVendedor.EditValue);
                objMovimientoPedido.IdCopiloto = Convert.ToInt32(cboCopiloto.EditValue);
                objMovimientoPedido.IdVehiculo = Convert.ToInt32(cboVehiculo.EditValue); 
                objMovimientoPedido.Conductor = cboVendedor.Text;
                objMovimientoPedido.Usuario = Parametros.strUsuarioLogin;
                objMovimientoPedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objMovimientoPedido.FlagEstado = true;

                objBL_MovimientoPedido.ActualizaConductor(objMovimientoPedido);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #region "Metodos"

            #endregion
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}