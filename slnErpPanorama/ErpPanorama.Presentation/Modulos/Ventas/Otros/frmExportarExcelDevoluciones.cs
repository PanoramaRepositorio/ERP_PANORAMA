using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmExportarExcelDevoluciones : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CambioBE> mLista = new List<CambioBE>();
        
        #endregion

        #region "Eventos"

        public frmExportarExcelDevoluciones()
        {
            InitializeComponent();
        }

        private void frmExportarExcelDevoluciones_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            mLista = new CambioBL().Lista(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            if (mLista.Count == 0)
            {
                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                ExportToExcel();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        public void ExportToExcel()
        {

            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            //Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            //ws.Range["A1:L1"].Font.Bold = true;

            //ws.Cells[1, 1] = "Empresa";
            //ws.Cells[1, 2] = "Tienda";
            //ws.Cells[1, 3] = "N° Devolución";
            //ws.Cells[1, 4] = "Fecha";
            //ws.Cells[1, 5] = "N° Pedido";
            //ws.Cells[1, 6] = "N° Documento Venta";
            //ws.Cells[1, 7] = "Cliente";
            //ws.Cells[1, 8] = "Moneda";
            //ws.Cells[1, 9] = "Total";
            //ws.Cells[1, 10] = "Aprobado";
            //ws.Cells[1, 11] = "Recibido";
            //ws.Cells[1, 12] = "N° Nota Crédito";

            //int i = 2;

            //foreach (var item in mLista)
            //{
            //    ws.Cells[i, 1] = item.RazonSocial;
            //    ws.Cells[i, 2] = item.DescTienda;
            //    ws.Cells[i, 3] = item.Numero;
            //    ws.Cells[i, 4] = item.Fecha.ToShortDateString();
            //    ws.Cells[i, 5] = item.NumeroPedido;
            //    ws.Cells[i, 6] = item.NumeroDocumentoVenta;
            //    ws.Cells[i, 7] = item.DescCliente;
            //    ws.Cells[i, 8] = item.CodMoneda;
            //    ws.Cells[i, 9] = item.Total;
            //    ws.Cells[i, 10] = item.FlagAprobado;
            //    ws.Cells[i, 11] = item.FlagRecibido;
            //    ws.Cells[i, 12] = item.NumeroNotaCredito;

            //    i = i + 1;
            //}

            

            //wb.SaveAs("ListaDevoluciones.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //wb.Close(false, Type.Missing, Type.Missing);
            ////app.Quit();

        }


        #endregion

        
        
    }
}