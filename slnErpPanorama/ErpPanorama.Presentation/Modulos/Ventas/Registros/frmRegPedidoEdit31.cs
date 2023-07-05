using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Funciones;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegPedidoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPedidoDetalle> mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();
        public List<CPedidoDetalle> mListaPedidoDetalleOrigen2 = new List<CPedidoDetalle>();
        public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();
        public List<DescuentoClienteFechaCompraBE> mListaDescuentoClienteFechaCompra = new List<DescuentoClienteFechaCompraBE>();
        public List<DescuentoClientePromocionBE> mDescuentoClientePromocion = new List<DescuentoClientePromocionBE>();// Cargar Descuento Cliente
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocionDosPorUno = new List<Promocion2x1DetalleBE>();// Cargar Lista 2x1
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion3x2 = new List<Promocion2x1DetalleBE>();// Cargar Lista 3x2
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion3x1 = new List<Promocion2x1DetalleBE>();// Cargar Lista 3x1
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion4x1 = new List<Promocion2x1DetalleBE>();// Cargar Lista 4x1
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion6x3 = new List<Promocion2x1DetalleBE>();// Cargar Lista 6x3
        public List<PromocionValeDescuentoBE> mListaPromocionVale = new List<PromocionValeDescuentoBE>();
        public List<CMovimientoAlmacenDetalle> mListaMovimientoAlmacenDetalleOrigen = new List<CMovimientoAlmacenDetalle>();

        public List<PedidoDetalleBE> mListaPedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
        public List<PedidoDetalleBE> mListaPedidoDetallePromo3x1 = new List<PedidoDetalleBE>();
        public List<PedidoDetalleBE> mListaPedidoDetallePromo4x1 = new List<PedidoDetalleBE>();

        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        bool _ActivaCabeceraCaja = false;
        public bool ActivaCabeceraCaja
        {
            get { return _ActivaCabeceraCaja; }
            set { _ActivaCabeceraCaja = value; }
        }

        private int IdTienda = Parametros.intTiendaId;
        private int IdCliente = 0;
        private int IdAsesorExterno = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private int IdProforma = 0;
        private int? IdContratoFabricacion = 0;
        private int? IdProyectoServicio = 0;
        private int? IdNovioRegalo = 0;
        private int IdSituacionModifica = 0;
        private int IdClienteAsociado = 0;
        private int? IdPedidoReferencia = 0;
        private bool bMoroso = false;
        private bool bCumpleAnios = false;
        private bool bEncuesta = false;
        private bool bOrigenFlagPreventa = false;
        private decimal DescuentoClientePromocion = 0;
        private int IdDescuentoClientePromocion = 0;
        private int ItemsDescuentoPromocion = 0;
        private bool DescuentoClienteBulto = true;

        private DateTime FechaCompraProducto ;
        private string ObservacionDefault = "";
        private string NumeroNotaSalida = "";
        private int IdProductoArmado = 0;
        private bool FlagPromocion2x1 = false;
        private bool FlagImpresionRus = true;
        private int intSeleccionaTipoCliente = 1;//1:final 2:Mayorista
        private bool FlagMayoristaActivo = true;
        private decimal DescuentoVale = 0; //Vale
        private decimal ImporteVale = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public bool bNuevo = true;
        public bool bConsulta = false;
        private int EBotonGrabar = 0;
        private int Periodo = Parametros.intPeriodo;

        decimal dmlTipoCambio = 0;

        public ParametroBE pParametroBE;
        public bool bFlagImpresion = false;
        public bool bFlagModificarAlmacen = false;//1: Almacen
        public int OrigenNuevo = 0; //1: Producto Transformado
        public decimal TotalPedido = 0;
        public int vIdPersonaPIN = 0;
        public int vIdPerfilVendedorPiso = 0;

        #endregion

        decimal vDesciuento = 0;
        decimal vTotalDescuento = 0;
        decimal vMp = 0;

        #region "Eventos"

        public frmRegPedidoEdit()
        {
            InitializeComponent();
        }

        private void frmRegPedidoEdit_Load(object sender, EventArgs e)
        {
            chkPreventa.Enabled = true; 
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            deFecha.EditValue = DateTime.Now;
            deFechaVencimiento.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocPedidoVenta;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            
            if (Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "etapia" 
                || Parametros.strUsuarioLogin == "ntapia" || Parametros.strUsuarioLogin == "dsalinas" || Parametros.strUsuarioLogin == "acordero" || Parametros.strUsuarioLogin.ToUpper() == "EVALDEZ"
                || Parametros.intPerfilId == Parametros.intPerAdministradorTienda || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCajeraDigital)
            {
                BSUtils.LoaderLook(cboTipoVenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoVenta), "DescTablaElemento", "IdTablaElemento", true);
            }
            else
            {
                BSUtils.LoaderLook(cboTipoVenta, new TablaElementoBL().ListaTodosActivoSinEcommerce(Parametros.intEmpresaId, Parametros.intTblTipoVenta), "DescTablaElemento", "IdTablaElemento", true);
            }
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;

            BSUtils.LoaderLook(cboAsesor, new PersonaBL().SeleccionaAsesor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboAsesor.EditValue = 0;
            BSUtils.LoaderLook(cboTipoDocumentoBusqueda, CargarTipDocumentoBusqueda(), "Descripcion", "Id", true);
            
            //BSUtils.LoaderLook(cboAsesorExterno, new ClienteBL().ListaAsesorExterno(Parametros.intEmpresaId), "DescCliente", "IdCliente", true);//add 
            //cboAsesorExterno.EditValue = 0;

            BSUtils.LoaderLook(cboCombo, new ComboBL().ListaTodosActivo(Parametros.intEmpresaId), "DescCombo", "IdCombo", true);
            cboCombo.EditValue = 0;
            BSUtils.LoaderLook(cboCaja, CargarCaja(), "Descripcion", "Id", false);
            cboCaja.EditValue = 6;

            CargarDescuentoClienteMayorista();
            CargarDescuentoClienteFechaCompra();//por Default, no es necesario cargar
            EstadoDescuentoClienteFechaCompra();

            ////Cargar Promociones ***** 2x1
            //CargarProductoPromocionDosPorUno();
            //CargarProductoPromocion3x2();
            ////Vale Apertura
            //if (Parametros.intTiendaId == Parametros.intTiendaMegaplaza)
            //{
            //    chkVale.Visible = true;
            //}

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteFacturacion || 
                Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion|| Parametros.intPerfilId == Parametros.intPerSupervisorVentasPiso || 
                Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.intPerfilId == Parametros.intPerAsistenteCompras)
            {
                txtDescuento.Properties.ReadOnly = false;
                eliminarpromocion2x1toolStripMenuItem.Enabled = true;
            }else
            {
                eliminarpromocion2x1toolStripMenuItem.Enabled = false;
            }

            //Traer Anuncio Publicitario
            //string Anuncio = "";
            //AnuncioBE objE_Anuncio = null;
            //objE_Anuncio = new AnuncioBL().SeleccionaUltimo();
            //if (objE_Anuncio != null)
            //{
            //    Anuncio = objE_Anuncio.DescAnuncio;
            //}

            string Anuncio = "";
            List<AnuncioBE>lst_Anuncio = null;
            lst_Anuncio = new AnuncioBL().ListaUltimoTipo(Parametros.intAnuncioPedido);
            if (lst_Anuncio.Count > 0)
            {
                Anuncio = lst_Anuncio[0].DescAnuncio;
            }

            //Add Anuncio de Stock Online
            if (Parametros.bValidarStockDetallePedido == true)
            {
                Anuncio = Anuncio + " - (STOCK ONLINE)";
            }

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Pedido Venta - Nuevo" + " " + Anuncio;
                //Especificamos los datos del cliente general
                IdCliente = Parametros.intIdClienteGeneral;
                IdTipoCliente = Parametros.intTipClienteFinal;
                txtNumeroDocumento.Text = Parametros.strNumeroCliente;
                txtDescCliente.Text = Parametros.strDescCliente;
                IdClasificacionCliente = Parametros.intClasico;
                txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
                txtDireccion.Text = Parametros.strDireccion;

                //ADD
                BSUtils.LoaderLook(cboFormaPago, CargarFormaPagoClienteFinal(), "DescTablaElemento", "IdTablaElemento", true);

                //ADD 120815
                #region "Ingresar PIN"
                if (Parametros.intPerfilId == Parametros.intPerAsesorVentaPiso)
                {
                    if (Parametros.bValidarPINUsuario)
                    {
                        frmAsignarPersona frm = new frmAsignarPersona();
                        frm.StartPosition = FormStartPosition.CenterParent;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            vIdPersonaPIN = frm.IdPersona;
                            cboVendedor.EditValue = frm.IdPersona;
                            cboVendedor.Properties.ReadOnly = true;
                            vIdPerfilVendedorPiso = 1;
                        }
                        else
                        {
                            this.Close();
                        }                    
                    }
                }
                #endregion

                //CODIGO PT
                if (OrigenNuevo == 1)//Crear PT
                {
                    //Especificamos los datos del cliente DECORATEX
                    IdCliente = 236149;
                    IdTipoCliente = Parametros.intTipClienteFinal;
                    txtNumeroDocumento.Text = "20600071344";
                    txtDescCliente.Text = "DECORATEX E.I.R.L.";
                    IdClasificacionCliente = Parametros.intClasico;
                    txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
                    txtDireccion.Text = "JR. UCAYALI NRO. 435  LIMA-LIMA-LIMA";
                    cboVendedor.EditValue = 74;
                    cboVendedor.Properties.ReadOnly = true;
                    txtNumeroDocumento.Properties.ReadOnly = true;
                    cboFormaPago.EditValue = Parametros.intContraEntrega;

                }
                chkPreventa.Enabled = true;
            }
            #region "Modificar"
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Pedido - Modificar" + "  " + Anuncio;

                //Carga Personal - Todos incluyendo Cesados
                BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                if (objE_Pedido != null)
                {
                    //CargarProductoPromocionDosPorUno(); //Dos por uno 
                    if (mListaPromocionVale.Count > 0)
                    {
                        FlagPromocion2x1 = false;
                    }
                    else
                    {
                        // Comentado por el calculo de mercado pago ...02-03-2021
                        //if (objE_Pedido.PorcentajeDescuento > 0)
                        //    FlagPromocion2x1 = false;
                        //else
                        //    FlagPromocion2x1 = true;
                    }

                    if (objE_Pedido.IdSituacion == Parametros.intPVAprobado || objE_Pedido.IdSituacion == Parametros.intFacturado 
                      || objE_Pedido.IdSituacion == Parametros.intPVAnulado || objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                    {
                        mListaPromocionVale.Clear();//add 250516
                    }

                    lblIdPedido.Text = objE_Pedido.IdPedido.ToString();
                    Periodo = objE_Pedido.Periodo;
                    cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                    IdTienda = objE_Pedido.IdTienda;
                    cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                    txtNumero.Text = objE_Pedido.Numero;
                    deFecha.EditValue = objE_Pedido.Fecha;
                    txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                    cboVendedor.EditValue = objE_Pedido.IdVendedor;
                    cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                    deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                    cboMoneda.EditValue = objE_Pedido.IdMoneda;
                    txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                    dmlTipoCambio = objE_Pedido.TipoCambio;
                    IdCliente = objE_Pedido.IdCliente;
                    IdTipoCliente = objE_Pedido.IdTipoCliente;
                    IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                    txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                    txtDescCliente.Text = objE_Pedido.DescCliente;
                 

                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                    {
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                        intSeleccionaTipoCliente = 1;

                        if (IdClasificacionCliente == Parametros.intClubDesign)
                            txtTipoCliente.ForeColor = Color.Fuchsia;
                        else
                            txtTipoCliente.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                        intSeleccionaTipoCliente = 2;
                        if (objE_Pedido.IdSituacionCliente == Parametros.intSITClienteInactivo)
                        {
                            FlagMayoristaActivo = false;
                            IdTipoCliente = Parametros.intTipClienteFinal;
                            txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-INACTIVO";
                            txtTipoCliente.ForeColor = Color.Red;
                        }

                        if (Parametros.intTiendaId != Parametros.intTiendaUcayali && Parametros.intTiendaId != Parametros.intTiendaAndahuaylas)//add 131217
                        {
                            FlagMayoristaActivo = false;
                            IdTipoCliente = Parametros.intTipClienteFinal;
                            txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "- P.FINAL";
                            txtTipoCliente.ForeColor = Color.Red;
                            //XtraMessageBox.Show("El cliente Mayorista, sólo puede comprar en la tienda UCAYALI Y ANDAHUAYLAS, por lo tanto, se aplicará el criterio de descuento del cliente final.\nPara más información consultar con su vendedor de cartera.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    txtDireccion.Text = objE_Pedido.Direccion;
                    cboCombo.EditValue = objE_Pedido.IdCombo;
                    cboCaja.Text = objE_Pedido.Despachar;
                    txtObservaciones.Text = objE_Pedido.Observacion;
                    txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                     vDesciuento = objE_Pedido.PorcentajeDescuento;
                    vTotalDescuento = objE_Pedido.Descuento;
                    vMp = objE_Pedido.Descuento;
                    txtDescuento.EditValue = objE_Pedido.PorcentajeDescuento;
                    txtTotalDscto2x1.EditValue = objE_Pedido.Descuento;
                    txtMP.EditValue = objE_Pedido.Descuento;
                    txtSubTotal.EditValue = objE_Pedido.SubTotal;
                    txtImpuesto.EditValue = objE_Pedido.Igv;
                    txtICBPER.EditValue = objE_Pedido.Icbper;
                    txtTotal.EditValue = objE_Pedido.Total;
                    txtTotalBruto.EditValue = objE_Pedido.TotalBruto;
                    cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                    cboMotivo.EditValue = objE_Pedido.IdMotivo;
                    chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                    cboAsesor.EditValue = objE_Pedido.IdAsesor;
                    //cboAsesorExterno.EditValue = objE_Pedido.IdAsesorExterno;
                    IdAsesorExterno = objE_Pedido.IdAsesorExterno;
                    IdPedidoReferencia = objE_Pedido.IdPedidoReferencia;
                    bFlagImpresion = objE_Pedido.FlagImpresion;//add 220116
                    FlagImpresionRus = objE_Pedido.FlagImpresionRus; //add 150216
                    IdContratoFabricacion = objE_Pedido.IdContratoFabricacion;
                    IdProyectoServicio = objE_Pedido.IdProyectoServicio;
                    IdNovioRegalo = objE_Pedido.IdNovioRegalo;

                    if (objE_Pedido.FlagCompraPerfecta == true)
                    {
                        chkCompraPerfecta.EditValue = objE_Pedido.FlagCompraPerfecta;
                        chkCompraPerfecta.Visible = true;
                        chkCompraPerfecta.Properties.ReadOnly = true;
                    }

                    //Carga ClienteAsociado
                    CargarClienteAsociado();
                    cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                    //Carga Asesor Externo
                    if (IdAsesorExterno > 0)
                    {
                        ClienteBE objE_ClienteExterno = null;
                        objE_ClienteExterno = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdAsesorExterno);

                        txtDniDiseñador.Text = objE_ClienteExterno.NumeroDocumento;
                        txtNombreDiseñador.Text = objE_ClienteExterno.DescCliente;
                    }

                    #region "Permisos x Usuario"
                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "liliana" || 
                        Parametros.strUsuarioLogin == "rcastañeda" || Parametros.strUsuarioLogin == "jzanabria" || 
                        Parametros.strUsuarioLogin == "dhuaman" || Parametros.strUsuarioLogin == "aflores" || 
                        Parametros.strUsuarioLogin == "nillanes" || Parametros.intPerfilId == Parametros.intPerAdministrador || 
                        Parametros.intPerfilId == Parametros.intPerHelpDesk)
                    {
                        Habilitar();
                    }
                    else
                    {
                        DesHabilitar();
                    }

                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "liliana" || 
                        Parametros.strUsuarioLogin == "rcastañeda" || Parametros.strUsuarioLogin == "jzanabria" || 
                        Parametros.strUsuarioLogin == "dhuaman" || Parametros.strUsuarioLogin == "nillanes" || 
                        Parametros.strUsuarioLogin == "aflores" || Parametros.intPerfilId == Parametros.intPerAdministrador || 
                        Parametros.intPerfilId == Parametros.intPerHelpDesk)
                    {

                        if (objE_Pedido.IdSituacion == Parametros.intFacturado || 
                            objE_Pedido.IdSituacion == Parametros.intPVAnulado || 
                            objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                        {
                            XtraMessageBox.Show("No se puede modificar el pedido está cancelado y/o anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnNuevo.Enabled = false;
                            btnEditar.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnGrabar.Enabled = false;
                            mnuContextual.Enabled = false;
                            menuStrip1.Enabled = false;
                            DesHabilitar(); // add
                        }
                        else
                        {
                            btnNuevo.Enabled = true;
                            btnEditar.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnGrabar.Enabled = true;
                            mnuContextual.Enabled = true;
                            menuStrip1.Enabled = true;
                        }
                    }
                    else
                    {
                        if (objE_Pedido.IdSituacion == Parametros.intPVAprobado || 
                            objE_Pedido.IdSituacion == Parametros.intFacturado || 
                            objE_Pedido.IdSituacion == Parametros.intPVAnulado || 
                            objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                        {
                            XtraMessageBox.Show("No se puede modificar el pedido está cancelado y/o anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnNuevo.Enabled = false;
                            btnEditar.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnGrabar.Enabled = false;
                            mnuContextual.Enabled = false;
                            menuStrip1.Enabled = false;
                            DesHabilitar(); // add
                        }
                        else
                        {
                            btnNuevo.Enabled = true;
                            btnEditar.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnGrabar.Enabled = true;
                            mnuContextual.Enabled = true;
                            menuStrip1.Enabled = true;
                        }
                    }

                    if (bConsulta)
                    {
                        btnNuevo.Enabled = false;
                        btnEditar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnGrabar.Enabled = false;
                        mnuContextual.Enabled = false;
                        menuStrip1.Enabled = false;
                    }
                    #endregion

                    #region "Boton Enviar a Almacen"
                    if (Parametros.bValidarStockDetallePedido == true)
                    {
                        if (chkPreventa.Checked == false)
                        {
                            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)//add 1708
                            {
                                if (objE_Pedido.FlagImpresion )//Pedido Impreso
                                {
                                    btnNuevo.Enabled = false;
                                    btnEditar.Enabled = false;
                                    btnEliminar.Enabled = false;
                                    btnGrabar.Enabled = false;
                                    mnuContextual.Enabled = false;
                                    menuStrip1.Enabled = false;

                                    btnEnviarAlmacen.Visible = false;
                                }
                                else
                                {
                                    btnEnviarAlmacen.Visible = true;
                                    btnGrabar.Visible = false;
                                }

                                if (ActivaCabeceraCaja) //261115
                                {
                                    //HabilitarCabecera();
                                    btnBuscar.Enabled = true;
                                    btnNuevoCliente.Enabled = true;
                                    cboMoneda.Enabled = false;
                                    btnGrabar.Enabled = true;
                                }

                            }
                            else
                            {
                                btnEnviarAlmacen.Visible = false;
                                btnGrabar.Visible = true;
                            }
                        }
                    }
                    #endregion


                    bNuevo = false;
                    IdSituacionModifica = objE_Pedido.IdSituacion;

                    ////Cargar Promociones ***** 2x1 --add 12/11/2015
                    //CargarProductoPromocionDosPorUno();
                    //CargarProductoPromocion3x2();
                    //CargarProductoPromocion3x1();
                    //CargarProductoPromocion4x1();
                    //CargarProductoPromocion6x3();

                }

                //Número de liberación
                if (Convert.ToInt32(objE_Pedido.NumeroLiberacion) > 0 && Parametros.intTiendaId == Parametros.intTiendaUcayali)
                {
                    bFlagModificarAlmacen = true;
                    btnNuevo.Enabled = false;
                }

                if (bFlagModificarAlmacen) //add 250116
                {
                    //if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado && Parametros.intTiendaId == Parametros.intTiendaUcayali && bFlagImpresion == true && Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacen)//add 2201
                    //{
                        if (objE_Pedido.IdSituacion == Parametros.intFacturado || objE_Pedido.IdSituacion == Parametros.intPVAnulado || objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                        {
                            //btnEditar.Enabled = false;
                            //btnEliminar.Enabled = false;
                            //btnEnviarAlmacen.Visible = false;
                        }
                        else
                        {

                            btnEditar.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnEnviarAlmacen.Visible = true;
                        }
                    //}
                }
                cboVendedor.Enabled = false;
            }
            #endregion

            #region "Consultar"
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Pedido - Consultar";

                //Carga Personal - Todos - Cesados
                BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                if (objE_Pedido != null)
                {
                    lblIdPedido.Text = objE_Pedido.IdPedido.ToString();
                    Periodo = objE_Pedido.Periodo;
                    cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                    IdTienda = objE_Pedido.IdTienda;
                    cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                    txtNumero.Text = objE_Pedido.Numero;
                    deFecha.EditValue = objE_Pedido.Fecha;
                    txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                    cboVendedor.EditValue = objE_Pedido.IdVendedor;
                    cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                    deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                    cboMoneda.EditValue = objE_Pedido.IdMoneda;
                    txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                    dmlTipoCambio = objE_Pedido.TipoCambio;
                    IdCliente = objE_Pedido.IdCliente;
                    IdTipoCliente = objE_Pedido.IdTipoCliente;
                    IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                    txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                    txtDescCliente.Text = objE_Pedido.DescCliente;
                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                    else
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                    txtDireccion.Text = objE_Pedido.Direccion;
                    cboCombo.EditValue = objE_Pedido.IdCombo;
                    cboCaja.Text = objE_Pedido.Despachar;
                    txtObservaciones.Text = objE_Pedido.Observacion;
                    txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                    txtDescuento.EditValue = objE_Pedido.PorcentajeDescuento;
                    txtSubTotal.EditValue = objE_Pedido.SubTotal;
                    txtImpuesto.EditValue = objE_Pedido.Igv;
                    txtICBPER.EditValue = objE_Pedido.Icbper;
                    txtTotal.EditValue = objE_Pedido.Total;
                    txtTotalBruto.EditValue = objE_Pedido.TotalBruto;
                    cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                    cboMotivo.EditValue = objE_Pedido.IdMotivo;
                    chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                    cboAsesor.EditValue = objE_Pedido.IdAsesor;
                    //cboAsesorExterno.EditValue = objE_Pedido.IdAsesorExterno;
                    IdAsesorExterno = objE_Pedido.IdAsesorExterno;
                    IdPedidoReferencia = objE_Pedido.IdPedidoReferencia;

                    //Carga ClienteAsociado
                    CargarClienteAsociado();
                    cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;
                    DesHabilitar();
                    DesHabilitarCabecera();
                    DesHabilitarEdition();
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnGrabar.Enabled = false;
                    mnuContextual.Enabled = false;
                    menuStrip1.Enabled = false;
                    cboTipoVenta.Enabled = false;
                    btnDelivery.Enabled = false;

                    btnEnviarAlmacen.Visible = false;

                    bNuevo = false;
                }

            }
            #endregion
            CargaPedidoDetalle();
            txtDescuento.EditValue = vDesciuento;
            txtTotalDscto2x1.EditValue = vTotalDescuento;
            txtMP.EditValue = vMp;
            cboMotivo.ReadOnly = true;
            CalculaTotales();
            CalculaTotales();
        }

        private void frmRegPedidoEdit_Shown(object sender, EventArgs e)
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
                //txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
                ////if (this.Text == "Pedido - Modificar")
                ////{
                ////    //txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
                ////    txtTipoCambio.EditValue = dmlTipoCambio;
                ////}

                if (pOperacion == Operacion.Nuevo)
                {
                    txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Venta.ToString());
                }
            }

            if (bolFlag)
            {
                this.Close();
            }
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            int intIdMoneda = 0;
            intIdMoneda = int.Parse(cboMoneda.EditValue.ToString());
            CalcularValoresGrilla(intIdMoneda);
            CalculaTotales();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);

                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    // Valida si el vendedor de piso puede vender a clientes black
                    if (frm.pClienteBE.IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal) && frm.pClienteBE.IdClasificacionCliente == Parametros.intBlack && vIdPerfilVendedorPiso == 1)
                    {
                        XtraMessageBox.Show("Usted no puede generar pedidos a clientes BLACK.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // La administradora de tienda no puede realizar pedidos a su nombre
                    if (Parametros.intPerfilId == Parametros.intPerAdministradorTienda)
                    {
                        ClienteBE objE_ClienteUsuario = null;
                        objE_ClienteUsuario = new ClienteBL().SeleccionaUsuarioNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                        if (objE_ClienteUsuario != null)
                        {
                            if (objE_ClienteUsuario.IdPerfil == Parametros.intPerfilId || objE_ClienteUsuario.IdPerfil == Parametros.intPerAdministrador)
                            {
                                XtraMessageBox.Show("Usted no puede generar pedidos a Adm. tienda/Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        }
                        else
                        { }
                    }

                    if (Parametros.intPerfilId != Parametros.intPerAdministrador)
                    {
                        if (ActivaCabeceraCaja)
                        {
                            if (IdTipoCliente != frm.pClienteBE.IdTipoCliente)
                            {
                                XtraMessageBox.Show("EL cambió de cliente no se pudo realizar Ud. está intentando cambiar un " + txtTipoCliente.Text + " a " + frm.pClienteBE.DescTipoCliente + "\nConsultar con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }
                    if (frm.pClienteBE.AbrevDomicilio == "OTR") frm.pClienteBE.AbrevDomicilio = ""; else frm.pClienteBE.AbrevDomicilio = frm.pClienteBE.AbrevDomicilio + " ";

                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                    FlagMayoristaActivo = true;

                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                        cboMoneda.EditValue = Parametros.intSoles;

                        //Calcula Cumpleaños
                        //DateTime FechaNac = Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                        DateTime FechaNac = frm.pClienteBE.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                        int PeriodoNac = FechaNac.Year;
                        int Anios = Parametros.intPeriodo - PeriodoNac;

                        //Compras del mes
                        List<DocumentoVentaBE> lstVenta = null;
                        lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, frm.pClienteBE.IdCliente);

                        if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                        {
                            lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                            bCumpleAnios = true;
                            btnEliminarCumpleanios.Visible = true;
                        }
                        else
                        {
                            lblMensaje.Text = "";
                            bCumpleAnios = false;
                            btnEliminarCumpleanios.Visible = false;
                        }

                        //Encuesta
                        EncuestaBE ObjE_Encuesta = null;
                        ObjE_Encuesta = new EncuestaBL().SeleccionaDescuento(frm.pClienteBE.IdCliente);
                        if (ObjE_Encuesta != null)
                        {
                            if (ObjE_Encuesta.FlagDescuento == false)
                            {
                                lblMensaje.Text = "-10% en Producto REGULAR x Encuesta!!!";
                                bEncuesta = true;
                                btnEliminarEncuesta.Visible = true;
                            }
                            else
                            {
                                lblMensaje.Text = "";
                                bEncuesta = false;
                                btnEliminarEncuesta.Visible = false;
                            }
                        }

                        //Cliente club Design
                        if(IdClasificacionCliente == Parametros.intClubDesign)
                            txtTipoCliente.ForeColor = Color.Fuchsia;
                        else
                            txtTipoCliente.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;

                        //Mayorista
                        //Calcula Cumpleaños
                        if (frm.pClienteBE.FechaNac != null)
                        {
                            //DateTime FechaNac = Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                            DateTime FechaNac = frm.pClienteBE.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                            int PeriodoNac = FechaNac.Year;
                            int Anios = Parametros.intPeriodo - PeriodoNac;

                            //Compras del mes
                            List<DocumentoVentaBE> lstVenta = null;
                            lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, frm.pClienteBE.IdCliente);

                            if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                            {
                                lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                            }                            
                        }

                        //-------------------------continue
                        if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                        {
                            cboMoneda.EditValue = Parametros.intSoles;
                        }
                        else
                        {
                            cboMoneda.EditValue = Parametros.intDolares;
                        }


                        ClienteBE objE_Cliente = new ClienteBE(); //add 180816
                        objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                        if (objE_Cliente.IdSituacion == Parametros.intSITClienteInactivo)//add 180816
                        {
                            FlagMayoristaActivo = false;
                            IdTipoCliente = Parametros.intTipClienteFinal;
                            txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-INACTIVO";
                            txtTipoCliente.ForeColor = Color.Red;
                            XtraMessageBox.Show("El cliente Mayorista está INACTIVO, por lo tanto, se aplicará el criterio de descuento del cliente final.\nPara más información consultar con su vendedor de cartera.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        //if (Parametros.intTiendaId != Parametros.intTiendaUcayali && Parametros.intTiendaId != Parametros.intTiendaAndahuaylas)//add 131217
                        //{
                        //    FlagMayoristaActivo = false;
                        //    IdTipoCliente = Parametros.intTipClienteFinal;
                        //    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "- P.FINAL";
                        //    txtTipoCliente.ForeColor = Color.Red;
                        //    XtraMessageBox.Show("El cliente Mayorista, sólo puede comprar en la tienda UCAYALI Y ANDAHUAYLAS, por lo tanto, se aplicará el descuento del cliente final.\nPara más información consultar con su vendedor de cartera.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //}
                    }

                    if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intCredito)
                    {
                        ClienteCreditoBE objE_ClienteCredito = null;
                        objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                        if (objE_ClienteCredito == null)
                        {
                            XtraMessageBox.Show("El cliente seleccionado no tiene una linea de crédito aprobada..por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                    objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                    if (objE_ClienteCreditoMoroso != null)
                    {
                        if (objE_ClienteCreditoMoroso.IdClasificacionCliente == Parametros.intMoroso)
                        {
                            XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente 0% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bMoroso = true;
                        }
                        else
                        {
                            bMoroso = false;
                        }
                    }

                    #region "Tipo de cambio"
                    //agregado para mostrar tipo cambio
                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack || !FlagMayoristaActivo)
                    {
                        txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMayorista).ToString();
                        if (intSeleccionaTipoCliente == 1)
                        {
                            BSUtils.LoaderLook(cboFormaPago, CargarFormaPagoClienteMayorista(), "DescTablaElemento", "IdTablaElemento", true);
                        }
                    }
                    else
                    {
                        txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMinorista).ToString();
                        if (intSeleccionaTipoCliente == 2)
                        {
                            BSUtils.LoaderLook(cboFormaPago, CargarFormaPagoClienteFinal(), "DescTablaElemento", "IdTablaElemento", true);
                        }
                    }
                    #endregion

                    //Busca si tiene preventa
                    PedidoBE objE_PedidoCliente = null;
                    objE_PedidoCliente = new PedidoBL().SeleccionaClientePreventa(Parametros.intPeriodo, IdCliente);
                    if(objE_PedidoCliente != null)
                    {
                        if (Convert.ToInt32(objE_PedidoCliente.TotalCantidad) > 0)
                        {
                            chkDescuentoExtraVenta.Visible = true;
                            chkDescuentoExtraVenta.Checked = true;
                        }
                        else
                        {
                            chkDescuentoExtraVenta.Visible = false;
                            chkDescuentoExtraVenta.Checked = false;
                        }
                    }


                    //Cliente Asociado
                    CargarClienteAsociado();  //Add
                    //if (IdCliente == Parametros.intIdClienteGeneral)
                    //{
                    //    cboClienteAsociado.Visible = false;
                    //    lblFacturara.Visible = false;
                    //}
                    //else {
                    //    cboClienteAsociado.Visible = true;
                    //    lblFacturara.Visible = true;
                    //}
                    cboFormaPago.EditValue = IdFormaPago;//add 280616
                    txtNumeroDocumento.Properties.ReadOnly = true;
                    btnNuevoCliente.Enabled = false;
                    btnNuevo.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroProforma_KeyUp(object sender, KeyEventArgs e)
        {
           //try
           // {
           //     if (e.KeyCode == Keys.Enter)
           //     {
           //         //Traemos la información de la proforma
           //         ProformaBE objE_Proforma = null;
           //         objE_Proforma = new ProformaBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim(), Parametros.intPFAprobado);
           //         if (objE_Proforma != null)
           //         {
           //             IdProforma = objE_Proforma.IdProforma;
           //             txtNumeroProforma.Text = objE_Proforma.Numero;
           //             cboVendedor.EditValue = objE_Proforma.IdVendedor;
           //             cboFormaPago.EditValue = objE_Proforma.IdFormaPago;
           //             cboMoneda.EditValue = objE_Proforma.IdMoneda;
           //             txtTipoCambio.EditValue = objE_Proforma.TipoCambio;
           //             IdCliente = objE_Proforma.IdCliente;
           //             txtNumeroDocumento.Text = objE_Proforma.NumeroDocumento;
           //             txtDescCliente.Text = objE_Proforma.DescCliente;
           //             txtTipoCliente.Text = objE_Proforma.DescTipoCliente;
           //             txtDireccion.Text = objE_Proforma.Direccion;

           //             //Tramoes la información del detalle de la proforma
           //             List<ProformaDetalleBE> lstTmpProformaDetalle = null;
           //             lstTmpProformaDetalle = new ProformaDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdProforma);
           //             int nItem = 1;
           //             foreach (ProformaDetalleBE item in lstTmpProformaDetalle)
           //             {
           //                 if (item.FlagAprobacion)
           //                 {
           //                     CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
           //                     objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
           //                     objE_PedidoDetalle.IdPedido = 0;
           //                     objE_PedidoDetalle.IdPedidoDetalle = 0;
           //                     objE_PedidoDetalle.Item = nItem;
           //                     objE_PedidoDetalle.IdProducto = item.IdProducto;
           //                     objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
           //                     objE_PedidoDetalle.NombreProducto = item.NombreProducto;
           //                     objE_PedidoDetalle.Abreviatura = item.Abreviatura;
           //                     objE_PedidoDetalle.Cantidad = item.Cantidad;
           //                     objE_PedidoDetalle.CantidadAnt = item.Cantidad;
           //                     objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
           //                     objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
           //                     objE_PedidoDetalle.Descuento = item.Descuento;
           //                     objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
           //                     objE_PedidoDetalle.ValorVenta = item.ValorVenta;
           //                     objE_PedidoDetalle.Observacion = item.Observacion;
           //                     objE_PedidoDetalle.IdKardex = 0;
           //                     objE_PedidoDetalle.FlagMuestra = false;
           //                     objE_PedidoDetalle.FlagRegalo = false;
           //                     objE_PedidoDetalle.Stock = 0;
           //                     objE_PedidoDetalle.TipoOper = item.TipoOper;
           //                     mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

           //                     nItem = nItem + 1;
           //                 }

           //             }

           //             bsListado.DataSource = mListaPedidoDetalleOrigen;
           //             gcPedidoDetalle.DataSource = bsListado;
           //             gcPedidoDetalle.RefreshDataSource();

           //             CalculaTotales();
           //         }
           //         else
           //         {
           //             XtraMessageBox.Show("Verificar que la proforma y los códigos esten aprobados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
           //         }
           //     }
           // }
           // catch (Exception ex)
           // {
           //     XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);

                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                { 
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        // Valida si el vendedor de piso puede vender a clientes black
                        if ( IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal) && objE_Cliente.IdClasificacionCliente == Parametros.intBlack && vIdPerfilVendedorPiso==1)
                        {
                            XtraMessageBox.Show("Usted no puede generar pedidos a clientes BLACK.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (Parametros.intPerfilId == Parametros.intPerAdministradorTienda)
                        {
                            ClienteBE objE_ClienteUsuario = null;
                            objE_ClienteUsuario = new ClienteBL().SeleccionaUsuarioNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                            if (objE_ClienteUsuario != null)
                            {
                                if (objE_ClienteUsuario.IdPerfil == Parametros.intPerfilId || objE_ClienteUsuario.IdPerfil == Parametros.intPerAdministrador)
                                {
                                    XtraMessageBox.Show("Usted no puede generar pedidos a Adm. tienda/Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }
                            else
                            { }
                        }

                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        //txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NumDireccion;
                        txtDireccion.Text = objE_Cliente.AbrevDomicilio + objE_Cliente.Direccion + objE_Cliente.NumDireccion;
                        IdTipoCliente = objE_Cliente.IdTipoCliente;
                        IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                        FlagMayoristaActivo = true;

                        //Bloquear Ruc
                        txtNumeroDocumento.Properties.ReadOnly = true;
                        btnNuevoCliente.Enabled = false;

                        if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                        {
                            txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                            cboMoneda.EditValue = Parametros.intSoles;

                            //Calcula Cumpleaños
                            //DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                            DateTime FechaNac = objE_Cliente.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                            int PeriodoNac = FechaNac.Year;
                            int Anios = Parametros.intPeriodo - PeriodoNac;

                            //Compras del mes
                            List<DocumentoVentaBE> lstVenta = null;
                            lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                            if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                            {
                                lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                                XtraMessageBox.Show("FELIZ CUMPLEAÑOS !!! " + FechaNac.ToShortDateString() , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bCumpleAnios = true;
                                btnEliminarCumpleanios.Visible = true;
                                //lblDsctoCumple.Visible = true;
                                //txtDsctoCumple.Visible = true;
                            }
                            else
                            {
                                lblMensaje.Text = "";
                                bCumpleAnios = false;
                                btnEliminarCumpleanios.Visible = false;
                                lblDsctoCumple.Visible = false;
                                txtDsctoCumple.Visible = false;
                            }

                            //Encuesta
                            EncuestaBE ObjE_Encuesta = null;
                            ObjE_Encuesta = new EncuestaBL().SeleccionaDescuento(objE_Cliente.IdCliente);
                            if (ObjE_Encuesta != null)
                            {
                                if (ObjE_Encuesta.FlagDescuento == false)
                                {
                                    lblMensaje.Text = "-10% en Producto REGULAR x Encuesta!!!";
                                    bEncuesta = true;
                                    btnEliminarEncuesta.Visible = true;
                                }
                            }
                            else
                            {
                                lblMensaje.Text = "";
                                bEncuesta = false;
                                btnEliminarEncuesta.Visible = false;
                            }

                            //Club Design
                            if (IdClasificacionCliente == Parametros.intClubDesign)
                                txtTipoCliente.ForeColor = Color.Fuchsia;
                            else
                                txtTipoCliente.ForeColor = Color.Black;
                        }
                        else
                        {
                            txtTipoCliente.Text = objE_Cliente.DescTipoCliente;

                            //Mayorista Inactivo --> aplica los mismos dsctos que el cliente final.
                            if (objE_Cliente.IdSituacion == Parametros.intSITClienteInactivo)//add 180816
                            {
                                FlagMayoristaActivo = false;
                                IdTipoCliente = Parametros.intTipClienteFinal;
                                txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-INACTIVO";
                                txtTipoCliente.ForeColor = Color.Red;
                                XtraMessageBox.Show("El cliente Mayorista está INACTIVO, por lo tanto, se aplicará el descuento del cliente final.\nPara más información consultar con su vendedor de cartera.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            //if (Parametros.intTiendaId != Parametros.intTiendaUcayali && Parametros.intTiendaId != Parametros.intTiendaAndahuaylas)//add 131217
                            //{
                            //    FlagMayoristaActivo = false;
                            //    IdTipoCliente = Parametros.intTipClienteFinal;
                            //    txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "- P.FINAL";
                            //    txtTipoCliente.ForeColor = Color.Red;
                            //    XtraMessageBox.Show("El cliente Mayorista, sólo puede comprar en la tienda UCAYALI Y ANDAHUAYLAS, por lo tanto, se aplicará el descuento del cliente final.\nPara más información consultar con su vendedor de cartera.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //}



                            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                            {
                                cboMoneda.EditValue = Parametros.intSoles;
                            }
                            else
                            {
                                cboMoneda.EditValue = Parametros.intDolares;
                            }
                        }

                        if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intCredito)
                        {
                            CargarSaldoDisponible();
                            ClienteCreditoBE objE_ClienteCredito = null;
                            objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente,Convert.ToInt32(cboMotivo.EditValue));
                            if (objE_ClienteCredito == null)
                            {
                                XtraMessageBox.Show("El cliente seleccionado no tiene una linea de crédito aprobada..por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                        ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                        objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                        if (objE_ClienteCreditoMoroso != null)
                        {
                            if (objE_ClienteCreditoMoroso.IdClasificacionCliente == Parametros.intMoroso)
                            {
                                XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente 0% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bMoroso = true;
                            }
                            else
                            {
                                bMoroso = false;
                            }
                        }

                        //////---------------------------------------------------
                        //agregado para mostrar tipo cambio
                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack || !FlagMayoristaActivo)
                        {
                            txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMayorista).ToString();
                            BSUtils.LoaderLook(cboFormaPago, CargarFormaPagoClienteMayorista(), "DescTablaElemento", "IdTablaElemento", true);
                            //FlagPromocion2x1 = true;
                        }
                        else
                        {
                            txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMinorista).ToString();
                            BSUtils.LoaderLook(cboFormaPago, CargarFormaPagoClienteFinal(), "DescTablaElemento", "IdTablaElemento", true);
                            ////// //FlagPromocion2x1 = true;

                            //txtTipoCambio.Text = Convert.ToDecimal(Parametros.dmlTCMayorista).ToString();
                            //BSUtils.LoaderLook(cboFormaPago, CargarFormaPagoClienteMayorista(), "DescTablaElemento", "IdTablaElemento", true);
                            //FlagPromocion2x1 = true;
                        }

                        //Busca si tiene preventa
                        PedidoBE objE_PedidoCliente = null;
                        objE_PedidoCliente = new PedidoBL().SeleccionaClientePreventa(Parametros.intPeriodo, IdCliente);
                        if(objE_PedidoCliente != null)
                        {
                            if (Convert.ToInt32(objE_PedidoCliente.TotalCantidad) > 0)
                            {
                                chkDescuentoExtraVenta.Visible = true;
                                chkDescuentoExtraVenta.Checked = true;
                            }
                            else
                            {
                                chkDescuentoExtraVenta.Visible = false;
                                chkDescuentoExtraVenta.Checked = false;
                            }
                        }

                        //Cliente Asociado
                        CargarClienteAsociado();  //Add
                        cboFormaPago.EditValue = IdFormaPago; //add 280616
                        btnNuevo.Focus();
                        //////---------------------------------------------------
                    }
                    else
                    {
                        if (XtraMessageBox.Show("El cliente no existe, desea registrar al nuevo cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            btnNuevoCliente_Click(sender, e);
                        }
                        //XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }else
                {
                    btnBuscar_Click(sender,e);
                }
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                //objManClientel.lstCliente = mLista;
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0,2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito  + '-' + objManCliente.DescProvincia  + '-' +  objManCliente.DescDepartamento;//add
                    txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;

                        //Calcula Cumpleaños
                        DateTime FechaNac = objE_Cliente.FechaNac == null? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        if(FechaNac == null)
                        {
                            int PeriodoNac = FechaNac.Year;
                            int Anios = Parametros.intPeriodo - PeriodoNac;

                            //Compras del mes
                            List<DocumentoVentaBE> lstVenta = null;
                            lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                            if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                            {
                                lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                                bCumpleAnios = true;
                            }
                            else
                            {
                                bCumpleAnios = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFormaPago_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (cboFormaPago.EditValue != null)
                {
                    gcSaldoDisponible.Visible = false;
                    DateTime dt = Convert.ToDateTime(deFecha.EditValue);
                    switch (Convert.ToInt32(cboFormaPago.EditValue))
                    {
                        case 61:
                            cboMoneda.EditValue = Parametros.intSoles;  //Contado
                            cboMoneda.Enabled = false;
                            cboCaja.EditValue = 6;
                            break;
                        case 62:  //Credito
                            cboMoneda.EditValue = Parametros.intDolares;
                            cboMoneda.Enabled = false;
                            cboCaja.EditValue = 10;
                            CargarSaldoDisponible();
                            break;
                        case 68:  //Contraentrega
                            if (IdTipoCliente == Parametros.intTipClienteMayorista || !FlagMayoristaActivo || IdClasificacionCliente == Parametros.intBlack)
                            {
                                cboMoneda.Enabled = false;
                                cboMoneda.EditValue = Parametros.intDolares;
                                cboCaja.EditValue = 10;
                            }
                            else
                            {
                                cboMoneda.Enabled = true;
                                cboMoneda.EditValue = Parametros.intSoles;
                                cboCaja.EditValue = 10;
                            }
                            break;
                        case 69:  //Copagan
                            if (IdTipoCliente == Parametros.intTipClienteMayorista || !FlagMayoristaActivo || IdClasificacionCliente == Parametros.intBlack)
                            {
                                cboMoneda.Enabled = false;
                                cboMoneda.EditValue = Parametros.intDolares;
                                cboCaja.EditValue = 10;
                            }
                            else
                            {
                                cboMoneda.Enabled = true;
                                cboMoneda.EditValue = Parametros.intSoles;
                                cboCaja.EditValue = 10;
                            }
                            break;
                        default:
                            cboMoneda.Enabled = true;
                            cboCaja.EditValue = 10;
                            break;
                    }
                }
            }
            else
            {
                //if (Parametros.intPerfilId != Parametros.intPerAdministrador)
                //{
                    PedidoBE ObjE_Pedido = new PedidoBE(); //add 17056
                    ObjE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    cboFormaPago.EditValue = ObjE_Pedido.IdFormaPago;
                    //XtraMessageBox.Show("No se puede cambiar la forma de Pago, Ud. Tiene que eliminar este pedido y crear uno nuevo.\nPor favor consultar con su administrador ó auditor.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cboFormaPago.Enabled = false;
                //}
            }


        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToInt32(cboFormaPago.EditValue)!=Parametros.intContado)
                {
                    if(IdCliente==Parametros.intIdClienteGeneral)
                    {
                        XtraMessageBox.Show("No se puede generar "+ cboFormaPago.Text +" como CLIENTE GENERAL, Consultar con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (gvPedidoDetalle.RowCount == 0)//ant 12/11
                {
                    if (IdTipoCliente == Parametros.intTipClienteMayorista && Parametros.intPerfilId == Parametros.intGestorCartera)//add 270616
                    {
                        if (Convert.ToInt32(cboTipoVenta.EditValue) == 0)
                        {
                            XtraMessageBox.Show("Sr(a). Gestor de Cartera, Seleccionar como captó esta venta?", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboTipoVenta.Select();
                            return;
                        }
                    }
                    
                    //CargarProductoPromocionDosPorUno(); //Dos por uno 
                    //CargarProductoPromocion3x2(); //3x2W
                    //CargarProductoPromocion3x1();
                    //CargarProductoPromocion4x1();
                    //CargarProductoPromocion6x3(); //6x3
                }
                int IdAlmacenOrigen = 0;

                frmRegPedidoDetalleEdit movDetalle = new frmRegPedidoDetalleEdit();
                int i = 0;
                if (mListaPedidoDetalleOrigen.Count > 0)
                    i = mListaPedidoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                        movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                        movDetalle.IdTipoCliente = IdTipoCliente;
                        movDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);//add 23 jun 15
                        movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                        movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        movDetalle.bPreVenta = chkPreventa.Checked;
                        movDetalle.bDescuentoCumpleanio = bCumpleAnios;
                        movDetalle.bDescuentoEncuesta = bEncuesta;
                        movDetalle.IdPedido = IdPedido;
                        movDetalle.PorcentajeDescuentoClientePromocion = DescuentoClientePromocion;
                        movDetalle.IdDescuentoClientePromocion = IdDescuentoClientePromocion;
                        movDetalle.ItemsDescuentoPromocion = ItemsDescuentoPromocion;
                        movDetalle.OrigenNuevo = OrigenNuevo;
                        movDetalle.DescuentoVale = DescuentoVale;
                        movDetalle.IdTipoVenta = Convert.ToInt32(cboTipoVenta.EditValue);
                        movDetalle.pOperacion = frmRegPedidoDetalleEdit.Operacion.Nuevo; //Add 07/07/15

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (movDetalle.mListaStock.Count > 0 )
                        {
                            #region "Ingreso de Varios Almacenes"
                            if (movDetalle.oBE.Cantidad <= 0)
                            {
                                return;
                            }

                            foreach (var item in movDetalle.mListaStock)
                            {
                                if (item.CantidadPedida > 0)
                                {
                                    IdAlmacenOrigen = item.IdAlmacen;

                                    if (mListaPedidoDetalleOrigen.Count == 0)
                                    {
                                        #region "NS de otros almacenes"
                                        //Verificar NS de Otros Almacenes
                                        if (Parametros.intAlmCentralUcayali != item.IdAlmacen)
                                        {
                                            if (Parametros.intTiendaId == Parametros.intTiendaUcayali) //Ucayali
                                            {
                                                if (item.IdAlmacen != Parametros.intAlmTiendaUcayali)
                                                {
                                                    CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                                                    objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                                                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                                                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                                                    objE_MovimientoAlmacenDetalle.Item = 1;
                                                    objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                                                    objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                                                    objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                                                    objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                                                    objE_MovimientoAlmacenDetalle.Cantidad = item.CantidadPedida;
                                                    objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                                                    objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                                                    objE_MovimientoAlmacenDetalle.MontoTotal = 0;
                                                    objE_MovimientoAlmacenDetalle.Stock = 0;
                                                    objE_MovimientoAlmacenDetalle.Observacion = "Pedido";
                                                    objE_MovimientoAlmacenDetalle.IdAlmacen = item.IdAlmacen;
                                                    objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                                                    objE_MovimientoAlmacenDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                                                    mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);

                                                    //Setear Almacén de Tienda
                                                    item.IdAlmacen = Parametros.intAlmCentralUcayali;
                                                }
                                            }
                                            else
                                            {
                                                CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                                                objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                                                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                                                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                                                objE_MovimientoAlmacenDetalle.Item = 1;
                                                objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                                                objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                                                objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                                                objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                                                objE_MovimientoAlmacenDetalle.Cantidad = item.CantidadPedida;
                                                objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                                                objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                                                objE_MovimientoAlmacenDetalle.MontoTotal = 0;
                                                objE_MovimientoAlmacenDetalle.Stock = 0;
                                                objE_MovimientoAlmacenDetalle.Observacion = "Pedido";
                                                objE_MovimientoAlmacenDetalle.IdAlmacen = item.IdAlmacen;
                                                objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                                                objE_MovimientoAlmacenDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                                                mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);

                                                //Setear Almacén de Tienda
                                                item.IdAlmacen = Parametros.intAlmCentralUcayali;
                                            }
                                        }
                                        #endregion

                                        bool FlagMuestra = false;
                                        if (item.IdAlmacen == Parametros.intAlmTiendaUcayali)
                                        {
                                            FlagMuestra = true;
                                        }
                                        string Asterisco = "";
                                        if (item.FlagAutoservicio) Asterisco = "(*)";

                                        gvPedidoDetalle.AddNewRow();
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", movDetalle.oBE.IdPedido);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", movDetalle.oBE.IdPedidoDetalle);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto",Asterisco + movDetalle.oBE.NombreProducto);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", item.CantidadPedida); //movDetalle.oBE.Cantidad);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);//movDetalle.oBE.CantidadAnt);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.PrecioVenta * item.CantidadPedida);//movDetalle.oBE.ValorVenta);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "(" + item.AbrevAlmacen + ")" + item.Observacion);//movDetalle.oBE.Observacion
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", item.IdAlmacen);//movDetalle.oBE.IdAlmacen);//add
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", IdAlmacenOrigen);//movDetalle.oBE.IdAlmacen);//add
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);//movDetalle.oBE.IdAlmacen);//add
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", FlagMuestra);//movDetalle.oBE.FlagMuestra);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagBultoCerrado", movDetalle.oBE.FlagBultoCerrado);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagNacional", movDetalle.oBE.FlagNacional);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "DescPromocion", movDetalle.oBE.DescPromocion);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                        //gvPedidoDetalle.UpdateCurrentRow();

                                        ////Producto Outlet Add 030517
                                        if (IdAlmacenOrigen == Parametros.intAlmOutlet)
                                        {
                                            if (movDetalle.DescuentoOutlet > item.Descuento)
                                            {
                                                decimal decPrecioVentaOT = 0;
                                                decimal decValorVentaOT = 0;

                                                decPrecioVentaOT = movDetalle.oBE.PrecioUnitario * ((100 - movDetalle.DescuentoOutlet) / 100);
                                                decValorVentaOT = Math.Round(decPrecioVentaOT, 2) * item.CantidadPedida;
                                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.DescuentoOutlet);
                                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", decPrecioVentaOT);
                                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", decValorVentaOT);
                                            }
                                        }
                                        gvPedidoDetalle.UpdateCurrentRow();

                                        bNuevo = movDetalle.bNuevo;

                                        //Armado
                                        if (movDetalle.oBE.IdProductoArmado > 0)
                                        {
                                            if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                CargarProductoArmado(movDetalle.oBE.IdProductoArmado, movDetalle.oBE.Cantidad);
                                            }
                                        }

                                        //ProductoAsociado
                                        if (movDetalle.oBE.FlagCompuesto)
                                        {
                                            CargarProductoAsociado(movDetalle.oBE.IdProducto, item.IdAlmacen, item.CantidadPedida, movDetalle.oBE.CodAfeIGV);
                                            XtraMessageBox.Show("Se agregó el complemento, obtenido del mismo almacén del producto origen.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }


                                        if(movDetalle.oBE.DescPromocion.Length>0) //add 15122019
                                        {
                                            FlagPromocion2x1 = true;
                                            AsignarCodigoPromocion();//ADD 20 MAY 2015
                                        }
                                        CalculaTotales();

                                        btnNuevo.Focus();

                                        //return;

                                    }else
                                    {
                                        var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto && oB.IdAlmacen == item.IdAlmacen).ToList();
                                        if (Buscar.Count > 0)
                                        {
                                            XtraMessageBox.Show("El código de producto ya existe, No se permiten duplicados de un almacén", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        #region "Ns de Otros Almacenes"
                                        //Verificar NS de Otros Almacenes
                                        if (Parametros.intAlmCentralUcayali != item.IdAlmacen)
                                        {
                                            if (Parametros.intTiendaId == Parametros.intTiendaUcayali) //Ucayali
                                            {
                                                if (item.IdAlmacen != Parametros.intAlmTiendaUcayali)
                                                {
                                                    CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                                                    objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                                                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                                                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                                                    objE_MovimientoAlmacenDetalle.Item = 1;
                                                    objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                                                    objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                                                    objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                                                    objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                                                    objE_MovimientoAlmacenDetalle.Cantidad = item.CantidadPedida;
                                                    objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                                                    objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                                                    objE_MovimientoAlmacenDetalle.MontoTotal = 0;
                                                    objE_MovimientoAlmacenDetalle.Stock = 0;
                                                    objE_MovimientoAlmacenDetalle.Observacion = "Pedido";
                                                    objE_MovimientoAlmacenDetalle.IdAlmacen = item.IdAlmacen;
                                                    objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                                                    objE_MovimientoAlmacenDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                                                    mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);

                                                    //Setear Almacén de Tienda
                                                    item.IdAlmacen = Parametros.intAlmCentralUcayali;
                                                }
                                            }
                                            else
                                            {
                                                CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                                                objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                                                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                                                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                                                objE_MovimientoAlmacenDetalle.Item = 1;
                                                objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                                                objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                                                objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                                                objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                                                objE_MovimientoAlmacenDetalle.Cantidad = item.CantidadPedida;
                                                objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                                                objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                                                objE_MovimientoAlmacenDetalle.MontoTotal = 0;
                                                objE_MovimientoAlmacenDetalle.Stock = 0;
                                                objE_MovimientoAlmacenDetalle.Observacion = "Pedido";
                                                objE_MovimientoAlmacenDetalle.IdAlmacen = item.IdAlmacen;
                                                objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                                                objE_MovimientoAlmacenDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                                                mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);

                                                //Setear Almacén de Tienda
                                                item.IdAlmacen = Parametros.intAlmCentralUcayali;
                                            }
                                        }
                                        #endregion


                                        bool FlagMuestra = false;
                                        if (item.IdAlmacen == Parametros.intAlmTiendaUcayali)
                                        {
                                            FlagMuestra = true;
                                        }
                                        string Asterisco = "";
                                        if (item.FlagAutoservicio) Asterisco = "(*)";

                                        gvPedidoDetalle.AddNewRow();
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", movDetalle.oBE.IdPedido);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", movDetalle.oBE.IdPedidoDetalle);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto",Asterisco + movDetalle.oBE.NombreProducto);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", item.CantidadPedida); //movDetalle.oBE.Cantidad);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);//movDetalle.oBE.CantidadAnt);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.PrecioVenta * item.CantidadPedida);//movDetalle.oBE.ValorVenta);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "(" + item.AbrevAlmacen + ")" + item.Observacion);//movDetalle.oBE.Observacion
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", item.IdAlmacen);//movDetalle.oBE.IdAlmacen);//add
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", IdAlmacenOrigen);//movDetalle.oBE.IdAlmacen);//add
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);//movDetalle.oBE.IdAlmacen);//add
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", FlagMuestra);//movDetalle.oBE.FlagMuestra);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagBultoCerrado", movDetalle.oBE.FlagBultoCerrado);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagNacional", movDetalle.oBE.FlagNacional);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "DescPromocion", movDetalle.oBE.DescPromocion);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                                        gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                        //gvPedidoDetalle.UpdateCurrentRow();

                                        ////Producto Outlet Add 030517
                                        if (IdAlmacenOrigen == Parametros.intAlmOutlet)
                                        {
                                            if (movDetalle.DescuentoOutlet > item.Descuento)
                                            {
                                                decimal decPrecioVentaOT = 0;
                                                decimal decValorVentaOT = 0;

                                                decPrecioVentaOT = movDetalle.oBE.PrecioUnitario * ((100 - movDetalle.DescuentoOutlet) / 100);
                                                decValorVentaOT = Math.Round(decPrecioVentaOT, 2) * item.CantidadPedida;
                                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.DescuentoOutlet);
                                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", decPrecioVentaOT);
                                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", decValorVentaOT);
                                            }
                                        }
                                        gvPedidoDetalle.UpdateCurrentRow();

                                        bNuevo = movDetalle.bNuevo;

                                        //Armado
                                        if (movDetalle.oBE.IdProductoArmado > 0)
                                        {
                                            if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                CargarProductoArmado(movDetalle.oBE.IdProductoArmado, movDetalle.oBE.Cantidad);
                                            }
                                        }

                                        //ProductoAsociado
                                        if (movDetalle.oBE.FlagCompuesto)
                                        {
                                            CargarProductoAsociado(movDetalle.oBE.IdProducto, item.IdAlmacen, item.CantidadPedida, movDetalle.oBE.CodAfeIGV);
                                            XtraMessageBox.Show("Se agregó el complemento, obtenido del mismo almacén del producto origen.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                        if (movDetalle.oBE.DescPromocion.Length > 0) //add 15122019
                                        {
                                            FlagPromocion2x1 = true;
                                            AsignarCodigoPromocion();//ADD 20 MAY 2015
                                        }
                                        CalculaTotales();

                                        btnNuevo.Focus();
                                    }
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            #region "Ingreso de un ALmacen"
                            if (movDetalle.oBE.Cantidad <= 0)
                            {
                                return;
                            }

                            if (chkPreventa.Checked == false)//add By Preventa
                            {
                                StockBE objE_Stock = null;
                                objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Convert.ToInt32(movDetalle.oBE.IdAlmacen), movDetalle.oBE.IdProducto);

                                if (objE_Stock != null)
                                {
                                    if (movDetalle.oBE.Cantidad > objE_Stock.Cantidad)
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }                            
                            }

                            if (mListaPedidoDetalleOrigen.Count == 0)
                            {
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", movDetalle.oBE.IdPedido);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", movDetalle.oBE.IdPedidoDetalle);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Medida", movDetalle.oBE.Medida);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", movDetalle.oBE.IdAlmacen);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagBultoCerrado", movDetalle.oBE.FlagBultoCerrado);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagNacional", movDetalle.oBE.FlagNacional);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "DescPromocion", movDetalle.oBE.DescPromocion);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();

                                bNuevo = movDetalle.bNuevo;

                                //Armado
                                if (movDetalle.oBE.IdProductoArmado > 0)
                                {
                                    if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        CargarProductoArmado(movDetalle.oBE.IdProductoArmado, movDetalle.oBE.Cantidad);
                                    }
                                }

                                //ProductoAsociado
                                if (movDetalle.oBE.FlagCompuesto)
                                {
                                    CargarProductoAsociado(movDetalle.oBE.IdProducto, Convert.ToInt32(movDetalle.oBE.IdAlmacen), movDetalle.oBE.Cantidad, movDetalle.oBE.CodAfeIGV);
                                    XtraMessageBox.Show("Se agregó el complemento, obtenido del mismo almacén del producto origen.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                if (movDetalle.oBE.DescPromocion.Length > 0) //add 15122019
                                {
                                    FlagPromocion2x1 = true;
                                    AsignarCodigoPromocion();//ADD 20 MAY 2015
                                }
                                CalculaTotales();//Estamos varificando el error

                                btnNuevo.Focus();

                                //Grabar Detalle - Reservar Stock 28/07/2015
                                if (Parametros.bValidarStockDetallePedido == true)
                                {
                                    if (chkPreventa.Checked == false)
                                    {
                                        GrabarDesdeDetalle();
                                        CargaPedidoDetalle();

                                        if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)//add 1708
                                        {
                                            btnEnviarAlmacen.Visible = true;
                                            btnGrabar.Visible = false;
                                        }
                                        else
                                        {
                                            btnEnviarAlmacen.Visible = false;
                                            btnGrabar.Visible = true;
                                        }

                                    }
                                }
                               return;
                            }
                            if (mListaPedidoDetalleOrigen.Count > 0)
                            {
                                var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", movDetalle.oBE.IdPedido);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", movDetalle.oBE.IdPedidoDetalle);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Medida", movDetalle.oBE.Medida);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", movDetalle.oBE.IdAlmacen);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagBultoCerrado", movDetalle.oBE.FlagBultoCerrado);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagNacional", movDetalle.oBE.FlagNacional);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "DescPromocion", movDetalle.oBE.DescPromocion);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();

                                bNuevo = movDetalle.bNuevo;

                                //Armado
                                if (movDetalle.oBE.IdProductoArmado > 0)
                                {
                                    if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        CargarProductoArmado(movDetalle.oBE.IdProductoArmado, movDetalle.oBE.Cantidad);
                                    }
                                }

                                //ProductoAsociado
                                if (movDetalle.oBE.FlagCompuesto)
                                {
                                    CargarProductoAsociado(movDetalle.oBE.IdProducto, Convert.ToInt32(movDetalle.oBE.IdAlmacen), movDetalle.oBE.Cantidad, movDetalle.oBE.CodAfeIGV);
                                    //XtraMessageBox.Show("Este producto está Compuesto por Otro Código, se agregó el código Complemento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    XtraMessageBox.Show("Se agregó el complemento, obtenido del mismo almacén del producto origen.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                if (movDetalle.oBE.DescPromocion.Length > 0) //add 15122019
                                {
                                    FlagPromocion2x1 = true;
                                    AsignarCodigoPromocion();//ADD 20 MAY 2015
                                }
                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                            #endregion                        
                        }
                    }

                    //Grabar Detalle - Reservar Stock
                    if (Parametros.bValidarStockDetallePedido == true)
                    {
                        if (chkPreventa.Checked == false)
                        {
                            GrabarDesdeDetalle();
                            CargaPedidoDetalle();

                            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)//add 1708
                            {
                                btnEnviarAlmacen.Visible = true;
                                btnGrabar.Visible = false;
                            }
                            else
                            {
                                btnEnviarAlmacen.Visible = false;
                                btnGrabar.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaPedidoDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegPedidoDetalleEdit movDetalle = new frmRegPedidoDetalleEdit();
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);//add 23 jun 15
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.bPreVenta = chkPreventa.Checked; //ADD
                movDetalle.PorcentajeDescuentoClientePromocion = DescuentoClientePromocion;

                movDetalle.IdPedido = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("IdPedido"));
                movDetalle.IdPedidoDetalle = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("IdPedidoDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvPedidoDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPedidoDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPedidoDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.Stock = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.txtObservacion.Text = gvPedidoDetalle.GetFocusedRowCellValue("Observacion").ToString();
                movDetalle.chkMuestra.Checked = bool.Parse(gvPedidoDetalle.GetFocusedRowCellValue("FlagMuestra").ToString());
                //movDetalle.IdKardex = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("IdKardex"));
                movDetalle.IdAlmacen = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("IdAlmacen"));
                movDetalle.PorcentajeDescuentoInicial =Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("PorcentajeDescuentoInicial"));
                movDetalle.CantidadModificada = Convert.ToInt32(gvPedidoDetalle.GetFocusedRowCellValue("Cantidad"));//Add
                movDetalle.bNuevo = false;
                movDetalle.txtCodigo.Properties.ReadOnly = true;
                movDetalle.FlagPromocion2x1 = FlagPromocion2x1;
                if (btnNuevo.Enabled == false) movDetalle.FlagAumentarCantidad = false;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPedidoDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPedidoDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPedidoDetalle.SetRowCellValue(xposition, "IdPedido", movDetalle.oBE.IdPedido);
                        gvPedidoDetalle.SetRowCellValue(xposition, "IdPedidoDetalle", movDetalle.oBE.IdPedidoDetalle);
                        gvPedidoDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvPedidoDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvPedidoDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvPedidoDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvPedidoDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvPedidoDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvPedidoDetalle.SetRowCellValue(xposition, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                        gvPedidoDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvPedidoDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvPedidoDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvPedidoDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvPedidoDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvPedidoDetalle.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        //gvPedidoDetalle.SetRowCellValue(xposition, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                        //gvPedidoDetalle.SetRowCellValue(xposition, "IdKardex", movDetalle.oBE.IdKardex);
                        gvPedidoDetalle.SetRowCellValue(xposition, "IdAlmacen", movDetalle.oBE.IdAlmacen);
                        gvPedidoDetalle.SetRowCellValue(xposition, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                        gvPedidoDetalle.SetRowCellValue(xposition, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                        //gvPedidoDetalle.SetRowCellValue(xposition, "FlagBultoCerrado", movDetalle.oBE.FlagBultoCerrado);
                        gvPedidoDetalle.SetRowCellValue(xposition, "Stock", 0);
                        gvPedidoDetalle.SetRowCellValue(xposition, "PrecioUnitarioInicial", 0);
                        gvPedidoDetalle.SetRowCellValue(xposition, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                        gvPedidoDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPedidoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPedidoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPedidoDetalle.UpdateCurrentRow();

                        bNuevo = movDetalle.bNuevo;

                        foreach (var item in mListaPedidoDetalleOrigen) //add only Halloween
                        {
                            //Código de obsequio  --add only by Halloween
                            #region "Halloween"
                            
                            if (item.IdProducto == 84652)
                            {
                                if (Convert.ToDecimal(txtTotal.EditValue) <= 180)
                                {
                                    item.Cantidad = 1;
                                    item.CodAfeIGV = Parametros.strGravadoOnerosa;
                                    item.PorcentajeDescuento = 0;
                                    item.Descuento = 0;
                                    item.PrecioUnitario = 4m;
                                    item.PrecioVenta = 4m;
                                    item.ValorVenta = 4m;
                                }
                                else
                                {
                                    item.Cantidad = 1;
                                    item.CodAfeIGV = Parametros.strGravadoEntregaTrabajadores;
                                    item.PorcentajeDescuento = 100;
                                    item.Descuento = 0;
                                    item.PrecioUnitario = 4m;
                                    item.PrecioVenta = 0m;
                                    item.ValorVenta = 0m;
                                }
                            }
                            #endregion
                        }

                        //AsignarCodigoPromocion();//add may 2 || mod. 201115
                        CalculaTotales();

                        //Grabar Detalle - Reservar Stock -- aDD 180815
                        if (Parametros.bValidarStockDetallePedido == true)
                        {
                            if (chkPreventa.Checked == false)
                            {
                                GrabarDesdeDetalle();
                                CargaPedidoDetalle();

                                if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)//add 1708
                                {
                                    btnEnviarAlmacen.Visible = true;
                                    btnGrabar.Visible = false;
                                }
                                else
                                {
                                    btnEnviarAlmacen.Visible = false;
                                    btnGrabar.Visible = true;
                                }
                            }
                        }

                        //add by almacen 250116
                        if (bFlagModificarAlmacen)
                        {
                            //DesHabilitarCabecera();
                            DesHabilitar();
                        }

                        btnNuevo.Focus();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPedidoDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPedidoDetalle = 0;
                        if (gvPedidoDetalle.GetFocusedRowCellValue("IdPedidoDetalle") != null)
                            IdPedidoDetalle = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdPedidoDetalle").ToString());
                        int Item = 0;
                        if (gvPedidoDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("Item").ToString());
                        PedidoDetalleBE objBE_PedidoDetalle = new PedidoDetalleBE();
                        objBE_PedidoDetalle.IdPedidoDetalle = IdPedidoDetalle;
                        objBE_PedidoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_PedidoDetalle.IdTienda = Parametros.intTiendaId;
                        objBE_PedidoDetalle.Periodo = Parametros.intPeriodo;
                        objBE_PedidoDetalle.Numero = txtNumero.Text;
                        objBE_PedidoDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objBE_PedidoDetalle.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objBE_PedidoDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objBE_PedidoDetalle.IdProducto = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                        objBE_PedidoDetalle.Cantidad = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("Cantidad").ToString());
                        //objBE_PedidoDetalle.IdAlmacen = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdAlmacen").ToString());
                        objBE_PedidoDetalle.IdAlmacen = gvPedidoDetalle.GetFocusedRowCellValue("IdAlmacen") == null ? (Int32?)null : int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdAlmacen").ToString());//Almacen
                        objBE_PedidoDetalle.IdAlmacenOrigen = gvPedidoDetalle.GetFocusedRowCellValue("IdAlmacenOrigen") == null ? (Int32?)null : int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdAlmacenOrigen").ToString());
                        objBE_PedidoDetalle.IdMovimientoAlmacenDetalle = gvPedidoDetalle.GetFocusedRowCellValue("IdMovimientoAlmacenDetalle") == null ? (Int32?)null : int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdMovimientoAlmacenDetalle").ToString());
                        objBE_PedidoDetalle.FlagPreventa = chkPreventa.Checked;
                        objBE_PedidoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_PedidoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                        objBL_PedidoDetalle.Elimina(objBE_PedidoDetalle);
                        gvPedidoDetalle.DeleteRow(gvPedidoDetalle.FocusedRowHandle);
                        gvPedidoDetalle.RefreshData();

                        //RegeneraItem
                        int i = 0;
                        int cuenta = 0;
                        foreach (var item in mListaPedidoDetalleOrigen)
                        {
                            item.Item = Convert.ToInt32(cuenta + 1);
                            cuenta++;
                            i++;

                            //Código de obsequio  --add only by Halloween
                            #region "Halloween"

                            if (item.IdProducto == 84652)
                            {
                                if (Convert.ToDecimal(txtTotal.EditValue) <= 180)
                                {
                                    item.Cantidad = 1;
                                    item.CodAfeIGV = Parametros.strGravadoOnerosa;
                                    item.PorcentajeDescuento = 0;
                                    item.Descuento = 0;
                                    item.PrecioUnitario = 4m;
                                    item.PrecioVenta = 4m;
                                    item.ValorVenta = 4m;
                                }
                                else
                                {
                                    item.Cantidad = 1;
                                    item.CodAfeIGV = Parametros.strGravadoEntregaTrabajadores;
                                    item.PorcentajeDescuento = 100;
                                    item.Descuento = 0;
                                    item.PrecioUnitario = 4m;
                                    item.PrecioVenta = 0m;
                                    item.ValorVenta = 0m;
                                }
                            }
                            #endregion
                        }

                        //Actualizar detalle 
                        if (Parametros.bValidarStockDetallePedido == true) //280715
                        {
                            if (chkPreventa.Checked == false)
                            {
                                GrabarDesdeDetalle();
                                CargaPedidoDetalle();
                            }
                        }


                        //add by almacen 250116
                        if (bFlagModificarAlmacen)
                        {
                            //DesHabilitarCabecera();
                            DesHabilitar();
                        }
                    }
                    else
                    {
                        gvPedidoDetalle.DeleteRow(gvPedidoDetalle.FocusedRowHandle);
                        gvPedidoDetalle.RefreshData();
                    }
                }

                CalculaTotales();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void establecerdescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "rtapia" || Parametros.strUsuarioLogin == "dsalinas"
                || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerHelpDesk || 
                Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.strUsuarioLogin.ToUpper() == "EVALDEZ" || Parametros.intPerfilId == Parametros.intPerAsistenteCompras)
                {
                frmEstablecerDescuento objDescuento = new frmEstablecerDescuento();
                objDescuento.StartPosition = FormStartPosition.CenterParent;
                if (objDescuento.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < gvPedidoDetalle.SelectedRowsCount; i++)
                    {
                        //Codigo de Promoción
                        //agregar aqui validación 

                        decimal decDescuento = 0;
                        decimal decPrecioVenta = 0;
                        decimal decValorVenta = 0;
                        decimal DescuentoAnterior = 0;

                        int row = gvPedidoDetalle.GetSelectedRows()[i];
                        DescuentoAnterior = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PorcentajeDescuento").ToString());
                        decDescuento = decimal.Parse(objDescuento.Descuento.ToString());
                        if(Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intObsequio)
                        {
                            if(decDescuento == 100)
                            {
                                XtraMessageBox.Show("No se puede asignar 100% de descuento a un obsequio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                gvPedidoDetalle.SetRowCellValue(row, "CodAfeIGV", Parametros.strGravadoEntregaTrabajadores);
                            }
                        }else
                        {
                            if (decDescuento == 100)
                                gvPedidoDetalle.SetRowCellValue(row, "CodAfeIGV", Parametros.strGravadoBonificaciones);
                            else
                                gvPedidoDetalle.SetRowCellValue(row, "CodAfeIGV", Parametros.strGravadoOnerosa);
                        }
                        gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);

                        decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
                        gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                        gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);



                        //add 06 Nov 15
                        int IdProducto = 0;
                        decimal PrecioUnitario = 0;

                        TempDescuentoVentaProductoBL objBL_TempDescuento = new TempDescuentoVentaProductoBL();
                        TempDescuentoVentaProductoBE objTempDescuento = new TempDescuentoVentaProductoBE();

                        IdProducto = int.Parse(gvPedidoDetalle.GetRowCellValue(row, "IdProducto").ToString());
                        PrecioUnitario = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString());

                        objTempDescuento.IdTienda = Parametros.intTiendaId;
                        objTempDescuento.IdProducto = IdProducto;
                        objTempDescuento.PrecioUnitario = PrecioUnitario;
                        objTempDescuento.PrecioVenta = decValorVenta;
                        objTempDescuento.DescuentoAnterior = DescuentoAnterior;
                        objTempDescuento.Descuento = decDescuento;
                        objTempDescuento.Operacion = "INSERT";
                        objTempDescuento.Fecha = DateTime.Now;
                        objTempDescuento.UsuarioAutoriza = Parametros.strUsuarioLogin;
                        objTempDescuento.IdPedido = IdPedido;
                        objTempDescuento.Motivo = objDescuento.DescMotivo;
                        objTempDescuento.Observacion = "Modificado por [Establecer Dscto] - Pedido";
                        objTempDescuento.FlagEstado = true;
                        objTempDescuento.Usuario = Parametros.strUsuarioLogin;
                        objTempDescuento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objTempDescuento.IdEmpresa = Parametros.intEmpresaId;
                        //agregar pedido y descuento anterior

                        objBL_TempDescuento.Inserta(objTempDescuento);

                    }
                }

                gvPedidoDetalle.RefreshData();

                CalculaTotales();


                //Grabar Detalle - Reservar Stock -- aDD 240815
                if (Parametros.bValidarStockDetallePedido == true)
                {
                    if (chkPreventa.Checked == false)
                    {
                        GrabarDesdeDetalle();
                        CargaPedidoDetalle();

                        if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                        {
                            btnEnviarAlmacen.Visible = true;
                            btnGrabar.Visible = false;
                        }
                        else
                        {
                            btnEnviarAlmacen.Visible = false;
                            btnGrabar.Visible = true;
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void tsmMenuAgregar_Click(object sender, EventArgs e)
        //{
        //    this.nuevoToolStripMenuItem_Click(sender, e);
        //}

        //private void tsmMenuEliminar_Click(object sender, EventArgs e)
        //{
        //    this.eliminarToolStripMenuItem_Click(sender, e);
        //}

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoVenta.EditValue) == 0)
            {
                XtraMessageBox.Show("Para continuar DEFINA EL TIPO DE VENTA", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.modificarprecioToolStripMenuItem_Click(sender, e);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string saludo = txtNumeroDocumento.Text.Trim();
                //     string saludo = "Hola";
                foreach (char letra in saludo)
                {
                    if (!char.IsDigit(letra))
                    {
                        //  //  MessageBox.Show("es numero!!! " + letra, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //}
                        //else
                        //{
                        MessageBox.Show("El numero de documento del cliente contiene letras, esto no esta permitido. " + saludo.Trim() + "\n Corrija y vuelva a intentarlo.", "ERROR: Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (Convert.ToInt32(cboTipoVenta.EditValue) == 0)
                {
                    XtraMessageBox.Show("Para continuar DEFINA EL TIPO DE VENTA", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pOperacion == Operacion.Consultar)
                {
                    return;
                }

                if(btnGrabar.Enabled == false) //(IdSituacionModifica != Parametros.intPVGenerado)
                {
                    return;
                }


                Cursor = Cursors.WaitCursor;

                //Calcula Totales
                CalculaTotales();

                if (!ValidarIngreso())
                {
                    Int32 Numero = 0;

                    PedidoBL objBL_Pedido = new PedidoBL();
                    PedidoBE objPedido = new PedidoBE();

                    objPedido.IdPedido = IdPedido;
                    objPedido.IdTienda = IdTienda;//Parametros.intTiendaId;
                    objPedido.IdCampana = 3;
                    objPedido.Periodo = Periodo;//Parametros.intPeriodo;
                    objPedido.Mes = deFecha.DateTime.Month;
                    objPedido.IdProforma = IdProforma == 0 ? (Int32?)null : IdProforma;
                    objPedido.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objPedido.Serie = "0";
                    objPedido.Numero = txtNumero.Text;
                    objPedido.IdPedidoReferencia = IdPedidoReferencia == 0 ? (Int32?)null : IdPedidoReferencia;//IdPedidoReferencia;
                    objPedido.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPedido.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objPedido.FechaCancelacion = (DateTime?)null;
                    objPedido.IdCliente = IdCliente;
                    objPedido.NumeroDocumento = txtNumeroDocumento.Text;
                    objPedido.DescCliente = txtDescCliente.Text;
                    objPedido.Direccion = txtDireccion.Text;
                    objPedido.IdClienteAsociado = IdClienteAsociado; //Add  *****verificar null
                    objPedido.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPedido.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objPedido.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objPedido.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objPedido.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objPedido.Descuento = Convert.ToDecimal(txtTotalDscto2x1.EditValue);
                    objPedido.PorcentajeImpuesto = Parametros.dmlIGV;
                    objPedido.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objPedido.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objPedido.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objPedido.Observacion = txtObservaciones.Text; //Agregar si es liquidacion **************
                    objPedido.IdCombo = Convert.ToInt32(cboCombo.EditValue);
                    objPedido.Despachar = cboCaja.Text;
                    objPedido.IdTipoVenta = Convert.ToInt32(cboTipoVenta.EditValue);
                    objPedido.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objPedido.IdAsesor = Convert.ToInt32(cboAsesor.EditValue);
                    objPedido.IdAsesorExterno = IdAsesorExterno; //Convert.ToInt32(cboAsesorExterno.EditValue); 
                    objPedido.FlagPreVenta = chkPreventa.Checked;
                    objPedido.FlagEstado = true;
                    objPedido.Usuario = Parametros.strUsuarioLogin;
                    objPedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPedido.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objPedido.bOrigenFlagPreVenta = bOrigenFlagPreventa;
                    objPedido.FlagImpresionRus = FlagImpresionRus;
                    objPedido.IdContratoFabricacion = IdContratoFabricacion;
                    objPedido.IdProyectoServicio = IdProyectoServicio;
                    objPedido.IdNovioRegalo = IdNovioRegalo;

                    //Pedido Detalle
                    List<PedidoDetalleBE> lstPedidoDetalle = new List<PedidoDetalleBE>();

                    foreach (var item in mListaPedidoDetalleOrigen)
                    {
                        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_PedidoDetalle.IdPedido = item.IdPedido;
                        objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                        objE_PedidoDetalle.Item = item.Item;
                        objE_PedidoDetalle.IdProducto = item.IdProducto;
                        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                        objE_PedidoDetalle.Cantidad = item.Cantidad;
                        objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_PedidoDetalle.Descuento = item.Descuento;
                        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                        objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                        if (item.FlagMuestra)
                            objE_PedidoDetalle.Observacion = "MUESTRA";
                        else
                            objE_PedidoDetalle.Observacion = item.Observacion;
                        objE_PedidoDetalle.CodAfeIGV = item.CodAfeIGV;
                        objE_PedidoDetalle.IdKardex = item.IdKardex;
                        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen;
                        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen;
                        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                        objE_PedidoDetalle.FlagRegalo = false;
                        objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                        objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                        objE_PedidoDetalle.DescPromocion = item.DescPromocion;
                        objE_PedidoDetalle.FlagEstado = true;
                        objE_PedidoDetalle.TipoOper = item.TipoOper;
                        lstPedidoDetalle.Add(objE_PedidoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //ObtenerCorrelativo();

                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///add 110915
                        {
                            objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                        }
                        else
                        {
                            objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMinorista);
                        }

                        objPedido.IdSituacion = Parametros.intPVGenerado;
                        Numero = objBL_Pedido.Inserta(objPedido, lstPedidoDetalle);

                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(Numero);
                        txtNumero.Text = objE_Pedido.Numero;

                        //Grabar movimiento de pedido
                        if (IdPedidoReferencia > 0)
                        {
                            MovimientoAlmacenBL objBL_MovimientoPedido = new MovimientoAlmacenBL();
                            objBL_MovimientoPedido.CopiarDatosEnvio(Convert.ToInt32(IdPedidoReferencia), Numero);
                        }
                        //add 210317
                        IdPedido = Numero;
                    }
                    else
                    {
                        Numero = IdPedido;
                        objPedido.TipoCambio = dmlTipoCambio;
                        objPedido.IdSituacion = IdSituacionModifica;
                        objBL_Pedido.Actualiza(objPedido, lstPedidoDetalle);
                    }

                    if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                    {

                        IdPedido = Numero;
                        //Actualiza Estado Impresion
                        PedidoBE objE_Pedido = new PedidoBE();
                        objE_Pedido = new PedidoBL().SeleccionaImpresion(IdPedido);

                        if (objE_Pedido.FlagImpresion == true)
                        {
                            XtraMessageBox.Show("El pedido ya ha sido impreso, por favor Consultar con la Recepcionista de pedido contado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        { 
                        //PedidoBL objBL_Pedido = new PedidoBL();
                        objBL_Pedido.ActualizaImpresion(IdPedido, true);

                        //Carga Informe

                            frmListaPrinters frmPrinter = new frmListaPrinters();
                            if (frmPrinter.ShowDialog() == DialogResult.OK)
                            {
                                List<ReportePedidoContadoBE> lstReporte = null;
                                lstReporte = new ReportePedidoContadoBL().Listado(Periodo, Numero, Parametros.intTiendaId);

                                #region "Codigo Barras"

                                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                                bc.TextAlignment = Element.ALIGN_LEFT;
                                bc.Code = lstReporte[0].Numero;
                                bc.StartStopText = false;
                                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                                bc.Extended = true;
                                bc.BarHeight = 27;
                                lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    if (Parametros.intTiendaId == Parametros.intTiendaUcayali) //add temp 29122017
                                    {
                                        rptPedidoContadoTicket objReporteGuia = new rptPedidoContadoTicket();
                                        objReporteGuia.SetDataSource(lstReporte);
                                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                                        //addd 300715
                                        //objReporteGuia.SetParameterValue("Modificado", "()");//add
                                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                    }
                                    else
                                    {
                                        rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                                        objReporteGuia.SetDataSource(lstReporte);
                                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                                        //addd 300715
                                        //objReporteGuia.SetParameterValue("Modificado", "()");//add
                                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                    }


                                    //rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                                    //objReporteGuia.SetDataSource(lstReporte);
                                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                                    ////addd 300715
                                    //objReporteGuia.SetParameterValue("Modificado", "()");//add
                                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                                    ///*if (pOperacion == Operacion.Nuevo)
                                    //{
                                    //    objReporteGuia.SetParameterValue("Modificado", "()");
                                    //    Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                                    //}
                                    //else
                                    //{

                                    //    rptPedidoContadoModifica objReporteGuiaMod = new rptPedidoContadoModifica();
                                    //    objReporteGuiaMod.SetDataSource(lstReporte);
                                    //    objReporteGuiaMod.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                    //    objReporteGuiaMod.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                    //    objReporteGuiaMod.SetParameterValue("Modificado", "(MODIFICADO)");
                                    //    Impresion.Imprimir(objReporteGuiaMod, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                                    //}*/

                                    ////Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                                }
                            }
                        }
                    }


                    //Actualizar estado Encuesta
                    if (bEncuesta)
                    { 
                        EncuestaBL ObjBL_Encuesta = new EncuestaBL();
                        ObjBL_Encuesta.ActualizaFlagDescuento(IdCliente);
                    }

                    Cursor = Cursors.Default;

                    EBotonGrabar = 1;

                    TotalPedido = Convert.ToDecimal(txtTotal.EditValue);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   if (XtraMessageBox.Show("Desea Actualizar los precios y tipo de cambio Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        #region "Pedido Actualizado"
                        //Traemos la información del Pedido
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text.Trim());
                        if (objE_Pedido != null )
                        {
                            if (objE_Pedido.FlagPreVenta == true)
                            {
                                #region "Pedido Preventa"

                                //if (objE_Pedido.IdSituacion == Parametros.intPVGenerado || objE_Pedido.IdSituacion == Parametros.intPVAnulado) //Factudo
                                //{
                                //    XtraMessageBox.Show("No se puede Generar pedido N°" + txtNumeroPedido.Text + ", No está Aprobado! \nSituación Actual: " + objE_Pedido.DescSituacion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    return;
                                //}
                                BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true); //add 31-08-15

                                cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                                cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                                txtNumero.Text = objE_Pedido.Numero;
                                txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                                cboVendedor.EditValue = objE_Pedido.IdVendedor;
                                cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                                deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                                cboMoneda.EditValue = objE_Pedido.IdMoneda;
                                txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                IdCliente = objE_Pedido.IdCliente;
                                IdTipoCliente = objE_Pedido.IdTipoCliente;
                                IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                                txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                                txtDescCliente.Text = objE_Pedido.DescCliente;
                                if (IdTipoCliente == Parametros.intTipClienteFinal)
                                    txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                                else
                                    txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                                txtDireccion.Text = objE_Pedido.Direccion;
                                cboCombo.EditValue = objE_Pedido.IdCombo;
                                cboCaja.Text = objE_Pedido.Despachar;
                                txtObservaciones.Text = objE_Pedido.Observacion;
                                txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                                txtSubTotal.EditValue = objE_Pedido.SubTotal;
                                txtImpuesto.EditValue = objE_Pedido.Igv;
                                txtTotal.EditValue = objE_Pedido.Total;
                                //chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                                chkPreventa.Checked = false;
                                cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                                //cboMotivo.EditValue = objE_Pedido.IdMotivo;
                                //Agregado para la campaña 2016
                                if (objE_Pedido.IdMotivo == Parametros.intMotivoVentaReligioso)
                                {
                                    cboMotivo.EditValue = Parametros.intMotivoVenta;
                                    XtraMessageBox.Show("Se cambió el tipo de venta de RELIGIOSO a VENTA Regular", this.Text);
                                }
                                    
                                else
                                    cboMotivo.EditValue = objE_Pedido.IdMotivo;

                                txtObservaciones.Text = "MODIFICACIÓN PV DEL PEDIDO : " + objE_Pedido.Numero;
                                IdPedidoReferencia = objE_Pedido.IdPedido;
                                bOrigenFlagPreventa = true;
                                txtDescuento.EditValue = Parametros.dmlDescuentoPreventaVenta; //add 31-08

                                //Carga ClienteAsociado
                                CargarClienteAsociado();
                                cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                                gcPedidoDetalle.Focus();

                                //Seteamos el Pedido
                                SeteaPedidoDetalle();

                                //Traemos la información del detalle del Pedido

                                List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                                lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoActualizadoStock(objE_Pedido.IdPedido);

                                foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                                {
                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = item.Item;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                    objE_PedidoDetalle.IdKardex = item.IdKardex;
                                    //objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                    objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali; //add
                                    objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                    objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                    objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                    objE_PedidoDetalle.Observacion = item.Observacion;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                }

                                bsListado.DataSource = mListaPedidoDetalleOrigen;
                                gcPedidoDetalle.DataSource = bsListado;
                                gcPedidoDetalle.RefreshDataSource();

                                CalculaTotales();
                                #endregion
                            }
                            else
                            {
                                #region "Pedido Normal"
                                cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                                cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                                txtNumero.Text = objE_Pedido.Numero;
                                txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                                cboVendedor.EditValue = objE_Pedido.IdVendedor;
                                cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                                deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                                cboMoneda.EditValue = objE_Pedido.IdMoneda;
                                txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                IdCliente = objE_Pedido.IdCliente;
                                IdTipoCliente = objE_Pedido.IdTipoCliente;
                                IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                                txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                                txtDescCliente.Text = objE_Pedido.DescCliente;
                                if (IdTipoCliente == Parametros.intTipClienteFinal)
                                    txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                                else
                                    txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                                txtDireccion.Text = objE_Pedido.Direccion;
                                cboCombo.EditValue = objE_Pedido.IdCombo;
                                cboCaja.Text = objE_Pedido.Despachar;
                                txtObservaciones.Text = objE_Pedido.Observacion;
                                txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                                txtSubTotal.EditValue = objE_Pedido.SubTotal;
                                txtImpuesto.EditValue = objE_Pedido.Igv;
                                txtTotal.EditValue = objE_Pedido.Total;
                                chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                                cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                                cboMotivo.EditValue = objE_Pedido.IdMotivo;
                                txtObservaciones.Text = "MODIFICACIÓN DEL PEDIDO : " + objE_Pedido.Numero;
                                IdPedidoReferencia = objE_Pedido.IdPedido;

                                //Carga ClienteAsociado
                                CargarClienteAsociado();
                                cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                                gcPedidoDetalle.Focus();

                                //Seteamos el Pedido
                                SeteaPedidoDetalle();

                                //Traemos la información del detalle del Pedido

                                List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                                lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoActualizado(objE_Pedido.IdPedido);

                                foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                                {
                                    #region "Validar Stock Físico"

                                    int CantidadDisponible = 0;
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock = new StockBL().SeleccionaCantidadIdProducto(item.IdTienda, Convert.ToInt32(item.IdAlmacen), item.IdProducto);

                                    if (objE_Stock.Cantidad > item.Cantidad)
                                    {
                                        CantidadDisponible = item.Cantidad;
                                    }
                                    else
                                    {
                                        CantidadDisponible = objE_Stock.Cantidad;
                                    }

                                    #endregion
                                    if (CantidadDisponible > 0)
                                    {
                                        CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_PedidoDetalle.IdPedido = 0;
                                        objE_PedidoDetalle.IdPedidoDetalle = 0;
                                        objE_PedidoDetalle.Item = item.Item;
                                        objE_PedidoDetalle.IdProducto = item.IdProducto;
                                        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                        objE_PedidoDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                                        objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_PedidoDetalle.Descuento = item.Descuento;
                                        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_PedidoDetalle.ValorVenta = CantidadDisponible * item.PrecioVenta;//item.ValorVenta;
                                        objE_PedidoDetalle.IdKardex = item.IdKardex;
                                        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                        objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                        objE_PedidoDetalle.Observacion = item.Observacion;
                                        objE_PedidoDetalle.Stock = 0;
                                        objE_PedidoDetalle.TipoOper = item.TipoOper;
                                        mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);         
                                    }
                                }

                                bsListado.DataSource = mListaPedidoDetalleOrigen;
                                gcPedidoDetalle.DataSource = bsListado;
                                gcPedidoDetalle.RefreshDataSource();

                                CalculaTotales();
                                #endregion                            
                            }
                        }

                        #endregion
                    }
                    else 
                    { 
                        #region "Pedido Original"
                        //Traemos la información del Pedido
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text.Trim());
                        if (objE_Pedido != null)
                        {

                            if (objE_Pedido.FlagPreVenta == true)
                            {
                                #region "Pedido Preventa"

                                //if (objE_Pedido.IdSituacion == Parametros.intPVGenerado || objE_Pedido.IdSituacion == Parametros.intPVAnulado) //Factudo
                                //{
                                //    XtraMessageBox.Show("No se puede Generar pedido N°" + txtNumeroPedido.Text + ", No está Aprobado! \nSituación Actual: " + objE_Pedido.DescSituacion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    return;
                                //}
                                BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true); //add 31-08-15

                                cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                                cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                                txtNumero.Text = objE_Pedido.Numero;
                                txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                                cboVendedor.EditValue = objE_Pedido.IdVendedor;
                                cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                                deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                                cboMoneda.EditValue = objE_Pedido.IdMoneda;
                                txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                IdCliente = objE_Pedido.IdCliente;
                                IdTipoCliente = objE_Pedido.IdTipoCliente;
                                IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                                txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                                txtDescCliente.Text = objE_Pedido.DescCliente;
                                if (IdTipoCliente == Parametros.intTipClienteFinal)
                                    txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                                else
                                    txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                                txtDireccion.Text = objE_Pedido.Direccion;
                                cboCombo.EditValue = objE_Pedido.IdCombo;
                                cboCaja.Text = objE_Pedido.Despachar;
                                txtObservaciones.Text = objE_Pedido.Observacion;
                                txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                                txtSubTotal.EditValue = objE_Pedido.SubTotal;
                                txtImpuesto.EditValue = objE_Pedido.Igv;
                                txtTotal.EditValue = objE_Pedido.Total;
                                //chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                                chkPreventa.Checked = false;
                                cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                                //cboMotivo.EditValue = objE_Pedido.IdMotivo;
                                //Agregado para la campaña 2016
                                if (objE_Pedido.IdMotivo == Parametros.intMotivoVentaReligioso)
                                    cboMotivo.EditValue = Parametros.intMotivoVenta;
                                else
                                    cboMotivo.EditValue = objE_Pedido.IdMotivo;
                                txtObservaciones.Text = "MODIFICACIÓN DEL PEDIDO : " + objE_Pedido.Numero;
                                IdPedidoReferencia = objE_Pedido.IdPedido;
                                bOrigenFlagPreventa = true;
                                txtDescuento.EditValue = Parametros.dmlDescuentoPreventaVenta; //add 31-08

                                //Carga ClienteAsociado
                                CargarClienteAsociado();
                                cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                                gcPedidoDetalle.Focus();

                                //Seteamos el Pedido
                                SeteaPedidoDetalle();

                                //Traemos la información del detalle del Pedido

                                List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                                lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosStock(objE_Pedido.IdPedido);


                                foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                                {
                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = item.Item;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                    objE_PedidoDetalle.IdKardex = item.IdKardex;
                                    //objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                    objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali; //add
                                    objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                    objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                    objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                    objE_PedidoDetalle.Observacion = item.Observacion;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                }

                                bsListado.DataSource = mListaPedidoDetalleOrigen;
                                gcPedidoDetalle.DataSource = bsListado;
                                gcPedidoDetalle.RefreshDataSource();

                                CalculaTotales();
                                #endregion
                            }
                            else
                            {
                                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                                frmAutoriza.ShowDialog();

                                if (frmAutoriza.Edita)
                                {
                                    if (frmAutoriza.Usuario == "master" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerHelpDesk)
                                    {
                                        #region "Pedido Normal"

                                        #region "Pedido Anulado"
                                        if (objE_Pedido.IdSituacion == Parametros.intPVAnulado)
                                        {
                                            if (objE_Pedido.IdTipoCliente != IdTipoCliente)
                                            {
                                                XtraMessageBox.Show("No se puede copiar información de un cliente Final a Mayorista o Viceversa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                return;
                                            }

                                            gcPedidoDetalle.Focus();

                                            //Seteamos el Pedido
                                            SeteaPedidoDetalle();

                                            //Traemos la información del detalle del Pedido

                                            List<PedidoDetalleBE> lstTmpPedidoDetalle1 = null;
                                            lstTmpPedidoDetalle1 = new PedidoDetalleBL().ListaTodos(objE_Pedido.IdPedido);

                                            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle1)
                                            {
                                                #region "Validar Stock Físico"

                                                int CantidadDisponible = 0;
                                                StockBE objE_Stock = new StockBE();
                                                objE_Stock = new StockBL().SeleccionaCantidadIdProducto(item.IdTienda, Convert.ToInt32(item.IdAlmacen), item.IdProducto);

                                                if (objE_Stock.Cantidad > item.Cantidad)
                                                {
                                                    CantidadDisponible = item.Cantidad;
                                                }
                                                else
                                                {
                                                    CantidadDisponible = objE_Stock.Cantidad;
                                                }

                                                #endregion
                                                if (CantidadDisponible > 0)
                                                {
                                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                                    objE_PedidoDetalle.IdPedido = 0;
                                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                                    objE_PedidoDetalle.Item = item.Item;
                                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                                    objE_PedidoDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                                    objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                                    objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                                    objE_PedidoDetalle.Descuento = item.Descuento;
                                                    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                                    objE_PedidoDetalle.ValorVenta = CantidadDisponible * item.PrecioVenta;//item.ValorVenta;
                                                    objE_PedidoDetalle.IdKardex = item.IdKardex;
                                                    objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                                    objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                                    objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                                    objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                                    objE_PedidoDetalle.Observacion = item.Observacion;
                                                    objE_PedidoDetalle.Stock = 0;
                                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                                }


                                            }

                                            bsListado.DataSource = mListaPedidoDetalleOrigen;
                                            gcPedidoDetalle.DataSource = bsListado;
                                            gcPedidoDetalle.RefreshDataSource();

                                            CalculaTotales();

                                            return;
                                        }
                                        #endregion


                                        cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                                        cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                                        txtNumero.Text = objE_Pedido.Numero;
                                        txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                                        cboVendedor.EditValue = objE_Pedido.IdVendedor;
                                        cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                                        deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                                        cboMoneda.EditValue = objE_Pedido.IdMoneda;
                                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                        IdCliente = objE_Pedido.IdCliente;
                                        IdTipoCliente = objE_Pedido.IdTipoCliente;
                                        IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                                        txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                                        txtDescCliente.Text = objE_Pedido.DescCliente;
                                        if (IdTipoCliente == Parametros.intTipClienteFinal)
                                            txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                                        else
                                            txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                                        txtDireccion.Text = objE_Pedido.Direccion;
                                        cboCombo.EditValue = objE_Pedido.IdCombo;
                                        cboCaja.Text = objE_Pedido.Despachar;
                                        txtObservaciones.Text = objE_Pedido.Observacion;
                                        txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                                        txtSubTotal.EditValue = objE_Pedido.SubTotal;
                                        txtImpuesto.EditValue = objE_Pedido.Igv;
                                        txtTotal.EditValue = objE_Pedido.Total;
                                        chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                                        cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                                        cboMotivo.EditValue = objE_Pedido.IdMotivo;
                                        txtObservaciones.Text = "MODIFICACIÓN DEL PEDIDO : " + objE_Pedido.Numero;
                                        IdPedidoReferencia = objE_Pedido.IdPedido;

                                        //Carga ClienteAsociado
                                        CargarClienteAsociado();
                                        cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                                        gcPedidoDetalle.Focus();

                                        //Seteamos el Pedido
                                        SeteaPedidoDetalle();

                                        //Traemos la información del detalle del Pedido

                                        List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                                        lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodos(objE_Pedido.IdPedido);

                                        foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                                        {
                                            #region "Validar Stock Físico"

                                            int CantidadDisponible = 0;
                                            StockBE objE_Stock = new StockBE();
                                            objE_Stock = new StockBL().SeleccionaCantidadIdProducto(item.IdTienda, Convert.ToInt32(item.IdAlmacen), item.IdProducto);

                                            if (objE_Stock.Cantidad > item.Cantidad)
                                            {
                                                CantidadDisponible = item.Cantidad;
                                            }
                                            else
                                            {
                                                CantidadDisponible = objE_Stock.Cantidad;
                                            }

                                            #endregion
                                            if (CantidadDisponible > 0)
                                            {
                                                CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                                objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                                objE_PedidoDetalle.IdPedido = 0;
                                                objE_PedidoDetalle.IdPedidoDetalle = 0;
                                                objE_PedidoDetalle.Item = item.Item;
                                                objE_PedidoDetalle.IdProducto = item.IdProducto;
                                                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                                objE_PedidoDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                                                objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                                objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                                objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                                objE_PedidoDetalle.Descuento = item.Descuento;
                                                objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                                objE_PedidoDetalle.ValorVenta = CantidadDisponible * item.PrecioVenta;//item.ValorVenta;
                                                objE_PedidoDetalle.IdKardex = item.IdKardex;
                                                objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                                objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add 071118
                                                objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                                objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                                objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                                objE_PedidoDetalle.Observacion = item.Observacion;
                                                objE_PedidoDetalle.Stock = 0;
                                                objE_PedidoDetalle.TipoOper = item.TipoOper;
                                                mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                            }
                                        }
                                        bsListado.DataSource = mListaPedidoDetalleOrigen;
                                        gcPedidoDetalle.DataSource = bsListado;
                                        gcPedidoDetalle.RefreshDataSource();

                                        CalculaTotales();
                                        #endregion
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nEsta copia podría estar sujeto a Auditoría de Descuento. Consulte con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }

                            //---------------------------

                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCombo.EditValue) == 0)
            {
                if (bNuevo)
                {
                    #region "Total y Descuento Mayorista"

                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                    {
                        if (Convert.ToDecimal(txtTotal.Text) > 0)
                        {
                            decimal decTotal = 0;

                            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                            {
                                decTotal = Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(Parametros.dmlTCMayorista);
                            }
                            else
                            {
                                decTotal = Convert.ToDecimal(txtTotal.Text);
                            }

                            if (gvPedidoDetalle.RowCount > 0)
                            {
                                gvPedidoDetalle.RefreshData();

                                for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
                                {
                                    int IdPromocionCadena = 0;//add 260515
                                    IdPromocionCadena = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["IdPromocion"])));//add
                                    if (IdPromocionCadena == 0)
                                    {
                                        int IdProducto = 0;
                                        int IdLineaProducto = 0;
                                        decimal decDescuentoOriginal = 0;
                                        decimal decDescuento = 0;
                                        decimal decPrecioVenta = 0;
                                        decimal decValorVenta = 0;
                                        decimal decDescuentoEstablecido = 0;
                                        decimal decDescuentoBulto = 5;//add 1008
                                        bool FlagBultoCerrado = false;

                                        IdProducto = int.Parse(gvPedidoDetalle.GetRowCellValue(i, "IdProducto").ToString());
                                        decDescuentoEstablecido = decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());
                                        FlagBultoCerrado = bool.Parse(gvPedidoDetalle.GetRowCellValue(i, "FlagBultoCerrado").ToString());
                                        decDescuentoBulto = decDescuentoEstablecido + 5;


                                        StockBE objE_Stock = null;
                                        objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);

                                        //Add by ClienteDescuentoFechaCompra  **********
                                        FechaCompraProducto = Convert.ToDateTime(objE_Stock.FechaCompra.ToShortDateString());

                                        if (objE_Stock != null)
                                        {
                                            //normal
                                            IdLineaProducto = objE_Stock.IdLineaProducto;
                                            if (decDescuentoEstablecido > objE_Stock.Descuento)
                                            { decDescuentoOriginal = decDescuentoEstablecido; }
                                            else
                                            { decDescuentoOriginal = objE_Stock.Descuento; }

                                            #region "Sin Escala de descuento"
                                            if (objE_Stock.FlagEscala == false)
                                            {
                                                decDescuento = objE_Stock.Descuento;
                                                gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento);
                                                decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100), 2);
                                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                return;
                                            }
                                            #endregion

                                        }

                                        foreach (var itemdescuento in mListaDescuentoClienteMayorista)
                                        {
                                            if (Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && decTotal >= itemdescuento.MontoMin && decTotal <= itemdescuento.MontoMax && itemdescuento.FlagPreVenta == chkPreventa.Checked)
                                            //if (Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && decTotal >= itemdescuento.MontoMin && decTotal <= itemdescuento.MontoMax && itemdescuento.FlagPreVenta == chkPreventa.Checked && itemdescuento.FlagVenta == chkDescuentoExtraVenta.Checked)
                                            {
                                                decDescuento = itemdescuento.PorDescuento;
                                                decimal decDescuentoMoroso = 0;

                                                //Agregado 10/02/2020 para condicionar si el descuento temporal es 0 que aplique las condiciones del modulo descuento de mayoristas
                                                PromocionTemporalDetalleBE objE_PromocionTemporal = new PromocionTemporalDetalleBL().SeleccionaUltimo(Parametros.intEmpresaId, IdTipoCliente, itemdescuento.IdFormaPago, Parametros.intTiendaId, IdProducto);
                                                if (objE_PromocionTemporal == null)
                                                {
                                                    
                                                }else if(objE_PromocionTemporal.Descuento != 0)
                                                {
                                                    decDescuento = 0;
                                                }
                                                //----------------------------------------------------------
                                                
                                                if (decDescuentoOriginal > decDescuento)
                                                {
                                                    if (bMoroso)
                                                    {
                                                        gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                        decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                        gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                        gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                    }
                                                    else
                                                    {
                                                        gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoOriginal);
                                                        decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoOriginal) / 100), 2);
                                                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                        gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                        gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                    }
                                                }
                                                else
                                                {
                                                    if (bMoroso)
                                                    {
                                                        gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                        decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                        gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                        gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                    }
                                                    else
                                                    {
                                                        gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento);
                                                        decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100), 2);
                                                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                        gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                        gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                    }
                                                }
                                            }

                                        }

                                        #region "Descuento por FechaCompra"

                                        if (pParametroBE.FlagEstado == true)
                                        {
                                            decimal decDescuentoCompra = 0;

                                            IdProducto = int.Parse(gvPedidoDetalle.GetRowCellValue(i, "IdProducto").ToString());
                                            decDescuentoEstablecido = decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());

                                            foreach (var itemdescuento in mListaDescuentoClienteFechaCompra)
                                            {
                                                //if (Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && decTotal >= itemdescuento.MontoMin && decTotal <= itemdescuento.MontoMax && itemdescuento.FlagPreVenta == chkPreventa.Checked)
                                                if (IdTipoCliente == itemdescuento.IdTipoCliente && Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && FechaCompraProducto >= itemdescuento.FechaInicio && FechaCompraProducto <= itemdescuento.FechaFin)
                                                {
                                                    decDescuentoCompra = itemdescuento.Descuento;
                                                    decimal decDescuentoMoroso = 0;

                                                    if (decDescuentoEstablecido > decDescuentoCompra)
                                                    {
                                                        if (bMoroso)
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                        else
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoEstablecido);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoEstablecido) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (bMoroso)
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                        else
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoCompra);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoCompra) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                        #endregion



                                        //Temporal 
                                        #region "Descuento por Lista Feria"

                                        /*if (DateTime.Now <= Convert.ToDateTime("08/02/2015"))
                                        {
                                            DescuentoClienteMayoristaFeriaBE obj_Feria = new DescuentoClienteMayoristaFeriaBE();
                                            obj_Feria = new DescuentoClienteMayoristaFeriaBL().Selecciona(IdProducto);

                                            if (obj_Feria != null)
                                            { 
                                                decimal decDescuentoCompra = 0;

                                                IdProducto = int.Parse(gvPedidoDetalle.GetRowCellValue(i, "IdProducto").ToString());
                                                decDescuentoEstablecido = decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());

                                                //if (IdTipoCliente == itemdescuento.IdTipoCliente && Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && FechaCompraProducto >= itemdescuento.FechaInicio && FechaCompraProducto <= itemdescuento.FechaFin)
                                                //{
                                                    decDescuentoCompra = obj_Feria.Descuento;
                                                    decimal decDescuentoMoroso = 0;

                                                    if (decDescuentoEstablecido > decDescuentoCompra)
                                                    {
                                                        if (bMoroso)
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                        else
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoEstablecido);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoEstablecido) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (bMoroso)
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                        else
                                                        {
                                                            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoCompra);
                                                            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoCompra) / 100), 2);
                                                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                                        }
                                                    }
                                                //}
                                                                                 
                                            }



                                        }*/
                                        #endregion



                                        #region "Descuento por Bulto"

                                        //if (DescuentoClienteBulto == true) /// comentado el 031117
                                        //{
                                        //    //decimal decDescuentoBulto = 5;
                                        //    decimal decDescuentoMoroso = 0;

                                        //    decDescuentoEstablecido = decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());
                                        //    decDescuentoBulto = decDescuentoEstablecido + 5;

                                        //    if (FlagBultoCerrado)
                                        //    {
                                        //        if (bMoroso)
                                        //        {
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                        //            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                        //            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                        //            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                        //        }
                                        //        else
                                        //        {
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoBulto);
                                        //            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoBulto) / 100), 2);
                                        //            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                        //            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                        //            gvPedidoDetalle.SetRowCellValue(i, "FlagBultoCerrado", false); //add
                                        //        }
                                        //    }

                                        //}
                                        #endregion


                                        //Test de velociad por Hora
                                        #region "Descuento Promocion Temporal No va - SOlo seleccion" 

                                        //PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                        //objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), IdProducto);
                                        //if (objE_PromocionTemporal != null)
                                        //{
                                        //    //decimal decDescuentoBulto = 5;
                                        //    decimal decDescuentoMoroso = 0;

                                        //    decDescuentoEstablecido = decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());

                                        //    if (decDescuentoEstablecido < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                        //    {
                                        //        if (bMoroso)
                                        //        {
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                        //            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                                        //            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                        //            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                        //        }
                                        //        else
                                        //        {
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", objE_PromocionTemporal.Descuento);
                                        //            decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - objE_PromocionTemporal.Descuento) / 100), 2);
                                        //            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                        //            gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                        //            gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                        //            gvPedidoDetalle.SetRowCellValue(i, "FlagBultoCerrado", false); //add
                                        //        }
                                        //    }

                                        //}

                                        #endregion

                                        //Visita de campo
                                        #region "Visita campo"
                                        //if (Convert.ToDateTime(DateTime.Now) <= Convert.ToDateTime("28/02/2019"))
                                        //{
                                        //    if (Convert.ToInt32(cboTipoVenta.EditValue) == Parametros.intPorVisitaCampo) //add 29012018 -- delete 
                                        //    {
                                        //        //if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intDolares)
                                        //        //{
                                        //        //    if (Convert.ToDecimal(txtTotal.EditValue) >= 300)
                                        //        //    {
                                        //        //        txtDescuento.EditValue = Convert.ToDecimal("2.00");
                                        //        //    }
                                        //        //    else
                                        //        //    {
                                        //        //        txtDescuento.EditValue = Convert.ToDecimal("0");
                                        //        //    }
                                        //        //}
                                        //    }
                                        //    else
                                        //    {
                                        //        txtDescuento.EditValue = Convert.ToDecimal("0");
                                        //    }
                                        //}

                                        #endregion

                                    }
                                }
                            }


                        }
                    }
                    #endregion


                    //if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                    //{
                    //    decimal decPrecioVenta = 0;
                    //    decimal decValorVenta = 0;
                    //    decimal decDescuentoEstablecido = 0;
                    //    decimal decDescuentoBulto = 0;//add 1008
                    //    bool FlagBultoCerrado = false;

                    //    if (Convert.ToDecimal(txtTotal.Text) > 0)
                    //    {
                    //        decimal decTotal = 0;

                    //        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                    //        {
                    //            decTotal = Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(Parametros.dmlTCMayorista);
                    //        }
                    //        else
                    //        {
                    //            decTotal = Convert.ToDecimal(txtTotal.Text);
                    //        }

                    //        if (gvPedidoDetalle.RowCount > 0)
                    //        {
                    //            for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
                    //            {
                    //                int IdPromocionCadena = 0;//add 260515
                    //                IdPromocionCadena = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["IdPromocion"])));//add



                    //                if (IdPromocionCadena == 0)
                    //                {
                    //                    if (DescuentoClienteBulto == true)
                    //                    {
                    //                        //decimal decDescuentoBulto = 5;
                    //                        decimal decDescuentoMoroso = 0;

                    //                        //decDescuentoBultoCerrado = decDescuentoEstablecido + decDescuentoBulto;
                    //                        FlagBultoCerrado = bool.Parse(gvPedidoDetalle.GetRowCellValue(i, "FlagBultoCerrado").ToString());
                    //                        decDescuentoEstablecido = decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());
                    //                        decDescuentoBulto = decDescuentoEstablecido + 5;


                    //                        if (FlagBultoCerrado)
                    //                        {
                    //                            if (bMoroso)
                    //                            {
                    //                                gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                    //                                decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                    //                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                    //                                gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                    //                                gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                    //                            }
                    //                            else
                    //                            {
                    //                                gvPedidoDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoBulto);
                    //                                decPrecioVenta = Math.Round(decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoBulto) / 100), 2);
                    //                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(i, "Cantidad").ToString());
                    //                                gvPedidoDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                    //                                gvPedidoDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                    //                                gvPedidoDetalle.SetRowCellValue(i, "FlagBultoCerrado", false);
                    //                            }
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}



                }

                //Calcular Descuento ADICIONAL



            }
            if (pOperacion == Operacion.Consultar)
            {
                CalculaTotales();
                return;
            }

            //CalculaTotales(); //delete o verificar

            //Bloquear Cabecera
            if (Convert.ToDecimal(txtTotal.EditValue) == 0)
            {
                //HabilitarCabecera();
                HabilitarCabeceraInicial();
            }
            else 
            { 
                DesHabilitarCabecera();


                //Bloquear PEdido Por despachador -----------------------------
                //Chequeador
                MovimientoPedidoBE objE_MovimientoPedido = null;
                objE_MovimientoPedido = new MovimientoPedidoBL().SeleccionaChequeo(IdPedido);
                if (objE_MovimientoPedido != null)
                {
                    if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                    {
                        if (objE_MovimientoPedido.IdAuxiliar > 0)
                        {
                            lblMensajePedido.Text = "En preparación por: " + objE_MovimientoPedido.DescAuxiliar;
                            if (Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerHelpDesk)
                            {
                                //Usuario Permitido
                            }
                            else
                            {
                                DesHabilitarCabecera();
                                DesHabilitarEdition();
                                DesHabilitar();
                            }
                        }
                        else
                        {
                            lblMensajePedido.Text = "";
                        }
                    }
                    else
                    {
                        if (objE_MovimientoPedido.IdChequeador > 0)
                        {
                            lblMensajePedido.Text = "Chequeado por: " + objE_MovimientoPedido.DescChequeador;
                            if(Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerHelpDesk)
                            {
                                //Usuario Permitido
                            }else
                            {
                                DesHabilitarCabecera();
                                DesHabilitarEdition();
                                DesHabilitar();
                            }
                        }
                        else
                        {
                            if (objE_MovimientoPedido.DescAuxiliar.Trim().Length>0)
                            {
                                lblMensajePedido.Text = "Picking por: " + objE_MovimientoPedido.DescAuxiliar;
                            }
                            else
                            {
                                lblMensajePedido.Text = "";
                            }
                        }
                    }

                }

                //Add For Administrators Users

                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "rcastañeda"  || Parametros.strUsuarioLogin == "dhuaman" || ActivaCabeceraCaja || Parametros.strUsuarioLogin == "nillanes" || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    //HabilitarCabecera();
                    if (IdSituacionModifica == Parametros.intFacturado || IdSituacionModifica == Parametros.intPVAnulado || IdSituacionModifica == Parametros.intPVDespachado)
                    {
                        DesHabilitarCabecera();
                        DesHabilitar();
                    }
                    else {
                        HabilitarCabecera();
                    }
                }
                

            }
        }

        private void frmRegPedidoEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (EBotonGrabar == 0)
            //{
            //    btnGrabar_Click(sender, e);
            //}
        }

        private void btnClienteAsociado_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar un cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumeroDocumento.Focus();
                    return;
                }

                frmBusClienteAsociado frm = new frmBusClienteAsociado();
                frm.IdCliente = IdCliente;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteAsociadoBE != null)
                {
                    txtNumeroDocumento.Text = frm.pClienteAsociadoBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteAsociadoBE.DescCliente;
                    txtDireccion.Text = frm.pClienteAsociadoBE.Direccion;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTipoVenta_EditValueChanged(object sender, EventArgs e)
        {
            labelControl30.Visible = false;
            txtMP.Visible = false;
            simpleButton1.Visible = false;

            if (Convert.ToInt32(cboTipoVenta.EditValue) == Parametros.intPorAsesoria)
            {
                ////if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador)
                ////{
                ////    cboAsesor.Enabled = true;
                ////    btnGrabar.Enabled = true;
                ////}
                ////lblAsesor.Visible = true;
                ////cboAsesor.Visible = true;
                ////cboAsesor.EditValue = cboVendedor.EditValue;
                //////Asesor externo
                ////gcDiseñador.Visible = false;
                
                //cboAsesorExterno.Visible = false;
                //cboAsesorExterno.EditValue = 0;
            }
            else if (Convert.ToInt32(cboTipoVenta.EditValue) == Parametros.intPorAsesoriaExterna)
            {
                if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    //cboAsesorExterno.Enabled = true;
                    btnGrabar.Enabled = true;
                }
                gcDiseñador.Visible = true;
                //lblAsesor.Visible = true;
                //cboAsesorExterno.Visible = true;
                //Aseseor
                lblAsesor.Visible = false;
                cboAsesor.Visible = false;
                cboAsesor.EditValue = 0;
            }
            else if (Convert.ToInt32(cboTipoVenta.EditValue) == Parametros.intPorMercadoPago)   // Mercado Pago
            {
                if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    btnGrabar.Enabled = true;
                }
                labelControl30.Visible = true;
                txtMP.Visible = true;
                simpleButton1.Visible = true;
                txtMP.EditValue = 0.00;                
            }
            else
            {
                lblAsesor.Visible = false;
                cboAsesor.Visible = false;
                gcDiseñador.Visible = false;
                //cboAsesorExterno.Visible = false;
                //cboAsesorExterno.EditValue = 0;
                cboAsesor.EditValue = 0;
            }

            //if(Convert.ToInt32(cboTipoVenta.EditValue) == Parametros.intPorVisitaCampo) //add 29012018 -- delete 
            //{
            //    txtDescuento.EditValue = Convert.ToDecimal("2.00");
            //}else
            //{
            //    txtDescuento.EditValue = Convert.ToDecimal("0");
            //}
        }

        private void cboClienteAsociado_EditValueChanged(object sender, EventArgs e)
        {
            CargarClienteAsociadoSelecciona();
        }

        private void btnEliminarCumpleanios_Click(object sender, EventArgs e)
        {
            bCumpleAnios = false;
            lblMensaje.Text = "";
            btnEliminarCumpleanios.Visible = false;
        }

        private void btnEliminarEncuesta_Click(object sender, EventArgs e)
        {
            bEncuesta = false;
            lblMensaje.Text = "";
            btnEliminarEncuesta.Visible = false;
        }

        private void btnPromocion_Click(object sender, EventArgs e)
        {
            //frmBusProductoStockPromocion objBusProductoPreVenta = new frmBusProductoStockPromocion();
            ////objBusProductoPreVenta.pDescripcion = txtCodigo.Text.Trim();
            //objBusProductoPreVenta.IdTienda = Parametros.intTiendaId;
            //objBusProductoPreVenta.IdAlmacen = Parametros.intAlmCentralUcayali;
            //objBusProductoPreVenta.ShowDialog();
            //if (objBusProductoPreVenta.pProductoBE != null)
            //{
            //    XtraMessageBox.Show("Funca", "title");



            //    //IdProducto = objBusProductoPreVenta.pProductoBE.IdProducto;
            //    //IdLineaProducto = objBusProductoPreVenta.pProductoBE.IdLineaProducto;
            //    //txtCodigo.Text = objBusProductoPreVenta.pProductoBE.CodigoProveedor;
            //    //txtProducto.Text = objBusProductoPreVenta.pProductoBE.NombreProducto;
            //    //txtUM.Text = objBusProductoPreVenta.pProductoBE.Abreviatura;
            //    //txtCantidad.EditValue = 1;
            //    //if (IdMoneda == Parametros.intSoles)
            //    //{
            //    //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
            //    //    {
            //    //        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioABSoles;
            //    //        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
            //    //        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            //    //        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            //    //    }
            //    //    else
            //    //    {
            //    //        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioCDSoles; ;
            //    //        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
            //    //        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            //    //        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
            //    //    {
            //    //        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioAB;
            //    //        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
            //    //        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            //    //        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            //    //    }
            //    //    else
            //    //    {
            //    //        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioCD;
            //    //        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
            //    //        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            //    //        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            //    //    }
            //    //}

            //    //Stock = objBusProductoPreVenta.pProductoBE.Cantidad;
            //    //txtCantidad.SelectAll();
            //    //txtCantidad.Focus();




            ////////////////Desde aqui
            try
            {
                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //seleccionar el tipo cliente y formaPago


                //Busca
                frmBusProductoStockPromocion movDetalle = new frmBusProductoStockPromocion();
                movDetalle.IdTienda = Parametros.intTiendaId;
                movDetalle.IdAlmacen = Parametros.intAlmCentralUcayali;

                int intCorrelativo = 0;
                int i = 0;
                if (mListaPedidoDetalleOrigen.Count > 0)
                    i = mListaPedidoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                movDetalle.Total = Convert.ToDecimal(txtTotal.EditValue);
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                //movDetalle.bPreVenta = chkPreventa.Checked;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.pProductoBE != null)
                    {
                        if (mListaPedidoDetalleOrigen.Count == 0)
                        {
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", intCorrelativo);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", 1);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.pProductoBE.PrecioCDSoles);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.pProductoBE.Descuento);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.pProductoBE.Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", movDetalle.pProductoBE.Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "Promocion");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            btnNuevo.Focus();

                            return;

                        }
                        if (mListaPedidoDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if(movDetalle.pProductoBE.IdProducto == 84652)
                            {
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", intCorrelativo);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.pProductoBE.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.pProductoBE.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.pProductoBE.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.pProductoBE.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", 1);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 1);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.pProductoBE.PrecioCDSoles);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 100);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.pProductoBE.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "Promocion");
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoEntregaTrabajadores);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", Parametros.intAlmCentralUcayali);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", Parametros.intAlmCentralUcayali);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagBultoCerrado", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagNacional", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", 24);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();
                            }
                            else
                            {
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.pProductoBE.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", intCorrelativo);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", movDetalle.pProductoBE.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.pProductoBE.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.pProductoBE.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.pProductoBE.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", 1);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.pProductoBE.PrecioCDSoles);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", movDetalle.pProductoBE.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.pProductoBE.Precio);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", movDetalle.pProductoBE.Precio);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "Promocion");
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.pProductoBE.IdLineaProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();

                                //bNuevo = movDetalle.bNuevo;
                            }


                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            frmDeliveryTarifa movDetalle = new frmDeliveryTarifa();
            if (movDetalle.ShowDialog() == DialogResult.OK)
            {
                decimal Tarifa = movDetalle.oBE.TarifaEnvio;
                string Distrito = movDetalle.oBE.DescUbigeo;
                int Producto = Parametros.intIdProductoDelivery;
                CargarProductoDelivery(Producto, Tarifa, Distrito);

                //Verificar si grabó
                if (gvPedidoDetalle.RowCount > 0)
                {
                    frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
                    frm.IdPedido = IdPedido;
                    frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo cargar datos de Despacho");
                }
            }
        }

        private void cboVendedor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (vIdPersonaPIN == 0)
                {
                    PersonaBE objE_Persona = new PersonaBE();

                    if (pOperacion == Operacion.Modificar || pOperacion == Operacion.Consultar)
                    {
                        return;
                    }

                    objE_Persona = new PersonaBL().Selecciona_UsuarioValidar(Parametros.intEmpresaId, Convert.ToInt32(cboVendedor.EditValue));

                    if (Convert.ToInt32(cboVendedor.EditValue) == Parametros.intPersonaId)
                    { return; }

                    if (objE_Persona != null)
                    {
                        //Cursor = Cursors.WaitCursor;
                        frmAutorizacionUsuarioPedido frmAutoriza = new frmAutorizacionUsuarioPedido();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.vUsuarioValidarlo = objE_Persona.Usuario;
                        frmAutoriza.vClaveValidarlo = objE_Persona.Password;

                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(cboVendedor.EditValue));

                            if (objE_Persona.IdCargo == Parametros.intDisenadorInteriorMaster ||
                                objE_Persona.IdCargo == Parametros.intDisenadorInteriorSenior ||
                                objE_Persona.IdCargo == Parametros.intDisenadorInteriorJunior)
                            {
                                cboTipoVenta.Enabled = true;
                                cboTipoVenta.EditValue = 0;
                                lblAsesor.Visible = false;
                                cboAsesor.Visible = false;
                                cboAsesor.EditValue = 0;
                            }
                            else
                            {
                                cboTipoVenta.Enabled = true;
                            }

                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            cboVendedor.EditValue = Parametros.intPersonaId;
                        }
                    }

                    else
                    {
                        cboVendedor.EditValue = Parametros.intPersonaId;
                    }

                }
                else
                {
                    PersonaBE objE_Persona = new PersonaBE();

                    if (pOperacion == Operacion.Modificar || pOperacion == Operacion.Consultar)
                    {
                        return;
                    }

                    objE_Persona = new PersonaBL().Selecciona_UsuarioValidar(Parametros.intEmpresaId, Convert.ToInt32(vIdPersonaPIN));

                    if (Convert.ToInt32(cboVendedor.EditValue) == Parametros.intPersonaId)
                    { return; }

                    if (objE_Persona != null)
                    {
                        //Cursor = Cursors.WaitCursor;
                        //frmAutorizacionUsuarioPedido frmAutoriza = new frmAutorizacionUsuarioPedido();
                        //frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        //frmAutoriza.vUsuarioValidarlo = objE_Persona.Usuario;
                        //frmAutoriza.vClaveValidarlo = objE_Persona.Password;

                        //frmAutoriza.ShowDialog();

                        //if (frmAutoriza.Edita)
                        //{
                            objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(vIdPersonaPIN));

                            if (objE_Persona.IdCargo == Parametros.intDisenadorInteriorMaster ||
                                objE_Persona.IdCargo == Parametros.intDisenadorInteriorSenior ||
                                objE_Persona.IdCargo == Parametros.intDisenadorInteriorJunior)
                            {
                                cboTipoVenta.Enabled = true;
                                cboTipoVenta.EditValue = 0;
                                lblAsesor.Visible = false;
                                cboAsesor.Visible = false;
                                cboAsesor.EditValue = 0;
                            }
                            else
                            {
                                cboTipoVenta.Enabled = true;
                            }

                            Cursor = Cursors.Default;
                        //}
                        //else
                        //{
                        //    cboVendedor.EditValue = Parametros.intPersonaId;
                        //}
                    }

                    //else
                    //{
                    //    cboVendedor.EditValue = Parametros.intPersonaId;
                    //}



                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTipoCliente_EditValueChanged(object sender, EventArgs e)
        {
            if (IdTipoCliente == Parametros.intTipClienteMayorista)
            {
                //cboTipoVenta.Enabled = false;
                //cboTipoVenta.EditValue = 0;
                lblAsesor.Visible = false;
                cboAsesor.Visible = false;
                cboAsesor.EditValue = 0;
            }
            else
            {
                cboTipoVenta.Enabled = true;
            }
        }

        private void chkPreventa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreventa.Checked)
            {
                panelPreventa.Visible = true;
                //btnEditar.Visible = true;
            }
            else
            {
                panelPreventa.Visible = false;
                //btnEditar.Visible = false;
            }
        }

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMotivoVentaNavidad)//navidad verificar mes
            //{
            //    chkPreventa.Checked = true;
            //}
            //else
            //{ chkPreventa.Checked = false; }
        }

        private void cboClientePromocion_EditValueChanged(object sender, EventArgs e)
        {
            if (cboClientePromocion.EditValue.ToString() != "0")
            {
                var item = cboClientePromocion.GetSelectedDataRow() as DescuentoClientePromocionBE;
                //XtraMessageBox.Show(item.IdDescuentoClientePromocion.ToString() +" - "+ item.Descuento.ToString(), this.Text);
                DescuentoClientePromocion = item.Descuento;
                IdDescuentoClientePromocion = item.IdDescuentoClientePromocion;
                ItemsDescuentoPromocion = item.Items;
                if (item.IdDescuentoClientePromocion > 0)
                {
                    txtObservaciones.Text = item.Descripcion;
                }
                else
                {
                    txtObservaciones.Text = "";
                }
            }
        }

        private void btnClientePromocion_Click(object sender, EventArgs e)
        {
            mDescuentoClientePromocion = new DescuentoClientePromocionBL().ListaCombo(0);
            if (mDescuentoClientePromocion.Count > 0)
            {
                cboClientePromocion.Visible = true;
                cboClientePromocion.Properties.DataSource = mDescuentoClientePromocion;
                //cboClientePromocion.Properties.ShowHeader = false;
                //cboPromocionEventual.Properties.ShowFooter = false;
                //cboClientePromocion.EditValue = mDescuentoClientePromocion.FirstOrDefault();
                cboClientePromocion.EditValue = mDescuentoClientePromocion[0].IdDescuentoClientePromocion;
                cboClientePromocion.Properties.DisplayMember = "Descripcion";
                btnClientePromocion.Visible = false;
            }
        }

        private void gvPedidoDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedidoDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["DescPromocion"]);
                    if (objDocRetiro != null)
                    {
                        string IdTipoDocumento = objDocRetiro.ToString();//int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == "2x1")
                        {
                            e.Appearance.BackColor = Color.YellowGreen;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == "3x2")
                        {
                            e.Appearance.BackColor = Color.Pink;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == "6x3")
                        {
                            e.Appearance.BackColor = Color.MediumPurple;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                    }

                    object objDocRetiroNac = View.GetRowCellValue(e.RowHandle, View.Columns["FlagNacional"]); //o en Descuento
                    if (objDocRetiroNac != null)
                    {
                        bool IdTipoDocumento = bool.Parse(objDocRetiroNac.ToString());
                        if (IdTipoDocumento)
                        {
                            gvPedidoDetalle.Columns["Item"].AppearanceCell.BackColor = Color.Red;
                            gvPedidoDetalle.Columns["Item"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else
                        {
                            gvPedidoDetalle.Columns["Item"].AppearanceCell.BackColor = Color.White;
                            gvPedidoDetalle.Columns["Item"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                if (pOperacion == Operacion.Consultar)
                {
                    return;
                }

                string saludo = txtNumeroDocumento.Text.Trim();
                //     string saludo = "Hola";
                foreach (char letra in saludo)
                {
                    if (!char.IsDigit(letra))
                    {
                    //  //  MessageBox.Show("es numero!!! " + letra, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                    //else
                    //{
                        MessageBox.Show("El numero de documento del cliente contiene letras, esto no esta permitido. " + saludo.Trim() + "\n Corrija y vuelva a intentarlo.", "ERROR: Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Cursor = Cursors.WaitCursor;

                ////Calcula Totales
                ////CalculaTotales();
                #region "Grabar Cab Det"
                if (!ValidarIngreso())
                {
                    Int32 Numero = 0;

                    PedidoBL objBL_Pedido = new PedidoBL();
                    PedidoBE objPedido = new PedidoBE();

                    objPedido.IdPedido = IdPedido;
                    objPedido.IdTienda = IdTienda;//Parametros.intTiendaId;
                    objPedido.IdCampana = 3;
                    objPedido.Periodo = Periodo;//Parametros.intPeriodo;
                    objPedido.Mes = deFecha.DateTime.Month;
                    objPedido.IdProforma = IdProforma == 0 ? (Int32?)null : IdProforma;
                    objPedido.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objPedido.Serie = "0";
                    objPedido.Numero = txtNumero.Text;
                    objPedido.IdPedidoReferencia = IdPedidoReferencia == 0 ? (Int32?)null : IdPedidoReferencia;//IdPedidoReferencia;
                    objPedido.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPedido.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objPedido.FechaCancelacion = (DateTime?)null;
                    objPedido.IdCliente = IdCliente;
                    objPedido.NumeroDocumento = txtNumeroDocumento.Text;
                    objPedido.DescCliente = txtDescCliente.Text;
                    objPedido.Direccion = txtDireccion.Text;
                    objPedido.IdClienteAsociado = IdClienteAsociado; //Add  *****verificar null
                    objPedido.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPedido.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objPedido.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objPedido.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objPedido.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objPedido.Descuento = Convert.ToDecimal(txtTotalDscto2x1.EditValue);
                    objPedido.PorcentajeImpuesto = Parametros.dmlIGV;
                    objPedido.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objPedido.Icbper = Convert.ToDecimal(txtICBPER.EditValue);
                    objPedido.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objPedido.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objPedido.Observacion = txtObservaciones.Text; //Agregar si es liquidacion **************
                    objPedido.IdCombo = Convert.ToInt32(cboCombo.EditValue);
                    objPedido.Despachar = cboCaja.Text;
                    objPedido.IdTipoVenta = Convert.ToInt32(cboTipoVenta.EditValue);
                    objPedido.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objPedido.IdAsesor = Convert.ToInt32(cboAsesor.EditValue);
                    objPedido.IdAsesorExterno = IdAsesorExterno;// Convert.ToInt32(cboAsesorExterno.EditValue);
                    objPedido.FlagPreVenta = chkPreventa.Checked;
                    objPedido.FlagEstado = true;
                    objPedido.Usuario = Parametros.strUsuarioLogin;
                    objPedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPedido.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objPedido.bOrigenFlagPreVenta = bOrigenFlagPreventa;
                    objPedido.FlagImpresionRus = FlagImpresionRus;
                    objPedido.IdContratoFabricacion = IdContratoFabricacion;
                    objPedido.IdProyectoServicio = IdProyectoServicio;
                    objPedido.IdNovioRegalo = IdNovioRegalo;

                    //    //Pedido Detalle
                    //    List<PedidoDetalleBE> lstPedidoDetalle = new List<PedidoDetalleBE>();

                    //    foreach (var item in mListaPedidoDetalleOrigen)
                    //    {
                    //        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                    //        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                    //        objE_PedidoDetalle.IdPedido = item.IdPedido;
                    //        objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                    //        objE_PedidoDetalle.Item = item.Item;
                    //        objE_PedidoDetalle.IdProducto = item.IdProducto;
                    //        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                    //        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                    //        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                    //        objE_PedidoDetalle.Cantidad = item.Cantidad;
                    //        objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                    //        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                    //        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    //        objE_PedidoDetalle.Descuento = item.Descuento;
                    //        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                    //        objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                    //        if (item.FlagMuestra)
                    //            objE_PedidoDetalle.Observacion = "MUESTRA";
                    //        else
                    //            objE_PedidoDetalle.Observacion = item.Observacion;
                    //        objE_PedidoDetalle.IdKardex = item.IdKardex;
                    //        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen;
                    //        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                    //        objE_PedidoDetalle.FlagRegalo = false;
                    //        objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                    //        objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                    //        objE_PedidoDetalle.FlagEstado = true;
                    //        objE_PedidoDetalle.TipoOper = item.TipoOper;
                    //        lstPedidoDetalle.Add(objE_PedidoDetalle);
                    //    }

                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    //    //ObtenerCorrelativo();

                    //    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                    //    {
                    //        objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                    //    }
                    //    else
                    //    {
                    //        objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMinorista);
                    //    }

                    //    objPedido.IdSituacion = Parametros.intPVGenerado;
                    //    Numero = objBL_Pedido.Inserta(objPedido, lstPedidoDetalle);

                    //    PedidoBE objE_Pedido = null;
                    //    objE_Pedido = new PedidoBL().Selecciona(Numero);
                    //    txtNumero.Text = objE_Pedido.Numero;

                    ////Grabar movimiento de pedido
                    //if (IdPedidoReferencia > 0)
                    //{
                    //    MovimientoAlmacenBL objBL_MovimientoPedido = new MovimientoAlmacenBL();
                    //    objBL_MovimientoPedido.CopiarDatosEnvio(Convert.ToInt32(IdPedidoReferencia), Numero);
                    //}


                    //}
                    //else
                    //{
                    //    Numero = IdPedido;
                    //    objPedido.TipoCambio = dmlTipoCambio;
                    //    objPedido.IdSituacion = IdSituacionModifica;
                    //    objBL_Pedido.Actualiza(objPedido, lstPedidoDetalle);
                    //}

                    Numero = IdPedido;
                    objPedido.TipoCambio = dmlTipoCambio;
                    objPedido.IdSituacion = IdSituacionModifica;
                    objBL_Pedido.ActualizaCabecera(objPedido);
                }
                #endregion
                //if (XtraMessageBox.Show("Está seguro de Terminar con la edición de Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{

                if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                {
                    //IdPedido = Numero;
                    //Actualiza Estado Impresion
                    PedidoBL objBL_Pedido = new PedidoBL();
                    PedidoBE objE_Pedido = new PedidoBE();
                    objE_Pedido = new PedidoBL().SeleccionaImpresion(IdPedido);

                    if (objE_Pedido.FlagImpresion == true && bFlagModificarAlmacen == false)//modif 2501 &&almac
                    {
                        XtraMessageBox.Show("El pedido ya ha sido impreso, por favor Consultar con la Recepcionista de pedido contado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Parametros.bImpresionPedidoDirecto)
                        {
                            if (Parametros.intTiendaId == Parametros.intTiendaUcayali  || Parametros.intTiendaId == Parametros.intTiendaAviacion2 ) //add temp 29122017
                            {
                                bool Imprimir = false;
                                foreach (var item in mListaPedidoDetalleOrigen)
                                {
                                    if (!item.FlagMuestra)
                                    {
                                        Imprimir = true;
                                    }
                                }

                                if (Imprimir)
                                {
                                    List<ReportePedidoContadoBE> lstReporte = null;
                                    lstReporte = new ReportePedidoContadoBL().Listado(Periodo, IdPedido, Parametros.intTiendaId);

                                    #region "Codigo Barras"

                                    iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                                    bc.TextAlignment = Element.ALIGN_LEFT;
                                    bc.Code = lstReporte[0].Numero;
                                    bc.StartStopText = false;
                                    bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                                    bc.Extended = true;
                                    bc.BarHeight = 27;
                                    lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                                    #endregion

                                    if (lstReporte.Count > 0)
                                    {
                                        rptPedidoContadoTicket objReporteGuia = new rptPedidoContadoTicket();
                                        objReporteGuia.SetDataSource(lstReporte);
                                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                                        //objReporteGuia.PrintOptions.PrinterName = @"EPSON FX-890 ESC/P";
                                        //objReporteGuia.PrintToPrinter(1, false, 0, 0);

                                        #region "Buscar Impresora ..."
                                        bool found = false;
                                        PrinterSettings prtSetting = new PrinterSettings();
                                        foreach (string prtName in PrinterSettings.InstalledPrinters)
                                        {
                                            string printer = "";
                                            if (prtName.StartsWith("\\\\"))
                                            {
                                                printer = prtName.Substring(3);
                                                printer = printer.Substring(printer.IndexOf("\\") + 1);
                                            }
                                            else
                                                printer = prtName;

                                            if (printer.ToUpper().StartsWith("(P)"))
                                            {
                                                found = true;
                                                PrintOptions bufPO = objReporteGuia.PrintOptions;
                                                prtSetting.PrinterName = prtName;
                                                objReporteGuia.PrintOptions.PrinterName = prtName;

                                                Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                                break;
                                            }
                                        }

                                        if (!found)
                                        {
                                            Cursor = Cursors.Default;
                                            MessageBox.Show("La impresora (P) Nombre para Pedido de Venta no ha sido encontrada.");
                                            return;
                                        }
                                        //Actualiza Impresión
                                        objBL_Pedido.ActualizaImpresion(IdPedido, true);

                                        //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                                        MessageBox.Show("El pedido se imprimió correctamente");// se envió a  + prtName);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    XtraMessageBox.Show("El pedido es sólo MUESTRA, No se imprimirá en Almacen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    objBL_Pedido.ActualizaImpresion(IdPedido, true);
                                }
                            }
                            else
                            {
                                //PedidoBL objBL_Pedido = new PedidoBL();
                                objBL_Pedido.ActualizaImpresion(IdPedido, true);

                                //Carga Informe

                                frmListaPrinters frmPrinter = new frmListaPrinters();
                                if (frmPrinter.ShowDialog() == DialogResult.OK)
                                {
                                    List<ReportePedidoContadoBE> lstReporte = null;
                                    lstReporte = new ReportePedidoContadoBL().Listado(Periodo, IdPedido, Parametros.intTiendaId);

                                    #region "Codigo Barras"
                                    iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                                    bc.TextAlignment = Element.ALIGN_LEFT;
                                    bc.Code = lstReporte[0].Numero;
                                    bc.StartStopText = false;
                                    bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                                    bc.Extended = true;
                                    bc.BarHeight = 27;
                                    lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                                    #endregion

                                    if (lstReporte.Count > 0)
                                    {
                                        if(Parametros.intTiendaId == Parametros.intTiendaAndahuaylas|| Parametros.intTiendaId == Parametros.intTiendaAviacion || 
                                           Parametros.intTiendaId == Parametros.intTiendaPrescott )
                                        {
                                            rptPedidoContadoTicket objReporteGuia = new rptPedidoContadoTicket();
                                            objReporteGuia.SetDataSource(lstReporte);
                                            objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                            objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                            objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");

                                            Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                        }
                                        //else if(Parametros.intTiendaId == Parametros.intTiendaPrescott)
                                        //{
                                            //#region "Impresión matricial"
                                            //CreaTicket ticket = new CreaTicket();
                                            //ticket.impresora = frmPrinter.strNamePrinter;
                                            ////ticket.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                            //ticket.TextoCentro("***** " + lstReporte[0].Numero + " *****");
                                            //ticket.TextoIzquierda("");
                                            //ticket.TextoIzquierda("TIENDA : " + lstReporte[0].DescTienda);
                                            //ticket.TextoIzquierda("FECHA  : " + lstReporte[0].Fecha.ToShortDateString() + "    " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                            //ticket.TextoIzquierda("CLIENTE: " + lstReporte[0].DescCliente);
                                            //ticket.TextoIzquierda("DOCMTO.: " + lstReporte[0].NumeroDocumento);
                                            //ticket.TextoIzquierda("VENDEDOR: " + lstReporte[0].DescVendedor);
                                            //ticket.TextoIzquierda("FORMPAGO: " + lstReporte[0].DescFormaPago);
                                            //ticket.TextoIzquierda("EQUIPO  : " + WindowsIdentity.GetCurrent().Name.ToString());
                                            //ticket.TextoIzquierda("USUARIO : " + Parametros.strUsuarioLogin);
                                            //ticket.TextoIzquierda("");
                                            //ticket.TextoIzquierda("DESPACHADOR:-----------------------------");
                                            ////ticket.LineasGuion();
                                            ////ticket.EncabezadoVenta();
                                            //ticket.TextoIzquierda("CANT      ARTICULO");
                                            //ticket.LineasGuion();
                                            //foreach (var item in lstReporte)
                                            //{
                                            //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                            //    //ticket.AgregaArticuloDetalle(item.NombreProducto.PadRight(, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                            //    ticket.TextoIzquierda((item.UbicacionUcayali + "   " + item.NombreProducto).Trim());
                                            //}
                                            //ticket.LineasGuion();
                                            //ticket.TextoIzquierda("OBS.:" + lstReporte[0].Observacion);
                                            //ticket.TextoIzquierda("");
                                            //ticket.TextoIzquierda("");
                                            //ticket.TextoIzquierda("");
                                            //ticket.TextoCentro("-----------------------------");
                                            //ticket.TextoCentro("RECIBI CONFORME");
                                            //ticket.CortaTicket();
                                            //#endregion
                                        //}
                                        else
                                        {
                                            rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                                            objReporteGuia.SetDataSource(lstReporte);
                                            objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                            objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                            objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");

                                            Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                        }
                                    }
                                }
                            }




//---------------------------77777777

                        }
                        else
                        {
                            //PedidoBL objBL_Pedido = new PedidoBL();
                            objBL_Pedido.ActualizaImpresion(IdPedido, true);

                            //Carga Informe
                            frmListaPrinters frmPrinter = new frmListaPrinters();
                            if (frmPrinter.ShowDialog() == DialogResult.OK)
                            {
                                List<ReportePedidoContadoBE> lstReporte = null;
                                lstReporte = new ReportePedidoContadoBL().Listado(Periodo, IdPedido, Parametros.intTiendaId);

                                #region "Codigo Barras"

                                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                                bc.TextAlignment = Element.ALIGN_LEFT;
                                bc.Code = lstReporte[0].Numero;
                                bc.StartStopText = false;
                                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                                bc.Extended = true;
                                bc.BarHeight = 27;
                                lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                                #endregion


                                if (lstReporte.Count > 0)
                                {
                                    if (Parametros.intTiendaId == Parametros.intTiendaUcayali) //add temp 29122017
                                    {
                                        rptPedidoContadoTicket objReporteGuia = new rptPedidoContadoTicket();
                                        objReporteGuia.SetDataSource(lstReporte);
                                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                                        //addd 300715
                                        //objReporteGuia.SetParameterValue("Modificado", "()");//add
                                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                    }
                                    else
                                    {
                                        rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                                        objReporteGuia.SetDataSource(lstReporte);
                                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                                        //addd 300715
                                        //objReporteGuia.SetParameterValue("Modificado", "()");//add
                                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                                    }

                                    //rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                                    //objReporteGuia.SetDataSource(lstReporte);
                                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                                    ////addd 300715
                                    ////objReporteGuia.SetParameterValue("Modificado", "()");//add
                                    //objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                                    ///*if (pOperacion == Operacion.Nuevo)
                                    //{
                                    //    objReporteGuia.SetParameterValue("Modificado", "()");
                                    //    Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                                    //}
                                    //else
                                    //{

                                    //    rptPedidoContadoModifica objReporteGuiaMod = new rptPedidoContadoModifica();
                                    //    objReporteGuiaMod.SetDataSource(lstReporte);
                                    //    objReporteGuiaMod.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                    //    objReporteGuiaMod.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                    //    objReporteGuiaMod.SetParameterValue("Modificado", "(MODIFICADO)");
                                    //    Impresion.Imprimir(objReporteGuiaMod, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                                    //}*/

                                    ////Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                                }
                            }
                        }
                    }
                }


                //Actualizar estado Encuesta
                if (bEncuesta)
                {
                    EncuestaBL ObjBL_Encuesta = new EncuestaBL();
                    ObjBL_Encuesta.ActualizaFlagDescuento(IdCliente);
                }
                Cursor = Cursors.Default;

                EBotonGrabar = 1;

                TotalPedido = Convert.ToDecimal(txtTotal.EditValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
                //}
                //else
                //{
                //    Cursor = Cursors.Default;
                //    return;
                //}

                CalculaTotales();


            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void chkVale_CheckedChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Modificar)
            {
                CalculaTotales();
            }
            if (pOperacion == Operacion.Nuevo)
            {
                txtTotal_EditValueChanged(sender, e);
            }
        }

        private void eliminarpromocion2x1toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPedidoDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPedidoDetalle = 0;
                        int? IdPromocion = null;
                        int IdProducto = 0;

                        if (gvPedidoDetalle.GetFocusedRowCellValue("IdPedidoDetalle") != null)
                            IdPedidoDetalle = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdPedidoDetalle").ToString());
                        if (gvPedidoDetalle.GetFocusedRowCellValue("IdProducto") != null)
                            IdProducto = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdProducto").ToString());

                        //IdPromocion = gvPedidoDetalle.GetFocusedRowCellValue("IdPromocion") == null ? (Int32?)null : int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdPromocion").ToString());//Almacen
                        //objBE_PedidoDetalle.FlagPreventa = chkPreventa.Checked;
                        //objBE_PedidoDetalle.Usuario = Parametros.strUsuarioLogin;
                        //objBE_PedidoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                        objBL_PedidoDetalle.ActualizaPromocion(IdPedidoDetalle, IdPromocion, IdTipoCliente, IdProducto, "");
                        //gvPedidoDetalle.DeleteRow(gvPedidoDetalle.FocusedRowHandle);
                        gvPedidoDetalle.RefreshData();

                        CargaPedidoDetalle();//add 1012

                        CalculaTotales();

                        //Actualizar detalle 
                        if (Parametros.bValidarStockDetallePedido == true) //280715
                        {
                            if (chkPreventa.Checked == false)
                            {
                                GrabarDesdeDetalle();
                                CargaPedidoDetalle();
                            }
                        }
                    }
                    else
                    {
                        //gvPedidoDetalle.DeleteRow(gvPedidoDetalle.FocusedRowHandle);
                        //gvPedidoDetalle.RefreshData();
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gvPedidoDetalle_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //try
            //{
            //    object obj = gvPedidoDetalle.GetRow(e.RowHandle);

            //    GridView View = sender as GridView;
            //    if (e.RowHandle >= 0)
            //    {
            //        object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FlagNacional"]); //o en Descuento
            //        if (objDocRetiro != null)
            //        {
            //            bool IdTipoDocumento = bool.Parse(objDocRetiro.ToString());
            //            if (IdTipoDocumento)
            //            {
            //                gvPedidoDetalle.Columns["Item"].AppearanceCell.BackColor = Color.Red;
            //                gvPedidoDetalle.Columns["Item"].AppearanceCell.BackColor2 = Color.SeaShell;
            //                e.Appearance.BackColor = Color.Red;
            //                e.Appearance.BackColor2 = Color.SeaShell;
            //            }

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtDniDiseñador_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (char.IsNumber(Convert.ToChar(txtDniDiseñador.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtDniDiseñador.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.IdClasificacionCliente != Parametros.intClubDesign)
                        {
                            XtraMessageBox.Show("La persona seleccionada NO es un asesor externo, Verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        IdAsesorExterno = objE_Cliente.IdCliente;
                        txtDniDiseñador.Text = objE_Cliente.NumeroDocumento;
                        txtNombreDiseñador.Text = objE_Cliente.DescCliente;

                        ////Calcula Cumpleaños
                        //DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        //int PeriodoNac = FechaNac.Year;
                        //int Anios = Parametros.intPeriodo - PeriodoNac;

                        ////Compras del mes
                        //List<DocumentoVentaBE> lstVenta = null;
                        //lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                        //if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                        //{
                        //    lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                        //    bCumpleAnios = true;
                        //    btnEliminarCumpleanios.Visible = true;
                        //}
                        //else
                        //{
                        //    lblMensaje.Text = "";
                        //    bCumpleAnios = false;
                        //    btnEliminarCumpleanios.Visible = false;
                        //}
                        txtDniDiseñador.Properties.ReadOnly = true;
                        btnNuevo.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    frmBusCliente frm = new frmBusCliente();
                    frm.pNumeroDescCliente = txtDniDiseñador.Text;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pClienteBE != null)
                    {
                        ClienteBE objE_Cliente = null;
                        objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, frm.pClienteBE.NumeroDocumento);

                        if (objE_Cliente.IdClasificacionCliente != Parametros.intClubDesign)
                        {
                            XtraMessageBox.Show("La persona seleccionada NO es un asesor externo, Verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        IdAsesorExterno = objE_Cliente.IdCliente;
                        txtDniDiseñador.Text = objE_Cliente.NumeroDocumento;
                        txtNombreDiseñador.Text = objE_Cliente.DescCliente;

                        ////Calcula Cumpleaños
                        //DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        //int PeriodoNac = FechaNac.Year;
                        //int Anios = Parametros.intPeriodo - PeriodoNac;

                        ////Compras del mes
                        //List<DocumentoVentaBE> lstVenta = null;
                        //lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                        //if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                        //{
                        //    lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                        //    bCumpleAnios = true;
                        //    btnEliminarCumpleanios.Visible = true;
                        //}
                        //else
                        //{
                        //    lblMensaje.Text = "";
                        //    bCumpleAnios = false;
                        //    btnEliminarCumpleanios.Visible = false;
                        //}
                        txtDniDiseñador.Properties.ReadOnly = true;
                        btnNuevo.Focus();
                    }

                }
            }
        }

        private void btnBuscarDiseñador_Click(object sender, EventArgs e)
        {
            frmBusCliente frm = new frmBusCliente();
            frm.pNumeroDescCliente = txtDniDiseñador.Text;
            frm.pFlagMultiSelect = false;
            frm.ShowDialog();
            if (frm.pClienteBE != null)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, frm.pClienteBE.NumeroDocumento);

                if(objE_Cliente.IdClasificacionCliente !=Parametros.intClubDesign)
                {
                    XtraMessageBox.Show("La persona seleccionada NO es un asesor externo, Verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //if (objE_Cliente.FlagAsesorExterno == false)
                //{
                //    XtraMessageBox.Show("La persona seleccionada NO es un asesor externo, Verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                IdAsesorExterno = objE_Cliente.IdCliente;
                txtDniDiseñador.Text = objE_Cliente.NumeroDocumento;
                txtNombreDiseñador.Text = objE_Cliente.DescCliente;
                txtDniDiseñador.Properties.ReadOnly = true;

                ////Calcula Cumpleaños
                //DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                //int PeriodoNac = FechaNac.Year;
                //int Anios = Parametros.intPeriodo - PeriodoNac;

                ////Compras del mes
                //List<DocumentoVentaBE> lstVenta = null;
                //lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                //if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                //{
                //    lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                //    bCumpleAnios = true;
                //    btnEliminarCumpleanios.Visible = true;
                //}
                //else
                //{
                //    lblMensaje.Text = "";
                //    bCumpleAnios = false;
                //    btnEliminarCumpleanios.Visible = false;
                //}

                btnNuevo.Focus();
            }
        }

        private void btnInstalacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPedido == 0)
                {
                    XtraMessageBox.Show("El número de Pedido no Existe!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                //Verficar Pedido existente
                HojaInstalacionDetalleBE ObjE_Hoja = null;
                ObjE_Hoja = new HojaInstalacionDetalleBL().SeleccionaPedido(IdPedido);
                if (ObjE_Hoja != null)
                {
                    string mensajeInstalacion = "";
                    if (ObjE_Hoja.Fecha > DateTime.Now)
                        mensajeInstalacion = "se instalará el ";
                    else
                        mensajeInstalacion = "fue instalado el ";

                    if (XtraMessageBox.Show("El pedido " + mensajeInstalacion + "día " + ObjE_Hoja.Fecha.ToShortDateString().ToString() + ", Desea abrir el archivo?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        HojaInstalacionBE objHojaInstalacion = new HojaInstalacionBE();

                        objHojaInstalacion.IdHojaInstalacion = ObjE_Hoja.IdHojaInstalacion;
                        frmRegHojaInstalacionEdit objManHojaInstalacionEdit = new frmRegHojaInstalacionEdit();
                        objManHojaInstalacionEdit.pOperacion = frmRegHojaInstalacionEdit.Operacion.Modificar;
                        objManHojaInstalacionEdit.IdHojaInstalacion = objHojaInstalacion.IdHojaInstalacion;
                        objManHojaInstalacionEdit.pHojaInstalacionBE = objHojaInstalacion;
                        objManHojaInstalacionEdit.Origen = 1;
                        objManHojaInstalacionEdit.IdPedido = IdPedido;
                        objManHojaInstalacionEdit.StartPosition = FormStartPosition.CenterParent;
                        objManHojaInstalacionEdit.ShowDialog();
                    }
                }
                else
                {
                    HojaInstalacionDetalleBE objE_HojaInstalacionDetalle = new HojaInstalacionDetalleBE();
                    objE_HojaInstalacionDetalle.IdPedido = IdPedido;
                    objE_HojaInstalacionDetalle.NumeroPedido = txtNumero.Text;
                    objE_HojaInstalacionDetalle.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objE_HojaInstalacionDetalle.FlagEstado = true;

                    frmRegHojaInstalacionEdit objManHojaInstalacion = new frmRegHojaInstalacionEdit();
                    //objManHojaInstalacion.lstHojaInstalacion = mLista;
                    objManHojaInstalacion.pOperacion = frmRegHojaInstalacionEdit.Operacion.Nuevo;
                    objManHojaInstalacion.IdHojaInstalacion = 0;
                    objManHojaInstalacion.Origen = 1;
                    objManHojaInstalacion.IdCliente = IdCliente;
                    objManHojaInstalacion.DescCliente = txtDescCliente.Text;
                    objManHojaInstalacion.Direccion = txtDireccion.Text;
                    objManHojaInstalacion.pHojaInstalacionDetallePedidoBE = objE_HojaInstalacionDetalle;
                    objManHojaInstalacion.StartPosition = FormStartPosition.CenterParent;
                    objManHojaInstalacion.ShowDialog();
                }

                CargaPedidoDetalle();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //frmRegHojaInstalacionPedido frm = new frmRegHojaInstalacionPedido();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
        }

        private void btnEliminarVale_Click(object sender, EventArgs e)
        {
            mListaPromocionVale.Clear();
            btnEliminarVale.Visible = false;
            CalculaTotales();
        }

        private void bntEliminarDsctoVale_Click(object sender, EventArgs e)
        {
            DescuentoVale = 0;
            btnEliminarDsctoVale.Visible = false;
            //CalculaTotales();
        }

        private void btnCargarVale_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("Debido al cambio de políticas. El vale debe presentarse en caja al momento de pagar.",this.Text ,MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //CargarPromocionVale();
            frmVerValeDisponible frm = new frmVerValeDisponible();
            frm.TipoVale = 1;
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnCargarVale.Text = "ON";
                DescuentoVale = frm.DescuentoVale;
                ImporteVale = frm.ImporteVale;
                if (ImporteVale > 0)
                {
                    mListaPromocionVale = new PromocionValeDescuentoBL().ListaTodosActivo(frm.IdPromocionValeDescuento);//add250516
                }
                if (DescuentoVale > 0)
                {
                    btnEliminarDsctoVale.Visible = true;
                    btnEliminarDsctoVale.Text = "Eliminar + " + DescuentoVale + " % Dscto Vale";
                    txtObservaciones.Text = "PROMOCION VALE +" + DescuentoVale + "% " + txtObservaciones.Text;
                }
            }
        }

        private void txtNumeroContrato_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información de la Si
                    Dis_ContratoFabricacionBE objE_Dis_ContratoFabricacion = null;
                    objE_Dis_ContratoFabricacion = new Dis_ContratoFabricacionBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroContrato.Text.Trim());
                    if (objE_Dis_ContratoFabricacion != null)
                    {
                        IdContratoFabricacion = objE_Dis_ContratoFabricacion.IdDis_ContratoFabricacion;
                        txtNumeroContrato.Text = objE_Dis_ContratoFabricacion.Numero;
                        //cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;
                        cboFormaPago.EditValue = Parametros.intContraEntrega;
                        //cboMoneda.EditValue = objE_Dis_ContratoFabricacion.IdMoneda;
                        //txtTipoCambio.EditValue = objE_Dis_ContratoFabricacion.TipoCambio;
                        IdCliente = objE_Dis_ContratoFabricacion.IdCliente;
                        txtNumeroDocumento.Text = objE_Dis_ContratoFabricacion.NumeroDocumento;
                        txtDescCliente.Text = objE_Dis_ContratoFabricacion.DescCliente;
                        //txtTipoCliente.Text = objE_Dis_ContratoFabricacion.DescTipoCliente;
                        txtDireccion.Text = objE_Dis_ContratoFabricacion.Direccion;
                        txtObservaciones.Text = "Contrato Fab. N°:" + txtNumeroContrato.Text;

                        if (objE_Dis_ContratoFabricacion.IdVendedor2 > 0)
                        {
                            cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor2;
                            cboTipoVenta.EditValue = Parametros.intPorAsesoria;
                            cboAsesor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;
                        }
                        else
                        {
                            cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;
                        }

                        if (cboVendedor.Text == "")
                        {
                            XtraMessageBox.Show("El Vendedor que creó el contrato ya Cesó!, por lo tanto, se procederá a crear el pedido con el usuario actual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboVendedor.EditValue = Parametros.intUsuarioId;
                        }



                        //Tramoes la información del detalle de la Dis_ContratoFabricacion
                        List<Dis_ContratoFabricacionDetalleBE> lstTmpDis_ContratoFabricacionDetalle = null;
                        lstTmpDis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBL().ListaTodosActivo(Convert.ToInt32(IdContratoFabricacion));
                        int nItem = 1;
                        foreach (Dis_ContratoFabricacionDetalleBE item in lstTmpDis_ContratoFabricacionDetalle)
                        {
                            if (item.FlagAprobado)
                            {
                                if (item.IdProducto > 0)
                                {
                                    decimal Descuento = 0;
                                    decimal PrecioVenta = 0;

                                    //Test de velociad por Hora
                                    #region "Descuento Promocion Temporal"
                                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), Parametros.intTiendaId, 0, item.IdProducto);
                                    if (objE_PromocionTemporal != null)
                                    {
                                        //if (Convert.ToDecimal(txtDescuento.EditValue) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                        //{
                                        Descuento = objE_PromocionTemporal.Descuento;
                                        PrecioVenta = Math.Round(item.Precio * ((100 - Descuento) / 100), 2);
                                        item.ValorVenta = PrecioVenta * item.Cantidad;
                                        //}
                                    }

                                    #endregion


                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = nItem;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.Precio;//item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = Descuento;// item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = 0; // item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = PrecioVenta;// item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                    objE_PedidoDetalle.Observacion = "CF";//item.Observacion;
                                    objE_PedidoDetalle.IdKardex = 0;
                                    objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.FlagMuestra = false;
                                    objE_PedidoDetalle.FlagRegalo = false;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                                    nItem = nItem + 1;
                                }
                            }
                        }

                        bsListado.DataSource = mListaPedidoDetalleOrigen;
                        gcPedidoDetalle.DataSource = bsListado;
                        gcPedidoDetalle.RefreshDataSource();

                        CalculaTotales();
                    }
                    else
                    {
                        XtraMessageBox.Show("Verificar que la Dis_ContratoFabricacion y los códigos esten aprobados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroProforma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cboTipoDocumentoBusqueda.EditValue) == Parametros.intTipoDocContratoFabricacion)
                {
                    //Validamos si CF tiene pedidos 
                    PedidoBE objE_Dis_ContratoFabricacion = null;
                    objE_Dis_ContratoFabricacion = new PedidoBL().SeleccionaPedidoAsociadoCF(Parametros.intPeriodo, txtNumeroProforma.Text.Trim());
                    if (objE_Dis_ContratoFabricacion != null)
                    {
                        XtraMessageBox.Show("El Contrato de Fabricación tiene asociado un Pedido." + "\n Nro. Pedido: " + objE_Dis_ContratoFabricacion.Numero, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (XtraMessageBox.Show("Está seguro de Importar los datos de " + cboTipoDocumentoBusqueda.Text + " N°" + txtNumeroProforma.Text + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CargarBusquedaDocumento();
                }

            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaTotales();
            }
        }

        private void bntVerNS_Click(object sender, EventArgs e)
        {
            if (IdPedido != 0)
            {
                frmVerMovAlmacenPedido frm = new frmVerMovAlmacenPedido();
                frm.IdPedido = IdPedido;
                frm.ShowDialog();
            }
        }

        private void descuentocupontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Utilizar esta opción de descuento al  terminar de ingresar todo los códigos.");

            frmBusDescuentoProximaCompra frm = new frmBusDescuentoProximaCompra();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
                {
                    int row = i;
                    int IdProducto = int.Parse(gvPedidoDetalle.GetRowCellValue(row, "IdProducto").ToString());

                    ProductoBE objE_Producto = new ProductoBE();
                    objE_Producto = new ProductoBL().SeleccionaMarca(Parametros.intEmpresaId, IdProducto);

                    if (objE_Producto.IdMarca == 3 || objE_Producto.IdMarca == 24 || objE_Producto.IdMarca == 15 || objE_Producto.IdMarca == 19)
                    {
                        decimal decDescuento = 0;
                        decimal decPrecioVenta = 0;
                        decimal decValorVenta = 0;
                        decimal DescuentoAnterior = 0;

                        DescuentoAnterior = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PorcentajeDescuento").ToString());
                        decDescuento = decimal.Parse(frm.Descuento.ToString());
                        gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);

                        decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
                        gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                        gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
                    }
                }

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaPromocionProxima(frm.IdDocumentoVenta, true);

                GrabarDesdeDetalle();
            }

        }

        private void txtNumeroProforma_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDescuentoValeMarca_Click(object sender, EventArgs e)
        {
            int IdPromocionMarca = 0;

            List<PromocionMarcaBE> lst_PromocionMarca = null;
            lst_PromocionMarca = new PromocionMarcaBL().ListaFecha(Parametros.intEmpresaId);
            if (lst_PromocionMarca != null)
            {
                List<PedidoDetalleBE> lst_MarcaPedidoDetalle = null;
                lst_MarcaPedidoDetalle = new PedidoDetalleBL().ListaTotalMarca(IdPedido, 1);//Stock mayor a cero
                if (lst_MarcaPedidoDetalle != null)
                {
                    foreach (var item in lst_MarcaPedidoDetalle)
                    {
                        foreach (var item2 in lst_PromocionMarca)
                        {
                            if (item.IdMarca == item2.IdMarca)
                            {
                                if (item.ValorVenta > item2.MontoMin && item.ValorVenta < item2.MontoMax)
                                {
                                    IdPromocionMarca = item2.IdPromocionMarca;
                                    //abrir formulario de busqueda de productos

                                    //Si es OK
                                    //frm

                                    //VALIDAR APLICAR DOS VECES
                                }
                            }
                        }
                    }

                }


                //foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
                //{
                //    Decimal Total = 0;
                //    Total = Total + item.ValorVenta;

                //}

            }
        }

        private void establecerpreciopublicitariotoolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (IdClasificacionCliente != Parametros.intPublicitario)
            //{
            //    XtraMessageBox.Show("Esta opción es aplicable para clientes publicitarios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //frmModificaPrecioPublicitario objModificaPrecio = new frmModificaPrecioPublicitario();
            //objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            //objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            //objModificaPrecio.ShowDialog();

            //bNuevo = false;
            //txtPrecioUnitario.EditValue = objModificaPrecio.PrecioUnitario;
            //txtDescuento.EditValue = 0;
            //txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            //txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

            //btnAceptar.Focus();



            //foreach(var item in mListaPedidoDetalleOrigen)
            //{
            //    xposition = gvPedidoDetalle.FocusedRowHandle;


            //    gvPedidoDetalle.SetRowCellValue(xposition, "IdEmpresa", item.IdEmpresa);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "IdPedido", item.IdPedido);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "IdPedidoDetalle", item.IdPedidoDetalle);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "Item", item.Item);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "IdProducto", item.IdProducto);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "CodigoProveedor", item.CodigoProveedor);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "NombreProducto", item.NombreProducto);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "Abreviatura", item.Abreviatura);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "Cantidad", item.Cantidad);
            //    //gvPedidoDetalle.SetRowCellValue(xposition, "CantidadAnt", item.CantidadAnt);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "PrecioUnitario", item.PrecioUnitario);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", item.PorcentajeDescuento);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "Descuento", item.Descuento);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "PrecioVenta", item.PrecioVenta);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "ValorVenta", item.ValorVenta);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "Observacion", item.Observacion);
            //    //gvPedidoDetalle.SetRowCellValue(xposition, "IdKardex", item.IdKardex);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "IdAlmacen", item.IdAlmacen);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "FlagMuestra", item.FlagMuestra);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "FlagRegalo", item.FlagRegalo);
            //    //gvPedidoDetalle.SetRowCellValue(xposition, "FlagBultoCerrado", item.FlagBultoCerrado);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "Stock", 0);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "PrecioUnitarioInicial", 0);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "PorcentajeDescuentoInicial", item.PorcentajeDescuentoInicial);
            //    gvPedidoDetalle.SetRowCellValue(xposition, "IdLineaProducto", item.IdLineaProducto);
            //    if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPedidoDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
            //        gvPedidoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
            //    else
            //        gvPedidoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
            //    gvPedidoDetalle.UpdateCurrentRow();

            //    bNuevo = movDetalle.bNuevo;

            //    //AsignarCodigoPromocion();//add may 2 || mod. 201115
            //    CalculaTotales();

            //    //Grabar Detalle - Reservar Stock -- aDD 180815
            //    if (Parametros.bValidarStockDetallePedido == true)
            //    {
            //        if (chkPreventa.Checked == false)
            //        {
            //            GrabarDesdeDetalle();
            //            CargaPedidoDetalle();

            //            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)//add 1708
            //            {
            //                btnEnviarAlmacen.Visible = true;
            //                btnGrabar.Visible = false;
            //            }
            //            else
            //            {
            //                btnEnviarAlmacen.Visible = false;
            //                btnGrabar.Visible = true;
            //            }
            //        }
            //    }

            //    //add by almacen 250116
            //    if (bFlagModificarAlmacen)
            //    {
            //        //DesHabilitarCabecera();
            //        DesHabilitar();
            //    }
            //}

        }

        private void utilizarprecioucayalitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedidoDetalle.RowCount > 0)
                {
                    int IdProductoP = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("IdProducto").ToString());

                    StockBE pProductoBE = null;

                    pProductoBE = new StockBL().SeleccionaIdProductoPrecio(1, 1, IdProductoP);

                    decimal PrecioUnitario = 0;
                    decimal PrecioVenta = 0;
                    decimal ValorVenta = 0;
                    decimal Descuento = 0;
                    int Cantidad = 0;

                    if (pProductoBE != null)
                    {
                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                        {
                            Descuento = decimal.Parse(gvPedidoDetalle.GetFocusedRowCellValue("PorcentajeDescuento").ToString());
                            Cantidad = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("Cantidad").ToString());

                            PrecioUnitario = pProductoBE.PrecioCDSoles;
                            PrecioVenta = Convert.ToDecimal(PrecioUnitario) * ((100 - Convert.ToDecimal(Descuento)) / 100);
                            ValorVenta = Convert.ToDecimal(PrecioVenta) * Convert.ToDecimal(Cantidad);

                            int xposition = gvPedidoDetalle.FocusedRowHandle;
                            gvPedidoDetalle.SetRowCellValue(xposition, "PrecioUnitario", PrecioUnitario);
                            gvPedidoDetalle.SetRowCellValue(xposition, "PrecioVenta", PrecioVenta);
                            gvPedidoDetalle.SetRowCellValue(xposition, "ValorVenta", ValorVenta);

                            CalculaTotales();



                        }
                        else
                        {
                            Descuento = decimal.Parse(gvPedidoDetalle.GetFocusedRowCellValue("PorcentajeDescuento").ToString());
                            Cantidad = int.Parse(gvPedidoDetalle.GetFocusedRowCellValue("Cantidad").ToString());

                            PrecioUnitario = pProductoBE.PrecioCD;
                            PrecioVenta = Convert.ToDecimal(PrecioUnitario) * ((100 - Convert.ToDecimal(Descuento)) / 100);
                            ValorVenta = Convert.ToDecimal(PrecioVenta) * Convert.ToDecimal(Cantidad);

                            int xposition = gvPedidoDetalle.FocusedRowHandle;
                            gvPedidoDetalle.SetRowCellValue(xposition, "PrecioUnitario", PrecioUnitario);
                            gvPedidoDetalle.SetRowCellValue(xposition, "PrecioVenta", PrecioVenta);
                            gvPedidoDetalle.SetRowCellValue(xposition, "ValorVenta", ValorVenta);

                            CalculaTotales();
                        }
                    }

                    CalculaTotales();


                    //Grabar Detalle - Reservar Stock -- aDD 240815
                    if (Parametros.bValidarStockDetallePedido == true)
                    {
                        if (chkPreventa.Checked == false)
                        {
                            GrabarDesdeDetalle();
                            CargaPedidoDetalle();

                            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                            {
                                btnEnviarAlmacen.Visible = true;
                                btnGrabar.Visible = false;
                            }
                            else
                            {
                                btnEnviarAlmacen.Visible = false;
                                btnGrabar.Visible = true;
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se puede aplicar el precio de la Tienda UCAYALI, Por favor comuníquese con SISTEMAS.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void CargarDescuentoClienteMayorista()
        {
            mListaDescuentoClienteMayorista = new DescuentoClienteMayoristaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
        }

        private void CargarDescuentoClienteFechaCompra()
        {
            mListaDescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBL().ListaTodosActivo(Parametros.intEmpresaId);
        }

        private void EstadoDescuentoClienteFechaCompra()
        {
            pParametroBE = new ParametroBL().Selecciona(Parametros.strDescuentoClienteFechaCompra);
            //chkEstado.Checked = pParametroBE.FlagEstado;
        }

        private void CargarProductoPromocionDosPorUno()
        {
            if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime("19/05/2015"))
            {
                mListaDescuentoPromocionDosPorUno = new Promocion2x1DetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), "2x1", Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
            }
        }

        private void CargarProductoPromocion3x2()
        {
            if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime("01/11/2015"))
            {
                mListaDescuentoPromocion3x2 = new Promocion2x1DetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), "3x2", Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
            }
        }

        private void CargarProductoPromocion3x1()
        {
            if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime("01/11/2019"))
            {
                mListaDescuentoPromocion3x1 = new Promocion2x1DetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), "3x1", Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
            }
        }

        private void CargarProductoPromocion4x1()
        {
            if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime("01/11/2019"))
            {
                mListaDescuentoPromocion4x1 = new Promocion2x1DetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), "4x1", Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
            }
        }

        private void CargarProductoPromocion6x3()
        {
            if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime("19/10/2017"))
            {
                mListaDescuentoPromocion6x3 = new Promocion2x1DetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), "6x3", Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
            }
        }

        private void CargarPromocionVale()
        {
            mListaPromocionVale = new PromocionValeDescuentoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId);//add250516
            btnCargarVale.Text = "ON";
        }

        private void LimpiarTextos()
        {
            if (pOperacion == Operacion.Nuevo)
                ObtenerCorrelativo();
            txtNumeroProforma.Text = "";
            IdCliente = 0;
            txtNumeroDocumento.Text = "";
            txtDescCliente.Text = "";
            txtDireccion.Text = "";
            txtObservaciones.Text = "";
            txtTotalCantidad.EditValue = 0;
            txtSubTotal.EditValue = 0;
            txtImpuesto.EditValue = 0;
            txtTotal.EditValue = 0;
            chkPreventa.Checked = false;

            mListaPedidoDetalleOrigen.Clear();
            bsListado.DataSource = mListaPedidoDetalleOrigen;
            gcPedidoDetalle.DataSource = bsListado;
            gcPedidoDetalle.RefreshDataSource();
        }

        private void CargarBusquedaDocumento()
        {
            IdProyectoServicio = 0;
            IdContratoFabricacion = 0;
            IdProforma = 0;
            IdPedido = 0;

            int IdTipoDocumentoCopia = Convert.ToInt32(cboTipoDocumentoBusqueda.EditValue);

            #region "Pedido"

            if (IdTipoDocumentoCopia == Parametros.intTipoDocPedidoVenta)
            {
                if (XtraMessageBox.Show("Desea Actualizar los precios y tipo de cambio Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    #region "Pedido Actualizado"
                    //Traemos la información del Pedido
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim());
                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.FlagPreVenta == true)
                        {
                            #region "Pedido Preventa"

                            //if (objE_Pedido.IdSituacion == Parametros.intPVGenerado || objE_Pedido.IdSituacion == Parametros.intPVAnulado) //Factudo
                            //{
                            //    XtraMessageBox.Show("No se puede Generar pedido N°" + txtNumeroPedido.Text + ", No está Aprobado! \nSituación Actual: " + objE_Pedido.DescSituacion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true); //add 31-08-15

                            cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                            cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                            txtNumero.Text = objE_Pedido.Numero;
                            txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                            cboVendedor.EditValue = objE_Pedido.IdVendedor;
                            cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                            deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                            cboMoneda.EditValue = objE_Pedido.IdMoneda;
                            txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                            IdCliente = objE_Pedido.IdCliente;
                            IdTipoCliente = objE_Pedido.IdTipoCliente;
                            IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                            txtDescCliente.Text = objE_Pedido.DescCliente;
                            if (IdTipoCliente == Parametros.intTipClienteFinal)
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                            else
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                            txtDireccion.Text = objE_Pedido.Direccion;
                            cboCombo.EditValue = objE_Pedido.IdCombo;
                            cboCaja.Text = objE_Pedido.Despachar;
                            txtObservaciones.Text = objE_Pedido.Observacion;
                            txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                            txtSubTotal.EditValue = objE_Pedido.SubTotal;
                            txtImpuesto.EditValue = objE_Pedido.Igv;
                            txtTotal.EditValue = objE_Pedido.Total;
                            //chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                            chkPreventa.Checked = false;
                            cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                            cboMotivo.EditValue = objE_Pedido.IdMotivo;
                            txtObservaciones.Text = "MODIFICACIÓN PV DEL PEDIDO : " + objE_Pedido.Numero;
                            IdPedidoReferencia = objE_Pedido.IdPedido;
                            bOrigenFlagPreventa = true;
                            txtDescuento.EditValue = Parametros.dmlDescuentoPreventaVenta; //add 31-08

                            //Carga ClienteAsociado
                            CargarClienteAsociado();
                            cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                            gcPedidoDetalle.Focus();

                            //Seteamos el Pedido
                            SeteaPedidoDetalle();

                            //Traemos la información del detalle del Pedido

                            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoActualizadoStock(objE_Pedido.IdPedido);

                            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                            {
                                CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                objE_PedidoDetalle.IdPedido = 0;
                                objE_PedidoDetalle.IdPedidoDetalle = 0;
                                objE_PedidoDetalle.Item = item.Item;
                                objE_PedidoDetalle.IdProducto = item.IdProducto;
                                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                objE_PedidoDetalle.Cantidad = item.Cantidad;
                                objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                objE_PedidoDetalle.Descuento = item.Descuento;
                                objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                objE_PedidoDetalle.IdKardex = item.IdKardex;
                                //objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali; //add
                                objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                objE_PedidoDetalle.Observacion = item.Observacion;
                                objE_PedidoDetalle.Stock = 0;
                                objE_PedidoDetalle.TipoOper = item.TipoOper;
                                mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                            }

                            bsListado.DataSource = mListaPedidoDetalleOrigen;
                            gcPedidoDetalle.DataSource = bsListado;
                            gcPedidoDetalle.RefreshDataSource();

                            CalculaTotales();
                            #endregion
                        }
                        else
                        {
                            #region "Pedido Normal"
                            cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                            cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                            txtNumero.Text = objE_Pedido.Numero;
                            txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                            cboVendedor.EditValue = objE_Pedido.IdVendedor;
                            cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                            deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                            cboMoneda.EditValue = objE_Pedido.IdMoneda;
                            txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                            IdCliente = objE_Pedido.IdCliente;
                            IdTipoCliente = objE_Pedido.IdTipoCliente;
                            IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                            txtDescCliente.Text = objE_Pedido.DescCliente;
                            if (IdTipoCliente == Parametros.intTipClienteFinal)
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                            else
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                            txtDireccion.Text = objE_Pedido.Direccion;
                            cboCombo.EditValue = objE_Pedido.IdCombo;
                            cboCaja.Text = objE_Pedido.Despachar;
                            txtObservaciones.Text = objE_Pedido.Observacion;
                            txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                            txtSubTotal.EditValue = objE_Pedido.SubTotal;
                            txtImpuesto.EditValue = objE_Pedido.Igv;
                            txtTotal.EditValue = objE_Pedido.Total;
                            chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                            cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                            cboMotivo.EditValue = objE_Pedido.IdMotivo;
                            txtObservaciones.Text = "MODIFICACIÓN DEL PEDIDO : " + objE_Pedido.Numero;
                            IdPedidoReferencia = objE_Pedido.IdPedido;

                            //Carga ClienteAsociado
                            CargarClienteAsociado();
                            cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                            gcPedidoDetalle.Focus();

                            //Seteamos el Pedido
                            SeteaPedidoDetalle();

                            //Traemos la información del detalle del Pedido

                            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoActualizado(objE_Pedido.IdPedido);

                            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                            {
                                #region "Validar Stock Físico"

                                int CantidadDisponible = 0;
                                StockBE objE_Stock = new StockBE();
                                objE_Stock = new StockBL().SeleccionaCantidadIdProducto(item.IdTienda, Convert.ToInt32(item.IdAlmacen), item.IdProducto);

                                if (objE_Stock.Cantidad > item.Cantidad)
                                {
                                    CantidadDisponible = item.Cantidad;
                                }
                                else
                                {
                                    CantidadDisponible = objE_Stock.Cantidad;
                                }

                                #endregion
                                if (CantidadDisponible > 0)
                                {
                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = item.Item;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = CantidadDisponible * item.PrecioVenta;//item.ValorVenta;
                                    objE_PedidoDetalle.IdKardex = item.IdKardex;
                                    objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                    objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                    objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                    objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                    objE_PedidoDetalle.Observacion = item.Observacion;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                }
                            }

                            bsListado.DataSource = mListaPedidoDetalleOrigen;
                            gcPedidoDetalle.DataSource = bsListado;
                            gcPedidoDetalle.RefreshDataSource();

                            CalculaTotales();
                            #endregion
                        }
                    }

                    #endregion
                }
                else
                {
                    #region "Pedido Original"
                    //Traemos la información del Pedido
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim());
                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.FlagPreVenta == true)
                        {
                            #region "Pedido Preventa"

                            //if (objE_Pedido.IdSituacion == Parametros.intPVGenerado || objE_Pedido.IdSituacion == Parametros.intPVAnulado) //Factudo
                            //{
                            //    XtraMessageBox.Show("No se puede Generar pedido N°" + txtNumeroPedido.Text + ", No está Aprobado! \nSituación Actual: " + objE_Pedido.DescSituacion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true); //add 31-08-15

                            cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                            cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                            txtNumero.Text = objE_Pedido.Numero;
                            txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                            cboVendedor.EditValue = objE_Pedido.IdVendedor;
                            cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                            deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                            cboMoneda.EditValue = objE_Pedido.IdMoneda;
                            txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                            IdCliente = objE_Pedido.IdCliente;
                            IdTipoCliente = objE_Pedido.IdTipoCliente;
                            IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                            txtDescCliente.Text = objE_Pedido.DescCliente;
                            if (IdTipoCliente == Parametros.intTipClienteFinal)
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                            else
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                            txtDireccion.Text = objE_Pedido.Direccion;
                            cboCombo.EditValue = objE_Pedido.IdCombo;
                            cboCaja.Text = objE_Pedido.Despachar;
                            txtObservaciones.Text = objE_Pedido.Observacion;
                            txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                            txtSubTotal.EditValue = objE_Pedido.SubTotal;
                            txtImpuesto.EditValue = objE_Pedido.Igv;
                            txtTotal.EditValue = objE_Pedido.Total;
                            //chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                            chkPreventa.Checked = false;
                            cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                            cboMotivo.EditValue = objE_Pedido.IdMotivo;
                            txtObservaciones.Text = "MODIFICACIÓN DEL PEDIDO : " + objE_Pedido.Numero;
                            IdPedidoReferencia = objE_Pedido.IdPedido;
                            bOrigenFlagPreventa = true;
                            txtDescuento.EditValue = Parametros.dmlDescuentoPreventaVenta; //add 31-08

                            //Carga ClienteAsociado
                            CargarClienteAsociado();
                            cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                            gcPedidoDetalle.Focus();

                            //Seteamos el Pedido
                            SeteaPedidoDetalle();

                            //Traemos la información del detalle del Pedido

                            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosStock(objE_Pedido.IdPedido);


                            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                            {
                                CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                objE_PedidoDetalle.IdPedido = 0;
                                objE_PedidoDetalle.IdPedidoDetalle = 0;
                                objE_PedidoDetalle.Item = item.Item;
                                objE_PedidoDetalle.IdProducto = item.IdProducto;
                                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                objE_PedidoDetalle.Cantidad = item.Cantidad;
                                objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                objE_PedidoDetalle.Descuento = item.Descuento;
                                objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                objE_PedidoDetalle.IdKardex = item.IdKardex;
                                //objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali; //add
                                objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                objE_PedidoDetalle.Observacion = item.Observacion;
                                objE_PedidoDetalle.Stock = 0;
                                objE_PedidoDetalle.TipoOper = item.TipoOper;
                                mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                            }

                            bsListado.DataSource = mListaPedidoDetalleOrigen;
                            gcPedidoDetalle.DataSource = bsListado;
                            gcPedidoDetalle.RefreshDataSource();

                            CalculaTotales();
                            #endregion
                        }
                        else
                        {
                            #region "Pedido Normal"

                            #region "Pedido Anulado"
                            if (objE_Pedido.IdSituacion == Parametros.intPVAnulado)
                            {
                                if (objE_Pedido.IdTipoCliente != IdTipoCliente)
                                {
                                    XtraMessageBox.Show("No se puede copiar información de un cliente Final a Mayorista o Viceversa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }

                                gcPedidoDetalle.Focus();

                                //Seteamos el Pedido
                                SeteaPedidoDetalle();

                                //Traemos la información del detalle del Pedido

                                List<PedidoDetalleBE> lstTmpPedidoDetalle1 = null;
                                lstTmpPedidoDetalle1 = new PedidoDetalleBL().ListaTodos(objE_Pedido.IdPedido);

                                foreach (PedidoDetalleBE item in lstTmpPedidoDetalle1)
                                {
                                    #region "Validar Stock Físico"

                                    int CantidadDisponible = 0;
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock = new StockBL().SeleccionaCantidadIdProducto(item.IdTienda, Convert.ToInt32(item.IdAlmacen), item.IdProducto);

                                    if (objE_Stock.Cantidad > item.Cantidad)
                                    {
                                        CantidadDisponible = item.Cantidad;
                                    }
                                    else
                                    {
                                        CantidadDisponible = objE_Stock.Cantidad;
                                    }

                                    #endregion
                                    if (CantidadDisponible > 0)
                                    {
                                        CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_PedidoDetalle.IdPedido = 0;
                                        objE_PedidoDetalle.IdPedidoDetalle = 0;
                                        objE_PedidoDetalle.Item = item.Item;
                                        objE_PedidoDetalle.IdProducto = item.IdProducto;
                                        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                        objE_PedidoDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                                        objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_PedidoDetalle.Descuento = item.Descuento;
                                        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_PedidoDetalle.ValorVenta = CantidadDisponible * item.PrecioVenta;//item.ValorVenta;
                                        objE_PedidoDetalle.IdKardex = item.IdKardex;
                                        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                        objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                        objE_PedidoDetalle.Observacion = item.Observacion;
                                        objE_PedidoDetalle.Stock = 0;
                                        objE_PedidoDetalle.TipoOper = item.TipoOper;
                                        mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                    }


                                }

                                bsListado.DataSource = mListaPedidoDetalleOrigen;
                                gcPedidoDetalle.DataSource = bsListado;
                                gcPedidoDetalle.RefreshDataSource();

                                CalculaTotales();

                                return;
                            }
                            #endregion


                            cboEmpresa.EditValue = objE_Pedido.IdEmpresa;
                            cboDocumento.EditValue = objE_Pedido.IdTipoDocumento;
                            txtNumero.Text = objE_Pedido.Numero;
                            txtNumeroProforma.Text = objE_Pedido.NumeroProforma;
                            cboVendedor.EditValue = objE_Pedido.IdVendedor;
                            cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                            deFechaVencimiento.EditValue = objE_Pedido.FechaVencimiento;
                            cboMoneda.EditValue = objE_Pedido.IdMoneda;
                            txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                            IdCliente = objE_Pedido.IdCliente;
                            IdTipoCliente = objE_Pedido.IdTipoCliente;
                            IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                            txtDescCliente.Text = objE_Pedido.DescCliente;
                            if (IdTipoCliente == Parametros.intTipClienteFinal)
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente + "-" + objE_Pedido.DescClasificacionCliente;
                            else
                                txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                            txtDireccion.Text = objE_Pedido.Direccion;
                            cboCombo.EditValue = objE_Pedido.IdCombo;
                            cboCaja.Text = objE_Pedido.Despachar;
                            txtObservaciones.Text = objE_Pedido.Observacion;
                            txtTotalCantidad.EditValue = objE_Pedido.TotalCantidad;
                            txtSubTotal.EditValue = objE_Pedido.SubTotal;
                            txtImpuesto.EditValue = objE_Pedido.Igv;
                            txtTotal.EditValue = objE_Pedido.Total;
                            chkPreventa.Checked = objE_Pedido.FlagPreVenta;
                            cboTipoVenta.EditValue = objE_Pedido.IdTipoVenta;
                            cboMotivo.EditValue = objE_Pedido.IdMotivo;
                            txtObservaciones.Text = "MODIFICACIÓN DEL PEDIDO : " + objE_Pedido.Numero;
                            IdPedidoReferencia = objE_Pedido.IdPedido;

                            //Carga ClienteAsociado
                            CargarClienteAsociado();
                            cboClienteAsociado.EditValue = objE_Pedido.IdClienteAsociado;

                            gcPedidoDetalle.Focus();

                            //Seteamos el Pedido
                            SeteaPedidoDetalle();

                            //Traemos la información del detalle del Pedido

                            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodos(objE_Pedido.IdPedido);

                            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                            {
                                #region "Validar Stock Físico"

                                int CantidadDisponible = 0;
                                StockBE objE_Stock = new StockBE();
                                objE_Stock = new StockBL().SeleccionaCantidadIdProducto(item.IdTienda, Convert.ToInt32(item.IdAlmacen), item.IdProducto);

                                if (objE_Stock.Cantidad > item.Cantidad)
                                {
                                    CantidadDisponible = item.Cantidad;
                                }
                                else
                                {
                                    CantidadDisponible = objE_Stock.Cantidad;
                                }

                                #endregion
                                if (CantidadDisponible > 0)
                                {
                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = item.Item;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = CantidadDisponible * item.PrecioVenta;//item.ValorVenta;
                                    objE_PedidoDetalle.IdKardex = item.IdKardex;
                                    objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                                    objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                    objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                                    objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                                    objE_PedidoDetalle.Observacion = item.Observacion;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                                }


                            }

                            bsListado.DataSource = mListaPedidoDetalleOrigen;
                            gcPedidoDetalle.DataSource = bsListado;
                            gcPedidoDetalle.RefreshDataSource();

                            CalculaTotales();
                            #endregion
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region "Proforma"

            else if (IdTipoDocumentoCopia == Parametros.intTipoDocProforma)
            {
                //Traemos la información de la proforma
                ProformaBE objE_Proforma = null;
                objE_Proforma = new ProformaBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim(), Parametros.intPFAprobado);
                if (objE_Proforma != null)
                {
                    IdProforma = objE_Proforma.IdProforma;
                    txtNumeroProforma.Text = objE_Proforma.Numero;
                    cboVendedor.EditValue = objE_Proforma.IdVendedor;
                    cboFormaPago.EditValue = objE_Proforma.IdFormaPago;
                    cboMoneda.EditValue = objE_Proforma.IdMoneda;
                    txtTipoCambio.EditValue = objE_Proforma.TipoCambio;
                    IdCliente = objE_Proforma.IdCliente;
                    txtNumeroDocumento.Text = objE_Proforma.NumeroDocumento;
                    txtDescCliente.Text = objE_Proforma.DescCliente;
                    txtTipoCliente.Text = objE_Proforma.DescTipoCliente;
                    txtDireccion.Text = objE_Proforma.Direccion;

                    //Tramoes la información del detalle de la proforma
                    List<ProformaDetalleBE> lstTmpProformaDetalle = null;
                    lstTmpProformaDetalle = new ProformaDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdProforma);
                    int nItem = 1;
                    foreach (ProformaDetalleBE item in lstTmpProformaDetalle)
                    {
                        if (item.FlagAprobacion)
                        {
                            CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                            objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_PedidoDetalle.IdPedido = 0;
                            objE_PedidoDetalle.IdPedidoDetalle = 0;
                            objE_PedidoDetalle.Item = nItem;
                            objE_PedidoDetalle.IdProducto = item.IdProducto;
                            objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                            objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                            objE_PedidoDetalle.Cantidad = item.Cantidad;
                            objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                            objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                            objE_PedidoDetalle.Descuento = item.Descuento;
                            objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                            objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                            objE_PedidoDetalle.Observacion = item.Observacion;
                            objE_PedidoDetalle.IdKardex = 0;
                            objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali; //add
                            objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmCentralUcayali; //add
                            objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                            objE_PedidoDetalle.FlagMuestra = false;
                            objE_PedidoDetalle.FlagRegalo = false;
                            objE_PedidoDetalle.Stock = 0;
                            objE_PedidoDetalle.TipoOper = item.TipoOper;
                            mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                            nItem = nItem + 1;
                        }
                    }

                    bsListado.DataSource = mListaPedidoDetalleOrigen;
                    gcPedidoDetalle.DataSource = bsListado;
                    gcPedidoDetalle.RefreshDataSource();

                    CalculaTotales();
                }
                else
                {
                    XtraMessageBox.Show("Verificar que la proforma y los códigos esten aprobados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region "Proyecto"
            else if (IdTipoDocumentoCopia == Parametros.intTipoDocProyectoServicio)
            {
                //Traemos la información de la Si
                Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = null;
                objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim());
                if (objE_Dis_ProyectoServicio != null)
                {
                    if (cboVendedor.Text == "")
                    {
                        XtraMessageBox.Show("El Vendedor que creó el proyecto ya Cesó!, por lo tanto, solicitar el cambió a su supervisora.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        //cboVendedor.EditValue = Parametros.intUsuarioId;
                    }

                    if (objE_Dis_ProyectoServicio.FlagCerrado)
                    {
                        XtraMessageBox.Show("El proyecto ya Finalizó!, por favor verifcar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                    IdProyectoServicio = objE_Dis_ProyectoServicio.IdDis_ProyectoServicio;
                    txtNumeroContrato.Text = objE_Dis_ProyectoServicio.Numero;
                    //cboVendedor.EditValue = objE_Dis_ProyectoServicio.IdVendedor;
                    cboFormaPago.EditValue = Parametros.intContraEntrega;
                    //cboMoneda.EditValue = objE_Dis_ProyectoServicio.IdMoneda;
                    //txtTipoCambio.EditValue = objE_Dis_ProyectoServicio.TipoCambio;
                    IdCliente = objE_Dis_ProyectoServicio.IdCliente;
                    txtNumeroDocumento.Text = objE_Dis_ProyectoServicio.NumeroDocumento;
                    txtDescCliente.Text = objE_Dis_ProyectoServicio.DescCliente;
                    //txtTipoCliente.Text = objE_Dis_ProyectoServicio.DescTipoCliente;
                    txtDireccion.Text = objE_Dis_ProyectoServicio.Direccion;
                    txtObservaciones.Text = "Proyecto N°:" + txtNumeroContrato.Text;

                    if (objE_Dis_ProyectoServicio.IdVendedor > 0)
                    {
                        cboVendedor.EditValue = objE_Dis_ProyectoServicio.IdVendedor;
                        cboTipoVenta.EditValue = Parametros.intPorAsesoria;
                        cboAsesor.EditValue = objE_Dis_ProyectoServicio.IdAsesor;
                    }
                    else
                    {
                        cboVendedor.EditValue = objE_Dis_ProyectoServicio.IdAsesor;
                    }



                }
                else
                {
                    XtraMessageBox.Show("El Proyecto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region "Contrato Fabricación"
            else if (IdTipoDocumentoCopia == Parametros.intTipoDocContratoFabricacion)
            {
                //Traemos la información de la Si
                Dis_ContratoFabricacionBE objE_Dis_ContratoFabricacion = null;
                objE_Dis_ContratoFabricacion = new Dis_ContratoFabricacionBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim());
                if (objE_Dis_ContratoFabricacion != null)
                {
                    if (cboVendedor.Text == "")
                    {
                        XtraMessageBox.Show("El Vendedor que creó el contrato ya Cesó!, por lo tanto, solicitar el cambió de vendedor con el supervisor de tienda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        //cboVendedor.EditValue = Parametros.intUsuarioId;
                    }


                    //Preguntar si desea actualizar los descuentos a la fecha.
                    ///////////////////?????????????????????????///////////////

                    if (!objE_Dis_ContratoFabricacion.FlagCerrado)
                    {
                        XtraMessageBox.Show("El contrato de fabricación no está cerrado, Por favor Verifique!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Validar Detalle
                    List<Dis_ContratoFabricacionDetalleBE> lstTmpDis_ContratoFabricacionDetalle = null;
                    lstTmpDis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBL().ListaSinFoto(objE_Dis_ContratoFabricacion.IdDis_ContratoFabricacion);

                    foreach (Dis_ContratoFabricacionDetalleBE item in lstTmpDis_ContratoFabricacionDetalle)
                    {
                        if (item.FlagAprobado)
                        {
                            if (item.IdProducto == 0)
                            {
                                XtraMessageBox.Show("El producto " + item.NombreProducto + " debe tener Código de Venta. Consultar con Facturación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            if (item.Precio == 0 && !item.FlagObsequio)
                            {
                                XtraMessageBox.Show("El producto " + item.NombreProducto + " debe tener Precio de Venta. Consultar con Facturación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }


                    IdContratoFabricacion = objE_Dis_ContratoFabricacion.IdDis_ContratoFabricacion;
                    //IdProyectoServicio = objE_Dis_ContratoFabricacion.IdProyecto;
                    txtNumeroContrato.Text = objE_Dis_ContratoFabricacion.Numero;
                    //cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;
                    cboFormaPago.EditValue = Parametros.intContraEntrega;
                    //cboMoneda.EditValue = objE_Dis_ContratoFabricacion.IdMoneda;
                    //txtTipoCambio.EditValue = objE_Dis_ContratoFabricacion.TipoCambio;
                    IdCliente = objE_Dis_ContratoFabricacion.IdCliente;
                    txtNumeroDocumento.Text = objE_Dis_ContratoFabricacion.NumeroDocumento;
                    txtDescCliente.Text = objE_Dis_ContratoFabricacion.DescCliente;
                    //txtTipoCliente.Text = objE_Dis_ContratoFabricacion.DescTipoCliente;
                    txtDireccion.Text = objE_Dis_ContratoFabricacion.Direccion;
                    txtObservaciones.Text = "Contrato Fab. N°:" + txtNumeroContrato.Text;

                    if (objE_Dis_ContratoFabricacion.IdVendedor2 > 0)
                    {
                        cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor2;
                        cboTipoVenta.EditValue = Parametros.intPorAsesoria;
                        cboAsesor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;  //--- comentado 25/04/2022
                    }
                    else
                    {
                        cboVendedor.EditValue = objE_Dis_ContratoFabricacion.IdVendedor;
                    }


                    //if (XtraMessageBox.Show("Desea actualizar el precio de venta utilizando el descuento Temporal actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{

                    //}

                    ////Tramoes la información del detalle de la Dis_ContratoFabricacion
                    //List<Dis_ContratoFabricacionDetalleBE> lstTmpDis_ContratoFabricacionDetalle = null;
                    //lstTmpDis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBL().ListaTodosActivo(Convert.ToInt32(IdContratoFabricacion));
                    int nItem = 1;
                    string msgCodigoNoImportado = "";
                    foreach (Dis_ContratoFabricacionDetalleBE item in lstTmpDis_ContratoFabricacionDetalle)
                    {
                        if (item.FlagAprobado)
                        {
                            if (item.IdProducto > 0)
                            {
                                #region "Validar Stock Físico"

                                int CantidadDisponible = 0;
                                StockBE objE_Stock = null;
                                objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, item.IdProducto);

                                if (objE_Stock == null)
                                {
                                    XtraMessageBox.Show("El producto " + item.CodigoProveedor + ", no esta recepcionado. Verificar con Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }

                                if (objE_Stock.Cantidad > item.Cantidad)
                                {
                                    CantidadDisponible = item.Cantidad;
                                }
                                else
                                {
                                    CantidadDisponible = objE_Stock.Cantidad;
                                }

                                #endregion
                                if (CantidadDisponible > 0)
                                {
                                    decimal Descuento = 0;
                                    decimal PrecioVenta = item.Precio;

                                    #region "Descuento Promocion Temporal"
                                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboTipoVenta.EditValue), item.IdProducto);
                                    if (objE_PromocionTemporal != null)
                                    {
                                        Descuento = objE_PromocionTemporal.Descuento;
                                        PrecioVenta = Math.Round(item.Precio * ((100 - Descuento) / 100), 2);
                                        item.ValorVenta = PrecioVenta * item.Cantidad;
                                    }

                                    #endregion


                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = nItem;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.Precio;//item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = Descuento;// item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = 0; // item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = PrecioVenta;//item.Precio;// item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                    //if (item.FlagObsequio) objE_PedidoDetalle.Observacion = "CF Obsequio"; else objE_PedidoDetalle.Observacion = "CF";
                                    objE_PedidoDetalle.IdKardex = 0;
                                    objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                    objE_PedidoDetalle.FlagMuestra = false;
                                    objE_PedidoDetalle.FlagRegalo = false;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;

                                    if (item.FlagObsequio)
                                    {
                                        objE_PedidoDetalle.PorcentajeDescuento = 100;
                                        objE_PedidoDetalle.PrecioVenta = 0;
                                        objE_PedidoDetalle.ValorVenta = 0;
                                        objE_PedidoDetalle.CodAfeIGV = Parametros.strGravadoBonificaciones;
                                        objE_PedidoDetalle.Observacion = "CF Obsequio";
                                    }
                                    else
                                    {
                                        objE_PedidoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                                        objE_PedidoDetalle.Observacion = "CF";
                                    }
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                                    nItem = nItem + 1;
                                }
                                else
                                {
                                    msgCodigoNoImportado = msgCodigoNoImportado + item.CodigoProveedor + " " + item.NombreProducto + "\n";
                                }
                            }
                        }
                    }

                    if (msgCodigoNoImportado.Length > 0)
                    {
                        XtraMessageBox.Show(msgCodigoNoImportado, this.Text);
                    }

                    bsListado.DataSource = mListaPedidoDetalleOrigen;
                    gcPedidoDetalle.DataSource = bsListado;
                    gcPedidoDetalle.RefreshDataSource();

                    CalculaTotales();
                }
                else
                {
                    XtraMessageBox.Show("Verificar que el ContratoFabricacion y los códigos esten aprobados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region "Lista Novios"
            else if (IdTipoDocumentoCopia == Parametros.intTipoDocNovioRegalo)
            {
                //Traemos la información de la Si
                NovioRegaloBE objE_NovioRegalo = null;
                objE_NovioRegalo = new NovioRegaloBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim());
                if (objE_NovioRegalo != null)
                {
                    if (cboVendedor.Text == "")
                    {
                        XtraMessageBox.Show("Ud debe ingresar los datos de la cabecera antes de ingresar la lista.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        //cboVendedor.EditValue = Parametros.intUsuarioId;
                    }

                    frmRegNovioRegaloLista objRegNovioRegaloEdit = new frmRegNovioRegaloLista();
                    objRegNovioRegaloEdit.pOperacion = frmRegNovioRegaloLista.Operacion.Modificar;
                    objRegNovioRegaloEdit.IdNovioRegalo = objE_NovioRegalo.IdNovioRegalo;
                    objRegNovioRegaloEdit.StartPosition = FormStartPosition.CenterParent;
                    if (objRegNovioRegaloEdit.ShowDialog() == DialogResult.OK)
                    {

                        //if (!objE_NovioRegalo.FlagCerrado)
                        //{
                        //    XtraMessageBox.Show("El contrato de fabricación no está cerrado, Por favor Verifique!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        ////Validar Detalle
                        //List<NovioRegaloDetalleBE> lstTmpNovioRegaloDetalle = null;
                        //lstTmpNovioRegaloDetalle = new NovioRegaloDetalleBL().ListaSinFoto(objE_NovioRegalo.IdNovioRegalo);

                        //foreach (NovioRegaloDetalleBE item in lstTmpNovioRegaloDetalle)
                        //{
                        //    if (item.FlagAprobado)
                        //    {
                        //        if (item.IdProducto == 0)
                        //        {
                        //            XtraMessageBox.Show("El producto " + item.NombreProducto + " debe tener Código de Venta. Consultar con Facturación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //            return;
                        //        }

                        //        if (item.Precio == 0)
                        //        {
                        //            XtraMessageBox.Show("El producto " + item.NombreProducto + " debe tener Precio de Venta. Consultar con Facturación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //            return;
                        //        }
                        //    }
                        //}

                        IdNovioRegalo = objE_NovioRegalo.IdNovioRegalo;
                        txtNumeroContrato.Text = objE_NovioRegalo.Numero;
                        //cboFormaPago.EditValue = Parametros.intContraEntrega;
                        txtObservaciones.Text = "Lista Novio N°:" + txtNumeroContrato.Text;


                        ////Tramoes la información del detalle de la NovioRegalo
                        //List<NovioRegaloDetalleBE> lstTmpNovioRegaloDetalle = null;
                        //lstTmpNovioRegaloDetalle = objRegNovioRegaloEdit.mListaNovioRegaloDetalleOrigen; //new NovioRegaloDetalleBL().ListaTodosActivo(Convert.ToInt32(IdContratoFabricacion));
                        int nItem = 1;
                        string msgCodigoNoImportado = "";
                        foreach (NovioRegaloDetalleBE item in objRegNovioRegaloEdit.lstNovioRegaloDetalle2)
                        {
                            if (item.IdProducto > 0)
                            {
                                #region "Validar Stock Físico"

                                int CantidadDisponible = 0;
                                StockBE objE_Stock = null;
                                objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, item.IdProducto);

                                if (objE_Stock == null)
                                {
                                    XtraMessageBox.Show("El producto " + item.CodigoProveedor + ", no esta recepcionado. Verificar con Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }

                                if (objE_Stock.Cantidad > item.Cantidad)
                                {
                                    CantidadDisponible = item.Cantidad;
                                }
                                else
                                {
                                    CantidadDisponible = objE_Stock.Cantidad;
                                }

                                #endregion
                                if (CantidadDisponible > 0)
                                {
                                    decimal Descuento = 0;
                                    decimal PrecioVenta = 0;

                                    #region "Descuento Promocion Temporal"
                                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboTipoVenta.EditValue), item.IdProducto);
                                    if (objE_PromocionTemporal != null)
                                    {
                                        //if (Convert.ToDecimal(txtDescuento.EditValue) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                        //{
                                        Descuento = objE_PromocionTemporal.Descuento;
                                        PrecioVenta = Math.Round(item.PrecioVenta * ((100 - Descuento) / 100), 2);
                                        item.ValorVenta = PrecioVenta * item.Cantidad;
                                        //}
                                    }
                                    #endregion

                                    CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                                    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_PedidoDetalle.IdPedido = 0;
                                    objE_PedidoDetalle.IdPedidoDetalle = 0;
                                    objE_PedidoDetalle.Item = nItem;
                                    objE_PedidoDetalle.IdProducto = item.IdProducto;
                                    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                                    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                                    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                                    objE_PedidoDetalle.Cantidad = item.Cantidad;
                                    objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                                    objE_PedidoDetalle.PrecioUnitario = item.PrecioVenta;//item.PrecioUnitario;
                                    objE_PedidoDetalle.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                                    objE_PedidoDetalle.Descuento = 0; // item.Descuento;
                                    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;// item.PrecioVenta;
                                    objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                                    objE_PedidoDetalle.Observacion = "LNV";//item.Observacion;
                                    objE_PedidoDetalle.IdKardex = 0;
                                    objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
                                    objE_PedidoDetalle.FlagMuestra = false;
                                    objE_PedidoDetalle.FlagRegalo = false;
                                    objE_PedidoDetalle.Stock = 0;
                                    objE_PedidoDetalle.TipoOper = item.TipoOper;
                                    mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                                    nItem = nItem + 1;
                                }
                                else
                                {
                                    msgCodigoNoImportado = msgCodigoNoImportado + item.CodigoProveedor + " " + item.NombreProducto + "\n";
                                }

                            }
                        }

                        if (msgCodigoNoImportado.Length > 0)
                        {
                            XtraMessageBox.Show(msgCodigoNoImportado, "Productos sin Stock");
                        }

                        bsListado.DataSource = mListaPedidoDetalleOrigen;
                        gcPedidoDetalle.DataSource = bsListado;
                        gcPedidoDetalle.RefreshDataSource();

                        CalculaTotales();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Verificar que la lista de novios exista.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region "Nota Salida"

            //else if (IdTipoDocumentoCopia == Parametros.intTipoDocNotaSalida)
            //{
            //    //Verificar
            //    List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalleIngreso = null;
            //    lstMovimientoAlmacenDetalleIngreso = new MovimientoAlmacenDetalleBL().ListaNumeroDocumento(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipMovIngreso, txtNumeroProforma.Text.Trim());
            //    if (lstMovimientoAlmacenDetalleIngreso.Count > 0)
            //    {
            //        XtraMessageBox.Show("El número de documento ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }

            //    //Cargar 
            //    List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
            //    lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipMovSalida, txtNumeroProforma.Text.Trim());

            //    if (lstMovimientoAlmacenDetalle.Count == 0)
            //    {
            //        XtraMessageBox.Show("La nota de salida no tiene códigos, Verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }


            //    //Traemos la información de la proforma
            //    ProformaBE objE_Proforma = null;
            //    objE_Proforma = new ProformaBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProforma.Text.Trim(), Parametros.intPFAprobado);
            //    if (objE_Proforma != null)
            //    {
            //        //IdProforma = objE_Proforma.IdProforma;
            //        //txtNumeroProforma.Text = objE_Proforma.Numero;
            //        cboVendedor.EditValue = objE_Proforma.IdVendedor;
            //        cboFormaPago.EditValue = objE_Proforma.IdFormaPago;
            //        cboMoneda.EditValue = objE_Proforma.IdMoneda;
            //        txtTipoCambio.EditValue = objE_Proforma.TipoCambio;
            //        IdCliente = objE_Proforma.IdCliente;
            //        txtNumeroDocumento.Text = objE_Proforma.NumeroDocumento;
            //        txtDescCliente.Text = objE_Proforma.DescCliente;
            //        txtTipoCliente.Text = objE_Proforma.DescTipoCliente;
            //        txtDireccion.Text = objE_Proforma.Direccion;


            //        int nItem = 1;
            //        foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
            //        {
            //            CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
            //            objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
            //            objE_PedidoDetalle.IdPedido = 0;
            //            objE_PedidoDetalle.IdPedidoDetalle = 0;
            //            objE_PedidoDetalle.Item = nItem;
            //            objE_PedidoDetalle.IdProducto = item.IdProducto;
            //            objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
            //            objE_PedidoDetalle.NombreProducto = item.NombreProducto;
            //            objE_PedidoDetalle.Abreviatura = item.Abreviatura;
            //            objE_PedidoDetalle.Cantidad = item.Cantidad;
            //            objE_PedidoDetalle.CantidadAnt = item.Cantidad;
            //            objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
            //            objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
            //            objE_PedidoDetalle.Descuento = item.Descuento;
            //            objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
            //            objE_PedidoDetalle.ValorVenta = item.ValorVenta;
            //            objE_PedidoDetalle.Observacion = item.Observacion;
            //            objE_PedidoDetalle.IdKardex = 0;
            //            objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali; //add
            //            objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmCentralUcayali; //add
            //            objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
            //            objE_PedidoDetalle.FlagMuestra = false;
            //            objE_PedidoDetalle.FlagRegalo = false;
            //            objE_PedidoDetalle.Stock = 0;
            //            objE_PedidoDetalle.TipoOper = item.TipoOper;
            //            mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

            //            nItem = nItem + 1;
            //        }
 
            //        bsListado.DataSource = mListaPedidoDetalleOrigen;
            //        gcPedidoDetalle.DataSource = bsListado;
            //        gcPedidoDetalle.RefreshDataSource();

            //        CalculaTotales();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Verificar que la proforma y los códigos esten aprobados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion


        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPedidoVenta, Parametros.intPeriodo);
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

        private DataTable CargarCaja()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "CAJA 1";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "CAJA 2";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "CAJA 3";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "CAJA 4";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "CAJA 5";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "DESPACHO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "CAJA 6";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "CAJA 7";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "CAJA 8";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "ALMACEN";
            dr["Id"] = 11;
            dr["Descripcion"] = "DIGITAL";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarFormaPagoClienteFinal()
        {
            intSeleccionaTipoCliente = 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("IdTablaElemento", Type.GetType("System.Int32"));
            dt.Columns.Add("DescTablaElemento", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 61;
            dr["DescTablaElemento"] = "CONTADO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 65;
            dr["DescTablaElemento"] = "CONSIGNACION";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 67;
            dr["DescTablaElemento"] = "SEPARACION";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 68;
            dr["DescTablaElemento"] = "CONTRAENTREGA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 69;
            dr["DescTablaElemento"] = "COPAGAN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 130;
            dr["DescTablaElemento"] = "OBSEQUIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            return dt;
        }

        private DataTable CargarFormaPagoClienteMayorista()
        {
            intSeleccionaTipoCliente = 2;

            DataTable dt = new DataTable();
            dt.Columns.Add("IdTablaElemento", Type.GetType("System.Int32"));
            dt.Columns.Add("DescTablaElemento", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 61;
            dr["DescTablaElemento"] = "CONTADO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 62;
            dr["DescTablaElemento"] = "CREDITO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 65;
            dr["DescTablaElemento"] = "CONSIGNACION";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 68;
            dr["DescTablaElemento"] = "CONTRAENTREGA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 69;
            dr["DescTablaElemento"] = "COPAGAN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["IdTablaElemento"] = 130;
            dr["DescTablaElemento"] = "OBSEQUIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            return dt;
        }

        private void CalculaTotales()
        {
            try
            {
                FlagImpresionRus = true;

                if (FlagPromocion2x1 == true)// || chkVale.Checked == false)//add mod chk
                {
                    //if (IdTipoCliente == Parametros.intTipClienteFinal || IdClasificacionCliente != Parametros.intBlack)
                    //{
                        CalculaTotalPromocion2x1();
                        return;
                    //}
                }

                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deICBPER = 0;
                decimal deTotal = 0;
                decimal deTotal2 = 0;
                decimal detotalDsctoCumple = 0;
                //decimal deTotal2 = 0;
                int intTotalCantidad = 0;

                if (mListaPedidoDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaPedidoDetalleOrigen)
                    {
                        if (item.IdProducto == 83617 || item.IdProducto == 83618)
                        {
                            deICBPER = deICBPER + item.ValorVenta;
                        }
                        else
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        // Solo se ejecuta cuando el cliente final esta de cumpleaños en el mes
                        //if (bCumpleAnios)
                        //{
                        //    if (item.PorcentajeDescuento <= new decimal(50))
                        //    {
                        //        detotalDsctoCumple = detotalDsctoCumple + item.ValorVenta * new decimal(0.10);
                        //    }
                        //}
                    }

                    txtTotalBruto.EditValue = 0;//add may 25

                    //if (chkVale.Checked) //solo por apertura
                    //{
                    //    if (deTotal > 50)
                    //    {
                    //        txtTotalBruto.EditValue = deTotal;
                    //        deTotal = deTotal - 50;
                    //    }
                    //}

                    if (mListaPromocionVale.Count > 0)//add 250516
                    {
                        CalculaTotalesVale(intTotalCantidad, deTotal);
                        return;
                    }

                    deTotal = Math.Round(deTotal, 2);
                    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                    txtTotal.EditValue = deTotal + deICBPER;
                    txtSubTotal.EditValue = deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;
                    txtTotalCantidad.EditValue = intTotalCantidad;
                    txtICBPER.EditValue = deICBPER;
                    txtDsctoCumple.EditValue = detotalDsctoCumple;

                    //txtTotal.EditValue = Math.Round(deTotal, 2); //AAA
                    //deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    //txtSubTotal.EditValue = deSubTotal;
                    //deImpuesto = deTotal - deSubTotal;
                    //txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    //txtTotalCantidad.EditValue = intTotalCantidad;
                    ////txtTotalBruto.EditValue = 0;//add may 25

                    //Agregado para Preventa
                    if (Convert.ToDecimal(txtDescuento.EditValue) > 0 || Convert.ToDecimal(txtMP.EditValue) > 0)
                    {   deTotal2 = deTotal;
                        txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                        deTotal = deTotal * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);

                        txtDescuento.EditValue = Math.Round((Convert.ToDecimal(txtMP.EditValue) * 100) / (Convert.ToDecimal(deTotal2)), 15);

                        txtTotalDscto2x1.EditValue = txtMP.EditValue;
                        txtTotal.Text = Math.Round(deTotal, 2).ToString();
                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        txtSubTotal.EditValue = deSubTotal;
                        deImpuesto = deTotal - deSubTotal;
                        txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    }
                }
                else
                {
                    txtTotalCantidad.EditValue = 0;
                    txtSubTotal.EditValue = 0;
                    txtImpuesto.EditValue = 0;
                    txtTotal.EditValue = 0;
                    txtTotalBruto.EditValue = 0;//add may 25
                    txtDescuento.EditValue = 0;//add ago 31
                    txtICBPER.EditValue = 0;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalculaTotalesVale(int intTotalCantidad, decimal deTotal)
        {
            //no utilizado
            try
            {
                if (mListaPromocionVale.Count > 0)
                {
                    decimal deImpuesto = 0;
                    decimal deSubTotal = 0;
                    decimal TotalMonto = 0;

                    var BuscarFormaPago = mListaPromocionVale.Where(oB => oB.IdFormaPago == Convert.ToInt32(cboFormaPago.EditValue) && oB.IdTipoCliente == IdTipoCliente).ToList();
                    if (BuscarFormaPago.Count > 0)
                    {
                        foreach (var item in mListaPedidoDetalleOrigen)
                        {
                            if (item.PorcentajeDescuento >= BuscarFormaPago[0].DescuentoDesde && item.PorcentajeDescuento <= BuscarFormaPago[0].DescuentoHasta)
                            {
                                TotalMonto = TotalMonto + item.ValorVenta;
                            }
                        }

                        if (TotalMonto > 0)
                        {
                            //Consultar Monto minimo y maximo
                            var BuscarMonto = BuscarFormaPago.Where(oB => TotalMonto >= oB.MontoMin && TotalMonto <= oB.MontoMax).ToList();
                            if (BuscarMonto.Count > 0)
                            {
                                txtTotalBruto.EditValue = deTotal;
                                deTotal = deTotal - BuscarMonto[0].Importe;
                                btnEliminarVale.Text = "Eliminar &Vale de S/" + BuscarMonto[0].Importe.ToString();
                                txtObservaciones.Text = "VALE S/" + BuscarMonto[0].Importe.ToString();
                                btnEliminarVale.Visible = true;
                            }
                            else
                                btnEliminarVale.Visible = false;
                        }
                        else
                            btnEliminarVale.Visible = false;
                    }

                    deTotal = Math.Round(deTotal, 2);
                    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                    txtTotal.EditValue = deTotal;
                    txtSubTotal.EditValue = deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;

                    //txtTotal.EditValue = Math.Round(deTotal, 2);
                    //deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    //txtSubTotal.EditValue = deSubTotal;
                    //deImpuesto = deTotal - deSubTotal;
                    //txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    ////txtTotalCantidad.EditValue = intTotalCantidad;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularValoresGrilla(int IdMoneda)
        {
            try
            {
                if (gvPedidoDetalle.RowCount > 0)
                {
                    if (IdMoneda == Parametros.intSoles)
                    {
                        int posicion = 0;
                        foreach (var item in mListaPedidoDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }

                            gvPedidoDetalle.SetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvPedidoDetalle.SetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvPedidoDetalle.SetRowCellValue(posicion, gvPedidoDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                    else
                    {
                        int posicion = 0;
                        foreach (var item in mListaPedidoDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(posicion, gvPedidoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);

                            }
                            gvPedidoDetalle.SetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvPedidoDetalle.SetRowCellValue(posicion, gvPedidoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvPedidoDetalle.SetRowCellValue(posicion, gvPedidoDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                }
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

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Seleccionar un cliente válido.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de documento.\n";
                flag = true;
            }

            if (cboVendedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar un vendedor.\n";
                flag = true;
            }

            if (cboFormaPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la forma de pago.\n";
                flag = true;
            }

            if (mListaPedidoDetalleOrigen.Count == 0 && IdPedido == 0 )
            {
                strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo || pOperacion == Operacion.Modificar)
            {
                if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intCredito)
                {
                    if (!chkPreventa.Checked)
                    {
                        ClienteCreditoBE objE_ClienteCredito = null;
                        objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                        if (objE_ClienteCredito == null)
                        {
                            strMensaje = strMensaje + "- El cliente seleccionado no tiene una linea de crédito aprobada..por favor verifique con el Area de Créditos.\n";
                            flag = true;
                        }
                        else
                        {
                            //if (!chkPreventa.Checked)
                            //{
                            if (Convert.ToDecimal(txtTotal.EditValue) > objE_ClienteCredito.LineaCreditoDisponible)
                            {
                                strMensaje = strMensaje + "- El cliente seleccionado excede en su linea de credito disponible..por favor verifique con el Area de Créditos.\n";
                                flag = true;
                            }
                            //}
                        }
                    }
                }

                if (Convert.ToInt32(cboEmpresa.EditValue) != Parametros.intPanoraramaDistribuidores)
                {
                    TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                    objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));

                    decimal Tope = 0;

                    if (objE_TopeEmpresa != null)
                    {
                        Tope = objE_TopeEmpresa.Tope;
                    }

                    DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                    objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaPeriodo(Convert.ToInt32(cboEmpresa.EditValue), deFecha.DateTime.Year, deFecha.DateTime.Month);

                    decimal TotalVenta = 0;

                    if (objE_Documento != null)
                    {
                        TotalVenta = Convert.ToDecimal(txtTotal.EditValue) + objE_Documento.Total;
                    }
                    else
                    {
                        TotalVenta = 0;
                    }

                    EmpresaBE objE_Empresa = null;
                    objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));
                    if (objE_Empresa != null)
                    {
                        if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                        {
                            if (TotalVenta > Tope)
                            {
                                strMensaje = strMensaje + "El importe de venta sobrepasa el tope mensual del RUS, por favor verifique\n. Consultar al area de contabilidad.";
                                flag = true;
                            }
                        }
                    }
                }

                #region "Cliente General por Defecto"
                if (IdCliente == Parametros.intIdClienteGeneral)
                {
                    //Especificamos los datos del cliente general
                    //IdCliente = Parametros.intIdClienteGeneral;
                    IdTipoCliente = Parametros.intTipClienteFinal;
                    txtNumeroDocumento.Text = Parametros.strNumeroCliente;
                    txtDescCliente.Text = Parametros.strDescCliente;
                    IdClasificacionCliente = Parametros.intClasico;
                    txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
                    txtDireccion.Text = Parametros.strDireccion;
                }
                #endregion
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        //private void ColumRowFocus(string searchText, string Column)
        //{
        //    // obtaining the focused view 
        //    ColumnView View = (ColumnView)gcPedidoDetalle.FocusedView;
        //    // obtaining the column bound to the Country field 
        //    GridColumn column = View.Columns[Column];
        //    if (column != null)
        //    {
        //        // locating the row 
        //        int rhFound = View.LocateByDisplayText(gvPedidoDetalle.FocusedRowHandle + 1, column, searchText);
        //        // focusing the cell 
        //        if (rhFound != 0)
        //        {
        //            View.FocusedRowHandle = rhFound;
        //            View.FocusedColumn = column;
        //        }
        //    }

        //}

        //private void ColumRowFocusCantidad(string searchText, string Column)
        //{
        //    // obtaining the focused view 
        //    ColumnView View = (ColumnView)gcPedidoDetalle.FocusedView;
        //    // obtaining the column bound to the Country field 
        //    GridColumn column = View.Columns[Column];
        //    GridColumn columnbus = View.Columns["Cantidad"];
        //    if (column != null)
        //    {
        //        // locating the row 
        //        int rhFound = View.LocateByDisplayText(gvPedidoDetalle.FocusedRowHandle + 1, column, searchText);
        //        // focusing the cell 
        //        if (rhFound != 0)
        //        {
        //            View.FocusedRowHandle = rhFound;
        //            View.FocusedColumn = columnbus;
        //        }
        //    }

        //}

        private void SeteaPedidoDetalle()
        {
            mListaPedidoDetalleOrigen.Clear();
            bsListado.DataSource = mListaPedidoDetalleOrigen;
            gcPedidoDetalle.DataSource = bsListado;
            gcPedidoDetalle.RefreshDataSource();
        }

        private void cboCombo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCombo.EditValue != null)
                {
                    if (Convert.ToInt32(cboCombo.EditValue) == 0)
                    {
                        mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();
                        bsListado.DataSource = mListaPedidoDetalleOrigen;
                        gcPedidoDetalle.DataSource = bsListado;
                        gcPedidoDetalle.RefreshDataSource();
                    }
                    else
                    {
                        mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();

                        //Traemos la información del detalle del Combo
                        List<ComboDetalleBE> lstComboDetalle = null;
                        lstComboDetalle = new ComboDetalleBL().ListaTodosActivo(Convert.ToInt32(cboCombo.EditValue));

                        int i = 1;

                        foreach (ComboDetalleBE item in lstComboDetalle)
                        {
                            CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();

                            #region "Validar Stock"
                            StockBE objE_Stock = null;
                            objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, item.IdProducto);

                            if (objE_Stock != null)
                            {
                                if (item.Cantidad > objE_Stock.Cantidad)
                                {

                                    if(Parametros.intTiendaId == Parametros.intTiendaUcayali)
                                    {
                                        StockBE objE_Stock2 = null;
                                        objE_Stock2 = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Parametros.intAlmTiendaUcayali, item.IdProducto);
                                        if (objE_Stock2!=null)
                                        {
                                            if (item.Cantidad > objE_Stock2.Cantidad)
                                            {
                                                if (objE_Stock2.Cantidad <= 0) return;
                                                XtraMessageBox.Show("Stock Insuficiente en Almacén, se agregará lo disponible de Muestra " + Convert.ToInt32(objE_Stock2.Cantidad).ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                item.Cantidad = objE_Stock2.Cantidad;
                                            }

                                            objE_PedidoDetalle.IdAlmacen = Parametros.intAlmTiendaUcayali;
                                            objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmTiendaUcayali;
                                        }
                                    }else
                                    {
                                        if (objE_Stock.Cantidad <= 0) return;
                                        XtraMessageBox.Show("Stock Insuficiente, se agregará lo disponible : " + Convert.ToInt32(objE_Stock.Cantidad).ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        item.Cantidad = objE_Stock.Cantidad;
                                    }


                                }
                                else
                                {
                                    objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmCentralUcayali;
                                    objE_PedidoDetalle.FlagMuestra = false;
                                }

                            }
                            #endregion 


                            objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_PedidoDetalle.IdPedido = 0;
                            objE_PedidoDetalle.IdPedidoDetalle = 0;
                            objE_PedidoDetalle.Item = i;
                            objE_PedidoDetalle.IdProducto = item.IdProducto;
                            objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                            objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                            objE_PedidoDetalle.Cantidad = item.Cantidad;
                            objE_PedidoDetalle.CantidadAnt = item.Cantidad;
                            objE_PedidoDetalle.PrecioUnitario = item.Precio;
                            objE_PedidoDetalle.PorcentajeDescuento = item.Descuento;
                            objE_PedidoDetalle.Descuento = 0;
                            objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                            objE_PedidoDetalle.ValorVenta = item.PrecioVenta * item.Cantidad;
                            objE_PedidoDetalle.IdKardex = 0;
                            //objE_PedidoDetalle.IdAlmacen = Parametros.intAlmCentralUcayali;
                            //objE_PedidoDetalle.IdAlmacenOrigen = Parametros.intAlmCentralUcayali;
                            //objE_PedidoDetalle.FlagMuestra = false;
                            objE_PedidoDetalle.FlagRegalo = false;
                            objE_PedidoDetalle.Stock = 0;
                            objE_PedidoDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                            mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                            i = i + 1;
                        }

                        bsListado.DataSource = mListaPedidoDetalleOrigen;
                        gcPedidoDetalle.DataSource = bsListado;
                        gcPedidoDetalle.RefreshDataSource();
                    }

                    CalculaTotales();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaPedidoDetalle()
        {
            mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();

            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
            {
                CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                objE_PedidoDetalle.IdPedido = item.IdPedido;
                objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                objE_PedidoDetalle.Item = item.Item;
                objE_PedidoDetalle.IdProducto = item.IdProducto;
                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                objE_PedidoDetalle.Medida = item.Medida;
                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                objE_PedidoDetalle.Cantidad = item.Cantidad;
                objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_PedidoDetalle.Descuento = item.Descuento;
                objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                objE_PedidoDetalle.Observacion = item.Observacion;
                objE_PedidoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_PedidoDetalle.IdKardex = item.IdKardex;
                objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                objE_PedidoDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle; //add
                objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                objE_PedidoDetalle.DescPromocion = item.DescPromocion;
                objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                objE_PedidoDetalle.FlagNacional = item.FlagNacional;
                objE_PedidoDetalle.Stock = 0;
                objE_PedidoDetalle.PrecioUnitarioInicial = 0;
                objE_PedidoDetalle.PorcentajeDescuentoInicial = 0;
                objE_PedidoDetalle.IdLineaProducto = item.IdLineaProducto;
                objE_PedidoDetalle.IdMarca = item.IdMarca;
                objE_PedidoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                //if (item.IdPromocion > 0)
                //{
                //    FlagPromocion2x1 = true;
                //}
            }

            bsListado.DataSource = mListaPedidoDetalleOrigen;
            gcPedidoDetalle.DataSource = bsListado;
            gcPedidoDetalle.RefreshDataSource();

            
            CalculaTotales();

            //if (FlagPromocion2x1 == true)//cargará al Iniciar
            //{
            //    CargarProductoPromocionDosPorUno(); //Dos por uno 
            //}

        }

        private void CargarClienteAsociado() 
        {
            List<ClienteAsociadoBE> objClienteAsociado = null;
            objClienteAsociado = new ClienteAsociadoBL().ListaTodosActivoConPrincipal(Parametros.intEmpresaId, IdCliente);
            BSUtils.LoaderLook(cboClienteAsociado,  objClienteAsociado, "DescCliente", "IdClienteAsociado", true);

            if (objClienteAsociado.Count() > 1)
            {
                grdDatosFacturacion.Visible = true;
            }
            else {
                grdDatosFacturacion.Visible = false;
            }
         }

        private void CargarSaldoDisponible()
        {
            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
            { 
                gcSaldoDisponible.Visible = true;
                ClienteCreditoBE objE_ClienteCredito = null;
                objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                if (objE_ClienteCredito == null)
                {
                    txtSaldoDisponible.EditValue = 0;
                }
                else
                {
                    if (!chkPreventa.Checked)
                    {
                        txtSaldoDisponible.EditValue = objE_ClienteCredito.LineaCreditoDisponible;
                    }
                }
            }
            else
            {
                txtSaldoDisponible.EditValue = 0;
                gcSaldoDisponible.Visible = false;
            }
        }

        public void Habilitar()
        {
            cboVendedor.Enabled = true;
            if (Parametros.strUsuarioLogin.ToLower() == "master")
            {
                cboFormaPago.Enabled = true;
                deFecha.Enabled = true;
                cboVendedor.Properties.ReadOnly = false;
            }
                
            else
            cboFormaPago.Enabled = false;
            deFechaVencimiento.Enabled = true;
            txtNumeroProforma.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            btnBuscar.Enabled = true;
            txtDescCliente.Enabled = true;
            cboCombo.Enabled = true;
            btnNuevoCliente.Enabled = true;
            btnPromocion.Enabled = true;
            txtDireccion.Enabled = true;
            cboTipoVenta.Enabled = true;
            btnClientePromocion.Enabled = true;
        }

        public void DesHabilitar()
        {
            cboVendedor.Enabled = false;
            cboFormaPago.Enabled = false; //Solo estaban estos 4
            cboMoneda.Enabled = false; //aa
            deFechaVencimiento.Enabled = false; //aa
            deFecha.Enabled = false; //aa
            txtNumeroProforma.Enabled = false;
            txtNumeroDocumento.Enabled = false;
            btnBuscar.Enabled = false;
            txtDescCliente.Enabled = false;
            btnClienteAsociado.Enabled = false;
            cboCombo.Enabled = false;
            btnNuevoCliente.Enabled = false;
            //btnPromocion.Enabled = false;
            txtDireccion.Enabled = false;
            //cboTipoVenta.Enabled = false;
            cboEmpresa.Enabled = false;
            cboCaja.Enabled = false;
            cboAsesor.Enabled = false;
            txtNumeroPedido.Enabled = false;
            //txtObservaciones.Enabled = false;
            chkPreventa.Enabled = false;
            mnuContextual.Enabled = false;
            cboMotivo.Enabled = false;
            btnClientePromocion.Enabled = false;


            this.nuevoToolStripMenuItem.Enabled = false;
            modificarprecioToolStripMenuItem.Enabled = false;
            this.eliminarpromocion2x1toolStripMenuItem.Enabled = false;
            gcDiseñador.Enabled = false;
        }


        public void HabilitarCabecera()
        {
            btnBuscar.Enabled = true;
            txtDescCliente.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            txtDireccion.Enabled = true;
            cboMoneda.Enabled = true;
            if(Parametros.strUsuarioLogin.ToLower() =="master")
            {
                cboFormaPago.Enabled = true;
                //chkPreventa.Enabled = false;
            }
            else
                cboFormaPago.Enabled = false;
            txtNumeroPedido.Enabled = true;
            btnNuevoCliente.Enabled = true;
        }

        public void HabilitarCabeceraInicial()
        {
            btnBuscar.Enabled = true;
            txtDescCliente.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            txtDireccion.Enabled = true;
            cboMoneda.Enabled = true;
            cboFormaPago.Enabled = true;
            txtNumeroPedido.Enabled = true;
            btnNuevoCliente.Enabled = true;
            //if(pOperacion == Operacion.Nuevo)
            //    cboFormaPago.Enabled = true;
            //else
            //    cboFormaPago.Enabled = false;
        }


        public void DesHabilitarCabecera()
        {
            txtNumeroDocumento.Enabled = false;
            btnBuscar.Enabled = false;
            txtDescCliente.Enabled = false;
            cboMoneda.Enabled = false;
            cboFormaPago.Enabled = false;
            txtDireccion.Enabled = false;
            txtNumeroPedido.Enabled = false;
            chkPreventa.Enabled = false;

        }

        public void HabilitarEdition()
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGrabar.Enabled = true;
        }

        public void DesHabilitarEdition()
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        public void CargarClienteAsociadoSelecciona()
        {
            ClienteAsociadoBE objE_ClienteAsociado = null;
            objE_ClienteAsociado = new ClienteAsociadoBL().SeleccionaConPrincipal(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboClienteAsociado.EditValue));

            if (objE_ClienteAsociado != null)
            {
                IdClienteAsociado = objE_ClienteAsociado.IdClienteAsociado;

                txtNumeroDocumentoAsociado.Text = objE_ClienteAsociado.NumeroDocumento;
                //txtDescCliente.Text = objE_ClienteAsociado.DescCliente;
                txtDireccionAsociado.Text = objE_ClienteAsociado.Direccion;
            }
            //cboClienteAsociado.Properties.Columns.Count();

        }

        private void CargarProductoArmado(int IdProducto, int Cantidad)
        {
            try
            {
                #region "HangTag"

                StockBE pProductoBE = null;
                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, IdProducto);
                if (pProductoBE != null)
                {
                    IdProducto = pProductoBE.IdProducto;
                    pProductoBE.Cantidad = Cantidad;

                    int i = 0;
                    int Item = 0;
                    if (mListaPedidoDetalleOrigen.Count > 0)
                        i = mListaPedidoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                    Item = Convert.ToInt32(i) + 1;

                    //IdLineaProducto = pProductoBE.IdLineaProducto;
                    //txtCodigo.Text = pProductoBE.CodigoProveedor;
                    //txtProducto.Text = pProductoBE.NombreProducto;
                    //txtUM.Text = pProductoBE.Abreviatura;
                    //txtCantidad.EditValue = 1;
                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                    {
                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        {
                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioABSoles);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioABSoles * ((100 - pProductoBE.Descuento) / 100));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioABSoles * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);

                            //Verificar de varios almacenes
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                        else
                        {

                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioCDSoles);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioCDSoles * ((100 - pProductoBE.Descuento) / 100));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioCDSoles * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }
                    else
                    {
                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        {

                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioAB);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioAB * ((100 - pProductoBE.Descuento) / 100));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioAB * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                        else
                        {
                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioCD);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioCD * ((100 - pProductoBE.Descuento) / 100));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioCD * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductoDelivery(int IdProducto, decimal Precio, string Distrito)
        {
            try
            {
                #region "HangTag"

                StockBE pProductoBE = null;
                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, IdProducto);
                if (pProductoBE != null)
                {
                    //IdProducto = pProductoBE.IdProducto;
                    pProductoBE.Cantidad = 1;
                    pProductoBE.NombreProducto = pProductoBE.NombreProducto + " - " + Distrito;
                    int i = 0;
                    int Item = 0;
                    if (mListaPedidoDetalleOrigen.Count > 0)
                        i = mListaPedidoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                    Item = Convert.ToInt32(i) + 1;

                    // el delivery se inserta al final del pedido para validar el monto 
                    CalculaTotales();

                    if (Convert.ToDecimal(txtTotal.EditValue) > 500)
                    {
                        Precio = 0;
                    }
                    //---------------------------------------------------------------//
                    //IdLineaProducto = pProductoBE.IdLineaProducto;
                    //txtCodigo.Text = pProductoBE.CodigoProveedor;
                    //txtProducto.Text = pProductoBE.NombreProducto;
                    //txtUM.Text = pProductoBE.Abreviatura;
                    //txtCantidad.EditValue = 1;
                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                    {
                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        {
                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                        else
                        {

                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Precio);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }
                    else
                    {
                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        {

                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", Precio / Convert.ToDecimal(Parametros.dmlTCMayorista));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMayorista));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMayorista));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                        else
                        {
                            var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPedidoDetalle.AddNewRow();
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                            //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", Precio / Convert.ToDecimal(Parametros.dmlTCMinorista));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMinorista));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Precio / Convert.ToDecimal(Parametros.dmlTCMinorista));
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "DELIVERY");
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPedidoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }

                    //Grabar Detalle - Reservar Stock --add 2008
                    if (Parametros.bValidarStockDetallePedido == true)
                    {
                        if (chkPreventa.Checked == false)
                        {
                            GrabarDesdeDetalle();
                            CargaPedidoDetalle();

                            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)//add 1708
                            {
                                btnEnviarAlmacen.Visible = true;
                                btnGrabar.Visible = false;
                            }
                            else
                            {
                                btnEnviarAlmacen.Visible = false;
                                btnGrabar.Visible = true;
                            }
                        }
                    }


                }

                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductoAsociado(int IdProducto, int IdAlmacen, int Cantidad, string CodAfeIGV)
        {
            try
            {
                #region "HangTag"

                List<ProductoAsociadoBE> lstTmpProductoAsociado = null;
                lstTmpProductoAsociado = new ProductoAsociadoBL().ListaTodosActivo(IdProducto);

                if (lstTmpProductoAsociado != null)
                {
                    //IdProducto = pProductoBE.IdProducto;
                    //pProductoBE.Cantidad = Cantidad;

                    int i = 0;
                    int Item = 0;
                    if (mListaPedidoDetalleOrigen.Count > 0)
                        i = mListaPedidoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                    Item = Convert.ToInt32(i) + 1;

                    //IdLineaProducto = pProductoBE.IdLineaProducto;
                    //txtCodigo.Text = pProductoBE.CodigoProveedor;
                    //txtProducto.Text = pProductoBE.NombreProducto;
                    //txtUM.Text = pProductoBE.Abreviatura;
                    //txtCantidad.EditValue = 1;

                    foreach (ProductoAsociadoBE item in lstTmpProductoAsociado)
                    {
                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                        {
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", item.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", item.Cantidad * Cantidad);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100),2));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2)*(item.Cantidad * Cantidad));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "COMPLEMENTO");
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", IdAlmacen);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", IdAlmacen);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto",Parametros.intNinguno);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();


                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                            else
                            {

                                var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", item.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", item.Cantidad * Cantidad);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", item.Precio);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", item.Precio * (item.Cantidad* Cantidad));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "COMPLEMENTO");
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", IdAlmacen);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", IdAlmacen);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();

                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                        }
                        else
                        {
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {

                                var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", item.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", item.Cantidad * Cantidad);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", item.Precio);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", item.Precio * (item.Cantidad * Cantidad));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "COMPLEMENTO");
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", IdAlmacen);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", IdAlmacen);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();

                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                            else
                            {
                                var Buscar = mListaPedidoDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvPedidoDetalle.AddNewRow();
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdEmpresa", item.IdEmpresa);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedido", IdPedido);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", Item);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", item.Cantidad * Cantidad);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Descuento", 0);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioVenta", item.Precio);
                                //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "ValorVenta", item.Precio * (item.Cantidad* Cantidad));
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Observacion", "COMPLEMENTO");
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacen", IdAlmacen);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdAlmacenOrigen", IdAlmacen);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);//movDetalle.oBE.IdAlmacen);//add
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Stock", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvPedidoDetalle.UpdateCurrentRow();

                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                        }

                        Item = Item + 1; //Agregar Registro
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void establecerdescuentocerotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvPedidoDetalle.SelectedRowsCount; i++)
            {
                decimal decDescuento = 0;
                decimal decPrecioVenta = 0;
                decimal decValorVenta = 0;

                int row = gvPedidoDetalle.GetSelectedRows()[i];
                decDescuento = decimal.Parse((0).ToString());
                gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);

                decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
                gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);

            }

            gvPedidoDetalle.RefreshData();

            CalculaTotales();

            //Grabar Detalle - Reservar Stock -- aDD 240815
            if (Parametros.bValidarStockDetallePedido == true)
            {
                if (chkPreventa.Checked == false)
                {
                    GrabarDesdeDetalle();
                    CargaPedidoDetalle();

                    if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                    {
                        btnEnviarAlmacen.Visible = true;
                        btnGrabar.Visible = false;
                    }
                    else
                    {
                        btnEnviarAlmacen.Visible = false;
                        btnGrabar.Visible = true;
                    }
                }
            }

        }


        private DataTable CargarTipDocumentoBusqueda()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "87";
            dr["Descripcion"] = "PEDIDO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "94";
            dr["Descripcion"] = "PROFORMA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "103";
            dr["Descripcion"] = "PROY. DISEÑO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "79";
            dr["Descripcion"] = "C. FABRICACION";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "107";
            dr["Descripcion"] = "LISTA NOVIOS";
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["Id"] = "27";
            //dr["Descripcion"] = "NOTA INGRESO";
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["Id"] = "29";
            //dr["Descripcion"] = "NOTA SALIDA";
            //dt.Rows.Add(dr);
            return dt;
        }


        private void CalculaTotalPromocion2x1_Total()
        {
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;
            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;

            List<CPedidoDetalle> lst_PedidoDetallePromo2x1 = new List<CPedidoDetalle>();
            List<CPedidoDetalle> lst_PedidoDetallePromo2x1_Impar = new List<CPedidoDetalle>();
            List<CPedidoDetalle> lst_PedidoDetallePromo3x2 = new List<CPedidoDetalle>();

            List<CPedidoDetalle> lst_PedidoDetallePromo3x1 = new List<CPedidoDetalle>();
            List<CPedidoDetalle> lst_PedidoDetallePromo4x1 = new List<CPedidoDetalle>();

            List<CPedidoDetalle> lst_PedidoDetalleSinPromo = new List<CPedidoDetalle>();

            #region "Promociones"
            int nItem = 1;
            bool bPromo3x2 = false;
            bool bPromo3x1 = false;
            bool bPromo4x1 = false;

            foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
            {
                #region"2x1"
                if (item.DescPromocion == "2x1")
                {
                    if (item.Cantidad % 2 == 0)
                    {
                        #region "Par"
                        CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoDetalle.IdPedido = 0;
                        objE_DocumentoDetalle.IdPedidoDetalle = 0;
                        objE_DocumentoDetalle.Item = nItem;
                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                        objE_DocumentoDetalle.Cantidad = item.Cantidad;
                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_DocumentoDetalle.PorcentajeDescuento = 50;//item.PorcentajeDescuento;
                        objE_DocumentoDetalle.Descuento = item.Descuento;
                        objE_DocumentoDetalle.PrecioVenta = Math.Round(item.PrecioUnitario / 2, 2);
                        objE_DocumentoDetalle.ValorVenta = Math.Round((Math.Round(item.PrecioUnitario / 2, 2)) * item.Cantidad, 2);
                        objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                        objE_DocumentoDetalle.IdKardex = item.IdKardex;
                        objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                        objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                        objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
                        objE_DocumentoDetalle.FlagRegalo = false;
                        objE_DocumentoDetalle.Stock = 0;
                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                        lst_PedidoDetallePromo2x1.Add(objE_DocumentoDetalle);
                        #endregion
                    }
                    else
                    {
                        int Canten = item.Cantidad - 1;
                        if (Canten > 0)
                        {
                            #region "Par"
                            CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdPedido = 0;
                            objE_DocumentoDetalle.IdPedidoDetalle = 0;
                            objE_DocumentoDetalle.Item = nItem;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = Canten;
                            objE_DocumentoDetalle.CantidadAnt = Canten;
                            objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_DocumentoDetalle.PorcentajeDescuento = 50;// item.PorcentajeDescuento;
                            objE_DocumentoDetalle.Descuento = item.Descuento;
                            objE_DocumentoDetalle.PrecioVenta = Math.Round(item.PrecioUnitario / 2, 2);//item.PrecioVenta;
                            objE_DocumentoDetalle.ValorVenta = Math.Round((Math.Round(item.PrecioUnitario / 2, 2)) * Canten, 2);//item.PrecioVenta * Canten;
                            objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                            objE_DocumentoDetalle.IdKardex = item.IdKardex;
                            objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                            objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                            objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
                            objE_DocumentoDetalle.FlagRegalo = false;
                            objE_DocumentoDetalle.Stock = 0;
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            lst_PedidoDetallePromo2x1.Add(objE_DocumentoDetalle);
                            #endregion

                            #region "Impar"
                            //add 1
                            CPedidoDetalle objE_DocumentoDetalle2 = new CPedidoDetalle();
                            objE_DocumentoDetalle2.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdPedido = 0;
                            objE_DocumentoDetalle.IdPedidoDetalle = 0;
                            objE_DocumentoDetalle2.Item = nItem;
                            objE_DocumentoDetalle2.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle2.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle2.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle2.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle2.Cantidad = 1;
                            objE_DocumentoDetalle2.CantidadAnt = 1;
                            objE_DocumentoDetalle2.PrecioUnitario = item.PrecioUnitario;
                            objE_DocumentoDetalle2.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                            objE_DocumentoDetalle2.Descuento = item.Descuento;
                            objE_DocumentoDetalle2.PrecioVenta = item.PrecioVenta;
                            objE_DocumentoDetalle2.ValorVenta = item.PrecioVenta;
                            objE_DocumentoDetalle2.CodAfeIGV = Parametros.strGravadoOnerosa;
                            objE_DocumentoDetalle2.IdKardex = item.IdKardex;
                            objE_DocumentoDetalle2.IdPromocion = item.IdPromocion;
                            objE_DocumentoDetalle2.DescPromocion = item.DescPromocion;
                            objE_DocumentoDetalle2.FlagMuestra = item.FlagMuestra;
                            objE_DocumentoDetalle2.FlagRegalo = false;
                            objE_DocumentoDetalle2.Stock = 0;
                            objE_DocumentoDetalle2.TipoOper = item.TipoOper;
                            lst_PedidoDetallePromo2x1_Impar.Add(objE_DocumentoDetalle2);
                            #endregion
                        }
                        else
                        {
                            #region "Impar"
                            CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdPedido = 0;
                            objE_DocumentoDetalle.IdPedidoDetalle = 0;
                            objE_DocumentoDetalle.Item = nItem;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = 1;
                            objE_DocumentoDetalle.CantidadAnt = 1;
                            objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_DocumentoDetalle.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                            objE_DocumentoDetalle.Descuento = item.Descuento;
                            objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                            objE_DocumentoDetalle.ValorVenta = item.PrecioVenta;
                            objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                            objE_DocumentoDetalle.IdKardex = item.IdKardex;
                            objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                            objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                            objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
                            objE_DocumentoDetalle.FlagRegalo = false;
                            objE_DocumentoDetalle.Stock = 0;
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            lst_PedidoDetallePromo2x1_Impar.Add(objE_DocumentoDetalle);
                            #endregion
                        }
                    }
                }
                #endregion

                #region"3x2"
                else if (item.DescPromocion == "3x2")
                {
                    bPromo3x2 = true;
                    decimal DescuentoPromo3x2 = 0;
                    decimal TotalGrupo3x2_Mayor = 0;
                    decimal TotalGrupo3x2 = 0;

                    int RegistroP = 0;
                    //int TotalRegistroP = mListaPedidoDetallePromo3x2.Count();

                    foreach (var itemp in mListaPedidoDetallePromo3x2)
                    {
                        if (itemp.Item == 1)
                        {
                            TotalGrupo3x2 = TotalGrupo3x2 + itemp.PrecioUnitario;
                            TotalGrupo3x2_Mayor = TotalGrupo3x2_Mayor + itemp.PrecioUnitario;
                        }
                        else if (itemp.Item == 2)
                        {
                            TotalGrupo3x2 = TotalGrupo3x2 + itemp.PrecioUnitario;
                            TotalGrupo3x2_Mayor = TotalGrupo3x2_Mayor + itemp.PrecioUnitario;
                        }
                        else if (itemp.Item == 3)
                        {
                            TotalGrupo3x2 = TotalGrupo3x2 + itemp.PrecioUnitario;
                            DescuentoPromo3x2 = (1 - Math.Round(TotalGrupo3x2_Mayor / TotalGrupo3x2, 4));
                            //XtraMessageBox.Show(TotalGrupo3x2_Mayor.ToString() + " | " + TotalGrupo3x2.ToString() + " | " + DescuentoPromo3x2.ToString());

                            //mListaPedidoDetallePromo3x2[RegistroP].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            //mListaPedidoDetallePromo3x2[RegistroP].PrecioVenta = Math.Round(Math.Round(itemp.PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            //mListaPedidoDetallePromo3x2[RegistroP].ValorVenta = itemp.Cantidad * itemp.PrecioVenta;

                            mListaPedidoDetallePromo3x2[RegistroP].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            mListaPedidoDetallePromo3x2[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x2[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            mListaPedidoDetallePromo3x2[RegistroP].ValorVenta = mListaPedidoDetallePromo3x2[RegistroP].Cantidad * mListaPedidoDetallePromo3x2[RegistroP].PrecioVenta;

                            mListaPedidoDetallePromo3x2[RegistroP - 1].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            mListaPedidoDetallePromo3x2[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x2[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            mListaPedidoDetallePromo3x2[RegistroP - 1].ValorVenta = mListaPedidoDetallePromo3x2[RegistroP - 1].Cantidad * mListaPedidoDetallePromo3x2[RegistroP - 1].PrecioVenta;

                            mListaPedidoDetallePromo3x2[RegistroP - 2].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            mListaPedidoDetallePromo3x2[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x2[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            mListaPedidoDetallePromo3x2[RegistroP - 2].ValorVenta = mListaPedidoDetallePromo3x2[RegistroP - 2].Cantidad * mListaPedidoDetallePromo3x2[RegistroP - 2].PrecioVenta;

                            TotalGrupo3x2_Mayor = 0;
                            TotalGrupo3x2 = 0;
                        }

                        RegistroP = RegistroP + 1;
                    }
                }
                #endregion

                #region"3x1"
                else if (item.DescPromocion == "3x1")
                {
                    bPromo3x1 = true;
                    decimal DescuentoPromo3x1 = 0;
                    decimal TotalGrupo3x1_Mayor = 0;
                    decimal TotalGrupo3x1 = 0;

                    int RegistroP = 0;
                    int TotalRegP = mListaPedidoDetallePromo3x1.Count();

                    foreach (var itemp in mListaPedidoDetallePromo3x1)
                    {
                        if (itemp.Item == 1)
                        {
                            TotalGrupo3x1 = TotalGrupo3x1 + itemp.PrecioUnitario;
                            TotalGrupo3x1_Mayor = TotalGrupo3x1_Mayor + itemp.PrecioUnitario;
                        }
                        else if (itemp.Item == 2)
                        {
                            if ((RegistroP + 1) == TotalRegP) //último registro
                            {
                                TotalGrupo3x1 = TotalGrupo3x1 + itemp.PrecioUnitario;
                                DescuentoPromo3x1 = (1 - Math.Round(TotalGrupo3x1_Mayor / TotalGrupo3x1, 4));

                                mListaPedidoDetallePromo3x1[RegistroP].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                                mListaPedidoDetallePromo3x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                                mListaPedidoDetallePromo3x1[RegistroP].ValorVenta = mListaPedidoDetallePromo3x1[RegistroP].Cantidad * mListaPedidoDetallePromo3x1[RegistroP].PrecioVenta;

                                mListaPedidoDetallePromo3x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                                mListaPedidoDetallePromo3x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                                mListaPedidoDetallePromo3x1[RegistroP - 1].ValorVenta = mListaPedidoDetallePromo3x1[RegistroP - 1].Cantidad * mListaPedidoDetallePromo3x1[RegistroP - 1].PrecioVenta;

                                //mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                                //mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                                //mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].ValorVenta = mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].Cantidad * mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PrecioVenta;

                                TotalGrupo3x1_Mayor = 0;
                                TotalGrupo3x1 = 0;
                            }
                            else
                            {
                                TotalGrupo3x1 = TotalGrupo3x1 + itemp.PrecioUnitario;
                                //TotalGrupo3x1_Mayor = TotalGrupo3x1_Mayor + itemp.PrecioUnitario;
                            }
                        }
                        else if (itemp.Item == 3)
                        {
                            TotalGrupo3x1 = TotalGrupo3x1 + itemp.PrecioUnitario;
                            DescuentoPromo3x1 = (1 - Math.Round(TotalGrupo3x1_Mayor / TotalGrupo3x1, 4));

                            mListaPedidoDetallePromo3x1[RegistroP].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                            mListaPedidoDetallePromo3x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                            mListaPedidoDetallePromo3x1[RegistroP].ValorVenta = mListaPedidoDetallePromo3x1[RegistroP].Cantidad * mListaPedidoDetallePromo3x1[RegistroP].PrecioVenta;

                            mListaPedidoDetallePromo3x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                            mListaPedidoDetallePromo3x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                            mListaPedidoDetallePromo3x1[RegistroP - 1].ValorVenta = mListaPedidoDetallePromo3x1[RegistroP - 1].Cantidad * mListaPedidoDetallePromo3x1[RegistroP - 1].PrecioVenta;

                            mListaPedidoDetallePromo3x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                            mListaPedidoDetallePromo3x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo3x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                            mListaPedidoDetallePromo3x1[RegistroP - 2].ValorVenta = mListaPedidoDetallePromo3x1[RegistroP - 2].Cantidad * mListaPedidoDetallePromo3x1[RegistroP - 2].PrecioVenta;

                            TotalGrupo3x1_Mayor = 0;
                            TotalGrupo3x1 = 0;
                        }

                        RegistroP = RegistroP + 1;
                    }
                }
                #endregion

                #region"4x1"
                else if (item.DescPromocion == "4x1")
                {
                    bPromo4x1 = true;
                    decimal DescuentoPromo4x1 = 0;
                    decimal TotalGrupo4x1_Mayor = 0;
                    decimal TotalGrupo4x1 = 0;

                    int RegistroP = 0;
                    int TotalRegP = mListaPedidoDetallePromo4x1.Count();

                    foreach (var itemp in mListaPedidoDetallePromo4x1)
                    {
                        if (itemp.Item == 1)
                        {
                            TotalGrupo4x1 = TotalGrupo4x1 + itemp.PrecioUnitario;
                            TotalGrupo4x1_Mayor = TotalGrupo4x1_Mayor + itemp.PrecioUnitario;
                        }
                        else if (itemp.Item == 2)
                        {
                            if ((RegistroP + 1) == TotalRegP) //último registro
                            {
                                TotalGrupo4x1 = TotalGrupo4x1 + itemp.PrecioUnitario;
                                DescuentoPromo4x1 = (1 - Math.Round(TotalGrupo4x1_Mayor / TotalGrupo4x1, 4));

                                mListaPedidoDetallePromo4x1[RegistroP].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaPedidoDetallePromo4x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaPedidoDetallePromo4x1[RegistroP].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP].Cantidad * mListaPedidoDetallePromo4x1[RegistroP].PrecioVenta;

                                mListaPedidoDetallePromo4x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaPedidoDetallePromo4x1[RegistroP - 1].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP - 1].Cantidad * mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioVenta;

                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioVenta;

                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioVenta;

                                TotalGrupo4x1_Mayor = 0;
                                TotalGrupo4x1 = 0;
                            }
                            else
                            {
                                TotalGrupo4x1 = TotalGrupo4x1 + itemp.PrecioUnitario;
                                //TotalGrupo4x1_Mayor = TotalGrupo4x1_Mayor + itemp.PrecioUnitario;
                            }
                        }
                        else if (itemp.Item == 3)
                        {
                            if ((RegistroP + 1) == TotalRegP) //último registro
                            {
                                TotalGrupo4x1 = TotalGrupo4x1 + itemp.PrecioUnitario;
                                DescuentoPromo4x1 = (1 - Math.Round(TotalGrupo4x1_Mayor / TotalGrupo4x1, 4));

                                mListaPedidoDetallePromo4x1[RegistroP].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaPedidoDetallePromo4x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaPedidoDetallePromo4x1[RegistroP].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP].Cantidad * mListaPedidoDetallePromo4x1[RegistroP].PrecioVenta;

                                mListaPedidoDetallePromo4x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaPedidoDetallePromo4x1[RegistroP - 1].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP - 1].Cantidad * mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioVenta;

                                mListaPedidoDetallePromo4x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaPedidoDetallePromo4x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaPedidoDetallePromo4x1[RegistroP - 2].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP - 2].Cantidad * mListaPedidoDetallePromo4x1[RegistroP - 2].PrecioVenta;

                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                //mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioVenta;

                                TotalGrupo4x1_Mayor = 0;
                                TotalGrupo4x1 = 0;
                            }
                            else
                            {
                                TotalGrupo4x1 = TotalGrupo4x1 + itemp.PrecioUnitario;
                                //TotalGrupo4x1_Mayor = TotalGrupo4x1_Mayor + itemp.PrecioUnitario;
                            }
                        }
                        else if (itemp.Item == 4)
                        {
                            TotalGrupo4x1 = TotalGrupo4x1 + itemp.PrecioUnitario;
                            DescuentoPromo4x1 = (1 - Math.Round(TotalGrupo4x1_Mayor / TotalGrupo4x1, 4));


                            mListaPedidoDetallePromo4x1[RegistroP].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaPedidoDetallePromo4x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaPedidoDetallePromo4x1[RegistroP].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP].Cantidad * mListaPedidoDetallePromo4x1[RegistroP].PrecioVenta;

                            mListaPedidoDetallePromo4x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaPedidoDetallePromo4x1[RegistroP - 1].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP - 1].Cantidad * mListaPedidoDetallePromo4x1[RegistroP - 1].PrecioVenta;

                            mListaPedidoDetallePromo4x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaPedidoDetallePromo4x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaPedidoDetallePromo4x1[RegistroP - 2].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP - 2].Cantidad * mListaPedidoDetallePromo4x1[RegistroP - 2].PrecioVenta;

                            mListaPedidoDetallePromo4x1[RegistroP - 3].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaPedidoDetallePromo4x1[RegistroP - 3].PrecioVenta = Math.Round(Math.Round(mListaPedidoDetallePromo4x1[RegistroP - 3].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaPedidoDetallePromo4x1[RegistroP - 3].ValorVenta = mListaPedidoDetallePromo4x1[RegistroP - 3].Cantidad * mListaPedidoDetallePromo4x1[RegistroP - 3].PrecioVenta;


                            TotalGrupo4x1_Mayor = 0;
                            TotalGrupo4x1 = 0;
                        }

                        RegistroP = RegistroP + 1;
                    }
                }
                #endregion

                #region "Default"
                else
                {
                    CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoDetalle.IdPedido = 0;
                    objE_DocumentoDetalle.IdPedidoDetalle = 0;
                    objE_DocumentoDetalle.Item = nItem;
                    objE_DocumentoDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                    objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoDetalle.Descuento = item.Descuento;
                    objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                    objE_DocumentoDetalle.IdKardex = item.IdKardex;
                    objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoDetalle.FlagMuestra = false;
                    objE_DocumentoDetalle.FlagRegalo = false;
                    objE_DocumentoDetalle.Stock = 0;
                    objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    //mListaPedidoDetalleOrigenPromo.Add(objE_DocumentoDetalle);
                    lst_PedidoDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            //Agregar Descuentos
            #region "Agregar descuentos"

            int Registro = 1;
            int TotalRegistro = lst_PedidoDetallePromo2x1_Impar.Count;//  mListaPedidoDetalleOrigen.Count;
            decimal Valor1 = 0;
            decimal Valor2 = 0;
            decimal Mayor = 0;
            decimal Descuento = 0;
            foreach (var item in lst_PedidoDetallePromo2x1_Impar)//mListaPedidoDetalleOrigen)
            {
                if (Registro % 2 != 0)
                {
                    if (Registro < TotalRegistro)
                    {
                        Valor1 = lst_PedidoDetallePromo2x1_Impar[Registro - 1].PrecioVenta;
                        Valor2 = lst_PedidoDetallePromo2x1_Impar[Registro].PrecioVenta;
                        if (Valor1 > Valor2)
                            Mayor = Valor1;
                        else
                            Mayor = Valor2;

                        Descuento = (1 - Math.Round((Mayor / (Valor1 + Valor2)), 4)) * 100;
                        //XtraMessageBox.Show(Descuento.ToString(), this.Text);
                    }
                    else //último
                    {
                        Descuento = 0;
                    }
                }

                if (Descuento > 0)
                {
                    lst_PedidoDetallePromo2x1_Impar[Registro - 1].PorcentajeDescuento = Descuento;
                    lst_PedidoDetallePromo2x1_Impar[Registro - 1].PrecioVenta = Math.Round(Math.Round(item.PrecioUnitario, 2) * ((100 - Descuento) / 100), 2);
                    lst_PedidoDetallePromo2x1_Impar[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }
                else
                {
                    Descuento = 0;
                    lst_PedidoDetallePromo2x1_Impar[Registro - 1].PorcentajeDescuento = Descuento;
                    lst_PedidoDetallePromo2x1_Impar[Registro - 1].PrecioVenta = Math.Round(item.PrecioUnitario, 2);
                    lst_PedidoDetallePromo2x1_Impar[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }

                Registro = Registro + 1;
            }
            #endregion

            mListaPedidoDetalleOrigen2 = new List<CPedidoDetalle>();
            nItem = 1;

            #region "Agregar 2x1 Par"
            //Agregar Promociones a la lista
            foreach (CPedidoDetalle item in lst_PedidoDetallePromo2x1)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 2x1 Impar"
            foreach (CPedidoDetalle item in lst_PedidoDetallePromo2x1_Impar)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;// item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x2"
            foreach (PedidoDetalleBE item in mListaPedidoDetallePromo3x2)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //objE_DocumentoDetalle.ValorVenta =item.ValorVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta==0? item.Cantidad *item.PrecioUnitario: item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x1"
            foreach (PedidoDetalleBE item in mListaPedidoDetallePromo3x1)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //objE_DocumentoDetalle.ValorVenta =item.ValorVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 4x1"
            foreach (PedidoDetalleBE item in mListaPedidoDetallePromo4x1)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //objE_DocumentoDetalle.ValorVenta =item.ValorVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion


            //Agregar Sin Promoción 
            #region "Agregar códigos sin promoción"
            foreach (CPedidoDetalle item in lst_PedidoDetalleSinPromo)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;// item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra; //false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion


            ////bsListado.DataSource = mListaPedidoDetalleOrigenPromo;
            //bsListado.DataSource = mListaPedidoDetalleOrigen;
            //gcPedidoDetalle.DataSource = bsListado;
            //gcPedidoDetalle.RefreshDataSource();

     //       CalculaTotales();
            ////CalculaTotalesPromo();


            #region "Calcular Total"
            decimal deImpuesto = 0;
            decimal deValorVenta = 0;
            decimal deSubTotal = 0;
            decimal deTotal = 0;
            decimal deICBPER = 0;
            int intTotalCantidad = 0;
            //decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            if (mListaPedidoDetalleOrigen2.Count > 0)
            {
                foreach (var item in mListaPedidoDetalleOrigen2)
                {
                    if (item.IdProducto == 83617 || item.IdProducto == 83618)
                    {
                        deICBPER = deICBPER + item.ValorVenta;
                    }
                    else
                    {
                        intTotalCantidad = intTotalCantidad + item.Cantidad;
                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                    }
                }

                //txtTotalBruto.EditValue = 0;//add may 25
                ////if (mListaPromocionVale.Count > 0)//add 250516
                ////{
                ////    CalculaTotalesVale(intTotalCantidad, deTotal);
                ////    return;
                ////}

                deTotal = Math.Round(deTotal, 2);
                deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                txtTotal.EditValue = deTotal + deICBPER;
                txtSubTotal.EditValue = deSubTotal;
                txtImpuesto.EditValue = deImpuesto;
                txtICBPER.EditValue = deICBPER;
                txtTotalCantidad.EditValue = intTotalCantidad;
            }
            else
            {
                txtTotalCantidad.EditValue = 0;
                txtSubTotal.EditValue = 0;
                txtImpuesto.EditValue = 0;
                txtTotal.EditValue = 0;
                txtICBPER.EditValue = 0;
            }
            #endregion

            #endregion

        }


        private void CalculaTotalPromocion2x1_Total_unoAuno()
        {
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;
            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;

            List<CPedidoDetalle> lst_PedidoDetallePromo2x1 = new List<CPedidoDetalle>();
            List<CPedidoDetalle> lst_PedidoDetallePromo3x2 = new List<CPedidoDetalle>();
            List<CPedidoDetalle> lst_PedidoDetalleSinPromo = new List<CPedidoDetalle>();

            #region "Promociones"
            int nItem = 1; 
            foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
            {
                #region"2x1"
                if (item.DescPromocion == "2x1")
                {
                    for (int i = 1; i <= item.Cantidad; i++)
                    {
                        CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoDetalle.IdPedido = 0;
                        objE_DocumentoDetalle.IdPedidoDetalle = 0;
                        objE_DocumentoDetalle.Item = nItem;
                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                        objE_DocumentoDetalle.Cantidad = 1;
                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_DocumentoDetalle.Descuento = item.Descuento;
                        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                        objE_DocumentoDetalle.ValorVenta = item.PrecioVenta;
                        objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                        objE_DocumentoDetalle.IdKardex = item.IdKardex;
                        objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                        objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                        objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
                        objE_DocumentoDetalle.FlagRegalo = false;
                        objE_DocumentoDetalle.Stock = 0;
                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                        //if (nItem % 2 == 0)
                        //{
                        //    objE_DocumentoDetalle.PorcentajeDescuento = 0;
                        //    objE_DocumentoDetalle.Descuento = 0;
                        //    objE_DocumentoDetalle.PrecioVenta = 0;
                        //    objE_DocumentoDetalle.ValorVenta = 0;
                        //    objE_DocumentoDetalle.CodAfeIGV = "21";
                        //}
                        lst_PedidoDetallePromo2x1.Add(objE_DocumentoDetalle);

                        nItem = nItem + 1;
                    }
                }
                #endregion

                #region"3x2"
                else if (item.DescPromocion == "3x2")
                {
                    for (int i = 1; i <= item.Cantidad; i++)
                    {
                        CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoDetalle.IdPedido = 0;
                        objE_DocumentoDetalle.IdPedidoDetalle = 0;
                        objE_DocumentoDetalle.Item = nItem;
                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                        objE_DocumentoDetalle.Cantidad = 1;
                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_DocumentoDetalle.Descuento = item.Descuento;
                        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                        objE_DocumentoDetalle.ValorVenta = item.PrecioVenta;
                        objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                        objE_DocumentoDetalle.IdKardex = item.IdKardex;
                        objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                        objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                        objE_DocumentoDetalle.FlagMuestra = false;
                        objE_DocumentoDetalle.FlagRegalo = false;
                        objE_DocumentoDetalle.Stock = 0;
                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                        if (nItem % 3 == 0)
                        {
                            objE_DocumentoDetalle.PorcentajeDescuento = 0;
                            objE_DocumentoDetalle.Descuento = 0;
                            objE_DocumentoDetalle.PrecioVenta = 0;
                            objE_DocumentoDetalle.ValorVenta = 0;
                            objE_DocumentoDetalle.CodAfeIGV = "21";
                        }
                        lst_PedidoDetallePromo3x2.Add(objE_DocumentoDetalle);


                        nItem = nItem + 1;
                    }
                }
                #endregion

                #region "Default"
                else
                {
                    CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoDetalle.IdPedido = 0;
                    objE_DocumentoDetalle.IdPedidoDetalle = 0;
                    objE_DocumentoDetalle.Item = nItem;
                    objE_DocumentoDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoDetalle.Descuento = item.Descuento;
                    objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                    objE_DocumentoDetalle.IdKardex = item.IdKardex;
                    objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoDetalle.FlagMuestra = false;
                    objE_DocumentoDetalle.FlagRegalo = false;
                    objE_DocumentoDetalle.Stock = 0;
                    objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    //mListaPedidoDetalleOrigen2Promo.Add(objE_DocumentoDetalle);
                    lst_PedidoDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            mListaPedidoDetalleOrigen2 = new List<CPedidoDetalle>();

            //Agregar Promociones a la lista
            foreach (CPedidoDetalle item in lst_PedidoDetallePromo2x1)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedido = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
            }

            //Agregar Descuentos
            #region "Agregar descuentos"
            int Registro = 1;
            int TotalRegistro = mListaPedidoDetalleOrigen2.Count;
            decimal Valor1 = 0;
            decimal Valor2 = 0;
            decimal Mayor = 0;
            decimal Descuento = 0;
            foreach (var item in mListaPedidoDetalleOrigen2)
            {
                if (Registro % 2 != 0)
                {
                    if (Registro < TotalRegistro)
                    {
                        Valor1 = mListaPedidoDetalleOrigen2[Registro - 1].PrecioVenta;
                        Valor2 = mListaPedidoDetalleOrigen2[Registro].PrecioVenta;
                        if (Valor1 > Valor2)
                            Mayor = Valor1;
                        else
                            Mayor = Valor2;

                        Descuento = (1 - Math.Round((Mayor / (Valor1 + Valor2)), 4)) * 100;
                        //XtraMessageBox.Show(Descuento.ToString(), this.Text);
                    }
                    else //último
                    {
                        Descuento = 0;
                    }
                }

                if (Descuento > 0)
                {
                    decimal PrecioVenta = Math.Round(Math.Round(item.PrecioUnitario, 2) * ((100 - Descuento) / 100), 2);
                    mListaPedidoDetalleOrigen2[Registro - 1].PorcentajeDescuento = Descuento;
                    mListaPedidoDetalleOrigen2[Registro - 1].PrecioVenta = PrecioVenta;// Math.Round(Math.Round(item.PrecioUnitario, 2) * ((100 - Descuento) / 100), 2);
                    mListaPedidoDetalleOrigen2[Registro - 1].ValorVenta = item.Cantidad * PrecioVenta;
                }
                else
                {
                    Descuento = 0;
                    mListaPedidoDetalleOrigen2[Registro - 1].PorcentajeDescuento = Descuento;
                    mListaPedidoDetalleOrigen2[Registro - 1].PrecioVenta = Math.Round(item.PrecioUnitario, 2);
                    mListaPedidoDetalleOrigen2[Registro - 1].ValorVenta = item.Cantidad * Math.Round(item.PrecioUnitario, 2);
                }


                Registro = Registro + 1;
            }
            #endregion


            //Agregar Sin Promoción 
            #region "Agregar códigos sin promoción"
            foreach (CPedidoDetalle item in lst_PedidoDetalleSinPromo)
            {
                CPedidoDetalle objE_DocumentoDetalle = new CPedidoDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.IdPedidoDetalle = 0;
                objE_DocumentoDetalle.Item = item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra; //false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen2.Add(objE_DocumentoDetalle);
            }
            #endregion


            ////bsListado.DataSource = mListaPedidoDetalleOrigen2Promo;
            //bsListado.DataSource = mListaPedidoDetalleOrigen2;
            //gcPedidoDetalle.DataSource = bsListado;
            //gcPedidoDetalle.RefreshDataSource();


            #region "Calcular Total"
            decimal deImpuesto = 0;
            decimal deValorVenta = 0;
            decimal deSubTotal = 0;
            decimal deTotal = 0;
            int intTotalCantidad = 0;
            //decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            if (mListaPedidoDetalleOrigen2.Count > 0)
            {
                foreach (var item in mListaPedidoDetalleOrigen2)
                {
                    intTotalCantidad = intTotalCantidad + item.Cantidad;
                    deValorVenta = item.ValorVenta;
                    deTotal = deTotal + deValorVenta;
                }

                //txtTotalBruto.EditValue = 0;//add may 25
                ////if (mListaPromocionVale.Count > 0)//add 250516
                ////{
                ////    CalculaTotalesVale(intTotalCantidad, deTotal);
                ////    return;
                ////}

                deTotal = Math.Round(deTotal, 2);
                deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                txtTotal.EditValue = deTotal;
                txtSubTotal.EditValue = deSubTotal;
                txtImpuesto.EditValue = deImpuesto;
                txtTotalCantidad.EditValue = intTotalCantidad;
            }
            else
            {
                txtTotalCantidad.EditValue = 0;
                txtSubTotal.EditValue = 0;
                txtImpuesto.EditValue = 0;
                txtTotal.EditValue = 0;
            }
            #endregion


            //CalculaTotales();
            ////CalculaTotalesPromo();

            #endregion

        }

        private void CalculaTotalPromocion2x1()
        {
            int PosicionX = 0;
            int Cantidad = 0;
            int intTotalCantidad = 0;

            Decimal PrecioUnitario = 0;
            Decimal Icbper = 0;
            Decimal PrecioVenta = 0;
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;

            Decimal TotalPrecio3x2 = 0;
            Decimal Total3x2SinPromo = 0;

            Decimal TotalPrecio3x1 = 0;
            Decimal Total3x1SinPromo = 0;

            Decimal TotalPrecio4x1 = 0;
            Decimal Total4x1SinPromo = 0;

            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;
            Decimal TotalIcbper = 0;


            //if (mListaPedidoDetalleOrigen.Count > 0)

            foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
            {
                //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["Cantidad"])));
                //PrecioUnitario = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));

                Cantidad = item.Cantidad;
                PrecioUnitario = item.PrecioUnitario;
                PrecioVenta = item.PrecioVenta;//add 121115
                Icbper = item.Icbper;
                if (item.DescPromocion == "2x1")
                {
                    //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["Cantidad"])));
                    //PrecioUnitario = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));
                    if (Cantidad % 2 == 0)
                    {
                        TotalPrecio2x1 += ((Cantidad / 2) * PrecioUnitario);  //Math Round
                    }
                    else
                    {
                        if (Cantidad > 2)
                        {
                            //Cantidad = Cantidad - 1;
                            TotalPrecio2x1 += (((Cantidad - 1) / 2) * PrecioUnitario);  //Math Round   
                            //agregarle el uno
                        }
                    }

                    Total2x1SinPromo += (Cantidad * PrecioUnitario);
                    FlagImpresionRus = false;
                    //Precio2x1 = Precio2x1 + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));  
                }
                else if (item.DescPromocion == "3x2")
                {
                    //if (Cantidad % 3 == 0)
                    //{
                    //    TotalPrecio3x2 += ((Cantidad / 3) * PrecioUnitario);  //Math Round
                    //}
                    //else
                    //{
                    //    if (Cantidad > 2)
                    //    {
                    //        //Cantidad = Cantidad - 1;
                    //        TotalPrecio3x2 += (((Cantidad - 1) / 3) * PrecioUnitario);  //Math Round   
                    //        //agregarle el uno
                    //    }
                    //}

                    //if (Cantidad % 2 == 0)
                    //{
                    //    TotalPrecio3x2 += ((Cantidad / 2) * PrecioUnitario);  //Math Round
                    //}
                    //else
                    //{
                    //    if (Cantidad > 2)
                    //    {
                    //        //Cantidad = Cantidad - 1;
                    //        TotalPrecio3x2 += (((Cantidad - 1) / 2) * PrecioUnitario);  //Math Round   
                    //        //agregarle el uno
                    //    }
                    //}

                    Total3x2SinPromo = Total3x2SinPromo + (Cantidad * PrecioUnitario);
                    FlagImpresionRus = false;
                    //Precio2x1 = Precio2x1 + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));  
                }
                else if (item.DescPromocion == "3x1")
                {
                    Total3x1SinPromo = Total3x1SinPromo + (Cantidad * PrecioUnitario);
                    FlagImpresionRus = false;
                }
                else if (item.DescPromocion == "4x1")
                {
                    Total4x1SinPromo = Total4x1SinPromo + (Cantidad * PrecioUnitario);
                    FlagImpresionRus = false;
                }
                else if (item.DescPromocion == "6x3")
                {
                    if (Cantidad % 2 == 0)
                    {
                        TotalPrecio6x3 += ((Cantidad / 2) * PrecioUnitario);  //Math Round
                    }
                    else
                    {
                        if (Cantidad > 2)
                        {
                            //Cantidad = Cantidad - 1;
                            TotalPrecio6x3 += (((Cantidad - 1) / 2) * PrecioUnitario);  //Math Round   
                            //agregarle el uno
                        }
                    }

                    Total6x3SinPromo += (Cantidad * PrecioUnitario);
                    FlagImpresionRus = false;
                }
                else //Producto sin Promoción
                {
                    if (item.IdProducto == 83617 || item.IdProducto == 83618)
                    {
                        TotalIcbper = TotalIcbper + item.ValorVenta;
                    }
                    else
                    {
                        TotalSinPromocion += item.ValorVenta;
                    }
                }

                intTotalCantidad = intTotalCantidad + item.Cantidad;

                PosicionX = PosicionX + 1;
            }


            List<PedidoDetalleBE> lst_PedidoDetallePromo = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo3x2 = new List<PedidoDetalleBE>();

            List<PedidoDetalleBE> lst_PedidoDetallePromo3x1 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo4x1 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo6x3 = new List<PedidoDetalleBE>();
            Decimal PrecioUnitarioPromo = 0;
            Decimal PrecioVentaPromo = 0;
            String PromocionCadena = "";
            int CantidadImpar = 0;
            int PosicionY = 0;
            int Itemk = 1;
            for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
            {
                PromocionCadena = Convert.ToString(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["DescPromocion"])));

                CantidadImpar = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["Cantidad"])));
                PrecioUnitarioPromo = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["PrecioUnitario"])));
                PrecioVentaPromo = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["PrecioVenta"])));//add 121115

                if (PromocionCadena == "2x1")
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["PrecioUnitario"])));

                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        lst_PedidoDetallePromo.Add(ObjE_Detalle);
                    }
                }
                else if (PromocionCadena == "3x2")
                {
                    for (int j = 1; j <= CantidadImpar; j++)
                    {
                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();

                        ObjE_Detalle.Item = Itemk;
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        ObjE_Detalle.PrecioVenta = PrecioVentaPromo;
                        lst_PedidoDetallePromo3x2.Add(ObjE_Detalle);

                        if (Itemk == 3) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
                    }
                }

                else if (PromocionCadena == "3x1")
                {
                    for (int j = 1; j <= CantidadImpar; j++)
                    {
                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();

                        ObjE_Detalle.Item = Itemk;
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        ObjE_Detalle.PrecioVenta = PrecioVentaPromo;
                        lst_PedidoDetallePromo3x1.Add(ObjE_Detalle);

                        if (Itemk == 3) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
                    }
                }

                else if (PromocionCadena == "4x1")
                {
                    for (int j = 1; j <= CantidadImpar; j++)
                    {
                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();

                        ObjE_Detalle.Item = Itemk;
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        ObjE_Detalle.PrecioVenta = PrecioVentaPromo;
                        lst_PedidoDetallePromo4x1.Add(ObjE_Detalle);

                        if (Itemk == 4) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
                    }
                }

                else if (PromocionCadena == "6x3")
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["PrecioUnitario"])));

                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        lst_PedidoDetallePromo.Add(ObjE_Detalle);
                    }
                }

                PosicionY = PosicionY + 1;
            }
            //Agregar a Lista Pública
            mListaPedidoDetallePromo3x2 = lst_PedidoDetallePromo3x2;
            mListaPedidoDetallePromo3x1 = lst_PedidoDetallePromo3x1;
            mListaPedidoDetallePromo4x1 = lst_PedidoDetallePromo4x1;

            //Recorrido de la lista sumar 2x1
            if (lst_PedidoDetallePromo.Count > 0)
            {
                for (int i = 0; i < lst_PedidoDetallePromo.Count; i += 2)
                {
                    TotalPrecio2x1 += lst_PedidoDetallePromo[i].PrecioUnitario;
                }
            }

            //Recorrido de la lista sumar 3x2
            if (lst_PedidoDetallePromo3x2.Count > 0)
            {
                for (int i = 2; i < lst_PedidoDetallePromo3x2.Count; i = i + 3)
                {
                    TotalPrecio3x2 += lst_PedidoDetallePromo3x2[i].PrecioUnitario; //Precio Gratis -Descto
                    //gvPedidoDetalle.SetRowCellValue(0, gvPedidoDetalle.Columns["Observacion"], 1);
                }
            }

            //Recorrido de la lista sumar 3x1
            if (lst_PedidoDetallePromo3x1.Count > 0)
            {
                for (int i = 2; i < lst_PedidoDetallePromo3x1.Count; i = i + 3)
                {
                    TotalPrecio3x1 += lst_PedidoDetallePromo3x1[i].PrecioUnitario; //Precio Gratis -Descto
                    //gvPedidoDetalle.SetRowCellValue(0, gvPedidoDetalle.Columns["Observacion"], 1);
                }
            }

            //Recorrido de la lista sumar 4x1
            if (lst_PedidoDetallePromo4x1.Count > 0)
            {
                for (int i = 3; i < lst_PedidoDetallePromo4x1.Count; i = i + 4)
                {
                    TotalPrecio4x1 += lst_PedidoDetallePromo4x1[i].PrecioUnitario; //Precio Gratis -Descto
                    //gvPedidoDetalle.SetRowCellValue(0, gvPedidoDetalle.Columns["Observacion"], 1);
                }
            }

            //Recorrido de la lista sumar 6x3
            if (lst_PedidoDetallePromo6x3.Count > 0)
            {
                for (int i = 0; i < lst_PedidoDetallePromo6x3.Count; i += 2)
                {
                    TotalPrecio6x3 += lst_PedidoDetallePromo6x3[i].PrecioUnitario; //Precio Gratis -Descto
                }
            }

            txtTotal2x1.EditValue = TotalPrecio2x1 + Total3x2SinPromo + TotalPrecio6x3  +   Total3x1SinPromo+ Total4x1SinPromo; //TotalPrecio3x2
            txtTotalDscto2x1.EditValue = (Total2x1SinPromo - TotalPrecio2x1) + TotalPrecio3x2 + (Total6x3SinPromo - TotalPrecio6x3) + TotalPrecio3x1+TotalPrecio4x1;// versión 2.0

            ////Calcular el Total General con Descuento
            Decimal deTotal = 0;
            Decimal deSubTotal = 0;
            deTotal = TotalSinPromocion + TotalPrecio2x1 + (Total3x2SinPromo - TotalPrecio3x2) + TotalPrecio6x3 + (Total3x1SinPromo - TotalPrecio3x1) + (Total4x1SinPromo - TotalPrecio4x1);
            deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

            txtTotal.EditValue = Math.Round(deTotal + TotalIcbper, 2);
            txtSubTotal.EditValue = deSubTotal;
            txtICBPER.EditValue = TotalIcbper;
            txtImpuesto.EditValue = Math.Round((deTotal - deSubTotal), 2);
            txtTotalBruto.EditValue = Math.Round((TotalSinPromocion + TotalIcbper + Total2x1SinPromo + Total3x2SinPromo + Total6x3SinPromo   + Total3x1SinPromo+ Total4x1SinPromo), 2);
            txtTotalCantidad.EditValue = intTotalCantidad;

            CalculaTotalPromocion2x1_Total(); 
        }

        private void CalculaTotalPromocion3x2_Back()
        {
            int PosicionX = 0;
            int Cantidad = 0;
            int intTotalCantidad = 0;
            Decimal PrecioUnitario = 0;
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalSinPromocion = 0;


            //if (mListaPedidoDetalleOrigen.Count > 0)

            foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
            {
                //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["Cantidad"])));
                //PrecioUnitario = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));

                Cantidad = item.Cantidad;
                PrecioUnitario = item.PrecioUnitario;

                if (item.IdPromocion == 1)
                {
                    //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["Cantidad"])));
                    //PrecioUnitario = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));
                    if (Cantidad % 2 == 0)
                    {
                        TotalPrecio2x1 += ((Cantidad / 2) * PrecioUnitario);  //Math Round
                    }
                    else
                    {
                        if (Cantidad > 2)
                        {
                            //Cantidad = Cantidad - 1;
                            TotalPrecio2x1 += (((Cantidad - 1) / 2) * PrecioUnitario);  //Math Round   
                            //agregarle el uno
                        }
                    }

                    Total2x1SinPromo += (Cantidad * PrecioUnitario);
                    //Precio2x1 = Precio2x1 + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["PrecioUnitario"])));  
                }
                else //Producto sin Promoción
                {
                    TotalSinPromocion += item.ValorVenta;
                }

                intTotalCantidad = intTotalCantidad + item.Cantidad;

                PosicionX = PosicionX + 1;
            }

            //Recorrido del codigo Cantidad Impar con Mlista
            //List<PedidoDetalleBE> lst_PedidoDetallePromo = new List<PedidoDetalleBE>();
            //Decimal PrecioUnitarioPromo = 0;
            //int PosicionY = 0;
            //foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
            //{
            //    if (item.IdPromocion == 1)
            //    {
            //        if (item.Cantidad % 2 != 0)
            //        {
            //            //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["Cantidad"])));
            //            //PrecioUnitarioPromo = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["PrecioUnitario"])));

            //            PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();
            //            ObjE_Detalle.Cantidad = 1;
            //            ObjE_Detalle.PrecioUnitario = item.PrecioUnitario;//PrecioUnitarioPromo;
            //            lst_PedidoDetallePromo.Add(ObjE_Detalle);
            //        }
            //    }
            //    PosicionY = PosicionY + 1;
            //}

            List<PedidoDetalleBE> lst_PedidoDetallePromo = new List<PedidoDetalleBE>();
            Decimal PrecioUnitarioPromo = 0;
            int IdPromocionCadena = 0;
            int CantidadImpar = 0;
            int PosicionY = 0;
            for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
            {
                IdPromocionCadena = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["IdPromocion"])));
                CantidadImpar = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["Cantidad"])));
                PrecioUnitarioPromo = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["PrecioUnitario"])));

                if (IdPromocionCadena == 1)
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionY, (gvPedidoDetalle.Columns["PrecioUnitario"])));

                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        lst_PedidoDetallePromo.Add(ObjE_Detalle);
                    }
                }
                PosicionY = PosicionY + 1;
            }

            //Recorrido de la lista sumar
            if (lst_PedidoDetallePromo.Count > 0)
            {
                for (int i = 0; i < lst_PedidoDetallePromo.Count; i += 2)
                {
                    TotalPrecio2x1 += lst_PedidoDetallePromo[i].PrecioUnitario;
                }
            }

            txtTotal2x1.EditValue = TotalPrecio2x1;
            txtTotalDscto2x1.EditValue = Total2x1SinPromo - TotalPrecio2x1;


            ////Calcular el Total General con Descuento
            Decimal deTotal = 0;
            Decimal deSubTotal = 0;
            deTotal = TotalSinPromocion + TotalPrecio2x1;
            deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

            txtTotal.EditValue = Math.Round(deTotal, 2);
            txtSubTotal.EditValue = deSubTotal;
            txtImpuesto.EditValue = Math.Round((deTotal - deSubTotal), 2);
            txtTotalBruto.EditValue = Math.Round((Total2x1SinPromo + TotalSinPromocion), 2);
            txtTotalCantidad.EditValue = intTotalCantidad;
        }

        private void AsignarCodigoPromocion()
        {
            if (FlagPromocion2x1)
            {
                //this.gvPedidoDetalle.Columns["IdPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;//modificar para todos
                this.gvPedidoDetalle.Columns["DescPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;//modificar para todos
                this.gvPedidoDetalle.Columns["PrecioUnitario"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

                //Asignar valor ordenado de Item
                int PosicionX = 0;

                foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
                {
                    gvPedidoDetalle.SetRowCellValue(PosicionX, gvPedidoDetalle.Columns["Item"], PosicionX + 1);
                    PosicionX = PosicionX + 1;
                }
            }

            #region "Version Anterior"

            //CargarProductoPromocionDosPorUno(); //Dos por uno 

            //if (chkVale.Checked == false)
            //{
            //    //add 18 05 2015
            //    if (gvPedidoDetalle.RowCount > 0)
            //    {
            //        //if (IdTipoCliente == Parametros.intTipClienteFinal || IdClasificacionCliente != Parametros.intBlack)
            //        //{
            //        for (int i = 0; i < gvPedidoDetalle.RowCount; i++) //Existe
            //        {
            //            int IdProductoLista = 0;
            //            int IdAlmacenOrigen = 0;
            //            //int row = gvPedidoDetalle.GetRowHandle(i);//BUG
            //            int row = gvPedidoDetalle.GetRowHandle(i);//BUG

            //            IdProductoLista = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(row, (gvPedidoDetalle.Columns["IdProducto"])));
            //            IdAlmacenOrigen = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(row, (gvPedidoDetalle.Columns["IdAlmacenOrigen"])));

            //            if(IdAlmacenOrigen != Parametros.intAlmOutlet)//Outlet
            //            {
            //                #region "2x1"
            //                foreach (var item in mListaDescuentoPromocionDosPorUno) // SELECT directo
            //                {
            //                    if (item.IdProducto == IdProductoLista)
            //                    {
            //                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "2x1");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605

            //                            //add para descuento = 0;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }
            //                        else
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //1);
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "2x1");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605

            //                            //add para descuento = 0;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }

            //                    }
            //                }
            //                #endregion

            //                #region "3x2"
            //                foreach (var item in mListaDescuentoPromocion3x2) // SELECT directo
            //                {
            //                    if (item.IdProducto == IdProductoLista)
            //                    {
            //                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "3x2");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                                //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }
            //                        else
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "3x2");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                         //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }

            //                    }
            //                }
            //                #endregion

            //                #region "3x1"
            //                foreach (var item in mListaDescuentoPromocion3x1) // SELECT directo
            //                {
            //                    if (item.IdProducto == IdProductoLista)
            //                    {
            //                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x1
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "3x1");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                                //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }
            //                        else
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "3x1");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                         //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }

            //                    }
            //                }
            //                #endregion

            //                #region "4x1"
            //                foreach (var item in mListaDescuentoPromocion4x1) // SELECT directo
            //                {
            //                    if (item.IdProducto == IdProductoLista)
            //                    {
            //                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //4x1
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "4x1");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                                //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }
            //                        else
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "4x1");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                         //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }

            //                    }
            //                }
            //                #endregion


            //                #region "6x3"
            //                foreach (var item in mListaDescuentoPromocion6x3) // SELECT directo
            //                {
            //                    if (item.IdProducto == IdProductoLista)
            //                    {
            //                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "6x3");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                                //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }
            //                        else
            //                        {
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["DescPromocion"], "6x3");
            //                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                         //gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                            //add para descuento = 0;
            //                            //decimal decDescuento = item.Descuento;
            //                            decimal decDescuento = 0;
            //                            decimal decPrecioVenta = 0;
            //                            decimal decValorVenta = 0;
            //                            gvPedidoDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                            decPrecioVenta = decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvPedidoDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                            gvPedidoDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                            gvPedidoDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                            gvPedidoDetalle.RefreshData();

            //                            FlagPromocion2x1 = true;
            //                        }

            //                    }
            //                }
            //                #endregion
            //            }
            //        }

            //        if (mListaDescuentoPromocionDosPorUno.Count > 0 || mListaDescuentoPromocion3x2.Count > 0 || mListaDescuentoPromocion3x1.Count > 0 || mListaDescuentoPromocion4x1.Count > 0 || mListaDescuentoPromocion6x3.Count > 0 && FlagPromocion2x1 == true)//add2605
            //        {
            //            this.gvPedidoDetalle.Columns["IdPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;//modificar para todos
            //            this.gvPedidoDetalle.Columns["PrecioUnitario"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            //            //Asignar valor ordenado de Item
            //            int PosicionX = 0;

            //            foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
            //            {
            //                gvPedidoDetalle.SetRowCellValue(PosicionX, gvPedidoDetalle.Columns["Item"], PosicionX + 1);
            //                PosicionX = PosicionX + 1;
            //            }
            //        }
            //    }
            //}
            #endregion

        }

        //Almacen Nota de Salida
        private void ObtenerCorrelativoNotaSalida()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocNotaSalida, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                NumeroNotaSalida = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrabarNotaSalida()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mListaPedidoDetalleOrigen.Count > 0)
                {
                    //string Usuario = Parametros.strUsuarioLogin;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (!frmAutoriza.Edita)
                    {
                        return;
                    }

                    if (frmAutoriza.Usuario == "almacen1")
                    {
                        XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                        return;
                    }

                    //Usuario = frmAutoriza.Usuario;
                    int? IdAuxiliar;

                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                    objMovimientoAlmacen.IdMovimientoAlmacen = 0;
                    objMovimientoAlmacen.Periodo = deFecha.DateTime.Year;
                    objMovimientoAlmacen.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objMovimientoAlmacen.Numero = NumeroNotaSalida;
                    objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                    objMovimientoAlmacen.IdAlmacenOrigen = 2; //Convert.ToInt32(cboAlmacen.EditValue);
                    objMovimientoAlmacen.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objMovimientoAlmacen.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objMovimientoAlmacen.NumeroDocumento = txtNumeroDocumento.Text;
                    objMovimientoAlmacen.Referencia = "";
                    objMovimientoAlmacen.Observaciones = txtObservaciones.Text.Trim();//+ " - " + txtDescCliente.Text.ToLower() ;
                    objMovimientoAlmacen.IdAlmacenDestino = 1;//cboAlmacenDestino.Text.Trim() == "" ? (int?)null : Convert.ToInt32(cboAlmacenDestino.EditValue);
                    objMovimientoAlmacen.IdCliente = IdCliente == null ? (int?)null : IdCliente;
                    objMovimientoAlmacen.FlagEstado = true;
                    objMovimientoAlmacen.Usuario = Parametros.strUsuarioLogin;//Usuario
                    objMovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
                    objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;
                    objMovimientoAlmacen.IdAuxiliar = null; // IdAuxiliar == null ? (int?)null : IdAuxiliar; //objMovimientoAlmacen.IdAuxiliar = IdAuxiliar;

                    int Contador = 0;
                    //Registro de Compra Detalle
                    List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();

                    foreach (var item in mListaPedidoDetalleOrigen)
                    {
                        if (item.IdProducto > 0)
                        {
                            MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;//item.IdMovimientoAlmacenDetalle;
                            objE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0; // IdMovimientoAlmacen;
                            objE_MovimientoAlmacenDetalle.Item = item.Item;
                            objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                            objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                            objE_MovimientoAlmacenDetalle.CantidadAnt = item.CantidadAnt;
                            objE_MovimientoAlmacenDetalle.CostoUnitario = 0;// item.CostoUnitario;
                            objE_MovimientoAlmacenDetalle.MontoTotal = 0;// item.MontoTotal;
                            objE_MovimientoAlmacenDetalle.IdKardex = item.IdKardex;
                            objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                            objE_MovimientoAlmacenDetalle.FlagEstado = true;
                            objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                            lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);
                        }
                        Contador = Contador + 1;

                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_MovimientoAlmacen.Inserta(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                    }
                    else
                    {
                        objBL_MovimientoAlmacen.Actualiza(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                    }

                    ////Nota De ingreso
                    //if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTranferenciaDirecta)
                    //{
                    //    InsertaNotaIngreso();
                    //}
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrabarDesdeDetalle()
        {
            try
            {
                if (btnGrabar.Enabled == false) //(IdSituacionModifica != Parametros.intPVGenerado)
                {
                    return;
                }

                Cursor = Cursors.WaitCursor;

                //Calcula Totales
                CalculaTotales();

                if (!ValidarIngreso())
                {
                    Int32 Numero = 0;

                    PedidoBL objBL_Pedido = new PedidoBL();
                    PedidoBE objPedido = new PedidoBE();

                    objPedido.IdPedido = IdPedido;
                    objPedido.IdTienda = IdTienda;//Parametros.intTiendaId;
                    objPedido.IdCampana = 3;
                    objPedido.Periodo = Periodo;//Parametros.intPeriodo;
                    objPedido.Mes = deFecha.DateTime.Month;
                    objPedido.IdProforma = IdProforma == 0 ? (Int32?)null : IdProforma;
                    objPedido.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objPedido.Serie = "0";
                    objPedido.Numero = txtNumero.Text;
                    objPedido.IdPedidoReferencia = IdPedidoReferencia == 0 ? (Int32?)null : IdPedidoReferencia;//IdPedidoReferencia;
                    objPedido.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPedido.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                    objPedido.FechaCancelacion = (DateTime?)null;
                    objPedido.IdCliente = IdCliente;
                    objPedido.NumeroDocumento = txtNumeroDocumento.Text;
                    objPedido.DescCliente = txtDescCliente.Text;
                    objPedido.Direccion = txtDireccion.Text;
                    objPedido.IdClienteAsociado = IdClienteAsociado; //Add  *****verificar null
                    objPedido.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPedido.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objPedido.DescVendedor = cboVendedor.Text;
                    objPedido.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objPedido.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objPedido.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objPedido.PorcentajeImpuesto = Parametros.dmlIGV;
                    objPedido.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objPedido.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objPedido.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objPedido.Observacion = txtObservaciones.Text; //Agregar si es liquidacion **************
                    objPedido.IdCombo = Convert.ToInt32(cboCombo.EditValue);
                    objPedido.Despachar = cboCaja.Text;
                    objPedido.IdTipoVenta = Convert.ToInt32(cboTipoVenta.EditValue);
                    objPedido.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objPedido.IdAsesor = Convert.ToInt32(cboAsesor.EditValue);
                    objPedido.IdAsesorExterno = IdAsesorExterno; //Convert.ToInt32(cboAsesorExterno.EditValue);
                    objPedido.FlagPreVenta = chkPreventa.Checked;
                    objPedido.FlagEstado = true;
                    objPedido.Usuario = Parametros.strUsuarioLogin;
                    objPedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPedido.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objPedido.bOrigenFlagPreVenta = bOrigenFlagPreventa;
                    objPedido.FlagImpresionRus = FlagImpresionRus;
                    objPedido.IdContratoFabricacion = IdContratoFabricacion;
                    objPedido.IdProyectoServicio = IdProyectoServicio;
                    objPedido.IdNovioRegalo = IdNovioRegalo;

                    //IdSituacionModifica = IdSituacionModifica;//Add 280715
                    //IdSituacionModifica = Parametros.intPVGenerado;//Add 280715
                    if (IdSituacionModifica == Parametros.intNinguno)
                    {
                        IdSituacionModifica = Parametros.intPVGenerado;//Add 280715 
                    }

                    //Pedido Detalle
                    List<PedidoDetalleBE> lstPedidoDetalle = new List<PedidoDetalleBE>();

                    foreach (var item in mListaPedidoDetalleOrigen)
                    {
                        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_PedidoDetalle.IdPedido = item.IdPedido;
                        objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                        objE_PedidoDetalle.Item = item.Item;
                        objE_PedidoDetalle.IdProducto = item.IdProducto;
                        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                        objE_PedidoDetalle.Cantidad = item.Cantidad;
                        objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_PedidoDetalle.Descuento = item.Descuento;
                        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                        objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                        if (item.FlagMuestra)
                            objE_PedidoDetalle.Observacion = "MUESTRA";
                        else
                            objE_PedidoDetalle.Observacion = item.Observacion;
                        objE_PedidoDetalle.CodAfeIGV = item.CodAfeIGV;
                        objE_PedidoDetalle.IdKardex = item.IdKardex;
                        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen;
                        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen;
                        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                        objE_PedidoDetalle.FlagRegalo = false;
                        objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                        objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                        objE_PedidoDetalle.DescPromocion = item.DescPromocion;
                        objE_PedidoDetalle.FlagEstado = true;
                        objE_PedidoDetalle.TipoOper = item.TipoOper;
                        lstPedidoDetalle.Add(objE_PedidoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //ObtenerCorrelativo();

                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                        {
                            objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                            dmlTipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                        }
                        else
                        {
                            objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMinorista);
                            dmlTipoCambio = Convert.ToDecimal(Parametros.dmlTCMinorista);
                        }

                        objPedido.IdSituacion = Parametros.intPVGenerado;
                        Numero = objBL_Pedido.Inserta(objPedido, lstPedidoDetalle);

                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(Numero);
                        txtNumero.Text = objE_Pedido.Numero;

                        IdPedido = Numero;//add 280715
                        lblIdPedido.Text = Numero.ToString();
                    }
                    else
                    {
                        Numero = IdPedido;
                        objPedido.TipoCambio = dmlTipoCambio;
                        objPedido.IdSituacion = IdSituacionModifica;
                        objBL_Pedido.Actualiza(objPedido, lstPedidoDetalle);
                    }

                    ////Actualizar estado Encuesta
                    //if (bEncuesta)
                    //{
                    //    EncuestaBL ObjBL_Encuesta = new EncuestaBL();
                    //    ObjBL_Encuesta.ActualizaFlagDescuento(IdCliente);
                    //}

                    Cursor = Cursors.Default;

                    //EBotonGrabar = 1;

                    //this.Close();

                    //add 28/07/2015
                    pOperacion = Operacion.Modificar;

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }



        #endregion

        public class CPedidoDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPedido { get; set; }
            public Int32 IdPedidoDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Medida { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 CantidadAnt { get; set; }
            public Decimal Icbper { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String CodAfeIGV { get; set; }
            public String Observacion { get; set; }
            public Int32? IdKardex { get; set; }
            public Int32? IdAlmacen { get; set; }
            public Int32? IdAlmacenOrigen { get; set; }
            public Int32? IdMovimientoAlmacenDetalle { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PrecioUnitarioInicial { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 IdMarca { get; set; }
            public Int32? IdPromocion { get; set; }
            public String DescPromocion { get; set; }
            public Boolean FlagBultoCerrado { get; set; }
            public Boolean FlagNacional { get; set; }
            public Int32 TipoOper { get; set; }

            public CPedidoDetalle()
            {

            }
        }

        private void txtNumeroProforma_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void toastNotificationsManager1_Activated(object sender, DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs e)
        {
            switch (e.NotificationID.ToString())
            {
                case "ad2422f1-7f87-4299-ae9b-f1956161fb97":
                    MessageBox.Show("Notification #1 Clicked");
                    break;
                case "66501f90-ac6b-440d-bf73-483c5ab22143":
                    MessageBox.Show("Notification #2 Clicked");
                    break;
            }



        }

        private void toastNotificationsManager1_TimedOut(object sender, DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show((cboTipoVenta.EditValue).ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CalculaTotales();
            CalculaTotales();
        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar)) && (!char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }
    }
}