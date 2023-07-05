using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManActualizaListaPrecioEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        int _IdListaPrecio = 0;

        public int IdListaPrecio
        {
            get { return _IdListaPrecio; }
            set { _IdListaPrecio = value; }
        }

        public string DescListaPrecio = "";

        #endregion

        #region "Eventos"

        public frmManActualizaListaPrecioEdit()
        {
            InitializeComponent();
        }

        private void frmManActualizaListaPrecioEdit_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = DescListaPrecio;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(chkMayorista.Checked==false && chkMinorista.Checked==false)
            {
                XtraMessageBox.Show("Seleccionar el tipo de Cliente, Mayorista AB y Final CD\nSi los productos son nuevos seleccionar AB y CD.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xls;*.csv";
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

                List<ListaPrecioDetalleBE> mListaPrecioDetalle = new List<ListaPrecioDetalleBE>();

                //Recorremos para el detalle de la Factura
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {

                    ListaPrecioDetalleBE objE_ListaPrecioDetalle = new ListaPrecioDetalleBE();
                    objE_ListaPrecioDetalle.IdListaPrecio = IdListaPrecio;
                    objE_ListaPrecioDetalle.CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    objE_ListaPrecioDetalle.IdProducto = 0;

                    if (chkMinorista.Checked)
                        objE_ListaPrecioDetalle.PrecioCD = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    else
                        objE_ListaPrecioDetalle.PrecioCD = 0;
                    if (chkMayorista.Checked)
                        objE_ListaPrecioDetalle.PrecioAB = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    else
                        objE_ListaPrecioDetalle.PrecioAB = 0;

                    //objE_ListaPrecioDetalle.PrecioCD = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //objE_ListaPrecioDetalle.PrecioAB = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    ////objE_ListaPrecioDetalle.PrecioAB = Convert.ToDecimal((string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim());
                    ////objE_ListaPrecioDetalle.PrecioCD = Convert.ToDecimal((string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim());
                    objE_ListaPrecioDetalle.Descuento = Convert.ToDecimal((string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim());
                    objE_ListaPrecioDetalle.TipoCambioCD = Convert.ToDecimal((string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim());
                    objE_ListaPrecioDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_ListaPrecioDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_ListaPrecioDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objE_ListaPrecioDetalle.FlagEstado = true;

                    //if(objE_ListaPrecioDetalle.PrecioCD ==0)disable 140120
                    //{
                    //    XtraMessageBox.Show("El precio de venta Ingresado para el código " + objE_ListaPrecioDetalle.CodigoProveedor + " es incorrecto, Por favor verificar.\nSi Ud. desea realizar una venta con precio(0), debe ingresar el precio que corresponde y 100% de Descuento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}

                    mListaPrecioDetalle.Add(objE_ListaPrecioDetalle);

                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                objBL_ListaPrecioDetalle.ActualizaMasivo(mListaPrecioDetalle,chkTodo.Checked);

                //if (chkTodo.Checked)
                //{
                //    List<ListaPrecioBE> lst_ListaPrecio = new List<ListaPrecioBE>();
                //    lst_ListaPrecio = new ListaPrecioBL().ListaTodosActivo(Parametros.intEmpresaId, 0);

                //    foreach (var item in lst_ListaPrecio)
                //    {
                //        ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                //        objBL_ListaPrecioDetalle.ActualizaMasivo(mListaPrecioDetalle, item.IdListaPrecio);
                //    }
                //}
                //else
                //{
                //    ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                //    objBL_ListaPrecioDetalle.ActualizaMasivo(mListaPrecioDetalle, IdListaPrecio); 
                //}


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

        #endregion
   
    }
}