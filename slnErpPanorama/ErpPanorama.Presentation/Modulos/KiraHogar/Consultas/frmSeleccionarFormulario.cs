using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.Presentation.Modulos.KiraHogar.Registros;

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    public partial class frmSeleccionarFormulario : DevExpress.XtraEditors.XtraForm
    {
        public frmSeleccionarFormulario()
        {
            InitializeComponent();
        }

        // Agregar una propiedad para almacenar la selección del formulario
        public string FormularioSeleccionado { get; private set; }

        private void frmSeleccionarFormulario_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrirCotizacion_Click(object sender, EventArgs e)
        {
            FormularioSeleccionado = "Cotizacion";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAbrirProductoTerminado_Click(object sender, EventArgs e)
        {
            FormularioSeleccionado = "ProductoTerminado";
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
