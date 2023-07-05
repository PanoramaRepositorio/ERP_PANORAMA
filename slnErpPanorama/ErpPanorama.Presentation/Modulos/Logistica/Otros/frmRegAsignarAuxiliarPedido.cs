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
    public partial class frmRegAsignarAuxiliarPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        public PedidoBE oBE;

        #endregion

        #region "Eventos"
        public frmRegAsignarAuxiliarPedido()
        {
            InitializeComponent();
        }

        private void frmRegAsignarAuxiliarPedido_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaAuxiliar(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            txtCodigo.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboVendedor.Text != "")
                {
                    Cursor = Cursors.WaitCursor;
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                    MovimientoPedidoBE objMovimientoPedido = new MovimientoPedidoBE();
                    objMovimientoPedido.IdPedido = IdPedido;
                    objMovimientoPedido.IdAuxiliar = Convert.ToInt32(cboVendedor.EditValue);
                    objMovimientoPedido.Origen = 1;
                    objBL_MovimientoPedido.ActualizaAuxiliar(objMovimientoPedido);

                    oBE = new PedidoBE();
                    oBE.DescAuxiliar = cboVendedor.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txtCodigo.Select();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Trim().Length > 0)
                {
                    cboVendedor.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
                    btnGrabar.Focus();
                }
            }
        }

        #region "Metodos"

        #endregion
    }
}