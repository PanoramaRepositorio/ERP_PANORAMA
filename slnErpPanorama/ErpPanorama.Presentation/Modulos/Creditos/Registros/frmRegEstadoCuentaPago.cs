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
    public partial class frmRegEstadoCuentaPago : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<EstadoCuentaBE> lstEstadoCuenta;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdCliente { get; set; }
        public string Numero { get; set; }
        public string DescCliente { get; set; }
        public string TipoCliente { get; set; }
        public int IdMotivo { get; set; }
        public int Periodo { get; set; }

        int _IdEstadoCuenta = 0;

        public int IdEstadoCuenta
        {
            get { return _IdEstadoCuenta; }
            set { _IdEstadoCuenta = value; }
        }

        decimal decImporteAnt = 0;
        int? IdDocumentoVenta = 0;
        int? IdCotizacion = 0;
        int? IdPedido = 0;

        #endregion

        #region "Eventos"

        public String cadena = "";

        public frmRegEstadoCuentaPago()
        {
            InitializeComponent();
        }

        private void frmRegEstadoCuentaPago_Load(object sender, EventArgs e)
        {
            deFechaCredito.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);

            txtNumero.Text = Numero;
            txtDescCliente.Text = DescCliente;
            txtTipoCliente.Text = TipoCliente;
            cboMotivo.EditValue = IdMotivo;

            //Traemos el estado de cuenta del cliente
            lstEstadoCuenta = new EstadoCuentaBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente, IdMotivo);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Estado de Cuenta - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Estado de Cuenta - Modificar";

                EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                objE_EstadoCuenta = new EstadoCuentaBL().Selecciona(Parametros.intEmpresaId, IdEstadoCuenta);

                cboMotivo.EditValue = objE_EstadoCuenta.IdMotivo;
                txtNumeroDocumento.Text = objE_EstadoCuenta.NumeroDocumento;
                deFechaCredito.EditValue = objE_EstadoCuenta.FechaCredito;
                deFechaDeposito.EditValue = objE_EstadoCuenta.FechaDeposito;
                txtConcepto.Text = objE_EstadoCuenta.Concepto;
                deFechaVencimiento.EditValue = objE_EstadoCuenta.FechaVencimiento;
                txtImporte.EditValue = objE_EstadoCuenta.Importe;
                decImporteAnt = objE_EstadoCuenta.ImporteAnt;
                IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                txtObservacion.Text = objE_EstadoCuenta.Observacion;
                //personalizado
                Size size = new Size();
                size.Height = 20;
                size.Width = 620;
                txtConcepto.Size = size;
                txtNumeroPedido.Visible = false;
                labelControl6.Visible = false;
                txtNumeroDocumento.Properties.ReadOnly = true;
            }

            CargarPedido();
            cboPedido.EditValue = null;
            txtNumeroDocumento.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                    EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();

                    objE_EstadoCuenta.IdEstadoCuenta = IdEstadoCuenta;
                    objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                    objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                    objE_EstadoCuenta.IdCliente = IdCliente;
                    objE_EstadoCuenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFechaCredito.DateTime.ToShortDateString());
                    if (deFechaDeposito.Text == "")
                        objE_EstadoCuenta.FechaDeposito = null;
                    else
                        objE_EstadoCuenta.FechaDeposito = Convert.ToDateTime(deFechaDeposito.DateTime.ToShortDateString());

                    //if (txtNumeroPedido.Text == "")
                    //    objE_EstadoCuenta.Concepto = txtConcepto.Text.Trim();
                    //else
                    //    objE_EstadoCuenta.Concepto = txtConcepto.Text.Trim() + " N° " + txtNumeroPedido.Text.Trim();

                    if (cboPedido.Text == "")
                        objE_EstadoCuenta.Concepto = txtConcepto.Text.Trim();
                    else
                        objE_EstadoCuenta.Concepto = txtConcepto.Text.Trim() + " N° " + txtNumeroPedido.Text.Trim();


                    if (deFechaVencimiento.Text == "")
                        objE_EstadoCuenta.FechaVencimiento = null;
                    else
                        objE_EstadoCuenta.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objE_EstadoCuenta.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objE_EstadoCuenta.ImporteAnt = decImporteAnt;
                    objE_EstadoCuenta.TipoMovimiento = "A";
                    objE_EstadoCuenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                    objE_EstadoCuenta.Observacion = txtObservacion.Text;
                    objE_EstadoCuenta.FlagEstado = true;
                    objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                    objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                        objE_EstadoCuenta.IdCotizacion = (int?)null;
                        objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);
                    }
                    else
                    {
                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                        objE_EstadoCuenta.IdCotizacion = IdCotizacion;
                        objBL_EstadoCuenta.Actualiza(objE_EstadoCuenta);
                    }

                    #region "auditoria Eliminacion"

                    EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                    objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                    objE_EstadoCuentaHistorial.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                    objE_EstadoCuentaHistorial.Periodo = objE_EstadoCuenta.Periodo;
                    objE_EstadoCuentaHistorial.IdCliente = objE_EstadoCuenta.IdCliente;
                    objE_EstadoCuentaHistorial.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                    objE_EstadoCuentaHistorial.FechaCredito = objE_EstadoCuenta.FechaCredito;
                    objE_EstadoCuentaHistorial.FechaDeposito = objE_EstadoCuenta.FechaDeposito;
                    objE_EstadoCuentaHistorial.Concepto = objE_EstadoCuenta.Concepto;
                    objE_EstadoCuentaHistorial.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                    objE_EstadoCuentaHistorial.Importe = objE_EstadoCuenta.Importe;
                    objE_EstadoCuentaHistorial.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                    objE_EstadoCuentaHistorial.IdMotivo = objE_EstadoCuenta.IdMotivo;
                    objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                    objE_EstadoCuentaHistorial.IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                    objE_EstadoCuentaHistorial.IdPedido = objE_EstadoCuenta.IdPedido;
                    objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                    objE_EstadoCuentaHistorial.Observacion = objE_EstadoCuenta.Observacion;
                    objE_EstadoCuentaHistorial.ObservacionElimina = "Por: " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. DOLARES";
                    objE_EstadoCuentaHistorial.TipoRegistro = "A";
                    objE_EstadoCuentaHistorial.FlagEstado = objE_EstadoCuenta.FlagEstado;
                    objE_EstadoCuentaHistorial.Usuario = Parametros.strUsuarioLogin;
                    objE_EstadoCuentaHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                    objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaHistorial);
                    #endregion


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

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaCredito.Focus();
            }
        }

        private void optCreditoCargo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void optPagoAbono_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void deFechaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaDeposito.Focus();
            }
        }

        private void deFechaDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtConcepto.Focus();
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
                //SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        //Traemos la información del Pedido
            //        PedidoBE objE_Pedido = null;
            //        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text.Trim());
            //        if (objE_Pedido != null)
            //        {
            //            //IdCliente = objE_Pedido.IdCliente;
            //            //IdPedido = objE_Pedido.IdPedido;
            //            //txtNumeroPedido.Text = objE_Pedido.Numero;
            //            //cboMoneda.EditValue = objE_Pedido.IdMoneda;
            //            //txtCodMonedaPedido.Text = objE_Pedido.CodMoneda;
            //            //txtTotal.EditValue = objE_Pedido.Total;
            //            //txtDescCliente.Text = objE_Pedido.DescCliente;
            //            //txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
            //            //cboMotivo.EditValue = objE_Pedido.IdMotivo;
            //            //IdTipoCliente = objE_Pedido.IdTipoCliente;
            //            //IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
            //            //FormaPagoPedido = objE_Pedido.DescFormaPago;
            //            //txtFormaPago.EditValue = objE_Pedido.DescFormaPago;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese N° Documento.\n";
                flag = true;
            }

            if (deFechaCredito.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Crédito.\n";
                flag = true;
            }

            if (txtConcepto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el concepto.\n";
                flag = true;
            }

            if (txtImporte.Text.Trim().ToString() == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el importe.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                string Concepto = "";
                if (txtNumeroPedido.Text == "")
                    Concepto = txtConcepto.Text.Trim();
                else
                    Concepto = txtConcepto.Text.Trim() + " N° " + txtNumeroPedido.Text.Trim();
                var Buscar = lstEstadoCuenta.Where(oB => oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Número de documento ya existe.\n";
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

        private void CargarPedido()
        {
            //BSUtils.LoaderLook(cboPedido, new PedidoBL().ListaFechaCliente(Convert.ToDateTime("01/01/" + Parametros.intPeriodo), DateTime.Now, IdCliente), "Numero", "IdPedido", true);
            BSUtils.LoaderLook(cboPedido, new PedidoBL().ListaClientePorCobrar(IdCliente), "Numero", "IdPedido", true);
        }

        #endregion

        private void cboPedido_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPedido.Text != "")
            {
                PedidoBE obj_PedidoBE = null;
                obj_PedidoBE = new PedidoBL().Selecciona(Convert.ToInt32(cboPedido.EditValue));
                cboMotivo.EditValue = obj_PedidoBE.IdMotivo;

                if (obj_PedidoBE.IdFormaPago == Parametros.intContraEntrega)
                {
                    cadena = cadena +   " CE " + this.cboPedido.Text  + " / " ;
                }
                else if (obj_PedidoBE.IdFormaPago == Parametros.intCredito)
                {
                    cadena = cadena + " CR " + this.cboPedido.Text + " / " ;
                }
                else
                {
                   // txtConcepto.Text = "PAGO";
                }
            }
            else {
                cadena = "PAGO ";
            }
            this.txtConcepto.Text =cadena;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboPedido.EditValue = null;
        }

    }
}