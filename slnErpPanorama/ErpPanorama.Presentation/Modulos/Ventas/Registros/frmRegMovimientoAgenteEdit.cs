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

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegMovimientoAgenteEdit : DevExpress.XtraEditors.XtraForm
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

        string _strTipoMovimiento = "R";
        public string strTipoMovimiento
        {
            get { return _strTipoMovimiento; }
            set { _strTipoMovimiento = value; }
        }

        private int IdPedido = 0;

        #endregion

        #region "Eventos"

        public frmRegMovimientoAgenteEdit()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoAgenteEdit_Load(object sender, EventArgs e)
        {
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
                //BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
                //cboDocumento.EditValue = Parametros.intTipoDocTicketAgenteBanco;
                BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
                cboDocumento.EditValue = Parametros.intTipoDocTicketAgenteBanco;


                BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
                cboCondicionPago.EditValue = Parametros.intEfectivo;
                txtTipoCambio.EditValue = objE_TipoCambio.Compra;
                BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                cboMoneda.EditValue = Parametros.intSoles;

                //tipo de Movimiento
                if (strTipoMovimiento == "R")
                    optRetiro.Checked = true;
                else
                    optPago.Checked = true;


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
                    //txtNumeroPedido.Text = objE_Pago.NumeroPedido;
                    //txtCodMonedaPedido.Text = objE_Pago.CodMonedaPedido;
                    //txtTotal.EditValue = objE_Pago.Total;
                    //txtDescCliente.Text = objE_Pago.DescCliente;
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
                    objPago.NumeroDocumento = txtNumeroDocumento.Text;
                    objPago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objPago.Concepto = txtConcepto.Text;
                    objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                    objPago.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                    //objPago.TipoMovimiento = "R"; // Abono - R -RETIRO
                    if(optRetiro.Checked == true)
                        objPago.TipoMovimiento = "R";
                    else
                        objPago.TipoMovimiento = "P";

                    objPago.FlagEstado = true;
                    objPago.Usuario = Parametros.strUsuarioLogin;
                    objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPago.IdEmpresa = Parametros.intEmpresaId;

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
                    //objMovimientoCaja.TipoMovimiento = "I";
                    if (optRetiro.Checked == true)
                    {
                        objMovimientoCaja.TipoMovimiento = "S";
                    }
                    else {
                        objMovimientoCaja.TipoMovimiento = "I";
                    }
                    objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                    objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                    objMovimientoCaja.FlagEstado = true;
                    objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                    lstMovimientoCaja.Add(objMovimientoCaja);
                    //Estado Cuenta
                    EstadoCuentaBE objE_EstadoCuenta =null;
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
                        objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(Parametros.intEmpresaId ,Parametros.intTipoDocTicketAgenteBanco, txtNumeroDocumento.Text.Trim());

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

        //private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            //Traemos la información del Pedido
        //            PedidoBE objE_Pedido = null;
        //            objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text.Trim());
        //            if (objE_Pedido != null)
        //            {
        //                IdPedido = objE_Pedido.IdPedido;
        //                txtNumeroPedido.Text = objE_Pedido.Numero;
        //                cboMoneda.EditValue = objE_Pedido.IdMoneda;
        //                txtCodMonedaPedido.Text = objE_Pedido.CodMoneda;
        //                txtTotal.EditValue = objE_Pedido.Total;
        //                txtDescCliente.Text = objE_Pedido.DescCliente;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmBusCliente frm = new frmBusCliente();
        //        frm.pFlagMultiSelect = false;
        //        frm.ShowDialog();
        //        if (frm.pClienteBE != null)
        //        {
        //            txtDescCliente.Text = frm.pClienteBE.DescCliente;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = Parametros.intTipoDocTicketAgenteBanco;
            dr["Descripcion"] = "TKA";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

    }
}