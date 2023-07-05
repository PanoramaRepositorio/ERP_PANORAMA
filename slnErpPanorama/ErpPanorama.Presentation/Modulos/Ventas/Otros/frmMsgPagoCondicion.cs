using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using System.Security.Principal;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Funciones;
using System.Drawing.Printing;
using System.IO;
using System.Diagnostics;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmMsgPagoCondicion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private FacturacionElectronica FacturaE = new FacturacionElectronica();

        private List<PedidoDetalleBE> mListaDetalle = null;
        List<PedidoDetalleBE> mListaPedidoDetalleOrigen = new List<PedidoDetalleBE>();

        public String NumeroPedido = "";
        //public decimal Total = 0;
        //public int PagoIdPedido = 0;
        public int IdPedido = 0;
        public string NumeroDocumento = "";
        public string DescCliente = "";
        public string Direccion = "";
        public int IdTipoDocumentoClienteAsociado = 0;
        public int IdCliente = 0;
        public int IdDocumentoNC = 0;
        private decimal ImporteCupon = 0;
        private int IdTarjetaRegalo = 0;

        public int IdTipoDocumento { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdClasificacionCliente { get; set; }

        public int IdClienteRef = 0;
        public int IdTipoClienteRef { get; set; } = Parametros.intTipClienteFinal;
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Visa { get; set; }
        public decimal MasterCard { get; set; }
        public string NumeroNotaCredito { get; set; }
        public string NumeroReciboPago { get; set; }
        public decimal Total { get; set; }
        public string VisaTipoTarjeta { get; set; }
        public string MasterTipoTarjeta { get; set; }

        public decimal VisaPuntosVida { get; set; }
        public decimal MasterCardPuntosVida { get; set; }
        public string NumeroCupon { get; set; }
        public decimal Cupon { get; set; }


        public int IdEmpresaOrigen { get; set; }
        public int IdTipoMaster { get; set; }
        public int TipoDocBolFac { get; set; }
        public bool FlagBusquedaCliente = false;
        private bool FlagMayoristaActivo = true;

        public bool DescuentoFlag = false;

        public int vIdcomercio = 0;

        int valueId2;  // = cboEmpresa.Properties.GetDataSourceValue("IdEmpresa", i);
        string value2;   //= cboEmpresa.Properties.GetDataSourceValue("RazonSocial", i);

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmMsgPagoCondicion()
        {
            InitializeComponent();
        }

        private void frmMsgPagoCondicion_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;

            BSUtils.LoaderLook(cboEmpresaOrigen, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresaOrigen.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboMonedaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMonedaPago.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(Parametros.intEmpresaId, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = IdTipoDocumento;
            BSUtils.LoaderLook(cboDocumentoGenerarRCP, new TalonBL().ListaCaja(Parametros.intEmpresaId, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumentoGenerarRCP.EditValue = IdTipoDocumento;

            //BSUtils.LoaderLook(cboDocumentoCR, new ModuloDocumentoBL().ListaDevolucion(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            //cboDocumentoCR.EditValue = Parametros.intTipoDocNotaCredito;
            BSUtils.LoaderLook(cboDocumentoCR, CargarTipoDocumentoPago(), "Descripcion", "Id", false);
            cboDocumentoCR.EditValue = Parametros.intTipoDocNotaCredito;

            BSUtils.LoaderLook(cboTipoVisa, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoVisa.EditValue = "D";
            BSUtils.LoaderLook(cboTipoMasterCard, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoMasterCard.EditValue = "D";
            BSUtils.LoaderLook(cboTipoMaster, CargarTipoMaster(), "Descripcion", "Id", false);
            cboTipoMaster.EditValue = 100;

            BSUtils.LoaderLook(cboTipoVisaRCP, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoVisaRCP.EditValue = "D";
            BSUtils.LoaderLook(cboTipoMasterCardRCP, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoMasterCardRCP.EditValue = "D";
            BSUtils.LoaderLook(cboCupon, CargarCupon(), "Descripcion", "Id", false);
            cboCupon.EditValue = 64;

            deFecha.EditValue = DateTime.Now;
            txtTotalResumen.EditValue = Total;
            txtResta.EditValue = Total; //add 
            gcPago.Select();
            txtEfectivo.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVisa.Focus();
                txtVisa.SelectAll();
            }
        }

        private void txtVisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMastercard.Focus();
                txtMastercard.SelectAll();
            }
        }

        private void txtMastercard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }

        private void btnImpresion_Click(object sender, EventArgs e)
        {

        }

        private void frmMsgPagoCondicion_Shown(object sender, EventArgs e)
        {
            bool bolFlag = false;

            TipoCambioBE objE_TipoCambio = null;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
            if (objE_TipoCambio == null)
            {
                XtraMessageBox.Show("Falta ingresar Tipo de Cambio del Día", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolFlag = true;
            }
            else
            {
                txtTC.EditValue = objE_TipoCambio.Compra;
            }

            if (bolFlag)
            {
                this.Close();
            }
        }

        private void txtEfectivo_EditValueChanged(object sender, EventArgs e)
        {
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtVisaPuntosVida.EditValue) + Convert.ToDecimal(txtMastercardPuntosVida.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            CalcularPago();
        }

        private void txtVisa_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPago();

            ////txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtVisaPuntosVida.EditValue) + Convert.ToDecimal(txtMastercardPuntosVida.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //if (Convert.ToDecimal(txtVisa.EditValue) > 0 || Convert.ToDecimal(txtMastercard.EditValue) > 0) //add 180216
            //{
            //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
            //    {
            //        lblMensaje.Text = "COBRAR EL 5% POR\nRECARGO DE TARJETA";
            //        gcReciboPago.Visible = true;
            //        this.Size = new Size(534, 539);
            //        txtTotalResumenRCP.EditValue =  (Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue))* Convert.ToDecimal("0.05"); //5% por Tarjeta
            //    }
            //}
            //else
            //{
            //    lblMensaje.Text = "";
            //}
        }

        private void txtMastercard_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPago();

            ////txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtVisaPuntosVida.EditValue) + Convert.ToDecimal(txtMastercardPuntosVida.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //if (Convert.ToDecimal(txtVisa.EditValue) > 0 || Convert.ToDecimal(txtMastercard.EditValue) > 0) //add 180216
            //{
            //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
            //    {
            //        lblMensaje.Text = "COBRAR EL 5% POR\nRECARGO DE TARJETA";
            //        gcReciboPago.Visible = true;
            //        this.Size = new Size(534, 539);
            //        txtTotalResumenRCP.EditValue = (Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue)) * Convert.ToDecimal("0.05"); //5% por Tarjeta
            //    }
            //}
            //else
            //{
            //    lblMensaje.Text = "";
            //}
        }

        private void txtImporteNCSoles_EditValueChanged(object sender, EventArgs e)
        {
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtVisaPuntosVida.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Activar pago con la nota de credito
            // EDGAR 190123: UPDATE - se cambió de la línea 264 "&&" por "||" - ERROR CORREGIDO -->
            if (chkActivaEmpresa.Checked == true || (IdTipoCliente == Parametros.intTipClienteMayorista || (Convert.ToDecimal(txtVisa.EditValue) > new decimal(0)) || (Convert.ToDecimal(txtMastercard.EditValue) > new decimal(0))))
            {
                //cobrar todo
                if (Convert.ToDecimal(txtResta.EditValue) > 0)
                {
                    XtraMessageBox.Show("Pendiente por cobrar: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEfectivo.Select();
                    txtEfectivo.SelectAll();
                    return;
                }

                //aprovecha el cobro
                if (Convert.ToDecimal(txtResta.EditValue) < 0)
                {
                    XtraMessageBox.Show("No se puede cobrar en negativo: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEfectivo.Select();
                    txtEfectivo.SelectAll();
                    return;
                }

                //5% Obligatorio
                if (Convert.ToDecimal(txtRestaRCP.EditValue) > 0 || Convert.ToDecimal(txtRestaRCP.EditValue) < 0)
                {
                    XtraMessageBox.Show("Pendiente por cobrar 5% de Tarjeta: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEfectivo.Select();
                    txtEfectivo.SelectAll();
                    return;
                }

                //Cupón
                if (Convert.ToDecimal(txtCupon2.EditValue) > 0 && txtNumeroCupon.Text.Trim() == string.Empty)
                {
                    XtraMessageBox.Show("Debe ingresar el código de cupón o eliminar el monto del cupón.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeroCupon.Focus();
                    return;
                }

                if (gcClienteReferido.Visible)
                {
                    if (IdClienteRef == 0)
                    {
                        XtraMessageBox.Show("Ud. Debe seleccionar el cliente referente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtDni.Focus();
                        return;
                    }

                    ////10% de la promocíón -- Add 13-01-2019
                    //if ((Convert.ToInt32(txtCupon.EditValue) / Convert.ToInt32(txtTotalResumen.EditValue)) * 100 > 10)
                    //{
                    //    XtraMessageBox.Show("Verificar el monto del vale ingresado, Para referidos sólo se puede aplicar el 10% del total.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    txtCupon.Focus();
                    //    return;
                    //}

                    //10% de la promocíón -- Add 13-01-2019
                    if (cboCupon.Text != "COMERCIO AMIGO")
                    {
                        if ((Convert.ToInt32(txtCupon2.EditValue) / Convert.ToInt32(txtTotalResumen.EditValue)) * 100 > 10)
                        {
                            XtraMessageBox.Show("Verificar el monto del vale ingresado, Para referidos sólo se puede aplicar el 10% del total.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtCupon2.Focus();
                            return;
                        }
                    }


                    // Restricción a clientes mayoristas para que no cojan el cupon
                    if (cboCupon.Text == "COMERCIO AMIGO" && IdTipoCliente == Parametros.intTipClienteMayorista)
                    {
                        XtraMessageBox.Show("No aplicable a clientes MAYORISTAS - Comercio Amigo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtCupon2.Focus();
                        return;
                    }
                }

                //Aplicar la nota de crédito dentro de la misma empresa
                if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0 && Convert.ToInt32(cboEmpresa.EditValue) != Convert.ToInt32(cboEmpresaOrigen.EditValue))
                {
                    XtraMessageBox.Show("La nota de crédito sólo puede aplicar en una Boleta/Factura de " + cboEmpresaOrigen.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //Mayor a 700
                int TipoDocFac = 0;
                TipoDocFac = Convert.ToInt32(cboDocumento.EditValue);
                if (TipoDocFac == Parametros.intTipoDocBoletaVenta || TipoDocFac == Parametros.intTipoDocFacturaVenta || TipoDocFac == Parametros.intTipoDocTicketBoleta || TipoDocFac == Parametros.intTipoDocTicketFactura || TipoDocFac == Parametros.intTipoDocBoletaElectronica || TipoDocFac == Parametros.intTipoDocFacturaElectronica)
                {
                    if (NumeroDocumento == Parametros.strNumeroCliente && Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intSoles && Convert.ToDecimal(txtTotalResumen.EditValue) >= 700 || NumeroDocumento == Parametros.strNumeroCliente && Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intDolares && Convert.ToDecimal(txtTotalResumen.EditValue) * Convert.ToDecimal(txtTC.EditValue) >= 700)
                    {
                        XtraMessageBox.Show("No se puede imprimir un comprobante como " + Parametros.intIdClienteGeneral + ", el importe es mayor a S/700\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura || TipoDocFac == Parametros.intTipoDocFacturaElectronica)
                {
                    if (NumeroDocumento.Trim().Length < 11 && IdTipoDocumentoClienteAsociado == 0)
                    {
                        XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoDNI)
                    {
                        XtraMessageBox.Show("No se puede imprimir una factura con ruc de ASOCIADO no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                #region "Obtener N° de Doc a Facturar"
                string NumeroDoc = "";

                //Traemos la información del pedido. //add 180917
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);
                if (objE_Pedido != null)
                {
                    if (objE_Pedido.IdClienteAsociado == 0)
                    {
                        NumeroDoc = objE_Pedido.NumeroDocumento;
                    }
                    else
                    {
                        NumeroDoc = objE_Pedido.NumeroDocumentoAsociado;
                    }

                    if (Convert.ToDecimal(txtTotalResumen.EditValue) != objE_Pedido.Total)
                    {
                        XtraMessageBox.Show("El monto a cobrar(" + txtTotalResumen.Text + ") difiere del pedido(" + objE_Pedido.Total + "), verificar con la vendedora si hubo modificación\nDebe cancelar esta opción y volver a cargar con F8.\nSi el problema persiste informar a sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    NumeroDoc = NumeroDocumento;
                }
                #endregion


                #region "Consulta RUC Data Local"
                int TipoDocFactP = Convert.ToInt32(cboDocumento.EditValue);

                if (TipoDocFactP == Parametros.intTipoDocBoletaElectronica)
                {
                    if (NumeroDoc.Length == 11)
                    {
                        XtraMessageBox.Show("No se puede emitir una boleta con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (TipoDocFactP == Parametros.intTipoDocFacturaElectronica)
                {
                    if (NumeroDoc.Trim().Length == 11)
                    {
                        ClienteBE objE_Cliente = null;
                        objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, NumeroDoc.Trim());
                        if (objE_Cliente != null)
                        {
                            //txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
                            //txtDescCliente.Text = objE_Cliente.DescCliente;
                            if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
                            {
                                XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
                            {
                                XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El RUC no existe en la base de datos " + objE_Cliente.DescCondicion + " Por favor consultar con Sistemas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("El RUC " + NumeroDoc + " no es válido, Por favor verificar que tenga 11 caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                #endregion

                //Cinco por ciento RCP
                if (Convert.ToDecimal(txtTotalResumenRCP.EditValue) > 0)
                {
                    if (chkEmitirComprobante.Checked) //add 100417
                    {
                        if (Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocTicketFactura || Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocFacturaElectronica)
                        {
                            if (NumeroDocumento.Trim().Length < 11 && IdTipoDocumentoClienteAsociado == 0)
                            {
                                XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoDNI)
                            {
                                XtraMessageBox.Show("No se puede imprimir una factura con ruc de ASOCIADO no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        #region "Consulta RUC Data Local RCP"
                        int TipoDocFact = Convert.ToInt32(cboDocumentoGenerarRCP.EditValue);

                        if (TipoDocFact == Parametros.intTipoDocBoletaElectronica)
                        {
                            if (NumeroDoc.Length == 11)
                            {
                                XtraMessageBox.Show("No se puede emitir una boleta de 5% con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (TipoDocFact == Parametros.intTipoDocFacturaElectronica)
                        {
                            if (NumeroDoc.Trim().Length == 11)
                            {
                                ClienteBE objE_Cliente = null;
                                objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, NumeroDoc.Trim());
                                if (objE_Cliente != null)
                                {
                                    //txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
                                    //txtDescCliente.Text = objE_Cliente.DescCliente;
                                    if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
                                    {
                                        XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
                                    {
                                        XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("El RUC no existe en la base de datos " + objE_Cliente.DescCondicion + " Por favor consultar con Sistemas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El RUC " + NumeroDoc + " no es válido, Por favor verificar que tenga 11 caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        #endregion
                    }

                    if (txtNumeroRCP.Text.Trim() == "" && chkEmitirComprobante.Checked == false)
                    {
                        XtraMessageBox.Show("Falta ingresar el número de RCP del 5%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        //AgregarReciboPagoCincoPorCiento();
                        InsertarDocumentoVentaPagoVarios(Convert.ToDecimal(txtEfectivoRCP.EditValue), Convert.ToDecimal(txtVisaRCP.EditValue), Convert.ToDecimal(txtMastercardRCP.EditValue), Convert.ToDecimal(txtVisaPuntosVida.EditValue), Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue), cboTipoVisaRCP.Text, cboTipoMasterCard.Text, 0);
                    }
                }

                this.DialogResult = DialogResult.OK;
                IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                Fecha = deFecha.DateTime;
                Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
                Visa = Convert.ToDecimal(txtVisa.EditValue);
                MasterCard = Convert.ToDecimal(txtMastercard.EditValue);
                VisaPuntosVida = Convert.ToDecimal(txtVisaPuntosVida.EditValue);
                MasterCardPuntosVida = Convert.ToDecimal(txtMastercardPuntosVida.EditValue); //add 080316
                VisaTipoTarjeta = cboTipoVisa.EditValue.ToString();
                MasterTipoTarjeta = cboTipoMasterCard.EditValue.ToString();
                Cupon = Convert.ToDecimal(txtCupon2.EditValue);
                NumeroCupon = cboCupon.Text + ": " + txtNumeroCupon.Text;
                IdTipoMaster = Convert.ToInt32(cboTipoMaster.EditValue);
                TipoDocBolFac = TipoDocFac;

                //IdEmpresaOrigen = Convert.ToInt32(cboEmpresaOrigen.EditValue);

                if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0)
                {
                    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        ActualizaNotaCredito();
                        NumeroNotaCredito = txtSerie.Text + "-" + txtNumeroDocumento.Text;
                    }
                    else
                    {
                        ActualizaSolicitud();
                        NumeroNotaCredito = txtNumeroDocumento.Text;
                    }
                }
                else
                {
                    NumeroNotaCredito = "";
                }

                //Actualiza GIFT CARD
                if (IdTarjetaRegalo > 0)
                {
                    TarjetaRegaloBE ObjE_Tarjeta = new TarjetaRegaloBE();
                    TarjetaRegaloBL objBL_Tarjeta = new TarjetaRegaloBL();

                    ObjE_Tarjeta.IdTarjetaRegalo = IdTarjetaRegalo;
                    ObjE_Tarjeta.IdCliente = IdCliente;
                    ObjE_Tarjeta.IdEmpresa = Parametros.intEmpresaId;
                    ObjE_Tarjeta.IdTienda = Parametros.intTiendaId;
                    ObjE_Tarjeta.ImporteUtilizado = Convert.ToDecimal(txtCupon2.EditValue);
                    ObjE_Tarjeta.IdSituacion = Parametros.intGiftCardActivo;
                    ObjE_Tarjeta.FlagEstado = true;
                    objBL_Tarjeta.ActualizaDisponible(ObjE_Tarjeta);
                }

                //if (IdClienteRef > 0)
                //{
                //    if (InsertaClienteReferido())
                //    {
                //        XtraMessageBox.Show("Se registró en el EECC la comisión por Referido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}

                if (IdClienteRef > 0)
                {
                    if (cboCupon.Text == "COMERCIO AMIGO")
                    {
                        if (InsertaClienteComercioAmigo())
                        {
                            XtraMessageBox.Show("Se registró la venta para el Comercio Amigo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (InsertaClienteReferido())
                        {
                            XtraMessageBox.Show("Se registró en el EECC la comisión por Referido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            else
            {
                mListaDetalle = null;
                mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

                IList list = cboEmpresa.Properties.DataSource as IList;
                int count = list.Count;

                // Bucle de las empresas
                for (int i = 0; i < count; i++)
                {
                    valueId2 = Convert.ToInt32(cboEmpresa.Properties.GetDataSourceValue("IdEmpresa", i));
                    value2 = Convert.ToString(cboEmpresa.Properties.GetDataSourceValue("RazonSocial", i));
                    //     XtraMessageBox.Show(value.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //cobrar todo
                    if (Convert.ToDecimal(txtResta.EditValue) > 0)
                    {
                        XtraMessageBox.Show("Pendiente por cobrar: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEfectivo.Select();
                        txtEfectivo.SelectAll();
                        return;
                    }

                    //aprovecha el cobro
                    if (Convert.ToDecimal(txtResta.EditValue) < 0)
                    {
                        XtraMessageBox.Show("No se puede cobrar en negativo: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEfectivo.Select();
                        txtEfectivo.SelectAll();
                        return;
                    }

                    //5% Obligatorio
                    if (Convert.ToDecimal(txtRestaRCP.EditValue) > 0 || Convert.ToDecimal(txtRestaRCP.EditValue) < 0)
                    {
                        XtraMessageBox.Show("Pendiente por cobrar 5% de Tarjeta: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEfectivo.Select();
                        txtEfectivo.SelectAll();
                        return;
                    }

                    //Cupón
                    if (Convert.ToDecimal(txtCupon2.EditValue) > 0 && txtNumeroCupon.Text.Trim() == string.Empty)
                    {
                        XtraMessageBox.Show("Debe ingresar el código de cupón o eliminar el monto del cupón.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNumeroCupon.Focus();
                        return;
                    }

                    if (gcClienteReferido.Visible)
                    {
                        if (IdClienteRef == 0)
                        {
                            XtraMessageBox.Show("Ud. Debe seleccionar el cliente referente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtDni.Focus();
                            return;
                        }

                        //10% de la promocíón -- Add 13-01-2019
                        if (cboCupon.Text != "COMERCIO AMIGO")
                        {
                            if ((Convert.ToInt32(txtCupon2.EditValue) / Convert.ToInt32(txtTotalResumen.EditValue)) * 100 > 10)
                            {
                                XtraMessageBox.Show("Verificar el monto del vale ingresado, Para referidos sólo se puede aplicar el 10% del total.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                txtCupon2.Focus();
                                return;
                            }
                        }
                    }

                    // Restricción a clientes mayoristas para que no cojan el cupon
                    if (cboCupon.Text == "COMERCIO AMIGO" && IdTipoCliente == Parametros.intTipClienteMayorista)
                    {
                        XtraMessageBox.Show("No aplicable a clientes MAYORISTAS.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtCupon2.Focus();
                        return;
                    }


                    //Aplicar la nota de crédito dentro de la misma empresa
                    if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0 && Convert.ToInt32(valueId2) != Convert.ToInt32(cboEmpresaOrigen.EditValue))
                    {
                        XtraMessageBox.Show("La nota de crédito sólo puede aplicar en una Boleta/Factura de " + cboEmpresaOrigen.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Mayor a 700
                    int TipoDocFac = 0;
                    TipoDocFac = Convert.ToInt32(cboDocumento.EditValue);
                    if (TipoDocFac == Parametros.intTipoDocBoletaVenta || TipoDocFac == Parametros.intTipoDocFacturaVenta || TipoDocFac == Parametros.intTipoDocTicketBoleta
                     || TipoDocFac == Parametros.intTipoDocTicketFactura || TipoDocFac == Parametros.intTipoDocBoletaElectronica || TipoDocFac == Parametros.intTipoDocFacturaElectronica)
                    {
                        if (NumeroDocumento == Parametros.strNumeroCliente && Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intSoles && Convert.ToDecimal(txtTotalResumen.EditValue) >= 700 || NumeroDocumento == Parametros.strNumeroCliente && Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intDolares && Convert.ToDecimal(txtTotalResumen.EditValue) * Convert.ToDecimal(txtTC.EditValue) >= 700)
                        {
                            XtraMessageBox.Show("No se puede imprimir un comprobante como " + Parametros.intIdClienteGeneral + ", el importe es mayor a S/700\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura || TipoDocFac == Parametros.intTipoDocFacturaElectronica)
                    {
                        if (NumeroDocumento.Trim().Length < 11 && IdTipoDocumentoClienteAsociado == 0)
                        {
                            XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + value2.ToString() + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoDNI)
                        {
                            XtraMessageBox.Show("No se puede imprimir una factura con ruc de ASOCIADO no válido: " + value2.ToString() + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    #region "Obtener N° de Doc a Facturar"
                    string NumeroDoc = "";

                    //Traemos la información del pedido. //add 180917
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);
                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.IdClienteAsociado == 0)
                        {
                            NumeroDoc = objE_Pedido.NumeroDocumento;
                        }
                        else
                        {
                            NumeroDoc = objE_Pedido.NumeroDocumentoAsociado;
                        }

                        if (Convert.ToDecimal(txtTotalResumen.EditValue) != objE_Pedido.Total)
                        {
                            XtraMessageBox.Show("El monto a cobrar(" + txtTotalResumen.Text + ") difiere del pedido(" + objE_Pedido.Total + "), verificar con la vendedora si hubo modificación\nDebe cancelar esta opción y volver a cargar con F8.\nSi el problema persiste informar a sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        NumeroDoc = NumeroDocumento;
                    }
                    #endregion

                    #region "Consulta RUC Data Local"
                    int TipoDocFactP = Convert.ToInt32(cboDocumento.EditValue);

                    if (TipoDocFactP == Parametros.intTipoDocBoletaElectronica)
                    {
                        if (NumeroDoc.Length == 11)
                        {
                            XtraMessageBox.Show("No se puede emitir una boleta con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (TipoDocFactP == Parametros.intTipoDocFacturaElectronica)
                    {
                        if (NumeroDoc.Trim().Length == 11)
                        {
                            ClienteBE objE_Cliente = null;
                            objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, NumeroDoc.Trim());
                            if (objE_Cliente != null)
                            {
                                //txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
                                //txtDescCliente.Text = objE_Cliente.DescCliente;
                                if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
                                {
                                    XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
                                {
                                    XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El RUC no existe en la base de datos " + objE_Cliente.DescCondicion + " Por favor consultar con Sistemas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El RUC " + NumeroDoc + " no es válido, Por favor verificar que tenga 11 caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    #endregion

                    //Cinco por ciento RCP
                    if (Convert.ToDecimal(txtTotalResumenRCP.EditValue) > 0)
                    {
                        if (chkEmitirComprobante.Checked) //add 100417
                        {
                            if (Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocTicketFactura || Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocFacturaElectronica)
                            {
                                if (NumeroDocumento.Trim().Length < 11 && IdTipoDocumentoClienteAsociado == 0)
                                {
                                    XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoDNI)
                                {
                                    XtraMessageBox.Show("No se puede imprimir una factura con ruc de ASOCIADO no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            #region "Consulta RUC Data Local RCP"
                            int TipoDocFact = Convert.ToInt32(cboDocumentoGenerarRCP.EditValue);

                            if (TipoDocFact == Parametros.intTipoDocBoletaElectronica)
                            {
                                if (NumeroDoc.Length == 11)
                                {
                                    XtraMessageBox.Show("No se puede emitir una boleta de 5% con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            if (TipoDocFact == Parametros.intTipoDocFacturaElectronica)
                            {
                                if (NumeroDoc.Trim().Length == 11)
                                {
                                    ClienteBE objE_Cliente = null;
                                    objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, NumeroDoc.Trim());
                                    if (objE_Cliente != null)
                                    {
                                        //txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
                                        //txtDescCliente.Text = objE_Cliente.DescCliente;
                                        if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
                                        {
                                            XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
                                        {
                                            XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("El RUC no existe en la base de datos " + objE_Cliente.DescCondicion + " Por favor consultar con Sistemas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("El RUC " + NumeroDoc + " no es válido, Por favor verificar que tenga 11 caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            #endregion
                        }

                        if (txtNumeroRCP.Text.Trim() == "" && chkEmitirComprobante.Checked == false)
                        {
                            XtraMessageBox.Show("Falta ingresar el número de RCP del 5%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            //AgregarReciboPagoCincoPorCiento();
                            InsertarDocumentoVentaPagoVarios(Convert.ToDecimal(txtEfectivoRCP.EditValue), Convert.ToDecimal(txtVisaRCP.EditValue), Convert.ToDecimal(txtMastercardRCP.EditValue), Convert.ToDecimal(txtVisaPuntosVida.EditValue), Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue), cboTipoVisaRCP.Text, cboTipoMasterCard.Text, 0);
                        }
                    }

                    //No genera fact en los RER
                    if ((Convert.ToInt32(valueId2) == 3 || Convert.ToInt32(valueId2) == 19 || Convert.ToInt32(valueId2) == 21 || Convert.ToInt32(valueId2) == 23 || Convert.ToInt32(valueId2) == 8 || Convert.ToInt32(valueId2) == 20) && TipoDocFac == Parametros.intTipoDocFacturaElectronica)
                    {
                        continue;
                    }
                    //Validar cuando es RER no permita boletearlo con cliente Mayorista
                    if (Convert.ToInt32(valueId2) == 3 || Convert.ToInt32(valueId2) == 19 || Convert.ToInt32(valueId2) == 21 ||
                        Convert.ToInt32(valueId2) == 23 || Convert.ToInt32(valueId2) == 8 || Convert.ToInt32(valueId2) == 20)
                    {
                        if (IdTipoCliente == 87)
                        {
                            //XtraMessageBox.Show("Solo puede emitir RER de " + value2.ToString() + "\n a Clientes Finales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            continue;
                        }
                        //Valida descto mayores al 30 % en RER
                        if (DescuentoFlag == false)
                        {
                            bool qValorReturn = ValidaPorcentajeDescuento();
                            if (qValorReturn)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (!ValidarTopeEmpresaRus())
                    {
                        if (!ValidarTopeEmpresaDiarioRus())
                        {
                            this.DialogResult = DialogResult.OK;
                            IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            IdEmpresa = Convert.ToInt32(valueId2);
                            Fecha = deFecha.DateTime;
                            Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
                            Visa = Convert.ToDecimal(txtVisa.EditValue);
                            MasterCard = Convert.ToDecimal(txtMastercard.EditValue);
                            VisaPuntosVida = Convert.ToDecimal(txtVisaPuntosVida.EditValue);
                            MasterCardPuntosVida = Convert.ToDecimal(txtMastercardPuntosVida.EditValue); //add 080316
                            VisaTipoTarjeta = cboTipoVisa.EditValue.ToString();
                            MasterTipoTarjeta = cboTipoMasterCard.EditValue.ToString();

                            if (Convert.ToInt32(cboCupon.EditValue) == 2)
                            {
                                Cupon = Convert.ToDecimal(txtCupon2.EditValue);
                            }
                            else
                            {
                                Cupon = Convert.ToDecimal(txtResta.EditValue) > Convert.ToDecimal(txtCupon.EditValue) ? Convert.ToDecimal(txtCupon.EditValue) : Convert.ToDecimal(txtCupon.EditValue) - Convert.ToDecimal(txtCupon2.EditValue);
                            }




                            NumeroCupon = cboCupon.Text + ": " + txtNumeroCupon.Text;
                            IdTipoMaster = Convert.ToInt32(cboTipoMaster.EditValue);
                            TipoDocBolFac = TipoDocFac;

                            //IdEmpresaOrigen = Convert.ToInt32(cboEmpresaOrigen.EditValue);

                            if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0)
                            {
                                if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                                {
                                    ActualizaNotaCredito();
                                    NumeroNotaCredito = txtSerie.Text + "-" + txtNumeroDocumento.Text;
                                }
                                else
                                {
                                    ActualizaSolicitud();
                                    NumeroNotaCredito = txtNumeroDocumento.Text;
                                }
                            }
                            else
                            {
                                NumeroNotaCredito = "";
                            }

                            //Actualiza GIFT CARD
                            if (IdTarjetaRegalo > 0)
                            {
                                TarjetaRegaloBE ObjE_Tarjeta = new TarjetaRegaloBE();
                                TarjetaRegaloBL objBL_Tarjeta = new TarjetaRegaloBL();

                                ObjE_Tarjeta.IdTarjetaRegalo = IdTarjetaRegalo;
                                ObjE_Tarjeta.IdCliente = IdCliente;
                                ObjE_Tarjeta.IdEmpresa = Parametros.intEmpresaId;
                                ObjE_Tarjeta.IdTienda = Parametros.intTiendaId;
                                ObjE_Tarjeta.ImporteUtilizado = Convert.ToDecimal(txtResta.EditValue) > Convert.ToDecimal(txtCupon.EditValue) ? Convert.ToDecimal(txtCupon.EditValue) : Convert.ToDecimal(txtCupon.EditValue) - Convert.ToDecimal(txtCupon2.EditValue);
                                ObjE_Tarjeta.IdSituacion = Parametros.intGiftCardActivo;
                                ObjE_Tarjeta.FlagEstado = true;
                                objBL_Tarjeta.ActualizaDisponible(ObjE_Tarjeta);
                            }


                            if (IdClienteRef > 0)
                            {
                                if (cboCupon.Text == "COMERCIO AMIGO")
                                {
                                    if (InsertaClienteComercioAmigo())
                                    {
                                        XtraMessageBox.Show("Se registró la venta para el Comercio Amigo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    if (InsertaClienteReferido())
                                    {
                                        XtraMessageBox.Show("Se registró en el EECC la comisión por Referido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }

                        }
                        else
                        { continue; }
                    }
                    else
                    { continue; }
                    return;
                }
            }
        }


        private bool ValidarTopeEmpresaRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total2 = Total;

            if (Convert.ToInt32(valueId2) != Parametros.intPanoraramaDistribuidores)
            {
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(Convert.ToInt32(valueId2));

                decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.Tope;
                    //Parametros.dmlTopeEmpresaDiarioRUS = objE_TopeEmpresa.TopeDiario;//add 07012016
                }

                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaPeriodo(Convert.ToInt32(valueId2), deFecha.DateTime.Year, deFecha.DateTime.Month);
                //                objE_DocumentoDia = new DocumentoVentaBL().SeleccionaEmpresaPeriodoDia(Convert.ToInt32(cboEmpresa.EditValue), deFecha.DateTime.Year, deFecha.DateTime.Month);
                decimal TotalVentaDia = 0;
                decimal TotalVentaMensual = 0;

                if (objE_Documento != null)
                {
                    TotalVentaMensual = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVentaMensual = 0;
                }

                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(valueId2));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                    {
                        // Validación por el monto total - Mensual
                        if (TotalVentaMensual > Tope)
                        {
                            //  XtraMessageBox.Show("El importe de venta sobrepasa el tope mensual del RUS, por favor verifique.\n Consultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                            //return;
                        }
                        else
                        {
                            //XtraMessageBox.Show("No llega al Tope Mensual, continuamos ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = false;
                        }



                    }
                }
            }

            if (flag)
            {
                //XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private bool ValidarTopeEmpresaDiarioRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total2 = Total;

            if (valueId2 != Parametros.intPanoraramaDistribuidores)
            {
                /// *****************************************************************************************
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(Convert.ToInt32(valueId2));

                decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.TopeDiario;
                }
                /// ******************************************************************************************
               // decimal Tope = Parametros.dmlTopeEmpresaDiarioRUS;
                //decimal Tope = Parametros.dmlTopeEmpresaDiarioRUS;
                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaFecha(Convert.ToInt32(valueId2), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                decimal TotalVenta = 0;

                if (objE_Documento != null)
                {
                    TotalVenta = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVenta = 0;
                }


                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(valueId2));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                    {
                        if (TotalVenta > Tope)
                        {
                            //   XtraMessageBox.Show("El importe de venta sobrepasa el tope diario del RUS, por favor verifique.\n Consultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                            //return;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }

            if (flag)
            {
                //   XtraMessageBox.Show(strMensaje + ": Supera TOPE diario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //Cursor = Cursors.Default;
            }
            return flag;
        }
        private bool ValidaPorcentajeDescuento()
        {
            bool flag = false;
            //Documento Vneta Detalle
            List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
            lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

            foreach (var item in mListaDetalle)
            {
                if (item.PorcentajeDescuento > 30)
                {
                    flag = true;
                }
            }

            return flag;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboDocumentoCR_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
            {
                txtSerie.Enabled = true;
                txtSerie.Select();
                ////cboEmpresaOrigen.Enabled = false;
                //cboEmpresaOrigen.Properties.ReadOnly = true;
                cboEmpresaOrigen.EditValue = Parametros.intEmpresaId;
            }
            else
            {
                txtSerie.Enabled = false;
                txtNumeroDocumento.Focus();
                //cboEmpresaOrigen.Enabled = true;
                cboEmpresaOrigen.Properties.ReadOnly = false;
            }

            //if (Parametros.dtFechaHoraServidor == Convert.ToDateTime("08/11/2014") && Parametros.intTiendaId == Parametros.intTiendaPrescott)
            //{
            //    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocValeDescuento)
            //    {
            //        txtImporteNCSoles.EditValue = 50;
            //        txtNumeroDocumento.Text = "VALE";
            //        txtEfectivo.Focus();
            //    }
            //}


        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text.Trim(), txtNumeroDocumento.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            //Verificar si la NC está usada
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text + "-" + objE_DocumentoVenta.Numero); //txtNumeroDocumento.Text);
                            if (objE_MovimientoCaja != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " ya está usada, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            //Verificar Estado de cuenta
                            EstadoCuentaBE objE_EstadoCuenta = null;
                            objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaDocumentoVenta(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);

                            if (objE_EstadoCuenta != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " ya existe en el estado de cuenta Mayorista, por lo tanto no se puede aplicar, por favor consultar con Créditos y Cobranzas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            //Verificar Estado de cuenta C. Final
                            SeparacionBE objE_Separacion = null;
                            objE_Separacion = new SeparacionBL().SeleccionaDocumentoVenta(objE_DocumentoVenta.IdDocumentoVenta);

                            if (objE_Separacion != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " ya existe en el estado de cuenta C. Final, por lo tanto no se puede aplicar, por favor consultar con Créditos y Cobranzas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            if (objE_DocumentoVenta.IdCliente != IdCliente)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " No pertenece al cliente: " + DescCliente, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                #region "Motivos excepcionales"
                                //if (objE_DocumentoVenta.CodigoNC == "01")
                                //{
                                //    XtraMessageBox.Show("No se puede aplicar una Nota de crédito con motivo: ANULACIÓN DE LA OPERACION.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //    return;
                                //}
                                //else if (objE_DocumentoVenta.CodigoNC == "02")
                                //{
                                //    XtraMessageBox.Show("No se puede aplicar una Nota de crédito con motivo: ANULACIÓN POR ERROR EN EL RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //    return;
                                //}
                                //else if (objE_DocumentoVenta.CodigoNC == "03")
                                //{
                                //    XtraMessageBox.Show("No se puede aplicar una Nota de crédito con motivo: CORRECCIÓN POR ERROR EN LA DESCRIPCION.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //    return;
                                //}

                                #endregion
                            }

                            ////Mayorista en Estado de cuenta
                            //EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                            //objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaDocumentoVenta(objE_DocumentoVenta.IdDocumentoVenta);

                            //if (objE_EstadoCuenta != null)
                            //{
                            //    if (XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " ya existe cómo saldo a favor en el estado de Cuenta\nDesea Eliminar el cobro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.Yes)
                            //    {
                            //        //Eliminar del Estado de cuenta
                            //    }
                            //    else
                            //    {
                            //        LimpiarPago();
                            //        return;
                            //    }
                            //}

                            //////if (objE_DocumentoVenta.IdTipoCliente == Parametros.intTipClienteMayorista)
                            //////{
                            //////    XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " No se puede aplicar, El Cliente es Mayorista.\nPor lo tanto tiene u", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //////    //LimpiarPago();
                            //////    //return;
                            //////}

                            //De aqui el documento
                            IdDocumentoNC = objE_DocumentoVenta.IdDocumentoVenta;
                            txtCodMonedaPedido.Text = objE_DocumentoVenta.CodMoneda;
                            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                            txtImporteNCDolares.EditValue = objE_DocumentoVenta.Total;
                            txtNumeroDocumento.Text = objE_DocumentoVenta.Numero;
                            cboEmpresaOrigen.Properties.ReadOnly = true;
                            if (objE_DocumentoVenta.CodMoneda == "US$")
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total * Convert.ToDecimal(txtTC.Text);
                                txtEfectivo.Focus();
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total;
                                txtEfectivo.Focus();
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("No existe la nota de credito en: " + cboEmpresaOrigen.Text + ", debe ser genereado por \nel área de facturación antes de seguir su proceso, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimpiarPago();
                        }
                    }
                    else
                    {
                        //Cuando es solicitud de devolucion

                        CambioBE objE_Cambio = null;
                        objE_Cambio = new CambioBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Parametros.intPeriodo, txtNumeroDocumento.Text.Trim());
                        if (objE_Cambio != null)
                        {

                            //Verificar si la SD está usada
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), objE_Cambio.Numero);
                            if (objE_MovimientoCaja != null)
                            {
                                XtraMessageBox.Show("La Solicitud de devolución " + txtNumeroDocumento.Text + ", ya está usada, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            //Documento Cambio
                            txtCodMonedaPedido.Text = objE_Cambio.CodMoneda;
                            txtDescCliente.Text = objE_Cambio.DescCliente;
                            txtImporteNCDolares.EditValue = objE_Cambio.Total;
                            txtNumeroDocumento.Text = objE_Cambio.Numero;
                            if (objE_Cambio.CodMoneda == "US$")
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total * Convert.ToDecimal(txtTC.Text);
                                txtEfectivo.Focus();
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total;
                                txtEfectivo.Focus();
                            }
                        }

                        else
                        {
                            XtraMessageBox.Show("No existe la solicitud de devolución N°" + txtNumeroDocumento.Text + " para la empresa: " + cboEmpresaOrigen.Text + ", \npor favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimpiarPago();
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTipoVisa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoVisa.EditValue.ToString() == "C")
                cboTipoVisa.BackColor = Color.LightCoral;
            else
                cboTipoVisa.BackColor = Color.LightGreen;

        }

        private void cboTipoMasterCard_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoMasterCard.EditValue.ToString() == "C")
                cboTipoMasterCard.BackColor = Color.LightCoral;
            else
                cboTipoMasterCard.BackColor = Color.LightGreen;
        }

        private void txtMastercardPuntosVida_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPago();
            ////txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtVisaPuntosVida.EditValue) + Convert.ToDecimal(txtMastercardPuntosVida.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //if (Convert.ToDecimal(txtVisa.EditValue) > 0 || Convert.ToDecimal(txtMastercard.EditValue) > 0) //add 180216
            //{
            //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
            //    {
            //        lblMensaje.Text = "COBRAR EL 5% POR\nRECARGO DE TARJETA";
            //        txtTotalResumenRCP.EditValue = (Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue)) * Convert.ToDecimal("0.05"); //5% por Tarjeta
            //    }
            //}
            //else
            //{
            //    lblMensaje.Text = "";
            //}
        }

        private void txtVisaPuntosVida_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPago();
            ////txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtVisaPuntosVida.EditValue) + Convert.ToDecimal(txtMastercardPuntosVida.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
            //if (Convert.ToDecimal(txtVisa.EditValue) > 0 || Convert.ToDecimal(txtMastercard.EditValue) > 0) //add 180216
            //{
            //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
            //    {
            //        lblMensaje.Text = "COBRAR EL 5% POR\nRECARGO DE TARJETA";
            //        txtTotalResumenRCP.EditValue = (Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue)) * Convert.ToDecimal("0.05"); //5% por Tarjeta
            //    }
            //}
            //else
            //{
            //    lblMensaje.Text = "";
            //}
        }

        private void txtEfectivoRCP_EditValueChanged(object sender, EventArgs e)
        {
            txtRestaRCP.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue) - (Convert.ToDecimal(txtEfectivoRCP.EditValue) + Convert.ToDecimal(txtVisaRCP.EditValue) + Convert.ToDecimal(txtMastercardRCP.EditValue) + Convert.ToDecimal(txtVisaPuntosVidaRCP.EditValue) + Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue)), 2);

        }

        private void txtVisaRCP_EditValueChanged(object sender, EventArgs e)
        {
            txtRestaRCP.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue) - (Convert.ToDecimal(txtEfectivoRCP.EditValue) + Convert.ToDecimal(txtVisaRCP.EditValue) + Convert.ToDecimal(txtMastercardRCP.EditValue) + Convert.ToDecimal(txtVisaPuntosVidaRCP.EditValue) + Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue)), 2);
        }

        private void txtMastercardRCP_EditValueChanged(object sender, EventArgs e)
        {
            txtRestaRCP.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue) - (Convert.ToDecimal(txtEfectivoRCP.EditValue) + Convert.ToDecimal(txtVisaRCP.EditValue) + Convert.ToDecimal(txtMastercardRCP.EditValue) + Convert.ToDecimal(txtVisaPuntosVidaRCP.EditValue) + Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue)), 2);
        }

        private void txtVisaPuntosVidaRCP_EditValueChanged(object sender, EventArgs e)
        {
            txtRestaRCP.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue) - (Convert.ToDecimal(txtEfectivoRCP.EditValue) + Convert.ToDecimal(txtVisaRCP.EditValue) + Convert.ToDecimal(txtMastercardRCP.EditValue) + Convert.ToDecimal(txtVisaPuntosVidaRCP.EditValue) + Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue)), 2);
        }

        private void txtMastercardPuntosVidaRCP_EditValueChanged(object sender, EventArgs e)
        {
            txtRestaRCP.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue) - (Convert.ToDecimal(txtEfectivoRCP.EditValue) + Convert.ToDecimal(txtVisaRCP.EditValue) + Convert.ToDecimal(txtMastercardRCP.EditValue) + Convert.ToDecimal(txtVisaPuntosVidaRCP.EditValue) + Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue)), 2);
        }

        private void txtCupon_EditValueChanged(object sender, EventArgs e)
        {
            //if(Convert.ToDecimal(txtCupon.EditValue)> ImporteCupon)
            //{
            //    XtraMessageBox.Show("EL importe debe ser igual o menor al Importe disponible del GIFT CARD");
            //    txtCupon.EditValue = ImporteCupon;
            //}
            CalcularPago();
        }

        private void txtVisaPuntosVida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMastercardPuntosVida.Focus();
                txtMastercardPuntosVida.SelectAll();
            }

        }

        private void txtMastercardPuntosVida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumeroCupon.Focus();
                txtNumeroCupon.SelectAll();
            }
        }

        private void txtNumeroCupon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cboCupon.EditValue) == Parametros.intTblSituacionGiftCard)
                {
                    TarjetaRegaloBE objBE_Tarjeta = null;
                    objBE_Tarjeta = new TarjetaRegaloBL().SeleccionaNumero(txtNumeroCupon.Text.Trim());
                    if (objBE_Tarjeta != null)
                    {
                        if (objBE_Tarjeta.ImporteDisponible <= 0)
                        {
                            XtraMessageBox.Show("La tarjeta/Vale está aplicada al 100%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        txtCupon.EditValue = objBE_Tarjeta.ImporteDisponible;
                        ImporteCupon = objBE_Tarjeta.ImporteDisponible;
                        IdTarjetaRegalo = objBE_Tarjeta.IdTarjetaRegalo;
                        txtNumeroCupon.Properties.ReadOnly = true;
                        txtCupon.Properties.ReadOnly = true;
                        cboCupon.Properties.ReadOnly = true;

                        #region "Limpiar Cliente Referido"
                        gcClienteReferido.Visible = false;
                        IdTipoClienteRef = 0;
                        IdClienteRef = 0;
                        txtDescClienteRef.Text = "";
                        txtDni.Text = "";

                        txtCupon2.Text = String.Format("{0:#,##0.00}", (Convert.ToDecimal(txtCupon.Text) - Convert.ToDecimal(txtResta.Text)) < 0 ? 0 : Convert.ToDecimal(txtCupon.Text) - Convert.ToDecimal(txtResta.Text));
                        txtCupon.Select();
                        txtCupon_EditValueChanged(null, null);
                        #endregion
                    }
                    else
                    {
                        XtraMessageBox.Show("Codigo de la GIFT CARD no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (Convert.ToInt32(cboCupon.EditValue) == 2)
                {
                    #region "Vale"
                    frmVerValeDisponible frm = new frmVerValeDisponible();
                    frm.TipoVale = 2;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.ImporteVale > 0)
                        {
                            if (frm.IdTipoPromocion == Parametros.intPromClienteReferido)
                            {
                                gcClienteReferido.Visible = true;
                                txtNumeroCupon.Text = "S/" + frm.ImporteVale + "|COD:" + frm.IdPromocionValeDescuento;
                                txtCupon2.EditValue = frm.ImporteVale;
                                txtNumeroCupon.Properties.ReadOnly = true;
                                //txtCupon.Properties.ReadOnly = true;

                                txtDni.Select();
                            }
                            else
                            {
                                gcClienteReferido.Visible = false;
                                IdTipoClienteRef = 0;
                                IdClienteRef = 0;
                                txtDescClienteRef.Text = "";
                                txtDni.Text = "";

                                txtNumeroCupon.Text = "S/" + frm.ImporteVale + "|COD:" + frm.IdPromocionValeDescuento;
                                txtCupon2.EditValue = frm.ImporteVale;
                                txtNumeroCupon.Properties.ReadOnly = true;
                                txtCupon2.Properties.ReadOnly = true;
                                XtraMessageBox.Show("El vale debe ser retenido con la copia de la Boleta y/o Factura.\nPara su posterior verificación con Auditoria", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtNumeroCupon.Text = "";
                            txtNumeroCupon.Enabled = false;
                            txtCupon2.EditValue = "0.00";
                        }
                    }

                    cboCupon.Properties.ReadOnly = true;
                    txtCupon2.Focus();
                    txtCupon2.SelectAll();
                    #endregion
                }
            }
        }

        private void txtCupon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }

        private void cboEmpresaOrigen_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCupon_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCupon.EditValue) == Parametros.intPromClienteReferido)
            {
                txtNumeroCupon.Focus();
            }
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDni.Text.Trim().Length > 0)
                {
                    if (cboCupon.Text == "COMERCIO AMIGO")
                    {
                        if (char.IsNumber(Convert.ToChar(txtDni.Text.Trim().Substring(0, 1))) == true)
                        {
                            ClienteBE objE_Cliente = null;
                            objE_Cliente = new ClienteBL().SeleccionaNumeroComercio(Parametros.intEmpresaId, txtDni.Text.Trim());
                            if (objE_Cliente != null)
                            {
                                PersonaBE objBE_Persona = null;
                                objBE_Persona = new PersonaBL().SeleccionaNumeroDocumento(objE_Cliente.NumeroDocumento);
                                if (objBE_Persona == null)
                                {
                                    IdClienteRef = objE_Cliente.IdCliente;
                                    txtDni.Text = objE_Cliente.NumeroDocumento;
                                    txtDescClienteRef.Text = objE_Cliente.DescCliente;
                                    IdTipoClienteRef = objE_Cliente.IdTipoCliente;

                                    txtDni.Properties.ReadOnly = true;
                                    txtDescClienteRef.Properties.ReadOnly = true;

                                    txtEfectivo.Select();
                                }
                                else
                                {
                                    XtraMessageBox.Show("El trabajador no puede referir a clientes. Consulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El número de documento de cliente no figura como comercio Amigo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            btnBuscar_Click(sender, e);
                        }
                    }
                    else
                    {
                        if (char.IsNumber(Convert.ToChar(txtDni.Text.Trim().Substring(0, 1))) == true)
                        {
                            ClienteBE objE_Cliente = null;
                            objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtDni.Text.Trim());
                            if (objE_Cliente != null)
                            {
                                PersonaBE objBE_Persona = null;
                                objBE_Persona = new PersonaBL().SeleccionaNumeroDocumento(objE_Cliente.NumeroDocumento);
                                if (objBE_Persona == null)
                                {
                                    IdClienteRef = objE_Cliente.IdCliente;
                                    txtDni.Text = objE_Cliente.NumeroDocumento;
                                    txtDescClienteRef.Text = objE_Cliente.DescCliente;
                                    IdTipoClienteRef = objE_Cliente.IdTipoCliente;
                                    gcClienteReferido.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;

                                    txtDni.Properties.ReadOnly = true;
                                    txtDescClienteRef.Properties.ReadOnly = true;

                                    txtEfectivo.Select();
                                }
                                else
                                {
                                    XtraMessageBox.Show("El trabajador no puede referir a clientes. Consulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            btnBuscar_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtDni.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdClienteRef = frm.pClienteBE.IdCliente;
                    txtDni.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescClienteRef.Text = frm.pClienteBE.DescCliente;
                    IdTipoClienteRef = frm.pClienteBE.IdTipoCliente;
                    if (cboCupon.Text == "COMERCIO AMIGO")
                    {
                        gcClienteReferido.Text = "COMERCIO AMIGO";
                    }
                    else
                    {
                        gcClienteReferido.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                    }
                    txtDni.Properties.ReadOnly = true;
                    txtDescClienteRef.Properties.ReadOnly = true;

                    txtEfectivo.Select();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void LimpiarPago()
        {
            IdDocumentoNC = 0;
            txtImporteNCSoles.EditValue = 0;
            txtImporteNCDolares.EditValue = 0;
            txtDescCliente.Text = "";
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "BOV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 26;
            dr["Descripcion"] = "FAV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 90;
            dr["Descripcion"] = "TKV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 91;
            dr["Descripcion"] = "TKF";
            dt.Rows.Add(dr);
            return dt;
        }

        private void ActualizaNotaCredito()
        {
            PagosBL objBL_Pagos = new PagosBL();

            //Datos del Recibo de Pago
            PagosBE objPago = new PagosBE();
            objPago.IdPago = 0;
            objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
            objPago.IdCaja = Parametros.intCajaId; //Convert.ToInt32(cboCaja.EditValue);
            objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objPago.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
            string Numero = "";
            Numero = txtSerie.Text + "-" + txtNumeroDocumento.Text;
            objPago.NumeroDocumento = Numero;
            objPago.IdCondicionPago = Parametros.intEfectivo;
            objPago.Concepto = "APLICACION NOTA DE CREDITO";
            objPago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
            objPago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
            objPago.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objPago.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTC.EditValue);
            objPago.FlagEstado = true;
            objPago.Usuario = Parametros.strUsuarioLogin;
            objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objPago.IdEmpresa = Convert.ToInt32(cboEmpresaOrigen.EditValue); //Convert.ToInt32(cboEmpresa.EditValue);

            //Datos del Movimiento de Caja
            List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

            MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
            objMovimientoCaja.IdMovimientoCaja = 0;
            objMovimientoCaja.IdCaja = Parametros.intCajaId; //Convert.ToInt32(cboCaja.EditValue);
            objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
            objMovimientoCaja.NumeroDocumento = txtSerie.Text + "-" + txtNumeroDocumento.Text;
            objMovimientoCaja.IdFormaPago = Parametros.intContado;
            objMovimientoCaja.IdCondicionPago = Parametros.intEfectivo;
            objMovimientoCaja.TipoMovimiento = "I";
            objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
            objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
            objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTC.EditValue);
            objMovimientoCaja.IdPedido = IdPedido;
            objMovimientoCaja.IdDocumentoVenta = IdDocumentoNC;
            objMovimientoCaja.IdDocumentoVentaReferencia = 0; //Id doc Venta
            objMovimientoCaja.FlagEstado = true;

            objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
            objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresaOrigen.EditValue);//Convert.ToInt32(cboEmpresa.EditValue);
            lstMovimientoCaja.Add(objMovimientoCaja);

            //Estado Cuenta
            EstadoCuentaBE objE_EstadoCuenta = null;
            SeparacionBE objE_Separacion = null;

            if (objMovimientoCaja != null)
            {
                //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
            }

        }

        private void ActualizaSolicitud()
        {
            PagosBL objBL_Pagos = new PagosBL();

            //Datos del Recibo de Pago
            PagosBE objPago = new PagosBE();
            objPago.IdPago = 0;
            objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
            objPago.IdCaja = Parametros.intCajaId;
            objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objPago.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
            string Numero = "";
            Numero = txtNumeroDocumento.Text;
            objPago.NumeroDocumento = Numero;
            objPago.IdCondicionPago = Parametros.intEfectivo;
            objPago.Concepto = "APLICACION SOLICITUD DEVOLUCION";
            objPago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
            objPago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
            objPago.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objPago.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTC.EditValue);
            objPago.FlagEstado = true;
            objPago.Usuario = Parametros.strUsuarioLogin;
            objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objPago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

            //Datos del Movimiento de Caja
            List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

            MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
            objMovimientoCaja.IdMovimientoCaja = 0;
            objMovimientoCaja.IdCaja = Parametros.intCajaId; //Convert.ToInt32(cboCaja.EditValue);
            objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
            objMovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
            objMovimientoCaja.IdFormaPago = Parametros.intContado;
            objMovimientoCaja.IdCondicionPago = Parametros.intEfectivo;
            objMovimientoCaja.TipoMovimiento = "I";
            objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
            objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
            objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTC.EditValue);
            objMovimientoCaja.IdPedido = IdPedido;
            objMovimientoCaja.FlagEstado = true;
            objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
            objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            lstMovimientoCaja.Add(objMovimientoCaja);

            //Estado Cuenta
            EstadoCuentaBE objE_EstadoCuenta = null;
            SeparacionBE objE_Separacion = null;

            if (objMovimientoCaja != null)
            {
                //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
            }

        }

        private void InsertarDocumentoVentaPagoVarios(decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC)
        {
            try
            {
                int IdTipoDocumentoRCP = Parametros.intTipoDocReciboPago;
                if (chkEmitirComprobante.Checked)
                {
                    IdTipoDocumentoRCP = Convert.ToInt32(cboDocumentoGenerarRCP.EditValue);

                    #region "DocumentoVenta"
                    string Serie = "";
                    string Numero = "";
                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = null;
                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);

                    //Obtener la serie del documento relacionado a la caja
                    //if (NumeracionAutomatica == true) //Add 13-03-15
                    //{
                    TalonBE objE_Talon = null;
                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumentoGenerarRCP.EditValue));
                    if (objE_Talon != null)
                    {
                        Serie = "";
                        Serie = objE_Talon.NumeroSerie;
                    }
                    //}

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumentoGenerarRCP.EditValue), Serie);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    }

                    //Traemos la información del pedido. //add 180917
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);
                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.IdClienteAsociado == 0)
                        {
                            objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                            objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                            objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                        }
                        else
                        {
                            objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                            objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                            objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                        }
                    }
                    else
                    {
                        ////Cliente
                        //ClienteBE objE_Cliente = new ClienteBE();
                        //objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                        objDocumentoVenta.NumeroDocumento = NumeroDocumento;
                        objDocumentoVenta.DescCliente = DescCliente;
                        objDocumentoVenta.Direccion = Direccion;
                    }


                    ////Cliente
                    //ClienteBE objE_Cliente = new ClienteBE();
                    //objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    decimal deTotal = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue), 2);
                    decimal deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;

                    //objDocumentoVenta.NumeroDocumento = objE_Cliente.NumeroDocumento;
                    //objDocumentoVenta.DescCliente = objE_Cliente.DescCliente;
                    //objDocumentoVenta.Direccion = objE_Cliente.Direccion;
                    objDocumentoVenta.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTC.EditValue);//Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Parametros.intPersonaId; //Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = 1; //Convert.ToInt32(txtTotalCantidad.EditValue);
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deTotal - deSubTotal;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = 0;
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR 5% DE TARJETA | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;

                    //Documento Vneta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                    objE_DocumentoVentaDetalle.Item = 1;
                    objE_DocumentoVentaDetalle.IdProducto = 54101;
                    objE_DocumentoVentaDetalle.CodigoProveedor = "SERV-020";
                    objE_DocumentoVentaDetalle.NombreProducto = "GASTO ADMINISTRATIVO";
                    objE_DocumentoVentaDetalle.Abreviatura = "PZA";
                    objE_DocumentoVentaDetalle.Cantidad = 1;
                    objE_DocumentoVentaDetalle.PrecioUnitario = deTotal;
                    objE_DocumentoVentaDetalle.PorcentajeDescuento = 0;
                    objE_DocumentoVentaDetalle.Descuento = 0;
                    objE_DocumentoVentaDetalle.PrecioVenta = deTotal;
                    objE_DocumentoVentaDetalle.ValorVenta = deTotal;
                    objE_DocumentoVentaDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                    objE_DocumentoVentaDetalle.IdKardex = 0;
                    objE_DocumentoVentaDetalle.FlagMuestra = false;
                    objE_DocumentoVentaDetalle.FlagRegalo = false;
                    objE_DocumentoVentaDetalle.IdPromocion = 0;//item.IdPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = 1;//item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                    //Movimiento Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                    if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0))
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        objE_MovimientoCaja.IdMovimientoCaja = 0;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 98;//
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo;
                        objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Visa > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 1;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 99;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa;
                        objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCard > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 2;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;//Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 100;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard;
                        objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    if (VisaPuntosVida > 0) //--------------------------------------------------------add
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 3;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }


                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();

                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = IdTipoDocumentoRCP;//Convert.ToInt32(cboDocumento.EditValue);
                    objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                    objE_Pago.IdCondicionPago = Parametros.intEfectivo;//Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_Pago.Importe = deTotal; //Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);



                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, true);
                    //ImpresionTicket(cboDocumentoGenerarRCP.Text, IdDocumentoVenta);

                    #region "Envío e Impresión de Comprobante electrónico"
                    if (Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocBoletaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineBoletaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }
                    else
                    if (Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocFacturaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineFacturaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }
                    else
                    {
                        ImpresionTicket(cboDocumentoGenerarRCP.Text, IdDocumentoVenta);
                    }
                    #endregion


                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Edición no Disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    #endregion

                }
                else
                {
                    #region "Recibo de Pago"

                    //Cliente
                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    if (NumeroPedido != "") NumeroPedido = "PED: " + NumeroPedido;
                    else
                        NumeroPedido = "Autoserv.";

                    PagosBL objBL_Pagos = new PagosBL();

                    //Datos del Recibo de Pago
                    PagosBE objPago = new PagosBE();
                    objPago.IdPago = 0;
                    objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                    objPago.IdCaja = Parametros.intCajaId;
                    objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPago.IdTipoDocumento = IdTipoDocumentoRCP;
                    objPago.NumeroDocumento = txtNumeroRCP.Text;
                    objPago.IdCondicionPago = Parametros.intEfectivo; //Convert.ToInt32(cboCondicionPago.EditValue);
                    objPago.Concepto = "RECARGO 5% " + NumeroPedido + " " + objE_Cliente.DescCliente;
                    objPago.IdMoneda = Parametros.intSoles;
                    objPago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objPago.ImporteSoles = Convert.ToDecimal(txtTotalResumenRCP.EditValue);
                    objPago.ImporteDolares = Convert.ToDecimal(txtTotalResumenRCP.EditValue) / Convert.ToDecimal(txtTC.EditValue);
                    objPago.TipoMovimiento = "I";
                    objPago.IdVendedor = Parametros.intUsuarioId; //Convert.ToInt32(cboVendedor.EditValue);
                    objPago.IdDis_ProyectoServicio = null;// IdDis_ProyectoServicio;
                    objPago.IdCliente = IdCliente;
                    objPago.FlagEstado = true;
                    objPago.Usuario = Parametros.strUsuarioLogin;
                    objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPago.IdEmpresa = Parametros.intEmpresaId;

                    //Movimiento Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                    if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0))
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        objE_MovimientoCaja.IdMovimientoCaja = 0;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = txtNumeroRCP.Text.Trim();
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 98;//
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo;
                        objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Visa > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 1;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = txtNumeroRCP.Text.Trim();
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 99;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa;
                        objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCard > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 2;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;//Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = txtNumeroRCP.Text.Trim();
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 100;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard;
                        objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    if (VisaPuntosVida > 0) //--------------------------------------------------------add
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 3;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = txtNumeroRCP.Text.Trim();
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumentoRCP;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = txtNumeroRCP.Text.Trim();
                        objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }


                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();

                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = IdTipoDocumentoRCP;//Convert.ToInt32(cboDocumento.EditValue);
                    objE_Pago.NumeroDocumento = txtNumeroRCP.Text.Trim();
                    objE_Pago.IdCondicionPago = Parametros.intEfectivo;//Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotalResumenRCP.EditValue); //Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);

                    //Estado Cuenta
                    EstadoCuentaBE objE_EstadoCuenta = null;
                    SeparacionBE objE_Separacion = null;


                    objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);



                    #endregion
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarDocumentoCincoPorCiento()
        {
            #region "Ticket"
            if (Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumentoGenerarRCP.EditValue) == Parametros.intTipoDocTicketFactura)
            {
                Cursor = Cursors.WaitCursor;

                string Serie = "";
                string Numero = "";

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;
                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                //Obtener la serie del documento relacionado a la caja
                TalonBE objE_Talon = null;
                objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                if (objE_Talon != null)
                {
                    Serie = "";
                    Serie = objE_Talon.NumeroSerie;
                }

                if (Serie == null)
                {
                    XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    cboDocumento.SelectAll();
                    cboDocumento.Focus();
                    return;
                }

                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                {
                    if (txtNumeroDocumento.Text.Length != 11)
                    {
                        XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        txtNumeroDocumento.SelectAll();
                        txtNumeroDocumento.Focus();
                        return;
                    }

                }

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                }

                //Cliente
                ClienteBE objE_Cliente = new ClienteBE();
                objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                decimal deTotal = Convert.ToDecimal(txtTotalResumenRCP.EditValue);
                decimal deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = objE_Cliente.NumeroDocumento;
                objDocumentoVenta.DescCliente = objE_Cliente.DescCliente;
                objDocumentoVenta.Direccion = objE_Cliente.Direccion;
                objDocumentoVenta.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMoneda.EditValue);
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTC.EditValue);//Convert.ToDecimal(txtTipoCambio.EditValue);
                objDocumentoVenta.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                objDocumentoVenta.IdVendedor = Parametros.intUsuarioId; //Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = 1; //Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = deSubTotal;
                objDocumentoVenta.PorcentajeDescuento = 0;
                objDocumentoVenta.Descuentos = 0;
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = deTotal - deSubTotal;
                objDocumentoVenta.Total = deTotal;
                objDocumentoVenta.TotalBruto = 0;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR 5% DE TARJETA | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                objE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoVentaDetalle.Item = 1;
                objE_DocumentoVentaDetalle.IdProducto = 54101;
                objE_DocumentoVentaDetalle.CodigoProveedor = "SERV-020";
                objE_DocumentoVentaDetalle.NombreProducto = "GASTO ADMINISTRATIVO";
                objE_DocumentoVentaDetalle.Abreviatura = "PZA";
                objE_DocumentoVentaDetalle.Cantidad = 1;
                objE_DocumentoVentaDetalle.PrecioUnitario = deTotal;
                objE_DocumentoVentaDetalle.PorcentajeDescuento = 0;
                objE_DocumentoVentaDetalle.Descuento = 0;
                objE_DocumentoVentaDetalle.PrecioVenta = deTotal;
                objE_DocumentoVentaDetalle.ValorVenta = deTotal;
                objE_DocumentoVentaDetalle.IdKardex = 0;
                objE_DocumentoVentaDetalle.FlagMuestra = false;
                objE_DocumentoVentaDetalle.FlagRegalo = false;
                objE_DocumentoVentaDetalle.IdPromocion = 0;//item.IdPromocion;
                objE_DocumentoVentaDetalle.FlagEstado = true;
                objE_DocumentoVentaDetalle.TipoOper = 1;//item.TipoOper;
                lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                //Movimiento Caja
                MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                objE_MovimientoCaja.IdCondicionPago = Parametros.intEfectivo; //Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Parametros.intSoles; //Convert.ToInt32(cboMoneda.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue); //Convert.ToDecimal(txtTipoCambio.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtEfectivoRCP.EditValue);//Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtEfectivoRCP.EditValue) * Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.IdPedido = IdPedido;
                objE_MovimientoCaja.FlagEstado = true;
                objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();

                DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                objE_Pago.IdDocumentoVenta = 0;
                objE_Pago.IdDocumentoVentaPago = 0;
                objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                objE_Pago.IdCondicionPago = Parametros.intEfectivo;//Convert.ToInt32(cboCondicionPago.EditValue);
                objE_Pago.IdMoneda = Parametros.intSoles;// Convert.ToInt32(cboMoneda.EditValue);
                objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);/// Convert.ToDecimal(txtTipoCambio.EditValue);
                                                                          /// 
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta)
                    objE_Pago.Importe = deSubTotal;
                else
                    objE_Pago.Importe = deTotal;
                objE_Pago.FlagEstado = true;
                objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                lstDocumentoVentaPago.Add(objE_Pago);

                //if (pOperacion == Operacion.Nuevo)
                //{
                int IdDocumentoVenta = 0;
                IdDocumentoVenta = objBL_DocumentoVenta.InsertaAutoservicio(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                ImpresionTicket(cboDocumentoGenerarRCP.Text, IdDocumentoVenta);
                //}
                //else
                //{
                //    objBL_DocumentoVenta.ActualizaAutoservicio(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                //}

            }
            #endregion 
        }

        private void ImpresionTicket(String TipoDoc, int IdDocumentoVenta)
        {
            string dirFacturacion = "<No Especificado>";

            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
            {
                dirFacturacion = Parametros.strDireccionUcayali2;
            }
            else
            {
                dirFacturacion = Parametros.strDireccionUcayali;
            }

            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
            {
                dirFacturacion = Parametros.strDireccionAndahuaylas;
            }
            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
            {
                dirFacturacion = Parametros.strDireccionMegaplaza;
            }
            if (Parametros.intTiendaId == Parametros.intTiendaPrescott)
            {
                dirFacturacion = Parametros.strDireccionPrescott;
            }

            DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
            List<DocumentoVentaDetalleBE> lstDocumentoDetalle = new List<DocumentoVentaDetalleBE>();

            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
            lstDocumentoDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);


            #region "Ticket Boleta"
            if (TipoDoc == "TKV")
            {
                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                //DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
                bool found = false;
                PrinterSettings prtSetting = new PrinterSettings();
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    string printer = "";
                    if (prtName.StartsWith("\\\\"))
                    {
                        printer = prtName.Substring(3);
                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                    }
                    else
                        printer = prtName;

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                if (objTalon.FlagAbrirCajon == true) ticket.AbreCajon();  //abre el cajón
                //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                //ticket.TextoCentro(dirFacturacion);
                //ticket.TextoCentro("RUC: 20330676826");
                ticket.TextoCentro(objTalon.NombreComercial);
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(objTalon.DireccionFiscal);
                if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                ticket.TextoIzquierda(cboDocumentoGenerarRCP.Text + objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierda("CLIENTE: " + objE_DocumentoVenta.DescCliente); //Convert.ToString(txtDescCliente.Text.Trim()));
                ticket.LineasGuion();
                ticket.EncabezadoVenta();

                foreach (var item in lstDocumentoDetalle)
                {
                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                }
                ticket.LineasTotales();
                ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(txtTotalResumenRCP.EditValue), 2)); // imprime linea con total
                ticket.TextoIzquierda("");
                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                ticket.TextoIzquierda("");
                //ticket.TextoCentro("www.panoramadistribuidores.com");
                ticket.TextoCentro(objTalon.PaginaWeb);
                ticket.CortaTicket();

            }
            #endregion


            #region "Ticket Factura"
            else
                if (TipoDoc == "TKF")
            {
                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
                bool found = false;
                PrinterSettings prtSetting = new PrinterSettings();
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    string printer = "";
                    if (prtName.StartsWith("\\\\"))
                    {
                        printer = prtName.Substring(3);
                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                    }
                    else
                        printer = prtName;

                    if (printer.ToUpper().StartsWith(objTalon.Impresora)) //("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                if (objTalon.FlagAbrirCajon == true) ticket.AbreCajon();  //abre el cajon
                                                                          //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                                                                          //ticket.TextoCentro(dirFacturacion);
                                                                          //ticket.TextoCentro("RUC: 20330676826");
                ticket.TextoCentro(objTalon.NombreComercial);
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(objTalon.DireccionFiscal);
                if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);

                ticket.TextoIzquierda(cboDocumentoGenerarRCP.Text + objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierdaNLineas("CLIENTE: " + objE_DocumentoVenta.DescCliente);// txtDescCliente.Text.Trim());
                ticket.TextoIzquierda("RUC: " + objE_DocumentoVenta.NumeroDocumento);//txtNumeroDocumento.Text.Trim());
                ticket.TextoIzquierdaNLineas("DIR: " + objE_DocumentoVenta.Direccion);// txtDireccion.Text.Trim());
                ticket.LineasGuion();
                ticket.EncabezadoVenta();

                foreach (var item in lstDocumentoDetalle)
                {
                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                }
                ticket.LineasTotales();
                ticket.AgregaTotales("SubTotal", Convert.ToDouble(objE_DocumentoVenta.SubTotal));//  Math.Round(Convert.ToDouble(txtTotalResumenRCP.EditValue), 2));
                ticket.AgregaTotales("IGV", Convert.ToDouble(objE_DocumentoVenta.Igv)); //Math.Round(Convert.ToDouble(txtImpuesto.EditValue), 2));
                ticket.AgregaTotales("Total a Pagar", Convert.ToDouble(objE_DocumentoVenta.Total)); // Math.Round(Convert.ToDouble(txtTotal.EditValue), 2));
                ticket.TextoIzquierda("");
                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(objE_DocumentoVenta.Total), 2).ToString()) + " Soles");
                ticket.TextoIzquierda("");
                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                ticket.TextoIzquierda("");
                //ticket.TextoCentro("www.panoramadistribuidores.com");
                ticket.TextoCentro(objTalon.PaginaWeb);
                //Agregar Nota de Crédito en auto

                ticket.CortaTicket();


            }
            #endregion



            //Agregar aquí la impresión electrónica

        }

        private DataTable CargarTipoDocumentoPago()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 36;
            dr["Descripcion"] = "NCV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "NCE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 95;
            dr["Descripcion"] = "SDV";
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["Id"] = 17;
            //dr["Descripcion"] = "VALE";
            //dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarTipoTarjeta()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "C";
            dr["Descripcion"] = "CREDITO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "D";
            dr["Descripcion"] = "DEBITO";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarTipoMaster()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "100";
            dr["Descripcion"] = "MASTERCARD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "101";
            dr["Descripcion"] = "AMERICAN EXPRESS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "22";
            dr["Descripcion"] = "DINNERS CLUB";
            dt.Rows.Add(dr);
            #region "Nuevo"
            dr = dt.NewRow();
            dr["Id"] = "192";
            dr["Descripcion"] = "VISA VIDA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "193";
            dr["Descripcion"] = "MASTERCARD VIDA";
            dt.Rows.Add(dr);

            // 572  --Dinerclub PROMOCIÓN || Prueba ( 552 )
            // 573  --Tarjetas Foraneas   || Prueba ( 553 )   
            dr = dt.NewRow();
            dr["Id"] = "572";
            dr["Descripcion"] = "DINERCLUB PROMOCIÓN";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "573";
            dr["Descripcion"] = "TARJETAS FORANEAS";
            dt.Rows.Add(dr);
            #endregion
            return dt;
        }

        private DataTable CargarCupon()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "64";
            dr["Descripcion"] = "GIFT CARD";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "1";
            dr["Descripcion"] = "CUPONATIC";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "2";
            dr["Descripcion"] = "VALE";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "3";
            dr["Descripcion"] = "COMERCIO AMIGO";
            dt.Rows.Add(dr);
            return dt;
        }


        private void chkEmitirComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmitirComprobante.Checked)
            {
                txtNumeroRCP.Text = "";
                txtNumeroRCP.Properties.ReadOnly = true;
            }
            else
            {
                txtNumeroRCP.Properties.ReadOnly = false;
            }

        }

        private void CalcularPago()
        {
            if (Convert.ToDecimal(txtCupon.Text) >= Convert.ToDecimal(txtTotalResumen.Text))
            {
                txtResta.EditValue = 0;
            }
            else
            {
                if (Convert.ToInt32(cboCupon.EditValue) == 2)
                {
                    txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) +
                                                                                                    Convert.ToDecimal(txtVisa.EditValue) +
                                                                                                    Convert.ToDecimal(txtMastercard.EditValue) +
                                                                                                    Convert.ToDecimal(txtVisaPuntosVida.EditValue) +
                                                                                                    Convert.ToDecimal(txtMastercardPuntosVida.EditValue) +
                                                                                                    Convert.ToDecimal(txtImporteNCSoles.EditValue) +
                                                                                                    Convert.ToDecimal(txtCupon2.EditValue)), 2);
                }
                else
                {
                    txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) +
                                                                                                                   Convert.ToDecimal(txtVisa.EditValue) +
                                                                                                                   Convert.ToDecimal(txtMastercard.EditValue) +
                                                                                                                   Convert.ToDecimal(txtVisaPuntosVida.EditValue) +
                                                                                                                   Convert.ToDecimal(txtMastercardPuntosVida.EditValue) +
                                                                                                                   Convert.ToDecimal(txtImporteNCSoles.EditValue) +
                                                                                                                   Convert.ToDecimal(txtCupon.EditValue)), 2);
                }

            }


            if (Convert.ToDecimal(txtResta.EditValue) < 0 && Convert.ToDecimal(txtCupon.Text) != 0 && Convert.ToDecimal(txtVisa.Text) == 0 && Convert.ToDecimal(txtEfectivo.Text) == 0 && Convert.ToDecimal(txtMastercard.Text) == 0)
            {
                txtResta.EditValue = 0;
            }

            if (Convert.ToDecimal(txtVisa.EditValue) > 0 || Convert.ToDecimal(txtMastercard.EditValue) > 0  ) //add 180216
            {
                if (IdTipoCliente == Parametros.intTipClienteMayorista || (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)  )
                {
                    #region "Mayorista Activo tambien se le agrego a final black"
                    if (!FlagBusquedaCliente)
                    {
                        ClienteBE objE_Cliente = new ClienteBE();
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                        if (objE_Cliente.IdSituacion == Parametros.intSITClienteInactivo)
                        {
                            FlagMayoristaActivo = false;
                        }
                    }
                    #endregion

                    if (FlagMayoristaActivo && IdCliente != 2418)
                    {
                        lblMensaje.Text = "COBRAR EL 5% POR\nRECARGO DE TARJETA";
                        gcReciboPago.Visible = true;
                        this.Size = new Size(585, 571);
                        txtTotalResumenRCP.EditValue = (Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue)) * Convert.ToDecimal("0.05"); //5% por Tarjeta
                        txtRestaRCP.EditValue = (Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue)) * Convert.ToDecimal("0.05"); //5% por Tarjeta
                    }
                }
            }
            else
            {
                lblMensaje.Text = "";
                txtTotalResumenRCP.EditValue = 0;
                txtRestaRCP.EditValue = 0;
            }
        }

        private void ImpresionElectronicaLocal(int IdDocumentoVenta, int IdTamanoHoja, string Impresora)
        {
            //frmListaPrinters frmPrinter = new frmListaPrinters();
            //if (frmPrinter.ShowDialog() == DialogResult.OK)
            //{

            if (IdTamanoHoja == Parametros.intTamanoA4)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    #region "Codigo QR"
                    int Regs = lstReporte.Count - 1;
                    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(ValorQR, out qrCode);

                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();

                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                    //imagen.Save("imagen.png", ImageFormat.Png);
                    #endregion
                    rptFacturaElectronicaPanoramaA4 objReporteGuia = new rptFacturaElectronicaPanoramaA4();
                    objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                    #region "Buscar Impresora ..."

                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith(Impresora))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            break;
                        }
                    }

                    if (!found)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                        return;
                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                    #endregion

                }
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmTermico)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    #region "Codigo QR"
                    int Regs = lstReporte.Count - 1;
                    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(ValorQR, out qrCode);

                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();

                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                    //imagen.Save("imagen.png", ImageFormat.Png);
                    #endregion

                    rptFacturaElectronicaPanorama80mm objReporteGuia = new rptFacturaElectronicaPanorama80mm();
                    objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                    #region "Buscar Impresora ..."

                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith(Impresora))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            break;
                        }
                    }

                    if (!found)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                        return;
                    }
                    //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    //MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                    #endregion
                }
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmMatricial)
            {
                #region "Impresión Matricial"

                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali2;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                    dirFacturacion = Parametros.strDireccionUcayali3;
                else
                    dirFacturacion = Parametros.strDireccionUcayali;
                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott) dirFacturacion = Parametros.strDireccionPrescott;


                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
                bool found = false;
                PrinterSettings prtSetting = new PrinterSettings();
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    string printer = "";
                    if (prtName.StartsWith("\\\\"))
                    {
                        printer = prtName.Substring(3);
                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                    }
                    else
                        printer = prtName;

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                ticket.AbreCajon();
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(objTalon.DireccionFiscal);
                if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                ticket.TextoIzquierda("");
                ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                ticket.TextoIzquierda("N° " + objTalon.NumeroSerie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                ticket.LineasGuion();
                ticket.EncabezadoVenta();

                foreach (var item in lstReporte)
                {
                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                }
                ticket.LineasTotales();
                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                {
                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                }
                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                ticket.TextoIzquierda("");
                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                ticket.TextoIzquierda("");
                ticket.TextoCentro("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant());
                ticket.TextoCentro("de Venta Electrónica.");
                ticket.TextoCentro("Consulte su documento en");
                ticket.TextoCentro("http://www.intelfac.com");
                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                ticket.TextoIzquierda("");
                ticket.TextoCentro("www.panoramahogar.com");
                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                //if (lstReporte[0].IdPromocionProxima > 0)
                //{
                //    ticket.CortaTicket();
                //    ticket.TextoCentro("=========================================");
                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                //    ticket.TextoCentro("=========================================");
                //}
                ticket.CortaTicket();
                #endregion
            }

            #region "Nota de crédito"

            if ("NOTA CREDITO" == "NC")
            {
                //rptNotaCreditoElectronicaPanoramaA4 objReporteGuia = new rptNotaCreditoElectronicaPanoramaA4();
                //objReporteGuia.SetDataSource(lstReporte);
                ////objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                ////objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                ////Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                #region "Buscar Impresora ..."

                //bool found = false;
                //PrinterSettings prtSetting = new PrinterSettings();
                //foreach (string prtName in PrinterSettings.InstalledPrinters)
                //{
                //    string printer = "";
                //    if (prtName.StartsWith("\\\\"))
                //    {
                //        printer = prtName.Substring(3);
                //        printer = printer.Substring(printer.IndexOf("\\") + 1);
                //    }
                //    else
                //        printer = prtName;

                //    if (printer.ToUpper().StartsWith(Impresora))
                //    {
                //        found = true;
                //        PrintOptions bufPO = objReporteGuia.PrintOptions;
                //        prtSetting.PrinterName = prtName;
                //        objReporteGuia.PrintOptions.PrinterName = prtName;

                //        Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                //        break;
                //    }
                //}

                //if (!found)
                //{
                //    Cursor = Cursors.Default;
                //    MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                //    return;
                //}
                //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                //MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                #endregion

            }
            #endregion
        }

        private bool InsertaClienteReferido()
        {
            bool flag = false;

            #region "Comisión EECC"

            EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
            SeparacionBL objBL_Separacion = new SeparacionBL();

            int IdMotivo = Parametros.intMotivoVenta;
            int IdMoneda = Parametros.intSoles;
            decimal decTotalComision = 0;

            //Estado de Cuenta
            EstadoCuentaBE objE_EstadoCuenta = null;
            SeparacionBE objE_Separacion = null;

            ClienteBE objE_Cliente = new ClienteBE();
            objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, IdClienteRef);


            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
            {
                IdMoneda = Parametros.intDolares;
                decTotalComision = Convert.ToDecimal(Convert.ToDecimal("5.00") / Convert.ToDecimal(Parametros.dmlTCMayorista));

                //Datos del estado de cuenta
                objE_EstadoCuenta = new EstadoCuentaBE();

                objE_EstadoCuenta.IdEstadoCuenta = 0;
                objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                objE_EstadoCuenta.IdCliente = IdClienteRef;
                objE_EstadoCuenta.NumeroDocumento = "CLIREF";
                objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_EstadoCuenta.FechaDeposito = null;
                objE_EstadoCuenta.Concepto = "COMISION CLIENTE REFERIDO " + Parametros.strDescTienda;
                objE_EstadoCuenta.FechaVencimiento = null;
                objE_EstadoCuenta.Importe = decTotalComision;
                objE_EstadoCuenta.ImporteAnt = 0;
                objE_EstadoCuenta.TipoMovimiento = "A";
                objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta;//Verificar para NAVIDAD
                objE_EstadoCuenta.IdPedido = IdPedido;
                objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                objE_EstadoCuenta.Observacion = "";
                objE_EstadoCuenta.FlagEstado = true;
                objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);
                flag = true;
            }
            else
            {
                decTotalComision = Convert.ToDecimal("5.00") * Convert.ToInt32(Convert.ToDecimal(txtCupon2.EditValue) / 10);

                //Datos del estado de cuenta
                objE_Separacion = new SeparacionBE();

                objE_Separacion.IdSeparacion = 0;
                objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                objE_Separacion.Periodo = Parametros.intPeriodo;
                objE_Separacion.IdCliente = IdClienteRef;
                objE_Separacion.NumeroDocumento = "CLIREF";
                objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_Separacion.FechaPago = null;
                objE_Separacion.Concepto = "COMISION CLIENTE REFERIDO " + Parametros.strDescTienda;
                objE_Separacion.FechaVencimiento = null;
                objE_Separacion.Importe = decTotalComision;
                objE_Separacion.ImporteAnt = 0;
                objE_Separacion.TipoMovimiento = "A";
                objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Verificar para NAVIDAD
                objE_Separacion.IdPedido = IdPedido;
                objE_Separacion.IdDocumentoVenta = (int?)null;
                objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                objE_Separacion.Observacion = "";
                objE_Separacion.FlagEstado = true;
                objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_Separacion.Inserta(objE_Separacion);
                flag = true;
            }


            #region "EstadoCuentaCliente"
            EstadoCuentaClienteBL ojbBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();
            EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();

            objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
            objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
            objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
            objE_EstadoCuentaCliente.IdCliente = IdClienteRef;
            objE_EstadoCuentaCliente.NumeroDocumento = "CLIREF";
            objE_EstadoCuentaCliente.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objE_EstadoCuentaCliente.Concepto = "COMISION CLIENTE REFERIDO " + Parametros.strDescTienda;
            objE_EstadoCuentaCliente.FechaVencimiento = null;
            objE_EstadoCuentaCliente.IdMoneda = IdMoneda;
            objE_EstadoCuentaCliente.Importe = decTotalComision;
            objE_EstadoCuentaCliente.TipoMovimiento = "A";
            objE_EstadoCuentaCliente.IdMotivo = Parametros.intMotivoVenta;
            objE_EstadoCuentaCliente.IdDocumentoVenta = (int?)null;
            objE_EstadoCuentaCliente.IdPedido = IdPedido;
            objE_EstadoCuentaCliente.IdMovimientoCaja = 0;
            objE_EstadoCuentaCliente.IdCuentaBancoDetalle = 0;
            objE_EstadoCuentaCliente.IdPersona = Parametros.intPersonaId;
            objE_EstadoCuentaCliente.UsuarioRegistro = Parametros.strUsuarioLogin;
            objE_EstadoCuentaCliente.FechaRegistro = DateTime.Now;
            objE_EstadoCuentaCliente.Observacion = "";
            objE_EstadoCuentaCliente.Saldo = decTotalComision;
            objE_EstadoCuentaCliente.FlagEstado = true;
            objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
            objE_EstadoCuentaCliente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            ojbBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
            #endregion

            #endregion

            return flag;
        }

        private bool InsertaClienteComercioAmigo()
        {
            bool flag = false;

            #region "Registro de Venta - Comercio Amigo"

            EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
            SeparacionBL objBL_Separacion = new SeparacionBL();

            int IdMotivo = Parametros.intMotivoVenta;
            int IdMoneda = Parametros.intSoles;
            decimal decTotalComision = 0;

            ClienteBE objE_Cliente = new ClienteBE();
            objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, IdClienteRef);

            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteFinal && objE_Cliente.IdClasificacionCliente != Parametros.intBlack)
            {
                #region "EstadoCuentaCliente"
                ClienteComercioBL ojbBL_ClienteComercio = new ClienteComercioBL();
                ClienteComercioBE objE_ClienteComercio = new ClienteComercioBE();

                objE_ClienteComercio.IdComercio = 0;
                objE_ClienteComercio.IdEmpresa = Parametros.intEmpresaId;
                objE_ClienteComercio.IdTienda = Parametros.intTiendaId;
                objE_ClienteComercio.Periodo = Parametros.intPeriodo;
                objE_ClienteComercio.Mes = Convert.ToInt32(deFecha.DateTime.Month);

                objE_ClienteComercio.IdDocumentoVenta = (int?)null;
                objE_ClienteComercio.Fecdoc = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_ClienteComercio.IdPedido = IdPedido;

                objE_ClienteComercio.IdCliente = IdClienteRef;
                objE_ClienteComercio.IdTipodocumento = objE_Cliente.IdTipoDocumento;
                objE_ClienteComercio.NumeroDocumento = objE_Cliente.NumeroDocumento;
                objE_ClienteComercio.DescCliente = objE_Cliente.DescCliente;

                objE_ClienteComercio.IdMoneda = IdMoneda;
                objE_ClienteComercio.IdFormaPago = 0;
                objE_ClienteComercio.Total = 0;
                objE_ClienteComercio.IdSituacion = 103;

                vIdcomercio = ojbBL_ClienteComercio.Inserta(objE_ClienteComercio);
                flag = true;
                #endregion
            }

            #endregion

            return flag;
        }
        #endregion

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(IdEmpresa, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
        }

        private void chkActivaEmpresa_Click(object sender, EventArgs e)
        {


        }

        private void chkActivaEmpresa_Validating(object sender, CancelEventArgs e)
        {

        }

        private void chkActivaEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivaEmpresa.Checked)
            {
                cboEmpresa.ReadOnly = false;
                cboEmpresa.Select();
            }
            else
            {
                cboEmpresa.ReadOnly = true;
            }
        }

        private void cboCupon_TextChanged(object sender, EventArgs e)
        {
            if (cboCupon.Text == "COMERCIO AMIGO")
            {
                gcClienteReferido.Visible = true;
                gcClienteReferido.Text = "Comercio Amigo";
                txtNumeroCupon.Enabled = false;
                txtCupon2.Enabled = false;
                txtNumeroCupon.Text = " ";
                txtCupon2.Text = "0.00";
                txtDni.Focus();
                txtDni.SelectAll();
            }
            //else if (cboCupon.Text == "GIFT CARD")
            //{
            //    gcClienteReferido.Visible = false;
            //    gcClienteReferido.Text = "Cliente referido";
            //    txtNumeroCupon.Enabled = true;
            //    txtCupon.Enabled = true;
            //    txtDni.Text = "";
            //    txtDescClienteRef.Text = "";
            //    IdClienteRef = 0;
            //    txtNumeroCupon.Focus();
            //    txtNumeroCupon.SelectAll();
            //}
            else
            {
                gcClienteReferido.Text = "Cliente referido";
                txtNumeroCupon.Enabled = true;
                txtCupon2.Enabled = true;
                txtDni.Text = "";
                txtDescClienteRef.Text = "";
                IdClienteRef = 0;
                txtNumeroCupon.Focus();
                txtNumeroCupon.SelectAll();

                #region "Limpiar Cliente Referido"
                gcClienteReferido.Visible = false;
                IdTipoClienteRef = 0;
                IdClienteRef = 0;
                txtDescClienteRef.Text = "";
                txtDni.Text = "";
                #endregion
            }


        }
    }
}