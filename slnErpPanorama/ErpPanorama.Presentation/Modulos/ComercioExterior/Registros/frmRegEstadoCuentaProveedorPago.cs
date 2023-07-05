using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Security.Principal;
using ErpPanorama.Presentation.Utils;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmRegEstadoCuentaProveedorPago : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<EstadoCuentaProveedorBE> lstEstadoCuenta;
        FacturaCompraBE objBE_FacturaCompra = new FacturaCompraBE();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdProveedor { get; set; }

        //public string Numero { get; set; }
        public int IdMotivo { get; set; }
        public string DescProveedor { get; set; }
        public int IdSituacion { get; set; }
        public int Periodo { get; set; }
        public string TipoMovimiento { get; set; }

        int _IdEstadoCuentaProveedor = 0;

        public int IdEstadoCuentaProveedor
        {
            get { return _IdEstadoCuentaProveedor; }
            set { _IdEstadoCuentaProveedor = value; }
        }

        public int  IdFacturaCompra  { get; set; }

        decimal decImporteAnt = 0;
        
       
        #endregion
        public frmRegEstadoCuentaProveedorPago()
        {
            InitializeComponent();
        }

        private void frmRegEstadoCuentaProveedorPago_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboFactuaCompra, new FacturaCompraBL().ListadoPendientesProveedor(Parametros.intIdPanoramaDistribuidores, IdProveedor, null), "NumeroDocumento", "IdFacturaCompra", true);
            lstEstadoCuenta = new EstadoCuentaProveedorBL().ListaTodosActivo(Parametros.intEmpresaId, IdProveedor,"", IdSituacion);
            FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
            objBE_FacturaCompra =objBL_FacturaCompra.Selecciona(Parametros.intEmpresaId,Convert.ToInt32( cboFactuaCompra.EditValue));
          

            txtDescProveedor.Text = DescProveedor;
            if(TipoMovimiento=="A")
            {
                optPagoAbono.Checked = true;
                optCreditoCargo.Enabled = false;
            }
            else if(TipoMovimiento == "C")
           
            {
                optCreditoCargo.Checked = true;
                optPagoAbono.Enabled = false;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Estado de Cuenta - Nuevo";
               
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Estado de Cuenta - Modificar";

                EstadoCuentaProveedorBE objE_EstadoCuenta = new EstadoCuentaProveedorBE();
                objE_EstadoCuenta = new EstadoCuentaProveedorBL().Selecciona(Parametros.intEmpresaId, IdEstadoCuentaProveedor);

                //cboMotivo.EditValue = objE_EstadoCuenta.IdMotivo;
                txtNumeroDocumento.Text = objE_EstadoCuenta.NumeroDocumento;
                deFechaCredito.EditValue = objE_EstadoCuenta.Fecha;
                deFechaDeposito.EditValue = objE_EstadoCuenta.Fecha;
                txtConcepto.Text = objE_EstadoCuenta.Concepto;
                deFechaVencimiento.EditValue = objE_EstadoCuenta.FechaVencimiento;
                txtImporte.EditValue = objE_EstadoCuenta.Importe;
                decImporteAnt = objE_EstadoCuenta.ImporteAnt;
                IdFacturaCompra = Convert.ToInt32(objE_EstadoCuenta.IdFacturaCompra);
                // IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                txtObservacion.Text = objE_EstadoCuenta.Observacion;
                //personalizado
                Size size = new Size();
                size.Height = 20;
                size.Width = 620;
               // txtConcepto.Size = size;
                txtNumeroPedido.Visible = false;
                labelControl6.Visible = false;
                txtNumeroDocumento.Properties.ReadOnly = true;
                cboFactuaCompra.Visible = false;
                btnLimpiar.Visible = false;
                labelControl9.Visible = false;
            }

           //  CargarFactura();
            cboFactuaCompra.EditValue = null;
            txtNumeroDocumento.Select();    
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EstadoCuentaProveedorBL objBL_EstadoCuentaProveedor = new EstadoCuentaProveedorBL();
                    EstadoCuentaProveedorBE objE_EstadoCuentaProveedor = new EstadoCuentaProveedorBE();

                    objE_EstadoCuentaProveedor.IdEstadoCuentaProveedor = IdEstadoCuentaProveedor;
                    objE_EstadoCuentaProveedor.IdEmpresa = Parametros.intEmpresaId;
                    objE_EstadoCuentaProveedor.Periodo = Parametros.intPeriodo;
                    objE_EstadoCuentaProveedor.IdProveedor = IdProveedor;
                    objE_EstadoCuentaProveedor.NumeroDocumento = txtNumeroDocumento.Text;
                    objE_EstadoCuentaProveedor.Fecha = Convert.ToDateTime(deFechaCredito.DateTime.ToShortDateString());

                    if (Convert.ToInt32(cboFactuaCompra.EditValue)==0)
                    { 
                        objE_EstadoCuentaProveedor.Concepto = txtConcepto.Text.Trim();
                        objE_EstadoCuentaProveedor.IdMotivo = 0;
                    }
                    else
                    { 
                        objE_EstadoCuentaProveedor.Concepto = txtConcepto.Text.Trim() + " N° " + cboFactuaCompra.Text.Trim();
                        objE_EstadoCuentaProveedor.IdMotivo = Convert.ToInt32(objBE_FacturaCompra.IdMotivoVenta); 
                    }
                    if (deFechaVencimiento.Text == "")
                        objE_EstadoCuentaProveedor.FechaVencimiento = null;
                    else
                        objE_EstadoCuentaProveedor.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objE_EstadoCuentaProveedor.IdMoneda = Parametros.intDolares;
                    objE_EstadoCuentaProveedor.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objE_EstadoCuentaProveedor.ImporteAnt = decImporteAnt;
                    objE_EstadoCuentaProveedor.TipoMovimiento =TipoMovimiento;
                
                    objE_EstadoCuentaProveedor.IdCuentaBancoDetalle = null;
                    objE_EstadoCuentaProveedor.IdPersona = Parametros.intUsuarioId;
                    objE_EstadoCuentaProveedor.UsuarioRegistro = Parametros.strUsuarioLogin;
                    objE_EstadoCuentaProveedor.FechaRegistro = Parametros.dtFechaHoraServidor;
                    objE_EstadoCuentaProveedor.Observacion = txtObservacion.Text;
                    objE_EstadoCuentaProveedor.Saldo = Convert.ToDecimal(txtImporte.EditValue);
                    objE_EstadoCuentaProveedor.FlagEstado = true;
                    
                    objE_EstadoCuentaProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_EstadoCuentaProveedor.Usuario = Parametros.strUsuarioLogin;
                    if (pOperacion == Operacion.Nuevo)
                    {
                        if(Convert.ToInt32(cboFactuaCompra.EditValue) ==0)
                        {
                            objE_EstadoCuentaProveedor.IdFacturaCompra = null;
                        }
                        else
                        {
                            objE_EstadoCuentaProveedor.IdFacturaCompra = Convert.ToInt32(cboFactuaCompra.EditValue);
                        }
                        objBL_EstadoCuentaProveedor.Inserta(objE_EstadoCuentaProveedor);
                    }
                    else
                    {

                        objE_EstadoCuentaProveedor.IdFacturaCompra = IdFacturaCompra;
                        objBL_EstadoCuentaProveedor.Actualiza(objE_EstadoCuentaProveedor);
                    }

                    #region "auditoria Eliminacion"
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
        #region Metodos

        //private void CargarFactura()
        //{
        //   // BSUtils.LoaderLook(cboFactuaCompra, new PedidoBL().ListaClientePorCobrar(IdProveedor), "Numero", "IdPedido", true);
        //    BSUtils.LoaderLook(cboFactuaCompra, new FacturaCompraBL().ListaProveedor(Parametros.intIdPanoramaDistribuidores, IdProveedor, null), "NumeroDocumento", "IdFacturaCompra", true);
        //}
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
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboFactuaCompra.EditValue = null;
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaCredito.Focus();
            }
        }

        private void deFechaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaDeposito.Focus();
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFechaVencimiento.Focus();
            }
        }

        private void deFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtImporte.Focus();
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtObservacion.Focus();
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnGrabar.Focus();
            }
        }
    }
}