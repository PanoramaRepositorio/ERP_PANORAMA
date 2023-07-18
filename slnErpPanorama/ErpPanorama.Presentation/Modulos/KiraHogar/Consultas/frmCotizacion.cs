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
using ErpPanorama.Presentation.Modulos.KiraHogar.Registros;

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    public partial class frmCotizacion : DevExpress.XtraEditors.XtraForm
    {
        public ComboTipoCotizacionBL comboTipoCotizacionBL;
        //public ComboTipoCotizacionBL comboTipoCotizacionBL;
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
            personalizacióncontrolesform();




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
            dtDatos.Columns.Add("Descripción", typeof(string));
            dtDatos.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total

            // Asignar el DataTable como fuente de datos para cada GridControl
            gridControlPestaña1.DataSource = dtDatos;
            gridControlPestaña2.DataSource = dtDatos;
            gridControlPestaña3.DataSource = dtDatos;
            gridControlPestaña4.DataSource = dtDatos;
            gridControlPestaña5.DataSource = dtDatos;

            // Suscribirte al evento SelectedIndexChanged del ComboBoxEdit
            
        }

        private void personalizacióncontrolesform()
        {
            grid.TabPages[0].Text = "Materiales";
            grid.TabPages[1].Text = "Insumos";
            grid.TabPages[2].Text = "Accesorios";
            grid.TabPages[3].Text = "Mano de Obra ";
            grid.TabPages[4].Text = "Movilidad y Viaticos";
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
            // Configurar ComboBoxEdit
            cboMaterial.Properties.TextEditStyle = TextEditStyles.Standard;
            cboMaterial.Properties.AutoComplete = true;
            cboMaterial.Properties.CaseSensitiveSearch = false;
            // Configurar propiedades del control ComboBoxEdit
            //cboMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // Crear instancia de ComboTipoCotizacionBL
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            // Obtener la lista de objetos ComboTipoCotizacionBE
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = comboTipoCotizacionBL.ObtenerComboMateriales();
            // Limpiar los elementos existentes en el ComboBoxEdit
            cboMaterial.Properties.Items.Clear();
            // Agregar elementos al ComboBoxEdit
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
            cboSeleccionaMovilidad.Properties.Items.Clear();
            foreach (var item in listamovi)
            {
                cboSeleccionaMovilidad.Properties.Items.Add(item.DescTablaElemento);
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
            // Obtener el DataTable del DataSource del GridControl
            DataTable dt = (DataTable)gridControlPestaña1.DataSource;
            // Agregar una nueva fila al DataTable con los valores correspondientes
            DataRow newRow = dt.NewRow();
            newRow["Descripción"] = material;
            newRow["Costo" + " " + " S/."] = monto;
            dt.Rows.Add(newRow);

            // Limpiar los controles NumericUpDown y ComboBoxEdit

            cboMaterial.Text = "Seleccione Material";
            txtPrecio.Text = string.Empty;

            // Refrescar el GridControl para mostrar los nuevos datos
            gridControlPestaña1.RefreshDataSource();
        }
        private void btnAgregarPestaña2_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles NumericUpDown y ComboBoxEdit

            string insumo = cboInsumos.Text;
            string monto = txtinsumo.Text;

            // Verificar si se ha seleccionado un material
            if (string.IsNullOrWhiteSpace(insumo))
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
            // Obtener el DataTable del DataSource del GridControl
            DataTable dt = (DataTable)gridControlPestaña2.DataSource;
            // Agregar una nueva fila al DataTable con los valores correspondientes
            DataRow newRow = dt.NewRow();
            newRow["Descripción"] = insumo;
            newRow["Costo" + " " + " S/."] = monto;
            dt.Rows.Add(newRow);

            // Limpiar los controles NumericUpDown y ComboBoxEdit

            cboInsumos.Text = "Seleccione Material";
            txtinsumo.Text = string.Empty;

            // Refrescar el GridControl para mostrar los nuevos datos
            gridControlPestaña2.RefreshDataSource();
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
            DataTable dt = (DataTable)gridControlPestaña3.DataSource;
            DataRow newRow = dt.NewRow();
            newRow["Descripción"] = accesorio;
            newRow["Costo" + " " + " S/."] = monto;
            dt.Rows.Add(newRow);
            cboAccesorios.Text = "Seleccione Accesorio";
            txtMontoaccesorio.Text = string.Empty;
            gridControlPestaña3.RefreshDataSource();
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
            DataTable dt = (DataTable)gridControlPestaña3.DataSource;
            DataRow newRow = dt.NewRow();
            newRow["Descripción"] = manoobra;
            newRow["Costo" + " " + " S/."] = monto;
            dt.Rows.Add(newRow);
            cboManoObra.Text = "Seleccione Mano de obra";
            txtManoobra.Text = string.Empty;
            gridControlPestaña4.RefreshDataSource();

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
            DataTable dt = (DataTable)gridControlPestaña3.DataSource;
            DataRow newRow = dt.NewRow();
            newRow["Descripción"] = movilidad;
            newRow["Costo" + " " + " S/."] = monto;
            dt.Rows.Add(newRow);
            cboSeleccionaMovilidad.Text = "Seleccione Movilidad - viaticos";
            txtMovilidad.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();

        }
    }
}