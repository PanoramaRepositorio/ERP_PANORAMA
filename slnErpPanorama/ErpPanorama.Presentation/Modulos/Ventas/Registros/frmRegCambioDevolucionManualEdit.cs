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
using Excel = Microsoft.Office.Interop.Excel;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegCambioDevolucionManualEdit : DevExpress.XtraEditors.XtraForm
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
        int IdMonedaPedido = 5;
        decimal TipoCambio = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;

        #endregion

        #region "Eventos"

        public frmRegCambioDevolucionManualEdit()
        {
            InitializeComponent();
        }

        private void frmRegCambioDevolucionManualEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaVentas(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocTicketBoleta;
            deFecha.EditValue = DateTime.Now;
            deFechaVenta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMotivoDevolucion), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboSupervisor, new PersonaBL().SeleccionaCargo(Parametros.intEmpresaId, Parametros.intSupervisoraVentaPiso), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;

            txtPeriodoPedido.EditValue = DateTime.Now.Year;
            

            if (pOperacion == Operacion.Nuevo)
                ObtenerCorrelativo();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cambio / Devolución - Nuevo";
                
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cambio / Devolución - Modificar";

                CambioBE objE_Cambio = null;
                objE_Cambio = new CambioBL().Selecciona(IdEmpresa, IdCambio);
                if (objE_Cambio != null)
                {
                    IdCambio = objE_Cambio.IdCambio;
                    IdPedido = objE_Cambio.IdPedido;
                    cboEmpresa.EditValue = objE_Cambio.IdEmpresa;
                    txtNumeroPedido.Text = objE_Cambio.NumeroPedido;
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
                    cboSupervisor.EditValue = objE_Cambio.IdSupervisor;
                    txtObservaciones.Text = objE_Cambio.Observacion;

                    txtNumeroPedido.Properties.ReadOnly = true;

                    //Calcula numero de dias
                    TimeSpan ts = objE_Cambio.Fecha - objE_Cambio.FechaVenta;
                    int dias = ts.Days;
                    txtNDias.EditValue = dias;

                }
            }

            CargaCambioDetalle();

            txtSerie.Focus();
        }

        private void txtNumeroDocumentoVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumeroDocumentoVenta.Text.Trim());
                if (objE_Documento != null)
                {
                    IdPedido = objE_Documento.IdPedido;
                    if (objE_Documento.IdPedido != null)
                    {
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(objE_Documento.IdPedido));
                        IdMonedaPedido = objE_Pedido.IdMoneda;
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

                    SeteaCambioDetalle();

                    //Traemos la información del detalle del documento
                    List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                    lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaPedido(objE_Documento.IdDocumentoVenta);

                    foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
                    {
                        CCambioDetalle objE_CambioDetalle = new CCambioDetalle();
                        objE_CambioDetalle.IdEmpresa = item.IdEmpresa;
                        objE_CambioDetalle.IdCambio = 0;
                        objE_CambioDetalle.IdCambioDetalle = 0;
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
                        objE_CambioDetalle.TipoOper = item.TipoOper;
                        mListaCambioDetalleOrigen.Add(objE_CambioDetalle);
                    }

                    bsListado.DataSource = mListaCambioDetalleOrigen;
                    gcCambioDetalle.DataSource = bsListado;
                    gcCambioDetalle.RefreshDataSource();
                }
                else
                {
                    XtraMessageBox.Show("El documento de venta no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void gvCambioDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Cant.")
            {
                decimal decCantidad = 0;
                decimal decPrecioVenta = 0;
                decimal decValorVenta = 0;

                decCantidad = decimal.Parse(e.Value.ToString());
                decPrecioVenta = decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitario").ToString()) * ((100 - decimal.Parse(gvCambioDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
                decValorVenta = Math.Round(decPrecioVenta, 2) * decCantidad;
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

            CalculaTotales();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CambioBL objBL_Cambio = new CambioBL();
                    CambioBE objCambio = new CambioBE();

                    objCambio.IdCambio = IdCambio;
                    objCambio.IdTienda = Parametros.intTiendaId;
                    objCambio.Periodo = Parametros.intPeriodo;
                    objCambio.Numero = txtNumero.Text;
                    objCambio.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCambio.IdTipoDocumento = Parametros.intTipoDocCambiosDevoluciones;
                    objCambio.IdTipoCambio = 136;
                    //objCambio.IdPedido = IdPedido;
                    if (IdPedido == 0) objCambio.IdPedido = null;
                    else objCambio.IdPedido = IdPedido;

                    objCambio.NumeroPedido = txtNumeroPedido.Text;
                    objCambio.IdTipoDocumentoVenta = Parametros.intTipoDocPedidoVenta;//Convert.ToInt32(cboDocumento.EditValue);
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
                    objCambio.Observacion = txtObservaciones.Text;

                    objCambio.FlagEstado = true;
                    objCambio.Usuario = Parametros.strUsuarioLogin;
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
                        objE_CambioDetalle.Observacion = "";
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

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PedidoBE objE_Documento = new PedidoBE();
                    objE_Documento = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodoPedido.EditValue), txtNumeroPedido.Text.Trim());
                    if (objE_Documento != null)
                    {
                        IdPedido = objE_Documento.IdPedido;
                        IdMonedaPedido = objE_Documento.IdMoneda;
                        cboEmpresa.EditValue = objE_Documento.IdEmpresa;
                        txtNumeroPedido.Text = objE_Documento.Numero;
                        cboDocumento.EditValue = objE_Documento.IdTipoDocumento;
                        //txtSerie.Text = objE_Documento.Serie;
                        //txtNumeroDocumentoVenta.Text = objE_Documento.Numero;
                        deFechaVenta.EditValue = objE_Documento.Fecha;
                        txtCodMoneda.Text = objE_Documento.CodMoneda;
                        cboMoneda.EditValue = objE_Documento.IdMoneda; //add
                        IdCliente = objE_Documento.IdCliente;
                        txtCliente.Text = objE_Documento.DescCliente;
                        txtNumeroCliente.Text = objE_Documento.NumeroDocumento;
                        TipoCambio = objE_Documento.TipoCambio;
                        //Calcula numero de dias
                        TimeSpan ts = deFecha.DateTime - objE_Documento.Fecha;
                        int dias = ts.Days;
                        txtNDias.EditValue = dias;

                        SeteaCambioDetalle();

                        //Traemos la información del detalle de Pedido
                        List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                        lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoConsignacion(objE_Documento.IdPedido);

                        foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                        {
                            CCambioDetalle objE_CambioDetalle = new CCambioDetalle();
                            objE_CambioDetalle.IdEmpresa = item.IdEmpresa;
                            objE_CambioDetalle.IdCambio = 0;
                            objE_CambioDetalle.IdCambioDetalle = 0;
                            objE_CambioDetalle.IdProducto = item.IdProducto;
                            objE_CambioDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_CambioDetalle.NombreProducto = item.NombreProducto;
                            objE_CambioDetalle.Abreviatura = item.Abreviatura;
                            objE_CambioDetalle.Cantidad = item.Cantidad;
                            objE_CambioDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_CambioDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                            objE_CambioDetalle.PrecioVenta = item.PrecioVenta;
                            objE_CambioDetalle.ValorVenta = item.ValorVenta;
                            objE_CambioDetalle.TipoCambio = TipoCambio;//item.TipoCambio;
                            objE_CambioDetalle.PrecioUnitarioPedido = item.PrecioUnitario;
                            objE_CambioDetalle.PrecioVentaPedido = item.PrecioVenta;
                            if (IdMonedaPedido == 5)
                            {
                                objE_CambioDetalle.ValorVentaSoles = item.ValorVenta;
                                objE_CambioDetalle.ValorVentaDolares = item.ValorVenta / TipoCambio;
                            }
                            else
                            {
                                objE_CambioDetalle.ValorVentaSoles = item.ValorVenta * TipoCambio;
                                objE_CambioDetalle.ValorVentaDolares = item.ValorVenta;
                            }

                            objE_CambioDetalle.ValorVentaDolares = item.ValorVenta;
                            objE_CambioDetalle.TipoOper = item.TipoOper;
                            mListaCambioDetalleOrigen.Add(objE_CambioDetalle);
                        }

                        bsListado.DataSource = mListaCambioDetalleOrigen;
                        gcCambioDetalle.DataSource = bsListado;
                        gcCambioDetalle.RefreshDataSource();
                    }
                    else
                    {
                        XtraMessageBox.Show("El documento de venta no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroCliente.Text = frm.pClienteBE.NumeroDocumento;
                    txtCliente.Text = frm.pClienteBE.DescCliente;
                    //txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                    btnNuevo.Focus();
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
                    txtNumeroCliente.Focus();
                    return;
                }

                frmBusClienteAsociado frm = new frmBusClienteAsociado();
                frm.IdCliente = IdCliente;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteAsociadoBE != null)
                {
                    txtNumeroCliente.Text = frm.pClienteAsociadoBE.NumeroDocumento;
                    txtCliente.Text = frm.pClienteAsociadoBE.DescCliente;
                    //txtDireccion.Text = frm.pClienteAsociadoBE.Direccion;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroCliente.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //frmRegPedidoDetalleEdit movDetalle = new frmRegPedidoDetalleEdit();
                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                int i = 0;
                //if (mListaCambioDetalleOrigen.Count > 0)
                //    i = mListaCambioDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                //movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                //movDetalle.bPreVenta = chkPreventa.Checked;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaCambioDetalleOrigen.Count == 0)
                        {
                            gvCambioDetalle.AddNewRow();
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Stock", 0);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvCambioDetalle.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            btnNuevo.Focus();

                            return;

                        }
                        if (mListaCambioDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaCambioDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvCambioDetalle.AddNewRow();
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Stock", 0);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvCambioDetalle.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;

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

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            IdMonedaPedido = Convert.ToInt32(cboMoneda.EditValue);
            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                txtCodMoneda.Text = "S/";
            else
                txtCodMoneda.Text = "US$";
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.modificarprecioToolStripMenuItem_Click(sender, e);
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaCambioDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                movDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdDocumentoVenta = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("IdDocumentoVenta"));
                movDetalle.IdDocumentoVentaDetalle = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvCambioDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvCambioDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvCambioDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvCambioDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvCambioDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvCambioDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvCambioDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.IdKardex = Convert.ToInt32(gvCambioDetalle.GetFocusedRowCellValue("IdKardex"));
                movDetalle.PorcentajeDescuentoInicial = Convert.ToDecimal(gvCambioDetalle.GetFocusedRowCellValue("PorcentajeDescuentoInicial"));
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvCambioDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvCambioDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvCambioDetalle.SetRowCellValue(xposition, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                        gvCambioDetalle.SetRowCellValue(xposition, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                        gvCambioDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvCambioDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvCambioDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvCambioDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvCambioDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvCambioDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvCambioDetalle.SetRowCellValue(xposition, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                        gvCambioDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvCambioDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvCambioDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvCambioDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvCambioDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvCambioDetalle.SetRowCellValue(xposition, "IdKardex", movDetalle.oBE.IdKardex);
                        gvCambioDetalle.SetRowCellValue(xposition, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                        gvCambioDetalle.SetRowCellValue(xposition, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                        gvCambioDetalle.SetRowCellValue(xposition, "Stock", 0);
                        gvCambioDetalle.SetRowCellValue(xposition, "PrecioUnitarioInicial", 0);
                        gvCambioDetalle.SetRowCellValue(xposition, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                        gvCambioDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        gvCambioDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvCambioDetalle.UpdateCurrentRow();

                        //bNuevo = movDetalle.bNuevo;

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
                int IdCambioDetalle = 0;
                if (gvCambioDetalle.GetFocusedRowCellValue("IdCambioDetalle") != null)
                    IdCambioDetalle = int.Parse(gvCambioDetalle.GetFocusedRowCellValue("IdCambioDetalle").ToString());
                //int Item = 0;
                //if (gvCambioDetalle.GetFocusedRowCellValue("Item") != null)
                //    Item = int.Parse(gvCambioDetalle.GetFocusedRowCellValue("Item").ToString());
                CambioDetalleBE objBE_CambioDetalle = new CambioDetalleBE();
                objBE_CambioDetalle.IdCambioDetalle = IdCambioDetalle;
                objBE_CambioDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_CambioDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_CambioDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                CambioDetalleBL objBL_CambioDetalle = new CambioDetalleBL();
                objBL_CambioDetalle.Elimina(objBE_CambioDetalle);
                gvCambioDetalle.DeleteRow(gvCambioDetalle.FocusedRowHandle);
                gvCambioDetalle.RefreshData();

                //RegeneraItem
                //int i = 0;
                //int cuenta = 0;
                //foreach (var item in mListaCambioDetalleOrigen)
                //{
                //    item.Item = Convert.ToByte(cuenta + 1);
                //    cuenta++;
                //    i++;
                //}

                CalculaTotales();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                //Cargar();
            }
        }


        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            try
            {
                decimal deValorVenta = 0;
                decimal deTotal = 0;

                if (mListaCambioDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaCambioDetalleOrigen)
                    {

                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);
                }
                else
                {
                    txtTotal.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //if (txtNumeroDocumentoVenta.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Seleccionar el documento ventas.\n";
            //    flag = true;
            //}

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número del documento.\n";
                flag = true;
            }

            if(IdCliente == Parametros.intIdClienteGeneral)
            {
                strMensaje = strMensaje + "- No se aceptan devoluciones con CLIENTE GENERAL.\n";
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
                objE_DocumentoDetalle.Observacion = item.Observacion;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaCambioDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            bsListado.DataSource = mListaCambioDetalleOrigen;
            gcCambioDetalle.DataSource = bsListado;
            gcCambioDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private void ImportarExcel(string filename)
        {
            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;


                //Recorremos para el Cambio
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaPrecio(Parametros.intEmpresaId, Parametros.intTiendaUcayali, CodigoProveedor);

                    if (objE_Producto != null)
                    {
                        decimal Precio = 0;
                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                            Precio = objE_Producto.PrecioCDSoles;
                        else
                            Precio = objE_Producto.PrecioCD;

                        gvCambioDetalle.AddNewRow();
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Item",(mListaCambioDetalleOrigen.Count - 1) + 1);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdProducto",objE_Producto.IdProducto);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "CantidadAnt", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioUnitario", Precio);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PorcentajeDescuento", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Descuento", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioVenta", Precio);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "ValorVenta", Precio * Cantidad);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdKardex", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "FlagMuestra", false);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "FlagRegalo", false);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "Stock", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PrecioUnitarioInicial", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", 0);
                        gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "IdLineaProducto", objE_Producto.IdLineaProducto);
                        //gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));

                        if (pOperacion == Operacion.Modificar)
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvCambioDetalle.SetRowCellValue(gvCambioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    }
                    else
                    {
                        XtraMessageBox.Show("El código " + CodigoProveedor + "No existe, Verificar!.\nSin embargo continuará la importación con los códigos válidos.", this.Text);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                //EncuestaBL objBL_Encuesta = new EncuestaBL();
                //objBL_Encuesta.InsertaLista(mEncuesta);

                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        public class CCambioDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdCambio { get; set; }
            public Int32 IdCambioDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public Decimal TipoCambio { get; set; }
            public Decimal PrecioUnitarioPedido { get; set; }
            public Decimal PrecioVentaPedido { get; set; }
            public Decimal ValorVentaSoles { get; set; }
            public Decimal ValorVentaDolares { get; set; }
            public String Observacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CCambioDetalle()
            {

            }
        }


    }
}