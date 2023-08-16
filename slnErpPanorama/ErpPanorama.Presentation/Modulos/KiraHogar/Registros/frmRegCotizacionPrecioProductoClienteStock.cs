using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
using ErpPanorama.Presentation.Modulos.KiraHogar.Registros;


namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    public partial class frmCotizacion : DevExpress.XtraEditors.XtraForm
    {
        public ComboTipoCotizacionBL comboTipoCotizacionBL;
        private CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        // Variable para almacenar el cuadro de diálogo de selección de archivos
        private OpenFileDialog openFile = new OpenFileDialog();
        private frmRegKiraCotizacion formRegKiraCotizacion;
        // Declarar una variable para almacenar los detalles de cotización
        List<DetalleCotizacionBE> detalleCotizacionList = new List<DetalleCotizacionBE>();

        public frmCotizacion()
        {
            InitializeComponent();

        }
        private DataTable dtDatospestaña1;
        private DataTable dtDatospestaña2;
        private DataTable dtDatospestaña3;
        private DataTable dtDatospestaña4;
        private DataTable dtDatospestaña5;
        private DataTable dtDatospestaña6;
        private DataTable dtDatosResumen;
        private ImageCollection imageCollection;


        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            imageCollection = new ImageCollection();
            imageCollection.AddImage(Properties.Resources.Stop_2);
            CrearDatable_GridControl();
            ConfigurarComboBoxTipoCotizacion();
            ConfigurarComboBoxMateriales();
            ConfigurarComboBoxInsumo();
            ConfigurarConboBoxAccesorio();
            ConfigurarComboBoxMano();
            ConfigurarComboBoxMovilidad();
            ConfigurarComboBoxTipoMoneda();
            ConfigurarComboBoxEquipos();
            personalizacióncontrolesform();
            AgregarPestaña6();
            OcultarColumnasGridControlPestañas();
            calcularTotalGastospestaña7();


            // Establecer la propiedad MaxLength a 0 para permitir una cantidad ilimitada de caracteres
            txtCodigoProducto.Properties.MaxLength = 0;
            txtCodigoProducto.TextChanged += txtCodigoProducto_TextChanged;
        }

        // Evento de clic para el botón de eliminar en la pestaña 1


        private void CrearDatable_GridControl()
        {
            // Crear el DataTable para almacenar los datos pestaña 1
            dtDatospestaña1 = new DataTable();
            dtDatospestaña1.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña1.Columns.Add("Item", typeof(int));
            dtDatospestaña1.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña1.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña1.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña1.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total

            // Crear el DataTable para almacenar los datos pestaña 2
            dtDatospestaña2 = new DataTable();
            dtDatospestaña2.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña2.Columns.Add("Item", typeof(int));
            dtDatospestaña2.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña2.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña2.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña2.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total

            // Crear el DataTable para almacenar los datos pestaña 3
            dtDatospestaña3 = new DataTable();
            dtDatospestaña3.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña3.Columns.Add("Item", typeof(int));
            dtDatospestaña3.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña3.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña3.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña3.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total


            // Crear el DataTable para almacenar los datos pestaña 4
            dtDatospestaña4 = new DataTable();
            dtDatospestaña4.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña4.Columns.Add("Item", typeof(int));
            dtDatospestaña4.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña4.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña4.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña4.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total

            // Crear el DataTable para almacenar los datos pestaña 5
            dtDatospestaña5 = new DataTable();
            dtDatospestaña5.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña5.Columns.Add("Item", typeof(int));
            dtDatospestaña5.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña5.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña5.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña5.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total

            // Crear el DataTable para almacenar los datos pestaña 6
            dtDatospestaña6 = new DataTable();
            dtDatospestaña6.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña6.Columns.Add("Item", typeof(int));
            dtDatospestaña6.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña6.Columns.Add("FlagAprobacion", typeof(bool));
            dtDatospestaña6.Columns.Add("FlagEstado", typeof(bool));
            dtDatospestaña6.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total

            // Crear el DataTable para almacenar los datos pestaña 7

            dtDatosResumen = new DataTable();
            dtDatosResumen.Columns.Add("NombreTablaElemento", typeof(string)); // Columna para mostrar el nombre
            dtDatosResumen.Columns.Add("DescripcionGastos", typeof(string));
            dtDatosResumen.Columns.Add("Costo" + " " + " S/.", typeof(decimal)); // Nueva columna para el precio total



            // Asignar el DataTable como fuente de datos para cada GridControl
            gridControlPestaña1.DataSource = dtDatospestaña1;
            gridControlPestaña2.DataSource = dtDatospestaña2;
            gridControlPestaña3.DataSource = dtDatospestaña3;
            gridControlPestaña4.DataSource = dtDatospestaña4;
            gridControlPestaña5.DataSource = dtDatospestaña5;
            gridControlPestaña6.DataSource = dtDatospestaña6;


            // Agregar un evento TableNewRow a cada DataTable para actualizar automáticamente el resumen
            dtDatospestaña1.TableNewRow += DtDatospestaña1_TableNewRow;
            dtDatospestaña2.TableNewRow += DtDatospestaña2_TableNewRow;
            dtDatospestaña3.TableNewRow += DtDatospestaña3_TableNewRow;
            dtDatospestaña4.TableNewRow += DtDatospestaña4_TableNewRow;
            dtDatospestaña5.TableNewRow += DtDatospestaña5_TableNewRow;
            dtDatospestaña6.TableNewRow += DtDatospestaña6_TableNewRow;
            gridControlPestaña7Resumen.DataSource = dtDatosResumen;
            gridView7.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            gridView7.Columns["NombreTablaElemento"].GroupIndex = 0; // Establecer la columna "NombreTablaElemento" como columna de agrupación

        }

        private void OcultarColumnasGridControlPestañas()
        {
            // Obtener el objeto GridView asociado a gridControlPestaña1
            GridView gridViewPestaña1 = gridControlPestaña1.MainView as GridView;
            GridView gridViewPestaña2 = gridControlPestaña2.MainView as GridView;
            GridView gridViewPestaña3 = gridControlPestaña3.MainView as GridView;
            GridView gridViewPestaña4 = gridControlPestaña4.MainView as GridView;
            GridView gridViewPestaña5 = gridControlPestaña5.MainView as GridView;
            GridView gridViewPestaña6 = gridControlPestaña6.MainView as GridView;


            // Verificar que el objeto GridView no sea nulo
            if (gridViewPestaña1 != null)
            {
                // Ocultar las columnas que no quieres mostrar en gridControlPestaña1
                gridViewPestaña1.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña1.Columns["Item"].Visible = false;
                gridViewPestaña1.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña1.Columns["FlagEstado"].Visible = false;

                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña1.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña1.Columns["Costo" + " " + " S/."].Visible = true;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña2
                gridViewPestaña2.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña2.Columns["Item"].Visible = false;
                gridViewPestaña2.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña2.Columns["FlagEstado"].Visible = false;

                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña2.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña2.Columns["Costo" + " " + " S/."].Visible = true;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña3
                gridViewPestaña3.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña3.Columns["Item"].Visible = false;
                gridViewPestaña3.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña3.Columns["FlagEstado"].Visible = false;

                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña3.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña3.Columns["Costo" + " " + " S/."].Visible = true;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña4
                gridViewPestaña4.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña4.Columns["Item"].Visible = false;
                gridViewPestaña4.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña4.Columns["FlagEstado"].Visible = false;

                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña4.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña4.Columns["Costo" + " " + " S/."].Visible = true;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña5
                gridViewPestaña5.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña5.Columns["Item"].Visible = false;
                gridViewPestaña5.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña5.Columns["FlagEstado"].Visible = false;

                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña5.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña5.Columns["Costo" + " " + " S/."].Visible = true;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña6
                gridViewPestaña6.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña6.Columns["Item"].Visible = false;
                gridViewPestaña6.Columns["FlagAprobacion"].Visible = false;
                gridViewPestaña6.Columns["FlagEstado"].Visible = false;

                // Dejar visibles solo las columnas DescripcionGastos y Costo
                gridViewPestaña6.Columns["DescripcionGastos"].Visible = true;
                gridViewPestaña6.Columns["Costo" + " " + " S/."].Visible = true;
            }
        }


        /// <summary>
        ///Método para verificar si una fila está vacía o contiene solo valores nulos o en blanco
        /// </summary>
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
        /// <summary>
        ///toma los datos de la tabla dtPestana, verifica si la fila no está vacía 
        ///y luego agrega algunas columnas específicas de esa fila a otro DataTable llamado dtDatosResumen
        /// </summary>
        private void AgregarDatosDePestanaAlResumen(DataTable dtPestana)
        {
            foreach (DataRow row in dtPestana.Rows)
            {
                if (!DataRowIsEmpty(row))
                {
                    DataRow newRow = dtDatosResumen.NewRow();
                    newRow["NombreTablaElemento"] = ObtenerNombreTablaElemento((int)row["IdTablaElemento"]); // Usamos una función para obtener el nombre
                    newRow["DescripcionGastos"] = row["DescripcionGastos"];
                    newRow["Costo" + " " + " S/."] = row["Costo" + " " + " S/."];
                    dtDatosResumen.Rows.Add(newRow);
                }
            }
        }
        // Método para agregar todos los datos de cada pestaña al resumen
        private void AgregarDatosAlResumen()
        {
            // Limpiar el resumen antes de agregar los nuevos datos
            dtDatosResumen.Rows.Clear();
            // Agregar los datos de cada pestaña al resumen
            AgregarDatosDePestanaAlResumen(dtDatospestaña1);
            AgregarDatosDePestanaAlResumen(dtDatospestaña2);
            AgregarDatosDePestanaAlResumen(dtDatospestaña3);
            AgregarDatosDePestanaAlResumen(dtDatospestaña4);
            AgregarDatosDePestanaAlResumen(dtDatospestaña5);
            AgregarDatosDePestanaAlResumen(dtDatospestaña6);
            // Actualiza el DataSource del gridControlPestaña7Resumen con el DataTable dtDatosResumen
            gridControlPestaña7Resumen.DataSource = dtDatosResumen;
            calcularTotalGastospestaña7();
        }

        private void DtDatospestaña1_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }
        private void DtDatospestaña2_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }
        private void DtDatospestaña3_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }
        private void DtDatospestaña4_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }
        private void DtDatospestaña5_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }
        private void DtDatospestaña6_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            AgregarDatosAlResumen();
        }
        private void personalizacióncontrolesform()
        {
            int siguienteNumeroCotizacion = cotizacionKiraBL.ObtenerSiguienteNumeroCotizacion();
            txtNumeroCotizacion.Text = siguienteNumeroCotizacion.ToString();
            txtNumeroCotizacion.Enabled = false;
            Tabcontrol.TabPages[0].Text = "Materiales";
            Tabcontrol.TabPages[1].Text = "Insumos";
            Tabcontrol.TabPages[2].Text = "Accesorios";
            Tabcontrol.TabPages[3].Text = "Mano de Obra ";
            Tabcontrol.TabPages[4].Text = "Movilidad y Viaticos";
            //Tabcontrol.TabPages[5].Text = "Equipos y Herramientas";
            // Ocultar la pestaña "Equipos y Herramientas"
            int indexToHide = 5; // Índice de la pestaña que deseas ocultar
            if (indexToHide >= 0 && indexToHide < Tabcontrol.TabCount)
            {
                TabPage tabPageToHide = Tabcontrol.TabPages[indexToHide];
                Tabcontrol.TabPages.Remove(tabPageToHide);
            }
            Tabcontrol.TabPages[5].Text = "Resumen";
            txtFecha.Properties.MinValue = DateTime.Today;
            txtFecha.DateTime = DateTime.Today;
            txtCaracteristicas.ScrollBars = ScrollBars.Vertical;
            txtCaracteristicas.ScrollBars = ScrollBars.Horizontal;
            txtCaracteristicas.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Both;
            txtBreveDescripcion.ScrollBars = ScrollBars.Horizontal;
            txtEquipoyherramientas.Text = "50";
            txtEquipoyherramientas.Enabled = false;
            txtequipos.Text = "50";
            txtequipos.Enabled = false;
            txtMargen.Text = Parametros.margencontri.ToString();
            txtPrecioVenta.Enabled = false;
            txtMargen.Enabled = false;
            btnActualizarPestaña1.Visible = false;
            btnActualizarPestaña2.Visible = false;
            btnActualizarPestaña3.Visible = false;
            btnActualizarPestaña4.Visible = false;
            btnActualizarPestaña5.Visible = false;

        }

        /// <summary>
        /// Metodos de llenar datos a los combos de la BD
        /// </summary>
        private void ConfigurarComboBoxTipoCotizacion()
        {
            //cboTipoCotizacion.Text = "Seleccione un Tipo";
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
            // Seleccionar un valor por defecto (por ejemplo, el primer elemento de la lista)
            if (listaComboTipoCotizacion.Count > 0)
            {
                cboTipoCotizacion.SelectedIndex = 0;
                cboTipoCotizacion.Enabled = false; // Deshabilitar el ComboBox
            }
        }
        private void ConfigurarComboBoxMateriales()
        {
            cboMaterial.Text = "Seleccione Material";
            //cboMaterial.Properties.TextEditStyle = TextEditStyles.Standard;
            //cboMaterial.Properties.AutoComplete = true;
            //cboMaterial.Properties.CaseSensitiveSearch = false;
            cboMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboTipoCotizacionBL = new ComboTipoCotizacionBL();
            List<ComboTipoCotizacionBE> listaComboTipoCotizacion = comboTipoCotizacionBL.ObtenerComboMateriales();
            cboMaterial.Properties.Items.Clear();
            foreach (var item in listaComboTipoCotizacion)
            {
                cboMaterial.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        public void ConfigurarComboBoxInsumo()
        {
            cboInsumos.Text = "Selecione Insumo";
            cboInsumos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            cboAccesorios.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            cboManoObra.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            //cboSeleccionaMovilidad.Properties.TextEditStyle = TextEditStyles.Standard;
            cboSeleccionaMovilidad.Properties.AutoComplete = true;
            cboSeleccionaMovilidad.Properties.CaseSensitiveSearch = false;
            List<ComboTipoCotizacionBE> listamovi = comboTipoCotizacionBL.ObtenerMovilidadyViaticos();
            // Configurar el ComboBox
            cboSeleccionaMovilidad.Properties.Items.Clear();
            foreach (ComboTipoCotizacionBE item in listamovi)
            {
                cboSeleccionaMovilidad.Properties.Items.Add(item.DescTablaElemento);
            }
        }
        public void ConfigurarComboBoxTipoMoneda()
        {
            //cboTipoMoneda.Text = "Seleccione Moneda";
            cboTipoMoneda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<ComboTipoCotizacionBE> listamone = comboTipoCotizacionBL.ObtenerComboTipoMoneda();
            // Configurar el ComboBox
            cboTipoMoneda.Properties.Items.Clear();
            foreach (ComboTipoCotizacionBE item in listamone)
            {
                cboTipoMoneda.Properties.Items.Add(item.DescTablaElemento);
            }
            // Seleccionar un valor por defecto (por ejemplo, el primer elemento de la lista)
            if (listamone.Count > 0)
            {
                cboTipoMoneda.SelectedIndex = 0;
                //cboTipoMoneda.Enabled = false; // Deshabilitar el ComboBox
            }
        }
        public void ConfigurarComboBoxEquipos()
        {
            //cboequipos.Text = "Seleccione opción";
            cboequipos.Properties.TextEditStyle = TextEditStyles.Standard;
            cboequipos.Properties.ReadOnly = true; // Establecer como no editable
            List<ComboTipoCotizacionBE> listequi = comboTipoCotizacionBL.ObtenerComboEquiposHerramienta();
            // Configurar el ComboBox
            cboequipos.Properties.Items.Clear();
            foreach (ComboTipoCotizacionBE item in listequi)
            {
                cboequipos.Properties.Items.Add(item.DescTablaElemento);
            }
            // Verificar si hay un único registro en la lista
            if (listequi.Count == 1)
            {
                // Seleccionar automáticamente el único registro
                cboequipos.SelectedItem = listequi[0].DescTablaElemento;
            }
        }

        /// <summary>
        /// Metodos agregar valores a los combos despues de alguna operación (guardar)
        /// </summary>
        public void valorespredeterminadosdeloscbo()
        {
            string cboTipoCotizacionDefault = "Seleccione un Tipo";
            string cboMaterialDefault = "Seleccione Material";
            string cboInsumosDefault = "Selecione Insumo";
            string cboAccesoriosDefault = "Seleccione Accesorio";
            string cboManoObraDefault = "Seleccione Mano de Obra";
            string cboSeleccionaMovilidadDefault = "Seleccione Movilidad - Viaticos";
            string cboTipoMonedaDefault = "Seleccione Moneda";
            // Restaurar los valores predeterminados en los comboboxes
            cboTipoCotizacion.Text = cboTipoCotizacionDefault;
            cboMaterial.Text = cboMaterialDefault;
            cboInsumos.Text = cboInsumosDefault;
            cboAccesorios.Text = cboAccesoriosDefault;
            cboManoObra.Text = cboManoObraDefault;
            cboSeleccionaMovilidad.Text = cboSeleccionaMovilidadDefault;
            cboTipoMoneda.Text = cboTipoMonedaDefault;
        }

        public void calcularTotalGastospestaña7()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña7Resumen.DataSource;
            // Calcular el Total de Gastos
            decimal totalGastos = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Costo" + " " + " S/."]));
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

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///Método para obtener el nombre correspondiente a un valor de IdTablaElemento
        /// </summary>
        private string ObtenerNombreTablaElemento(int idTablaElemento)
        {
            // Valores y nombres correspondientes
            Dictionary<int, string> nombresTablaElemento = new Dictionary<int, string>
                {
                    { 714, "MATERIALES" },
                    { 715, "MATERIALES" },
                    { 716, "MATERIALES" },
                    { 717, "MATERIALES" },
                    { 718, "MATERIALES" },
                    { 719, "MATERIALES" },
                    { 720, "MATERIALES" },
                    { 721, "MATERIALES" },
                    { 722, "MATERIALES" },
                    { 723, "MATERIALES" },
                    { 724, "MATERIALES" },
                    { 725, "MATERIALES" },
                    { 726, "MATERIALES" },
                    { 727, "MATERIALES" },
                    { 728, "MATERIALES" },
                    { 729, "INSUMOS" },
                    { 730, "INSUMOS" },
                    { 731, "INSUMOS" },
                    { 732, "INSUMOS" },
                    { 733, "INSUMOS" },
                    { 734, "ACCESORIOS" },
                    { 735, "ACCESORIOS" },
                    { 736, "ACCESORIOS" },
                    { 737, "ACCESORIOS" },
                    { 738, "ACCESORIOS" },
                    { 739, "ACCESORIOS" },
                    { 740, "ACCESORIOS" },
                    { 741, "MANO DE OBRA" },
                    { 742, "MANO DE OBRA" },
                    { 743, "MANO DE OBRA" },
                    { 744, "MANO DE OBRA" },
                    { 745, "MANO DE OBRA" },
                    { 746, "MANO DE OBRA" },
                    { 747, "MANO DE OBRA" },
                    { 748, "MANO DE OBRA" },
                    { 749, "MOVILIDAD Y VIATICOS" },
                    { 750, "MOVILIDAD Y VIATICOS" },
                    { 751, "MOVILIDAD Y VIATICOS" },
                    { 752, "MOVILIDAD Y VIATICOS" },
                    { 753, "EQUIPOS Y HERRAMIENTAS" },
                    // Agrega aquí más valores y nombres correspondientes
                };

            return nombresTablaElemento.ContainsKey(idTablaElemento) ? nombresTablaElemento[idTablaElemento] : string.Empty;
        }

        /// <summary>
        ///  Método para calcular la suma de costos de la pestaña 1
        /// </summary>
        private decimal CalcularSumaCostosPestana1(DataTable dt)
        {
            decimal sumaCostos = 0.0m;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                    {
                        sumaCostos += costo;
                    }
                }
            }

            return sumaCostos;
        }
        private decimal CalcularSumaCostosPestana2(DataTable dt)
        {
            decimal sumaCostos = 0.0m;
            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                {
                    sumaCostos += costo;
                }
            }
            return sumaCostos;
        }
        private decimal CalcularSumaCostosPestana3(DataTable dt)
        {
            decimal sumaCostos = 0.0m;
            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                {
                    sumaCostos += costo;
                }
            }
            return sumaCostos;
        }
        private decimal CalcularSumaCostosPestana4(DataTable dt)
        {
            decimal sumaCostos = 0.0m;
            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                {
                    sumaCostos += costo;
                }
            }
            return sumaCostos;
        }
        private decimal CalcularSumaCostosPestana5(DataTable dt)
        {
            decimal sumaCostos = 0.0m;
            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                {
                    sumaCostos += costo;
                }
            }
            return sumaCostos;
        }
        private decimal CalcularSumaCostosPestana6(DataTable dt)
        {
            decimal sumaCostos = 0.0m;
            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Costo" + " " + " S/."].ToString(), out decimal costo))
                {
                    sumaCostos += costo;
                }
            }
            return sumaCostos;
        }
        /// <summary>
        /// Metodos de los botones agregar de cada pesataña TAB
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
            // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboMateriales()
                .FirstOrDefault(x => x.DescTablaElemento == cboMaterial.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Obtener el DataTable del DataSource del gridControlPestaña1
            DataTable dt = (DataTable)gridControlPestaña1.DataSource;

            // Buscar si la descripción ya existe en el DataTable
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == material);

            if (existingRow != null)
            {
                // Si la descripción ya existe, incrementar el Item en esa fila
                int currentItem = existingRow.Field<int>("Item");
                decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                existingRow["Item"] = currentItem + 1;
                existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
            }
            else
            {
                // Si la descripción no existe, agregar una nueva fila con el Item en 1
                DataRow newRow = dt.NewRow();
                newRow["IdTablaElemento"] = idTablaElemento;
                newRow["DescripcionGastos"] = material;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                dt.Rows.Add(newRow);
            }
            // Llamamos al método que agrega todos los datos al resumen
            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();

            // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");

            cboMaterial.Text = "Seleccione Materiales";
            txtPrecio.Text = string.Empty;
            gridControlPestaña1.RefreshDataSource();
            //calcularTotalGastospestaña1();
            // Después de agregar los datos a la pestaña 1, actualiza el resumen

        }

        private void btnAgregarPestaña2_Click(object sender, EventArgs e)
        {
            try
            {
                string insumo = cboInsumos.Text;
                string monto = txtinsumo.Text;
                if (string.IsNullOrWhiteSpace(insumo))
                {
                    MessageBox.Show("Por favor, seleccione un Isumo antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(monto, out decimal montoDecimal))
                {
                    MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboInsumo()
                    .FirstOrDefault(x => x.DescTablaElemento == cboInsumos.Text);

                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idTablaElemento = itemSeleccionado.IdTablaElemento;
                DataTable dt = (DataTable)gridControlPestaña2.DataSource;
                DataRow existingRow = dt.AsEnumerable()
                    .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == insumo);
                if (existingRow != null)
                {
                    int currentItem = existingRow.Field<int>("Item");
                    decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                    existingRow["Item"] = currentItem + 1;
                    existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow["IdTablaElemento"] = idTablaElemento;
                    newRow["DescripcionGastos"] = insumo;
                    newRow["Item"] = 1;
                    newRow["Costo" + " " + " S/."] = montoDecimal;
                    newRow["FlagAprobacion"] = true;
                    newRow["FlagEstado"] = true;
                    dt.Rows.Add(newRow);
                }
                AgregarDatosAlResumen();
                gridView7.ExpandAllGroups();
                decimal sumaCostosPestana2 = CalcularSumaCostosPestana2(dt);
                txtSumaCostosPestaña2.Text = sumaCostosPestana2.ToString("0.00");
                cboInsumos.Text = "Seleccione Insumos";
                txtinsumo.Text = string.Empty;
                gridControlPestaña2.RefreshDataSource();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnAgregarPestaña3_Click(object sender, EventArgs e)
        {
            try
            {
                string accesorio = cboAccesorios.Text;
                string monto = txtMontoaccesorio.Text;
                if (string.IsNullOrWhiteSpace(accesorio))
                {
                    MessageBox.Show("Por favor, seleccione un Accesorio antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(monto, out decimal montoDecimal))
                {
                    MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerAccesorios()
                    .FirstOrDefault(x => x.DescTablaElemento == cboAccesorios.Text);

                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idTablaElemento = itemSeleccionado.IdTablaElemento;
                DataTable dt = (DataTable)gridControlPestaña3.DataSource;
                DataRow existingRow = dt.AsEnumerable()
                    .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == accesorio);

                if (existingRow != null)
                {
                    int currentItem = existingRow.Field<int>("Item");
                    decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                    existingRow["Item"] = currentItem + 1;
                    existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow["IdTablaElemento"] = idTablaElemento;
                    newRow["DescripcionGastos"] = accesorio;
                    newRow["Item"] = 1;
                    newRow["Costo" + " " + " S/."] = montoDecimal;
                    newRow["FlagAprobacion"] = true;
                    newRow["FlagEstado"] = true;
                    dt.Rows.Add(newRow);
                }
                AgregarDatosAlResumen();
                gridView7.ExpandAllGroups();
                decimal sumaCostosPestana3 = CalcularSumaCostosPestana3(dt);
                txtSumaCostosPestaña3.Text = sumaCostosPestana3.ToString("0.00");
                cboAccesorios.Text = "Seleccione Accesorio";
                txtMontoaccesorio.Text = string.Empty;
                gridControlPestaña3.RefreshDataSource();
            }
            catch (Exception)
            {

                throw;
            }


        }


        private void btnAgregarPestaña4_Click(object sender, EventArgs e)
        {
            string manoobra = cboManoObra.Text;
            string monto = txtManoobra.Text;
            if (string.IsNullOrWhiteSpace(manoobra))
            {
                MessageBox.Show("Por favor, seleccione Mano de obra antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerManoObra()
                .FirstOrDefault(x => x.DescTablaElemento == cboManoObra.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;
            DataTable dt = (DataTable)gridControlPestaña4.DataSource;
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == manoobra);

            if (existingRow != null)
            {
                int currentItem = existingRow.Field<int>("Item");
                decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                existingRow["Item"] = currentItem + 1;
                existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["IdTablaElemento"] = idTablaElemento;
                newRow["DescripcionGastos"] = manoobra;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true;
                newRow["FlagEstado"] = true;
                dt.Rows.Add(newRow);
            }
            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();
            decimal sumaCostosPestana4 = CalcularSumaCostosPestana4(dt);
            txtSumaCostosPestaña4.Text = sumaCostosPestana4.ToString("0.00");
            cboManoObra.Text = "Seleccione Mano de Obra";
            txtManoobra.Text = string.Empty;
            gridControlPestaña4.RefreshDataSource();

        }


        private void btnAgregarPestaña5_Click(object sender, EventArgs e)
        {
            string movilidad = cboSeleccionaMovilidad.Text;
            string monto = txtMovilidad.Text;

            if (string.IsNullOrWhiteSpace(movilidad))
            {
                MessageBox.Show("Por favor, seleccione un Viatico antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerMovilidadyViaticos()
                .FirstOrDefault(x => x.DescTablaElemento == cboSeleccionaMovilidad.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idTablaElemento = itemSeleccionado.IdTablaElemento;
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == movilidad);
            if (existingRow != null)
            {
                int currentItem = existingRow.Field<int>("Item");
                decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                existingRow["Item"] = currentItem + 1;
                existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["IdTablaElemento"] = idTablaElemento;
                newRow["DescripcionGastos"] = movilidad;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true;
                newRow["FlagEstado"] = true;
                dt.Rows.Add(newRow);
            }
            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();
            decimal sumaCostosPestana5 = CalcularSumaCostosPestana5(dt);
            txtSumaCostosPestaña5.Text = sumaCostosPestana5.ToString("0.00");
            cboSeleccionaMovilidad.Text = "Seleccione Movilidad - viaticos";
            txtMovilidad.Text = string.Empty;
            gridControlPestaña5.RefreshDataSource();
        }


        private void btnAgregarPestaña6_Click(object sender, EventArgs e)
        {
            //string movilidad = cboequipos.Text;
            //string monto = txtequipos.Text;
            //if (string.IsNullOrWhiteSpace(movilidad))
            //{
            //    MessageBox.Show("Por favor, seleccione un Equipo antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (!decimal.TryParse(monto, out decimal montoDecimal))
            //{
            //    MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboEquiposHerramienta()
            //    .FirstOrDefault(x => x.DescTablaElemento == cboequipos.Text);

            //if (itemSeleccionado == null)
            //{
            //    MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //int idTablaElemento = itemSeleccionado.IdTablaElemento;
            //DataTable dt = (DataTable)gridControlPestaña6.DataSource;
            //DataRow existingRow = dt.AsEnumerable()
            //    .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == movilidad);
            //if (existingRow != null)
            //{
            //    int currentItem = existingRow.Field<int>("Item");
            //    decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
            //    existingRow["Item"] = currentItem + 1;
            //    existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
            //}
            //else
            //{
            //    DataRow newRow = dt.NewRow();
            //    newRow["IdTablaElemento"] = idTablaElemento;
            //    newRow["DescripcionGastos"] = movilidad;
            //    newRow["Item"] = 1;
            //    newRow["Costo" + " " + " S/."] = montoDecimal;
            //    newRow["FlagAprobacion"] = true;
            //    newRow["FlagEstado"] = true;
            //    dt.Rows.Add(newRow);
            //}
            //AgregarDatosAlResumen();
            //gridView7.ExpandAllGroups();
            //decimal sumaCostosPestana6 = CalcularSumaCostosPestana6(dt);
            //txtSumaCostosPestaña6.Text = sumaCostosPestana6.ToString("0.00");
            //txtequipos.Text = "50";
            //gridControlPestaña6.RefreshDataSource();
        }

        private void AgregarPestaña6()
        {
            string movilidad = cboequipos.Text;
            string monto = txtequipos.Text;
            if (string.IsNullOrWhiteSpace(movilidad))
            {
                MessageBox.Show("Por favor, seleccione un Equipo antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboEquiposHerramienta()
                .FirstOrDefault(x => x.DescTablaElemento == cboequipos.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idTablaElemento = itemSeleccionado.IdTablaElemento;
            DataTable dt = (DataTable)gridControlPestaña6.DataSource;
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == movilidad);
            if (existingRow != null)
            {
                int currentItem = existingRow.Field<int>("Item");
                decimal currentItemCosto = existingRow.Field<decimal>("Costo" + " " + " S/.");
                existingRow["Item"] = currentItem + 1;
                existingRow["Costo" + " " + " S/."] = currentItemCosto + montoDecimal;
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["IdTablaElemento"] = idTablaElemento;
                newRow["DescripcionGastos"] = movilidad;
                newRow["Item"] = 1;
                newRow["Costo" + " " + " S/."] = montoDecimal;
                newRow["FlagAprobacion"] = true;
                newRow["FlagEstado"] = true;
                dt.Rows.Add(newRow);
            }
            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();
            decimal sumaCostosPestana6 = CalcularSumaCostosPestana6(dt);
            txtSumaCostosPestaña6.Text = sumaCostosPestana6.ToString("0.00");
            txtequipos.Text = "50";
            gridControlPestaña6.RefreshDataSource();
        }


        /// <summary>
        /// Metodos que obtiene las filas del Gridcontrol para posterior usarlo 
        /// en RegistrarCotizacionYDetalle
        /// </summary>
        private void AgregarDatosDePestanaAlDetalle(DataTable dtPestana, DataTable dtDetalleCompleto)
        {
            // Verificar que el DataTable de la pestaña no sea nulo y contenga filas
            if (dtPestana != null && dtPestana.Rows.Count > 0)
            {
                int item = 1; // Variable para almacenar el número de item
                foreach (DataRow row in dtPestana.Rows)
                {
                    DataRow newRow = dtDetalleCompleto.NewRow();
                    newRow["IdTablaElemento"] = row["IdTablaElemento"];
                    newRow["DescripcionGastos"] = row["DescripcionGastos"];
                    newRow["Costo" + " " + " S/."] = row["Costo" + " " + " S/."];
                    newRow["FlagAprobacion"] = true; // Establecer el valor predeterminado de FlagAprobacion a true
                    newRow["FlagEstado"] = true; // Establecer el valor predeterminado de FlagEstado a true
                    newRow["Item"] = item; // Asignar el número de item
                    dtDetalleCompleto.Rows.Add(newRow);
                    item++;
                }
            }
        }

        
        public void LimpiarControlesTextBox(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                    int siguienteNumeroCotizacion = cotizacionKiraBL.ObtenerSiguienteNumeroCotizacion();
                    txtNumeroCotizacion.Text = siguienteNumeroCotizacion.ToString();
                }
                else if (control is System.Windows.Forms.ComboBox comboBox)
                {
                    valorespredeterminadosdeloscbo();
                }
                else if (control.HasChildren) // Si el control tiene controles hijos, realizar un recorrido recursivo
                {
                    LimpiarControlesTextBox(control.Controls);
                }
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
        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            CotizacionKiraBL cotizacionKiraBLs = new CotizacionKiraBL();
            if (cotizacionKiraBLs.ValidarCodigoProducto(txtCodigoProducto.Text))
            {
                lblCodigoExistente.Text = "El código de producto ya existe en la base de datos.";
                lblCodigoExistente.ForeColor = Color.Red;
            }
            else
            {
                lblCodigoExistente.Text = "Código disponible.";
                lblCodigoExistente.ForeColor = Color.Green;
            }
        }



        private void txtEquipoyherramientas_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizarPestaña1_Click(object sender, EventArgs e)
        {
            // Obtener el DataTable asociado al gridControlPestaña1 y actualizar los datos si es necesario.
            DataTable dt = (DataTable)gridControlPestaña1.DataSource;

            // Actualizar el resumen y el gridControlPestaña1
            AgregarDatosAlResumen();
            gridView1.RefreshData();
            // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
        }

        private void btnActualizarPestaña2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControlPestaña2.DataSource;
            AgregarDatosAlResumen();
            gridView2.RefreshData();
            decimal sumaCostosPestana2 = CalcularSumaCostosPestana2(dt);
            txtSumaCostosPestaña2.Text = sumaCostosPestana2.ToString("0.00");
        }

        private void btnActualizarPestaña3_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControlPestaña3.DataSource;
            AgregarDatosAlResumen();
            gridView3.RefreshData();
            decimal sumaCostosPestana3 = CalcularSumaCostosPestana3(dt);
            txtSumaCostosPestaña3.Text = sumaCostosPestana3.ToString("0.00");
        }

        private void btnActualizarPestaña4_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControlPestaña4.DataSource;
            AgregarDatosAlResumen();
            gridView4.RefreshData();
            decimal sumaCostosPestana4 = CalcularSumaCostosPestana4(dt);
            txtSumaCostosPestaña4.Text = sumaCostosPestana4.ToString("0.00");
        }
        private void btnActualizarPestaña5_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;
            AgregarDatosAlResumen();
            gridView5.RefreshData();
            decimal sumaCostosPestana5 = CalcularSumaCostosPestana5(dt);
            txtSumaCostosPestaña5.Text = sumaCostosPestana5.ToString("0.00");
        }

        private void btnEliminarPestaña1_Click(object sender, EventArgs e)
        {
            // Obtener el GridView correspondiente a la pestaña 1 (gridView1) y el índice de la fila seleccionada
            GridView gridView = gridView1;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                // Confirmar si el usuario desea eliminar el registro
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Eliminar la fila del DataTable asociado al gridControlPestaña1
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    dt.Rows.RemoveAt(selectedRowHandle);

                    // Actualizar el resumen y el gridControlPestaña1
                    AgregarDatosAlResumen();
                    gridView.RefreshData();
                    // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
                    decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
                    txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
                }
            }
        }

        private void btnEliminarPestaña2_Click(object sender, EventArgs e)
        {
            GridView gridView = gridView2;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    dt.Rows.RemoveAt(selectedRowHandle);
                    AgregarDatosAlResumen();
                    gridView.RefreshData();
                    decimal sumaCostosPestana2 = CalcularSumaCostosPestana2(dt);
                    txtSumaCostosPestaña2.Text = sumaCostosPestana2.ToString("0.00");
                }
            }
        }

        private void btnEliminarPestaña3_Click(object sender, EventArgs e)
        {
            GridView gridView = gridView3;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    dt.Rows.RemoveAt(selectedRowHandle);
                    AgregarDatosAlResumen();
                    gridView.RefreshData();
                    decimal sumaCostosPestana3 = CalcularSumaCostosPestana3(dt);
                    txtSumaCostosPestaña3.Text = sumaCostosPestana3.ToString("0.00");
                }
            }
        }

        private void btnEliminarPestaña4_Click(object sender, EventArgs e)
        {
            GridView gridView = gridView4;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    dt.Rows.RemoveAt(selectedRowHandle);
                    AgregarDatosAlResumen();
                    gridView.RefreshData();
                    decimal sumaCostosPestana4 = CalcularSumaCostosPestana4(dt);
                    txtSumaCostosPestaña4.Text = sumaCostosPestana4.ToString("0.00");
                }
            }
        }

        private void btnEliminarPestaña5_Click(object sender, EventArgs e)
        {
            GridView gridView = gridView5;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    dt.Rows.RemoveAt(selectedRowHandle);
                    AgregarDatosAlResumen();
                    gridView.RefreshData();
                    decimal sumaCostosPestana5 = CalcularSumaCostosPestana5(dt);
                    txtSumaCostosPestaña5.Text = sumaCostosPestana5.ToString("0.00");
                }
            }
        }






        // Clase auxiliar para almacenar la información del menú contextual
        private class MenuItemInfo
        {
            public GridView View { get; set; }
            public int RowHandle { get; set; }

            public MenuItemInfo(GridView view, int rowHandle)
            {
                View = view;
                RowHandle = rowHandle;
            }
        }

        // Evento que se activa cuando se hace clic en el elemento de menú "Eliminar Fila"
        private void OnMenuItemClick(object sender, EventArgs e)
        {
            if (sender is DXMenuItem item)
            {
                if (item.Tag is MenuItemInfo menuItemInfo)
                {
                    if (menuItemInfo.View.IsValidRowHandle(menuItemInfo.RowHandle))
                    {
                        menuItemInfo.View.DeleteRow(menuItemInfo.RowHandle);
                        // Obtener el DataTable asociado al gridControlPestaña1
                        DataTable dt = (DataTable)gridControlPestaña1.DataSource;
                        DataTable dt2 = (DataTable)gridControlPestaña2.DataSource;

                        // Actualizar el resumen y el gridControlPestaña1
                        AgregarDatosAlResumen();
                        gridView1.RefreshData();

                        // Calcular la suma de costos de la pestaña 1 y mostrarla en el textbox correspondiente
                        decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
                        decimal sumaCostosPestana2 = CalcularSumaCostosPestana1(dt2);
                        txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");
                        txtSumaCostosPestaña2.Text = sumaCostosPestana2.ToString("0.00");
                    }
                }
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                if (rowHandle >= 0 && view.IsDataRow(rowHandle))
                {
                    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Fila", OnMenuItemClick);
                    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                    menuItemEliminar.Tag = new MenuItemInfo(view, rowHandle);
                    e.Menu.Items.Add(menuItemEliminar);
                }
            }
        }

        private void gridView2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                if (rowHandle >= 0 && view.IsDataRow(rowHandle))
                {
                    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Fila", OnMenuItemClick);
                    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                    menuItemEliminar.Tag = new MenuItemInfo(view, rowHandle);
                    e.Menu.Items.Add(menuItemEliminar);
                }
            }
        }

        private void gridView3_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                if (rowHandle >= 0 && view.IsDataRow(rowHandle))
                {
                    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Fila", OnMenuItemClick);
                    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                    menuItemEliminar.Tag = new MenuItemInfo(view, rowHandle);
                    e.Menu.Items.Add(menuItemEliminar);
                }
            }
        }

        private void gridView4_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                if (rowHandle >= 0 && view.IsDataRow(rowHandle))
                {
                    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Fila", OnMenuItemClick);
                    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                    menuItemEliminar.Tag = new MenuItemInfo(view, rowHandle);
                    e.Menu.Items.Add(menuItemEliminar);
                }
            }
        }

        private void gridView5_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                GridView view = sender as GridView;
                if (rowHandle >= 0 && view.IsDataRow(rowHandle))
                {
                    DXMenuItem menuItemEliminar = new DXMenuItem("Eliminar Fila", OnMenuItemClick);
                    menuItemEliminar.ImageOptions.Image = imageCollection.Images[0]; // Agregar la imagen al elemento de menú
                    menuItemEliminar.Tag = new MenuItemInfo(view, rowHandle);
                    e.Menu.Items.Add(menuItemEliminar);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox de Tipo de Cotización
                ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboTipoCotizacion()
                    .FirstOrDefault(x => x.DescTablaElemento == cboTipoCotizacion.Text);

                if (itemSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de cotización válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Obtener el elemento ComboTipoCotizacionBE seleccionado en el ComboBox de Tipo de Moneda
                ComboTipoCotizacionBE itemMonedaSeleccionado = comboTipoCotizacionBL.ObtenerComboTipoMoneda()
                    .FirstOrDefault(x => x.DescTablaElemento == cboTipoMoneda.Text);

                if (itemMonedaSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de moneda válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el IdTablaElemento de los tipos de cotización y moneda seleccionados
                int idTipoCotizacion = itemSeleccionado.IdTablaElemento;
                int idMoneda = itemMonedaSeleccionado.IdTablaElemento;
                // Crear objeto CotizacionKiraBE con los valores ingresados por el usuario
                CotizacionKiraBE cotizacion = new CotizacionKiraBE
                {
                    IdTablaElemento = idTipoCotizacion, // IdTipoCotizacion obtenido del ComboBox de Tipo de Cotización
                    Fecha = txtFecha.DateTime,
                    CodigoProducto = txtCodigoProducto.Text,
                    Descripcion = txtBreveDescripcion.Text,
                    Caracteristicas = txtCaracteristicas.Text,
                    Imagen = "",
                    TotalGastos = decimal.TryParse(txtTotal.Text, out decimal totalGastos) ? totalGastos : 0.0m,
                    PrecioVenta = decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m,
                    IdMoneda = idMoneda, // IdMoneda obtenido del ComboBox de Tipo de Moneda
                    FlagEstado = true
                };

                // Calcular las sumas de costos de cada pestaña y agregarlas al objeto CotizacionKiraBE
                cotizacion.CostoMateriales = decimal.TryParse(txtSumaCostosPestaña1.Text, out decimal sumaCostosPestana1) ? sumaCostosPestana1 : 0.0m;
                cotizacion.CostoInsumos = decimal.TryParse(txtSumaCostosPestaña2.Text, out decimal sumaCostosPestana2) ? sumaCostosPestana2 : 0.0m;
                cotizacion.CostoAccesorios = decimal.TryParse(txtSumaCostosPestaña3.Text, out decimal sumaCostosPestana3) ? sumaCostosPestana3 : 0.0m;
                cotizacion.CostoManoObra = decimal.TryParse(txtSumaCostosPestaña4.Text, out decimal sumaCostosPestana4) ? sumaCostosPestana4 : 0.0m;
                cotizacion.CostoMovilidad = decimal.TryParse(txtSumaCostosPestaña5.Text, out decimal sumaCostosPestana5) ? sumaCostosPestana5 : 0.0m;
                //cotizacion.CostoEquipos = decimal.TryParse(txtSumaCostosPestaña6.Text, out decimal sumaCostosPestana6) ? sumaCostosPestana6 : 0.0m;
                cotizacion.CostoEquipos = decimal.Parse(txtEquipoyherramientas.Text);
                // Guardar la imagen en el fileserver y obtener la ruta de destino
                if (picImage.Image != null && !string.IsNullOrEmpty(openFile.FileName))
                {
                    string fileName = Path.GetFileName(openFile.FileName);
                    string destinationPath = Path.Combine(@"\\172.16.0.155\Sistemas\Imagenes", fileName);
                    try
                    {
                        File.Copy(openFile.FileName, destinationPath, true);
                        cotizacion.Imagen = destinationPath;
                    }
                    catch (Exception ex)
                    {
                        // Manejar errores si ocurre algún problema al copiar la imagen
                        MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Crear un nuevo DataTable para el detalle completo con la estructura requerida
                DataTable dtDetalleCompleto = new DataTable();
                dtDetalleCompleto.Columns.Add("IdTablaElemento", typeof(int));
                dtDetalleCompleto.Columns.Add("DescripcionGastos", typeof(string));
                dtDetalleCompleto.Columns.Add("FlagAprobacion", typeof(bool));
                dtDetalleCompleto.Columns.Add("FlagEstado", typeof(bool));
                dtDetalleCompleto.Columns.Add("Costo" + " " + " S/.", typeof(decimal));
                dtDetalleCompleto.Columns.Add("Item", typeof(int)); // Nueva columna para almacenar el número de item

                // Agregar los datos de cada pestaña al DataTable dtDetalleCompleto
                AgregarDatosDePestanaAlDetalle(dtDatospestaña1, dtDetalleCompleto);
                AgregarDatosDePestanaAlDetalle(dtDatospestaña2, dtDetalleCompleto);
                AgregarDatosDePestanaAlDetalle(dtDatospestaña3, dtDetalleCompleto);
                AgregarDatosDePestanaAlDetalle(dtDatospestaña4, dtDetalleCompleto);
                AgregarDatosDePestanaAlDetalle(dtDatospestaña5, dtDetalleCompleto);
                AgregarDatosDePestanaAlDetalle(dtDatospestaña6, dtDetalleCompleto);


                // Obtener la lista de detalles de cotización desde el dtDetalleCompleto
                List<DetalleCotizacionBE> detallesCotizacion = new List<DetalleCotizacionBE>();
                foreach (DataRow row in dtDetalleCompleto.Rows)
                {
                    DetalleCotizacionBE detalle = new DetalleCotizacionBE
                    {
                        IdTablaElemento = Convert.ToInt32(row["IdTablaElemento"]),
                        Item = Convert.ToInt32(row["Item"]),
                        DescripcionGastos = row["DescripcionGastos"].ToString(),
                        FlagAprobacion = Convert.ToBoolean(row["FlagAprobacion"]),
                        FlagEstado = Convert.ToBoolean(row["FlagEstado"]),
                        Costo = Convert.ToDecimal(row["Costo" + " " + " S/."]) // Agregar el campo Costo
                    };
                    detallesCotizacion.Add(detalle);
                }

                // Llamada al procedimiento almacenado con la nueva estructura
                int idCotizacion = 0;
                cotizacionKiraBL.RegistrarCotizacionYDetalle(cotizacion, detallesCotizacion, out idCotizacion);

                LimpiarControlesTextBox(this.Controls);
                valorespredeterminadosdeloscbo();
                lblCodigoExistente.Text = "";
                DataTable dtVacio = new DataTable();
                gridControlPestaña1.DataSource = dtVacio;
                gridControlPestaña2.DataSource = dtVacio;
                gridControlPestaña3.DataSource = dtVacio;
                gridControlPestaña4.DataSource = dtVacio;
                gridControlPestaña5.DataSource = dtVacio;
                gridControlPestaña6.DataSource = dtVacio;
                gridControlPestaña7Resumen.DataSource = dtVacio;
                this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;

                //MessageBox.Show("La cotización se registró correctamente. ID de cotización Precio Producto Cliente Stock : " + idCotizacion, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DevExpress.XtraEditors.XtraMessageBox.Show("La cotización se registró correctamente. ID de cotización Precio Producto Cliente Stock : " + idCotizacion, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Suponiendo que tienes una instancia de frmRegKiraCotizacion llamada formRegKiraCotizacion
                if (formRegKiraCotizacion == null)
                {
                    // Crear una nueva instancia si no existe
                    formRegKiraCotizacion = new frmRegKiraCotizacion();
                }

                // Llamar al método CargarListadoCotizaciones del formulario frmRegKiraCotizacion
                formRegKiraCotizacion.CargarListadoCotizaciones();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la cotización: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarControlesTextBox(this.Controls);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void picImage_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}