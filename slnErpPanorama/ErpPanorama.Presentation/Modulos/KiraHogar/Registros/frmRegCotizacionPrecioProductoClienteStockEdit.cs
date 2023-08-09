using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegCotizacionPrecioProductoClienteStockEdit : DevExpress.XtraEditors.XtraForm
    {
        private int idCotizacion;
        private CotizacionKiraBE cotizacion;

        public int IdCotizacion
        {
            get { return idCotizacion; }
            set
            {
                idCotizacion = value;
                CargarCotizacion();
            }
        }

        private CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        public frmRegCotizacionPrecioProductoClienteStockEdit()
        {
            InitializeComponent();
        }

        private void frmRegCotizacionPrecioProductoClienteStockEdit_Load(object sender, EventArgs e)
        {
            CargarCotizacion();
        }

        private void CargarCotizacion()
        {
            try
            {
                if (idCotizacion > 0)
                {
                    cotizacion = cotizacionKiraBL.ObtenerCotizacionPorId(idCotizacion);

                    // Cargar los datos de la cotización en los controles
                    txtNumeroCotizacion.Text = cotizacion.IdCotizacion.ToString();
                    txtCodigoProducto.Text = cotizacion.CodigoProducto;
                    txtBreveDescripcion.Text = cotizacion.Descripcion;
                    txtCaracteristicas.Text = cotizacion.Caracteristicas;
                    txtFecha.Text = cotizacion.Fecha.ToString();

                    // Seleccionar el valor en el ComboBoxEdit cboTipoCotizacion
                    foreach (ComboTipoCotizacionBE item in cboTipoCotizacion.Properties.Items)
                    {
                        if (item.IdTablaElemento == cotizacion.IdTablaElemento)
                        {
                            cboTipoCotizacion.EditValue = item;
                            break;
                        }
                    }

                    // Seleccionar el valor en el ComboBoxEdit cboTipoMoneda
                    foreach (ComboTipoCotizacionBE item in cboTipoMoneda.Properties.Items)
                    {
                        if (item.IdTablaElemento == cotizacion.IdMoneda)
                        {
                            cboTipoMoneda.EditValue = item;
                            break;
                        }
                    }

                    picImage.Image = LoadImageFromPath(cotizacion.Imagen); // Cargar la imagen desde cotizacion.Imagen si es necesario

                    // Cargar los detalles de cotización en el GridView gvCotizacionEdit
                    gvCotizacionEdit.GridControl.DataSource = cotizacionKiraBL.ObtenerDetallesCotizacionPorId(idCotizacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image LoadImageFromPath(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                try
                {
                    return Image.FromFile(imagePath);
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }


    }
}
