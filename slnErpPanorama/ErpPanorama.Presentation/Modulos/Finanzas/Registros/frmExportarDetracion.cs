using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraGrid.Columns;
using System.IO;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmExportarDetracion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<CuentaPorPagarBE> mLista2 = new List<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList2 = new BindingList<CuentaPorPagarBE>();
        public enum Operacion
        {
            Excel = 1,
            Texto = 2
        }

        Int32 Situacion = 0;
        String IndiceBloque = "";
        public Operacion pOperacion { get; set; }
        #endregion

        #region "Eventos"
        public frmExportarDetracion()
        {
            InitializeComponent();
        }

        private void frmExportarDetracion_Load(object sender, EventArgs e)
        {

            if (pOperacion == Operacion.Excel)
            {
                this.Text = "Exportar Excel";
            }
            else if (pOperacion == Operacion.Texto)
            {
                this.Text = "Exportar Texto";
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (txtLote.Text != "")
            {
                try
                {
                    //Situacion = 404;
                    Situacion = Parametros.intSitAplicadoCon;
                    IndiceBloque = txtLote.Text;

                    Cargar2(Situacion, IndiceBloque);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (gridView1.DataRowCount != 0)
                    {
                        if (pOperacion == Operacion.Excel)
                        {
                            ExportarExcel();
                        }
                        else if (pOperacion == Operacion.Texto)
                        {
                            ExportarTxt();
                        }

                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("No existe el lote de detraccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Ingrese el lote de detracciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnExportar.Focus();
            }
        }
        #endregion

        #region "Metodos"
        private void Cargar2(Int32 pIdSituacion, String pIndiceBloque)
        {
            // EDGAR 260123: AGREGAR LISTADO DE CUENTAS POR PAGAR SEGUN SITUACION -->
            mLista2 = new CuentaPorPagarBL().ListaPorBloque(pIndiceBloque);
            supList2 = new BindingList<CuentaPorPagarBE>(mLista2);
            if (supList2.Count == 0)
            {
                XtraMessageBox.Show("No hay detracciones en el lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                gridControl1.DataSource = supList2;
            }
            //
        }

        private void ExportarTxt()
		{
            Decimal totalImporte = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                 totalImporte += Decimal.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
            }

            String txtfile = "";
			txtfile += "*20330676826PANORAMA DISTRIBUIDORES S.A.";
            txtfile += "\t";
            txtfile += IndiceBloque;
            txtfile += FuncionBase.AgregarCaracter(totalImporte.ToString().Replace(".", String.Empty).Replace(",", String.Empty), "0", 15);
            txtfile += "\n";

			for (int i = 0; i < gridView1.RowCount; i++)
            {
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString();
                txtfile += "\t\t\t\t\t";
                txtfile += "000000000";
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString();
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString();
                txtfile += FuncionBase.AgregarCaracter(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString().Replace(".", String.Empty), "0", 15);
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString();
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[9]).ToString();
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString();
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString();
                txtfile += gridView1.GetRowCellValue(i, gridView1.Columns[12]).ToString();
                txtfile += "\n";
            }

            byte[] byteArray = Convert.FromBase64String(EncodeTo64(txtfile));
            MemoryStream ms = new MemoryStream(byteArray);

            try
            {
                WriteFile(ms);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al guardar el archivo \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
		}

        private void ExportarExcel ()
        {

            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "D" + "20330676826" + IndiceBloque;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                foreach (GridColumn column in gridView1.Columns)
                {
                    column.Visible = true;
                }
                gridView1.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        public void WriteFile(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            string _msg = "Se genero el archivo de texto de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "D" + "20330676826" + IndiceBloque;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);

            String path = f.SelectedPath + @"\" + _fileName + ".txt";
            using (var fs = new FileStream(path, FileMode.Create))
            {
                try
                {
                    stream.CopyTo(fs);
                    string _nM = string.Format(_msg, path);
                    XtraMessageBox.Show(_nM, "Exportar lote", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error al generar el archivo \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        #endregion
    }
}