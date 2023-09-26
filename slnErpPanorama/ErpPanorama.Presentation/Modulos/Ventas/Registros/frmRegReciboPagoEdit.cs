using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using System.Drawing.Printing;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegReciboPagoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PagosBE> lstPago;

        private string NumeroDevolucion = "";
        private int? IdDocumentoVentaNC;
        public int IdDocumentoNC = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DateTime FechaD { get; set; }
        public string vCodigoGiftCard = "";

        int _IdPago = 0;

        public int IdPago
        {
            get { return _IdPago; }
            set { _IdPago = value; }
        }

        private int? IdPedido = null;
        private int? IdCliente = 0;
        private int? IdPersona = 0;
        decimal decImporteAnt = 0;
        int? IdDocumentoVenta = 0;
        int? IdMovimientoCaja = 0;
        int? IdCotizacion = 0;
        int IdEstadoCuenta = 0;
        int IdSeparacion = 0;
        int IdTipoCliente = 0;
        int IdClasificacionCliente = 0;
        private int? IdDis_ProyectoServicio;
        private int? IdDis_ContratoFabricacion;

        private string NumeroDocumento = "";
        private string FormaPagoPedido = "";

        #endregion

        #region "Eventos"

        public frmRegReciboPagoEdit()
        {
            InitializeComponent();
        }

        private void frmRegReciboPagoEdit_Load(object sender, EventArgs e)
        {
            txtTipoCambio.ReadOnly = true;
            this.Location = new Point(0, 0);
            //deFecha.EditValue = DateTime.Now;
            deFecha.EditValue = FechaD;
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboEmpresaOrigen, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresaOrigen.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboDocumentoCR, CargarTipoDocumentoPago(), "Descripcion", "Id", false);
            cboDocumentoCR.EditValue = Parametros.intTipoDocNotaCredito;
            BSUtils.LoaderLook(cboDocumentoGenerarRCP, new TalonBL().ListaCaja(Parametros.intEmpresaId, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumentoGenerarRCP.EditValue = Parametros.intTipoDocTicketBoleta;
            BSUtils.LoaderLook(cboTipoVisaRCP, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoVisaRCP.EditValue = "D";
            BSUtils.LoaderLook(cboTipoMasterCardRCP, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoMasterCardRCP.EditValue = "D";

            BSUtils.LoaderLook(cboTipoVisa, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoVisa.EditValue = "D";
            BSUtils.LoaderLook(cboTipoMasterCard, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoMasterCard.EditValue = "D";
            BSUtils.LoaderLook(cboTipoMaster, CargarTipoMaster(), "Descripcion", "Id", false);
            cboTipoMaster.EditValue = 100;


            TipoCambioBE objE_TipoCambio = null;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.EditValue));
            if (objE_TipoCambio == null)
            {
                XtraMessageBox.Show("El tipo de cambio del día no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescCaja", "IdCaja", true);
                cboCaja.EditValue = Parametros.intCajaId;
                BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
                cboDocumento.EditValue = Parametros.intTipoDocReciboPago;
                BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
                cboCondicionPago.EditValue = Parametros.intEfectivo;
                txtTipoCambio.EditValue = objE_TipoCambio.Venta;
                BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                cboMoneda.EditValue = Parametros.intSoles;
                BSUtils.LoaderLook(cboMonedaCheque, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                BSUtils.LoaderLook(cboDocumentoCheque, CargarTipoDocumentoCheque(), "Descripcion", "Id", true);

                if (pOperacion == Operacion.Nuevo)
                {
                    this.Text = "Recibo de Pago - Nuevo";
                }
                else if (pOperacion == Operacion.Modificar)
                {
                    this.Text = "Recibo de Pago - Modificar";

                    PagosBE objE_Pago = null;
                    objE_Pago = new PagosBL().Selecciona(Parametros.intEmpresaId, IdPago);

                    IdPago = objE_Pago.IdPago;
                    IdPedido = objE_Pago.IdPedido == null ? 0 : IdPedido;
                    txtNumeroPedido.Text = objE_Pago.NumeroPedido;
                    txtCodMonedaPedido.Text = objE_Pago.CodMonedaPedido;
                    txtTotal.EditValue = objE_Pago.Total;
                    txtDescCliente.Text = objE_Pago.DescCliente;
                    cboCaja.EditValue = objE_Pago.IdCaja;
                    deFecha.EditValue = objE_Pago.Fecha;
                    cboDocumento.EditValue = objE_Pago.IdTipoDocumento;
                    txtNumeroDocumento.Text = objE_Pago.NumeroDocumento;
                    NumeroDocumento = objE_Pago.NumeroDocumento;
                    cboCondicionPago.EditValue = objE_Pago.IdCondicionPago;
                    txtConcepto.Text = objE_Pago.Concepto;
                    cboMoneda.EditValue = objE_Pago.IdMoneda;
                    txtTipoCambio.EditValue = objE_Pago.TipoCambio;
                    txtImporteSoles.EditValue = objE_Pago.ImporteSoles;
                    txtImporteDolares.EditValue = objE_Pago.ImporteDolares;
                    IdMovimientoCaja = objE_Pago.IdMovimientoCaja;
                    cboVendedor.EditValue = objE_Pago.IdVendedor;
                    IdCliente = objE_Pago.IdCliente;
                    txtTipoCliente.EditValue = objE_Pago.TipoCliente;
                    IdDis_ProyectoServicio = objE_Pago.IdDis_ProyectoServicio;
                    txtNumeroProyecto.EditValue = objE_Pago.NumeroProyectoServicio;
                    txtNumeroProyecto.Enabled = false;
                    txtGiftCard.Text = vCodigoGiftCard;
                    if (IdMovimientoCaja > 0 || IdMovimientoCaja != null)
                    {
                        EstadoCuentaBE objE_EstadoCuenta = null;
                        objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaMovimientoCaja(IdMovimientoCaja);

                        SeparacionBE objE_Separacion = null;
                        objE_Separacion = new SeparacionBL().SeleccionaMovimientoCaja(IdMovimientoCaja);

                        if (objE_EstadoCuenta != null)
                        {
                            decImporteAnt = objE_EstadoCuenta.Importe;
                            IdEstadoCuenta = objE_EstadoCuenta.IdEstadoCuenta;
                        }
                        else if (objE_Separacion != null)
                        {
                            decImporteAnt = objE_Separacion.Importe;
                            IdSeparacion = objE_Separacion.IdSeparacion;
                        }

                    }

                    btnGrabar.Enabled = false;
                }
                txtTipoCambio.ReadOnly = true;
                txtNumeroDocumento.Select();
            }

        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            {
                decimal ImporteDolares = 0;
                ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteDolares.EditValue = ImporteDolares;
                lblEfectivo.Text = "EFECTIVO S/";
                lblEfectivo.ForeColor = Color.Black;

                //txtImporteDolares.Properties.ReadOnly = true;
                //txtImporteSoles.Properties.ReadOnly = false;
                txtImporteSoles.Select();
            }
            else
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtImporteDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteSoles.EditValue = ImporteSoles;
                lblEfectivo.Text = "EFECTIVO US$";
                lblEfectivo.ForeColor = Color.Green;
                //txtImporteDolares.Properties.ReadOnly = false;
                //txtImporteSoles.Properties.ReadOnly = true;
                txtImporteDolares.Select();
            }

            ValidarTotal();
            ValidarDiferencia();
        }

        private void txtImporteSoles_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
            {
                decimal ImporteDolares = 0;
                ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteDolares.EditValue = ImporteDolares;

                ValidarTotal();
                ValidarDiferencia();
            }
        }

        private void txtImporteDolares_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtImporteDolares.EditValue) > 0)
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtImporteDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteSoles.EditValue = ImporteSoles;

                ValidarTotal();
                ValidarDiferencia();

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar el ingreso del recibo de pago - Max. 3 días
                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
                {
                }
                else
                { 
                    TimeSpan difFechas = (DateTime.Now.Date - Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
                    int vNumDias = difFechas.Days;

                    if (vNumDias > 3)
                    {
                        XtraMessageBox.Show("No puede registrar recibos de pago con fecha mayor a 3 días.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }



                Cursor = Cursors.WaitCursor;

                if (IdCliente == 477159)
                {
                    if (txtGiftCard.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Ingrese el codigo de la GIFTCARD para continuar...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    TarjetaRegaloBE objE_TarjetaRegalo = null;
                    objE_TarjetaRegalo = new TarjetaRegaloBL().SeleccionaNumero(txtGiftCard.Text.Trim()); //      .SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Parametros.intTipoDocReciboPago, NumeroDocumento);
                    if (objE_TarjetaRegalo == null)
                    {
                        XtraMessageBox.Show("El codigo de la GIFTCARD no existe. Verifique la tarjeta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

                if (chkPlanilla.Checked)
                {
                    #region "Recibo de pago trabajador"

                    if (!ValidarIngresoPlanilla())
                    {
                        if (Convert.ToDecimal(txtChequeSoles.EditValue) == 0)//Dejar Pasar saldo para caso Cheque
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
                        }

                        PagosBL objBL_Pagos = new PagosBL();

                        //Datos del Recibo de Pago
                        PagosBE objPago = new PagosBE();
                        objPago.IdPago = IdPago;
                        objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                        objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objPago.NumeroDocumento = txtNumeroDocumento.Text;
                        objPago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objPago.Concepto = txtConcepto.Text;
                        objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objPago.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                        objPago.TipoMovimiento = "I";
                        objPago.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                        objPago.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                        objPago.IdCliente = IdCliente;
                        objPago.FlagEstado = true;
                        objPago.Usuario = Parametros.strUsuarioLogin;
                        objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objPago.IdEmpresa = Parametros.intEmpresaId;


                        //****************************
                        //Cargar Valores
                        decimal Efectivo = 0;
                        Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intDolares)
                            Efectivo = Efectivo * Convert.ToDecimal(txtTipoCambio.EditValue);

                        decimal Visa = Convert.ToDecimal(txtVisa.EditValue);
                        decimal MasterCard = Convert.ToDecimal(txtMastercard.EditValue);
                        decimal Cheque = Convert.ToDecimal(txtChequeSoles.EditValue);

                        if (Convert.ToDecimal(txtChequeSoles.EditValue) == Convert.ToDecimal(txtTotalResumen.EditValue))//add 18/09/15
                        {
                            Efectivo = Convert.ToDecimal(txtChequeSoles.EditValue);
                        }

                        //Movimiento Caja
                        List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                        if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0))
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            objE_MovimientoCaja.IdMovimientoCaja = 0;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                           // objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 98;//
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Efectivo;
                            objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.FlagEstado = true;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }
                        if (Visa > 0)
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdMovimientoCaja = 1;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                           // objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 99;
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMoneda.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Visa;
                            objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                           // objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 100;
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Parametros.intSoles; //Convert.ToInt32(cboMoneda.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = MasterCard;
                            objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.FlagEstado = true;
                            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }
                        if (Cheque > 0)//add 1703
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdMovimientoCaja = 3;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            //objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 194;
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaCheque.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Cheque;
                            objE_MovimientoCaja.ImporteDolares = Cheque / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.NumeroCondicion = txtNumeroCheque.Text.Trim();
                            objE_MovimientoCaja.FlagEstado = true;
                            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }

                        //if (Cheque > 0)
                        //{
                        //    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        //    objE_MovimientoCaja.IdMovimientoCaja = 3;
                        //    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        //    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        //    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumentoCheque.EditValue);
                        //    objE_MovimientoCaja.NumeroDocumento = txtNumeroCheque.Text.Trim(); //txtNumeroDocumento.Text;
                        //    if (txtNumeroCheque.Text.Trim().Length > 0) objE_MovimientoCaja.NumeroDocumento = txtNumeroCheque.Text.Trim(); else objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                        //    objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                        //    objE_MovimientoCaja.IdCondicionPago = 98;
                        //    objE_MovimientoCaja.TipoMovimiento = "I";
                        //    objE_MovimientoCaja.TipoTarjeta = "";
                        //    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaCheque.EditValue);
                        //    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        //    //objE_MovimientoCaja.ImporteSoles = Cheque;
                        //    //objE_MovimientoCaja.ImporteDolares = Cheque / Convert.ToDecimal(txtTipoCambio.EditValue);
                        //    objE_MovimientoCaja.FlagEstado = true;
                        //    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        //    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        //    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;

                        //    //if (Convert.ToInt32(cboMonedaCheque.EditValue) == Parametros.intSoles)
                        //    //{
                        //    objE_MovimientoCaja.ImporteSoles = Cheque;
                        //    objE_MovimientoCaja.ImporteDolares = Cheque / Convert.ToDecimal(txtTipoCambio.EditValue);
                        //    //}
                        //    //else
                        //    //{
                        //    //    objE_MovimientoCaja.ImporteSoles = Cheque;// *Convert.ToDecimal(txtTipoCambio.EditValue); ;
                        //    //    objE_MovimientoCaja.ImporteDolares = Cheque;
                        //    //}

                        //    lstMovimientoCaja.Add(objE_MovimientoCaja);
                        //}

                        //****************************
                        string NumeroPedido = "";
                        if (IdPedido != null)
                        {
                            NumeroPedido = " " + FormaPagoPedido + " N° " + Convert.ToInt32(txtNumeroPedido.Text.Trim()).ToString();
                        };


                        //EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                        EstadoCuentaBE objE_EstadoCuenta = null;

                        //Separacion
                        SeparacionBE objE_Separacion = null;


                        //CABECERA ADD 15-03-17
                        //......
                        SolicitudPrestamoBL objBL_SolicitudPrestamo = new SolicitudPrestamoBL();
                        SolicitudPrestamoBE objSolicitudPrestamo = new SolicitudPrestamoBE();
                        objSolicitudPrestamo.IdSolicitudPrestamo = 0;
                        objSolicitudPrestamo.IdTipoDocumento = Parametros.intTipoDocReciboDescuentoPlanilla;
                        objSolicitudPrestamo.Periodo = Parametros.intPeriodo;
                        objSolicitudPrestamo.Numero = "000000";
                        objSolicitudPrestamo.FechaSolicitud = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());//Convert.ToDateTime(deFecha.EditValue);
                        objSolicitudPrestamo.IdPersona = Convert.ToInt32(IdPersona);
                        objSolicitudPrestamo.Importe = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objSolicitudPrestamo.Interes = 0;
                        objSolicitudPrestamo.TotalPago = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objSolicitudPrestamo.SaldoAnterior = 0;
                        objSolicitudPrestamo.NumeroCuotas = 0;
                        objSolicitudPrestamo.TipoCuota = 24;
                        objSolicitudPrestamo.Cuota = 0;
                        objSolicitudPrestamo.Metodo = 1;
                        objSolicitudPrestamo.Observacion = "Origen RCP: " + txtConcepto.Text.Trim();
                        objSolicitudPrestamo.IdPersonaAprueba = Parametros.intPersonaId;
                        objSolicitudPrestamo.FlagAprobado = true;
                        objSolicitudPrestamo.IdSituacion = 0;
                        objSolicitudPrestamo.Motivo = "";//txtMotivo.Text;
                        objSolicitudPrestamo.FlagEstado = true;
                        objSolicitudPrestamo.Usuario = Parametros.strUsuarioLogin;
                        objSolicitudPrestamo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objSolicitudPrestamo.IdEmpresa = Parametros.intEmpresaId;

                        //SolicitudPrestamo Detalle
                        List<SolicitudPrestamoDetalleBE> lstSolicitudPrestamoDetalle = new List<SolicitudPrestamoDetalleBE>();

                        //foreach (var item in mListaSolicitudPrestamoDetalleOrigen)
                        //{
                        SolicitudPrestamoDetalleBE objE_SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBE();
                        objE_SolicitudPrestamoDetalle.IdSolicitudPrestamo = 0;
                        objE_SolicitudPrestamoDetalle.IdSolicitudPrestamoDetalle = 0;
                        objE_SolicitudPrestamoDetalle.NumeroCuota = 1;// item.NumeroCuota;
                        objE_SolicitudPrestamoDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_SolicitudPrestamoDetalle.Concepto = txtConcepto.Text.Trim(); //"AMORTIZACION DE DEUDA";
                        objE_SolicitudPrestamoDetalle.FechaPago = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_SolicitudPrestamoDetalle.FechaVencimiento = null;
                        objE_SolicitudPrestamoDetalle.Capital = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objE_SolicitudPrestamoDetalle.Interes = 0;
                        objE_SolicitudPrestamoDetalle.Importe = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objE_SolicitudPrestamoDetalle.TipoMovimiento = "A";
                        objE_SolicitudPrestamoDetalle.IdPersona = Convert.ToInt32(IdPersona);
                        objE_SolicitudPrestamoDetalle.FlagEstado = true;
                        objE_SolicitudPrestamoDetalle.TipoOper = 1;
                        objE_SolicitudPrestamoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudPrestamoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstSolicitudPrestamoDetalle.Add(objE_SolicitudPrestamoDetalle);
                        //}

                        if (pOperacion == Operacion.Nuevo)
                        {
                            objBL_SolicitudPrestamo.Inserta(objSolicitudPrestamo, lstSolicitudPrestamoDetalle);
                        }

                        #region "Antes grabar det"

                        ////Solicitud Préstamo
                        //SolicitudPrestamoDetalleBE objE_SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBE();
                        //SolicitudPrestamoDetalleBL objBL_Solicitud = new SolicitudPrestamoDetalleBL();
                        ////objE_SolicitudPrestamoDetalle.IdSolicitudPrestamo = null;
                        //objE_SolicitudPrestamoDetalle.IdSolicitudPrestamoDetalle = 0;
                        //objE_SolicitudPrestamoDetalle.NumeroCuota = 1;
                        //objE_SolicitudPrestamoDetalle.Fecha = Convert.ToDateTime(deFecha.EditValue);
                        //objE_SolicitudPrestamoDetalle.Concepto = txtConcepto.Text.Trim();
                        //objE_SolicitudPrestamoDetalle.FechaPago = Convert.ToDateTime(deFecha.EditValue);
                        ////objE_SolicitudPrestamoDetalle.FechaPago = item.FechaPago == Convert.ToDateTime("01/01/2000") ? (DateTime?)null : item.FechaPago;
                        //objE_SolicitudPrestamoDetalle.FechaVencimiento = null;
                        //objE_SolicitudPrestamoDetalle.Capital = Convert.ToDecimal(txtImporteSoles.EditValue);
                        //objE_SolicitudPrestamoDetalle.Interes = 0;
                        //objE_SolicitudPrestamoDetalle.Importe = Convert.ToDecimal(txtImporteSoles.EditValue);
                        //objE_SolicitudPrestamoDetalle.TipoMovimiento = "A";
                        //objE_SolicitudPrestamoDetalle.IdPersona = Convert.ToInt32(IdPersona);
                        //objE_SolicitudPrestamoDetalle.FlagEstado = true;
                        //objE_SolicitudPrestamoDetalle.TipoOper = 1;
                        //objE_SolicitudPrestamoDetalle.Usuario = Parametros.strUsuarioLogin;
                        //objE_SolicitudPrestamoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        //objBL_Solicitud.Inserta(objE_SolicitudPrestamoDetalle);
                        #endregion


                        if (pOperacion == Operacion.Nuevo)
                        {
                            //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                            IdPago = objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);

                            //Imprimir
                            //Imprimir(IdPago);
                        }
                        else
                        {
                            //Datos del Movimiento de Caja
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Parametros.intTipoDocReciboPago, NumeroDocumento);

                            //objE_MovimientoCaja.IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;

                            //objBL_Pagos.Actualiza(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                            objBL_Pagos.Actualiza(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        }

                        this.Close();
                    }
                    #endregion
                }
                else
                {
                    #region "Recibo de pago Cliente"

                    if (!ValidarIngreso())
                    {
                        if (Convert.ToDecimal(txtChequeSoles.EditValue) == 0)  //Dejar Pasar saldo para caso Cheque
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
                        }

                        //5% Obligatorio
                        if (Convert.ToDecimal(txtRestaRCP.EditValue) != 0)
                        {
                            XtraMessageBox.Show("Pendiente por cobrar 5% de Tarjeta: " + txtResta.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEfectivo.Select();
                            txtEfectivo.SelectAll();
                            return;
                        }


                        //Cinco por ciento RCP
                        if (Convert.ToDecimal(txtTotalResumenRCP.EditValue) > 0)
                        {
                            //if (txtNumeroRCP.Text.Trim() == "" && chkEmitirComprobante.Checked == false)
                            if (chkEmitirComprobante.Checked == false)
                            {
                                if (txtNumeroRCP.Text.Trim() == "")
                                {
                                    XtraMessageBox.Show("Falta ingresar el número de RCP del 5%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                            }
                            else //FE
                            {
                                if (cboDocumentoGenerarRCP.Text.Length == 0)
                                {
                                    XtraMessageBox.Show("Seleccionar el tipo de comprobante a emitir BOLETA/FACTURA", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                            }

                            InsertarDocumentoVentaPagoVarios(Convert.ToDecimal(txtEfectivoRCP.EditValue), Convert.ToDecimal(txtVisaRCP.EditValue), Convert.ToDecimal(txtMastercardRCP.EditValue), 0, Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue), cboTipoVisaRCP.Text, "", 0);

                        }


                        PagosBL objBL_Pagos = new PagosBL();

                        //Datos del Recibo de Pago
                        PagosBE objPago = new PagosBE();
                        objPago.IdPago = IdPago;
                        objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                        objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                       // objPago.NumeroDocumento = txtNumeroDocumento.Text;
                        objPago.NumeroDocumento = txtNumeroDocumento.Text;
                        objPago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objPago.Concepto = txtConcepto.Text + " " + txtGiftCard.Text.ToString().Trim();
                        objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objPago.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                        objPago.TipoMovimiento = "I";
                        objPago.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                        objPago.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                        objPago.IdDis_ContratoFabricacion = IdDis_ContratoFabricacion;
                        objPago.IdCliente = IdCliente;
                        objPago.FlagEstado = true;
                        objPago.Usuario = Parametros.strUsuarioLogin;
                        objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objPago.IdEmpresa = Parametros.intEmpresaId;
                        objPago.CodigoGiftCard = (txtGiftCard.Text.ToString());
                        //****************************
                        //Cargar Valores
                        decimal Efectivo = 0;
                        Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intDolares)
                            Efectivo = Efectivo * Convert.ToDecimal(txtTipoCambio.EditValue);

                        decimal Visa = Convert.ToDecimal(txtVisa.EditValue);
                        decimal MasterCard = Convert.ToDecimal(txtMastercard.EditValue);
                        decimal Cheque = Convert.ToDecimal(txtChequeSoles.EditValue);


                        //if (Convert.ToDecimal(txtChequeSoles.EditValue) == Convert.ToDecimal(txtTotalResumen.EditValue))//add 18/09/15
                        //{
                        //    Efectivo = Convert.ToDecimal(txtChequeSoles.EditValue);
                        //}

                        //Movimiento Caja
                        List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                        //if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && Cheque==0))
                        if (Efectivo > 0)//add 050716
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            objE_MovimientoCaja.IdMovimientoCaja = 0;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;  // txtNumeroDocumento.Text;
                            
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 98;//
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Efectivo;
                            objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.FlagEstado = true;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }
                        if (Visa > 0)
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdMovimientoCaja = 1;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text; // txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            //objE_MovimientoCaja.IdCondicionPago = 99;
                            //objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdCondicionPago = 99;
                            objE_MovimientoCaja.TipoTarjeta = cboTipoVisa.EditValue.ToString();
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMoneda.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Visa;
                            objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;  // txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            //objE_MovimientoCaja.IdCondicionPago = 100;
                            //objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboTipoMaster.EditValue);
                            objE_MovimientoCaja.TipoTarjeta = cboTipoMasterCard.EditValue.ToString();
                            objE_MovimientoCaja.TipoMovimiento = "I";

                            objE_MovimientoCaja.IdMoneda = Parametros.intSoles; //Convert.ToInt32(cboMoneda.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = MasterCard;
                            objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.FlagEstado = true;
                            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }
                        if (Cheque > 0)//add 1703
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdMovimientoCaja = 3;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;  // txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 194;
                            objE_MovimientoCaja.TipoMovimiento = "I";
                            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaCheque.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Cheque;
                            objE_MovimientoCaja.ImporteDolares = Cheque / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.NumeroCondicion = txtNumeroCheque.Text.Trim();
                            objE_MovimientoCaja.FlagEstado = true;
                            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }

                        //****************************
                        string Concepto = "PAGO";
                        //string NumeroPedido = "";
                        if (IdPedido != null)
                        {
                            Concepto = "PAGO " + FormaPagoPedido + " N° " + txtNumeroPedido.Text.Trim();
                        };
                        if (IdDis_ProyectoServicio != null)
                        {
                            Concepto = "PAGO PROYECTO N° " + txtNumeroProyecto.Text.Trim();
                        }
                        if (IdDis_ContratoFabricacion != null)
                        {
                            Concepto = "PAGO CONTRATO FAB. N° " + txtNumeroContrato.Text.Trim();
                        }


                        //Glosa EECC
                        string NumeroEECC = "R" +txtNumeroDocumento.Text.Trim(); // txtNumeroDocumento.Text.Trim();
                        //Concepto = "PAGO" + NumeroPedido;
                        if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0 && (Efectivo == 0 && Visa == 0 && MasterCard == 0 && Cheque == 0))
                        {
                            NumeroEECC = "SD " + NumeroDevolucion;
                            Concepto = "NC " + txtSerie.Text + "-" + txtNumeroNCV.Text;
                        }

                        //Estado Cuenta
                        //EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                        EstadoCuentaBE objE_EstadoCuenta = null;
                        if (IdCliente != 477159)
                        {
                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                            {
                                objE_EstadoCuenta = new EstadoCuentaBE();
                                objE_EstadoCuenta.IdEstadoCuenta = IdEstadoCuenta;
                                objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuenta.IdCliente = Convert.ToInt32(IdCliente);
                                objE_EstadoCuenta.NumeroDocumento = NumeroEECC;//"R" + txtNumeroDocumento.Text.Trim();
                                objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                objE_EstadoCuenta.FechaDeposito = null;
                                objE_EstadoCuenta.Concepto = Concepto;//PAGO" + NumeroPedido;
                                objE_EstadoCuenta.FechaVencimiento = null;
                                objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteDolares.EditValue);
                                objE_EstadoCuenta.ImporteAnt = decImporteAnt;
                                objE_EstadoCuenta.TipoMovimiento = "A";
                                objE_EstadoCuenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                                objE_EstadoCuenta.Observacion = "";
                                objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                                objE_EstadoCuenta.FlagEstado = true;
                                objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVentaNC;//(int?)null;
                                objE_EstadoCuenta.IdCotizacion = (int?)null;
                                objE_EstadoCuenta.IdPedido = (int?)IdPedido;
                            }
                        }

                        //Separacion
                        SeparacionBE objE_Separacion = null;
                        if (IdCliente != 477159)
                        {
                            if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)
                            {
                                //Datos de la separación
                                objE_Separacion = new SeparacionBE();
                                objE_Separacion.IdSeparacion = IdSeparacion;
                                objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                                objE_Separacion.Periodo = Parametros.intPeriodo;
                                objE_Separacion.IdCliente = Convert.ToInt32(IdCliente);
                                objE_Separacion.NumeroDocumento = NumeroEECC;//"R" + txtNumeroDocumento.Text.Trim();
                                objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                objE_Separacion.FechaPago = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());// null;
                                objE_Separacion.Concepto = Concepto;// "PAGO" + NumeroPedido;

                                objE_Separacion.FechaVencimiento = null;
                                objE_Separacion.Importe = Convert.ToDecimal(txtImporteSoles.EditValue);
                                objE_Separacion.ImporteAnt = decImporteAnt;
                                objE_Separacion.TipoMovimiento = "A";
                                objE_Separacion.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                                objE_Separacion.IdDocumentoVenta = IdDocumentoVentaNC;//(int?)null;
                                objE_Separacion.IdPedido = IdPedido;
                                objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                                objE_Separacion.FlagEstado = true;
                                objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                if (IdDis_ProyectoServicio > 0)
                                {
                                    objE_Separacion.Concepto = txtConcepto.Text.Trim();

                                    Dis_ProyectoServicioBE ojbE_ProyectoServicio = new Dis_ProyectoServicioBE();

                                    ojbE_ProyectoServicio.IdEmpresa = Parametros.intEmpresaId;
                                    ojbE_ProyectoServicio.IdDis_ProyectoServicio = Convert.ToInt32(IdDis_ProyectoServicio);
                                    ojbE_ProyectoServicio.IdSituacion = Parametros.intSITProyectoServicioEjecucion;
                                    ojbE_ProyectoServicio.Usuario = Parametros.strUsuarioLogin;
                                    ojbE_ProyectoServicio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                    Dis_ProyectoServicioBL objBL_ProyectoServicio = new Dis_ProyectoServicioBL();
                                    objBL_ProyectoServicio.ActualizaSituacion(ojbE_ProyectoServicio);
                                }
                            }
                        }

                        if (pOperacion == Operacion.Nuevo)
                        {
                            //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                            IdPago = objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);

                            if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0) //add 060416
                            {
                                if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                                    ActualizaNotaCredito();
                                else
                                    ActualizaSolicitud();
                            }
                        }
                        else
                        {
                            //Datos del Movimiento de Caja
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Parametros.intTipoDocReciboPago, NumeroDocumento);

                            //objE_MovimientoCaja.IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;

                            //objBL_Pagos.Actualiza(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                            objBL_Pagos.Actualiza(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        }

                        this.Close();
                    }
                    #endregion
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

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información del Pedido
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumeroPedido.Text.Trim());
                    if (objE_Pedido != null)
                    {
                        IdCliente = objE_Pedido.IdCliente;
                        IdPedido = objE_Pedido.IdPedido;
                        txtNumeroPedido.Text = objE_Pedido.Numero;
                        cboMoneda.EditValue = objE_Pedido.IdMoneda;
                        txtCodMonedaPedido.Text = objE_Pedido.CodMoneda;
                        txtTotal.EditValue = objE_Pedido.Total;
                        txtDescCliente.Text = objE_Pedido.DescCliente;
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                        cboMotivo.EditValue = objE_Pedido.IdMotivo;
                        IdTipoCliente = objE_Pedido.IdTipoCliente;
                        IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                        FormaPagoPedido = objE_Pedido.DescFormaPago;
                        txtFormaPago.EditValue = objE_Pedido.DescFormaPago;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkPlanilla.Checked)
                {
                    frmBuscaPersona frm = new frmBuscaPersona();
                    frm.TipoBusqueda = 0;
                    //frm.Title = "Búsqueda de Persona sin Usuario";
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        IdPersona = frm._Be.IdPersona;
                        txtDescCliente.Text = frm._Be.ApeNom;
                        txtConcepto.Select();
                    }
                }
                else
                {
                    frmBusCliente frm = new frmBusCliente();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pClienteBE != null)
                    {
                        IdCliente = frm.pClienteBE.IdCliente;
                        txtDescCliente.Text = frm.pClienteBE.DescCliente;
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;

                        IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                        IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;

                        //add 210116
                        List<Dis_ProyectoServicioBE> lst_ProyectoServicio = new List<Dis_ProyectoServicioBE>();
                        lst_ProyectoServicio = new Dis_ProyectoServicioBL().ListaSituacionCliente(Parametros.intEmpresaId, Convert.ToInt32(IdCliente), Parametros.intSITProyectoServicioEjecucion);

                        if (lst_ProyectoServicio.Count > 0)
                        {
                            if (XtraMessageBox.Show("El Cliente cuenta con un Proyecto de Diseño en Ejecución N°" + lst_ProyectoServicio[0].Numero + "\nAsesorado por: " + lst_ProyectoServicio[0].DescAsesor + "\nDesea vincular este pago al proyecto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                IdDis_ProyectoServicio = lst_ProyectoServicio[0].IdDis_ProyectoServicio;
                                txtNumeroProyecto.Text = lst_ProyectoServicio[0].Numero;
                                txtNumeroProyecto.Properties.ReadOnly = true;
                                txtNumeroPedido.Properties.ReadOnly = true;
                                chkPlanilla.Enabled = false;
                                btnBuscar.Enabled = false;

                            }
                        }

                        if (IdCliente == 477159)
                        {
                            txtGiftCard.Enabled = true;
                        }
                        txtNumeroDocumento.Select();
                    }
                }


            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEfectivo_EditValueChanged(object sender, EventArgs e)
        {
            ValidarDiferencia();
        }

        private void txtVisa_EditValueChanged(object sender, EventArgs e)
        {
            ValidarDiferencia();
        }

        private void txtMastercard_EditValueChanged(object sender, EventArgs e)
        {
            ValidarDiferencia();
        }

        private void txtCheque_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtChequeSoles.EditValue) > 0)
            {
                decimal ImporteDolares = 0;
                ImporteDolares = Convert.ToDecimal(txtChequeSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                txtChequeDolares.EditValue = ImporteDolares;
            }

            ValidarDiferencia();
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
                btnGrabar.Focus();
            }
        }

        private void txtCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGrabar.Focus();
            }
        }

        private void txtChequeDolares_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtChequeDolares.EditValue) > 0)
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtChequeDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtChequeSoles.EditValue = ImporteSoles;
            }
        }

        private void txtNumeroProyecto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información de la Dis_ProyectoServicio
                    Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = null;
                    objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProyecto.Text.Trim());
                    if (objE_Dis_ProyectoServicio != null)
                    {
                        IdDis_ProyectoServicio = objE_Dis_ProyectoServicio.IdDis_ProyectoServicio;
                        txtNumeroProyecto.Text = objE_Dis_ProyectoServicio.Numero;
                        cboVendedor.EditValue = objE_Dis_ProyectoServicio.IdAsesor;
                        cboMoneda.EditValue = objE_Dis_ProyectoServicio.IdMoneda;
                        txtTipoCambio.EditValue = objE_Dis_ProyectoServicio.TipoCambio;
                        IdCliente = objE_Dis_ProyectoServicio.IdCliente;
                        //txtNumeroDocumento.Text = objE_Dis_ProyectoServicio.NumeroDocumento;
                        txtDescCliente.Text = objE_Dis_ProyectoServicio.DescCliente;

                        if (objE_Dis_ProyectoServicio.CantidadPago == 0)
                        {
                            txtImporteSoles.EditValue = 300;
                            txtConcepto.Text = "1° PAGO DE ASESORIA DE DISEÑO";
                        }
                        else
                        {
                            txtImporteSoles.EditValue = 0;
                            txtConcepto.Text = "PAGO PROYECTO N° " + objE_Dis_ProyectoServicio.Numero;
                            //txtConcepto.Text = "";
                        }

                        //Selecciona TipoCliente
                        ClienteBE objE_Cliente = null;
                        //objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, objE_Dis_ProyectoServicio.NumeroDocumento);
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(IdCliente));
                        if (objE_Cliente != null)
                        {
                            //IdCliente = objE_Cliente.IdCliente;
                            //txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                            txtDescCliente.Text = objE_Cliente.DescCliente;
                            IdTipoCliente = objE_Cliente.IdTipoCliente;
                            IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                            //txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                            if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                            {
                                txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                                cboMoneda.EditValue = Parametros.intSoles;
                                txtCodMonedaPedido.Text = "S/";
                            }
                            else
                            {
                                cboMoneda.EditValue = Parametros.intDolares;
                                txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                                txtCodMonedaPedido.Text = "US$";
                            }
                        }

                        txtNumeroContrato.Properties.ReadOnly = true;
                        txtNumeroProyecto.Properties.ReadOnly = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de proyecto no existe, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPlanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlanilla.Checked)
            {
                txtConcepto.Text = "AMORTIZACION DE DEUDA";
            }
            else
            {
                txtConcepto.Text = "";
            }
        }

        private void cboDocumentoCR_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
            {
                txtSerie.Enabled = true;
                txtSerie.Select();
                ////cboEmpresaOrigen.Enabled = false;
                //cboEmpresaOrigen.Properties.ReadOnly = true;
                //cboEmpresaOrigen.EditValue = Parametros.intEmpresaId;
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

        private void txtNumeroNCV_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text.Trim(), txtNumeroNCV.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            //Verificar si la NC está usada
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text + "-" + objE_DocumentoVenta.Numero); //txtNumeroDocumento.Text);
                            if (objE_MovimientoCaja != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroNCV.Text + " ya está usada, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            //Verificar Estado de cuenta
                            EstadoCuentaBE objE_EstadoCuenta = null;
                            objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaDocumentoVenta(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);

                            if (objE_EstadoCuenta != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroNCV.Text + " ya existe en el estado de cuenta Mayorista, por lo tanto no se puede aplicar, por favor consultar con Créditos y Cobranzas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            //Verificar Estado de cuenta C. Final
                            SeparacionBE objE_Separacion = null;
                            objE_Separacion = new SeparacionBL().SeleccionaDocumentoVenta(objE_DocumentoVenta.IdDocumentoVenta);

                            if (objE_Separacion != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroNCV.Text + " ya existe en el estado de cuenta C. Final, por lo tanto no se puede aplicar, por favor consultar con Créditos y Cobranzas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                //}else


                                //if (objE_DocumentoVenta.CodigoNC == "02")
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


                            #region "Solicitud Devolución"

                            //Traemos la información del Pedido
                            CambioBE objE_Cambio = null;
                            objE_Cambio = new CambioBL().SeleccionaNotaCredito(objE_DocumentoVenta.IdDocumentoVenta);
                            if (objE_Cambio != null)
                            {
                                //IdCambio = objE_Cambio.IdCambio;
                                NumeroDevolucion = objE_Cambio.Numero;
                            }
                            else
                            {
                                NumeroDevolucion = "";
                                XtraMessageBox.Show("El Documento Venta " + txtSerie.Text + "-" + txtNumeroNCV.Text + " de la empresa " + cboEmpresaOrigen.Text + " no está autorizado ó ya fue recibida\nConsulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            #endregion


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
                            IdDocumentoVentaNC = objE_DocumentoVenta.IdDocumentoVenta;
                            txtCodMonedaPedido.Text = objE_DocumentoVenta.CodMoneda;
                            txtDescClienteNCV.Text = objE_DocumentoVenta.DescCliente;
                            txtImporteNCDolares.EditValue = objE_DocumentoVenta.Total;
                            txtNumeroDocumento.Text = objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;
                            if (objE_DocumentoVenta.IdMoneda == Parametros.intSoles)
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total;
                                txtEfectivo.Focus();
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total * Convert.ToDecimal(txtTipoCambio.Text);
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
                        objE_Cambio = new CambioBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Parametros.intPeriodo, txtNumeroNCV.Text.Trim());
                        if (objE_Cambio != null)
                        {

                            //Verificar si la SD está usada
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), objE_Cambio.Numero);
                            if (objE_MovimientoCaja != null)
                            {
                                XtraMessageBox.Show("La Solicitud de devolución " + txtNumeroNCV.Text + ", ya está usada, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LimpiarPago();
                                return;
                            }

                            //Documento Cambio
                            //IdDocumentoVentaNC = objE_Cambio.IdDocumentoVenta;
                            txtCodMonedaPedido.Text = objE_Cambio.CodMoneda;
                            txtDescClienteNCV.Text = objE_Cambio.DescCliente;
                            txtImporteNCDolares.EditValue = objE_Cambio.Total;
                            txtNumeroDocumento.Text = objE_Cambio.Numero;
                            if (objE_Cambio.CodMoneda.Contains("S/"))
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total;
                                txtEfectivo.Focus();
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total * Convert.ToDecimal(txtTipoCambio.Text);
                                txtEfectivo.Focus();
                            }
                        }

                        else
                        {
                            XtraMessageBox.Show("No existe la solicitud de devolución N°" + txtNumeroNCV.Text + " para la empresa: " + cboEmpresaOrigen.Text + ", \npor favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtEfectivoRCP_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPagoCincoPorCiento();
        }

        private void txtVisaRCP_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPagoCincoPorCiento();
        }

        private void txtVisaPuntosVidaRCP_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPagoCincoPorCiento();
        }

        private void txtMastercardRCP_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPagoCincoPorCiento();
        }

        private void txtMastercardPuntosVidaRCP_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPagoCincoPorCiento();
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

        #endregion

        
        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboCaja.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la caja.\n";
                flag = true;
            }


            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Ingresar Nombre del cliente.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione el documento.\n";
                flag = true;
            }

            if (IdCliente == Parametros.intIdClienteGeneral)
            {
                strMensaje = strMensaje + "- No se puede registrar con CLIENTE GENERAL.\n";
                flag = true;
            }


            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (cboCondicionPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la condición de pago.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la moneda.\n";
                flag = true;
            }

            if (txtConcepto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el concepto del recibo de pago.\n";
                flag = true;
            }

            if (Convert.ToDecimal(txtImporteSoles.EditValue) <= 0)
            {
                strMensaje = strMensaje + "- Ingrese El importe en los datos del estado Importe.\n";
                flag = true;
            }

            EstadoCuentaBE objE_EstadoCuenta = null;
            objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaNumeroDocumento(Parametros.intPeriodo, "R" + txtNumeroDocumento.Text.Trim());
            if (objE_EstadoCuenta != null)
            {
                strMensaje = strMensaje + "- El Numero de documento ya existe en el Estado de Cuenta de Cliente Mayorista.\n";
                flag = true;
            }

            SeparacionBE objE_Separacion = null;
            objE_Separacion = new SeparacionBL().SeleccionaNumeroDocumento(Parametros.intPeriodo, "R" + txtNumeroDocumento.Text.Trim());
            if (objE_Separacion != null)
            {
                strMensaje = strMensaje + "- El Numero de documento ya existe en el Estado de Cuenta de Cliente Final.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPago.Where(oB => oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El documento ya existe.\n";
                    flag = true;
                }

            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private bool ValidarIngresoPlanilla()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboCaja.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la caja.\n";
                flag = true;
            }


            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "- Ingresar Nombre del Personal.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione el documento.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (cboCondicionPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la condición de pago.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la moneda.\n";
                flag = true;
            }

            if (txtConcepto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el concepto del recibo de pago.\n";
                flag = true;
            }

            //EstadoCuentaBE objE_EstadoCuenta = null;
            //objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaNumeroDocumento(Parametros.intPeriodo, "R"+ txtNumeroDocumento.Text.Trim());
            //if (objE_EstadoCuenta != null)
            //{
            //    strMensaje = strMensaje + "- El Numero de documento ya existe en el Estado de Cuenta de Cliente Mayorista.\n";
            //    flag = true;                
            //}

            //SeparacionBE objE_Separacion = null;
            //objE_Separacion = new SeparacionBL().SeleccionaNumeroDocumento(Parametros.intPeriodo, "R" + txtNumeroDocumento.Text.Trim());
            //if (objE_Separacion != null)
            //{
            //    strMensaje = strMensaje + "- El Numero de documento ya existe en el Estado de Cuenta de Cliente Final.\n";
            //    flag = true;
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPago.Where(oB => oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El documento ya existe.\n";
                    flag = true;
                }

            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void ValidarTotal()
        {
            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            {
                txtEfectivo.EditValue = txtImporteSoles.EditValue;
            }
            else
            {
                txtEfectivo.EditValue = txtImporteDolares.EditValue;
            }
        }

        private void ValidarDiferencia()
        {
            decimal Efectivo = 0;
            decimal Cheque = 0;

            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            {
                txtTotalResumen.EditValue = txtImporteSoles.EditValue;
                Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
                Cheque = Convert.ToDecimal(txtChequeSoles.EditValue);//add
            }
            else
            {
                txtTotalResumen.EditValue = txtImporteSoles.EditValue;
                Efectivo = Convert.ToDecimal(txtEfectivo.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                Cheque = Convert.ToDecimal(txtChequeSoles.EditValue);//add
            }

            //Cheque

            //if (Convert.ToInt32(cboMonedaCheque.EditValue) == Parametros.intSoles)
            //{
            //    txtTotalResumen.EditValue = txtImporteSoles.EditValue;
            //    Cheque = Convert.ToDecimal(txtChequeSoles.EditValue);
            //}
            //else
            //{
            //    txtTotalResumen.EditValue = txtImporteSoles.EditValue;
            //    Cheque = Convert.ToDecimal(txtChequeSoles.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
            //}



            //txtResta.EditValue = Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue));
            txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Efectivo + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Cheque + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);

            if (Convert.ToDecimal(txtVisa.EditValue) > 0 || Convert.ToDecimal(txtMastercard.EditValue) > 0) //add 180216
            {
                if (IdTipoCliente == Parametros.intTipClienteMayorista && IdCliente != 2697)
                {
                    lblMensaje.Text = "COBRAR EL 5% POR\nRECARGO DE TARJETA";
                    gcReciboPago.Visible = true;
                    this.Size = new Size(1080, 622);
                    txtTotalResumenRCP.EditValue = Math.Round((Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue)) * Convert.ToDecimal("0.05"), 2); //5% por Tarjeta
                    CalcularPagoCincoPorCiento();
                }
            }
            else
            {
                lblMensaje.Text = "";
                txtTotalResumenRCP.EditValue = 0;
                CalcularPagoCincoPorCiento();
                this.Size = new Size(553, 622);
            }

        }

        private void CalcularPagoCincoPorCiento()
        {
            txtRestaRCP.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue) - (Convert.ToDecimal(txtEfectivoRCP.EditValue) + Convert.ToDecimal(txtVisaRCP.EditValue) + Convert.ToDecimal(txtMastercardRCP.EditValue) + Convert.ToDecimal(txtVisaPuntosVidaRCP.EditValue) + Convert.ToDecimal(txtMastercardPuntosVidaRCP.EditValue)), 2);

        }

        private DataTable CargarTipoDocumentoCheque()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 14;
            dr["Descripcion"] = "CHQ";
            dt.Rows.Add(dr);
            return dt;
        }

        private void Imprimir(int IdPagoI)
        {
            PagosBE objE_Pago = null;
            objE_Pago = new PagosBL().Selecciona(Parametros.intEmpresaId, IdPagoI);

            if (objE_Pago != null)
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

                #region "Ticket Pago"

                //TalonBE objTalon = null;
                //objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Parametros.intTipoDocReciboPago);

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

                    //if (printer.ToUpper().StartsWith(objTalon.Impresora))//("(T)"))
                    if (printer.ToUpper().StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    //MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                    MessageBox.Show("La impresora (T) Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                string MonedaLetra = "";
                decimal ImportePago = 0;
                if (objE_Pago.IdMoneda == Parametros.intSoles)
                {
                    MonedaLetra = " Soles";
                    ImportePago = objE_Pago.ImporteSoles;
                }
                else
                {
                    MonedaLetra = " Dolares";
                    ImportePago = objE_Pago.ImporteDolares;
                }


                //ticket.AbreCajon();  //abre el cajon

                //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                //ticket.TextoCentro(dirFacturacion);
                //ticket.TextoCentro("RUC: 20330676826");
                //ticket.TextoCentro(objTalon.NombreComercial);
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(dirFacturacion);
                if (Parametros.intEmpresaId == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                ticket.TextoIzquierda("N° " + objE_Pago.NumeroDocumento + "      " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.LineasGuion();
                ticket.TextoIzquierda("RECIBI DE: " + objE_Pago.DescCliente);
                ticket.TextoIzquierdaNLineas("La Cantidad de: " + FuncionBase.Enletras(Math.Round(Convert.ToDouble(ImportePago), 2).ToString()) + MonedaLetra);
                ticket.TextoIzquierda("Referencia: " + objE_Pago.Concepto);
                ticket.TextoIzquierda("");
                ticket.LineasTotales();
                ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(ImportePago), 2)); // imprime linea con total
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoCentro(new String('-', Parametros.strEmpresaNombre.Length));
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.CortaTicket();

                #endregion

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


                    //Cliente
                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(IdCliente));

                    decimal deTotal = Math.Round(Convert.ToDecimal(txtTotalResumenRCP.EditValue), 2);
                    decimal deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = Convert.ToInt32(IdCliente);
                    objDocumentoVenta.NumeroDocumento = objE_Cliente.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Cliente.DescCliente;
                    objDocumentoVenta.Direccion = objE_Cliente.Direccion;
                    objDocumentoVenta.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);//Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Parametros.intContado; //Convert.ToInt32(cboFormaPago.EditValue);
                    //objDocumentoVenta.IdVendedor = 10085; //Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.IdVendedor = objE_Cliente.IdVendedor;
                    objDocumentoVenta.TotalCantidad = 1; //Convert.ToInt32(txtTotalCantidad.EditValue);
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deTotal - deSubTotal;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = 0;
                    objDocumentoVenta.Observacion = "DOCUMENTO DE VENTA GENERADO POR 5% DE TARJETA";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo;
                        objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa;
                        objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard;
                        objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
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
                    objE_Pago.IdMoneda = Parametros.intSoles;
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_Pago.Importe = deTotal; //Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);



                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, true);
                    ImpresionTicket(cboDocumentoGenerarRCP.Text, IdDocumentoVenta);

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
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(IdCliente));

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
                    objPago.Concepto = "RECARGO 5% " + txtNumeroPedido.Text + " " + objE_Cliente.DescCliente;
                    objPago.IdMoneda = Parametros.intSoles;
                    objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objPago.ImporteSoles = Convert.ToDecimal(txtTotalResumenRCP.EditValue);
                    objPago.ImporteDolares = Convert.ToDecimal(txtTotalResumenRCP.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo;
                        objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa;
                        objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard;
                        objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTipoCambio.EditValue);
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
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
                        objE_MovimientoCaja.IdMoneda = Parametros.intSoles;
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
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
                    objE_Pago.IdMoneda = Parametros.intSoles;
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotalResumenRCP.EditValue); //Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);

                    //Estado Cuenta
                    EstadoCuentaBE objE_EstadoCuenta = null;
                    SeparacionBE objE_Separacion = null;


                    objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                    MessageBox.Show("5% emitido!");


                    #endregion
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (TipoDoc == "BEE")
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
                if (TipoDoc == "FEE")
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
                else
                {
                    MessageBox.Show("Se encontro impresora " + objTalon.Impresora +  " Se procederá a imprimir ");
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


        }

        private void LimpiarPago()
        {
            txtImporteNCSoles.EditValue = 0;
            txtImporteNCDolares.EditValue = 0;
            txtDescCliente.Text = "";
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
            //Numero = txtSerie.Text + "-" + txtNumeroDocumento.Text;
            Numero = txtNumeroDocumento.Text;
            objPago.NumeroDocumento = Numero;
            objPago.IdCondicionPago = Parametros.intEfectivo;
            objPago.Concepto = "APLICACION NOTA DE CREDITO";
            objPago.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMonedaPago.EditValue);
            objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            objPago.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objPago.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            objPago.FlagEstado = true;
            objPago.Usuario = Parametros.strUsuarioLogin;
            objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objPago.IdEmpresa = Convert.ToInt32(cboEmpresaOrigen.EditValue);

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
            objMovimientoCaja.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMonedaPago.EditValue);
            objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            objMovimientoCaja.IdDocumentoVenta = IdDocumentoVentaNC;
            objMovimientoCaja.FlagEstado = true;
            objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
            objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresaOrigen.EditValue);
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
            objPago.IdMoneda = Parametros.intSoles;// Convert.ToInt32(cboMonedaPago.EditValue);
            objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            objPago.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objPago.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            objPago.FlagEstado = true;
            objPago.Usuario = Parametros.strUsuarioLogin;
            objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objPago.IdEmpresa = Convert.ToInt32(cboEmpresaOrigen.EditValue);

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
            objMovimientoCaja.IdMoneda = Parametros.intSoles;// Convert.ToInt32(cboMonedaPago.EditValue);
            objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            objMovimientoCaja.FlagEstado = true;
            objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
            objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresaOrigen.EditValue);
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


            dr = dt.NewRow();
            dr["Id"] = "757";
            dr["Descripcion"] = "BBVA PROMOCION";
            dt.Rows.Add(dr);
            #endregion
            return dt;
        }

        #endregion

        private void txtNumeroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información de la Dis_ContratoFabricacion
                    Dis_ContratoFabricacionBE objE_Dis_ContratoFabricacion = null;
                    objE_Dis_ContratoFabricacion = new Dis_ContratoFabricacionBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroContrato.Text.Trim());
                    if (objE_Dis_ContratoFabricacion != null)
                    {
                        IdDis_ContratoFabricacion = objE_Dis_ContratoFabricacion.IdDis_ContratoFabricacion;
                        txtNumeroContrato.Text = objE_Dis_ContratoFabricacion.Numero;
                        cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;
                        //cboMoneda.EditValue = objE_Dis_ContratoFabricacion.IdMoneda;
                        //txtTipoCambio.EditValue = objE_Dis_ContratoFabricacion.TipoCambio;
                        IdCliente = objE_Dis_ContratoFabricacion.IdCliente;
                        //txtNumeroDocumento.Text = objE_Dis_ContratoFabricacion.NumeroDocumento;
                        txtDescCliente.Text = objE_Dis_ContratoFabricacion.DescCliente;
                        txtConcepto.Text = "PAGO CF N° " + objE_Dis_ContratoFabricacion.Numero;

                        //if (objE_Dis_ContratoFabricacion.CantidadPago == 0)
                        //{
                        //    txtImporteSoles.EditValue = 300;
                        //    txtConcepto.Text = "1° PAGO DE ASESORIA DE DISEÑO";
                        //}
                        //else
                        //{
                        //    txtImporteSoles.EditValue = 0;
                        //    txtConcepto.Text = "";
                        //}

                        //Selecciona TipoCliente
                        ClienteBE objE_Cliente = null;
                        //objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, objE_Dis_ContratoFabricacion.NumeroDocumento);
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(IdCliente));
                        if (objE_Cliente != null)
                        {
                            //IdCliente = objE_Cliente.IdCliente;
                            //txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                            txtDescCliente.Text = objE_Cliente.DescCliente;
                            IdTipoCliente = objE_Cliente.IdTipoCliente;
                            IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                            //txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                            if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                            {
                                txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                                cboMoneda.EditValue = Parametros.intSoles;
                                txtCodMonedaPedido.Text = "S/";
                            }
                            else
                            {
                                cboMoneda.EditValue = Parametros.intDolares;
                                txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                                txtCodMonedaPedido.Text = "US$";
                            }
                        }

                        txtNumeroContrato.Properties.ReadOnly = true;
                        txtNumeroProyecto.Properties.ReadOnly = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de Contrato no existe, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si se presionó la tecla Enter, mover el enfoque al siguiente control .
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtConcepto.Focus();
                return;
            }


            // Obtener el contenido actual del TextBox
            string contenido = txtNumeroDocumento.Text;

            // Verificar si el primer carácter ingresado es un cero
            if (e.KeyChar == '0' && string.IsNullOrEmpty(contenido))
            {
                // Cancelar el evento para evitar que se ingrese el cero
                e.Handled = true;
                return;
            }

            // Verificar si el documento inicia con "F" o "B"
            if (contenido.StartsWith("F") || contenido.StartsWith("B"))
            {
                // Permitir cualquier ingreso en este caso
                return;
            }

            // Si no inicia con "F" o "B", verificar si el primer carácter ingresado es un cero
            if (e.KeyChar == '0')
            {
                // Cancelar el evento para evitar que se ingrese el cero
                e.Handled = true;
            }

        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtGiftCard.Focus();
            }
        }

        private void txtGiftCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtImporteSoles.Focus();
            }
        }

        private void txtNumeroRCP_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}