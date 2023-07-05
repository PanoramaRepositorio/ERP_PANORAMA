using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Principal;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmImportarInventarioVisual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"



        int _IdListaPrecio = 0;

        public int IdListaPrecio
        {
            get { return _IdListaPrecio; }
            set { _IdListaPrecio = value; }
        }

        public string DescListaPrecio = "";



        public int IdTienda { get; set; }
        public int IdBloque { get; set; }
        public int IdModulo { get; set; }

        public bool bHantag = false;


        #endregion

        #region "Eventos"
        public frmImportarInventarioVisual()
        {
            InitializeComponent();
        }

        private void frmImportarInventarioVisual_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = DescListaPrecio;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region "Metodos"

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

                List<InventarioVisualBE> mInventarioVisual = new List<InventarioVisualBE>();


                if (bHantag == false)
                {
                    //Recorremos para el detalle de la Factura
                    while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                    {
                        InventarioVisualBE objE_InventarioVisual = new InventarioVisualBE();
                        objE_InventarioVisual.IdTienda = IdTienda;
                        objE_InventarioVisual.IdBloque = IdBloque;
                        objE_InventarioVisual.IdModulo = IdModulo;
                        objE_InventarioVisual.Usuario = Parametros.strUsuarioLogin;
                        objE_InventarioVisual.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InventarioVisual.CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                        objE_InventarioVisual.IdProducto = 0;
                        //objE_InventarioVisual.FlagAutoservicio = Convert.ToBoolean((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());

                        mInventarioVisual.Add(objE_InventarioVisual);

                        prgFactura.PerformStep();
                        prgFactura.Update();

                        Row++;
                    }

                    InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                    objBL_InventarioVisual.ActualizaCodigo(mInventarioVisual);

                    XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Recorremos para el detalle de la Factura
                    while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                    {
                        InventarioVisualBE objE_InventarioVisual = new InventarioVisualBE();
                        objE_InventarioVisual.IdTienda = IdTienda;
                        objE_InventarioVisual.IdBloque = IdBloque;
                        objE_InventarioVisual.IdModulo = IdModulo;
                        objE_InventarioVisual.Usuario = Parametros.strUsuarioLogin;
                        objE_InventarioVisual.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InventarioVisual.CodigoProveedor = "";
                        objE_InventarioVisual.IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                        //objE_InventarioVisual.FlagAutoservicio = Convert.ToBoolean((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());

                        mInventarioVisual.Add(objE_InventarioVisual);

                        prgFactura.PerformStep();
                        prgFactura.Update();

                        Row++;
                    }

                    InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                    objBL_InventarioVisual.ActualizaCodigoIdProducto(mInventarioVisual);

                    XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }






                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarExcel(string filename)
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
                List<InventarioVisualBE> mInventarioVisual = new List<InventarioVisualBE>();
                mInventarioVisual = new InventarioVisualBL().ListaTodosActivo(1, 1);

                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;

                foreach (var item in mInventarioVisual)
                {
                    xlHoja.Cells[Row, "A"] = item.CodigoProveedor;

                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                xlLibro.Save();
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                this.Close();
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

    }
}