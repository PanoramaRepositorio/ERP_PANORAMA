using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using System.Security.Principal;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmMsgPagoCondicionManual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public String NumeroPedido = "";
        //public decimal Total = 0;
        public int PagoIdPedido = 0;
        private int IdPedido = 0;
        public int IdDocumentoNC = 0;
        public string NumeroDocumento = "";

        public int IdTipoDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Visa { get; set; }
        public decimal MasterCard { get; set; }
        public string NumeroNotaCredito { get; set; }
        public decimal Total { get; set; }
        public string VisaTipoTarjeta { get; set; }
        public string MasterTipoTarjeta { get; set; }
        public int IdEmpresaOrigen { get; set; }
        public int IdTipoMaster { get; set; }

        public decimal VisaPuntosVida { get; set; }
        public decimal MasterCardPuntosVida { get; set; }

        public string NumeroManual { get; set; }
        public string SerieManual { get; set; }

        #endregion

        #region "Eventos"

        public frmMsgPagoCondicionManual()
        {
            InitializeComponent();
        }

        private void frmMsgPagoCondicionManual_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            //BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
            //cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboEmpresaOrigen, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresaOrigen.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboMonedaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMonedaPago.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", true);
            cboDocumento.EditValue = Parametros.intTipoDocBoletaVenta;
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
            txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
        }

        private void txtVisa_EditValueChanged(object sender, EventArgs e)
        {
            txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
        }

        private void txtMastercard_EditValueChanged(object sender, EventArgs e)
        {
            txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
        }

        private void txtImporteNCSoles_EditValueChanged(object sender, EventArgs e)
        {
            txtResta.EditValue = Math.Round(Convert.ToDecimal(txtTotalResumen.EditValue) - (Convert.ToDecimal(txtEfectivo.EditValue) + Convert.ToDecimal(txtVisa.EditValue) + Convert.ToDecimal(txtMastercard.EditValue) + Convert.ToDecimal(txtImporteNCSoles.EditValue)), 2);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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

            //Numeracion documento
            if (txtSerieManual.Text.Trim() =="" || txtNumeroManual.Text.Trim() =="")
            {
                XtraMessageBox.Show("Ingresar Serie y Número del documento a generar, incluyendo los ceros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerieManual.Select();
                txtSerieManual.SelectAll();
                return;
            }

            //Mayor a 700
            int TipoDocFac = 0;
            TipoDocFac = Convert.ToInt32(cboDocumento.EditValue);
            if (TipoDocFac == Parametros.intTipoDocBoletaVenta || TipoDocFac == Parametros.intTipoDocFacturaVenta || TipoDocFac == Parametros.intTipoDocTicketBoleta || TipoDocFac == Parametros.intTipoDocTicketFactura)
            {
                if (NumeroDocumento == Parametros.strNumeroCliente && Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intSoles && Convert.ToDecimal(txtTotalResumen.EditValue) >= 700 || NumeroDocumento == Parametros.strNumeroCliente && Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intDolares && Convert.ToDecimal(txtTotalResumen.EditValue) * Convert.ToDecimal(txtTC.EditValue) >= 700)
                {
                    XtraMessageBox.Show("No se puede imprimir un comprobante como " + Parametros.intIdClienteGeneral + ", el importe es mayor a S/700\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
            IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            Fecha = deFecha.DateTime;
            Efectivo = Convert.ToDecimal(txtEfectivo.EditValue);
            Visa = Convert.ToDecimal(txtVisa.EditValue);
            MasterCard = Convert.ToDecimal(txtMastercard.EditValue);
            VisaTipoTarjeta = cboTipoVisa.EditValue.ToString();
            MasterTipoTarjeta = cboTipoMasterCard.EditValue.ToString();
            VisaPuntosVida = 0;
            MasterCardPuntosVida = 0;
            SerieManual = txtSerieManual.Text.Trim();
            NumeroManual = txtNumeroManual.Text.Trim();
            IdTipoMaster = Convert.ToInt32(cboTipoMaster.EditValue);

            //IdEmpresaOrigen = Convert.ToInt32(cboEmpresaOrigen.EditValue);

            if (Convert.ToDecimal(txtImporteNCSoles.EditValue) > 0)
            {
                if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito)
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

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboDocumentoCR_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito)
            {
                txtSerie.Enabled = true;
                txtSerie.Select();
            }
            else
            {
                txtSerie.Enabled = false;
                txtNumeroDocumento.Focus();
            }

            if (Parametros.dtFechaHoraServidor == Convert.ToDateTime("08/11/2014") && Parametros.intTiendaId == Parametros.intTiendaPrescott)
            {
                if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocValeDescuento)
                {
                    txtImporteNCSoles.EditValue = 50;
                    txtNumeroDocumento.Text = "VALE";
                    txtEfectivo.Focus();
                }
            }


        }

        private void LimpiarPago()
        {
            txtImporteNCSoles.EditValue = 0;
            txtImporteNCDolares.EditValue = 0;
            txtDescCliente.Text = "";
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
                    if (Convert.ToInt32(cboDocumentoCR.EditValue) == Parametros.intTipoDocNotaCredito)
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

                            //De aqui el documento
                            IdDocumentoNC = objE_DocumentoVenta.IdDocumentoVenta;
                            txtCodMonedaPedido.Text = objE_DocumentoVenta.CodMoneda;
                            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                            txtImporteNCDolares.EditValue = objE_DocumentoVenta.Total;
                            txtNumeroDocumento.Text = objE_DocumentoVenta.Numero;
                            if (objE_DocumentoVenta.IdMoneda == Parametros.intSoles)
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total;
                                txtEfectivo.Focus();
                            }
                            else
                            {
                                txtImporteNCSoles.EditValue = objE_DocumentoVenta.Total * Convert.ToDecimal(txtTC.Text);
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

        #endregion

        #region "Metodos"

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
            //dr = dt.NewRow();
            //dr["Id"] = 90;
            //dr["Descripcion"] = "TKV";
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["Id"] = 91;
            //dr["Descripcion"] = "TKF";
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
            objPago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

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

        private void frmMsgPagoCondicionManual_Shown(object sender, EventArgs e)
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


    }
}