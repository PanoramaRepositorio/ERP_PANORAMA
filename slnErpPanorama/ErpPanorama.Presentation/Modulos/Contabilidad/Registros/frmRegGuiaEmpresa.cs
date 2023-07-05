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
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Rpt;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    public partial class frmRegGuiaEmpresa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        #endregion

        #region "Eventos"

        public frmRegGuiaEmpresa()
        {
            InitializeComponent();
        }

        private void frmRegGuiaEmpresa_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();

            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegGuiaEmpresaEdit objManDocumentoVenta = new frmRegGuiaEmpresaEdit();
                objManDocumentoVenta.pOperacion = frmRegGuiaEmpresaEdit.Operacion.Nuevo;
                objManDocumentoVenta.IdDocumentoVenta = 0;
                objManDocumentoVenta.StartPosition = FormStartPosition.CenterParent;
                objManDocumentoVenta.ShowDialog();
                Cargar();
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
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                        objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));

                        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                        objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
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

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {

        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDocumentoVentasTraslado";
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

        private void vistapreliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {

                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    string dirFacturacion = "<No Especificado>";

                    if (objE_DocumentoVenta.IdEmpresa == Parametros.intIdPanoramaDistribuidores)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali;
                    }


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

                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaBL().ListaGuiaCliente(Convert.ToInt32(objE_DocumentoVenta.IdEmpresa), Convert.ToInt32(objE_DocumentoVenta.IdCliente), deDesde.DateTime, deHasta.DateTime);


//                    rptGuiaRemisionTrasladoPanorama objReporteGuia = new rptGuiaRemisionTrasladoPanorama();

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

                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptDocumento = new RptVistaReportes();
                        objRptDocumento.VerRptGuiaEmpresaTraslado(lstReporte, dirFacturacion, DirguiaRem);
                        objRptDocumento.ShowDialog();
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
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVentaTraslado)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListaCliente(Convert.ToInt32(objE_DocumentoVenta.IdEmpresa), Convert.ToInt32(objE_DocumentoVenta.IdCliente), deDesde.DateTime, deHasta.DateTime);

                        rptBoletaPanoramaTraslado objReporteGuia = new rptBoletaPanoramaTraslado();
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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVentaTraslado) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListaCliente(Convert.ToInt32(objE_DocumentoVenta.IdEmpresa), Convert.ToInt32(objE_DocumentoVenta.IdCliente), deDesde.DateTime, deHasta.DateTime);

                            rptFacturaPanoramaTraslado objReporteGuia = new rptFacturaPanoramaTraslado();
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

        private void imprimirundocumentotoolStripMenuItem_Click(object sender, EventArgs e)
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
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVentaTraslado)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                        rptBoletaPanoramaTraslado objReporteGuia = new rptBoletaPanoramaTraslado();
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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVentaTraslado) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptFacturaPanoramaTraslado objReporteGuia = new rptFacturaPanoramaTraslado();
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

        private void imprimirguiatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

                    string dirFacturacion = "<No Especificado>";

                    if (objE_DocumentoVenta.IdEmpresa == Parametros.intIdPanoramaDistribuidores)
                    {
                        dirFacturacion = Parametros.strDireccionUcayali;
                    }


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

 

                    #region "Guia Remisión - Boleta"
                 /*   if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        #region "Guia Remision Continuo por cliente"

                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
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
                            MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);

                        #endregion
                    }*/
                    #endregion

                    #region "Guia Remisión - Factura y Otros"
                    //else
                    //{
                        #region "Guia Remision Continuo por Cliente"

                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        //lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido));
                        lstReporte = new ReporteDocumentoVentaBL().ListaGuiaCliente(Convert.ToInt32(objE_DocumentoVenta.IdEmpresa), Convert.ToInt32(objE_DocumentoVenta.IdCliente), objE_DocumentoVenta.Fecha, objE_DocumentoVenta.Fecha);// deDesde.DateTime, deHasta.DateTime);

                        rptGuiaRemisionTrasladoPanorama objReporteGuia = new rptGuiaRemisionTrasladoPanorama();

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
                            MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    //}
                        #endregion
                }
                    #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirunaguiatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    //DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);

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

    
                    if (XtraMessageBox.Show("Esta seguro de Imprimir los documentos seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        prgFactura.Visible = true;
                        for (int j = 0; j < gvDocumento.SelectedRowsCount; j++)
                        {
                            //int IdDocumentoVenta = 0;

                            int row = gvDocumento.GetSelectedRows()[j];
                            int TotRow = gvDocumento.SelectedRowsCount;
                            TotRow = TotRow - row + 1;
                            prgFactura.Properties.Step = 1;
                            prgFactura.Properties.Maximum = TotRow;
                            prgFactura.Properties.Minimum = 0;

                            //IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());

                            DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(row);

                    #region "Guia Remisión - Boleta"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
                    {
                        #region "Guia Remision desglosable Documento"
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                        rptGuiaRemisionTrasladoPanorama objReporteGuia = new rptGuiaRemisionTrasladoPanorama();

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

                        rptGuiaRemisionTrasladoPanorama objReporteGuia = new rptGuiaRemisionTrasladoPanorama();

                        #region "Direccion"
                        frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                        frm.ShowDialog();
                        String DirguiaRem = "";
                        DirguiaRem = objE_DocumentoVenta.Direccion;

                        //if (frm.DireccionGuiaPrint == "")
                        //{
                        //    DirguiaRem = objE_DocumentoVenta.Direccion;
                        //}
                        //else
                        //{
                        //    DirguiaRem = frm.DireccionGuiaPrint;
                        //}
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

                    prgFactura.PerformStep();
                    prgFactura.Update();

                        }
                        //gvDocumento.DeleteRow(gvDocumento.FocusedRowHandle);
                        //gvDocumento.RefreshData();
                        XtraMessageBox.Show("se imprimió los documentos correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        prgFactura.Visible = false;
                        Cargar();

                    }


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

                    //-------------


                    #region "Boleta continua"
                    if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaVentaTraslado)
                    {
                        List<ReporteDocumentoVentaBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                        rptBoletaPanoramaTraslado objReporteGuia = new rptBoletaPanoramaTraslado();
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
                        if ((objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaVentaTraslado) && (objE_DocumentoVenta.IdEmpresa == Parametros.intPanoraramaDistribuidores))//Factura Panorama Continua
                        {
                            List<ReporteDocumentoVentaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            rptFacturaPanoramaTraslado objReporteGuia = new rptFacturaPanoramaTraslado();
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

                        #region "Otros"
                        else
                        {
                            XtraMessageBox.Show("No disponible para este documento, opción accesible para Boleta,Factura y Nota de Crédito", "Impresión Documento Continuo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        #endregion



                    //--Desde
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

                    string Serie = "";
                    string Numero = "";

                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    //Serie = gvDocumento.GetRowCellValue(row, "Serie").ToString();

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
                    if (i == 0)
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

            //frmEstablecerNumero objDescuento = new frmEstablecerNumero();
            //objDescuento.StartPosition = FormStartPosition.CenterParent;
            //if (objDescuento.ShowDialog() == DialogResult.OK)
            //{
            //    int Num = 0;
            //    for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
            //    {
            //        int IdEmpresa = 0;
            //        int IdDocumentoVenta = 0;
            //        string Serie = "";
            //        string Numero = "";

            //        int row = gvDocumento.GetSelectedRows()[i];
            //        IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
            //        IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
            //        Serie = gvDocumento.GetRowCellValue(row, "Serie").ToString();

            //        if (i == 0)
            //        {
            //            Num = objDescuento.Numero;
            //        }

            //        DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
            //        DocumentoVentaBE objE_Documento = new DocumentoVentaBE();

            //        objE_Documento.IdEmpresa = IdEmpresa;
            //        objE_Documento.IdDocumentoVenta = IdDocumentoVenta;
            //        objE_Documento.Serie = Serie;
            //        Numero = FuncionBase.AgregarCaracter(Num.ToString(), "0", 6);
            //        objE_Documento.Numero = Numero;
            //        objBL_Documento.ActualizaNumeroSerie(objE_Documento);

            //        Num++;
            //    }
            //}

            ////CargarBusqueda();
            Cargar();
        }

        private void cambiarrazonsocialtoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DocumentoVentaBL().ListaGuiaEmpresaTraslado(0, deDesde.DateTime, deHasta.DateTime);
            gcDocumento.DataSource = mLista;
        }


        public void InicializarModificar()
        {
            if (gvDocumento.RowCount > 0)
            {
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
                objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                frmRegFacturacionEmpresaRegistroEdit objRegFacturacionEdit = new frmRegFacturacionEmpresaRegistroEdit();
                objRegFacturacionEdit.pOperacion = frmRegFacturacionEmpresaRegistroEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                //objRegFacturacionEdit.btnGrabar.Enabled = true;
                //objRegFacturacionEdit.mnuContextual.Enabled = true;
                objRegFacturacionEdit.ShowDialog();

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

        #endregion


    }
}