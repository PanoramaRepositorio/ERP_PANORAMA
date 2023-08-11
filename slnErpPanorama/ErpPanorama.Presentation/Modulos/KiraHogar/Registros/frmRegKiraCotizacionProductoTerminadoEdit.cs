using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegKiraCotizacionProductoTerminadoEdit : DevExpress.XtraEditors.XtraForm
    {

        private int idCotizacion;
        private CotizacionKiraProductoTerminadoBE cotizacion;
        private OpenFileDialog openFile = new OpenFileDialog();
        private CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        private ComboTipoCotizacionBL comboTipoCotizacionBL = new ComboTipoCotizacionBL();
        private frmRegKiraCotizacion formRegKiraCotizacion;
        public CotizacionKiraProductoTerminadoBE Cotizacion { get; set; }
        public int IdCotizacion
        {
            get { return idCotizacion; }
            set
            {
                idCotizacion = value;
                CargarCotizacion();

            }
        }
        public frmRegKiraCotizacionProductoTerminadoEdit()
        {
            InitializeComponent();
        }

        private void frmRegKiraCotizacionProductoTerminadoEdit_Load(object sender, EventArgs e)
        {
            CargarCotizacion();
            txtCodigoProducto.Properties.MaxLength = 0;
            txtCaracteristicas.ScrollBars = ScrollBars.Vertical;
            txtCaracteristicas.ScrollBars = ScrollBars.Horizontal;
            txtCaracteristicas.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Vertical;
            txtBreveDescripcion.ScrollBars = ScrollBars.Horizontal;
            txtNumeroCotizacion.Enabled = false;
        }
        private string originalImagePath;
        private void CargarCotizacion()
        {
            try
            {
                if (idCotizacion > 0)
                {
                    cotizacion = cotizacionKiraBL.ObtenerCotizacionProductoPorId(idCotizacion);

                    // Cargar los datos de la cotización en los controles
                    txtNumeroCotizacion.Text = cotizacion.IdCotizacion.ToString();
                    txtCodigoProducto.Text = cotizacion.CodigoProducto;
                    txtBreveDescripcion.Text = cotizacion.Descripcion;
                    txtCaracteristicas.Text = cotizacion.Caracteristicas;
                    txtFecha.Text = cotizacion.Fecha.ToString();
                    txtFecha.ReadOnly = true; // Deshabilitar la edición
                    // Cargar los combos usando métodos de configuración
                    ConfigurarComboBoxTipoCotizacion();
                    ConfigurarComboBoxTipoMoneda();

                    // Seleccionar el valor en el ComboBoxEdit cboTipoCotizacion
                    cboTipoCotizacion.EditValue = cotizacion.DescTablaElemento;
                    cboTipoCotizacion.ReadOnly = true; // Deshabilitar la edición
                    // Seleccionar el valor en el ComboBoxEdit cboTipoMoneda

                    if (cotizacion.IdMoneda == 6)
                    {
                        cboTipoMoneda.EditValue = "DOLARES AMERICANOS";
                    }
                    else if (cotizacion.IdMoneda == 5)
                    {
                        cboTipoMoneda.EditValue = "SOLES";
                    }
                    cboTipoMoneda.ReadOnly = true; // Deshabilitar la edición

                    if (picImage.Image == null)
                    {
                        this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
                    }
                    else
                    {
                        picImage.Image = LoadImageFromPath(cotizacion.Imagen); // Cargar la imagen desde cotizacion.Imagen si es necesario
                                                                               // Almacenar la ruta original de la imagen
                        originalImagePath = cotizacion.Imagen;
                    }

                    // Cargar los detalles de cotización en el GridView gvCotizacionEdit
                    gvCotizacionProductoEdit.GridControl.DataSource = cotizacionKiraBL.ObtenerCotizacionproductoPorId2(idCotizacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarComboBoxTipoCotizacion()
        {
            cboTipoCotizacion.Text = "Seleccione un Tipo";
            cboTipoCotizacion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = comboTipoCotizacionBL.ObtenerComboTipoCotizacion();
            cboTipoCotizacion.Properties.Items.Clear();
            foreach (var item in listaComboTipoCotizacion)
            {
                cboTipoCotizacion.Properties.Items.Add(item.DescTablaElemento);
            }
        }

        private void ConfigurarComboBoxTipoMoneda()
        {
            cboTipoMoneda.Text = "Seleccione Moneda";
            cboTipoMoneda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<ComboTipoCotizacionBE> listamone = comboTipoCotizacionBL.ObtenerComboTipoMoneda();
            cboTipoMoneda.Properties.Items.Clear();
            foreach (var item in listamone)
            {
                if (item.IdTablaElemento == 6)
                {
                    cboTipoMoneda.Properties.Items.Add("DOLARES AMERICANOS");
                }
                else if (item.IdTablaElemento == 5)
                {
                    cboTipoMoneda.Properties.Items.Add("SOLES");
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener los datos de la cotización desde los controles
                CotizacionKiraProductoTerminadoBE cotizacion = new CotizacionKiraProductoTerminadoBE();
                cotizacion.IdCotizacion = Convert.ToInt32(txtNumeroCotizacion.Text);
                cotizacion.CodigoProducto = txtCodigoProducto.Text;
                cotizacion.Descripcion = txtBreveDescripcion.Text;
                cotizacion.Caracteristicas = txtCaracteristicas.Text;
                // Verificar si la imagen se ha modificado antes de intentar copiarla y actualizar la ruta
                bool imagenModificada = false;

                if (picImage.Image != null && !string.IsNullOrEmpty(openFile.FileName))
                {
                    string fileName = Path.GetFileName(openFile.FileName);
                    string destinationPath = Path.Combine(@"\\172.16.0.155\Sistemas\Imagenes", fileName);
                    try
                    {
                        File.Copy(openFile.FileName, destinationPath, true);
                        cotizacion.Imagen = destinationPath;
                        imagenModificada = true; // Establecer la bandera en true si la imagen se ha modificado
                    }
                    catch (Exception ex)
                    {
                        // Manejar errores si ocurre algún problema al copiar la imagen
                        MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (!string.IsNullOrEmpty(originalImagePath) && !imagenModificada)
                {
                    cotizacion.Imagen = originalImagePath; // Restaurar la ruta original de la imagen
                }

                try
                {
                    for (int i = 0; i < gvCotizacionProductoEdit.RowCount; i++)
                    {
                        cotizacion.CostoProductos += Convert.ToDecimal(gvCotizacionProductoEdit.GetRowCellValue(i, "CostoProductos"));
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error de formato al convertir valor numérico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //cotizacion.IdMoneda = Convert.ToInt32(((DataRowView)cboTipoMoneda.SelectedItem)["IdMoneda"]);

                // Actualizar la cotización en la capa de negocios
                cotizacionKiraBL.ActualizarCotizacionProductos(cotizacion);

                // Mostrar mensaje de éxito
                MessageBox.Show("Cotización actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (formRegKiraCotizacion == null)
                {
                    // Crear una nueva instancia si no existe
                    formRegKiraCotizacion = new frmRegKiraCotizacion();
                }

                // Llamar al método CargarListadoCotizaciones del formulario frmRegKiraCotizacion
                formRegKiraCotizacion.CargarListadoCotizaciones();
                formRegKiraCotizacion.CargarListadoCotizacionesProducto();
                this.Close();
                CargarCotizacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            CotizacionKiraBL cotizacionKiraBLs = new CotizacionKiraBL();
            if (cotizacionKiraBLs.ValidarCodigoProductoproducto(txtCodigoProducto.Text))
            {
                lblCodigoExistente.Text = "Codigo registrado";
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
