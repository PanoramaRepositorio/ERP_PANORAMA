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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManActualizaCodigoBarra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioBE> lst_InventarioMsg = new List<InventarioBE>();

        #endregion

        #region "Eventos"

        public frmManActualizaCodigoBarra()
        {
            InitializeComponent();
        }

        private void frmManActualizaCodigoBarra_Load(object sender, EventArgs e)
        {

        }

        #endregion

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

        #region "Metodos"

        private void ImportarExcel_Back(string filename)
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

                List<ProductoBE> mListaProducto = new List<ProductoBE>();

                //Recorremos para el detalle de la Factura
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    ProductoBE objE_Producto = new ProductoBE();
                   
                    objE_Producto.CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    objE_Producto.CodigoBarra = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                    mListaProducto.Add(objE_Producto);

                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                //Codigos de Barras Duplicados


                ProductoBL objBL_Producto = new ProductoBL();
                objBL_Producto.ActualizaCodigoBarra(mListaProducto);

                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                List<ProductoBE> mListaProducto = new List<ProductoBE>();

                //Recorremos para el detalle de la Factura
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    ProductoBE objE_Producto = new ProductoBE();

                    string CodigoProveedor = "";
                    string CodigoBarra = "";
                    CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    CodigoBarra = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();

                    objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(CodigoBarra); //Codigo de Barras de Importación

                    if (objE_Producto != null)
                    {
                        InventarioBE ObjE_Inventario = new InventarioBE();
                        ObjE_Inventario.CodigoProveedor = CodigoProveedor; //objE_Producto.CodigoProveedor;
                        ObjE_Inventario.Cantidad = 1;
                        ObjE_Inventario.Ubicacion = objE_Producto.CodigoBarra;
                        ObjE_Inventario.Observacion = "Existe_Con_" + objE_Producto.CodigoProveedor;
                        lst_InventarioMsg.Add(ObjE_Inventario);
                    }
                    else
                    {
                        ProductoBE objE_ProductoImporta = new ProductoBE();
                        objE_ProductoImporta.CodigoProveedor = CodigoProveedor; //(string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                        objE_ProductoImporta.CodigoBarra = CodigoBarra; // (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                        mListaProducto.Add(objE_ProductoImporta);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                //Codigos de Barras Duplicados

                ProductoBL objBL_Producto = new ProductoBL();
                objBL_Producto.ActualizaCodigoBarra(mListaProducto);

                if (mListaProducto.Count>0)
                XtraMessageBox.Show("La Importacion se realizó correctamente\n" + mListaProducto.Count +" Registros Actualizados" , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Código de barra existente
                if (lst_InventarioMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.Titulo = "Código de Barras Existentes";
                    frm.NombreArchivoExcel = "CodigoBarras_existentes";
                    frm.mLista = lst_InventarioMsg;
                    frm.ShowDialog();
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

        #endregion

        
    }
}