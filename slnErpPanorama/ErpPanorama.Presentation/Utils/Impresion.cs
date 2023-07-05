using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace ErpPanorama.Presentation.Utils
{
    public class Impresion
    {
        public static void Imprimir(ReportDocument report, string impresora, int nCopies, int startPage, int endPage, PaperSize paperSize)
        {
            report.PrintOptions.PrinterName = impresora;
            report.PrintOptions.PaperSize = paperSize;
            report.PrintToPrinter(nCopies, false, startPage, endPage);
        }
    }
}
