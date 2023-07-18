using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.Presentation.Modulos.KiraHogar.Consultas;

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegKiraCotizacion : DevExpress.XtraEditors.XtraForm
    {
        public frmRegKiraCotizacion()
        {
            InitializeComponent();
        }

        private void frmRegKiraCotizacion_Load(object sender, EventArgs e)
        {
            frmRegKiraCotizacion formCotizacion = new frmRegKiraCotizacion();
            formCotizacion.WindowState = FormWindowState.Maximized;
            tlbMenu.Ensamblado = this.Tag.ToString();
          
        }

        private void tlbMenu_NewClick()
        {
           
            frmCotizacion formCotizacion = new frmCotizacion();
            formCotizacion.Dock = DockStyle.Fill; // Rellenar el área del contenedor
            formCotizacion.StartPosition = FormStartPosition.CenterParent;
            formCotizacion.Show(); // Mostrar el formulario


        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
