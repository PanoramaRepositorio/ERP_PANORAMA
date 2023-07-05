using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Principal;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid.Views.Grid;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmImportarClasificacionProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Metodos"
        List<ProductoBE> mLista;
        List<ProductoBE> mListaRapida;

        #endregion

        public frmImportarClasificacionProducto()
        {
            InitializeComponent();
        }

        private void frmImportarClasificacionProducto_Load(object sender, EventArgs e)
        {
            Parametros.pListaUnidadMedida = new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId);
            
        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
            }

            #region "Segunda"
            //Mod2
            //string cod;
            //string nom;
            //string uni;
            //Decimal? pes;
            //string mar;
            //string med;
            //string prc;
            //string mat;
            //string lin;
            //string mod;
            //ofdXls.Filter = "Solo Archivos Excel(*.xls,*.xlsx)|*.xls;*.xlsx";
            //ofdXls.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //ofdXls.ShowDialog();
            //if (ofdXls.FileName.Trim() != "")
            //{
            //    txtDirectorio.Text = ofdXls.FileName.Substring(ofdXls.FileName.LastIndexOf('\\') + 1);
            //    txtDirectorio.Tag = ofdXls.FileName;
            //    Limpiar();

            //    try
            //    {
            //        this.Cursor = Cursors.WaitCursor;

            //        //mlis
            //        FileStream s = File.Open(ofdXls.FileName, FileMode.Open, FileAccess.Read);

            //        IExcelDataReader er = ExcelReaderFactory.CreateBinaryReader(s);
            //        er.IsFirstRowAsColumnNames = true;
            //        er.Read();

            //        while (er.Read())
            //        {
            //            if (er.GetString(0) != null)
            //            {
            //                #region Código
            //                cod = er.GetString(0).Trim();
            //                txtDirectorio.Tag = cod;
            //                #endregion

            //                #region Nombre
            //                if (er.GetString(1) == null)
            //                { nom = null; }
            //                else
            //                { nom = er.GetString(1).Trim(); }
            //                #endregion

            //                #region Unidad
            //                if (er.GetString(2) == null)
            //                { uni = null; }
            //                else
            //                { uni = er.GetString(2).Trim(); }
            //                #endregion

            //                #region Peso
            //                if (er.GetString(3) == null)
            //                { pes = null; }
            //                else
            //                { pes = Convert.ToDecimal(er.GetString(3).Trim()); }
            //                #endregion

            //                #region Medida
            //                if (er.GetString(4) == null)
            //                { med = null; }
            //                else
            //                { med = er.GetString(4).Trim(); }
            //                #endregion

            //                #region Marca
            //                if (er.GetString(5) == null)
            //                { mar = null; }
            //                else
            //                { mar = er.GetString(5).Trim(); }
            //                #endregion

            //                #region Procedencia
            //                if (er.GetString(6) == null)
            //                { prc = null; }
            //                else
            //                { prc = er.GetString(6).Trim(); }
            //                #endregion

            //                #region Material
            //                if (er.GetString(7) == null)
            //                { mat = null; }
            //                else
            //                { mat = er.GetString(7).Trim(); }
            //                #endregion

            //                #region Linea
            //                if (er.GetString(8) == null)
            //                { lin = null; }
            //                else
            //                { lin = er.GetString(8).Trim(); }
            //                #endregion

            //                #region Modelo
            //                if (er.GetString(9) == null)
            //                { mod = null; }
            //                else
            //                { mod = er.GetString(9).Trim(); }
            //                #endregion

            //                //List<ProductoBE> o = new List<ProductoBE>(cod, nom, uni, pes, med, mar, prc, mat, lin, mod);
            //                m_Lis.Add(o);
            //            }
            //        }
            //        er.Close();
            //        //prdBinding.DataSource = m_Lis;
            //        dgProducto.DataSource = 
            //        dgProducto.RefreshData();
            //        Contar(m_Lis.Count);
            //        btnDirectorio.Enabled = false;
            //        btnValida.Enabled = true;
            //        this.Cursor = Cursors.Arrow;
            //    }
            //    catch (Exception ex)
            //    {
                    
            //        Cursor = Cursors.Default;
            //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //this.Cursor = Cursors.Arrow;
            //        //Excepcion.LanzarError(ex);
            //    }
            //}
            #endregion

        }

        private void Limpiar() { 
            
        }
        private void Contar(int c)
        {
            countToolStripStatusLabel.Text = " " + c.ToString() + " Items Localizados";
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            
            if (mLista == null) {
                MessageBox.Show("Existen Códigos con datos incorrectos. Verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("¿ Desea Actualizar los Códigos? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    //foreach (DataGridViewRow r in gvProducto.SelectRows)
                    foreach (ProductoBE item in mLista)
                    {
                            ProductoBL objBL_Producto = new ProductoBL();
                            objBL_Producto.ActualizaClasificacion(item);
                    }

                    XtraMessageBox.Show("La importación se generó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                //Creamos la lista
                List<ProductoBE> mListaProducto = new List<ProductoBE>();

                //Cargamos Toda la información de l
                List<MarcaBE> objE_Marca = new List<MarcaBE>();
                objE_Marca = new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId);

                List<ProcedenciaBE> objE_Procedencia = new List<ProcedenciaBE>();
                objE_Procedencia = new ProcedenciaBL().ListaTodosActivo(Parametros.intEmpresaId);

                List<MaterialBE> objE_Material = new List<MaterialBE>();
                objE_Material = new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId);

                List<FamiliaProductoBE> objE_FamiliaProducto = new List<FamiliaProductoBE>();
                objE_FamiliaProducto = new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                List<LineaProductoBE> objE_LineaProducto = new List<LineaProductoBE>();
                objE_LineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                List<SubLineaProductoBE> objE_SubLineaProducto = new List<SubLineaProductoBE>();
                objE_SubLineaProducto = new SubLineaProductoBL().ListaTodos(Parametros.intEmpresaId, 0);

                List<ModeloProductoBE> objE_ModeloProducto = new List<ModeloProductoBE>();
                objE_ModeloProducto = new ModeloProductoBL().ListaTodos(Parametros.intEmpresaId, 0,0);


                //Contador de Registros
                while ((string)xlHoja.get_Range("B" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("B" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;
                int Contador = 0;
                int ConError = 0;

                //Recorremos
                while ((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string Peso = "0";
                    ProductoBE objE_Producto = new ProductoBE();
                    objE_Producto.IdProducto = 0;
                    objE_Producto.FlagEstado = true;
                    objE_Producto.CodigoProveedor = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                    objE_Producto.NombreProducto = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    foreach (UnidadMedidaBE item in Parametros.pListaUnidadMedida)
                    {
                        if (item.Abreviatura == (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim())
                        {
                            objE_Producto.IdUnidadMedida = item.IdUnidadMedida;
                            objE_Producto.Abreviatura = item.Abreviatura;
                        }
                    }

                    objE_Producto.Descripcion = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();

                    //objE_Producto.Peso =  Convert.ToDecimal((string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim());
                    Peso = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();
                    if(Peso == "")
                        objE_Producto.Peso = 0;
                    else
                        objE_Producto.Peso =  Convert.ToDecimal((string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim());

                    //Medida
                    objE_Producto.Medida = (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim();

                    //Marca
                    //List<MarcaBE> objE_Marca = new List<MarcaBE>();
                    //objE_Marca = new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId);

                    foreach (MarcaBE item in objE_Marca)
                    {
                        if (item.DescMarca == (string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim())
                        {
                            objE_Producto.IdMarca = item.IdMarca;
                            objE_Producto.DescMarca = item.DescMarca;
                        }
                    }

                    //Pocedencia
                    //List<ProcedenciaBE> objE_Procedencia = new List<ProcedenciaBE>();
                    //objE_Procedencia = new ProcedenciaBL().ListaTodosActivo(Parametros.intEmpresaId);

                    foreach (ProcedenciaBE item in objE_Procedencia)
                    {
                        if (item.DescProcedencia == (string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim())
                        {
                            objE_Producto.IdProcedencia = item.IdProcedencia;
                            objE_Producto.DescProcedencia = item.DescProcedencia;
                        }
                    }

                    //Material
                    //List<MaterialBE> objE_Material = new List<MaterialBE>();
                    //objE_Material = new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId);

                    foreach (MaterialBE item in objE_Material)
                    {
                        if (item.DescMaterial == (string)xlHoja.get_Range("J" + Row, Missing.Value).Text.ToString().Trim())
                        {
                            objE_Producto.IdMaterial = item.IdMaterial;
                            objE_Producto.DescMaterial = item.DescMaterial;
                        }
                    }

                    //Familia
                    //List<FamiliaProductoBE> objE_FamiliaProducto = new List<FamiliaProductoBE>();
                    //objE_FamiliaProducto = new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                    foreach (FamiliaProductoBE item in objE_FamiliaProducto)
                    {
                        if (item.DescFamiliaProducto == (string)xlHoja.get_Range("K" + Row, Missing.Value).Text.ToString().Trim())
                        {
                            objE_Producto.IdFamiliaProducto = item.IdFamiliaProducto;
                            objE_Producto.DescFamiliaProducto = item.DescFamiliaProducto;
                        }
                    }

                    //LineaProducto
                    //List<LineaProductoBE> objE_LineaProducto = new List<LineaProductoBE>();
                    //objE_LineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                    foreach (LineaProductoBE item in objE_LineaProducto)
                    {
                        if (item.DescLineaProducto == (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim())
                        {
                            objE_Producto.IdLineaProducto = item.IdLineaProducto;
                            objE_Producto.DescLineaProducto = item.DescLineaProducto;
                        }
                    }

                    //SubLineaProducto
                    //List<SubLineaProductoBE> objE_SubLineaProducto = new List<SubLineaProductoBE>();
                    //objE_SubLineaProducto = new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(objE_Producto.IdLineaProducto));

                    string DescSubLinea = (string)xlHoja.get_Range("M" + Row, Missing.Value).Text.ToString().Trim();
                    if (DescSubLinea.Length > 0)
                    {
                        foreach (SubLineaProductoBE item in objE_SubLineaProducto)
                        {
                            //if (item.DescSubLineaProducto == (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim())
                            //if (item.DescSubLineaProducto == (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim() && item.DescLineaProducto == objE_Producto.DescLineaProducto)
                            if (item.DescSubLineaProducto == DescSubLinea && item.IdLineaProducto == objE_Producto.IdLineaProducto)
                            {
                                objE_Producto.IdSubLineaProducto = item.IdSubLineaProducto;
                                objE_Producto.DescSubLineaProducto = item.DescSubLineaProducto;
                            }
                        }               
                    }


                    //ModeloProducto
                    //List<ModeloProductoBE> objE_ModeloProducto = new List<ModeloProductoBE>();
                    //objE_ModeloProducto = new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(objE_Producto.IdLineaProducto), Convert.ToInt32(objE_Producto.IdSubLineaProducto));

                    string DescModelo = (string)xlHoja.get_Range("N" + Row, Missing.Value).Text.ToString().Trim();

                    if (DescModelo.Length > 0)
                    {
                        foreach (ModeloProductoBE item in objE_ModeloProducto)
                        {
                            if (item.DescModeloProducto == DescModelo && item.DescLineaProducto == objE_Producto.DescLineaProducto && item.DescSubLineaProducto == objE_Producto.DescSubLineaProducto)
                            {
                                objE_Producto.IdModeloProducto = item.IdModeloProducto;
                                objE_Producto.DescModeloProducto = item.DescModeloProducto;
                            }
                        }                 
                    }

                    objE_Producto.Coleccion = (string)xlHoja.get_Range("P" + Row, Missing.Value).Text.ToString().Trim();


                    //verificar datos
                    Contador = Contador + 1;

                    if (objE_Producto.IdUnidadMedida == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }
                    if (objE_Producto.IdMarca == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }
                    if (objE_Producto.IdProcedencia == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }
                    if (objE_Producto.IdMaterial == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }

                    if (objE_Producto.IdFamiliaProducto == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }

                    if (objE_Producto.IdLineaProducto == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }
                    if (objE_Producto.IdModeloProducto == null)
                    {
                        objE_Producto.FlagEstado = false;
                        ConError = ConError + 1;
                    }

                    tssCantidadtoolStripStatus.Text = Contador.ToString() + " Items  |  " + ConError.ToString() + " Errores";

                    mListaProducto.Add(objE_Producto);

                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                gcProducto.RefreshDataSource();
                gcProducto.DataSource = mListaProducto;
                if (ConError == 0)
                {
                    mLista = mListaProducto;
                }
                //lista Rápida
                mListaRapida = mListaProducto;


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

        private void gvProducto_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                object obj = gvProducto.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocProducto = View.GetRowCellValue(e.RowHandle, View.Columns["FlagEstado"]);
                    if (objDocProducto != null) {
                        
                        bool bEstado = Convert.ToBoolean(objDocProducto);
                        if (bEstado == false) {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;                        
                        }
                   }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcesoRapido_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Desea Actualizar todos los Códigos de esta lista? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    //foreach (DataGridViewRow r in gvProducto.SelectRows)
                    foreach (ProductoBE item in mListaRapida)
                    {
                        ProductoBL objBL_Producto = new ProductoBL();
                        objBL_Producto.ActualizaClasificacion(item);
                    }
                    mListaRapida.Clear();//limpiar

                    XtraMessageBox.Show("La importación se generó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}