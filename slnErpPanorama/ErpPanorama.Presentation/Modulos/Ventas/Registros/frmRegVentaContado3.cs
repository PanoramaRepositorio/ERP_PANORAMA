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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Contabilidad.Consultas;
using ErpPanorama.Presentation.Funciones;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.ws_integrens;
using System.IO;
using System.Diagnostics;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegVentaContado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        ws_integrensSoapClient WS = new ws_integrensSoapClient();

        private List<PedidoBE> mLista = new List<PedidoBE>();
        private List<PedidoDetalleBE> mListaDetalle = null;
        private List<Empresas> mListaEmpresasRER = null;
        public List<CDocumentoVentaPago> mListaDocumentoVentaPagoOrigen = new List<CDocumentoVentaPago>();
        public List<CMovimientoCaja> mListaMovimientoCaja = new List<CMovimientoCaja>();
        public DocumentoVentaBE mDocumentoVentaE = new DocumentoVentaBE();
        private FacturacionElectronica FacturaE = new FacturacionElectronica();
        //private FacturacionElectronicaDemo FacturaE = new FacturacionElectronicaDemo();
        List<PedidoDetalleBE> mListaPedidoDetalleOrigen = new List<PedidoDetalleBE>();


        DataTable dtPedido = new DataTable();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        int IdPedido = 0;
        int IdEmpresa = 0;
        int IdTienda = 0;
        int IdCliente = 0;
        private string SerieRUS="0";
        private string Serie;
        private string Numero;
        private int IdTamanoHoja = 0;
        private int IdAsesorExterno = 0;
        private string NumeroCupon = "";
        decimal Cupon = 0;

        int IdTipoDocumentoCliente = 0;
        int IdTipoDocumentoClienteAsociado = 0;
        string NumeroDocumento = "";
        int IdAlmacen = 0;
        string NumeroCredito = "";
        string CodigoNC = "";

        #endregion

        #region "Eventos"

        public frmRegVentaContado()
        {
            InitializeComponent();
        }

        private void frmRegVentaContado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            deFecha.EditValue = DateTime.Now;
            //BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);

            BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            //BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivosRER(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
            //cboEmpresa.EditValue = Parametros.intEmpresaId;

            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPedidoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intPVGenerado;
            BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
            cboCondicionPago.EditValue = Parametros.intEfectivo;
            BSUtils.LoaderLook(cboMonedaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMonedaPago.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(Parametros.intEmpresaId, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
            Cargar();
            CargaDocumentoVentaPago();
            this.pOperacion = Operacion.Nuevo;
            if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
            {
                IdAlmacen = Parametros.intAlmCentralUcayali;
                chkDespachar.Visible = true;
            }
            else
            {
                IdAlmacen = Parametros.intAlmTienda;
            }

            if (Parametros.intTiendaId == Parametros.intTiendaMegaplaza)//Tipo de Tienda x Departamento
            {
                liberarpedidotoolStripMenuItem.Visible = true;
            }
            else
            {
                liberarpedidotoolStripMenuItem.Visible = false;
            }
                
        }

        private void frmRegVentaContado_Shown(object sender, EventArgs e)
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

            List<MovimientoCajaBE> mLista = null;
            mLista = new MovimientoCajaBL().ListaTodosActivo(Parametros.intCajaId, Parametros.dtFechaHoraServidor);
            var Buscar = mLista.Where(oB => oB.IdTipoDocumento == Parametros.intTipoDocAperturaCaja).ToList();
            if (Buscar.Count == 0)
            {
                XtraMessageBox.Show("Por favor, falta aperturar la caja asiganda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolFlag = true;
            }

            if (bolFlag)
            {
                this.Close();
            }
        }

        private void gvPedido_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                DataRow dr;
                dr = gvPedido.GetDataRow(e.RowHandle);
                IdPedido = 0;
                IdEmpresa = int.Parse(dr["IdEmpresa"].ToString());
                IdPedido = int.Parse(dr["IdPedido"].ToString());
                IdTienda = int.Parse(dr["IdTienda"].ToString());
                IdCliente = int.Parse(dr["IdCliente"].ToString());

                lblPedido.Text = dr["Numero"].ToString();
                lblTipoCliente.Text = dr["TiposCliente"].ToString();

                IdTipoDocumentoCliente = int.Parse(dr["IdTipoDocumentoCliente"].ToString());
                txtTotal.EditValue = decimal.Parse(dr["Total"].ToString());
                txtTotalResumen.EditValue = decimal.Parse(dr["Total"].ToString());
                txtResta.EditValue = decimal.Parse(dr["Total"].ToString());
                NumeroDocumento = "";
                NumeroDocumento = dr["NumeroDocumento"].ToString();
                cboEmpresa.EditValue = IdEmpresa;

                //Mostrar Asociado
                IdTipoDocumentoClienteAsociado = int.Parse(dr["IdTipoDocumentoClienteAsociado"].ToString());
                txtDescClienteAsociado.EditValue = dr["DescClienteAsociado"].ToString();

                //Diseñador externo
                IdAsesorExterno = int.Parse(dr["IdAsesorExterno"].ToString());

                txtIngresa.Focus();
                
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();

            //Habilitar para imprimir
            btnImprimirDocumento.Enabled = true;
            cmdCobrar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtImporte.EditValue) == 0)
                {
                    XtraMessageBox.Show("El importe no puede ser 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.EditValue) < 0)
                {
                    XtraMessageBox.Show("El importe no puede ser menor a 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
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

        private void btnImprimirDocumento_Click(object sender, EventArgs e)
        {
            //Desactivar para Imprimir
            btnImprimirDocumento.Enabled = false;
            cmdCobrar.Enabled = false;

            if (IdPedido == 0)
            {
                XtraMessageBox.Show("Seleccione un pedido para cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intFacturado || Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVAnulado)
            {
                XtraMessageBox.Show("No se puede imprimir un pedido " + cboSituacion.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //PedidoBE objE_Pedido = null;
            //objE_Pedido = new PedidoBL().SeleccionaSituacion(IdPedido);//add 060116

            PedidoBE objE_Pedido = null;
            objE_Pedido = new PedidoBL().Selecciona(IdPedido);

            if (objE_Pedido != null)
            {
                if (objE_Pedido.IdSituacion != Parametros.intPVGenerado)
                {
                    XtraMessageBox.Show("El Pedido ya está facturado!, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cargar();
                    return;
                }

                //Diferencia de Totales
                if (objE_Pedido.Total != Convert.ToDecimal(txtTotal.EditValue))
                {
                    XtraMessageBox.Show("El total del Pedido es " + objE_Pedido.Total + " es diferente al actual "+ txtTotal.EditValue + ", Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cargar();
                    return;
                }

                //Diferencia de Totales
                if (objE_Pedido.Total != Convert.ToDecimal(txtTotal.EditValue))
                {
                    XtraMessageBox.Show("El total del Pedido es " + objE_Pedido.Total + " es diferente al actual " + txtTotal.EditValue + ", Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cargar();
                    return;
                }

                //Validar cuando es RER no permita boletearlo con cliente Mayorista
                //if (Parametros.intTiendaId == 1 && Parametros.intCajaId == 3)
                //{
                //    cboEmpresa.EditValue = 3;   //Corona
                //}

                //IdAsesorExterno = objE_Pedido.IdAsesorExterno; //add 090316
            }

            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intFacturado || Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVAnulado)
            {
                XtraMessageBox.Show("No se puede imprimir un pedido " + cboSituacion.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (IdTienda != Parametros.intTiendaId)
            {
                XtraMessageBox.Show("El Pedido pertenece a otra tienda, no se puede facturar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Mayor a 700
            decimal TotalImprimir = 0;
            string NumDocumento = objE_Pedido.NumeroDocumento;
            string NumDocumentoAsociado = objE_Pedido.NumeroDocumentoAsociado;
            TotalImprimir = objE_Pedido.Total;

            //string NumDocumento = gvPedido.GetFocusedRowCellValue("NumeroDocumento").ToString();
            //string NumDocumentoAsociado = gvPedido.GetFocusedRowCellValue("NumeroDocumentoAsociado").ToString();
            //TotalImprimir = decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());

            if (NumDocumento == Parametros.strNumeroCliente && TotalImprimir >= 700)
            {
                XtraMessageBox.Show("No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/700\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (NumeroDocumento.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura && txtDescClienteAsociado.Text == "") // Validar RUC DE ASOCIADO .. FALTA
            {
                XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NumeroDocumento.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica && txtDescClienteAsociado.Text == "") // Validar RUC DE ASOCIADO .. FALTA
            {
                XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region "Consulta RUC Data Local"
            //Boleta con RUC
            //if (NumDocumento.Trim().Length == 8 || NumDocumento.Trim().Length == 11)
            //{
            //    XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            string NumDocumentoFac = "";

            //Verificar si tiene asociado A Facturar
            if (txtDescClienteAsociado.Text == "")
                NumDocumentoFac = NumDocumento;
            else
                NumDocumentoFac = NumDocumentoAsociado;

            int TipoDocFact = Convert.ToInt32(cboDocumento.EditValue);
            if(TipoDocFact == Parametros.intTipoDocBoletaElectronica)
            {
                if (NumDocumentoFac.Trim().Length == 11)
                {
                    XtraMessageBox.Show("No se puede emitir una boleta con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (TipoDocFact == Parametros.intTipoDocFacturaElectronica)
            {
                if (NumDocumentoFac.Trim().Length == 11)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, NumDocumentoFac.Trim());
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
                    XtraMessageBox.Show("El RUC " + NumDocumentoFac + " no es válido, Por favor verificar que tenga 11 caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            #endregion

            // Obtiene los datos de la caja
            CajaEmpresaBE objCajaEmpresa = null;     
            objCajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId);

            if (objCajaEmpresa == null)
            {
                XtraMessageBox.Show("No se puede imprimir en esta Caja, pedido de " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //SerieRUS =  Convert.ToInt32(objCajaEmpresa.SerieBoleta);

            mListaDetalle = null;
            mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

            //add 250319 temporal
            #region "Agregar Promocion 2x1 y Otros" 
            bool bFlagPromocion2 = false;
            foreach(var item in mListaDetalle)
            {
                if(item.DescPromocion.Length>0)
                {
                    bFlagPromocion2 = true;
                    break;
                }
            }


            if(bFlagPromocion2)
            {
                mListaPedidoDetalleOrigen = mListaDetalle;
                CalculaTotalPromocion2x1_Total();
            }                
            #endregion


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
            if (IdEmpresa != Parametros.intEmpresaId) //Parametros.intIdPanoramaDistribuidores;
            {
                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo Rus
                    {
                        #region "Rus"

                        if (!objE_Pedido.FlagImpresionRus) //add 160216
                        {
                            XtraMessageBox.Show("No se puede imprimir una boleta RUS con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if (!ValidarTopeEmpresaRus()) //Mensual
                        {
                            if (!ValidarTopeEmpresaDiarioRus()) //Diario
                            {
                                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                                {
                                    // Validacion de cliente mayorista para RER
                                    if (objE_Pedido.IdTipoCliente == 87)
                                    {
                                        XtraMessageBox.Show("Solo puede emitir RER de " + cboEmpresa.Text.Trim() + "\n a Clientes Finales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Cargar();
                                        return;
                                    }

                                    // Validacion en RER si los productos exceden el descuento del 30%
                                    bool qValorReturn = ValidaPorcentajeDescuento();
                                    if (!qValorReturn)
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaRUSPorTipDoc(TipoDocFact);
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("No puede emitir RER con productos que contengan descuento \n mayores al 30%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    //Actualizamos la grilla
                                    Cargar();
                                    return;
                                }
                                else
                                {
                                    if (mListaDetalle.Count <= 6)
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaRUS();
                                        ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);

                                        //Actualizamos la grilla
                                        Cargar();

                                        return;
                                    }
                                    else
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaVariosRUS(6);
                                        ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);

                                        //Actualizamos la grilla
                                        Cargar();

                                        return;
                                    }
                                }
                            }
                            return;
                        }
                        return;

                        #endregion
                    }
                    else //RER Y REG
                    {
                        #region "RER"

                        if (!objE_Pedido.FlagImpresionRus) //add 160216
                        {
                            XtraMessageBox.Show("No se puede imprimir una boleta RER Y REG con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
                        //{
                        if (mListaDetalle.Count <= 6)
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVenta(IdEmpresa, "BOV");
                            ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);
                            Cargar();
                            return;

                        }
                        else
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaVarios(6, IdEmpresa, "BOV");
                            ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);
                            Cargar();
                            return;
                        }
                        //}

                        ////if (!ValidarTopeEmpresaRus()) //Mensual
                        ////{
                        ////    if (!ValidarTopeEmpresaDiarioRus()) //Diario
                        ////    {
                        //if (mListaDetalle.Count <= 6)
                        //        {
                        //            InsertarEstadoCuentaDiseñador();
                        //            InsertarDocumentoVentaRUS();
                        //            ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);

                        //            //Actualizamos la grilla
                        //            Cargar();

                        //            return;
                        //        }
                        //        else
                        //        {
                        //            InsertarEstadoCuentaDiseñador();
                        //            InsertarDocumentoVentaVariosRUS(6);
                        //            ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);

                        //            //Actualizamos la grilla
                        //            Cargar();

                        //            return;
                        //        }
                        ////    }
                        ////    return;
                        ////}
                        ////return;

                        #endregion
                    }
                }
            }




            ////bool qValorReturno = ProcesoBoleteoRER(objE_Pedido.FlagImpresionRus, objE_Pedido.IdTipoCliente, TipoDocFact, objCajaEmpresa.IdTipoFormato);

            ////if (!qValorReturno)
            ////{       
            ////        // REGIMEN GENERAL PANORAMA DISTRIBUIDORES
            ////        if (!objE_Pedido.FlagImpresionRus) //add 160216
            ////        {
            ////            XtraMessageBox.Show("No se puede imprimir una boleta RER Y REG con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////            return ;
            ////        }

            ////        if (mListaDetalle.Count <= 6)
            ////        {
            ////            InsertarEstadoCuentaDiseñador();
            ////            InsertarDocumentoVenta(13, "BOV");
            ////            ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);
            ////            Cargar();
            ////            return;

            ////        }
            ////        else
            ////        {
            ////            InsertarEstadoCuentaDiseñador();
            ////            InsertarDocumentoVentaVarios(6, 13, "BOV");
            ////            ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);
            ////            Cargar();
            ////            return;
            ////        }
            ////}

            //Obtener la serie del documento relacionado a la caja
            TalonBE objE_Talon = null;
                //objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                objE_Talon = new TalonBL().SeleccionaCajaDocumento(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
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

                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
                {
                    if (mListaDetalle.Count <= 6)
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta(IdEmpresa, "BOV");
                        ImpresionDirecta("BOV", objE_Talon.IdTipoFormato);
                    }
                    else
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVentaVarios(6, IdEmpresa, "BOV");
                        ImpresionDirecta("BOV", objE_Talon.IdTipoFormato);
                    }
                }

                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                {
                    //if (IdTipoDocumentoCliente == Parametros.intTipoDocumentoRUC)
                    if (IdTipoDocumentoCliente == Parametros.intTipoDocumentoRUC && IdTipoDocumentoClienteAsociado == 0)
                    {
                        if (mListaDetalle.Count <= 10)
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVenta(IdEmpresa, "FAV");
                            ImpresionDirecta("FAV", objE_Talon.IdTipoFormato);
                        }
                        else
                        {
                            //validar ruc
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaVarios(10, IdEmpresa, "FAV");
                            ImpresionDirecta("FAV", objE_Talon.IdTipoFormato);
                        }
                    }
                    else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoRUC)
                    {
                        if (mListaDetalle.Count <= 10)
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVenta(IdEmpresa, "FAV");
                            ImpresionDirecta("FAV", objE_Talon.IdTipoFormato);
                        }
                        else
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaVarios(10, IdEmpresa, "FAV");
                            ImpresionDirecta("FAV", objE_Talon.IdTipoFormato);
                        }
                    }

                    else
                    {
                        XtraMessageBox.Show("No se puede facturar a un cliente con DNI, por favor verifique el pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta)
                {
                    InsertarEstadoCuentaDiseñador();
                    InsertarDocumentoVenta(IdEmpresa, "TKV");
                    ImpresionDirecta("TKV", objE_Talon.IdTipoFormato);
                }
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                {
                    if (IdTipoDocumentoCliente == Parametros.intTipoDocumentoRUC && IdTipoDocumentoClienteAsociado == 0) //Add 050615
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta(IdEmpresa, "TKF");
                        ImpresionDirecta("TKF", objE_Talon.IdTipoFormato);
                    }
                    else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoRUC)
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta(IdEmpresa, "TKF");
                        ImpresionDirecta("TKF", objE_Talon.IdTipoFormato);
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede facturar a un cliente con DNI, por favor verifique el pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                /// Boleta de panorama
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                {
                    #region "Diferencia cabecera vs detalle"
                    if (objE_Pedido.TotalDiferencia != 0)
                    {
                        XtraMessageBox.Show("No se puede generar un comprobante electrónico\nLa suma de cabecera y detalle tiene diferencia de:" + objE_Pedido.TotalDiferencia.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    InsertarEstadoCuentaDiseñador();
                    InsertarDocumentoVenta(IdEmpresa, "TEB");
                    //ImpresionDirecta("TEB", objE_Talon.IdTipoFormato);
                }

                // Factura electronica
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                {
                    #region "Diferencia cabecera vs detalle"
                    if (objE_Pedido.TotalDiferencia != 0)
                    {
                        XtraMessageBox.Show("No se puede generar un comprobante electrónico\nLa suma de cabecera y detalle tiene diferencia de:" + objE_Pedido.TotalDiferencia.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    if (IdTipoDocumentoCliente == Parametros.intTipoDocumentoRUC && IdTipoDocumentoClienteAsociado == 0) //Add 050615
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta(IdEmpresa, "TEF");
                        //ImpresionDirecta("TEF", objE_Talon.IdTipoFormato);
                    }
                    else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoRUC)
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta(IdEmpresa, "TEF");
                        //ImpresionDirecta("TEF", objE_Talon.IdTipoFormato);
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede facturar a un cliente con DNI, por favor verifique el pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocGuiaRemision)
                {
                    ImpresionDirecta("G/R", objE_Talon.IdTipoFormato);
                }
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)
                {
                    ImpresionDirecta("NCV", objE_Talon.IdTipoFormato);
                }
                LimpiarTextos();
            //Actualizar Despacho
            //Actualizamos la grilla
            Cargar();

            btnConsultar.Focus();
        }

        #region "PROCESO BOLETEO RER"
        private bool ProcesoBoleteoRER(Boolean parFlagImpresionRus, int parIdTipoCliente, int parTipoDocFact, int parIdTipoFormato)
        {
            //mListaEmpresasRER = null;
            //mListaEmpresasRER = new CajaEmpresaBL().Selecciona(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId);

            ////add 250319 temporal
            //#region "Agregar Promocion 2x1 y Otros" 
            //bool bFlagPromocion2 = false;
            //foreach (var item in mListaEmpresasRER)
            //{
            //    if (item.DescPromocion.Length > 0)
            //    {
            //        bFlagPromocion2 = true;
            //        break;
            //    }
            //}

            // Obtiene los datos de la caja
            //CajaEmpresaBE objCajaEmpresa = null;
            //objCajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId);

            //if (objCajaEmpresa == null)
            //{
            //    XtraMessageBox.Show("No se puede imprimir en esta Caja, pedido de " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            ////

            bool flagReturn = false;

            EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo Rus
                    {
                        #region "Rus"

                        if (!parFlagImpresionRus) //add 160216
                        {
                            XtraMessageBox.Show("No se puede imprimir una boleta RUS con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return flagReturn;
                        }

                        if (!ValidarTopeEmpresaRus()) //Mensual
                        {
                            if (!ValidarTopeEmpresaDiarioRus()) //Diario
                            {
                                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                                {
                                    // Validacion de cliente mayorista para RER
                                    if (parIdTipoCliente == 87)
                                    {
                                       // XtraMessageBox.Show("Solo puede emitir RER de " + cboEmpresa.Text.Trim() + "\n a Clientes Finales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Cargar();
                                    return flagReturn;
                                }

                                    // Validacion en RER si los productos exceden el descuento del 30%
                                    bool qValorReturn = ValidaPorcentajeDescuento();
                                    if (!qValorReturn)
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaRUSPorTipDoc(parTipoDocFact);
                                    Cargar();
                                    return true;
                                }
                                    else
                                    {
                                        XtraMessageBox.Show("No puede emitir RER con productos que contengan descuento \n mayores al 30%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //Actualizamos la grilla
                                    Cargar();
                                    return flagReturn;
                                }

                                }
                                else
                                {
                                    if (mListaDetalle.Count <= 6)
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaRUS();
                                        ImpresionDirecta("BOV", parIdTipoFormato);

                                        //Actualizamos la grilla
                                        Cargar();

                                        return true;
                                    }
                                    else
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaVariosRUS(6);
                                        ImpresionDirecta("BOV", parIdTipoFormato);

                                        //Actualizamos la grilla
                                        Cargar();

                                        return true;
                                    }
                                }
                            }
                            return flagReturn;
                        }
                        return flagReturn;

                        #endregion
                    }
                }

            return flagReturn;
        }
        #endregion


        private void txtIngresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToDecimal(txtTotal.Text) > 0)
            {
                if (e.KeyCode == Keys.F8)
                {
                    if (btnImprimirDocumento.Enabled == false)
                    { 
                        XtraMessageBox.Show("Actualizar antes de Cobrar, Clic en Consultar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (IdPedido == 0)
                    {
                        XtraMessageBox.Show("Seleccione un pedido para cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaSituacion(IdPedido);//add 060116

                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.IdSituacion != Parametros.intPVGenerado)
                        {
                            XtraMessageBox.Show("El Pedido ya está facturado!, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cargar();
                            return;
                        }

                        //Diferencia de Totales
                        if (objE_Pedido.Total != Convert.ToDecimal(txtTotal.EditValue))
                        {
                            XtraMessageBox.Show("El total del Pedido es " + objE_Pedido.Total + " es diferente al actual " + txtTotal.EditValue + ", Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cargar();
                            return;
                        }
                    }

                    if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intFacturado || Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVAnulado)
                    {
                        XtraMessageBox.Show("No se puede imprimir un pedido " + cboSituacion.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (IdTienda != Parametros.intTiendaId)
                    {
                        XtraMessageBox.Show("El Pedido pertenece a otra tienda, no se puede facturar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    CajaEmpresaBE objCajaEmpresa = null;
                    objCajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId);

                    if (objCajaEmpresa == null)
                    {
                        XtraMessageBox.Show("No se puede imprimir en esta Caja, pedido de " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //SerieRUS = Convert.ToInt32(objCajaEmpresa.SerieBoleta);

                    mListaDetalle = null;
                    mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

                    //add 250319 temporal
                    #region "Agregar Promocion 2x1 y Otros" 
                    bool bFlagPromocion2 = false;
                    foreach (var item in mListaDetalle)
                    {
                        if (item.DescPromocion.Length > 0)
                        {
                            bFlagPromocion2 = true;
                            break;
                        }
                    }
                    if (bFlagPromocion2)
                    {
                        mListaPedidoDetalleOrigen = mListaDetalle;
                        CalculaTotalPromocion2x1_Total();
                        objE_Pedido.TotalDiferencia = 0;
                    }

                    #endregion


                    frmMsgPagoCondicion frmMsgPago = new frmMsgPagoCondicion();
                    frmMsgPago.NumeroPedido = lblPedido.Text;
                    frmMsgPago.IdEmpresa = IdEmpresa;
                    frmMsgPago.NumeroDocumento = gvPedido.GetFocusedRowCellValue("NumeroDocumento").ToString();
                    frmMsgPago.DescCliente = gvPedido.GetFocusedRowCellValue("DescCliente").ToString();
                    frmMsgPago.Total = decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());
                    frmMsgPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    frmMsgPago.IdCliente = IdCliente;
                    frmMsgPago.IdTipoCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoCliente").ToString());
                    frmMsgPago.IdTipoDocumentoClienteAsociado = IdTipoDocumentoClienteAsociado;
                    frmMsgPago.IdPedido = IdPedido;
                    frmMsgPago.ShowDialog();

                    if (frmMsgPago.DialogResult == DialogResult.OK)
                    {
                        IdEmpresa = frmMsgPago.IdEmpresa;
                        cboEmpresa.EditValue = IdEmpresa;
                        NumeroCupon = frmMsgPago.NumeroCupon;
                        Cupon = frmMsgPago.Cupon;

                        //Validar cuando es RER no permita boletearlo con cliente Mayorista
                        if (Convert.ToInt32(cboEmpresa.EditValue) == 3 || Convert.ToInt32(cboEmpresa.EditValue) == 19 || Convert.ToInt32(cboEmpresa.EditValue) == 21 || 
                            Convert.ToInt32(cboEmpresa.EditValue) == 23 || Convert.ToInt32(cboEmpresa.EditValue) == 8 || Convert.ToInt32(cboEmpresa.EditValue) == 20)
                        {
                            if (frmMsgPago.IdTipoCliente == 87)
                            {
                                XtraMessageBox.Show("Solo puede emitir RER de " + cboEmpresa.Text.Trim() + "\n a Clientes Finales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Cargar();
                                return;
                            }
                        }

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

                        EmpresaBE objE_Empresa = null;
                        objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);


                        if (IdEmpresa != Parametros.intEmpresaId)
                        {
                            if (objE_Empresa != null)
                            {
                                if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo Rus
                                {
                                    #region "RUS"
                                    if (!objE_Pedido.FlagImpresionRus) //add 160216
                                    {
                                        XtraMessageBox.Show("No se puede imprimir una boleta RUS con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }

                                    if (!ValidarTopeEmpresaRus()) //Mensual
                                    {
                                        if (!ValidarTopeEmpresaDiarioRus()) //Diario
                                        {
                                            if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                                            {
                                                // Validacion en RER si los productos exceden el descuento del 30%
                                                bool qValorReturn = ValidaPorcentajeDescuento();
                                                if (!qValorReturn)
                                                {
                                                    InsertarEstadoCuentaDiseñador();
                                                    InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, frmMsgPago.TipoDocBolFac);
                                                }
                                                else
                                                {
                                                    XtraMessageBox.Show("No puede emitir RER con productos que contengan descuento \n mayores al 30%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                }
                                                Cargar();
                                                return;
                                            }
                                            else
                                            {
                                                if (mListaDetalle.Count <= 6)
                                                {
                                                    //InsertarDocumentoVentaRUS();
                                                    InsertarEstadoCuentaDiseñador();
                                                    InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, frmMsgPago.TipoDocBolFac);
                                                    ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);

                                                    //Actualizamos la grilla
                                                    Cargar();

                                                    return;
                                                }
                                                else
                                                {
                                                    //InsertarDocumentoVentaVariosRUS(6);
                                                    InsertarEstadoCuentaDiseñador();
                                                    InsertarDocumentoVentaVariosPagoVariosRUS(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster);
                                                    ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);

                                                    //Actualizamos la grilla
                                                    Cargar();

                                                    return;
                                                }
                                            }
                                        }
                                        return;
                                    }
                                    return;
                                    #endregion
                                }
                                else
                                {
                                    #region "RER"

                                    if (!objE_Pedido.FlagImpresionRus) //add 160216
                                    {
                                        XtraMessageBox.Show("No se puede imprimir una boleta RER Y REG con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }

                                    ////if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA

                                    if (mListaDetalle.Count <= 6)
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa,"BOV");
                                        ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);
                                        Cargar();

                                        return;
                                    }
                                    else
                                    {
                                        InsertarEstadoCuentaDiseñador();
                                        InsertarDocumentoVentaVariosPagoVarios(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa,"BOV");
                                        ImpresionDirecta("BOV", objCajaEmpresa.IdTipoFormato);
                                        Cargar();

                                        return;
                                    }

                                    #endregion
                                }
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
                            if (mListaDetalle.Count <= 6)
                            {
                                InsertarEstadoCuentaDiseñador();
                                InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                                ImpresionDirecta("BOV", objE_Talon.IdTipoFormato);
                            }
                            else
                            {
                                InsertarEstadoCuentaDiseñador();
                                InsertarDocumentoVentaVariosPagoVarios(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                                ImpresionDirecta("BOV", objE_Talon.IdTipoFormato);
                            }
                        }

                        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                        {
                            if (mListaDetalle.Count <= 10)
                            {
                                InsertarEstadoCuentaDiseñador();
                                InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                                ImpresionDirecta("FAV", objE_Talon.IdTipoFormato);
                            }
                            else
                            {
                                InsertarEstadoCuentaDiseñador();
                                InsertarDocumentoVentaVariosPagoVarios(10, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                                ImpresionDirecta("FAV", objE_Talon.IdTipoFormato);
                            }
                        }

                        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketBoleta)
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                            ImpresionDirecta("TKV", objE_Talon.IdTipoFormato);
                        }

                        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketFactura)
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                            ImpresionDirecta("TKF", objE_Talon.IdTipoFormato);
                        }

                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                        {
                            #region "Diferencia cabecera vs detalle"
                            if (objE_Pedido.TotalDiferencia != 0 && objE_Pedido.Descuento==0)
                            {
                                XtraMessageBox.Show("No se puede generar un comprobante electrónico\nLa suma de cabecera y detalle tiene diferencia de:" + objE_Pedido.TotalDiferencia.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            #endregion

                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                            //InsertarDocumentoVenta(IdEmpresa, "TEB");
                        }
                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                        {
                            #region "Diferencia cabecera vs detalle"
                            if (objE_Pedido.TotalDiferencia != 0)
                            {
                                XtraMessageBox.Show("No se puede generar un comprobante electrónico\nLa suma de cabecera y detalle tiene diferencia de:" + objE_Pedido.TotalDiferencia.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            #endregion

                            if (IdTipoDocumentoCliente == Parametros.intTipoDocumentoRUC && IdTipoDocumentoClienteAsociado == 0) //Add 050615
                            {
                                InsertarEstadoCuentaDiseñador();
                                InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                                //InsertarDocumentoVenta(IdEmpresa, "TEF");
                            }
                            else if (IdTipoDocumentoClienteAsociado == Parametros.intTipoDocumentoRUC)
                            {
                                InsertarEstadoCuentaDiseñador();
                                InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.IdDocumentoNC, frmMsgPago.IdTipoMaster, IdEmpresa, TipoDoc);
                                //InsertarDocumentoVenta(IdEmpresa, "TEF");
                            }
                            else
                            {
                                XtraMessageBox.Show("No se puede facturar a un cliente con DNI, por favor verifique el pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    LimpiarTextos();

                    //Actualizamos la grilla
                    Cargar();
                }
            }
            else
            {
                XtraMessageBox.Show("No se puede cobrar un pedido con monto cero, Seleccionar un pedido ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescCliente_KeyUp(object sender, KeyEventArgs e)
        {
            CargarCliente();
        }

        private void cmdCobrar_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDateTime(DateTime.Now.ToShortDateString()) >= Convert.ToDateTime("01/11/2018"))
            //{
            //    XtraMessageBox.Show("A partir de la fecha no se puede emitir una boleta manual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            //Desactivar para Imprimir
            btnImprimirDocumento.Enabled = false;
            cmdCobrar.Enabled = false;

            if (IdPedido == 0)
            {
                XtraMessageBox.Show("Seleccione un pedido para cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intFacturado)
            {
                XtraMessageBox.Show("No se puede imprimir un pedido " + cboSituacion.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PedidoBE objE_Pedido = null;
            objE_Pedido = new PedidoBL().SeleccionaSituacion(IdPedido);//add 060116

            if (objE_Pedido != null)
            {
                if (objE_Pedido.IdSituacion != Parametros.intPVGenerado)
                {
                    XtraMessageBox.Show("El Pedido ya está facturado!, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cargar();
                    return;
                }

                //Diferencia de Totales
                if (objE_Pedido.Total != Convert.ToDecimal(txtTotal.EditValue))
                {
                    XtraMessageBox.Show("El total del Pedido es " + objE_Pedido.Total + " es diferente al actual " + txtTotal.EditValue + ", Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Cargar();
                    return;
                }

                IdAsesorExterno = objE_Pedido.IdAsesorExterno; //add 090316
            }


            mListaDetalle = null;
            mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

            if (mListaDetalle.Count <= 6)
            {
                frmRazonSocialEmisora frmEmpresaEmisora = new frmRazonSocialEmisora();
                frmEmpresaEmisora.Total = decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());
                if (frmEmpresaEmisora.ShowDialog() == DialogResult.OK)
                {
                    InsertarDocumentoVentaEmpresa(frmEmpresaEmisora.IdTipoDocumento, frmEmpresaEmisora.IdEmpresa, frmEmpresaEmisora.Serie, frmEmpresaEmisora.Numero, frmEmpresaEmisora.Fecha);
                }
            }
            else
            {
                if (XtraMessageBox.Show("El Pedido seleccionado va a generar  mas ( 1 (una) boletas de ventas) \n Estas seguro(a) de realizarlo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmRazonSocialEmisora frmEmpresaEmisora = new frmRazonSocialEmisora();
                    frmEmpresaEmisora.Total = decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());
                    if (frmEmpresaEmisora.ShowDialog() == DialogResult.OK)
                    {
                        InsertarDocumentoVentaVariosEmpresa(6, frmEmpresaEmisora.IdTipoDocumento, frmEmpresaEmisora.IdEmpresa, frmEmpresaEmisora.Serie, frmEmpresaEmisora.Numero, frmEmpresaEmisora.Fecha);
                    }
                }
            }

            LimpiarTextos();
            //Actualizamos la grilla
            Cargar();
            btnConsultar.Focus();

        }

        private void btnActualizarDocumentoVenta_Click(object sender, EventArgs e)
        {
            if (IdPedido == 0)
            {
                XtraMessageBox.Show("Seleccione un pedido para cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intFacturado)
            {
                frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                objVentaPedido.IdPedido = IdPedido;
                objVentaPedido.NumeroPedido = lblPedido.Text;
                objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                objVentaPedido.Show();
            }
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(IdEmpresa, Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
        }

        private void btnVentaTope_Click(object sender, EventArgs e)
        {
            frmConVentasEmpresaFecha frm = new frmConVentasEmpresaFecha();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void cboEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                txtIngresa_KeyDown(sender, e);
            }
        }

        private void gvPedido_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedido.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FlagImpresionRus"]);
                    if (objDocRetiro != null)
                    {
                        bool FlagImpresionRus = Convert.ToBoolean(objDocRetiro);

                        if (!FlagImpresionRus)//Parametros.intCajaId)
                        {
                            e.Appearance.BackColor = Color.LawnGreen;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPedido_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }


        #endregion

        #region "Metodos"

        private void LimpiarTextos()
        {
            txtTotal.EditValue = 0;
            txtIngresa.EditValue = 0;
            txtVuelto.EditValue = 0;

            txtImporte.EditValue = 0;
            txtTotalResumen.EditValue = 0;
            txtResta.EditValue = 0;
            IdPedido = 0;

            mListaDocumentoVentaPagoOrigen.Clear();
            bsListadoPago.DataSource = mListaDocumentoVentaPagoOrigen;
            gcDocumentoVentaPago.DataSource = bsListadoPago;
            gcDocumentoVentaPago.RefreshDataSource();
        }

        private void InsertarDocumentoVenta(int IdEmpresaGenera, string TipoDoc)
        {
            try
            {
                //Traemos la información del pedido.
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);


                //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                //{
                //    if (objE_Pedido.NumeroDocumento.Length != 11)
                //    {
                //        XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        Cursor = Cursors.Default;
                //        return;
                //    }

                //}

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido;
                objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                objDocumentoVenta.Mes = objE_Pedido.Mes;
                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                if (IdEmpresaGenera == Parametros.intEmpresaId)
                {
                    //Obtener la serie del documento relacionado a la caja
                    TalonBE objE_Talon = null;
                    objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                    if (objE_Talon != null)
                    {
                        Serie = "";
                        Serie = objE_Talon.NumeroSerie;
                        //IdTamanoHoja = objE_Talon.IdTamanoHoja;
                    }

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Serie);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    }

                    //Verificar Número de Documento
                    #region "Verificar Número"

                    DocumentoVentaBE objE_DocumentoVentaSerie = null;
                    objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(IdEmpresaGenera, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                    if (objE_DocumentoVentaSerie != null)
                    {
                        XtraMessageBox.Show("El documento "+ objE_DocumentoVentaSerie.CodTipoDocumento + ":" + Serie +"-"+ Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    #endregion

                }
                else
                {
                    CajaEmpresaBE objE_CajaEmpresa = new CajaEmpresaBE();
                    objE_CajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresaGenera, Parametros.intTiendaId, Parametros.intCajaId);

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresaGenera, Parametros.intTipoDocBoletaVenta, objE_CajaEmpresa.SerieBoleta);
                    if (mListaNumero.Count > 0)
                    {
                        Serie = mListaNumero[0].Serie;
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    }
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                //Verificar si tiene asociado A Facturar
                if (objE_Pedido.IdClienteAsociado == 0)
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                }
                else
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                    objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                }
                //-----------------------------
                //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                objDocumentoVenta.TotalCantidad = objE_Pedido.TotalCantidad;
                objDocumentoVenta.SubTotal = objE_Pedido.SubTotal;
                objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                objDocumentoVenta.Igv = objE_Pedido.Igv;
                objDocumentoVenta.Icbper = objE_Pedido.Icbper;
                objDocumentoVenta.Total = objE_Pedido.Total;
                objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresaGenera;//Parametros.intEmpresaId;
                objDocumentoVenta.IdAlmacen = IdAlmacen;
                objDocumentoVenta.IdTipoCliente = Int32.Parse( gvPedido.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDetalle)
                {
                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = IdEmpresaGenera;// item.IdEmpresa;
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
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//Convert.ToInt32(cboDocumento.EditValue);
                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.IdPedido = IdPedido;
                objE_MovimientoCaja.FlagEstado = true;
                objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;//Parametros.intEmpresaId;


                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count == 0)
                {
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = IdEmpresaGenera;//objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//Convert.ToInt32(cboDocumento.EditValue);
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
                        objE_DocumentoVentaPago.IdEmpresa = IdEmpresaGenera;//objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                        objE_DocumentoVentaPago.Fecha = item.Fecha;
                        objE_DocumentoVentaPago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// item.IdTipoDocumento;
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
                    int IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                    if (chkDespachar.Checked) GrabarDespacho();


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

                    #region "Envío e Impresión de Comprobante electrónico"
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineBoletaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresaGenera, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresaGenera, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora,  IdEmpresaGenera);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }

                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineFacturaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresaGenera, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresaGenera, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresaGenera);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }
                    #endregion

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

        private void InsertarDocumentoVentaVarios(int items, int IdEmpresaGenera, string TipoDoc)
        {
            try
            {
                int Contador = 0;

                if (mListaDetalle.Count % items == 0)
                {
                    Contador = mListaDetalle.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDetalle.Count / items) + 1);
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

                    for (int y = fila; y < mListaDetalle.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = IdEmpresaGenera;//mListaDetalle[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDetalle[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDetalle[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDetalle[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDetalle[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDetalle[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDetalle[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDetalle[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDetalle[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDetalle[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDetalle[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDetalle[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDetalle[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDetalle[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDetalle[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDetalle[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDetalle[row].IdPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDetalle[row].TipoOper;
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
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                    //{
                    //    if (objE_Pedido.NumeroDocumento.Length != 11)
                    //    {
                    //        XtraMessageBox.Show("No se puede generar factura a un número de ruc no válido, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        Cursor = Cursors.Default;
                    //        return;
                    //    }

                    //}

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                    objDocumentoVenta.Mes = objE_Pedido.Mes;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    if (IdEmpresaGenera == Parametros.intEmpresaId)
                    {
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


                        //Verificar Número de Documento
                        #region "Verificar Número"

                        DocumentoVentaBE objE_DocumentoVentaSerie = null;
                        objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(IdEmpresaGenera, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                        if (objE_DocumentoVentaSerie != null)
                        {
                            XtraMessageBox.Show("El documento "+ TipoDoc +":" + Serie +"-"+ Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        #endregion
                    }
                    else
                    {
                        CajaEmpresaBE objE_CajaEmpresa = new CajaEmpresaBE();
                        objE_CajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresaGenera, Parametros.intTiendaId, Parametros.intCajaId);

                        //Obtener el numero del documento relacionado a la serie
                        List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresaGenera, Parametros.intTipoDocBoletaVenta, objE_CajaEmpresa.SerieBoleta);
                        if (mListaNumero.Count > 0)
                        {
                            Serie = mListaNumero[0].Serie;
                            Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                        }
                        objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                    }

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                    //Verificar si tiene asociado A Facturar
                    if (objE_Pedido.IdClienteAsociado == 0)
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                        objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    }
                    else
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                        objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                    }
                    //-----------------------------
                    //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                    objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                    objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                    objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                    objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                    objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = 0;//objE_Pedido.TotalBruto;
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresaGenera;//Parametros.intEmpresaId;
                    objDocumentoVenta.IdAlmacen = IdAlmacen;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = deTotal;
                    objE_MovimientoCaja.ImporteDolares = deTotal / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;// Parametros.intEmpresaId;

                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                    {
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = IdEmpresaGenera;// Parametros.intEmpresaId;
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//Convert.ToInt32(cboDocumento.EditValue);
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
                            objE_DocumentoVentaPago.IdEmpresa = IdEmpresaGenera;// item.IdEmpresa;
                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                            objE_DocumentoVentaPago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// item.IdTipoDocumento;
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
                        objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();
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

        private void ImpresionDirecta(String TipoDoc, Int32 TipoFormato)  //REVISAR AQUI EL FORMATO//////////************************
        {
            try
            {
                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                {
                    dirFacturacion = Parametros.strDireccionUcayali2;
                }
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                {
                    dirFacturacion = Parametros.strDireccionUcayali3;
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
                if (Parametros.intTiendaId == Parametros.intTiendaAviacion2)
                {
                    dirFacturacion = Parametros.strDireccionAviacion2;
                }

                if (TipoDoc == "TKV")
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

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


                    if(objTalon.FlagAbrirCajon == true)ticket.AbreCajon();  //abre el cajon
                    //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                    //ticket.TextoCentro(dirFacturacion);
                    //ticket.TextoCentro("RUC: 20330676826");
                    ticket.TextoCentro(Parametros.strEmpresaNombre);
                    ticket.TextoCentro(objTalon.DireccionFiscal);
                    if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                    ticket.TextoCentro(Parametros.strEmpresaRuc);
                    ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                    ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                    ticket.TextoIzquierda(cboDocumento.Text + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                    ticket.TextoIzquierda("CLIENTE: " + lstReporte[0].DescCliente);
                    ticket.LineasGuion();
                    ticket.EncabezadoVenta();

                    foreach (var item in lstReporte)
                    {
                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                        //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(item.ValorVenta));
                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    }
                    ticket.LineasTotales();
                    if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                    { 
                        ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                        ticket.AgregaTotales("Descuento", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    }
                    ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(lstReporte[0].Total), 2)); // imprime linea con total
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                    ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                    ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("www.panoramadistribuidores.com");
                    ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                    if (lstReporte[0].IdPromocionProxima > 0)
                    {
                        //ticket.CortaTicket();
                        ticket.TextoCentro("=========================================");
                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                        ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                        ticket.TextoCentro("=========================================");
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

                    #region "Ticket Formato 1"

                    /*--------------------------------------------------------------------------------------
                                        List<ReporteDocumentoVentaBE> lstReporte = null;
                                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                                        TalonBE objTalon = null;
                                        objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                                        Ticket ticket = new Ticket();

                                        ticket.AddHeaderLine("               PANORAMA DISTRIBUIDORES");
                                        ticket.AddHeaderLine("                  " + dirFacturacion);
                                        ticket.AddHeaderLine("                     RUC: 20330676826");
                                        ticket.AddHeaderLine("                    AUT: " + objTalon.NumeroAutoriza);
                                        ticket.AddHeaderLine("                    SERIE: " + objTalon.SerieImpresora);


                                        ticket.AddSubHeaderLine(cboDocumento.Text + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                        //ticket.AddSubHeaderLine("CAJA: " + Parametros.strUsuarioLogin);
                                        ticket.AddSubHeaderLine("VENDEDOR: " + lstReporte[0].DescVendedor);
                                        ticket.AddSubHeaderLine("CLIENTE: " + lstReporte[0].DescCliente);//cliente

                                        foreach (var item in lstReporte)
                                        {
                                            ticket.AddItem(Convert.ToString(item.Cantidad), Convert.ToString(item.Abreviatura) + "  " + Convert.ToString(item.CodigoProveedor), Convert.ToString(Math.Round(item.PrecioVenta, 2)) + "  " + Convert.ToString(Math.Round(item.ValorVenta, 2)));
                                            ticket.AddItem("", item.NombreProducto, "");
                                        }

                                        ticket.AddTotal("                    TOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal(txtTotal.EditValue), 2)));

                                        ticket.AddFooterLine("                  ped: " + lstReporte[0].NumeroPedido);
                                        ticket.AddFooterLine("                  caja: " + Parametros.strUsuarioLogin);

                                        ticket.AddFooterLine("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                        ticket.AddFooterLine("             CAMBIOS NI DEVOLUCIONES");

                                        ticket.AddFooterLine("               GRACIAS POR SU COMPRA");
                                        ticket.AddFooterLine("      WWW.PANORAMADISTRIBUIDORES.COM");

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

                                            if (printer.ToUpper().StartsWith("(T)"))
                                            {
                                                found = true;
                                                ticket.PrintTicket(@printer);
                                            }
                                        }*/
                    #endregion
                }
                else if (TipoDoc == "TKF")
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

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

                    ticket.AbreCajon();  //abre el cajon
                    //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                    //ticket.TextoCentro(dirFacturacion);
                    //ticket.TextoCentro("RUC: 20330676826");
                    ticket.TextoCentro(Parametros.strEmpresaNombre);
                    ticket.TextoCentro(objTalon.DireccionFiscal);
                    if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                    ticket.TextoCentro(Parametros.strEmpresaRuc);
                    ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                    ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);

                    ticket.TextoIzquierda(cboDocumento.Text + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                    ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                    ticket.TextoIzquierda("RUC: " + lstReporte[0].NumeroDocumento);
                    ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                    ticket.LineasGuion();
                    ticket.EncabezadoVenta();

                    foreach (var item in lstReporte)
                    {
                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                        //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20) , Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    }
                    ticket.LineasTotales();
                    if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                    {
                        ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                        ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total)*-1, 2));
                    }
                    ticket.AgregaTotales("SubTotal", Math.Round(Convert.ToDouble(lstReporte[0].SubTotal), 2));
                    ticket.AgregaTotales("IGV", Math.Round(Convert.ToDouble(lstReporte[0].Igv), 2));
                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].Total), 2));
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                    ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                    ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("www.panoramadistribuidores.com");
                    ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                    if (lstReporte[0].IdPromocionProxima > 0)
                    {
                        //ticket.CortaTicket();
                        ticket.TextoCentro("=========================================");
                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                        ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                        ticket.TextoCentro("=========================================");
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

                    #region "Ticket Formato 1"
                    /*
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        Ticket ticket = new Ticket();

                        ticket.AddHeaderLine("               PANORAMA DISTRIBUIDORES");
                        ticket.AddHeaderLine("                  " + dirFacturacion);
                        ticket.AddHeaderLine("                     RUC: 20330676826");
                        ticket.AddHeaderLine("                    AUT: " + objTalon.NumeroAutoriza);
                        ticket.AddHeaderLine("                    SERIE: " + objTalon.SerieImpresora);

                        ticket.AddSubHeaderLine(cboDocumento.Text + Serie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.AddSubHeaderLine("VENDEDOR: " + lstReporte[0].DescVendedor);
                        ticket.AddSubHeaderLine("CLIENTE: " + lstReporte[0].DescCliente);
                        ticket.AddSubHeaderLine("RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.AddSubHeaderLine("DIRECCION : " + lstReporte[0].Direccion);

                        foreach (var item in lstReporte)
                        {
                            ticket.AddItem(Convert.ToString(item.Cantidad), Convert.ToString(item.Abreviatura) + "  " + Convert.ToString(item.CodigoProveedor), Convert.ToString(Math.Round(item.PrecioVenta, 2)) + "  " + Convert.ToString(Math.Round(item.ValorVenta, 2)));
                            ticket.AddItem("", item.NombreProducto, "");
                        }


                        ticket.AddTotal("                    SUBTOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal(lstReporte[0].SubTotal), 2)));
                        ticket.AddTotal("                    IGV", Convert.ToString(Math.Round(Convert.ToDecimal(lstReporte[0].Igv), 2)));
                        ticket.AddTotal("                    TOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal(txtTotal.EditValue), 2)));

                        ticket.AddFooterLine("                  ped: " + lstReporte[0].NumeroPedido);
                        ticket.AddFooterLine("                  caja: " + Parametros.strUsuarioLogin);

                        ticket.AddFooterLine("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                        ticket.AddFooterLine("             CAMBIOS NI DEVOLUCIONES");

                        ticket.AddFooterLine("         GRACIAS POR SU COMPRA");
                        ticket.AddFooterLine("    WWW.PANORAMADISTRIBUIDORES.COM");

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

                            if (printer.ToUpper().StartsWith("(T)"))
                            {
                                found = true;
                                ticket.PrintTicket(@printer);
                            }
                        }*/
                    #endregion
                }
                else if (TipoDoc == "BOV" && TipoFormato == Parametros.intTipoFormatoDesglosable)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                        rptBoletaPanoramaDesglosable objReporteGuia = new rptBoletaPanoramaDesglosable();
                        objReporteGuia.SetDataSource(lstReporte);
                        //objReporteGuia.PrintOptions.PrinterName = @"EPSON FX-890 ESC/P";
                        //objReporteGuia.PrintToPrinter(1, false, 0, 0);

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
                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    }
                else if (TipoDoc == "BOV" && TipoFormato == Parametros.intTipoFormatoContinuo)
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    if (IdTienda == 11)
                    {
                        //MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");
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
                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);

                    }
                    else
                    {
                            rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
                            objReporteGuia.SetDataSource(lstReporte);
                        //objReporteGuia.PrintOptions.PrinterName = @"EPSON FX-890 ESC/P";
                        //objReporteGuia.PrintToPrinter(1, false, 0, 0);

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
                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");
                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    }


                        }
                else if (TipoDoc == "FAV")
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

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
                                MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
                        }
                else if (TipoDoc == "G/R")//GUIA DE REMISION
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                                rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();
                                objReporteGuia.SetDataSource(lstReporte);
                                objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
                                objReporteGuia.PrintOptions.PrinterName = @"EPSON FX-890 ESC/P";
                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
                            }
                else if (TipoDoc == "NCV")//NOTACREDITO
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                                    rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
                                    objReporteNotaCredito.SetDataSource(lstReporte);

                                    objReporteNotaCredito.PrintOptions.PrinterName = @"EPSON FX-890 ESC/P";
                                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                                }

                if (!chkDespachar.Checked)
                {
                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.ActualizaSituacion(Parametros.intEmpresaId, IdPedido, Parametros.intFacturado, 0, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                }else
                {
                    chkDespachar.Checked = false;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar()
        {
            dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaContado(0, Parametros.intTiendaId, deFecha.DateTime, Convert.ToInt32(cboSituacion.EditValue)));
            gcPedido.DataSource = dtPedido;
            CargarTipoDocumentoPorDefecto();

            cboCondicionPago.EditValue = Parametros.intEfectivo;//por default 170616
            CodigoNC = "";
        }

        private void CargarTipoDocumentoPorDefecto()
        {
            //cboDocumento.EditValue = Parametros.intTipoDocBoletaVenta;
            //cboDocumento.EditValue = Parametros.intTipoDocTicketBoleta;
            BSUtils.LoaderLook(cboDocumento, new TalonBL().ListaCaja(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intCajaId), "CodTipoDocumento", "IdTipoDocumento", true);
        }

        private void CargarCliente()
        {
            DataView dvPedido = new DataView(dtPedido);
            dvPedido.RowFilter = "DescCliente LIKE  '%' + '" + txtDescCliente.Text.Trim() + "' + '%'";
            gcPedido.DataSource = dvPedido.ToTable();
        }


        private bool ValidarTopeEmpresaRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total = decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());

            /*if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }*/

            if (Convert.ToInt32(cboEmpresa.EditValue) != Parametros.intPanoraramaDistribuidores)
            {
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));

                decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.Tope;
                    //Parametros.dmlTopeEmpresaDiarioRUS = objE_TopeEmpresa.TopeDiario;//add 07012016
                }

                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaPeriodo(Convert.ToInt32(cboEmpresa.EditValue), deFecha.DateTime.Year, deFecha.DateTime.Month);
//                objE_DocumentoDia = new DocumentoVentaBL().SeleccionaEmpresaPeriodoDia(Convert.ToInt32(cboEmpresa.EditValue), deFecha.DateTime.Year, deFecha.DateTime.Month);
                decimal TotalVentaDia = 0;
                decimal TotalVentaMensual = 0;

                if (objE_Documento != null)
                {
                    TotalVentaMensual = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVentaMensual = 0;
                }


                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                    {
                        // Validación por el monto total - Mensual
                        if (TotalVentaMensual > Tope)
                        {
                            XtraMessageBox.Show("El importe de venta sobrepasa el tope mensual del RUS, por favor verifique.\n Consultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                            //return;
                        }
                        else
                        {
                            //XtraMessageBox.Show("No llega al Tope Mensual, continuamos ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = false;
                        }



                    }
                }
            }

             if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private bool ValidarTopeEmpresaDiarioRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total = decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());

            if (Convert.ToInt32(cboEmpresa.EditValue) != Parametros.intPanoraramaDistribuidores)
            {
                /// *****************************************************************************************
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));

                decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.TopeDiario;
                }
                /// ******************************************************************************************
               // decimal Tope = Parametros.dmlTopeEmpresaDiarioRUS;
                //decimal Tope = Parametros.dmlTopeEmpresaDiarioRUS;
                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaFecha(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

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
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)
                    {
                        if (TotalVenta > Tope)
                        {
                            XtraMessageBox.Show("El importe de venta sobrepasa el tope diario del RUS, por favor verifique.\n Consultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                            //return;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }





        //private void CargarDetalles(int IdPedido)
        //{
        //    try
        //    {
        //        mListaDetalle = null;
        //        mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

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

        public void InicializarModificar()
        {
            if (gvPedido.RowCount > 0)
            {
                PedidoBE objPedido = new PedidoBE();
                objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                frmRegPedidoEdit objRegPedidoEdit = new frmRegPedidoEdit();
                objRegPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
                objRegPedidoEdit.IdPedido = objPedido.IdPedido;
                objRegPedidoEdit.ActivaCabeceraCaja = true;
                objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVGenerado)
                    objRegPedidoEdit.bConsulta = false;
                else
                    objRegPedidoEdit.bConsulta = true;
                objRegPedidoEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private void InsertarDocumentoVentaEmpresa(int IdTipoDocumento, int IdEmpresa, string Serie, string Numero, DateTime Fecha)
        {
            try
            {
                //Traemos la información del pedido.
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido;
                objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                objDocumentoVenta.Mes = objE_Pedido.Mes;
                objDocumentoVenta.IdTipoDocumento = IdTipoDocumento;
                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(Fecha.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(Fecha.ToShortDateString());
                objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                //Verificar si tiene asociado A Facturar
                if (objE_Pedido.IdClienteAsociado == 0)
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                }
                else
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                    objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                }
                //-----------------------------
                objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                objDocumentoVenta.TotalCantidad = objE_Pedido.TotalCantidad;
                objDocumentoVenta.SubTotal = objE_Pedido.SubTotal;
                objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                objDocumentoVenta.Igv = objE_Pedido.Igv;
                objDocumentoVenta.Total = objE_Pedido.Total;
                objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresa;
                objDocumentoVenta.IdAlmacen = IdAlmacen;
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Venta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                mListaDetalle = null;
                mListaDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

                foreach (var item in mListaDetalle)
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
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(Fecha.ToShortDateString());
                objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.IdPedido = IdPedido;
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
                    objE_Pago.Fecha = Convert.ToDateTime(Fecha.ToShortDateString());
                    objE_Pago.IdTipoDocumento = IdTipoDocumento;
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
                    objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                    if (chkDespachar.Checked) GrabarDespacho();
                }
                else
                {
                    objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaVariosEmpresa(int items, int IdTipoDocumento, int IdEmpresa, string Serie, string Numero, DateTime Fecha)
        {
            try
            {
                int Contador = 0;

                if (mListaDetalle.Count % items == 0)
                {
                    Contador = mListaDetalle.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDetalle.Count / items) + 1);
                }

                int row = 0;

                for (int i = 0; i < Contador; i++)
                {
                    //Documento Venta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();
                    int fila = 0;
                    int cuenta = 0;
                    if (i > 0)
                    {
                        fila = row;
                    }

                    for (int y = fila; y < mListaDetalle.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                        objE_DocumentoVentaDetalle.IdEmpresa = IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDetalle[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDetalle[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDetalle[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDetalle[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDetalle[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDetalle[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDetalle[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDetalle[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDetalle[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDetalle[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDetalle[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDetalle[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDetalle[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDetalle[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDetalle[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDetalle[row].IdPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDetalle[row].TipoOper;
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
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                    objDocumentoVenta.Mes = objE_Pedido.Mes;
                    objDocumentoVenta.IdTipoDocumento = IdTipoDocumento;
                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(Fecha.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(Fecha.ToShortDateString());
                    objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                    //Verificar si tiene asociado A Facturar
                    if (objE_Pedido.IdClienteAsociado == 0)
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                        objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    }
                    else
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                        objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                    }
                    //-----------------------------
                    //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    //objDocumentoVenta.Direccion = objE_Pedido.Direccion;


                    objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                    objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                    objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                    objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                    objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                    objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresa;
                    objDocumentoVenta.IdAlmacen = IdAlmacen;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = deTotal;
                    objE_MovimientoCaja.ImporteDolares = deTotal / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_Pago.IdTipoDocumento = IdTipoDocumento;
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
                        objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();
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

        private void InsertarDocumentoVentaRUS()
        {
            try
            {
                //Traemos la información del pedido.
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido;
                objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                objDocumentoVenta.Mes = objE_Pedido.Mes;
                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                {
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
                }
                else
                {
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }                

                //Serie Asignada a la caja
                CajaEmpresaBE objCajaEmpresa = null;
                objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                SerieRUS = objCajaEmpresa.SerieBoleta;

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue) , Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                {
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTipoDocBoletaElectronica, SerieRUS);
                }
                else
                {
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTipoDocBoletaVenta, SerieRUS);
                }


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
                objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                //Verificar si tiene asociado A Facturar
                if (objE_Pedido.IdClienteAsociado == 0)
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                }
                else
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                    objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                }
                //-----------------------------
                //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                objDocumentoVenta.TotalCantidad = objE_Pedido.TotalCantidad;
                objDocumentoVenta.SubTotal = objE_Pedido.SubTotal;
                objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                objDocumentoVenta.Igv = objE_Pedido.Igv;
                objDocumentoVenta.Icbper = objE_Pedido.Icbper;
                objDocumentoVenta.Total = objE_Pedido.Total;
                objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresa;
                objDocumentoVenta.IdAlmacen = IdAlmacen;
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDetalle)
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
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());

                objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;   //Parametros.intTipoDocBoletaVenta;
                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.IdPedido = IdPedido;
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

                    objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa ==21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;
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
                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                    {
                        int vIdDocumentoVenta;
                        vIdDocumentoVenta= objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();    
                        
                    //    #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                        ImpresionElectronicaLocal(vIdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresa);
                    }
                    else
                    {
                        objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();
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

        private bool ValidaPorcentajeDescuento()
        {
            bool flag = false;
                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

            foreach (var item in mListaDetalle)
            {
                if (item.PorcentajeDescuento > 30)
                {
                    flag = true;                   
                }
            }

            return flag;
        }


        private void InsertarDocumentoVentaRUSPorTipDoc(int pTipoDocumentoBF)
        {
            try
            {
                //Traemos la información del pedido.
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido;
                objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                objDocumentoVenta.Mes = objE_Pedido.Mes;
                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                {
                    objDocumentoVenta.IdTipoDocumento = pTipoDocumentoBF;  //Parametros.intTipoDocBoletaElectronica;
                }
                else
                {
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }

                //Serie Asignada a la caja
                CajaEmpresaBE objCajaEmpresa = null;
                objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                if (pTipoDocumentoBF == 12) //BEE
                { SerieRUS = objCajaEmpresa.SerieBoleta; }
                else
                { SerieRUS = objCajaEmpresa.SerieFactura; }                

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue) , Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                {
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), pTipoDocumentoBF, SerieRUS);
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTipoDocBoletaElectronica, SerieRUS);
                }
                else
                {
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTipoDocBoletaVenta, SerieRUS);
                }


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
                objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                //Verificar si tiene asociado A Facturar
                if (objE_Pedido.IdClienteAsociado == 0)
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                }
                else
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                    objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                }
                //-----------------------------
                //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                objDocumentoVenta.TotalCantidad = objE_Pedido.TotalCantidad;
                objDocumentoVenta.SubTotal = objE_Pedido.SubTotal;
                objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                objDocumentoVenta.Igv = objE_Pedido.Igv;
                objDocumentoVenta.Icbper = objE_Pedido.Icbper;
                objDocumentoVenta.Total = objE_Pedido.Total;
                objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresa;
                objDocumentoVenta.IdAlmacen = IdAlmacen;
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDetalle)
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
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //Movimiento Caja
                MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                objE_MovimientoCaja.IdMovimientoCaja = 0;
                objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocumentoBF : Parametros.intTipoDocBoletaVenta;   //Parametros.intTipoDocBoletaVenta;
         //       objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;   //Parametros.intTipoDocBoletaVenta;                
                objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_MovimientoCaja.TipoMovimiento = "I";
                objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTC.EditValue);
                objE_MovimientoCaja.IdPedido = IdPedido;
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

                    objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocumentoBF : Parametros.intTipoDocBoletaVenta;
                    //objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;
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
                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                    {
                        int vIdDocumentoVenta;
                        vIdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();

                        //    #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                        ImpresionElectronicaLocal(vIdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresa);
                    }
                    else
                    {
                        objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();
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


        private void InsertarDocumentoVentaVariosRUS(int items)
        {
            try
            {
                int Contador = 0;

                if (mListaDetalle.Count % items == 0)
                {
                    Contador = mListaDetalle.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDetalle.Count / items) + 1);
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

                    for (int y = fila; y < mListaDetalle.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDetalle[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDetalle[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDetalle[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDetalle[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDetalle[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDetalle[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDetalle[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDetalle[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDetalle[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDetalle[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDetalle[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDetalle[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDetalle[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDetalle[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDetalle[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDetalle[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDetalle[row].IdPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDetalle[row].TipoOper;
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
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                    objDocumentoVenta.Mes = objE_Pedido.Mes;
                    objDocumentoVenta.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta; // Parametros.intTipoDocBoletaVenta;

                    //Serie asignada a la caja
                    CajaEmpresaBE objCajaEmpresa = null;
                    objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                    SerieRUS = objCajaEmpresa.SerieBoleta;

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue) , Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta, SerieRUS);
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
                    objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;

                    //Verificar si tiene asociado A Facturar
                    if (objE_Pedido.IdClienteAsociado == 0)
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                        objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    }
                    else
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                        objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                    }
                    //-----------------------------
                    //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                    objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                    objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                    objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                    objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                    objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresa;
                    objDocumentoVenta.IdAlmacen = IdAlmacen;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = deTotal;
                    objE_MovimientoCaja.ImporteDolares = deTotal / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;    //Parametros.intTipoDocBoletaVenta;
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
                        objBL_DocumentoVenta.InsertaDocumentoContado(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        if (chkDespachar.Checked) GrabarDespacho();
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

        private void InsertarDocumentoVentaPagoVariosRUS(decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster, int pTipoDocBolFac)
        {
            try
            {
                //Traemos la información del pedido.
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido;
                objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                objDocumentoVenta.Mes = objE_Pedido.Mes;
                objDocumentoVenta.IdTipoDocumento = IdEmpresa == 3 ||  IdEmpresa == 19 || IdEmpresa ==21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;
                //objDocumentoVenta.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;

                //Serie asignada a la caja
                CajaEmpresaBE objCajaEmpresa = null;
                objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                if (pTipoDocBolFac == 12)
                { SerieRUS = objCajaEmpresa.SerieBoleta; }
                else
                { SerieRUS = objCajaEmpresa.SerieFactura; }

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue) , Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta, SerieRUS);
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta, SerieRUS);
                if (mListaNumero.Count > 0)
                {
                    Serie = mListaNumero[0].Serie;// SerieRUS.ToString();//"001";
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
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
                objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;
                //Verificar si tiene asociado A Facturar
                if (objE_Pedido.IdClienteAsociado == 0)
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                }
                else
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                    objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                }
                objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                objDocumentoVenta.TotalCantidad = objE_Pedido.TotalCantidad;
                objDocumentoVenta.SubTotal = objE_Pedido.SubTotal;
                objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                objDocumentoVenta.Igv = objE_Pedido.Igv;
                objDocumentoVenta.Icbper = objE_Pedido.Icbper;
                objDocumentoVenta.Total = objE_Pedido.Total;
                objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresa;
                objDocumentoVenta.IdAlmacen = IdAlmacen;
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDetalle)
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
                   // objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 ||  IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = 98;//
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Efectivo;
                    objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Visa > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 1;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta; // Parametros.intTipoDocBoletaVenta;
                 //   objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta; // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = 99;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Visa;
                    objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                    //objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCard;
                    objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                  //  objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;  // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                    objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;   // Parametros.intTipoDocBoletaVenta;
                    //objE_MovimientoCaja.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;   // Parametros.intTipoDocBoletaVenta;
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                    objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Cupon;
                    objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
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
                    objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20  ? pTipoDocBolFac : Parametros.intTipoDocBoletaVenta;    //Parametros.intTipoDocBoletaVenta;
                    //objE_Pago.IdTipoDocumento = IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20 ? Parametros.intTipoDocBoletaElectronica : Parametros.intTipoDocBoletaVenta;    //Parametros.intTipoDocBoletaVenta;
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
                    if (IdEmpresa == 3 || IdEmpresa == 19 || IdEmpresa == 21 || IdEmpresa == 23 || IdEmpresa == 8 || IdEmpresa == 20)
                    {
                        int vIdDocumentoVenta;
                        vIdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                        if (chkDespachar.Checked) GrabarDespacho();
                        //    #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, pTipoDocBolFac);
                   //     objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                        
                        ImpresionElectronicaLocal(vIdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresa);
                    }
                    else
                    {
                        objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                        if (chkDespachar.Checked) GrabarDespacho();
                    }
                }
                else
                {
                    objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                }

                //Imprimimos los documentos
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

                if (mListaDetalle.Count % items == 0)
                {
                    Contador = mListaDetalle.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDetalle.Count / items) + 1);
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

                    for (int y = fila; y < mListaDetalle.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDetalle[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDetalle[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDetalle[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDetalle[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDetalle[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDetalle[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDetalle[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDetalle[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDetalle[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDetalle[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDetalle[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDetalle[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDetalle[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDetalle[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDetalle[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDetalle[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDetalle[row].IdPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDetalle[row].TipoOper;
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
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                    objDocumentoVenta.Mes = objE_Pedido.Mes;
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;

                    //Serie asignada a la caja
                    CajaEmpresaBE objCajaEmpresa = null;
                    objCajaEmpresa = new CajaEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Parametros.intCajaId);
                    SerieRUS = objCajaEmpresa.SerieBoleta;

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue) , Parametros.intTipoDocBoletaVenta, Parametros.intPeriodo);
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTipoDocBoletaVenta, SerieRUS);
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
                    objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;
                    //Verificar si tiene asociado A Facturar
                    if (objE_Pedido.IdClienteAsociado == 0)
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                        objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    }
                    else
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                        objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                    }
                    //-----------------------------
                    //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                    objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                    objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                    objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                    objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                    objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresa;
                    objDocumentoVenta.IdAlmacen = IdAlmacen;
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
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = 98;//
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Efectivo / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = 99;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Visa / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard / Contador;
                        objE_MovimientoCaja.ImporteDolares = (MasterCard / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                        objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Cupon;
                        objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
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
                        objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                        if (chkDespachar.Checked) GrabarDespacho();
                    }
                    else
                    {
                        objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaPagoVarios(decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster, int IdEmpresaGenera, string TipoDoc)
        {
            try
            {
                //Traemos la información del pedido.
                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido;
                objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                objDocumentoVenta.Mes = objE_Pedido.Mes;
                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                if (IdEmpresaGenera == Parametros.intEmpresaId)
                {
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
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    }

                    #region "Verificar Número"

                    DocumentoVentaBE objE_DocumentoVentaSerie = null;
                    objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(IdEmpresaGenera, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                    if (objE_DocumentoVentaSerie != null)
                    {
                        XtraMessageBox.Show("El documento "+ TipoDoc +":" + Serie +"-"+ Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    #endregion
                }
                else
                {
                    CajaEmpresaBE objE_CajaEmpresa = new CajaEmpresaBE();
                    objE_CajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresaGenera, Parametros.intTiendaId, Parametros.intCajaId);

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresaGenera, Parametros.intTipoDocBoletaVenta, objE_CajaEmpresa.SerieBoleta);
                    if (mListaNumero.Count > 0)
                    {
                        Serie = mListaNumero[0].Serie;
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    }
                    objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                }


                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;
                //Verificar si tiene asociado A Facturar
                if (objE_Pedido.IdClienteAsociado == 0)
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                }
                else
                {
                    objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                    objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                    objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                }
                objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                objDocumentoVenta.TotalCantidad = objE_Pedido.TotalCantidad;
                objDocumentoVenta.SubTotal = objE_Pedido.SubTotal;
                objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                objDocumentoVenta.Igv = objE_Pedido.Igv;
                objDocumentoVenta.Icbper = objE_Pedido.Icbper;
                objDocumentoVenta.Total = objE_Pedido.Total;
                objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = IdEmpresaGenera;//Parametros.intEmpresaId;
                objDocumentoVenta.IdAlmacen = IdAlmacen;
                objDocumentoVenta.CodigoNC = CodigoNC;

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDetalle)
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
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }


                //Movimiento Caja
                List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon ==0))
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //Parametros.intEmpresaId;
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = 98;//
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Efectivo;
                    objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Visa > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 1;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = 99;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Visa;
                    objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;// Parametros.intEmpresaId;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (MasterCard > 0)
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 2;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCard;
                    objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;// Parametros.intEmpresaId;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }

                if (VisaPuntosVida > 0) //--------------------------------------------------------add
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 3;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                    objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 4;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                    objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                    objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }
                if (Cupon > 0) //--------------------------------------------------------
                {
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 4;
                    objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                    objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                    objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                    objE_MovimientoCaja.TipoTarjeta = null;
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Cupon;
                    objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                    objE_MovimientoCaja.IdPedido = IdPedido;
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera;
                    lstMovimientoCaja.Add(objE_MovimientoCaja);
                }

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count == 0)
                {
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = IdEmpresaGenera; //Parametros.intEmpresaId;
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
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
                        objE_DocumentoVentaPago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //item.IdTipoDocumento;
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
                    IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                    if (chkDespachar.Checked) GrabarDespacho();

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

                    #region "Envío e Impresión de Comprobante electrónico"
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineBoletaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        TalonBE objTalon = null;
                        objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresa);
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

                        ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresa);
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                }

                //Imprimimos los documentos
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarDocumentoVentaVariosPagoVarios(int items, decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, int IdDocumentoNC, int IdTipoMaster, int IdEmpresaGenera, string TipoDoc)
        {
            try
            {
                int Contador = 0;

                if (mListaDetalle.Count % items == 0)
                {
                    Contador = mListaDetalle.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaDetalle.Count / items) + 1);
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

                    for (int y = fila; y < mListaDetalle.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = null;
                        objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();

                        objE_DocumentoVentaDetalle.IdEmpresa = IdEmpresaGenera;//mListaDetalle[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaDetalle[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaDetalle[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaDetalle[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaDetalle[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaDetalle[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaDetalle[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaDetalle[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaDetalle[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaDetalle[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaDetalle[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaDetalle[row].ValorVenta;
                        objE_DocumentoVentaDetalle.CodAfeIGV = mListaDetalle[row].CodAfeIGV;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDetalle[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaDetalle[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaDetalle[row].FlagRegalo;
                        objE_DocumentoVentaDetalle.IdPromocion = mListaDetalle[row].IdPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaDetalle[row].TipoOper;
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
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    //Generamos el documento cabecera.
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = objE_Pedido.Periodo;
                    objDocumentoVenta.Mes = objE_Pedido.Mes;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    if (IdEmpresaGenera == Parametros.intEmpresaId)
                    {
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

                        #region "Verificar Número"

                        DocumentoVentaBE objE_DocumentoVentaSerie = null;
                        objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(IdEmpresaGenera, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
                        if (objE_DocumentoVentaSerie != null)
                        {
                            XtraMessageBox.Show("El documento "+ TipoDoc +":" + Serie +"-"+ Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        #endregion
                    }
                    else
                    {
                        CajaEmpresaBE objE_CajaEmpresa = new CajaEmpresaBE();
                        objE_CajaEmpresa = new CajaEmpresaBL().Selecciona(IdEmpresaGenera, Parametros.intTiendaId, Parametros.intCajaId);

                        //Obtener el numero del documento relacionado a la serie
                        List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(IdEmpresaGenera, Parametros.intTipoDocBoletaVenta, objE_CajaEmpresa.SerieBoleta);
                        if (mListaNumero.Count > 0)
                        {
                            Serie = mListaNumero[0].Serie;
                            Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                        }
                        objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocBoletaVenta;
                    }


                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = objE_Pedido.IdCliente;
                    //Verificar si tiene asociado A Facturar
                    if (objE_Pedido.IdClienteAsociado == 0)
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                        objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    }
                    else
                    {
                        objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumentoAsociado;
                        objDocumentoVenta.DescCliente = objE_Pedido.DescClienteAsociado;
                        objDocumentoVenta.Direccion = objE_Pedido.DireccionAsociado;
                    }
                    //-----------------------------
                    //objDocumentoVenta.NumeroDocumento = objE_Pedido.NumeroDocumento;
                    //objDocumentoVenta.DescCliente = objE_Pedido.DescCliente;
                    //objDocumentoVenta.Direccion = objE_Pedido.Direccion;
                    objDocumentoVenta.IdMoneda = objE_Pedido.IdMoneda;
                    objDocumentoVenta.TipoCambio = objE_Pedido.TipoCambio;
                    objDocumentoVenta.IdFormaPago = objE_Pedido.IdFormaPago;
                    objDocumentoVenta.IdVendedor = objE_Pedido.IdVendedor;
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    objDocumentoVenta.PorcentajeDescuento = objE_Pedido.PorcentajeDescuento;
                    objDocumentoVenta.Descuentos = objE_Pedido.Descuento;
                    objDocumentoVenta.PorcentajeImpuesto = objE_Pedido.PorcentajeImpuesto;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = objE_Pedido.TotalBruto;
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA CONTADO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR VENTA CONTADO";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = IdEmpresaGenera;// Parametros.intEmpresaId;
                    objDocumentoVenta.IdAlmacen = IdAlmacen;
                    objDocumentoVenta.CodigoNC = CodigoNC;

                    //Movimiento Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                    if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon == 0))
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //Parametros.intEmpresaId;
                        objE_MovimientoCaja.IdMovimientoCaja = 0;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = 98;//
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Efectivo / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Efectivo / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (Visa > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 1;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = 99;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Visa / Contador;
                        objE_MovimientoCaja.ImporteDolares = (Visa / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCard > 0)
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 2;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCard / Contador;
                        objE_MovimientoCaja.ImporteDolares = (MasterCard / Contador) / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //Parametros.intEmpresaId;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    if (VisaPuntosVida > 0) //--------------------------------------------------------add
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 3;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
                        objE_MovimientoCaja.TipoTarjeta = TipoVisa;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }
                    if (MasterCardPuntosVida > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento; //Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
                        objE_MovimientoCaja.TipoTarjeta = TipoMaster;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
                        objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }

                    if (Cupon > 0) //--------------------------------------------------------
                    {
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 4;
                        objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
                        objE_MovimientoCaja.IdFormaPago = objE_Pedido.IdFormaPago;
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
                        objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
                        objE_MovimientoCaja.TipoTarjeta = null;
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Cupon;
                        objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
                        objE_MovimientoCaja.IdPedido = IdPedido;
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = IdEmpresaGenera; //IdEmpresa;
                        lstMovimientoCaja.Add(objE_MovimientoCaja);
                    }


                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    if (mListaDocumentoVentaPagoOrigen.Count == 0)
                    {
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = IdEmpresaGenera; //Parametros.intEmpresaId;
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;// Convert.ToInt32(cboDocumento.EditValue);
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
                            objE_DocumentoVentaPago.IdEmpresa = IdEmpresaGenera; //item.IdEmpresa;
                            objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                            objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                            objE_DocumentoVentaPago.Fecha = item.Fecha;
                            objE_DocumentoVentaPago.IdTipoDocumento = objDocumentoVenta.IdTipoDocumento;//item.IdTipoDocumento;
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
                        objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                        if (chkDespachar.Checked) GrabarDespacho();
                    }
                    else
                    {
                        objBL_DocumentoVenta.InsertaDocumentoContadoPagoVarios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, IdDocumentoNC);
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarEstadoCuentaDiseñador()
        {
            if (IdAsesorExterno > 0)
            {
                //En caso que sea nota de credito
                #region "Comisión EECC"

                int IdMotivo = Parametros.intMotivoVenta;
                decimal decTotalPedido = 0;

                //Estado de Cuenta
                EstadoCuentaBE objE_EstadoCuenta = null;
                SeparacionBE objE_Separacion = null;

                ClienteBE objE_Cliente = new ClienteBE();
                objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, IdCliente);


                if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                {
                    ////Datos del estado de cuenta
                    //EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                    //EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                    decTotalPedido = Math.Round( ((Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(Parametros.dmlTCMayorista)) / Convert.ToDecimal(Parametros.dblIGV)) * (Parametros.dmlClubDesign / 100),2);

                    //Datos del estado de cuenta
                    objE_EstadoCuenta = new EstadoCuentaBE();

                    objE_EstadoCuenta.IdEstadoCuenta = 0;
                    objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                    objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                    objE_EstadoCuenta.IdCliente = IdAsesorExterno;
                    objE_EstadoCuenta.NumeroDocumento = "COMCD";
                    objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_EstadoCuenta.FechaDeposito = null;
                    objE_EstadoCuenta.Concepto = "COMISION " + Parametros.dmlClubDesign + "% CLUB DESIGN - PEDIDO N° " + lblPedido.Text;
                    objE_EstadoCuenta.FechaVencimiento = null;
                    objE_EstadoCuenta.Importe = decTotalPedido;// ((Convert.ToDecimal(txtTotal.EditValue)/ Convert.ToDecimal(Parametros.dmlTCMayorista)) / Convert.ToDecimal(Parametros.dblIGV)) * (Parametros.dmlClubDesign / 100);
                    objE_EstadoCuenta.ImporteAnt = 0;
                    objE_EstadoCuenta.TipoMovimiento = "A";
                    objE_EstadoCuenta.IdMotivo = Parametros.intMotivoVenta;//Verificar para NAVIDAD
                    objE_EstadoCuenta.IdPedido = IdPedido;
                    objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                    objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                    objE_EstadoCuenta.Observacion = "";
                    objE_EstadoCuenta.FlagEstado = true;
                    objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                    objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    //objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);
                }
                else
                {
                    //SeparacionBE objE_Separacion = new SeparacionBE();
                    //SeparacionBL objBL_Separacion = new SeparacionBL();
                    decTotalPedido = Math.Round(((Convert.ToDecimal(txtTotal.EditValue)) / Convert.ToDecimal(Parametros.dblIGV)) * (Parametros.dmlClubDesign / 100),2);

                    //Datos del estado de cuenta
                    objE_Separacion = new SeparacionBE();

                    objE_Separacion.IdSeparacion = 0;
                    objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                    objE_Separacion.Periodo = Parametros.intPeriodo;
                    objE_Separacion.IdCliente = IdAsesorExterno;
                    objE_Separacion.NumeroDocumento = "COMCD";
                    objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Separacion.FechaPago = null;
                    objE_Separacion.Concepto = "COMISION " + Parametros.dmlClubDesign + "% CLUB DESIGN - PEDIDO N° " + lblPedido.Text;
                    objE_Separacion.FechaVencimiento = null;
                    objE_Separacion.Importe = decTotalPedido;// ((Convert.ToDecimal(txtTotal.EditValue))/ Convert.ToDecimal(Parametros.dblIGV))*(Parametros.dmlClubDesign/100);
                    objE_Separacion.ImporteAnt = 0;
                    objE_Separacion.TipoMovimiento = "A";
                    objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Verificar para NAVIDAD
                    objE_Separacion.IdPedido = IdPedido;
                    objE_Separacion.IdDocumentoVenta = (int?)null;
                    objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                    objE_Separacion.Observacion = "";
                    objE_Separacion.FlagEstado = true;
                    objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                    objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    //objBL_Separacion.Inserta(objE_Separacion);
                }
                #endregion

                if (pOperacion == Operacion.Nuevo)
                {
                    DocumentoVentaBL objBL_DocumentoVentaEstado = new DocumentoVentaBL();
                    if (objE_EstadoCuenta != null)
                    {
                        List<EstadoCuentaBE> lstEstadoCuenta = new List<EstadoCuentaBE>();
                        lstEstadoCuenta = new EstadoCuentaBL().ListaPedido(Parametros.intEmpresaId, IdPedido,"A");
                        if (lstEstadoCuenta.Count > 0)
                        {
                            XtraMessageBox.Show("Ya existe un registro N°: " + lstEstadoCuenta[0].NumeroDocumento + " en Estado de Cuenta Dolares(US$) \n US$ " + lstEstadoCuenta[0].Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            objBL_DocumentoVentaEstado.InsertaCredito(objE_EstadoCuenta, objE_Separacion);
                            XtraMessageBox.Show("Se registró Abono Club Design en Estado de Cuenta Dolares(US$) \n US$ " + decTotalPedido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (objE_Separacion != null)
                    {
                        List<SeparacionBE> lstSeparacion = new List<SeparacionBE>();
                        lstSeparacion = new SeparacionBL().ListaPedido(Parametros.intEmpresaId, IdPedido, "A");
                        if (lstSeparacion.Count > 0)
                        {
                            XtraMessageBox.Show("Ya existe un registro N°: " + lstSeparacion[0].NumeroDocumento + " en Estado de Cuenta Soles(S/) \n S/ " + lstSeparacion[0].Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                        else
                        {
                            objBL_DocumentoVentaEstado.InsertaCredito(objE_EstadoCuenta, objE_Separacion);
                            XtraMessageBox.Show("Se registró Abono Club Design en Estado de Cuenta Soles(S/) \n S/ " + decTotalPedido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            #region "Imprime Recibo"
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

                            ticket.TextoCentro(objTalon.NombreComercial);
                            ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            ticket.TextoCentro(Parametros.strEmpresaRuc);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("TIENDA: " + objTalon.DescTienda);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
                            ticket.TextoIzquierda("COD. ASESOR CLUB DESIGN: " + IdAsesorExterno);
                            //ticket.LineasGuion();
                            //ticket.LineasTotales();

                            //ticket.AgregaTotales("Total BONO S/ ", Convert.ToDouble(decTotalPedido)); // imprime linea con total
                            //ticket.TextoIzquierda("");
                            //ticket.TextoIzquierda("Ven:" + DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lblPedido.Text);
                            ticket.TextoCentro("");
                            ticket.TextoCentro("ENTREGAR ESTE VOUCHER AL DISEÑADOR");
                            ticket.TextoCentro("GRACIAS POR LA ASESORIA");
                            //ticket.TextoCentro("GRACIAS POR SU COMPRA");
                            ticket.TextoCentro(objTalon.PaginaWeb);

                            //ticket.TextoCentro("=========================================");
                            //ticket.TextoCentro("¡FELICIDADES!");
                            //ticket.TextoCentro("Ganaste 5% dscto.");
                            //ticket.TextoCentro("ENTREGAR ESTE VOUCHER AL DISEÑADOR");
                            //ticket.TextoCentro("PARA SU SEGUIMIENTO DE PEDIDO");
                            //ticket.TextoCentro("valido del 14 al 28 de Octubre del 2016");
                            //ticket.TextoCentro("Dscto no acumulable con otras promociones");
                            //ticket.TextoCentro("=========================================");
                            ticket.CortaTicket();

                            #endregion
                        }
                    }
                }
            }
        }

        private void ObtenerCorrelativoCreditoEstadoCuentaDiseñador()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocSaldoFavorDiseño, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }

                NumeroCredito = /*"CR " +*/ sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void liberarpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvPedido.RowCount > 0)
                {
                    if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVGenerado)
                    {
                        if (XtraMessageBox.Show("Está seguro de Liberar el pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Chequeador
                            int IdPedido = 0;
                            IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                            MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
                            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                            objE_MovimientoPedido.IdPedido = IdPedido;
                            objE_MovimientoPedido.IdAuxiliar = 0;
                            objBL_MovimientoPedido.ActualizaAuxiliar(objE_MovimientoPedido);

                            PedidoBL objBL_Pedido = new PedidoBL();
                            objBL_Pedido.ActualizaImpresion(IdPedido, false);

                            XtraMessageBox.Show("El Pedido quedó libre para ser modificado,\nEsto aplica sólo a pedidos con Situación: Generado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrabarDespacho()
        {
            PedidoBL objBL_Pedido = new PedidoBL();
            PedidoBE objE_Pedido = new PedidoBE();

            MovimientoPedidoBE objMovimientoPedido = new MovimientoPedidoBE();
            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            //objE_Pedido = objBL_Pedido.Selecciona(IdPedido);
            //if (objE_Pedido.IdSituacion == Parametros.intFacturado)
            //{
            objMovimientoPedido.IdPedido = IdPedido;
            objMovimientoPedido.CantidadBulto = 0;
            objMovimientoPedido.IdDespachador = Parametros.intPersonaId;

            objBL_MovimientoPedido.ActualizaOrigenDespacho(IdPedido, Parametros.strDescCaja);
            objBL_MovimientoPedido.ActualizaDespachador(objMovimientoPedido);
            objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnAlmacenDespacho, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
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

        private void ImpresionElectronicaLocal(int IdDocumentoVenta, int IdTamanoHoja, string Impresora, int parIdEmpresa)
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
            else if(IdTamanoHoja == Parametros.intTamano80mmTermico)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    TalonBE objTalon = null;
                    objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                    //lstReporte[0].DireccionTienda = objTalon.DireccionFiscal;

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
                    //objReporteGuia.SetParameterValue("DireccionTienda", objTalon.DireccionFiscal);
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
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                    dirFacturacion = Parametros.strDireccionUcayali3;
                else if (Parametros.intTiendaId==14)
                    dirFacturacion = Parametros.strDireccionPrescott;
                else
                    dirFacturacion = Parametros.strDireccionUcayali;
                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)dirFacturacion = Parametros.strDireccionAndahuaylas;
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)dirFacturacion = Parametros.strDireccionMegaplaza;
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott)dirFacturacion = Parametros.strDireccionPrescott;

                

                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                List<MovimientoCajaBE> lstPagosCaja = new List<MovimientoCajaBE>();
                lstPagosCaja = new MovimientoCajaBL().ListaFormaPago(IdDocumentoVenta);

                TalonBE objTalon = null;
                if (parIdEmpresa == 3 || parIdEmpresa == 19 || parIdEmpresa == 21 || parIdEmpresa == 23 || parIdEmpresa == 8 || parIdEmpresa == 20)
                {
                    objTalon = new TalonBL().SeleccionaCajaDocumento(parIdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                }
                else
                {
                    objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));
                }               
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
                    if (parIdEmpresa == 3)
                    {
                        #region "2 Copias CI"
                        string vDeliveryFree19 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("CORONA IMPORTADORES E.I.R.L.");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                           // ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("AV. GUILLERMO PRESCOTT NRO. 329 INT. 101");
                            ticket.TextoCentro("LIMA-LIMA-SAN ISIDRO");
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
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
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();

                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    }
                                    else
                                    {
                                        vDeliveryFree19 = Convert.ToString(item.CodigoProveedor);
                                    }
                                }

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));

                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.grupoaymservicios.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");

                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree19 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 2,000.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}


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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (IdEmpresa == 19)
                    {
                        #region "2 Copias THB"
                        string vDeliveryFree19 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN NELLY BETHSABE");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            ticket.TextoCentro("10727472873");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin +")"  );
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();

                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    }
                                    else
                                    {
                                        vDeliveryFree19 = Convert.ToString(item.CodigoProveedor);
                                    }
                                }

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));

                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.grupoaymservicios.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");

                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree19 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}


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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (parIdEmpresa == 21)
                    {
                        #region "2 Copias THL"
                        string vDeliveryFree21 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN SILVIA LILIANA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
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
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    }
                                    else
                                    {
                                        vDeliveryFree21 = Convert.ToString(item.CodigoProveedor);
                                    }

                                }

                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");

                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree21 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}
                                

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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (parIdEmpresa == 23)
                    {
                        #region "2 Copias TTELEAZAR"
                        string vDeliveryFree21 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA TARRILLO ELEAZAR");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
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
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    }
                                    else
                                    {
                                        vDeliveryFree21 = Convert.ToString(item.CodigoProveedor);
                                    }

                                }

                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. ");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");

                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree21 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}


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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (parIdEmpresa == 8)
                    {
                        #region "2 Copias Amalia"
                        string vDeliveryFree21 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("HUAMAN BRAMON TEODORA AMALIA");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
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
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    }
                                    else
                                    {
                                        vDeliveryFree21 = Convert.ToString(item.CodigoProveedor);
                                    }

                                }

                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. ");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");

                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree21 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}


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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (parIdEmpresa == 20)
                    {
                        #region "2 Copias Roxana"
                        string vDeliveryFree21 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN ROXANA INES");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
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
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    }
                                    else
                                    {
                                        vDeliveryFree21 = Convert.ToString(item.CodigoProveedor);
                                    }

                                }

                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. ");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");

                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree21 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}


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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else
                    {
                        #region "2 Copias PANORAMA"
                        string vDeliveryFree = "";

                        for (int i = 1; i <= 3; i++)
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
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();
                                foreach (var item in lstReporte)
                                {
                                    if (item.PrecioVenta != 0)
                                    {
                                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));                                        
                                    }
                                    else
                                    {
                                        vDeliveryFree = Convert.ToString(item.CodigoProveedor);
                                    }
                                }

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                            }

                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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

                            if (i == 1)
                            {
                               //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 155-2017/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en https://www.nubefact.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("www.panoramahogar.com");
                                ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");
                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");

                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}

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
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO " + Parametros.strVersion + " *****");
                            }
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
                    //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
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
                    ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                    ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                    ticket.TextoExtremos("ICBPER", lstReporte[0].CodMoneda + " " + lstReporte[0].Icbper.ToString());
                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
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
                    ticket.TextoCentro("***** COPIA CLIENTE v." + Parametros.strVersion + " *****");
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

        private void CalculaTotalPromocion2x1_Total()
        {
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;
            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;

            List<PedidoDetalleBE> lst_PedidoDetallePromo2x1 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo2x1_Impar = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo3x1 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetallePromo4x1 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetalleSinPromo = new List<PedidoDetalleBE>();

            //Cargar Lista 
            #region "Cargar Lista 3x2"
            List<PedidoDetalleBE> mListaPedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> mListaPedidoDetallePromo3x1 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> mListaPedidoDetallePromo4x1 = new List<PedidoDetalleBE>();

            int Itemk = 1;
            int Item3x2 = 1;
            int Item3x1 = 1;
            int Item4x1 = 1;

            foreach (var item in mListaPedidoDetalleOrigen)
            {

                if (item.DescPromocion == "3x2")
                {
                    for (int j = 1; j <= item.Cantidad; j++)
                    {
                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();

                        ObjE_Detalle.Item = Itemk;
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.IdProducto = item.IdProducto;
                        ObjE_Detalle.CodigoProveedor = item.CodigoProveedor;
                        ObjE_Detalle.NombreProducto = item.NombreProducto;
                        ObjE_Detalle.Abreviatura = item.Abreviatura;
                        ObjE_Detalle.PrecioUnitario =  item.PrecioUnitario;
                        ObjE_Detalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        ObjE_Detalle.PrecioVenta = item.PrecioVenta;
                        ObjE_Detalle.ValorVenta = item.PrecioVenta;//item.ValorVenta;
                        ObjE_Detalle.IdPromocion = item.IdPromocion;
                        ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.Observacion = item.Observacion;
                        ObjE_Detalle.FlagMuestra = item.FlagMuestra;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        lst_PedidoDetallePromo3x2.Add(ObjE_Detalle);

                        if (Itemk == 3) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
                    }
                }

                if (item.DescPromocion == "3x1")
                {
                    for (int j = 1; j <= item.Cantidad; j++)
                    {
                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();

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
                        ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.Observacion = item.Observacion;
                        ObjE_Detalle.FlagMuestra = item.FlagMuestra;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        lst_PedidoDetallePromo3x2.Add(ObjE_Detalle);

                        if (Item3x1 == 3) Item3x1 = 1;
                        else
                            Item3x1 = Item3x1 + 1;
                    }
                }

                if (item.DescPromocion == "4x1")
                {
                    for (int j = 1; j <= item.Cantidad; j++)
                    {
                        PedidoDetalleBE ObjE_Detalle = new PedidoDetalleBE();

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
                        ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.Observacion = item.Observacion;
                        ObjE_Detalle.FlagMuestra = item.FlagMuestra;
                        ObjE_Detalle.DescPromocion = item.DescPromocion;
                        lst_PedidoDetallePromo3x2.Add(ObjE_Detalle);

                        if (Item4x1 == 3) Item4x1 = 1;
                        else
                            Item4x1 = Item4x1 + 1;
                    }
                }

            }

            //Agregar a Lista Pública
            mListaPedidoDetallePromo3x2 = lst_PedidoDetallePromo3x2;
            mListaPedidoDetallePromo3x1 = lst_PedidoDetallePromo3x1;
            mListaPedidoDetallePromo4x1 = lst_PedidoDetallePromo4x1;

            #endregion

            #region "Promociones"
            int nItem = 1;
            bool bPromo3x2 = false;
            bool bPromo3x1 = false;
            bool bPromo4x1 = false;

            foreach (PedidoDetalleBE item in mListaPedidoDetalleOrigen)
            {
                #region"2x1"
                if (item.DescPromocion == "2x1")
                {
                    if (item.Cantidad % 2 == 0)
                    {
                        #region "Par"
                        PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                            PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            lst_PedidoDetallePromo2x1.Add(objE_DocumentoDetalle);
                            #endregion

                            #region "Impar"
                            //add 1
                            PedidoDetalleBE objE_DocumentoDetalle2 = new PedidoDetalleBE();
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
                            objE_DocumentoDetalle2.TipoOper = item.TipoOper;
                            lst_PedidoDetallePromo2x1_Impar.Add(objE_DocumentoDetalle2);
                            #endregion
                        }
                        else
                        {
                            #region "Impar"
                            PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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

                    #region "3x2 Version 2"
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
                    #endregion

                }
                #endregion
                
                #region"3x1"
                else if (item.DescPromocion == "3x1")
                {
                    #region "3x1 Version 2"
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
                    #endregion
                }
                #endregion
                
                #region"4x1"
                else if (item.DescPromocion == "4x1")
                {

                    #region "4x1 Version 2"
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
                    #endregion
                }
                #endregion

                #region "Default"
                else
                {
                    PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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

            mListaPedidoDetalleOrigen = new List<PedidoDetalleBE>();
            nItem = 1;

            #region "Agregar 2x1 Par"
            //Agregar Promociones a la lista
            foreach (PedidoDetalleBE item in lst_PedidoDetallePromo2x1)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 2x1 Impar"
            foreach (PedidoDetalleBE item in lst_PedidoDetallePromo2x1_Impar)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x2"
            foreach (PedidoDetalleBE item in mListaPedidoDetallePromo3x2)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioVenta : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                //objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x1"
            foreach (PedidoDetalleBE item in mListaPedidoDetallePromo3x1)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioVenta : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                //objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 4x1"
            foreach (PedidoDetalleBE item in mListaPedidoDetallePromo4x1)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioVenta : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                //objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion


            //Agregar Sin Promoción 
            #region "Agregar códigos sin promoción"
            foreach (PedidoDetalleBE item in lst_PedidoDetalleSinPromo)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            mListaDetalle = mListaPedidoDetalleOrigen;
            mListaPedidoDetalleOrigen = null;

            ////bsListado.DataSource = mListaPedidoDetalleOrigenPromo;
            //bsListado.DataSource = mListaPedidoDetalleOrigen;
            //gPedidoDetalleBE.DataSource = bsListado;
            //gPedidoDetalleBE.RefreshDataSource();

            //CalculaTotales();
            ////CalculaTotalesPromo();

            #region "Calcular Total"
            //decimal deImpuesto = 0;
            //decimal deValorVenta = 0;
            //decimal deSubTotal = 0;
            //decimal deTotal = 0;
            //int intTotalCantidad = 0;
            ////decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            //if (mListaPedidoDetalleOrigen.Count > 0)
            //{
            //    foreach (var item in mListaPedidoDetalleOrigen)
            //    {
            //        intTotalCantidad = intTotalCantidad + item.Cantidad;
            //        deValorVenta = item.ValorVenta;
            //        deTotal = deTotal + deValorVenta;
            //    }

            //    //txtTotalBruto.EditValue = 0;//add may 25
            //    ////if (mListaPromocionVale.Count > 0)//add 250516
            //    ////{
            //    ////    CalculaTotalesVale(intTotalCantidad, deTotal);
            //    ////    return;
            //    ////}

            //    deTotal = Math.Round(deTotal, 2);
            //    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
            //    deImpuesto = Math.Round(deTotal - deSubTotal, 2);
            //    txtTotal.EditValue = deTotal;
            //    txtSubTotal.EditValue = deSubTotal;
            //    txtImpuesto.EditValue = deImpuesto;
            //    txtTotalCantidad.EditValue = intTotalCantidad;
            //}
            //else
            //{
            //    txtTotalCantidad.EditValue = 0;
            //    txtSubTotal.EditValue = 0;
            //    txtImpuesto.EditValue = 0;
            //    txtTotal.EditValue = 0;
            //}
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

            List<PedidoDetalleBE> lst_PedidoDetallePromo2x1 = new List<PedidoDetalleBE>();

            List<PedidoDetalleBE> lst_PedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
            List<PedidoDetalleBE> lst_PedidoDetalleSinPromo = new List<PedidoDetalleBE>();

            #region "Promociones"
            int nItem = 1;
            foreach (PedidoDetalleBE item in mListaPedidoDetalleOrigen)
            {
                #region"2x1"
                if (item.DescPromocion == "2x1")
                {
                    for (int i = 1; i <= item.Cantidad; i++)
                    {
                        PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                        PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                    PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                    objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    //mListaPedidoDetalleOrigen2Promo.Add(objE_DocumentoDetalle);
                    lst_PedidoDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            mListaPedidoDetalleOrigen = new List<PedidoDetalleBE>();

            //Agregar Promociones a la lista
            foreach (PedidoDetalleBE item in lst_PedidoDetallePromo2x1)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            //Agregar Descuentos
            #region "Agregar descuentos"
            int Registro = 1;
            int TotalRegistro = mListaPedidoDetalleOrigen.Count;
            decimal Valor1 = 0;
            decimal Valor2 = 0;
            decimal Mayor = 0;
            decimal Descuento = 0;
            foreach (var item in mListaPedidoDetalleOrigen)
            {
                if (Registro % 2 != 0)
                {
                    if (Registro < TotalRegistro)
                    {
                        Valor1 = mListaPedidoDetalleOrigen[Registro - 1].PrecioVenta;
                        Valor2 = mListaPedidoDetalleOrigen[Registro].PrecioVenta;
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
                    mListaPedidoDetalleOrigen[Registro - 1].PorcentajeDescuento = Descuento;
                    mListaPedidoDetalleOrigen[Registro - 1].PrecioVenta = Math.Round(Math.Round(item.PrecioUnitario, 2) * ((100 - Descuento) / 100), 2);
                    mListaPedidoDetalleOrigen[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }
                else
                {
                    Descuento = 0;
                    mListaPedidoDetalleOrigen[Registro - 1].PorcentajeDescuento = Descuento;
                    mListaPedidoDetalleOrigen[Registro - 1].PrecioVenta = Math.Round(item.PrecioUnitario, 2);
                    mListaPedidoDetalleOrigen[Registro - 1].ValorVenta = item.Cantidad * item.PrecioVenta;
                }


                Registro = Registro + 1;
            }
            #endregion


            //Agregar Sin Promoción 
            #region "Agregar códigos sin promoción"
            foreach (PedidoDetalleBE item in lst_PedidoDetalleSinPromo)
            {
                PedidoDetalleBE objE_DocumentoDetalle = new PedidoDetalleBE();
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
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_DocumentoDetalle);
            }
            #endregion


            mListaDetalle = mListaPedidoDetalleOrigen;
            mListaPedidoDetalleOrigen = null;

            ////bsListado.DataSource = mListaPedidoDetalleOrigen2Promo;
            //bsListado.DataSource = mListaPedidoDetalleOrigen2;
            //gPedidoDetalleBE.DataSource = bsListado;
            //gPedidoDetalleBE.RefreshDataSource();


            #region "Calcular Total"
            //decimal deImpuesto = 0;
            //decimal deValorVenta = 0;
            //decimal deSubTotal = 0;
            //decimal deTotal = 0;
            //int intTotalCantidad = 0;
            ////decimal deMinimoVale = 0;//add 240516 -- menor a 20%

            //if (mListaPedidoDetalleOrigen.Count > 0)
            //{
            //    foreach (var item in mListaPedidoDetalleOrigen)
            //    {
            //        intTotalCantidad = intTotalCantidad + item.Cantidad;
            //        deValorVenta = item.ValorVenta;
            //        deTotal = deTotal + deValorVenta;
            //    }

            //    //txtTotalBruto.EditValue = 0;//add may 25

            //    deTotal = Math.Round(deTotal, 2);
            //    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
            //    deImpuesto = Math.Round(deTotal - deSubTotal, 2);
            //    txtTotal.EditValue = deTotal;
            //    txtSubTotal.EditValue = deSubTotal;
            //    txtImpuesto.EditValue = deImpuesto;
            //    txtTotalCantidad.EditValue = intTotalCantidad;
            //}
            //else
            //{
            //    txtTotalCantidad.EditValue = 0;
            //    txtSubTotal.EditValue = 0;
            //    txtImpuesto.EditValue = 0;
            //    txtTotal.EditValue = 0;
            //}
            #endregion


            //CalculaTotales();
            ////CalculaTotalesPromo();

            #endregion

        }




        #endregion

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

        public class CMovimientoCaja
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdMovimientoCaja { get; set; }
            public Int32 IdCaja { get; set; }
            public DateTime Fecha { get; set; }
            public Int32 IdTipoDocumento { get; set; }
            public String NumeroDocumento { get; set; }
            public Int32 IdFormaPago { get; set; }
            public Int32 IdCondicionPago { get; set; }
            public String TipoMovimiento { get; set; }
            public Int32 IdMoneda { get; set; }
            public Decimal TipoCambio { get; set; }
            public Decimal ImporteSoles { get; set; }
            public Decimal ImporteDolares { get; set; }
            public Int32 IdDocumentoVenta { get; set; }

            public CMovimientoCaja()
            {

            }

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }
    }
}