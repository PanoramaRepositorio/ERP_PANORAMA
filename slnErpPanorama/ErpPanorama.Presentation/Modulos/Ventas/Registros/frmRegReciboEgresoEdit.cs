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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.Presentation.Modulos.Creditos.Consultas;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegReciboEgresoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PagosBE> lstPago;

        private int? IdDocumentoVentaNC;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DateTime FechaD { get; set; }

        int _IdPago = 0;

        public int IdPago
        {
            get { return _IdPago; }
            set { _IdPago = value; }
        }

        string _strTipoMovimiento = "R";
        public string strTipoMovimiento
        {
            get { return _strTipoMovimiento; }
            set { _strTipoMovimiento = value; }
        }

        private int IdPedido = 0;
        private int IdPersona;
        private int IdCliente;
        private int IdSolicitudPrestamo;
        private int? IdHoraExtra;
        private int IdTipoCliente;
        private int IdClasificacionCliente;
        private bool FlagClubDesign = false;
        public string sTipoTarjeta = "";
        #endregion

        #region "Eventos"

        public frmRegReciboEgresoEdit()
        {
            InitializeComponent();
        }

        private void frmRegReciboEgresoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresaOrigen, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresaOrigen.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboDocumentoCR, CargarTipoDocumentoPago(), "Descripcion", "Id", false);
            cboDocumentoCR.EditValue = Parametros.intTipoDocNotaCredito;
            txtTipoCambio.ReadOnly = true;
            //deFecha.EditValue = DateTime.Now;
            deFecha.EditValue = FechaD;
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
                BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
                cboDocumento.EditValue = Parametros.intTipoDocReciboEgreso;
                BSUtils.LoaderLook(cboMotivoEgreso, CargarMotivoEgreso(), "Descripcion", "Id", false);
                cboMotivoEgreso.EditValue = 2;// 1;


                BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
                cboCondicionPago.EditValue = Parametros.intEfectivo;
                txtTipoCambio.EditValue = objE_TipoCambio.Compra;
                BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                cboMoneda.EditValue = Parametros.intSoles;

                BSUtils.LoaderLook(cboTipoTarjeta, CargarTipoTarjeta(), "Descripcion", "Id", false);
                cboTipoTarjeta.EditValue = "";
                ////tipo de Movimiento
                //if (strTipoMovimiento == "R")
                //    optRetiro.Checked = true;
                //else
                //    optPago.Checked = true;


                if (pOperacion == Operacion.Nuevo)
                {
                    this.Text = "Recibo de Egreso - Nuevo";
                }
                else if (pOperacion == Operacion.Modificar)
                {
                    this.Text = "Recibo de Egreso - Modificar";

                    PagosBE objE_Pago = null;
                    objE_Pago = new PagosBL().Selecciona(Parametros.intEmpresaId, IdPago);

                    IdPago = objE_Pago.IdPago;
                    IdPedido = objE_Pago.IdPedido == null ? 0 : IdPedido;
                    IdPersona = objE_Pago.IdPersona == null ? 0 : IdPersona;
                    IdSolicitudPrestamo = objE_Pago.IdSolicitudPrestamo == null ? 0 : IdSolicitudPrestamo;
                    IdHoraExtra = objE_Pago.IdHoraExtra == null ? 0 : IdHoraExtra;
                    IdCliente = objE_Pago.IdCliente == null ? 0 : IdCliente;
                    txtPersona.Text = objE_Pago.DescCliente;
                    cboCaja.EditValue = objE_Pago.IdCaja;
                    deFecha.EditValue = objE_Pago.Fecha;
                    cboDocumento.EditValue = objE_Pago.IdTipoDocumento;
                    txtNumeroDocumento.Text = objE_Pago.NumeroDocumento;
                    cboCondicionPago.EditValue = objE_Pago.IdCondicionPago;
                    txtConcepto.Text = objE_Pago.Concepto;
                    cboMoneda.EditValue = objE_Pago.IdMoneda;
                    txtTipoCambio.EditValue = objE_Pago.TipoCambio;
                    txtImporteSoles.EditValue = objE_Pago.ImporteSoles;
                    txtImporteDolares.EditValue = objE_Pago.ImporteDolares;
                    txtTipoCambio.ReadOnly = true;
                    cboTipoTarjeta.EditValue = sTipoTarjeta;
                    btnGrabar.Enabled = false;
                    if (IdPersona != null)
                    {
                        cboMotivoEgreso.EditValue = 1;
                    }
                    else
                    {
                        cboMotivoEgreso.EditValue = 3;
                    }
                    txtIdHoraExtra.Properties.ReadOnly = true;
                    txtNumeroPrestamo.Properties.ReadOnly = true;

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
            }
            else
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtImporteDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteSoles.EditValue = ImporteSoles;
            }
        }

        private void txtImporteSoles_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
            {
                decimal ImporteDolares = 0;
                ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteDolares.EditValue = ImporteDolares;
            }
        }

        private void txtImporteDolares_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtImporteDolares.EditValue) > 0)
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtImporteDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteSoles.EditValue = ImporteSoles;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PagosBL objBL_Pagos = new PagosBL();

                    //Datos del Recibo de Pago
                    PagosBE objPago = new PagosBE();
                    objPago.IdPago = IdPago;
                    objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                    objPago.IdPersona = IdPersona == 0 ? (int?)null : IdPersona;
                    objPago.IdHoraExtra = IdHoraExtra == 0 ? (int?)null : IdHoraExtra;
                    objPago.IdSolicitudPrestamo = IdSolicitudPrestamo == 0 ? (int?)null : IdSolicitudPrestamo;
                    objPago.IdCliente = IdCliente == 0 ? (int?)null : IdCliente;
                    objPago.IdVendedor = Parametros.intPersonaId;
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
                    objPago.TipoMovimiento = "R"; // Abono - R -RETIRO
                    objPago.FlagEstado = true;
                    objPago.Usuario = Parametros.strUsuarioLogin;
                    objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPago.IdEmpresa = Parametros.intEmpresaId;

                    //Datos del Movimiento de Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                    if (!chkDevolucionNCV.Checked)
                    {
                        MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE(); //Egreso Normal
                        objMovimientoCaja.IdMovimientoCaja = 0;
                        objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objMovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                        objMovimientoCaja.IdFormaPago = Parametros.intContado;
                        objMovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objMovimientoCaja.TipoMovimiento = "S";
                        objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                        objMovimientoCaja.FlagRetiroCliente = true; // ECM
                        objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                        objMovimientoCaja.FlagEstado = true;
                        objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objMovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objMovimientoCaja);
                    }
                    else
                    {
                        #region "MovimientoCaja"

                        //Nota de Crédito
                        MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                        objMovimientoCaja.IdMovimientoCaja = 0;
                        objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
                        objMovimientoCaja.NumeroDocumento = txtSerie.Text +"-"+ txtNumeroNCV.Text;
                        objMovimientoCaja.IdFormaPago = Parametros.intContado;
                        objMovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objMovimientoCaja.TipoMovimiento = "I";
                        objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                        objMovimientoCaja.FlagRetiroCliente = true; // ECM
                        objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
                        objMovimientoCaja.ImporteDolares = (Convert.ToDecimal(txtImporteNCSoles.EditValue)/ Convert.ToDecimal(txtTipoCambio.EditValue));
                        objMovimientoCaja.FlagEstado = true;
                        objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objMovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objMovimientoCaja);



                        //Cargar Valores
                        decimal Efectivo = 0;
                        Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intDolares)
                            Efectivo = Efectivo * Convert.ToDecimal(txtTipoCambio.EditValue);

                        decimal Visa = Convert.ToDecimal(txtVisa.EditValue);
                        decimal MasterCard = Convert.ToDecimal(txtMastercard.EditValue);
                        decimal Cheque = 0;// Convert.ToDecimal(txtChequeSoles.EditValue);

                        ////Movimiento Caja
                        //List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                        if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && Cheque == 0))
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            objE_MovimientoCaja.IdMovimientoCaja = 0;
                            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 98;//
                            objE_MovimientoCaja.TipoMovimiento = "S";
                            objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                            objMovimientoCaja.FlagRetiroCliente = true; // ECM
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
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 99;
                            objE_MovimientoCaja.TipoMovimiento = "S";
                            objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                            objMovimientoCaja.FlagRetiroCliente = true; // ECM
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
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 100;
                            objE_MovimientoCaja.TipoMovimiento = "S";
                            objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                            objMovimientoCaja.FlagRetiroCliente = true; // ECM
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
                            objE_MovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                            objE_MovimientoCaja.IdFormaPago = Parametros.intContado;
                            objE_MovimientoCaja.IdCondicionPago = 194;
                            objE_MovimientoCaja.TipoMovimiento = "S";
                            objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                            objMovimientoCaja.FlagRetiroCliente = true; // ECM
                            objE_MovimientoCaja.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMonedaCheque.EditValue);
                            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.ImporteSoles = Cheque;
                            objE_MovimientoCaja.ImporteDolares = Cheque / Convert.ToDecimal(txtTipoCambio.EditValue);
                            objE_MovimientoCaja.NumeroCondicion = "";// txtNumeroCheque.Text.Trim();
                            objE_MovimientoCaja.FlagEstado = true;
                            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            lstMovimientoCaja.Add(objE_MovimientoCaja);
                        }

                        #endregion
                    }


                    #region "Estado de cuenta"

                    //Estado Cuenta
                    //EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                    EstadoCuentaBE objE_EstadoCuenta = null;
                    SeparacionBE objE_Separacion = null;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        if (Convert.ToInt32(cboMotivoEgreso.EditValue) ==2)
                        {
                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                            {
                                if (chkDevolucionNCV.Checked)
                                {
                                    if (Convert.ToDecimal(txtEfectivo.EditValue) > 0)
                                    {
                                        objE_EstadoCuenta = new EstadoCuentaBE();
                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuenta.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_EstadoCuenta.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "DEV DE EFECTIVO";
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = Convert.ToDecimal(txtEfectivo.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);
                                        //if (txtCodMonedaPedido.Text == "S/")
                                        //    objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteNCDolares.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);

                                        objE_EstadoCuenta.ImporteAnt = 0;
                                        objE_EstadoCuenta.TipoMovimiento = "C";
                                        objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta; //Convert.ToInt32(cboMotivo.EditValue);
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVentaNC;// (int?)null;
                                        objE_EstadoCuenta.IdCotizacion = (int?)null;
                                        objE_EstadoCuenta.IdPedido = (int?)IdPedido;
                                        objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                                    }        

                                    if (Convert.ToDecimal(txtVisa.EditValue) > 0)
                                    {
                                        objE_EstadoCuenta = new EstadoCuentaBE();
                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuenta.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_EstadoCuenta.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "DEV WEB VISA";
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = Convert.ToDecimal(txtVisa.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);
                                        //if (txtCodMonedaPedido.Text == "S/")
                                        //    objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteNCDolares.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);

                                        objE_EstadoCuenta.ImporteAnt = 0;
                                        objE_EstadoCuenta.TipoMovimiento = "C";
                                        objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta; //Convert.ToInt32(cboMotivo.EditValue);
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVentaNC;// (int?)null;
                                        objE_EstadoCuenta.IdCotizacion = (int?)null;
                                        objE_EstadoCuenta.IdPedido = (int?)IdPedido;
                                        objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                                    }
                                    if (Convert.ToDecimal(txtMastercard.EditValue) > 0)
                                    {
                                        objE_EstadoCuenta = new EstadoCuentaBE();
                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuenta.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_EstadoCuenta.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "DEV WEB MASTERCARD";
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = Convert.ToDecimal(txtMastercard.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);
                                        //if (txtCodMonedaPedido.Text == "S/")
                                        //    objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteNCDolares.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);

                                        objE_EstadoCuenta.ImporteAnt = 0;
                                        objE_EstadoCuenta.TipoMovimiento = "C";
                                        objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta; //Convert.ToInt32(cboMotivo.EditValue);
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVentaNC;// (int?)null;
                                        objE_EstadoCuenta.IdCotizacion = (int?)null;
                                        objE_EstadoCuenta.IdPedido = (int?)IdPedido;
                                        objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
                                    {
                                        objE_EstadoCuenta = new EstadoCuentaBE();
                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuenta.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_EstadoCuenta.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "DEV DE EFECTIVO";
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteDolares.EditValue);
                                        //if (txtCodMonedaPedido.Text == "S/")
                                        //    objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteNCDolares.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);

                                        objE_EstadoCuenta.ImporteAnt = 0;
                                        objE_EstadoCuenta.TipoMovimiento = "C";
                                        objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta; //Convert.ToInt32(cboMotivo.EditValue);
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVentaNC;//(int?)null;
                                        objE_EstadoCuenta.IdCotizacion = (int?)null;
                                        objE_EstadoCuenta.IdPedido = (int?)IdPedido;
                                        objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                                    }
                                }

                            }

                            ////Separacion
                            //SeparacionBE objE_Separacion = null;
                            if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)
                            {
                                if (chkDevolucionNCV.Checked)
                                {
                                    if (Convert.ToDecimal(txtEfectivo.EditValue) > 0)
                                    {
                                        objE_Separacion = new SeparacionBE();
                                        objE_Separacion.IdSeparacion = 0;
                                        objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                                        objE_Separacion.Periodo = Parametros.intPeriodo;
                                        objE_Separacion.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_Separacion.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_Separacion.FechaPago = null;
                                        objE_Separacion.Concepto = "DEV DE EFECTIVO";
                                        objE_Separacion.FechaVencimiento = null;
                                        objE_Separacion.Importe = Convert.ToDecimal(txtEfectivo.EditValue);
                                        objE_Separacion.ImporteAnt = 0;
                                        objE_Separacion.TipoMovimiento = "C";
                                        objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Convert.ToInt32(cboMotivo.EditValue);
                                        objE_Separacion.IdDocumentoVenta = IdDocumentoVentaNC;// (int?)null;
                                        objE_Separacion.IdPedido = IdPedido;
                                        objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                                        objE_Separacion.FlagEstado = true;
                                        objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                        objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    }

                                    if (Convert.ToDecimal(txtVisa.EditValue) > 0)
                                    {
                                        objE_Separacion = new SeparacionBE();
                                        objE_Separacion.IdSeparacion = 0;
                                        objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                                        objE_Separacion.Periodo = Parametros.intPeriodo;
                                        objE_Separacion.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_Separacion.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_Separacion.FechaPago = null;
                                        objE_Separacion.Concepto = "DEV WEB VISA";
                                        objE_Separacion.FechaVencimiento = null;
                                        objE_Separacion.Importe = Convert.ToDecimal(txtVisa.EditValue);
                                        objE_Separacion.ImporteAnt = 0;
                                        objE_Separacion.TipoMovimiento = "C";
                                        objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Convert.ToInt32(cboMotivo.EditValue);
                                        objE_Separacion.IdDocumentoVenta = IdDocumentoVentaNC; // (int?)null;
                                        objE_Separacion.IdPedido = IdPedido;
                                        objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                                        objE_Separacion.FlagEstado = true;
                                        objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                        objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    }
                                    if (Convert.ToDecimal(txtMastercard.EditValue) > 0)
                                    {
                                        objE_Separacion = new SeparacionBE();
                                        objE_Separacion.IdSeparacion = 0;
                                        objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                                        objE_Separacion.Periodo = Parametros.intPeriodo;
                                        objE_Separacion.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_Separacion.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_Separacion.FechaPago = null;
                                        objE_Separacion.Concepto = "DEV WEB MASTERCARD";
                                        objE_Separacion.FechaVencimiento = null;
                                        objE_Separacion.Importe = Convert.ToDecimal(txtVisa.EditValue);
                                        objE_Separacion.ImporteAnt = 0;
                                        objE_Separacion.TipoMovimiento = "C";
                                        objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Convert.ToInt32(cboMotivo.EditValue);
                                        objE_Separacion.IdDocumentoVenta = IdDocumentoVentaNC;// (int?)null;
                                        objE_Separacion.IdPedido = IdPedido;
                                        objE_Separacion.FlagEstado = true;
                                        objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                        objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0) //CD
                                    {
                                        //Datos de la separación
                                        objE_Separacion = new SeparacionBE();
                                        objE_Separacion.IdSeparacion = 0;
                                        objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                                        objE_Separacion.Periodo = Parametros.intPeriodo;
                                        objE_Separacion.IdCliente = Convert.ToInt32(IdCliente);
                                        objE_Separacion.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                        objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_Separacion.FechaPago = null;
                                        objE_Separacion.Concepto = FlagClubDesign? txtConcepto.Text: "DEV DE EFECTIVO";
                                        objE_Separacion.FechaVencimiento = null;
                                        objE_Separacion.Importe = Convert.ToDecimal(txtImporteSoles.EditValue);
                                        objE_Separacion.ImporteAnt = 0;
                                        objE_Separacion.TipoMovimiento = "C";
                                        objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Convert.ToInt32(cboMotivo.EditValue);
                                        objE_Separacion.IdDocumentoVenta = IdDocumentoVentaNC;// (int?)null;
                                        objE_Separacion.IdPedido = IdPedido;
                                        objE_Separacion.FlagEstado = true;
                                        objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                        objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    }
                                }

                            }
                        }

                    }


                    #endregion

                    //////Estado Cuenta
                    ////EstadoCuentaBE objE_EstadoCuenta = null;
                    ////SeparacionBE objE_Separacion = null;



                    if (pOperacion == Operacion.Nuevo)
                    {
                        //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                    }
                    else
                    {
                        //Datos del Movimiento de Caja
                        MovimientoCajaBE objE_MovimientoCaja = null;
                        objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Parametros.intTipoDocReciboEgreso, txtNumeroDocumento.Text.Trim());

                        //objMovimientoCaja.IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;
                        ////objBL_Pagos.Actualiza(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        objBL_Pagos.Actualiza(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                    }

                    this.Close();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboMotivoEgreso.EditValue) == 2)
                {
                    frmBusCliente frm = new frmBusCliente();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pClienteBE != null)
                    {
                        IdCliente = frm.pClienteBE.IdCliente;
                        txtPersona.Text = frm.pClienteBE.DescCliente;

                        ClienteBE objE_Cliente = new ClienteBE();
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);
                        IdTipoCliente = objE_Cliente.IdTipoCliente;
                        IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;

                        txtConcepto.Select();
                    }
                }
                else
                {
                    frmBuscaPersona frm = new frmBuscaPersona();
                    frm.TipoBusqueda = 0;
                    //frm.Title = "Búsqueda de Persona sin Usuario";
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        IdPersona = frm._Be.IdPersona;
                        txtPersona.Text = frm._Be.ApeNom;
                        txtConcepto.Select();
                    }
                }


            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroPrestamo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SolicitudPrestamoBE objE_Solicitud = new SolicitudPrestamoBE();
                objE_Solicitud = new SolicitudPrestamoBL().SeleccionaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipoDocPrestamo, txtNumeroPrestamo.Text.Trim());
                if (objE_Solicitud != null)
                {
                    IdSolicitudPrestamo = objE_Solicitud.IdSolicitudPrestamo;
                    IdPersona = objE_Solicitud.IdPersona;
                    txtPersona.Text = objE_Solicitud.DescPersona;
                    txtImporteSoles.EditValue = objE_Solicitud.TotalPago;
                    if (objE_Solicitud.Metodo == 1)
                    {
                        txtConcepto.Text = "PRESTAMO N°" + txtNumeroPrestamo.Text;
                    }
                    else
                    {
                        txtConcepto.Text = "ADELANTO DE SUELDO N°" + txtNumeroPrestamo.Text;
                    }

                    txtConcepto.Properties.ReadOnly = true;
                    cboMotivoEgreso.Properties.ReadOnly = true;
                    btnBuscar.Enabled = true;

                    //Conversion
                    if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
                    {
                        decimal ImporteDolares = 0;
                        ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                        txtImporteDolares.EditValue = ImporteDolares;
                    }

                    txtIdHoraExtra.Properties.ReadOnly = true;
                    txtNumeroPrestamo.Properties.ReadOnly = true;
                    txtNumeroDocumento.Select();
                }
            }
        }

        private void txtIdHoraExtra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Verificar Cobro
                if (txtIdHoraExtra.Text.ToString().Length == 0)
                {
                    return;
                }
                PagosBE objE_Pago = null;
                objE_Pago = new PagosBL().SeleccionaHoraExtra(Parametros.intEmpresaId, Convert.ToInt32(txtIdHoraExtra.EditValue));
                if (objE_Pago != null)
                {
                    XtraMessageBox.Show("La hora extra fue cobrada por Concepto: " + objE_Pago.Concepto + " en " + objE_Pago.DescTienda + " el día " + objE_Pago.Fecha.ToShortDateString() + " en la Caja "+ objE_Pago.DescCaja , this.Text,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }

                HoraExtraBE objE_HoraExtra = null;
                objE_HoraExtra = new HoraExtraBL().Selecciona(Convert.ToInt32(txtIdHoraExtra.EditValue));
                if (objE_HoraExtra != null)
                {
                    if (objE_HoraExtra.FlagAprobado)
                    {
                        IdHoraExtra = objE_HoraExtra.IdHoraExtra;
                        IdPersona = objE_HoraExtra.IdPersona;
                        txtPersona.Text = objE_HoraExtra.ApeNom;
                        txtImporteSoles.EditValue = objE_HoraExtra.Importe;
                        txtConcepto.Text = "PAGO HHEE N° " + txtIdHoraExtra.Text + " - " + txtPersona.Text;
                        txtConcepto.Properties.ReadOnly = true;
                        cboMotivoEgreso.Properties.ReadOnly = true;
                        btnBuscar.Enabled = true;

                        //Conversion
                        if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
                        {
                            decimal ImporteDolares = 0;
                            ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                            txtImporteDolares.EditValue = ImporteDolares;
                        }
                        //cboMotivoEgreso.EditValue = 2;
                        txtIdHoraExtra.Properties.ReadOnly = true;
                        txtNumeroPrestamo.Properties.ReadOnly = true;
                        txtImporteSoles.Properties.ReadOnly = true;
                        txtImporteDolares.Properties.ReadOnly = true;
                        txtNumeroDocumento.Select();
                    }
                    else
                    {
                        XtraMessageBox.Show("La hora extra no está aprobada por Recursos Humanos, Favor de consultar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
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
                strMensaje = strMensaje + "- Ingrese el concepto del recibo de egreso.\n";
                flag = true;
            }

            if (Convert.ToDecimal(txtImporteSoles.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingrese el importe de Egreso.\n";
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

                //if (IdHoraExtra != null)
                //{
                //    PagosBE objE_Pagos = null;
                //    objE_Pagos = new PagosBL().Selecciona();
                //}
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = Parametros.intTipoDocReciboEgreso;
            dr["Descripcion"] = "RDE";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarMotivoEgreso()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "PLANILLA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "CLIENTE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "EXTERNO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();

            return dt;
        }


        #endregion

        private void txtNumeroNCV_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboMotivoEgreso.EditValue = 2;//Cliente
                    cboMotivoEgreso.Properties.ReadOnly = true;

                    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text.Trim(), txtNumeroNCV.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {

                            //Verificar si la NC está usada
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue),Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text + "-" + objE_DocumentoVenta.Numero); //txtNumeroDocumento.Text);
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

                            if (objE_DocumentoVenta.IdDocumentoReferencia != null)
                            {
                                //DocumentoVentaBE objE_DocumentoOrigen = new DocumentoVentaBE();
                                //objE_DocumentoOrigen = new DocumentoVentaBL().Selecciona(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));

                                #region "Ver Forma de pago en caja"

                                List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();
                                lstMovimientoCaja = new MovimientoCajaBL().ListaDocumentoVenta(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));

                                txtEfectivoDevolucion.EditValue = 0;
                                txtVisaDevolucion.EditValue = 0;
                                txtMasterCardDevolucion.EditValue = 0;

                                foreach (MovimientoCajaBE item in lstMovimientoCaja)
                                {
                                    if (item.IdCondicionPago == Parametros.intEfectivo)
                                    {
                                        txtEfectivoDevolucion.EditValue = item.ImporteSoles;
                                    }
                                    else if (item.IdCondicionPago == Parametros.intVisa)
                                    {
                                        txtVisaDevolucion.EditValue = item.ImporteSoles;
                                    }
                                    else if (item.IdCondicionPago == Parametros.intMasterCard)
                                    {
                                        txtMasterCardDevolucion.EditValue = item.ImporteSoles;
                                    }
                                }

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
                            //txtCodMonedaPedido.Text = objE_DocumentoVenta.CodMoneda;
                            txtDescClienteNCV.Text = objE_DocumentoVenta.DescCliente;
                            txtImporteNCDolares.EditValue = objE_DocumentoVenta.Total;
                            IdCliente = objE_DocumentoVenta.IdCliente;

                            ClienteBE objE_Cliente = new ClienteBE(); //add 270716
                            objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);
                            IdTipoCliente = objE_Cliente.IdTipoCliente;
                            IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;


                            //txtNumeroDocumento.Text = objE_DocumentoVenta.Numero;
                            if (objE_DocumentoVenta.IdMoneda == Parametros.intSoles)
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total;
                                //txtImporteSoles.Focus();
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total * Convert.ToDecimal(txtTipoCambio.Text);
                                //txtImporteSoles.Focus();
                            }
                            txtImporteSoles.EditValue = txtImporteNCSoles.EditValue;

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
                            //txtCodMonedaPedido.Text = objE_Cambio.CodMoneda;
                            txtDescClienteNCV.Text = objE_Cambio.DescCliente;
                            txtImporteNCDolares.EditValue = objE_Cambio.Total;
                            txtNumeroDocumento.Text = objE_Cambio.Numero;
                            if (objE_Cambio.CodMoneda.Contains("S/"))
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total;
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total * Convert.ToDecimal(txtTipoCambio.Text);
                            }

                            txtImporteSoles.EditValue = txtImporteNCSoles.EditValue;
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

        private void LimpiarPago()
        {
            txtImporteNCSoles.EditValue = 0;
            txtImporteNCDolares.EditValue = 0;
            txtDescClienteNCV.Text = "";
            txtNumeroNCV.Text = "";
            txtSerie.Text = "";
        }

        private void chkDevolucionNCV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDevolucionNCV.Checked)
            {
                grdFormaPago.Visible = true;
                btnGrabar.Location = new Point(365, 507);
                btnCancelar.Location = new Point(444, 507);
                this.Size = new Size(554, 578);
                txtImporteSoles.Properties.ReadOnly = true;
                txtImporteDolares.Properties.ReadOnly = true;
            }
            else
            {
                grdFormaPago.Visible = false;
                btnGrabar.Location = new Point(365, 221);
                btnCancelar.Location = new Point(444, 221);
                this.Size = new Size(554, 312);
                txtImporteSoles.Properties.ReadOnly = false;
                txtImporteDolares.Properties.ReadOnly = false;

                LimpiarPago();
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
            return dt;
        }
        private DataTable CargarTipoTarjeta()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "";
            dr["Descripcion"] = "NINGUNO";
            dt.Rows.Add(dr);

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
        private void btnCargarImporteClub_Click(object sender, EventArgs e)
        {
            if(IdCliente>0)
            {
                List<SeparacionBE> lstSeparacion = new List<SeparacionBE>();
                lstSeparacion = new SeparacionBL().ListaCliente(Convert.ToDateTime("01/01/2013"), Convert.ToDateTime(DateTime.Now.ToShortDateString()), IdCliente, Parametros.intMotivoVenta);

                int intTotRegistros = lstSeparacion.Count();

                if (intTotRegistros > 0)
                {
                    decimal Saldo = lstSeparacion[intTotRegistros - 1].Saldo;
                    if (Saldo > 0)
                    {
                        txtImporteSoles.EditValue = 0;
                        txtImporteDolares.EditValue = 0;
                        XtraMessageBox.Show("El cliente tiene una deuda de " + Saldo.ToString() + " Soles\nConsultar su estado de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        #region "Estado de cuenta"
                        int IdMotivo = 0;
                        IdMotivo = Parametros.intMotivoVenta;

                        ClienteBE objE_Cliente = new ClienteBE();
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                        if (IdCliente.ToString() != "")
                        {
                            //if (objE_Cliente.IdTipoCliente  == Parametros.intTipClienteMayorista)
                            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                            {
                                frmConEstadoCuenta frm = new frmConEstadoCuenta();
                                frm.IdCliente = IdCliente;
                                frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                                frm.DescCliente = objE_Cliente.DescCliente;
                                frm.IdMotivoVenta = IdMotivo;
                                frm.Origen = 1;
                                frm.StartPosition = FormStartPosition.CenterParent;
                                frm.ShowDialog();
                            }
                            else
                            {
                                frmConSeparacion frm = new frmConSeparacion();
                                frm.IdCliente = IdCliente;
                                frm.NumeroDocumento = objE_Cliente.NumeroDocumento;//  gvPedido.GetFocusedRowCellValue("NumeroDocumento").ToString();
                                frm.DescCliente = objE_Cliente.DescCliente;// gvPedido.GetFocusedRowCellValue("DescCliente").ToString();
                                frm.IdMotivoVenta = IdMotivo;
                                frm.Origen = 1;
                                frm.StartPosition = FormStartPosition.CenterParent;
                                frm.ShowDialog();
                            }
                        }
                        #endregion

                    }else if(Saldo ==0)
                    {
                        XtraMessageBox.Show("El cliente no tiene saldo  una deuda de " + Saldo.ToString() + " Soles\nConsultar su estado de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        txtConcepto.Text = "RETIRO DE EFECTIVO POR CLUB DESIGN";
                        txtImporteSoles.EditValue = (Saldo*-1);
                        txtImporteSoles.Properties.ReadOnly = true;
                        txtImporteDolares.Properties.ReadOnly = true;
                        btnBuscar.Enabled = false;
                        FlagClubDesign = true;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Seleccionar un cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }
    }
}