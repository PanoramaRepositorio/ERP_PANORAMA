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
using ErpPanorama.Presentation.Modulos.Maestros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Registros;
using ErpPanorama.Presentation.Funciones;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.ws_integrens;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegFacturacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        ws_integrensSoapClient WS = new ws_integrensSoapClient();
        FacturacionElectronica FacturaE = new FacturacionElectronica();

        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigenPromo = new List<CDocumentoVentaDetalle>();
        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigenTemp = new List<CDocumentoVentaDetalle>();


        int _IdDocumentoVenta = 0;
        int _IdEstadoCuenta2 = 0;

        public int IdDocumentoVenta
        {
            get { return _IdDocumentoVenta; }
            set { _IdDocumentoVenta = value; }
        }

        public int IdEstadoCuenta2
        {
            get { return _IdEstadoCuenta2; }
            set { _IdEstadoCuenta2 = value; }
        }

        private int IdTienda = Parametros.intTiendaId;
        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private int IdTipoDocumentoCliente = 0;
        //private int IdClasificacionClienteAsociado = 0;
        private int IdPedido = 0;
        private int IdDocumentoReferencia = 0;
        private string Serie;
        private string Numero;
        private int IdCambio = 0;
        private string NumeroDevolucion = "";
        private int IdFormaPago = 0;
        private int IdMonedaPedido = 0;
        private decimal decTotalPedido = 0;
        private string NumeroCredito;
        private int IdNumeracionDocumento = 0;
        private int IdAsesorExterno = 0;
        decimal decTotalVentaDolares = 0;
        private Int32 NumeroCaracter = 6;
        private string CodigoNC = "";
        private int IdSituacion = 0;
        private decimal TipoCambioPedido = 0;
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public DocumentoVentaBE mDocumentoVentaE = new DocumentoVentaBE();

        #endregion
        decimal vDsctoPorcentaje = 0;
        decimal vTotalDscto = 0;
        decimal vMercadop = 0;
        public int vIdDocumentoVenta = 0;
        public bool bFlagCumpleanios = false;
        #region "Eventos"

        public frmRegFacturacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegFacturacionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            deFecha.EditValue = DateTime.Now;
            deFechaVencimiento.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentasSunat, 0), "CodTipoDocumento", "IdTipoDocumento", false);
            cboDocumento.EditValue = Parametros.intTipoDocNotaCredito;
            //BSUtils.LoaderLook(cboDocumentoReferencia, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentasSunat, 0), "CodTipoDocumento", "IdTipoDocumento", false);
            BSUtils.LoaderLook(cboDocumentoReferencia, new ModuloDocumentoBL().ListaVentasNC(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", false);
            BSUtils.LoaderLook(cboTipoNotaDebito, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblNotaDebito), "DescTablaElemento", "IdTablaElemento", true);
            

            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            txtPeriodo.EditValue = DateTime.Now.Year;

            if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Facturación - Modificar";

                BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", false);

                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);

                if (objE_DocumentoVenta != null)
                {
                    if (objE_DocumentoVenta.IdPedido != null)
                    {
                        IdPedido = Convert.ToInt32(objE_DocumentoVenta.IdPedido);//ad 12-11
                    }
                    cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                    IdTienda = objE_DocumentoVenta.IdTienda;
                    cboDocumento.EditValue = objE_DocumentoVenta.IdTipoDocumento;
                    txtSerie.EditValue = objE_DocumentoVenta.Serie;
                    txtNumero.Text = objE_DocumentoVenta.Numero;


                    cboDocumentoReferencia.EditValue = objE_DocumentoVenta.IdTipoDocumentoReferencia;
                    txtSerieReferencia.Text = objE_DocumentoVenta.SerieReferencia;
                    txtNumeroReferencia.Text = objE_DocumentoVenta.NumeroReferencia;
                    dtFechaRef.EditValue = objE_DocumentoVenta.FechaReferencia;

                    deFecha.EditValue = objE_DocumentoVenta.Fecha;
                    txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                    cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                    cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                    deFechaVencimiento.EditValue = objE_DocumentoVenta.FechaVencimiento;
                    cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                    txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                    IdCliente = objE_DocumentoVenta.IdCliente;
                    IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                    IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                    txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                    txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                    else
                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                    txtDireccion.Text = objE_DocumentoVenta.Direccion;
                    txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                    txtDescuento.EditValue = objE_DocumentoVenta.PorcentajeDescuento;
                    txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                    txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                    txtTotal.EditValue = objE_DocumentoVenta.Total;
                    txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;//add
                    txtObservacion.Text = objE_DocumentoVenta.Observacion;
                    CodigoNC = objE_DocumentoVenta.CodigoNC;
                    IdSituacion = objE_DocumentoVenta.IdSituacion;
                    lblFechaRegistro.Text = "F. Registro: " + objE_DocumentoVenta.FechaRegistro.ToString();

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                    {
                        XtraMessageBox.Show("No se puede modificar la nota de credito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnGrabar.Enabled = false;
                    }
                    //else
                    //{
                    //    //btnGrabar.Enabled = true;
                    //}
                    bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios;
                    if (bFlagCumpleanios)
                    {
                        decimal dTotalDscCumpleanios = objE_DocumentoVenta.TotalDscCumpleanios;
                        decimal dTotalSinDscCumple = Math.Round(dTotalDscCumpleanios + objE_DocumentoVenta.Total, 2);
                        txtDsctoCumple.EditValue = objE_DocumentoVenta.TotalDscCumpleanios;
                        txtTotalSinDscCumple.EditValue = dTotalSinDscCumple;
                    }
                    cboSerie.Visible = false;

                }

            }

            CargaDocumentoVentaDetalle();

            FiltroMenuContextual();

            txtNumeroPedido.Focus();
            CalculaTotales();
        }

        private void frmRegFacturacionEdit_Shown(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)//add 1711
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
                }

                if (bolFlag)
                {
                    this.Close();
                }
            }
        }

        private void gvDocumentoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Cantidad")
            {
                decimal decCantidad = 0;
                decimal decPrecioVenta = 0;
                decimal decValorVenta = 0;

                decCantidad = decimal.Parse(e.Value.ToString());
                decPrecioVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitario").ToString()) * ((100 - decimal.Parse(gvDocumentoDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
                decValorVenta = decPrecioVenta * decCantidad;
                gvDocumentoDetalle.SetRowCellValue(e.RowHandle, "PrecioVenta", decPrecioVenta);
                gvDocumentoDetalle.SetRowCellValue(e.RowHandle, "ValorVenta", decValorVenta);

            }

            CalculaTotales();
        }

        private void CalculaTotalPromocion2x1_ecm()
        {
            if (IdTipoCliente != Parametros.intTipClienteFinal) return;
            if (IdClasificacionCliente == Parametros.intBlack) return;
            #region "2022/06 ecm 2x1 v2"
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
                                PorcentajeDesc = item.PorcentajeDescuento;

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

                    decimal pVenta = Math.Round(dSuma / iCant, 2); // (dSuma / iCant );
                    decimal PrecioVenta2x1 = Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2);
                    decimal ValorVenta2x1 = Math.Round(PrecioVenta2x1 * iCant, 2); // Math.Round(pVenta * iCant, 2);

                    //decimal pVenta =  (dSuma / iCant );
                    //decimal PrecioVenta2x1 =  Math.Round(pVenta, 2);
                    //decimal ValorVenta2x1 = Math.Round(pVenta * iCant, 2);

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
                                PorcentajeDesc = item.PorcentajeDescuento;

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

                    //decimal pVenta =   Math.Round(dSuma / iCant, 2); // (dSuma / iCant );
                    //decimal PrecioVenta3x2 = Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2);
                    //decimal ValorVenta3x2 =  Math.Round(PrecioVenta3x2 * iCant, 2); // Math.Round(pVenta * iCant, 2);
                    decimal pVenta = (dSuma / iCant);
                    decimal PrecioVenta3x2 = Math.Round(pVenta, 2);
                    decimal ValorVenta3x2 = Math.Round(pVenta * iCant, 2);

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
            #endregion
        }
        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            int intIdMoneda = 0;
            intIdMoneda = int.Parse(cboMoneda.EditValue.ToString());
            CalcularValoresGrilla(intIdMoneda);
            CalculaTotalPromocion2x1_ecm();
            if (mListaDocumentoVentaDetalleOrigen.Where(x => x.DescPromocion.Length > 0).ToList().Count > 0)
            {
                bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                gcDocumentoDetalle.DataSource = bsListado;
                gcDocumentoDetalle.RefreshDataSource();
            }
            CalculaTotales();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    if (txtNumeroDocumento.Text.Trim().Length != frm.pClienteBE.NumeroDocumento.Length)
                    {
                        XtraMessageBox.Show("No se puede cambiar de un RUC a Dni o Viceversa. Consulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                        cboMoneda.EditValue = Parametros.intSoles;
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
                            XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente un 10% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            try

            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información del Pedido
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumeroPedido.Text.Trim());
                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.IdSituacion == Parametros.intFacturado || objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                        {
                            XtraMessageBox.Show("El N° Pedido ya está cancelado, no se puede facturar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (objE_Pedido.IdSituacion == Parametros.intPVAnulado)
                        {
                            XtraMessageBox.Show("El N° Pedido está cancelado, no se puede facturar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //if (objE_Pedido.IdSituacion != Parametros.intPVAprobado)
                        //{
                        //    XtraMessageBox.Show("El N° Pedido no está APROBADO, no se puede facturar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}


                        if (objE_Pedido.IdFormaPago == Parametros.intContado)
                        {
                            XtraMessageBox.Show("El pedido es CONTADO, se recomienda facturar por el módulo de ventas contado.\nPara más información consultar con el área de sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (objE_Pedido.IdTienda != Parametros.intTiendaId)
                        {
                            //if (XtraMessageBox.Show("El Pedido pertenece a " + objE_Pedido.DescTienda +", Desea facturar de todas formas.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            //{
                            //    return;
                            //}
                            XtraMessageBox.Show("El Pedido pertenece a " + objE_Pedido.DescTienda + ", no se puede facturar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (objE_Pedido.FlagPreVenta)
                        {
                            XtraMessageBox.Show("El Pedido es de preventa Ud. debe generar una copia, no se puede facturar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ////verificar ingreso de N/S  -- add 010716
                        //List<MovimientoAlmacenBE> lst_MovimientoNS = new List<MovimientoAlmacenBE>();
                        //lst_MovimientoNS = new MovimientoAlmacenBL().ListaNotaSalidaPendientePedido(objE_Pedido.IdPedido);

                        //if (lst_MovimientoNS.Count > 0)
                        //{
                        //    string NumeroNS = "";
                        //    foreach (var item in lst_MovimientoNS)
                        //    {
                        //        NumeroNS = NumeroNS + ", " + item.DescAlmacen + ":" + item.Numero;
                        //    }
                        //    XtraMessageBox.Show("No se puede iniciar el picking faltan recibir N/S." + NumeroNS, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        //Pedido chequeado
                        if (Parametros.intTiendaId == Parametros.intTiendaUcayali)
                        {
                            //if (objE_Pedido.Despachar == "ALMACEN")
                            //{
                            MovimientoPedidoBE objE_MovimientoPedido = null;
                            objE_MovimientoPedido = new MovimientoPedidoBL().Selecciona(objE_Pedido.IdPedido);
                            if (objE_MovimientoPedido != null)
                            {
                                if (!objE_MovimientoPedido.Chequeado && objE_Pedido.IdCliente != 236149)
                                {
                                    if (objE_Pedido.Despachar == "ALMACEN")
                                    {
                                        XtraMessageBox.Show("El pedido tiene que terminar el proceso de chequeo para poder facturar(Bóton FINALIZAR), Favor de Consultar con Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("El pedido tiene que terminar el proceso de chequeo por DESPACHO, Favor de Consultar con 'Carmencita Lara'.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                }
                            }
                            //}
                        }

                        IdPedido = objE_Pedido.IdPedido;
                        txtNumeroPedido.Text = objE_Pedido.Numero;
                        cboVendedor.EditValue = objE_Pedido.IdVendedor;
                        cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                        cboMoneda.EditValue = objE_Pedido.IdMoneda;
                        // txtTipoCambio.EditValue = objE_Pedido.TipoCambio; //del 19-02-19

                        if (pOperacion == Operacion.Nuevo)
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
                            }

                            if (bolFlag)
                            {
                                this.Close();
                            }
                        }

                        TipoCambioPedido = objE_Pedido.TipoCambio;
                        IdCliente = objE_Pedido.IdCliente;
                        IdTipoCliente = objE_Pedido.IdTipoCliente;
                        IdTipoDocumentoCliente = objE_Pedido.IdTipoDocumentoCliente;
                        //txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                        //txtDescCliente.Text = objE_Pedido.DescCliente;
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                        //txtDireccion.Text = objE_Pedido.Direccion;
                        cboMotivo.EditValue = objE_Pedido.IdMotivo;

                        decTotalPedido = objE_Pedido.Total;
                        IdClasificacionCliente = objE_Pedido.IdClasificacionCliente;
                        IdMonedaPedido = objE_Pedido.IdMoneda;
                        IdFormaPago = objE_Pedido.IdFormaPago;
                        IdAsesorExterno = objE_Pedido.IdAsesorExterno;
                        CodigoNC = "";
                        txtDescuento.EditValue = objE_Pedido.PorcentajeDescuento;//add 01/09
                        txtTotalDescuento.EditValue = objE_Pedido.Descuento;
                        vDsctoPorcentaje = objE_Pedido.PorcentajeDescuento; ;
                        vTotalDscto = objE_Pedido.Descuento;

                        cboVendedor.Enabled = false;


                        if (objE_Pedido.TotalBruto != 0)
                        {
                            txtDescuento.EditValue = Math.Round((vTotalDscto * 100) / objE_Pedido.TotalBruto, 15);
                        }
                        else
                        {
                            txtDescuento.EditValue = 0;
                        }

                        /// Luis Comento el 01/03/2021 --- Mercado pago
                        //if ((objE_Pedido.TotalBruto - objE_Pedido.Total) > 1)//add 16/11/15
                        //{
                        //    txtDescuento.EditValue = Math.Round(Math.Round(((1 - (objE_Pedido.Total / objE_Pedido.TotalBruto)) * 100), 4), 4);
                        //    //txtDescuento.EditValue = Math.Round(objE_Pedido.PorcentajeDescuento + Math.Round(((1 - (objE_Pedido.Total / objE_Pedido.TotalBruto)) * 100), 4), 4);

                        //    //Verificar Tipo de Afectación de IGV  --ADD 151118
                        //}

                        //Para Facturacion
                        if (objE_Pedido.IdClienteAsociado == 0)
                        {
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                            txtDescCliente.Text = objE_Pedido.DescCliente;
                            txtDireccion.Text = objE_Pedido.Direccion;
                        }
                        else
                        {
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumentoAsociado;
                            txtDescCliente.Text = objE_Pedido.DescClienteAsociado;
                            txtDireccion.Text = objE_Pedido.DireccionAsociado;
                            txtDescClientePrincipal.Text = objE_Pedido.DescCliente;
                        }

                        if (objE_Pedido.IdFormaPago == Parametros.intCredito) //Dias de Linea crédito
                        {
                            //int NumDias = 0;

                            //ClienteCreditoBE objClienteCredito = null;
                            //objClienteCredito = new ClienteCreditoBL().SeleccionaCliente(objE_Pedido.IdEmpresa, objE_Pedido.IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                            //if (objClienteCredito != null)
                            //{
                            //    NumDias = objClienteCredito.NumeroDias;
                            //}
                            //deFechaVencimiento.EditValue = deFecha.DateTime.AddDays(NumDias); //Fecha del Pedido o Facturación????


                            //Facturas Navideñas
                            if (objE_Pedido.IdMotivo == Parametros.intMotivoVentaNavidad)//add 04 /09
                            {
                                deFechaVencimiento.EditValue = Convert.ToDateTime("24/12/" + DateTime.Now.Year); //objE_Pedido.FechaVencimiento;
                            }
                            else
                            {
                                if (IdCliente == 174260)  // Zanolli Castellani Rafaella 
                                {
                                    deFechaVencimiento.EditValue = deFecha.DateTime.AddDays(15);
                                }
                                else
                                {
                                    if (decTotalPedido <= 500)
                                    {
                                        deFechaVencimiento.EditValue = deFecha.DateTime.AddDays(30);
                                    }
                                    else if (decTotalPedido > 500 && decTotalPedido <= 1500)
                                    {
                                        deFechaVencimiento.EditValue = deFecha.DateTime.AddDays(45);
                                    }
                                    else if (decTotalPedido > 1500)
                                    {
                                        deFechaVencimiento.EditValue = deFecha.DateTime.AddDays(60);
                                    }
                                }
                            }

                            //cboMoneda.EditValue = Parametros.intDolares;
                            //cboMoneda.Properties.ReadOnly = true;
                        }
                        else
                        {
                            deFechaVencimiento.EditValue = DateTime.Now;
                        }


                        SeteaDocumentoDetalle();

                        //Traemos la información del detalle del Pedido
                        List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                        lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);
                        int nItem = 1;
                        foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
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
                            objE_DocumentoDetalle.IdMarca = item.IdMarca;//ECM3
                            objE_DocumentoDetalle.FlagMuestra = false;
                            objE_DocumentoDetalle.FlagRegalo = false;
                            objE_DocumentoDetalle.Stock = 0;
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                            if (item.CodAfeIGV == Parametros.strGravadoOnerosa && item.PorcentajeDescuento == 100)
                            {
                                XtraMessageBox.Show(item.CodigoProveedor + " No se puede facturar un producto con 100% de descuento\nDebe realizar una venta por obsequio o Asignarle como bonificación .", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                                return;
                            }

                            //if(objE_Pedido.IdFormaPago ==Parametros.intObsequio)
                            //{
                            //    if (item.PorcentajeDescuento > 0)
                            //    {
                            //        XtraMessageBox.Show("No se puede facturar Obsequios con Descuentos.\n" + item.CodigoProveedor + " tiene " + item.PorcentajeDescuento + "% Descuento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        this.Close();
                            //        return;
                            //    }
                            //}

                            nItem = nItem + 1;
                        }

                        bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                        gcDocumentoDetalle.DataSource = bsListado;
                        gcDocumentoDetalle.RefreshDataSource();

                        bFlagCumpleanios = objE_Pedido.FlagCumpleanios;
                        //ECM3
                        //if (bFlagCumpleanios)
                        //{
                        //    decimal dTotalDscCumpleanios = objE_Pedido.TotalDscCumpleanios;
                        //    decimal dTotalSinDscCumple = Math.Round(dTotalDscCumpleanios + objE_Pedido.Total,2);
                        //    txtDsctoCumple.EditValue = objE_Pedido.TotalDscCumpleanios;
                        //    txtTotalSinDscCumple.EditValue = dTotalSinDscCumple;
                        //}

                        CalculaTotales();

                        /// Luis Comento el 01/03/2021 --- Mercado pago
                        //if ((objE_Pedido.TotalBruto - objE_Pedido.Total) > 1)//add 151118
                        //{
                        //    ////Verificar Tipo de Afectación de IGV  --ADD 151118
                        //    CalculaTotalPromocion2x1();
                        //}

                        if (Parametros.intPerfilId == Parametros.intPerAdministrador)
                        {
                            mnuContextual.Enabled = true;
                            cboMotivo.Properties.ReadOnly = false;
                        }

                        else
                            mnuContextual.Enabled = false;
                    }
                    //txtDescuento.EditValue = vDsctoPorcentaje;
                    //txtDscto.EditValue = vTotalDscto;
                    //CalculaTotales();
                    //CalculaTotales();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                if (objE_Cliente != null)
                {
                    IdCliente = objE_Cliente.IdCliente;
                    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = objE_Cliente.DescCliente;
                    txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion;
                    IdTipoCliente = objE_Cliente.IdTipoCliente;
                    IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                        cboMoneda.EditValue = Parametros.intSoles;
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
                            XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente un 10% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                {
                    XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cboFormaPago_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboFormaPago.EditValue != null)
            //{
            //    DateTime dt = Convert.ToDateTime(deFecha.EditValue);
            //    switch (Convert.ToInt32(cboFormaPago.EditValue))
            //    {
            //        case 70: dt = dt.AddDays(30);
            //            deFechaVencimiento.EditValue = dt;
            //            break;
            //        case 72: dt = dt.AddDays(45);
            //            deFechaVencimiento.EditValue = dt;
            //            break;
            //        case 71: dt = dt.AddDays(60);
            //            deFechaVencimiento.EditValue = dt;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvDocumentoDetalle.AddNewRow();
                gvDocumentoDetalle.SetRowCellValue(gvDocumentoDetalle.FocusedRowHandle, "Item", (mListaDocumentoVentaDetalleOrigen.Count - 1) + 1);
                if (pOperacion == Operacion.Modificar)
                    gvDocumentoDetalle.SetRowCellValue(gvDocumentoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                else
                    gvDocumentoDetalle.SetRowCellValue(gvDocumentoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                gvDocumentoDetalle.FocusedColumn = gvDocumentoDetalle.GetVisibleColumn(1);
                gvDocumentoDetalle.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {

                    #region "Multiple"


                    for (int i = 0; i < gvDocumentoDetalle.SelectedRowsCount; i++)
                    {
                        int IdProducto = 0;
                        int IdDocumentoDetalle = 0;
                        int Cantidad = 0;
                        int Item = 0;

                        int row = gvDocumentoDetalle.GetSelectedRows()[i];
                        IdProducto = int.Parse(gvDocumentoDetalle.GetRowCellValue(row, "IdProducto").ToString());
                        IdDocumentoDetalle = int.Parse(gvDocumentoDetalle.GetRowCellValue(row, "IdDocumentoVentaDetalle").ToString());
                        Cantidad = int.Parse(gvDocumentoDetalle.GetRowCellValue(row, "Cantidad").ToString());
                        Item = int.Parse(gvDocumentoDetalle.GetRowCellValue(row, "Item").ToString());


                        if (int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                        {
                            DocumentoVentaDetalleBE objBE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                            objBE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = IdDocumentoDetalle;
                            objBE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objBE_DocumentoVentaDetalle.IdTienda = Parametros.intTiendaId;
                            objBE_DocumentoVentaDetalle.Periodo = Parametros.intPeriodo;
                            objBE_DocumentoVentaDetalle.Numero = txtNumero.Text;
                            objBE_DocumentoVentaDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objBE_DocumentoVentaDetalle.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                            objBE_DocumentoVentaDetalle.IdProducto = IdProducto;
                            objBE_DocumentoVentaDetalle.Cantidad = Cantidad;
                            objBE_DocumentoVentaDetalle.Usuario = Parametros.strUsuarioLogin;
                            objBE_DocumentoVentaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            DocumentoVentaDetalleBL objBL_DocumentoVentaDetalle = new DocumentoVentaDetalleBL();
                            objBL_DocumentoVentaDetalle.EliminaFisico(objBE_DocumentoVentaDetalle);
                            mListaDocumentoVentaDetalleOrigen.RemoveAt(gvDocumentoDetalle.FocusedRowHandle);
                            gvDocumentoDetalle.RefreshData();


                            //Actualizar totales
                            CalculaTotales();

                            #region "Modificar"
                            if (pOperacion == Operacion.Modificar)
                            {
                                if (!ValidarIngreso())
                                {
                                    //Generamos el documento cabecera.
                                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                                    objDocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                                    objDocumentoVenta.IdTienda = IdTienda;//Parametros.intTiendaId;
                                    objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                                    objDocumentoVenta.Serie = txtSerie.Text;
                                    objDocumentoVenta.Numero = txtNumero.Text;
                                    objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
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
                                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR FACTURACIÓN | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR FACTURACIÓN";
                                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                                    objDocumentoVenta.FlagEstado = true;
                                    objDocumentoVenta.IdCambio = IdCambio;
                                    objDocumentoVenta.NumeroDevolucion = NumeroDevolucion;
                                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                                    //Documento Vneta Detalle
                                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                                    lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                                    {
                                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                                        objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;//0
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
                                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                                        objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                                        objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                                        objE_DocumentoVentaDetalle.FlagEstado = true;
                                        objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                                    }

                                    objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);

                                }
                                return;
                            }
                            #endregion


                            //RegeneraItem
                            int k = 0;
                            int cuenta = 0;
                            foreach (var item in mListaDocumentoVentaDetalleOrigen)
                            {
                                item.Item = Convert.ToInt32(cuenta + 1);
                                cuenta++;
                                k++;
                            }
                        }
                        else
                        {
                            gvDocumentoDetalle.DeleteRow(gvDocumentoDetalle.FocusedRowHandle);
                            gvDocumentoDetalle.RefreshData();
                        }
                    }

                    #endregion


                    if (int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdDocumentoDetalle = 0;
                        IdDocumentoDetalle = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                        //if (gvDocumentoDetalle.GetFocusedRowCellValue("IdPedidoDetalle") != null)
                        //    IdDocumentoDetalle = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                        int Item = 0;
                        if (gvDocumentoDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("Item").ToString());
                        DocumentoVentaDetalleBE objBE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                        objBE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = IdDocumentoDetalle;
                        objBE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_DocumentoVentaDetalle.IdTienda = Parametros.intTiendaId;
                        objBE_DocumentoVentaDetalle.Periodo = Parametros.intPeriodo;
                        objBE_DocumentoVentaDetalle.Numero = txtNumero.Text;
                        objBE_DocumentoVentaDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objBE_DocumentoVentaDetalle.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objBE_DocumentoVentaDetalle.IdProducto = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                        objBE_DocumentoVentaDetalle.Cantidad = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("Cantidad").ToString());
                        objBE_DocumentoVentaDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_DocumentoVentaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        DocumentoVentaDetalleBL objBL_DocumentoVentaDetalle = new DocumentoVentaDetalleBL();
                        //objBL_DocumentoVentaDetalle.Elimina(objBE_DocumentoVentaDetalle);//Logico
                        objBL_DocumentoVentaDetalle.EliminaFisico(objBE_DocumentoVentaDetalle);
                        mListaDocumentoVentaDetalleOrigen.RemoveAt(gvDocumentoDetalle.FocusedRowHandle);
                        //gvDocumentoDetalle.DeleteRow(gvDocumentoDetalle.FocusedRowHandle);
                        gvDocumentoDetalle.RefreshData();


                        //Actualizar totales
                        CalculaTotales();

                        #region "Modificar"
                        if (pOperacion == Operacion.Modificar)
                        {
                            if (!ValidarIngreso())
                            {
                                //Generamos el documento cabecera.
                                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                                objDocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                                objDocumentoVenta.IdTienda = IdTienda;//Parametros.intTiendaId;
                                objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                                objDocumentoVenta.Mes = deFecha.DateTime.Month;
                                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                                objDocumentoVenta.Serie = txtSerie.Text;
                                objDocumentoVenta.Numero = txtNumero.Text;
                                objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
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
                                objDocumentoVenta.Observacion = "DOC. GENERADO  POR FACTURACIÓN | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR FACTURACIÓN";
                                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                                objDocumentoVenta.FlagEstado = true;
                                objDocumentoVenta.IdCambio = IdCambio;
                                objDocumentoVenta.NumeroDevolucion = NumeroDevolucion;
                                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                                //Documento Vneta Detalle
                                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                                {
                                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                                    objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                                    objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;//0
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
                                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                                    objE_DocumentoVentaDetalle.FlagEstado = true;
                                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                                }

                                objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);

                            }
                            return;
                        }
                        #endregion


                        //RegeneraItem
                        int i = 0;
                        int cuenta = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            item.Item = Convert.ToInt32(cuenta + 1);
                            cuenta++;
                            i++;
                        }
                    }
                    else
                    {
                        gvDocumentoDetalle.DeleteRow(gvDocumentoDetalle.FocusedRowHandle);
                        gvDocumentoDetalle.RefreshData();
                    }
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIngreso())
            {
                if (gvDocumentoDetalle.RowCount == 0)
                    return;

                //if (Parametros.intMes != deFecha.DateTime.Month)
                //{
                //    XtraMessageBox.Show("El mes de la factura no coincide con el mes contable actual \n. No se puede Facturar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (txtNumeroDocumento.Text.Trim().Length < 11 && (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)) // Validar RUC DE AS
                {
                    XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura) // Validar RUC DE AS
                {
                    XtraMessageBox.Show("No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region "Validar Nota Credito"
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaDebitoElectronica)
                {
                    if (IdDocumentoReferencia == 0)
                    {
                        XtraMessageBox.Show("No se puede generar una nota de crédito, por favor verifique el documento de REFERENCIA.\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (IdCliente == Parametros.intIdClienteGeneral)
                    {
                        XtraMessageBox.Show("No se generar una Nota de crédito con " + Parametros.strDescCliente, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //if (txtSerie.Text.Length != txtSerieReferencia1.Text.Length)
                    //{
                    //    XtraMessageBox.Show("No se emitir una Nota de Crédito Electrónica con Nota de Credito Física o Viceversa\nPara más información consultar con el área contable.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        if (txtSerie.Text.Substring(0, 1) != txtSerieReferencia.Text.Substring(0, 1))
                        {
                            XtraMessageBox.Show("La serie de la Nota de credito debe comenzar con:" + txtSerieReferencia.Text.Substring(0, 1), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else
                {
                    if (IdDocumentoReferencia > 0)
                    {
                        XtraMessageBox.Show("No se puede generar una BOLETA/FACTURA de Venta con origen de otro documento.\nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion

                #region "Modificar"
                if (pOperacion == Operacion.Modificar)
                {
                    if (!ValidarIngreso())
                    {
                        //Generamos el documento cabecera.
                        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                        DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                        objDocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                        objDocumentoVenta.IdTienda = IdTienda;//Parametros.intTiendaId;
                        objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                        objDocumentoVenta.Periodo = Parametros.intPeriodo;
                        objDocumentoVenta.Mes = deFecha.DateTime.Month;
                        objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objDocumentoVenta.Serie = txtSerie.Text;
                        objDocumentoVenta.Numero = txtNumero.Text;
                        objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
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
                        objDocumentoVenta.Observacion = "DOC. GENERADO POR FACTURACIÓN | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();  // "DOCUMENTO DE VENTA GENERADO POR FACTURACIÓN";
                        objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                        objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                        objDocumentoVenta.FlagEstado = true;
                        objDocumentoVenta.IdCambio = IdCambio;
                        objDocumentoVenta.NumeroDevolucion = NumeroDevolucion;
                        objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                        objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                        //Documento Vneta Detalle
                        List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                        lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                            objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;//0
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
                            objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                            objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                            objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                            objE_DocumentoVentaDetalle.IdPromocion2 = item.IdPromocion2;
                            objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                            objE_DocumentoVentaDetalle.FlagEstado = true;
                            objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                            lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                        }

                        objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);

                    }
                    this.Close();
                    return;
                }
                #endregion

                // BOLETA VENTA - FISICA
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) // CUANDO ES BOLETA DE VENTA
                {
                    if (!ValidarTopeEmpresaRus())
                    {
                        InsertarEstadoCuenta(); //Estado de Cuenta
                        if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVenta();
                            if (XtraMessageBox.Show("Esta seguro de imprimir la boleta de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                #region "Impresion"
                                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores)//Verificando Panorama
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                    if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores) //Verificando Corona
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                {
                                    ImpresionDirectaDesglosable();
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaVarios(6);
                            if (XtraMessageBox.Show("Esta seguro de imprimir la boleta de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                #region "Impresion"
                                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores)//Verificando Panorama
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                    if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores) //Verificando Corona
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                {
                                    ImpresionDirectaDesglosable();
                                }
                                #endregion
                            }
                        }
                    }
                }

                // FACTURA - FISICA
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
                {
                    if (!ValidarTopeEmpresaRus())
                    {
                        InsertarEstadoCuentaDiseñador();
                        InsertarEstadoCuenta(); //Estado de Cuenta
                        if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
                        {
                            InsertarDocumentoVenta();
                            if (XtraMessageBox.Show("Esta seguro de imprimir la factura de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                #region "Impresion"
                                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores)//Verificando Panorama
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                    if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores) //Verificando Corona
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                {
                                    ImpresionDirectaDesglosable();
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarDocumentoVentaVarios(10);
                            if (XtraMessageBox.Show("Esta seguro de imprimir la factura de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                #region "Impresion"
                                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores)//Verificando Panorama
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                    if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores) //Verificando Corona
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                {
                                    ImpresionDirectaDesglosable();
                                }
                                #endregion
                            }
                        }
                    }
                }

                //ADDD TEMPORAL PARA ticket FACTURACION
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura) //ticket
                {
                    if (txtSerie.Text == "007")
                    {
                        if (!ValidarTopeEmpresaRus())
                        {
                            InsertarEstadoCuentaDiseñador();
                            InsertarEstadoCuenta(); //Estado de Cuenta
                            InsertarDocumentoVenta();
                            ImpresionTicketFisico(cboDocumento.Text, 0);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Sólo se puede generar TICKETs con la serie 007", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // BOLETA ELECTRONICA
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica) //BOLETA ELECTRONICA
                {
                    if (!ValidarTopeEmpresaRus())
                    {
                        InsertarEstadoCuenta(); //Estado de Cuenta
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta();
                    }
                }

                // FACTURA ELECTRONICA
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica) //FACTURA ELECTRONICA
                {
                    if (!ValidarTopeEmpresaRus())
                    {
                        InsertarEstadoCuenta(); //Estado de Cuenta    
                        InsertarEstadoCuentaDiseñador();
                        InsertarDocumentoVenta();
                    }
                }

                // NOTA CREDITO ELECTRONICA
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica) // CREDITO ELECTRONICA
                {
                    InsertarDocumentoVenta();
                }

                // Nota de Debito Electronica
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaDebitoElectronica)  
                {
                    InsertarDocumentoVenta();
                }


                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito) //CUANDO ES NOTA DE CREDITO
                {
                    if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
                    {
                        InsertarDocumentoVenta();
                        if (XtraMessageBox.Show("Esta seguro de imprimir la nota de credito?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ImpresionDirectaDesglosable();
                        }
                    }
                    else
                    {
                        InsertarDocumentoVentaVarios(10);
                        if (XtraMessageBox.Show("Esta seguro de imprimir la nota de credito?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ImpresionDirectaDesglosable();
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtTipoCambio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvDocumentoDetalle.RowCount > 0)
                {
                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                    {
                        int posicion = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;

                            decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString());
                            decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                            decPrecioVenta = (decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100)) / decimal.Parse(Parametros.dmlTCMayorista.ToString()) * decimal.Parse(txtTipoCambio.Text);
                            decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);

                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"], decValorVenta);
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
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(txtTipoCambio.Text);
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(txtTipoCambio.Text);
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;

                            }
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                }

                CalculaTotales();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroPedido_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboDocumento.Focus();
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                cboSerie.Select();
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDocumentoReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSerieReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboFormaPago_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (pOperacion == Operacion.Nuevo)
                {
                    //BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo), "Serie", "Serie", true);
                    List<NumeracionDocumentoBE> lst_Numeracion = new List<NumeracionDocumentoBE>();
                    lst_Numeracion = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboDocumento.EditValue), true, Parametros.intPeriodo);

                    if (lst_Numeracion.Count > 0)
                    {
                        cboSerie.EditValue = 0;
                        BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboDocumento.EditValue), true, Parametros.intPeriodo), "Serie", "IdNumeracionDocumento", true);
                    }
                    else
                    {
                        LimpiarCargaCorrelativo();
                        BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboDocumento.EditValue), true, Parametros.intPeriodo), "Serie", "IdNumeracionDocumento", true);
                    }
                }

                if (Convert.ToInt32(cboDocumento.EditValue) == 110)
                {
                    lblTipoNotaDebito.Visible = true;
                    cboTipoNotaDebito.Visible = true;
                    cboTipoNotaDebito.Select();
                }
                else
                {
                    lblTipoNotaDebito.Visible = false;
                    cboTipoNotaDebito.Visible = false;
                }

            }
            catch (Exception ex)
            {
              //  XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSerie_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                List<NumeracionDocumentoBE> lst_Numeracion = new List<NumeracionDocumentoBE>();
                lst_Numeracion = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), cboSerie.Text);
                if (lst_Numeracion.Count > 0)
                {
                    txtSerie.Text = cboSerie.Text;
                    txtNumero.EditValue = lst_Numeracion[0].Numero.ToString();
                    NumeroCaracter = lst_Numeracion[0].NumeroCaracter;
                    IdNumeracionDocumento = lst_Numeracion[0].IdNumeracionDocumento;
                }
                else
                {
                    txtSerie.Text = "";
                    txtNumero.EditValue = 0;
                    NumeroCaracter = 0;
                    IdNumeracionDocumento = 0;
                }
            }
        }

        private void cboSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtNumero.Select();
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores)
                {
                    BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentasSunat, 0), "CodTipoDocumento", "IdTipoDocumento", false);
                    LimpiarCargaCorrelativo();
                    //cboDocumento.EditValue = 0;
                    cboDocumento.EditValue = Parametros.intTipoDocNotaCredito;
                    //BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo), "Serie", "Serie", true);
                    BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboDocumento.EditValue), true, Parametros.intPeriodo), "Serie", "IdNumeracionDocumento", true);
                }
                else
                {
                    BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentasRER, 0), "CodTipoDocumento", "IdTipoDocumento", false);
                    LimpiarCargaCorrelativo();
                    //cboDocumento.EditValue = 0;
                    cboDocumento.EditValue = Parametros.intTipoDocNotaCredito;
                    BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Parametros.intTiendaId, Convert.ToInt32(cboDocumento.EditValue), true, Parametros.intPeriodo), "Serie", "IdNumeracionDocumento", true);
                    //BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo), "Serie", "Serie", true);
                }
            }
        }

        private void btnEditNumeracionDocumento_Click(object sender, EventArgs e)
        {
            if (cboSerie.Text == "")
            {
                LimpiarCargaCorrelativo();
            }

            if (IdNumeracionDocumento > 0)
            {
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
                {
                    XtraMessageBox.Show("No se puede alterar la numeración de un Ticket de Venta.\nConsulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                {
                    XtraMessageBox.Show("No se puede alterar la numeración de un comprobante electrónico.\nConsulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NumeracionDocumentoBE objNumeracionDocumento = new NumeracionDocumentoBE();
                objNumeracionDocumento.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objNumeracionDocumento.IdTienda = Parametros.intTiendaId;
                objNumeracionDocumento.IdNumeracionDocumento = IdNumeracionDocumento;
                objNumeracionDocumento.Periodo = Parametros.intPeriodo;
                objNumeracionDocumento.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                objNumeracionDocumento.Serie = cboSerie.Text;
                objNumeracionDocumento.Numero = Convert.ToInt32(txtNumero.Text);
                objNumeracionDocumento.NumeroCaracter = NumeroCaracter;
                objNumeracionDocumento.FlagFacturacion = true;
                objNumeracionDocumento.FlagEstado = true;

                frmManNumeracionDocumentoEdit objManNumeracionDocumentoEdit = new frmManNumeracionDocumentoEdit();
                objManNumeracionDocumentoEdit.pOperacion = frmManNumeracionDocumentoEdit.Operacion.ConsultarEditar;
                objManNumeracionDocumentoEdit.IdNumeracionDocumento = objNumeracionDocumento.IdNumeracionDocumento;
                objManNumeracionDocumentoEdit.pNumeracionDocumentoBE = objNumeracionDocumento;
                objManNumeracionDocumentoEdit.cboEmpresa.Enabled = false;
                objManNumeracionDocumentoEdit.cboDocumento.Enabled = false;

                objManNumeracionDocumentoEdit.StartPosition = FormStartPosition.CenterParent;
                objManNumeracionDocumentoEdit.ShowDialog();

                if (objManNumeracionDocumentoEdit.DialogResult == DialogResult.OK)
                {
                    txtNumero.EditValue = objManNumeracionDocumentoEdit.intNumero;
                }

                //frmManNumeracionDocumentoEdit frm = new frmManNumeracionDocumentoEdit();
                //frm.pOperacion = frmManNumeracionDocumentoEdit.Operacion.Modificar;
                //frm.pNumeracionDocumentoBE.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                ////frm.pNumeracionDocumentoBE.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                //frm.pNumeracionDocumentoBE.Periodo = PeriodoNumeracion;
                //frm.pNumeracionDocumentoBE.Serie = Convert.ToInt32(cboSerie.Text);
                //frm.pNumeracionDocumentoBE.Numero = Convert.ToInt32(txtNumero.Text);
                //frm.ShowDialog();
            }


        }

        private void editartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                movDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdDocumentoVenta = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("IdDocumentoVenta"));
                movDetalle.IdDocumentoVentaDetalle = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvDocumentoDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvDocumentoDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvDocumentoDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("Cantidad"));
                //movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvDocumentoDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvDocumentoDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvDocumentoDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvDocumentoDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvDocumentoDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.IdKardex = Convert.ToInt32(gvDocumentoDetalle.GetFocusedRowCellValue("IdKardex"));
                movDetalle.PorcentajeDescuentoInicial = Convert.ToDecimal(gvDocumentoDetalle.GetFocusedRowCellValue("PorcentajeDescuentoInicial"));
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDocumentoDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvDocumentoDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                        //gvDocumentoDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioUnitario);//movDetalle.oBE.PrecioVenta);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "IdKardex", movDetalle.oBE.IdKardex);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "Stock", 0);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "PrecioUnitarioInicial", 0);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        gvDocumentoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDocumentoDetalle.UpdateCurrentRow();

                        //bNuevo = movDetalle.bNuevo;

                        CalculaTotales();

                    }
                }
            }
        }

        private void txtNumeroReferencia_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    #region "Traslados"
                    if (Convert.ToInt32(cboDocumentoReferencia.EditValue) == Parametros.intTipoDocFacturaVentaTraslado || Convert.ToInt32(cboDocumentoReferencia.EditValue) == Parametros.intTipoDocFacturaVentaTraslado)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                            IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                            IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);

                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                            if (objE_Pedido != null)
                            {
                                txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                            }
                            else
                            {
                                txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                            }
                            txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                            cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                            cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                            IdCliente = objE_DocumentoVenta.IdCliente;
                            IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                            IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                            txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                            if (IdTipoCliente == Parametros.intTipClienteFinal)
                                txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                            else
                                txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                            txtDireccion.Text = objE_DocumentoVenta.Direccion;
                            cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                            txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                            txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                            txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                            txtTotal.EditValue = objE_DocumentoVenta.Total;
                            txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;


                            SeteaDocumentoDetalle();

                            //Traemos la información del detalle de la devolución
                            List<DocumentoVentaDetalleBE> lstTmpCambioDetalle = null;
                            lstTmpCambioDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(objE_DocumentoVenta.IdDocumentoVenta);

                            int Item = 1;
                            decTotalVentaDolares = 0;
                            foreach (DocumentoVentaDetalleBE item in lstTmpCambioDetalle)
                            {
                                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                                objE_DocumentoDetalle.Item = Item;
                                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                objE_DocumentoDetalle.Descuento = 0;
                                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                                objE_DocumentoDetalle.IdKardex = 0;
                                objE_DocumentoDetalle.FlagMuestra = false;
                                objE_DocumentoDetalle.FlagRegalo = false;
                                objE_DocumentoDetalle.Stock = 0;
                                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                                decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                                Item = Item + 1;
                            }

                            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                            gcDocumentoDetalle.DataSource = bsListado;
                            gcDocumentoDetalle.RefreshDataSource();

                            bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios; //ECM4
                            CalculaTotales();

                            mnuContextual.Enabled = true;
                            nuevoToolStripMenuItem.Enabled = false;
                            editartoolStripMenuItem.Enabled = false;
                            eliminarToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " \n no existe, Verifique el Número de Comprobante.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion

                    #region "Nota de Credito"
                    else if(Convert.ToInt32(cboDocumentoReferencia.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        //Traemos la información del Pedido
                        CambioBE objE_Cambio = null;
                        objE_Cambio = new CambioBL().SeleccionaTipoDocumentoNCE(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                        if (objE_Cambio != null)
                        {
                            IdCambio = objE_Cambio.IdCambio;
                            NumeroDevolucion = objE_Cambio.Numero;
                            CodigoNC = objE_Cambio.CodigoNC;

                            if (objE_Cambio.FlagRecibido)    //Change Recibido
                            {
                                DocumentoVentaBE objE_DocumentoVenta = null;
                                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                                if (objE_DocumentoVenta != null)
                                {
                                    cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                                    IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                                    IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);

                                    PedidoBE objE_Pedido = null;
                                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                                    if (objE_Pedido != null)
                                    {
                                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                    }
                                    else
                                    {
                                        txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                                    }

                                    txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                                    cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                                    cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                                    IdCliente = objE_DocumentoVenta.IdCliente;
                                    IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                                    IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                                    txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                                    txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                                    else
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                                    txtDireccion.Text = objE_DocumentoVenta.Direccion;
                                    cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                                    txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                                    txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                                    txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                                    txtTotal.EditValue = objE_DocumentoVenta.Total;
                                    txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;


                                    SeteaDocumentoDetalle();

                                    //Traemos la información del detalle de la devolución
                                    //List<CambioDetalleBE> lstTmpCambioDetalle = null;
                                    //lstTmpCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objE_Cambio.IdCambio);
                                    List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                                    lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(Convert.ToInt32(objE_Cambio.IdDocumentoVentaNcv));

                                    int Item = 1;
                                    decTotalVentaDolares = 0;
                                    foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
                                    {
                                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                                        objE_DocumentoDetalle.Item = Item;
                                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                        objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_DocumentoDetalle.Descuento = 0;
                                        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                                        objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                                        objE_DocumentoDetalle.IdKardex = 0;
                                        objE_DocumentoDetalle.FlagMuestra = false;
                                        objE_DocumentoDetalle.FlagRegalo = false;
                                        objE_DocumentoDetalle.Stock = 0;
                                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                        mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                                        decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                                    }

                                    bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                                    gcDocumentoDetalle.DataSource = bsListado;
                                    gcDocumentoDetalle.RefreshDataSource();

                                    bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios; //ECM4
                                    CalculaTotales();

                                    mnuContextual.Enabled = true;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " \n no se encuentra en condición RECIBIDO, por lo tanto No podrá generar una nota de crédito, Consulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " no está autorizado ó ya fue recibida\nConsulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    #endregion

                    #region "Facturación Normal"
                    else
                    {
                        //Traemos la información del Pedido
                        CambioBE objE_Cambio = null;
                        objE_Cambio = new CambioBL().SeleccionaTipoDocumento(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                        if (objE_Cambio != null)
                        {
                            IdCambio = objE_Cambio.IdCambio;
                            NumeroDevolucion = objE_Cambio.Numero;
                            CodigoNC = objE_Cambio.CodigoNC;
                            if (objE_Cambio.FlagRecibido)//Change Recibido
                            {
                                DocumentoVentaBE objE_DocumentoVenta = null;
                                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                                if (objE_DocumentoVenta != null)
                                {
                                    cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                                    IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                                    IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                                    //if(txtSerieReferencia.Text.Trim().Length==4)
                                    //{
                                    //    //cboDocumento.EditValue == Parametros.intTipoDocNotaCreditoElectronica;
                                    //    //if (objE_DocumentoVenta.Serie.Substring(0, 1) == "")
                                    //    //{

                                    //    //}
                                    //}

                                    PedidoBE objE_Pedido = null;
                                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                                    if (objE_Pedido != null)
                                    {
                                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                    }
                                    else
                                    {
                                        txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                                    }

                                    txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                                    cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                                    cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                                    IdCliente = objE_DocumentoVenta.IdCliente;
                                    IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                                    IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                                    txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                                    txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                                    else
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                                    txtDireccion.Text = objE_DocumentoVenta.Direccion;
                                    cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                                    txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                                    txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                                    txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                                    txtTotal.EditValue = objE_DocumentoVenta.Total;
                                    txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;


                                    SeteaDocumentoDetalle();

                                    //Traemos la información del detalle de la devolución
                                    List<CambioDetalleBE> lstTmpCambioDetalle = null;
                                    lstTmpCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objE_Cambio.IdCambio);

                                    int Item = 1;
                                    decTotalVentaDolares = 0;
                                    foreach (CambioDetalleBE item in lstTmpCambioDetalle)
                                    {
                                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                                        objE_DocumentoDetalle.Item = Item;
                                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                        objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_DocumentoDetalle.Descuento = 0;
                                        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                                        objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                                        objE_DocumentoDetalle.IdKardex = 0;
                                        objE_DocumentoDetalle.FlagMuestra = false;
                                        objE_DocumentoDetalle.FlagRegalo = false;
                                        objE_DocumentoDetalle.Stock = 0;
                                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                        mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                                        decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                                    }

                                    bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                                    gcDocumentoDetalle.DataSource = bsListado;
                                    gcDocumentoDetalle.RefreshDataSource();

                                    bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios; //ECM4
                                    CalculaTotales();

                                    mnuContextual.Enabled = false;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " \n no se encuentra en condición RECIBIDO, por lo tanto No podrá generar una nota de crédito, Consulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " no está autorizado ó ya fue recibida\nConsulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCambiarTC_Click(object sender, EventArgs e)
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ygomez" || frmAutoriza.Usuario == "mmurrugarra")
                {
                    txtTipoCambio.ReadOnly = false;
                    txtTipoCambio.Properties.DisplayFormat.FormatString = "n3";
                    txtTipoCambio.Properties.Mask.EditMask = "n3";
                    txtTipoCambio.Select();
                    txtTipoCambio.SelectAll();
                }
                else
                {
                    XtraMessageBox.Show("Ud. no tiene permisos para realizar esta operación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }




        }

        #endregion

        #region "Metodos"

        private void SeteaDocumentoDetalle()
        {
            mListaDocumentoVentaDetalleOrigen.Clear();
            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();
        }

        private void InsertarDocumentoVenta()
        {
            if (!ValidarIngreso())
            {
                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                objDocumentoVenta.IdTienda = IdTienda;//Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                objDocumentoVenta.NumeroPedido = txtNumeroPedido.Text;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;
                objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo);
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    Serie = mListaNumero[0].Serie;
                }

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                objDocumentoVenta.DescCliente = txtDescCliente.Text;
                objDocumentoVenta.Direccion = txtDireccion.Text;
                objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objDocumentoVenta.TipoCambioPedido = TipoCambioPedido;
                objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objDocumentoVenta.DescFormaPago = cboFormaPago.Text;
                objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                objDocumentoVenta.FlagCumpleanios = bFlagCumpleanios; //    ECM2    2022_07_20
                objDocumentoVenta.TotalDscCumpleanios = Convert.ToDecimal(txtDsctoCumple.EditValue); //    ECM2    2022_07_20
                //objDocumentoVenta.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                objDocumentoVenta.PorcentajeDescuento = Math.Round(Convert.ToDecimal(txtDescuento.EditValue), 2);//ADD 2011
                objDocumentoVenta.Descuentos = Convert.ToDecimal(txtTotalDescuento.EditValue);
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
                objDocumentoVenta.Observacion = "DOC. GENERADO  POR FACTURACIÓN | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR FACTURACIÓN";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.CodigoNC = Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaDebitoElectronica ? Convert.ToString(cboTipoNotaDebito.EditValue): CodigoNC;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.IdCambio = IdCambio;
                objDocumentoVenta.NumeroDevolucion = NumeroDevolucion;
                objDocumentoVenta.TotalVentaDolares = decTotalVentaDolares;///ECM2
                objDocumentoVenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                objDocumentoVenta.IdUsuario = Parametros.intUsuarioId;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objDocumentoVenta.IdAlmacen = Parametros.intAlmCentralUcayali;
                objDocumentoVenta.Icbper = Convert.ToDecimal(txtICBPER.EditValue);

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
                    objE_DocumentoVentaDetalle.IdPromocion2 = item.IdPromocion2;
                    objE_DocumentoVentaDetalle.DescPromocion = item.DescPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                if (pOperacion == Operacion.Nuevo)
                {

                    IdDocumentoVenta = objBL_DocumentoVenta.Inserta_EC(objDocumentoVenta, lstDocumentoVentaDetalle, IdEstadoCuenta2, Convert.ToDecimal(txtTipoCambio.EditValue), Convert.ToInt32(cboMoneda.EditValue));///ECM2

                    #region "Envío e Impresión de Comprobante electrónico"
                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineBoletaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(objDocumentoVenta.IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }

                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineFacturaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarVentaIntegrens(objDocumentoVenta.IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }

                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        #region "Grabar"
                        if (Parametros.bOnlineFacturaElectronica)
                        {
                            string MensajeService = FacturaE.GrabarNotaCreditoIntegrens(objDocumentoVenta.IdEmpresa, IdDocumentoVenta);
                            if (MensajeService.ToUpper() != "OK")
                                XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                        #region "Impresión"
                        ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                        //ImpresionTicketElectronico("C");
                        #endregion
                    }


                    #endregion

                }
                else
                {
                    objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);
                }
            }
        }

        private void InsertarDocumentoVentaVarios(int items)
        {
            if (!ValidarIngreso())
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
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();
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
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                        objE_DocumentoVentaDetalle.IdEmpresa = mListaDocumentoVentaDetalleOrigen[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        //objE_DocumentoVentaDetalle.Item = mListaDocumentoVentaDetalleOrigen[row].Item;
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
                        objE_DocumentoVentaDetalle.IdPromocion2 = mListaDocumentoVentaDetalleOrigen[row].IdPromocion2;
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
                    decimal deTotalBruto = 0;
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

                    //Descuentos Adicionales por Cabecera
                    if (Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    {
                        deTotalBruto = deTotal;
                        deTotal = Math.Round(deTotal * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100), 2);
                        deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                        deImpuesto = deTotal - deSubTotal;
                    }



                    //Generamos el documento cabecera.

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = IdTienda;//Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                    objDocumentoVenta.NumeroPedido = txtNumeroPedido.Text;
                    objDocumentoVenta.Periodo = Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo);
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                        Serie = mListaNumero[0].Serie;
                    }

                    objDocumentoVenta.Serie = Serie;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.TipoCambioPedido = TipoCambioPedido;
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.DescFormaPago = cboFormaPago.Text;
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = intTotalCantidad;
                    objDocumentoVenta.SubTotal = deSubTotal;
                    //objDocumentoVenta.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objDocumentoVenta.PorcentajeDescuento = Math.Round(Convert.ToDecimal(txtDescuento.EditValue), 2);//ADD 2011
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = deImpuesto;
                    objDocumentoVenta.Total = deTotal;
                    objDocumentoVenta.TotalBruto = deTotalBruto; //add 01/09
                    objDocumentoVenta.Observacion = "DOC. GENERADO  POR FACTURACIÓN | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR FACTURACIÓN";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.CodigoNC = CodigoNC;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.IdCambio = IdCambio;
                    objDocumentoVenta.NumeroDevolucion = NumeroDevolucion;
                    objDocumentoVenta.TotalVentaDolares = decTotalVentaDolares;
                    objDocumentoVenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objDocumentoVenta.IdAlmacen = Parametros.intAlmCentralUcayali;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_DocumentoVenta.Inserta(objDocumentoVenta, lstDocumentoVentaDetalle);
                    }
                    else
                    {
                        objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);
                    }
                }
            }
        }

        private void InsertarEstadoCuenta()
        {
            if (!ValidarIngreso())
            {
                IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                ObtenerCorrelativoCredito();

                //Estado de Cuenta
                EstadoCuentaBE objE_EstadoCuenta = null;
                SeparacionBE objE_Separacion = null;

                if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                {
                    if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan)
                    {
                        //Datos del estado de cuenta
                        objE_EstadoCuenta = new EstadoCuentaBE();

                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                        objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                        objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                        objE_EstadoCuenta.IdCliente = IdCliente;
                        objE_EstadoCuenta.NumeroDocumento = NumeroCredito;//txtNumero.Text;
                        objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_EstadoCuenta.FechaDeposito = null;
                        objE_EstadoCuenta.Concepto = cboFormaPago.Text + " N° " + txtNumeroPedido.Text;
                        objE_EstadoCuenta.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                        //objE_EstadoCuenta.Importe = if(IdMonedaPedido==Parametros.intSoles)
                        //decTotalPedido; 
                        objE_EstadoCuenta.Importe = Convert.ToInt32(cboMoneda.EditValue) == 5? Math.Round(Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue), 2)   : Convert.ToDecimal(txtTotal.EditValue);  
                        objE_EstadoCuenta.ImporteAnt = Convert.ToInt32(cboMoneda.EditValue) == 5 ? Math.Round(Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue), 2) : Convert.ToDecimal(txtTotal.EditValue);
                        objE_EstadoCuenta.TipoMovimiento = "C";
                        objE_EstadoCuenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                        objE_EstadoCuenta.IdDocumentoVenta = (int?)null;
                        objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
                        objE_EstadoCuenta.IdPedido = IdPedido;
                        objE_EstadoCuenta.FlagEstado = true;
                        objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                        objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    }
                }

                if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)
                {
                    if (IdFormaPago == Parametros.intSeparacion || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan)
                    {
                        //Datos de la separación
                        objE_Separacion = new SeparacionBE();

                        objE_Separacion.IdSeparacion = 0;
                        objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                        objE_Separacion.Periodo = Parametros.intPeriodo;
                        objE_Separacion.IdCliente = IdCliente;
                        objE_Separacion.NumeroDocumento = NumeroCredito;
                        objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Separacion.FechaPago = null;
                        objE_Separacion.Concepto = cboFormaPago.Text + " N° " + txtNumeroPedido.Text;
                        objE_Separacion.FechaVencimiento = Convert.ToDateTime(deFechaVencimiento.DateTime.ToShortDateString());
                        objE_Separacion.Importe = decTotalPedido;
                        objE_Separacion.ImporteAnt = decTotalPedido;
                        objE_Separacion.TipoMovimiento = "C";
                        objE_Separacion.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                        objE_Separacion.IdDocumentoVenta = (int?)null;
                        objE_Separacion.IdPedido = IdPedido;
                        objE_Separacion.IdUsuario = Parametros.intUsuarioId;
                        objE_Separacion.FlagEstado = true;
                        objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                        objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    }
                }

                if (pOperacion == Operacion.Nuevo)
                {

                    DocumentoVentaBL objBL_DocumentoVentaEstado = new DocumentoVentaBL();
                    if (objE_EstadoCuenta != null)
                    {
                        List<EstadoCuentaBE> lstEstadoCuenta = new List<EstadoCuentaBE>();
                        lstEstadoCuenta = new EstadoCuentaBL().ListaPedido(Parametros.intEmpresaId, IdPedido, "C");  //Cargo

                        if (lstEstadoCuenta.Count > 0)
                        {
                            XtraMessageBox.Show("Ya existe un registro N°: " + lstEstadoCuenta[0].NumeroDocumento + " en Estado de Cuenta en Dolares(US$) \n US$ " + lstEstadoCuenta[0].Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            IdEstadoCuenta2 = objBL_DocumentoVentaEstado.InsertaCredito2(objE_EstadoCuenta, objE_Separacion);
                            XtraMessageBox.Show("Se registró Crédito N°: " + NumeroCredito + " en Estado de Cuenta en Dolares(US$) \n US$ " + objE_EstadoCuenta.Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (objE_Separacion != null)
                    {
                        List<SeparacionBE> lstSeparacion = new List<SeparacionBE>();
                        lstSeparacion = new SeparacionBL().ListaPedido(Parametros.intEmpresaId, IdPedido, "C");
                        if (lstSeparacion.Count > 0)
                        {
                            XtraMessageBox.Show("Ya existe un registro N°: " + lstSeparacion[0].NumeroDocumento + " en Estado de Cuenta en Soles(S/) \n S/ " + lstSeparacion[0].Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            IdEstadoCuenta2 = objBL_DocumentoVentaEstado.InsertaCredito2(objE_EstadoCuenta, objE_Separacion);
                            XtraMessageBox.Show("Se registró Crédito N°: " + NumeroCredito + " en Estado de Cuenta en Soles(S/) \n S/" + decTotalPedido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }

            }
        }

        private void CalcularValoresGrilla(int IdMoneda)
        {
            try
            {
                if (gvDocumentoDetalle.RowCount > 0)
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
                            decimal decPrecioVenta2 = 0;

                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                            {
                                decValorVenta = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"]).ToString()) * decimal.Parse(txtTipoCambio.Text), 2);
                                decPrecioVenta = Math.Round(decValorVenta / decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()), 2);


                                decPrecioUnitario = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(txtTipoCambio.Text), 4);
                                decPrecioUnitario = (decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString()) * decPrecioUnitario) / 100;
                                decPrecioUnitario = Math.Round((decPrecioUnitario + decPrecioVenta), 2);

                                //decPrecioUnitario = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(txtTipoCambio.Text), 2);
                                //decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                ////decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                //decPrecioVenta2 = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"]).ToString()), 2);
                                //decPrecioVenta = Math.Round(decPrecioVenta2 * decimal.Parse(txtTipoCambio.Text), 4);

                                ////decPrecioVenta = Math.Round(decPrecioUnitario - Math.Round((decPrecioUnitario * (decPorcentajeDescuento / 100)), 4), 2);
                                //decValorVenta = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta, 2);
                            }
                            else
                            {
                                decValorVenta = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"]).ToString()) * decimal.Parse(txtTipoCambio.Text), 2);
                                decPrecioVenta = Math.Round(decValorVenta / decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()), 2);

                                decPrecioUnitario = Math.Round(decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(txtTipoCambio.Text), 4);
                                decPrecioUnitario = (decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString()) * decPrecioUnitario) / 100;
                                decPrecioUnitario = Math.Round((decPrecioUnitario + decPrecioVenta), 2);
                            }

                            //if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                            //{
                            //    //decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                            //    decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(txtTipoCambio.Text);
                            //    decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                            //    //decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                            //    //decPrecioVenta = Math.Round(decPrecioUnitario - (decPrecioUnitario * (decPorcentajeDescuento / 100)), 2);
                            //    decPrecioVenta = Math.Round(decPrecioUnitario - Math.Round((decPrecioUnitario * (decPorcentajeDescuento / 100)), 4), 2);
                            //    decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            //}
                            //else
                            //{
                            //    decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
                            //    decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                            //    decPrecioVenta = Math.Round(decPrecioUnitario, 2) * ((100 - decPorcentajeDescuento) / 100);
                            //    decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            //}

                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"], decValorVenta);
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
                                //  decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(txtTipoCambio.Text);
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = Math.Round(decPrecioUnitario, 2) * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = Math.Round(decPrecioUnitario, 2) * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);

                            }
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"], decValorVenta);
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

        private void ImpresionDirecta()
        {
            try
            {
                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                {
                    dirFacturacion = Parametros.strDireccionUcayali2;
                }
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
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
                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores)
                {
                    dirFacturacion = Parametros.strDireccionCoronaImportadores;
                }

                #region "CONTINUO"

                #region "Boleta Continua Panorama"
                //if (TipoDoc == "BOV")
                if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores))
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

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
                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                }
                #endregion

                #region "Factura Continua Panorama"
                else
                    //if (TipoDoc == "FAV")
                    if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores))
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptFacturaPanorama objReporteGuia = new rptFacturaPanorama();
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
                #endregion

                #region "Factura Continua Corona"
                else
                        if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores))
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptFacturaCorona objReporteGuia = new rptFacturaCorona();
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
                #endregion

                #region "Guia Remision"
                else
                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocGuiaRemision)
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();
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
                #endregion

                #region "Nota Credito"


                #region "Nota Credito Panorama"
                else
                                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoPanoramaDesglosable objReporteNotaCredito = new rptNotaCreditoPanoramaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Corona"
                else
                                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores))//Corona
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoCoronaDesglosable objReporteNotaCredito = new rptNotaCreditoCoronaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Amalia"
                else
                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intHuamanBramonTeodoraAmalia))//amalia
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoAmaliaDesglosable objReporteNotaCredito = new rptNotaCreditoAmaliaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Eleazar"
                else
                                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaTarrilloEleazar))//Eleazar
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoEleazarDesglosable objReporteNotaCredito = new rptNotaCreditoEleazarDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Olga"
                else
                                                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaCalderonOlgaLidia))//Olga
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoOlgaDesglosable objReporteNotaCredito = new rptNotaCreditoOlgaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion


                //else
                //    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                //    {
                //        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                //        lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoReferencia);

                //        rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
                //        objReporteNotaCredito.SetDataSource(lstReporte);

                //        bool found = false;
                //        PrinterSettings prtSetting = new PrinterSettings();
                //        foreach (string prtName in PrinterSettings.InstalledPrinters)
                //        {
                //            string printer = "";
                //            if (prtName.StartsWith("\\\\"))
                //            {
                //                printer = prtName.Substring(3);
                //                printer = printer.Substring(printer.IndexOf("\\") + 1);
                //            }
                //            else
                //                printer = prtName;

                //            if (printer.ToUpper().StartsWith("(F)"))
                //            {
                //                found = true;
                //                PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                //                prtSetting.PrinterName = prtName;
                //                objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                //                int rawKind = -1;
                //                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                //                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                //                {
                //                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                //                    {
                //                        rawKind = prtSetting.PaperSizes[i].RawKind;
                //                        objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                //                        break;
                //                    }
                //                }
                //                if (rawKind == -1)
                //                {
                //                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                }
                //                break;
                //            }
                //        }

                //        if (!found)
                //        {
                //            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

                //        }
                //        objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                //    }
                #endregion

                #endregion


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImpresionDirectaDesglosable()
        {
            try
            {
                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                {
                    dirFacturacion = Parametros.strDireccionUcayali2;
                }
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
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
                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores)
                {
                    dirFacturacion = Parametros.strDireccionCoronaImportadores;
                }


                #region "DESGLOSABLE"

                #region "Boleta Panorama desglosable"
                if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores))//Boleta Panorama desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

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
                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                }
                #endregion

                #region "Boleta Corona desglosable"
                else
                    if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores))//Boleta Corona desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptBoletaCoronaDesglosable objReporteGuia = new rptBoletaCoronaDesglosable();
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
                #endregion

                #region "Boleta Eleazar desglosable"
                else
                        if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaTarrilloEleazar))//Boleta Eleazar desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptBoletaEleazarDesglosable objReporteGuia = new rptBoletaEleazarDesglosable();
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
                #endregion

                #region "Boleta Amalia desglosable"
                else
                            if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intHuamanBramonTeodoraAmalia))//Boleta Amalia desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptBoletaAmaliaDesglosable objReporteGuia = new rptBoletaAmaliaDesglosable();
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
                #endregion

                #region "Boleta Olga desglosable"
                else
                                if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaCalderonOlgaLidia))//Boleta Olga desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptBoletaOlgaDesglosable objReporteGuia = new rptBoletaOlgaDesglosable();
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
                #endregion

                #region "Boleta Decoratex desglosable"
                else
                                    if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intDecoratex))//Boleta Decoratex desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptBoletaDecoratexDesglosable objReporteGuia = new rptBoletaDecoratexDesglosable();
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
                #endregion

                #region "Factura Panorama Desglosable"
                else
                                    if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores))//Factura Panorama Desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptFacturaPanoramaDesglosable objReporteGuia = new rptFacturaPanoramaDesglosable();
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
                #endregion

                #region "Factura Eleazar Desglosable"
                else
                                        if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaTarrilloEleazar))//Factura Eleazar Desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptFacturaEleazarDesglosable objReporteGuia = new rptFacturaEleazarDesglosable();
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
                #endregion

                #region "Factura Amalia Desglosable"
                else
                                            if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaTarrilloEleazar))//Factura Amalia Desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);


                    rptFacturaAmaliaDesglosable objReporteGuia = new rptFacturaAmaliaDesglosable();
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
                #endregion

                #region "Factura Olga Desglosable"
                else
                                                if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaCalderonOlgaLidia))//Factura Olga Desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptFacturaOlgaDesglosable objReporteGuia = new rptFacturaOlgaDesglosable();
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
                #endregion

                #region "Factura Decoractex Desglosable"
                else
                                                    if ((Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intDecoratex))//Factura Eleazar Desglosable
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptFacturaDecoratexDesglosable objReporteGuia = new rptFacturaDecoratexDesglosable();
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
                #endregion

                #region "Guia Remision"
                else
                                                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocGuiaRemision)
                {
                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, IdPedido);

                    rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();
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
                #endregion

                #region "Nota Credito"

                #region "Nota Credito Panorama"
                else
                                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoPanoramaDesglosable objReporteNotaCredito = new rptNotaCreditoPanoramaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Corona"
                else
                                                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores))//Corona
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoCoronaDesglosable objReporteNotaCredito = new rptNotaCreditoCoronaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Amalia"
                else
                                                                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intHuamanBramonTeodoraAmalia))//amalia
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoAmaliaDesglosable objReporteNotaCredito = new rptNotaCreditoAmaliaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Eleazar"
                else
                                                                    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaTarrilloEleazar))//Eleazar
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoEleazarDesglosable objReporteNotaCredito = new rptNotaCreditoEleazarDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Olga"
                else
                                                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intTapiaCalderonOlgaLidia))//Olga
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoOlgaDesglosable objReporteNotaCredito = new rptNotaCreditoOlgaDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                #region "Nota Credito Decoratex"
                else
                                                                            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito && (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intDecoratex))//Decoratex
                {
                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoVenta);

                    rptNotaCreditoDecoratexDesglosable objReporteNotaCredito = new rptNotaCreditoDecoratexDesglosable();
                    objReporteNotaCredito.SetDataSource(lstReporte);

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
                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
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
                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                }

                #endregion

                //else
                //    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                //    {
                //        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                //        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(IdDocumentoReferencia));

                //        rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
                //        objReporteNotaCredito.SetDataSource(lstReporte);

                //        bool found = false;
                //        PrinterSettings prtSetting = new PrinterSettings();
                //        foreach (string prtName in PrinterSettings.InstalledPrinters)
                //        {
                //            string printer = "";
                //            if (prtName.StartsWith("\\\\"))
                //            {
                //                printer = prtName.Substring(3);
                //                printer = printer.Substring(printer.IndexOf("\\") + 1);
                //            }
                //            else
                //                printer = prtName;

                //            if (printer.ToUpper().StartsWith("(F)"))
                //            {
                //                found = true;
                //                PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
                //                prtSetting.PrinterName = prtName;
                //                objReporteNotaCredito.PrintOptions.PrinterName = prtName;

                //                int rawKind = -1;
                //                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
                //                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                //                {
                //                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                //                    {
                //                        rawKind = prtSetting.PaperSizes[i].RawKind;
                //                        objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                //                        break;
                //                    }
                //                }
                //                if (rawKind == -1)
                //                {
                //                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                }
                //                break;
                //            }
                //        }

                //        if (!found)
                //        {
                //            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

                //        }
                //        objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                //    }

                #endregion

                #endregion


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculaTotales()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;
                decimal deTotal22 = 0;
                decimal detotalDsctoCumple = 0; // ECM3
                int intTotalCantidad = 0;
                decimal deICBPER = 0;
                decimal deICBPERTotal = 0;
                decimal deICBPER_Afecto_Igv = 0;
                decimal deICBPER_Afecto_Igv2 = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        if (item.IdProducto == 83617 || item.IdProducto == 83618)
                        {
                            deICBPER_Afecto_Igv2 = 0;
                            if (Convert.ToInt32(cboMoneda.EditValue) == 5)
                            {
                                deICBPER_Afecto_Igv = deICBPER_Afecto_Igv + (item.ValorVenta - (item.Cantidad * new decimal(0.50)));                    ///(item.Cantidad * new decimal(0.10));
                                deICBPER_Afecto_Igv2 = deICBPER_Afecto_Igv2 + (item.ValorVenta - (item.Cantidad * new decimal(0.50)));
                                deICBPER = deICBPER + (item.ValorVenta - deICBPER_Afecto_Igv2);
                                deICBPERTotal = deICBPERTotal + item.ValorVenta;
                            }
                            else if (Convert.ToInt32(cboMoneda.EditValue) == 6)
                            {
                                deICBPER_Afecto_Igv = deICBPER_Afecto_Igv + Math.Round((Math.Round(item.ValorVenta * Convert.ToDecimal(txtTipoCambio.EditValue), 2) - (item.Cantidad * new decimal(0.50))) / Convert.ToDecimal(txtTipoCambio.EditValue), 2);                    ///(item.Cantidad * new decimal(0.10));
                                deICBPER_Afecto_Igv2 = deICBPER_Afecto_Igv2 + Math.Round(((item.ValorVenta * Convert.ToDecimal(txtTipoCambio.EditValue)) - (item.Cantidad * new decimal(0.50))) / Convert.ToDecimal(txtTipoCambio.EditValue), 2);
                                deICBPER = deICBPER + (item.ValorVenta - deICBPER_Afecto_Igv2);
                                deICBPERTotal = deICBPERTotal + item.ValorVenta;
                            }
                            //deICBPER = deICBPER + (item.ValorVenta - (item.Cantidad * new decimal(0.10)));
                            //deICBPERTotal = deICBPERTotal + item.ValorVenta;
                        }
                        else
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        //ECM3
                        if (bFlagCumpleanios)
                        {
                            //if (IdContratoFabricacion == 0)// No cuenta con fabricacion
                            //{
                            detotalDsctoCumple = new PedidoBL().lgDescuentoPorCumpleanios(detotalDsctoCumple, item.IdMarca, item.PorcentajeDescuento, item.ValorVenta);
                            //}
                        }
                    }

                    //ECM3
                    if (bFlagCumpleanios)
                    {
                        txtTotalSinDscCumple.EditValue = deTotal;

                        deTotal = Math.Round(deTotal - detotalDsctoCumple, 2);
                        txtDsctoCumple.EditValue = deTotal;
                    }
                    deTotal = Math.Round(deTotal, 2);
                    deSubTotal = Math.Round((deTotal + (deICBPER_Afecto_Igv)) / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    deImpuesto = Math.Round((deTotal + (deICBPERTotal - deICBPER)) - deSubTotal, 2);
                    // deSubTotal = Math.Round((deTotal + (deICBPERTotal - deICBPER)) / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    // deImpuesto = Math.Round(deTotal + ((deICBPERTotal - deICBPER)) - deSubTotal, 2);
                    txtTotal.EditValue = deTotal + deICBPERTotal;
                    txtSubTotal.EditValue = deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;
                    txtTotalCantidad.EditValue = intTotalCantidad;
                    txtICBPER.EditValue = deICBPER;
                    txtDsctoCumple.EditValue = detotalDsctoCumple;

                    ///////

                    if (Convert.ToDecimal(txtDescuento.EditValue) > 0 || Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    {
                        deTotal22 = deTotal;
                        txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                        deTotal = deTotal * ((100 - Math.Round((Convert.ToDecimal(txtTotalDescuento.EditValue) * 100) / Convert.ToDecimal(txtTotalBruto.EditValue), 15)) / 100);


                        txtDescuento.EditValue = Math.Round((Convert.ToDecimal(txtTotalDescuento.EditValue) * 100) / Convert.ToDecimal(txtTotalBruto.EditValue), 15);

                        txtTotal.Text = Math.Round(deTotal, 2).ToString();
                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        txtSubTotal.EditValue = deSubTotal;
                        deImpuesto = deTotal - deSubTotal;
                        txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    }

                    #region 'COMENTADO'
                    //if (bFlagCumpleanios)
                    //{
                    //    decimal dDsctoCumple =Convert.ToDecimal( txtDsctoCumple.EditValue);
                    //    decimal dTotalSinDscCumple = Convert.ToDecimal(txtTotalSinDscCumple.EditValue);
                    //    txtTotal.EditValue = Math.Round(dTotalSinDscCumple - dDsctoCumple, 2);
                    //}
                    //if (Convert.ToDecimal(txtDescuento.EditValue) > 0 || Convert.ToDecimal(txtMP.EditValue) > 0)
                    //{
                    //    deTotal2 = deTotal;
                    //    txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                    //    deTotal = deTotal * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);

                    //    txtDescuento.EditValue = Math.Round((Convert.ToDecimal(txtDescuento.EditValue) * 100) / (Convert.ToDecimal(deTotal22)), 15);

                    //    txtTotalDscto2x1.EditValue = txtMP.EditValue;
                    //    txtTotal.Text = Math.Round(deTotal, 2).ToString();
                    //    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    //    txtSubTotal.EditValue = deSubTotal;
                    //    deImpuesto = deTotal - deSubTotal;
                    //    txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    //}



                    //if (Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    //{
                    //    txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                    //    deTotal = deTotal * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                    //    txtTotal.EditValue = Math.Round(deTotal, 2);
                    //    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()),2);
                    //    txtSubTotal.EditValue = deSubTotal;
                    //    deImpuesto = deTotal - deSubTotal;
                    //    txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    //}
                    #endregion
                }
                else
                {
                    txtTotalCantidad.EditValue = 0;
                    txtSubTotal.EditValue = 0;
                    txtImpuesto.EditValue = 0;
                    txtTotal.EditValue = 0;
                    txtTotalDescuento.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculaTotalesPromo()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;
                int intTotalCantidad = 0;

                if (mListaDocumentoVentaDetalleOrigenPromo.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaDetalleOrigenPromo)
                    {
                        intTotalCantidad = intTotalCantidad + item.Cantidad;
                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                    }

                    deTotal = Math.Round(deTotal, 2);
                    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                    txtTotal.EditValue = deTotal;
                    txtSubTotal.EditValue = deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;
                    txtTotalCantidad.EditValue = intTotalCantidad;

                    //if (Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    //{
                    //    txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                    //    deTotal = deTotal * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                    //    txtTotal.EditValue = Math.Round(deTotal, 2);
                    //    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()),2);
                    //    txtSubTotal.EditValue = deSubTotal;
                    //    deImpuesto = deTotal - deSubTotal;
                    //    txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    //}
                }
                else
                {
                    txtTotalCantidad.EditValue = 0;
                    txtSubTotal.EditValue = 0;
                    txtImpuesto.EditValue = 0;
                    txtTotal.EditValue = 0;
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

             if(Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaDebitoElectronica && Convert.ToInt32(cboTipoNotaDebito.EditValue)==0)
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de la nota de debito.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de documento.\n";
                flag = true;
            }

            if (cboSerie.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la serie del documento.\n";
                flag = true;
            }

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Verificar el número de documento.\n";
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

            if (mListaDocumentoVentaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- No se puede generar la venta, mientras no haya productos.\n";
                flag = true;
            }

            int TipoDoc = Convert.ToInt32(cboDocumento.EditValue);
            if (TipoDoc == Parametros.intTipoDocBoletaElectronica || TipoDoc == Parametros.intTipoDocFacturaElectronica || TipoDoc == Parametros.intTipoDocNotaCreditoElectronica)
            {
                deFecha.EditValue = Parametros.dtFechaHoraServidor;
                deFecha.Properties.ReadOnly = true;
                if (Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()) || Convert.ToDateTime(deFecha.DateTime.ToShortDateString()) > Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    strMensaje = strMensaje + "- No se puede generar un comprobante electrónico con fecha diferente a la actual.\n";
                    flag = true;
                }
            }

            //VALIDAR CLIENTE ACTIVO
            #region "Consulta RUC Data Local"
            int TipoDocFact = Convert.ToInt32(cboDocumento.EditValue);
            if (TipoDocFact == Parametros.intTipoDocBoletaElectronica)
            {
                if (txtNumeroDocumento.Text.Trim().Length == 11)
                {
                    XtraMessageBox.Show("No se puede emitir una boleta con RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = true;
                }
            }

            if (TipoDocFact == Parametros.intTipoDocFacturaVenta || TipoDocFact == Parametros.intTipoDocTicketFactura || TipoDocFact == Parametros.intTipoDocFacturaElectronica || TipoDocFact == Parametros.intTipoDocBoletaElectronica)
            {
                //if (txtNumeroDocumento.Text.Trim().Length == 11)
                //{
                //    ClienteBE objE_Cliente = null;
                //    objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                //    if (objE_Cliente != null)
                //    {
                //        txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + objE_Cliente.NomDpto + " - " + objE_Cliente.NomProv + " - " + objE_Cliente.NomDist;
                //        txtDescCliente.Text = objE_Cliente.DescCliente;
                //        if (objE_Cliente.DescCategoria != "ACTIVO")//Estado contribuyente
                //        {
                //            strMensaje = strMensaje + "- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCategoria + ".\n";
                //            flag = true;
                //        }

                //        if (objE_Cliente.DescCondicion != "HABIDO")//Condicion Domicilio
                //        {
                //            strMensaje = strMensaje + "- El RUC seleccionado se encuentra en condición de " + objE_Cliente.DescCondicion + ".\n";
                //            flag = true;
                //        }
                //    }
                //    else
                //    {
                //        strMensaje = strMensaje + "- El RUC no existe en la base de datos. Por favor consultar con Sistemas.\n";
                //        flag = true;
                //    }
                //}
            }

            #endregion

            //VALIDAR DNI = SEGUN RENIEC

            //Mayor a 700
            int TipoDocFac = 0;
            TipoDocFac = Convert.ToInt32(cboDocumento.EditValue);
            if (TipoDocFac == Parametros.intTipoDocBoletaVenta || TipoDocFac == Parametros.intTipoDocFacturaVenta || TipoDocFac == Parametros.intTipoDocTicketBoleta || TipoDocFac == Parametros.intTipoDocTicketFactura || TipoDocFac == Parametros.intTipoDocBoletaElectronica || TipoDocFac == Parametros.intTipoDocFacturaElectronica)
            {
                if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles && Convert.ToDecimal(txtTotal.EditValue) >= 700 || IdCliente == Parametros.intIdClienteGeneral && Convert.ToInt32(cboMoneda.EditValue) == Parametros.intDolares && Convert.ToDecimal(txtTotal.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue) >= 700)
                {
                    strMensaje = strMensaje + "- No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/700\nConsulte con su Administrador.\n";
                    flag = true;
                }
                if (IdDocumentoReferencia > 0)
                {
                    //strMensaje = strMensaje + "- No se puede generar una venta a partir de una nota de crédito.\n";
                    //flag = true;
                }

                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().SeleccionaSituacion(IdPedido);
                if (objE_Pedido.IdSituacion == Parametros.intFacturado || objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                {
                    strMensaje = strMensaje + "- No se puede Factura el Pedido ya está cancelado.\n";
                    flag = true;
                }
            }

            //Validar Número
            if (TipoDocFac == Parametros.intTipoDocTicketBoleta || TipoDocFac == Parametros.intTipoDocTicketFactura || TipoDocFac == Parametros.intTipoDocBoletaElectronica || TipoDocFac == Parametros.intTipoDocFacturaElectronica || TipoDocFac == Parametros.intTipoDocNotaCreditoElectronica)
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                }

                DocumentoVentaBE ojbE_DocumentoV = null;
                ojbE_DocumentoV = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), cboSerie.Text, Numero);
                if (ojbE_DocumentoV != null)
                {
                    strMensaje = strMensaje + "- El número de documento ya existe.\n";
                    flag = true;
                }
            }

            ////Validar notacredito
            //int TipoDoc2 = Convert.ToInt32(cboDocumento.EditValue);
            //if (TipoDoc2 == Parametros.intTipoDocBoletaElectronica || TipoDoc2 == Parametros.intTipoDocFacturaElectronica)
            //    IdDocumentoReferencia = 0;

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaDocumentoVentaDetalle()
        {
            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);

            foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
            {
                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                objE_DocumentoDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                objE_DocumentoDetalle.Item = item.Item;
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
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
                objE_DocumentoDetalle.FlagRegalo = item.FlagRegalo;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;

                objE_DocumentoDetalle.IdMarca = item.IdMarca; // <-- 130323

                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();
        }

        private bool ValidarTopeEmpresaRus()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            decimal Total = Convert.ToDecimal(txtTotal.Text); // decimal.Parse(gvPedido.GetFocusedRowCellValue("Total").ToString());

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

                    TotalVenta = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVenta = Total;
                    //TotalVenta = 0;
                }


                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS || objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRER)
                    {
                        if (TotalVenta > Tope)
                        {
                            XtraMessageBox.Show("El importe de venta sobrepasa el tope mensual, por favor verifique. \nConsultar al área de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                            //return;
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

        private void ObtenerCorrelativoCredito()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocFacturaCredito, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }

                NumeroCredito = "CR" + sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltroMenuContextual()
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "cvega" || Parametros.strUsuarioLogin == "oguevara")
            {
                editartoolStripMenuItem.Visible = true;
            }
            else
            {
                editartoolStripMenuItem.Visible = false;
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
                    decTotalPedido = Math.Round(((Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(Parametros.dmlTCMayorista)) / Convert.ToDecimal(Parametros.dblIGV)) * (Parametros.dmlClubDesign / 100), 2);

                    //Datos del estado de cuenta
                    objE_EstadoCuenta = new EstadoCuentaBE();

                    objE_EstadoCuenta.IdEstadoCuenta = 0;
                    objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
                    objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
                    objE_EstadoCuenta.IdCliente = IdAsesorExterno;
                    objE_EstadoCuenta.NumeroDocumento = "COMCD";
                    objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_EstadoCuenta.FechaDeposito = null;
                    objE_EstadoCuenta.Concepto = "COMISION " + Parametros.dmlClubDesign + "% CLUB DESIGN - PEDIDO N° " + txtNumeroPedido.Text;
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
                    decTotalPedido = Math.Round(((Convert.ToDecimal(txtTotal.EditValue)) / Convert.ToDecimal(Parametros.dblIGV)) * (Parametros.dmlClubDesign / 100), 2);

                    //Datos del estado de cuenta
                    objE_Separacion = new SeparacionBE();

                    objE_Separacion.IdSeparacion = 0;
                    objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
                    objE_Separacion.Periodo = Parametros.intPeriodo;
                    objE_Separacion.IdCliente = IdAsesorExterno;
                    objE_Separacion.NumeroDocumento = "COMCD";
                    objE_Separacion.FechaSeparacion = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Separacion.FechaPago = null;
                    objE_Separacion.Concepto = "COMISION " + Parametros.dmlClubDesign + "% CLUB DESIGN - PEDIDO N° " + txtNumeroPedido.Text;
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
                        lstEstadoCuenta = new EstadoCuentaBL().ListaPedido(Parametros.intEmpresaId, IdPedido, "A");
                        if (lstEstadoCuenta.Count > 0)
                        {
                            XtraMessageBox.Show("Ya existe un registro N°: " + lstEstadoCuenta[0].NumeroDocumento + " en Estado de Cuenta Dolares(US$) \n US$ " + lstEstadoCuenta[0].Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            objBL_DocumentoVentaEstado.InsertaCredito(objE_EstadoCuenta, objE_Separacion);
                            XtraMessageBox.Show("Se registró Abono Club Desgin en Estado de Cuenta Dolares(US$) \n US$ " + decTotalPedido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            XtraMessageBox.Show("Se registró Abono Club Desgin en Estado de Cuenta Soles(S/) \n S/ " + decTotalPedido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            #region "Imprime Recibo"
                            //TalonBE objTalon = null;
                            //objTalon = new TalonBL().SeleccionaCajaDocumento(Convert.ToInt32(cboEmpresa.EditValue) , Parametros.intTiendaId, Parametros.intCajaId, Convert.ToInt32(cboDocumento.EditValue));


                            //CreaTicket ticket = new CreaTicket();

                            //#region "Busca Impresora"
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

                            //    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                            //    {
                            //        found = true;
                            //        ticket.impresora = @printer;
                            //    }
                            //}

                            //if (!found)
                            //{
                            //    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                            //}
                            //#endregion

                            //ticket.TextoCentro(objTalon.NombreComercial);
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            //ticket.TextoCentro(objTalon.DireccionFiscal);
                            ////if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            //ticket.TextoCentro(Parametros.strEmpresaRuc);
                            //ticket.TextoIzquierda("");
                            //ticket.TextoIzquierda("TIENDA: " + objTalon.DescTienda);
                            //ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
                            //ticket.TextoIzquierda("COD. ASESOR CLUB DESIGN: " + IdAsesorExterno);
                            ////ticket.LineasGuion();
                            ////ticket.LineasTotales();

                            ////ticket.AgregaTotales("Total BONO S/ ", Convert.ToDouble(decTotalPedido)); // imprime linea con total
                            ////ticket.TextoIzquierda("");
                            ////ticket.TextoIzquierda("Ven:" + DescVendedor);
                            //ticket.TextoIzquierda("Ped:" + Convert.ToInt32(txtNumeroPedido.EditValue));
                            //ticket.TextoCentro("");
                            //ticket.TextoCentro("ENTREGAR ESTE VOUCHER AL DISEÑADOR");
                            //ticket.TextoCentro("GRACIAS POR LA ASESORIA");
                            ////ticket.TextoCentro("GRACIAS POR SU COMPRA");
                            //ticket.TextoCentro(objTalon.PaginaWeb);

                            ////ticket.TextoCentro("=========================================");
                            ////ticket.TextoCentro("¡FELICIDADES!");
                            ////ticket.TextoCentro("Ganaste 5% dscto.");
                            ////ticket.TextoCentro("ENTREGAR ESTE VOUCHER AL DISEÑADOR");
                            ////ticket.TextoCentro("PARA SU SEGUIMIENTO DE PEDIDO");
                            ////ticket.TextoCentro("valido del 14 al 28 de Octubre del 2016");
                            ////ticket.TextoCentro("Dscto no acumulable con otras promociones");
                            ////ticket.TextoCentro("=========================================");
                            //ticket.CortaTicket();

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
                //objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);

                if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ImpresionTicketElectronico("G");
                    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                }
            }
            //MessageBox.Show(WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N"));
            //txtObservacion.Text = dsCabecera.GetXml();

        }

        private void GrabarNotaCreditoIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            mDocumentoVentaE = objE_DocumentoVenta;

            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

            #region "Datatable"
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
            #endregion

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
            dr["codmot"] = "07";//MOTIVO DE DEVOLUCION --AGREGAR MAS
            dr["tidomd"] = objE_DocumentoVenta.IdConTipoComprobantePagoRef;
            dr["nudomd"] = objE_DocumentoVenta.SerieReferencia + "-" + objE_DocumentoVenta.NumeroReferencia;
            dr["fedomd"] = objE_DocumentoVenta.FechaReferencia;
            dr["tidove"] = "1";//Dni Vendedor - Ver caso Carnet de Extranjería
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
            dr["estreg"] = "CO";//??? a Dacta
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
                dr2["codafe"] = "10"; //Tipo de Afectación del IGV -(Gravado - Operación Onerosa)
                dr2["monisc"] = "0.00000";
                dr2["tipisc"] = "0";
                dr2["prelis"] = item.PrecioVenta;//"22687.69000";
                dr2["valref"] = "0.00000"; //Sólo si es gratuito
                dr2["totuni"] = item.PrecioUnitario * item.Cantidad;// "19226.86000";
                dr2["montot"] = item.ValorVenta; //"22687.69000";
                dr2["monper"] = "0.00000"; //Monto de Percepción
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
            dr3["nudoem"] = Parametros.strEmpresaRuc;//"20330676826";EL ANTICIPO ????
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
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                //objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);

                if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ImpresionTicketElectronico("G");
                    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                }
            }
        }

        private void LimpiarCargaCorrelativo()
        {
            cboSerie.EditValue = 0;
            txtSerie.Text = "";
            txtNumero.EditValue = 0;
            NumeroCaracter = 0;
            IdNumeracionDocumento = 0;
        }

        private void CalculaTotalPromocion2x1()
        {
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;
            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;

            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo2x1 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo2x1_Impar = new List<CDocumentoVentaDetalle>();

            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo3x2 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_PedidoDetalleSinPromo = new List<CDocumentoVentaDetalle>();

            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo3x1 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo4x1 = new List<CDocumentoVentaDetalle>();

            //Cargar Lista 
            #region "Cargar Lista 3x2"
            List<CDocumentoVentaDetalle> mListaPedidoDetallePromo3x2 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> mListaPedidoDetallePromo3x1 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> mListaPedidoDetallePromo4x1 = new List<CDocumentoVentaDetalle>();


            int Itemk = 1;
            foreach (var item in mListaDocumentoVentaDetalleOrigen)
            {
                if (item.DescPromocion == "3x2")
                {
                    for (int j = 1; j <= item.Cantidad; j++)
                    {
                        CDocumentoVentaDetalle ObjE_Detalle = new CDocumentoVentaDetalle();
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
                        ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = item.FlagMuestra;
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
                        CDocumentoVentaDetalle ObjE_Detalle = new CDocumentoVentaDetalle();
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
                        ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = item.FlagMuestra;
                        lst_PedidoDetallePromo3x1.Add(ObjE_Detalle);

                        if (Itemk == 3) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
                    }
                }
                if (item.DescPromocion == "4x1")
                {
                    for (int j = 1; j <= item.Cantidad; j++)
                    {
                        CDocumentoVentaDetalle ObjE_Detalle = new CDocumentoVentaDetalle();
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
                        ObjE_Detalle.IdAlmacen = item.IdAlmacen;
                        ObjE_Detalle.FlagMuestra = item.FlagMuestra;
                        lst_PedidoDetallePromo4x1.Add(ObjE_Detalle);

                        if (Itemk == 4) Itemk = 1;
                        else
                            Itemk = Itemk + 1;
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
                            CDocumentoVentaDetalle objE_DocumentoDetalle2 = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle2.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle2.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle2.IdDocumentoVentaDetalle = 0;
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

                #region"3x1"
                else if (item.DescPromocion == "4x1")
                {
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


                #region"3x2 antes"
                //else if (item.DescPromocion == "3x2")
                //{
                //    for (int i = 1; i <= item.Cantidad; i++)
                //    {
                //        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                //        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                //        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                //        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                //        objE_DocumentoDetalle.Item = nItem;
                //        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                //        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                //        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                //        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                //        objE_DocumentoDetalle.Cantidad = 1;
                //        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                //        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                //        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                //        objE_DocumentoDetalle.Descuento = item.Descuento;
                //        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                //        objE_DocumentoDetalle.ValorVenta = item.PrecioVenta;
                //        objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                //        objE_DocumentoDetalle.IdKardex = item.IdKardex;
                //        objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                //        objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                //        objE_DocumentoDetalle.FlagMuestra = false;
                //        objE_DocumentoDetalle.FlagRegalo = false;
                //        objE_DocumentoDetalle.Stock = 0;
                //        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                //        if (nItem % 3 == 0)
                //        {
                //            objE_DocumentoDetalle.PorcentajeDescuento = 0;
                //            objE_DocumentoDetalle.Descuento = 0;
                //            objE_DocumentoDetalle.PrecioVenta = 0;
                //            objE_DocumentoDetalle.ValorVenta = 0;
                //            objE_DocumentoDetalle.CodAfeIGV = "21";
                //        }
                //        lst_PedidoDetallePromo3x2.Add(objE_DocumentoDetalle);


                //        nItem = nItem + 1;
                //    }
                //}
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
                    //mListaDocumentoVentaDetalleOrigenPromo.Add(objE_DocumentoDetalle);
                    lst_PedidoDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            //Agregar Descuentos
            #region "Agregar descuentos"

            int Registro = 1;
            int TotalRegistro = lst_PedidoDetallePromo2x1_Impar.Count;//  mListaDocumentoVentaDetalleOrigen.Count;
            decimal Valor1 = 0;
            decimal Valor2 = 0;
            decimal Mayor = 0;
            decimal Descuento = 0;
            foreach (var item in lst_PedidoDetallePromo2x1_Impar)//mListaDocumentoVentaDetalleOrigen)
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

            mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
            nItem = 1;

            #region "Agregar 2x1 Par"
            //Agregar Promociones a la lista
            foreach (CDocumentoVentaDetalle item in lst_PedidoDetallePromo2x1)
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
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 2x1 Impar"
            foreach (CDocumentoVentaDetalle item in lst_PedidoDetallePromo2x1_Impar)
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
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x2"
            foreach (CDocumentoVentaDetalle item in mListaPedidoDetallePromo3x2)
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
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 3x1"
            foreach (CDocumentoVentaDetalle item in mListaPedidoDetallePromo3x1)
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
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            #region "Agregar 4x1"
            foreach (CDocumentoVentaDetalle item in mListaPedidoDetallePromo4x1)
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
                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.Descuento = item.Descuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
                objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
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
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                nItem = nItem + 1;
            }
            #endregion

            //Agrupar códigos 
            #region "Agrupar Códigos por Promoción"
            //int TotalRegistroPromo = mListaDocumentoVentaDetalleOrigen.Count;

            //foreach (var item in mListaDocumentoVentaDetalleOrigen)
            //{
            //    if(item.DescPromocion == "3x2")
            //    {

            //    }
            //    if (item.DescPromocion == "3x1")
            //    {

            //    }
            //    if (item.DescPromocion == "4x1")
            //    {

            //    }

            //    CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
            //    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
            //    objE_DocumentoDetalle.IdDocumentoVenta = 0;
            //    objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
            //    objE_DocumentoDetalle.Item = nItem;// item.Item;
            //    objE_DocumentoDetalle.IdProducto = item.IdProducto;
            //    objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
            //    objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
            //    objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
            //    objE_DocumentoDetalle.Cantidad = item.Cantidad;
            //    objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
            //    objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
            //    objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
            //    objE_DocumentoDetalle.Descuento = item.Descuento;
            //    objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
            //    objE_DocumentoDetalle.ValorVenta = item.ValorVenta == 0 ? item.Cantidad * item.PrecioUnitario : item.ValorVenta;
            //    objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
            //    objE_DocumentoDetalle.IdKardex = item.IdKardex;
            //    objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
            //    objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
            //    objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;//false
            //    objE_DocumentoDetalle.FlagRegalo = false;
            //    objE_DocumentoDetalle.Stock = 0;
            //    objE_DocumentoDetalle.TipoOper = item.TipoOper;
            //    mListaDocumentoVentaDetalleOrigenTemp.Add(objE_DocumentoDetalle);
            //    nItem = nItem + 1;
            //}
            #endregion

            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();

            CalculaTotales();
            //CalculaTotalesPromo();

            #endregion

        }

        private void CalculaTotalPromocion2x1_unouno()
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
                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
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
                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
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
                if (Registro % 2 != 0)
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
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }
            #endregion


            //bsListado.DataSource = mListaDocumentoVentaDetalleOrigenPromo;
            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();

            CalculaTotales();
            //CalculaTotalesPromo();

            #endregion

        }

        private void CalculaTotalPromocion2x1_PorTransGratuita()
        {
            Decimal TotalPrecio2x1 = 0;
            Decimal Total2x1SinPromo = 0;
            Decimal TotalPrecio3x2Dscto = 0;
            Decimal Total3x2SinPromo = 0;
            Decimal TotalPrecio6x3 = 0;
            Decimal Total6x3SinPromo = 0;
            Decimal TotalSinPromocion = 0;

            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo3x2 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_PedidoDetalleSinPromo = new List<CDocumentoVentaDetalle>();

            #region "Demo"
            int nItem = 1;
            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                #region"3x2"
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
                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
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
                        if (nItem % 2 == 0)
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
                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
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
                    //mListaDocumentoVentaDetalleOrigenPromo.Add(objE_DocumentoDetalle);
                    lst_PedidoDetalleSinPromo.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }
                #endregion
            }

            mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();

            //Agregar Promociones a la lista
            foreach (CDocumentoVentaDetalle item in lst_PedidoDetallePromo3x2)
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
                objE_DocumentoDetalle.FlagMuestra = false;
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }
            //Agregar Sin Promoción 
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
                objE_DocumentoDetalle.FlagMuestra = false;
                objE_DocumentoDetalle.FlagRegalo = false;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            //bsListado.DataSource = mListaDocumentoVentaDetalleOrigenPromo;
            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();

            CalculaTotales();
            //CalculaTotalesPromo();

            #endregion





            //txtTotal2x1.EditValue = TotalPrecio2x1 + Total3x2SinPromo + TotalPrecio6x3; //TotalPrecio3x2
            //txtTotalDscto2x1.EditValue = (Total2x1SinPromo - TotalPrecio2x1) + TotalPrecio3x2Dscto + (Total6x3SinPromo - TotalPrecio6x3);// versión 2.0


            //////Calcular el Total General con Descuento
            //Decimal deTotal = 0;
            //Decimal deSubTotal = 0;
            //deTotal = TotalSinPromocion + TotalPrecio2x1 + (Total3x2SinPromo - TotalPrecio3x2Dscto) + TotalPrecio6x3;
            //deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

            //txtTotal.EditValue = Math.Round(deTotal, 2);
            //txtSubTotal.EditValue = deSubTotal;
            //txtImpuesto.EditValue = Math.Round((deTotal - deSubTotal), 2);
            //txtTotalBruto.EditValue = Math.Round((TotalSinPromocion + Total2x1SinPromo + Total3x2SinPromo + Total6x3SinPromo), 2);
            //txtTotalCantidad.EditValue = intTotalCantidad;
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

            foreach (CDocumentoVentaDetalle item in mListaDocumentoVentaDetalleOrigen)
            {
                Cantidad = item.Cantidad;
                PrecioUnitario = item.PrecioUnitario;
                PrecioVenta = item.PrecioVenta;//add 121115

                if (item.DescPromocion == "2x1")
                {
                    if (Cantidad % 2 == 0)
                    {
                        TotalPrecio2x1 += ((Cantidad / 2) * PrecioUnitario);  //Math Round
                    }
                    else
                    {
                        if (Cantidad > 2)
                        {
                            TotalPrecio2x1 += (((Cantidad - 1) / 2) * PrecioUnitario);  //Math Round   
                        }
                    }
                    Total2x1SinPromo += (Cantidad * PrecioUnitario);
                }
                else if (item.DescPromocion == "3x2")
                {
                    Total3x2SinPromo = Total3x2SinPromo + (Cantidad * PrecioUnitario);
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
                            TotalPrecio6x3 += (((Cantidad - 1) / 2) * PrecioUnitario);  //Math Round   
                        }
                    }

                    Total6x3SinPromo += (Cantidad * PrecioUnitario);
                }
                else //Producto sin Promoción
                {
                    TotalSinPromocion += item.ValorVenta;
                }

                intTotalCantidad = intTotalCantidad + item.Cantidad;

                PosicionX = PosicionX + 1;
            }

            List<PedidoDetalleBE> lst_PedidoDetallePromo = new List<PedidoDetalleBE>();
            //List<PedidoDetalleBE> lst_PedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
            List<CDocumentoVentaDetalle> lst_PedidoDetallePromo3x2 = new List<CDocumentoVentaDetalle>();
            List<CDocumentoVentaDetalle> lst_PedidoDetalleSinPromo = new List<CDocumentoVentaDetalle>();

            List<PedidoDetalleBE> lst_PedidoDetallePromo6x3 = new List<PedidoDetalleBE>();
            Decimal PrecioUnitarioPromo = 0;
            Decimal PrecioVentaPromo = 0;
            String PromocionCadena = "";
            int CantidadImpar = 0;
            int PosicionY = 0;
            for (int i = 0; i < gvDocumentoDetalle.RowCount; i++)
            {
                PromocionCadena = Convert.ToString(gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["DescPromocion"])));

                CantidadImpar = Convert.ToInt32(gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["Cantidad"])));
                PrecioUnitarioPromo = Convert.ToDecimal(gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["PrecioUnitario"])));
                PrecioVentaPromo = Convert.ToDecimal(gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["PrecioVenta"])));//add 121115

                int Item = Convert.ToInt32(gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["Item"])));
                int IdProducto = Convert.ToInt32(gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["IdProducto"])));
                string CodigoProveedor = gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["CodigoProveedor"])).ToString();
                string NombreProducto = gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["NombreProducto"])).ToString();
                //int? IdPromocion =  gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["IdPromocion"]));
                string DescPromocion = gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["DescPromocion"])).ToString();
                string Abreviatura = gvDocumentoDetalle.GetRowCellValue(i, (gvDocumentoDetalle.Columns["Abreviatura"])).ToString();

                //CDocumentoVentaDetalle objE_DocumentoVentaDet = (CDocumentoVentaDetalle)gvDocumentoDetalle.GetRow(i);

                if (PromocionCadena == "2x1")
                {
                    if (CantidadImpar % 2 != 0)
                    {
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
                        CDocumentoVentaDetalle ObjE_Detalle = new CDocumentoVentaDetalle();

                        ObjE_Detalle.Item = Item;
                        ObjE_Detalle.IdProducto = IdProducto;
                        ObjE_Detalle.CodigoProveedor = CodigoProveedor;
                        ObjE_Detalle.NombreProducto = NombreProducto;
                        ObjE_Detalle.Cantidad = 1;
                        ObjE_Detalle.Abreviatura = Abreviatura;
                        ObjE_Detalle.PrecioUnitario = PrecioUnitarioPromo;//PrecioUnitarioPromo;
                        ObjE_Detalle.PrecioVenta = PrecioVentaPromo;
                        ObjE_Detalle.ValorVenta = PrecioVentaPromo;
                        ObjE_Detalle.DescPromocion = DescPromocion;
                        lst_PedidoDetallePromo3x2.Add(ObjE_Detalle);

                        //lst_PedidoDetallePromo.Cantidad = 1; //add 1311
                        //objE_DocumentoVentaDet.PrecioUnitario = PrecioUnitarioPromo;
                        //objE_DocumentoVentaDet.PrecioVenta = PrecioVentaPromo;
                        //lst_PedidoDetallePromo3x2.Add(objE_DocumentoVentaDet);
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

                //int nItem = 1;
                foreach (var item in lst_PedidoDetallePromo3x2)
                {
                    #region "Agregar Promociones"

                    //CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    //objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    //objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    //objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                    //objE_DocumentoDetalle.Item = nItem;
                    //objE_DocumentoDetalle.IdProducto = item.IdProducto;
                    //objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                    //objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                    //objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                    //objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    //objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                    //objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                    //objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    //objE_DocumentoDetalle.Descuento = item.Descuento;
                    //objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                    //objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                    //objE_DocumentoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                    //objE_DocumentoDetalle.IdKardex = item.IdKardex;
                    //objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
                    //objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                    //objE_DocumentoDetalle.FlagMuestra = false;
                    //objE_DocumentoDetalle.FlagRegalo = false;
                    //objE_DocumentoDetalle.Stock = 0;
                    //objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    //if (nItem % 3 == 0)
                    //{
                    //    objE_DocumentoDetalle.PorcentajeDescuento = 0;
                    //    objE_DocumentoDetalle.Descuento = 0;
                    //    objE_DocumentoDetalle.PrecioVenta = 0;
                    //    objE_DocumentoDetalle.ValorVenta = 0;
                    //    objE_DocumentoDetalle.CodAfeIGV = "21";
                    //}
                    //mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                    //bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                    //gcDocumentoDetalle.DataSource = bsListado;
                    //gcDocumentoDetalle.RefreshDataSource();

                    //nItem = nItem + 1;
                    ////CalculaTotales();
                    #endregion
                }



                for (int i = 2; i < lst_PedidoDetallePromo3x2.Count; i = i + 3)
                {
                    //List<PedidoDetalleBE> lstF_PedidoDetallePromo3x2 = new List<PedidoDetalleBE>();
                    TotalPrecio3x2Dscto += lst_PedidoDetallePromo3x2[i].PrecioUnitario; //Precio Gratis -Descto

                    #region "Agregar Promociones"

                    int nItem = 1;
                    //foreach (PedidoDetalleBE item in lst_PedidoDetallePromo3x2)
                    //{
                    CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    objE_DocumentoDetalle.IdEmpresa = lst_PedidoDetallePromo3x2[i].IdEmpresa;
                    objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                    objE_DocumentoDetalle.Item = nItem;
                    objE_DocumentoDetalle.IdProducto = lst_PedidoDetallePromo3x2[i].IdProducto;
                    objE_DocumentoDetalle.CodigoProveedor = lst_PedidoDetallePromo3x2[i].CodigoProveedor;
                    objE_DocumentoDetalle.NombreProducto = lst_PedidoDetallePromo3x2[i].NombreProducto;
                    objE_DocumentoDetalle.Abreviatura = lst_PedidoDetallePromo3x2[i].Abreviatura;
                    objE_DocumentoDetalle.Cantidad = lst_PedidoDetallePromo3x2[i].Cantidad;
                    objE_DocumentoDetalle.CantidadAnt = lst_PedidoDetallePromo3x2[i].Cantidad;
                    objE_DocumentoDetalle.PrecioUnitario = lst_PedidoDetallePromo3x2[i].PrecioUnitario;
                    objE_DocumentoDetalle.PorcentajeDescuento = lst_PedidoDetallePromo3x2[i].PorcentajeDescuento;
                    objE_DocumentoDetalle.Descuento = lst_PedidoDetallePromo3x2[i].Descuento;
                    objE_DocumentoDetalle.PrecioVenta = lst_PedidoDetallePromo3x2[i].PrecioVenta;
                    objE_DocumentoDetalle.ValorVenta = lst_PedidoDetallePromo3x2[i].ValorVenta;
                    objE_DocumentoDetalle.CodAfeIGV = "21";
                    objE_DocumentoDetalle.IdKardex = lst_PedidoDetallePromo3x2[i].IdKardex;
                    objE_DocumentoDetalle.IdPromocion = lst_PedidoDetallePromo3x2[i].IdPromocion;
                    objE_DocumentoDetalle.DescPromocion = "Dscto"; //item.DescPromocion;
                    objE_DocumentoDetalle.FlagMuestra = false;
                    objE_DocumentoDetalle.FlagRegalo = false;
                    objE_DocumentoDetalle.Stock = 0;
                    objE_DocumentoDetalle.TipoOper = lst_PedidoDetallePromo3x2[i].TipoOper;
                    mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                    //nItem = nItem + 1;
                    //}

                    bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                    gcDocumentoDetalle.DataSource = bsListado;
                    gcDocumentoDetalle.RefreshDataSource();

                    //CalculaTotales();
                    #endregion
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




            //txtTotal2x1.EditValue = TotalPrecio2x1 + Total3x2SinPromo + TotalPrecio6x3; //TotalPrecio3x2
            //txtTotalDscto2x1.EditValue = (Total2x1SinPromo - TotalPrecio2x1) + TotalPrecio3x2Dscto + (Total6x3SinPromo - TotalPrecio6x3);// versión 2.0


            //////Calcular el Total General con Descuento
            //Decimal deTotal = 0;
            //Decimal deSubTotal = 0;
            //deTotal = TotalSinPromocion + TotalPrecio2x1 + (Total3x2SinPromo - TotalPrecio3x2Dscto) + TotalPrecio6x3;
            //deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);

            //txtTotal.EditValue = Math.Round(deTotal, 2);
            //txtSubTotal.EditValue = deSubTotal;
            //txtImpuesto.EditValue = Math.Round((deTotal - deSubTotal), 2);
            //txtTotalBruto.EditValue = Math.Round((TotalSinPromocion + Total2x1SinPromo + Total3x2SinPromo + Total6x3SinPromo), 2);
            //txtTotalCantidad.EditValue = intTotalCantidad;
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
            public Int32 CantidadAnt { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String CodAfeIGV { get; set; }
            public Int32 IdAlmacen { get; set; }
            public Int32? IdKardex { get; set; }
            public Int32? IdPromocion { get; set; }
            public Int32 IdPromocion2 { get; set; }
            public String DescPromocion { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Int32 TipoOper { get; set; }
            public Int32 IdMarca { get; set; }//ECM3
            public CDocumentoVentaDetalle()
            {

            }
        }

        private void Demo_Click(object sender, EventArgs e)
        {

            #region "Codigo QR"
            string ValorQR = "20330676826||100";

            Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(ValorQR, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(200, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(100, 100)));
            //lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
            //imagen.Save("imagen.png", ImageFormat.Png);
            #endregion


            Ticket ticket = new Ticket();

            ticket.AddHeaderLine("PANORAMA DISTRIBUIDORES");
            ticket.AddHeaderLine("JR. UCAYALI 425");
            ticket.AddHeaderLine("                     RUC: 20330676826");


            //ticket.AddSubHeaderLine(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            ticket.AddSubHeaderLine("TKE: B001-00001001  14/04/2013" + " " + DateTime.Now.ToShortTimeString());

            List<DocumentoVentaDetalleBE> lstListaDetalle = null;
            lstListaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(1093569);

            foreach (var item in lstListaDetalle)
            {
                ticket.AddItem(Convert.ToString(item.Cantidad), Convert.ToString(item.Abreviatura) + "  " + Convert.ToString(item.CodigoProveedor), Convert.ToString(Math.Round(item.PrecioVenta, 2)) + "  " + Convert.ToString(Math.Round(item.ValorVenta, 2)));
                ticket.AddItem("", item.NombreProducto, "");
            }


            ticket.AddTotal("                    SUBTOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal("84.75"), 2)));
            ticket.AddTotal("                    IGV", Convert.ToString(Math.Round(Convert.ToDecimal("15.25"), 2)));
            ticket.AddTotal("                    TOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal("100"), 2)));


            ticket.AddFooterLine("                  caja: " + Parametros.strUsuarioLogin);

            ticket.AddFooterLine("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
            ticket.AddFooterLine("             CAMBIOS NI DEVOLUCIONES");

            ticket.AddFooterLine("         GRACIAS POR SU COMPRA");
            ticket.AddFooterLine("    WWW.PANORAMADISTRIBUIDORES.COM");
            ticket.HeaderImage = imagen;

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

                if (printer.ToUpper().StartsWith("(K)"))
                {
                    found = true;
                    ticket.PrintTicket(@printer);
                }
            }




            ////GrabarVentaIntegrens(1051778);
            ////GrabarNotaCreditoIntegrens(1052789);

            //DocumentoVentaBE objE_DocumentoVenta = null;
            //objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(1068225);
            //mDocumentoVentaE = objE_DocumentoVenta;

            //ImpresionTicketElectronico("C");

            //GrabarNotaCreditoIntegrens(1069245);
            //ImpresionElectronicaLocal(1069245, "","TK");
        }

        private void ImpresionTicketFisico(String TipoDoc, Int32 TipoFormato)
        {
            try
            {
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


                    if (objTalon.FlagAbrirCajon == true) ticket.AbreCajon();  //abre el cajon
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
                        ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                        ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + (Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2)));
                        //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                        //ticket.AgregaTotales("Descuento", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    }
                    //ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(lstReporte[0].Total), 2)); // imprime linea con total
                    ticket.TextoExtremos("Total a Pagar", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                    ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("www.panoramadistribuidores.com");
                    ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                    if (lstReporte[0].IdPromocionProxima > 0)
                    {
                        ticket.CortaTicket();
                        ticket.TextoCentro("=========================================");
                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                        ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                        ticket.TextoCentro("=========================================");
                    }
                    ticket.CortaTicket();

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
                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    }
                    ticket.LineasTotales();
                    if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                    {
                        ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                        ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + (Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2)));
                        //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                        //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    }
                    ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                    ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                    //ticket.AgregaTotales("SubTotal", Math.Round(Convert.ToDouble(lstReporte[0].SubTotal), 2));
                    //ticket.AgregaTotales("IGV", Math.Round(Convert.ToDouble(lstReporte[0].Igv), 2));
                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].Total), 2));
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                    ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("TODO CAMBIO O DEVOLUCIÓN SE DEBE REALIZAR DENTRO DE LOS SIETE (7) DÍAS CALENDARIO CONTADOS A PARTIR DE LA FECHA EN QUE SE RECIBIÓ EL PRODUCTO");
                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("www.panoramadistribuidores.com");
                    ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                    if (lstReporte[0].IdPromocionProxima > 0)
                    {
                        ticket.CortaTicket();
                        ticket.TextoCentro("=========================================");
                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                        ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                        ticket.TextoCentro("=========================================");
                    }
                    ticket.CortaTicket();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImpresionTicketElectronico(string Formato)
        {
            //XML
            string sNombreArchivo = mDocumentoVentaE.Ruc + "_" + mDocumentoVentaE.IdConTipoComprobantePago + "_" + mDocumentoVentaE.Serie + "_" + mDocumentoVentaE.Numero;
            byte[] data = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "XML", "");
            File.WriteAllBytes(sNombreArchivo + ".xml", data);


            ////PDF
            byte[] datap = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "PDF", Formato);
            File.WriteAllBytes(sNombreArchivo + ".pdf", datap);


            ////ZIP
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

        private void ImpresionElectronicaLocal(int IdDocumentoVenta, int IdTipoDocumento, string Formato)
        {
            frmListaPrinters frmPrinter = new frmListaPrinters();
            if (frmPrinter.ShowDialog() == DialogResult.OK)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                #region "Codigo QR"
                int Regs = lstReporte.Count() - 1;
                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

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

                if (lstReporte.Count > 0)
                {
                    if (Formato == "TK")//Ticket
                    {
                        if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        {
                            XtraMessageBox.Show("El formato Ticket de NC no existe, por favor verificar.\nConsultar con el área de sistemas");
                        }
                        else
                        {
                            rptFacturaElectronicaPanoramaA4 objReporteGuia = new rptFacturaElectronicaPanoramaA4();
                            objReporteGuia.SetDataSource(lstReporte);
                            Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }

                    }
                    else //A4
                    {
                        if (lstReporte[0].IdEmpresa == 21)
                        {
                            if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                rptNotaCreditoElectronicaPanoramaA4_THL objReporteGuia = new rptNotaCreditoElectronicaPanoramaA4_THL();
                                objReporteGuia.SetDataSource(lstReporte);
                                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            }
                            else
                            {
                                rptFacturaElectronicaPanoramaA4_THL objReporteGuia = new rptFacturaElectronicaPanoramaA4_THL();
                                objReporteGuia.SetDataSource(lstReporte);
                                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            }
                        }
                        else
                        {
                            if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                rptNotaCreditoElectronicaPanoramaA4 objReporteGuia = new rptNotaCreditoElectronicaPanoramaA4();
                                objReporteGuia.SetDataSource(lstReporte);
                                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            }
                            else
                            {
                                rptFacturaElectronicaPanoramaA4 objReporteGuia = new rptFacturaElectronicaPanoramaA4();
                                objReporteGuia.SetDataSource(lstReporte);
                                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            }
                        }
                    }
                }
            }

        }

        private void gcDocumentoDetalle_PaintEx(object sender, DevExpress.XtraGrid.PaintExEventArgs e)
        {
            if (IdSituacion == Parametros.intDVAnulado)
            {
                Bitmap bmp = Properties.Resources.Anulado;
                bmp.MakeTransparent(Color.White);
                e.Cache.DrawImage(bmp, new Point(250, 60));
            }
        }

        private void txtNumeroPedido_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDscto_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gcDocumentoDetalle_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNumeroReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMotivoNC.Text = "";
                    #region "Traslados"
                    if (Convert.ToInt32(cboDocumentoReferencia.EditValue) == Parametros.intTipoDocFacturaVentaTraslado || Convert.ToInt32(cboDocumentoReferencia.EditValue) == Parametros.intTipoDocFacturaVentaTraslado)
                    {
                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                            IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                            IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);

                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                            if (objE_Pedido != null)
                            {
                                txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                            }
                            else
                            {
                                txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                            }
                            txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                            cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                            cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                            IdCliente = objE_DocumentoVenta.IdCliente;
                            IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                            IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                            txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                            if (IdTipoCliente == Parametros.intTipClienteFinal)
                                txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                            else
                                txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                            txtDireccion.Text = objE_DocumentoVenta.Direccion;
                            cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                            txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                            txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                            txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                            txtTotal.EditValue = objE_DocumentoVenta.Total;
                            txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;


                            SeteaDocumentoDetalle();

                            //Traemos la información del detalle de la devolución
                            List<DocumentoVentaDetalleBE> lstTmpCambioDetalle = null;
                            lstTmpCambioDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(objE_DocumentoVenta.IdDocumentoVenta);

                            int Item = 1;
                            decTotalVentaDolares = 0;
                            foreach (DocumentoVentaDetalleBE item in lstTmpCambioDetalle)
                            {
                                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                                objE_DocumentoDetalle.Item = Item;
                                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                objE_DocumentoDetalle.Descuento = 0;
                                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                                objE_DocumentoDetalle.IdKardex = 0;
                                objE_DocumentoDetalle.FlagMuestra = false;
                                objE_DocumentoDetalle.FlagRegalo = false;
                                objE_DocumentoDetalle.Stock = 0;
                                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                                decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                                Item = Item + 1;
                            }

                            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                            gcDocumentoDetalle.DataSource = bsListado;
                            gcDocumentoDetalle.RefreshDataSource();

                            bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios; //ECM4
                            CalculaTotales();

                            mnuContextual.Enabled = true;
                            nuevoToolStripMenuItem.Enabled = false;
                            editartoolStripMenuItem.Enabled = false;
                            eliminarToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " \n no existe, Verifique el Número de Comprobante.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion

                    #region "Nota de Credito"
                    else if (Convert.ToInt32(cboDocumentoReferencia.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        //Traemos la información del Pedido
                        CambioBE objE_Cambio = null;
                        objE_Cambio = new CambioBL().SeleccionaTipoDocumentoNCE(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                        if (objE_Cambio != null)
                        {
                            IdCambio = objE_Cambio.IdCambio;
                            NumeroDevolucion = objE_Cambio.Numero;
                            CodigoNC = objE_Cambio.CodigoNC;

                            if (objE_Cambio.FlagRecibido)    //Change Recibido
                            {
                                DocumentoVentaBE objE_DocumentoVenta = null;
                                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                                if (objE_DocumentoVenta != null)
                                {
                                    cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                                    IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                                    IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);

                                    PedidoBE objE_Pedido = null;
                                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                                    if (objE_Pedido != null)
                                    {
                                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                    }
                                    else
                                    {
                                        txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                                    }
                                    dtFechaRef.EditValue = objE_DocumentoVenta.Fecha;
                                    txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                                    cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                                    cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                                    IdCliente = objE_DocumentoVenta.IdCliente;
                                    IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                                    IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                                    txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                                    txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                                    else
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                                    txtDireccion.Text = objE_DocumentoVenta.Direccion;
                                    cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                                    txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                                    txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                                    txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                                    txtTotal.EditValue = objE_DocumentoVenta.Total;
                                    txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;


                                    SeteaDocumentoDetalle();

                                    //Traemos la información del detalle de la devolución
                                    //List<CambioDetalleBE> lstTmpCambioDetalle = null;
                                    //lstTmpCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objE_Cambio.IdCambio);
                                    List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                                    lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(Convert.ToInt32(objE_Cambio.IdDocumentoVentaNcv));

                                    int Item = 1;
                                    decTotalVentaDolares = 0;
                                    foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
                                    {
                                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                                        objE_DocumentoDetalle.Item = Item;
                                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                        objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_DocumentoDetalle.Descuento = 0;
                                        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                                        objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                                        objE_DocumentoDetalle.IdKardex = 0;
                                        objE_DocumentoDetalle.FlagMuestra = false;
                                        objE_DocumentoDetalle.FlagRegalo = false;
                                        objE_DocumentoDetalle.Stock = 0;
                                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                        mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                                        decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                                    }

                                    bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                                    gcDocumentoDetalle.DataSource = bsListado;
                                    gcDocumentoDetalle.RefreshDataSource();

                                    bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios; //ECM4
                                    CalculaTotales();

                                    mnuContextual.Enabled = true;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " \n no se encuentra en condición RECIBIDO, por lo tanto No podrá generar una nota de crédito, Consulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " no está autorizado ó ya fue recibida\nConsulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    #endregion

                    #region "Facturación Normal"
                    else
                    {
                        //Traemos la información del Pedido
                        CambioBE objE_Cambio = null;
                        objE_Cambio = new CambioBL().SeleccionaTipoDocumento(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                        if (objE_Cambio != null)
                        {
                            IdCambio = objE_Cambio.IdCambio;
                            NumeroDevolucion = objE_Cambio.Numero;
                            CodigoNC = objE_Cambio.CodigoNC;
                            if (objE_Cambio.FlagRecibido)//Change Recibido
                            {
                                DocumentoVentaBE objE_DocumentoVenta = null;
                                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                                if (objE_DocumentoVenta != null)
                                {
                                    cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                                    IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                                    IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                                    //if(txtSerieReferencia.Text.Trim().Length==4)
                                    //{
                                    //    //cboDocumento.EditValue == Parametros.intTipoDocNotaCreditoElectronica;
                                    //    //if (objE_DocumentoVenta.Serie.Substring(0, 1) == "")
                                    //    //{

                                    //    //}
                                    //}

                                    PedidoBE objE_Pedido = null;
                                    objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                                    if (objE_Pedido != null)
                                    {
                                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                                    }
                                    else
                                    {
                                        txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                                    }

                                    txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                                    cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                                    cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                                    IdCliente = objE_DocumentoVenta.IdCliente;
                                    IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                                    IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                                    txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                                    txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                                    else
                                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                                    txtDireccion.Text = objE_DocumentoVenta.Direccion;
                                    cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                                    txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                                    txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                                    txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                                    txtTotal.EditValue = objE_DocumentoVenta.Total;
                                    txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;
                                    txtMotivoNC.Text = objE_Cambio.Motivo;

                                    SeteaDocumentoDetalle();

                                    //Traemos la información del detalle de la devolución
                                    List<CambioDetalleBE> lstTmpCambioDetalle = null;
                                    lstTmpCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objE_Cambio.IdCambio);

                                    int Item = 1;
                                    decTotalVentaDolares = 0;
                                    foreach (CambioDetalleBE item in lstTmpCambioDetalle)
                                    {
                                        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                        objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                        objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                                        objE_DocumentoDetalle.Item = Item;
                                        objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                        objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                                        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                                        objE_DocumentoDetalle.Descuento = 0;
                                        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                                        objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                                        objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                                        objE_DocumentoDetalle.IdKardex = 0;
                                        objE_DocumentoDetalle.FlagMuestra = false;
                                        objE_DocumentoDetalle.FlagRegalo = false;
                                        objE_DocumentoDetalle.Stock = 0;
                                        objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                        mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                                        decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                                    }

                                    bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                                    gcDocumentoDetalle.DataSource = bsListado;
                                    gcDocumentoDetalle.RefreshDataSource();

                                    bFlagCumpleanios = objE_DocumentoVenta.FlagCumpleanios; //ECM4
                                    CalculaTotales();

                                    mnuContextual.Enabled = false;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " \n no se encuentra en condición RECIBIDO, por lo tanto No podrá generar una nota de crédito, Consulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("El Documento Venta " + txtSerieReferencia.Text + "-" + txtNumeroReferencia.Text + " de la empresa " + cboEmpresa.Text + " no está autorizado ó ya fue recibida\nConsulte con el supervisor de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtSerieReferencia_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDocumentoReferencia_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                txtSerieReferencia.Select();
            }

        }

        private void cboDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboDocumento_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

     //       XtraMessageBox.Show(Convert.ToString(cboDocumento.EditValue), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cboDocumento_Validating(object sender, CancelEventArgs e)
        {
    
        }

        private void cboDocumento_Validated(object sender, EventArgs e)
        {
          
        }

        private void cboDocumento_Click(object sender, EventArgs e)
        {
           
        }
    }
}