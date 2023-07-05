using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegGestionPedidoDespachoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<MovimientoPedidoBE> lstMovimientoPedido;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public MovimientoPedidoBE pMovimientoPedidoBE { get; set; }
        
        int _IdMovimientoPedido = 0;

        public int IdMovimientoPedido
        {
            get { return _IdMovimientoPedido; }
            set { _IdMovimientoPedido = value; }
        }

        //int IdPedido = 0;
        int IdCliente = 0;
        int IdTipoCliente = 0;
        int IdAgencia = 0;
        int IdMoneda = 0;
        int IdFormaPago = 0;
        public bool CambioFechaDelivery = false;
        private DateTime FechaPedido;
        private DateTime FechaDelivery;
        public int Origen = 0;
        public int wVendedor = 0;
        //int IdClasificacionClientePed;

        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }


        #endregion

        #region "Eventos"

        public frmRegGestionPedidoDespachoEdit()
        {
            InitializeComponent();
        }

        private void frmRegGestionPedidoDespachoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboPrioridad, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblPrioridadDespacho), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDestino, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblDestinoDespacho ), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboPagoFlete, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblPagoFleteDespacho), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDescAgencia, new AgenciaBL().ListaTodosActivo(), "DescAgencia", "IdAgencia", true);
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "DescTipoDocumento", "IdTipoDocumento", false);

            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;
            //cboDocumento.EditValue = Parametros.intTipoDocNotaCredito;


            tmrNumero.Enabled = true;
            tmrNumero.Interval = 1000;
            //ObtenerCorrelativo();
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Despacho - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Despacho - Modificar";

                txtNumeroPedido.Properties.ReadOnly = true;

                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                if (objE_Pedido != null)
                {
                    IdPedido = objE_Pedido.IdPedido;
                    txtNumeroPedido.Text = objE_Pedido.Numero;
                    IdFormaPago = objE_Pedido.IdFormaPago;
                    txtDescFormaPago.Text = objE_Pedido.DescFormaPago;
                    IdMoneda = objE_Pedido.IdMoneda;
                    txtCodMoneda.Text = objE_Pedido.CodMoneda;
                    txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                    txtImporte.EditValue = objE_Pedido.Total;
                    IdCliente = objE_Pedido.IdCliente;
                    IdTipoCliente = objE_Pedido.IdTipoCliente;
                    txtDescCliente.Text = objE_Pedido.DescCliente;
                    txtDireccion.Text = objE_Pedido.Direccion;
                    cboMotivo.EditValue = objE_Pedido.IdMotivo;
                    FechaPedido = objE_Pedido.Fecha;
                    wVendedor = objE_Pedido.IdVendedor;

                }
                else {
                    XtraMessageBox.Show("El pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                
                }

                txtNumero.Select();

                //despacho

                MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
                objE_MovimientoPedido = new MovimientoPedidoBL().SeleccionaDespacho(IdPedido);

                if (objE_MovimientoPedido != null)
                {
                    string IdDepartamento = string.Empty;
                    string IdProvincia = string.Empty;
                    string IdDistrito = string.Empty;

                    IdAgencia = objE_MovimientoPedido.IdAgencia;
                    txtNumero.EditValue = objE_MovimientoPedido.NumeroDespacho;
                    deFecha.EditValue = objE_MovimientoPedido.FechaDespacho2;
                    txtBultos.EditValue = objE_MovimientoPedido.CantidadBulto;
                    cboPrioridad.EditValue = objE_MovimientoPedido.IdPrioridad;
                    cboDestino.EditValue = objE_MovimientoPedido.IdDestino;
                    cboPagoFlete.EditValue = objE_MovimientoPedido.IdPagoFlete;
                    cboDescAgencia.EditValue = objE_MovimientoPedido.IdAgencia;
                    txtDireccionAgencia.Text = objE_MovimientoPedido.Direccion;
                    txtReferencia.Text = objE_MovimientoPedido.Referencia;
                    txtObservacion.EditValue = objE_MovimientoPedido.Observacion2;
                    txtClaveEnvio.EditValue = objE_MovimientoPedido.ClaveEnvio;
                    cboDocumento.EditValue = objE_MovimientoPedido.IdTipoDocumento;
                    txtNumeroDocumento.EditValue = objE_MovimientoPedido.NumeroDocumento;
                    txtNumeroPiso.EditValue = objE_MovimientoPedido.NumeroPiso;
                    FechaDelivery = Convert.ToDateTime(objE_MovimientoPedido.FechaDespacho2);
                    CambioFechaDelivery = objE_MovimientoPedido.CambioFechaDelivery;
                    txtPersonaRecoge.EditValue = objE_MovimientoPedido.PersonaRecoge;
                    if (objE_MovimientoPedido.IdUbigeoDelivery.Trim() != "")
                        IdDepartamento = objE_MovimientoPedido.IdUbigeoDelivery.Substring(0, 2);
                    cboDepartamento.EditValue = IdDepartamento;
                    if (objE_MovimientoPedido.IdUbigeoDelivery.Trim() != "")
                        IdProvincia = objE_MovimientoPedido.IdUbigeoDelivery.Substring(2, 2);
                    cboProvincia.EditValue = IdProvincia;
                    if (objE_MovimientoPedido.IdUbigeoDelivery.Trim() != "")
                        IdDistrito = objE_MovimientoPedido.IdUbigeoDelivery.Substring(4, 2);
                    cboDistrito.EditValue = IdDistrito;

                    //if (objE_MovimientoPedido.FechaDespacho2 == null) {
                    //    deFecha.EditValue = DateTime.Now;
                    //}

                    if (Convert.ToInt32(cboDestino.EditValue) ==Parametros.intDDAgencia && IdAgencia == 0)
                    {
                        ClienteBE objE_Cliente = new ClienteBE();
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                        if (objE_Cliente.IdAgencia > 0)
                        { 
                            cboDescAgencia.EditValue = objE_Cliente.IdAgencia;
                            //cboDestino.EditValue = objE_Cliente.IdDestino;
                            lblSugerido.Visible = true;
                        }
                    }
                }
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
                        txtDireccion.Text = objE_Pedido.Direccion;
                        cboMotivo.EditValue = objE_Pedido.IdMotivo;

                        txtBultos.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede generar el Despacho, porque el número de pedido no se encuentra facturado ni despachado...por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                    MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();

                    objE_MovimientoPedido.IdMovimientoPedido = IdMovimientoPedido;
                    objE_MovimientoPedido.IdPedido = IdPedido;
                    objE_MovimientoPedido.IdAgencia = Convert.ToInt32(cboDescAgencia.EditValue);
                    objE_MovimientoPedido.Direccion = txtDireccionAgencia.Text;
                    objE_MovimientoPedido.IdUbigeoDelivery = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_MovimientoPedido.Referencia = txtReferencia.Text;
                    objE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtBultos.EditValue);
                    objE_MovimientoPedido.IdPrioridad = Convert.ToInt32(cboPrioridad.EditValue);
                    objE_MovimientoPedido.IdDestino = Convert.ToInt32(cboDestino.EditValue);
                    objE_MovimientoPedido.IdPagoFlete = Convert.ToInt32(cboPagoFlete.EditValue);
                    objE_MovimientoPedido.NumeroDespacho = txtNumero.Text.Trim();
                    objE_MovimientoPedido.FechaDespacho2 = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoPedido.ClaveEnvio = txtClaveEnvio.Text.Trim();
                    objE_MovimientoPedido.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoPedido.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    objE_MovimientoPedido.NumeroPiso = Convert.ToInt32(txtNumeroPiso.Text);
                    objE_MovimientoPedido.Observacion2 = txtObservacion.Text ;
                    objE_MovimientoPedido.CambioFechaDelivery = CambioFechaDelivery;
                    objE_MovimientoPedido.UsuarioCambioFecha = Parametros.strUsuarioLogin;
                    objE_MovimientoPedido.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoPedido.Equipo = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoPedido.PersonaRecoge = txtPersonaRecoge.Text.Trim();

                    if (Origen == 1)//Almacen
                    {
                        if (FechaDelivery != Convert.ToDateTime(deFecha.EditValue))
                        {
                            objE_MovimientoPedido.CambioFechaDelivery = true;
                        }
                    }

                    objBL_MovimientoPedido.ActualizaDespacho(objE_MovimientoPedido);

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

        private void btnNuevaAgencia_Click(object sender, EventArgs e)
        {

        }

        private void cboDescAgencia_EditValueChanged(object sender, EventArgs e)
        {
            AgenciaBE objAgencia = new AgenciaBE();
            objAgencia = new AgenciaBL().Selecciona(Convert.ToInt32(cboDescAgencia.EditValue));

            if (objAgencia != null) 
            {
                txtDireccionAgencia.EditValue = objAgencia.Direccion;
            }
        }

        #endregion

        #region "Metodos"

        private void ObtenerCorrelativo()
        {
            //try
            //{
            //    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            //    string sNumero = "";
            //    string sSerie = "";
            //    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocMovimientoPedidoCredito, Parametros.intPeriodo);
            //    if (mListaNumero.Count > 0)
            //    {
            //        sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            //        sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
            //    }

            //    txtNumero.Text = sNumero;
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            // Validando Fecha delivery
            //FechaPedido
            TimeSpan difFechasDel = (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) - FechaPedido);
            int vNumDias = difFechasDel.Days;
            //XtraMessageBox.Show(vNumDias.ToString());

            if (Parametros.intTiendaId == 1 || Parametros.intTiendaId == 2)
            {
                if (wVendedor == 2 || wVendedor == 9850)
                {
                }
                else
                { 
                    if (vNumDias < 2)
                    {
                        // XtraMessageBox.Show("La fecha de DELIVERY tiene que ser mayor a 2 días.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        strMensaje = strMensaje + "- La fecha de DELIVERY tiene que ser mayor a 2 días.\n";
                        flag = true;
                    }
                }
            }

            if (IdPedido == 0)
            {
                strMensaje = strMensaje + "- Debe ingresar un número de pedido.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtNumeroPiso.Text) == 0)
            {
                strMensaje = strMensaje + "- Debe ingresar el numero de piso.\n";
                flag = true;
            }

            if (txtDireccionAgencia.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Debe ingresar la dirección de envío.\n";
                flag = true;
            }

            if (txtBultos.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Debe ingresar Cantidad de bultos.\n";
                flag = true;
            }
            if (txtPersonaRecoge.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingrese la persona quien recogera los productos.\n";
                flag = true;
            }

            if (txtDireccion.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Debe ingresar Dirección del Cliente.\n";
                flag = true;
            }

            if (deFecha.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de envío.\n";
                flag = true;
            }

            if (cboDistrito.Text == "")
            {
                strMensaje = strMensaje + "- Ingrese el Distrito.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboDestino.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingrese Destino.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboPrioridad.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingrese la prioridad.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboPagoFlete.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingrese el pago del flete.\n";
                flag = true;
            }

            if (txtReferencia.Text == "")
            {
                strMensaje = strMensaje + "- Ingrese la referencia del lugar .\n";
                flag = true;
            }

            



            if (Origen == 0)
            {
                if (IdFormaPago != Parametros.intContado)
                {
                    //if (DateTime.Now.TimeOfDay < TimeSpan.Parse("05:00:00"))
                    //{
                        if (Convert.ToDateTime(deFecha.EditValue) < FechaPedido.AddDays(1))
                        {
                            strMensaje = strMensaje + "- La fecha de despacho no debe ser menor a 1 día.\n";
                            flag = true;
                        }
                    //}
                    //else
                    //{
                    //    if (Convert.ToDateTime(deFecha.EditValue) < FechaPedido.AddDays(2))
                    //    {
                    //        strMensaje = strMensaje + "- La fecha de despacho no debe ser menor a dos días.\n";
                    //        strMensaje = strMensaje + "- La hora límite de despacho para el día siguiente es 5:00 p.m.\n";
                    //        flag = true;
                    //    }
                    //}
                }


                //Pedido verificar
                if (FechaDelivery != Convert.ToDateTime(deFecha.EditValue) && FechaDelivery >Convert.ToDateTime("01/01/2000"))
                {
                    PedidoBE ojbE_Pedido = null;
                    ojbE_Pedido = new PedidoBL().Selecciona(IdPedido);
                    if (ojbE_Pedido != null)
                    {
                        if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerSupervisorVentasPiso || Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas)
                        {
                        }
                        else
                        {
                            if (Parametros.intPersonaId == ojbE_Pedido.IdVendedor)
                            {

                            }
                            else
                            {
                                strMensaje = strMensaje + "- El cambio de fecha sólo está disponible para el Vendedor que realizó el pedido, Supervisor de tienda y Administrador..\nUd debe salir y volver a ingresar al sistema con tu Usuario y Contraseña";
                                flag = true;
                            }
                        }
                    }
                }
                

                //De varios Almacenes
                PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                objE_PedidoDetalle = new PedidoDetalleBL().SeleccionaVariosAlmacenes(IdPedido);

                if (objE_PedidoDetalle.Cantidad > 0)
                {
                    if (Convert.ToDateTime(deFecha.EditValue) < FechaPedido.AddDays(1))
                    {
                        strMensaje = strMensaje + "- La fecha de Delivery no puede ser menor a 1 día cuando solicitan de otra tienda.\n";// antes 4 días
                        flag = true;
                    }
                }
            }

            if (txtNumeroPiso.Text == ""|| Convert.ToInt32(txtNumeroPiso.EditValue) <= 0)
            {
                strMensaje = strMensaje + "- Ingrese El número de piso de entrega.\n";
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

        private void cboDestino_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDestino.EditValue) == Parametros.intDDAgencia && IdAgencia == 0)
            {
                ClienteBE objE_Cliente = new ClienteBE();
                objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                if (objE_Cliente.IdAgencia > 0)
                {
                    cboDescAgencia.EditValue = objE_Cliente.IdAgencia;
                    //cboDestino.EditValue = objE_Cliente.IdDestino;
                    lblSugerido.Visible = true;
                }
            }
        }

        private void cboDescAgencia_Click(object sender, EventArgs e)
        {
            lblSugerido.Visible = false;
        }

        private void chkCallao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCallao.Checked == true)
            {
                cboDepartamento.EditValue = "07";//Callao
            }
            else
            {
                cboDepartamento.EditValue = Parametros.sIdDepartamento;//Lima
            }
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }
    }
}