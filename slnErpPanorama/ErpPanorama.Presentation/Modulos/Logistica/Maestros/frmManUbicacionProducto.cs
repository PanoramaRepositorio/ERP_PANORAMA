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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManUbicacionProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PreventaDetalleBE> lst_ProductoIncentivadoDetalleMsg = new List<PreventaDetalleBE>();

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        
        #endregion

        #region "Eventos"

        public frmManUbicacionProducto()
        {
            InitializeComponent();
        }

        private void frmManUbicacionProducto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();
            if (gvProducto.RowCount > 0)
                gvProducto.BestFitColumns();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManUbicacionProductoEdit objManUbicacionProducto = new frmManUbicacionProductoEdit();
                objManUbicacionProducto.pOperacion = frmManUbicacionProductoEdit.Operacion.Nuevo;
                objManUbicacionProducto.IdUbicacionProducto = 0;
                objManUbicacionProducto.StartPosition = FormStartPosition.CenterParent;
                objManUbicacionProducto.ShowDialog();
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
                        UbicacionProductoBE objE_UbicacionProducto = new UbicacionProductoBE();
                        objE_UbicacionProducto.IdUbicacionProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdUbicacionProducto").ToString());
                        objE_UbicacionProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_UbicacionProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_UbicacionProducto.IdEmpresa = Parametros.intEmpresaId;

                        UbicacionProductoBL objBL_UbicacionProducto = new UbicacionProductoBL();
                        objBL_UbicacionProducto.Elimina(objE_UbicacionProducto);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteUbicacionProductoBE> lstReporte = null;
                lstReporte = new ReporteUbicacionProductoBL().Listado();

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptUbicacionProducto = new RptVistaReportes();
                        objRptUbicacionProducto.VerRptUbicacionProducto(lstReporte);
                        objRptUbicacionProducto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoUbicacionProducto";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.ToString().Length > 2)
            {
                CargarBusqueda();
            }
            
        }

        private void gvProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            gcProducto.DataSource = new UbicacionProductoBL().SeleccionaBusqueda(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtDescripcion.Text, pagina, registros);
        }

        private void CargarBusqueda()
        {
            gcProducto.DataSource = new UbicacionProductoBL().SeleccionaBusqueda(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina);
            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            intRowCount = new UbicacionProductoBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtDescripcion.Text);
            return intRowCount;
        }

        public void InicializarModificar()
        {
            if (gvProducto.RowCount > 0)
            {
                UbicacionProductoBE objUbicacionProducto = new UbicacionProductoBE();
                objUbicacionProducto.IdUbicacionProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdUbicacionProducto").ToString());
                objUbicacionProducto.IdTienda = int.Parse(gvProducto.GetFocusedRowCellValue("IdTienda").ToString());
                objUbicacionProducto.IdAlmacen = int.Parse(gvProducto.GetFocusedRowCellValue("IdAlmacen").ToString());
                objUbicacionProducto.DescAlmacen = gvProducto.GetFocusedRowCellValue("DescAlmacen").ToString();
                objUbicacionProducto.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                objUbicacionProducto.CodigoProveedor = gvProducto.GetFocusedRowCellValue("CodigoProveedor").ToString();
                objUbicacionProducto.NombreProducto = gvProducto.GetFocusedRowCellValue("NombreProducto").ToString();
                objUbicacionProducto.Abreviatura = gvProducto.GetFocusedRowCellValue("Abreviatura").ToString();
                objUbicacionProducto.DescUbicacion = gvProducto.GetFocusedRowCellValue("DescUbicacion").ToString();
                objUbicacionProducto.FlagEstado = Convert.ToBoolean(gvProducto.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManUbicacionProductoEdit objManUbicacionProductoEdit = new frmManUbicacionProductoEdit();
                objManUbicacionProductoEdit.pOperacion = frmManUbicacionProductoEdit.Operacion.Modificar;
                objManUbicacionProductoEdit.IdUbicacionProducto = objUbicacionProducto.IdUbicacionProducto;
                objManUbicacionProductoEdit.pUbicacionProductoBE = objUbicacionProducto;
                objManUbicacionProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManUbicacionProductoEdit.ShowDialog();

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

            if (gvProducto.GetFocusedRowCellValue("IdUbicacionProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una ubicación de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void importarporcodigotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                //Cargar();
            }
        }

        private void importarporhangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcelHangTag(_file_excel);
                //Cargar();
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


                //Recorremos los códigos de ProductoIncentivado
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    string Ubicacion = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                    //int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedorInventario(CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        UbicacionProductoBL objBL_UbicacionProducto = new UbicacionProductoBL();
                        
                        List<UbicacionProductoBE> lstUbicacionProducto = new List<UbicacionProductoBE>();
                        lstUbicacionProducto = new UbicacionProductoBL().ListaCodigo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, objE_Producto.IdProducto);

                        if (lstUbicacionProducto.Count > 0)//Existe
                        {
                            if (Ubicacion.Length > 0)
                            {
                                foreach (var item in lstUbicacionProducto)
                                {
                                    UbicacionProductoBE objE_Ubicacion = new UbicacionProductoBE();
                                    objE_Ubicacion.IdUbicacionProducto = item.IdUbicacionProducto;
                                    objE_Ubicacion.IdAlmacen = item.IdAlmacen;
                                    objE_Ubicacion.IdProducto = item.IdProducto;
                                    objE_Ubicacion.DescUbicacion = Ubicacion;//item.DescUbicacion;
                                    objE_Ubicacion.FlagEstado = true;
                                    objE_Ubicacion.Usuario = Parametros.strUsuarioLogin;
                                    objE_Ubicacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_Ubicacion.IdEmpresa = Parametros.intEmpresaId;

                                    objBL_UbicacionProducto.Actualiza(objE_Ubicacion);
                                }                            
                            }
                        }
                        else
                        {
                            if (Ubicacion.Length > 0)
                            {
                                UbicacionProductoBE objE_Ubicacion = new UbicacionProductoBE();
                                objE_Ubicacion.IdUbicacionProducto = 0;
                                objE_Ubicacion.IdAlmacen = Parametros.intAlmCentralUcayali;
                                objE_Ubicacion.IdProducto = objE_Producto.IdProducto;
                                objE_Ubicacion.DescUbicacion = Ubicacion;//item.DescUbicacion;
                                objE_Ubicacion.FlagEstado = true;
                                objE_Ubicacion.Usuario = Parametros.strUsuarioLogin;
                                objE_Ubicacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_Ubicacion.IdEmpresa = Parametros.intEmpresaId;

                                objBL_UbicacionProducto.Inserta(objE_Ubicacion);
                            }
                        }
                    }
                    else
                    {
                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_ProductoIncentivadoDetalle = new PreventaDetalleBE();
                        ObjE_ProductoIncentivadoDetalle.CodigoProveedor = CodigoProveedor;
                        //ObjE_ProductoIncentivadoDetalle.Cantidad = Cantidad;
                        lst_ProductoIncentivadoDetalleMsg.Add(ObjE_ProductoIncentivadoDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }
                //lblTotalRegistros.Text = gvProductoIncentivadoDetalle.RowCount.ToString() + " Registros";
                //CalculaTotales();

                if (lst_ProductoIncentivadoDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_ProductoIncentivadoDetalleMsg;
                    frm.ShowDialog();
                }

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

        private void ImportarExcelHangTag(string filename)
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


                //Recorremos los códigos de ProductoIncentivado
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    string Ubicacion = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        UbicacionProductoBL objBL_UbicacionProducto = new UbicacionProductoBL();

                        List<UbicacionProductoBE> lstUbicacionProducto = new List<UbicacionProductoBE>();
                        lstUbicacionProducto = new UbicacionProductoBL().ListaCodigo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, objE_Producto.IdProducto);

                        if (lstUbicacionProducto.Count >0)//Existe
                        {
                            if (Ubicacion.Length > 0)
                            {
                                foreach (var item in lstUbicacionProducto)
                                {
                                    UbicacionProductoBE objE_Ubicacion = new UbicacionProductoBE();
                                    objE_Ubicacion.IdUbicacionProducto = item.IdUbicacionProducto;
                                    objE_Ubicacion.IdAlmacen = item.IdAlmacen;
                                    objE_Ubicacion.IdProducto = item.IdProducto;
                                    objE_Ubicacion.DescUbicacion = Ubicacion;//item.DescUbicacion;
                                    objE_Ubicacion.FlagEstado = true;
                                    objE_Ubicacion.Usuario = Parametros.strUsuarioLogin;
                                    objE_Ubicacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_Ubicacion.IdEmpresa = Parametros.intEmpresaId;

                                    objBL_UbicacionProducto.Actualiza(objE_Ubicacion);
                                }
                            }
                        }
                        else
                        {
                            if (Ubicacion.Length > 0)
                            {
                                UbicacionProductoBE objE_Ubicacion = new UbicacionProductoBE();
                                objE_Ubicacion.IdUbicacionProducto = 0;
                                objE_Ubicacion.IdAlmacen = Parametros.intAlmCentralUcayali;
                                objE_Ubicacion.IdProducto = objE_Producto.IdProducto;
                                objE_Ubicacion.DescUbicacion = Ubicacion;//item.DescUbicacion;
                                objE_Ubicacion.FlagEstado = true;
                                objE_Ubicacion.Usuario = Parametros.strUsuarioLogin;
                                objE_Ubicacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_Ubicacion.IdEmpresa = Parametros.intEmpresaId;

                                objBL_UbicacionProducto.Inserta(objE_Ubicacion);
                            }
                        }
                    }
                    else
                    {
                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_ProductoIncentivadoDetalle = new PreventaDetalleBE();
                        ObjE_ProductoIncentivadoDetalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_ProductoIncentivadoDetalle.Cantidad = Cantidad;
                        lst_ProductoIncentivadoDetalleMsg.Add(ObjE_ProductoIncentivadoDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                //lblTotalRegistros.Text = gvProductoIncentivadoDetalle.RowCount.ToString() + " Registros";
                //CalculaTotales();

                if (lst_ProductoIncentivadoDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_ProductoIncentivadoDetalleMsg;
                    frm.ShowDialog();
                }

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
        
    }
}