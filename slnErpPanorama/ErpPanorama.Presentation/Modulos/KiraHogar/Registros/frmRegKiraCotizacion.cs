﻿using System;
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
        public frmRegKiraCotizacion()
        {
            InitializeComponent();
            timerFilas();
            // Suscribirse a los eventos
            gvCotizacion.FocusedRowChanged += gvCotizacion_FocusedRowChanged;
            gvCotizacion.LostFocus += gvCotizacion_LostFocus;

        }
        private ImageCollection imageCollection;
        private void frmRegKiraCotizacion_Load(object sender, EventArgs e)
        {
            frmRegKiraCotizacion formCotizacion = new frmRegKiraCotizacion();
            formCotizacion.WindowState = FormWindowState.Maximized;
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
            timerFilas();
            imageCollection = new ImageCollection();
            imageCollection.AddImage(Properties.Resources.Stop_2);
        }
        private void timerFilas() {
            timer = new Timer();
            timer.Interval = 25000; // 25 segundos
            timer.Tick += timer1_Tick;
            timer.Start();
            txtPeriodo.Text = "2023";
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
        private List<CotizacionKiraBE> listaCotizacionesOriginal = new List<CotizacionKiraBE>();
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
            //frmCotizacion formCotizacion = new frmCotizacion();
            //formCotizacion.Dock = DockStyle.Fill; // Rellenar el área del contenedor
            //formCotizacion.StartPosition = FormStartPosition.CenterParent;
            //formCotizacion.Show(); // Mostrar el formulario
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Listado de cotizaciones KIRA";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcCotizaciones.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }
        CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        private void tlbMenu_DeleteClick()
        {
            // Obtener la fila seleccionada en el GridView
            int filaSeleccionada = gvCotizacion.FocusedRowHandle;
            // Verificar que haya una fila seleccionada
            if (filaSeleccionada >= 0)
            {
                // Obtener el valor del CodigoProducto de la fila seleccionada
                string codigoProducto = gvCotizacion.GetRowCellValue(filaSeleccionada, "CodigoProducto").ToString();

                // Preguntar al usuario si está seguro de eliminar la cotización
                DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar la cotización?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al método para eliminar la cotización por CodigoProducto
                        cotizacionKiraBL.EliminarCotizacionPorCodigoProducto(codigoProducto);
                        // Actualizar la lista de cotizaciones en el grid
                        CargarListadoCotizaciones();
                        // Mostrar mensaje de éxito
                        MessageBox.Show("La cotización se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Manejar el error si ocurre
                        MessageBox.Show("Error al eliminar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Si no hay una fila seleccionada, mostrar un mensaje
                MessageBox.Show("Selecciona una cotización para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tlbMenu_Load(object sender, EventArgs e)
        {
            CargarListadoCotizaciones();
        }

        private void tlbMenu_RefreshClick()
        {
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
        }


        private void OnMenuItemEliminarClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            if (menuItem != null)
            {
                string codigoProducto = menuItem.Tag.ToString();

                // Preguntar al usuario si está seguro de eliminar la cotización
                DialogResult resultado = XtraMessageBox.Show("¿Estás seguro de eliminar la cotización?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al método para eliminar la cotización por CodigoProducto
                        cotizacionKiraBL.EliminarCotizacionPorCodigoProducto(codigoProducto);
                        // Actualizar la lista de cotizaciones en el grid
                        CargarListadoCotizaciones();
                        // Mostrar mensaje de éxito
                        XtraMessageBox.Show("La cotización se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Manejar el error si ocurre
                        XtraMessageBox.Show("Error al eliminar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gvCotizacion_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.MenuType == GridMenuType.Row && e.HitInfo.InRow)
            {
                int filaSeleccionada = e.HitInfo.RowHandle;
                string codigoProducto = gridView.GetRowCellValue(filaSeleccionada, "CodigoProducto").ToString();

                // Crear el DXMenuItem para la eliminación de la cotización
                DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Cotización", OnMenuItemEliminarClick);
                menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                menuItemEliminar.Tag = codigoProducto;

                // Agregar el DXMenuItem al menú
                e.Menu.Items.Add(menuItemEliminar);
            }
        }


        private List<CotizacionKiraBE> cotizacionesFiltradas; // Agrega esta línea
        private void tlbMenu_EditClick()
        {

            try
            {
                int rowIndex = gvCotizacion.FocusedRowHandle;
                if (rowIndex >= 0)
                {
                    CotizacionKiraBE cotizacion = (CotizacionKiraBE)gvCotizacion.GetRow(rowIndex);

                    if (cotizacion != null)
                    {
                        AbrirFormularioEdicion(cotizacion.IdCotizacion); // Utilizas el método existente para abrir el formulario de edición
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        int periodo = Convert.ToInt32(txtPeriodo.Text);
            //        int numeroCotizacion = Convert.ToInt32(txtNumero.Text);

            //        cotizacionesFiltradas = cotizacionKiraBL.FiltrarCotizacionesPorPeriodoYNumero(periodo, numeroCotizacion);

            //        gcCotizaciones.DataSource = cotizacionesFiltradas; // Asigna los nuevos datos
            //        gvCotizacion.BestFitColumns(); // Ajusta el tamaño de las columnas
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        private void gvCotizacion_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if (e.Column.FieldName == "PrecioVenta" || e.Column.FieldName == "TotalGastos")
            {
                // Obtener el valor de la celda
                decimal valor = Convert.ToDecimal(e.CellValue);
                Color color = Color.Empty;

                if (e.Column.FieldName == "PrecioVenta")
                {
                    // Resaltar el campo "PrecioVenta" en color verde si es mayor a 2000
                    if (valor > 2000)
                        color = Color.Green;
                }
                else if (e.Column.FieldName == "TotalGastos")
                {
                    // Resaltar el campo "TotalGastos" con diferentes colores según su valor
                    if (valor >= 2000)
                        color = Color.Red;
                    else if (valor >= 1500 )
                        color = Color.Orange;
                    else
                        color = Color.Green;
                }

                if (color != Color.Empty)
                {
                    // Cambiar el color de fondo de la celda
                    e.Appearance.BackColor = color;
                    e.Appearance.BackColor2 = color;
                }
            }
        }

        private void gvCotizacion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            timer.Stop();
        }

        private void gvCotizacion_LostFocus(object sender, EventArgs e)
        {
            timer.Start();
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
        private void gvCotizacion_DoubleClick(object sender, EventArgs e)
        {
            if (gvCotizacion.GetFocusedRow() is CotizacionKiraBE cotizacion)
            {
                AbrirFormularioEdicion(cotizacion.IdCotizacion);
            }
        }
    }
}
