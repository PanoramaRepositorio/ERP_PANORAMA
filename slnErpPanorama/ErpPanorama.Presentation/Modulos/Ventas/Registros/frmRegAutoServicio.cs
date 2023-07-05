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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.ws_integrens;
using System.IO;
using System.Diagnostics;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.Collections;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegAutoServicio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        ws_integrensSoapClient WS = new ws_integrensSoapClient();
        FacturacionElectronica FacturaE = new FacturacionElectronica();
        //FacturacionElectronicaDemo FacturaE = new FacturacionElectronicaDemo();

        private List<PedidoDetalleBE> mListaDetalle = null;
        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen2 = new List<CDocumentoVentaDetalle>();
        public List<CDocumentoVentaPago> mListaDocumentoVentaPagoOrigen = new List<CDocumentoVentaPago>();
        public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();
        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocionDosPorUno = new List<Promocion2x1DetalleBE>();// Cargar promocion 2x1
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion3x2 = new List<Promocion2x1DetalleBE>();// Cargar 3x2
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion3x1 = new List<Promocion2x1DetalleBE>();// Cargar 3x2
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion4x1 = new List<Promocion2x1DetalleBE>();// Cargar 3x2
        public List<Promocion2x1DetalleBE> mListaDescuentoPromocion6x3 = new List<Promocion2x1DetalleBE>();// Cargar 6x3
        public List<PromocionValeDescuentoBE> mListaPromocionVale = new List<PromocionValeDescuentoBE>();
        public DocumentoVentaBE mDocumentoVentaE = new DocumentoVentaBE();
        public List<DocumentoVentaDetalleBE> mListaDocumentoVentaDetallePromo3x2 = new List<DocumentoVentaDetalleBE>();
        public List<DocumentoVentaDetalleBE> mListaDocumentoVentaDetallePromo3x1 = new List<DocumentoVentaDetalleBE>();
        public List<DocumentoVentaDetalleBE> mListaDocumentoVentaDetallePromo4x1 = new List<DocumentoVentaDetalleBE>();
        List<PedidoDetalleBE> mListaPedidoDetalleOrigen = new List<PedidoDetalleBE>();
        public List<EscalaMayoristaBE> mListaEscalaMayorista = new List<EscalaMayoristaBE>();

        public bool bLogicaMayorista = false;
        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private bool bMoroso = false;
        private bool bCumpleAnios = false;
        private bool bRegimenRus = false;
        private bool FlagPromocion2x1 = false;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public bool bNuevo = true;

        int IdEmpresa = 0;
        private string SerieRUS = "0";
        private string Serie;
        private string Numero;
        private bool NumeracionAutomatica = true;

        private int TipoFormato = 0;
        private bool bFlagImpresion = true;
        private bool FlagImpresionRus = true;
        private string NumeroCupon = "";
        private decimal Cupon = 0;
        private int IdClienteComercio = 0;
        private string CodigoNC = "";

        int valueId;  // = cboEmpresa.Properties.GetDataSourceValue("IdEmpresa", i);
        string value;   //= cboEmpresa.Properties.GetDataSourceValue("RazonSocial", i);

        #region "Precio"
        private decimal decDescuentoFinal = 0;
        private decimal decPrecioUnitFinal = 0;
        private decimal decPrecioVenFinal = 0;
        private decimal decValorFinal = 0;
        #endregion


        #endregion

        #region "Eventos"

        public frmRegAutoServicio()
        {
            InitializeComponent();
        }

        private void frmRegAutoServicio_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deFecha.EditValue = DateTime.Now;
            //BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);

            if (Parametros.intCajaId != 0)
            {
                List<CajaEmpresaBE> lst_CajaEmpresa = null;
                lst_CajaEmpresa = new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId);
                if (lst_CajaEmpresa.Count == 0)
                {
                    XtraMessageBox.Show("Esta caja no tiene empresa de facturación asignada, Para agregar:\n" + "Ir a Configuración-->Caja-->Clic Derecho-->Asignar Empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                ////BSUtils.LoaderLook(cboEmpresa, lst_CajaEmpresa, "RazonSocial", "IdEmpresa", true);
                BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
                cboEmpresa.EditValue = Parametros.intEmpresaId;
            }

            //BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocTicketBoleta;

            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(Parametros.intEmpresaId, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);


            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
            cboCondicionPago.EditValue = Parametros.intEfectivo;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboDocumentoReferencia, CargarTipoDocumento(), "Descripcion", "Id", true);
            //BSUtils.LoaderLook(cboDocumentoReferencia, new TalonBL().ListaCaja(Parametros.intEmpresaId, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboMonedaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMonedaPago.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            this.pOperacion = Operacion.Nuevo;

            //Especificamos los datos del cliente general
            IdCliente = Parametros.intIdClienteGeneral;
            IdTipoCliente = Parametros.intTipClienteFinal;
            txtNumeroDocumento.Text = Parametros.strNumeroCliente;
            txtDescCliente.Text = Parametros.strDescCliente;
            IdClasificacionCliente = Parametros.intClasico;
            txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
            txtDireccion.Text = Parametros.strDireccion;

            CargaDocumentoVentaDetalle(0);
            CargaDocumentoVentaPago();
            CargarDescuentoClienteMayorista();

            this.CargarEscala();

            //Traer Anuncio Publicitario
            //string Anuncio = "";
            //AnuncioBE objE_Anuncio = null;
            //objE_Anuncio = new AnuncioBL().SeleccionaUltimo();
            //if (objE_Anuncio != null)
            //{
            //    Anuncio = objE_Anuncio.DescAnuncio;
            //}

            string Anuncio = "";
            List<AnuncioBE> lst_Anuncio = null;
            lst_Anuncio = new AnuncioBL().ListaUltimoTipo(Parametros.intAnuncioPedido);
            if (lst_Anuncio.Count > 0)
            {
                Anuncio = lst_Anuncio[0].DescAnuncio;
            }


            ////Vale autoservicio //ESTANDARIZAR FECHA DE APERTURA
            //if (Parametros.intTiendaId == Parametros.intTiendaMegaplaza)
            //{
            //    chkVale.Visible = true;
            //}

            //Add 20 mayo
            CargarProductoPromocionDosPorUno(); //Dos por uno 
            CargarProductoPromocion3x2();//3x2
            CargarProductoPromocion3x1();//3x1
            CargarProductoPromocion4x1();//4x1
            CargarProductoPromocion6x3();//6x3


            ////PREDETERMINAR BOLETA O FACTURA ELECTRONICA
            //if(txtNumeroDocumento.Text.Trim().Length ==11)
            //    cboDocumento.EditValue = Parametros.intTipoDocFacturaElectronica;
            //else
            //    cboDocumento.EditValue = Parametros.intTipoDocBoletaElectronica;

            if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
                chkCantidadAutomatica.Checked = true;

            this.Text = "VENTA AUTOSERVICIO " + "  " + Anuncio;



        }

        private void frmRegAutoServicio_Shown(object sender, EventArgs e)
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
                txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Venta.ToString());
                txtTC.EditValue = decimal.Parse(objE_TipoCambio.Venta.ToString());
            }

            List<MovimientoCajaBE> mLista = null;
            mLista = new MovimientoCajaBL().ListaTodosActivo(Parametros.intCajaId, Parametros.dtFechaHoraServidor);
            var Buscar = mLista.Where(oB => oB.IdTipoDocumento == Parametros.intTipoDocAperturaCaja).ToList();
            if (Buscar.Count == 0)
            {
                XtraMessageBox.Show("Por favor, falta aperturar la caja asignada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolFlag = true;
            }

            if (bolFlag)
            {
                this.Close();
            }

            btnNuevo.Focus();
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            bLogicaMayorista = true;
            int intIdMoneda = 0;
            intIdMoneda = int.Parse(cboMoneda.EditValue.ToString());
            CalcularValoresGrilla(intIdMoneda);
            CalculaTotales();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    if (frm.pClienteBE.AbrevDomicilio == "OTR") frm.pClienteBE.AbrevDomicilio = ""; else frm.pClienteBE.AbrevDomicilio = frm.pClienteBE.AbrevDomicilio + " ";

                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                    this.Bloquear_Cumpleanios();
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                        cboMoneda.EditValue = Parametros.intSoles;
                        //FlagPromocion2x1 = true;

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
                            XtraMessageBox.Show("FELIZ CUMPLEAÑOS !!! " + FechaNac.ToShortDateString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            bCumpleAnios = true;
                            this.Desbloquear_Cumpleanios();
                        }
                        else
                        {
                            bCumpleAnios = false;
                        }

                        //Club Design
                        if (IdClasificacionCliente == Parametros.intClubDesign)
                            txtTipoCliente.ForeColor = Color.Fuchsia;
                        else
                            txtTipoCliente.ForeColor = Color.Black;
                    }
                    else
                    {

                        if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                        {
                            cboMoneda.EditValue = Parametros.intSoles;
                        }
                        else
                        {
                            cboMoneda.EditValue = Parametros.intDolares;
                        }

                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                        //FlagPromocion2x1 = false;

                        gvDocumentoVentaDetalle.Columns["DescFamiliaProducto"].Visible = true;
                        gvDocumentoVentaDetalle.Columns["DescFamiliaProducto"].VisibleIndex = 2;

                    }

                    ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                    objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
                    if (objE_ClienteCreditoMoroso != null)
                    {
                        if (objE_ClienteCreditoMoroso.IdClasificacionCliente == Parametros.intMoroso)
                        {
                            XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente un 0% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bMoroso = true;
                        }
                        else
                        {
                            bMoroso = false;
                        }
                    }

                    BloquearDatoCliente();

                    #region "Cambiar tipo documento"
                    //Cambiar tipo documento automático
                    if (frm.pClienteBE.NumeroDocumento.Length == 11)
                        cboDocumento.EditValue = Parametros.intTipoDocFacturaElectronica;
                    else
                        cboDocumento.EditValue = Parametros.intTipoDocBoletaElectronica;
                    #endregion

                    btnNuevo.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Bloquear_Cumpleanios()
        {
            lblDsctoCumple.Visible = false;
            txtDsctoCumple.Visible = false;
            lblTotalSinDscCumple.Visible = false;
            txtTotalSinDscCumple.Visible = false;
        }

        private void Desbloquear_Cumpleanios()
        {
            lblDsctoCumple.Visible = true;
            txtDsctoCumple.Visible = true;
            lblTotalSinDscCumple.Visible = true;
            txtTotalSinDscCumple.Visible = true;
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR") objE_Cliente.AbrevDomicilio = ""; else objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtDireccion.Text = objE_Cliente.AbrevDomicilio + objE_Cliente.Direccion;
                        IdTipoCliente = objE_Cliente.IdTipoCliente;
                        IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                        this.Bloquear_Cumpleanios();
                        if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                        {
                            txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                            cboMoneda.EditValue = Parametros.intSoles;
                            //FlagPromocion2x1 = true;

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
                                lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!!" + FechaNac.ToShortDateString();
                                XtraMessageBox.Show("FELIZ CUMPLEAÑOS !!! " + FechaNac.ToShortDateString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bCumpleAnios = true;
                                this.Desbloquear_Cumpleanios();
                            }
                            else
                            {
                                bCumpleAnios = false;
                            }

                            //Club Design
                            if (IdClasificacionCliente == Parametros.intClubDesign)
                                txtTipoCliente.ForeColor = Color.Fuchsia;
                            else
                                txtTipoCliente.ForeColor = Color.Black;
                        }
                        else
                        {
                            if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                            {
                                cboMoneda.EditValue = Parametros.intSoles;
                            }
                            else
                            {
                                cboMoneda.EditValue = Parametros.intDolares;
                            }

                            txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                            //FlagPromocion2x1 = false;
                        }

                        ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                        objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
                        if (objE_ClienteCreditoMoroso != null)
                        {
                            if (objE_ClienteCreditoMoroso.IdClasificacionCliente == Parametros.intMoroso)
                            {
                                XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente un 10% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bMoroso = true;
                            }
                            else
                            {
                                bMoroso = false;
                            }
                        }

                        BloquearDatoCliente();
                        btnNuevo.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void txtNumeroReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información del Pedido
                    DocumentoVentaBE objE_DocumentoVenta = null;
                    objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                    if (objE_DocumentoVenta != null)
                    {
                        cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                        cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                        txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                        IdCliente = Convert.ToInt32(objE_DocumentoVenta.IdCliente);
                        txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                        txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                        txtDireccion.Text = objE_DocumentoVenta.Direccion;
                        txtTotalDiferencia.EditValue = objE_DocumentoVenta.Total;
                        //Traemos la información del detalle del documento
                        CargaDocumentoVentaDetalle(objE_DocumentoVenta.IdDocumentoVenta);

                        CalculaTotales();
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de documento " + txtSerieReferencia.Text.Trim() + "-" + txtNumeroReferencia.Text.Trim() + " de la empresa " + cboEmpresa.Text + ", no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //txtDireccion.Text = objManCliente.AbrevDocimicilio + ' ' + objManCliente.Direccion;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;

                        //Calcula Cumpleaños
                        //DateTime FechaNac = Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        DateTime FechaNac = objE_Cliente.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        int PeriodoNac = FechaNac.Year;
                        int Anios = Parametros.intPeriodo - PeriodoNac;

                        //Compras del mes
                        List<DocumentoVentaBE> lstVenta = null;
                        lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);
                        this.Bloquear_Cumpleanios();
                        if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                        {
                            lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                            XtraMessageBox.Show("FELIZ CUMPLEAÑOS !!! " + FechaNac.ToShortDateString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bCumpleAnios = true;
                            this.Desbloquear_Cumpleanios();
                        }
                        else
                        {
                            bCumpleAnios = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bLogicaMayorista = true;
                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmRegAutoServicioDetalle movDetalle = new frmRegAutoServicioDetalle();
                int i = 0;
                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                    i = mListaDocumentoVentaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                movDetalle.bDescuentoCumpleanio = bCumpleAnios;
                movDetalle.bCantidadAutomatica = chkCantidadAutomatica.Checked;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count == 0)
                        {
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdMarca", movDetalle.oBE.IdMarca);//2022
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ObsEscala", movDetalle.oBE.ObsEscala);//2022
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagNacional", movDetalle.oBE.FlagNacional);//2022
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagEscala", movDetalle.oBE.FlagEscala);//2022
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "DescFamiliaProducto", movDetalle.oBE.DescFamiliaProducto);//2022
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "DescPromocion", movDetalle.oBE.DescPromocion);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdFamiliaProducto", movDetalle.oBE.IdFamiliaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            //Armado
                            if (movDetalle.oBE.IdProductoArmado > 0)
                            {
                                if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
                                }
                            }

                            //ProductoAsociado
                            if (movDetalle.oBE.FlagCompuesto)
                            {
                                CargarProductoAsociado(movDetalle.oBE.IdProducto, movDetalle.oBE.Cantidad, movDetalle.oBE.CodAfeIGV);
                                XtraMessageBox.Show("Se agregó el complemento.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            if (movDetalle.oBE.DescPromocion.Length > 0) //add 15122019
                            {
                                FlagPromocion2x1 = true;
                                AsignarCodigoPromocion();//ADD 20 MAY 2015
                            }
                            CalculaTotales();
                            CalculaTotales();
                            btnNuevo.Focus();

                            //Carga automática
                            this.nuevoToolStripMenuItem_Click(sender, e);
                            CalculaTotales();
                            return;

                        }
                        if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                if (!chkCantidadAutomatica.Checked)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    //Agregar + one
                                    #region "Agregar cantidad"

                                    int decCantidad = 0;
                                    int intCantidadLectura = 0;
                                    int intCantidadTotal = 0;
                                    decimal decPrecioVenta = 0;
                                    int IdProducto = 0;
                                    string CodigoProveedor = "";
                                    string NombreProducto = "";
                                    string Abreviatura = "";

                                    intCantidadLectura = movDetalle.oBE.Cantidad;
                                    IdProducto = movDetalle.oBE.IdProducto;
                                    CodigoProveedor = movDetalle.oBE.CodigoProveedor;
                                    NombreProducto = movDetalle.oBE.NombreProducto;
                                    Abreviatura = movDetalle.oBE.Abreviatura;

                                    for (int j = 0; j < gvDocumentoVentaDetalle.RowCount; j++)
                                    {
                                        string sDescPromocion = "";
                                        int IdProductoLista = 0;
                                        int row = gvDocumentoVentaDetalle.GetRowHandle(j);
                                        IdProductoLista = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["IdProducto"])));
                                        sDescPromocion = gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["DescPromocion"])).ToString();

                                        if (IdProducto == IdProductoLista)
                                        {
                                            decCantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                                            decPrecioVenta = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["PrecioVenta"])));
                                            intCantidadTotal = decCantidad + intCantidadLectura;

                                            //Validar Stock
                                            #region "Validar stock"
                                            if (!Parametros.bStockNegativo)
                                            {
                                                StockBE objE_Stock = null;
                                                objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, IdProducto);

                                                if (objE_Stock != null)
                                                {
                                                    if (intCantidadTotal > objE_Stock.Cantidad)
                                                    {
                                                        XtraMessageBox.Show("Su Stock Actual es :" + objE_Stock.Cantidad + "\nVerificar si se abasteció correctamente.\nPara mayor infomación consultar con Almacén.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                }
                                            }
                                            #endregion

                                            gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["Cantidad"], intCantidadTotal);
                                            lblMensaje.Text = CodigoProveedor;

                                            if (sDescPromocion.Length == 0)
                                            {
                                                CalculaDescuentoClienteFinal(IdProducto, intCantidadTotal);

                                                //Actualizar lista
                                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], decDescuentoFinal);
                                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioVenta"], decPrecioVenFinal);
                                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["ValorVenta"], decValorFinal);
                                            }

                                            //gvDocumentoVentaDetalle.focus .SelectCell(row, gvDocumentoVentaDetalle.Columns["CodigoProveedor"]);//add 101218
                                            gvDocumentoVentaDetalle.FocusedRowHandle = row;

                                            decDescuentoFinal = 0;
                                            decPrecioUnitFinal = 0;
                                            decPrecioVenFinal = 0;
                                            decValorFinal = 0;



                                        }
                                    }


                                    if (FlagPromocion2x1 == true) //add 15122019
                                        AsignarCodigoPromocion();//ADD 20 MAY 2015

                                    CalculaTotales();

                                    ////Armado
                                    //if (movDetalle.oBE.IdProductoArmado > 0)
                                    //{
                                    //    if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    //    {
                                    //        CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
                                    //    }
                                    //}

                                    ////ProductoAsociado
                                    //if (movDetalle.oBE.FlagCompuesto)
                                    //{
                                    //    CargarProductoAsociado(movDetalle.oBE.IdProducto, movDetalle.oBE.Cantidad, movDetalle.oBE.CodAfeIGV);
                                    //    XtraMessageBox.Show("Se agregó el complemento.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //}

                                    //AsignarCodigoPromocion();//add may 20
                                    //CalculaTotales();

                                    //btnNuevo.Focus();

                                    //Carga automática Según CHECK
                                    this.nuevoToolStripMenuItem_Click(sender, e);

                                    #endregion
                                }
                            }
                            else
                            {
                                #region "Agregar Nuevo"

                                gvDocumentoVentaDetalle.AddNewRow();
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdMarca", movDetalle.oBE.IdMarca);//2022
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ObsEscala", movDetalle.oBE.ObsEscala);//2022
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", movDetalle.oBE.CodAfeIGV);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagNacional", movDetalle.oBE.FlagNacional);//2022
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagEscala", movDetalle.oBE.FlagEscala);//2022
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "DescFamiliaProducto", movDetalle.oBE.DescFamiliaProducto);//2022
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "DescPromocion", movDetalle.oBE.DescPromocion);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdFamiliaProducto", movDetalle.oBE.IdFamiliaProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvDocumentoVentaDetalle.UpdateCurrentRow();
                                bNuevo = movDetalle.bNuevo;

                                //Armado
                                if (movDetalle.oBE.IdProductoArmado > 0)
                                {
                                    if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
                                    }
                                }

                                //ProductoAsociado
                                if (movDetalle.oBE.FlagCompuesto)
                                {
                                    CargarProductoAsociado(movDetalle.oBE.IdProducto, movDetalle.oBE.Cantidad, movDetalle.oBE.CodAfeIGV);
                                    XtraMessageBox.Show("Se agregó el complemento.", "Producto compuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                if (movDetalle.oBE.DescPromocion.Length > 0) //add 15122019
                                {
                                    FlagPromocion2x1 = true;
                                    AsignarCodigoPromocion();//ADD 20 MAY 2015
                                }

                                CalculaTotales();
                                CalculaTotales();
                                btnNuevo.Focus();

                                //Carga automática Según CHECK
                                this.nuevoToolStripMenuItem_Click(sender, e);
                                CalculaTotales();
                                #endregion
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
            bLogicaMayorista = true;
            if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegAutoServicioDetalle movDetalle = new frmRegAutoServicioDetalle();
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdDocumentoVenta = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVenta"));
                movDetalle.IdDocumentoVentaDetalle = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdMarca = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdMarca"));
                movDetalle.IdFamiliaProducto = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdFamiliaProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvDocumentoVentaDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvDocumentoVentaDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvDocumentoVentaDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.IdKardex = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdKardex"));
                movDetalle.PorcentajeDescuentoInicial = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PorcentajeDescuentoInicial"));
                movDetalle.CantidadModificada = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                movDetalle.FlagPromocion2x1 = FlagPromocion2x1;
                movDetalle.bFlagEscala = bool.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("FlagEscala").ToString()); //2022
                if (gvDocumentoVentaDetalle.GetFocusedRowCellValue("DescPromocion") != "")//Add 
                {
                    movDetalle.bNuevo = false;
                }


                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDocumentoVentaDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdKardex", movDetalle.oBE.IdKardex);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Stock", 0);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioUnitarioInicial", 0);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdFamiliaProducto", movDetalle.oBE.IdFamiliaProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdMarca", movDetalle.oBE.IdMarca);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDocumentoVentaDetalle.UpdateCurrentRow();

                        bNuevo = movDetalle.bNuevo;

                        CalculaTotales();

                        btnNuevo.Focus();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bLogicaMayorista = true;
                int IdDocumentoVentaDetalle = 0;
                if (gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle") != null)
                    IdDocumentoVentaDetalle = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                int Item = 0;
                if (gvDocumentoVentaDetalle.GetFocusedRowCellValue("Item") != null)
                    Item = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Item").ToString());
                DocumentoVentaDetalleBE objBE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                objBE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = IdDocumentoVentaDetalle;
                objBE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_DocumentoVentaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_DocumentoVentaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                DocumentoVentaDetalleBL objBL_DocumentoVentaDetalle = new DocumentoVentaDetalleBL();
                objBL_DocumentoVentaDetalle.Elimina(objBE_DocumentoVentaDetalle);
                gvDocumentoVentaDetalle.DeleteRow(gvDocumentoVentaDetalle.FocusedRowHandle);
                gvDocumentoVentaDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    item.Item = Convert.ToByte(cuenta + 1);
                    cuenta++;
                    i++;
                }

                CalculaTotales();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
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
                if (mListaDocumentoVentaDetalleOrigen.Count == 0)
                {
                    XtraMessageBox.Show("Ingrese algun producto para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                    IList list = cboEmpresa.Properties.DataSource as IList;
                int count = list.Count;

                // Bucle de las empresas
                for (int i = 0; i < count; i++)
                {
                    valueId = Convert.ToInt32(cboEmpresa.Properties.GetDataSourceValue("IdEmpresa", i));
                    value = Convert.ToString(cboEmpresa.Properties.GetDataSourceValue("RazonSocial", i));
                    //     XtraMessageBox.Show(value.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    CajaEmpresaBE objCajaEmpresa = null;
                    objCajaEmpresa = new CajaEmpresaBL().Selecciona(valueId, Parametros.intTiendaId, Parametros.intCajaId);

                    if (objCajaEmpresa == null)
                    {
                        XtraMessageBox.Show("No se puede imprimir en esta Caja, Documentos de venta de: " + value.ToString() + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TipoFormato = objCajaEmpresa.IdTipoFormato;

                    //Mayor a 700
                    if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToDecimal(txtTotal.EditValue) >= 700)
                    {
                        XtraMessageBox.Show("No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/700\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBuscar.Focus();
                        return;
                    }

                    if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                    {
                        XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + value.ToString() + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                    {
                        XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + value.ToString() + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (cboVendedor.Text == "")
                    {
                        XtraMessageBox.Show("Seleccionar un vendedor. Sin embargo se ingresará usuario actual por defecto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboVendedor.EditValue = Parametros.intPersonaId;
                        txtPIN.Select();
                        return;
                    }

                    #region "Validacion - Consulta RUC Data Local"
                    //Boleta con RUC
                    //if (NumDocumento.Trim().Length == 8 || NumDocumento.Trim().Length == 11)
                    //{
                    //    XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    int TipoDocFact = Convert.ToInt32(cboDocumento.EditValue);
                    if (TipoDocFact == Parametros.intTipoDocBoletaElectronica)
                    {
                        if (txtNumeroDocumento.Text.Trim().Length == 11)
                        {
                            XtraMessageBox.Show("No se puede emitir una boleta con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (TipoDocFact == Parametros.intTipoDocFacturaElectronica)
                    {
                        if (txtNumeroDocumento.Text.Trim().Length == 11)
                        {
                            ClienteBE objE_Cliente = null;
                            objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                            if (objE_Cliente != null)
                            {
                                //txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
                                //txtDescCliente.Text = objE_Cliente.DescCliente;
                                if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
                                {
                                    XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
                                {
                                    XtraMessageBox.Show("- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El RUC no existe en la base de datos " + objE_Cliente.DescCondicion + " Por favor consultar con Sistemas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El RUC " + txtNumeroDocumento.Text + " no es válido, Por favor verificar que tenga 11 caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    #endregion

                    //Agregar el detalle de promociones -- add 151119
                    if (FlagPromocion2x1)
                    {
                        // mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
                        // mListaDocumentoVentaDetalleOrigen = mListaDocumentoVentaDetalleOrigen2;
                    }

                    //Validar cuando es RER no permita boletearlo con cliente Mayorista
                    if (Convert.ToInt32(valueId) == 3 || Convert.ToInt32(valueId) == 19 || Convert.ToInt32(valueId) == 21 ||
                        Convert.ToInt32(valueId) == 23 || Convert.ToInt32(valueId) == 8 || Convert.ToInt32(valueId) == 20)
                    {
                        if (IdTipoCliente == 87)
                        {
                            // XtraMessageBox.Show("Solo puede emitir RER de " + value.ToString().Trim() + "\n a Clientes Finales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            continue;
                        }
                    }
                    if ((Convert.ToInt32(valueId) == 3 || Convert.ToInt32(valueId) == 19 || Convert.ToInt32(valueId) == 21 || Convert.ToInt32(valueId) == 23
                        || Convert.ToInt32(valueId) == 8 || Convert.ToInt32(valueId) == 20) && TipoDocFact == Parametros.intTipoDocFacturaElectronica)
                    {
                        continue;
                    }

                    IdEmpresa = Convert.ToInt32(valueId);

                    EmpresaBE objE_Empresa = null;
                    objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);
                    if (objE_Empresa != null)
                    {
                        #region "Promocion Cliente 22"
                        //CLIENTE N° 22
                        if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == Convert.ToDateTime("11/10/2018"))
                        {
                            DocumentoVentaBE objE_DocumentoVG = null;
                            objE_DocumentoVG = new DocumentoVentaBL().SeleccionaGanador22(Parametros.intTiendaId);
                            if (objE_DocumentoVG != null)
                            {
                                if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
                                {
                                    if (objE_DocumentoVG.TotalCantidad == 100)
                                    {
                                        CodigoNC = "10";
                                        #region "Impresión Vale"
                                        TalonBE objTalon = null;
                                        objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                        CreaTicket ticket = new CreaTicket();

                                        #region "Busca Impresora"
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

                                            if (printer.ToUpper().StartsWith(objTalon.Impresora)) //("(T)"))
                                            {
                                                found = true;
                                                ticket.impresora = @printer;
                                            }
                                        }

                                        if (!found)
                                        {
                                            MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                                        }
                                        #endregion
                                        ticket.TextoCentro("¡¡¡¡GANASTE!!!!");
                                        ticket.TextoIzquierdaNLineas("VALE DE S/50.00, CANJE VALIDO SÓLO EL LUNES 15 DE OCTUBRE EN TIENDA UCAYALI. PRESENTAR ESTE VOUCHER Y SU COMPROBANTE DE VENTA PARA HACER EFECTIVO.");
                                        ticket.CortaTicket();
                                        #endregion

                                        frmMensajePromocion frmMsg = new frmMensajePromocion();
                                        frmMsg.ShowDialog();
                                    }
                                    if (objE_DocumentoVG.TotalCantidad == 200)
                                    {
                                        CodigoNC = "20";
                                        #region "Impresión Vale"
                                        TalonBE objTalon = null;
                                        objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                        CreaTicket ticket = new CreaTicket();

                                        #region "Busca Impresora"
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

                                            if (printer.ToUpper().StartsWith(objTalon.Impresora)) //("(T)"))
                                            {
                                                found = true;
                                                ticket.impresora = @printer;
                                            }
                                        }

                                        if (!found)
                                        {
                                            MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                                        }
                                        #endregion
                                        ticket.TextoCentro("¡¡¡¡GANASTE!!!!");
                                        ticket.TextoIzquierdaNLineas("VALE DE S/50.00, CANJE VALIDO SÓLO EL LUNES 15 DE OCTUBRE EN TIENDA UCAYALI. PRESENTAR ESTE VOUCHER Y SU COMPROBANTE DE VENTA PARA HACER EFECTIVO.");
                                        ticket.CortaTicket();
                                        #endregion
                                        frmMensajePromocion frmMsg = new frmMensajePromocion();
                                        frmMsg.ShowDialog();
                                    }
                                }
                            }
                        }
                        #endregion

                        if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo RUS
                        {
                            bRegimenRus = true;
                            #region "Rus"

                            if (!ValidarTopeEmpresaRus()) //Mensual
                            {
                                if (!FlagImpresionRus) //add 160216
                                {
                                    XtraMessageBox.Show("No se puede imprimir una boleta RUS con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //return;
                                    continue;
                                }

                                if (!ValidarTopeEmpresaDiarioRus()) //Diario
                                {
                                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)  //THL  //THB  //TTE
                                    {
                                        // Validacion en RER si los productos exceden el descuento del 30%
                                        bool qValorReturn2 = ValidaPorcentajeDescuento();
                                        if (!qValorReturn2)
                                        {
                                            InsertarDocumentoVentaRUS(TipoDocFact);
                                            this.Close();
                                            return;
                                        }
                                        else
                                        {
                                            // XtraMessageBox.Show("No puede emitir RER con productos que contengan descuento \n mayores al 30%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            continue;
                                        }
                                    }
                                    //else
                                    //{
                                    //    if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                                    //    {
                                    //        InsertarDocumentoVentaRUS(TipoDocFact);
                                    //        //ImpresionDirecta("BOV");
                                    //        this.Close();
                                    //        return;
                                    //    }
                                    //    else
                                    //    {
                                    //        InsertarDocumentoVentaVariosRUS(6);
                                    //        //ImpresionDirecta("BOV");
                                    //        this.Close();
                                    //        return;
                                    //    }
                                    //}
                                }
                                else
                                { continue; }
                            }
                            else
                            { continue; }


                            #endregion
                        }
                        else if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRER)// solo Rus
                        {
                            #region "RER"

                            if (!ValidarTopeEmpresaRus()) //Mensual
                            {
                                if (!FlagImpresionRus) //add 160216
                                {
                                    XtraMessageBox.Show("No se puede imprimir una boleta RER con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }

                                if (!ValidarTopeEmpresaDiarioRus()) //Diario
                                {
                                    if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                                    {
                                        InsertarDocumentoVentaRUS(TipoDocFact);
                                        //ImpresionDirecta("BOV");
                                        this.Close();
                                        return;
                                    }
                                    else
                                    {
                                        InsertarDocumentoVentaVariosRUS(6);
                                        //ImpresionDirecta("BOV");
                                        this.Close();
                                        return;
                                    }
                                }
                                return;
                            }
                            return;

                            #endregion
                        }
                        else  // Regimen General y RER
                        {
                            #region "Ticket"
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                            {
                                Cursor = Cursors.WaitCursor;

                                CalculaTotales();

                                if (!ValidarIngreso())
                                {
                                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                                    objDocumentoVenta.IdDocumentoVenta = 0;
                                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                                    objDocumentoVenta.IdPedido = null;
                                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                                    //Obtener la serie del documento relacionado a la caja
                                    TalonBE objE_Talon = null;
                                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                                    if (objE_Talon != null)
                                    {
                                        Serie = "";
                                        Serie = objE_Talon.NumeroSerie;
                                    }

                                    if (Serie == null)
                                    {
                                        XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Cursor = Cursors.Default;
                                        cboDocumento.SelectAll();
                                        cboDocumento.Focus();
                                        return;
                                    }

                                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                                    {
                                        if (txtNumeroDocumento.Text.Length != 11)
                                        {
                                            XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            Cursor = Cursors.Default;
                                            txtNumeroDocumento.SelectAll();
                                            txtNumeroDocumento.Focus();
                                            return;
                                        }

                                    }

                                    //Obtener el numero del documento relacionado a la serie
                                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                                    if (mListaNumero.Count > 0)
                                    {
                                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                                    }

                                    #region "Verificar Número"

                                    DocumentoVentaBE objE_DocumentoVentaSerie = null;
                                    objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(Parametros.intEmpresaId, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                                    if (objE_DocumentoVentaSerie != null)
                                    {
                                        XtraMessageBox.Show("El documento " + cboDocumento.Text + ":" + Serie + "-" + Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    #endregion


                                    objDocumentoVenta.Serie = Serie;
                                    objDocumentoVenta.Numero = Numero;
                                    objDocumentoVenta.IdDocumentoReferencia = null;
                                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                    objDocumentoVenta.IdCliente = IdCliente;
                                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                                    objDocumentoVenta.Direccion = txtDireccion.Text;
                                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                                    objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                                    objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                                    objDocumentoVenta.PorcentajeDescuento = 0;
                                    objDocumentoVenta.Descuentos = 0;
                                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                                    objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                                    objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                                    objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                                    objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                                    objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);
                                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                                    objDocumentoVenta.FlagEstado = true;
                                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                                    objDocumentoVenta.IdTipoCliente = IdTipoCliente;
                                    objDocumentoVenta.CodigoNC = CodigoNC;
                                    objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                                    objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);

                                    //Documento Vneta Detalle
                                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                                    {
                                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                                        objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                                        objE_DocumentoVentaDetalle.Item = item.Item;
                                        objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                                        objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                                        objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                                        objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                                        objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                                        objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                                        objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                                        objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                                        objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                                        objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                                        objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                                        objE_DocumentoVentaDetalle.FlagEstado = true;
                                        objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                                    }

                                    //Movimiento Caja
                                    MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                                    objE_MovimientoCaja.TipoMovimiento = "I";
                                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                                    objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                                    objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                                    objE_MovimientoCaja.FlagEstado = true;
                                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;

                                    //Documento Venta Pago
                                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                                    {
                                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                                        objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                                        objE_Pago.IdDocumentoVenta = 0;
                                        objE_Pago.IdDocumentoVentaPago = 0;
                                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                                        objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                                        objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                                        objE_Pago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta)
                                            objE_Pago.Importe = Convert.ToDecimal(txtSubTotal.EditValue);
                                        else
                                            objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                                        objE_Pago.FlagEstado = true;
                                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                                        lstDocumentoVentaPago.Add(objE_Pago);
                                    }
                                    else
                                    {
                                        foreach (var item in mListaDocumentoVentaPagoOrigen)
                                        {
                                            DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                                            objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                                            objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                                            objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                                            objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                                            objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                                            objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                                            objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                                            objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                                            objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                                            objE_DocumentoVentaPago.Importe = item.Importe;
                                            objE_DocumentoVentaPago.FlagEstado = true;
                                            objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                                            lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                                        }
                                    }

                                    if (pOperacion == Operacion.Nuevo)
                                    {
                                        int IdDocumentoVenta = objBL_DocumentoVenta.InsertaAutoservicio(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                                        ImpresionTicket(cboDocumento.Text);

                                        #region "Envío de prueba"
                                        //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta)
                                        //{
                                        //    #region "Grabar"
                                        //    if (Parametros.bOnlineBoletaElectronica)
                                        //    {
                                        //        string MensajeService = FacturaE.GrabarVentaIntegrens(IdDocumentoVenta);
                                        //        if (MensajeService.ToUpper() != "OK")
                                        //            XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    }
                                        //    #endregion
                                        //}

                                        //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                                        //{
                                        //    #region "Grabar"
                                        //    if (Parametros.bOnlineFacturaElectronica)
                                        //    {
                                        //        string MensajeService = FacturaE.GrabarVentaIntegrens(IdDocumentoVenta);
                                        //        if (MensajeService.ToUpper() != "OK")
                                        //            XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    }
                                        //    #endregion

                                        //}
                                        #endregion

                                    }
                                    else
                                    {
                                        objBL_DocumentoVenta.ActualizaAutoservicio(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                                    }
                                }
                            }
                            #endregion

                            #region "Ticket Electrónico"
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                            {
                                #region "Diferencia cabecera vs detalle"
                                if (!bCumpleAnios)
                                {
                                    decimal TotalDiferencia = CalcularCabeceravsDetalle();
                                    if (TotalDiferencia != 0)
                                    {
                                        XtraMessageBox.Show("La suma de cabecera y detalle no son iguales. Por favor verificar con sistemas.\nNo se puede emitir una BE o FE con VALE o Promoción 2x1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                }



                                //if (Convert.ToDecimal(txtTotalBruto.EditValue) > 0)
                                //{
                                //    if (Convert.ToDecimal(txtTotalBruto.EditValue) != Convert.ToDecimal(txtTotal.EditValue))
                                //    {
                                //        XtraMessageBox.Show("No se puede emitir una BE o FE con VALE o Promoción 2x1 ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //        return;
                                //    }
                                //}
                                #endregion

                                Cursor = Cursors.WaitCursor;
                                //if (!FlagPromocion2x1)
                                CalculaTotales();

                                if (!ValidarIngreso())
                                {
                                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                                    objDocumentoVenta.IdDocumentoVenta = 0;
                                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                                    objDocumentoVenta.IdPedido = null;
                                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                                    //Obtener la serie del documento relacionado a la caja
                                    TalonBE objE_Talon = null;
                                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                                    if (objE_Talon != null)
                                    {
                                        Serie = "";
                                        Serie = objE_Talon.NumeroSerie;
                                    }

                                    if (Serie == null)
                                    {
                                        XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Cursor = Cursors.Default;
                                        cboDocumento.SelectAll();
                                        cboDocumento.Focus();
                                        return;
                                    }

                                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                                    {
                                        if (txtNumeroDocumento.Text.Length != 11)
                                        {
                                            XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            Cursor = Cursors.Default;
                                            txtNumeroDocumento.SelectAll();
                                            txtNumeroDocumento.Focus();
                                            return;
                                        }
                                    }

                                    //Obtener el numero del documento relacionado a la serie
                                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                                    if (mListaNumero.Count > 0)
                                    {
                                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                                    }

                                    #region "Verificar Número"

                                    DocumentoVentaBE objE_DocumentoVentaSerie = null;
                                    objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(Parametros.intEmpresaId, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                                    if (objE_DocumentoVentaSerie != null)
                                    {
                                        XtraMessageBox.Show("El documento " + cboDocumento.Text + ":" + Serie + "-" + Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    #endregion


                                    objDocumentoVenta.Serie = Serie;
                                    objDocumentoVenta.Numero = Numero;
                                    objDocumentoVenta.IdDocumentoReferencia = null;
                                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                    objDocumentoVenta.IdCliente = IdCliente;
                                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                                    objDocumentoVenta.Direccion = txtDireccion.Text;
                                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                                    objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                                    objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                                    objDocumentoVenta.PorcentajeDescuento = 0;
                                    objDocumentoVenta.Descuentos = 0;
                                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                                    objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                                    objDocumentoVenta.Icbper = Convert.ToDecimal(txtIcbper.EditValue);
                                    objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                                    objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                                    objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                                    objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);
                                    objDocumentoVenta.Observacion = "DOC.ELECTRONICO POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                                    objDocumentoVenta.FlagEstado = true;
                                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                                    objDocumentoVenta.IdTipoCliente = IdTipoCliente;
                                    objDocumentoVenta.CodigoNC = CodigoNC;
                                    objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                                    objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);

                                    //Documento Vneta Detalle
                                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                                    {
                                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                                        objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                                        objE_DocumentoVentaDetalle.Item = item.Item;
                                        objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                                        objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                                        objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                                        objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                                        objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                                        objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                                        objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                                        objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                                        objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                                        objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                                        objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                                        objE_DocumentoVentaDetalle.FlagEstado = true;
                                        objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                                    }

                                    //Movimiento Caja
                                    MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                                    objE_MovimientoCaja.TipoMovimiento = "I";
                                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                                    objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                                    objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                                    objE_MovimientoCaja.FlagEstado = true;
                                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;

                                    //Documento Venta Pago
                                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                                    {
                                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                                        objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                                        objE_Pago.IdDocumentoVenta = 0;
                                        objE_Pago.IdDocumentoVentaPago = 0;
                                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                                        objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                                        objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                                        objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                                        objE_Pago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta)
                                            objE_Pago.Importe = Convert.ToDecimal(txtSubTotal.EditValue);
                                        else
                                            objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                                        objE_Pago.FlagEstado = true;
                                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                                        lstDocumentoVentaPago.Add(objE_Pago);
                                    }
                                    else
                                    {
                                        foreach (var item in mListaDocumentoVentaPagoOrigen)
                                        {
                                            DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                                            objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                                            objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                                            objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                                            objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                                            objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                                            objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                                            objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                                            objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                                            objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                                            objE_DocumentoVentaPago.Importe = item.Importe;
                                            objE_DocumentoVentaPago.IdEstadoCuentaCliente = null;
                                            objE_DocumentoVentaPago.FlagEstado = true;
                                            objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                                            lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                                        }
                                    }

                                    if (pOperacion == Operacion.Nuevo)
                                    {
                                        int IdDocumentoVenta = 0;
                                        IdDocumentoVenta = objBL_DocumentoVenta.InsertaAutoservicio(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);

                                        #region "Envío e Impresión de Comprobante electrónico"
                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                                        {
                                            #region "Grabar"
                                            if (Parametros.bOnlineBoletaElectronica)
                                            {
                                                string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                                                if (MensajeService.ToUpper() != "OK")
                                                {
                                                    XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    this.Close();
                                                }
                                            }
                                            #endregion

                                            #region "Impresión"
                                            TalonBE objTalon = null;
                                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                            ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                                            //ImpresionTicketElectronico("C");
                                            #endregion
                                        }

                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                                        {
                                            #region "Grabar"
                                            if (Parametros.bOnlineFacturaElectronica)
                                            {
                                                string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                                                if (MensajeService.ToUpper() != "OK")
                                                    XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            #endregion

                                            #region "Impresión"
                                            TalonBE objTalon = null;
                                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                            ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                                            //ImpresionTicketElectronico("C");
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        objBL_DocumentoVenta.ActualizaAutoservicio(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                                    }
                                }

                            }
                            #endregion

                            #region "Documento continuo"

                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
                            {
                                if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                                {
                                    InsertarDocumentoVenta();
                                    //ImpresionTicket("BOV");
                                }
                                else
                                {
                                    InsertarDocumentoVentaVarios(6);
                                    //ImpresionTicket("BOV");
                                }
                            }

                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                            {
                                if (txtNumeroDocumento.Text.Length != 11)
                                {
                                    XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtNumeroDocumento.SelectAll();
                                    txtNumeroDocumento.Focus();
                                    return;
                                }
                                if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
                                {
                                    InsertarDocumentoVenta();
                                    //ImpresionTicket("FAV");
                                }
                                else
                                {
                                    InsertarDocumentoVentaVarios(10);
                                    //ImpresionTicket("FAV");
                                }
                            }

                            this.Close();

                            #endregion
                        }
                    }
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

        private bool ValidaPorcentajeDescuento()
        {
            bool flag = false;
            //mListaDetalle = null;
            //mListaDetalle = gvDocumentoVentaDetalle.DataSource;
            List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
            lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

            for (int i = 0; i < gvDocumentoVentaDetalle.DataRowCount; i++)
            {
                if (Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString()) > 30)
                {
                    // XtraMessageBox.Show("siii", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = true;
                }
            }




            //foreach (var item in mListaDetalle)
            //{
            //    if (item.PorcentajeDescuento > 30)
            //    {
            //        flag = true;
            //    }
            //}

            return flag;
        }

        private void txtIngresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                cboCondicionPago.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtImporte.EditValue) == 0)
                {
                    XtraMessageBox.Show("El importe no puede ser 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.EditValue) < 0)
                {
                    XtraMessageBox.Show("El importe no puede ser menor a 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.EditValue) > Convert.ToDecimal(txtTotalResumen.Text))
                {
                    XtraMessageBox.Show("El importe no puede ser mayor al total de la venta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.Text) > Convert.ToDecimal(txtResta.Text))
                {
                    XtraMessageBox.Show("El importe no puede ser mayor a la resta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                CDocumentoVentaPago objE_Pago = new CDocumentoVentaPago();
                objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                objE_Pago.IdDocumentoVenta = 0;
                objE_Pago.IdDocumentoVentaPago = 0;
                objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                objE_Pago.CodTipoDocumento = cboDocumento.Text;
                objE_Pago.NumeroDocumento = "";
                objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_Pago.DescCondicionPago = cboCondicionPago.Text;
                objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                objE_Pago.CodMoneda = cboMonedaPago.Text;
                objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_Pago.Importe = Convert.ToDecimal(txtImporte.EditValue);
                objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                mListaDocumentoVentaPagoOrigen.Add(objE_Pago);

                bsListadoPago.DataSource = mListaDocumentoVentaPagoOrigen;
                gcDocumentoVentaPago.DataSource = bsListadoPago;
                gcDocumentoVentaPago.RefreshDataSource();

                if (Convert.ToInt32(cboMonedaPago.EditValue) == Parametros.intSoles)
                {
                    txtResta.EditValue = Convert.ToDecimal(txtResta.Text) - Convert.ToDecimal(txtImporte.Text);
                }
                else
                {
                    txtResta.EditValue = Convert.ToDecimal(txtResta.Text) - (Convert.ToDecimal(txtImporte.Text) * Convert.ToDecimal(txtTC.EditValue));
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void elimiarPagotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdDocumentoVentaDetalle = 0;
                if (gvDocumentoVentaPago.GetFocusedRowCellValue("IdDocumentoVentaDetalle") != null)
                    IdDocumentoVentaDetalle = int.Parse(gvDocumentoVentaPago.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                int Item = 0;
                if (gvDocumentoVentaPago.GetFocusedRowCellValue("Item") != null)
                    Item = int.Parse(gvDocumentoVentaPago.GetFocusedRowCellValue("Item").ToString());
                DocumentoVentaDetalleBE objBE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                objBE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = IdDocumentoVentaDetalle;
                objBE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_DocumentoVentaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_DocumentoVentaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                DocumentoVentaDetalleBL objBL_DocumentoVentaDetalle = new DocumentoVentaDetalleBL();
                objBL_DocumentoVentaDetalle.Elimina(objBE_DocumentoVentaDetalle);
                gvDocumentoVentaPago.DeleteRow(gvDocumentoVentaPago.FocusedRowHandle);
                gvDocumentoVentaPago.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIngresa_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtIngresa.EditValue.ToString()) > Convert.ToDecimal(txtTotal.EditValue))
            {
                txtVuelto.EditValue = Convert.ToDecimal(txtIngresa.EditValue.ToString()) - Convert.ToDecimal(txtTotal.EditValue.ToString());
            }
        }

        private void tsmMenuSelText_Click(object sender, EventArgs e)
        {
            txtIngresa.Focus();
            txtIngresa.SelectAll();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F8) CobrarImprimir();
            if (keyData == Keys.F1) AgregarProductoOutlet();
            if (keyData == Keys.F2) txtPIN.Select();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCobrarVarios_Click(object sender, EventArgs e)
        {
            CobrarImprimir();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(IdEmpresa, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
        }

        private void gcDocumentoVentaDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            /*     if (Convert.ToDecimal(txtTotal.Text) > 0)
                  {

                      if (e.KeyCode == Keys.F8)
                      {

                          //Obtener la serie del documento relacionado a la caja
                          TalonBE objE_Talon = null;
                          objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                          if (objE_Talon != null)
                          {
                              Serie = "";
                              Serie = objE_Talon.NumeroSerie;
                          }

                          if (Serie == null)
                          {
                              XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                              Cursor = Cursors.Default;
                              cboDocumento.Focus();
                              return;
                          }

                          //mListaDetalle = null;
                          //mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);


                          frmMsgPagoCondicion frmMsgPago = new frmMsgPagoCondicion();
                          frmMsgPago.NumeroPedido = "";
                          frmMsgPago.Total = Convert.ToDecimal(txtTotal.Text);
                          frmMsgPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                          frmMsgPago.ShowDialog();

                          if (frmMsgPago.DialogResult == DialogResult.OK)
                          {
                              cboDocumento.EditValue = frmMsgPago.IdTipoDocumento;//Capturamos el valor
                              if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
                              {
                                  if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                                  {
                                      InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard);
                                  }
                                  else
                                  {
                                      InsertarDocumentoVentaVariosPagoVarios(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard);
                                  }
                              }

                              if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                              {
                                  if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
                                      {
                                          InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard);
                                      }
                                      else
                                      {
                                          InsertarDocumentoVentaVariosPagoVarios(10, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard);
                                      }
                              }

                              if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketBoleta)
                              {
                                  InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard);
                                 // ImpresionDirecta("TKV");
                              }
                              if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketFactura)
                              {
                                  InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard);
                                 // ImpresionDirecta("TKF");
                              }
                              this.Close();
                          }
                      }
                  }
                  else
                  {
                      XtraMessageBox.Show("No se puede cobrar un pedido con monto cero, Seleccionar un pedido ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }*/
        }

        private void btnOutlet_Click(object sender, EventArgs e)
        {
            AgregarNuevoOutlet();
            //try
            //{
            //    if (txtNumeroDocumento.Text.Trim() == "")
            //    {
            //        XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    frmRegAutoServicioDetalleOutlet movDetalle = new frmRegAutoServicioDetalleOutlet();
            //    int i = 0;
            //    if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            //        i = mListaDocumentoVentaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
            //    movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
            //    movDetalle.IdTipoCliente = IdTipoCliente;
            //    movDetalle.IdClasificacionCliente = IdClasificacionCliente;
            //    movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
            //    movDetalle.bDescuentoCumpleanio = bCumpleAnios;
            //    if (movDetalle.ShowDialog() == DialogResult.OK)
            //    {
            //        if (movDetalle.oBE != null)
            //        {
            //            if (mListaDocumentoVentaDetalleOrigen.Count == 0)
            //            {
            //                gvDocumentoVentaDetalle.AddNewRow();
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
            //                gvDocumentoVentaDetalle.UpdateCurrentRow();

            //                bNuevo = movDetalle.bNuevo;

            //                //Armado
            //                if (movDetalle.oBE.IdProductoArmado > 0)
            //                {
            //                    if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                    {
            //                        CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
            //                    }
            //                }

            //                CalculaTotales();

            //                btnNuevo.Focus();

            //                return;

            //            }
            //            if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            //            {
            //                var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
            //                if (Buscar.Count > 0)
            //                {
            //                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //                gvDocumentoVentaDetalle.AddNewRow();
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
            //                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
            //                gvDocumentoVentaDetalle.UpdateCurrentRow();

            //                bNuevo = movDetalle.bNuevo;

            //                //Armado
            //                if (movDetalle.oBE.IdProductoArmado > 0)
            //                {
            //                    if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                    {
            //                        CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
            //                    }
            //                }

            //                CalculaTotales();

            //                btnNuevo.Focus();
            //            }
            //        }
            //    }


            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void AgregarNuevoOutlet()
        {
            try
            {
                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmRegAutoServicioDetalleOutlet movDetalle = new frmRegAutoServicioDetalleOutlet();
                int i = 0;
                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                    i = mListaDocumentoVentaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.bDescuentoCumpleanio = bCumpleAnios;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count == 0)
                        {
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto + " - OUTLET");
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            //Armado
                            if (movDetalle.oBE.IdProductoArmado > 0)
                            {
                                if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
                                }
                            }

                            CalculaTotales();

                            btnNuevo.Focus();

                            return;

                        }
                        if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto + " - OUTLET");
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            //Armado
                            if (movDetalle.oBE.IdProductoArmado > 0)
                            {
                                if (XtraMessageBox.Show("Este producto necesita de armado, desea solicitar el servicio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    CargarProductoArmado(movDetalle.oBE.IdProductoArmado);
                                }
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

        private void btnCobrarManual_Click(object sender, EventArgs e)
        {
            //if(Convert.ToDateTime(DateTime.Now.ToShortDateString())>= Convert.ToDateTime("01/11/2018"))
            //{
            //    XtraMessageBox.Show("A partir de la fecha no se puede emitir una boleta manual",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            CobrarDocumentoManual();
            /*if (Convert.ToDecimal(txtTotal.EditValue)  == 0)
            {
                XtraMessageBox.Show("No se puede generar un documento sin Items.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Mayor a 700
            if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToDecimal(txtTotal.EditValue) >= 700)
            {
                XtraMessageBox.Show("No se puede Generar un comprobante como " + Parametros.intIdClienteGeneral + ", el importe es mayor a S/700\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
            {
                XtraMessageBox.Show("No se puede Generar una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //mListaDetalle = null;
            //mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

            if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
            {
                frmMsgPagoCondicionManual frmEmpresaEmisora = new frmMsgPagoCondicionManual();
                //frmEmpresaEmisora.Total = decimal.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Total").ToString());
                if (frmEmpresaEmisora.ShowDialog() == DialogResult.OK)
                {
                    //InsertarDocumentoVentaEmpresa(frmEmpresaEmisora.IdTipoDocumento, frmEmpresaEmisora.IdEmpresa, frmEmpresaEmisora.Serie, frmEmpresaEmisora.Numero, frmEmpresaEmisora.Fecha);
                }
            }
            else
            {
                if (XtraMessageBox.Show("El Pedido seleccionado va a generar  mas ( 1 (una) boletas de ventas) \n Estas seguro(a) de realizarlo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmMsgPagoCondicionManual frmEmpresaEmisora = new frmMsgPagoCondicionManual();
                    frmEmpresaEmisora.Total = decimal.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Total").ToString());
                    if (frmEmpresaEmisora.ShowDialog() == DialogResult.OK)
                    {
                        //InsertarDocumentoVentaVariosEmpresa(6, frmEmpresaEmisora.IdTipoDocumento, frmEmpresaEmisora.IdEmpresa, frmEmpresaEmisora.Serie, frmEmpresaEmisora.Numero, frmEmpresaEmisora.Fecha);
                    }
                }
            }*/
        }

        private void gvDocumentoVentaDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumentoVentaDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["DescPromocion"]);
                    if (objDocRetiro != null)
                    {
                        //int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        string IdTipoDocumento = objDocRetiro.ToString();
                        if (IdTipoDocumento == "2x1")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        if (IdTipoDocumento == "3x2")
                        {
                            e.Appearance.BackColor = Color.Pink;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                    }

                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                    {
                        object objObsEscala = View.GetRowCellValue(e.RowHandle, View.Columns["ObsEscala"]); //o en Escala
                        if (objObsEscala != null)
                        {
                            gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"].AppearanceCell.BackColor = Color.White;
                            gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"].AppearanceCell.BackColor2 = Color.White;
                            string ObsEscala = objObsEscala.ToString();
                            if (ObsEscala != "")
                            {
                                gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"].AppearanceCell.BackColor = Color.Green;
                                gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"].AppearanceCell.BackColor2 = Color.SeaShell;
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
            if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime("01/07/2017"))
            {
                mListaDescuentoPromocion6x3 = new Promocion2x1DetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), "6x3", Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));
            }
        }

        private void CargarPromocionVale()
        {
            //mListaPromocionVale = new PromocionValeDescuentoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId);//add250516
            mListaPromocionVale = new PromocionValeDescuentoBL().ListaFecha(Parametros.intEmpresaId, Parametros.intTiendaId, 1);
        }

        private void CargarEscala()
        {
            int FPago = Convert.ToInt32(cboFormaPago.EditValue);
            mListaEscalaMayorista = new EscalaMayoristaBL().ListaTodosActivo(0, FPago);
        }


        private void AsignarCodigoPromocion()
        {
            if (FlagPromocion2x1)
            {
                //this.gvDocumentoVentaDetalle.Columns["IdPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;//modificar para todos
                this.gvDocumentoVentaDetalle.Columns["DescPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;//modificar para todos
                this.gvDocumentoVentaDetalle.Columns["PrecioUnitario"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

                //Asignar valor ordenado de Item
                int PosicionX = 0;

                foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
                {
                    gvDocumentoVentaDetalle.SetRowCellValue(PosicionX, gvDocumentoVentaDetalle.Columns["Item"], PosicionX + 1);
                    PosicionX = PosicionX + 1;
                }
            }


            //CargarProductoPromocionDosPorUno(); //Dos por uno 

            #region "Version Anterior"

            //if (chkVale.Checked == false)
            //{
            //    //add 18 05 2015
            //    if (gvDocumentoVentaDetalle.RowCount > 0)
            //    {
            //        //if (IdTipoCliente == Parametros.intTipClienteFinal || IdClasificacionCliente != Parametros.intBlack)
            //        //{
            //        for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++) //Existe
            //        {
            //            int IdProductoLista = 0;
            //            int row = gvDocumentoVentaDetalle.GetRowHandle(i);

            //            IdProductoLista = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["IdProducto"])));
            //            //IdAlmacenOrigen = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["IdAlmacenOrigen"])));


            //            #region "2x1"
            //            foreach (var item in mListaDescuentoPromocionDosPorUno) // SELECT directo
            //            {
            //                if (item.IdProducto == IdProductoLista)
            //                {
            //                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "2x1");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605

            //                        //add para descuento = 0;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }
            //                    else
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //1);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "2x1");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605

            //                        //add para descuento = 0;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }

            //                }
            //            }
            //            #endregion

            //            #region "3x2"
            //            foreach (var item in mListaDescuentoPromocion3x2) // SELECT directo
            //            {
            //                if (item.IdProducto == IdProductoLista)
            //                {
            //                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "3x2");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                            //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }
            //                    else
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "3x2");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                        //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }

            //                }
            //            }
            //            #endregion

            //            #region "3x1"
            //            foreach (var item in mListaDescuentoPromocion3x1) // SELECT directo
            //            {
            //                if (item.IdProducto == IdProductoLista)
            //                {
            //                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "3x1");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                                            //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }
            //                    else
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "3x1");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                                     //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }

            //                }
            //            }
            //            #endregion

            //            #region "4x1"
            //            foreach (var item in mListaDescuentoPromocion4x1) // SELECT directo
            //            {
            //                if (item.IdProducto == IdProductoLista)
            //                {
            //                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "4x1");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                                            //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115
            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }
            //                    else
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "4x1");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }
            //                }
            //            }
            //            #endregion

            //            #region "6x3"
            //            foreach (var item in mListaDescuentoPromocion6x3) // SELECT directo
            //            {
            //                if (item.IdProducto == IdProductoLista)
            //                {
            //                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "6x3");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
            //                                                                                                                            //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }
            //                    else
            //                    {
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "6x3");
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.Precio);//add 2605
            //                                                                                                                        //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

            //                        //add para descuento = 0;
            //                        //decimal decDescuento = item.Descuento;
            //                        decimal decDescuento = 0;
            //                        decimal decPrecioVenta = 0;
            //                        decimal decValorVenta = 0;
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
            //                        decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
            //                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
            //                        gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
            //                        gvDocumentoVentaDetalle.RefreshData();

            //                        FlagPromocion2x1 = true;
            //                    }

            //                }
            //            }
            //            #endregion

            //        }

            //        if (mListaDescuentoPromocionDosPorUno.Count > 0 || mListaDescuentoPromocion3x2.Count > 0 || mListaDescuentoPromocion3x1.Count > 0 || mListaDescuentoPromocion4x1.Count > 0 || mListaDescuentoPromocion6x3.Count > 0 && FlagPromocion2x1 == true)//add2605
            //        {
            //            this.gvDocumentoVentaDetalle.Columns["IdPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;//modificar para todos
            //            this.gvDocumentoVentaDetalle.Columns["PrecioUnitario"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            //            //Asignar valor ordenado de Item
            //            int PosicionX = 0;

            //            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            //            {
            //                gvDocumentoVentaDetalle.SetRowCellValue(PosicionX, gvDocumentoVentaDetalle.Columns["Item"], PosicionX + 1);
            //                PosicionX = PosicionX + 1;
            //            }
            //        }
            //    }
            //}
            #endregion

        }

        private decimal BuscarPromocionTemporal(int IdProducto)
        {
            decimal Descuento = 0;
            int IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
            int IdTipoVenta = Convert.ToInt32(0);
            PromocionTemporalDetalleBE objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
            if (objE_PromocionTemporal != null)
            {
                Descuento = objE_PromocionTemporal.Descuento;
            }
            return Descuento;
        }

        private void CalculaTotalPromocion2x1()
        {
            #region "2022/06 ecm 2x1 v2"
            if (IdTipoCliente != Parametros.intTipClienteFinal) return;
            if (IdClasificacionCliente == Parametros.intBlack) return;

            List<CDocumentoVentaDetalle> nLista2x1 = mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion == "2x1").ToList();
            List<CDocumentoVentaDetalle> nLista3x2 = mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion == "3x2").ToList();

            #region "2x1 ecm"
            if (nLista2x1.Count != 0)
            {
                nLista2x1 = nLista2x1.OrderByDescending(x => x.PrecioUnitario).ToList();

                List<CDocumentoVentaDetalle> nListaNuevo2x1 = new List<CDocumentoVentaDetalle>();
                int iCount = 1;
                int l2x1count = nLista2x1.Sum(x => x.Cantidad);
                bool l2x1Multiplo = true;
                if (l2x1count % 2 != 0)
                {
                    l2x1Multiplo = false;
                }

                foreach (CDocumentoVentaDetalle item in nLista2x1)
                {
                    int cant = item.Cantidad;
                    int IdProducto = item.IdProducto;
                    decimal PrecioUni = item.PrecioUnitario;
                    bool FlagMuestra = item.FlagMuestra;
                    decimal PorcentajeDesc = 0;

                    for (int i2 = 0; i2 <= cant - 1; i2++)
                    {
                        CDocumentoVentaDetalle RegItem = new CDocumentoVentaDetalle();
                        decimal PrecioUniFinal = PrecioUni;

                        if (l2x1count == iCount)
                        {
                            if (l2x1Multiplo == false)
                            {
                                PorcentajeDesc = BuscarPromocionTemporal(IdProducto);
                                if (item.FlagFijarDescuento)
                                {
                                    PorcentajeDesc = item.PorcentajeDescuento;
                                }
                                PrecioUniFinal = Math.Round(PrecioUniFinal * ((100 - PorcentajeDesc) / 100), 2);
                                if (cant != 1)
                                {
                                    PorcentajeDesc = 0;
                                }
                            }
                        }
                        RegItem.IdProducto = IdProducto;
                        RegItem.Item = iCount;
                        RegItem.PrecioUnitario = PrecioUniFinal;
                        RegItem.PorcentajeDescuento = PorcentajeDesc;
                        RegItem.FlagMuestra = FlagMuestra;
                        if (iCount % 2 == 0)
                        {
                            RegItem.PrecioUnitario = 0;
                        }

                        nListaNuevo2x1.Add(RegItem);
                        iCount += 1;
                    }
                }

                foreach (CDocumentoVentaDetalle item in nLista2x1)
                {
                    int IdProducto = item.IdProducto;
                    int iCant = item.Cantidad;
                    bool FlagMuestra = item.FlagMuestra;
                    decimal dSuma = nListaNuevo2x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);
                    decimal PorcentajeDescuento = nListaNuevo2x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PorcentajeDescuento);

                    //decimal pVenta =   Math.Round(dSuma / iCant, 2); // (dSuma / iCant );
                    //decimal PrecioVenta2x1 = Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2);
                    //decimal ValorVenta2x1 =  Math.Round(PrecioVenta2x1 * iCant, 2); // Math.Round(pVenta * iCant, 2);

                    decimal pVenta = (dSuma / iCant);
                    decimal PrecioVenta2x1 = Math.Round(pVenta, 2);
                    decimal ValorVenta2x1 = Math.Round(pVenta * iCant, 2);

                    mListaDocumentoVentaDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
                        s => {
                            s.PorcentajeDescuento = PorcentajeDescuento;
                            s.PrecioVenta = PrecioVenta2x1;
                            s.ValorVenta = ValorVenta2x1;
                        }
                   );
                }
            }
            #endregion

            #region "3x2 ecm"
            if (nLista3x2.Count != 0)
            {
                nLista3x2 = nLista3x2.OrderByDescending(x => x.PrecioUnitario).ToList();

                List<CDocumentoVentaDetalle> nListaNuevo3x2 = new List<CDocumentoVentaDetalle>();
                int iCount = 0;

                int l3x2count = nLista3x2.Sum(x => x.Cantidad);
                bool l3x2Multiplo = true;
                if (l3x2count % 3 != 0)
                {
                    l3x2Multiplo = false;
                    l3x2count -= 1;
                    if (l3x2count % 3 != 0)
                    {
                        l3x2count -= 1;
                    }
                }

                foreach (CDocumentoVentaDetalle item in nLista3x2)
                {
                    int cant = item.Cantidad;
                    int IdProducto = item.IdProducto;
                    decimal PrecioUni = item.PrecioUnitario;
                    bool FlagMuestra = item.FlagMuestra;
                    decimal PorcentajeDesc = 0;

                    for (int i2 = 0; i2 <= cant - 1; i2++)
                    {
                        CDocumentoVentaDetalle RegItem = new CDocumentoVentaDetalle();
                        iCount += 1;

                        decimal PrecioUniFinal = PrecioUni;
                        if (l3x2count < iCount)
                        {
                            if (l3x2Multiplo == false)
                            {
                                PorcentajeDesc = BuscarPromocionTemporal(IdProducto);
                                if (item.FlagFijarDescuento)
                                {
                                    PorcentajeDesc = item.PorcentajeDescuento;
                                }
                                PrecioUniFinal = Math.Round(PrecioUniFinal * ((100 - PorcentajeDesc) / 100), 2);

                                if (cant != 1 && cant != 2)
                                {
                                    PorcentajeDesc = 0;
                                }
                            }
                        }

                        RegItem.IdProducto = IdProducto;
                        RegItem.Item = iCount;
                        RegItem.PrecioUnitario = PrecioUniFinal;
                        RegItem.PorcentajeDescuento = PorcentajeDesc;
                        RegItem.FlagMuestra = FlagMuestra;
                        if (iCount % 3 == 0)
                        {
                            RegItem.PrecioUnitario = 0;
                        }

                        nListaNuevo3x2.Add(RegItem);
                    }
                }

                foreach (CDocumentoVentaDetalle item in nLista3x2)
                {
                    int IdProducto = item.IdProducto;
                    int iCant = item.Cantidad;
                    bool FlagMuestra = item.FlagMuestra;
                    decimal dSuma = nListaNuevo3x2.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);
                    decimal PorcentajeDescuento = nListaNuevo3x2.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PorcentajeDescuento);

                    decimal pVenta = Math.Round(dSuma / iCant, 2); // (dSuma / iCant );
                    decimal PrecioVenta3x2 = Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2);
                    decimal ValorVenta3x2 = Math.Round(PrecioVenta3x2 * iCant, 2); // Math.Round(pVenta * iCant, 2);

                    mListaDocumentoVentaDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
                        s =>
                        {
                            s.PorcentajeDescuento = PorcentajeDescuento;
                            s.PrecioVenta = PrecioVenta3x2;
                            s.ValorVenta = ValorVenta3x2;
                        }
                   );
                }
            }
            #endregion

            #region "Promociones Listas pero Pendientes a Aprobación"
            List<CDocumentoVentaDetalle> nLista3x1 = mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion == "3x1").ToList();
            List<CDocumentoVentaDetalle> nLista4x1 = mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion == "4x1").ToList();
            List<CDocumentoVentaDetalle> nLista6x3 = mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion == "6x3").ToList();

            List<CDocumentoVentaDetalle> nLista2DO_50 = mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion == "2DOx50").ToList();

            #region "3x1 ecm"
            //if (nLista3x1.Count != 0)
            //{
            //   nLista3x1 = nLista3x1.OrderByDescending(x => x.PrecioUnitario).ToList();

            //    int iCount = 0;
            //    List<CPedidoDetalle> nListaNuevo3x1 = new List<CPedidoDetalle>();
            //    decimal PorDesc3x1 = 0;

            //    foreach (CPedidoDetalle item in nLista3x1)
            //    {
            //        int cant = item.Cantidad;
            //        int IdProducto = item.IdProducto;
            //        decimal PrecioUni = item.PrecioUnitario;
            //        decimal PorcentajeDesc = item.PorcentajeDescuento;
            //        bool FlagMuestra = item.FlagMuestra;

            //        decimal Con_Porcentaje_PrecioUni = Math.Round(PrecioUni * ((100 - PorcentajeDesc) / 100), 2);
            //        if (PorcentajeDesc > 0)
            //        {
            //            PorDesc3x1 += (PrecioUni - Con_Porcentaje_PrecioUni);
            //        }
            //        PrecioUni = Con_Porcentaje_PrecioUni;

            //        int iCantidadMult = cant;
            //        int iTres = 3;
            //        int indTres = 1;
            //        if (cant >= iTres)
            //        {
            //            for (int i2 = 0; i2 <= cant - 1; i2++)
            //            {
            //                CPedidoDetalle RegItem = new CPedidoDetalle();
            //                iCount += 1;

            //                RegItem.IdProducto = IdProducto;
            //                RegItem.Item = iCount;
            //                RegItem.PrecioUnitario = PrecioUni;
            //                RegItem.FlagMuestra = FlagMuestra;

            //                if (iCantidadMult >= iTres)
            //                {
            //                    if (indTres % 2 == 0 || indTres % 3 == 0)
            //                    {
            //                        RegItem.PrecioUnitario = 0;
            //                    }
            //                }

            //                nListaNuevo3x1.Add(RegItem);

            //                if (indTres == iTres)
            //                {
            //                    indTres = 0;
            //                    iCantidadMult = iCantidadMult - iTres;
            //                }
            //                indTres += 1;
            //            }
            //        }

            //    }
            //    //if (nListaNuevo3x2.Count == 0) return;

            //    foreach (CPedidoDetalle item in nLista3x1)
            //    {
            //        int IdProducto = item.IdProducto;
            //        int iCant = item.Cantidad;
            //        bool FlagMuestra = item.FlagMuestra;
            //        decimal dSuma = nListaNuevo3x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);


            //        decimal PrecioUni = nListaNuevo3x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PrecioUnitario);


            //        decimal pVenta =  Math.Round(dSuma / iCant, 2); // (dSuma / iCant); 
            //        decimal PrecioVenta3x1 =  Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2); 
            //        decimal ValorVenta3x1 =  Math.Round(PrecioVenta3x1 * iCant, 2); // Math.Round(pVenta * iCant, 2); 

            //        mListaPedidoDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
            //            s =>
            //            {
            //                //s.PrecioUnitario = PrecioUni;
            //                s.PrecioVenta = PrecioVenta3x1;
            //                s.ValorVenta = ValorVenta3x1;
            //            }
            //       );
            //    }

            //    if (PorDesc3x1 > 0)
            //    {
            //        //if (MessageBox.Show(PorDesc3x1.ToString(), "My Application", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            //    }
            //}
            #endregion

            #region "4x1 ecm"
            //if (nLista4x1.Count != 0)
            //{
            //    nLista4x1 = nLista4x1.OrderByDescending(x => x.PrecioUnitario).ToList();

            //    int iCount = 0;
            //    List<CPedidoDetalle> nListaNuevo4x1 = new List<CPedidoDetalle>();
            //    decimal PorDesc4x1 = 0;

            //    foreach (CPedidoDetalle item in nLista4x1)
            //    {
            //        int cant = item.Cantidad;
            //        int IdProducto = item.IdProducto;
            //        decimal PrecioUni = item.PrecioUnitario;
            //        decimal PorcentajeDesc = item.PorcentajeDescuento;
            //        bool FlagMuestra = item.FlagMuestra;

            //        decimal Con_Porcentaje_PrecioUni = Math.Round(PrecioUni * ((100 - PorcentajeDesc) / 100), 2);
            //        if (PorcentajeDesc > 0)
            //        {
            //            PorDesc4x1 += (PrecioUni - Con_Porcentaje_PrecioUni);
            //        }
            //        PrecioUni = Con_Porcentaje_PrecioUni;

            //        int iCantidadMult = cant;
            //        int iCuatro = 4;
            //        int indCuatro = 1;
            //        if (cant >= iCuatro)
            //        {
            //            for (int i2 = 0; i2 <= cant - 1; i2++)
            //            {
            //                CPedidoDetalle RegItem = new CPedidoDetalle();
            //                iCount += 1;

            //                RegItem.IdProducto = IdProducto;
            //                RegItem.Item = iCount;
            //                RegItem.PrecioUnitario = PrecioUni;
            //                RegItem.FlagMuestra = FlagMuestra;

            //                if (iCantidadMult >= iCuatro)
            //                {
            //                    if (indCuatro % 2 == 0 || indCuatro % 3 == 0 || indCuatro % 4 == 0)
            //                    {
            //                        RegItem.PrecioUnitario = 0;
            //                    }
            //                }

            //                nListaNuevo4x1.Add(RegItem);

            //                if (indCuatro == iCuatro)
            //                {
            //                    indCuatro = 0;
            //                    iCantidadMult = iCantidadMult - iCuatro;
            //                }
            //                indCuatro += 1;
            //            }
            //        }

            //    }
            //    //if (nListaNuevo4x1.Count == 0) return;

            //    foreach (CPedidoDetalle item in nLista4x1)
            //    {
            //        int IdProducto = item.IdProducto;
            //        int iCant = item.Cantidad;
            //        bool FlagMuestra = item.FlagMuestra;
            //        decimal dSuma = nListaNuevo4x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);


            //        decimal PrecioUni = nListaNuevo4x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PrecioUnitario);


            //        decimal pVenta =  Math.Round(dSuma / iCant, 2); // (dSuma / iCant); 
            //        decimal PrecioVenta4x1 =  Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2); 
            //        decimal ValorVenta4x1 =   Math.Round(PrecioVenta4x1 * iCant, 2); // Math.Round(pVenta * iCant, 2); 

            //        mListaPedidoDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
            //            s =>
            //            {
            //                //s.PrecioUnitario = PrecioUni;
            //                s.PrecioVenta = PrecioVenta4x1;
            //                s.ValorVenta = ValorVenta4x1;
            //            }
            //       );
            //    }

            //    if (PorDesc4x1 > 0)
            //    {
            //        //if (MessageBox.Show(PorDesc4x1.ToString(), "My Application", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            //    }
            //}
            #endregion

            #region "6x3 ecm"
            //if (nLista6x3.Count != 0)
            //{
            //    nLista6x3 = nLista6x3.OrderByDescending(x => x.PrecioUnitario).ToList();

            //    int iCount = 0;
            //    List<CPedidoDetalle> nListaNuevo6x3 = new List<CPedidoDetalle>();
            //    decimal PorDesc6x3 = 0;

            //    foreach (CPedidoDetalle item in nLista6x3)
            //    {
            //        int cant = item.Cantidad;
            //        int IdProducto = item.IdProducto;
            //        decimal PrecioUni = item.PrecioUnitario;
            //        decimal PorcentajeDesc = item.PorcentajeDescuento;
            //        bool FlagMuestra = item.FlagMuestra;

            //        decimal Con_Porcentaje_PrecioUni = Math.Round(PrecioUni * ((100 - PorcentajeDesc) / 100), 2);
            //        if (PorcentajeDesc > 0)
            //        {
            //            PorDesc6x3 += (PrecioUni - Con_Porcentaje_PrecioUni);
            //        }
            //        PrecioUni = Con_Porcentaje_PrecioUni;

            //        int iCantidadMult = cant;
            //        int iSeis = 6;
            //        int indSeis = 1;
            //        if (cant >= iSeis)
            //        {
            //            for (int i2 = 0; i2 <= cant - 1; i2++)
            //            {
            //                CPedidoDetalle RegItem = new CPedidoDetalle();
            //                iCount += 1;

            //                RegItem.IdProducto = IdProducto;
            //                RegItem.Item = iCount;
            //                RegItem.PrecioUnitario = PrecioUni;
            //                RegItem.FlagMuestra = FlagMuestra;

            //                if (iCantidadMult >= iSeis)
            //                {
            //                    if (indSeis % 4 == 0 || indSeis % 5 == 0 || indSeis % 6 == 0)
            //                    {
            //                        RegItem.PrecioUnitario = 0;
            //                    }
            //                }

            //                nListaNuevo6x3.Add(RegItem);

            //                if (indSeis == iSeis)
            //                {
            //                    indSeis = 0;
            //                    iCantidadMult = iCantidadMult - iSeis;
            //                }
            //                indSeis += 1;
            //            }
            //        }

            //    }
            //    //if (nListaNuevo6x3.Count == 0) return;

            //    foreach (CPedidoDetalle item in nLista6x3)
            //    {
            //        int IdProducto = item.IdProducto;
            //        int iCant = item.Cantidad;
            //        bool FlagMuestra = item.FlagMuestra;
            //        decimal dSuma = nListaNuevo6x3.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);


            //        decimal PrecioUni = nListaNuevo6x3.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PrecioUnitario);


            //        decimal pVenta =   Math.Round(dSuma / iCant, 2); // (dSuma / iCant); 
            //        decimal PrecioVenta4x1 =  Math.Round(dSuma / iCant, 2);  // Math.Round(pVenta, 2); 
            //        decimal ValorVenta4x1 =  Math.Round(PrecioVenta4x1 * iCant, 2); // Math.Round(pVenta * iCant, 2); 

            //        mListaPedidoDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
            //            s => {
            //                //s.PrecioUnitario = PrecioUni;
            //                s.PrecioVenta = PrecioVenta4x1;
            //                s.ValorVenta = ValorVenta4x1;
            //            }
            //       );
            //    }

            //    if (PorDesc6x3 > 0)
            //    {
            //        //if (MessageBox.Show(PorDesc6x3.ToString(), "My Application", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            //    }
            //}
            #endregion

            #region "2DO_50 ecm"
            //if (nLista2DO_50.Count != 0)
            //{
            //   nLista2DO_50 = nLista2DO_50.OrderByDescending(x => x.PrecioUnitario).ToList();

            //    int iCount = 0;
            //    List<CPedidoDetalle> nListaNuevo2DO_50 = new List<CPedidoDetalle>();
            //    decimal PorDesc2DO_50 = 0;

            //    foreach (CPedidoDetalle item in nLista2DO_50)
            //    {
            //        int cant = item.Cantidad;
            //        int IdProducto = item.IdProducto;
            //        decimal PrecioUni = item.PrecioUnitario;
            //        decimal PorcentajeDesc = item.PorcentajeDescuento;
            //        bool FlagMuestra = item.FlagMuestra;

            //        decimal Con_Porcentaje_PrecioUni = Math.Round(PrecioUni * ((100 - PorcentajeDesc) / 100), 2);
            //        if (PorcentajeDesc > 0)
            //        {
            //            PorDesc2DO_50 += (PrecioUni - Con_Porcentaje_PrecioUni);
            //        }
            //        PrecioUni = Con_Porcentaje_PrecioUni;

            //        for (int i2 = 0; i2 <= cant - 1; i2++)
            //        {
            //            CPedidoDetalle RegItem = new CPedidoDetalle();

            //            RegItem.IdProducto = IdProducto;
            //            RegItem.Item = iCount + 1;
            //            RegItem.PrecioUnitario = PrecioUni;
            //            RegItem.FlagMuestra = FlagMuestra;
            //            if (iCount % 2 != 0)
            //            {
            //                RegItem.PrecioUnitario = Math.Round((PrecioUni/2), 2);
            //            }

            //            nListaNuevo2DO_50.Add(RegItem);
            //            iCount += 1;
            //        }
            //    }
            //    //if (nListaNuevo2DO_50.Count == 0) return;

            //    foreach (CPedidoDetalle item in nLista2DO_50)
            //    {
            //        int IdProducto = item.IdProducto;
            //        int iCant = item.Cantidad;
            //        bool FlagMuestra = item.FlagMuestra;
            //        decimal dSuma = nListaNuevo2DO_50.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);


            //        decimal PrecioUni = nListaNuevo2DO_50.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PrecioUnitario);


            //        decimal pVenta = Math.Round(dSuma / iCant, 2); // (dSuma / iCant); 
            //        decimal PrecioVenta2DO_50 =  Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2); 
            //        decimal ValorVenta2DO_50 =  Math.Round(PrecioVenta2DO_50 * iCant, 2); // Math.Round(pVenta * iCant, 2); 

            //        mListaPedidoDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
            //            s => {
            //                //s.PrecioUnitario = PrecioUni;
            //                s.PrecioVenta = PrecioVenta2DO_50;
            //                s.ValorVenta = ValorVenta2DO_50;
            //            }
            //       );
            //    }

            //    if (PorDesc2DO_50 > 0)
            //    {
            //        //if (MessageBox.Show(PorDesc2DO_50.ToString(), "My Application", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            //    }
            //}
            #endregion
            #endregion

            return;

            #endregion

            int PosicionX = 0;
            int Cantidad = 0;
            int intTotalCantidad = 0;
            Decimal PrecioUnitario = 0;
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


            //if (mListaDocumentoVentaDetalleOrigen.Count > 0)

            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                //PrecioUnitario = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                Cantidad = item.Cantidad;
                PrecioUnitario = item.PrecioUnitario;
                PrecioVenta = item.PrecioVenta;//add 121115

                if (item.DescPromocion == "2x1")
                {
                    //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                    //PrecioUnitario = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));
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
                    //Precio2x1 = Precio2x1 + Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));  
                }

                else if (item.DescPromocion == "3x2")
                {
                    Total3x2SinPromo = Total3x2SinPromo + (Cantidad * PrecioUnitario);
                    FlagImpresionRus = false;
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
                    TotalSinPromocion += item.ValorVenta;
                }

                intTotalCantidad = intTotalCantidad + item.Cantidad;

                PosicionX = PosicionX + 1;
            }


            List<DocumentoVentaDetalleBE> lst_DocumentoVentaDetallePromo = new List<DocumentoVentaDetalleBE>();
            List<DocumentoVentaDetalleBE> lst_DocumentoVentaDetallePromo3x2 = new List<DocumentoVentaDetalleBE>();
            List<DocumentoVentaDetalleBE> lst_DocumentoVentaDetallePromo3x1 = new List<DocumentoVentaDetalleBE>();
            List<DocumentoVentaDetalleBE> lst_DocumentoVentaDetallePromo4x1 = new List<DocumentoVentaDetalleBE>();
            List<DocumentoVentaDetalleBE> lst_DocumentoVentaDetallePromo6x3 = new List<DocumentoVentaDetalleBE>();
            Decimal PrecioUnitarioPromo = 0;
            Decimal PrecioVentaPromo = 0;
            String PromocionCadena = "";
            int CantidadImpar = 0;
            int PosicionY = 0;
            int Itemk = 1;
            for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
            {
                PromocionCadena = Convert.ToString(gvDocumentoVentaDetalle.GetRowCellValue(i, (gvDocumentoVentaDetalle.Columns["DescPromocion"])));

                CantidadImpar = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(i, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                PrecioUnitarioPromo = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(i, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));
                PrecioVentaPromo = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(i, (gvDocumentoVentaDetalle.Columns["PrecioVenta"])));//add 121115


                CDocumentoVentaDetalle item = (CDocumentoVentaDetalle)gvDocumentoVentaDetalle.GetRow(i);//add 151119

                int Item2x1 = 1;
                int Item3x2 = 1;
                int Item3x1 = 1;
                int Item4x1 = 1;


                if (PromocionCadena == "2x1")
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                        DocumentoVentaDetalleBE ObjE_Detalle = new DocumentoVentaDetalleBE();
                        ObjE_Detalle.Cantidad = 1;
                        //ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        ObjE_Detalle.IdProducto = item.IdProducto;
                        ObjE_Detalle.CodigoProveedor = item.CodigoProveedor;
                        ObjE_Detalle.NombreProducto = item.NombreProducto;
                        ObjE_Detalle.Abreviatura = item.Abreviatura;
                        ObjE_Detalle.PrecioUnitario = item.PrecioUnitario;
                        ObjE_Detalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        ObjE_Detalle.PrecioVenta = item.PrecioVenta;
                        ObjE_Detalle.ValorVenta = item.PrecioVenta;//item.ValorVenta;
                        ObjE_Detalle.IdPromocion = item.IdPromocion;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        //ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = false;
                        lst_DocumentoVentaDetallePromo.Add(ObjE_Detalle);
                    }
                }

                else if (PromocionCadena == "3x2")
                {
                    for (int j = 1; j <= CantidadImpar; j++)
                    {
                        DocumentoVentaDetalleBE ObjE_Detalle = new DocumentoVentaDetalleBE();

                        ObjE_Detalle.Item = Itemk;
                        ObjE_Detalle.Cantidad = 1;

                        ObjE_Detalle.IdProducto = item.IdProducto;
                        ObjE_Detalle.CodigoProveedor = item.CodigoProveedor;
                        ObjE_Detalle.NombreProducto = item.NombreProducto;
                        ObjE_Detalle.Abreviatura = item.Abreviatura;
                        ObjE_Detalle.PrecioUnitario = item.PrecioUnitario;
                        ObjE_Detalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        ObjE_Detalle.PrecioVenta = item.PrecioVenta;
                        ObjE_Detalle.ValorVenta = item.PrecioVenta;//item.ValorVenta;
                        ObjE_Detalle.IdPromocion = item.IdPromocion;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        //ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = false;

                        lst_DocumentoVentaDetallePromo3x2.Add(ObjE_Detalle);

                        if (Itemk == 3) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
                    }
                }

                else if (PromocionCadena == "3x1")
                {
                    for (int j = 1; j <= CantidadImpar; j++)
                    {
                        DocumentoVentaDetalleBE ObjE_Detalle = new DocumentoVentaDetalleBE();

                        ObjE_Detalle.Item = Item3x1;
                        ObjE_Detalle.Cantidad = 1;

                        ObjE_Detalle.IdProducto = item.IdProducto;
                        ObjE_Detalle.CodigoProveedor = item.CodigoProveedor;
                        ObjE_Detalle.NombreProducto = item.NombreProducto;
                        ObjE_Detalle.Abreviatura = item.Abreviatura;
                        ObjE_Detalle.PrecioUnitario = item.PrecioUnitario;
                        ObjE_Detalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        ObjE_Detalle.PrecioVenta = item.PrecioVenta;
                        ObjE_Detalle.ValorVenta = item.PrecioVenta;//item.ValorVenta;
                        ObjE_Detalle.IdPromocion = item.IdPromocion;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        //ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = false;

                        lst_DocumentoVentaDetallePromo3x1.Add(ObjE_Detalle);

                        if (Item3x1 == 3) Item3x1 = 1;
                        else
                            Item3x1 = Item3x1 + 1;
                    }
                }

                else if (PromocionCadena == "4x1")
                {
                    for (int j = 1; j <= CantidadImpar; j++)
                    {
                        DocumentoVentaDetalleBE ObjE_Detalle = new DocumentoVentaDetalleBE();

                        ObjE_Detalle.Item = Item4x1;
                        ObjE_Detalle.Cantidad = 1;

                        ObjE_Detalle.IdProducto = item.IdProducto;
                        ObjE_Detalle.CodigoProveedor = item.CodigoProveedor;
                        ObjE_Detalle.NombreProducto = item.NombreProducto;
                        ObjE_Detalle.Abreviatura = item.Abreviatura;
                        ObjE_Detalle.PrecioUnitario = item.PrecioUnitario;
                        ObjE_Detalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        ObjE_Detalle.PrecioVenta = item.PrecioVenta;
                        ObjE_Detalle.ValorVenta = item.PrecioVenta;//item.ValorVenta;
                        ObjE_Detalle.IdPromocion = item.IdPromocion;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        //ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = false;

                        lst_DocumentoVentaDetallePromo4x1.Add(ObjE_Detalle);

                        if (Item4x1 == 4) Item4x1 = 1;
                        else
                            Item4x1 = Item4x1 + 1;
                    }
                }

                else if (PromocionCadena == "6x3")
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                        DocumentoVentaDetalleBE ObjE_Detalle = new DocumentoVentaDetalleBE();
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        lst_DocumentoVentaDetallePromo.Add(ObjE_Detalle);
                    }
                }

                PosicionY = PosicionY + 1;
            }

            //Agregar a Lista Pública
            mListaDocumentoVentaDetallePromo3x2 = lst_DocumentoVentaDetallePromo3x2;
            mListaDocumentoVentaDetallePromo3x1 = lst_DocumentoVentaDetallePromo3x1;
            mListaDocumentoVentaDetallePromo4x1 = lst_DocumentoVentaDetallePromo4x1;


            //Recorrido de la lista sumar 2x1
            if (lst_DocumentoVentaDetallePromo.Count > 0)
            {
                for (int i = 0; i < lst_DocumentoVentaDetallePromo.Count; i += 2)
                {
                    TotalPrecio2x1 += lst_DocumentoVentaDetallePromo[i].PrecioUnitario;
                }
            }

            //Recorrido de la lista sumar 3x2
            if (lst_DocumentoVentaDetallePromo3x2.Count > 0)
            {
                for (int i = 2; i < lst_DocumentoVentaDetallePromo3x2.Count; i = i + 3)
                {
                    TotalPrecio3x2 += lst_DocumentoVentaDetallePromo3x2[i].PrecioUnitario; //Precio Gratis -Descto
                    //gvDocumentoVentaDetalle.SetRowCellValue(0, gvDocumentoVentaDetalle.Columns["Observacion"], 1);
                }
            }

            //Recorrido de la lista sumar 3x1
            if (lst_DocumentoVentaDetallePromo3x1.Count > 0)
            {
                for (int i = 2; i < lst_DocumentoVentaDetallePromo3x1.Count; i = i + 3)
                {
                    TotalPrecio3x1 += lst_DocumentoVentaDetallePromo3x1[i].PrecioUnitario; //Precio Gratis -Descto
                    //gvDocumentoVentaDetalle.SetRowCellValue(0, gvDocumentoVentaDetalle.Columns["Observacion"], 1);
                }
            }

            //Recorrido de la lista sumar 4x1
            if (lst_DocumentoVentaDetallePromo4x1.Count > 0)
            {
                for (int i = 3; i < lst_DocumentoVentaDetallePromo4x1.Count; i = i + 4)
                {
                    TotalPrecio4x1 += lst_DocumentoVentaDetallePromo4x1[i].PrecioUnitario; //Precio Gratis -Descto
                    //gvDocumentoVentaDetalle.SetRowCellValue(0, gvDocumentoVentaDetalle.Columns["Observacion"], 1);
                }
            }





            //Recorrido de la lista sumar 6x3
            if (lst_DocumentoVentaDetallePromo6x3.Count > 0)
            {
                for (int i = 0; i < lst_DocumentoVentaDetallePromo6x3.Count; i += 2)
                {
                    TotalPrecio6x3 += lst_DocumentoVentaDetallePromo6x3[i].PrecioUnitario; //Precio Gratis -Descto
                }
            }

            txtTotal2x1.EditValue = TotalPrecio2x1 + Total3x2SinPromo + TotalPrecio6x3 + Total3x1SinPromo + Total4x1SinPromo; //TotalPrecio3x2
            ///txtTotalDscto2x1.EditValue = (Total2x1SinPromo - TotalPrecio2x1) + TotalPrecio3x2Dscto;// versión 2.0
            txtTotalDscto2x1.EditValue = (Total2x1SinPromo - TotalPrecio2x1) + TotalPrecio3x2 + (Total6x3SinPromo - TotalPrecio6x3) + TotalPrecio3x1 + TotalPrecio4x1;// versión 2.0
            //txtTotal2x1.EditValue = TotalPrecio2x1;
            //txtTotalDscto2x1.EditValue = Total2x1SinPromo - TotalPrecio2x1;


            ////Calcular el Total General con Descuento
            Decimal deTotal = 0;
            Decimal deSubTotal = 0;
            deTotal = TotalSinPromocion + TotalPrecio2x1 + (Total3x2SinPromo - TotalPrecio3x2) + TotalPrecio6x3 + (Total3x1SinPromo - TotalPrecio3x1) + (Total4x1SinPromo - TotalPrecio4x1);
            deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

            txtTotal.EditValue = Math.Round(deTotal, 2);
            txtSubTotal.EditValue = deSubTotal;
            txtImpuesto.EditValue = Math.Round((deTotal - deSubTotal), 2);
            txtTotalBruto.EditValue = Math.Round((TotalSinPromocion + Total2x1SinPromo + Total3x2SinPromo + Total6x3SinPromo + Total3x1SinPromo + Total4x1SinPromo), 2);
            txtTotalCantidad.EditValue = intTotalCantidad;

            CalculaTotalPromocion2x1_Total();
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

            List<CDocumentoVentaDetalle> lst_DocumentoVentaDetallePromo2x1 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_DocumentoVentaDetallePromo2x1_Impar = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_DocumentoVentaDetallePromo3x2 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_DocumentoVentaDetallePromo3x1 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_DocumentoVentaDetallePromo4x1 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_DocumentoVentaDetalleSinPromo = new List<CDocumentoVentaDetalle>();

            #region "Promociones"
            int nItem = 1;
            bool bPromo3x2 = false;
            bool bPromo3x1 = false;
            bool bPromo4x1 = false;

            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                #region"2x1"
                if (item.DescPromocion == "2x1")
                {
                    if (item.Cantidad % 2 == 0)
                    {
                        #region "Par"
                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoDetalle.Item = nItem;
                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                        objE_DocumentoDetalle.Cantidad = item.Cantidad;
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
                        lst_DocumentoVentaDetallePromo2x1.Add(objE_DocumentoDetalle);
                        #endregion
                    }
                    else
                    {
                        int Canten = item.Cantidad - 1;
                        if (Canten > 0)
                        {
                            #region "Par"
                            CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                            objE_DocumentoDetalle.Item = nItem;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = Canten;
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
                            lst_DocumentoVentaDetallePromo2x1.Add(objE_DocumentoDetalle);
                            #endregion

                            #region "Impar"
                            //add 1
                            CDocumentoVentaDetalle objE_DocumentoDetalle2 = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle2.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                            objE_DocumentoDetalle2.Item = nItem;
                            objE_DocumentoDetalle2.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle2.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle2.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle2.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle2.Cantidad = 1;
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
                            lst_DocumentoVentaDetallePromo2x1_Impar.Add(objE_DocumentoDetalle2);
                            #endregion
                        }
                        else
                        {
                            #region "Impar"
                            CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                            objE_DocumentoDetalle.Item = nItem;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = 1;
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
                            lst_DocumentoVentaDetallePromo2x1_Impar.Add(objE_DocumentoDetalle);
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
                    //int TotalRegistroP = mListaDocumentoVentaDetallePromo3x2.Count();

                    foreach (var itemp in mListaDocumentoVentaDetallePromo3x2)
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

                            //mListaDocumentoVentaDetallePromo3x2[RegistroP].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            //mListaDocumentoVentaDetallePromo3x2[RegistroP].PrecioVenta = Math.Round(Math.Round(itemp.PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            //mListaDocumentoVentaDetallePromo3x2[RegistroP].ValorVenta = itemp.Cantidad * itemp.PrecioVenta;

                            mListaDocumentoVentaDetallePromo3x2[RegistroP].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            mListaDocumentoVentaDetallePromo3x2[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x2[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            mListaDocumentoVentaDetallePromo3x2[RegistroP].ValorVenta = mListaDocumentoVentaDetallePromo3x2[RegistroP].Cantidad * mListaDocumentoVentaDetallePromo3x2[RegistroP].PrecioVenta;

                            mListaDocumentoVentaDetallePromo3x2[RegistroP - 1].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            mListaDocumentoVentaDetallePromo3x2[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x2[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            mListaDocumentoVentaDetallePromo3x2[RegistroP - 1].ValorVenta = mListaDocumentoVentaDetallePromo3x2[RegistroP - 1].Cantidad * mListaDocumentoVentaDetallePromo3x2[RegistroP - 1].PrecioVenta;

                            mListaDocumentoVentaDetallePromo3x2[RegistroP - 2].PorcentajeDescuento = DescuentoPromo3x2 * 100;
                            mListaDocumentoVentaDetallePromo3x2[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x2[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo3x2), 2);
                            mListaDocumentoVentaDetallePromo3x2[RegistroP - 2].ValorVenta = mListaDocumentoVentaDetallePromo3x2[RegistroP - 2].Cantidad * mListaDocumentoVentaDetallePromo3x2[RegistroP - 2].PrecioVenta;

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
                    int TotalRegP = mListaDocumentoVentaDetallePromo3x1.Count();

                    foreach (var itemp in mListaDocumentoVentaDetallePromo3x1)
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

                                mListaDocumentoVentaDetallePromo3x1[RegistroP].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                                mListaDocumentoVentaDetallePromo3x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                                mListaDocumentoVentaDetallePromo3x1[RegistroP].ValorVenta = mListaDocumentoVentaDetallePromo3x1[RegistroP].Cantidad * mListaDocumentoVentaDetallePromo3x1[RegistroP].PrecioVenta;

                                mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                                mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                                mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].ValorVenta = mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].Cantidad * mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PrecioVenta;

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

                            mListaDocumentoVentaDetallePromo3x1[RegistroP].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                            mListaDocumentoVentaDetallePromo3x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                            mListaDocumentoVentaDetallePromo3x1[RegistroP].ValorVenta = mListaDocumentoVentaDetallePromo3x1[RegistroP].Cantidad * mListaDocumentoVentaDetallePromo3x1[RegistroP].PrecioVenta;

                            mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                            mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                            mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].ValorVenta = mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].Cantidad * mListaDocumentoVentaDetallePromo3x1[RegistroP - 1].PrecioVenta;

                            mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo3x1 * 100;
                            mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo3x1), 2);
                            mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].ValorVenta = mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].Cantidad * mListaDocumentoVentaDetallePromo3x1[RegistroP - 2].PrecioVenta;

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
                    int TotalRegP = mListaDocumentoVentaDetallePromo4x1.Count();

                    foreach (var itemp in mListaDocumentoVentaDetallePromo4x1)
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

                                mListaDocumentoVentaDetallePromo4x1[RegistroP].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaDocumentoVentaDetallePromo4x1[RegistroP].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioVenta;

                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioVenta;

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

                                mListaDocumentoVentaDetallePromo4x1[RegistroP].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaDocumentoVentaDetallePromo4x1[RegistroP].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioVenta;

                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioVenta;

                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                                mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioVenta;

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

                            mListaDocumentoVentaDetallePromo4x1[RegistroP].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaDocumentoVentaDetallePromo4x1[RegistroP].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP].PrecioVenta;

                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 1].PrecioVenta;

                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 2].PrecioVenta;

                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PorcentajeDescuento = DescuentoPromo4x1 * 100;
                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioVenta = Math.Round(Math.Round(mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioUnitario, 2) * (1 - DescuentoPromo4x1), 2);
                            mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].ValorVenta = mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].Cantidad * mListaDocumentoVentaDetallePromo4x1[RegistroP - 3].PrecioVenta;


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
                    CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
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
                    //mListaDocumentoVentaDetalleOrigenPromo.Add(objE_DocumentoDetalle);
                    lst_DocumentoVentaDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            //Agregar Descuentos
            #region "Agregar descuentos"

            int Registro = 1;
            int TotalRegistro = lst_DocumentoVentaDetallePromo2x1_Impar.Count;//  mListaDocumentoVentaDetalleOrigen.Count;
            decimal Valor1 = 0;
            decimal Valor2 = 0;
            decimal Mayor = 0;
            decimal Descuento = 0;
            foreach (var item in lst_DocumentoVentaDetallePromo2x1_Impar)//mListaDocumentoVentaDetalleOrigen)
            {
                if (Registro % 2 != 0)
                {
                    if (Registro < TotalRegistro)
                    {
                        Valor1 = lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].PrecioVenta;
                        Valor2 = lst_DocumentoVentaDetallePromo2x1_Impar[Registro].PrecioVenta;
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
                    lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].PorcentajeDescuento = Descuento;
                    lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].PrecioVenta = Math.Round(Math.Round(item.PrecioUnitario, 2) * ((100 - Descuento) / 100), 2);
                    lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }
                else
                {
                    Descuento = 0;
                    lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].PorcentajeDescuento = Descuento;
                    lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].PrecioVenta = Math.Round(item.PrecioUnitario, 2);
                    lst_DocumentoVentaDetallePromo2x1_Impar[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }

                Registro = Registro + 1;
            }
            #endregion

            mListaDocumentoVentaDetalleOrigen2 = new List<CDocumentoVentaDetalle>();
            nItem = 1;

            #region "Agregar 2x1 Par"
            //Agregar Promociones a la lista
            foreach (CDocumentoVentaDetalle item in lst_DocumentoVentaDetallePromo2x1)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
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
                mListaDocumentoVentaDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 2x1 Impar"
            foreach (CDocumentoVentaDetalle item in lst_DocumentoVentaDetallePromo2x1_Impar)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;// item.Item;
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
                mListaDocumentoVentaDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x2"
            foreach (DocumentoVentaDetalleBE item in mListaDocumentoVentaDetallePromo3x2)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //objE_DocumentoDetalle.ValorVenta =item.ValorVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = 0;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x1"
            foreach (DocumentoVentaDetalleBE item in mListaDocumentoVentaDetallePromo3x1)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //objE_DocumentoDetalle.ValorVenta =item.ValorVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = 0;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 4x1"
            foreach (DocumentoVentaDetalleBE item in mListaDocumentoVentaDetallePromo4x1)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;//item.Item;
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //objE_DocumentoDetalle.ValorVenta =item.ValorVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = 0;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            //Agregar Sin Promoción 
            #region "Agregar códigos sin promoción"
            foreach (CDocumentoVentaDetalle item in lst_DocumentoVentaDetalleSinPromo)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                objE_DocumentoDetalle.Item = nItem;// item.Item;
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
                mListaDocumentoVentaDetalleOrigen2.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion


            ////bsListado.DataSource = mListaDocumentoVentaDetalleOrigenPromo;
            //bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            //gcDocumentoVentaDetalle.DataSource = bsListado;
            //gcDocumentoVentaDetalle.RefreshDataSource();

            //CalculaTotales();
            ////CalculaTotalesPromo();


            #region "Calcular Total"
            decimal deImpuesto = 0;
            decimal deValorVenta = 0;
            decimal deSubTotal = 0;
            decimal deTotal = 0;
            int intTotalCantidad = 0;
            //decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            if (mListaDocumentoVentaDetalleOrigen2.Count > 0)
            {
                foreach (var item in mListaDocumentoVentaDetalleOrigen2)
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

            #endregion
        }





        private void CalculaTotalPromocion2x1_unoAuno()
        {
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;
            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;

            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo2x1 = new List<CDocumentoVentaDetalle>();

            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo3x2 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_PedidoDetalleSinPromo = new List<CDocumentoVentaDetalle>();

            #region "Promociones"
            int nItem = 1;
            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                #region"2x1"
                if (item.DescPromocion == "2x1")
                {
                    for (int i = 1; i <= item.Cantidad; i++)
                    {
                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
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
                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
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
                    CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
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
                    //mListaDocumentoVentaDetalleOrigenPromo.Add(objE_DocumentoDetalle);
                    lst_PedidoDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();

            //Agregar Promociones a la lista
            foreach (CDocumentoVentaDetalle item in lst_PedidoDetallePromo2x1)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
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
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            //Agregar Descuentos
            #region "Agregar descuentos"
            int Registro = 1;
            int TotalRegistro = mListaDocumentoVentaDetalleOrigen.Count;
            decimal Valor1 = 0;
            decimal Valor2 = 0;
            decimal Mayor = 0;
            decimal Descuento = 0;
            foreach (var item in mListaDocumentoVentaDetalleOrigen)
            {
                if (Registro % 2 != 0) //1,3
                {
                    if (Registro < TotalRegistro)
                    {
                        Valor1 = mListaDocumentoVentaDetalleOrigen[Registro - 1].PrecioVenta;
                        Valor2 = mListaDocumentoVentaDetalleOrigen[Registro].PrecioVenta;
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
                    mListaDocumentoVentaDetalleOrigen[Registro - 1].PorcentajeDescuento = Descuento;
                    mListaDocumentoVentaDetalleOrigen[Registro - 1].PrecioVenta = Math.Round(Math.Round(item.PrecioUnitario, 2) * ((100 - Descuento) / 100), 2);
                    mListaDocumentoVentaDetalleOrigen[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }
                else
                {
                    Descuento = 0;
                    mListaDocumentoVentaDetalleOrigen[Registro - 1].PorcentajeDescuento = Descuento;
                    mListaDocumentoVentaDetalleOrigen[Registro - 1].PrecioVenta = Math.Round(item.PrecioUnitario, 2);
                    mListaDocumentoVentaDetalleOrigen[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }


                Registro = Registro + 1;
            }
            #endregion


            //Agregar Sin Promoción 
            #region "Agregar códigos sin promoción"
            foreach (CDocumentoVentaDetalle item in lst_PedidoDetalleSinPromo)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
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
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }
            #endregion


            //bsListado.DataSource = mListaDocumentoVentaDetalleOrigenPromo;
            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoVentaDetalle.DataSource = bsListado;
            gcDocumentoVentaDetalle.RefreshDataSource();


            #region "Calcular Total"
            decimal deImpuesto = 0;
            decimal deValorVenta = 0;
            decimal deSubTotal = 0;
            decimal deTotal = 0;
            int intTotalCantidad = 0;
            //decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            {
                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    intTotalCantidad = intTotalCantidad + item.Cantidad;
                    deValorVenta = item.ValorVenta;
                    deTotal = deTotal + deValorVenta;
                }

                txtTotalBruto.EditValue = 0;//add may 25
                //if (mListaPromocionVale.Count > 0)//add 250516
                //{
                //    CalculaTotalesVale(intTotalCantidad, deTotal);
                //    return;
                //}

                deTotal = Math.Round(deTotal, 2);
                deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                txtTotal.EditValue = deTotal;
                txtSubTotal.EditValue = deSubTotal;
                txtImpuesto.EditValue = deImpuesto;
                txtTotalCantidad.EditValue = intTotalCantidad;

                txtTotalResumen.EditValue = deTotal;
                txtResta.EditValue = deTotal;

                //Calcula las referencias
                if (Convert.ToDecimal(txtTotalDiferencia.EditValue) > 0)
                {
                    txtDifrencia.EditValue = Convert.ToDecimal(txtTotal.EditValue) - Convert.ToDecimal(txtTotalDiferencia.EditValue);
                }
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

        private void CalculaTotalPromocion2x1_250319()
        {
            int PosicionX = 0;
            int Cantidad = 0;
            int intTotalCantidad = 0;
            Decimal PrecioUnitario = 0;
            Decimal PrecioVenta = 0;
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;

            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;

            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;


            //if (mListaDocumentoVentaDetalleOrigen.Count > 0)

            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                //PrecioUnitario = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                Cantidad = item.Cantidad;
                PrecioUnitario = item.PrecioUnitario;
                PrecioVenta = item.PrecioVenta;//add 121115

                if (item.DescPromocion == "2x1")
                {
                    //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                    //PrecioUnitario = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));
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
                    //Precio2x1 = Precio2x1 + Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));  
                }
                else if (item.DescPromocion == "3x2")
                {
                    Total3x2SinPromo += (Cantidad * PrecioUnitario);
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
                    TotalSinPromocion += item.ValorVenta;
                }

                intTotalCantidad = intTotalCantidad + item.Cantidad;

                PosicionX = PosicionX + 1;
            }

            //Recorrido del codigo Cantidad Impar
            List<PedidoDetalleBE> lst_PedidoDetallePromo = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo6x3 = new List<PedidoDetalleBE>();
            Decimal PrecioUnitarioPromo = 0;
            Decimal PrecioVentaPromo = 0;
            //int IdPromocionCadena = 0;
            String PromocionCadena = "";
            int CantidadImpar = 0;
            int PosicionY = 0;
            for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
            {
                //IdPromocionCadena = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(i, (gvDocumentoVentaDetalle.Columns["IdPromocion"])));
                PromocionCadena = Convert.ToString(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["DescPromocion"])));
                CantidadImpar = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                PrecioUnitarioPromo = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                if (PromocionCadena == "2x1")
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

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

                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;
                        ObjE_Detalle.PrecioVenta = PrecioVentaPromo;
                        lst_PedidoDetallePromo3x2.Add(ObjE_Detalle);
                    }
                }
                else if (PromocionCadena == "6x3")
                {
                    if (CantidadImpar % 2 != 0)
                    {
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

            //Recorrido de la lista sumar 3x2
            if (lst_PedidoDetallePromo3x2.Count > 0)
            {
                for (int i = 2; i < lst_PedidoDetallePromo3x2.Count; i = i + 3)
                {
                    TotalPrecio3x2Dscto += lst_PedidoDetallePromo3x2[i].PrecioUnitario; //Precio Gratis -Descto
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

            txtTotal2x1.EditValue = TotalPrecio2x1 + Total3x2SinPromo + TotalPrecio6x3; //TotalPrecio3x2
            txtTotalDscto2x1.EditValue = (Total2x1SinPromo - TotalPrecio2x1) + TotalPrecio3x2Dscto + (Total6x3SinPromo - TotalPrecio6x3);// versión 2.0

            //txtTotal2x1.EditValue = TotalPrecio2x1;
            //txtTotalDscto2x1.EditValue = Total2x1SinPromo - TotalPrecio2x1;


            ////Calcular el Total General con Descuento
            Decimal deTotal = 0;
            Decimal deSubTotal = 0;
            deTotal = Math.Round(TotalSinPromocion + TotalPrecio2x1 + (Total3x2SinPromo - TotalPrecio3x2Dscto) + TotalPrecio6x3, 2);
            //deTotal = TotalSinPromocion + TotalPrecio2x1;
            deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

            txtTotal.EditValue = Math.Round(deTotal, 2);
            txtSubTotal.EditValue = deSubTotal;
            txtImpuesto.EditValue = Math.Round((deTotal - deSubTotal), 2);
            txtTotalBruto.EditValue = Math.Round((TotalSinPromocion + Total2x1SinPromo + Total3x2SinPromo + Total6x3SinPromo), 2);
            //txtTotalBruto.EditValue = Math.Round((Total2x1SinPromo + TotalSinPromocion), 2);
            txtTotalCantidad.EditValue = intTotalCantidad;
        }

        private void CalculaTotalPromocion2x1_Back()
        {
            int PosicionX = 0;
            int Cantidad = 0;
            int intTotalCantidad = 0;
            Decimal PrecioUnitario = 0;
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalSinPromocion = 0;


            //if (mListaDocumentoVentaDetalleOrigen.Count > 0)

            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                //PrecioUnitario = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                Cantidad = item.Cantidad;
                PrecioUnitario = item.PrecioUnitario;

                if (item.IdPromocion == 1)
                {
                    //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                    //PrecioUnitario = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));
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
                    //Precio2x1 = Precio2x1 + Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionX, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));  
                }
                else //Producto sin Promoción
                {
                    TotalSinPromocion += item.ValorVenta;
                }

                intTotalCantidad = intTotalCantidad + item.Cantidad;

                PosicionX = PosicionX + 1;
            }

            //Recorrido del codigo Cantidad Impar
            List<PedidoDetalleBE> lst_PedidoDetallePromo = new List<PedidoDetalleBE>();
            Decimal PrecioUnitarioPromo = 0;
            int IdPromocionCadena = 0;
            int CantidadImpar = 0;
            int PosicionY = 0;
            for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
            {
                IdPromocionCadena = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(i, (gvDocumentoVentaDetalle.Columns["IdPromocion"])));
                CantidadImpar = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                PrecioUnitarioPromo = Convert.ToDecimal(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

                if (IdPromocionCadena == 1)
                {
                    if (CantidadImpar % 2 != 0)
                    {
                        //Cantidad = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["Cantidad"])));
                        //PrecioUnitarioPromo = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(PosicionY, (gvDocumentoVentaDetalle.Columns["PrecioUnitario"])));

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

        private void AsignarCodigoPromocion_151119()
        {
            //CargarProductoPromocionDosPorUno(); //Dos por uno 

            if (chkVale.Checked == false)//add 181115
            {
                //add 18 05 2015
                if (gvDocumentoVentaDetalle.RowCount > 0)
                {
                    //if (IdTipoCliente == Parametros.intTipClienteFinal)
                    //{
                    for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++) //Existe
                    {
                        int IdProductoLista = 0;
                        int row = gvDocumentoVentaDetalle.GetRowHandle(i);

                        IdProductoLista = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(row, (gvDocumentoVentaDetalle.Columns["IdProducto"])));

                        #region "2x1"
                        foreach (var item in mListaDescuentoPromocionDosPorUno)
                        {
                            if (item.IdProducto == IdProductoLista)
                            {
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], 1);
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "2x1");

                                //add para descuento = 0;
                                decimal decDescuento = 0;
                                decimal decPrecioVenta = 0;
                                decimal decValorVenta = 0;
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
                                gvDocumentoVentaDetalle.RefreshData();

                                FlagPromocion2x1 = true;
                            }
                        }
                        #endregion

                        #region "3x2"
                        foreach (var item in mListaDescuentoPromocion3x2) // SELECT directo
                        {
                            if (item.IdProducto == IdProductoLista)
                            {
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //3x2
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "3x2");
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
                                //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

                                //add para descuento = 0;
                                //decimal decDescuento = item.Descuento;
                                decimal decDescuento = 0;
                                decimal decPrecioVenta = 0;
                                decimal decValorVenta = 0;
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
                                gvDocumentoVentaDetalle.RefreshData();

                                FlagPromocion2x1 = true;

                            }
                        }
                        #endregion

                        #region "6x3"
                        foreach (var item in mListaDescuentoPromocion6x3) // SELECT directo
                        {
                            if (item.IdProducto == IdProductoLista)
                            {
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["IdPromocion"], item.IdPromocion2x1); //6x3
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["DescPromocion"], "6x3");
                                gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], item.PrecioCDSoles);//add 2605
                                //gvDocumentoVentaDetalle.SetRowCellValue(row, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"], item.Descuento);//add 121115

                                //add para descuento = 0;
                                //decimal decDescuento = item.Descuento;
                                decimal decDescuento = 0;
                                decimal decPrecioVenta = 0;
                                decimal decValorVenta = 0;
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);
                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                                gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);
                                gvDocumentoVentaDetalle.RefreshData();

                                FlagPromocion2x1 = true;

                            }
                        }
                        #endregion

                    }

                    if (mListaDescuentoPromocionDosPorUno.Count > 0 || mListaDescuentoPromocion3x2.Count > 0 || mListaDescuentoPromocion6x3.Count > 0 && FlagPromocion2x1 == true)//add2605
                    {
                        this.gvDocumentoVentaDetalle.Columns["IdPromocion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        this.gvDocumentoVentaDetalle.Columns["PrecioUnitario"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

                        //Asignar valor ordenado de Item
                        int PosicionX = 0;
                        foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
                        {
                            gvDocumentoVentaDetalle.SetRowCellValue(PosicionX, gvDocumentoVentaDetalle.Columns["Item"], PosicionX + 1);
                            PosicionX = PosicionX + 1;
                        }
                    }
                }
            }

        }

        private void chkVale_CheckedChanged(object sender, EventArgs e)
        {
            txtTotal_EditValueChanged(sender, e);
        }

        private void txtPIN_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtPIN.Text.Trim().Length > 0)
            //    {
            //        cboVendedor.EditValue = Convert.ToInt32(txtPIN.Text);
            //    }
            //}
        }

        private void eliminarpromocion2x1toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPromocion", null);
                    gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "DescPromocion", "");
                    gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);

                    int IdProducto = Convert.ToInt32(gvDocumentoVentaDetalle.GetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto"));

                    //Test de velociad por Hora
                    #region "Descuento Promocion Temporal"
                    decimal decPrecioVenta = 0;
                    decimal decValorVenta = 0;


                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), Parametros.intTiendaId, 0, IdProducto);
                    if (objE_PromocionTemporal != null)
                    {
                        //decimal decDescuentoBulto = 5;
                        decimal decDescuentoMoroso = 0;

                        if (bMoroso)
                        {
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", decDescuentoMoroso);
                            decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad").ToString());
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", decPrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", decValorVenta);
                        }
                        else
                        {
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", objE_PromocionTemporal.Descuento);
                            decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario").ToString()) * ((100 - objE_PromocionTemporal.Descuento) / 100), 2);
                            decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad").ToString());
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", decPrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", decValorVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagBultoCerrado", false); //add
                        }
                    }
                    #endregion


                    //gvDocumentoVentaDetalle.DeleteRow(gvDocumentoVentaDetalle.FocusedRowHandle);
                    gvDocumentoVentaDetalle.RefreshData();


                }

                CalculaTotales();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void establecerdescuentocerotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvDocumentoVentaDetalle.SelectedRowsCount; i++)
            {
                decimal decDescuento = 0;
                decimal decPrecioVenta = 0;
                decimal decValorVenta = 0;

                //decimal pven = 0;
                //decimal pven2 = 0;

                int row = gvDocumentoVentaDetalle.GetSelectedRows()[i];
                decDescuento = decimal.Parse((0).ToString());
                gvDocumentoVentaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);

                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                //pven = Math.Round(decPrecioVenta, 2);
                //pven2 = decimal.Round(decPrecioVenta, 2);

                //decValorVenta = Math.Round(pven2 * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString()), 2);
                decValorVenta = decPrecioVenta * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString());
                gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);


                //decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                //decValorVenta = Math.Round(Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(row, "Cantidad").ToString()), 2);
                //gvDocumentoVentaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                //gvDocumentoVentaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);

            }

            gvDocumentoVentaDetalle.RefreshData();

            CalculaTotales();

        }

        private void btnCargarVale_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("Debido al cambio de políticas. El vale se aplicará al momento del cobro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            XtraMessageBox.Show("No se puede aplicar por este módulo, realizar un PEDIDO para aplicar el vale. Consulte con su administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //CargarPromocionVale();
            //lblMensaje.Text = "Vale válido si cumple las condiciones.";

        }

        private void btnEliminarVale_Click(object sender, EventArgs e)
        {
            EliminarVale();
        }

        private void txtIngresa_Click(object sender, EventArgs e)
        {
            //txtIngresa.SelectAll();
        }

        private void utilizarprecioucayalitoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDocumentoVentaDetalle.RowCount > 0)
                {
                    int IdProductoP = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdProducto").ToString());

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
                            Descuento = decimal.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PorcentajeDescuento").ToString());
                            Cantidad = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Cantidad").ToString());

                            PrecioUnitario = pProductoBE.PrecioCDSoles;
                            PrecioVenta = Convert.ToDecimal(PrecioUnitario) * ((100 - Convert.ToDecimal(Descuento)) / 100);
                            ValorVenta = Convert.ToDecimal(PrecioVenta) * Convert.ToDecimal(Cantidad);

                            int xposition = gvDocumentoVentaDetalle.FocusedRowHandle;
                            gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioUnitario", PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioVenta", PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(xposition, "ValorVenta", ValorVenta);

                            CalculaTotales();
                        }
                        else
                        {
                            Descuento = decimal.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PorcentajeDescuento").ToString());
                            Cantidad = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Cantidad").ToString());

                            PrecioUnitario = pProductoBE.PrecioCD;
                            PrecioVenta = Convert.ToDecimal(PrecioUnitario) * ((100 - Convert.ToDecimal(Descuento)) / 100);
                            ValorVenta = Convert.ToDecimal(PrecioVenta) * Convert.ToDecimal(Cantidad);

                            int xposition = gvDocumentoVentaDetalle.FocusedRowHandle;
                            gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioUnitario", PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioVenta", PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(xposition, "ValorVenta", ValorVenta);

                            CalculaTotales();
                        }
                    }
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se puede aplicar el precio de la Tienda UCAYALI, Por favor comuníquese con SISTEMAS.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkCantidadAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            //if(chkCantidadAutomatica.Checked)
            //{
            //    btnAgregar.Focus();
            //}

        }

        private void txtPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPIN.Text.Trim().Length > 0)
                {
                    cboVendedor.EditValue = Convert.ToInt32(txtPIN.Text);
                    txtPIN.Select();
                    txtPIN.SelectAll();
                }
            }
        }

        #endregion

        #region "Metodos"

        private void CargarDescuentoClienteMayorista()
        {
            mListaDescuentoClienteMayorista = new DescuentoClienteMayoristaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
        }

        private void TotalSumaEscalaFamilia()
        {
            try
            {
                if (gvDocumentoVentaDetalle.RowCount > 0)
                {
                    decimal dTotalVentaSinDsc_Regular = 0;
                    decimal dTotalVentaSinDsc_Navidad = 0;
                    decimal dTotalVentaSinDsc_Religioso = 0;

                    for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
                    {
                        int IdFamiliaProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdFamiliaProducto").ToString());
                        string ObsEscala = gvDocumentoVentaDetalle.GetRowCellValue(i, "ObsEscala").ToString();
                        if (ObsEscala != "")
                        {
                            // Validar General en Listado de todas las Escalas
                            decimal dDescMIN = this.Obtener_Dsc_Escala(IdFamiliaProducto, 0);

                            decimal decDescuento = dDescMIN;
                            decimal decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100), 2);
                            decimal decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());

                            decValorVenta = Conversion_Monto_Moneda(decValorVenta); // Conversion En Soles
                            if (IdFamiliaProducto == Parametros.intFamiliaRegular)
                            {
                                dTotalVentaSinDsc_Regular += decValorVenta;
                            }
                            else if (IdFamiliaProducto == Parametros.intFamiliaNavidad)
                            {
                                dTotalVentaSinDsc_Navidad += decValorVenta;
                            }
                            else if (IdFamiliaProducto == Parametros.intFamiliaReligioso)
                            {
                                dTotalVentaSinDsc_Religioso += decValorVenta;
                            }
                        }

                    }
                    lblTotRegular.Visible = false;
                    lblTotNavidad.Visible = false;
                    lblTotReligioso.Visible = false;
                    txtTotRegular.Visible = false;
                    txtTotNavidad.Visible = false;
                    txtTotReligioso.Visible = false;

                    if (dTotalVentaSinDsc_Regular != 0)
                    {
                        lblTotRegular.Visible = true;
                        txtTotRegular.Visible = true;
                        txtTotRegular.EditValue = Math.Round(dTotalVentaSinDsc_Regular, 2);
                    }
                    if (dTotalVentaSinDsc_Navidad != 0)
                    {
                        lblTotNavidad.Visible = true;
                        txtTotNavidad.Visible = true;
                        txtTotNavidad.EditValue = Math.Round(dTotalVentaSinDsc_Navidad, 2);
                    }
                    if (dTotalVentaSinDsc_Religioso != 0)
                    {
                        lblTotReligioso.Visible = true;
                        txtTotReligioso.Visible = true;
                        txtTotReligioso.EditValue = Math.Round(dTotalVentaSinDsc_Religioso, 2);
                    }

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal Obtener_Dsc_Escala(int IdFamiliaProducto, decimal dDescCeros)
        {
            decimal dDescMIN = 0;
            //Variable para obtener minimo
            List<EscalaMayoristaBE> lst_EscalaMayoristaBE = mListaEscalaMayorista;

            // Validar General en Listado de todas las Escalas
            var var_Escala = lst_EscalaMayoristaBE.Find(x => x.IdFamiliaProducto == IdFamiliaProducto && x.General == true);
            if (var_Escala != null)
            {
                dDescMIN = var_Escala.Descuento;
            }
            else
            {
                //Lista de Escala segun precio final y filtros
                var vr_Escala = lst_EscalaMayoristaBE.Where(itemEsc =>
                itemEsc.IdFamiliaProducto == IdFamiliaProducto &&
                itemEsc.Precio_Al >= dDescCeros).ToList();
                // Si encontro ingresa
                if (vr_Escala.Count != 0)
                {
                    dDescMIN = vr_Escala.Min(i2 => i2.Descuento);//Obtiene el minimo de la lista
                }
            }
            return dDescMIN;
        }

        public decimal Conversion_Monto_Moneda(decimal dMonto)
        {
            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            {
                decimal TipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
                dMonto = Math.Round(dMonto / TipoCambio, 2);
            }
            return dMonto;
        }

        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {

            #region "2022 DALILA"
            if (bLogicaMayorista)
            {
                bLogicaMayorista = false;
                // Para Mayorista y Black
                if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                {
                    if (gvDocumentoVentaDetalle.RowCount > 0)
                    {
                        gvDocumentoVentaDetalle.RefreshData();


                        #region "Encontrar Asociados"
                        List<int> lstTempoAsociado = new List<int>();
                        var var_FlagCompuesto = mListaPedidoDetalleOrigen.Where(x => x.FlagCompuesto = true).ToList();
                        foreach (var item in var_FlagCompuesto)
                        {
                            lstTempoAsociado.Add(item.IdProducto);
                        }
                        #endregion


                        #region  "2022"
                        // Variable Globales
                        int FPago = Convert.ToInt32(cboFormaPago.EditValue);
                        int IdTipoVenta = 0;// Convert.ToInt32(cboTipoVenta.EditValue);
                        List<DsctoMayoristaFamiliaFormaPagoBE> lst_MayoristaFamFPagoBE = new DsctoMayoristaFamiliaFormaPagoBL().ListaTodosActivo(0, FPago);
                        List<EscalaMayoristaBE> lst_EscalaMayoristaBE = mListaEscalaMayorista;
                        // Variables para Suma Escala por Familia
                        decimal dEscala_Regular = 0;
                        decimal dEscala_Navidad = 0;
                        decimal dEscala_Religioso = 0;
                        // Bucle de Productos


                        List<int> lstProductosEscala = new List<int>();

                        for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
                        {
                            //Variables globales de Productos
                            int IdFamiliaProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdFamiliaProducto").ToString());
                            int IdMarca = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdMarca").ToString());
                            int IdProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdProducto").ToString());
                            bool bIdEscala = bool.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "FlagEscala").ToString());
                            bool FlagNacional = bool.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "FlagNacional").ToString());
                            bool FlagFijarDescuento = bool.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "FlagFijarDescuento").ToString());
                            decimal PorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());
                            var var_IdPromocion2 = gvDocumentoVentaDetalle.GetRowCellValue(i, "IdPromocion2");


                            // Variables de almacenamiento
                            decimal PT_DESCUENTO = 0;
                            int IdPromocion2_guardar = 0;

                            //Varible para identificar Promocion temporal, Final o Mayorista
                            bool bFlagClienteMayorista = false;
                            bool bFlagClienteFinal = false;
                            // Lista de Promocion Temporal segun Productos y parametros
                            List<PromocionTemporalDetalleBE> ListPromocionTempo = new PromocionTemporalDetalleBL().Selecciona_Lista(Parametros.intEmpresaId, IdTipoCliente, FPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
                            ListPromocionTempo = ListPromocionTempo.Where(x => x.FlagClienteMayorista == true).ToList();
                            if (ListPromocionTempo.Count != 0)
                            {
                                //Variable para validar si Tiene promocion mayorista
                                var var_ListPromocionTempo = ListPromocionTempo.Where(ob => ob.FlagClienteMayorista == true).ToList();
                                bool bEsMayorista = true;

                                if (var_ListPromocionTempo.Count == 0)
                                {
                                    bEsMayorista = false;  // Si no Tiene promocion Mayorista variable en False
                                }
                                // Obtiene el descuento maximo segun Final o Mayorista
                                decimal dDescMayorMAX_mayor = ListPromocionTempo.Where(ob => ob.FlagClienteMayorista == bEsMayorista).Max(i2 => i2.Descuento);
                                foreach (var item_PromoTemp in ListPromocionTempo.Where(ob => ob.Descuento == dDescMayorMAX_mayor && ob.FlagClienteMayorista == bEsMayorista))
                                {
                                    //Setea variables
                                    IdPromocion2_guardar = item_PromoTemp.IdPromocionTemporalDetalle;
                                    bFlagClienteMayorista = item_PromoTemp.FlagClienteMayorista;
                                    bFlagClienteFinal = item_PromoTemp.FlagClienteFinal;
                                    PT_DESCUENTO = item_PromoTemp.Descuento; // Obtiene el -----> % DESCUENTO
                                    break;
                                }

                                // Temporal Final y Mayorista
                                if (bFlagClienteFinal)
                                {
                                    // Lista de Mayorista para aplicar el descuento segun su familia y forma de pago

                                    var varlistaMayoristaFamFPago = lst_MayoristaFamFPagoBE.Where(itemdsc =>
                                        itemdsc.IdFormaPago == FPago &&
                                        itemdsc.IdFamiliaProducto == IdFamiliaProducto &&
                                        itemdsc.Precio_Al >= PT_DESCUENTO).ToList();

                                    // variable para obtener  el descuento maximo por tienda
                                    decimal dDescPrecio_Al = 0;
                                    if (varlistaMayoristaFamFPago.Count != 0)
                                    {
                                        dDescPrecio_Al = varlistaMayoristaFamFPago.Min(i2 => i2.Precio_Al);//Obtiene el minimo de la lista
                                    }
                                    // Si el descuento obtnerido <= al maximo seteado
                                    //Agrega o adicional al Descuento
                                    foreach (var item in varlistaMayoristaFamFPago.Where(ob => ob.Precio_Al == dDescPrecio_Al))// 2023
                                    {
                                        decimal Dscto = item.DsctoTiendaMayorista;
                                        //TienePromo = true;
                                        if (item.Adicional)
                                        {
                                            PT_DESCUENTO += Dscto;//Adicional ADD
                                        }
                                        else
                                        {
                                            if (PT_DESCUENTO <= Dscto)
                                            {
                                                PT_DESCUENTO = Dscto;//SET 
                                            }
                                        }
                                        break;
                                    }

                                    if (IdMarca == Parametros.intIdMarcaKira)
                                    {
                                        PT_DESCUENTO = 10;
                                    }

                                }
                                if (FlagFijarDescuento)
                                {
                                    PT_DESCUENTO = PorcentajeDescuento;
                                }

                                // Seteo Final de DESCUENTO    
                                decimal decDescuento_2 = 0;
                                decimal decPrecioVenta_2 = 0;
                                decimal decValorVenta_2 = 0;
                                decDescuento_2 = PT_DESCUENTO;
                                decPrecioVenta_2 = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento_2) / 100), 2);
                                decValorVenta_2 = Math.Round(decPrecioVenta_2, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento_2);
                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta_2);
                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta_2);

                                mListaPedidoDetalleOrigen.Where(w => w.IdProducto == IdProducto).ToList().ForEach(s => s.IdPromocion2 = IdPromocion2_guardar);
                            }
                            else
                            {
                                bool bEncontroProductoEscala = false;

                                // Lista de Mayorista para aplicar el descuento segun su familia y forma de pago
                                var varlistaMayoristaFamFPago = lst_MayoristaFamFPagoBE.Where(itemdsc =>
                                            itemdsc.IdFormaPago == FPago &&
                                            itemdsc.IdFamiliaProducto == IdFamiliaProducto &&
                                            itemdsc.Precio_Del == PT_DESCUENTO).ToList();


                                // variable para obtener  el descuento maximo por tienda
                                decimal dDescPrecio_Al = 0;
                                if (varlistaMayoristaFamFPago.Count != 0)
                                {
                                    dDescPrecio_Al = varlistaMayoristaFamFPago.Min(i2 => i2.Precio_Al);//Obtiene el minimo de la lista
                                    dDescPrecio_Al = varlistaMayoristaFamFPago.Min(i2 => i2.Precio_Al);//Obtiene el minimo de la lista
                                }
                                // Si el descuento obtnerido <= al maximo seteado
                                //Agrega o adicional al Descuento
                                foreach (var item in varlistaMayoristaFamFPago.Where(ob => ob.Precio_Al == dDescPrecio_Al))// 2023
                                {
                                    decimal Dscto = item.DsctoTiendaMayorista;
                                    if (item.Adicional)
                                    {
                                        PT_DESCUENTO += Dscto;//Adicional ADD
                                    }
                                    else
                                    {
                                        if (PT_DESCUENTO <= Dscto)
                                        {
                                            PT_DESCUENTO = Dscto;//SET 
                                        }
                                    }
                                    break;
                                }


                                // Validacion si pertenece a la escala
                                lst_EscalaMayoristaBE = lst_EscalaMayoristaBE.OrderBy(x => x.Descuento).ToList();
                                var item_val = lst_EscalaMayoristaBE.Find(x => x.IdFamiliaProducto == IdFamiliaProducto); //falta el minimo de descuento
                                if (item_val != null)
                                {
                                    bEncontroProductoEscala = true;
                                    PT_DESCUENTO = item_val.Descuento;
                                    //PT_DESCUENTO = 0; //1 Encontro ESCALA
                                }


                                if (FlagNacional == true || IdMarca == Parametros.intIdMarcaKira)
                                {
                                    PT_DESCUENTO = 0;
                                    bEncontroProductoEscala = false;
                                }

                                // si es asociado
                                if (lstTempoAsociado.Count != 0)
                                {
                                    foreach (var iPro in lstTempoAsociado)
                                    {
                                        List<ProductoAsociadoBE> lstProductoAsociadoBE = new ProductoAsociadoBL().ListaTodosActivo(iPro);
                                        var varAsoc = lstProductoAsociadoBE.Find(x => x.IdProducto == IdProducto);
                                        if (varAsoc != null)// Si encontro
                                        {
                                            PT_DESCUENTO = 0;
                                            bEncontroProductoEscala = false;
                                        }
                                    }
                                }

                                if (var_IdPromocion2 == null) var_IdPromocion2 = 0;
                                if (Convert.ToInt32(var_IdPromocion2) != 0)//Si encontro una promocion ya dada al producto
                                {
                                    PT_DESCUENTO = PorcentajeDescuento;
                                    bEncontroProductoEscala = false;
                                }

                                if (FlagFijarDescuento)
                                {
                                    PT_DESCUENTO = PorcentajeDescuento;
                                }

                                // Seteo Final de DESCUENTO
                                decimal decDescuento_2 = 0;
                                decimal decPrecioVenta_2 = 0;
                                decimal decValorVenta_2 = 0;
                                decDescuento_2 = PT_DESCUENTO;
                                decPrecioVenta_2 = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento_2) / 100), 2);
                                decValorVenta_2 = Math.Round(decPrecioVenta_2, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento_2);
                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta_2);
                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta_2);

                                if (bEncontroProductoEscala)
                                {
                                    lstProductosEscala.Add(IdProducto);// add lista 
                                    decValorVenta_2 = Conversion_Monto_Moneda(decValorVenta_2); // Conversion En Soles
                                    if (IdFamiliaProducto == Parametros.intFamiliaRegular)
                                    {
                                        dEscala_Regular += decValorVenta_2;//Regular
                                    }
                                    else if (IdFamiliaProducto == Parametros.intFamiliaNavidad)
                                    {
                                        dEscala_Navidad += decValorVenta_2;//Navidad
                                    }
                                    else if (IdFamiliaProducto == Parametros.intFamiliaReligioso)
                                    {
                                        dEscala_Religioso += decValorVenta_2;//Religioso
                                    }
                                    else
                                    {
                                        dEscala_Regular += decValorVenta_2;//Otros
                                    }
                                }
                            }
                        }



                        if (lstProductosEscala.Count != 0)
                        {
                            gvDocumentoVentaDetalle.RefreshData();
                            //decimal Desc_PedidoReferencia = 0;
                            for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)//Contador de Productos
                            {
                                //Variables globales de Productos
                                int IdProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdProducto").ToString());
                                int IdFamiliaProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdFamiliaProducto").ToString());
                                int IdMarca = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdMarca").ToString());
                                string DescFamiliaProducto = gvDocumentoVentaDetalle.GetRowCellValue(i, "DescFamiliaProducto").ToString();
                                decimal PorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());
                                bool FlagNacional = bool.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "FlagNacional").ToString());
                                bool FlagEscala = bool.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "FlagEscala").ToString());
                                bool FlagFijarDescuento = bool.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "FlagFijarDescuento").ToString());

                                var varEncontro = lstProductosEscala.Find(x => x == IdProducto);
                                if (varEncontro != 0)
                                {
                                    decimal dSumaTotFamilia = 0;
                                    if (IdFamiliaProducto == Parametros.intFamiliaRegular)
                                    {
                                        dSumaTotFamilia = dEscala_Regular;// Set Suma de Escala Regular
                                    }
                                    else if (IdFamiliaProducto == Parametros.intFamiliaNavidad)
                                    {
                                        dSumaTotFamilia = dEscala_Navidad;// Set Suma de Escala Navidad
                                    }
                                    else if (IdFamiliaProducto == Parametros.intFamiliaReligioso)
                                    {
                                        dSumaTotFamilia = dEscala_Religioso;// SetSuma de Escala Religioso
                                    }
                                    else
                                    {
                                        dSumaTotFamilia = dEscala_Regular;// Set Otros
                                    }


                                    //decimal dDescMIN = 0;
                                    // Validar General en Listado de todas las Escalas
                                    decimal dDescEscala = this.Obtener_Dsc_Escala(IdFamiliaProducto, dSumaTotFamilia);
                                    if (dDescEscala != 0)
                                    {
                                        if (FlagFijarDescuento)
                                        {
                                            dDescEscala = PorcentajeDescuento;
                                        }

                                        //Seteo
                                        decimal decDescuento = dDescEscala;
                                        decimal decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100), 2);
                                        decimal decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                        gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento);
                                        gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                        gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);

                                        // Varible y Update de ObsEscala
                                        string ObsEscala = "De la familia " + DescFamiliaProducto.ToString() + " : El producto fue sujeto a escala ";
                                        //mListaPedidoDetalleOrigen.Where(w => w.IdProducto == IdProducto).ToList().ForEach(s => s.ObsEscala = ObsEscala);
                                        gvDocumentoVentaDetalle.SetRowCellValue(i, "ObsEscala", ObsEscala);
                                    }
                                }
                            }

                        }




                        this.TotalSumaEscalaFamilia();

                        #endregion
                    }
                }

            }

            #endregion




            #region "Anterior"
            //if (bNuevo)
            //{
            //    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
            //    {
            //        if (Convert.ToDecimal(txtTotal.Text) > 0)
            //        {
            //            decimal decTotal = 0;

            //            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
            //            {
            //                decTotal = Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(Parametros.dmlTCMayorista);
            //            }
            //            else
            //            {
            //                decTotal = Convert.ToDecimal(txtTotal.Text);
            //            }

            //            if (gvDocumentoVentaDetalle.RowCount > 0)
            //            {
            //                gvDocumentoVentaDetalle.RefreshData();

            //                for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
            //                {
            //                    int IdProducto = 0;
            //                    int IdLineaProducto = 0;
            //                    decimal decDescuentoOriginal = 0;
            //                    decimal decDescuento = 0;
            //                    decimal decPrecioVenta = 0;
            //                    decimal decValorVenta = 0;

            //                    IdProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdProducto").ToString());
            //                    decDescuentoOriginal = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());

            //                    StockBE objE_Stock = null;
            //                    objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
            //                    if (objE_Stock != null)
            //                    {
            //                        IdLineaProducto = objE_Stock.IdLineaProducto;
            //                        if (objE_Stock.FlagDescuentoAB)
            //                            decDescuentoOriginal = objE_Stock.DescuentoAB;
            //                        else
            //                            decDescuentoOriginal = objE_Stock.Descuento + Parametros.dmlDescuentoMayoristaExtra; //add
            //                            //decDescuentoOriginal = objE_Stock.Descuento; //
            //                    }

            //                    foreach (var itemdescuento in mListaDescuentoClienteMayorista)
            //                    {
            //                        if (Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && decTotal >= itemdescuento.MontoMin && decTotal <= itemdescuento.MontoMax)
            //                        {
            //                            decDescuento = itemdescuento.PorDescuento;
            //                            if (decDescuentoOriginal > decDescuento)
            //                            {
            //                                if (bMoroso)
            //                                {
            //                                    decimal decDescuentoMoroso = 0;
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
            //                                    decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100),2);
            //                                    decValorVenta = Math.Round(decPrecioVenta,2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
            //                                }
            //                                else
            //                                {
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoOriginal);
            //                                    decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoOriginal) / 100),2);
            //                                    decValorVenta = Math.Round(decPrecioVenta,2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
            //                                }
            //                            }
            //                            else
            //                            {
            //                                if (bMoroso)
            //                                {
            //                                    decimal decDescuentoMoroso = 0;
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
            //                                    decPrecioVenta =  Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100),2);
            //                                    decValorVenta = Math.Round(decPrecioVenta,2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
            //                                }
            //                                else
            //                                {
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento);
            //                                    decPrecioVenta = Math.Round( decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100),2);
            //                                    decValorVenta = Math.Round(decPrecioVenta,2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
            //                                    gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
            //                                }
            //                            }
            //                        }
            //                    }


            //                    //Test de velociad por Hora
            //                    #region "Descuento Promocion Temporal"

            //                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
            //                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Convert.ToInt32(cboFormaPago.EditValue), Parametros.intTiendaId, 0, IdProducto);
            //                    if (objE_PromocionTemporal != null)
            //                    {
            //                        //decimal decDescuentoBulto = 5;
            //                        decimal decDescuentoMoroso = 0;

            //                        if (decDescuentoOriginal < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
            //                        {
            //                            if (bMoroso)
            //                            {
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
            //                                decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100), 2);
            //                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
            //                            }
            //                            else
            //                            {
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", objE_PromocionTemporal.Descuento);
            //                                decPrecioVenta = Math.Round(decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - objE_PromocionTemporal.Descuento) / 100), 2);
            //                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
            //                                gvDocumentoVentaDetalle.SetRowCellValue(i, "FlagBultoCerrado", false); //add
            //                            }
            //                        }
            //                    }
            //                    #endregion


            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
            //CalculaTotales();
        }

        private void CalcularValoresGrilla(int IdMoneda)
        {
            try
            {
                if (gvDocumentoVentaDetalle.RowCount > 0)
                {
                    if (IdMoneda == Parametros.intSoles)
                    {
                        int posicion = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }

                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                    else
                    {
                        int posicion = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;

                            }
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["ValorVenta"], decValorVenta);
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

            if (cboFormaPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la forma de pago.\n";
                flag = true;
            }

            if (mListaDocumentoVentaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

            #region "Consulta RUC Data Local"

            //int TipoDocFact = Convert.ToInt32(cboDocumento.EditValue);
            //if (TipoDocFact == Parametros.intTipoDocFacturaElectronica)
            //{
            //    if (txtNumeroDocumento.Text.Trim().Length == 11)
            //    {
            //        ClienteBE objE_Cliente = null;
            //        objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
            //        if (objE_Cliente != null)
            //        {
            //            txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
            //            txtDescCliente.Text = objE_Cliente.DescCliente;
            //            if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
            //            {
            //                strMensaje = strMensaje + "- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria + ".\n";
            //                flag = true;
            //            }

            //            if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
            //            {
            //                strMensaje = strMensaje + "- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion + ".\n";
            //                flag = true;
            //            }
            //        }
            //        else
            //        {
            //            strMensaje = strMensaje + "- El RUC no existe en la base de datos SUNAT " + objE_Cliente.DescCondicion + " Por favor consultar con Sistemas.\n";
            //            flag = true;
            //        }
            //    }
            //    else
            //    {
            //        strMensaje = strMensaje + "- El RUC " + txtNumeroDocumento + " no es válido, Por favor verificar que tenga 11 caracteres.\n";
            //        flag = true;
            //    }
            //}

            #endregion


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

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CalculaTotales()
        {
            try
            {
                FlagImpresionRus = true;
                CalculaTotalPromocion2x1(); // 2022/06 ecm

                if (FlagPromocion2x1 == true)//add
                {
                    //if (IdTipoCliente == Parametros.intTipClienteFinal || IdClasificacionCliente != Parametros.intBlack)
                    //{
                    //CalculaTotalPromocion2x1();
                    //return;
                    //}
                }

                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;
                decimal deICBPER = 0;
                decimal deICBPERTotal = 0;
                decimal detotalDsctoCumple = 0;
                int intTotalCantidad = 0;
                decimal deICBPER_Afecto_Igv = 0;
                decimal deICBPER_Afecto_Igv2 = 0;
                //decimal deMinimoVale = 0;//add 240516 -- menor a 20%

                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        if (item.IdProducto == 83617 || item.IdProducto == 83618)
                        {
                            deICBPER_Afecto_Igv2 = 0;
                            deICBPER_Afecto_Igv = deICBPER_Afecto_Igv + (item.ValorVenta - (item.Cantidad * new decimal(0.50)));                    ///(item.Cantidad * new decimal(0.10));
                            deICBPER_Afecto_Igv2 = deICBPER_Afecto_Igv2 + (item.ValorVenta - (item.Cantidad * new decimal(0.50)));
                            deICBPER = deICBPER + (item.ValorVenta - deICBPER_Afecto_Igv2);
                            deICBPERTotal = deICBPERTotal + item.ValorVenta;

                         //   deICBPER = deICBPER + item.ValorVenta;
                        }
                        else
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        if (bCumpleAnios)
                        {
                            detotalDsctoCumple = new PedidoBL().lgDescuentoPorCumpleanios(detotalDsctoCumple, item.IdMarca, item.PorcentajeDescuento, item.ValorVenta);
                        }
                    }
                    //foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    //{
                    //    intTotalCantidad = intTotalCantidad + item.Cantidad;
                    //    deValorVenta = item.ValorVenta;
                    //    deTotal = deTotal + deValorVenta;
                    //}

                    txtTotalBruto.EditValue = 0;//add may 25

                    //if (chkVale.Checked) //solo por apertura
                    //{
                    //    if(deTotal >50)
                    //    {
                    //        txtTotalBruto.EditValue = deTotal;
                    //        deTotal = deTotal - 50;
                    //    }
                    //}

                    if (bCumpleAnios)
                    {
                        txtTotalSinDscCumple.EditValue = deTotal;

                        deTotal = Math.Round(deTotal - detotalDsctoCumple, 2);
                        txtDsctoCumple.EditValue = deTotal;
                    }


                    if (mListaPromocionVale.Count > 0)//add 250516
                    {
                        CalculaTotalesVale(intTotalCantidad, deTotal);
                        return;
                    }

                    deTotal = Math.Round(deTotal, 2);
                    deSubTotal = Math.Round((deTotal + (deICBPER_Afecto_Igv)) / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    //deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    deImpuesto = Math.Round((deTotal + (deICBPERTotal - deICBPER)) - deSubTotal, 2);
                    //deImpuesto = Math.Round(deTotal - deSubTotal, 2);

                    txtTotal.EditValue = deTotal + deICBPERTotal;
                    //txtTotal.EditValue = deTotal + deICBPER;
                    txtSubTotal.EditValue = deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;
                    txtTotalCantidad.EditValue = intTotalCantidad;
                    txtIcbper.EditValue = deICBPER;
                    txtDsctoCumple.EditValue = detotalDsctoCumple;

                    txtTotalResumen.EditValue = deTotal + deICBPER;
                    txtResta.EditValue = deTotal + deICBPER;

                    //txtTotal.EditValue = Math.Round(deTotal, 2); //AL 221018
                    //deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    //txtSubTotal.EditValue = deSubTotal;
                    //deImpuesto = deTotal - deSubTotal;
                    //txtImpuesto.EditValue = deImpuesto;
                    //Math.Round(deImpuesto, 2);
                    //txtTotalCantidad.EditValue = intTotalCantidad;

                    //txtTotalResumen.EditValue = deTotal;
                    //txtResta.EditValue = deTotal;

                    //Calcula las referencias
                    if (Convert.ToDecimal(txtTotalDiferencia.EditValue) > 0)
                    {
                        txtDifrencia.EditValue = Convert.ToDecimal(txtTotal.EditValue) - Convert.ToDecimal(txtTotalDiferencia.EditValue);
                    }
                }
                else
                {
                    txtTotalCantidad.EditValue = 0;
                    txtSubTotal.EditValue = 0;
                    txtImpuesto.EditValue = 0;
                    txtTotal.EditValue = 0;
                    txtIcbper.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalcularCabeceravsDetalle()
        {
            decimal deTotalDiferencia = 0;
            decimal deImpuesto = 0;
            decimal deValorVenta = 0;
            decimal deSubTotal = 0;
            decimal deTotal = 0;

            int intTotalCantidad = 0;
            //decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            {
                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    intTotalCantidad = intTotalCantidad + item.Cantidad;
                    deValorVenta = item.ValorVenta;
                    deTotal = deTotal + deValorVenta;
                }

                deTotalDiferencia = Math.Round(deTotal, 2) - Convert.ToDecimal(txtTotal.EditValue);
            }


            return deTotalDiferencia;
        }

        private void CalculaTotalesVale(int intTotalCantidad, decimal deTotal)
        {
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
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
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
                                btnEliminarVale.Visible = true;
                            }
                            else
                                btnEliminarVale.Visible = false;
                        }
                        else
                            btnEliminarVale.Visible = false;
                    }


                    txtTotal.EditValue = Math.Round(deTotal, 2);
                    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    txtSubTotal.EditValue = deSubTotal;
                    deImpuesto = deTotal - deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;
                    //txtTotalCantidad.EditValue = intTotalCantidad;

                    txtTotalResumen.EditValue = deTotal;
                    txtResta.EditValue = deTotal;

                    //Calcula las referencias
                    if (Convert.ToDecimal(txtTotalDiferencia.EditValue) > 0)
                    {
                        txtDifrencia.EditValue = Convert.ToDecimal(txtTotal.EditValue) - Convert.ToDecimal(txtTotalDiferencia.EditValue);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColumRowFocus(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcDocumentoVentaDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvDocumentoVentaDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = column;
                }
            }

        }

        private void ColumRowFocusCantidad(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcDocumentoVentaDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            GridColumn columnbus = View.Columns["Cantidad"];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvDocumentoVentaDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = columnbus;
                }
            }

        }

        private void CargaDocumentoVentaDetalle(int IdDocumentoVenta)
        {
            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);

            foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
            {
                CDocumentoVentaDetalle objE_DocumentoVentaDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoVentaDetalle.IdDocumentoVenta = 0; //item.IdDocumentoVenta;
                objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;//item.IdDocumentoVentaDetalle;
                objE_DocumentoVentaDetalle.Item = item.Item;
                objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoVentaDetalle.IdKardex = 0;//Convert.ToInt32(item.IdKardex);
                objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoVentaDetalle.Stock = 0;
                objE_DocumentoVentaDetalle.PorcentajeDescuentoInicial = 0;
                objE_DocumentoVentaDetalle.IdLineaProducto = 0;
                objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoVentaDetalle);
            }

            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoVentaDetalle.DataSource = bsListado;
            gcDocumentoVentaDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private void CargaDocumentoVentaPago()
        {
            List<DocumentoVentaPagoBE> lstTmpDocumentoVentaPago = null;
            lstTmpDocumentoVentaPago = new DocumentoVentaPagoBL().ListaTodosActivo(Parametros.intEmpresaId, 0);

            foreach (DocumentoVentaPagoBE item in lstTmpDocumentoVentaPago)
            {
                CDocumentoVentaPago objE_DocumentoVentaPago = new CDocumentoVentaPago();
                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                objE_DocumentoVentaPago.Fecha = item.Fecha;
                objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                objE_DocumentoVentaPago.NumeroDocumento = item.NumeroDocumento;
                objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                objE_DocumentoVentaPago.Importe = item.Importe;
                objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                mListaDocumentoVentaPagoOrigen.Add(objE_DocumentoVentaPago);
            }

            bsListadoPago.DataSource = mListaDocumentoVentaPagoOrigen;
            gcDocumentoVentaPago.DataSource = bsListadoPago;
            gcDocumentoVentaPago.RefreshDataSource();
        }

        private void ImpresionTicket(String TipoDoc)
        {
            string dirFacturacion = "<No Especificado>";

            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
            {
                dirFacturacion = Parametros.strDireccionUcayali2;
            }
            else
            {
                dirFacturacion = Parametros.strDireccionUcayali;
            }

            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
            {
                dirFacturacion = Parametros.strDireccionAndahuaylas;
            }
            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
            {
                dirFacturacion = Parametros.strDireccionMegaplaza;
            }
            if (Parametros.intTiendaId == Parametros.intTiendaPrescott)
            {
                dirFacturacion = Parametros.strDireccionPrescott;
            }

            #region "Ticket Boleta"
            if (TipoDoc == "TKV")
            {
                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
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

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                if (objTalon.FlagAbrirCajon == true) ticket.AbreCajon();  //abre el cajón
                //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                //ticket.TextoCentro(dirFacturacion);
                //ticket.TextoCentro("RUC: 20330676826");
                ticket.TextoCentro(objTalon.NombreComercial);
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(objTalon.DireccionFiscal);
                //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                ticket.TextoIzquierda(cboDocumento.Text + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierda("CLIENTE: " + Convert.ToString(txtDescCliente.Text.Trim()));
                ticket.LineasGuion();
                ticket.EncabezadoVenta();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                }
                ticket.LineasTotales();
                if (Convert.ToDouble(txtTotalBruto.EditValue) > Convert.ToDouble(txtTotal.EditValue)) //add 20 may 15
                {
                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(txtTotalBruto.EditValue), 2));
                    ticket.AgregaTotales("Descuento ", Math.Round((Convert.ToDouble(txtTotalBruto.EditValue) - Convert.ToDouble(txtTotal.EditValue)) * -1, 2));
                }
                ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(txtTotal.EditValue), 2)); // imprime linea con total
                ticket.TextoIzquierda("");
                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                ticket.TextoIzquierda("");
                //ticket.TextoCentro("www.panoramadistribuidores.com");
                ticket.TextoCentro(objTalon.PaginaWeb);
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                {
                    PromocionProximaBE objE_PromocionProxima = null;
                    objE_PromocionProxima = new PromocionProximaBL().SeleccionaActivo(Parametros.intTiendaId, Convert.ToInt32(cboFormaPago.EditValue), IdTipoCliente, Convert.ToDecimal(txtTotal.EditValue));//pItem.IdTipoCliente);
                    if (objE_PromocionProxima != null)
                    {
                        //ticket.CortaTicket();
                        ticket.TextoCentro("=========================================");
                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                        ojbPromocion = new PromocionProximaBL().Selecciona(objE_PromocionProxima.IdPromocionProxima);
                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                        ticket.TextoCentro("=========================================");
                    }
                }

                #region "Promoción 11 de Octubre - UCAYALI"
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == Convert.ToDateTime("11/10/2018"))
                {
                    if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
                    {
                        if (Math.Round(Convert.ToDouble(txtTotal.EditValue), 2) >= 100 && Math.Round(Convert.ToDouble(txtTotal.EditValue), 2) < 200)
                        {
                            //ticket.CortaTicket();
                            ticket.TextoCentro("");
                            ticket.TextoCentro("=========================================");
                            ticket.TextoCentro("¡¡¡¡¡¡¡¡FELICIDADES!!!!!!!!");
                            ticket.TextoIzquierdaNLineas("DECORAMOS TU FELICIDAD EN TU ESPACIO FAVORITO. ¡GANASTE! UNA ASESORIA EN DISENO DE INTERIORES VALIDO HASTA EL 31/10/2018");
                            ticket.TextoCentro("=========================================");
                            //ticket.TextoCentro("DECORAMOS TU FELICIDAD EN TU ESPACIO");
                            //ticket.TextoCentro("FAVORITO");
                            //ticket.TextoCentro("¡¡GANASTE!!");
                            //ticket.TextoCentro("UNA ASESORÍA EN DISEÑO DE INTERIORES");
                            //ticket.TextoCentro("VÁLIDO HASTA EL 31/10/2018");
                        }
                    }
                }

                #endregion

                ticket.CortaTicket();

            }
            #endregion

            #region "Ticket Factura"
            else
                if (TipoDoc == "TKF")
            {
                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
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

                    if (printer.ToUpper().StartsWith(objTalon.Impresora)) //("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                if (objTalon.FlagAbrirCajon == true) ticket.AbreCajon();  //abre el cajon
                                                                          //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                                                                          //ticket.TextoCentro(dirFacturacion);
                                                                          //ticket.TextoCentro("RUC: 20330676826");
                ticket.TextoCentro(objTalon.NombreComercial);
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(objTalon.DireccionFiscal);
                //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);

                ticket.TextoIzquierda(cboDocumento.Text + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierdaNLineas("CLIENTE: " + txtDescCliente.Text.Trim());
                ticket.TextoIzquierda("RUC: " + txtNumeroDocumento.Text.Trim());
                ticket.TextoIzquierdaNLineas("DIR: " + txtDireccion.Text.Trim());
                ticket.LineasGuion();
                ticket.EncabezadoVenta();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                }
                ticket.LineasTotales();
                if (Convert.ToDouble(txtTotalBruto.EditValue) > Convert.ToDouble(txtTotal.EditValue)) //add 20 may 15
                {
                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(txtTotalBruto.EditValue), 2));
                    ticket.AgregaTotales("Descuento ", Math.Round((Convert.ToDouble(txtTotalBruto.EditValue) - Convert.ToDouble(txtTotal.EditValue)) * -1, 2));
                }
                ticket.AgregaTotales("SubTotal", Math.Round(Convert.ToDouble(txtSubTotal.EditValue), 2));
                ticket.AgregaTotales("IGV", Math.Round(Convert.ToDouble(txtImpuesto.EditValue), 2));
                ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(txtTotal.EditValue), 2));
                ticket.TextoIzquierda("");
                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(txtTotal.EditValue), 2).ToString()) + " " + cboMoneda.Text);
                //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                ticket.TextoIzquierda("");
                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                ticket.TextoIzquierda("");
                //ticket.TextoCentro("www.panoramadistribuidores.com");
                ticket.TextoCentro(objTalon.PaginaWeb);
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                {
                    PromocionProximaBE objE_PromocionProxima = null;
                    objE_PromocionProxima = new PromocionProximaBL().SeleccionaActivo(Parametros.intTiendaId, Convert.ToInt32(cboFormaPago.EditValue), IdTipoCliente, Convert.ToDecimal(txtTotal.EditValue));//pItem.IdTipoCliente);
                    if (objE_PromocionProxima != null)
                    {
                        //ticket.CortaTicket();
                        ticket.TextoCentro("=========================================");
                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                        ojbPromocion = new PromocionProximaBL().Selecciona(objE_PromocionProxima.IdPromocionProxima);
                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                        ticket.TextoCentro("=========================================");
                    }
                }
                #region "Promoción 11 de Octubre - UCAYALI"
                if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == Convert.ToDateTime("11/10/2018"))
                {
                    if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
                    {
                        if (Math.Round(Convert.ToDouble(txtTotal.EditValue), 2) >= 100 && Math.Round(Convert.ToDouble(txtTotal.EditValue), 2) < 200)
                        {
                            //ticket.CortaTicket();
                            ticket.TextoCentro("");
                            ticket.TextoCentro("=========================================");
                            ticket.TextoCentro("¡¡¡¡¡¡¡¡FELICIDADES!!!!!!!!");
                            ticket.TextoIzquierdaNLineas("DECORAMOS TU FELICIDAD EN TU ESPACIO FAVORITO. ¡GANASTE! UNA ASESORIA EN DISENO DE INTERIORES VALIDO HASTA EL 31/10/2018");
                            ticket.TextoCentro("=========================================");
                            //ticket.TextoCentro("DECORAMOS TU FELICIDAD EN TU ESPACIO");
                            //ticket.TextoCentro("FAVORITO");
                            //ticket.TextoCentro("¡¡GANASTE!!");
                            //ticket.TextoCentro("UNA ASESORÍA EN DISEÑO DE INTERIORES");
                            //ticket.TextoCentro("VÁLIDO HASTA EL 31/10/2018");
                        }
                    }
                }

                #endregion


                //Agregar Nota de Crédito en auto

                ticket.CortaTicket();


            }
            #endregion

        }

        private void GrabarVentaIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            mDocumentoVentaE = objE_DocumentoVenta;

            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);


            DataTable facelecab = new DataTable();
            facelecab.Columns.Add("ipserver", Type.GetType("System.String"));
            facelecab.Columns.Add("instance", Type.GetType("System.String"));
            facelecab.Columns.Add("dbname", Type.GetType("System.String"));
            facelecab.Columns.Add("numruc", Type.GetType("System.String"));
            facelecab.Columns.Add("altido", Type.GetType("System.String"));
            facelecab.Columns.Add("sersun", Type.GetType("System.String"));
            facelecab.Columns.Add("numsun", Type.GetType("System.String"));
            facelecab.Columns.Add("fecemi", Type.GetType("System.String"));
            facelecab.Columns.Add("codmnd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidoid", Type.GetType("System.String"));
            facelecab.Columns.Add("numidn", Type.GetType("System.String"));
            facelecab.Columns.Add("nomcli", Type.GetType("System.String"));
            facelecab.Columns.Add("tidore", Type.GetType("System.String"));
            facelecab.Columns.Add("nudore", Type.GetType("System.String"));
            facelecab.Columns.Add("basafe", Type.GetType("System.String"));
            facelecab.Columns.Add("basina", Type.GetType("System.String"));
            facelecab.Columns.Add("basexo", Type.GetType("System.String"));
            facelecab.Columns.Add("mongra", Type.GetType("System.String"));
            facelecab.Columns.Add("mondsc", Type.GetType("System.String"));
            facelecab.Columns.Add("monigv", Type.GetType("System.String"));
            facelecab.Columns.Add("monisc", Type.GetType("System.String"));
            facelecab.Columns.Add("monotr", Type.GetType("System.String"));
            facelecab.Columns.Add("dscglo", Type.GetType("System.String"));
            facelecab.Columns.Add("monoca", Type.GetType("System.String"));
            facelecab.Columns.Add("mondoc", Type.GetType("System.String"));
            facelecab.Columns.Add("basper", Type.GetType("System.String"));
            facelecab.Columns.Add("monper", Type.GetType("System.String"));
            facelecab.Columns.Add("totdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("mopedo", Type.GetType("System.String"));
            facelecab.Columns.Add("todope", Type.GetType("System.String"));
            facelecab.Columns.Add("totant", Type.GetType("System.String"));
            facelecab.Columns.Add("cobide", Type.GetType("System.String"));
            facelecab.Columns.Add("ctadet", Type.GetType("System.String"));
            facelecab.Columns.Add("prcdet", Type.GetType("System.String"));
            facelecab.Columns.Add("mondet", Type.GetType("System.String"));
            facelecab.Columns.Add("codmot", Type.GetType("System.String"));
            facelecab.Columns.Add("tidomd", Type.GetType("System.String"));
            facelecab.Columns.Add("nudomd", Type.GetType("System.String"));
            facelecab.Columns.Add("fedomd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidove", Type.GetType("System.String"));
            facelecab.Columns.Add("nudove", Type.GetType("System.String"));
            facelecab.Columns.Add("tipcam", Type.GetType("System.String"));
            facelecab.Columns.Add("codcli", Type.GetType("System.String"));
            facelecab.Columns.Add("ubifis", Type.GetType("System.String"));
            facelecab.Columns.Add("dirfis", Type.GetType("System.String"));
            facelecab.Columns.Add("tiodre", Type.GetType("System.String"));
            facelecab.Columns.Add("nuodre", Type.GetType("System.String"));
            facelecab.Columns.Add("coddoc", Type.GetType("System.String"));
            facelecab.Columns.Add("numdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("tipped", Type.GetType("System.String"));
            facelecab.Columns.Add("numped", Type.GetType("System.String"));
            facelecab.Columns.Add("dester", Type.GetType("System.String"));
            facelecab.Columns.Add("ordcom", Type.GetType("System.String"));
            facelecab.Columns.Add("fecvct", Type.GetType("System.String"));
            facelecab.Columns.Add("observ", Type.GetType("System.String"));
            facelecab.Columns.Add("estreg", Type.GetType("System.String"));
            facelecab.Columns.Add("defopa", Type.GetType("System.String"));
            facelecab.Columns.Add("texglo", Type.GetType("System.String"));
            facelecab.Columns.Add("corepe", Type.GetType("System.String"));
            facelecab.Columns.Add("prcper", Type.GetType("System.String"));
            facelecab.Columns.Add("fecped", Type.GetType("System.String"));

            DataRow dr;
            dr = facelecab.NewRow();
            dr["ipserver"] = "panorama_interface";
            dr["instance"] = "postgres";
            dr["dbname"] = "ifac_panorama";
            dr["numruc"] = Parametros.strEmpresaRuc;
            dr["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;//"01";
            dr["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr["fecemi"] = objE_DocumentoVenta.Fecha;// "27/11/2017 10:00:00 a.m.";
            dr["codmnd"] = objE_DocumentoVenta.CodMoneda;//"USD";
            dr["tidoid"] = objE_DocumentoVenta.IdTipoIdentidad;// "6";
            dr["numidn"] = objE_DocumentoVenta.NumeroDocumento;// "20330676826"; //****ACTIVO Y HABIDO
            dr["nomcli"] = objE_DocumentoVenta.DescCliente;// "PANORAMA DISTRIB";
            dr["tidore"] = "";
            dr["nudore"] = "";
            dr["basafe"] = objE_DocumentoVenta.SubTotal;// "19226.86000"; ??
            dr["basina"] = "0.00000";
            dr["basexo"] = "0.00000";
            dr["mongra"] = "0.00000"; //SÓLO SIN SON GRATUITAS
            dr["mondsc"] = "0.00000";
            dr["monigv"] = objE_DocumentoVenta.Igv;//"3460.83000";
            dr["monisc"] = "0.00000";
            dr["monotr"] = "0.00000";
            dr["dscglo"] = "0.00000";//Descuentos globales
            dr["monoca"] = "0.00000";
            dr["mondoc"] = objE_DocumentoVenta.Total; //"22687.69000";
            dr["basper"] = "0.00000";
            dr["monper"] = "0.00000";
            dr["totdoc"] = "0.00000";
            dr["mopedo"] = "0.00000";
            dr["todope"] = objE_DocumentoVenta.Total;// "22687.69000";
            dr["totant"] = objE_DocumentoVenta.Total;//"22687.69000"; ANTICIPOS
            dr["cobide"] = "";
            dr["ctadet"] = "";
            dr["prcdet"] = "0.00000";
            dr["mondet"] = "0.00000";
            dr["codmot"] = "";
            dr["tidomd"] = "";
            dr["nudomd"] = "";
            dr["fedomd"] = "";
            dr["tidove"] = "1";//Ver caso Carnet de Extranjería
            dr["nudove"] = objE_DocumentoVenta.DniVendedor;//"42309349";
            dr["tipcam"] = objE_DocumentoVenta.TipoCambio;// "3.42100";
            dr["codcli"] = objE_DocumentoVenta.IdCliente;// "80-00-5089";
            dr["ubifis"] = objE_DocumentoVenta.IdUbigeoDom;// "110108";
            dr["dirfis"] = objE_DocumentoVenta.Direccion;//"AV.EL ZINC 271 URB.INSDUSTRIAL INFENTAS";
            dr["tiodre"] = "";
            dr["nuodre"] = "";
            dr["coddoc"] = "";
            dr["numdoc"] = "";
            dr["tipped"] = "NRO";
            dr["numped"] = objE_DocumentoVenta.NumeroPedido;// "000001";
            dr["dester"] = objE_DocumentoVenta.DescFormaPago;// "CONTADO CONTRA ENTREGA";
            dr["ordcom"] = objE_DocumentoVenta.Periodo.ToString() + "-" + objE_DocumentoVenta.NumeroPedido;// "GG-0034-2016";
            dr["fecvct"] = ""; //Consultar
            dr["observ"] = "";//"CONTROL: 22216 MERCADERIA ENTREGADA EN: T.C: 3.42100 VENDEDOR: EMMA GARCIA FECHA PEDIDO: 2017 - 06 - 19 FECHA ORD: 2017 - 06 - 19 - INCORPORADO AL REGIMEN DE AGENTES DE RETENCION DEL IGV SEGUN RS Nchar(176) 378 - 2013 SUNAT";
            dr["estreg"] = "CO";//CO = Correcto; AN= Anulado
            dr["defopa"] = "";
            dr["texglo"] = "";
            dr["corepe"] = "";
            dr["prcper"] = "0";
            dr["fecped"] = objE_DocumentoVenta.Fecha;// "27/11/2017 09:00:00 a.m.";

            facelecab.Rows.Add(dr);
            facelecab.TableName = "facelecab";

            DataSet dsCabecera = new DataSet();
            dsCabecera.Tables.Add(facelecab);

            #endregion

            #region "Detalle"

            DataTable faceledet = new DataTable();
            faceledet.Columns.Add("numruc");
            faceledet.Columns.Add("altido");
            faceledet.Columns.Add("sersun");
            faceledet.Columns.Add("numsun");
            faceledet.Columns.Add("nroitm");
            faceledet.Columns.Add("coduni");
            faceledet.Columns.Add("canped");
            faceledet.Columns.Add("codpro");
            faceledet.Columns.Add("nompro");
            faceledet.Columns.Add("valbas");
            faceledet.Columns.Add("mondsc");
            faceledet.Columns.Add("preuni");
            faceledet.Columns.Add("monigv");
            faceledet.Columns.Add("codafe");
            faceledet.Columns.Add("monisc");
            faceledet.Columns.Add("tipisc");
            faceledet.Columns.Add("prelis");
            faceledet.Columns.Add("valref");
            faceledet.Columns.Add("totuni");
            faceledet.Columns.Add("montot");
            faceledet.Columns.Add("monper");
            faceledet.Columns.Add("nomabr");
            faceledet.Columns.Add("eanbar");
            faceledet.Columns.Add("desdet");

            foreach (var item in lstTmpDocumentoVentaDetalle)
            {
                DataRow dr2;
                dr2 = faceledet.NewRow();
                dr2["numruc"] = Parametros.strEmpresaRuc;//"20330676826";
                dr2["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
                dr2["sersun"] = objE_DocumentoVenta.Serie;// "F001";
                dr2["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
                dr2["nroitm"] = item.Item; //"1";
                dr2["coduni"] = item.Abreviatura;//"UND";
                dr2["canped"] = item.Cantidad;// "1.00000";
                dr2["codpro"] = item.IdProducto;// "PB000001";
                dr2["nompro"] = item.NombreProducto;// "ANTICIPO DE ORDEN DE COMPRA GG-0034-2016";
                dr2["valbas"] = item.PrecioUnitario;// "19226.86000";
                dr2["mondsc"] = item.Descuento; //"0.00000";
                dr2["preuni"] = item.PrecioVenta;// "19226.86000";
                dr2["monigv"] = (Convert.ToDouble(item.Cantidad) * (Convert.ToDouble(item.PrecioVenta) - ((Convert.ToDouble(item.PrecioVenta) / Parametros.dblIGV)))).ToString(); //"3460.83000";
                dr2["codafe"] = "10"; //Tipo de Afectación del IGV
                dr2["monisc"] = "0.00000";
                dr2["tipisc"] = "0";
                dr2["prelis"] = item.PrecioVenta;//"22687.69000";
                dr2["valref"] = "0.00000"; //Sólo si es gratuito
                dr2["totuni"] = item.PrecioUnitario * item.Cantidad;// "19226.86000";
                dr2["montot"] = item.ValorVenta; //"22687.69000";
                dr2["monper"] = "0.00000";
                dr2["nomabr"] = "ANTICIPO DE ORDEN DE COMP";//??? DACTA
                dr2["eanbar"] = "";
                dr2["desdet"] = "";

                faceledet.Rows.Add(dr2);
            }

            faceledet.TableName = "faceledet";

            DataSet dsDetalle = new DataSet();
            dsDetalle.Tables.Add(faceledet);

            #endregion

            #region "Adicional"

            DataTable faceleant = new DataTable();
            faceleant.Columns.Add("numruc");
            faceleant.Columns.Add("altido");
            faceleant.Columns.Add("sersun");
            faceleant.Columns.Add("numsun");
            faceleant.Columns.Add("nroitm");
            faceleant.Columns.Add("tidoan");
            faceleant.Columns.Add("docant");
            faceleant.Columns.Add("tidoem");
            faceleant.Columns.Add("nudoem");
            faceleant.Columns.Add("monant");

            DataRow dr3;
            dr3 = faceleant.NewRow();
            dr3["numruc"] = Parametros.strEmpresaRuc;//"20330676826";
            dr3["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr3["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr3["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr3["nroitm"] = "1";
            dr3["tidoan"] = "01";
            dr3["docant"] = objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;//  "F001-00000001";
            dr3["tidoem"] = "6";//Ruc de Panorama
            dr3["nudoem"] = Parametros.strEmpresaRuc;//"20330676826";
            dr3["monant"] = objE_DocumentoVenta.Total;//"22687.69000";

            faceleant.Rows.Add(dr3);
            faceleant.TableName = "faceleant";

            DataSet dsAdicional = new DataSet();
            dsAdicional.Tables.Add(faceleant);

            #endregion

            string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N");

            if (MensajeService.ToUpper() != "OK")
            {
                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //XtraMessageBox.Show("Documento enviado correctamente. " + MensajeService.ToUpper(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                ///objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);

                ////if (XtraMessageBox.Show("Desea Imprimir el Comprobante" + IdDocumentoVenta.ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ////{
                ////ImpresionTicketElectronico("C"); //Impresión Prov
                ////}

                //TalonBE objTalon = null;
                //objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                //ImpresionElectronicaLocal(IdDocumentoVenta, "TK", objTalon.Impresora);

            }
        }


        private void InsertarDocumentoVenta()
        {
            try
            {
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta)
                {
                    if (txtNumeroDocumento.Text.Length != 11)
                    {
                        XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        txtNumeroDocumento.SelectAll();
                        txtNumeroDocumento.Focus();
                        return;
                    }

                }

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = null;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;
                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                //Obtener la serie del documento relacionado a la caja
                TalonBE objE_Talon = null;
                objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                if (objE_Talon != null)
                {
                    Serie = "";
                    Serie = objE_Talon.NumeroSerie;
                }

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                }


                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                objDocumentoVenta.DescCliente = txtDescCliente.Text;
                objDocumentoVenta.Direccion = txtDireccion.Text;
                objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                objDocumentoVenta.PorcentajeDescuento = 0;
                objDocumentoVenta.Descuentos = 0;
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);
                objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                    objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                    objE_DocumentoVentaDetalle.Item = item.Item;
                    objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                    objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                    objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                objE_MovimientoCaja.FlagEstado = true;
                objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count == 0)
                {
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                    objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);
                }
                else
                {
                    foreach (var item in mListaDocumentoVentaPagoOrigen)
                    {
                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                        objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                        objE_DocumentoVentaPago.Fecha = item.Fecha;
                        objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                        objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                        objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                        objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                        objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                        objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                        objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                        objE_DocumentoVentaPago.Importe = item.Importe;
                        objE_DocumentoVentaPago.FlagEstado = true;
                        objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                        lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                    }
                }

                if (pOperacion == Operacion.Nuevo)
                {
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoContinuo(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago, NumeracionAutomatica);

                    ImpresionContinua(IdDocumentoVenta);

                }
                else
                {
                    objBL_DocumentoVenta.ActualizaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                }

                //Imprimimos los documentos
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaVarios(int items)
        {
            try
            {
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                {
                    if (txtNumeroDocumento.Text.Length != 11)
                    {
                        XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        txtNumeroDocumento.SelectAll();
                        txtNumeroDocumento.Focus();
                        return;
                    }

                }

                int Contador = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count % items == 0)
                {
                    Contador = mListaDocumentoVentaDetalleOrigen.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDocumentoVentaDetalleOrigen.Count / items) + 1);
                }

                int row = 0;

                for (int i = 0; i < Contador; i++)
                {
                    //Documento Venta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                    lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    int fila = 0;
                    int cuenta = 0;
                    if (i > 0)
                    {
                        fila = row;
                    }

                    for (int y = fila; y < mListaDocumentoVentaDetalleOrigen.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDocumentoVentaDetalleOrigen[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDocumentoVentaDetalleOrigen[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDocumentoVentaDetalleOrigen[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDocumentoVentaDetalleOrigen[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDocumentoVentaDetalleOrigen[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDocumentoVentaDetalleOrigen[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDocumentoVentaDetalleOrigen[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDocumentoVentaDetalleOrigen[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDocumentoVentaDetalleOrigen[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDocumentoVentaDetalleOrigen[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDocumentoVentaDetalleOrigen[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDocumentoVentaDetalleOrigen[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDocumentoVentaDetalleOrigen[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDocumentoVentaDetalleOrigen[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDocumentoVentaDetalleOrigen[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDocumentoVentaDetalleOrigen[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDocumentoVentaDetalleOrigen[row].IdPromocion;
                        objE_DocumentoVentaDetalle.DescPromocion = mListaDocumentoVentaDetalleOrigen[row].DescPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDocumentoVentaDetalleOrigen[row].TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                        row = row + 1;
                        cuenta = cuenta + 1;
                    }

                    //Calcula Montos Totales

                    decimal deImpuesto = 0;
                    decimal deValorVenta = 0;
                    decimal deSubTotal = 0;
                    decimal deTotal = 0;
                    int intTotalCantidad = 0;

                    if (lstDocumentoVentaDetalle.Count > 0)
                    {
                        foreach (var item in lstDocumentoVentaDetalle)
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        deImpuesto = deTotal - deSubTotal;

                    }


                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = null;
                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    //Obtener la serie del documento relacionado a la caja
                    TalonBE objE_Talon = null;
                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                    if (objE_Talon != null)
                    {
                        Serie = "";
                        Serie = objE_Talon.NumeroSerie;
                    }

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);

                    }

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_MovimientoCaja.ImporteSoles = deTotal; //Convert.ToDecimal(txtTotal.EditValue); //**********************************
                    objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;

                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                    {
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                        objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_Pago.Importe = deTotal;
                        objE_Pago.FlagEstado = true;
                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        lstDocumentoVentaPago.Add(objE_Pago);
                    }
                    else
                    {
                        foreach (var item in mListaDocumentoVentaPagoOrigen)
                        {
                            DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                            objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                            objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                            objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                            objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                            objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                            objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                            objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                            objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                            objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                            objE_DocumentoVentaPago.Importe = item.Importe;
                            objE_DocumentoVentaPago.FlagEstado = true;
                            objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                            lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int IdDocumentoVenta = 0;
                        IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoContinuo(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago, NumeracionAutomatica);
                        ImpresionContinua(IdDocumentoVenta);
                    }
                    else
                    {
                        objBL_DocumentoVenta.ActualizaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImpresionContinua(int IdDocumentoVenta)
        {
            if (bFlagImpresion)
            {
                #region "RUS"
                //if (Convert.ToInt32(cboEmpresa.EditValue) != Parametros.intPanoraramaDistribuidores) 
                if (bRegimenRus == true)
                {
                    if (TipoFormato == Parametros.intTipoFormatoDesglosable)
                    {
                        DocumentoVentaBE objDocumento = null;
                        objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, Convert.ToInt32(cboDocumento.EditValue), Serie, Numero);

                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(IdDocumentoVenta);

                        rptBoletaPanoramaDesglosable objReporteGuia = new rptBoletaPanoramaDesglosable();
                        objReporteGuia.SetDataSource(lstReporte);


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

                            if (printer.ToUpper().StartsWith("(B)"))
                            {
                                found = true;
                                PrintOptions bufPO = objReporteGuia.PrintOptions;
                                prtSetting.PrinterName = prtName;
                                objReporteGuia.PrintOptions.PrinterName = prtName;

                                int rawKind = -1;
                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                                {
                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                    {
                                        rawKind = prtSetting.PaperSizes[i].RawKind;
                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                        break;
                                    }
                                }
                                if (rawKind == -1)
                                {
                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                            }
                        }

                        if (!found)
                        {
                            MessageBox.Show("La impresora (B) Nombre para Boleta no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);

                        return;
                    }
                    else
                    {
                        DocumentoVentaBE objDocumento = null;
                        objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdEmpresa == 8 ? 9 : Convert.ToInt32(cboDocumento.EditValue), Serie, Numero);

                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(IdDocumentoVenta);

                        if (IdEmpresa == 8)
                        {
                            rptBoletaPanoramaAviacion2 objReporteGuia = new rptBoletaPanoramaAviacion2();
                            objReporteGuia.SetDataSource(lstReporte);


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

                                if (printer.ToUpper().StartsWith("(B)"))
                                {
                                    found = true;
                                    PrintOptions bufPO = objReporteGuia.PrintOptions;
                                    prtSetting.PrinterName = prtName;
                                    objReporteGuia.PrintOptions.PrinterName = prtName;

                                    int rawKind = -1;
                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                                    {
                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                        {
                                            rawKind = prtSetting.PaperSizes[i].RawKind;
                                            objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                            break;
                                        }
                                    }
                                    if (rawKind == -1)
                                    {
                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                                }
                            }

                            if (!found)
                            {
                                MessageBox.Show("La impresora (B) Nombre para Boleta no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);

                            return;
                        }
                        else
                        {
                            rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
                            objReporteGuia.SetDataSource(lstReporte);


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

                                if (printer.ToUpper().StartsWith("(B)"))
                                {
                                    found = true;
                                    PrintOptions bufPO = objReporteGuia.PrintOptions;
                                    prtSetting.PrinterName = prtName;
                                    objReporteGuia.PrintOptions.PrinterName = prtName;

                                    int rawKind = -1;
                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                                    {
                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                        {
                                            rawKind = prtSetting.PaperSizes[i].RawKind;
                                            objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                            break;
                                        }
                                    }
                                    if (rawKind == -1)
                                    {
                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                                }
                            }

                            if (!found)
                            {
                                MessageBox.Show("La impresora (B) Nombre para Boleta no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);

                            return;
                        }
                    }


                }



                #endregion

                #region "Boleta Continua"
                if (cboDocumento.Text == "BOV")
                {
                    DocumentoVentaBE objDocumento = null;
                    objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie, Numero);

                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(IdDocumentoVenta);

                    rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
                    objReporteGuia.SetDataSource(lstReporte);


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

                        if (printer.ToUpper().StartsWith("(B)"))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                    break;
                                }
                            }
                            if (rawKind == -1)
                            {
                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("La impresora (B) Nombre para Boleta no ha sido encontrada.");

                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                }
                #endregion

                #region "Factura Continua"
                else
                    if (cboDocumento.Text == "FAV")
                {
                    DocumentoVentaBE objDocumento = null;
                    objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie, Numero);

                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(IdDocumentoVenta);

                    //string numLetra = FuncionBase.Enletras("200.23");

                    rptFacturaPanorama objReporteGuia = new rptFacturaPanorama();
                    objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("NumLetra", numLetra + " Soles");

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

                        if (printer.ToUpper().StartsWith("(F)"))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                    break;
                                }
                            }
                            if (rawKind == -1)
                            {
                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("La impresora (F) Nombre para Factura no ha sido encontrada.");

                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                }
                #endregion

                #region "Ticket Boleta"
                else
                    if (cboDocumento.Text == "TKV")
                {
                    ImpresionTicket("TKV");
                }

                #endregion

                #region "Ticket Factura"
                else
                    if (cboDocumento.Text == "TKF")
                {
                    ImpresionTicket("TKF");
                }

                #endregion            

                #region "Ticket Electronico"
                else if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                {
                    #region "Envío e Impresión de Comprobante electrónico"
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineBoletaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                            {
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }

                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }

                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineFacturaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                            {
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }
                    #endregion
                }

                #endregion            


            }
        }

        private void CobrarImprimir()
        {
            if (Convert.ToDecimal(txtTotal.Text) > 0)
            {
                //Validar Empresa 
                CajaEmpresaBE objCajaEmpresa = null;
                objCajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId);

                if (objCajaEmpresa == null)
                {
                    XtraMessageBox.Show("No se puede imprimir en esta Caja, Documentos de venta de: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CalculaTotales();//add By modified

                TipoFormato = objCajaEmpresa.IdTipoFormato;

                frmMsgPagoCondicion frmMsgPago = new frmMsgPagoCondicion();
                frmMsgPago.NumeroPedido = "";
                frmMsgPago.IdEmpresa = IdEmpresa;
                frmMsgPago.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                frmMsgPago.DescCliente = txtDescCliente.Text;
                frmMsgPago.Direccion = txtDireccion.Text;
                frmMsgPago.Total = Convert.ToDecimal(txtTotal.Text);
                frmMsgPago.IdCliente = IdCliente;
                frmMsgPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                frmMsgPago.IdClasificacionCliente = IdClasificacionCliente;
                frmMsgPago.IdTipoCliente = IdTipoCliente;

                frmMsgPago.DescuentoFlag = ValidaPorcentajeDescuento();

                frmMsgPago.ShowDialog();

                if (frmMsgPago.DialogResult == DialogResult.OK)
                {
                    IdEmpresa = frmMsgPago.IdEmpresa;
                    cboEmpresa.EditValue = IdEmpresa;
                    NumeroCupon = frmMsgPago.NumeroCupon;
                    Cupon = frmMsgPago.Cupon;
                    IdClienteComercio = frmMsgPago.vIdcomercio;

                    #region "Promocion Cliente 22"
                    //CLIENTE N° 22
                    if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) == Convert.ToDateTime("11/10/2018"))
                    {
                        DocumentoVentaBE objE_DocumentoVG = null;
                        objE_DocumentoVG = new DocumentoVentaBL().SeleccionaGanador22(Parametros.intTiendaId);
                        if (objE_DocumentoVG != null)
                        {
                            if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
                            {
                                if (objE_DocumentoVG.TotalCantidad == 100)
                                {
                                    CodigoNC = "10";
                                    #region "Impresión Vale"
                                    TalonBE objTalon = null;
                                    objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                    CreaTicket ticket = new CreaTicket();

                                    #region "Busca Impresora"
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

                                        if (printer.ToUpper().StartsWith(objTalon.Impresora)) //("(T)"))
                                        {
                                            found = true;
                                            ticket.impresora = @printer;
                                        }
                                    }

                                    if (!found)
                                    {
                                        MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                                    }
                                    #endregion
                                    ticket.TextoCentro("¡¡¡¡GANASTE!!!!");
                                    ticket.TextoIzquierdaNLineas("VALE DE S/50.00, CANJE VALIDO SÓLO EL LUNES 15 DE OCTUBRE EN TIENDA UCAYALI");
                                    ticket.CortaTicket();
                                    #endregion

                                    frmMensajePromocion frmMsg = new frmMensajePromocion();
                                    frmMsg.ShowDialog();
                                }
                                if (objE_DocumentoVG.TotalCantidad == 200)
                                {
                                    CodigoNC = "20";
                                    #region "Impresión Vale"
                                    TalonBE objTalon = null;
                                    objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                    CreaTicket ticket = new CreaTicket();

                                    #region "Busca Impresora"
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

                                        if (printer.ToUpper().StartsWith(objTalon.Impresora)) //("(T)"))
                                        {
                                            found = true;
                                            ticket.impresora = @printer;
                                        }
                                    }

                                    if (!found)
                                    {
                                        MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                                    }
                                    #endregion
                                    ticket.TextoCentro("¡¡¡¡GANASTE!!!!");
                                    ticket.TextoIzquierdaNLineas("VALE DE S/50.00, CANJE VALIDO SÓLO EL LUNES 15 DE OCTUBRE EN TIENDA UCAYALI");
                                    ticket.CortaTicket();
                                    #endregion
                                    frmMensajePromocion frmMsg = new frmMensajePromocion();
                                    frmMsg.ShowDialog();
                                }
                            }

                            //if (Parametros.intTiendaId == Parametros.intTiendaMegaplaza || Parametros.intTiendaId == Parametros.intTiendaPrescott)
                            //{
                            //    if (objE_DocumentoVG.TotalCantidad == 11)
                            //    {
                            //        CodigoNC = "22";
                            //        frmMensajePromocion frmMsg = new frmMensajePromocion();
                            //        frmMsg.ShowDialog();
                            //    }
                            //}
                            //else
                            //{
                            //    if (objE_DocumentoVG.TotalCantidad == 21)
                            //    {
                            //        CodigoNC = "22";
                            //        frmMensajePromocion frmMsg = new frmMensajePromocion();
                            //        frmMsg.ShowDialog();
                            //    }
                            //}
                        }
                    }


                    #endregion

                    //Validar cuando es RER no permita boletearlo con cliente Mayorista
                    //if (Convert.ToInt32(cboEmpresa.EditValue) == 3 || Convert.ToInt32(cboEmpresa.EditValue) == 19 || Convert.ToInt32(cboEmpresa.EditValue) == 21 ||
                    //    Convert.ToInt32(cboEmpresa.EditValue) == 23 || Convert.ToInt32(cboEmpresa.EditValue) == 8 || Convert.ToInt32(cboEmpresa.EditValue) == 20)
                    //{
                    //    if (IdTipoCliente == 87)
                    //    {
                    //        XtraMessageBox.Show("Solo puede emitir RER de " + cboEmpresa.Text.Trim() + "\n a Clientes Finales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //        return;
                    //    }
                    //}

                    //Agregar el detalle de promociones -- add 151119
                    if (FlagPromocion2x1)
                    {
                       // mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
                      //  mListaDocumentoVentaDetalleOrigen = mListaDocumentoVentaDetalleOrigen2;
                    }

                    EmpresaBE objE_Empresa = null;
                    objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);
                    if (objE_Empresa != null)
                    {
                        if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo Rus
                        {
                            bRegimenRus = true;
                            if (!FlagImpresionRus) //add 160216
                            {
                                XtraMessageBox.Show("No se puede imprimir una boleta RUS con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            //if (!ValidarTopeEmpresaRus()) //Mensual
                            //{
                            //if (!ValidarTopeEmpresaDiarioRus()) //Diario
                            //{
                            if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)  //  THB    THL
                            {

                                // Validacion en RER si los productos exceden el descuento del 30%
                                //bool qValorReturn2 = ValidaPorcentajeRER();
                                //if (!qValorReturn2)
                                //{

                                InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, frmMsgPago.TipoDocBolFac);
                                this.Close();
                                //}
                                //else
                                //{
                                //    XtraMessageBox.Show("No puede emitir RER con productos que contengan descuento \n mayores al 30%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //}
                                //ImpresionDirecta("BOV");
                                return;
                                //InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster);
                                //ImpresionDirecta("BOV");                                        
                            }
                            //else
                            //{
                            //    if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                            //    {
                            //        InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, frmMsgPago.TipoDocBolFac);
                            //        //ImpresionDirecta("BOV");
                            //        this.Close();
                            //        return;
                            //    }
                            //    else
                            //    {
                            //        InsertarDocumentoVentaVariosPagoVariosRUS(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster);
                            //        //ImpresionDirecta("BOV");
                            //        this.Close();
                            //        return;
                            //    }
                            //}
                            //}
                            //return;
                            //}
                            //return;
                        }
                    }

                    //Panorama y RER
                    //Obtener la serie del documento relacionado a la caja
                    TalonBE objE_Talon = null;
                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                    if (objE_Talon != null)
                    {
                        Serie = "";
                        Serie = objE_Talon.NumeroSerie;
                    }

                    if (Serie == null)
                    {
                        XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        cboDocumento.Focus();
                        return;
                    }

                    cboDocumento.EditValue = frmMsgPago.IdTipoDocumento;//Capturamos el valor
                    string TipoDoc = cboDocumento.Text;
                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                        {
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                        else
                        {
                            InsertarDocumentoVentaVariosPagoVarios(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                    }

                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
                        {
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                        else
                        {
                            InsertarDocumentoVentaVariosPagoVarios(10, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                    }

                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketBoleta)
                    {
                        InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        // ImpresionDirecta("TKV");
                    }
                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketFactura)
                    {
                        InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        // ImpresionDirecta("TKF");
                    }

                    #region "Ticket Electrónico"
                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocBoletaElectronica || Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocFacturaElectronica)
                    {
                        #region "Diferencia Cabecera vs detalle"
                        decimal TotalDiferencia = CalcularCabeceravsDetalle();
                        if (!bCumpleAnios)
                        {
                            if (TotalDiferencia != 0)
                            {
                                XtraMessageBox.Show("La suma de cabecera y detalle no son iguales. Por favor verificar con sistemas.\nNo se puede emitir una BE o FE con VALE o Promoción 2x1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }

                        ////if (Convert.ToDecimal(txtTotalBruto.EditValue) > 0)
                        ////{
                        ////    if (Convert.ToDecimal(txtTotalBruto.EditValue) != Convert.ToDecimal(txtTotal.EditValue))
                        ////    {
                        ////        XtraMessageBox.Show("No se puede emitir una BE o FE con VALE o Promoción 2x1 ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ////        return;
                        ////    }
                        ////}
                        #endregion

                        InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                    }
                    #endregion


                    this.Close();
                }

            }
            else
            {
                XtraMessageBox.Show("No se puede cobrar con monto cero, verificar venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CobrarDocumentoManual()
        {
            if (gvDocumentoVentaDetalle.RowCount > 0)
            {
                //Validar Empresa 
                //CajaEmpresaBE objCajaEmpresa = null;
                //objCajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId);

                //if (objCajaEmpresa == null)
                //{
                //    XtraMessageBox.Show("No se puede imprimir en esta Caja, Documentos de venta de: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                frmMsgPagoCondicionManual frmMsgPago = new frmMsgPagoCondicionManual();
                frmMsgPago.NumeroPedido = "";
                frmMsgPago.IdEmpresa = IdEmpresa;
                frmMsgPago.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                frmMsgPago.Total = Convert.ToDecimal(txtTotal.Text);
                frmMsgPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                frmMsgPago.ShowDialog();

                if (frmMsgPago.DialogResult == DialogResult.OK)
                {
                    IdEmpresa = frmMsgPago.IdEmpresa;
                    Serie = frmMsgPago.SerieManual;
                    Numero = frmMsgPago.NumeroManual;
                    NumeracionAutomatica = false;

                    //add 220116
                    bFlagImpresion = false;

                    EmpresaBE objE_Empresa = null;
                    objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);
                    if (objE_Empresa != null)
                    {
                        if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo Rus
                        {
                            bRegimenRus = true;

                            if (!ValidarTopeEmpresaRus()) //Mensual
                            {
                                if (!ValidarTopeEmpresaDiarioRus()) //Diario
                                {
                                    if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                                    {
                                        InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, 0);
                                        //ImpresionDirecta("BOV");
                                        this.Close();
                                        return;
                                    }
                                    else
                                    {
                                        InsertarDocumentoVentaVariosPagoVariosRUS(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster);
                                        //ImpresionDirecta("BOV");
                                        this.Close();
                                        return;
                                    }
                                }
                                return;
                            }
                            return;
                        }
                    }


                    ////Panorama y RER
                    ////Obtener la serie del documento relacionado a la caja
                    //TalonBE objE_Talon = null;
                    //objE_Talon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                    //if (objE_Talon != null)
                    //{
                    //    Serie = "";
                    //    Serie = objE_Talon.NumeroSerie;
                    //}

                    //if (Serie == null)
                    //{
                    //    XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    Cursor = Cursors.Default;
                    //    cboDocumento.Focus();
                    //    return;
                    //}

                    cboDocumento.EditValue = frmMsgPago.IdTipoDocumento;//Capturamos el valor
                    string TipoDoc = cboDocumento.Text;
                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                        {
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                        else
                        {
                            InsertarDocumentoVentaVariosPagoVarios(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                    }

                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
                        {
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                        else
                        {
                            InsertarDocumentoVentaVariosPagoVarios(10, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, TipoDoc);
                        }
                    }

                    /*if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketBoleta)
                    {
                        InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC);
                        // ImpresionDirecta("TKV");
                    }
                    if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketFactura)
                    {
                        InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC);
                        // ImpresionDirecta("TKF");
                    }*/
                    this.Close();
                }

            }
            else
            {
                XtraMessageBox.Show("No se puede cobrar sin códigos, verificar venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarProductoOutlet()
        {
            AgregarNuevoOutlet();
        }

        private bool ValidarTopeEmpresaRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total = Convert.ToDecimal(txtTotal.EditValue);

            /*if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }*/

            if (Convert.ToInt32(valueId) != Parametros.intPanoraramaDistribuidores)
            {
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(valueId);

                decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.Tope;
                }

                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaPeriodo(valueId, deFecha.DateTime.Year, deFecha.DateTime.Month);

                decimal TotalVenta = 0;

                if (objE_Documento != null)
                {
                    TotalVenta = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVenta = 0;
                }


                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(valueId));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                    {
                        if (TotalVenta > Tope)
                        {
                           // XtraMessageBox.Show("El importe de venta sobrepasa el tope mensual del RUS, por favor verifique.\n Consultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                        }
                    }
                }
            }

            if (flag)
            {
                //XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private bool ValidarTopeEmpresaDiarioRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total = Convert.ToDecimal(txtTotal.EditValue);

            //if (Convert.ToInt32(cboEmpresa.EditValue) == 3 || Convert.ToInt32(cboEmpresa.EditValue) == 8 || Convert.ToInt32(cboEmpresa.EditValue) == 19 ||
            //    Convert.ToInt32(cboEmpresa.EditValue) == 20|| Convert.ToInt32(cboEmpresa.EditValue) == 21 || Convert.ToInt32(cboEmpresa.EditValue) == 23)
            //{ 
                //decimal Tope = Parametros.dmlTopeEmpresaDiarioRUS; ;
                /// ********************************************************************************************
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(valueId);  // Convert.ToInt32(cboEmpresa.EditValue)

            decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.TopeDiario;
                }
                /// *******************************************************************************************
                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaFecha(valueId, Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                decimal TotalVenta = 0;

                if (objE_Documento != null)
                {
                    TotalVenta = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVenta = 0;
                }
                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(valueId);  //Convert.ToInt32(cboEmpresa.EditValue)
            if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                    {
                        if (TotalVenta > Tope)
                        {
                            //XtraMessageBox.Show("El importe de venta sobrepasa el tope diario del RUS, por favor verifique. \n Consultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
         //   }

            if (flag)
            {
                //XtraMessageBox.Show(strMensaje + ": Supera TOPE diario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  Cursor = Cursors.Default;
            }
            return flag;
        }

        private void InsertarDocumentoVentaRUS(int pTipoDocBolFac)
        {
            try
            {
                //Traemos la información del pedido.
                //PedidoBE objE_Pedido = null;
                //objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = null;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;

                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)  //THL  //THB
                {
                    objDocumentoVenta.IdTipoDocumento = pTipoDocBolFac;  //  Parametros.intTipoDocBoletaElectronica;
                }
                else
                {
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }

                //Serie asignada a la caja
                CajaEmpresaBE objCajaEmpresa = null;
                objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(IdEmpresa), Parametros.intTiendaId, Parametros.intCajaId);
                if (pTipoDocBolFac == 12)
                { SerieRUS = objCajaEmpresa.SerieBoleta; }
                else
                { SerieRUS = objCajaEmpresa.SerieFactura; }


                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(IdEmpresa, Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)   //THL  /THB
                {
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, pTipoDocBolFac, SerieRUS);
                    // mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaElectronica, SerieRUS);
                }
                else
                {
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, SerieRUS);
                }

                //         mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, SerieRUS);
                if (mListaNumero.Count > 0)
                {
                    Serie = mListaNumero[0].Serie;// SerieRUS.ToString();//"001";
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                }

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                objDocumentoVenta.DescCliente = txtDescCliente.Text;
                objDocumentoVenta.Direccion = txtDireccion.Text;
                objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                objDocumentoVenta.PorcentajeDescuento = 0;
                objDocumentoVenta.Descuentos = 0;
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);
                objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresa;
                objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                objDocumentoVenta.CodigoNC = CodigoNC;
                objDocumentoVenta.Icbper = Convert.ToDecimal(txtIcbper.EditValue);
                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                    objE_DocumentoVentaDetalle.Item = item.Item;
                    objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                    objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                    objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)   //THL //THB
                {
                    objE_MovimientoCaja.IdTipoDocumento = pTipoDocBolFac; //Parametros.intTipoDocBoletaElectronica;
                }
                else
                {
                    objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }

                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.FlagEstado = true;
                objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_MovimientoCaja.IdEmpresa = IdEmpresa;

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count == 0)
                {
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = IdEmpresa;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    //         objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;

                    objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                    objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);
                }
                else
                {
                    foreach (var item in mListaDocumentoVentaPagoOrigen)
                    {
                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                        objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                        objE_DocumentoVentaPago.Fecha = item.Fecha;
                        objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                        objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                        objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                        objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                        objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                        objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                        objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                        objE_DocumentoVentaPago.Importe = item.Importe;
                        objE_DocumentoVentaPago.FlagEstado = true;
                        objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                        lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                    }
                }

                if (pOperacion == Operacion.Nuevo)
                {
                    //objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoContinuo(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago, NumeracionAutomatica);

                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)  //THL   THB
                    {
                        //  #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                    }
                    else
                    {
                        ImpresionContinua(IdDocumentoVenta);
                    }

                }
                else
                {
                    objBL_DocumentoVenta.ActualizaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                }

                //Imprimimos los documentos
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaPorcentajeRER()
        {
            bool flag = false;
            //Documento Venta Detalle
            //List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
            //lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();
            foreach (var item in mListaDocumentoVentaDetalleOrigen)
            {
                if (item.PorcentajeDescuento > 30)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void InsertarDocumentoVentaVariosRUS(int items)
        {
            try
            {
                int Contador = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count % items == 0)
                {
                    Contador = mListaDocumentoVentaDetalleOrigen.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDocumentoVentaDetalleOrigen.Count / items) + 1);
                }

                int row = 0;

                for (int i = 0; i < Contador; i++)
                {
                    //Documento Venta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                    lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    int fila = 0;
                    int cuenta = 0;
                    if (i > 0)
                    {
                        fila = row;
                    }

                    for (int y = fila; y < mListaDocumentoVentaDetalleOrigen.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDocumentoVentaDetalleOrigen[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDocumentoVentaDetalleOrigen[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDocumentoVentaDetalleOrigen[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDocumentoVentaDetalleOrigen[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDocumentoVentaDetalleOrigen[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDocumentoVentaDetalleOrigen[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDocumentoVentaDetalleOrigen[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDocumentoVentaDetalleOrigen[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDocumentoVentaDetalleOrigen[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDocumentoVentaDetalleOrigen[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDocumentoVentaDetalleOrigen[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDocumentoVentaDetalleOrigen[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDocumentoVentaDetalleOrigen[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDocumentoVentaDetalleOrigen[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDocumentoVentaDetalleOrigen[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDocumentoVentaDetalleOrigen[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDocumentoVentaDetalleOrigen[row].IdPromocion;
                        objE_DocumentoVentaDetalle.DescPromocion = mListaDocumentoVentaDetalleOrigen[row].DescPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDocumentoVentaDetalleOrigen[row].TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                        row = row + 1;
                        cuenta = cuenta + 1;
                    }

                    //Calcula Montos Totales

                    decimal deImpuesto = 0;
                    decimal deValorVenta = 0;
                    decimal deSubTotal = 0;
                    decimal deTotal = 0;
                    int intTotalCantidad = 0;

                    if (lstDocumentoVentaDetalle.Count > 0)
                    {
                        foreach (var item in lstDocumentoVentaDetalle)
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        deImpuesto = deTotal - deSubTotal;

                    }

                    //Traemos la información del pedido.
                    //PedidoBE objE_Pedido = null;
                    //objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = null;
                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;


                    //Serie asignada a la caja
                    CajaEmpresaBE objCajaEmpresa = null;
                    objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                    SerieRUS = objCajaEmpresa.SerieBoleta;

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(IdEmpresa, Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, SerieRUS);
                    if (mListaNumero.Count > 0)
                    {
                        Serie = mListaNumero[0].Serie;// SerieRUS.ToString();//"001";
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);

                    }

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresa;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = deTotal;
                    objE_MovimientoCaja.ImporteDolares = deTotal / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;

                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                    {
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = IdEmpresa;
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                        objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_Pago.Importe = deTotal;
                        objE_Pago.FlagEstado = true;
                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        lstDocumentoVentaPago.Add(objE_Pago);
                    }
                    else
                    {
                        foreach (var item in mListaDocumentoVentaPagoOrigen)
                        {
                            DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                            objE_DocumentoVentaPago.IdEmpresa = IdEmpresa;
                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                            objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                            objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                            objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                            objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                            objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                            objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                            objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                            objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                            objE_DocumentoVentaPago.Importe = item.Importe;
                            objE_DocumentoVentaPago.FlagEstado = true;
                            objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                            lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        int IdDocumentoVenta = 0;
                        IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoContinuo(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago, NumeracionAutomatica);
                        ImpresionContinua(IdDocumentoVenta);
                    }
                    else
                    {
                        objBL_DocumentoVenta.ActualizaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaPagoVarios(decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster, string TipoDoc)
        {
            try
            {
                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = null;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;
                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                //Obtener la serie del documento relacionado a la caja
                if (NumeracionAutomatica == true) //Add 13-03-15
                {
                    TalonBE objE_Talon = null;
                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                    if (objE_Talon != null)
                    {
                        Serie = "";
                        Serie = objE_Talon.NumeroSerie;
                    }
                }

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                }

                #region "Verificar Número"

                DocumentoVentaBE objE_DocumentoVentaSerie = null;
                objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(Parametros.intEmpresaId, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                if (objE_DocumentoVentaSerie != null)
                {
                    XtraMessageBox.Show("El documento " + TipoDoc + ":" + Serie + "-" + Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                #endregion

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                objDocumentoVenta.DescCliente = txtDescCliente.Text;
                objDocumentoVenta.Direccion = txtDireccion.Text;
                objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                objDocumentoVenta.PorcentajeDescuento = 0;
                objDocumentoVenta.Descuentos = 0;
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                objDocumentoVenta.Icbper = Convert.ToDecimal(txtIcbper.EditValue);
                objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);
                objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                objDocumentoVenta.CodigoNC = CodigoNC;
                objDocumentoVenta.IdComercioAmigo = IdClienteComercio;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                    objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                    objE_DocumentoVentaDetalle.Item = item.Item;
                    objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                    objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                    objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }


                //Movimiento Caja
                List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon == 0))
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = 98;//
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Efectivo;
                    objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Visa > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 1;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = 99;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Visa;
                    objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (MasterCard > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 2;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCard;
                    objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }

                if (VisaPuntosVida > 0) //--------------------------------------------------------add
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 3;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 4;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Cupon > 0) //--------------------------------------------------------
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 4;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                    objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Cupon;
                    objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count == 0)
                {
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());

                    objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                    objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);
                }
                else
                {
                    foreach (var item in mListaDocumentoVentaPagoOrigen)
                    {
                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                        objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                        objE_DocumentoVentaPago.Fecha = item.Fecha;
                        objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                        objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                        objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                        objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                        objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                        objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                        objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                        objE_DocumentoVentaPago.Importe = item.Importe;
                        objE_DocumentoVentaPago.FlagEstado = true;
                        objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                        lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                    }
                }

                if (pOperacion == Operacion.Nuevo)
                {
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, NumeracionAutomatica);

                    ImpresionContinua(IdDocumentoVenta);

                    #region "Envío de prueba"
                    //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta)
                    //{
                    //    #region "Grabar"
                    //    if (Parametros.bOnlineBoletaElectronica)
                    //    {
                    //        string MensajeService = FacturaE.GrabarVentaIntegrens(IdDocumentoVenta);
                    //        if (MensajeService.ToUpper() != "OK")
                    //            XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    #endregion
                    //}

                    //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                    //{
                    //    #region "Grabar"
                    //    if (Parametros.bOnlineFacturaElectronica)
                    //    {
                    //        string MensajeService = FacturaE.GrabarVentaIntegrens(IdDocumentoVenta);
                    //        if (MensajeService.ToUpper() != "OK")
                    //            XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    #endregion

                    //}
                    #endregion
                }
                else
                {
                    XtraMessageBox.Show("Edición no Disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaVariosPagoVarios(int items, decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster, string TipoDoc)
        {
            try
            {
                int Contador = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count % items == 0)
                {
                    Contador = mListaDocumentoVentaDetalleOrigen.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDocumentoVentaDetalleOrigen.Count / items) + 1);
                }

                int row = 0;

                for (int i = 0; i < Contador; i++)
                {
                    //Documento Venta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                    lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    int fila = 0;
                    int cuenta = 0;
                    if (i > 0)
                    {
                        fila = row;
                    }

                    for (int y = fila; y < mListaDocumentoVentaDetalleOrigen.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDocumentoVentaDetalleOrigen[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDocumentoVentaDetalleOrigen[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDocumentoVentaDetalleOrigen[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDocumentoVentaDetalleOrigen[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDocumentoVentaDetalleOrigen[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDocumentoVentaDetalleOrigen[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDocumentoVentaDetalleOrigen[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDocumentoVentaDetalleOrigen[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDocumentoVentaDetalleOrigen[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDocumentoVentaDetalleOrigen[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDocumentoVentaDetalleOrigen[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDocumentoVentaDetalleOrigen[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDocumentoVentaDetalleOrigen[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDocumentoVentaDetalleOrigen[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDocumentoVentaDetalleOrigen[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDocumentoVentaDetalleOrigen[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDocumentoVentaDetalleOrigen[row].IdPromocion;
                        objE_DocumentoVentaDetalle.DescPromocion = mListaDocumentoVentaDetalleOrigen[row].DescPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDocumentoVentaDetalleOrigen[row].TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                        row = row + 1;
                        cuenta = cuenta + 1;
                    }

                    //Calcula Montos Totales

                    decimal deImpuesto = 0;
                    decimal deValorVenta = 0;
                    decimal deSubTotal = 0;
                    decimal deTotal = 0;
                    int intTotalCantidad = 0;

                    if (lstDocumentoVentaDetalle.Count > 0)
                    {
                        foreach (var item in lstDocumentoVentaDetalle)
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        deImpuesto = deTotal - deSubTotal;

                    }


                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = null;
                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    //Obtener la serie del documento relacionado a la caja
                    if (NumeracionAutomatica == true)
                    {
                        TalonBE objE_Talon = null;
                        objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                        if (objE_Talon != null)
                        {
                            Serie = "";
                            Serie = objE_Talon.NumeroSerie;
                        }
                    }


                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    }

                    #region "Verificar Número"

                    DocumentoVentaBE objE_DocumentoVentaSerie = null;
                    objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(Parametros.intEmpresaId, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                    if (objE_DocumentoVentaSerie != null)
                    {
                        XtraMessageBox.Show("El documento " + TipoDoc + ":" + Serie + "-" + Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    #endregion


                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                    if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon == 0))
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        objE_MovimientoCaja.IdMovimientoCaja = 0;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 98;//
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Efectivo / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Visa > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 1;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 99;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Visa / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCard > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 2;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard / Contador;
                        objE_MovimientoCaja.ImporteDolares = (MasterCard / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    if (VisaPuntosVida > 0) //--------------------------------------------------------add
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 3;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Cupon > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                        objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Cupon;
                        objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                    {
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                        objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_Pago.Importe = deTotal;
                        objE_Pago.FlagEstado = true;
                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        lstDocumentoVentaPago.Add(objE_Pago);
                    }
                    else
                    {
                        foreach (var item in mListaDocumentoVentaPagoOrigen)
                        {
                            DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                            objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                            objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                            objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                            objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                            objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                            objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                            objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                            objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                            objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                            objE_DocumentoVentaPago.Importe = item.Importe;
                            objE_DocumentoVentaPago.FlagEstado = true;
                            objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                            lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        int IdDocumentoVenta = 0;
                        IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, NumeracionAutomatica);
                        ImpresionContinua(IdDocumentoVenta);
                    }
                    else
                    {
                        objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, NumeracionAutomatica);
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaPagoVariosRUS(decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster, int TipoDocBolFac)
        {
            try
            {
                //Traemos la información del pedido.
                //PedidoBE objE_Pedido = null;
                //objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = null;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;

                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                {
                    objDocumentoVenta.IdTipoDocumento = TipoDocBolFac;    //Parametros.intTipoDocBoletaElectronica;
                }
                else
                {
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }


                if (NumeracionAutomatica == true)
                {
                    //Serie asignada a la caja
                    CajaEmpresaBE objCajaEmpresa = null;
                    objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);

                    if (TipoDocBolFac == 12)
                    { SerieRUS = objCajaEmpresa.SerieBoleta; }
                    else
                    { SerieRUS = objCajaEmpresa.SerieFactura; }


                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(IdEmpresa, Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                    {
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, TipoDocBolFac, SerieRUS);
                        //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaElectronica, SerieRUS);
                    }
                    else
                    {
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, SerieRUS);
                    }

                    if (mListaNumero.Count > 0)
                    {
                        Serie = mListaNumero[0].Serie;// SerieRUS.ToString();//"001";
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    }
                }

                ////Obtener la serie del documento relacionado a la caja
                //TalonBE objE_Talon = null;
                //objE_Talon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Parametros.intTipoDocBoletaVenta);
                //if (objE_Talon != null)
                //{
                //    Serie = "";
                //    Serie = objE_Talon.NumeroSerie;
                //}


                ////Obtener el numero del documento relacionado a la serie
                //List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, txtSerie.Text);
                //if (mListaNumero.Count > 0)
                //{
                //    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                //}

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                objDocumentoVenta.DescCliente = txtDescCliente.Text;
                objDocumentoVenta.Direccion = txtDireccion.Text;
                objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                objDocumentoVenta.PorcentajeDescuento = 0;
                objDocumentoVenta.Descuentos = 0;
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                objDocumentoVenta.FlagCumpleanios = bCumpleAnios;
                objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue);
                objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresa;
                objDocumentoVenta.CodigoNC = CodigoNC;
                objDocumentoVenta.IdComercioAmigo = IdClienteComercio;
                objDocumentoVenta.Icbper = Convert.ToDecimal(txtIcbper.EditValue);

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                    objE_DocumentoVentaDetalle.Item = item.Item;
                    objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                    objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                    objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon == 0))
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = 98;//
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Efectivo;
                    objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Visa > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 1;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = 99;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Visa;
                    objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (MasterCard > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 2;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCard;
                    objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }

                if (VisaPuntosVida > 0) //--------------------------------------------------------add
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 3;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 4;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Cupon > 0) //--------------------------------------------------------
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 4;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                    objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Cupon;
                    objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count == 0)
                {
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = IdEmpresa;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? TipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                    objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                    objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);
                }
                else
                {
                    foreach (var item in mListaDocumentoVentaPagoOrigen)
                    {
                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                        objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                        objE_DocumentoVentaPago.Fecha = item.Fecha;
                        objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                        objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                        objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                        objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                        objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                        objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                        objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                        objE_DocumentoVentaPago.Importe = item.Importe;
                        objE_DocumentoVentaPago.FlagEstado = true;
                        objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                        lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                    }
                }

                if (pOperacion == Operacion.Nuevo)
                {
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, NumeracionAutomatica);

                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)  //THL   THB
                    {
                        //  #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora);
                    }
                    else
                    {
                        ImpresionContinua(IdDocumentoVenta);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Edición no Disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaVariosPagoVariosRUS(int items, decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster)
        {
            try
            {
                int Contador = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count % items == 0)
                {
                    Contador = mListaDocumentoVentaDetalleOrigen.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDocumentoVentaDetalleOrigen.Count / items) + 1);
                }

                int row = 0;

                for (int i = 0; i < Contador; i++)
                {
                    //Documento Venta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                    lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    int fila = 0;
                    int cuenta = 0;
                    if (i > 0)
                    {
                        fila = row;
                    }

                    for (int y = fila; y < mListaDocumentoVentaDetalleOrigen.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDocumentoVentaDetalleOrigen[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDocumentoVentaDetalleOrigen[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDocumentoVentaDetalleOrigen[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDocumentoVentaDetalleOrigen[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDocumentoVentaDetalleOrigen[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDocumentoVentaDetalleOrigen[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDocumentoVentaDetalleOrigen[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDocumentoVentaDetalleOrigen[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDocumentoVentaDetalleOrigen[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDocumentoVentaDetalleOrigen[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDocumentoVentaDetalleOrigen[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDocumentoVentaDetalleOrigen[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDocumentoVentaDetalleOrigen[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDocumentoVentaDetalleOrigen[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDocumentoVentaDetalleOrigen[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDocumentoVentaDetalleOrigen[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDocumentoVentaDetalleOrigen[row].IdPromocion;
                        objE_DocumentoVentaDetalle.DescPromocion = mListaDocumentoVentaDetalleOrigen[row].DescPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDocumentoVentaDetalleOrigen[row].TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                        row = row + 1;
                        cuenta = cuenta + 1;
                    }

                    //Calcula Montos Totales

                    decimal deImpuesto = 0;
                    decimal deValorVenta = 0;
                    decimal deSubTotal = 0;
                    decimal deTotal = 0;
                    int intTotalCantidad = 0;

                    if (lstDocumentoVentaDetalle.Count > 0)
                    {
                        foreach (var item in lstDocumentoVentaDetalle)
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        deImpuesto = deTotal - deSubTotal;

                    }

                    ////Traemos la información del pedido.
                    //PedidoBE objE_Pedido = null;
                    //objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = null;
                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;

                    //Obtener el numero del documento relacionado a la serie
                    if (NumeracionAutomatica == true) //add 1303
                    {
                        //Serie asignada a la caja
                        CajaEmpresaBE objCajaEmpresa = null;
                        objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                        SerieRUS = objCajaEmpresa.SerieBoleta;


                        List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                        //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(IdEmpresa, Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, SerieRUS);
                        if (mListaNumero.Count > 0)
                        {
                            Serie = mListaNumero[0].Serie;// SerieRUS.ToString();//"001";
                            Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                        }
                    }

                    ////Obtener la serie del documento relacionado a la caja
                    //TalonBE objE_Talon = null;
                    //objE_Talon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Parametros.intTipoDocBoletaVenta);
                    //if (objE_Talon != null)
                    //{
                    //    Serie = "";
                    //    Serie = objE_Talon.NumeroSerie;
                    //}

                    ////Obtener el numero del documento relacionado a la serie
                    //List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresa, Parametros.intTipoDocBoletaVenta, txtSerie.Text);
                    //if (mListaNumero.Count > 0)
                    //{
                    //    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);

                    //}

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresa;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                    if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon == 0))
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        objE_MovimientoCaja.IdMovimientoCaja = 0;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 98;//
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Efectivo / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Visa > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 1;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = 99;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Visa / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCard > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 2;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard / Contador;
                        objE_MovimientoCaja.ImporteDolares = (MasterCard / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    if (VisaPuntosVida > 0) //--------------------------------------------------------add
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 3;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Cupon > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                        objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Cupon;
                        objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                    {
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = IdEmpresa;
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                        objE_Pago.NumeroDocumento = Serie + "-" + Numero;
                        objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                        objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_Pago.Importe = deTotal;
                        objE_Pago.FlagEstado = true;
                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        lstDocumentoVentaPago.Add(objE_Pago);
                    }
                    else
                    {
                        foreach (var item in mListaDocumentoVentaPagoOrigen)
                        {
                            DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                            objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                            objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                            objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                            objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
                            objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                            objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                            objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                            objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                            objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                            objE_DocumentoVentaPago.Importe = item.Importe;
                            objE_DocumentoVentaPago.FlagEstado = true;
                            objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                            lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                        int IdDocumentoVenta = 0;
                        IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC, NumeracionAutomatica);
                        ImpresionContinua(IdDocumentoVenta);
                    }
                    else
                    {
                        XtraMessageBox.Show("Edición no Disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "BEE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 13;
            dr["Descripcion"] = "FEE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 90;
            dr["Descripcion"] = "TKV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 91;
            dr["Descripcion"] = "TKF";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "BOV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 26;
            dr["Descripcion"] = "FAV";
            dt.Rows.Add(dr);
            return dt;
        }

        private void CargarProductoArmado(int IdProducto)
        {
            try
            {
                #region "HangTag"

                StockBE pProductoBE = null;
                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, IdProducto);
                if (pProductoBE != null)
                {
                    IdProducto = pProductoBE.IdProducto;
                    pProductoBE.Cantidad = 1;

                    int i = 0;
                    int Item = 0;
                    if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                        i = mListaDocumentoVentaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
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
                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedido", null);
                            //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioABSoles);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioABSoles * ((100 - pProductoBE.Descuento) / 100));
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioABSoles * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                        else
                        {

                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedido", null);
                            //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioCDSoles);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioCDSoles * ((100 - pProductoBE.Descuento) / 100));
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioCDSoles * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }
                    else
                    {
                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        {

                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedido", null);
                            //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioAB);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioAB * ((100 - pProductoBE.Descuento) / 100));
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioAB * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                        else
                        {
                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == pProductoBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", pProductoBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedido", null);
                            //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdPedidoDetalle", pProductoBE.IdPedidoDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", pProductoBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", pProductoBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", pProductoBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", pProductoBE.PrecioCD);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", pProductoBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", pProductoBE.PrecioCD * ((100 - pProductoBE.Descuento) / 100));
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", (pProductoBE.PrecioCD * ((100 - pProductoBE.Descuento) / 100)) * pProductoBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Observacion", "SERVICIO");
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", Parametros.strGravadoOnerosa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", pProductoBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

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

        private void EliminarVale()
        {
            mListaPromocionVale.Clear();
            btnEliminarVale.Visible = false;
            CalculaTotales();
        }

        private void CargarProductoAsociado(int IdProducto, int Cantidad, string CodAfeIGV)
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
                    if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                        i = mListaDocumentoVentaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
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
                                var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvDocumentoVentaDetalle.AddNewRow();
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", item.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", 0);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", item.Precio);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", item.Precio * item.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvDocumentoVentaDetalle.UpdateCurrentRow();

                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                            else
                            {
                                var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvDocumentoVentaDetalle.AddNewRow();
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", item.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", 0);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", item.Precio);
                                //gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", item.Precio * item.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvDocumentoVentaDetalle.UpdateCurrentRow();

                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                        }
                        else
                        {
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {

                                var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvDocumentoVentaDetalle.AddNewRow();
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", item.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvDocumentoVentaDetalle.UpdateCurrentRow();

                                CalculaTotales();

                                btnNuevo.Focus();
                            }
                            else
                            {
                                var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == item.IdProducto).ToList();
                                if (Buscar.Count > 0)
                                {
                                    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                gvDocumentoVentaDetalle.AddNewRow();
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", Item);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", item.IdProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", item.CodigoProveedor);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", item.NombreProducto);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", item.Abreviatura);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", item.Cantidad);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", item.Precio);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", item.Descuento);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", Math.Round(item.Precio * ((100 - item.Descuento) / 100), 2) * (item.Cantidad * Cantidad));
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodAfeIGV", CodAfeIGV);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", false);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", Parametros.intNinguno);
                                gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                gvDocumentoVentaDetalle.UpdateCurrentRow();

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

        private void ImpresionTicketElectronico(string Formato)
        {
            string sNombreArchivo = mDocumentoVentaE.Ruc + "_" + mDocumentoVentaE.IdConTipoComprobantePago + "_" + mDocumentoVentaE.Serie + "_" + mDocumentoVentaE.Numero;

            //XML
            byte[] data = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "XML", "");
            File.WriteAllBytes(sNombreArchivo + ".xml", data);

            //PDF
            byte[] datap = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "PDF", Formato);
            File.WriteAllBytes(sNombreArchivo + ".pdf", datap);

            //ZIP
            byte[] dataz = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "ZIP", "");
            File.WriteAllBytes(sNombreArchivo + ".zip", dataz);


            #region "Imprimir"
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = @"" + sNombreArchivo + ".pdf";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
            #endregion


        }

        private void ImpresionElectronicaLocal(int IdDocumentoVenta, int IdTamanoHoja, string Impresora)
        {
            //frmListaPrinters frmPrinter = new frmListaPrinters();
            //if (frmPrinter.ShowDialog() == DialogResult.OK)
            //{

            if (IdTamanoHoja == Parametros.intTamanoA4)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    #region "Codigo QR"
                    int Regs = lstReporte.Count() - 1;
                    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(ValorQR, out qrCode);

                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();

                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                    //imagen.Save("imagen.png", ImageFormat.Png);
                    #endregion
                    rptFacturaElectronicaPanoramaA4 objReporteGuia = new rptFacturaElectronicaPanoramaA4();
                    objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

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

                        if (printer.ToUpper().StartsWith(Impresora))
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
                        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                        return;
                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                    #endregion

                }
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmTermico)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    #region "Codigo QR"
                    int Regs = lstReporte.Count() - 1;
                    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(ValorQR, out qrCode);

                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();

                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                    //imagen.Save("imagen.png", ImageFormat.Png);
                    #endregion

                    rptFacturaElectronicaPanorama80mm objReporteGuia = new rptFacturaElectronicaPanorama80mm();
                    objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

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

                        if (printer.ToUpper().StartsWith(Impresora))
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
                        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                        return;
                    }
                    //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    //MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                    #endregion
                }
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmMatricial)
            {
                #region "Impresión Matricial"

                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali2;
                else if (IdEmpresa == 13 && Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                    dirFacturacion = Parametros.strDireccionUcayali3;
                else
                    dirFacturacion = Parametros.strDireccionUcayali;
                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott) dirFacturacion = Parametros.strDireccionPrescott;
                if (Parametros.intTiendaId == Parametros.intTiendaAviacion2) dirFacturacion = Parametros.strDireccionAviacion2;

                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                List<MovimientoCajaBE> lstPagosCaja = new List<MovimientoCajaBE>();
                lstPagosCaja = new MovimientoCajaBL().ListaFormaPago(IdDocumentoVenta);

                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
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

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                ticket.AbreCajon();

                if (objTalon.NumeroAutoriza == "TERMICA")
                {
                    if (IdEmpresa == 3)  // Empresa    CI
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("CORONA IMPORTADORES E.I.R.L.");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS, PLAQUE Y MANTELERIA");
                            ticket.TextoCentro("AV. GUILLERMO PRESCOTT NRO. 329 INT. 101");
                            ticket.TextoCentro("SAN ISIDRO - LIMA - LIMA");
                            ticket.TextoCentro("PTO. VTA.: JR. UCAYALI 425 - LIMA - LIMA");

                            //  ticket.TextoCentro(objTalon.DireccionFiscal);
                            //            if (objTalon.IdTienda == Parametros.intTiendaAviacion2) ticket.TextoCentro("LIMA - LIMA - LIMA");
                            ticket.TextoCentro("20506249601");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //}
                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("CORONA IMPORTADORES E.I.R.L.");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }

                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }


                        #endregion
                    }
                    else if (IdEmpresa == 19)  // Empresa    THB
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN NELLY BETHSABE");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS, PLAQUE Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //            if (objTalon.IdTienda == Parametros.intTiendaAviacion2) ticket.TextoCentro("LIMA - LIMA - LIMA");
                            ticket.TextoCentro("10727472873");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //}
                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. ");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("TAPIA HUAMAN NELLY BETHSABE");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }


                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (IdEmpresa == 21)  // Empresa THL
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN SILVIA LILIANA");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR, CRISTALERIA, LAMPARAS, PLAQUE Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //            if (objTalon.IdTienda == Parametros.intTiendaAviacion2) ticket.TextoCentro("LIMA - LIMA - LIMA");
                            ticket.TextoCentro("10435468140");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //}
                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }

                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("TAPIA HUAMAN SILVIA LILIANA");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }

                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }

                        #endregion
                    }
                    else if (IdEmpresa == 23)  // Empresa TTELEAZAR
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA TARRILLO ELEAZAR");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR, CRISTALERIA, LAMPARAS, PLAQUE Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10068611143");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                                                                                //foreach (var item in lstReporte)
                                                                                                //{
                                                                                                //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                                                                                //   ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                                                                                // }
                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }

                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("TAPIA TARRILLO ELEAZAR");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }


                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }

                        #endregion
                    }
                    else if (IdEmpresa == 8)  // Empresa Amalia
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("HUAMAN BRAMON TEODORA AMALIA");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR, CRISTALERIA, LAMPARAS, PLAQUE Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10068692968");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //}
                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }

                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("HUAMAN BRAMON TEODORA AMALIA");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }

                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (IdEmpresa == 20)  // Roxana
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN ROXANA INES");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR, CRISTALERIA, LAMPARAS, PLAQUE Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10426485287");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                                                                                //foreach (var item in lstReporte)
                                                                                                //{
                                                                                                //   ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                                                                                //   ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                                                                                //}

                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("TAPIA HUAMAN ROXANA INES");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }


                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }

                        #endregion
                    }
                    else   // PANORAMA
                    {
                        #region "Impresión 2 Copia"
                        for (int i = 1; i <= 2; i++)
                        {
                            ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            ticket.TextoCentro(Parametros.strEmpresaRuc);
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("N° " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel

                                //foreach (var item in lstReporte)
                                //{
                                //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //}
                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }

                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                            //ticket.TextoIzquierda("");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            //ticket.TextoIzquierda("Ped:");
                            if (i == 1)
                            {
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 155-2017/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en https://www.nubefact.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("www.panoramahogar.com");
                                ticket.TextoCentro("***** COPIA CLIENTE   v." + Parametros.strVersion + " *****");

                            }
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A.");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }


                        // IMprime por Vale S/50
                        if (lstReporte[0].Total > 500 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡GANASTE UN CUPON DE S/ 50.00!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Hazlo efectivo del 1 de julio al 31 de julio de 2023 en cualquiera de nuestras tiendas.");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- Valido SOLO para Cliente Final");
                            ticket.TextoIzquierda("- Aplicable para compras minimas de S/ 300");
                            ticket.TextoIzquierda("- Cupones no acumulables");
                            ticket.TextoIzquierda("- No aplica para servicio de diseño interiores, ni papel tapiz");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");
                            ticket.CortaTicket();
                        }

                        // IMprime por compras minima S/ 150
                        if (lstReporte[0].Total >= 150 && lstReporte[0].IdTipoCliente == 86)
                        {
                            ticket.TextoIzquierda("*************************************************");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("¡FELICIDADES!");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierdaNLineas("Disfruta del 10% de descuento en tu próxima compra en nuestra web www.panoramahogar.com ingresando el codigo PV10");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("Restricciones:");
                            ticket.TextoIzquierda("- No acumulable");
                            ticket.TextoIzquierda("- No aplica en mercaderia de la marca Kira Hogar");
                            ticket.TextoIzquierda("- No incluye delivery");

                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("*************************************************");

                            ticket.CortaTicket();
                        }

                        #endregion
                    }
                }
                else
                {
                    #region "Impresión 1 Copia"

                    ticket.TextoCentro(Parametros.strEmpresaNombre);
                    ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                    ticket.TextoCentro(objTalon.DireccionFiscal);
                    if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                    ticket.TextoCentro(Parametros.strEmpresaRuc);
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                    //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                    //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                    ticket.TextoIzquierda("N° " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                    ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                    ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                    ///ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                    ticket.LineasGuion();
                    ticket.EncabezadoVenta();

                    foreach (var item in lstReporte)
                    {
                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    }
                    ticket.LineasTotales();
                    if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                    {
                        ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                        ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                        //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                        //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    }
                    ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                    ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                    ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + "" + lstReporte[0].Icbper.ToString());
                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                    ticket.TextoIzquierda("");
                    //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                    ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                    //ticket.TextoIzquierda("");
                    foreach (var item in lstPagosCaja)
                    {
                        if (item.IdMoneda == Parametros.intSoles)
                            ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                        else
                            ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                    }
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                    ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                    ticket.TextoIzquierda("");
                    //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                    ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 155-2017/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en https://www.nubefact.com/consulta");
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("www.panoramahogar.com");
                    ticket.TextoCentro("ver. " + Parametros.strVersion);
                    //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                    //if (lstReporte[0].IdPromocionProxima > 0)
                    //{
                    //    ticket.CortaTicket();
                    //    ticket.TextoCentro("=========================================");
                    //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                    //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                    //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                    //    ticket.TextoCentro("=========================================");
                    //}
                    ticket.CortaTicket();
                    #endregion
                }

                #endregion
            }

            #region "Nota de crédito"

            if ("NOTA CREDITO" == "NC")
            {
                //rptNotaCreditoElectronicaPanoramaA4 objReporteGuia = new rptNotaCreditoElectronicaPanoramaA4();
                //objReporteGuia.SetDataSource(lstReporte);
                ////objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                ////objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                ////Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                #region "Buscar Impresora ..."

                //bool found = false;
                //PrinterSettings prtSetting = new PrinterSettings();
                //foreach (string prtName in PrinterSettings.InstalledPrinters)
                //{
                //    string printer = "";
                //    if (prtName.StartsWith("\\\\"))
                //    {
                //        printer = prtName.Substring(3);
                //        printer = printer.Substring(printer.IndexOf("\\") + 1);
                //    }
                //    else
                //        printer = prtName;

                //    if (printer.ToUpper().StartsWith(Impresora))
                //    {
                //        found = true;
                //        PrintOptions bufPO = objReporteGuia.PrintOptions;
                //        prtSetting.PrinterName = prtName;
                //        objReporteGuia.PrintOptions.PrinterName = prtName;

                //        Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                //        break;
                //    }
                //}

                //if (!found)
                //{
                //    Cursor = Cursors.Default;
                //    MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                //    return;
                //}
                //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                //MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                #endregion

            }
            #endregion
        }

        private void Imprimir_Detalle(CreaTicket ticket, List<ReporteDocumentoVentaElectronicaBE> lstReporte, int IdDocumentoVenta, int I_Parametro)
        {
            //// SI SE MODIFICA, TAMBIEN MODIFICAR
            ///  frmRegMovimientoCaja   // frmRegVentaContado   //  frmRegAutoServicio

            #region "IMPRESION 2x1"
            List<DocumentoVentaDetalleBE> mListaPromocion2x1 = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);
            List<DocumentoVentaDetalleBE> mListaSinPromo = mListaPromocion2x1.Where(x => x.DescPromocion.Length == 0).ToList();
            List<DocumentoVentaDetalleBE> nLista2x1 = mListaPromocion2x1.Where(x => x.DescPromocion.Length > 0).OrderByDescending(x => x.PrecioUnitario).ToList();
            // SOLO PRODUCTOS 2x1
            foreach (var item in nLista2x1)
            {
                string IdProducto = item.IdProducto.ToString();
                string CodigoProveedor = item.CodigoProveedor.PadRight(100).Substring(0, 16);
                string COD = "";
                COD = CodigoProveedor;  // I_Parametro == 1 ? IdProducto : CodigoProveedor;
                string Abrev = item.Abreviatura;
                string DescPro = item.DescPromocion;
                string NombreProducto = item.NombreProducto;
                string DescPro_NombrePro = DescPro + " " + NombreProducto.PadRight(100).Substring(0, 20);

                int Cantidad = item.Cantidad;
                double PrecioUnitario = Convert.ToDouble(item.PrecioUnitario);
                decimal PrecioVentaPrincpal = item.PrecioVenta;
                decimal ValorVentaPrincpal = item.ValorVenta;

                if (item.DescPromocion.Length > 0)
                {
                    double Valor2x1 = Convert.ToDouble(ValorVentaPrincpal) - (Cantidad * PrecioUnitario);
                    ticket.AgregaArticuloCodigo2x1(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(COD), Math.Round(PrecioUnitario, 2).ToString("0.00"), Math.Round((PrecioUnitario * Cantidad), 2).ToString("0.00"));
                    ticket.AgregaArticuloDetalle2x1(DescPro_NombrePro, "", Math.Round(Valor2x1, 2).ToString("0.00"));
                }
            }
            // SOLO PRODUCTOS
            foreach (var item in mListaSinPromo)
            {
                string IdProducto = item.IdProducto.ToString();
                string CodigoProveedor = item.CodigoProveedor.PadRight(100).Substring(0, 16);
                string COD = "";
                COD = CodigoProveedor;  // I_Parametro == 1 ? IdProducto : CodigoProveedor;

                ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(COD));
                ticket.AgregaArticuloDetalleCeros(item.NombreProducto + new string(' ', 20), Math.Round(item.PrecioVenta, 2).ToString("0.00"), Math.Round(item.ValorVenta, 2).ToString("0.00"));
            }
            #endregion

            //foreach (var item in lstReporte)
            //{
            //    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
            //    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
            //}
        }

        private void CalculaDescuentoClienteFinal(int IdProducto, int Cantidad)
        {
            try
            {
                decimal decDescuento = 0;
                decimal decPrecioAB = 0;
                decimal decPrecioCD = 0;
                decimal decDescuentoOrigen = 0;
                decimal decDescuentoClubDesign = 0;

                //decimal decDescuentoFinal = 0;
                //decimal decPrecioUnitFinal = 0;
                //decimal decPrecioVenFinal = 0;
                //decimal decValorFinal = 0;
                int IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                bool bFlagNacional = false;
                int IdFamiliaProducto = 0;
                int IdLineaProducto = 0;


                //Traemos el precio AB del producto seleccionado
                StockBE objE_Stock = null;
                objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                if (objE_Stock != null)
                {
                    decDescuentoOrigen = objE_Stock.Descuento;
                    bFlagNacional = objE_Stock.FlagNacional;
                    IdFamiliaProducto = objE_Stock.IdFamiliaProducto;
                    IdLineaProducto = objE_Stock.IdLineaProducto;
                    foreach (var item in Parametros.pListaDescuentoClienteFinal)
                    {
                        #region "Descuento por Cantidad"

                        if (Cantidad >= item.CantidadMinima && Cantidad <= item.CantidadMaxima)
                        {
                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                decPrecioUnitFinal = decPrecioCD;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = decDescuentoOrigen + 10;
                                    else
                                        decDescuentoFinal = decDescuentoOrigen;
                                    decPrecioVenFinal = Math.Round(decPrecioCD * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                                else
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = item.PorDescuento + 10;
                                    else
                                        decDescuentoFinal = item.PorDescuento;
                                    decPrecioVenFinal = Math.Round(decPrecioCD * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)

                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                decPrecioUnitFinal = decPrecioCD;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = decDescuentoOrigen + 10;
                                    else
                                        decDescuentoFinal = decDescuentoOrigen;
                                    decPrecioVenFinal = Math.Round(decPrecioCD * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                                else
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = item.PorDescuento + 10;
                                    else
                                        decDescuentoFinal = item.PorDescuento;
                                    decPrecioVenFinal = Math.Round(decPrecioCD * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                            }


                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioAB && item.PorDescuento == 0)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioAB = objE_Stock.PrecioABSoles;
                                else
                                    decPrecioAB = objE_Stock.PrecioAB;

                                decPrecioUnitFinal = decPrecioAB;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = decDescuentoOrigen + 10;
                                    else
                                        decDescuentoFinal = decDescuentoOrigen;
                                    decPrecioVenFinal = Math.Round(decPrecioAB * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                                else
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = item.PorDescuento + 10;
                                    else
                                        decDescuentoFinal = item.PorDescuento;
                                    decPrecioVenFinal = Math.Round(decPrecioAB * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }

                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioAB && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioAB = objE_Stock.PrecioABSoles;
                                else
                                    decPrecioAB = objE_Stock.PrecioAB;

                                decPrecioUnitFinal = decPrecioAB;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = decDescuentoOrigen + 10;
                                    else
                                        decDescuentoFinal = decDescuentoOrigen;
                                    decPrecioVenFinal = Math.Round(decPrecioAB * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                                else
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = item.PorDescuento + 10;
                                    else
                                        decDescuentoFinal = item.PorDescuento;
                                    decPrecioVenFinal = Math.Round(decPrecioAB * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }

                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)

                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                decPrecioUnitFinal = decPrecioCD;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = decDescuentoOrigen + 10;
                                    else
                                        decDescuentoFinal = decDescuentoOrigen;
                                    decPrecioVenFinal = Math.Round(decPrecioCD * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                                else
                                {
                                    if (bCumpleAnios)
                                        decDescuentoFinal = item.PorDescuento + 10;
                                    else
                                        decDescuentoFinal = item.PorDescuento;
                                    decPrecioVenFinal = Math.Round(decPrecioCD * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                                    decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                                }
                            }
                        }
                        #endregion
                    }

                    #region "Descuento por Club Design"
                    if (IdClasificacionCliente == Parametros.intClubDesign)
                    {
                        if (bFlagNacional)
                            decDescuentoClubDesign = Convert.ToDecimal(5.00);
                        else
                        {
                            if (IdFamiliaProducto == Parametros.intFamiliaNavidad)
                                decDescuentoClubDesign = Convert.ToDecimal(5.00);
                            else //regular
                            {
                                if (IdLineaProducto == Parametros.intLineaReligioso)
                                    decDescuentoClubDesign = Convert.ToDecimal(5.00);
                                else //Todas las lineas Regulares
                                {
                                    decDescuentoClubDesign = Convert.ToDecimal(20.00);
                                }
                            }
                        }
                    }
                    if (decDescuentoFinal < decDescuentoClubDesign)
                    {
                        decDescuentoFinal = decDescuentoClubDesign;
                        decPrecioVenFinal = Math.Round(decPrecioUnitFinal * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                        decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                    }


                    #endregion

                    //Test de velociad por Hora
                    #region "Descuento Promocion Temporal"
                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Parametros.intContado, Parametros.intTiendaId, 0, IdProducto);
                    if (objE_PromocionTemporal != null)
                    {
                        if (decDescuentoFinal < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                        {
                            decDescuentoFinal = objE_PromocionTemporal.Descuento;
                            decPrecioVenFinal = Math.Round(decPrecioUnitFinal * ((100 - Convert.ToDecimal(decDescuentoFinal)) / 100), 2);
                            decValorFinal = decPrecioVenFinal * Convert.ToDecimal(Cantidad);
                        }
                    }

                    #endregion

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BloquearDatoCliente()
        {
            txtNumeroDocumento.Properties.ReadOnly = true;
            txtDescCliente.Properties.ReadOnly = true;
        }
        #endregion

        public class CDocumentoVentaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoVenta { get; set; }
            public Int32 IdDocumentoVentaDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String CodAfeIGV { get; set; }
            public Int32 IdKardex { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32? IdPromocion { get; set; }
            public String DescPromocion { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 IdFamiliaProducto { get; set; }

            public String ObsEscala { get; set; }
            public String DescFamiliaProducto { get; set; }
            public Int32 IdMarca { get; set; }
            public bool FlagEscala { get; set; }
            public bool FlagNacional { get; set; }
            public bool FlagFijarDescuento { get; set; }
            public Int32 IdPromocion2 { get; set; }

            public Int32 TipoOper { get; set; }

            public CDocumentoVentaDetalle()
            {

            }
        }

        public class CDocumentoVentaPago
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoVenta { get; set; }
            public Int32 IdDocumentoVentaPago { get; set; }
            public DateTime Fecha { get; set; }
            public Int32 IdTipoDocumento { get; set; }
            public String CodTipoDocumento { get; set; }
            public String NumeroDocumento { get; set; }
            public Int32 IdCondicionPago { get; set; }
            public String DescCondicionPago { get; set; }
            public Int32 IdMoneda { get; set; }
            public String CodMoneda { get; set; }
            public Decimal TipoCambio { get; set; }
            public Decimal Importe { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoVentaPago()
            {

            }
        }

        private void txtTotal2x1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDsctoCumple_Click(object sender, EventArgs e)
        {

        }

        private void txtDsctoCumple_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl26_Click(object sender, EventArgs e)
        {

        }
    }

}