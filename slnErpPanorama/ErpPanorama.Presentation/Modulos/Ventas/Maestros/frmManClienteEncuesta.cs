using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteEncuesta : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"


        private List<EncuestaBE> mLista = new List<EncuestaBE>();

        #endregion

        #region "Eventos"

        public frmManClienteEncuesta()
        {
            InitializeComponent();
        }

        private void frmManClienteEncuesta_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteEncuesta";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }

        private void importarclientetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                Cargar();
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

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void toolstpEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de Eliminar la Encuesta del cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IdEncuesta = 0;
                    IdEncuesta = int.Parse(gvCliente.GetRowCellValue(gvCliente.FocusedRowHandle, "IdEncuesta").ToString());
                    EncuestaBL ObjBL_Encuesta = new EncuestaBL();
                    ObjBL_Encuesta.Elimina(IdEncuesta);

                    gvCliente.DeleteRow(gvCliente.FocusedRowHandle);
                    gvCliente.RefreshData();
                    lblTotal.Text = gvCliente.RowCount.ToString();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new EncuestaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCliente.DataSource = mLista;
            lblTotal.Text = mLista.Count().ToString() + " Registros Encontrados";
        }

        private void CargarBusqueda()
        {
            gcCliente.DataSource = mLista.Where(obj =>
                                                   obj.DescCliente.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
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

                List<EncuestaBE> mEncuesta = new List<EncuestaBE>();
                ClienteBE ObjE_Cliente = null;//Cliente
                string NumeroDocumento ="";

                //Recorremos para el detalle del cliente
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    EncuestaBE objE_Encuesta = new EncuestaBE();
                    NumeroDocumento = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();

                    ObjE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, NumeroDocumento);

                    if (ObjE_Cliente != null && ObjE_Cliente.IdTipoCliente == Parametros.intTipClienteFinal)
                    {
                        objE_Encuesta.IdCliente = ObjE_Cliente.IdCliente;
                        objE_Encuesta.NumeroDocumento = ObjE_Cliente.NumeroDocumento;
                        objE_Encuesta.FlagDescuento = false;
                        objE_Encuesta.FlagEstado = true;

                        mEncuesta.Add(objE_Encuesta);
                    }
                    else { 
                    
                    }

                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                EncuestaBL objBL_Encuesta = new EncuestaBL();
                objBL_Encuesta.InsertaLista(mEncuesta);

                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //this.Close();
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