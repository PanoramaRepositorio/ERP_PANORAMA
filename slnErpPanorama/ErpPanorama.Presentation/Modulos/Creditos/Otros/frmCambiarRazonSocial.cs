using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    public partial class frmCambiarRazonSocial : DevExpress.XtraEditors.XtraForm
    {
        #region "Propieadades"

        public int IdEmpresa { get; set; }
        public int IdDocumentoVenta { get; set; }

        public int Origen = 0; //0=DocumentoVenta; 1=CuentaBanco
        public int IdCuentaBancoDetalle = 0;

        public int IdCliente = 0;
        public int IdMotivo = 0;
        public int IdPedido = 0;
        public string NumeroPedido = "";
        public string FormaPago = "";

        #endregion

        #region "Eventos"

        public frmCambiarRazonSocial()
        {
            InitializeComponent();
        }

        private void frmCambiarRazonSocial_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);

            DocumentoVentaBE objDocumento = null;
            objDocumento = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
            if (objDocumento != null)
            {
                IdCliente = objDocumento.IdCliente;
                txtNumeroDocumento.Text = objDocumento.NumeroDocumento;
                txtDescCliente.Text = objDocumento.DescCliente;
                txtDireccion.Text = objDocumento.Direccion;
            }
            txtNumero.Select();
            txtPeriodo.EditValue = DateTime.Now.Year.ToString();
        }

        private void btnClienteAsociado_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar un cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumeroDocumento.Focus();
                    return;
                }

                frmBusClienteAsociado frm = new frmBusClienteAsociado();
                frm.IdCliente = IdCliente;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteAsociadoBE != null)
                {
                    txtNumeroDocumento.Text = frm.pClienteAsociadoBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteAsociadoBE.DescCliente;
                    txtDireccion.Text = frm.pClienteAsociadoBE.Direccion;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //if (Origen == 0)
            //{
            //    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
            //    objBL_Documento.ActualizaCliente(IdDocumentoVenta, IdCliente, txtNumeroDocumento.Text, txtDescCliente.Text, txtDireccion.Text);

            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}

            if (Origen == 1)
            {
                if (txtTipoCambio.Visible == true && Convert.ToDecimal(txtTipoCambio.EditValue) == 0)
                {
                    XtraMessageBox.Show("Debe ingresar el Tipo de Cambio de Facturación.",this.Text);
                    return;
                }

                CuentaBancoDetalleBE objE_CuentaBanco = new CuentaBancoDetalleBE();
                CuentaBancoDetalleBL objBL_Documento = new CuentaBancoDetalleBL();
                objE_CuentaBanco.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
                objE_CuentaBanco.IdCliente = IdCliente;
                objE_CuentaBanco.DescCliente = txtDescCliente.Text.Trim();
                objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
                objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_Documento.ActualizaCliente(objE_CuentaBanco);

                if (txtNumero.Text.Trim().Length > 0)
                {
                    NumeroPedido = " N° " + txtNumero.Text.Trim();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "mmurrugarra" || Parametros.strUsuarioLogin == "dhuaman" || Parametros.intPerfilId == Parametros.intPerAdministrador || 
                    Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion || Parametros.strUsuarioLogin == "pmoscaiza" || Parametros.intPerfilId == Parametros.intPerAsistenteFacturacion)//contadoras
                {
                    frmBusCliente frm = new frmBusCliente();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pClienteBE != null)
                    {
                        IdCliente = frm.pClienteBE.IdCliente;
                        txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                        txtDescCliente.Text = frm.pClienteBE.DescCliente;
                        txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;

                        //if (frm.pClienteBE.IdTipoCliente == Parametros.intTipClienteMayorista || frm.pClienteBE.IdClasificacionCliente == Parametros.intBlack)
                        //{
                        TipoCambioBE objE_TipoCambio = null;
                        objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
                        txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
                        //txtTipoCambio.Properties.ReadOnly = false;
                        //txtTipoCambio.Visible = true;
                        //}
                        //else
                        //{
                        //    txtTipoCambio.Properties.ReadOnly = true;
                        //    txtTipoCambio.Visible = false;
                        //    txtTipoCambio.EditValue = 0;
                        //}




                        txtDescCliente.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Ud. no cuenta con los permisos necesarios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PedidoBE objE_Pedido = null;
               // objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumero.Text.Trim());
                objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.Text), txtNumero.Text.Trim());
                if (objE_Pedido != null)
                {
                    IdPedido = objE_Pedido.IdPedido;
                    cboMotivo.EditValue = objE_Pedido.IdMotivo;
                    txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                    IdCliente = objE_Pedido.IdCliente;
                    txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                    txtDescCliente.Text = objE_Pedido.DescCliente;
                    txtDireccion.Text = objE_Pedido.Direccion;
                    //textEdit1.Text= objE_Pedido.Direccion;
                    FormaPago = objE_Pedido.DescFormaPago;
                }
                else
                {
                    XtraMessageBox.Show("El número de pedido no existe!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        #region "Metodos"

        #endregion

        private void txtNumero_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}