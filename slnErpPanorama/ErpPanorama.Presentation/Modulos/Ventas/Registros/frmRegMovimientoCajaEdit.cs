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
using ErpPanorama.Presentation.Modulos.Creditos.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegMovimientoCajaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<MovimientoCajaBE> lstMovimientoCaja;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DateTime FechaD { get; set; }
        public int? IdDocumentoVenta { get; set; }

        int _IdMovimientoCaja = 0;

        public int IdMovimientoCaja
        {
            get { return _IdMovimientoCaja; }
            set { _IdMovimientoCaja = value; }
        }


        
        public int IdEmpresa   { get; set; }//= 0;
        public int IdTienda{ get; set; }//= 0;
        public int IdCaja { get; set; }//= 0;
        private int? IdPedido = null;
        private int IdTipoCliente = 0;
        private int IdCliente = 0;
        private int IdClasificacionCliente = 0;
        private int IdTipoDocumento = 0;

        #endregion

        #region "Eventos"

        public frmRegMovimientoCajaEdit()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoCajaEdit_Load(object sender, EventArgs e)
        {
            //deFecha.EditValue = DateTime.Now;
            deFecha.EditValue = FechaD;
            TipoCambioBE objE_TipoCambio = null;
            cboCaja.Properties.ReadOnly = true;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.EditValue));
            if (objE_TipoCambio == null)
            {
                XtraMessageBox.Show("El tipo de cambio del día no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
                cboEmpresa.EditValue = IdEmpresa; //Parametros.intEmpresaId;
                BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(IdEmpresa,IdTienda /*Parametros.intEmpresaId, Parametros.intTiendaId*/), "DescCaja", "IdCaja", true);
                cboCaja.EditValue = IdCaja; //Parametros.intCajaId;
                BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
                cboFormaPago.EditValue = Parametros.intContado;
                BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
                cboCondicionPago.EditValue = Parametros.intEfectivo;
                txtTipoCambio.EditValue = objE_TipoCambio.Compra;
                BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                cboMoneda.EditValue = Parametros.intSoles;
                BSUtils.LoaderLook(cboTipoTarjeta, CargarTipoTarjeta(), "Descripcion", "Id", false);
                cboTipoTarjeta.EditValue = "";

                BSUtils.LoaderLook(cboEmpresaOrigen, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
                cboEmpresaOrigen.EditValue = IdEmpresa;
                BSUtils.LoaderLook(cboDocumentoCR, CargarTipoDocumentoPago(), "Descripcion", "Id", false);
                cboDocumentoCR.EditValue = Parametros.intTipoDocNotaCredito;

                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda" || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho || Parametros.intPerfilId == Parametros.intPerAdministrador)
                BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
                else
                BSUtils.LoaderLook(cboDocumento, CargarTipoDocumentoMovimientoCaja(), "Descripcion", "Id", true);

                if (pOperacion == Operacion.Nuevo)
                {
                    this.Text = "Movimiento Caja - Nuevo";
                        btnGastos.Visible = true;

                }
                else if (pOperacion == Operacion.Modificar)
                {
                    this.Text = "Movimiento Caja - Modificar";

                    MovimientoCajaBE objE_MovimientoCaja = null;
                    objE_MovimientoCaja = new MovimientoCajaBL().Selecciona(IdMovimientoCaja);

                    IdEmpresa = objE_MovimientoCaja.IdEmpresa;
                    cboEmpresa.EditValue = objE_MovimientoCaja.IdEmpresa;
                    IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;
                    cboCaja.EditValue = objE_MovimientoCaja.IdCaja;
                    deFecha.EditValue = objE_MovimientoCaja.Fecha;
                    cboDocumento.EditValue = objE_MovimientoCaja.IdTipoDocumento;
                    IdTipoDocumento = objE_MovimientoCaja.IdTipoDocumento;
                    txtNumeroDocumento.Text = objE_MovimientoCaja.NumeroDocumento;
                    cboFormaPago.EditValue = objE_MovimientoCaja.IdFormaPago;
                    cboCondicionPago.EditValue = objE_MovimientoCaja.IdCondicionPago;
                    cboMoneda.EditValue = objE_MovimientoCaja.IdMoneda;
                    txtTipoCambio.EditValue = objE_MovimientoCaja.TipoCambio;
                    txtImporteSoles.EditValue = objE_MovimientoCaja.ImporteSoles;
                    txtImporteDolares.EditValue = objE_MovimientoCaja.ImporteDolares;
                    chkEstado.Checked = objE_MovimientoCaja.FlagEstado;
                    cboTipoTarjeta.EditValue = objE_MovimientoCaja.TipoTarjeta;
                    txtNumeroCheque.EditValue = objE_MovimientoCaja.NumeroCondicion;

                    if (chkEstado.Checked == false)
                    {
                        lblEstado.Visible = true;
                    }

                    if (IdDocumentoVenta > 0)
                        lblGeneraTipo.Visible = false;
                    else
                        lblGeneraTipo.Visible = true;

                   
                    //Bloquear Modificar
                    cboEmpresa.Properties.ReadOnly = true;
                    txtTipoCambio.Properties.ReadOnly = true;
                    txtImporteSoles.Properties.ReadOnly = true;
                    txtImporteDolares.Properties.ReadOnly = true;
                    //cboFormaPago.Properties.ReadOnly = true;
                    cboDocumento.Properties.ReadOnly = true;
                    cboCaja.Properties.ReadOnly = true;
                    cboMoneda.Properties.ReadOnly = true;
                    if(objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocTicketBoleta|| objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocTicketFactura || objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica || objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocReciboPago)
                    {
                        txtNumeroDocumento.Properties.ReadOnly = true;
                    }

                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda" ||Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho || Parametros.intPerfilId == Parametros.intPerAdministrador)
                    {
                        cboEmpresa.Properties.ReadOnly = false;
                        deFecha.Properties.ReadOnly = false;
                        txtTipoCambio.Properties.ReadOnly = false;
                        txtImporteSoles.Properties.ReadOnly = false;
                        txtImporteDolares.Properties.ReadOnly = false;
                        cboDocumento.Properties.ReadOnly = false;
                        cboMoneda.Properties.ReadOnly = false;
                        cboCaja.Properties.ReadOnly = false;
                        //cboCondicionPago.Properties.ReadOnly = false;
                    }
                }

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

               if (     Parametros.intPerfilId == Parametros.intPerCajeroCentral || Parametros.intPerfilId == Parametros.intPerCajeroSucursal 
                    || Parametros.intPerfilId == Parametros.intPerCajeroSucursal || Parametros.intPerfilId == Parametros.intPerAdministradorTienda)
                {
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocAperturaCaja)
                    {
                        XtraMessageBox.Show("RECORDATORIO: \n \n - Realizar el cierre de LOTE", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }



                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    if (chkDevolucionPago.Checked == false) //ver1
                    {
                        MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();

                        MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                        objMovimientoCaja.IdMovimientoCaja = IdMovimientoCaja;
                        objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());

                        if (pOperacion == Operacion.Nuevo)
                            objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        else
                        {
                            objMovimientoCaja.IdTipoDocumento = IdTipoDocumento;
                            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda" || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
                            {
                                objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            }
                        }
                            

                        objMovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                        objMovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objMovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);

                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocRetiroCaja|| Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocReciboEgreso)
                            objMovimientoCaja.TipoMovimiento = "S";
                        else
                            objMovimientoCaja.TipoMovimiento = "I";

                        if (cboTipoTarjeta.EditValue.ToString() != "" || cboTipoTarjeta.EditValue.ToString() != null)
                        {
                            objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString();
                        }

                        objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                        objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                        objMovimientoCaja.IdDocumentoVenta = null;
                        objMovimientoCaja.NumeroCondicion = txtNumeroCheque.Text.Trim();
                        objMovimientoCaja.FlagEstado = chkEstado.Checked;
                        objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        if (pOperacion == Operacion.Nuevo)
                        {
                            //objMovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                            //objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                            objBL_MovimientoCaja.Inserta(objMovimientoCaja);

                            if (chkDevolucionPago.Checked == true)
                            {
                                XtraMessageBox.Show("Se registró correctamente la Nota Crédito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (IdDocumentoVenta > 0)
                            {
                                objMovimientoCaja.IdDocumentoVenta = IdDocumentoVenta;
                            }
                            objBL_MovimientoCaja.Actualiza(objMovimientoCaja);
                        }
                    
                    }else //Especial
                    {
                        PagosBL objBL_Pagos = new PagosBL();

                        //Datos del Recibo de Pago
                        PagosBE objPago = new PagosBE();
                        objPago.IdPago = 0;
                        objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                        objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        string Numero = "";
                        Numero = /*txtSerie.Text + "-" +*/ txtNumeroDocumento.Text;
                        objPago.NumeroDocumento = Numero;
                        objPago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objPago.Concepto = txtNumeroDocumento.Text; //txtConcepto.Text;
                        objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);// 0;
                        objPago.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);//0;
                        objPago.FlagEstado = true;
                        objPago.Usuario = Parametros.strUsuarioLogin;
                        objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objPago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                        //Datos del Movimiento de Caja
                        List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                        MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                        objMovimientoCaja.IdMovimientoCaja = 0;
                        objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objMovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text;
                        objMovimientoCaja.IdFormaPago = Parametros.intContado;
                        objMovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objMovimientoCaja.TipoMovimiento = "S";
                        objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objMovimientoCaja.ImporteSoles = 0;//Convert.ToDecimal(txtImporteSoles.EditValue);
                        objMovimientoCaja.ImporteDolares = 0;// Convert.ToDecimal(txtImporteDolares.EditValue);
                        objMovimientoCaja.FlagEstado = true;
                        objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        lstMovimientoCaja.Add(objMovimientoCaja);

                    #region "Estado de cuenta"

                            //Estado Cuenta
                            //EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                            EstadoCuentaBE objE_EstadoCuenta = null;

                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                            {
                                objE_EstadoCuenta = new EstadoCuentaBE();
                                objE_EstadoCuenta.IdEstadoCuenta = 0;
                                objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuenta.IdCliente = Convert.ToInt32(IdCliente);
                                objE_EstadoCuenta.NumeroDocumento = "EG" + txtNumeroDocumento.Text.Trim();
                                objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                objE_EstadoCuenta.FechaDeposito = null;
                                objE_EstadoCuenta.Concepto = "DEV DE EFECTIVO" ;
                                objE_EstadoCuenta.FechaVencimiento = null;
                                objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteNCDolares.EditValue);

                                if (txtCodMonedaPedido.Text.Contains("S/"))
                                    objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporteNCDolares.EditValue) / Convert.ToDecimal(txtTipoCambio.Text);

                                objE_EstadoCuenta.ImporteAnt = 0;
                                objE_EstadoCuenta.TipoMovimiento = "C";
                                objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta; //Convert.ToInt32(cboMotivo.EditValue);
                                objE_EstadoCuenta.Observacion = "";
                                objE_EstadoCuenta.FlagEstado = true;
                                objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                                objE_EstadoCuenta.IdCotizacion = (int?)null;
                                objE_EstadoCuenta.IdPedido = (int?)IdPedido;

                                /*if (pOperacion == Operacion.Nuevo)
                                {
                                    objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                                    objE_EstadoCuenta.IdCotizacion = (int?)null;
                                }
                                else
                                {
                                    objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                    objE_EstadoCuenta.IdCotizacion = IdCotizacion;
                                }*/
                            }

                            //Separacion
                            SeparacionBE objE_Separacion = null;
                            if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)
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
                                objE_Separacion.Concepto = "DEV DE EFECTIVO";
                                objE_Separacion.FechaVencimiento = null;
                                objE_Separacion.Importe = Convert.ToDecimal(txtImporteNCSoles.EditValue);
                                objE_Separacion.ImporteAnt = 0;
                                objE_Separacion.TipoMovimiento = "C";
                                objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Convert.ToInt32(cboMotivo.EditValue);
                                objE_Separacion.IdDocumentoVenta = (int?)null;
                                objE_Separacion.IdPedido = IdPedido;
                                objE_Separacion.FlagEstado = true;
                                objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            }
                    #endregion

                        if (pOperacion == Operacion.Nuevo)
                        {
                            //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                            objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        }
                        else
                        {
                            //Datos del Movimiento de Caja
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue),Parametros.intTipoDocReciboPago, txtNumeroDocumento.Text.Trim());

                            objMovimientoCaja.IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;

                            //objBL_Pagos.Actualiza(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                            objBL_Pagos.Actualiza(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        }


                        ActualizaNotaCredito();
                    }

                    this.DialogResult = DialogResult.OK;
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

        private void txtImporteDolares_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtImporteDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteSoles.EditValue = ImporteSoles;
                btnGrabar.Focus();
            }
        }

        private void txtImporteSoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal ImporteDolares = 0;
                ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteDolares.EditValue = ImporteDolares;
                btnGrabar.Focus();
            }
        }

        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtImporteSoles.Focus();
            }
        }

        private void chkEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGrabar.Focus();
            }
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {

            if (IdDocumentoVenta > 0)
            {
                if (Parametros.strUsuarioLogin != "master")
                {
                    XtraMessageBox.Show("No se puede eliminar por esta opción, Este movimiento tiene documento vinculados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnGrabar.Enabled = false;
                    return;
                }
            }

            if (chkEstado.Checked == true)
            {
                lblEstado.Visible = false;
            }
            else
            {
                lblEstado.Visible = true;
            }
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


        private void cboTipoTarjeta_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoTarjeta.Visible == true)
            {
                if (cboTipoTarjeta.EditValue.ToString() == "C")
                    cboTipoTarjeta.BackColor = Color.LightCoral;
                else
                    cboTipoTarjeta.BackColor = Color.LightGreen;
            }

        }

        private void cboCondicionPago_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCondicionPago.EditValue) == 98)
            {
                cboTipoTarjeta.Visible = false;
                cboTipoTarjeta.EditValue = "";
            }
            else
            {
                cboTipoTarjeta.Visible = true;
                cboTipoTarjeta.EditValue = "D";
            }

            if (Convert.ToInt32(cboCondicionPago.EditValue) == 194 || Convert.ToInt32(cboCondicionPago.EditValue) == 298)
            {
                txtNumeroCheque.Visible = true;
                this.Size = new Size(622, 263);
            }
            else
            {
                txtNumeroCheque.Visible = false;
                this.Size = new Size(526, 263);
            }

        }

        private DataTable CargarTipoDocumentoMovimientoCaja()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 92;
            dr["Descripcion"] = "APC";
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["Id"] = 93;
            //dr["Descripcion"] = "RDC";
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["Id"] = 49;
            //dr["Descripcion"] = "RCP";
            //dt.Rows.Add(dr);
            return dt;
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

        private void txtNumeroNC_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresaOrigen.EditValue), Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text.Trim(), txtNumeroNC.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            //Verificar si la NC está usada
                            MovimientoCajaBE objE_MovimientoCaja = null;
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboDocumentoCR.EditValue), txtSerie.Text + "-" + objE_DocumentoVenta.Numero); //txtNumeroDocumento.Text);
                            if (objE_MovimientoCaja != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroNC.Text + " ya está usada, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //LimpiarPago();
                                return;
                            }

                            //Verificar Estado de cuenta
                            EstadoCuentaBE objE_EstadoCuenta = null;
                            objE_EstadoCuenta = new EstadoCuentaBL().SeleccionaDocumentoVenta(objE_DocumentoVenta.IdEmpresa,  objE_DocumentoVenta.IdDocumentoVenta);

                            if (objE_EstadoCuenta != null)
                            {
                                XtraMessageBox.Show("La nota de crédito " + txtSerie.Text + "-" + txtNumeroDocumento.Text + " ya existe en el estado de cuenta Mayorista, por lo tanto no se puede aplicar, por favor consultar con Créditos y Cobranzas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //LimpiarPago();
                                return;
                            }


                            //De aqui el documento
                            txtCodMonedaPedido.Text = objE_DocumentoVenta.CodMoneda;
                            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                            txtImporteNCDolares.EditValue = objE_DocumentoVenta.Total;
                            IdPedido = objE_DocumentoVenta.IdPedido;
                            IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                            IdCliente = objE_DocumentoVenta.IdCliente;
                            IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;

                            //txtNumeroDocumento.Text = objE_DocumentoVenta.Numero;
                            if (objE_DocumentoVenta.CodMoneda == "US$")
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total * Convert.ToDecimal(txtTipoCambio.Text);
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total;
                            }

                        }

                        else
                        {
                            XtraMessageBox.Show("No existe la nota de credito en: " + cboEmpresaOrigen.Text + ", debe ser genereado por \nel área de facturación antes de seguir su proceso, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //LimpiarPago();
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
                            objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboDocumentoCR.EditValue), objE_Cambio.Numero);
                            if (objE_MovimientoCaja != null)
                            {
                                XtraMessageBox.Show("La Solicitud de devolución " + txtNumeroDocumento.Text + ", ya está usada, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // LimpiarPago();
                                return;
                            }

                            //Documento Cambio
                            txtCodMonedaPedido.Text = objE_Cambio.CodMoneda;
                            txtDescCliente.Text = objE_Cambio.DescCliente;
                            txtImporteNCDolares.EditValue = objE_Cambio.Total;
                            txtNumeroDocumento.Text = objE_Cambio.Numero;
                            if (objE_Cambio.CodMoneda == "US$")
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total * Convert.ToDecimal(txtTipoCambio.Text);
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_Cambio.Total;
                            }
                        }

                        else
                        {
                            XtraMessageBox.Show("No existe la solicitud de devolución N°" + txtNumeroDocumento.Text + " para la empresa: " + cboEmpresaOrigen.Text + ", \npor favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //LimpiarPago();
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDevolucionPago_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDevolucionPago.Checked == true)
            {
                gcPago.Visible = true;
                this.Size = new Size(543, 387);
                cboDocumento.EditValue = 93;
            }
            else
            {
                gcPago.Visible = false;
                this.Size = new Size(543, 271);
            }

        }

        private void ter(object sender, EventArgs e)
        {

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
                if (pOperacion == Operacion.Nuevo)
                { 
                    strMensaje = strMensaje + "- Seleccione el documento.\n";
                    flag = true;
                }
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (cboFormaPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la forma de pago.\n";
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

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstMovimientoCaja.Where(oB => oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- El documento ya existe.\n";
                //    flag = true;
                //}
                var BuscarApertura = lstMovimientoCaja.Where(oB => oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue)).ToList();
                if (BuscarApertura.Count > 0)
                {
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocAperturaCaja)
                    {
                        strMensaje = strMensaje + "- La caja ya esta aperturada por favor verifique.\n";
                        flag = true;
                    }
                    
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void ActualizaNotaCredito()
        {
            PagosBL objBL_Pagos = new PagosBL();

            //Datos del Recibo de Pago
            PagosBE objPago = new PagosBE();
            objPago.IdPago = 0;
            objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
            objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);//Parametros.intCajaId;
            objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objPago.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
            string Numero = "";
            Numero = txtSerie.Text + "-" + txtNumeroNC.Text;
            objPago.NumeroDocumento = Numero;
            objPago.IdCondicionPago = Parametros.intEfectivo;
            objPago.Concepto = "APLICACION NOTA DE CREDITO";
            objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
            objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            objPago.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objPago.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            objPago.FlagEstado = true;
            objPago.Usuario = Parametros.strUsuarioLogin;
            objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objPago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

            //Datos del Movimiento de Caja
            List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

            MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
            objMovimientoCaja.IdMovimientoCaja = 0;
            objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);// Parametros.intCajaId; 
            objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumentoCR.EditValue);
            objMovimientoCaja.NumeroDocumento = txtSerie.Text + "-" + txtNumeroNC.Text;
            objMovimientoCaja.IdFormaPago = Parametros.intContado;
            objMovimientoCaja.IdCondicionPago = Parametros.intEfectivo;
            objMovimientoCaja.TipoMovimiento = "I";
            objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
            objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteNCSoles.EditValue);
            objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteNCSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
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


        #endregion

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    frmRegMovimientoCajaChicaEdit frm = new frmRegMovimientoCajaChicaEdit();
            //    frm.pOperacion = frmRegMovimientoCajaChicaEdit.Operacion.Nuevo;
            //    frm.IdMovimientoCajaChica = 0;
            //    frm.IdCaja = Convert.ToInt32(cboCaja.EditValue);
            //    frm.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            //    frm.StartPosition = FormStartPosition.CenterParent;
            //    frm.ShowDialog();
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();

            //    //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocRetiroCaja)
            //    //    btnGastos.Visible = true;
            //    //else
            //    //    btnGastos.Visible = false;
            //}
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            frmRegMovimientoCajaSalidaEdit objManMovimientoCaja = new frmRegMovimientoCajaSalidaEdit();
            objManMovimientoCaja.pOperacion = frmRegMovimientoCajaSalidaEdit.Operacion.Nuevo;
            objManMovimientoCaja.IdMovimientoCaja = 0;
            objManMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            objManMovimientoCaja.IdTienda = IdTienda;
            objManMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
            objManMovimientoCaja.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objManMovimientoCaja.StartPosition = FormStartPosition.CenterParent;
            objManMovimientoCaja.ShowDialog();
            this.Close();


            //frmRegMovimientoCajaChicaEdit frm = new frmRegMovimientoCajaChicaEdit();
            //frm.pOperacion = frmRegMovimientoCajaChicaEdit.Operacion.Nuevo;
            //frm.IdMovimientoCajaChica = 0;
            //frm.IdCaja = Convert.ToInt32(cboCaja.EditValue);
            //frm.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnRetiroCliente_Click(object sender, EventArgs e)
        {
            frmRegReciboEgresoEdit objManReciboEgreso = new frmRegReciboEgresoEdit();
            objManReciboEgreso.lstPago = new PagosBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue), Convert.ToDateTime(deFecha.EditValue), Parametros.intTipoDocReciboEgreso);
            objManReciboEgreso.pOperacion = frmRegReciboEgresoEdit.Operacion.Nuevo;
            objManReciboEgreso.IdPago = 0;
            objManReciboEgreso.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objManReciboEgreso.StartPosition = FormStartPosition.CenterParent;
            objManReciboEgreso.ShowDialog();
            this.Close();

        }
    }
}