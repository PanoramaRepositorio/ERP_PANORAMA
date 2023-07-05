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
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Consultas;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegCambioDevolucionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CambioBE> lstCambio;
        public List<CCambioDetalle> mListaCambioDetalleOrigen = new List<CCambioDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdCambio = 0;

        public int IdCambio
        {
            get { return _IdCambio; }
            set { _IdCambio = value; }
        }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int? IdPedido = 0;
        int IdCliente = 0;
        int IdMonedaPedido = 0;
        int IdDocumentoVenta = 0;
        int IdDocumentoVentaNcv = 0;

        //private int IdAsesorExterno = 0;
        bool bRecibido = false;
        public int IdMoneda = Parametros.intSoles;
        public int vIdDocumentoVentaFac = 0;
        public int vIdMonedaDocumentoVenta = 0;//ECM2
        public decimal vTotal = 0;
        public bool bFlagCumpleanios = false;

        #endregion

        #region "Eventos"

        public frmRegCambioDevolucionEdit()
        {
            InitializeComponent();
        }

        private void frmRegCambioDevolucionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaVentas(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocBoletaElectronica; // .intTipoDocTicketBoleta;
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoDevolucion), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = null;
            BSUtils.LoaderLook(cboMotivoSunat, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoNCSunat), "DescTablaElemento", "Abreviatura", true);
            cboMotivoSunat.EditValue = null;
            BSUtils.LoaderLook(cboSupervisor, new PersonaBL().SeleccionaCargo(Parametros.intEmpresaId, Parametros.intSupervisoraVentaPiso), "ApeNom", "IdPersona", true);
            cboSupervisor.EditValue = 0;
            BSUtils.LoaderLook(cboAplicacion, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoAplicacionNotaCredito), "DescTablaElemento", "IdTablaElemento", true);
            cboAplicacion.EditValue = 270;

            //if (pOperacion == Operacion.Nuevo)


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cambio / Devolución - Nuevo";
                //this.Size = new Size(864, 619);
                gcAprobado.Visible = false;
                gcRecibido.Visible = false;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cambio / Devolución - Modificar";
                this.Size = new Size(941, 619);
                gcAprobado.Visible = true;
                gcRecibido.Visible = true;
                txtNumeroDocumentoVenta.Properties.ReadOnly = true;
                txtSerie.Properties.ReadOnly = true;
                cboDocumento.ReadOnly = true;
                chkReajuste.Enabled = false;

                BSUtils.LoaderLook(cboSupervisor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);


                CambioBE objE_Cambio = null;
                objE_Cambio = new CambioBL().Selecciona(IdEmpresa, IdCambio);
                if (objE_Cambio != null)
                {
                    IdCambio = objE_Cambio.IdCambio;
                    IdPedido = objE_Cambio.IdPedido;
                    cboEmpresa.EditValue = objE_Cambio.IdEmpresa;
                    txtNumeroPedido.Text = objE_Cambio.NumeroPedido;
                    IdDocumentoVenta = objE_Cambio.IdDocumentoVenta;
                    cboDocumento.EditValue = objE_Cambio.IdTipoDocumentoVenta;
                    txtSerie.Text = objE_Cambio.SerieDocumentoVenta;
                    txtNumeroDocumentoVenta.Text = objE_Cambio.NumeroDocumentoVenta;
                    deFechaVenta.EditValue = objE_Cambio.FechaVenta;
                    txtCodMoneda.Text = objE_Cambio.CodMoneda;
                    txtTotal.EditValue = objE_Cambio.Total;
                    IdCliente = objE_Cambio.IdCliente;
                    txtCliente.Text = objE_Cambio.DescCliente;
                    txtNumeroCliente.Text = objE_Cambio.NumeroCliente;
                    txtPeriodo.EditValue = objE_Cambio.Periodo;
                    deFecha.EditValue = objE_Cambio.Fecha;
                    txtNumero.Text = objE_Cambio.Numero;
                    cboMotivo.EditValue = objE_Cambio.IdMotivo;
                    cboMotivoSunat.EditValue = objE_Cambio.CodigoNC;
                    cboSupervisor.EditValue = objE_Cambio.IdSupervisor;
                    txtObservaciones.Text = objE_Cambio.Observacion;
                    cboAplicacion.EditValue = objE_Cambio.IdTipoAplicacion;
                    IdDocumentoVentaNcv = Convert.ToInt32(objE_Cambio.IdDocumentoVentaNcv);
                    bRecibido = objE_Cambio.FlagRecibido;
                    chkReajuste.Checked = objE_Cambio.FlagReajuste;

                    lblUsuarioAprobado.Text = objE_Cambio.UsuarioAprobado;
                    lblFechaAprobado.Text = objE_Cambio.FechaAprobado.ToString();
                    lblUsuarioRecibido.Text = objE_Cambio.UsuarioRecibido;
                    lblFechaRecibido.Text = objE_Cambio.FechaRecibido.ToString();

                    //Calcula numero de dias
                    TimeSpan ts = objE_Cambio.Fecha - objE_Cambio.FechaVenta;
                    int dias = ts.Days;
                    txtNDias.EditValue = dias;

                    //Verifica el tipo de moneda usado para facturar
                    if (IdPedido != null)
                    {
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(IdPedido));
                        IdMonedaPedido = objE_Pedido.IdMoneda;
                        bFlagCumpleanios = objE_Pedido.FlagCumpleanios;
                    }
                    else
                    {
                        DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                        objE_Documento = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumeroDocumentoVenta.Text.Trim());
                        if (objE_Documento != null)
                        {
                            IdMonedaPedido = objE_Documento.IdMoneda;
                            bFlagCumpleanios = objE_Documento.FlagCumpleanios;
                        }
                        else
                        {
                            IdMonedaPedido = IdMoneda;
                        }
                    }

                    #region "Ver Forma de pago en caja"
                    if (IdDocumentoVenta > 0)
                    {
                        List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();
                        lstMovimientoCaja = new MovimientoCajaBL().ListaDocumentoVenta(IdDocumentoVenta);

                        txtEfectivo.EditValue = 0;
                        txtVisa.EditValue = 0;
                        txtMastercard.EditValue = 0;

                        foreach (MovimientoCajaBE item in lstMovimientoCaja)
                        {
                            if (item.IdCondicionPago == Parametros.intEfectivo)
                            {
                                txtEfectivo.EditValue = item.ImporteSoles;
                            }
                            else if (item.IdCondicionPago == Parametros.intVisa)
                            {
                                txtVisa.EditValue = item.ImporteSoles;
                            }
                            else if (item.IdCondicionPago == Parametros.intMasterCard)
                            {
                                txtMastercard.EditValue = item.ImporteSoles;
                            }
                        }
                    }
                    #endregion

                    if (IdDocumentoVentaNcv > 0 || bRecibido == true)
                    {
                        mnuContextual.Enabled = false;
                        btnGrabar.Enabled = false;
                    }

                    if (Parametros.intPerfilId == Parametros.intPerAdministrador && objE_Cambio.FlagAprobado == false)
                    {
                        gvCambioDetalle.Columns["PorcentajeDescuento"].OptionsColumn.AllowEdit = true;
                        gvCambioDetalle.Columns["PorcentajeDescuento"].OptionsColumn.AllowFocus = true;
                        gvCambioDetalle.Columns["PrecioUnitario"].OptionsColumn.AllowEdit = true;
                        gvCambioDetalle.Columns["PrecioUnitario"].OptionsColumn.AllowFocus = true;
                    }
                }
            }

            CargaCambioDetalle();

            txtSerie.Focus();
        }

        private void txtNumeroDocumentoVenta_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void CalculaTotalPromocion2x1()
        {

            #region "2022/06 ecm 2x1 v2"
            List<CCambioDetalle> nLista2x1 = mListaCambioDetalleOrigen.Where(x => x.DescPromocion == "2x1").ToList();
            List<CCambioDetalle> nLista3x2 = mListaCambioDetalleOrigen.Where(x => x.DescPromocion == "3x2").ToList();

            #region "2x1 ecm"
            if (nLista2x1.Count != 0)
            {
                nLista2x1 = nLista2x1.OrderByDescending(x => x.PrecioUnitario).ToList();

                List<CCambioDetalle> nListaNuevo2x1 = new List<CCambioDetalle>();
                int iCount = 1;
                int l2x1count = nLista2x1.Sum(x => x.Cantidad);
                bool l2x1Multiplo = true;
                if (l2x1count % 2 != 0)
                {
                    l2x1Multiplo = false;
                }

                foreach (CCambioDetalle item in nLista2x1)
                {
                    int cant = item.Cantidad;
                    int IdProducto = item.IdProducto;
                    decimal PrecioUni = item.PrecioUnitario;
                    bool FlagMuestra = item.FlagMuestra; // ecm10
                    decimal PorcentajeDesc = 0;

                    for (int i2 = 0; i2 <= cant - 1; i2++)
                    {
                        CCambioDetalle RegItem = new CCambioDetalle();
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
                        RegItem.FlagMuestra = FlagMuestra;// ecm10
                        if (iCount % 2 == 0)
                        {
                            RegItem.PrecioUnitario = 0;
                        }

                        nListaNuevo2x1.Add(RegItem);
                        iCount += 1;
                    }
                }

                foreach (CCambioDetalle item in nLista2x1)
                {
                    int IdProducto = item.IdProducto;
                    int iCant = item.Cantidad;
                    bool FlagMuestra = item.FlagMuestra; // ecm10
                    decimal dSuma = nListaNuevo2x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario); // ecm10
                    decimal PorcentajeDescuento = nListaNuevo2x1.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PorcentajeDescuento); // ecm10
                    //decimal dSuma = nListaNuevo2x1.Where(x => x.IdProducto == IdProducto ).Sum(x => x.PrecioUnitario);
                    //decimal PorcentajeDescuento = nListaNuevo2x1.Where(x => x.IdProducto == IdProducto ).Max(x => x.PorcentajeDescuento);

                    decimal pVenta = Math.Round(dSuma / iCant, 2); // (dSuma / iCant );
                    decimal PrecioVenta2x1 = Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2);
                    decimal ValorVenta2x1 = Math.Round(PrecioVenta2x1 * iCant, 2); // Math.Round(pVenta * iCant, 2);

                    //mListaCambioDetalleOrigen.Where(w => w.IdProducto == IdProducto ).ToList().ForEach(
                    mListaCambioDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach( // ecm10
                        s => {
                            s.PorcentajeDescuento = PorcentajeDescuento;
                            s.PrecioVenta = PrecioVenta2x1;
                            s.ValorVenta = ValorVenta2x1;
                            s.ValorVentaDolares = vIdMonedaDocumentoVenta == Parametros.intDolares ? ValorVenta2x1 : Math.Round(ValorVenta2x1 / s.TipoCambio, 2);
                        }
                   );
                }
            }
            #endregion

            #region "3x2 ecm"
            if (nLista3x2.Count != 0)
            {
                nLista3x2 = nLista3x2.OrderByDescending(x => x.PrecioUnitario).ToList();

                List<CCambioDetalle> nListaNuevo3x2 = new List<CCambioDetalle>();
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

                foreach (CCambioDetalle item in nLista3x2)
                {
                    int cant = item.Cantidad;
                    int IdProducto = item.IdProducto;
                    decimal PrecioUni = item.PrecioUnitario;
                    bool FlagMuestra = item.FlagMuestra; // ecm10
                    decimal PorcentajeDesc = 0;

                    for (int i2 = 0; i2 <= cant - 1; i2++)
                    {
                        CCambioDetalle RegItem = new CCambioDetalle();
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
                        RegItem.FlagMuestra = FlagMuestra; // ecm10
                        if (iCount % 3 == 0)
                        {
                            RegItem.PrecioUnitario = 0;
                        }

                        nListaNuevo3x2.Add(RegItem);
                    }
                }

                foreach (CCambioDetalle item in nLista3x2)
                {
                    int IdProducto = item.IdProducto;
                    int iCant = item.Cantidad;
                    bool FlagMuestra = item.FlagMuestra;// ecm10
                    decimal dSuma = nListaNuevo3x2.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Sum(x => x.PrecioUnitario);// ecm10
                    decimal PorcentajeDescuento = nListaNuevo3x2.Where(x => x.IdProducto == IdProducto && x.FlagMuestra == FlagMuestra).Max(x => x.PorcentajeDescuento); // ecm10
                    //decimal dSuma = nListaNuevo3x2.Where(x => x.IdProducto == IdProducto ).Sum(x => x.PrecioUnitario);
                    //decimal PorcentajeDescuento = nListaNuevo3x2.Where(x => x.IdProducto == IdProducto).Max(x => x.PorcentajeDescuento);

                    //decimal pVenta =   Math.Round(dSuma / iCant, 2); // (dSuma / iCant );
                    //decimal PrecioVenta3x2 = Math.Round(dSuma / iCant, 2); // Math.Round(pVenta, 2);
                    //decimal ValorVenta3x2 =  Math.Round(PrecioVenta3x2 * iCant, 2); // Math.Round(pVenta * iCant, 2);
                    decimal pVenta = (dSuma / iCant);
                    decimal PrecioVenta3x2 = Math.Round(pVenta, 2);
                    decimal ValorVenta3x2 = Math.Round(pVenta * iCant, 2);

                    //mListaCambioDetalleOrigen.Where(w => w.IdProducto == IdProducto ).ToList().ForEach(// ecm10
                    mListaCambioDetalleOrigen.Where(w => w.IdProducto == IdProducto && w.FlagMuestra == FlagMuestra).ToList().ForEach(
                       s =>
                       {
                           s.PorcentajeDescuento = PorcentajeDescuento;
                           s.PrecioVenta = PrecioVenta3x2;
                           s.ValorVenta = ValorVenta3x2;
                           s.ValorVentaDolares = vIdMonedaDocumentoVenta == Parametros.intDolares ? ValorVenta3x2 : Math.Round(ValorVenta3x2 / s.TipoCambio, 2);
                       }
                   );
                }
            }
            #endregion
            #endregion
        }
        private void gvCambioDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Cant.")
            {
                decimal decCantidad = 0;
                decimal decPrecioVenta = 0;
                decimal decValorVenta = 0;

                string gv_DescPromocion = gvCambioDetalle.GetRowCellValue(e.RowHandle, "DescPromocion").ToString();
                decimal gv_PrecioVenta = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVenta").ToString());

                decCantidad = decimal.Parse(e.Value.ToString());
                decPrecioVenta = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitario").ToString()) * ((100 - decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
                decValorVenta = Math.Round(decPrecioVenta, 2) * decCantidad;
                if (gv_DescPromocion != "")
                {
                    decPrecioVenta = gv_PrecioVenta;
                    decValorVenta = Math.Round(decPrecioVenta, 2) * decCantidad;

                    this.CalculaTotalPromocion2x1();
                    bsListado.DataSource = mListaCambioDetalleOrigen;
                    gcCambioDetalle.DataSource = bsListado;
                    gcCambioDetalle.RefreshDataSource();
                    this.CalculaTotales();
                    return;
                }
                gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVenta", decPrecioVenta);
                gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVenta", decValorVenta);
                decimal decTipoCambio = 0;
                decTipoCambio = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "TipoCambio").ToString());

                if (decTipoCambio > 0)
                {
                    decimal decPrecioVentaPedido = 0;
                    decimal decValorVentaDolares = 0;

                    if (IdMonedaPedido == Parametros.intDolares)
                    {
                        decPrecioVentaPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVentaPedido").ToString());
                        decValorVentaDolares = decPrecioVentaPedido * decCantidad;
                        //ECM2 //Dalila
                        if (vIdMonedaDocumentoVenta == Parametros.intSoles)
                        {
                            decValorVentaDolares = decValorVentaDolares / decTipoCambio;//ECM2
                        }
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaDolares);
                    }
                    else
                    {
                        decPrecioVentaPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVentaPedido").ToString());
                        decValorVentaDolares = decPrecioVentaPedido * decCantidad;
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaDolares / decTipoCambio);
                    }

                    //if (IdMonedaPedido == Parametros.intSoles)
                    //{
                    //    decPrecioUnitarioPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitarioPedido").ToString());
                    //}
                    //else
                    //{
                    //    decPrecioUnitarioPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitarioPedido").ToString()) * decTipoCambio;
                    //}

                    //if (txtCodMoneda.Text == "S/")
                    //{
                    //    decPrecioVentaPedido = decPrecioUnitarioPedido * ((100 - decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
                    //    decValorVentaSoles =  Math.Round(decPrecioVentaPedido,2) * decCantidad;
                    //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                    //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaSoles", decValorVentaSoles);
                    //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaSoles / decTipoCambio);
                    //}
                    //else
                    //{
                    //    decPrecioVentaPedido = decPrecioUnitarioPedido * ((100 - decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
                    //    decValorVentaSoles = Math.Round(decPrecioVentaPedido,2) * decCantidad * decTipoCambio;
                    //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                    //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaSoles", decValorVentaSoles);
                    //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaSoles / decTipoCambio);
                    //}

                }
            }

            if (e.Column.Caption == "% Dscto" || e.Column.Caption == "P.Unitario")
            {
                decimal decCantidad = 0;
                decimal decDescuento = 0;
                decimal decPrecioVenta = 0;
                decimal decValorVenta = 0;

                string gv_DescPromocion = gvCambioDetalle.GetRowCellValue(e.RowHandle, "DescPromocion").ToString();
                decimal gv_PrecioVenta = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVenta").ToString());

                //decDescuento = decimal.Parse(e.Value.ToString());
                decCantidad = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "Cantidad").ToString());
                decPrecioVenta = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitario").ToString()) * ((100 - decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
                decValorVenta = Math.Round(decPrecioVenta, 2) * decCantidad;
                if (gv_DescPromocion != "")
                {
                    decPrecioVenta = gv_PrecioVenta;
                    decValorVenta = Math.Round(decPrecioVenta, 2) * decCantidad;
                    this.CalculaTotalPromocion2x1();
                    bsListado.DataSource = mListaCambioDetalleOrigen;
                    gcCambioDetalle.DataSource = bsListado;
                    gcCambioDetalle.RefreshDataSource();
                    this.CalculaTotales();
                    return;
                }
                gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVenta", decPrecioVenta);
                gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVenta", decValorVenta);

                decimal decTipoCambio = 0;
                decTipoCambio = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "TipoCambio").ToString());

                if (decTipoCambio > 0)
                {
                    decimal decPrecioVentaPedido = 0;

                    decimal decValorVentaDolares = 0;

                    if (IdMonedaPedido == Parametros.intDolares)
                    {
                        decPrecioVentaPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVentaPedido").ToString());
                        decValorVentaDolares = decPrecioVentaPedido * decCantidad;
                        //ECM2 //Dalila
                        if (vIdMonedaDocumentoVenta == Parametros.intSoles)
                        {
                            decValorVentaDolares = decValorVentaDolares / decTipoCambio;//ECM2
                        }
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaDolares);
                    }
                    else
                    {

                        //decPrecioVentaPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVentaPedido").ToString());
                        //decValorVentaDolares = decPrecioVentaPedido * decCantidad;
                        //gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                        //gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaDolares / decTipoCambio);

                        decPrecioVenta = decPrecioVenta * decCantidad; //28-09-2016
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
                        gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decPrecioVenta / decTipoCambio);

                    }
                }
            }

            //if (e.Column.Caption == "P.Unitario")
            //{
            //    decimal decCantidad = 0;
            //    decimal decDescuento = 0;
            //    decimal decPrecioVenta = 0;
            //    decimal decValorVenta = 0;

            //    //decDescuento = decimal.Parse(e.Value.ToString());
            //    decCantidad = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "Cantidad").ToString());
            //    decPrecioVenta = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitario").ToString()) * ((100 - decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
            //    decValorVenta = Math.Round(decPrecioVenta, 2) * decCantidad;
            //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVenta", decPrecioVenta);
            //    gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVenta", decValorVenta);

            //    decimal decTipoCambio = 0;
            //    decTipoCambio = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "TipoCambio").ToString());

            //    if (decTipoCambio > 0)
            //    {
            //        decimal decPrecioVentaPedido = 0;

            //        decimal decValorVentaDolares = 0;

            //        if (IdMonedaPedido == Parametros.intDolares)
            //        {
            //            decPrecioVentaPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVentaPedido").ToString());
            //            decValorVentaDolares = decPrecioVentaPedido * decCantidad;
            //            gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
            //            gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaDolares);
            //        }
            //        else
            //        {
            //            decPrecioVentaPedido = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioVentaPedido").ToString());
            //            decValorVentaDolares = decPrecioVentaPedido * decCantidad;
            //            gvCambioDetalle.SetRowCellValue(e.RowHandle, "PrecioVentaPedido", decPrecioVentaPedido);
            //            gvCambioDetalle.SetRowCellValue(e.RowHandle, "ValorVentaDolares", decValorVentaDolares / decTipoCambio);
            //        }
            //    }
            //}


            CalculaTotales();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////////////////////////////////////////////////
                /// Validación de las notas que se creen 
                ///////////////////////////////////////////////////////////////////////////////
                DocumentoVentaBE objE_DocumentoCambio = new DocumentoVentaBE();
                objE_DocumentoCambio = new DocumentoVentaBL().SeleccionaTotalCambio(Convert.ToInt32(cboEmpresa.EditValue), vIdDocumentoVentaFac);

                if (objE_DocumentoCambio != null)
                {
                    if ((objE_DocumentoCambio.Total > vTotal))   //+ Convert.ToDecimal(txtTotal.Text))
                    {
                        XtraMessageBox.Show("El monto acumulado de la devolución es mayor al documento de venta de referencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                ///////////////////////////////////////////////////////////////////////////////

                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    //string Usuario = Parametros.strUsuarioLogin;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (!frmAutoriza.Edita)
                    {
                        return;
                    }

                    if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                    {
                        XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                        return;
                    }

                    if (XtraMessageBox.Show("Esta seguro que el motivo de devolución es: " + cboMotivoSunat.Text, this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    CambioBL objBL_Cambio = new CambioBL();
                    CambioBE objCambio = new CambioBE();
                    ObtenerCorrelativo();

                    objCambio.IdCambio = IdCambio;
                    objCambio.IdTienda = Parametros.intTiendaId;
                    objCambio.Periodo = Parametros.intPeriodo;
                    objCambio.Numero = txtNumero.Text;
                    objCambio.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCambio.IdTipoDocumento = Parametros.intTipoDocCambiosDevoluciones;
                    objCambio.IdTipoCambio = 136;
                    objCambio.IdPedido = IdPedido;
                    objCambio.NumeroPedido = txtNumeroPedido.Text;
                    objCambio.IdDocumentoVenta = IdDocumentoVenta;//add
                    objCambio.IdTipoDocumentoVenta = Convert.ToInt32(cboDocumento.EditValue);
                    objCambio.SerieDocumentoVenta = txtSerie.Text;
                    objCambio.NumeroDocumentoVenta = txtNumeroDocumentoVenta.Text;
                    objCambio.FechaVenta = Convert.ToDateTime(deFechaVenta.DateTime.ToShortDateString());
                    objCambio.CodMoneda = txtCodMoneda.Text;
                    objCambio.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objCambio.IdCliente = IdCliente;
                    objCambio.NumeroCliente = txtNumeroCliente.Text;
                    objCambio.DescCliente = txtCliente.Text;
                    objCambio.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objCambio.IdSupervisor = Convert.ToInt32(cboSupervisor.EditValue);
                    objCambio.Usuario = frmAutoriza.Usuario;
                    objCambio.IdPersonaRecibido = Parametros.intUsuarioId;
                    objCambio.FlagReajuste = chkReajuste.Checked;
                    objCambio.CodigoNC = cboMotivoSunat.EditValue.ToString();
                    objCambio.Observacion = txtObservaciones.Text;
                    if (cboAplicacion.Text != "")
                        objCambio.IdTipoAplicacion = Convert.ToInt32(cboAplicacion.EditValue);

                    objCambio.FlagEstado = true;
                    //objCambio.Usuario = Parametros.strUsuarioLogin;
                    objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCambio.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //Cambio Detalle
                    List<CambioDetalleBE> lstCambioDetalle = new List<CambioDetalleBE>();

                    foreach (var item in mListaCambioDetalleOrigen)
                    {
                        CambioDetalleBE objE_CambioDetalle = new CambioDetalleBE();
                        objE_CambioDetalle.IdEmpresa = item.IdEmpresa;
                        objE_CambioDetalle.IdCambio = IdCambio;
                        objE_CambioDetalle.IdCambioDetalle = item.IdCambioDetalle;
                        objE_CambioDetalle.IdProducto = item.IdProducto;
                        objE_CambioDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_CambioDetalle.NombreProducto = item.NombreProducto;
                        objE_CambioDetalle.Abreviatura = item.Abreviatura;
                        objE_CambioDetalle.Cantidad = item.Cantidad;
                        objE_CambioDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_CambioDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_CambioDetalle.PrecioVenta = item.PrecioVenta;
                        objE_CambioDetalle.ValorVenta = item.ValorVenta;
                        objE_CambioDetalle.TipoCambio = item.TipoCambio;
                        objE_CambioDetalle.PrecioUnitarioPedido = item.PrecioUnitarioPedido;
                        objE_CambioDetalle.PrecioVentaPedido = item.PrecioVentaPedido;
                        objE_CambioDetalle.TipoCambio = item.TipoCambio;
                        objE_CambioDetalle.ValorVentaSoles = item.ValorVentaSoles;
                        objE_CambioDetalle.ValorVentaDolares = item.ValorVentaDolares;
                        objE_CambioDetalle.CodAfeIGV = item.CodAfeIGV;
                        objE_CambioDetalle.Observacion = "";
                        objE_CambioDetalle.DescPromocion = item.DescPromocion;
                        objE_CambioDetalle.FlagEstado = true;
                        objE_CambioDetalle.TipoOper = item.TipoOper;
                        lstCambioDetalle.Add(objE_CambioDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objCambio.FlagAprobado = false;
                        objCambio.FlagRecibido = false;
                        objBL_Cambio.Inserta(objCambio, lstCambioDetalle);
                    }
                    else
                    {
                        objBL_Cambio.Actualiza(objCambio, lstCambioDetalle);
                    }

                    XtraMessageBox.Show("Se genero satisfactoriamente la \nSolicitud de Devolución Nro.: " + txtNumero.Text.Trim(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaCambioDetalleOrigen.Count > 0)
                {
                    gvCambioDetalle.DeleteRow(gvCambioDetalle.FocusedRowHandle);
                    gvCambioDetalle.RefreshData();

                }
                this.CalculaTotalPromocion2x1();
                CalculaTotales();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            try
            {
                this.HabilitarCumpleanios();//add ecm 200615
                decimal deValorVenta = 0;
                decimal deTotal = 0;
                decimal deTotalBruto = 0;
                decimal detotalDsctoCumple = 0;

                if (mListaCambioDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaCambioDetalleOrigen)
                    {
                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                        deTotalBruto = deTotalBruto + deValorVenta;

                        if (bFlagCumpleanios)//add ecm 200615
                        {
                            detotalDsctoCumple = new PedidoBL().lgDescuentoPorCumpleanios(detotalDsctoCumple, item.IdMarca, item.PorcentajeDescuento, item.ValorVenta);
                        }
                    }

                    if (bFlagCumpleanios)//add ecm 200615
                    {
                        txtDsctoCumple.Text = Math.Round(detotalDsctoCumple, 2).ToString();
                        deTotal = Math.Round(deTotal - detotalDsctoCumple, 2);
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);
                    txtTotalBruto.EditValue = Math.Round(deTotalBruto, 2);
                }
                else
                {
                    txtTotal.EditValue = 0;
                    txtTotalBruto.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HabilitarCumpleanios()//add ecm 200615
        {
            lblDsctoCumple.Visible = false;
            txtDsctoCumple.Visible = false;
            if (bFlagCumpleanios)
            {
                lblDsctoCumple.Visible = true;
                txtDsctoCumple.Visible = true;
            }
        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocCambiosDevoluciones, Parametros.intPeriodo);
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

            if (txtNumeroDocumentoVenta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el documento ventas.\n";
                flag = true;
            }

            //if (txtNumero.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese el número del deocumento.\n";
            //    flag = true;
            //}

            if (cboSupervisor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el nombre del supervisor.\n";
                flag = true;
            }

            if (cboMotivo.EditValue == "" || cboMotivo.EditValue == null || cboMotivo.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar el motivo de devolución.\n";
                flag = true;
            }

            if (cboMotivoSunat.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar el motivo de devolución SUNAT.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var BuscarDocumento = lstCambio.Where(oB => oB.Numero.ToUpper() == txtNumero.Text.ToUpper()).ToList();
                if (BuscarDocumento.Count > 0)
                {
                    strMensaje = strMensaje + "- El número de documento ya existe.\n";
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

        private void SeteaCambioDetalle()
        {
            mListaCambioDetalleOrigen.Clear();
            bsListado.DataSource = mListaCambioDetalleOrigen;
            gcCambioDetalle.DataSource = bsListado;
            gcCambioDetalle.RefreshDataSource();
        }

        private void CargaCambioDetalle()
        {
            List<CambioDetalleBE> lstTmpCambioDetalle = null;
            lstTmpCambioDetalle = new CambioDetalleBL().ListaTodosActivo(IdCambio);

            foreach (CambioDetalleBE item in lstTmpCambioDetalle)
            {
                CCambioDetalle objE_DocumentoDetalle = new CCambioDetalle();
                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoDetalle.IdCambio = item.IdCambio;
                objE_DocumentoDetalle.IdCambioDetalle = item.IdCambioDetalle;
                objE_DocumentoDetalle.IdMarca = item.IdMarca;//add ecm 200615
                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoDetalle.TipoCambio = item.TipoCambio;
                objE_DocumentoDetalle.PrecioUnitarioPedido = item.PrecioUnitarioPedido;
                objE_DocumentoDetalle.PrecioVentaPedido = item.PrecioVentaPedido;
                objE_DocumentoDetalle.ValorVentaSoles = item.ValorVentaSoles;
                objE_DocumentoDetalle.ValorVentaDolares = item.ValorVentaDolares;
                objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_DocumentoDetalle.Observacion = "";
                objE_DocumentoDetalle.DescPromocion = item.DescPromocion;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaCambioDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            bsListado.DataSource = mListaCambioDetalleOrigen;
            gcCambioDetalle.DataSource = bsListado;
            gcCambioDetalle.RefreshDataSource();

            var var_ExistePromocion = mListaCambioDetalleOrigen.Find(x => x.DescPromocion.Length > 0);
            if (var_ExistePromocion != null)
            {
                gvCambioDetalle.Columns["DescPromocion"].Visible = true;
                gvCambioDetalle.Columns["DescPromocion"].VisibleIndex = 9;
            }
            CalculaTotales();
        }

        #endregion

        public class CCambioDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdCambio { get; set; }
            public Int32 IdCambioDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public Int32 IdMarca { get; set; }//add ecm 200615
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String CodAfeIGV { get; set; }
            public Decimal TipoCambio { get; set; }
            public Decimal PrecioUnitarioPedido { get; set; }
            public Decimal PrecioVentaPedido { get; set; }
            public Decimal ValorVentaSoles { get; set; }
            public Decimal ValorVentaDolares { get; set; }
            public String Observacion { get; set; }
            public String DescPromocion { get; set; }
            public Int32 TipoOper { get; set; }
            public Int32 Item { get; set; }
            public Boolean FlagMuestra { get; set; }// ecm10
            public CCambioDetalle()
            {

            }
        }

        private void chkReajuste_CheckedChanged(object sender, EventArgs e)
        {
            txtNumeroDocumentoVenta.Select();
            txtNumeroDocumentoVenta.SelectAll();
        }

        private void txtNumeroDocumentoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumeroDocumentoVenta.Text.Trim());
                vIdDocumentoVentaFac = objE_Documento.IdDocumentoVenta;
                vIdMonedaDocumentoVenta = objE_Documento.IdMoneda; //ECM2
                vTotal = objE_Documento.Total;
                if (objE_Documento != null)
                {
                    if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId != Parametros.intPerHelpDesk)
                    {
                    }
                    else
                    {
                        if (objE_Documento.IdTipoCliente == Parametros.intTipClienteMayorista)
                        {
                            if (objE_Documento.Fecha < DateTime.Now.AddDays(-16))
                            {
                                XtraMessageBox.Show("No se aceptan devoluciones pasado los 15 días, GRACIAS POR SU COMPRA!!!\nPara más información llamar a Atención al Cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        else
                        {
                            if (objE_Documento.Fecha < DateTime.Now.AddDays(-8))
                            {
                                XtraMessageBox.Show("No se aceptan devoluciones pasado los 7 días, GRACIAS POR SU COMPRA!!!\nPara más información llamar a Atención al Cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }

                    //if(objE_Documento.IdFormaPago==Parametros.intObsequio)
                    //{
                    //    XtraMessageBox.Show("No se puede realizar una devolución de un Obsequio.\nConsulte con su administrador.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}
                    bFlagCumpleanios = objE_Documento.FlagCumpleanios;
                    IdDocumentoVenta = objE_Documento.IdDocumentoVenta;
                    IdPedido = objE_Documento.IdPedido;
                    if (objE_Documento.IdPedido != null)
                    {
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(objE_Documento.IdPedido));
                        IdMonedaPedido = objE_Pedido.IdMoneda;
                        //IdAsesorExterno = objE_Pedido.IdAsesorExterno;
                    }
                    else
                    {
                        IdMonedaPedido = objE_Documento.IdMoneda;
                    }

                    cboEmpresa.EditValue = objE_Documento.IdEmpresa;
                    txtNumeroPedido.Text = objE_Documento.NumeroPedido;
                    cboDocumento.EditValue = objE_Documento.IdTipoDocumento;
                    txtSerie.Text = objE_Documento.Serie;
                    txtNumeroDocumentoVenta.Text = objE_Documento.Numero;
                    deFechaVenta.EditValue = objE_Documento.Fecha;
                    txtCodMoneda.Text = objE_Documento.CodMoneda;
                    IdCliente = objE_Documento.IdCliente;
                    txtCliente.Text = objE_Documento.DescCliente;
                    txtNumeroCliente.Text = objE_Documento.NumeroDocumento;
                    //Calcula numero de dias
                    TimeSpan ts = deFecha.DateTime - objE_Documento.Fecha;
                    int dias = ts.Days;
                    txtNDias.EditValue = dias;

                    txtTotal.EditValue = objE_Documento.Total;
                    txtTotalBruto.EditValue = objE_Documento.TotalBruto;//add 151215
                    txtDsctoCumple.EditValue = objE_Documento.TotalDscCumpleanios;//add ecm 200615
                    SeteaCambioDetalle();
                    this.HabilitarCumpleanios();//add ecm 200615

                    if (chkReajuste.Checked)//por Reajuste
                    {
                        frmEstablecerPrecio frm = new frmEstablecerPrecio();
                        frm.Titulo = "Ingresar el precio en Soles de Reajuste";
                        frm.StartPosition = FormStartPosition.CenterParent;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            CCambioDetalle objE_CambioDetalle = new CCambioDetalle();
                            objE_CambioDetalle.IdEmpresa = objE_Documento.IdEmpresa;
                            objE_CambioDetalle.IdCambio = 0;
                            objE_CambioDetalle.IdCambioDetalle = 0;
                            objE_CambioDetalle.IdMarca = 0;//add ecm 200615
                            objE_CambioDetalle.IdProducto = 44654;
                            objE_CambioDetalle.CodigoProveedor = "REAJUSTE";
                            objE_CambioDetalle.NombreProducto = "POR REAJUSTE DE PRECIOS";
                            objE_CambioDetalle.Abreviatura = "NNN";
                            objE_CambioDetalle.Cantidad = 1;
                            objE_CambioDetalle.PrecioUnitario = frm.Precio;
                            objE_CambioDetalle.PorcentajeDescuento = 0;
                            objE_CambioDetalle.PrecioVenta = frm.Precio;
                            objE_CambioDetalle.ValorVenta = frm.Precio;
                            objE_CambioDetalle.TipoCambio = objE_Documento.TipoCambio;
                            objE_CambioDetalle.PrecioUnitarioPedido = 0;
                            objE_CambioDetalle.PrecioVentaPedido = 0;
                            //objE_CambioDetalle.ValorVentaSoles = 0;
                            //objE_CambioDetalle.ValorVentaDolares = 0;
                            objE_CambioDetalle.Observacion = "";
                            objE_CambioDetalle.TipoOper = 1;
                            if (objE_Documento.IdMoneda == Parametros.intSoles)
                            {
                                objE_CambioDetalle.ValorVentaSoles = frm.Precio;
                                objE_CambioDetalle.ValorVentaDolares = Math.Round((frm.Precio / objE_Documento.TipoCambio), 2);
                            }
                            else
                            {
                                objE_CambioDetalle.ValorVentaSoles = Math.Round((frm.Precio * objE_Documento.TipoCambio), 2);
                                objE_CambioDetalle.ValorVentaDolares = frm.Precio;
                            }
                            objE_CambioDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                            mListaCambioDetalleOrigen.Add(objE_CambioDetalle);

                            txtTotal.EditValue = frm.Precio;
                            txtTotalBruto.EditValue = 0;//add 151215
                        }

                    }
                    else
                    {
                        //Traemos la información del detalle del documento
                        List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                        lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaPedido(objE_Documento.IdDocumentoVenta);

                        foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
                        {
                            CCambioDetalle objE_CambioDetalle = new CCambioDetalle();
                            objE_CambioDetalle.IdEmpresa = item.IdEmpresa;
                            objE_CambioDetalle.IdCambio = 0;
                            objE_CambioDetalle.IdCambioDetalle = 0;
                            objE_CambioDetalle.IdMarca = item.IdMarca;//add ecm 200615
                            objE_CambioDetalle.IdProducto = item.IdProducto;
                            objE_CambioDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_CambioDetalle.NombreProducto = item.NombreProducto;
                            objE_CambioDetalle.Abreviatura = item.Abreviatura;
                            objE_CambioDetalle.Cantidad = item.Cantidad;
                            objE_CambioDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_CambioDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                            objE_CambioDetalle.PrecioVenta = item.PrecioVenta;
                            objE_CambioDetalle.ValorVenta = item.ValorVenta;
                            objE_CambioDetalle.TipoCambio = item.TipoCambio;
                            objE_CambioDetalle.PrecioUnitarioPedido = item.PrecioUnitarioPedido;
                            objE_CambioDetalle.PrecioVentaPedido = item.PrecioVentaPedido;
                            objE_CambioDetalle.TipoCambio = item.TipoCambio;
                            objE_CambioDetalle.ValorVentaSoles = item.ValorVentaSoles;
                            objE_CambioDetalle.ValorVentaDolares = item.ValorVentaDolares;
                            objE_CambioDetalle.CodAfeIGV = item.CodAfeIGV;
                            objE_CambioDetalle.Observacion = "";
                            objE_CambioDetalle.DescPromocion = item.DescPromocion;
                            objE_CambioDetalle.FlagMuestra = item.FlagMuestra;// ecm10
                            objE_CambioDetalle.TipoOper = item.TipoOper;
                            mListaCambioDetalleOrigen.Add(objE_CambioDetalle);
                        }
                    }

                    bsListado.DataSource = mListaCambioDetalleOrigen;
                    gcCambioDetalle.DataSource = bsListado;
                    gcCambioDetalle.RefreshDataSource();
                    CalculaTotales();
                    var var_ExistePromocion = mListaCambioDetalleOrigen.Find(x => x.DescPromocion.Length > 0);
                    if (var_ExistePromocion != null)
                    {
                        gvCambioDetalle.Columns["DescPromocion"].Visible = true;
                        gvCambioDetalle.Columns["DescPromocion"].VisibleIndex = 9;
                    }
                    //Forma de pago en Caja

                    #region "Ver Forma de pago en caja"

                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();
                    lstMovimientoCaja = new MovimientoCajaBL().ListaDocumentoVenta(IdDocumentoVenta);

                    txtEfectivo.EditValue = 0;
                    txtVisa.EditValue = 0;
                    txtMastercard.EditValue = 0;

                    foreach (MovimientoCajaBE item in lstMovimientoCaja)
                    {
                        if (item.IdCondicionPago == Parametros.intEfectivo)
                        {
                            txtEfectivo.EditValue = item.ImporteSoles;
                        }
                        else if (item.IdCondicionPago == Parametros.intVisa)
                        {
                            txtVisa.EditValue = item.ImporteSoles;
                        }
                        else if (item.IdCondicionPago == Parametros.intMasterCard)
                        {
                            txtMastercard.EditValue = item.ImporteSoles;
                        }
                    }

                    #endregion

                    if (objE_Documento.TotalBruto > objE_Documento.Total)
                    {
                        gvCambioDetalle.Columns["PorcentajeDescuento"].OptionsColumn.AllowEdit = true;
                        gvCambioDetalle.Columns["PorcentajeDescuento"].OptionsColumn.AllowFocus = true;
                        gvCambioDetalle.Columns["PrecioUnitario"].OptionsColumn.AllowEdit = true;
                        gvCambioDetalle.Columns["PrecioUnitario"].OptionsColumn.AllowFocus = true;

                        XtraMessageBox.Show("Este documento contiene % DESCUENTO adicional en la facturación, Pasos a Realizar:\nCaso NCV: 2x1 aplicar 50%, 3x2 aplicar 33.33%\nCaso SDV: No es Necesario aplicar dsctos.(Válido para RUS)\nPara Más Información Consultar con Sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    txtNumeroDocumentoVenta.Properties.ReadOnly = true;
                    txtSerie.Properties.ReadOnly = true;
                    cboDocumento.ReadOnly = true;
                    chkReajuste.Enabled = false;
                    //btnEditar.Visible = false;

                    if (IdCliente == Parametros.intIdClienteGeneral)
                        btnBuscar.Enabled = true;
                    else
                        btnBuscar.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show("El documento de venta no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSerie_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}