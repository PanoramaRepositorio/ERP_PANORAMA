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
using DevExpress.XtraGrid.Views.Grid;

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
        private string originalImagePath;
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
        private DataTable dtDatospestaña1;
        private DataTable dtDatosResumen;

        private void frmRegKiraCotizacionProductoTerminadoEdit_Load(object sender, EventArgs e)
        {
            CargarCotizacion();
            personalizacióncontrolesform();
            ConfigurarComboBoxProductoTerminado();
            CrearDatable_GridControl();
            calcularTotalGastospestaña2();
            AgregarDatosDePestanaAlResumen(dtDatospestaña1, dtDatosResumen);
            txtCodigoProducto.TextChanged += txtCodigoProducto_TextChanged;
        }

        public void ConfigurarComboBoxProductoTerminado()
        {
            cboProductoTerminado.Text = "Selecione Gasto";
            cboProductoTerminado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaComboTipoIsumo = comboTipoCotizacionBL.ObtenerComboProductoTerminados();
            cboProductoTerminado.Properties.Items.Clear();
            foreach (var item in listaComboTipoIsumo)
            {
                cboProductoTerminado.Properties.Items.Add(item.DescTablaElemento);
            }

        }
        private void personalizacióncontrolesform()
        {
            
            txtNumeroCotizacion.Enabled = false;
            txtCodigoProducto.Properties.MaxLength = 0;
            Tabcontrol.TabPages[0].Text = "Producto Terminado";
            Tabcontrol.TabPages[1].Text = "Resumen";
            txtFecha.Properties.MinValue = DateTime.Today;
            txtFecha.DateTime = DateTime.Today;
            txtCaracteristicas.ScrollBars = ScrollBars.Vertical;
            txtCaracteristicas.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Both;
            txtMargen.Text = Parametros.margencontri.ToString();
            txtPrecioVenta.Enabled = false;
            txtMargen.Enabled = false;
            btnActualizarPestaña1.Visible = false;

            // Obtener el objeto GridView asociado a gridControlPestaña1
            GridView gridViewPestaña1 = gridControlPestaña1.MainView as GridView;
            GridView gridViewPestaña2 = gridControlPestañaResumen.MainView as GridView;
            // Verificar que el objeto GridView no sea nulo
            if (gridViewPestaña1 != null)
            {
                // Ocultar las columnas que no quieres mostrar en gridControlPestaña1
                gridViewPestaña1.Columns["DescTabla"].Visible = false;
                gridViewPestaña1.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña1.Columns["IdCotizacion"].Visible = false;
                gridViewPestaña1.Columns["IdCotizacionDetalle"].Visible = false;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña2
                gridViewPestaña2.Columns["DescTabla"].Visible = false;
                gridViewPestaña2.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña2.Columns["IdCotizacion"].Visible = false;
                gridViewPestaña2.Columns["IdCotizacionDetalle"].Visible = false;
            }


        }

        private void CrearDatable_GridControl()
        {
            dtDatospestaña1 = new DataTable();
            dtDatospestaña1.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña1.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña1.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña1.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña1.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña1.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total

            dtDatosResumen = new DataTable();
            dtDatosResumen.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatosResumen.Columns.Add("IdCotizacion", typeof(int));
            dtDatosResumen.Columns.Add("IdTablaElemento", typeof(int));
            dtDatosResumen.Columns.Add("DescTabla", typeof(string));
            dtDatosResumen.Columns.Add("DescripcionGastos", typeof(string));
            dtDatosResumen.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total




            List<DetalleCotizacionProductoBE> listaCostoProductosDetalles = cotizacionKiraBL.ObtenerDetelaleCotizacionCostoProducto(idCotizacion);

            foreach (DetalleCotizacionProductoBE dt in listaCostoProductosDetalles)
            {
                DataRow fila = dtDatospestaña1.NewRow();
                fila["IdCotizacionDetalle"] = dt.IdCotizacionDetalle;
                fila["IdCotizacion"] = dt.CotizacionKira.IdCotizacion;
                fila["IdTablaElemento"] = dt.CotizacionKira.IdTablaElemento;
                fila["DescTabla"] = dt.DescTabla;
                fila["DescripcionGastos"] = dt.DescripcionGastos;
                fila["Costo"] = dt.Costo;
                dtDatospestaña1.Rows.Add(fila);
            }

            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dtDatospestaña1);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
            gridControlPestaña1.DataSource = dtDatospestaña1;



            // Agregar un evento TableNewRow a cada DataTable para actualizar automáticamente el resumen
            dtDatospestaña1.TableNewRow += DtDatospestaña1_TableNewRow;
            gridControlPestañaResumen.DataSource = dtDatosResumen;
        }

        private bool DataRowIsEmpty(DataRow row)
        {
            // Verificar si la fila está vacía o contiene solo valores nulos o en blanco
            foreach (var item in row.ItemArray)
            {
                if (item != null && !string.IsNullOrWhiteSpace(item.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        private string ObtenerNombreTablaElemento(string idTablaElemento)
        {
            // Valores y nombres correspondientes
            Dictionary<string, string> nombresTablaElemento = new Dictionary<string, string>
                {
                    { Parametros.idCostoINC_IGVedit, Parametros.costo_inc_igv},
                    { Parametros.idMovilidadedit, Parametros.movilidad},
                    { Parametros.idServiciosAdicionalesedit, Parametros.serviciosadciones },
                    // Agrega aquí más valores y nombres correspondientes
                };

            return nombresTablaElemento.ContainsKey(idTablaElemento) ? nombresTablaElemento[idTablaElemento] : string.Empty;
        }
        private void AgregarDatosDePestanaAlResumen(DataTable pestañaOrigen, DataTable resumenDestino)
        {
            dtDatosResumen.Rows.Clear();

            // Agregar los datos de la pestaña 1 al resumen
            foreach (DataRow row in dtDatospestaña1.Rows)
            {

                if (!DataRowIsEmpty(row))
                {
                    DataRow filaResumen = dtDatosResumen.NewRow();

                    string nombreTablaElemento = ObtenerNombreTablaElemento((string)row["DescTabla"]);

                    if (!string.IsNullOrEmpty(nombreTablaElemento))
                    {
                        filaResumen["DescTabla"] = nombreTablaElemento;
                    }
                    else
                    {
                        filaResumen["DescTabla"] = row["DescTabla"];
                    }
                    filaResumen["IdCotizacionDetalle"] = row["IdCotizacionDetalle"];
                    filaResumen["IdCotizacion"] = row["IdCotizacion"];
                    filaResumen["IdTablaElemento"] = row["IdTablaElemento"];
                    filaResumen["DescripcionGastos"] = row["DescripcionGastos"];
                    filaResumen["Costo"] = row["Costo"];
                    dtDatosResumen.Rows.Add(filaResumen);
                }
            }

            // Calcular y mostrar el total de gastos en la pestaña 7
            calcularTotalGastospestaña2();
            gridView7.ExpandAllGroups();
        }

        public void calcularTotalGastospestaña2()
        {
            CotizacionKiraProductoTerminadoBE cotizacion = new CotizacionKiraProductoTerminadoBE();
            DataTable dt = (DataTable)gridControlPestañaResumen.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo"]));
            cotizacion.TotalGastos = totalGastos;
            txtTotal.Text = totalGastos.ToString();
            // Calcular el Precio de Venta
            if (totalGastos != 0)
            {
                decimal margenContribucion = Parametros.margencontri; // Valor de J69 (MARGEN DE CONTRIBUCION)
                decimal precioVenta = totalGastos / (1 - margenContribucion);
                cotizacion.PrecioVenta = precioVenta;
                txtPrecioVenta.Text = Math.Round(precioVenta, 2).ToString("0.00"); // Redondear a dos decimales
            }
            else
            {
                cotizacion.PrecioVenta = 0;
                txtPrecioVenta.Text = "0";
            }
        }
        private void AgregarDatosAlResumen()
        {

            dtDatosResumen.Rows.Clear();
            AgregarDatosDePestanaAlResumen(dtDatospestaña1, dtDatosResumen);
            gridControlPestañaResumen.DataSource = dtDatosResumen;
            calcularTotalGastospestaña2();
            gridView7.ExpandAllGroups();
        }

        private void DtDatospestaña1_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }

        private void CargarCotizacion()
        {
            try
            {
                if (idCotizacion > 0)
                {
                    cotizacion = cotizacionKiraBL.ObtenerCotizacionProductoPorId(idCotizacion);
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
                    //gvCotizacionProductoEdit.GridControl.DataSource = cotizacionKiraBL.ObtenerCotizacionproductoPorId2(idCotizacion);
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
                // Calcular las sumas de costos de cada pestaña 
                cotizacion.CostoProductos = decimal.TryParse(txtSumaCostosPestaña1.Text, out decimal sumaCostosPestana1) ? sumaCostosPestana1 : 0.0m;

                cotizacionKiraBL.ActualizarCotizacionProductos(cotizacion);



                // Actualizar los detalles de la cotización
                List<DetalleCotizacionProductoBE> detallesCotizacion = new List<DetalleCotizacionProductoBE>();

                foreach (DataRow row in dtDatosResumen.Rows)
                {
                    DetalleCotizacionProductoBE detalle = new DetalleCotizacionProductoBE();
                    detalle.IdCotizacion = cotizacion.IdCotizacion;
                    detalle.IdCotizacionDetalle = Convert.ToInt32(row["IdCotizacionDetalle"]);
                    detalle.DescripcionGastos = Convert.ToString(row["DescripcionGastos"]);
                    detalle.Costo = Convert.ToDecimal(row["Costo"]);
                    detallesCotizacion.Add(detalle);
                }

                cotizacionKiraBL.ActualizarDetalleCotizacionProducto(detallesCotizacion);

                // Mostrar mensaje de éxito
                DevExpress.XtraEditors.XtraMessageBox.Show("Cotización Precio Producto Terminado actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private decimal CalcularSumaCostosPestana1(DataTable dt)
        {
            decimal sumaCostos = 0.0m;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Costo"].ToString(), out decimal costo))
                    {
                        sumaCostos += costo;
                    }
                }
            }

            return sumaCostos;
        }

        private void btnAgregarPestaña1_Click(object sender, EventArgs e)
        {
            string productos = cboProductoTerminado.Text;
            string monto = txtPrecioProductoTerminado.Text;

            if (string.IsNullOrWhiteSpace(productos))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboProductoTerminados()
                .FirstOrDefault(x => x.DescTablaElemento == cboProductoTerminado.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Llamar al método de la capa de negocio para agregar el detalle
            cotizacionKiraBL.AgregarDetalleCotizacionProducto(cotizacion.IdCotizacion, idTablaElemento, productos, montoDecimal);

            // Obtener el nuevo detalle recién agregado desde la base de datos
            DetalleCotizacionProductoBE nuevoDetalle = cotizacionKiraBL.ObtenerUltimoDetalleCotizacionProducto(cotizacion.IdCotizacion);

            DataTable dt = (DataTable)gridControlPestaña1.DataSource;
            DataRow existingRow = dt.AsEnumerable().FirstOrDefault(row => row.Field<string>("DescripcionGastos") == productos);

            if (existingRow != null)
            {
                decimal currentItemCosto = existingRow.Field<decimal>("Costo");
                existingRow["Costo"] = currentItemCosto + montoDecimal;
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["DescTabla"] = idTablaElemento;
                newRow["IdTablaElemento"] = idTablaElemento;
                newRow["IdCotizacionDetalle"] = nuevoDetalle.IdCotizacionDetalle; // Nuevo IdCotizacionDetalle
                newRow["IdCotizacion"] = cotizacion.IdCotizacion;
                newRow["DescripcionGastos"] = productos;
                newRow["Costo"] = montoDecimal;
                dt.Rows.Add(newRow);
            }

            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();

            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");

            cboProductoTerminado.Text = "Seleccione Gastos";
            txtPrecioProductoTerminado.Text = string.Empty;

            // Refrescar el gridControlPestaña1
            gridControlPestañaResumen.RefreshDataSource();
        }

        private void btnEliminarPestaña1_Click(object sender, EventArgs e)
        {

            GridView gridView = gridView1;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                // Obtener el IdCotizacionDetalle desde el DataTable del DataSource
                DataTable dt = (DataTable)gridView.GridControl.DataSource;
                int idCotizacionDetalle = Convert.ToInt32(dt.Rows[selectedRowHandle]["IdCotizacionDetalle"]);

                // Verificar si es el último detalle de cotización en el DataTable
                bool esUltimoDetalle = dt.Rows.Count == 1 && Convert.ToInt32(dt.Rows[0]["IdCotizacionDetalle"]) == idCotizacionDetalle;

                if (esUltimoDetalle)
                {
                    MessageBox.Show("No es posible eliminar el último detalle de cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método de la capa de negocio para eliminar el detalle
                cotizacionKiraBL.EliminarDetalleCotizacionProducto(idCotizacionDetalle);

                // Eliminar la fila del DataTable
                dt.Rows.RemoveAt(selectedRowHandle);

                // Actualizar el resumen y el gridControlPestaña1
                gridView.RefreshData();
                gridControlPestaña1.RefreshDataSource();
                AgregarDatosAlResumen();
                decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
                txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
            }
        }

        private void Tabcontrol_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = Tabcontrol.TabPages[e.Index];

            // Cambiar el color de fondo de las pestañas
            e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), e.Bounds);

            // Cambiar el color del texto de las pestañas
            using (Brush textBrush = new SolidBrush(Color.DarkBlue))
            {
                e.Graphics.DrawString(tabPage.Text, Tabcontrol.Font, textBrush, e.Bounds.X + 3, e.Bounds.Y + 3);
            }
        }
    }
}
