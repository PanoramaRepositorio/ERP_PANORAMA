using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegCotizacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CotizacionBE> lstCotizacion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdCotizacion = 0;

        public int IdCotizacion
        {
            get { return _IdCotizacion; }
            set { _IdCotizacion = value; }
        }

        int IdPedido = 0;
        int IdCliente = 0;
        int IdTipoCliente = 0;
        int IdMoneda = 0;
        int IdFormaPago = 0;
        int IdClasificacionClientePed;

        #endregion

        #region "Eventos"

        public frmRegCotizacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegCotizacionEdit_Load(object sender, EventArgs e)
        {
            deFechaCredito.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);

            tmrNumero.Enabled = true;
            tmrNumero.Interval = 1000;
            ObtenerCorrelativo();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cotización - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cotización - Modificar";

                CotizacionBE objE_Cotizacion = new CotizacionBE();
                objE_Cotizacion = new CotizacionBL().Selecciona(Parametros.intEmpresaId, IdCotizacion);

                IdPedido = objE_Cotizacion.IdPedido;
                txtNumeroPedido.Text = objE_Cotizacion.NumeroPedido;
                txtDescFormaPago.Text = objE_Cotizacion.DescFormaPago;
                IdMoneda = objE_Cotizacion.IdMoneda;
                txtCodMoneda.Text = objE_Cotizacion.CodMoneda;
                txtImporte.EditValue = objE_Cotizacion.Total;
                IdCliente = objE_Cotizacion.IdCliente;
                txtDescCliente.Text = objE_Cotizacion.DescCliente;
                txtNumero.Text = objE_Cotizacion.NumeroCotizacion;
                txtConcepto.Text = objE_Cotizacion.Descripcion;
                deFechaCredito.EditValue = objE_Cotizacion.FechaCredito;
                deFechaVencimiento.EditValue = objE_Cotizacion.FechaVencimiento;
                cboMotivo.EditValue = objE_Cotizacion.IdMotivo;

            }

        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text);
                if (objE_Pedido != null)
                {
                    if (objE_Pedido.IdSituacion == Parametros.intFacturado || objE_Pedido.IdSituacion == Parametros.intPVDespachado || objE_Pedido.IdFormaPago == Parametros.intSeparacion )
                    {
                        IdPedido = objE_Pedido.IdPedido;
                        IdFormaPago = objE_Pedido.IdFormaPago;
                        txtDescFormaPago.Text = objE_Pedido.DescFormaPago;
                        IdMoneda = objE_Pedido.IdMoneda;
                        txtCodMoneda.Text = objE_Pedido.CodMoneda;
                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                        txtImporte.EditValue = objE_Pedido.Total;
                        IdCliente = objE_Pedido.IdCliente;
                        IdTipoCliente = objE_Pedido.IdTipoCliente;
                        txtDescCliente.Text = objE_Pedido.DescCliente;
                        txtConcepto.Text = objE_Pedido.DescFormaPago + " N° " + objE_Pedido.Numero;
                        IdClasificacionClientePed = objE_Pedido.IdClasificacionCliente;
                        cboMotivo.EditValue = objE_Pedido.IdMotivo;

                        if (objE_Pedido.IdFormaPago == Parametros.intCredito)
                        {
                            int NumDias = 0;

                            ClienteCreditoBE objClienteCredito = null;
                            objClienteCredito = new ClienteCreditoBL().SeleccionaCliente(objE_Pedido.IdEmpresa, objE_Pedido.IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                            if (objClienteCredito != null)
                            {
                                NumDias = objClienteCredito.NumeroDias;
                            }
                            deFechaVencimiento.EditValue = deFechaCredito.DateTime.AddDays(NumDias);
                        }
                        else
                        {
                            deFechaVencimiento.EditValue = DateTime.Now;
                        }
                        btnGrabar.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede generar la cotización, porque el número de pedido no se encuentra facturado ni despachado...por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("El número de pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CotizacionBL objBL_Cotizacion = new CotizacionBL();
                    CotizacionBE objE_Cotizacion = new CotizacionBE();

                    objE_Cotizacion.IdCotizacion = IdCotizacion;
                    objE_Cotizacion.IdEmpresa = Parametros.intEmpresaId;
                    objE_Cotizacion.Periodo = Parametros.intPeriodo;
                    objE_Cotizacion.IdPedido = IdPedido;
                    objE_Cotizacion.IdCliente = IdCliente;
                    objE_Cotizacion.NumeroCotizacion = txtNumero.Text;
                    objE_Cotizacion.FechaCredito = Convert.ToDateTime(deFechaCredito.DateTime.ToShortDateString());
                    objE_Cotizacion.IdMoneda = IdMoneda;
                    objE_Cotizacion.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_Cotizacion.Total = Convert.ToDecimal(txtImporte.EditValue);
                    objE_Cotizacion.Descripcion = txtConcepto.Text;
                    objE_Cotizacion.FechaCredito = Convert.ToDateTime(deFechaCredito.DateTime.ToShortDateString());
                    objE_Cotizacion.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objE_Cotizacion.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objE_Cotizacion.FlagEstado = true;
                    objE_Cotizacion.Usuario = Parametros.strUsuarioLogin;
                    objE_Cotizacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    EstadoCuentaBE objE_EstadoCuenta = null;
                    SeparacionBE objE_Separacion = null;

                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionClientePed == Parametros.intBlack)
                    {
                        if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan)
                        {
                            //Datos del estado de cuenta
                            objE_EstadoCuenta = new EstadoCuentaBE();

                            objE_EstadoCuenta.IdEstadoCuenta = 0;
                            objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                            objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                            objE_EstadoCuenta.IdCliente = IdCliente;
                            objE_EstadoCuenta.NumeroDocumento = txtNumero.Text;
                            objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFechaCredito.DateTime.ToShortDateString());
                            objE_EstadoCuenta.FechaDeposito = null;
                            objE_EstadoCuenta.Concepto = txtConcepto.Text;
                            objE_EstadoCuenta.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                            objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporte.EditValue);
                            objE_EstadoCuenta.ImporteAnt = Convert.ToDecimal(txtImporte.EditValue);
                            objE_EstadoCuenta.TipoMovimiento = "C";
                            objE_EstadoCuenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                            objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                            objE_EstadoCuenta.FlagEstado = true;
                            objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                            objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        }
                    }

                    if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionClientePed != Parametros.intBlack)
                    {
                        if (IdFormaPago == Parametros.intSeparacion || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan)
                        {
                            //Datos de la separación
                            objE_Separacion = new SeparacionBE();

                            objE_Separacion.IdSeparacion = 0;
                            objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                            objE_Separacion.Periodo = Parametros.intPeriodo;
                            objE_Separacion.IdCliente = IdCliente;
                            objE_Separacion.NumeroDocumento = txtNumero.Text;
                            objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFechaCredito.DateTime.ToShortDateString());
                            objE_Separacion.FechaPago = null;
                            objE_Separacion.Concepto = txtConcepto.Text;
                            objE_Separacion.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                            objE_Separacion.Importe = Convert.ToDecimal(txtImporte.EditValue);
                            objE_Separacion.ImporteAnt = Convert.ToDecimal(txtImporte.EditValue);
                            objE_Separacion.TipoMovimiento = "C";
                            objE_Separacion.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                            objE_Separacion.IdDocumentoVenta = (int?)null;
                            objE_Separacion.FlagEstado = true;
                            objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                            objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cotizacion.Inserta(objE_Cotizacion, objE_EstadoCuenta, objE_Separacion);
                    else
                        objBL_Cotizacion.Actualiza(objE_Cotizacion);

                    if (objE_EstadoCuenta != null)
                    {
                        XtraMessageBox.Show("Se registro en Estado de Cuenta en Dolares(US$)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (objE_Separacion != null)
                    {
                        XtraMessageBox.Show("Se registro en Estado de Cuenta en Soles(S/)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tmrNumero_Tick(object sender, EventArgs e)
        {
            //Obtener el correlativo del documento
            if (pOperacion == Operacion.Nuevo)
                ObtenerCorrelativo();
        }
        
        #endregion

        #region "Metodos"

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocCotizacionCredito, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }

                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdPedido == 0)
            {
                strMensaje = strMensaje + "- Debe ingresar un número de pedido.\n";
                flag = true;
            }

            if (IdFormaPago == Parametros.intCredito && IdMoneda == Parametros.intSoles)
            {
                strMensaje = strMensaje + "- No se puede generar un estado de cuenta en soles.\n";
                flag = true;
            }

            //if (IdFormaPago == Parametros.intContraEntrega && IdMoneda == Parametros.intSoles)
            //{
            //    strMensaje = strMensaje + "- No se puede generar un estado de cuenta en soles.\n";
            //    flag = true;
            //}

            if (IdFormaPago == Parametros.intSeparacion && IdTipoCliente == Parametros.intTipClienteMayorista)
            {
                strMensaje = strMensaje + "- No se puede generar una separación a un cliente mayorista.\n";
                flag = true;
            }

            
            if (deFechaCredito.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Crédito.\n";
                flag = true;
            }

            if (deFechaVencimiento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Vencimiento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                lstCotizacion = new CotizacionBL().ListaPedido(Parametros.intPeriodo, txtNumeroPedido.Text);
                if (lstCotizacion.Count > 0)
                {
                    strMensaje = strMensaje + "- Ya existe una cotización asociado al número de pedido.\n";
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