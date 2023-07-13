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

            ConfigurarComboBox();
            personalizacióncontrolesform();
            cboTipoCotizacion.Text = "Seleccione un Tipo";

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


        private void ConfigurarComboBox()
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
    }
}