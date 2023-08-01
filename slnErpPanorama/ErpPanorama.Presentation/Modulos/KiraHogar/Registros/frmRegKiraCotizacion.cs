using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using ErpPanorama.Presentation.Modulos.KiraHogar.Consultas;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;


namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegKiraCotizacion : DevExpress.XtraEditors.XtraForm
    {
        private Timer timer;

        public frmRegKiraCotizacion()
        {
            InitializeComponent();
            timerFilas();
        }

        private void frmRegKiraCotizacion_Load(object sender, EventArgs e)
        {
            frmRegKiraCotizacion formCotizacion = new frmRegKiraCotizacion();
            formCotizacion.WindowState = FormWindowState.Maximized;
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
            timerFilas();

        }
        private void timerFilas() {
            timer = new Timer();
            timer.Interval = 5000; // 5 segundos
            timer.Tick += timer1_Tick;
            timer.Start();
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

        public void CargarListadoCotizaciones()
        {
            try
            {
                ComboTipoCotizacionBL comboTipoCotizacionBL = new ComboTipoCotizacionBL();
                List<CotizacionKiraBE> listaCotizaciones = comboTipoCotizacionBL.ObtenerListadoCotizaciones();

                // Asignar la lista de cotizaciones al control gcCotizaciones
                gcCotizaciones.DataSource = listaCotizaciones;
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                MessageBox.Show("Error al cargar el listado de cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tlbMenu_NewClick()
        {

            frmCotizacion formCotizacion = new frmCotizacion();
            formCotizacion.Dock = DockStyle.Fill; // Rellenar el área del contenedor
            formCotizacion.StartPosition = FormStartPosition.CenterParent;
            formCotizacion.Show(); // Mostrar el formulario
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

        private void gvCotizacion_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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
                    if (valor > 2000)
                        color = Color.Red;
                    else if (valor > 1500)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
        }
    }
}
