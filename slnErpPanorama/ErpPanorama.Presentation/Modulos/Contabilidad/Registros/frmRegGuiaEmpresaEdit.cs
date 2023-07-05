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
using ErpPanorama.Presentation.Modulos.Contabilidad.Rpt;
using ErpPanorama.Presentation.Funciones;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    public partial class frmRegGuiaEmpresaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();

        int _IdDocumentoVenta = 0;

        public int IdDocumentoVenta
        {
            get { return _IdDocumentoVenta; }
            set { _IdDocumentoVenta = value; }
        }

        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private int IdPedido = 0;
        private int IdDocumentoReferencia = 0;
        private string Serie;
        private string Numero;
        private int IdCambio = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmRegGuiaEmpresaEdit()
        {
            InitializeComponent();
        }

        private void frmRegGuiaEmpresaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            BSUtils.LoaderLook(cboEmpresaVenta, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            deFecha.EditValue = DateTime.Now;
            deFechaVencimiento.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", false);
            cboDocumento.EditValue = Parametros.intTipoDocNotaCredito;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
            cboDocumento.EditValue = 28;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Facturación - Modificar";

                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);

                if (objE_DocumentoVenta != null)
                {
                    cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                    cboTienda.EditValue = objE_DocumentoVenta.IdTienda;
                    cboDocumento.EditValue = objE_DocumentoVenta.IdTipoDocumento;
                    //txtSerie.Text = objE_DocumentoVenta.Serie;
                    //txtNumero.Text = objE_DocumentoVenta.Numero;
                    deFecha.EditValue = objE_DocumentoVenta.Fecha;
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
                    txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                    txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                    txtTotal.EditValue = objE_DocumentoVenta.Total;

                    if (objE_DocumentoVenta.IdSituacion == Parametros.intDVAnulado || objE_DocumentoVenta.IdSituacion == Parametros.intDVGenerado || objE_DocumentoVenta.IdSituacion == Parametros.intDVCancelado)
                    {
                        XtraMessageBox.Show("No se puede modificar el documento de venta. la información es de lectura", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnGrabar.Enabled = true;
                    }
                    else
                    {
                        btnGrabar.Enabled = false;
                    }

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                    {
                        XtraMessageBox.Show("No se puede modificar la nota de credito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnGrabar.Enabled = true;
                    }
                    else
                    {
                        btnGrabar.Enabled = false;
                    }
                }

            }

            CargaDocumentoVentaDetalle();
        }


        private void frmRegFacturacionEdit_Shown(object sender, EventArgs e)
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
                txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
            }

            if (bolFlag)
            {
                this.Close();
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
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
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
                        objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
                        if (objE_ClienteCredito == null)
                        {
                            XtraMessageBox.Show("El cliente seleccionado no tiene una linea de crédito aprobada..por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                    objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
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
                        objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
                        if (objE_ClienteCredito == null)
                        {
                            XtraMessageBox.Show("El cliente seleccionado no tiene una linea de crédito aprobada..por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                    objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
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
            if (cboFormaPago.EditValue != null)
            {
                DateTime dt = Convert.ToDateTime(deFecha.EditValue);
                switch (Convert.ToInt32(cboFormaPago.EditValue))
                {
                    case 70: dt = dt.AddDays(30);
                        deFechaVencimiento.EditValue = dt;
                        break;
                    case 72: dt = dt.AddDays(45);
                        deFechaVencimiento.EditValue = dt;
                        break;
                    case 71: dt = dt.AddDays(60);
                        deFechaVencimiento.EditValue = dt;
                        break;
                    default:
                        break;
                }
            }
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
                    gvDocumentoDetalle.DeleteRow(gvDocumentoDetalle.FocusedRowHandle);
                    gvDocumentoDetalle.RefreshData();

                    //RegeneraItem
                    int i = 0;
                    int cuenta = 0;
                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        item.Item = Convert.ToInt32(cuenta + 1);
                        cuenta++;
                        i++;
                    }

                    CalculaTotales();
                }
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
            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaVentaTraslado) //CUANDO ES BOLETA DE VENTA
            {
                if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
                {
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

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVentaTraslado) //CUANDO ES FACTURA DE VENTA
            {
                if (mListaDocumentoVentaDetalleOrigen.Count <= 36)
                {
                    InsertarDocumentoVenta();//Revisar
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
                    InsertarDocumentoVentaVarios(36);
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

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocGuiaRemision) //CUANDO ES GUIA DE REMISION
            {
                if (mListaDocumentoVentaDetalleOrigen.Count <= 36)
                {
                    InsertarDocumentoVenta();//Revisar
                    if (XtraMessageBox.Show("Esta seguro de imprimir la guia de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    InsertarDocumentoVentaVarios(36);
                    if (XtraMessageBox.Show("Esta seguro de imprimir la guia de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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


            this.Close();
        }

        private void txtTipoCambio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvDocumentoDetalle.RowCount > 0)
                {
                    if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles) //soles
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
                            decPrecioVenta = (decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100)) * decimal.Parse(txtTipoCambio.Text);
                            decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;

                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"], Math.Round(decValorVenta, 2));
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
                objDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);//Parametros.intTiendaId;
                objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                objDocumentoVenta.Periodo = Convert.ToInt32(cboTienda.EditValue);//Parametros.intPeriodo;
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
                //objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
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
                objDocumentoVenta.Observacion = "DOCUMENTO DE VENTA GENERADO - TRASLADO";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.IdCambio = IdCambio;
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
                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                if (pOperacion == Operacion.Nuevo)
                {
                    objBL_DocumentoVenta.Inserta(objDocumentoVenta, lstDocumentoVentaDetalle);
                }
                else
                {
                    objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);
                }
            }

            //Imprimimos los documentos

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
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaDocumentoVentaDetalleOrigen[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = false;
                        objE_DocumentoVentaDetalle.FlagRegalo = false;
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
                    objDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);//Parametros.intTiendaId;
                    objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
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
                    //objDocumentoVenta.IdDocumentoReferencia = cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
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
                    objDocumentoVenta.Observacion = "DOCUMENTO DE VENTA GENERADO - TRASLADO";
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.IdCambio = IdCambio;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

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
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = Math.Round(decPrecioUnitario, 2) * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
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
                                decPrecioUnitario = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
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
                                //lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
                                lstReporte = new ReporteDocumentoVentaBL().ListaGuiaCliente(Convert.ToInt32(cboEmpresa.EditValue), IdCliente, deFecha.DateTime, deFecha.DateTime);

                                rptGuiaRemisionTrasladoPanorama objReporteGuia = new rptGuiaRemisionTrasladoPanorama();

                                #region "Direccion"
                                frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                                frm.ShowDialog();
                                String DirguiaRem = "";

                                if (frm.DireccionGuiaPrint == "")
                                {
                                    DirguiaRem =  txtDireccion.Text.Trim();
                                }
                                else
                                {
                                    DirguiaRem = frm.DireccionGuiaPrint;
                                }
                                #endregion

                                objReporteGuia.SetDataSource(lstReporte);

                                objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
                                objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);

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

                                    if (printer.ToUpper().StartsWith("(G)"))
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
                                    MessageBox.Show("La impresora (G) Nombre para Boleta Panorama no ha sido encontrada.");

                                }
                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
                            }
                        #endregion

                            #region "Nota Credito"
                            else
                                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(IdDocumentoReferencia);

                                    rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
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
                                                    else
                                                        if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                                                        {
                                                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(IdDocumentoReferencia));

                                                            rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
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
                int intTotalCantidad = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        intTotalCantidad = intTotalCantidad + item.Cantidad;
                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);
                    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    txtSubTotal.EditValue = deSubTotal;
                    deImpuesto = deTotal - deSubTotal;
                    txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
                    txtTotalCantidad.EditValue = intTotalCantidad;

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

            if (mListaDocumentoVentaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

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
                objE_DocumentoDetalle.IdKardex = item.IdKardex;
                objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
                objE_DocumentoDetalle.FlagRegalo = item.FlagRegalo;
                objE_DocumentoDetalle.Stock = 0;
                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
            }

            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();
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
            public Int32? IdKardex { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoVentaDetalle()
            {

            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {

                SeteaDocumentoDetalle();

                //Traemos la información del detalle del Pedido

                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaEmpresaTraslado(Convert.ToInt32(cboEmpresaVenta.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));


                int nItem = 1;
                foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
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
                    objE_DocumentoDetalle.IdKardex = item.IdKardex;
                    //objE_DocumentoDetalle.FlagMuestra = false;
                    //objE_DocumentoDetalle.FlagRegalo = false;
                    objE_DocumentoDetalle.Stock = 0;
                    objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                    nItem = nItem + 1;
                }

                bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                gcDocumentoDetalle.DataSource = bsListado;
                gcDocumentoDetalle.RefreshDataSource();

                //Calular Totales en la carga por el tipo de cambio
                if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles) //soles
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
                        decPrecioVenta = (decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100)) * decimal.Parse(txtTipoCambio.Text);
                        decValorVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(posicion, gvDocumentoDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;

                        gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["PrecioVenta"], decPrecioVenta);
                        gvDocumentoDetalle.SetRowCellValue(posicion, gvDocumentoDetalle.Columns["ValorVenta"], Math.Round(decValorVenta, 2));
                        posicion++;
                    }
                }

                CalculaTotales();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "Enero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "Febrero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "Marzo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "Abril";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "Mayo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "Junio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "Julio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "Agosto";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "Septiembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "Octubre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "Noviembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "Diciembre";
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 28;
            dr["Descripcion"] = "GUIA DE REMISION";
            dt.Rows.Add(dr);
            return dt;
        }


    }
}