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

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    public partial class frmCotizacion : DevExpress.XtraEditors.XtraForm
    {
        private ComboTipoCotizacionBL comboTipoCotizacionBL;
        public frmCotizacion()
        {
            InitializeComponent();
        }

        private void frmCotizacion_Load(object sender, EventArgs e)
        {

            ConfigurarComboBoxTipoCotizacion();
            ConfigurarComboBoxMateriales();
            personalizacióncontrolesform();
            ConfiguracionNumericUpdownMaterial();
            cboTipoCotizacion.Text = "Seleccione un Tipo";
            cboMaterial.Text = "Seleccione Material";

        }

        private void personalizacióncontrolesform()
        {
            tabControl1.TabPages[0].Text = "Materiales";
            tabControl1.TabPages[1].Text = "Insumos";
            tabControl1.TabPages[2].Text = "Accesorios";
            tabControl1.TabPages[3].Text = "Mano de Obra ";
            tabControl1.TabPages[4].Text = "Movilidad y Viaticos";
            Fecha.Properties.MinValue = DateTime.Today;
            Fecha.DateTime = DateTime.Today;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox2.ScrollBars = ScrollBars.Both;
        }


        private void ConfigurarComboBoxTipoCotizacion()
        {


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


            // Configurar propiedades del control ComboBoxEdit
            cboMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

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

        private void ConfiguracionNumericUpdownMaterial()
        {
            // Establecer las propiedades del control NumericUpDown
            MontoMaterialUpDown1.Minimum = 0;
            MontoMaterialUpDown1.Maximum = 100;
            MontoMaterialUpDown1.Value = 1;
            MontoMaterialUpDown1.Increment = 1;
        }
        private void txtPeriodo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
         
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void deDesde_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoCotizacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void MontoMaterialUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Obtener el valor actual del control NumericUpDown
            int cantidad = (int)MontoMaterialUpDown1.Value;

            // Hacer algo con la cantidad seleccionada
            // Por ejemplo, mostrarla en una etiqueta
            //label1.Text = "Cantidad: " + cantidad.ToString();
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }
    }
}