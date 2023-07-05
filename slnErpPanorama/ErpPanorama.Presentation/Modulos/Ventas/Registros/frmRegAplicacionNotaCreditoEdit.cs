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

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegAplicacionNotaCreditoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PagosBE> lstPago;

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

        private int IdPedido = 0;
        
        #endregion

        #region "Eventos"

        public frmRegAplicacionNotaCreditoEdit()
        {
            InitializeComponent();
        }

        private void frmRegAplicacionNotaCreditoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
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
                BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
                cboEmpresa.EditValue = Parametros.intEmpresaId;
                BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescCaja", "IdCaja", true);
                cboCaja.EditValue = Parametros.intCajaId;
                BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaDevolucion(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
                cboDocumento.EditValue = Parametros.intTipoDocNotaCredito;
                BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
                cboCondicionPago.EditValue = Parametros.intEfectivo;
                txtTipoCambio.EditValue = objE_TipoCambio.Compra;
                BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                cboMoneda.EditValue = Parametros.intSoles;

                if (pOperacion == Operacion.Nuevo)
                {
                    this.Text = "Aplicación de Nota de Crédito - Nuevo";
                }
                else if (pOperacion == Operacion.Modificar)
                {
                    this.Text = "Aplicación de Nota de Crédito- Modificar";

                    PagosBE objE_Pago = null;
                    objE_Pago = new PagosBL().Selecciona(Parametros.intEmpresaId, IdPago);

                    IdPago = objE_Pago.IdPago;
                    IdPedido = objE_Pago.IdPedido == null ? 0 : IdPedido;

                    cboEmpresa.EditValue = objE_Pago.IdEmpresa;
                    txtCodMonedaPedido.Text = objE_Pago.CodMonedaPedido;
                    txtTotal.EditValue = objE_Pago.Total;
                    txtDescCliente.Text = objE_Pago.DescCliente;
                    cboCaja.EditValue = objE_Pago.IdCaja;
                    deFecha.EditValue = objE_Pago.Fecha;
                    cboDocumento.EditValue = objE_Pago.IdTipoDocumento;

                    if (objE_Pago.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                    {
                        txtSerie.Text = objE_Pago.NumeroDocumento.Substring(0, 3);
                        txtNumeroDocumento.Text = objE_Pago.NumeroDocumento.Substring(5,5);
                    }
                    else
                    {
                        txtNumeroDocumento.Text = objE_Pago.NumeroDocumento;
                    }

                    cboCondicionPago.EditValue = objE_Pago.IdCondicionPago;
                    txtConcepto.Text = objE_Pago.Concepto;
                    cboMoneda.EditValue = objE_Pago.IdMoneda;
                    txtTipoCambio.EditValue = objE_Pago.TipoCambio;
                    txtImporteSoles.EditValue = objE_Pago.ImporteSoles;
                    txtImporteDolares.EditValue = objE_Pago.ImporteDolares;
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

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumeroDocumento.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            txtCodMonedaPedido.Text = objE_DocumentoVenta.CodMoneda;
                            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                            txtTotal.EditValue = objE_DocumentoVenta.Total;
                            txtNumeroDocumento.Text = objE_DocumentoVenta.Numero;
                            cboMoneda.EditValue = objE_DocumentoVenta.CodMoneda;
                            if (objE_DocumentoVenta.IdMoneda == Parametros.intSoles)
                            {
                                txtImporteSoles.EditValue = objE_DocumentoVenta.Total;
                                txtImporteSoles.Focus();
                            }
                            else
                            {
                                txtImporteDolares.EditValue = objE_DocumentoVenta.Total;
                                txtImporteDolares.Focus();
                            }

                        }

                        else
                        {
                            XtraMessageBox.Show("No existe la nota de credito, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //Cuando es solicitud de devolucion
                        CambioBE objE_Cambio = null;
                        objE_Cambio = new CambioBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intPeriodo, txtNumeroDocumento.Text.Trim());
                        if (objE_Cambio != null)
                        {
                            txtCodMonedaPedido.Text = objE_Cambio.CodMoneda;
                            txtDescCliente.Text = objE_Cambio.DescCliente;
                            txtTotal.EditValue = objE_Cambio.Total;
                            txtNumeroDocumento.Text = objE_Cambio.Numero;
                            cboMoneda.EditValue = objE_Cambio.CodMoneda;
                            if (objE_Cambio.CodMoneda == "US$")
                            {
                                txtImporteDolares.EditValue = objE_Cambio.Total;
                                txtImporteDolares.Focus();
                            }
                            else
                            {
                                txtImporteSoles.EditValue = objE_Cambio.Total;
                                txtImporteSoles.Focus();
                            }
                        }

                        else
                        {
                            XtraMessageBox.Show("No existe la solicitud de devolución, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    string Numero = "";
                    Numero = txtSerie.Text + "-" + txtNumeroDocumento.Text;
                    objPago.NumeroDocumento = Numero;
                    objPago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objPago.Concepto = txtConcepto.Text;
                    objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                    objPago.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
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
                    objMovimientoCaja.NumeroDocumento = txtSerie.Text +"-"+ txtNumeroDocumento.Text;
                    objMovimientoCaja.IdFormaPago = Parametros.intContado;
                    objMovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objMovimientoCaja.TipoMovimiento = "I";
                    objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                    objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                    objMovimientoCaja.FlagEstado = true;
                    objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    lstMovimientoCaja.Add(objMovimientoCaja);

                    //Estado Cuenta
                    EstadoCuentaBE objE_EstadoCuenta = null;
                    SeparacionBE objE_Separacion = null;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //objBL_Pagos.Inserta(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                        objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                    }
                    else
                    {
                        //Datos del Movimiento de Caja
                        MovimientoCajaBE objE_MovimientoCaja = null;
                        objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTipoDocReciboPago, txtNumeroDocumento.Text.Trim());

                        objMovimientoCaja.IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;

                        //objBL_Pagos.Actualiza(objPago, objMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
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
                strMensaje = strMensaje + "- Ingrese el concepto del recibo de pago.\n";
                flag = true;
            }

            if (txtCodMonedaPedido.Text == "S/")
            {
                if (Math.Round(Convert.ToDecimal(txtImporteSoles.EditValue),2) < Math.Round(Convert.ToDecimal(txtTotal.EditValue),2))
                {
                    strMensaje = strMensaje + "- El importe soles no puede ser menor al total de la nota de crédito o solicitud de devolución.\n";
                    flag = true;
                }
            }
            else
            {
                if (Convert.ToDecimal(txtImporteDolares.EditValue) < Convert.ToDecimal(txtTotal.EditValue))
                {
                    strMensaje = strMensaje + "- El importe dólares no puede ser menor al total de la nota de crédito o solicitud de devolución.\n";
                    flag = true;
                }
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPago.Where(oB => oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El documento ya existe.\n";
                    flag = true;
                }

                string Numero = "";
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)
                    Numero = txtSerie.Text + "-" + txtNumeroDocumento.Text;
                else
                    Numero = txtNumeroDocumento.Text;

                PagosBE objE_Pago = null;
                objE_Pago = new PagosBL().SeleccionaNotaCredito(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Numero);
                if (objE_Pago != null)
                {
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)
                        strMensaje = strMensaje + "- El nota de credito ya fué aplicada.\n";
                    else
                        strMensaje = strMensaje + "- La solicitud de devolución ya fué aplicada.\n";
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

        #endregion

       
    }
}