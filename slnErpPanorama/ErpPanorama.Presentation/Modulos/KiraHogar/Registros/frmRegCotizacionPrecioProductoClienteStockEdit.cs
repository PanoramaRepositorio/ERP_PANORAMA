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
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;


namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    public partial class frmRegCotizacionPrecioProductoClienteStockEdit : DevExpress.XtraEditors.XtraForm
    {
        private int idCotizacion;

        private CotizacionKiraBE cotizacion;

        private List<CotizacionKiraBE> listaCotizacionesOriginal = new List<CotizacionKiraBE>();
        private OpenFileDialog openFile = new OpenFileDialog();
        private CotizacionKiraBL cotizacionKiraBL = new CotizacionKiraBL();
        private ComboTipoCotizacionBL comboTipoCotizacionBL = new ComboTipoCotizacionBL();
        private frmRegKiraCotizacion formRegKiraCotizacion;
        // listaCotizacionesOriginal = comboTipoCotizacionBL.ObtenerListadoCotizaciones();
        public CotizacionKiraBE Cotizacion { get; set; }
        public int IdCotizacion
        {
            get { return idCotizacion; }
            set
            {
                idCotizacion = value;
                CargarCotizacion();
            }
        }


        public frmRegCotizacionPrecioProductoClienteStockEdit()
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

        private void frmRegCotizacionPrecioProductoClienteStockEdit_Load(object sender, EventArgs e)
        {

            CargarCotizacion();
            personalizacióncontrolesform();
            ConfigurarComboBoxTipoCotizacion();
            ConfigurarComboBoxMateriales();
            ConfigurarComboBoxInsumo();
            ConfigurarConboBoxAccesorio();
            ConfigurarComboBoxMano();
            ConfigurarComboBoxMovilidad();
            ConfigurarComboBoxTipoMoneda();
            ConfigurarComboBoxEquipos();
            ConfigurarComboBoxMateriales();
            CrearDatable_GridControl();
            calcularTotalGastospestaña7();
            AgregarDatosDePestanaAlResumen(dtDatospestaña1, dtDatosResumen);
            AgregarDatosDePestanaAlResumen(dtDatospestaña2, dtDatosResumen);
            // Establecer la propiedad MaxLength a 0 para permitir una cantidad ilimitada de caracteres


            txtCodigoProducto.TextChanged += txtCodigoProducto_TextChanged;

        }

        private void personalizacióncontrolesform()
        {

            gridView7.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            gridView7.Columns["DescTabla"].GroupIndex = 0; // Establecer la columna "DescTabla" como columna de agrupación
            txtNumeroCotizacion.Enabled = false;
            gridView7.ExpandAllGroups();
            //gridView7.OptionsView.ShowGroupPanel = true;
            //gridView7.OptionsView.ColumnAutoWidth = true;
            txtCodigoProducto.Properties.MaxLength = 0;
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

            // Obtener el objeto GridView asociado a gridControlPestaña1
            GridView gridViewPestaña1 = gridControlPestaña1.MainView as GridView;
            GridView gridViewPestaña2 = gridControlPestaña2.MainView as GridView;
            GridView gridViewPestaña3 = gridControlPestaña3.MainView as GridView;
            GridView gridViewPestaña4 = gridControlPestaña4.MainView as GridView;
            GridView gridViewPestaña5 = gridControlPestaña5.MainView as GridView;
            GridView gridViewPestaña6 = gridControlPestaña6.MainView as GridView;
            GridView gridViewPestaña7 = gridControlPestaña7Resumen.MainView as GridView;

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

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña3
                gridViewPestaña3.Columns["DescTabla"].Visible = false;
                gridViewPestaña3.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña3.Columns["IdCotizacion"].Visible = false;
                gridViewPestaña3.Columns["IdCotizacionDetalle"].Visible = false;
                // Ocultar las columnas que no quieres mostrar en gridControlPestaña4
                gridViewPestaña4.Columns["DescTabla"].Visible = false;
                gridViewPestaña4.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña4.Columns["IdCotizacion"].Visible = false;
                gridViewPestaña4.Columns["IdCotizacionDetalle"].Visible = false;

                // Ocultar las columnas que no quieres mostrar en gridControlPestaña5
                gridViewPestaña5.Columns["DescTabla"].Visible = false;
                gridViewPestaña5.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña5.Columns["IdCotizacion"].Visible = false;
                gridViewPestaña5.Columns["IdCotizacionDetalle"].Visible = false;

                gridViewPestaña7.Columns["DescTabla"].Visible = false;
                gridViewPestaña7.Columns["IdTablaElemento"].Visible = false;
                gridViewPestaña7.Columns["IdCotizacion"].Visible = false;
                gridViewPestaña7.Columns["IdCotizacionDetalle"].Visible = false;


            }

        }

        private void CrearDatable_GridControl()
        {
            // Crear el DataTable para almacenar los datos pestaña 1
            dtDatospestaña1 = new DataTable();
            dtDatospestaña1.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña1.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña1.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña1.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña1.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña1.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total

            dtDatospestaña2 = new DataTable();
            dtDatospestaña2.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña2.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña2.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña2.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña2.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña2.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total

            dtDatospestaña3 = new DataTable();
            dtDatospestaña3.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña3.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña3.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña3.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña3.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña3.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total

            dtDatospestaña4 = new DataTable();
            dtDatospestaña4.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña4.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña4.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña4.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña4.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña4.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total

            dtDatospestaña5 = new DataTable();
            dtDatospestaña5.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña5.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña5.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña5.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña5.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña5.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total

            dtDatospestaña6 = new DataTable();
            dtDatospestaña6.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatospestaña6.Columns.Add("IdCotizacion", typeof(int));
            dtDatospestaña6.Columns.Add("IdTablaElemento", typeof(int));
            dtDatospestaña6.Columns.Add("DescTabla", typeof(string));
            dtDatospestaña6.Columns.Add("DescripcionGastos", typeof(string));
            dtDatospestaña6.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total



            dtDatosResumen = new DataTable();
            dtDatosResumen.Columns.Add("IdCotizacionDetalle", typeof(int));
            dtDatosResumen.Columns.Add("IdCotizacion", typeof(int));
            dtDatosResumen.Columns.Add("IdTablaElemento", typeof(int));
            dtDatosResumen.Columns.Add("DescTabla", typeof(string));
            dtDatosResumen.Columns.Add("DescripcionGastos", typeof(string));
            dtDatosResumen.Columns.Add("Costo", typeof(decimal)); // Nueva columna para el precio total


            // Asignar el DataTable como fuente de datos para cada GridControl
            List<DetalleCotizacionBE> listamaterialesDetalles = cotizacionKiraBL.ObtenerDetelaleCotizacionMateriales(idCotizacion);

            foreach (DetalleCotizacionBE dt in listamaterialesDetalles)
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

            List<DetalleCotizacionBE> listainsumosDetalles = cotizacionKiraBL.ObtenerDetelaleCotizacionInsumos(idCotizacion);

            foreach (DetalleCotizacionBE dt in listainsumosDetalles)
            {
                DataRow fila = dtDatospestaña2.NewRow();
                fila["IdCotizacionDetalle"] = dt.IdCotizacionDetalle;
                fila["IdCotizacion"] = dt.CotizacionKira.IdCotizacion;
                fila["IdTablaElemento"] = dt.CotizacionKira.IdTablaElemento;
                fila["DescTabla"] = dt.DescTabla;
                fila["DescripcionGastos"] = dt.DescripcionGastos;
                fila["Costo"] = dt.Costo;
                dtDatospestaña2.Rows.Add(fila);
            }
            decimal sumaCostosPestana2 = CalcularSumaCostosPestana1(dtDatospestaña2);
            txtSumaCostosPestaña2.Text = sumaCostosPestana2.ToString("0.00");
            gridControlPestaña2.DataSource = dtDatospestaña2;

            List<DetalleCotizacionBE> listaAccesoriosDetalles = cotizacionKiraBL.ObtenerDetelaleCotizacionAccesorios(idCotizacion);

            foreach (DetalleCotizacionBE dt in listaAccesoriosDetalles)
            {
                DataRow fila = dtDatospestaña3.NewRow();
                fila["IdCotizacionDetalle"] = dt.IdCotizacionDetalle;
                fila["IdCotizacion"] = dt.CotizacionKira.IdCotizacion;
                fila["IdTablaElemento"] = dt.CotizacionKira.IdTablaElemento;
                fila["DescTabla"] = dt.DescTabla;
                fila["DescripcionGastos"] = dt.DescripcionGastos;
                fila["Costo"] = dt.Costo;
                dtDatospestaña3.Rows.Add(fila);
            }
            decimal sumaCostosPestana3 = CalcularSumaCostosPestana1(dtDatospestaña3);
            txtSumaCostosPestaña3.Text = sumaCostosPestana3.ToString("0.00");
            gridControlPestaña3.DataSource = dtDatospestaña3;

            List<DetalleCotizacionBE> listaManoObraDetalles = cotizacionKiraBL.ObtenerDetelaleCotizacionManoObra(idCotizacion);

            foreach (DetalleCotizacionBE dt in listaManoObraDetalles)
            {
                DataRow fila = dtDatospestaña4.NewRow();
                fila["IdCotizacionDetalle"] = dt.IdCotizacionDetalle;
                fila["IdCotizacion"] = dt.CotizacionKira.IdCotizacion;
                fila["IdTablaElemento"] = dt.CotizacionKira.IdTablaElemento;
                fila["DescTabla"] = dt.DescTabla;
                fila["DescripcionGastos"] = dt.DescripcionGastos;
                fila["Costo"] = dt.Costo;
                dtDatospestaña4.Rows.Add(fila);
            }
            decimal sumaCostosPestana4 = CalcularSumaCostosPestana1(dtDatospestaña4);
            txtSumaCostosPestaña4.Text = sumaCostosPestana4.ToString("0.00");
            gridControlPestaña4.DataSource = dtDatospestaña4;

            List<DetalleCotizacionBE> listaMovilidadDetalles = cotizacionKiraBL.ObtenerDetelaleCotizacionMovilidad(idCotizacion);

            foreach (DetalleCotizacionBE dt in listaMovilidadDetalles)
            {
                DataRow fila = dtDatospestaña5.NewRow();
                fila["IdCotizacionDetalle"] = dt.IdCotizacionDetalle;
                fila["IdCotizacion"] = dt.CotizacionKira.IdCotizacion;
                fila["IdTablaElemento"] = dt.CotizacionKira.IdTablaElemento;
                fila["DescTabla"] = dt.DescTabla;
                fila["DescripcionGastos"] = dt.DescripcionGastos;
                fila["Costo"] = dt.Costo;
                dtDatospestaña5.Rows.Add(fila);
            }
            decimal sumaCostosPestana5 = CalcularSumaCostosPestana1(dtDatospestaña5);
            txtSumaCostosPestaña5.Text = sumaCostosPestana5.ToString("0.00");
            gridControlPestaña5.DataSource = dtDatospestaña5;

            List<DetalleCotizacionBE> listaEquiposDetalles = cotizacionKiraBL.ObtenerDetelaleEquipos(idCotizacion);

            foreach (DetalleCotizacionBE dt in listaEquiposDetalles)
            {
                DataRow fila = dtDatospestaña6.NewRow();
                fila["IdCotizacionDetalle"] = dt.IdCotizacionDetalle;
                fila["IdCotizacion"] = dt.CotizacionKira.IdCotizacion;
                fila["IdTablaElemento"] = dt.CotizacionKira.IdTablaElemento;
                fila["DescTabla"] = dt.DescTabla;
                fila["DescripcionGastos"] = dt.DescripcionGastos;
                fila["Costo"] = dt.Costo;
                dtDatospestaña6.Rows.Add(fila);
            }
            gridControlPestaña6.DataSource = dtDatospestaña6;


            // Agregar un evento TableNewRow a cada DataTable para actualizar automáticamente el resumen
            dtDatospestaña1.TableNewRow += DtDatospestaña1_TableNewRow;
            dtDatospestaña2.TableNewRow += DtDatospestaña2_TableNewRow;
            dtDatospestaña3.TableNewRow += DtDatospestaña3_TableNewRow;
            dtDatospestaña4.TableNewRow += DtDatospestaña4_TableNewRow;
            dtDatospestaña5.TableNewRow += DtDatospestaña5_TableNewRow;
            dtDatospestaña6.TableNewRow += DtDatospestaña6_TableNewRow;
            gridControlPestaña7Resumen.DataSource = dtDatosResumen;

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


        private string ObtenerNombreTablaElemento(string idTablaElemento)
        {
            // Valores y nombres correspondientes
            Dictionary<string, string> nombresTablaElemento = new Dictionary<string, string>
                {
                    { Parametros.idACEROedit, Parametros.materiales},
                    { Parametros.idBRONCEedit, Parametros.materiales},
                    { Parametros.idCASOedit, Parametros.materiales},
                    { Parametros.idESPUMAedit, Parametros.materiales },
                    { Parametros.idESPEJOedit, Parametros.materiales },
                    { Parametros.idFIERROedit, Parametros.materiales },
                    { Parametros.idMADERAedit, Parametros.materiales },
                    { Parametros.idMDFedit, Parametros.materiales},
                    { Parametros.idMELAMINEedit, Parametros.materiales },
                    { Parametros.idNAPAedit, Parametros.materiales},
                    { Parametros.idNOTEXedit, Parametros.materiales },
                    { Parametros.idPIEDRAedit, Parametros.materiales },
                    { Parametros.idTELAedit, Parametros.materiales },
                    { Parametros.idVIDRIOedit, Parametros.materiales },
                    { Parametros.idENCHAPEedit, Parametros.materiales },


                    { Parametros.idCARTON_PRENSADOedit, Parametros.insumos },
                    { Parametros.idCRUDOedit, Parametros.insumos  },
                    { Parametros.idNOSAGedit, Parametros.insumos  },
                    { Parametros.iidPINTURAedit, Parametros.insumos  },
                    { Parametros.idPOLISEAedit, Parametros.insumos },

                    { Parametros.idBISAGRASedit, Parametros.accesorios},
                    { Parametros.idCORREDERASedit, Parametros.accesorios },
                    { Parametros.idTIRADORESedit, Parametros.accesorios },
                    { Parametros.idILUMINACIONedit, Parametros.accesorios },
                    { Parametros.idPATASZOCALOedit, Parametros.accesorios },
                    { Parametros.idPATASMADERAedit, Parametros.accesorios },
                    { Parametros.idPATASMETALICASedit,Parametros.accesorios},

                    { Parametros.idCARPINTERIAedit, Parametros.manodeobra},
                    { Parametros.idCOSTUREROEDIT, Parametros.manodeobra },
                    { Parametros.idELECTRICISTAedit, Parametros.manodeobra},
                    { Parametros.idESAMBLADORedit, Parametros.manodeobra},
                    { Parametros.idPINTURASedit, Parametros.manodeobra},
                    { Parametros.idSOLDADORedit, Parametros.manodeobra},
                    { Parametros.idTAPICEROedit, Parametros.manodeobra },
                    { Parametros.idVIDRIEROedit, Parametros.manodeobra },

                    { Parametros.idPASAJEDISENADORAedit, Parametros.movilidadyViatios },
                    { Parametros.idPASAJEPARAENTREGAedit, Parametros.movilidadyViatios},
                    { Parametros.idPASAJEPRODUCCIONedit, Parametros.movilidadyViatios },
                    { Parametros.idVIATICOSedit, Parametros.movilidadyViatios },
                    //{ 753, "EQUIPOS Y HERRAMIENTAS" },
                    // Agrega aquí más valores y nombres correspondientes
                };

            return nombresTablaElemento.ContainsKey(idTablaElemento) ? nombresTablaElemento[idTablaElemento] : string.Empty;
        }

        public void calcularTotalGastospestaña7()
        {
            CotizacionKiraBE cotizacion = new CotizacionKiraBE();
            DataTable dt = (DataTable)gridControlPestaña7Resumen.DataSource;
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

            // Agregar los datos de la pestaña 2 al resumen
            foreach (DataRow row in dtDatospestaña2.Rows)
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

            foreach (DataRow row in dtDatospestaña3.Rows)
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

            foreach (DataRow row in dtDatospestaña4.Rows)
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

            foreach (DataRow row in dtDatospestaña5.Rows)
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

            foreach (DataRow row in dtDatospestaña6.Rows)
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
            calcularTotalGastospestaña7();
            gridView7.ExpandAllGroups();
        }

        // Método para agregar todos los datos de cada pestaña al resumen
        private void AgregarDatosAlResumen()
        {
            dtDatosResumen.Rows.Clear();
            AgregarDatosDePestanaAlResumen(dtDatospestaña1, dtDatosResumen);
            AgregarDatosDePestanaAlResumen(dtDatospestaña2, dtDatosResumen);
            AgregarDatosDePestanaAlResumen(dtDatospestaña3, dtDatosResumen);
            AgregarDatosDePestanaAlResumen(dtDatospestaña4, dtDatosResumen);
            AgregarDatosDePestanaAlResumen(dtDatospestaña5, dtDatosResumen);
            AgregarDatosDePestanaAlResumen(dtDatospestaña6, dtDatosResumen);
            // Agregar más llamadas a AgregarDatosDePestanaAlResumen para las otras pestañas si es necesario
            gridControlPestaña7Resumen.DataSource = dtDatosResumen;
            calcularTotalGastospestaña7();
            gridView7.ExpandAllGroups();
        }

        private string originalImagePath;
        private void CargarCotizacion()
        {
            try
            {
                if (idCotizacion > 0)
                {
                    cotizacion = cotizacionKiraBL.ObtenerCotizacionPorId(idCotizacion);
                    txtNumeroCotizacion.Text = cotizacion.IdCotizacion.ToString();
                    txtCodigoProducto.Text = cotizacion.CodigoProducto;
                    txtBreveDescripcion.Text = cotizacion.Descripcion;
                    txtCaracteristicas.Text = cotizacion.Caracteristicas;
                    txtFecha.Text = cotizacion.Fecha.ToString();
                    txtFecha.ReadOnly = true; // Deshabilitar la edición
                    ConfigurarComboBoxTipoCotizacion();
                    ConfigurarComboBoxTipoMoneda();

                    // Seleccionar el valor en el ComboBoxEdit cboTipoCotizacion
                    cboTipoCotizacion.EditValue = cotizacion.DescTablaElemento;
                    //cboTipoCotizacion.ReadOnly = true; // Deshabilitar la edición


                    if (cotizacion.IdMoneda == 6)
                    {
                        cboTipoMoneda.EditValue = "DOLARES AMERICANOS";
                    }
                    else if (cotizacion.IdMoneda == 5)
                    {
                        cboTipoMoneda.EditValue = "SOLES";
                    }
                    //cboTipoMoneda.ReadOnly = true; // Deshabilitar la edición

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
                    //gvCotizacionEdit.GridControl.DataSource = cotizacionKiraBL.ObtenerCotizacionPorId2(idCotizacion);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarComboBoxTipoCotizacion()
        {

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
            //cboTipoMoneda.Text = "Seleccione Moneda";
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
        public void ConfigurarComboBoxEquipos()
        {
            //cboequipos.Text = "Seleccione opción";
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
                CotizacionKiraBE cotizacion = new CotizacionKiraBE();
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
                cotizacion.CostoMateriales = decimal.TryParse(txtSumaCostosPestaña1.Text, out decimal sumaCostosPestana1) ? sumaCostosPestana1 : 0.0m;
                cotizacion.CostoInsumos = decimal.TryParse(txtSumaCostosPestaña2.Text, out decimal sumaCostosPestana2) ? sumaCostosPestana2 : 0.0m;
                cotizacion.CostoAccesorios = decimal.TryParse(txtSumaCostosPestaña3.Text, out decimal sumaCostosPestana3) ? sumaCostosPestana3 : 0.0m;
                cotizacion.CostoManoObra = decimal.TryParse(txtSumaCostosPestaña4.Text, out decimal sumaCostosPestana4) ? sumaCostosPestana4 : 0.0m;
                cotizacion.CostoMovilidad = decimal.TryParse(txtSumaCostosPestaña5.Text, out decimal sumaCostosPestana5) ? sumaCostosPestana5 : 0.0m;
                //cotizacion.CostoEquipos = decimal.TryParse(txtSumaCostosPestaña6.Text, out decimal sumaCostosPestana6) ? sumaCostosPestana6 : 0.0m;
                cotizacion.CostoEquipos = decimal.Parse(txtEquipoyherramientas.Text);

                // Actualizar la cotización en la capa de negocios
                cotizacionKiraBL.ActualizarCotizacion(cotizacion);

                // Actualizar los detalles de la cotización
                List<DetalleCotizacionBE> detallesCotizacion = new List<DetalleCotizacionBE>();

                foreach (DataRow row in dtDatosResumen.Rows)
                {
                    DetalleCotizacionBE detalle = new DetalleCotizacionBE();
                    detalle.IdCotizacion = cotizacion.IdCotizacion;
                    detalle.IdCotizacionDetalle = Convert.ToInt32(row["IdCotizacionDetalle"]);
                    detalle.DescripcionGastos = Convert.ToString(row["DescripcionGastos"]);
                    detalle.Costo = Convert.ToDecimal(row["Costo"]);
                    detallesCotizacion.Add(detalle);
                }

                cotizacionKiraBL.ActualizarDetalleCotizacion(detallesCotizacion);

                // Mostrar mensaje de éxito
                DevExpress.XtraEditors.XtraMessageBox.Show("Cotización Precio Producto Cliente Stock actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (cotizacionKiraBLs.ValidarCodigoProducto(txtCodigoProducto.Text))
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarPestaña1_Click(object sender, EventArgs e)
        {
            string material = cboMaterial.Text;
            string monto = txtPrecio.Text;

            if (string.IsNullOrWhiteSpace(material))
            {
                MessageBox.Show("Por favor, seleccione un material antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(monto, out decimal montoDecimal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComboTipoCotizacionBE itemSeleccionado = comboTipoCotizacionBL.ObtenerComboMateriales()
                .FirstOrDefault(x => x.DescTablaElemento == cboMaterial.Text);

            if (itemSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un elemento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idTablaElemento = itemSeleccionado.IdTablaElemento;

            // Llamar al método de la capa de negocio para agregar el detalle
            cotizacionKiraBL.AgregarDetalleCotizacion(cotizacion.IdCotizacion, idTablaElemento, material, montoDecimal);

            // Obtener el nuevo detalle recién agregado desde la base de datos
            DetalleCotizacionBE nuevoDetalle = cotizacionKiraBL.ObtenerUltimoDetalleCotizacion(cotizacion.IdCotizacion);

            DataTable dt = (DataTable)gridControlPestaña1.DataSource;
            DataRow existingRow = dt.AsEnumerable().FirstOrDefault(row => row.Field<string>("DescripcionGastos") == material);

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
                newRow["DescripcionGastos"] = material;
                newRow["Costo"] = montoDecimal;
                dt.Rows.Add(newRow);
            }

            AgregarDatosAlResumen();
            gridView7.ExpandAllGroups();

            decimal sumaCostosPestana1 = CalcularSumaCostosPestana1(dt);
            txtSumaCostosPestaña1.Text = sumaCostosPestana1.ToString("0.00");

            cboMaterial.Text = "Seleccione Materiales";
            txtPrecio.Text = string.Empty;

            // Refrescar el gridControlPestaña1
            gridControlPestaña2.RefreshDataSource();

        }

        private void btnAgregarPestaña2_Click(object sender, EventArgs e)
        {
            try
            {
                string insumo = cboInsumos.Text;
                string monto = txtinsumo.Text;
                if (string.IsNullOrWhiteSpace(insumo))
                {
                    MessageBox.Show("Por favor, seleccione un Insumo antes de agregar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Llamar al método de la capa de negocio para agregar el detalle
                cotizacionKiraBL.AgregarDetalleCotizacion(cotizacion.IdCotizacion, idTablaElemento, insumo, montoDecimal);

                // Obtener el nuevo detalle recién agregado desde la base de datos
                DetalleCotizacionBE nuevoDetalle = cotizacionKiraBL.ObtenerUltimoDetalleCotizacion(cotizacion.IdCotizacion);
                DataTable dt = (DataTable)gridControlPestaña2.DataSource;
                DataRow existingRow = dt.AsEnumerable()
                    .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == insumo);
                if (existingRow != null)
                {
                    //int currentItem = existingRow.Field<int>("Item");
                    decimal currentItemCosto = existingRow.Field<decimal>("Costo");
                    //existingRow["Item"] = currentItem + 1;
                    existingRow["Costo"] = currentItemCosto + montoDecimal;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow["DescTabla"] = idTablaElemento;
                    newRow["IdTablaElemento"] = idTablaElemento;
                    newRow["IdCotizacionDetalle"] = nuevoDetalle.IdCotizacionDetalle; // Nuevo IdCotizacionDetalle
                    newRow["IdCotizacion"] = cotizacion.IdCotizacion;
                    newRow["DescripcionGastos"] = insumo;
                    newRow["Costo"] = montoDecimal;
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
                cotizacionKiraBL.AgregarDetalleCotizacion(cotizacion.IdCotizacion, idTablaElemento, accesorio, montoDecimal);

                // Obtener el nuevo detalle recién agregado desde la base de datos
                DetalleCotizacionBE nuevoDetalle = cotizacionKiraBL.ObtenerUltimoDetalleCotizacion(cotizacion.IdCotizacion);
                DataTable dt = (DataTable)gridControlPestaña3.DataSource;
                DataRow existingRow = dt.AsEnumerable()
                    .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == accesorio);

                if (existingRow != null)
                {
                    // int currentItem = existingRow.Field<int>("Item");
                    decimal currentItemCosto = existingRow.Field<decimal>("");
                    //existingRow["Item"] = currentItem + 1;
                    existingRow["Costo"] = currentItemCosto + montoDecimal;
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    newRow["DescTabla"] = idTablaElemento;
                    newRow["IdTablaElemento"] = idTablaElemento;
                    newRow["IdCotizacionDetalle"] = nuevoDetalle.IdCotizacionDetalle; // Nuevo IdCotizacionDetalle
                    newRow["IdCotizacion"] = cotizacion.IdCotizacion;
                    newRow["DescripcionGastos"] = accesorio;
                    newRow["Costo"] = montoDecimal;
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
            cotizacionKiraBL.AgregarDetalleCotizacion(cotizacion.IdCotizacion, idTablaElemento, manoobra, montoDecimal);

            // Obtener el nuevo detalle recién agregado desde la base de datos
            DetalleCotizacionBE nuevoDetalle = cotizacionKiraBL.ObtenerUltimoDetalleCotizacion(cotizacion.IdCotizacion);
            DataTable dt = (DataTable)gridControlPestaña4.DataSource;
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == manoobra);

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
                newRow["DescripcionGastos"] = manoobra;
                newRow["Costo"] = montoDecimal;
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
            cotizacionKiraBL.AgregarDetalleCotizacion(cotizacion.IdCotizacion, idTablaElemento, movilidad, montoDecimal);

            // Obtener el nuevo detalle recién agregado desde la base de datos
            DetalleCotizacionBE nuevoDetalle = cotizacionKiraBL.ObtenerUltimoDetalleCotizacion(cotizacion.IdCotizacion);
            DataTable dt = (DataTable)gridControlPestaña5.DataSource;
            DataRow existingRow = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("DescripcionGastos") == movilidad);
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
                newRow["DescripcionGastos"] = movilidad;
                newRow["Costo"] = montoDecimal;
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


        private void btnEliminarPestaña1_Click(object sender, EventArgs e)
        {

            GridView gridView = gridView1;
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Obtener el IdCotizacionDetalle desde el DataTable del DataSource
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    int idCotizacionDetalle = Convert.ToInt32(dt.Rows[selectedRowHandle]["IdCotizacionDetalle"]);

                    // Llamar al método de la capa de negocio para eliminar el detalle
                    cotizacionKiraBL.EliminarDetalleCotizacion(idCotizacionDetalle);

                    // Actualizar el resumen y el gridControlPestaña1
                    AgregarDatosAlResumen();
                    gridView.RefreshData();

                    // Eliminar la fila del DataTable
                    dt.Rows.RemoveAt(selectedRowHandle);

                    // Refrescar el gridControlPestaña1
                    gridControlPestaña1.RefreshDataSource();
                    AgregarDatosAlResumen();
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
                    // Obtener el IdCotizacionDetalle desde el DataTable del DataSource
                    DataTable dt = (DataTable)gridView.GridControl.DataSource;
                    int idCotizacionDetalle = Convert.ToInt32(dt.Rows[selectedRowHandle]["IdCotizacionDetalle"]);

                    // Llamar al método de la capa de negocio para eliminar el detalle
                    cotizacionKiraBL.EliminarDetalleCotizacion(idCotizacionDetalle);

                    // Actualizar el resumen y el gridControlPestaña1
                    gridView.RefreshData();

                    // Eliminar la fila del DataTable
                    dt.Rows.RemoveAt(selectedRowHandle);
                    AgregarDatosAlResumen();
                    // Refrescar el gridControlPestaña1
                    gridControlPestaña2.RefreshDataSource();
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
                    int idCotizacionDetalle = Convert.ToInt32(dt.Rows[selectedRowHandle]["IdCotizacionDetalle"]);
                    // Llamar al método de la capa de negocio para eliminar el detalle
                    cotizacionKiraBL.EliminarDetalleCotizacion(idCotizacionDetalle);
                    gridView.RefreshData();
                    dt.Rows.RemoveAt(selectedRowHandle);
                    gridControlPestaña3.RefreshDataSource();
                    AgregarDatosAlResumen();
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
                    int idCotizacionDetalle = Convert.ToInt32(dt.Rows[selectedRowHandle]["IdCotizacionDetalle"]);
                    cotizacionKiraBL.EliminarDetalleCotizacion(idCotizacionDetalle);
                    gridView.RefreshData();
                    dt.Rows.RemoveAt(selectedRowHandle);
                    gridControlPestaña4.RefreshDataSource();
                    AgregarDatosAlResumen();
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
                    int idCotizacionDetalle = Convert.ToInt32(dt.Rows[selectedRowHandle]["IdCotizacionDetalle"]);
                    cotizacionKiraBL.EliminarDetalleCotizacion(idCotizacionDetalle);
                    gridView.RefreshData();
                    dt.Rows.RemoveAt(selectedRowHandle);
                    gridControlPestaña5.RefreshDataSource();
                    gridControlPestaña7Resumen.RefreshDataSource();
                    AgregarDatosAlResumen();
                    decimal sumaCostosPestana5 = CalcularSumaCostosPestana5(dt);
                    txtSumaCostosPestaña5.Text = sumaCostosPestana5.ToString("0.00");
                }
            }
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

        private decimal CalcularSumaCostosPestana2(DataTable dt)
        {
            decimal sumaCostos = 0.0m;
            foreach (DataRow row in dt.Rows)
            {
                if (decimal.TryParse(row["Costo"].ToString(), out decimal costo))
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
                if (decimal.TryParse(row["Costo"].ToString(), out decimal costo))
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
                if (decimal.TryParse(row["Costo"].ToString(), out decimal costo))
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
                if (decimal.TryParse(row["Costo"].ToString(), out decimal costo))
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
                if (decimal.TryParse(row["Costo"].ToString(), out decimal costo))
                {
                    sumaCostos += costo;
                }
            }
            return sumaCostos;
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
