using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors; // Agrega esta directiva para poder usar ComboBoxEdit
using ErpPanorama.Presentation.Modulos.KiraHogar.Registros;


namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    public partial class frmCotizacion : DevExpress.XtraEditors.XtraForm
    {
        public ComboTipoCotizacionBL comboTipoCotizacionBL;

        // Declarar el diccionario como un campo de la clase
        private Dictionary<TabPage, ComboBoxEdit> comboBoxesByTabPage;
        private ComboBoxEdit selectedComboBox; // Variable para almacenar el ComboBox seleccionado

        private DataTable dtDatosActual;
        // Declarar una variable para almacenar los detalles de cotización
        List<DetalleCotizacionBE> detalleCotizacionList = new List<DetalleCotizacionBE>();



        public frmCotizacion()
        {
            InitializeComponent();

            // Inicializar el diccionario en el constructor
            comboBoxesByTabPage = new Dictionary<TabPage, ComboBoxEdit>
            {
                { tabPage1, cboMaterial },
                { tabPage2, cboInsumos },
                { tabPage3, cboAccesorios },
                { tabPage4, cboManoObra },
                { tabPage5, cboSeleccionaMovilidad }
            };
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
            personalizacióncontrolesform();
            calcularTotalGastospestaña1();
            calcularTotalGastospestaña2();
            calcularTotalGastospestaña3();
            calcularTotalGastospestaña4();
            calcularTotalGastospestaña5();
            // Agregar eventos de selección para los ComboBoxes en cada pestaña
            cboMaterial.SelectedIndexChanged += cboMaterial_SelectedIndexChanged;
            cboInsumos.SelectedIndexChanged += cboInsumos_SelectedIndexChanged;
            cboAccesorios.SelectedIndexChanged += cboAccesorios_SelectedIndexChanged;
            cboManoObra.SelectedIndexChanged += cboManoObra_SelectedIndexChanged;
            cboSeleccionaMovilidad.SelectedIndexChanged += cboSeleccionaMovilidad_SelectedIndexChanged;
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
            txtFecha.Properties.MinValue = DateTime.Today;
            txtFecha.DateTime = DateTime.Today;
            txtCaracteristicas.ScrollBars = ScrollBars.Vertical;
            txtCaracteristicas.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Both;
        }



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
        /// Eventos de los botones agregar de cada pesataña TAB
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
            if(!decimal.TryParse(monto, out decimal montoDecimal))
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

        private int ObtenerIdTablaElemento(ComboBoxEdit comboBox)
        {
            if (comboBox.SelectedIndex != -1)
            {
                ComboTipoCotizacionBE comboTipoCotizacionBE = comboTipoCotizacionBL.ObtenerComboTipoCotizacion().FirstOrDefault(x => x.DescTablaElemento == comboBox.SelectedItem.ToString());
                if (comboTipoCotizacionBE != null)
                {
                    return comboTipoCotizacionBE.IdTablaElemento;
                }
            }
            return 0; // O un valor adecuado según tu lógica de negocio
        }

        //private void btnguardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
        //        ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboTipoCotizacion()
        //            .FirstOrDefault(x => x.DescTablaElemento == cboTipoCotizacion.Text);

        //        if (itemSeleccionado == null)
        //        {
        //            MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        int idTablaElemento = itemSeleccionado.IdTablaElemento;

        //        // Crear objeto CotizacionKiraBE con los valores ingresados por el usuario
        //        CotizacionKiraBE cotizacion = new CotizacionKiraBE
        //        {
        //            IdTablaElemento = idTablaElemento,
        //            Fecha = txtFecha.DateTime,
        //            CodigoProducto = txtCodigoProducto.Text,
        //            Descripcion = txtBreveDescripcion.Text,
        //            Caracteristicas = txtCaracteristicas.Text,
        //            Imagen = txtUrlimagen.Text,
        //            TotalGastos = decimal.TryParse(txtTotal.Text, out decimal totalGastos) ? totalGastos : 0.0m,
        //            PrecioVenta = decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m
        //        };

        //        // Obtener el DataTable del DataSource del gridControlPestaña1
        //        DataTable dtDetalle = (DataTable)gridControlPestaña1.DataSource;

        //        // Verificar que el DataTable del detalle no sea nulo y contenga filas
        //        if (dtDetalle == null || dtDetalle.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Debe ingresar al menos un detalle de cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        //Crear un objeto DataTable con la estructura del tipo dbo.DetalleCotizacionType
        //        DataTable dtDetalleCotizacion = new DataTable();
        //        dtDetalleCotizacion.Columns.Add("IdTablaElemento", typeof(int));
        //        dtDetalleCotizacion.Columns.Add("Item", typeof(int));
        //        dtDetalleCotizacion.Columns.Add("DescripcionGastos", typeof(string));
        //        dtDetalleCotizacion.Columns.Add("FlagAprobacion", typeof(bool));
        //        dtDetalleCotizacion.Columns.Add("FlagEstado", typeof(bool));

        //        // Iterar sobre las filas del DataTable del detalle y agregar cada fila al DataTable dtDetalleCotizacion
        //        foreach (DataRow row in dtDetalle.Rows)
        //        {
        //            int idTablaElementoDetalle = Convert.ToInt32(row["IdTablaElemento"]);
        //            DataRow newRow = dtDetalleCotizacion.NewRow();
        //            newRow["IdTablaElemento"] = idTablaElementoDetalle;
        //            newRow["Item"] = Convert.ToInt32(row["Item"]);
        //            newRow["DescripcionGastos"] = row["DescripcionGastos"].ToString();
        //            newRow["FlagAprobacion"] = true;
        //            newRow["FlagEstado"] = true;
        //            dtDetalleCotizacion.Rows.Add(newRow);
        //        }

        //        // Verificar el contenido del DataTable dtDetalleCotizacion antes de guardar
        //        foreach (DataRow row in dtDetalleCotizacion.Rows)
        //        {
        //            Console.WriteLine($"IdTablaElemento: {row["IdTablaElemento"]}, Item: {row["Item"]}, DescripcionGastos: {row["DescripcionGastos"]},FlagAprobacion: {row["FlagAprobacion"]}, FlagEstado : {row["FlagEstado"]} ");
        //        }

        //        // Imprimir contenido del DataTable dtDetalle
        //        Console.WriteLine("Contenido de dtDetalle:");
        //        foreach (DataRow row in dtDetalle.Rows)
        //        {
        //            Console.WriteLine($"IdTablaElemento: {row["IdTablaElemento"]}, Item: {row["Item"]}, DescripcionGastos: {row["DescripcionGastos"]}");
        //        }

        //        // Imprimir contenido del DataTable dtDetalleCotizacion
        //        Console.WriteLine("Contenido de dtDetalleCotizacion:");
        //        foreach (DataRow row in dtDetalleCotizacion.Rows)
        //        {
        //            Console.WriteLine($"IdTablaElemento: {row["IdTablaElemento"]}, Item: {row["Item"]}, DescripcionGastos: {row["DescripcionGastos"]}, FlagAprobacion: {row["FlagAprobacion"]}, FlagEstado: {row["FlagEstado"]}");
        //        }


        //        // Llamar al método RegistrarCotizacionYDetalle de CotizacionKiraBL
        //        CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        //        cotizacionKiraBL.RegistrarCotizacionYDetalle(cotizacion, dtDetalleCotizacion);

        //        MessageBox.Show("La cotización se registró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al guardar la cotización: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Agregar este método en la clase de la presentación
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
                // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
                ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboTipoCotizacion()
                    .FirstOrDefault(x => x.DescTablaElemento == cboTipoCotizacion.Text);

                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idTablaElemento = itemSeleccionado.IdTablaElemento;

                // Crear objeto CotizacionKiraBE con los valores ingresados por el usuario
                CotizacionKiraBE cotizacion = new CotizacionKiraBE
                {
                    IdTablaElemento = idTablaElemento,
                    Fecha = txtFecha.DateTime,
                    CodigoProducto = txtCodigoProducto.Text,
                    Descripcion = txtBreveDescripcion.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Imagen = txtUrlimagen.Text,
                    TotalGastos = decimal.TryParse(txtTotal.Text, out decimal totalGastos) ? totalGastos : 0.0m,
                    PrecioVenta = decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m
                };

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

                // Llamar al método RegistrarCotizacionYDetalle de CotizacionKiraBL
                CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
                cotizacionKiraBL.RegistrarCotizacionYDetalle(cotizacion, detallesCotizacion);

                MessageBox.Show("La cotización se registró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la cotización: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedItem != null)
            {
                string materialSeleccionado = cboMaterial.SelectedItem.ToString();
                
            }
        }

        private void cboInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInsumos.SelectedItem != null)
            {
                string insumoSeleccionado = cboInsumos.SelectedItem.ToString();
                
            }
        }

        private void cboAccesorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAccesorios.SelectedItem != null)
            {
                string accesorioSeleccionado = cboAccesorios.SelectedItem.ToString();
               
            }
        }

        private void cboManoObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManoObra.SelectedItem != null)
            {
                string manoObraSeleccionada = cboManoObra.SelectedItem.ToString();
                
            }
        }

        private void cboSeleccionaMovilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSeleccionaMovilidad.SelectedItem != null)
            {
                string movilidadSeleccionada = cboSeleccionaMovilidad.SelectedItem.ToString();
                
            }
        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }
    }
}