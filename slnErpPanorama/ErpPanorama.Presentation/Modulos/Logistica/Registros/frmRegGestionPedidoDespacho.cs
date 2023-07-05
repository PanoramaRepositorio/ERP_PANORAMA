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
    public partial class frmRegGestionPedidoDespacho : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        #endregion

        #region "Eventos"

        public frmRegGestionPedidoDespacho()
        {
            InitializeComponent();
        }

        private void frmRegGestionPedidoDespacho_Load(object sender, EventArgs e)
        {
            //tlbMenu.Ensamblado = this.Tag.ToString();

            //deDesde.EditValue = DateTime.Now;
            //deHasta.EditValue = DateTime.Now;
            //Cargar();
        }

        //private void tlbMenu_NewClick()
        //{
        //    try
        //    {
        //        frmRegGestionPedidoDespachoEdit objManDocumentoVenta = new frmRegGestionPedidoDespachoEdit();
        //        objManDocumentoVenta.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Nuevo;
        //        objManDocumentoVenta.IdDocumentoVenta = 0;
        //        objManDocumentoVenta.StartPosition = FormStartPosition.CenterParent;
        //        objManDocumentoVenta.ShowDialog();
        //        Cargar();
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void tlbMenu_EditClick()
        //{
        //    InicializarModificar();
        //}

        //private void tlbMenu_DeleteClick()
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            if (!ValidarIngreso())
        //            {
        //                DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
        //                objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));

        //                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
        //                objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
        //                XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                Cargar();
        //            }
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor = Cursors.Default;
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void tlbMenu_RefreshClick()
        //{
        //    Cargar();
        //}

        //private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        CargarBusqueda();
        //    }
            
        //}

        //private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        CargarBusquedaDocumento();
        //    }
        //}

        //private void tlbMenu_PrintClick()
        //{
            
        //}

        //private void tlbMenu_ExportClick()
        //{
        //    string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
        //    string _fileName = "ListadoDocumentoVentas";
        //    FolderBrowserDialog f = new FolderBrowserDialog();
        //    f.ShowDialog(this);
        //    if (f.SelectedPath != "")
        //    {
        //        Cursor = Cursors.AppStarting;
        //        gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
        //        string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
        //        XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        Cursor = Cursors.Default;
        //    }
        //}

        //private void tlbMenu_ExitClick()
        //{
        //    this.Close();
        //}

        //private void gvDocumento_DoubleClick(object sender, EventArgs e)
        //{
        //    GridView view = (GridView)sender;
        //    Point pt = view.GridControl.PointToClient(Control.MousePosition);
        //    FilaDoubleClick(view, pt);
        //}
        
        //private void btnConsultar_Click(object sender, EventArgs e)
        //{
        //    Cargar();
        //}

        //private void imprimirguiaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            string dirFacturacion = "<No Especificado>";

        //            if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali2;
        //            }
        //            else if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaUcayali)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali3;
        //            }
        //            else
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }
        //            if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaAndahuaylas)
        //            {
        //                dirFacturacion = Parametros.strDireccionAndahuaylas;
        //            }
        //            if (objE_DocumentoVenta.IdTienda == Parametros.intTiendaKonceptos)
        //            {
        //                dirFacturacion = Parametros.strDireccionMegaplaza;
        //            }

        //            if (objE_DocumentoVenta.IdEmpresa == Parametros.intIdPanoramaDistribuidores)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }

        //            #region "Guia Remisión - Boleta"
        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
        //            {
        //                #region "Guia Remision desglosable con Pedido"
        //                if (objE_DocumentoVenta.IdPedido != null)
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
        //                    rptGuiaRemisionBoletaPanorama objReporteGuia = new rptGuiaRemisionBoletaPanorama();

        //                    #region "Direccion"
        //                    frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
        //                    frm.ShowDialog();
        //                    String DirguiaRem = "";

        //                    if (frm.DireccionGuiaPrint == "")
        //                    {
        //                        DirguiaRem = objE_DocumentoVenta.Direccion;
        //                    }
        //                    else
        //                    {
        //                        DirguiaRem = frm.DireccionGuiaPrint;
        //                    }
        //                    #endregion

        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
        //                    objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //                #endregion
        //                else
        //                {
        //                #region "Guia Remision desglosable Documento"
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptGuiaRemisionBoletaPanorama objReporteGuia = new rptGuiaRemisionBoletaPanorama();

        //                    #region "Direccion"
        //                    frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
        //                    frm.ShowDialog();
        //                    String DirguiaRem = "";

        //                    if (frm.DireccionGuiaPrint == "")
        //                    {
        //                        DirguiaRem = objE_DocumentoVenta.Direccion;
        //                    }
        //                    else
        //                    {
        //                        DirguiaRem = frm.DireccionGuiaPrint;
        //                    }
        //                    #endregion

        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
        //                    objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);



        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(B)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    //}
        //                    #endregion
        //                }
        //            }
        //            #endregion

        //            #region "Guia Remisión - Factura y Otros"
        //            else
        //            {
        //                #region "Guia Remision desglosable con Pedido"
        //                if (objE_DocumentoVenta.IdPedido != null)
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
        //                    rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

        //                    #region "Direccion"
        //                    frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
        //                    frm.ShowDialog();
        //                    String DirguiaRem = "";

        //                    if (frm.DireccionGuiaPrint == "")
        //                    {
        //                        DirguiaRem = objE_DocumentoVenta.Direccion;
        //                    }
        //                    else
        //                    {
        //                        DirguiaRem = frm.DireccionGuiaPrint;
        //                    }
        //                    #endregion

        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
        //                    objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //                #endregion
        //                else
        //                {
        //                #region "Guia Remision desglosable Documento"
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

        //                    #region "Direccion"
        //                    frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
        //                    frm.ShowDialog();
        //                    String DirguiaRem = "";

        //                    if (frm.DireccionGuiaPrint == "")
        //                    {
        //                        DirguiaRem = objE_DocumentoVenta.Direccion;
        //                    }
        //                    else
        //                    {
        //                        DirguiaRem = frm.DireccionGuiaPrint;
        //                    }
        //                    #endregion

        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
        //                    objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);



        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(B)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    //}
        //                    #endregion
        //                }                    
                    
        //            }
        //            #endregion

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void vistapreliminarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
        //            {
        //                List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));
        //                if (lstReporte.Count > 0)
        //                {
        //                    RptVistaReportes objRptDocumento = new RptVistaReportes();
        //                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));
        //                    objRptDocumento.ShowDialog();
        //                }
        //            }
        //            else
        //            {
        //                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
        //                if (lstReporte.Count > 0)
        //                {
        //                    RptVistaReportes objRptDocumento = new RptVistaReportes();
        //                    objRptDocumento.VerRptDocumentoVenta(lstReporte, objE_DocumentoVenta.IdTipoDocumento);
        //                    objRptDocumento.ShowDialog();
        //                }
        //            }
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            string dirFacturacion = "<No Especificado>";

        //            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali2;
        //            }
        //            else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali3;
        //            }
        //            else
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
        //            {
        //                dirFacturacion = Parametros.strDireccionAndahuaylas;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
        //            {
        //                dirFacturacion = Parametros.strDireccionMegaplaza;
        //            }

        //            #region "Boleta continua"
        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
        //            {
        //                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
        //                objReporteGuia.SetDataSource(lstReporte);

        //                bool found = false;
        //                PrinterSettings prtSetting = new PrinterSettings();
        //                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                {
        //                    string printer = "";
        //                    if (prtName.StartsWith("\\\\"))
        //                    {
        //                        printer = prtName.Substring(3);
        //                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                    }
        //                    else
        //                        printer = prtName;

        //                    if (printer.ToUpper().StartsWith("(B)"))
        //                    {
        //                        found = true;
        //                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                        prtSetting.PrinterName = prtName;
        //                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                        int rawKind = -1;
        //                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                        {
        //                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                            {
        //                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                break;
        //                            }
        //                        }
        //                        if (rawKind == -1)
        //                        {
        //                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                        break;
        //                    }
        //                }

        //                if (!found)
        //                {
        //                    MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                }
        //                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //            }
        //            #endregion

        //            #region "Factura Panorama Continua"
        //            else
        //                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                    rptFacturaPanorama objReporteGuia = new rptFacturaPanorama();
        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //            #endregion

        //            #region "Factura Corona Continua"
        //                else
        //                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Factura Corona Continua
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                        rptFacturaCorona objReporteGuia = new rptFacturaCorona();
        //                        objReporteGuia.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(F)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //                #endregion

        //            #region "Guia Remisión"
        //                else
        //                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaRemision)//GUIA DE REMISION
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                        rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();
        //                        objReporteGuia.SetDataSource(lstReporte);
        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(F)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //            #endregion

        //            #region "Nota Crédito"
        //                    else
        //                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
        //                        {
        //                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                            rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
        //                            objReporteNotaCredito.SetDataSource(lstReporte);

        //                            bool found = false;
        //                            PrinterSettings prtSetting = new PrinterSettings();
        //                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                            {
        //                                string printer = "";
        //                                if (prtName.StartsWith("\\\\"))
        //                                {
        //                                    printer = prtName.Substring(3);
        //                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                }
        //                                else
        //                                    printer = prtName;

        //                                if (printer.ToUpper().StartsWith("(F)"))
        //                                {
        //                                    found = true;
        //                                    PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                    prtSetting.PrinterName = prtName;
        //                                    objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                    int rawKind = -1;
        //                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                    {
        //                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                        {
        //                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                            objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                            break;
        //                                        }
        //                                    }
        //                                    if (rawKind == -1)
        //                                    {
        //                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                    }
        //                                    break;
        //                                }
        //                            }

        //                            if (!found)
        //                            {
        //                                MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                            }
        //                            objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                        }

        //            #endregion

        //            #region "Otros"
        //              else {
        //                  XtraMessageBox.Show("No disponible para este documento, opción accesible para Boleta,Factura y Nota de Crédito", "Impresión Documento Continuo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                   }
        //            #endregion
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void imprimirdocumentodesglosabletoolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            string dirFacturacion = "<No Especificado>";

        //            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali2;
        //            }
        //            else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali3;
        //            }
        //            else
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
        //            {
        //                dirFacturacion = Parametros.strDireccionAndahuaylas;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
        //            {
        //                dirFacturacion = Parametros.strDireccionMegaplaza;
        //            }
        //            #region "Boleta Panorama desglosable"
        //            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)&& (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Boleta Panorama desglosable
        //            {
        //                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                rptBoletaPanoramaDesglosable objReporteGuia = new rptBoletaPanoramaDesglosable();
        //                objReporteGuia.SetDataSource(lstReporte);

        //                bool found = false;
        //                PrinterSettings prtSetting = new PrinterSettings();
        //                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                {
        //                    string printer = "";
        //                    if (prtName.StartsWith("\\\\"))
        //                    {
        //                        printer = prtName.Substring(3);
        //                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                    }
        //                    else
        //                        printer = prtName;

        //                    if (printer.ToUpper().StartsWith("(B)"))
        //                    {
        //                        found = true;
        //                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                        prtSetting.PrinterName = prtName;
        //                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                        int rawKind = -1;
        //                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                        {
        //                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                            {
        //                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                break;
        //                            }
        //                        }
        //                        if (rawKind == -1)
        //                        {
        //                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                        break;
        //                    }
        //                }

        //                if (!found)
        //                {
        //                    MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                }
        //                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //            }
        //            #endregion

        //            #region "Boleta Corona desglosable"
        //            else
        //                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Boleta Corona desglosable
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                    rptBoletaCoronaDesglosable objReporteGuia = new rptBoletaCoronaDesglosable();
        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(B)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //            #endregion

        //            #region "Boleta Eleazar desglosable"
        //                else
        //                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Boleta Eleazar desglosable
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                        rptBoletaEleazarDesglosable objReporteGuia = new rptBoletaEleazarDesglosable();
        //                        objReporteGuia.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(B)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //                #endregion

        //            #region "Boleta Amalia desglosable"
        //                    else
        //                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Boleta Amalia desglosable
        //                        {
        //                            List<ReporteDocumentoVentaBE> lstReporte = null;
        //                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                            rptBoletaAmaliaDesglosable objReporteGuia = new rptBoletaAmaliaDesglosable();
        //                            objReporteGuia.SetDataSource(lstReporte);

        //                            bool found = false;
        //                            PrinterSettings prtSetting = new PrinterSettings();
        //                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                            {
        //                                string printer = "";
        //                                if (prtName.StartsWith("\\\\"))
        //                                {
        //                                    printer = prtName.Substring(3);
        //                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                }
        //                                else
        //                                    printer = prtName;

        //                                if (printer.ToUpper().StartsWith("(B)"))
        //                                {
        //                                    found = true;
        //                                    PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                    prtSetting.PrinterName = prtName;
        //                                    objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                    int rawKind = -1;
        //                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                    {
        //                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                        {
        //                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                            objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                            break;
        //                                        }
        //                                    }
        //                                    if (rawKind == -1)
        //                                    {
        //                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                    }
        //                                    break;
        //                                }
        //                            }

        //                            if (!found)
        //                            {
        //                                MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                            }
        //                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                        }
        //                    #endregion

        //            #region "Boleta Olga desglosable"
        //        else

        //            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Boleta Olga desglosable
        //            {
        //                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                rptBoletaOlgaDesglosable objReporteGuia = new rptBoletaOlgaDesglosable();
        //                objReporteGuia.SetDataSource(lstReporte);

        //                bool found = false;
        //                PrinterSettings prtSetting = new PrinterSettings();
        //                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                {
        //                    string printer = "";
        //                    if (prtName.StartsWith("\\\\"))
        //                    {
        //                        printer = prtName.Substring(3);
        //                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                    }
        //                    else
        //                        printer = prtName;

        //                    if (printer.ToUpper().StartsWith("(B)"))
        //                    {
        //                        found = true;
        //                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                        prtSetting.PrinterName = prtName;
        //                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                        int rawKind = -1;
        //                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                        {
        //                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                            {
        //                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                break;
        //                            }
        //                        }
        //                        if (rawKind == -1)
        //                        {
        //                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                        break;
        //                    }
        //                }

        //                if (!found)
        //                {
        //                    MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                }
        //                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //            }
        //        #endregion

        //            #region "Factura Panorama Desglosable"
        //            else
        //                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Desglosable
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                    rptFacturaPanoramaDesglosable objReporteGuia = new rptFacturaPanoramaDesglosable();
        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //            #endregion

        //            #region "Factura Corona Desglosable"
        //                else
        //                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Factura Corona Desglosable
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                        rptFacturaPanoramaDesglosable objReporteGuia = new rptFacturaPanoramaDesglosable();
        //                        objReporteGuia.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(F)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //                #endregion

        //            #region "Factura Eleazar Desglosable"
        //                else
        //                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Factura Eleazar Desglosable
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                        rptFacturaEleazarDesglosable objReporteGuia = new rptFacturaEleazarDesglosable();
        //                        objReporteGuia.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(F)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //                #endregion

        //            #region "Factura Amalia Desglosable"
        //                    else
        //                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Factura Amalia Desglosable
        //                        {
        //                            List<ReporteDocumentoVentaBE> lstReporte = null;
        //                            lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                            rptFacturaAmaliaDesglosable objReporteGuia = new rptFacturaAmaliaDesglosable();
        //                            objReporteGuia.SetDataSource(lstReporte);

        //                            bool found = false;
        //                            PrinterSettings prtSetting = new PrinterSettings();
        //                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                            {
        //                                string printer = "";
        //                                if (prtName.StartsWith("\\\\"))
        //                                {
        //                                    printer = prtName.Substring(3);
        //                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                }
        //                                else
        //                                    printer = prtName;

        //                                if (printer.ToUpper().StartsWith("(F)"))
        //                                {
        //                                    found = true;
        //                                    PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                    prtSetting.PrinterName = prtName;
        //                                    objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                    int rawKind = -1;
        //                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                    {
        //                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                        {
        //                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                            objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                            break;
        //                                        }
        //                                    }
        //                                    if (rawKind == -1)
        //                                    {
        //                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                    }
        //                                    break;
        //                                }
        //                            }

        //                            if (!found)
        //                            {
        //                                MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                            }
        //                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                        }
        //                    #endregion

        //            #region "Factura Olga Desglosable"
        //                        else
        //                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Factura Olga Desglosable
        //                            {
        //                                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                                rptFacturaOlgaDesglosable objReporteGuia = new rptFacturaOlgaDesglosable();
        //                                objReporteGuia.SetDataSource(lstReporte);

        //                                bool found = false;
        //                                PrinterSettings prtSetting = new PrinterSettings();
        //                                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                {
        //                                    string printer = "";
        //                                    if (prtName.StartsWith("\\\\"))
        //                                    {
        //                                        printer = prtName.Substring(3);
        //                                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                    }
        //                                    else
        //                                        printer = prtName;

        //                                    if (printer.ToUpper().StartsWith("(F)"))
        //                                    {
        //                                        found = true;
        //                                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                        prtSetting.PrinterName = prtName;
        //                                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                        int rawKind = -1;
        //                                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                        {
        //                                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                            {
        //                                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                break;
        //                                            }
        //                                        }
        //                                        if (rawKind == -1)
        //                                        {
        //                                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                        }
        //                                        break;
        //                                    }
        //                                }

        //                                if (!found)
        //                                {
        //                                    MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                }
        //                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                            }
        //                        #endregion

        //            #region "Guia de Remision"
        //                                            /*else
        //                                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocGuiaRemision)//GUIA DE REMISION
        //                                                {
        //                                                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                                    lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));

        //                                                    rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();
        //                                                    objReporteGuia.SetDataSource(lstReporte);
        //                                                    bool found = false;
        //                                                    PrinterSettings prtSetting = new PrinterSettings();
        //                                                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                                    {
        //                                                        string printer = "";
        //                                                        if (prtName.StartsWith("\\\\"))
        //                                                        {
        //                                                            printer = prtName.Substring(3);
        //                                                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                        }
        //                                                        else
        //                                                            printer = prtName;

        //                                                        if (printer.ToUpper().StartsWith("(F)"))
        //                                                        {
        //                                                            found = true;
        //                                                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                                            prtSetting.PrinterName = prtName;
        //                                                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                                            int rawKind = -1;
        //                                                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                            {
        //                                                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                                {
        //                                                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                                    break;
        //                                                                }
        //                                                            }
        //                                                            if (rawKind == -1)
        //                                                            {
        //                                                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                            }
        //                                                            break;
        //                                                        }
        //                                                    }

        //                                                    if (!found)
        //                                                    {
        //                                                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                                    }
        //                                                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                                                }*/
        //                                            #endregion

        //            #region "Nota Credito Panorama"
        //            else
        //                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                {
        //                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptNotaCreditoPanoramaDesglosable objReporteNotaCredito = new rptNotaCreditoPanoramaDesglosable();
        //                    objReporteNotaCredito.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                }

        //            #endregion

        //            #region "Nota Credito Corona"
        //            else
        //                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                {
        //                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptNotaCreditoCoronaDesglosable objReporteNotaCredito = new rptNotaCreditoCoronaDesglosable();
        //                    objReporteNotaCredito.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                }

        //            #endregion

        //            #region "Nota Credito Amalia"
        //            else
        //                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                {
        //                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptNotaCreditoAmaliaDesglosable objReporteNotaCredito = new rptNotaCreditoAmaliaDesglosable();
        //                    objReporteNotaCredito.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                }

        //            #endregion

        //            #region "Nota Credito Eleazar"
        //            else
        //                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                {
        //                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptNotaCreditoEleazarDesglosable objReporteNotaCredito = new rptNotaCreditoEleazarDesglosable();
        //                    objReporteNotaCredito.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                }

        //            #endregion

        //            #region "Nota Credito Olga"
        //            else
        //                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                {
        //                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptNotaCreditoOlgaDesglosable objReporteNotaCredito = new rptNotaCreditoOlgaDesglosable();
        //                    objReporteNotaCredito.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                }

        //            #endregion

        //            #region "Otros"
        //            else
        //            {
        //                XtraMessageBox.Show("Impresión no disponible para este documento, Consulte con su administrador", "Impresión Documento Desglosable", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            }
        //            #endregion

        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void undocumentocontinuotoolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            string dirFacturacion = "<No Especificado>";

        //            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali2;
        //            }
        //            else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali3;
        //            }
        //            else
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
        //            {
        //                dirFacturacion = Parametros.strDireccionAndahuaylas;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
        //            {
        //                dirFacturacion = Parametros.strDireccionMegaplaza;
        //            }

        //            #region "Boleta continua"
        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
        //            {
        //                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
        //                objReporteGuia.SetDataSource(lstReporte);

        //                bool found = false;
        //                PrinterSettings prtSetting = new PrinterSettings();
        //                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                {
        //                    string printer = "";
        //                    if (prtName.StartsWith("\\\\"))
        //                    {
        //                        printer = prtName.Substring(3);
        //                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                    }
        //                    else
        //                        printer = prtName;

        //                    if (printer.ToUpper().StartsWith("(B)"))
        //                    {
        //                        found = true;
        //                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                        prtSetting.PrinterName = prtName;
        //                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                        int rawKind = -1;
        //                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                        {
        //                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                            {
        //                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                break;
        //                            }
        //                        }
        //                        if (rawKind == -1)
        //                        {
        //                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                        break;
        //                    }
        //                }

        //                if (!found)
        //                {
        //                    MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                }
        //                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //            }
        //            #endregion

        //            #region "Factura Panorama Continua"
        //            else
        //              if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptFacturaPanorama objReporteGuia = new rptFacturaPanorama();
        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(F)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //            #endregion

        //            #region "Factura Corona Continua"
        //                else
        //                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Factura Corona Continua
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                        rptFacturaCorona objReporteGuia = new rptFacturaCorona();
        //                        objReporteGuia.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(F)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //                #endregion

        //            #region "Nota Crédito"
        //                else
        //                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
        //                    {
        //                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                        rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
        //                        objReporteNotaCredito.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(F)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                    }

        //                #endregion

        //            #region "Otros"
        //            else
        //            {
        //                XtraMessageBox.Show("No disponible para este documento, opción accesible para Boleta,Factura y Nota de Crédito", "Impresión Documento Continuo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            }
        //            #endregion
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void undocumentodesglosabletoolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            string dirFacturacion = "<No Especificado>";

        //            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali2;
        //            }
        //            else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali3;
        //            }
        //            else
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
        //            {
        //                dirFacturacion = Parametros.strDireccionAndahuaylas;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
        //            {
        //                dirFacturacion = Parametros.strDireccionMegaplaza;
        //            }
        //            #region "Boleta Panorama desglosable"
        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)//Boleta Panorama desglosable
        //            {
        //                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                rptBoletaPanoramaDesglosable objReporteGuia = new rptBoletaPanoramaDesglosable();
        //                objReporteGuia.SetDataSource(lstReporte);

        //                bool found = false;
        //                PrinterSettings prtSetting = new PrinterSettings();
        //                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                {
        //                    string printer = "";
        //                    if (prtName.StartsWith("\\\\"))
        //                    {
        //                        printer = prtName.Substring(3);
        //                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                    }
        //                    else
        //                        printer = prtName;

        //                    if (printer.ToUpper().StartsWith("(B)"))
        //                    {
        //                        found = true;
        //                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                        prtSetting.PrinterName = prtName;
        //                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                        int rawKind = -1;
        //                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                        {
        //                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                            {
        //                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                break;
        //                            }
        //                        }
        //                        if (rawKind == -1)
        //                        {
        //                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                        break;
        //                    }
        //                }

        //                if (!found)
        //                {
        //                    MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                }
        //                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //            }
        //            #endregion

        //            #region "Boleta Corona desglosable"
        //            else
        //                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intCoronaImportadores))//Boleta Corona desglosable
        //                {
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptBoletaCoronaDesglosable objReporteGuia = new rptBoletaCoronaDesglosable();
        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(B)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                }
        //            #endregion

        //                #region "Boleta Eleazar desglosable"
        //                else
        //                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Boleta Eleazar desglosable
        //                    {
        //                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                        rptBoletaEleazarDesglosable objReporteGuia = new rptBoletaEleazarDesglosable();
        //                        objReporteGuia.SetDataSource(lstReporte);

        //                        bool found = false;
        //                        PrinterSettings prtSetting = new PrinterSettings();
        //                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                        {
        //                            string printer = "";
        //                            if (prtName.StartsWith("\\\\"))
        //                            {
        //                                printer = prtName.Substring(3);
        //                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                            }
        //                            else
        //                                printer = prtName;

        //                            if (printer.ToUpper().StartsWith("(B)"))
        //                            {
        //                                found = true;
        //                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                prtSetting.PrinterName = prtName;
        //                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                int rawKind = -1;
        //                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                {
        //                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                    {
        //                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        break;
        //                                    }
        //                                }
        //                                if (rawKind == -1)
        //                                {
        //                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                }
        //                                break;
        //                            }
        //                        }

        //                        if (!found)
        //                        {
        //                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                        }
        //                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    }
        //                #endregion

        //                    #region "Boleta Amalia desglosable"
        //                    else
        //                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Boleta Amalia desglosable
        //                        {
        //                            List<ReporteDocumentoVentaBE> lstReporte = null;
        //                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                            rptBoletaAmaliaDesglosable objReporteGuia = new rptBoletaAmaliaDesglosable();
        //                            objReporteGuia.SetDataSource(lstReporte);

        //                            bool found = false;
        //                            PrinterSettings prtSetting = new PrinterSettings();
        //                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                            {
        //                                string printer = "";
        //                                if (prtName.StartsWith("\\\\"))
        //                                {
        //                                    printer = prtName.Substring(3);
        //                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                }
        //                                else
        //                                    printer = prtName;

        //                                if (printer.ToUpper().StartsWith("(B)"))
        //                                {
        //                                    found = true;
        //                                    PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                    prtSetting.PrinterName = prtName;
        //                                    objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                    int rawKind = -1;
        //                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                    {
        //                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                        {
        //                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                            objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                            break;
        //                                        }
        //                                    }
        //                                    if (rawKind == -1)
        //                                    {
        //                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                    }
        //                                    break;
        //                                }
        //                            }

        //                            if (!found)
        //                            {
        //                                MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                            }
        //                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                        }
        //                    #endregion

        //                        #region "Boleta Olga desglosable"
        //                        else

        //                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Boleta Olga desglosable
        //                            {
        //                                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                rptBoletaOlgaDesglosable objReporteGuia = new rptBoletaOlgaDesglosable();
        //                                objReporteGuia.SetDataSource(lstReporte);

        //                                bool found = false;
        //                                PrinterSettings prtSetting = new PrinterSettings();
        //                                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                {
        //                                    string printer = "";
        //                                    if (prtName.StartsWith("\\\\"))
        //                                    {
        //                                        printer = prtName.Substring(3);
        //                                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                    }
        //                                    else
        //                                        printer = prtName;

        //                                    if (printer.ToUpper().StartsWith("(B)"))
        //                                    {
        //                                        found = true;
        //                                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                        prtSetting.PrinterName = prtName;
        //                                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                        int rawKind = -1;
        //                                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                        {
        //                                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                            {
        //                                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                break;
        //                                            }
        //                                        }
        //                                        if (rawKind == -1)
        //                                        {
        //                                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                        }
        //                                        break;
        //                                    }
        //                                }

        //                                if (!found)
        //                                {
        //                                    MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                }
        //                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                            }
        //                        #endregion

        //                            #region "Factura Panorama Desglosable"
        //                            else
        //                                if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Desglosable
        //                                {
        //                                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                    rptFacturaPanoramaDesglosable objReporteGuia = new rptFacturaPanoramaDesglosable();
        //                                    objReporteGuia.SetDataSource(lstReporte);

        //                                    bool found = false;
        //                                    PrinterSettings prtSetting = new PrinterSettings();
        //                                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                    {
        //                                        string printer = "";
        //                                        if (prtName.StartsWith("\\\\"))
        //                                        {
        //                                            printer = prtName.Substring(3);
        //                                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                        }
        //                                        else
        //                                            printer = prtName;

        //                                        if (printer.ToUpper().StartsWith("(F)"))
        //                                        {
        //                                            found = true;
        //                                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                            prtSetting.PrinterName = prtName;
        //                                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                            int rawKind = -1;
        //                                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                            {
        //                                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                {
        //                                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                    break;
        //                                                }
        //                                            }
        //                                            if (rawKind == -1)
        //                                            {
        //                                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                            }
        //                                            break;
        //                                        }
        //                                    }

        //                                    if (!found)
        //                                    {
        //                                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                    }
        //                                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                                }
        //                            #endregion

        //                                #region "Factura Eleazar Desglosable"
        //                                else
        //                                    if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaTarrilloEleazar))//Factura Eleazar Desglosable
        //                                    {
        //                                        List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                        rptFacturaEleazarDesglosable objReporteGuia = new rptFacturaEleazarDesglosable();
        //                                        objReporteGuia.SetDataSource(lstReporte);

        //                                        bool found = false;
        //                                        PrinterSettings prtSetting = new PrinterSettings();
        //                                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                        {
        //                                            string printer = "";
        //                                            if (prtName.StartsWith("\\\\"))
        //                                            {
        //                                                printer = prtName.Substring(3);
        //                                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                            }
        //                                            else
        //                                                printer = prtName;

        //                                            if (printer.ToUpper().StartsWith("(F)"))
        //                                            {
        //                                                found = true;
        //                                                PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                                prtSetting.PrinterName = prtName;
        //                                                objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                                int rawKind = -1;
        //                                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                {
        //                                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                    {
        //                                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                        break;
        //                                                    }
        //                                                }
        //                                                if (rawKind == -1)
        //                                                {
        //                                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                }
        //                                                break;
        //                                            }
        //                                        }

        //                                        if (!found)
        //                                        {
        //                                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                        }
        //                                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                                    }
        //                                #endregion

        //                                    #region "Factura Amalia Desglosable"
        //                                    else
        //                                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia))//Factura Amalia Desglosable
        //                                        {
        //                                            List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                            rptFacturaAmaliaDesglosable objReporteGuia = new rptFacturaAmaliaDesglosable();
        //                                            objReporteGuia.SetDataSource(lstReporte);

        //                                            bool found = false;
        //                                            PrinterSettings prtSetting = new PrinterSettings();
        //                                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                            {
        //                                                string printer = "";
        //                                                if (prtName.StartsWith("\\\\"))
        //                                                {
        //                                                    printer = prtName.Substring(3);
        //                                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                }
        //                                                else
        //                                                    printer = prtName;

        //                                                if (printer.ToUpper().StartsWith("(F)"))
        //                                                {
        //                                                    found = true;
        //                                                    PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                                    prtSetting.PrinterName = prtName;
        //                                                    objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                                    int rawKind = -1;
        //                                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                    {
        //                                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                        {
        //                                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                            objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                            break;
        //                                                        }
        //                                                    }
        //                                                    if (rawKind == -1)
        //                                                    {
        //                                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                    }
        //                                                    break;
        //                                                }
        //                                            }

        //                                            if (!found)
        //                                            {
        //                                                MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                            }
        //                                            objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                                        }
        //                                    #endregion

        //                                        #region "Factura Olga Desglosable"
        //                                        else
        //                                            if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVenta) && (objE_DocumentoVenta.IdEmpresa == Parametros.intTapiaCalderonOlgaLidia))//Factura Olga Desglosable
        //                                            {
        //                                                List<ReporteDocumentoVentaBE> lstReporte = null;
        //                                                lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                                rptFacturaOlgaDesglosable objReporteGuia = new rptFacturaOlgaDesglosable();
        //                                                objReporteGuia.SetDataSource(lstReporte);

        //                                                bool found = false;
        //                                                PrinterSettings prtSetting = new PrinterSettings();
        //                                                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                                {
        //                                                    string printer = "";
        //                                                    if (prtName.StartsWith("\\\\"))
        //                                                    {
        //                                                        printer = prtName.Substring(3);
        //                                                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                    }
        //                                                    else
        //                                                        printer = prtName;

        //                                                    if (printer.ToUpper().StartsWith("(F)"))
        //                                                    {
        //                                                        found = true;
        //                                                        PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                                                        prtSetting.PrinterName = prtName;
        //                                                        objReporteGuia.PrintOptions.PrinterName = prtName;

        //                                                        int rawKind = -1;
        //                                                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                        {
        //                                                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                            {
        //                                                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                                break;
        //                                                            }
        //                                                        }
        //                                                        if (rawKind == -1)
        //                                                        {
        //                                                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                }

        //                                                if (!found)
        //                                                {
        //                                                    MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                                }
        //                                                objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                                            }
        //                                        #endregion
    
        //                                          #region "Nota Crédito Panorama"
        //                                        else
        //                                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
        //                                        {
        //                                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                            rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
        //                                            objReporteNotaCredito.SetDataSource(lstReporte);

        //                                            bool found = false;
        //                                            PrinterSettings prtSetting = new PrinterSettings();
        //                                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                            {
        //                                                string printer = "";
        //                                                if (prtName.StartsWith("\\\\"))
        //                                                {
        //                                                    printer = prtName.Substring(3);
        //                                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                }
        //                                                else
        //                                                    printer = prtName;

        //                                                if (printer.ToUpper().StartsWith("(F)"))
        //                                                {
        //                                                    found = true;
        //                                                    PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                                    prtSetting.PrinterName = prtName;
        //                                                    objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                                    int rawKind = -1;
        //                                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                    {
        //                                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                        {
        //                                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                            objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                            break;
        //                                                        }
        //                                                    }
        //                                                    if (rawKind == -1)
        //                                                    {
        //                                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                    }
        //                                                    break;
        //                                                }
        //                                            }

        //                                            if (!found)
        //                                            {
        //                                                MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                            }
        //                                            objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                                        }

        //                                    #endregion

        //                                        #region "Nota Credito Corona"
        //                                        else
        //                                            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                                            {
        //                                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                                rptNotaCreditoCoronaDesglosable objReporteNotaCredito = new rptNotaCreditoCoronaDesglosable();
        //                                                objReporteNotaCredito.SetDataSource(lstReporte);

        //                                                bool found = false;
        //                                                PrinterSettings prtSetting = new PrinterSettings();
        //                                                foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                                {
        //                                                    string printer = "";
        //                                                    if (prtName.StartsWith("\\\\"))
        //                                                    {
        //                                                        printer = prtName.Substring(3);
        //                                                        printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                    }
        //                                                    else
        //                                                        printer = prtName;

        //                                                    if (printer.ToUpper().StartsWith("(F)"))
        //                                                    {
        //                                                        found = true;
        //                                                        PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                                        prtSetting.PrinterName = prtName;
        //                                                        objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                                        int rawKind = -1;
        //                                                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                        {
        //                                                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                            {
        //                                                                rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                                objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                                break;
        //                                                            }
        //                                                        }
        //                                                        if (rawKind == -1)
        //                                                        {
        //                                                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                }

        //                                                if (!found)
        //                                                {
        //                                                    MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                                }
        //                                                objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                                            }

        //                                        #endregion

        //                                            #region "Nota Credito Amalia"
        //                                            else
        //                                                if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                                                {
        //                                                    List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                                                    lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                                    rptNotaCreditoAmaliaDesglosable objReporteNotaCredito = new rptNotaCreditoAmaliaDesglosable();
        //                                                    objReporteNotaCredito.SetDataSource(lstReporte);

        //                                                    bool found = false;
        //                                                    PrinterSettings prtSetting = new PrinterSettings();
        //                                                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                                    {
        //                                                        string printer = "";
        //                                                        if (prtName.StartsWith("\\\\"))
        //                                                        {
        //                                                            printer = prtName.Substring(3);
        //                                                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                        }
        //                                                        else
        //                                                            printer = prtName;

        //                                                        if (printer.ToUpper().StartsWith("(F)"))
        //                                                        {
        //                                                            found = true;
        //                                                            PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                                            prtSetting.PrinterName = prtName;
        //                                                            objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                                            int rawKind = -1;
        //                                                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                            {
        //                                                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                                {
        //                                                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                                    objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                                    break;
        //                                                                }
        //                                                            }
        //                                                            if (rawKind == -1)
        //                                                            {
        //                                                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                            }
        //                                                            break;
        //                                                        }
        //                                                    }

        //                                                    if (!found)
        //                                                    {
        //                                                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                                    }
        //                                                    objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                                                }

        //                                            #endregion

        //                                                #region "Nota Credito Eleazar"
        //                                                else
        //                                                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                                                    {
        //                                                        List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                                                        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                                        rptNotaCreditoEleazarDesglosable objReporteNotaCredito = new rptNotaCreditoEleazarDesglosable();
        //                                                        objReporteNotaCredito.SetDataSource(lstReporte);

        //                                                        bool found = false;
        //                                                        PrinterSettings prtSetting = new PrinterSettings();
        //                                                        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                                        {
        //                                                            string printer = "";
        //                                                            if (prtName.StartsWith("\\\\"))
        //                                                            {
        //                                                                printer = prtName.Substring(3);
        //                                                                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                            }
        //                                                            else
        //                                                                printer = prtName;

        //                                                            if (printer.ToUpper().StartsWith("(F)"))
        //                                                            {
        //                                                                found = true;
        //                                                                PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                                                prtSetting.PrinterName = prtName;
        //                                                                objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                                                int rawKind = -1;
        //                                                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                                {
        //                                                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                                    {
        //                                                                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                                        objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                                        break;
        //                                                                    }
        //                                                                }
        //                                                                if (rawKind == -1)
        //                                                                {
        //                                                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                                }
        //                                                                break;
        //                                                            }
        //                                                        }

        //                                                        if (!found)
        //                                                        {
        //                                                            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                                        }
        //                                                        objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                                                    }

        //                                                #endregion

        //                                                    #region "Nota Credito Olga"
        //                                                    else
        //                                                        if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//NOTACREDITO PANORAMA
        //                                                        {
        //                                                            List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                                                            lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                                                            rptNotaCreditoOlgaDesglosable objReporteNotaCredito = new rptNotaCreditoOlgaDesglosable();
        //                                                            objReporteNotaCredito.SetDataSource(lstReporte);

        //                                                            bool found = false;
        //                                                            PrinterSettings prtSetting = new PrinterSettings();
        //                                                            foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                                            {
        //                                                                string printer = "";
        //                                                                if (prtName.StartsWith("\\\\"))
        //                                                                {
        //                                                                    printer = prtName.Substring(3);
        //                                                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                                                }
        //                                                                else
        //                                                                    printer = prtName;

        //                                                                if (printer.ToUpper().StartsWith("(F)"))
        //                                                                {
        //                                                                    found = true;
        //                                                                    PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                                                    prtSetting.PrinterName = prtName;
        //                                                                    objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                                                    int rawKind = -1;
        //                                                                    CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                                                    for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                                                    {
        //                                                                        if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                                                        {
        //                                                                            rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                                                            objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                                                            break;
        //                                                                        }
        //                                                                    }
        //                                                                    if (rawKind == -1)
        //                                                                    {
        //                                                                        MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                                                    }
        //                                                                    break;
        //                                                                }
        //                                                            }

        //                                                            if (!found)
        //                                                            {
        //                                                                MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                                            }
        //                                                            objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                                                        }

        //                                                    #endregion

        //                                            #region "Nota Credito Comentario"
        //                                        //else
        //                                        //    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCredito)//NOTACREDITO
        //                                        //    {
        //                                        //        List<ReporteDocumentoReferenciaBE> lstReporte = null;
        //                                        //        lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoReferencia));

        //                                        //        rptNotaCreditoPanorama objReporteNotaCredito = new rptNotaCreditoPanorama();
        //                                        //        objReporteNotaCredito.SetDataSource(lstReporte);

        //                                        //        bool found = false;
        //                                        //        PrinterSettings prtSetting = new PrinterSettings();
        //                                        //        foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                                        //        {
        //                                        //            string printer = "";
        //                                        //            if (prtName.StartsWith("\\\\"))
        //                                        //            {
        //                                        //                printer = prtName.Substring(3);
        //                                        //                printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                                        //            }
        //                                        //            else
        //                                        //                printer = prtName;

        //                                        //            if (printer.ToUpper().StartsWith("(F)"))
        //                                        //            {
        //                                        //                found = true;
        //                                        //                PrintOptions bufPO = objReporteNotaCredito.PrintOptions;
        //                                        //                prtSetting.PrinterName = prtName;
        //                                        //                objReporteNotaCredito.PrintOptions.PrinterName = prtName;

        //                                        //                int rawKind = -1;
        //                                        //                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteNotaCredito.ReportDefinition.ReportObjects["PAPERNAME"];
        //                                        //                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                                        //                {
        //                                        //                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                        //                    {
        //                                        //                        rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                        //                        objReporteNotaCredito.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                        //                        break;
        //                                        //                    }
        //                                        //                }
        //                                        //                if (rawKind == -1)
        //                                        //                {
        //                                        //                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                        //                }
        //                                        //                break;
        //                                        //            }
        //                                        //        }

        //                                        //        if (!found)
        //                                        //        {
        //                                        //            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

        //                                        //        }
        //                                        //        objReporteNotaCredito.PrintToPrinter(1, false, 0, 0);
        //                                        //    }

        //                                        #endregion

        //                                                #region "Otros"
        //                                                else
        //                                                {
        //                                                    XtraMessageBox.Show("Impresión no disponible para este documento, Consulte con su administrador", "Impresión Documento Desglosable", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                                                }
        //                                                #endregion
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void unaguiatoolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

        //            string dirFacturacion = "<No Especificado>";

        //            if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali2;
        //            }
        //            else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali3;
        //            }
        //            else
        //            {
        //                dirFacturacion = Parametros.strDireccionUcayali;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
        //            {
        //                dirFacturacion = Parametros.strDireccionAndahuaylas;
        //            }
        //            if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
        //            {
        //                dirFacturacion = Parametros.strDireccionMegaplaza;
        //            }


        //            #region "Guia Remisión - Boleta"
        //            if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
        //            {
        //                 #region "Guia Remision desglosable Documento"
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptGuiaRemisionBoletaPanorama objReporteGuia = new rptGuiaRemisionBoletaPanorama();

        //                    #region "Direccion"
        //                    frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
        //                    frm.ShowDialog();
        //                    String DirguiaRem = "";

        //                    if (frm.DireccionGuiaPrint == "")
        //                    {
        //                        DirguiaRem = objE_DocumentoVenta.Direccion;
        //                    }
        //                    else
        //                    {
        //                        DirguiaRem = frm.DireccionGuiaPrint;
        //                    }
        //                    #endregion

        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
        //                    objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);



        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(B)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    //}
        //                    #endregion
        //            }
        //            #endregion

        //            #region "Guia Remisión - Factura y Otros"
        //            else
        //            {
        //                #region "Guia Remision desglosable Documento"
        //                    List<ReporteDocumentoVentaBE> lstReporte = null;
        //                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

        //                    rptGuiaRemisionPanorama objReporteGuia = new rptGuiaRemisionPanorama();

        //                    #region "Direccion"
        //                    frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
        //                    frm.ShowDialog();
        //                    String DirguiaRem = "";

        //                    if (frm.DireccionGuiaPrint == "")
        //                    {
        //                        DirguiaRem = objE_DocumentoVenta.Direccion;
        //                    }
        //                    else
        //                    {
        //                        DirguiaRem = frm.DireccionGuiaPrint;
        //                    }
        //                    #endregion

        //                    objReporteGuia.SetDataSource(lstReporte);

        //                    objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
        //                    objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);



        //                    bool found = false;
        //                    PrinterSettings prtSetting = new PrinterSettings();
        //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
        //                    {
        //                        string printer = "";
        //                        if (prtName.StartsWith("\\\\"))
        //                        {
        //                            printer = prtName.Substring(3);
        //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
        //                        }
        //                        else
        //                            printer = prtName;

        //                        if (printer.ToUpper().StartsWith("(B)"))
        //                        {
        //                            found = true;
        //                            PrintOptions bufPO = objReporteGuia.PrintOptions;
        //                            prtSetting.PrinterName = prtName;
        //                            objReporteGuia.PrintOptions.PrinterName = prtName;

        //                            int rawKind = -1;
        //                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
        //                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
        //                            {
        //                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
        //                                {
        //                                    rawKind = prtSetting.PaperSizes[i].RawKind;
        //                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        //                                    break;
        //                                }
        //                            }
        //                            if (rawKind == -1)
        //                            {
        //                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            }
        //                            break;
        //                        }
        //                    }

        //                    if (!found)
        //                    {
        //                        MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

        //                    }
        //                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
        //                    //}
        //                    #endregion

        //            }
        //            #endregion

        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void renumerartoolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmEstablecerNumero objDescuento = new frmEstablecerNumero();
        //    objDescuento.StartPosition = FormStartPosition.CenterParent;
        //    if (objDescuento.ShowDialog() == DialogResult.OK)
        //    {
        //        int Num = 0;
        //        for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
        //        {
        //            int IdEmpresa = 0;
        //            int IdDocumentoVenta = 0;
        //            string Serie = "";
        //            string Numero = "";
                    
        //            int row = gvDocumento.GetSelectedRows()[i];
        //            IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
        //            IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
        //            Serie = gvDocumento.GetRowCellValue(row, "Serie").ToString();

        //            if (i==0)
        //            {
        //                Num = objDescuento.Numero;
        //            }
                    
        //            DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
        //            DocumentoVentaBE objE_Documento = new DocumentoVentaBE();

        //            objE_Documento.IdEmpresa = IdEmpresa;
        //            objE_Documento.IdDocumentoVenta = IdDocumentoVenta;
        //            objE_Documento.Serie = Serie;
        //            Numero = FuncionBase.AgregarCaracter(Num.ToString(), "0", 6);
        //            objE_Documento.Numero = Numero;
        //            objBL_Documento.ActualizaNumeroSerie(objE_Documento);

        //            Num++;
        //        }
        //    }

        //    CargarBusqueda();
        //}

        //private void cambiarrazonsocialtoolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (mLista.Count > 0)
        //        {
        //            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
        //            frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
        //            objDescuento.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
        //            objDescuento.StartPosition = FormStartPosition.CenterParent;
        //            if (objDescuento.ShowDialog() == DialogResult.OK)
        //            {
        //                CargarBusqueda();
        //            }
                    
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void cambiarfechatoolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmEstablecerFecha objDescuento = new frmEstablecerFecha();
        //    objDescuento.StartPosition = FormStartPosition.CenterParent;
        //    if (objDescuento.ShowDialog() == DialogResult.OK)
        //    {
        //        int Num = 0;
        //        for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
        //        {
        //            int IdEmpresa = 0;
        //            int IdDocumentoVenta = 0;
        //            DateTime Fecha;

        //            int row = gvDocumento.GetSelectedRows()[i];
        //            IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
        //            IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    
        //            Fecha = objDescuento.Fecha;
                    
        //            DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
        //            DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
             
        //            objBL_Documento.ActualizaFecha(IdEmpresa, IdDocumentoVenta, Fecha);

        //            Num++;
        //        }
        //    }

        //    CargarBusqueda();
        //}

        //#endregion

        //#region "Metodos"

        //private void Cargar()
        //{
        //    mLista = new DocumentoVentaBL().Lista(0, deDesde.DateTime, deHasta.DateTime);
        //    gcDocumento.DataSource = mLista;
        //}

        //private void CargarBusqueda()
        //{
        //    //Traemos la información del Pedido
        //    PedidoBE objE_Pedido = null;
        //    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text.Trim());
        //    if (objE_Pedido != null)
        //    {
        //        mLista = new DocumentoVentaBL().ListadoPedido(objE_Pedido.IdPedido);
        //        gcDocumento.DataSource = mLista;
        //    }
        //}

        //private void CargarBusquedaDocumento()
        //{
        //    //Traemos la información del documento
        //    mLista = new DocumentoVentaBL().ListaSerieNumero(Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text, txtNumero.Text);
        //    gcDocumento.DataSource = mLista;
            
        //}

        //public void InicializarModificar()
        //{
        //    if (gvDocumento.RowCount > 0)
        //    {
        //        DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
        //        objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
        //        frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
        //        objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
        //        objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
        //        objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
        //        objRegFacturacionEdit.btnGrabar.Enabled = true;
        //        objRegFacturacionEdit.mnuContextual.Enabled = true;
        //        objRegFacturacionEdit.ShowDialog();

        //        Cargar();
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se pudo editar");
        //    }
        //}

        //private void FilaDoubleClick(GridView view, Point pt)
        //{
        //    GridHitInfo info = view.CalcHitInfo(pt);
        //    if (info.InRow || info.InRowCell)
        //    {
        //        if (gvDocumento.RowCount > 0)
        //        {
        //            DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
        //            objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
        //            frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
        //            objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
        //            objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
        //            objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
        //            objRegFacturacionEdit.btnGrabar.Enabled = false;
        //            objRegFacturacionEdit.mnuContextual.Enabled = false;
        //            objRegFacturacionEdit.ShowDialog();

        //            Cargar();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No se pudo editar");
        //        }
        //    }
        //}

        //private bool ValidarIngreso()
        //{
        //    bool flag = false;

        //    if (gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString() == "")
        //    {
        //        XtraMessageBox.Show("Seleccione un documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        flag = true;
        //    }

        //    Cursor = Cursors.Default;
        //    return flag;
        //}

        #endregion



    }
}