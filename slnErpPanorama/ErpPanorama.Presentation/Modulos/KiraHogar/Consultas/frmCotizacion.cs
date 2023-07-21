using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors; // Agrega esta directiva para poder usar ComboBoxEdit
using ErpPanorama.Presentation.Modulos.KiraHogar.Registros;


namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    public partial class frmCotizacion : DevExpress.XtraEditors.XtraForm
    {
        public ComboTipoCotizacionBL comboTipoCotizacionBL;
        private CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        // Variable para almacenar el cuadro de diálogo de selección de archivos
        private OpenFileDialog openFile = new OpenFileDialog();
        // Declarar una variable para almacenar los detalles de cotización
        List<DetalleCotizacionBE> detalleCotizacionList = new List<DetalleCotizacionBE>();

        public frmCotizacion()
        {
            InitializeComponent();
        }

        private DataTable dtDatos;
        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            //tlbMenu.Ensamblado = this.Tag.ToString();
            CrearDatable_GridControl();
            ConfigurarComboBoxTipoCotizacion();
            ConfigurarComboBoxMateriales();
            ConfigurarComboBoxInsumo();
            ConfigurarConboBoxAccesorio();
            ConfigurarComboBoxMano();
            ConfigurarComboBoxMovilidad();
            ConfigurarComboBoxTipoMoneda();
            personalizacióncontrolesform();
            calcularTotalGastospestaña1();
            calcularTotalGastospestaña2();
            calcularTotalGastospestaña3();
            calcularTotalGastospestaña4();
            calcularTotalGastospestaña5();
            txtCodigoProducto.TextChanged += txtCodigoProducto_TextChanged;
        }
        private void tlbMenu_NewClick()
        {
            frmRegKiraCotizacion formCotizacion = new frmRegKiraCotizacion();
            formCotizacion.ShowDialog();
            MessageBox.Show("Aquí dar lógica", "Mensaje tlbMenu_NewClick", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlbMenu_EditClick()
        {
            MessageBox.Show("Aquí dar lógica", "Mensaje tlbMenu_EditClick", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CrearDatable_GridControl()
        {
            // Crear el DataTable para almacenar los datos
            dtDatos = new DataTable();
            dtDatos.Columns.Add("IdTablaElemento", typeof(int));
            dtDatos.Columns.Add("Item", typeof(int));
            dtDatos.Columns.Add("DescripcionGastos", typeof(string));
            dtDatos.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatos.Columns.Add("FlagEstado", typeof(bool));
            dtDatos.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total
            // Asignar el DataTable como fuente de datos para cada GridControl
            gridControlPestaña1.DataSource = dtDatos;
            gridControlPestaña2.DataSource = dtDatos;
            gridControlPestaña3.DataSource = dtDatos;
            gridControlPestaña4.DataSource = dtDatos;
            gridControlPestaña5.DataSource = dtDatos;

        }
        private void personalizacióncontrolesform()
        {
            Tabcontrol.TabPages[0].Text = "Materiales";
            Tabcontrol.TabPages[1].Text = "Insumos";
            Tabcontrol.TabPages[2].Text = "Accesorios";
            Tabcontrol.TabPages[3].Text = "Mano de Obra ";
            Tabcontrol.TabPages[4].Text = "Movilidad y Viaticos";
            Tabcontrol.TabPages[5].Text = "Equipos y Herramientas";
            Tabcontrol.TabPages[6].Text = "Resumen";
            txtFecha.Properties.MinValue = DateTime.Today;
            txtFecha.DateTime = DateTime.Today;
            txtCaracteristicas.ScrollBars = ScrollBars.Vertical;
            txtCaracteristicas.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Both;
        }


        /// <summary>
        /// Metodos de llenar datos a los combos de la BD
        /// </summary>
        private void ConfigurarComboBoxTipoCotizacion()
        {
            cboTipoCotizacion.Text = "Seleccione un Tipo";
            // Configurar propiedades del control ComboBoxEdit
            cboTipoCotizacion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // Crear instancia de ComboTipoCotizacionBL
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            // Obtener la lista de objetos ComboTipoCotizacionBE
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = comboTipoCotizacionBL.ObtenerComboTipoCotizacion();
            // Limpiar los elementos existentes en el ComboBoxEdit
            cboTipoCotizacion.Properties.Items.Clear();
            // Agregar elementos al ComboBoxEdit
            foreach (var item in listaComboTipoCotizacion)
            {
                cboTipoCotizacion.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        private void ConfigurarComboBoxMateriales()
        {
            cboMaterial.Text = "Seleccione Material";
            cboMaterial.Properties.TextEditStyle = TextEditStyles.Standard;
            cboMaterial.Properties.AutoComplete = true;
            cboMaterial.Properties.CaseSensitiveSearch = false;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = comboTipoCotizacionBL.ObtenerComboMateriales();
            cboMaterial.Properties.Items.Clear();
            foreach (var item in listaComboTipoCotizacion)
            {
                cboMaterial.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        public void ConfigurarComboBoxInsumo()
        {
            cboInsumos.Text = "Selecione Insumo";
            cboInsumos.Properties.TextEditStyle = TextEditStyles.Standard;
            cboInsumos.Properties.AutoComplete = true;
            cboInsumos.Properties.CaseSensitiveSearch = false;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaComboTipoIsumo = comboTipoCotizacionBL.ObtenerComboInsumo();
            cboInsumos.Properties.Items.Clear();
            foreach (var item in listaComboTipoIsumo)
            {
                cboInsumos.Properties.Items.Add(item.DescTablaElemento);
            }

        }
        public void ConfigurarConboBoxAccesorio()
        {
            cboAccesorios.Text = "Seleccione Accesorio";
            cboAccesorios.Properties.TextEditStyle = TextEditStyles.Standard;
            cboAccesorios.Properties.AutoComplete = true;
            cboAccesorios.Properties.CaseSensitiveSearch = false;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaaccesorio = comboTipoCotizacionBL.ObtenerAccesorios();
            cboAccesorios.Properties.Items.Clear();
            foreach (var item in listaaccesorio)
            {
                cboAccesorios.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        public void ConfigurarComboBoxMano()
        {
            cboManoObra.Text = "Seleccione Mano de Obra";
            cboManoObra.Properties.TextEditStyle = TextEditStyles.Standard;
            cboManoObra.Properties.AutoComplete = true;
            cboManoObra.Properties.CaseSensitiveSearch = false;
            List<ComboTipoCotizacionBE> listamanoobra = comboTipoCotizacionBL.ObtenerManoObra();
            cboManoObra.Properties.Items.Clear();
            foreach (var item in listamanoobra)
            {
                cboManoObra.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        public void ConfigurarComboBoxMovilidad()
        {
            cboSeleccionaMovilidad.Text = "Seleccione Movilidad - Viaticos";
            cboSeleccionaMovilidad.Properties.TextEditStyle = TextEditStyles.Standard;
            cboSeleccionaMovilidad.Properties.AutoComplete = true;
            cboSeleccionaMovilidad.Properties.CaseSensitiveSearch = false;
            List<ComboTipoCotizacionBE> listamovi = comboTipoCotizacionBL.ObtenerMovilidadyViaticos();
            // Configurar el ComboBox
            cboSeleccionaMovilidad.Properties.Items.Clear();
            foreach (ComboTipoCotizacionBE item in listamovi)
            {
                cboSeleccionaMovilidad.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        public void ConfigurarComboBoxTipoMoneda()
        {
            cboTipoMoneda.Text = "Seleccione Moneda";
            cboTipoMoneda.Properties.TextEditStyle = TextEditStyles.Standard;
            cboTipoMoneda.Properties.AutoComplete = true;
            cboTipoMoneda.Properties.CaseSensitiveSearch = false;
            List<ComboTipoCotizacionBE> listamone = comboTipoCotizacionBL.ObtenerComboTipoMoneda();
            // Configurar el ComboBox
            cboTipoMoneda.Properties.Items.Clear();
            foreach (ComboTipoCotizacionBE item in listamone)
            {
                cboTipoMoneda.Properties.Items.Add(item.DescTablaElemento);
            }
        }



        /// <summary>
        /// Metodos agregar valores a los combos despues de alguna operación (guardar)
        /// </summary>
        public void valorespredeterminadosdeloscbo()


        {
            string cboTipoCotizacionDefault = "Seleccione un Tipo";
            string cboMaterialDefault = "Seleccione Material";
            string cboInsumosDefault = "Selecione Insumo";
            string cboAccesoriosDefault = "Seleccione Accesorio";
            string cboManoObraDefault = "Seleccione Mano de Obra";
            string cboSeleccionaMovilidadDefault = "Seleccione Movilidad - Viaticos";
            string cboTipoMonedaDefault = "Seleccione Moneda";
            // Restaurar los valores predeterminados en los comboboxes
            cboTipoCotizacion.Text = cboTipoCotizacionDefault;
            cboMaterial.Text = cboMaterialDefault;
            cboInsumos.Text = cboInsumosDefault;
            cboAccesorios.Text = cboAccesoriosDefault;
            cboManoObra.Text = cboManoObraDefault;
            cboSeleccionaMovilidad.Text = cboSeleccionaMovilidadDefault;
            cboTipoMoneda.Text = cboTipoMonedaDefault;
        }
        
        
        /// <summary>
        /// Metodos que lo que hace es sumar el monto de cada Item del GridControl de cada Pestaña
        /// </summary>
        public void calcularTotalGastospestaña1()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña1.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = 0.4m; // Valor de J69 (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = precioVenta.ToString();
            }
            else
            {
                // Manejar la situación cuando totalGastos es cero
                // Por ejemplo, puedes mostrar un mensaje de error o asignar un valor predeterminado al precio de venta.
                cotizacion.PrecioVenta = 0; // Asignar un valor predeterminado
                txtPrecioVenta.Text = "Error: totalGastos no puede ser cero";
            }
        }
        public void calcularTotalGastospestaña2()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña2.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = 0.4m; // Valor de J69 (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = precioVenta.ToString();
            }
            else
            {
                // Manejar la situación cuando totalGastos es cero
                // Por ejemplo, puedes mostrar un mensaje de error o asignar un valor predeterminado al precio de venta.
                cotizacion.PrecioVenta = 0; // Asignar un valor predeterminado
                txtPrecioVenta.Text = "Error: totalGastos no puede ser cero";
            }
        }
        public void calcularTotalGastospestaña3()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña3.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = 0.4m; // (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = precioVenta.ToString();
            }
            else
            {
                // Manejar la situación cuando totalGastos es cero
                // Por ejemplo, puedes mostrar un mensaje de error o asignar un valor predeterminado al precio de venta.
                cotizacion.PrecioVenta = 0; // Asignar un valor predeterminado
                txtPrecioVenta.Text = "Error: totalGastos no puede ser cero";
            }
        }
        public void calcularTotalGastospestaña4()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña4.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = 0.4m; // Valor de J69 (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = precioVenta.ToString();
            }
            else
            {
                // Manejar la situación cuando totalGastos es cero
                // Por ejemplo, puedes mostrar un mensaje de error o asignar un valor predeterminado al precio de venta.
                cotizacion.PrecioVenta = 0; // Asignar un valor predeterminado
                txtPrecioVenta.Text = "Error: totalGastos no puede ser cero";
            }
        }
        public void calcularTotalGastospestaña5()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = 0.4m; // Valor de J69 (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = precioVenta.ToString();
            }
            else
            {
                // Manejar la situación cuando totalGastos es cero
                // Por ejemplo, puedes mostrar un mensaje de error o asignar un valor predeterminado al precio de venta.
                cotizacion.PrecioVenta = 0; // Asignar un valor predeterminado
                txtPrecioVenta.Text = "Error: totalGastos no puede ser cero";
            }
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodos de los botones agregar de cada pesataña TAB
        /// </summary>
        private void btnAgregarPestaña1_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles NumericUpDown y ComboBoxEdit
            string material = cboMaterial.Text;
            string monto = txtPrecio.Text;
            // Verificar si se ha seleccionado un material
            if (string.IsNullOrWhiteSpace(material))
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
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboMateriales()
                .FirstOrDefault(x => x.DescTablaElemento == cboMaterial.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña5
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == material);

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
                newRow["DescripcionGastos"] = material;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }

            cboMaterial.Text = "Seleccione Materiales";
            txtPrecio.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();
            calcularTotalGastospestaña1();
        }
        private void btnAgregarPestaña2_Click(object sender, EventArgs e)
        {
            string insumo = cboInsumos.Text;
            string monto = txtinsumo.Text;
            if (string.IsNullOrWhiteSpace(insumo))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboInsumo()
                .FirstOrDefault(x => x.DescTablaElemento == cboInsumos.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña5
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == insumo);
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
                newRow["DescripcionGastos"] = insumo;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }

            cboInsumos.Text = "Seleccione Insumos";
            txtinsumo.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();
            calcularTotalGastospestaña2();
        }
        private void btnAgregarPestaña3_Click(object sender, EventArgs e)
        {
            string accesorio = cboAccesorios.Text;
            string monto = txtMontoaccesorio.Text;
            if (string.IsNullOrWhiteSpace(accesorio))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerAccesorios()
                .FirstOrDefault(x => x.DescTablaElemento == cboAccesorios.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña5
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == accesorio);

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
                newRow["DescripcionGastos"] = accesorio;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }

            cboAccesorios.Text = "Seleccione Accesorio";
            txtMontoaccesorio.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();
            calcularTotalGastospestaña3();
        }
        private void btnAgregarPestaña4_Click(object sender, EventArgs e)
        {
            string manoobra = cboManoObra.Text;
            string monto = txtManoobra.Text;
            if (string.IsNullOrWhiteSpace(manoobra))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerManoObra()
                .FirstOrDefault(x => x.DescTablaElemento == cboManoObra.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña5
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == manoobra);

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
                newRow["DescripcionGastos"] = manoobra;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }

            cboManoObra.Text = "Seleccione Mano de Obra";
            txtManoobra.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();
            calcularTotalGastospestaña4();

        }
        private void btnAgregarPestaña5_Click(object sender, EventArgs e)
        {


            string movilidad = cboSeleccionaMovilidad.Text;
            string monto = txtMovilidad.Text;

            if (string.IsNullOrWhiteSpace(movilidad))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerMovilidadyViaticos()
                .FirstOrDefault(x => x.DescTablaElemento == cboSeleccionaMovilidad.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña5
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == movilidad);

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
                newRow["DescripcionGastos"] = movilidad;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }

            cboSeleccionaMovilidad.Text = "Seleccione Movilidad - viaticos";
            txtMovilidad.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();
            calcularTotalGastospestaña5();

        }


        /// <summary>
        /// Metodos que obtiene las filas del Gridcontrol para posterior usarlo 
        /// en RegistrarCotizacionYDetalle
        /// </summary>
        private DataTable ObtenerDataTableDetalle()
        {
            // Obtener el DataTable del DataSource del gridControlPestaña1
            if (gridControlPestaña1.DataSource is DataTable dataTable)
            {
                return dataTable;
            }
            else
            {
                return null;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
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
                CotizacionKiraBE cotizacion = new CotizacionKiraBE
                {
                    IdTablaElemento = idTipoCotizacion, // IdTipoCotizacion obtenido del ComboBox de Tipo de Cotización
                    Fecha = txtFecha.DateTime,
                    CodigoProducto = txtCodigoProducto.Text,
                    Descripcion = txtBreveDescripcion.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Imagen = "",
                    TotalGastos = decimal.TryParse(txtTotal.Text, out decimal totalGastos) ? totalGastos : 0.0m,
                    PrecioVenta = decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m,
                    IdMoneda = idMoneda // IdMoneda obtenido del ComboBox de Tipo de Moneda
                };
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

                // Obtener el DataTable del detalle usando el método auxiliar
                DataTable dtDetalle = ObtenerDataTableDetalle();
                // Verificar que el DataTable del detalle no sea nulo y contenga filas
                if (dtDetalle == null || dtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Debe ingresar al menos un detalle de cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Obtener la lista de detalles de cotización desde el dtDetalle
                List<DetalleCotizacionBE> detallesCotizacion = new List<DetalleCotizacionBE>();
                foreach (DataRow row in dtDetalle.Rows)
                {
                    DetalleCotizacionBE detalle = new DetalleCotizacionBE
                    {
                        IdTablaElemento = Convert.ToInt32(row["IdTablaElemento"]),
                        Item = Convert.ToInt32(row["Item"]),
                        DescripcionGastos = row["DescripcionGastos"].ToString(),
                        FlagAprobacion = true,
                        FlagEstado = true
                    };
                    detallesCotizacion.Add(detalle);
                }
               cotizacionKiraBL.RegistrarCotizacionYDetalle(cotizacion, detallesCotizacion);
                LimpiarControlesTextBox(this.Controls);
                valorespredeterminadosdeloscbo();
                lblCodigoExistente.Text = "";
                DataTable dtVacio = new DataTable();
                gridControlPestaña1.DataSource = dtVacio;
                gridControlPestaña2.DataSource = dtVacio;
                gridControlPestaña3.DataSource = dtVacio;
                gridControlPestaña4.DataSource = dtVacio;
                gridControlPestaña5.DataSource = dtVacio;
                this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
                MessageBox.Show("La cotización se registró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la cotización: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarControlesTextBox(this.Controls);
            }
        }
        public void LimpiarControlesTextBox(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
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
        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            CotizacionKiraBL cotizacionKiraBLs = new CotizacionKiraBL();
            if (cotizacionKiraBLs.ValidarCodigoProducto(txtCodigoProducto.Text))
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

    }


}