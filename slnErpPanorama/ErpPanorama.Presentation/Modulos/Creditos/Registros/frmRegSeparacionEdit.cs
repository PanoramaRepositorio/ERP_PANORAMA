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
    public partial class frmRegSeparacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

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

        int _IdSeparacion = 0;
        string _strTipoMovimiento = "";

        public string strTipoMovimiento
        {
            get { return _strTipoMovimiento; }
            set { _strTipoMovimiento = value; }
        }

        public int IdSeparacion
        {
            get { return _IdSeparacion; }
            set { _IdSeparacion = value; }
        }

        decimal decImporteAnt = 0;
        int? IdDocumentoVenta = 0;
        int? IdCotizacion = 0;

        #endregion

        #region "Eventos"

        public frmRegSeparacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegSeparacionEdit_Load(object sender, EventArgs e)
        {
            deFechaSeparacion.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);

            txtNumero.Text = Numero;
            txtDescCliente.Text = DescCliente;
            txtTipoCliente.Text = TipoCliente;

            if (strTipoMovimiento == "C")
                optCreditoCargo.Checked = true;
            else
                optPagoAbono.Checked = true;


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Separación - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Separación - Modificar";

                SeparacionBE objE_Separacion = new SeparacionBE();
                objE_Separacion = new SeparacionBL().Selecciona(Parametros.intEmpresaId, IdSeparacion);

                cboMotivo.EditValue = objE_Separacion.IdMotivo;
                txtNumeroDocumento.Text = objE_Separacion.NumeroDocumento;
                if (objE_Separacion.TipoMovimiento == "C")
                    optCreditoCargo.Checked = true;
                else
                    optPagoAbono.Checked = true;
                deFechaSeparacion.EditValue = objE_Separacion.FechaSeparacion;
                deFechaPago.EditValue = objE_Separacion.FechaPago;
                txtConcepto.Text = objE_Separacion.Concepto;
                deFechaVencimiento.EditValue = objE_Separacion.FechaVencimiento;
                txtImporte.EditValue = objE_Separacion.Importe;
                decImporteAnt = objE_Separacion.ImporteAnt;
                IdDocumentoVenta = objE_Separacion.IdDocumentoVenta;
                IdCotizacion= objE_Separacion.IdCotizacion;

                //personalizado
                Size size = new Size();
                size.Height = 20;
                size.Width = 620;
                txtConcepto.Size = size;
                txtNumeroPedido.Visible = false;
                labelControl6.Visible = false;
                txtNumeroDocumento.Properties.ReadOnly = true;

                if (objE_Separacion.IdMovimientoCaja != null)
                {
                    txtImporte.Properties.ReadOnly = true;
                }

            }

            txtNumeroDocumento.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SeparacionBL objBL_Separacion = new SeparacionBL();
                    SeparacionBE objE_Separacion = new SeparacionBE();

                    objE_Separacion.IdSeparacion = IdSeparacion;
                    objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                    objE_Separacion.Periodo = Parametros.intPeriodo;
                    objE_Separacion.IdCliente = IdCliente;
                    objE_Separacion.NumeroDocumento = txtNumeroDocumento.Text;
                    objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFechaSeparacion.DateTime.ToShortDateString());
                    if (deFechaPago.Text == "")
                        objE_Separacion.FechaPago = null;
                    else
                        objE_Separacion.FechaPago = Convert.ToDateTime(deFechaPago.DateTime.ToShortDateString());

                    if (txtNumeroPedido.Text == "")
                        objE_Separacion.Concepto = txtConcepto.Text.Trim();
                    else
                        objE_Separacion.Concepto = txtConcepto.Text.Trim() + " N° " + txtNumeroPedido.Text.Trim();


                    if (deFechaVencimiento.Text == "")
                        objE_Separacion.FechaVencimiento = null;
                    else
                        objE_Separacion.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objE_Separacion.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objE_Separacion.ImporteAnt = decImporteAnt;
                    if (optCreditoCargo.Checked)
                        objE_Separacion.TipoMovimiento = "C";
                    else
                        objE_Separacion.TipoMovimiento = "A";
                    objE_Separacion.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                    objE_Separacion.FlagEstado = true;
                    objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                    objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objE_Separacion.IdDocumentoVenta = (int?)null;
                        objE_Separacion.IdCotizacion = (int?)null;
                        objBL_Separacion.Inserta(objE_Separacion);
                    }
                    else
                    {
                        objE_Separacion.IdDocumentoVenta = IdDocumentoVenta;
                        objE_Separacion.IdCotizacion = IdCotizacion;
                        objBL_Separacion.Actualiza(objE_Separacion);
                    }

                    #region "auditoria Eliminacion"

                    EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                    objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                    objE_EstadoCuentaHistorial.IdEmpresa = objE_Separacion.IdEmpresa;
                    objE_EstadoCuentaHistorial.Periodo = objE_Separacion.Periodo;
                    objE_EstadoCuentaHistorial.IdCliente = objE_Separacion.IdCliente;
                    objE_EstadoCuentaHistorial.NumeroDocumento = objE_Separacion.NumeroDocumento;
                    objE_EstadoCuentaHistorial.FechaCredito = objE_Separacion.FechaSeparacion;
                    objE_EstadoCuentaHistorial.FechaDeposito = objE_Separacion.FechaPago;
                    objE_EstadoCuentaHistorial.Concepto = objE_Separacion.Concepto;
                    objE_EstadoCuentaHistorial.FechaVencimiento = objE_Separacion.FechaVencimiento;
                    objE_EstadoCuentaHistorial.Importe = objE_Separacion.Importe;
                    objE_EstadoCuentaHistorial.TipoMovimiento = objE_Separacion.TipoMovimiento;
                    objE_EstadoCuentaHistorial.IdMotivo = objE_Separacion.IdMotivo;
                    objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_Separacion.IdDocumentoVenta;
                    objE_EstadoCuentaHistorial.IdCotizacion = objE_Separacion.IdCotizacion;
                    objE_EstadoCuentaHistorial.IdPedido = objE_Separacion.IdPedido;
                    objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_Separacion.IdMovimientoCaja;
                    objE_EstadoCuentaHistorial.Observacion = "";
                    objE_EstadoCuentaHistorial.ObservacionElimina = "Por: " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. SOLES";
                    objE_EstadoCuentaHistorial.TipoRegistro = "A";
                    objE_EstadoCuentaHistorial.FlagEstado = objE_Separacion.FlagEstado;
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
                //optCreditoCargo.Focus();
                deFechaSeparacion.Focus();
            }
        }

        private void optCreditoCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaSeparacion.Focus();
            }
        }

        private void optPagoAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaSeparacion.Focus();
            }
        }

        private void deFechaSeparacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaPago.Focus();
            }
        }

        private void deFechaPago_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumeroPedido_KeyPress(object sender, KeyPressEventArgs e)
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

            if (deFechaSeparacion.Text.Trim().ToString() == "")
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