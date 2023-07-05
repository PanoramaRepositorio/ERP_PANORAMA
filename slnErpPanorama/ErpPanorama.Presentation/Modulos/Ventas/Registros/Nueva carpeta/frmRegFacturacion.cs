using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Utils;
using System.Security.Principal;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.ws_integrens;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
//using GMT_Sfe_App;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegFacturacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        ws_integrensSoapClient WS = new ws_integrensSoapClient();
        FacturacionElectronica FacturaE = new FacturacionElectronica();
        FacturacionElectronicaOSE FacturaOSE = new FacturacionElectronicaOSE();
        FacturacionElectronicaSUNAT FacturaSUNAT = new FacturacionElectronicaSUNAT();
        FacturacionElectronicaSUNAT_THB FacturaSUNAT_THB = new FacturacionElectronicaSUNAT_THB();

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        #endregion

        #region "Eventos"

        public frmRegFacturacion()
        {
            InitializeComponent();
        }

        private void frmRegFacturacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", false);

            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            txtPeriodo.EditValue = DateTime.Now.Year;

            Cargar();

            if(Parametros.intPerfilId == Parametros.intPerAdministrador) //add 31-07-2019
            {
                enviarOSEtoolStripMenuItem.Enabled = true;
                generararchivobajatoolStripMenuItem.Enabled = true;
            }
            else
            {
                enviarOSEtoolStripMenuItem.Enabled = false;
                generararchivobajatoolStripMenuItem.Enabled = false;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegFacturacionEdit objManDocumentoVenta = new frmRegFacturacionEdit();
                objManDocumentoVenta.pOperacion = frmRegFacturacionEdit.Operacion.Nuevo;
                objManDocumentoVenta.IdDocumentoVenta = 0;
                objManDocumentoVenta.StartPosition = FormStartPosition.CenterParent;
                if (objManDocumentoVenta.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int TipoDoc = int.Parse(gvDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());

                if(TipoDoc == Parametros.intTipoDocNotaCreditoElectronica)
                {
                    XtraMessageBox.Show("No se puede anular una nota de crédito electrónica",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(TipoDoc == Parametros.intTipoDocBoletaElectronica || TipoDoc == Parametros.intTipoDocFacturaElectronica /*|| TipoDoc == Parametros.intTipoDocNotaCreditoElectronica*/)
                {
                    #region "Baja de comprobante Electrónico"
                    if (XtraMessageBox.Show("Está seguro de dar de BAJA el Comprobante electrónico?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarElimina())
                        {
                            DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));


                            if (objE_DocumentoVenta.Fecha <= Convert.ToDateTime(DateTime.Now.AddDays(-7).ToShortDateString()))
                            {
                                XtraMessageBox.Show("No se puede Eliminar, El máximo permitido para dar de baja un comprobante es de 7 días.\nConsulte con Contabilidad.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            //GRABAR OSE AQUI O ENVIAR A


                            ////GrabarAnulaVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
                            //if (TipoDoc == Parametros.intTipoDocNotaCreditoElectronica)
                            //    FacturaE.AnulaNotaCreditoIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
                            //else
                            //    FacturaE.AnulaVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);

                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                            //XtraMessageBox.Show("El Comprobante se dió de baja correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();

                            if(objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito|| objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                //NC
                            }else
                            //if (objE_DocumentoVenta.IdTipoDocumento != Parametros.intTipoDocNotaCredito)
                            {
                                //Anula Con Pedido
                                int? IdPedido = objE_DocumentoVenta.IdPedido;
                                if (IdPedido != null)
                                {
                                    if (XtraMessageBox.Show("El documento está asociado a un pedido, Desea Anular el Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        PedidoBE objE_Pedido = null;
                                        PedidoBL objBL_Pedido = new PedidoBL();
                                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(IdPedido));

                                        if (objE_Pedido != null)
                                        {
                                            objE_Pedido.IdPedido = objE_Pedido.IdPedido;
                                            objE_Pedido.IdTienda = objE_Pedido.IdTienda;
                                            objE_Pedido.IdFormaPago = objE_Pedido.IdFormaPago;
                                            objE_Pedido.Numero = objE_Pedido.Numero;
                                            objE_Pedido.FlagPreVenta = objE_Pedido.FlagPreVenta;
                                            objE_Pedido.Usuario = Parametros.strUsuarioLogin;
                                            objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                            objE_Pedido.IdEmpresa = objE_Pedido.IdEmpresa;
                                            objBL_Pedido.Elimina(objE_Pedido);
                                            XtraMessageBox.Show("El Pedido se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Cargar();
                                        }
                                    }

                                    //Insertamos en la auditoria - Estado de cuenta
                                    #region "Eliminar Abono Club Design"

                                    //EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                    //List<EstadoCuentaBE> lstEstadoCuenta = new List<EstadoCuentaBE>();

                                    List<SeparacionBE> lstSeparacion = new List<SeparacionBE>();
                                    //SeparacionBE objE_EstadoCuenta = new SeparacionBE();
                                    SeparacionBL objBL_Separacion = new SeparacionBL();

                                    lstSeparacion = new SeparacionBL().ListaPedido(Parametros.intEmpresaId, Convert.ToInt32(objE_DocumentoVenta.IdPedido), "A");
                                    if (lstSeparacion.Count > 0)
                                    {
                                        foreach (SeparacionBE objE_EstadoCuenta in lstSeparacion)
                                        {
                                            if (objE_EstadoCuenta.NumeroDocumento == "COMCD")
                                            {
                                                //objE_EstadoCuenta = lstSeparacion[0];

                                                EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                                                objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                                                objE_EstadoCuentaHistorial.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                                objE_EstadoCuentaHistorial.Periodo = objE_EstadoCuenta.Periodo;
                                                objE_EstadoCuentaHistorial.IdCliente = objE_EstadoCuenta.IdCliente;
                                                objE_EstadoCuentaHistorial.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                                objE_EstadoCuentaHistorial.FechaCredito = objE_EstadoCuenta.FechaSeparacion;
                                                objE_EstadoCuentaHistorial.FechaDeposito = objE_EstadoCuenta.FechaPago;
                                                objE_EstadoCuentaHistorial.Concepto = objE_EstadoCuenta.Concepto;
                                                objE_EstadoCuentaHistorial.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                                objE_EstadoCuentaHistorial.Importe = objE_EstadoCuenta.Importe;
                                                objE_EstadoCuentaHistorial.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                                                objE_EstadoCuentaHistorial.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                                objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                                objE_EstadoCuentaHistorial.IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                                                objE_EstadoCuentaHistorial.IdPedido = objE_EstadoCuenta.IdPedido;
                                                objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                                objE_EstadoCuentaHistorial.Observacion = objE_EstadoCuenta.Observacion;
                                                objE_EstadoCuentaHistorial.ObservacionElimina = "FACT:" + Parametros.strUsuarioLogin + " " + WindowsIdentity.GetCurrent().Name.ToString() + "";
                                                objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. SOLES";
                                                objE_EstadoCuentaHistorial.TipoRegistro = "E";
                                                objE_EstadoCuentaHistorial.FlagEstado = objE_EstadoCuenta.FlagEstado;
                                                objE_EstadoCuentaHistorial.Usuario = Parametros.strUsuarioLogin;
                                                objE_EstadoCuentaHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                                EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                                                objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaHistorial);

                                                objBL_Separacion.Elimina(objE_EstadoCuenta);
                                                XtraMessageBox.Show("Abono Club Design eliminado del estado de cuenta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }

                                        }
                                    }
                                    #endregion

                                }
                            }
                            XtraMessageBox.Show("El Comprobante se dió de baja correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    #endregion
                }
                else
                {
                    #region "Anulación de comprobante Físico"
                    if (XtraMessageBox.Show("Está seguro de anular el Documento?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarElimina())
                        {
                            DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));

                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                            //XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();


                            if (objE_DocumentoVenta.IdTipoDocumento != Parametros.intTipoDocNotaCredito)
                            {
                                //Anula Con Pedido
                                int? IdPedido = objE_DocumentoVenta.IdPedido;
                                if (IdPedido != null)
                                {
                                    if (XtraMessageBox.Show("El documento está asociado a un pedido, Desea Anular el Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        PedidoBE objE_Pedido = null;
                                        PedidoBL objBL_Pedido = new PedidoBL();
                                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(IdPedido));

                                        if (objE_Pedido != null)
                                        {
                                            objE_Pedido.IdPedido = objE_Pedido.IdPedido;
                                            objE_Pedido.IdTienda = objE_Pedido.IdTienda;
                                            objE_Pedido.IdFormaPago = objE_Pedido.IdFormaPago;
                                            objE_Pedido.Numero = objE_Pedido.Numero;
                                            objE_Pedido.FlagPreVenta = objE_Pedido.FlagPreVenta;
                                            objE_Pedido.Usuario = Parametros.strUsuarioLogin;
                                            objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                            objE_Pedido.IdEmpresa = objE_Pedido.IdEmpresa;
                                            objBL_Pedido.Elimina(objE_Pedido);
                                            XtraMessageBox.Show("El Pedido se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Cargar();
                                        }
                                    }

                                    //Insertamos en la auditoria - Estado de cuenta
                                    #region "Eliminar Abono Club Design"

                                    //EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                    //List<EstadoCuentaBE> lstEstadoCuenta = new List<EstadoCuentaBE>();

                                    List<SeparacionBE> lstSeparacion = new List<SeparacionBE>();
                                    //SeparacionBE objE_EstadoCuenta = new SeparacionBE();
                                    SeparacionBL objBL_Separacion = new SeparacionBL();

                                    lstSeparacion = new SeparacionBL().ListaPedido(Parametros.intEmpresaId, Convert.ToInt32(objE_DocumentoVenta.IdPedido), "A");
                                    if (lstSeparacion.Count > 0)
                                    {
                                        foreach(SeparacionBE objE_EstadoCuenta in lstSeparacion)
                                        {
                                            if(objE_EstadoCuenta.NumeroDocumento == "COMCD")
                                            {
                                                //objE_EstadoCuenta = lstSeparacion[0];

                                                EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                                                objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                                                objE_EstadoCuentaHistorial.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                                objE_EstadoCuentaHistorial.Periodo = objE_EstadoCuenta.Periodo;
                                                objE_EstadoCuentaHistorial.IdCliente = objE_EstadoCuenta.IdCliente;
                                                objE_EstadoCuentaHistorial.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                                objE_EstadoCuentaHistorial.FechaCredito = objE_EstadoCuenta.FechaSeparacion;
                                                objE_EstadoCuentaHistorial.FechaDeposito = objE_EstadoCuenta.FechaPago;
                                                objE_EstadoCuentaHistorial.Concepto = objE_EstadoCuenta.Concepto;
                                                objE_EstadoCuentaHistorial.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                                objE_EstadoCuentaHistorial.Importe = objE_EstadoCuenta.Importe;
                                                objE_EstadoCuentaHistorial.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                                                objE_EstadoCuentaHistorial.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                                objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                                objE_EstadoCuentaHistorial.IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                                                objE_EstadoCuentaHistorial.IdPedido = objE_EstadoCuenta.IdPedido;
                                                objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                                objE_EstadoCuentaHistorial.Observacion = objE_EstadoCuenta.Observacion;
                                                objE_EstadoCuentaHistorial.ObservacionElimina = "FACT:" + Parametros.strUsuarioLogin + " " + WindowsIdentity.GetCurrent().Name.ToString() + "";
                                                objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. SOLES";
                                                objE_EstadoCuentaHistorial.TipoRegistro = "E";
                                                objE_EstadoCuentaHistorial.FlagEstado = objE_EstadoCuenta.FlagEstado;
                                                objE_EstadoCuentaHistorial.Usuario = Parametros.strUsuarioLogin;
                                                objE_EstadoCuentaHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                                EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                                                objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaHistorial);

                                                objBL_Separacion.Elimina(objE_EstadoCuenta);
                                                XtraMessageBox.Show("Abono Club Design eliminado del estado de cuenta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }

                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                    #endregion
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
            
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaDocumento();
            }
        }

        private void tlbMenu_PrintClick()
        {
            
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDocumentoVentas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDocumento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void imprimirguiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    string dirFacturacion = "<No Especificado>";

                    if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali2;
                    }
                    else if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali3;
                    }
                    else
                    {
                        dirFacturacion = Parametros.strDireccionUcayali;
                    }
                    if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaAndahuaylas)
                    {
                        dirFacturacion = Parametros.strDireccionAndahuaylas;
                    }
                    if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaKonceptos)
                    {
                        dirFacturacion = Parametros.strDireccionMegaplaza;
                    }

                    if (objE_DocumentoVenta.IdEmpresa == Parametros.intIdPanoramaDistribuidores)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali;
                    }

                    #region "Guia Remisión - Boleta"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        #region "Guia Remision Continuo con Pedido"
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
                            rptGuiaRemisionBoletaPanorama objReporteGuia = new rptGuiaRemisionBoletaPanorama();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                                MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
                        }
                        #endregion
                        else
                        {
                        #region "Guia Remision Continuo Documento"
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptGuiaRemisionBoletaPanorama objReporteGuia = new rptGuiaRemisionBoletaPanorama();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                                MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
                            //}
                            #endregion
                        }
                    }
                    #endregion

                    #region "Guia Remisión - Factura y Otros"
                    else
                    {
                        #region "Guia Remision Continuo con Pedido"
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
                            rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                                MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
                        }
                        #endregion
                        else
                        {
                        #region "Guia Remision Continuo Documento"
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                                MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                            }
                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
                            //}
                            #endregion
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

        private void vistapreliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                    {
                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptDocumento = new RptVistaReportes();
                            objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));
                            objRptDocumento.ShowDialog();
                        }
                    }
                    else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Convert.ToInt32(objE_DocumentoVenta.IdTipoDocumento));
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptDocumento = new RptVistaReportes();
                            objRptDocumento.VerRptDocumentoVenta(lstReporte, objE_DocumentoVenta.IdTipoDocumento);
                            objRptDocumento.ShowDialog();
                        }
                    }
                    else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(objE_DocumentoVenta.IdDocumentoVenta);

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
                            objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, objE_DocumentoVenta.IdTipoDocumento);
                            objRptDocumento.ShowDialog();
                        }
                    }
                    else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
                    {
                        List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaElectronicaBL().ListadoGuia(objE_DocumentoVenta.IdDocumentoVenta);

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
                            objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, objE_DocumentoVenta.IdTipoDocumento);
                            objRptDocumento.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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

                    #region "Boleta continua"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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

                    #region "Factura Panorama Continua"
                    else
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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

                    #region "Factura Corona Continua"
                        else
                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Factura Corona Continua
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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

                    #region "Guia Remisión"
                        else
                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaRemision)//GUIA DE REMISION
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
    

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

                    #region "Nota Crédito"
                            /*else
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                }*/

                    #endregion

                    #region "Nota Credito Panorama"
                    else
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Corona"
                    else
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Otros"
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                    {
                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Ticket Físico"
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocTicketBoleta || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocTicketFactura)
                    {
                        if (objE_DocumentoVenta.Serie == "007")
                            ReimpresionTicketFisico();
                        else
                            XtraMessageBox.Show("Sólo se puede reimprimir la serie 007", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    #endregion

                    #region "Ticket Electrónico"
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                    {
                        frmMsgPrintDocFE frm = new frmMsgPrintDocFE();
                        if(frm.ShowDialog() == DialogResult.OK)
                        {
                            ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora , frm.sFormato);
                        }
                        //ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sFormato);

                        //ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, "TKE");
                    }
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        frmMsgPrintDocFE frm = new frmMsgPrintDocFE();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            //ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora, frm.sFormato);
                            ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora, "NC");
                        }
                    }
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
                    {
                        frmMsgPrintDocFE frm = new frmMsgPrintDocFE();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            //ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora, frm.sFormato);
                            ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora, "GRE");
                        }
                    }


                    #endregion

                    #region "Otros"
                    else
                    {
                       
                        XtraMessageBox.Show("No disponible para este documento, opción accesible para Boleta,Factura y Nota de Crédito", "Impresión Documento Continuo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirdocumentodesglosabletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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
                    #region "Boleta Panorama desglosable"
                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)&& (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Boleta Panorama desglosable
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Boleta Corona desglosable
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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
                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Boleta Eleazar desglosable
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Boleta Amalia desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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

                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Boleta Olga desglosable
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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

                    #region "Boleta Roxana desglosable"
                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaHuamanRoxana))//Boleta Roxana desglosable
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

                        rptBoletaRoxanaDesglosable objReporteGuia = new rptBoletaRoxanaDesglosable();
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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intDecoratex))//Boleta Decoratext desglosable
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);

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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Desglosable
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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

                    #region "Factura Corona Desglosable"
                        else
                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Factura Corona Desglosable
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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
                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Factura Eleazar Desglosable
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Factura Amalia Desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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
                                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Factura Olga Desglosable
                                    {
                                        List<ReporteDocumentoVentaBE> lstReporte = null;
                                        lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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

                    #region "Factura Decoratex"
                    else
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intDecoratex))//Factura Decoratex Desglosable
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);

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

                    #region "Guia de Remision"
                                                    /*else
                                                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaRemision)//GUIA DE REMISION
                                                        {
                                                            List<ReporteDocumentoVentaBE> lstReporte = null;
                                                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

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
                                                        }*/
                                                    #endregion

                    #region "Nota Credito Panorama"
                    else
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                       if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                       if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Decoratext"
                    else
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intDecoratex))//NOTACREDITO PANORAMA
                        {
                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Otros"
                    else
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO PANORAMA
                    {
                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Otros"
                    else
                    {
                       XtraMessageBox.Show("Impresión no disponible para este documento, Consulte con su administrador", "Impresión Documento Desglosable", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    #endregion

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void undocumentocontinuotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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

                    #region "Boleta continua"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Factura Panorama Continua"
                    else
                      if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Factura Corona Continua"
                        else
                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Factura Corona Continua
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Crédito Todo"
                        /*else
                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                            }*/

                        #endregion

                            #region "Nota Credito Panorama"
                            else
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                                #region "Nota Credito Corona"
                                else
                                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//NOTACREDITO PANORAMA
                                    {
                                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//NOTACREDITO PANORAMA
                                        {
                                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//NOTACREDITO PANORAMA
                                            {
                                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//NOTACREDITO PANORAMA
                                                {
                                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Olga"
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//NOTACREDITO PANORAMA
                    {
                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Otros"
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO PANORAMA
                    {
                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Otros"
                    else
                    {
                        XtraMessageBox.Show("No disponible para este documento, opción accesible para Boleta,Factura y Nota de Crédito", "Impresión Documento Continuo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void undocumentodesglosabletoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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
                    #region "Boleta Panorama desglosable"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Boleta Panorama desglosable
                    //if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)//Boleta Panorama desglosable
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Boleta Corona desglosable
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Boleta Eleazar desglosable
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Boleta Amalia desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                            #region "Boleta Roxana desglosable"
                            else
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaHuamanRoxana))//Boleta Amalia desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                    rptBoletaRoxanaDesglosable objReporteGuia = new rptBoletaRoxanaDesglosable();
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

                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Boleta Olga desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intDecoratex))//Boleta Decoratex desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Factura Eleazar Desglosable
                                    {
                                        List<ReporteDocumentoVentaBE> lstReporte = null;
                                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Factura Amalia Desglosable
                                        {
                                            List<ReporteDocumentoVentaBE> lstReporte = null;
                                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Factura Olga Desglosable
                                {
                                    List<ReporteDocumentoVentaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                            #region "Factura Decoratex Desglosable"
                                else
                                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intDecoratex))//Factura Decoratex Desglosable
                                    {
                                        List<ReporteDocumentoVentaBE> lstReporte = null;
                                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                            #region "Nota Crédito Panorama Desgosable"
                            else
                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//NOTACREDITO PANORAMA
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//NOTACREDITO PANORAMA
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//NOTACREDITO PANORAMA
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//NOTACREDITO PANORAMA
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                            #region "Nota Decoratex Eleazar"
                            else
                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intDecoratex))//NCVDecoratex PANORAMA
                                {
                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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

                    #region "Nota Credito Comentario"
                    //else
                    //    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                    //    {
                    //        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                    //        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));

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

                    #region "Nota Crédito Otros Desgosable"
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
                    {
                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

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
                            MessageBox.Show("La impresora (F) Nombre para NOTA DE CREDITO no ha sido encontrada.");

                        }
                        objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
                    }

                    #endregion


                    #region "Otros Doc"
                    else
                    {
                        XtraMessageBox.Show("Impresión no disponible para este documento, Consulte con su administrador", "Impresión Documento Desglosable", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    #endregion
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void unaguiatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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


                    #region "Guia Remisión - Boleta"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                         #region "Guia Remision desglosable Documento"
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptGuiaRemisionBoletaPanorama objReporteGuia = new rptGuiaRemisionBoletaPanorama();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                            //}
                            #endregion
                    }
                    #endregion

                    #region "Guia Remisión - Factura y Otros"
                    else
                    {
                        #region "Guia Remision desglosable Documento"
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                            //}
                            #endregion

                    }
                    #endregion

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void renumerartoolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmEstablecerNumero objDescuento = new frmEstablecerNumero();
            objDescuento.Serie = gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Serie").ToString();
            objDescuento.StartPosition = FormStartPosition.CenterParent;

            if (objDescuento.ShowDialog() == DialogResult.OK)
            {
                int Num = 0;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int IdEmpresa = 0;
                    int IdDocumentoVenta = 0;
                    int IdTipoDocumento = 0;

                    string Serie = "";
                    string Numero = "";
                    
                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetRowCellValue(row, "IdTipoDocumento").ToString());
                    //Serie = gvDocumento.GetRowCellValue(row, "Serie").ToString();

                    if(IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        XtraMessageBox.Show("No se puede renumerar un Ticket y/o documento Electrónico.\nConsultar con su Administrador.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //Validar Periodo
                    DateTime Fecha;
                    Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    //Documento
                    Serie = objDescuento.Serie;
                    if (i==0)
                    {
                        Num = objDescuento.Numero;
                    }
                    
                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    DocumentoVentaBE objE_Documento = new DocumentoVentaBE();

                    objE_Documento.IdEmpresa = IdEmpresa;
                    objE_Documento.IdDocumentoVenta = IdDocumentoVenta;
                    objE_Documento.Serie = Serie;
                    Numero = FuncionBase.AgregarCaracter(Num.ToString(), "0", 6);
                    objE_Documento.Numero = Numero;
                    objBL_Documento.ActualizaNumeroSerie(objE_Documento);

                    Num++;
                }
            }

            if(txtNumeroPedido.Text.Length > 2)
                CargarBusqueda();
            else
                Cargar();

        }

        private void cambiarrazonsocialtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    //Validar Periodo
                    DateTime Fecha;
                    Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Fecha").ToString());
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    //Documento
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        if(objE_DocumentoVenta.IdSituacionPSE>0)
                        {
                            XtraMessageBox.Show("No se puede realizar el cambio de la razón social, el documento se envió a la SUNAT.\nConsultar con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }else
                        {
                            frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
                            objDescuento.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                            objDescuento.StartPosition = FormStartPosition.CenterParent;
                            if (objDescuento.ShowDialog() == DialogResult.OK)
                            {
                                CargarBusqueda();
                            }
                        } 
                    }
                    else
                    {
                        frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
                        objDescuento.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                        objDescuento.StartPosition = FormStartPosition.CenterParent;
                        if (objDescuento.ShowDialog() == DialogResult.OK)
                        {
                            CargarBusqueda();
                        }
                    }


                    
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cambiarfechatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstablecerFecha objDescuento = new frmEstablecerFecha();
            objDescuento.StartPosition = FormStartPosition.CenterParent;
            if (objDescuento.ShowDialog() == DialogResult.OK)
            {
                int Num = 0;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int IdEmpresa = 0;
                    int IdDocumentoVenta = 0;
                    int IdTipoDocumento = 0;
                    DateTime Fecha;

                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetRowCellValue(row, "IdTipoDocumento").ToString());
                    Fecha = objDescuento.Fecha;

                    if (IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        XtraMessageBox.Show("No se cambiar la fecha de un Ticket, Bloqueado por la SUNAT.\nConsulte con el área de Contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //Validar Periodo
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede cambiar, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    //doc
                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
             
                    objBL_Documento.ActualizaFecha(IdEmpresa, IdDocumentoVenta, Fecha);

                    Num++;
                }
            }

            CargarBusqueda();
        }

        private void eliminafisicotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("No se puede eliminar, el proceso ha sido bloquedo por Contabilidad, consulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*try
            {
                if (XtraMessageBox.Show("Esta seguro de Eliminar el Documento de venta? \n. Porque tiene documento asociados.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    prgFactura.Visible = true;
                    for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                    {
                        int IdDocumentoVenta = 0;
                        int IdEmpresaElimina = 13;

                        int row = gvDocumento.GetSelectedRows()[i];
                        int TotRow = gvDocumento.SelectedRowsCount;
                        TotRow = TotRow - row + 1;
                        prgFactura.Properties.Step = 1;
                        prgFactura.Properties.Maximum = TotRow;
                        prgFactura.Properties.Minimum = 0;

                        IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                        IdEmpresaElimina = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());

                        //Validar Periodo
                        DateTime Fecha;
                        Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());
                        PeriodoBE objBE_Periodo = new PeriodoBE();
                        objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                        if (objBE_Periodo != null) 
                        {
                            if (objBE_Periodo.FlagEstado == false)
                            {
                                XtraMessageBox.Show("No se puede eliminar, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
             
                        if (IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        {
                            XtraMessageBox.Show("No se Eliminar un Ticket, Bloqueado por la SUNAT.\nConsulte con el área de Contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //Eliminar DocumentoVenta
                        DocumentoVentaBE objBE_DocumentoVenta = new DocumentoVentaBE();
                        objBE_DocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                        objBE_DocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                        objBE_DocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objBE_DocumentoVenta.IdEmpresa = IdEmpresaElimina;

                        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                        objBL_DocumentoVenta.EliminaFisico(objBE_DocumentoVenta);

                        prgFactura.PerformStep();
                        prgFactura.Update();

                    }
                    //gvDocumento.DeleteRow(gvDocumento.FocusedRowHandle);
                    //gvDocumento.RefreshData();
                    XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prgFactura.Visible = false;
                    Cargar();

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/



            /*try
            {
                if (XtraMessageBox.Show("Esta seguro de Eliminar el Documento de venta? \n. Porque tiene documento asociados.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objBL_DocumentoVenta.EliminaFisico(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));
                    gvDocumento.DeleteRow(gvDocumento.FocusedRowHandle);
                    gvDocumento.RefreshData();                
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnNuevoManual_Click(object sender, EventArgs e)
        {
            frmRegFacturacionManual frmRegManual = new frmRegFacturacionManual();
            frmRegManual.Show();
        }

        private void asociarapedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
                    frmBusPedido objDescuento = new frmBusPedido();
                    //objDescuento.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                    objDescuento.StartPosition = FormStartPosition.CenterParent;
                    if (objDescuento.ShowDialog() == DialogResult.OK)
                    {
                        if (objDescuento.pPedidoBE != null)
                        {
                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            objBL_DocumentoVenta.ActualizaVinculoPedido(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta), objDescuento.pPedidoBE.IdPedido);
                            XtraMessageBox.Show("Documento vinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("El Número de pedido no existe y/o anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //XtraMessageBox.Show("Documento Vinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Cargar();
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desasociartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    objBL_Documento.ActualizaVinculoPedido(objE_DocumentoVenta.IdDocumentoVenta, 0);
                    XtraMessageBox.Show("Documento Desvinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copiartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (XtraMessageBox.Show("Esta seguro de generar una copia del Documento de venta? \n. Porque puede alterar el total de ventas.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Validar Periodo
                        DateTime Fecha;
                        Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Fecha").ToString());
                        PeriodoBE objBE_Periodo = new PeriodoBE();
                        objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                        if (objBE_Periodo != null)
                        {
                            if (objBE_Periodo.FlagEstado == false)
                            {
                                XtraMessageBox.Show("No se puede Copiar, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        //Documento
                        DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
                        DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                        objBL_Documento.Copia(objE_DocumentoVenta.IdDocumentoVenta);
                        XtraMessageBox.Show("Copia Satisfactoria", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }

                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirguiaDesglosabletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    string dirFacturacion = "<No Especificado>";

                    if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali2;
                    }
                    else if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali3;
                    }
                    else
                    {
                        dirFacturacion = Parametros.strDireccionUcayali;
                    }
                    if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaAndahuaylas)
                    {
                        dirFacturacion = Parametros.strDireccionAndahuaylas;
                    }
                    if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaKonceptos)
                    {
                        dirFacturacion = Parametros.strDireccionMegaplaza;
                    }

                    if (objE_DocumentoVenta.IdEmpresa == Parametros.intIdPanoramaDistribuidores)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali;
                    }

                    #region "Guia Remisión - Boleta"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        #region "Guia Remision desglosable con Pedido"
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
                            rptGuiaRemisionBoletaPanoramaDesglosable objReporteGuia = new rptGuiaRemisionBoletaPanoramaDesglosable();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                        else
                        {
                            #region "Guia Remision desglosable Documento"
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptGuiaRemisionBoletaPanoramaDesglosable objReporteGuia = new rptGuiaRemisionBoletaPanoramaDesglosable();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                            //}
                            #endregion
                        }
                    }
                    #endregion

                    #region "Guia Remisión - Factura y Otros"
                    else
                    {
                        #region "Guia Remision desglosable con Pedido"
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
                            rptGuiaRemisionPanoramaDesglosable objReporteGuia = new rptGuiaRemisionPanoramaDesglosable();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                        else
                        {
                            #region "Guia Remision desglosable Documento"
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptGuiaRemisionPanoramaDesglosable objReporteGuia = new rptGuiaRemisionPanoramaDesglosable();

                            #region "Direccion"
                            frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                            frm.IdPedido = 0; //int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                            frm.ShowDialog();
                            String DirguiaRem = "";

                            if (frm.DireccionGuiaPrint == "")
                            {
                                DirguiaRem = objE_DocumentoVenta.Direccion;
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
                            //}
                            #endregion
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

        private void unaguiaDesglosabletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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


                    #region "Guia Remisión - Boleta"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        #region "Guia Remision desglosable Documento"
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                        rptGuiaRemisionBoletaPanoramaDesglosable objReporteGuia = new rptGuiaRemisionBoletaPanoramaDesglosable();

                        #region "Direccion"
                        frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                        frm.ShowDialog();
                        String DirguiaRem = "";

                        if (frm.DireccionGuiaPrint == "")
                        {
                            DirguiaRem = objE_DocumentoVenta.Direccion;
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
                        //}
                        #endregion
                    }
                    #endregion

                    #region "Guia Remisión - Factura y Otros"
                    else
                    {
                        #region "Guia Remision desglosable Documento"
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                        rptGuiaRemisionPanoramaDesglosable objReporteGuia = new rptGuiaRemisionPanoramaDesglosable();

                        #region "Direccion"
                        frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                        frm.ShowDialog();
                        String DirguiaRem = "";

                        if (frm.DireccionGuiaPrint == "")
                        {
                            DirguiaRem = objE_DocumentoVenta.Direccion;
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
                        //}
                        #endregion

                    }
                    #endregion

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
            objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());

            objDocumentoVenta.IdPedido = Convert.ToInt32(gvDocumento.GetFocusedRowCellValue("IdPedido"));

            frmRegGenerarGuiaRemision ObjGenerarGuiaRmision = new frmRegGenerarGuiaRemision();
            ObjGenerarGuiaRmision.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
            ObjGenerarGuiaRmision.IdPedido = objDocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objDocumentoVenta.IdPedido);
            ObjGenerarGuiaRmision.ShowDialog();
        }

        private void gvDocumento_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumento.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdSituacion"]);
                    if (objDocRetiro != null)
                    {
                        int IdSituacion = int.Parse(objDocRetiro.ToString());
                        if (IdSituacion == Parametros.intDVAnulado)
                        {
                            e.Appearance.ForeColor = Color.DarkGray;
                            //e.Appearance.ForeColor = Color.Gray;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReimpresionTicketFisico()
        {
            try
            {
                int IdEmpresa = 0;
                int IdTipoDocumento = 0;
                string TipoDoc = "";
                string NumeroDocumento = "";
                string Serie = "";
                string Numero = "";

                if (mLista.Count > 0)
                {
                    IdEmpresa = int.Parse(gvDocumento.GetFocusedRowCellValue("IdEmpresa").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                    TipoDoc = gvDocumento.GetFocusedRowCellValue("CodTipoDocumento").ToString();
                    NumeroDocumento = gvDocumento.GetFocusedRowCellValue("NumeroDocumento").ToString();
                    Serie = gvDocumento.GetFocusedRowCellValue("Serie").ToString();
                    Numero = gvDocumento.GetFocusedRowCellValue("Numero").ToString();
                    //Serie =  NumeroDocumento.Substring(0, 3);
                    //Numero = NumeroDocumento.Substring(4, 6);
                }

                if (TipoDoc == "TKV")
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "nillanes" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador)
                        {
                            #region "Ticket TKV"
                            DocumentoVentaBE objDocumento = null;
                            objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

                            TalonBE objTalon = null;
                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);


                            if (objDocumento != null)
                            {
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
                                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                                ticket.TextoIzquierda(TipoDoc + Serie + "-" + Numero + "  " + objDocumento.Fecha.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
                                ticket.TextoIzquierda("CLIENTE:" + objDocumento.DescCliente);
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                List<DocumentoVentaDetalleBE> lstReporte = null;
                                lstReporte = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

                                foreach (var item in lstReporte)
                                {
                                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                    //ticket.AgregaArticuloDetalle(item.NombreProducto.PadRight(, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                }
                                ticket.LineasTotales();
                                if (objDocumento.TotalBruto > objDocumento.Total) //add 20 may 15
                                {
                                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.TotalBruto), 2));
                                    ticket.AgregaTotales("Descuento", Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2));
                                }
                                ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(objDocumento.Total), 2)); // imprime linea con total
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("Ven:" + objDocumento.DescVendedor);
                                ticket.TextoIzquierda("Ped:" + objDocumento.NumeroPedido);
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro(objTalon.PaginaWeb);
                                if (objDocumento.IdPromocionProxima > 0)
                                {
                                    ticket.CortaTicket();
                                    ticket.TextoCentro("=========================================");
                                    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                    ojbPromocion = new PromocionProximaBL().Selecciona(objDocumento.IdPromocionProxima);
                                    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                    ticket.TextoCentro("=========================================");
                                }

                                ticket.CortaTicket();

                            }

                            #endregion
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Ticket.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    if (TipoDoc == "TKF")
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "nillanes" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador)
                        {
                            #region "Ticket TKF"


                            DocumentoVentaBE objDocumento = null;
                            objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

                            TalonBE objTalon = null;
                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);

                            if (objDocumento != null)
                            {

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
                                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                                //ticket.TextoIzquierda(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda(TipoDoc + Serie + "-" + Numero + "  " + objDocumento.Fecha.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
                                ticket.TextoIzquierdaNLineas("CLIENTE: " + objDocumento.DescCliente);
                                ticket.TextoIzquierda("RUC: " + objDocumento.NumeroDocumento);
                                ticket.TextoIzquierdaNLineas("DIR: " + objDocumento.Direccion);
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                List<DocumentoVentaDetalleBE> lstReporte = null;
                                lstReporte = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

                                foreach (var item in lstReporte)
                                {
                                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                    //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                }
                                ticket.LineasTotales();
                                if (objDocumento.TotalBruto > objDocumento.Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", objDocumento.CodMoneda + " " + objDocumento.TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", objDocumento.CodMoneda + " " + (Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2)));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento", Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", objDocumento.CodMoneda +" "+ objDocumento.SubTotal.ToString());
                                ticket.TextoExtremos("IGV", objDocumento.CodMoneda + " " + objDocumento.Igv.ToString());
                                ticket.TextoExtremos("Total", objDocumento.CodMoneda + " " + objDocumento.Total.ToString());
                                //ticket.AgregaTotales("SubTotal", Math.Round(Convert.ToDouble(objDocumento.SubTotal), 2));
                                //ticket.AgregaTotales("IGV", Math.Round(Convert.ToDouble(objDocumento.Igv), 2));
                                //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.Total), 2));
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(objDocumento.Total), 2).ToString()) + " " + objDocumento.DescMoneda);
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("Ven:" + objDocumento.DescVendedor);
                                ticket.TextoIzquierda("Ped:" + objDocumento.NumeroPedido);
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                //ticket.TextoCentro("www.panoramadistribuidores.com");
                                ticket.TextoCentro(objTalon.PaginaWeb);
                                if (objDocumento.IdPromocionProxima > 0)
                                {
                                    ticket.CortaTicket();
                                    ticket.TextoCentro("=========================================");
                                    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                    ojbPromocion = new PromocionProximaBL().Selecciona(objDocumento.IdPromocionProxima);
                                    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                    ticket.TextoCentro("=========================================");
                                }
                                ticket.CortaTicket();


                            }
                            #endregion
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Ticket.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void descargarxmltoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("Temporalmente los XML no se pueden descargar, sin embargo UD. puede solicitar una copia a Sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);


            #region "PSE"

            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {

                Cursor = Cursors.AppStarting;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int IdEmpresa = 0;
                    int IdDocumentoVenta = 0;
                    int IdTipoDocumento = 0;

                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetRowCellValue(row, "IdTipoDocumento").ToString());
                    string sIdConTipoComprobantePago = gvDocumento.GetRowCellValue(row, "IdConTipoComprobantePago").ToString();
                    string CodTipoDocumento = gvDocumento.GetRowCellValue(row, "CodTipoDocumento").ToString();
                    int IdSituacion = int.Parse(gvDocumento.GetRowCellValue(row, "IdSituacion").ToString());

                    if (IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        ////Validar Periodo
                        //DateTime Fecha;
                        //Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());
                        //PeriodoBE objBE_Periodo = new PeriodoBE();
                        //objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                        //if (objBE_Periodo != null)
                        //{
                        //    if (objBE_Periodo.FlagEstado == false)
                        //    {
                        //        XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return;
                        //    }
                        //}

                        //string Directorio = f.SelectedPath  + @"\" + sIdConTipoComprobantePago+"-" + CodTipoDocumento;
                        //Directory.CreateDirectory(Directorio);

                        DocumentoVentaBE mDocumentoVentaE = null;
                        mDocumentoVentaE = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
                        if (mDocumentoVentaE != null)
                        {
                            string sNombreArchivo = mDocumentoVentaE.Ruc + "_" + mDocumentoVentaE.IdConTipoComprobantePago + "_" + mDocumentoVentaE.Serie + "_" + mDocumentoVentaE.Numero;

                            string Directorio = f.SelectedPath + @"\" + sIdConTipoComprobantePago + "-" + CodTipoDocumento + @"\" + sNombreArchivo;
                            Directory.CreateDirectory(Directorio);

                            //XML
                            byte[] data = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "XML", "");
                            //File.WriteAllBytes(f.SelectedPath + @"\" + sNombreArchivo + ".xml", data);
                            File.WriteAllBytes(Directorio + @"\" + sNombreArchivo + ".xml", data);


                            ////PDF
                            byte[] datap = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "PDF", "G");
                            //File.WriteAllBytes(f.SelectedPath + @"\" + sNombreArchivo + ".pdf", datap);
                            File.WriteAllBytes(Directorio + @"\" + sNombreArchivo + ".pdf", datap);

                            if (IdSituacion == Parametros.intDVAnulado)
                            {
                                ////ZIP
                                byte[] dataz = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "ZIP", "");
                                //File.WriteAllBytes(f.SelectedPath + @"\" + sNombreArchivo + ".zip", dataz);
                                File.WriteAllBytes(Directorio + @"\" + sNombreArchivo + "-AN.zip", dataz);
                            }
                            else
                            {
                                ////ZIP
                                byte[] dataz = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "ZIP", "");
                                //File.WriteAllBytes(f.SelectedPath + @"\" + sNombreArchivo + ".zip", dataz);
                                File.WriteAllBytes(Directorio + @"\" + sNombreArchivo + ".zip", dataz);
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("No existen datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                XtraMessageBox.Show("Se genero los archivos de forma satisfactoria en la siguiente ubicación.\n" + f.SelectedPath, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(gvDocumento.RowCount > 0)
            {
                if (Convert.ToInt32(keyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.P))
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                    {
                        frmMsgPrintDocFE frmE = new frmMsgPrintDocFE();
                        if (frmE.ShowDialog() == DialogResult.OK)
                        {
                            ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frmE.sImpresora, frmE.sFormato);

                            //Cargar desde Dirección Print
                            if(frmE.bGuiaRemision)
                            {
                                #region "Guia Remision Continuo"

                                #region "Direccion Origen"
                                
                                string dirFacturacion = "<No Especificado>";

                                if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali) dirFacturacion = Parametros.strDireccionUcayali2;
                                else if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali) dirFacturacion = Parametros.strDireccionUcayali3;
                                else dirFacturacion = Parametros.strDireccionUcayali;

                                if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                                if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                                if (objE_DocumentoVenta.IdEmpresa == Parametros.intIdPanoramaDistribuidores) dirFacturacion = Parametros.strDireccionUcayali;

                                #endregion

                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

                                #region "Direccion"
                                frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                                frm.IdPedido = int.Parse(gvDocumento.GetFocusedRowCellValue("IdPedido").ToString());
                                frm.ShowDialog();
                                String DirguiaRem = "";

                                if (frm.DireccionGuiaPrint == "")
                                {
                                    DirguiaRem = objE_DocumentoVenta.Direccion;
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
                                    MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");
                                }
                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
                                #endregion
                            }

                            //Cargar Hoja de Despacho
                            if(frmE.bHojaDespacho)
                            {
                                #region "Hoja de Despacho"
                                List<ReporteMovimientoPedidoBE> lstReporte = null;
                                lstReporte = new ReporteMovimientoPedidoBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdPedido));

                                rptMovimientoPedido objReporteGuia = new rptMovimientoPedido();
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

                                    if (printer.ToUpper().StartsWith("(A4)"))
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
                                    MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");
                                }
                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
                                #endregion
                            }
                        }
                        //ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, "TKE");
                    }
                    else
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        frmMsgPrintDocFE frm = new frmMsgPrintDocFE();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            //ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora, frm.sFormato);
                            ImpresionElectronicaLocal(objE_DocumentoVenta.IdDocumentoVenta, frm.sImpresora, "NC");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Opción disponible sólo para documentos electrónicos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void enviarPSEtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumento.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    //DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    int row = gvDocumento.GetSelectedRows()[i];
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(row);

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

                    if (objE_DocumentoVenta.Serie.Length != 4)
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE SERIE INCORRECTO");
                        gcDocumento.Refresh();
                    }
                    if (objE_DocumentoVenta.Numero.Length != 8)
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE NUMERO INCORRECTO");
                        gcDocumento.Refresh();
                    }

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        if (objE_DocumentoVenta.IdSituacion != Parametros.intDVAnulado)
                        {
                            #region "Diferencia cabecera vs detalle Doc Ven"
                            if (objE_DocumentoVenta.TotalDiferencia != 0)
                            {
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:VERIFICAR SUMA DE CABECERA VS DETALLE");
                                gcDocumento.Refresh();
                            }
                            #endregion

                            #region "Envío e Impresión de Comprobante electrónico"
                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                            {
                                #region "Grabar"
                                //gvDocumento.SetRowCellValue(gvDocumento.FocusedRowHandle, "DescSituacionPSE", "ENVIANDO...");
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                                gcDocumento.Refresh();
                                string MensajeService = FacturaE.GrabarVentaIntegrens(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                                if (MensajeService.ToUpper() != "OK")
                                {
                                    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                                    gcDocumento.Refresh();
                                }
                                else
                                {
                                    //gvDocumento.SetRowCellValue(gvDocumento.FocusedRowHandle, "DescSituacionPSE", "ENVIADO");
                                    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIADO");
                                }

                                #endregion
                            }
                            else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                #region "Grabar"
                                //gvDocumento.SetRowCellValue(gvDocumento.FocusedRowHandle, "DescSituacionPSE", "ENVIANDO...");
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                                gcDocumento.Refresh();
                                string MensajeService = FacturaE.GrabarNotaCreditoIntegrens(objE_DocumentoVenta.IdEmpresa,objE_DocumentoVenta.IdDocumentoVenta);
                                if (MensajeService.ToUpper() != "OK")
                                {
                                    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                                    gcDocumento.Refresh();
                                }
                                else
                                {
                                    //gvDocumento.SetRowCellValue(gvDocumento.FocusedRowHandle, "DescSituacionPSE", "ENVIADO");
                                    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIADO");
                                }
                                #endregion
                            }
                            else
                            {
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
                                gcDocumento.Refresh();
                            }

                            #endregion
                        }
                        else
                        {
                            string MensajeService = "";
                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                                MensajeService = FacturaE.AnulaNotaCreditoIntegrens(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                            else
                                MensajeService = FacturaE.AnulaVentaIntegrens(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);

                            gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                            gcDocumento.Refresh();
                        }
                    }
                    else
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
                        gcDocumento.Refresh();
                    }

                    //gcDocumento.RefreshDataSource();
                    gcDocumento.Refresh();
                }

                Cursor = Cursors.Default;
            }
        }

        private void gvDocumento_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    //DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
            //    int IdTipoDocumento = int.Parse(gvDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());
            //    if (IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
            //    {
            //        cambiarfechatoolStripMenuItem.Visible = false;
            //        renumerartoolStripMenuItem.Visible = false;
            //        cambiarfechatoolStripMenuItem.Visible = false;
            //        eliminafisicotoolStripMenuItem.Visible = false;
            //        cambiarrazonsocialtoolStripMenuItem.Visible = false;
            //    }
            //    else
            //    {
            //        cambiarfechatoolStripMenuItem.Visible = true;
            //        renumerartoolStripMenuItem.Visible = true;
            //        cambiarfechatoolStripMenuItem.Visible = true;
            //        eliminafisicotoolStripMenuItem.Visible = true;
            //        cambiarrazonsocialtoolStripMenuItem.Visible = true;
            //    }
            //}
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if(Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
                mLista = new DocumentoVentaBL().Lista(0, 0, deDesde.DateTime, deHasta.DateTime);
            else
                mLista = new DocumentoVentaBL().Lista(0, Parametros.intTiendaId, deDesde.DateTime, deHasta.DateTime);
            gcDocumento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            //Traemos la información del Pedido
            PedidoBE objE_Pedido = null;
            objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumeroPedido.Text.Trim());
            if (objE_Pedido != null)
            {
                mLista = new DocumentoVentaBL().ListadoPedido(objE_Pedido.IdPedido);
                gcDocumento.DataSource = mLista;
            }
        }

        private void CargarBusquedaDocumento()
        {
            //Traemos la información del documento
            mLista = new DocumentoVentaBL().ListaSerieNumero(Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text, txtNumero.Text);
            gcDocumento.DataSource = mLista;
            
        }

        public void InicializarModificar()
        {
            if (gvDocumento.RowCount > 0)
            {
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
                objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                objRegFacturacionEdit.btnGrabar.Enabled = true;
                objRegFacturacionEdit.mnuContextual.Enabled = true;
                if (objRegFacturacionEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            
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
                if (gvDocumento.RowCount > 0)
                {
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
                    objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                    frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                    objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                    objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
                    objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                    objRegFacturacionEdit.btnGrabar.Enabled = false;
                    objRegFacturacionEdit.mnuContextual.Enabled = false;
                    if (objRegFacturacionEdit.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo editar");
                }
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private bool ValidarElimina()
        {
            bool flag = false;

            if (gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            if (Convert.ToInt32(gvDocumento.GetFocusedRowCellValue("IdFormaPago").ToString()) == Parametros.intContado)
            {
                XtraMessageBox.Show("No se puede anular una comprobante contado desde este módulo por favor eliminar desde Caja.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }


            //if (flag)
            //{
            //    XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Cursor = Cursors.Default;
            //}

            return flag;

            //Cursor = Cursors.Default;
            //return flag;
        }

        private void GrabarAnulaVentaIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            //mDocumentoVentaE = objE_DocumentoVenta;

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
            dr["estreg"] = "AN";//CO = Correcto; AN= Anulado
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
                
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                //objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
                XtraMessageBox.Show("Documento dado de baja correctamente. " + MensajeService.ToUpper(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ImpresionTicketElectronico("G");
            }
            //MessageBox.Show(WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N"));
            //txtObservacion.Text = dsCabecera.GetXml();

        }

        private void ImpresionElectronicaLocal(int IdDocumentoVenta, string Impresora, string Formato)
        {
            if(Formato == "GRE")
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().ListadoGuia(IdDocumentoVenta);

                #region "Codigo QR"
                int Regs = lstReporte.Count() - 1;
                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
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

                rptGuiaRemisionPanoramaElectronica objReporte = new rptGuiaRemisionPanoramaElectronica();
                objReporte.SetDataSource(lstReporte);
                Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
            }
            else
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                #region "Codigo QR"
                int Regs = lstReporte.Count() - 1;
                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
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
                    if (lstReporte[0].IdEmpresa == 19)
                    {
                        if (Formato == "A4")
                        {
                            rptFacturaElectronicaPanoramaA4_THB objReporte = new rptFacturaElectronicaPanoramaA4_THB();
                            objReporte.SetDataSource(lstReporte);
                            //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                            //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }
                        else if (Formato == "NC")//Ticket
                        {
                            rptNotaCreditoElectronicaPanoramaA4_THB objReporte = new rptNotaCreditoElectronicaPanoramaA4_THB();
                            objReporte.SetDataSource(lstReporte);
                            Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                            //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }
                    }
                    else if (lstReporte[0].IdEmpresa == 21)
                    {
                        if (Formato == "A4")
                        {
                            rptFacturaElectronicaPanoramaA4_THL objReporte = new rptFacturaElectronicaPanoramaA4_THL();
                            objReporte.SetDataSource(lstReporte);
                            //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                            //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }
                        else if (Formato == "NC")//Ticket
                        {
                            rptNotaCreditoElectronicaPanoramaA4_THL objReporte = new rptNotaCreditoElectronicaPanoramaA4_THL();
                            objReporte.SetDataSource(lstReporte);
                            Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                            //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }
                    }
                    else
                    {
                        if (Formato == "A4")
                        {
                            rptFacturaElectronicaPanoramaA4 objReporte = new rptFacturaElectronicaPanoramaA4();
                            objReporte.SetDataSource(lstReporte);
                            //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                            //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }
                        else if (Formato == "NC")//Ticket
                        {
                            rptNotaCreditoElectronicaPanoramaA4 objReporte = new rptNotaCreditoElectronicaPanoramaA4();
                            objReporte.SetDataSource(lstReporte);
                            Impresion.Imprimir(objReporte, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                            //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                        }
                        else
                        {
                            //if(Parametros.intTiendaId ==Parametros.intTiendaUcayali)
                            //{
                            //    rptFacturaElectronicaPanorama80mm objReporteGuia = new rptFacturaElectronicaPanorama80mm();
                            //    objReporteGuia.SetDataSource(lstReporte);
                            //    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            //    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                            //    Impresion.Imprimir(objReporteGuia, Impresora, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            //}
                            //else
                            {
                                #region "Impresión Matricial"

                                string dirFacturacion = "<No Especificado>";

                                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                                    dirFacturacion = Parametros.strDireccionUcayali2;
                                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                                    dirFacturacion = Parametros.strDireccionUcayali3;
                                else
                                    dirFacturacion = Parametros.strDireccionUcayali;
                                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                                if (Parametros.intTiendaId == Parametros.intTiendaPrescott) dirFacturacion = Parametros.strDireccionPrescott;


                                //List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                //lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                                //TalonBE objTalon = new TalonBE();
                                //objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, lstReporte[0].IdTipoDocumento);// Convert.ToInt32(cboDocumento.EditValue));

                                CreaTicket ticket = new CreaTicket();
                                ticket.impresora = Impresora;

                                //if(objTalon == null)
                                //{
                                //    objTalon.Impresora = "(T)";
                                //    objTalon.DireccionFiscal = dirFacturacion;
                                //}
                                #region "Busca Impresora"
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
                                #endregion

                                //ticket.AbreCajon();
                                ticket.TextoCentro(Parametros.strEmpresaNombre);
                                ticket.TextoCentro(dirFacturacion);
                                //ticket.TextoCentro(objTalon.DireccionFiscal);
                                //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                                if (lstReporte[0].IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                                ticket.TextoCentro(Parametros.strEmpresaRuc);
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                                //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                                //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                                ticket.TextoIzquierda("N° " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                                ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                                ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                                if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
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
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                                ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " " + lstReporte[0].DescMoneda);
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                                ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 155-2017/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en https://www.nubefact.com/consulta");
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                //ticket.TextoCentro("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant());
                                //ticket.TextoCentro("de Venta Electrónica.");
                                //ticket.TextoCentro("Consulte su documento en");
                                //ticket.TextoCentro("http://www.intelfac.com");
                                //ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                //ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                //ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("www.panoramahogar.com");
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

                        }
                    }
                }
            }
        }

        private void GrabarVentaIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            //mDocumentoVentaE = objE_DocumentoVenta;

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
                Cargar();

                //if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    //ImpresionTicketElectronico("G");
                //    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                //}
            }
            //MessageBox.Show(WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N"));
            //txtObservacion.Text = dsCabecera.GetXml();

        }

        private void GrabarNotaCreditoIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            //mDocumentoVentaE = objE_DocumentoVenta;

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
                Cargar();
                //if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    //ImpresionTicketElectronico("G");
                //    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
                //}
            }
        }


        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmEnviarPSE frm = new frmEnviarPSE();
            frm.Origen = 1;
            frm.ShowDialog();
        }

        private void enviarOSEtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumento.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int row = gvDocumento.GetSelectedRows()[i];
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(row);
                    // Validacion de la empresa
                    if (objE_DocumentoVenta.IdEmpresa != 13)
                    {
                        XtraMessageBox.Show("El documento no pertenece a la razon social PANORAMA DISTRIBUIDORES S.A." , "Envio a OSE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);
         

                    if (objE_DocumentoVenta.Serie.Length != 4)
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE SERIE INCORRECTO");
                        gcDocumento.Refresh();
                    }
                    if (objE_DocumentoVenta.Numero.Length != 8)
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE NUMERO INCORRECTO");
                        gcDocumento.Refresh();
                    }

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
                    {
                        //if (objE_DocumentoVenta.IdSituacion != Parametros.intDVAnulado)
                        //{
                        #region "Diferencia cabecera vs detalle Doc Ven"
                        if (objE_DocumentoVenta.TotalDiferencia != 0)
                        {
                            gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:VERIFICAR SUMA DE CABECERA VS DETALLE");
                            gcDocumento.Refresh();
                            continue;
                        }
                        #endregion

                        #region "Envío e Impresión de Comprobante electrónico"
                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                            {
                                #region "Grabar"
                                //gvDocumento.SetRowCellValue(gvDocumento.FocusedRowHandle, "DescSituacionPSE", "ENVIANDO...");
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                                gcDocumento.Refresh();
                                //string MensajeService = FacturaE.GrabarVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
                                string MensajeService = string.Empty;
                                if (objE_DocumentoVenta.IdFormaPago == Parametros.intObsequio)
                                {
                                    MensajeService = FacturaOSE.CrearFacturaGratuita(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                                }
                                else
                                {
                                    MensajeService = FacturaOSE.CrearFactura(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                                } 
                                
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                                gcDocumento.Refresh();

                                //if (MensajeService.ToUpper() != "OK")
                                //{
                                //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                                //    gcDocumento.Refresh();
                                //}
                                //else
                                //{
                                //    //gvDocumento.SetRowCellValue(gvDocumento.FocusedRowHandle, "DescSituacionPSE", "ENVIADO");
                                //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIADO");
                                //}

                                #endregion
                            }
                            else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                #region "Grabar"
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                                gcDocumento.Refresh();
                                string MensajeService = FacturaOSE.CrearNotaCredito(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                                gcDocumento.Refresh();
                                #endregion
                            }
                            else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
                            {
                                #region "Grabar"
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                                gcDocumento.Refresh();
                                string MensajeService = FacturaOSE.CrearGuiaRemision(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                                gcDocumento.Refresh();
                                #endregion
                            }
                            else
                            {
                                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
                                gcDocumento.Refresh();
                            }

                            #endregion
                        //}
                        //else
                        //{
                        //    //string MensajeService = "";
                        //    //if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        //    //    MensajeService = FacturaE.AnulaNotaCreditoIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
                        //    //else
                        //    //    MensajeService = FacturaE.AnulaVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);

                        //    //gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                        //    //gcDocumento.Refresh();
                        //}
                    }
                    else
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
                        gcDocumento.Refresh();
                    }

                    //gcDocumento.RefreshDataSource();
                    gcDocumento.Refresh();
                }

                Cursor = Cursors.Default;
            }
        }

        private void generararchivobajatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de generar el documento de baja de Facturas?\nTodo los documentos anulados en el ERP se enviarán al OSE.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string MensajeOSE = FacturaOSE.CrearComunicacionBaja();
                XtraMessageBox.Show(MensajeOSE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void enviarresumendiariotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de generar el archivo de resumen diario de Boletas?\nTodo los documentos anulados en el ERP se enviarán al OSE.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string MensajeOSE = FacturaOSE.CrearResumenDiario();
                XtraMessageBox.Show(MensajeOSE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void actualizarconsultatickettoolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region "Actualizar Mensaje"
            string MensajePendiente = string.Empty;

            List<SunatConsultaTicketBE> lstPendiente = new List<SunatConsultaTicketBE>();
            SunatConsultaTicketBL objBL_SunatConsulta = new SunatConsultaTicketBL();

            lstPendiente = objBL_SunatConsulta.ListaPendiente(Parametros.intEmpresaId);
            foreach(var item in lstPendiente)
            {
                string MensajeOSE = FacturaOSE.ConsultarTicket(item.NumeroTicket, item.Ruc);
                objBL_SunatConsulta.ActualizaMensaje(item.IdSunatConsultaTicket, MensajeOSE);

                MensajePendiente += $"{item.NumeroTicket} ==> {MensajeOSE}\n";
            }
            XtraMessageBox.Show(MensajePendiente, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion
        }

        private void gvDocumento_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumento.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdSituacionPSE"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == Parametros.intSitAnuladoPSE)
                        {
                            gvDocumento.Columns["DescSituacionPSE"].AppearanceCell.ForeColor = Color.Red;
                            gvDocumento.Columns["MensajeOSE"].AppearanceCell.ForeColor = Color.Red;
                        }
                        else
                        {
                            gvDocumento.Columns["DescSituacionPSE"].AppearanceCell.ForeColor = Color.Blue;
                            gvDocumento.Columns["MensajeOSE"].AppearanceCell.ForeColor = Color.Blue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarguiaelectronicatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumento.RowCount > 0)
            {
                DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                frmRegGuiaRemisionElectronica frm = new frmRegGuiaRemisionElectronica();
                frm.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                frm.ShowDialog();
            }
        }

        private void gcDocumento_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        private void enviarASUNATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumento.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int row = gvDocumento.GetSelectedRows()[i];
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(row);

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

                    if (objE_DocumentoVenta.Serie.Length != 4)
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE SERIE INCORRECTO");
                        gcDocumento.Refresh();
                    }
                    if (objE_DocumentoVenta.Numero.Length != 8)
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE NUMERO DOCUMENTO INCORRECTO");
                        gcDocumento.Refresh();
                    }

                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || 
                        objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
                    {
                        #region "Diferencia cabecera vs detalle Doc Ven"
                        if (objE_DocumentoVenta.TotalDiferencia != 0)
                        {
                            gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: VERIFICAR SUMA DE CABECERA VS DETALLE");
                            gcDocumento.Refresh();
                            continue;
                        }
                        #endregion
                        //frm_efact  FrmEnvioFE = new frm_efact();
                        //switch (objE_DocumentoVenta.IdTipoDocumento)
                        //{
                        //    case 10:
                        //        FrmEnvioFE.vTipoDocumento = 1;
                        //        break;

                        //    case 11:
                        //        FrmEnvioFE.vTipoDocumento = 1;
                        //        break;

                        //    case 12:
                        //        FrmEnvioFE.vTipoDocumento = 2;
                        //        break;

                        //    case 13:
                        //        FrmEnvioFE.vTipoDocumento = 1;
                        //        break;
                        //}

                        //FrmEnvioFE.vIdEmpresa = objE_DocumentoVenta.IdEmpresa;
                        //FrmEnvioFE.vIdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;

                        //FrmEnvioFE.ShowDialog();
                        #region "Envío e Impresión de Comprobante electrónico"
                        //if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                        //{
                        //    #region "Grabar"
                        //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                        //    gcDocumento.Refresh();
                        //    string MensajeService = string.Empty;

                        //    if (objE_DocumentoVenta.IdEmpresa == 19)    // Betsabe Tapia
                        //    {
                        //        if (objE_DocumentoVenta.IdFormaPago == Parametros.intObsequio)
                        //        {
                        //            MensajeService = FacturaSUNAT_THB.CrearFacturaGratuita(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //        }
                        //        else
                        //        {
                        //            MensajeService = FacturaSUNAT_THB.CrearFactura(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //        }

                        //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                        //        gcDocumento.Refresh();
                        //    }
                        //    else if (objE_DocumentoVenta.IdEmpresa == 21)    // Liliana Tapia
                        //        {
                        //            if (objE_DocumentoVenta.IdFormaPago == Parametros.intObsequio)
                        //            {
                        //                MensajeService = FacturaSUNAT.CrearFacturaGratuita(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //            }
                        //            else
                        //            {
                        //                MensajeService = FacturaSUNAT.CrearFactura(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //            }

                        //            gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                        //            gcDocumento.Refresh();
                        //        }

                        //    #endregion
                        //}
                        //else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        //{
                        //    if (objE_DocumentoVenta.IdEmpresa == 19)    // Betsabe Tapia
                        //    {
                        //        #region "Grabar"
                        //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                        //        gcDocumento.Refresh();
                        //        string MensajeService = FacturaSUNAT_THB.CrearNotaCredito(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                        //        gcDocumento.Refresh();
                        //        #endregion
                        //    }
                        //    else if (objE_DocumentoVenta.IdEmpresa == 21)    // Liliana Tapia
                        //    {
                        //        #region "Grabar"
                        //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                        //        gcDocumento.Refresh();
                        //        string MensajeService = FacturaSUNAT.CrearNotaCredito(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                        //        gcDocumento.Refresh();
                        //        #endregion
                        //    }
                        //}
                        //else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
                        //{
                        //    #region "Grabar"
                        //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
                        //    gcDocumento.Refresh();
                        //    string MensajeService = FacturaSUNAT.CrearGuiaRemision(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
                        //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
                        //    gcDocumento.Refresh();
                        //    #endregion
                        //}
                        //else
                        //{
                        //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
                        //    gcDocumento.Refresh();
                        //}
                        #endregion
                    }
                    else
                    {
                        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
                        gcDocumento.Refresh();
                    }
                    gcDocumento.Refresh();
            }

            Cursor = Cursors.Default;
            }
        }

        private void generarArchivoDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de generar el documento de baja de Facturas?\nTodo los documentos anulados en el ERP se enviarán a SUNAT.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string MensajeOSE = FacturaSUNAT_THB.CrearComunicacionBaja();
                XtraMessageBox.Show(MensajeOSE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void enviarResumenDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de generar el archivo de resumen diario de Boletas?\nTodo los documentos anulados en el ERP se enviarán a SUNAT.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DocumentoVentaBE objDocumentoVentaIdEmpresa1 = new DocumentoVentaBE();
                objDocumentoVentaIdEmpresa1.IdEmpresa = int.Parse(gvDocumento.GetFocusedRowCellValue("IdEmpresa").ToString());

                if (objDocumentoVentaIdEmpresa1.IdEmpresa == 19)   // Betsabe Tapia
                {
                    string MensajeOSE = FacturaSUNAT_THB.CrearResumenDiario();
                    XtraMessageBox.Show(MensajeOSE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (objDocumentoVentaIdEmpresa1.IdEmpresa == 21)   // Liliana Tapia
                {
                    string MensajeOSE = FacturaSUNAT.CrearResumenDiario();
                    XtraMessageBox.Show(MensajeOSE, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }


        private void actualizarConsultaTicketToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region "Actualizar Mensaje"
            string MensajePendiente = string.Empty;

            List<SunatConsultaTicketBE> lstPendiente = new List<SunatConsultaTicketBE>();
            SunatConsultaTicketBL objBL_SunatConsulta = new SunatConsultaTicketBL();

            DocumentoVentaBE objDocumentoVentaIdEmpresa = new DocumentoVentaBE();
            objDocumentoVentaIdEmpresa.IdEmpresa = int.Parse(gvDocumento.GetFocusedRowCellValue("IdEmpresa").ToString());

            if (objDocumentoVentaIdEmpresa.IdEmpresa == 19)   //Betsabe Tapia
            {
                lstPendiente = objBL_SunatConsulta.ListaPendiente(objDocumentoVentaIdEmpresa.IdEmpresa);
                foreach (var item in lstPendiente)
                {
                    string MensajeOSE = FacturaSUNAT_THB.ConsultarTicket(item.NumeroTicket, item.Ruc);
                    objBL_SunatConsulta.ActualizaMensaje(item.IdSunatConsultaTicket, MensajeOSE);

                    MensajePendiente += $"{item.NumeroTicket} ==> {MensajeOSE}\n";
                }
            }
            else if (objDocumentoVentaIdEmpresa.IdEmpresa == 21)   // Liliana Tapia
            {
                lstPendiente = objBL_SunatConsulta.ListaPendiente(objDocumentoVentaIdEmpresa.IdEmpresa);
                foreach (var item in lstPendiente)
                {
                    string MensajeOSE = FacturaSUNAT.ConsultarTicket(item.NumeroTicket, item.Ruc);
                    objBL_SunatConsulta.ActualizaMensaje(item.IdSunatConsultaTicket, MensajeOSE);

                    MensajePendiente += $"{item.NumeroTicket} ==> {MensajeOSE}\n";
                }
            }
            XtraMessageBox.Show(MensajePendiente, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion
        }

        //private void eNVIARBOLETANTToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (gvDocumento.RowCount > 0)
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
        //        {
        //            int row = gvDocumento.GetSelectedRows()[i];
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(row);

        //            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
        //            objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

        //            if (objE_DocumentoVenta.Serie.Length != 4)
        //            {
        //                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE SERIE INCORRECTO");
        //                gcDocumento.Refresh();
        //            }
        //            if (objE_DocumentoVenta.Numero.Length != 8)
        //            {
        //                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: LONGITUD DE NUMERO DOCUMENTO INCORRECTO");
        //                gcDocumento.Refresh();
        //            }

        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica ||
        //                objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
        //            {
        //                #region "Diferencia cabecera vs detalle Doc Ven"
        //                if (objE_DocumentoVenta.TotalDiferencia != 0)
        //                {
        //                    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR: VERIFICAR SUMA DE CABECERA VS DETALLE");
        //                    gcDocumento.Refresh();
        //                    continue;
        //                }
        //                #endregion
        //                //frm_efact FrmEnvioFE = new frm_efact();
        //                //switch (objE_DocumentoVenta.IdTipoDocumento)
        //                //{
        //                //    case 10:
        //                //        FrmEnvioFE.vTipoDocumento = 1;
        //                //        break;

        //                //    case 11:
        //                //        FrmEnvioFE.vTipoDocumento = 1;
        //                //        break;

        //                //    case 12:
        //                //        FrmEnvioFE.vTipoDocumento = 2;
        //                //        break;

        //                //    case 13:
        //                //        FrmEnvioFE.vTipoDocumento = 1;
        //                //        break;
        //                //}

        //                //FrmEnvioFE.vIdEmpresa = objE_DocumentoVenta.IdEmpresa;
        //                //FrmEnvioFE.vIdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;

        //                //FrmEnvioFE.ShowDialog();
        //                #region "Envío e Impresión de Comprobante electrónico"
        //                //if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
        //                //{
        //                //    #region "Grabar"
        //                //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
        //                //    gcDocumento.Refresh();
        //                //    string MensajeService = string.Empty;

        //                //    if (objE_DocumentoVenta.IdEmpresa == 19)    // Betsabe Tapia
        //                //    {
        //                //        if (objE_DocumentoVenta.IdFormaPago == Parametros.intObsequio)
        //                //        {
        //                //            MensajeService = FacturaSUNAT_THB.CrearFacturaGratuita(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //        }
        //                //        else
        //                //        {
        //                //            MensajeService = FacturaSUNAT_THB.CrearFactura(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //        }

        //                //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
        //                //        gcDocumento.Refresh();
        //                //    }
        //                //    else if (objE_DocumentoVenta.IdEmpresa == 21)    // Liliana Tapia
        //                //        {
        //                //            if (objE_DocumentoVenta.IdFormaPago == Parametros.intObsequio)
        //                //            {
        //                //                MensajeService = FacturaSUNAT.CrearFacturaGratuita(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //            }
        //                //            else
        //                //            {
        //                //                MensajeService = FacturaSUNAT.CrearFactura(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //            }

        //                //            gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
        //                //            gcDocumento.Refresh();
        //                //        }

        //                //    #endregion
        //                //}
        //                //else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
        //                //{
        //                //    if (objE_DocumentoVenta.IdEmpresa == 19)    // Betsabe Tapia
        //                //    {
        //                //        #region "Grabar"
        //                //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
        //                //        gcDocumento.Refresh();
        //                //        string MensajeService = FacturaSUNAT_THB.CrearNotaCredito(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
        //                //        gcDocumento.Refresh();
        //                //        #endregion
        //                //    }
        //                //    else if (objE_DocumentoVenta.IdEmpresa == 21)    // Liliana Tapia
        //                //    {
        //                //        #region "Grabar"
        //                //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
        //                //        gcDocumento.Refresh();
        //                //        string MensajeService = FacturaSUNAT.CrearNotaCredito(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //        gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
        //                //        gcDocumento.Refresh();
        //                //        #endregion
        //                //    }
        //                //}
        //                //else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
        //                //{
        //                //    #region "Grabar"
        //                //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ENVIANDO...");
        //                //    gcDocumento.Refresh();
        //                //    string MensajeService = FacturaSUNAT.CrearGuiaRemision(objE_DocumentoVenta.IdEmpresa, objE_DocumentoVenta.IdDocumentoVenta);
        //                //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", MensajeService);
        //                //    gcDocumento.Refresh();
        //                //    #endregion
        //                //}
        //                //else
        //                //{
        //                //    gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
        //                //    gcDocumento.Refresh();
        //                //}
        //                #endregion
        //            }
        //            else
        //            {
        //                gvDocumento.SetRowCellValue(row, "DescSituacionPSE", "ERROR:NO ES COMPROBANTE ELECTRONICO");
        //                gcDocumento.Refresh();
        //            }
        //            gcDocumento.Refresh();
        //        }

        //        Cursor = Cursors.Default;
        //    }
        //}
    }
}