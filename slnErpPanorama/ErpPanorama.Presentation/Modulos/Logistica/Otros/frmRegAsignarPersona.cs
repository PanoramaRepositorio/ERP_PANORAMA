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
    public partial class frmRegAsignarPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        public int Origen = 0;
        public int IdPedidoDetalle { get; set;}

        #endregion

        #region "Eventos"

        public frmRegAsignarPersona()
        {
            InitializeComponent();
        }

        private void frmRegAsignarPersona_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaAuxiliar(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            txtCodigo.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboVendedor.Text != "")
                {
                    Cursor = Cursors.WaitCursor;

                    if (Origen == 1)//Hoja De Instalación Detalle
                    {
                        PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                        //PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                        //objE_PedidoDetalle.IdPedido = IdPedido;
                        //objE_PedidoDetalle.IdPersonaServicio = Convert.ToInt32(cboVendedor.EditValue);
                        ////objE_PedidoDetalle.Origen = 1;
                        objBL_PedidoDetalle.ActualizaPersonaServicio(IdPedidoDetalle, Convert.ToInt32(cboVendedor.EditValue));
                    }



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

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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