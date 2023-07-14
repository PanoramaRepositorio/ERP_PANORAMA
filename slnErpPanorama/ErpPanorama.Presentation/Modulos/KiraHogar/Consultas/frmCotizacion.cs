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


            tlbMenu.Ensamblado = this.Tag.ToString();
            CrearDatable_GridControl();
            ConfigurarComboBoxTipoCotizacion();
            ConfigurarComboBoxMateriales();
            ConfigurarComboBoxInsumo();
            personalizacióncontrolesform();




        }

        private void tlbMenu_NewClick()
        {
            MessageBox.Show("Aquí dar lógica", "Mensaje tlbMenu_NewClick", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlbMenu_EditClick() { 
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
            cboMaterial.SelectedIndexChanged += cboMaterial_SelectedIndexChanged;
        }

        private void personalizacióncontrolesform()
        {
            grid.TabPages[0].Text = "Materiales";
            grid.TabPages[1].Text = "Insumos";
            grid.TabPages[2].Text = "Accesorios";
            grid.TabPages[3].Text = "Mano de Obra ";
            grid.TabPages[4].Text = "Movilidad y Viaticos";
            Fecha.Properties.MinValue = DateTime.Today;
            Fecha.DateTime = DateTime.Today;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox2.ScrollBars = ScrollBars.Both;
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



        private void MontoMaterialUpDown1_ValueChanged(object sender, EventArgs e)
        {
          
        }

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

        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
        

        }

        private void btnAgregarPestaña2_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles NumericUpDown y ComboBoxEdit

            string material = cboInsumos.Text;
            string monto = textEdit2.Text;

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
            DataTable dt = (DataTable)gridControlPestaña2.DataSource;
            // Agregar una nueva fila al DataTable con los valores correspondientes
            DataRow newRow = dt.NewRow();
            newRow["Descripción"] = material;
            newRow["Costo" + " " + " S/."] = monto;
            dt.Rows.Add(newRow);

            // Limpiar los controles NumericUpDown y ComboBoxEdit

            cboInsumos.Text = "Seleccione Material";
            textEdit2.Text = string.Empty;

            // Refrescar el GridControl para mostrar los nuevos datos
            gridControlPestaña2.RefreshDataSource();
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}