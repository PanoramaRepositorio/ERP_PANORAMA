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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraGrid.Views.Grid;

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
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();

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

        private void CargarListadoCotizaciones()
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

        private void tlbMenu_Load(object sender, EventArgs e)
        {
            CargarListadoCotizaciones();
        }

        private void tlbMenu_RefreshClick()
        {
            CargarListadoCotizaciones();
            ActualizarNumeroFilas();
        }


    }
}
