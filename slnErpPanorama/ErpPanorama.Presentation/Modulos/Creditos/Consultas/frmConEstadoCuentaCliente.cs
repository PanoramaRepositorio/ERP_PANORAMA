using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using System.Transactions;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using System.Security.Principal;


namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConEstadoCuentaCliente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaClienteBE> mLista = new List<EstadoCuentaClienteBE>();
        private List<EstadoCuentaClientePagoBE> mListaPago = new List<EstadoCuentaClientePagoBE>();

        public int IdCliente = 0;
        public int Origen = 0;
        public string NumeroDocumento = "";
        public string DescCliente = "";

        #endregion

        #region "Eventos"
        public frmConEstadoCuentaCliente()
        {
            InitializeComponent();
        }

        private void frmConEstadoCuentaCliente_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            BSUtils.LoaderLook(cboSituacion, CargarSituacion(), "Descripcion", "Id", false);
            cboSituacion.EditValue = 350;

            if (Origen == 1) //Desde Consulta de saldos
            {
                txtNumeroDocumento.Text = NumeroDocumento;
                txtDescCliente.Text = DescCliente;
                btnConsultar_Click(sender, e);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    Cargar();

                    //if (frm.pClienteBE.IdTipoCliente == Parametros.intTipClienteFinal && frm.pClienteBE.IdClasificacionCliente != Parametros.intBlack)
                    //{
                    //    XtraMessageBox.Show("Atención! El cliente es MINORISTA se recomienda registrar en el estado de cuenta Soles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvEstadoCuentaCliente_RowStyle(object sender, RowStyleEventArgs e)
        {
            //try
            //{
            //    object obj = gvEstadoCuentaCliente.GetRow(e.RowHandle);

            //    GridView View = sender as GridView;
            //    if (e.RowHandle >= 0)
            //    {
            //        object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["TipoMovimiento"]);
            //        if (objDocRetiro.ToString() == "A")
            //        {
            //            e.Appearance.BackColor = Color.LightGreen;
            //            e.Appearance.BackColor2 = Color.SeaShell;
            //        }

            //        //object objDocRetiro2 = View.GetRowCellValue(e.RowHandle, View.Columns["IdCuentaBancoDetalle"]);
            //        //if (objDocRetiro2 != null)
            //        //{
            //        //    e.Appearance.BackColor = Color.SkyBlue;
            //        //    e.Appearance.BackColor2 = Color.SeaShell;
            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            if (IdCliente > 0)
            {
                Cargar();
            }
        }

        private void gvEstadoCuentaCliente_DoubleClick(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                if (objE_DocumentoVenta.TipoMovimiento == "C")
                {
                    if (objE_DocumentoVenta.IdDocumentoVenta != null)
                    {
                        frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                        frm.IdDocumentoVenta = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                        frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                        frm.mnuContextual.Enabled = false;
                        frm.btnGrabar.Enabled = false;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("El documento actual no tiene asociado un comprobante de venta, por favor consultar con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void verdocumentoventatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                            frm.IdDocumentoVenta = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                            frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                            frm.mnuContextual.Enabled = false;
                            frm.btnGrabar.Enabled = false;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                            frm.IdDocumentoVenta = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                            frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                            frm.mnuContextual.Enabled = false;
                            frm.btnGrabar.Enabled = false;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void verpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            frmRegPedidoEdit frm = new frmRegPedidoEdit();
                            frm.IdPedido = Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                            frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            frmRegPedidoEdit frm = new frmRegPedidoEdit();
                            frm.IdPedido = Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                            frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //numero o cadena
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                        Cargar();
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void vistapreviatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        #region "Documentos Cargo"
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                            if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocFacturaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocBoletaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocFacturaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocBoletaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El documento no tiene asociado un comprobante. Por favor consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }
                    else
                    {
                        #region "Documentos Abono"
                        string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                        if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                        {
                            List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            #region "Codigo QR"
                            //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                            string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(ValorQR, out qrCode);

                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();

                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                            lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                            //imagen.Save("imagen.png", ImageFormat.Png);
                            #endregion

                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptDocumento = new RptVistaReportes();
                                objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                objRptDocumento.ShowDialog();
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        #region "Documentos Cargo"
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                            if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocFacturaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocBoletaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocFacturaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocBoletaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El documento no tiene asociado un comprobante. Por favor consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }
                    else
                    {
                        #region "Documentos Abono"
                        string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                        if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                        {
                            List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            #region "Codigo QR"
                            //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                            string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(ValorQR, out qrCode);

                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();

                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                            lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                            //imagen.Save("imagen.png", ImageFormat.Png);
                            #endregion

                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptDocumento = new RptVistaReportes();
                                objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                objRptDocumento.ShowDialog();
                            }
                        }
                        #endregion
                    }
                }

            }
        }



        private void verdocumentocompensadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        #region "Documentos Cargo"
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                            if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocFacturaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocBoletaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocFacturaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocBoletaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El documento no tiene asociado un comprobante. Por favor consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }
                    else
                    {
                        #region "Documentos Abono"
                        string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                        if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                        {
                            List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            #region "Codigo QR"
                            //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                            string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(ValorQR, out qrCode);

                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();

                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                            lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                            //imagen.Save("imagen.png", ImageFormat.Png);
                            #endregion

                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptDocumento = new RptVistaReportes();
                                objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                objRptDocumento.ShowDialog();
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        #region "Documentos Cargo"
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                            if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocFacturaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocBoletaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocFacturaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocBoletaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El documento no tiene asociado un comprobante. Por favor consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }
                    else
                    {
                        #region "Documentos Abono"
                        string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                        if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                        {
                            List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            #region "Codigo QR"
                            //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                            string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(ValorQR, out qrCode);

                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();

                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                            lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                            //imagen.Save("imagen.png", ImageFormat.Png);
                            #endregion

                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptDocumento = new RptVistaReportes();
                                objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                objRptDocumento.ShowDialog();
                            }
                        }
                        #endregion
                    }
                }

            }
        }

        private void tlbMenu_PrintClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (gvEstadoCuentaCliente.RowCount > 0)
                {
                    List<ReporteEstadoCuentaClienteCabBE> lstReporte = null;
                    lstReporte = new ReporteEstadoCuentaClienteCabBL().Listado(Parametros.intEmpresaId, IdCliente, "", Parametros.intSitPendienteCon);

                    if (lstReporte != null)
                    {
                        //Listar el datalle del reporte
                        List<ReporteEstadoCuentaClienteDetBE> lstReporteEstadoCuentaDetalle = null;
                        lstReporteEstadoCuentaDetalle = new ReporteEstadoCuentaClienteDetBL().Listado(Parametros.intEmpresaId, IdCliente, "", Parametros.intSitPendienteCon);
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptAccUsu = new RptVistaReportes();
                            objRptAccUsu.VerRptEstadoCuentaCliente(lstReporte, lstReporteEstadoCuentaDetalle);
                            objRptAccUsu.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadoCuentaCliente";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEstadoCuentaCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region "Metodos"
        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
            {
                mListaPago = new EstadoCuentaClientePagoBL().ListaPagado(Parametros.intEmpresaId, IdCliente);
                gcEstadoCuentaCliente.DataSource = mListaPago;

                gcGrupoPago.Visible = true;
                gcGrupoPago.GroupIndex = 1;
                gvEstadoCuentaCliente.OptionsView.ShowGroupPanel = false;
                gvEstadoCuentaCliente.ExpandAllGroups();

                gridColumn8.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                gridColumn8.DisplayFormat.FormatString = "";
            }
            else
            {
                mLista = new EstadoCuentaClienteBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente, "", Convert.ToInt32(cboSituacion.EditValue));
                gcEstadoCuentaCliente.DataSource = mLista;

                gcGrupoPago.Visible = false;
                gcGrupoPago.GroupIndex = -1;
                gvEstadoCuentaCliente.OptionsView.ShowGroupPanel = false;
                //gvEstadoCuentaCliente.ExpandAllGroups();

                gridColumn8.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColumn8.DisplayFormat.FormatString = "{0:#,0.00}";
            }
            Cursor = Cursors.Default;
        }

        private void CargarLineaCredito()
        {
            ClienteCreditoBE objE_ClienteCredito = null;
            objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
            if (objE_ClienteCredito != null)
            {
                txtLineaCredito.EditValue = objE_ClienteCredito.LineaCredito;
                txtLineaCreditoUtilizada.EditValue = objE_ClienteCredito.LineaCreditoUtilizada;
                txtLineaCreditoDisponible.EditValue = objE_ClienteCredito.LineaCreditoDisponible;
            }
            else
            {
                txtLineaCredito.EditValue = 0;
                txtLineaCreditoUtilizada.EditValue = 0;
                txtLineaCreditoDisponible.EditValue = 0;
            }
        }

        public void InicializarModificar()
        {
            //if (gvEstadoCuentaCliente.RowCount > 0)
            //{
            //    EstadoCuentaClienteBE objEstadoCuentaCliente = new EstadoCuentaClienteBE();

            //    objEstadoCuentaCliente.IdEstadoCuentaCliente = int.Parse(gvEstadoCuentaCliente.GetFocusedRowCellValue("IdEstadoCuentaCliente").ToString());

            //    frmRegEstadoCuentaClienteEdit objManEstadoCuentaClienteEdit = new frmRegEstadoCuentaClienteEdit();
            //    objManEstadoCuentaClienteEdit.IdCliente = IdCliente;
            //    objManEstadoCuentaClienteEdit.Numero = txtNumeroDocumento.Text;
            //    objManEstadoCuentaClienteEdit.DescCliente = txtDescCliente.Text;
            //    objManEstadoCuentaClienteEdit.TipoCliente = txtTipoCliente.Text;
            //    objManEstadoCuentaClienteEdit.pOperacion = frmRegEstadoCuentaClienteEdit.Operacion.Modificar;
            //    objManEstadoCuentaClienteEdit.IdEstadoCuentaCliente = objEstadoCuentaCliente.IdEstadoCuentaCliente;
            //    objManEstadoCuentaClienteEdit.StartPosition = FormStartPosition.CenterParent;
            //    objManEstadoCuentaClienteEdit.ShowDialog();

            //    Cargar();
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvEstadoCuentaCliente.GetFocusedRowCellValue("IdEstadoCuentaCliente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private DataTable CargarSituacion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "TODOS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 350;
            dr["Descripcion"] = "PENDIENTES";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 351;
            dr["Descripcion"] = "COMPENSADOS";
            dt.Rows.Add(dr);
            return dt;
        }

        #endregion


    }
}