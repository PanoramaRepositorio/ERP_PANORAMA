using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegKiraCotizacionProductoTerminado : DevExpress.XtraEditors.XtraForm
    {
        public ComboTipoCotizacionBL comboTipoCotizacionBL;
        private CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        private frmRegKiraCotizacion formRegKiraCotizacion;
        // Variable para almacenar el cuadro de diálogo de selección de archivos
        private OpenFileDialog openFile = new OpenFileDialog();
        public frmRegKiraCotizacionProductoTerminado()
        {
            InitializeComponent();
        }

        private DataTable dtDatospestaña1;
        private DataTable dtDatosResumen;
        private ImageCollection imageCollection;
        private void frmRegKiraCotizacionProductoTerminado_Load(object sender, EventArgs e)
        {
            ConfigurarComboBoxProductoTerminado();
            ConfigurarComboBoxTipoCotizacion();
            ConfigurarComboBoxTipoMoneda();
            personalizacióncontrolesform();
            CrearDatable_GridControl();
            OcultarColumnasGridControlPestañas();
            calcularTotalGastospestaña2();
            imageCollection = new ImageCollection();
            imageCollection.AddImage(Properties.Resources.Stop_2);
            // Establecer la propiedad MaxLength a 0 para permitir una cantidad ilimitada de caracteres
            txtCodigoProducto.Properties.MaxLength = 0;
        }


        public void ConfigurarComboBoxProductoTerminado()
        {
            cboProductoTerminado.Text = "Selecione Gasto";
            cboProductoTerminado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaComboTipoIsumo = comboTipoCotizacionBL.ObtenerComboProductoTerminados();
            cboProductoTerminado.Properties.Items.Clear();
            foreach (var item in listaComboTipoIsumo)
            {
                cboProductoTerminado.Properties.Items.Add(item.DescTablaElemento);
            }

        }

        private void ConfigurarComboBoxTipoCotizacion()
        {
            //cboTipoCotizacion.Text = "Seleccione un Tipo";
            cboTipoCotizacion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = comboTipoCotizacionBL.ObtenerComboTipoCotizacion();
            cboTipoCotizacion.Properties.Items.Clear();
            foreach (var item in listaComboTipoCotizacion)
            {
                cboTipoCotizacion.Properties.Items.Add(item.DescTablaElemento);
            }
            // Seleccionar un valor por defecto (por ejemplo, el primer elemento de la lista)
            if (listaComboTipoCotizacion.Count > 0)
            {
                cboTipoCotizacion.SelectedIndex = 1;
                cboTipoCotizacion.Enabled = false; // Deshabilitar el ComboBox
            }
        }

        public void ConfigurarComboBoxTipoMoneda()
        {
            //cboTipoMoneda.Text = "Seleccione Moneda";
            cboTipoMoneda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<ComboTipoCotizacionBE> listamone = comboTipoCotizacionBL.ObtenerComboTipoMoneda();
            // Configurar el ComboBox
            cboTipoMoneda.Properties.Items.Clear();
            foreach (ComboTipoCotizacionBE item in listamone)
            {
                cboTipoMoneda.Properties.Items.Add(item.DescTablaElemento);
            }

            if (listamone.Count > 0)
            {
                cboTipoMoneda.SelectedIndex = 0;
               // cboTipoMoneda.Enabled = false; // Deshabilitar el ComboBox
            }
        }


        private void personalizacióncontrolesform()
        {
            int siguienteNumeroCotizacion = cotizacionKiraBL.ObtenerSiguienteNumeroCotizacionProductoTerminado();
            txtNumeroCotizacion.Enabled = false;
            txtNumeroCotizacion.Text = siguienteNumeroCotizacion.ToString();
            Tabcontrol.TabPages[0].Text = "Producto Terminado";
            Tabcontrol.TabPages[1].Text = "Resumen";
            txtFecha.Properties.MinValue = DateTime.Today;
            txtFecha.DateTime = DateTime.Today;
            txtCaracteristicas.ScrollBars = ScrollBars.Vertical;
            txtCaracteristicas.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Both;
            txtMargen.Text = Parametros.margencontri.ToString();
            txtPrecioVenta.Enabled = false;
            txtMargen.Enabled = false;
            btnActualizarPestaña1.Visible = false;
        }

        private void CrearDatable_GridControl()
        {
            // Crear el DataTable para almacenar los datos pestaña 1
            dtDatospestaña1 = new DataTable();
            dtDatospestaña1.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña1.Columns.Add("Item", typeof(int));
            dtDatospestaña1.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña1.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña1.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña1.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total
            // Asignar el DataTable como fuente de datos para cada GridControl
            gridControlPestaña1.DataSource = dtDatospestaña1;
            // Crear el DataTable para almacenar los datos pestaña 7

            dtDatosResumen = new DataTable();
            dtDatosResumen.Columns.Add("NombreTablaElemento", typeof(string)); // Columna para mostrar el nombre
            dtDatosResumen.Columns.Add("DescripcionGastos", typeof(string));
            dtDatosResumen.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total
            // Agregar un evento TableNewRow a cada DataTable para actualizar automáticamente el resumen
            dtDatospestaña1.TableNewRow += DtDatospestaña1_TableNewRow;
            gridControlPestañaResumen.DataSource = dtDatosResumen;
        }

        private void OcultarColumnasGridControlPestañas()
        {
            // Obtener el objeto GridView asociado a gridControlPestaña1
            GridView gridViewPestaña1 = gridControlPestaña1.MainView as GridView;
            // Verificar que el objeto GridView no sea nulo
            if (gridViewPestaña1 != null)
            {
                // Ocultar las columnas que no quieres mostrar en gridControlPestaña1
                gridViewPestaña1.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña1.Columns["Item"].Visible = false;
                gridViewPestaña1.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña1.Columns["FlagEstado"].Visible = false;
                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña1.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña1.Columns["Costo" + " " + " S/."].Visible = true;

            }
        }

        /// <summary>
        ///Método para verificar si una fila está vacía o contiene solo valores nulos o en blanco
        /// </summary>
        private bool DataRowIsEmpty(DataRow row)
        {
            // Verificar si la fila está vacía o contiene solo valores nulos o en blanco
            foreach (var item in row.ItemArray)
            {
                if (item != null && !string.IsNullOrWhiteSpace(item.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///Método para obtener el nombre correspondiente a un valor de IdTablaElemento
        /// </summary>
        private string ObtenerNombreTablaElemento(int idTablaElemento)
        {
            // Valores y nombres correspondientes
            Dictionary<int, string> nombresTablaElemento = new Dictionary<int, string>
                {
                    { Parametros.idCostoINC_IGV, Parametros.costo_inc_igv },
                    { Parametros.idMovilidad, Parametros.movilidad },
                    { Parametros.idServiciosAdicionales, Parametros.serviciosadciones},
                    // Agrega aquí más valores y nombres correspondientes
                };

            return nombresTablaElemento.ContainsKey(idTablaElemento) ? nombresTablaElemento[idTablaElemento] : string.Empty;
        }

        /// <summary>
        ///toma los datos de la tabla dtPestana, verifica si la fila no está vacía 
        ///y luego agrega algunas columnas específicas de esa fila a otro DataTable llamado dtDatosResumen
        /// </summary>
        private void AgregarDatosDePestanaAlResumen(DataTable dtPestana)
        {
            foreach (DataRow row in dtPestana.Rows)
            {
                if (!DataRowIsEmpty(row))
                {
                    DataRow newRow = dtDatosResumen.NewRow();
                    newRow["NombreTablaElemento"] = ObtenerNombreTablaElemento((int)row["IdTablaElemento"]); // Usamos una función para obtener el nombre
                    newRow["DescripcionGastos"] = row["DescripcionGastos"];
                    newRow["Costo" + " " + " S/."] = row["Costo" + " " + " S/."];
                    dtDatosResumen.Rows.Add(newRow);
                }
            }
        }

        public void calcularTotalGastospestaña2()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestañaResumen.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = Parametros.margencontri; // Valor de J69 (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = Math.Round(precioVenta, 2).ToString("0.00"); // Redondear a dos decimales
            }
            else
            {
                cotizacion.PrecioVenta = 0;
                txtPrecioVenta.Text = "0";
            }
        }

        // Método para agregar todos los datos de cada pestaña al resumen
        private void AgregarDatosAlResumen()
        {
            // Limpiar el resumen antes de agregar los nuevos datos
            dtDatosResumen.Rows.Clear();
            // Agregar los datos de cada pestaña al resumen
            AgregarDatosDePestanaAlResumen(dtDatospestaña1);
            // Actualiza el DataSource del gridControlPestaña7Resumen con el DataTable dtDatosResumen
            gridControlPestañaResumen.DataSource = dtDatosResumen;
            calcularTotalGastospestaña2();
        }

        private void DtDatospestaña1_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }

        /// <summary>
        ///  Método para calcular la suma de costos de la pestaña 1
        /// </summary>
        private decimal CalcularSumaCostosPestana1(DataTable dt)
        {
            decimal sumaCostos = 0.0m;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                    {
                        sumaCostos += costo;
                    }
                }
            }

            return sumaCostos;
        }

        /// <summary>
        /// Metodos de los botones agregar de cada pesataña TAB
        /// </summary>

        private void btnAgregarPestaña1_Click_1(object sender, EventArgs e)
        {
            // Obtener los valores de los controles NumericUpDown y ComboBoxEdit
            string productoterminado = cboProductoTerminado.Text;
            string monto = txtPrecioProductoTerminado.Text;
            // Verificar si se ha seleccionado un material
            if (string.IsNullOrWhiteSpace(productoterminado))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Verificar si se ha ingresado un monto válido
            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboProductoTerminados()
                .FirstOrDefault(x => x.DescTablaElemento == cboProductoTerminado.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña1
            DataTable dt = (DataTable)gridControlPestaña1.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == productoterminado);

            if (existingRow != null)
            {
                // Si la descripción ya existe, incrementar el Item en esa fila
                int currentItem = existingRow.Field<int>("Item");
                decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                existingRow["Item"] = currentItem + 1;
                existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
            }
            else
            {
                // Si la descripción no existe, agregar una nueva fila con el Item en 1
                DataRow newRow = dt.NewRow();
                newRow["IdTablaElemento"] = idTablaElemento;
                newRow["DescripcionGastos"] = productoterminado;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }
            // Llamamos al método que agrega todos los datos al resumen
            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();

            // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");

            cboProductoTerminado.Text = "Seleccione Costo";
            txtPrecioProductoTerminado.Text = string.Empty;
            gridControlPestaña1.RefreshDataSource();
            //calcularTotalGastospestaña1();
            // Después de agregar los datos a la pestaña 1, actualiza el resumen

        }

        private void btnAgregarimg_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (!string.IsNullOrEmpty(openFile.FileName))
            {
                FileInfo fi;
                Decimal mxKb = Parametros.dmlTamanioImagen; // Convert.ToDecimal(100);
                Decimal acKb;

                fi = new FileInfo(openFile.FileName);
                acKb = Convert.ToDecimal(fi.Length) / 1024;
                if (fi.Length > (mxKb * 1024))
                {
                    XtraMessageBox.Show(openFile.FileName + " Tamaño Máximo: " + mxKb.ToString() + " Kb. Tamaño Actual: " + acKb.ToString("###,##0.00") + " Kb.", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.picImage.Image = Image.FromFile(openFile.FileName);
                }
            }
        }

        private void btnEliminarimg_Click(object sender, EventArgs e)
        {
            this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
        }

        /// <summary>
        /// Metodos que obtiene las filas del Gridcontrol para posterior usarlo 
        /// en RegistrarCotizacionYDetalle
        /// </summary>
        private void AgregarDatosDePestanaAlDetalle(DataTable dtPestana, DataTable dtDetalleCompleto)
        {
            // Verificar que el DataTable de la pestaña no sea nulo y contenga filas
            if (dtPestana != null && dtPestana.Rows.Count > 0)
            {
                int item = 1; // Variable para almacenar el número de item
                foreach (DataRow row in dtPestana.Rows)
                {
                    DataRow newRow = dtDetalleCompleto.NewRow();
                    newRow["IdTablaElemento"] = row["IdTablaElemento"];
                    newRow["DescripcionGastos"] = row["DescripcionGastos"];
                    newRow["Costo" + " " + " S/."] = row["Costo" + " " + " S/."];
                    newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                    newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                    newRow["Item"] = item; // Asignar el número de item
                    dtDetalleCompleto.Rows.Add(newRow);
                    item++;
                }
            }
        }

        public void LimpiarControlesTextBox(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                    int siguienteNumeroCotizacion = cotizacionKiraBL.ObtenerSiguienteNumeroCotizacionProductoTerminado();
                    txtNumeroCotizacion.Text = siguienteNumeroCotizacion.ToString();
                }
                else if (control is System.Windows.Forms.ComboBox comboBox)
                {
                    valorespredeterminadosdeloscbo();
                }
                else if (control.HasChildren) // Si el control tiene controles hijos, realizar un recorrido recursivo
                {
                    LimpiarControlesTextBox(control.Controls);
                }
            }
        }

        public void valorespredeterminadosdeloscbo()
        {
            string cboTipoCotizacionDefault = "Seleccione un Tipo";
            string cboProductoterminado= "Seleccione Gasto";
            string cboTipoMonedaDefault = "Seleccione Moneda";
            // Restaurar los valores predeterminados en los comboboxes
            cboTipoCotizacion.Text = cboTipoCotizacionDefault;
            cboProductoTerminado.Text = cboProductoterminado;
            cboTipoMoneda.Text = cboTipoMonedaDefault;
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            CotizacionKiraBL cotizacionKiraBLs = new CotizacionKiraBL();
            if (cotizacionKiraBLs.ValidarCodigoProductoproducto(txtCodigoProducto.Text))
            {
                lblCodigoExistente.Text = "El código de producto ya existe en la base de datos.";
                lblCodigoExistente.ForeColor = Color.Red;
            }
            else
            {
                lblCodigoExistente.Text = "Código disponible.";
                lblCodigoExistente.ForeColor = Color.Green;
            }
        }

        private void btnActualizarPestaña1_Click(object sender, EventArgs e)
        {
            // Obtener el DataTable asociado al gridControlPestaña1 y actualizar los datos si es necesario.
            DataTable dt = (DataTable)gridControlPestaña1.DataSource;

            // Actualizar el resumen y el gridControlPestaña1
            AgregarDatosAlResumen();
            gridView1.RefreshData();
            // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
        }

        private void btnEliminarPestaña1_Click(object sender, EventArgs e)
        {
            // Obtener el GridView correspondiente a la pestaña 1 (gridView1) y el índice de la fila seleccionada
            GridView gridView = gridView1;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                // Confirmar si el usuario desea eliminar el registro
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Eliminar la fila del DataTable asociado al gridControlPestaña1
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    dt.Rows.RemoveAt(selectedRowHandle);

                    // Actualizar el resumen y el gridControlPestaña1
                    AgregarDatosAlResumen();
                    gridView.RefreshData();
                    // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
                    decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
                    txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
                }
            }
        }

       

        // Clase auxiliar para almacenar la información del menú contextual
        private class MenuItemInfo
        {
            public GridView View { get; set; }
            public int RowHandle { get; set; }

            public MenuItemInfo(GridView view, int rowHandle)
            {
                View = view;
                RowHandle = rowHandle;
            }
        }


        // Evento que se activa cuando se hace clic en el elemento de menú "Eliminar Fila"
        private void OnMenuItemClick(object sender, EventArgs e)
        {
            if (sender is DXMenuItem item)
            {
                if (item.Tag is MenuItemInfo menuItemInfo)
                {
                    if (menuItemInfo.View.IsValidRowHandle(menuItemInfo.RowHandle))
                    {
                        menuItemInfo.View.DeleteRow(menuItemInfo.RowHandle);
                        // Obtener el DataTable asociado al gridControlPestaña1
                        DataTable dt = (DataTable)gridControlPestaña1.DataSource;
                        

                        // Actualizar el resumen y el gridControlPestaña1
                        AgregarDatosAlResumen();
                        gridView1.RefreshData();

                        // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
                        decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
                        
                        txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
                       
                    }
                }
            }
        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                if (rowHandle >= 0 && view.IsDataRow(rowHandle))
                {
                    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Fila", OnMenuItemClick);
                    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                    menuItemEliminar.Tag = new MenuItemInfo(view, rowHandle);
                    e.Menu.Items.Add(menuItemEliminar);
                }
            }
        }

        public event EventHandler CotizacionProductoGuardada;
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox de Tipo de Cotización
                ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboTipoCotizacion()
                    .FirstOrDefault(x => x.DescTablaElemento == cboTipoCotizacion.Text);

                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de cotización válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox de Tipo de Moneda
                ComboTipoCotizacionBE itemMonedaSeleccionado = comboTipoCotizacionBL.ObtenerComboTipoMoneda()
                    .FirstOrDefault(x => x.DescTablaElemento == cboTipoMoneda.Text);

                if (itemMonedaSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de moneda válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el IdTablaElemento de los tipos de cotización y moneda seleccionados
                int idTipoCotizacion = itemSeleccionado.IdTablaElemento;
                int idMoneda = itemMonedaSeleccionado.IdTablaElemento;
                // Crear objeto CotizacionKiraBE con los valores ingresados por el usuario
                CotizacionKiraProductoTerminadoBE cotizacion = new CotizacionKiraProductoTerminadoBE
                {
                    IdTablaElemento = idTipoCotizacion, // IdTipoCotizacion obtenido del ComboBox de Tipo de Cotización
                    Fecha = txtFecha.DateTime,
                    CodigoProducto = txtCodigoProducto.Text,
                    Descripcion = txtBreveDescripcion.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Imagen = "",
                    TotalGastos = decimal.TryParse(txtTotal.Text, out decimal totalGastos) ? totalGastos : 0.0m,
                    PrecioVenta = decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m,
                    IdMoneda = idMoneda, // IdMoneda obtenido del ComboBox de Tipo de Moneda
                    FlagEstado = true
                };

                // CAMBIAR 
                cotizacion.CostoProductos = decimal.TryParse(txtSumaCostosPestaña1.Text, out decimal sumaCostosPestana1) ? sumaCostosPestana1 : 0.0m;

                // Guardar la imagen en el fileserver y obtener la ruta de destino
                if (picImage.Image != null && !string.IsNullOrEmpty(openFile.FileName))
                {
                    string fileName = Path.GetFileName(openFile.FileName);
                    string destinationPath = Path.Combine(@"\\172.16.0.155\Sistemas\Imagenes", fileName);
                    try
                    {
                        File.Copy(openFile.FileName, destinationPath, true);
                        cotizacion.Imagen = destinationPath;
                    }
                    catch (Exception ex)
                    {
                        // Manejar errores si ocurre algún problema al copiar la imagen
                        MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Crear un nuevo DataTable para el detalle completo con la estructura requerida
                DataTable dtDetalleCompleto = new DataTable();
                dtDetalleCompleto.Columns.Add("IdTablaElemento", typeof(int));
                dtDetalleCompleto.Columns.Add("DescripcionGastos", typeof(string));
                dtDetalleCompleto.Columns.Add("FlagAprobacion", typeof(bool));
                dtDetalleCompleto.Columns.Add("FlagEstado", typeof(bool));
                dtDetalleCompleto.Columns.Add("Costo" + " " + " S/.", typeof(decimal));
                dtDetalleCompleto.Columns.Add("Item", typeof(int)); // Nueva columna para almacenar el número de item

                // Agregar los datos de cada pestaña al DataTable dtDetalleCompleto
                AgregarDatosDePestanaAlDetalle(dtDatospestaña1, dtDetalleCompleto);

                // Obtener la lista de detalles de cotización desde el dtDetalleCompleto
                List<DetalleCotizacionProductoBE> detallesCotizacion = new List<DetalleCotizacionProductoBE>();
                foreach (DataRow row in dtDetalleCompleto.Rows)
                {
                    DetalleCotizacionProductoBE detalle = new DetalleCotizacionProductoBE
                    {
                        IdTablaElemento = Convert.ToInt32(row["IdTablaElemento"]),
                        Item = Convert.ToInt32(row["Item"]),
                        DescripcionGastos = row["DescripcionGastos"].ToString(),
                        FlagAprobacion = Convert.ToBoolean(row["FlagAprobacion"]),
                        FlagEstado = Convert.ToBoolean(row["FlagEstado"]),
                        Costo = Convert.ToDecimal(row["Costo" + " " + " S/."]) // Agregar el campo Costo
                    };
                    detallesCotizacion.Add(detalle);
                }

                // Llamada al procedimiento almacenado con la nueva estructura
                int idCotizacion = 0;
                cotizacionKiraBL.RegistrarCotizacionYDetalleProductos(cotizacion, detallesCotizacion, out idCotizacion);
                CotizacionProductoGuardada?.Invoke(this, EventArgs.Empty);
                LimpiarControlesTextBox(this.Controls);
                valorespredeterminadosdeloscbo();
                lblCodigoExistente.Text = "";
                DataTable dtVacio = new DataTable();
                gridControlPestaña1.DataSource = dtVacio;
                gridControlPestañaResumen.DataSource = dtVacio;
                this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;

               // MessageBox.Show("La cotización se registró correctamente. ID de cotización: " + idCotizacion, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DevExpress.XtraEditors.XtraMessageBox.Show("La cotización se registró correctamente. ID de cotización Precio Producto Terminado : " + idCotizacion, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la cotización: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarControlesTextBox(this.Controls);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl17_Click(object sender, EventArgs e)
        {

        }

        private void Tabcontrol_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = Tabcontrol.TabPages[e.Index];

            // Cambiar el color de fondo de las pestañas
            e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), e.Bounds);

            // Cambiar el color del texto de las pestañas
            using (Brush textBrush = new SolidBrush(Color.DarkBlue))
            {
                e.Graphics.DrawString(tabPage.Text, Tabcontrol.Font, textBrush, e.Bounds.X + 3, e.Bounds.Y + 3);
            }
        }
    }
}
