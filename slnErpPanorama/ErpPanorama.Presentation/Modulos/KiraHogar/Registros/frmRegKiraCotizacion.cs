using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
using System.Windows.Forms;
using ErpPanorama.Presentation.Modulos.KiraHogar.Consultas;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using System.Data.SqlClient;



namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegKiraCotizacion : DevExpress.XtraEditors.XtraForm
    {
        private Timer timer;
        private frmRegKiraCotizacionProductoTerminado formRegKiraCotizacionProductoTerminado;
        public frmRegKiraCotizacion()
        {
            InitializeComponent();
            timerFilas();
            // Suscribirse a los eventos
            gvCotizacion.FocusedRowChanged += gvCotizacion_FocusedRowChanged;
            gvCotizacion.LostFocus += gvCotizacion_LostFocus;
            // Crear una nueva instancia del formulario frmRegKiraCotizacionProductoTerminado
            formRegKiraCotizacionProductoTerminado = new frmRegKiraCotizacionProductoTerminado();
            formRegKiraCotizacionProductoTerminado.CotizacionProductoGuardada += CotizacionProductoGuardadaEventHandler;

        }
        private ImageCollection imageCollection;

        private void CotizacionProductoGuardadaEventHandler(object sender, EventArgs e)
        {
            // Actualizar los GridView o realizar otras actualizaciones necesarias
            CargarListadoCotizacionesProducto();
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
            ActualizarNumeroFilasProductos();
        }
        private void frmRegKiraCotizacion_Load(object sender, EventArgs e)
        {
            frmRegKiraCotizacion formCotizacion = new frmRegKiraCotizacion();
            formCotizacion.WindowState = FormWindowState.Maximized;
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargarListadoCotizacionesProducto();
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
            ActualizarNumeroFilasProductos();
            timerFilas();
            imageCollection = new ImageCollection();
            imageCollection.AddImage(Properties.Resources.Stop_2);
        }
        private void timerFilas()
        {
            timer = new Timer();
            timer.Interval = 5000; //3 segundos
            timer.Tick += timer1_Tick;
            timer.Start();
            txtPeriodo.Text = "2023";
            txtPeriodoProducto.Text = "2023";
        }

        private void ActualizarNumeroFilas()
        {
            // Obtener la vista asociada al control "gcCotizaciones"
            GridView gridView = gcCotizaciones.MainView as GridView;
            if (gridView != null)
            {
                // Obtener el número de filas en la vista
                int rowCount = gridView.RowCount;

                // Actualizar el texto del label "lblTotalRegistros" con el número de filas
                lblTotalRegistros.Text = rowCount.ToString() + " Registros encontrados";
            }
        }

        private void ActualizarNumeroFilasProductos()
        {
            // Obtener la vista asociada al control "gcCotizaciones"
            GridView gridView = gcCotizacionesProducto.MainView as GridView;
            if (gridView != null)
            {
                // Obtener el número de filas en la vista
                int rowCount = gridView.RowCount;

                // Actualizar el texto del label "lblTotalRegistros" con el número de filas
                lblTotalRegistrosProductos.Text = rowCount.ToString() + " Registros encontrados";
            }
        }

        private List<CotizacionKiraBE> listaCotizacionesOriginal = new List<CotizacionKiraBE>();
        private List<CotizacionKiraProductoTerminadoBE> listaCotizacionesOriginalproductos = new List<CotizacionKiraProductoTerminadoBE>();
        public void CargarListadoCotizaciones()
        {
            try
            {
                ComboTipoCotizacionBL comboTipoCotizacionBL = new ComboTipoCotizacionBL();
                listaCotizacionesOriginal = comboTipoCotizacionBL.ObtenerListadoCotizaciones();
                gcCotizaciones.DataSource = listaCotizacionesOriginal;
                gvCotizacion.BestFitColumns(); // Ajusta el tamaño de las columnas

            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                MessageBox.Show("Error al cargar el listado de cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarListadoCotizacionesProducto()
        {
            try
            {
                ComboTipoCotizacionBL comboTipoCotizacionBL2 = new ComboTipoCotizacionBL();
                listaCotizacionesOriginalproductos = comboTipoCotizacionBL2.ObtenerListadoCotizacioneproductos();
                gcCotizacionesProducto.DataSource = listaCotizacionesOriginalproductos;
                gvCotizacionProducto.BestFitColumns(); // Ajusta el tamaño de las columnas

            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                MessageBox.Show("Error al cargar el listado de cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_NewClick()
        {

            // Crear y mostrar el formulario de selección
            using (frmSeleccionarFormulario formSeleccion = new frmSeleccionarFormulario())
            {
                DialogResult result = formSeleccion.ShowDialog(this);

                // Verificar si el usuario hizo una selección
                if (result == DialogResult.OK)
                {
                    if (formSeleccion.FormularioSeleccionado == "Cotizacion")
                    {
                        frmCotizacion formCotizacion = new frmCotizacion();
                        formCotizacion.Dock = DockStyle.Fill;
                        formCotizacion.StartPosition = FormStartPosition.CenterParent;
                        formCotizacion.ShowDialog(); // Abre el formulario como cuadro de diálogo
                    }
                    else if (formSeleccion.FormularioSeleccionado == "ProductoTerminado")
                    {
                        frmRegKiraCotizacionProductoTerminado formProductoTerminado = new frmRegKiraCotizacionProductoTerminado();
                        formProductoTerminado.Dock = DockStyle.Fill;
                        formProductoTerminado.StartPosition = FormStartPosition.CenterParent;
                        formProductoTerminado.ShowDialog(); // Abre el formulario como cuadro de diálogo
                    }
                }
            }

        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void tlbMenu_ExportClick()
        {

            string _msg = "Se generó el archivo Excel de forma satisfactoria en la siguiente ubicación:\n{0}\n\nExportado desde: {1}\n\n¿Desea continuar?";
            string _fileName = "Listado de cotizaciones KIRA";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);

            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;

                string exportFrom = isCotizacionProductoFocused ? "Cotización Productos Terminados" : "Cotizaciones Precio Producto"; // Determina el origen de exportación

                if (isCotizacionProductoFocused)
                {
                    if (DialogResult.Yes == XtraMessageBox.Show(string.Format(_msg, f.SelectedPath + @"\" + _fileName + "_ProductoTerminado.xls", exportFrom), "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gcCotizacionesProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + "_Producto.xls");
                        string _nM = string.Format("Archivo exportado desde {0}.", exportFrom);
                        XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (DialogResult.Yes == XtraMessageBox.Show(string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls", exportFrom), "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gcCotizaciones.ExportToXls(f.SelectedPath + @"\" + _fileName + "_Precio_Producto_Stock.xls");
                        string _nM = string.Format("Archivo exportado desde {0}.", exportFrom);
                        XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                Cursor = Cursors.Default;
            }
        }

        CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        private bool isCotizacionProductoFocused = false;
        private void tlbMenu_EditClick()
        {

            try
            {
                if (isCotizacionProductoFocused)
                {
                    int rowIndex = gvCotizacionProducto.FocusedRowHandle;
                    if (rowIndex >= 0)
                    {
                        CotizacionKiraProductoTerminadoBE cotizacionpro = (CotizacionKiraProductoTerminadoBE)gvCotizacionProducto.GetRow(rowIndex);
                        if (cotizacionpro != null)
                        {
                            AbrirFormularioProductoEdicion(cotizacionpro.IdCotizacion); // Utilizas el método para abrir el formulario de edición de productos
                        }
                    }
                }
                else
                {
                    int rowIndex = gvCotizacion.FocusedRowHandle;
                    if (rowIndex >= 0)
                    {
                        CotizacionKiraBE cotizacion = (CotizacionKiraBE)gvCotizacion.GetRow(rowIndex);
                        if (cotizacion != null)
                        {
                            AbrirFormularioEdicion(cotizacion.IdCotizacion); // Utilizas el método para abrir el formulario de edición normal
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tlbMenu_DeleteClick()
        {
            try
            {
                int rowIndex;

                if (isCotizacionProductoFocused)
                {
                    rowIndex = gvCotizacionProducto.FocusedRowHandle;
                    if (rowIndex >= 0)
                    {
                        CotizacionKiraProductoTerminadoBE cotizacionpro = (CotizacionKiraProductoTerminadoBE)gvCotizacionProducto.GetRow(rowIndex);
                        if (cotizacionpro != null)
                        {
                            string codigoProducto = cotizacionpro.CodigoProducto;
                            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar la cotización Producto Terminado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                            {
                                try
                                {
                                    cotizacionKiraBL.EliminarCotizacionProductoPorCodigoProducto(codigoProducto);
                                    CargarListadoCotizaciones();
                                    MessageBox.Show("La cotización se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    // Manejar el error si ocurre
                                    MessageBox.Show("Error al eliminar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    rowIndex = gvCotizacion.FocusedRowHandle;
                    if (rowIndex >= 0)
                    {
                        CotizacionKiraBE cotizacion = (CotizacionKiraBE)gvCotizacion.GetRow(rowIndex);
                        if (cotizacion != null)
                        {
                            string codigoProducto = cotizacion.CodigoProducto;
                            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar la cotización Precio Producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                            {
                                try
                                {
                                    cotizacionKiraBL.EliminarCotizacionPorCodigoProducto(codigoProducto);
                                    CargarListadoCotizaciones();
                                    MessageBox.Show("La cotización se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    // Manejar el error si ocurre
                                    MessageBox.Show("Error al eliminar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                int rowIndex;

                if (isCotizacionProductoFocused)
                {
                    rowIndex = gvCotizacionProducto.FocusedRowHandle;
                    if (rowIndex >= 0)
                    {
                        CotizacionKiraProductoTerminadoBE cotizacionpro = (CotizacionKiraProductoTerminadoBE)gvCotizacionProducto.GetRow(rowIndex);
                        if (cotizacionpro != null)
                        {
                            int idCotizacion = cotizacionpro.IdCotizacion;
                            GenerarInformeProductoTerminado(idCotizacion);
                        }
                    }
                }
                else
                {
                    int[] selectedRows = gvCotizacion.GetSelectedRows();
                    if (selectedRows.Length > 1)
                    {
                        //GenerarInformeAll();
                        // Obtén la lista de idCotizaciones seleccionadas
                        List<int> idCotizaciones = new List<int>();

                        foreach (int rowHandle in selectedRows)
                        {
                            CotizacionKiraBE cotizacion = (CotizacionKiraBE)gvCotizacion.GetRow(rowHandle);
                            if (cotizacion != null)
                            {
                                idCotizaciones.Add(cotizacion.IdCotizacion);
                            }
                        }
                        GenerarInformeAll(idCotizaciones);
                    }
                    else
                    {
                        rowIndex = gvCotizacion.FocusedRowHandle;
                        if (rowIndex >= 0)
                        {
                            CotizacionKiraBE cotizacion = (CotizacionKiraBE)gvCotizacion.GetRow(rowIndex);
                            if (cotizacion != null)
                            {
                                int idCotizacion = cotizacion.IdCotizacion;
                                GenerarInforme(idCotizacion);
                            }
                        }
                    }
                }

                //else
                //{
                //    rowIndex = gvCotizacion.FocusedRowHandle;
                //    if (rowIndex >= 0)
                //    {
                //        CotizacionKiraBE cotizacion = (CotizacionKiraBE)gvCotizacion.GetRow(rowIndex);
                //        if (cotizacion != null)
                //        {
                //            int idCotizacion = cotizacion.IdCotizacion;
                //            GenerarInforme(idCotizacion);
                //        }
                //        else
                //        {
                //            GenerarInformeAll();
                //        }
                //    }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerarInformeProductoTerminado(int idCotizacion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (listaCotizacionesOriginalproductos.Count > 0)
                {
                    List<CotizacionKiraProductoTerminadoBE> lstReporte = new CotizacionKiraBL().ListadoProducto(idCotizacion);
                    if (lstReporte != null && lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptProductoTerminado = new RptVistaReportes();
                        objRptProductoTerminado.VerRptCotizacionKiraProductoTerminado(lstReporte);
                        objRptProductoTerminado.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("No hay información de productos terminados para la cotización seleccionada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerarInforme(int idCotizacion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (listaCotizacionesOriginal.Count > 0)
                {
                    List<CotizacionKiraBE> lstReporte = new CotizacionKiraBL().Listado(idCotizacion);
                    if (lstReporte != null && lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptFacturaCompra = new RptVistaReportes();
                        objRptFacturaCompra.VerRptCotizacionKira(lstReporte);
                        objRptFacturaCompra.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void GenerarInformeAll()
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;

        //        if (listaCotizacionesOriginal.Count > 0)
        //        {
        //            List<CotizacionKiraBE> lstReporte = new CotizacionKiraBL().ListadoAll();
        //            if (lstReporte != null && lstReporte.Count > 0)
        //            {
        //                RptVistaReportes objRptFacturaCompra = new RptVistaReportes();
        //                objRptFacturaCompra.VerRptCotizacionKira(lstReporte);
        //                objRptFacturaCompra.ShowDialog();
        //            }
        //            else
        //            {
        //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor = Cursors.Default;
        //        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void GenerarInformeAll(List<int> listaIdCotizaciones)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (listaCotizacionesOriginal.Count > 0)
                {
                    // Obtén la lista de idCotizaciones que deseas consultar
                    List<int> idCotizaciones = new List<int>();

                    foreach (var cotizacion in listaCotizacionesOriginal)
                    {
                        idCotizaciones.Add(cotizacion.IdCotizacion);
                    }

                    List<CotizacionKiraBE> lstReporte = new CotizacionKiraBL().ListadoAll(listaIdCotizaciones);

                    if (lstReporte != null && lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptFacturaCompra = new RptVistaReportes();
                        objRptFacturaCompra.VerRptCotizacionKiraAll(lstReporte);
                        objRptFacturaCompra.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tlbMenu_Load(object sender, EventArgs e)
        {
            CargarListadoCotizaciones();
            CargarListadoCotizacionesProducto();
        }

        public void tlbMenu_RefreshClick()
        {
            CargarListadoCotizacionesProducto();
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
            ActualizarNumeroFilasProductos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
            ActualizarNumeroFilasProductos();
            CargarListadoCotizacionesProducto();
        }

        private void OnMenuItemEliminarClick(object sender, EventArgs e)
        {
            //DXMenuItem menuItem = sender as DXMenuItem;
            //if (menuItem != null)
            //{
            //    string codigoProducto = menuItem.Tag.ToString();

            //    // Preguntar al usuario si está seguro de eliminar la cotización
            //    DialogResult resultado = XtraMessageBox.Show("¿Estás seguro de eliminar la cotización?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (resultado == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            // Llamar al método para eliminar la cotización por CodigoProducto
            //            cotizacionKiraBL.EliminarCotizacionPorCodigoProducto(codigoProducto);
            //            // Actualizar la lista de cotizaciones en el grid
            //            CargarListadoCotizaciones();
            //            // Mostrar mensaje de éxito
            //            XtraMessageBox.Show("La cotización se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            // Manejar el error si ocurre
            //            XtraMessageBox.Show("Error al eliminar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void gvCotizacion_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //GridView gridView = sender as GridView;
            //if (e.MenuType == GridMenuType.Row && e.HitInfo.InRow)
            //{
            //    int filaSeleccionada = e.HitInfo.RowHandle;
            //    string codigoProducto = gridView.GetRowCellValue(filaSeleccionada, "CodigoProducto").ToString();

            //    // Crear el DXMenuItem para la eliminación de la cotización
            //    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Cotización", OnMenuItemEliminarClick);
            //    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
            //    menuItemEliminar.Tag = codigoProducto;

            //    // Agregar el DXMenuItem al menú
            //    e.Menu.Items.Add(menuItemEliminar);
            //}
        }


        private List<CotizacionKiraBE> cotizacionesFiltradas; 

        private void gvCotizacionProducto_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            isCotizacionProductoFocused = true; 
            gvCotizacion.ClearSelection(); // Desactivar la selección en gvCotizacion
            timer.Stop();
        }
        private void gvCotizacion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            timer.Stop();
            isCotizacionProductoFocused = false; // 
            gvCotizacionProducto.ClearSelection(); // Desactivar la selección en gvCotizacionProducto
        }

        private void gvCotizacionProducto_LostFocus(object sender, EventArgs e)
        {
            timer.Start();
            CargarListadoCotizacionesProducto();
            CargarListadoCotizaciones();
        }
        private void gvCotizacion_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // Verificar si la celda es de una de las columnas de gastos
            if (e.Column.FieldName == "CostoMateriales" ||
                e.Column.FieldName == "CostoInsumos" ||
                e.Column.FieldName == "CostoAccesorios" ||
                e.Column.FieldName == "CostoManoObra" ||
                e.Column.FieldName == "CostoMovilidad")
            {
                // Obtener los valores de la celda actual y de la fila actual
                decimal costo = Convert.ToDecimal(e.CellValue);
                decimal precioVenta = Convert.ToDecimal(gvCotizacion.GetRowCellValue(e.RowHandle, "PrecioVenta"));

                // Comparar los valores y mostrar una alerta si los gastos superan el precio de venta
                if (costo > precioVenta)
                {
                    e.Appearance.BackColor = Color.Red;  // Cambiar el color de fondo de la celda a rojo
                    e.Appearance.ForeColor = Color.White;  // Cambiar el color de texto a blanco
                    e.DisplayText = "Gastos > PrecioVenta";  // Cambiar el texto que se muestra en la celda
                }
            }

        }

        private void gvCotizacion_LostFocus(object sender, EventArgs e)
        {
            timer.Start();
            CargarListadoCotizacionesProducto();
            CargarListadoCotizaciones();
        }

        private void txtNumero_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AbrirFormularioEdicion(int idCotizacion)
        {
            frmRegCotizacionPrecioProductoClienteStockEdit frmEditar = new frmRegCotizacionPrecioProductoClienteStockEdit();
            frmEditar.IdCotizacion = idCotizacion;
            frmEditar.ShowDialog();
        }
        private void AbrirFormularioProductoEdicion(int idCotizacion)
        {
            frmRegKiraCotizacionProductoTerminadoEdit frmEditar = new frmRegKiraCotizacionProductoTerminadoEdit();
            frmEditar.IdCotizacion = idCotizacion;
            frmEditar.ShowDialog();
        }
        private void gvCotizacion_DoubleClick(object sender, EventArgs e)
        {
            if (gvCotizacion.GetFocusedRow() is CotizacionKiraBE cotizacion)
            {
                AbrirFormularioEdicion(cotizacion.IdCotizacion);
            }
        }

        private void gvCotizacionProducto_DoubleClick(object sender, EventArgs e)
        {
            if (gvCotizacionProducto.GetFocusedRow() is CotizacionKiraProductoTerminadoBE cotizacion)
            {
                AbrirFormularioProductoEdicion(cotizacion.IdCotizacion);
            }
        }

        private List<CotizacionKiraProductoTerminadoBE> cotizacionesFiltradasproducto; // Agrega esta línea
        private void txtNumeroProducto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtNumeroProducto.Text) || string.IsNullOrEmpty(txtPeriodo.Text))
                    {
                        // Mostrar un mensaje al usuario indicando que los campos son obligatorios
                        MessageBox.Show("Por favor, ingrese valores en los campos.");
                        return;
                    }

                    int periodo, numeroCotizacion;

                    if (!int.TryParse(txtPeriodoProducto.Text, out periodo) || !int.TryParse(txtNumeroProducto.Text, out numeroCotizacion))
                    {
                        // Mostrar un mensaje al usuario indicando que los valores ingresados no son válidos
                        MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos.");
                        return;
                    }

                    cotizacionesFiltradasproducto = cotizacionKiraBL.FiltrarCotizacionesPorPeriodoYNumeroproducto(periodo, numeroCotizacion);

                    gcCotizacionesProducto.DataSource = cotizacionesFiltradasproducto; // Asigna los nuevos datos
                    gvCotizacionProducto.BestFitColumns(); // Ajusta el tamaño de las columnas
                }
            }
            catch (Exception ex)
            {
                // Manejo adecuado de la excepción: muestra un mensaje de error al usuario
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtNumero.Text) || string.IsNullOrEmpty(txtPeriodo.Text))
                    {
                        // Mostrar un mensaje al usuario indicando que los campos son obligatorios
                        MessageBox.Show("Por favor, ingrese valores en los campos.");
                        return;
                    }

                    int periodo, numeroCotizacion;

                    if (!int.TryParse(txtPeriodo.Text, out periodo) || !int.TryParse(txtNumero.Text, out numeroCotizacion))
                    {
                        // Mostrar un mensaje al usuario indicando que los valores ingresados no son válidos
                        MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos.");
                        return;
                    }

                    cotizacionesFiltradas = cotizacionKiraBL.FiltrarCotizacionesPorPeriodoYNumero(periodo, numeroCotizacion);

                    gcCotizaciones.DataSource = cotizacionesFiltradas; // Asigna los nuevos datos
                    gvCotizacion.BestFitColumns(); // Ajusta el tamaño de las columnas
                }
            }
            catch (Exception ex)
            {
                // Manejo adecuado de la excepción: muestra un mensaje de error al usuario
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
       
    }
}
