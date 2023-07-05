using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using ErpPanorama.Presentation.Utils;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepVentasDiarias: DevExpress.XtraEditors.XtraForm
    {
        public frmRepVentasDiarias()
        {
            InitializeComponent();
            //gcApeNom.Caption = "Apellidos y\nNombres";
            //gcSueldoBruto.Caption = "Sueldo\nBruto";
        }

        private void frmRepVentasDiarias_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            txtPeriodo.EditValue = Parametros.intPeriodo;
            cboMes.EditValue = DateTime.Now.Month;
            
            BSUtils.LoaderLook(cboTipoReporte, CargarTipoReporte(), "Descripcion", "Id", false);
            cboTipoReporte.EditValue = 1;
            BSUtils.LoaderLook(cboTipoOperacion, CargarTipoResumen(), "Descripcion", "Id", false);
            cboTipoOperacion.EditValue = 1;

            BSUtils.LoaderLook(cboTienda, CargarTienda(), "Descripcion", "Id", false);
            cboTienda.EditValue = Parametros.intTiendaId;

            cboTienda.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarGrilla();

            if (chkResumen.Checked)
                CargarResumen();
            else
                Cargar();
 
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoReporteDTK_" + txtPeriodo.EditValue.ToString() + "-" + cboMes.EditValue.ToString(); ;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcReporte.DefaultView.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls", new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                if (XtraMessageBox.Show("Desea abrir este archivo", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(f.SelectedPath + @"\" + _fileName + ".xls");
                }

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMes_SelectedValueChanged(object sender, EventArgs e)
        {
            //CargarGrilla();
            ////ConfigurarGrilla();
            //switch (Convert.ToInt32(cboMes.EditValue))
            //{
            //    case 2:
            //        if (Convert.ToInt32(txtPeriodo.EditValue) % 4 == 0 && Convert.ToInt32(txtPeriodo.EditValue) % 100 != 0 || Convert.ToInt32(txtPeriodo.EditValue) % 400 == 0) //Bisiesto
            //            ConfigurarGrilla29dias();
            //        else
            //            ConfigurarGrilla28dias();
            //        break;
            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        ConfigurarGrilla30dias();
            //        break;
            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        ConfigurarGrilla31dias();
            //        break;
            //}
        }

        #region "Métodos"
        private void Cargar()
        {
            if(Convert.ToInt32(cboTienda.EditValue)==100 || Convert.ToInt32(cboTienda.EditValue) == 101)
            {
                XtraMessageBox.Show("opción disponible sólo para resumen semanal",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DateTime deDesde;
            DateTime deHasta;
            deDesde = new DateTime(Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), 1);
            deHasta = new DateTime(deDesde.Year, deDesde.Month, 1).AddMonths(1).AddDays(-1);

            int TipoReporte;
            TipoReporte = 2; // Convert.ToInt32(cboTipoReporte.EditValue);

            DataTable dt = null;
            dt = new ReporteVentaDataTicketBL().ListadoVtasDiarias(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue) , Convert.ToDateTime(deDesde.ToShortDateString()),Convert.ToDateTime(deHasta.ToShortDateString()), TipoReporte);
            gcReporte.DataSource = dt;
            Cursor = Cursors.Default;

            gvReporte.ViewCaption = (cboMes.Text + " - " + txtPeriodo.Text).ToUpper();
        }

        private void CargarResumen()
        {
            DateTime deDesde;
            DateTime deHasta;
            deDesde = new DateTime(Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), 1);
            deHasta = new DateTime(deDesde.Year, deDesde.Month, 1).AddMonths(1).AddDays(-1);

            int TipoReporte = Convert.ToInt32(cboTipoReporte.EditValue); ;
            int TipoOperacion = Convert.ToInt32(cboTipoOperacion.EditValue);

            DataTable dt = null;
            dt = new ReporteVentaDataTicketResumenBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToDateTime(deDesde.ToShortDateString()), Convert.ToDateTime(deHasta.ToShortDateString()), TipoReporte, TipoOperacion);
            gcReporte.DataSource = dt;
            Cursor = Cursors.Default;

            gvReporte.ViewCaption = ("REPORTE SEMANAL - " + cboTipoOperacion.Text +" "+ cboTipoReporte.Text + " - " + cboTienda.Text + " - " + cboMes.Text + " " + txtPeriodo.Text).ToUpper();
        }

        private void ConfigurarGrilla28dias()
        {
            gcReporte.ForceInitialize();
            gvReporte.PopulateColumns();

            gvReporte.Columns.Clear();
            gvReporte.SelectAll();
            gvReporte.DeleteSelectedRows();

            gvReporte.OptionsBehavior.Editable = true;
            gvReporte.OptionsCustomization.AllowColumnMoving = true;
            gvReporte.OptionsCustomization.AllowGroup = false;
            gvReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvReporte.OptionsSelection.MultiSelect = true;
            gvReporte.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvReporte.OptionsView.ShowGroupPanel = false;
            gvReporte.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gvReporte.OptionsView.ColumnAutoWidth = false;

            DevExpress.XtraGrid.Columns.GridColumn gcIdTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHora = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHoraFin = new DevExpress.XtraGrid.Columns.GridColumn();

            for (int i = 0; i <= 10; i++)
            {

                DevExpress.XtraGrid.Columns.GridColumn asddsa = new DevExpress.XtraGrid.Columns.GridColumn();

            }
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdTienda.Caption = "IdTienda";
            gcIdTienda.FieldName = "IdTienda";
            gcIdTienda.Name = "gcIdTienda";
            gcIdTienda.OptionsColumn.AllowEdit = false;
            gcIdTienda.Visible = false;
            gcIdTienda.VisibleIndex = -1;
            gcIdTienda.Width = 100;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 1;
            gcDescTienda.Width = 200;

            gcHora.Caption = "Cuota Mensual";
            gcHora.FieldName = "CuotaMensual";
            gcHora.Name = "gcCuotaMensual";
            gcHora.OptionsColumn.AllowEdit = false;
            gcHora.Visible = true;
            gcHora.VisibleIndex = 2;
            gcHora.Width = 80;

            gcHoraFin.Caption = "Cuota Diaria";
            gcHoraFin.FieldName = "CuotaDiaria";
            gcHoraFin.Name = "gcCuotaDiaria";
            gcHoraFin.OptionsColumn.AllowEdit = false;
            gcHoraFin.Visible = true;
            gcHoraFin.VisibleIndex = 2;
            gcHoraFin.Width = 80;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 3;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 4;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 5;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 6;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 7;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 8;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 9;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 10;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 11;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 12;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 13;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 14;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 15;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 16;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 17;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 18;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 19;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 20;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 21;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 22;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 23;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 24;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 25;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 26;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 27;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 28;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 29;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 30;
            gc28.Width = 25;

            //Formato para Valor venta
                #region "Formato Valor Venta"
                gc1.DisplayFormat.FormatString = "#,0.00";
                gc1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc2.DisplayFormat.FormatString = "#,0.00";
                gc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc3.DisplayFormat.FormatString = "#,0.00";
                gc3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc4.DisplayFormat.FormatString = "#,0.00";
                gc4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc5.DisplayFormat.FormatString = "#,0.00";
                gc5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc6.DisplayFormat.FormatString = "#,0.00";
                gc6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc7.DisplayFormat.FormatString = "#,0.00";
                gc7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc8.DisplayFormat.FormatString = "#,0.00";
                gc8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc9.DisplayFormat.FormatString = "#,0.00";
                gc9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc10.DisplayFormat.FormatString = "#,0.00";
                gc10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc11.DisplayFormat.FormatString = "#,0.00";
                gc11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc12.DisplayFormat.FormatString = "#,0.00";
                gc12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc13.DisplayFormat.FormatString = "#,0.00";
                gc13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc14.DisplayFormat.FormatString = "#,0.00";
                gc14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc15.DisplayFormat.FormatString = "#,0.00";
                gc15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc16.DisplayFormat.FormatString = "#,0.00";
                gc16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc17.DisplayFormat.FormatString = "#,0.00";
                gc17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc18.DisplayFormat.FormatString = "#,0.00";
                gc18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc19.DisplayFormat.FormatString = "#,0.00";
                gc19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc20.DisplayFormat.FormatString = "#,0.00";
                gc20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc21.DisplayFormat.FormatString = "#,0.00";
                gc21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc22.DisplayFormat.FormatString = "#,0.00";
                gc22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc23.DisplayFormat.FormatString = "#,0.00";
                gc23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc24.DisplayFormat.FormatString = "#,0.00";
                gc24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc25.DisplayFormat.FormatString = "#,0.00";
                gc25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc26.DisplayFormat.FormatString = "#,0.00";
                gc26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc27.DisplayFormat.FormatString = "#,0.00";
                gc27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc28.DisplayFormat.FormatString = "#,0.00";
                gc28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc1.Width = 60;
                gc2.Width = 60;
                gc3.Width = 60;
                gc4.Width = 60;
                gc5.Width = 60;
                gc6.Width = 60;
                gc7.Width = 60;
                gc8.Width = 60;
                gc9.Width = 60;
                gc10.Width = 60;
                gc11.Width = 60;
                gc12.Width = 60;
                gc13.Width = 60;
                gc14.Width = 60;
                gc15.Width = 60;
                gc16.Width = 60;
                gc17.Width = 60;
                gc18.Width = 60;
                gc19.Width = 60;
                gc20.Width = 60;
                gc21.Width = 60;
                gc22.Width = 60;
                gc23.Width = 60;
                gc24.Width = 60;
                gc25.Width = 60;
                gc26.Width = 60;
                gc27.Width = 60;
                gc28.Width = 60;
                #endregion

            //Formatear cabecera
            int Anio = Convert.ToInt32(txtPeriodo.EditValue);
            int Mes = Convert.ToInt32(cboMes.EditValue);


            gc1.Caption = string.Concat((new DateTime(Anio, Mes, 1).ToString("dddd")), " \n", 1);
            gc2.Caption = string.Concat((new DateTime(Anio, Mes, 2).ToString("dddd")), " \n", 2);
            gc3.Caption = string.Concat((new DateTime(Anio, Mes, 3).ToString("dddd")), " \n", 3);
            gc4.Caption = string.Concat((new DateTime(Anio, Mes, 4).ToString("dddd")), " \n", 4);
            gc5.Caption = string.Concat((new DateTime(Anio, Mes, 5).ToString("dddd")), " \n", 5);
            gc6.Caption = string.Concat((new DateTime(Anio, Mes, 6).ToString("dddd")), " \n", 6);
            gc7.Caption = string.Concat((new DateTime(Anio, Mes, 7).ToString("dddd")), " \n", 7);
            gc8.Caption = string.Concat((new DateTime(Anio, Mes, 8).ToString("dddd")), " \n", 8);
            gc9.Caption = string.Concat((new DateTime(Anio, Mes, 9).ToString("dddd")), " \n", 9);
            gc10.Caption = string.Concat((new DateTime(Anio, Mes, 10).ToString("dddd")), " \n", 10);
            gc11.Caption = string.Concat((new DateTime(Anio, Mes, 11).ToString("dddd")), " \n", 11);
            gc12.Caption = string.Concat((new DateTime(Anio, Mes, 12).ToString("dddd")), " \n", 12);
            gc13.Caption = string.Concat((new DateTime(Anio, Mes, 13).ToString("dddd")), " \n", 13);
            gc14.Caption = string.Concat((new DateTime(Anio, Mes, 14).ToString("dddd")), " \n", 14);
            gc15.Caption = string.Concat((new DateTime(Anio, Mes, 15).ToString("dddd")), " \n", 15);
            gc16.Caption = string.Concat((new DateTime(Anio, Mes, 16).ToString("dddd")), " \n", 16);
            gc17.Caption = string.Concat((new DateTime(Anio, Mes, 17).ToString("dddd")), " \n", 17);
            gc18.Caption = string.Concat((new DateTime(Anio, Mes, 18).ToString("dddd")), " \n", 18);
            gc19.Caption = string.Concat((new DateTime(Anio, Mes, 19).ToString("dddd")), " \n", 19);
            gc20.Caption = string.Concat((new DateTime(Anio, Mes, 20).ToString("dddd")), " \n", 20);
            gc21.Caption = string.Concat((new DateTime(Anio, Mes, 21).ToString("dddd")), " \n", 21);
            gc22.Caption = string.Concat((new DateTime(Anio, Mes, 22).ToString("dddd")), " \n", 22);
            gc23.Caption = string.Concat((new DateTime(Anio, Mes, 23).ToString("dddd")), " \n", 23);
            gc24.Caption = string.Concat((new DateTime(Anio, Mes, 24).ToString("dddd")), " \n", 24);
            gc25.Caption = string.Concat((new DateTime(Anio, Mes, 25).ToString("dddd")), " \n", 25);
            gc26.Caption = string.Concat((new DateTime(Anio, Mes, 26).ToString("dddd")), " \n", 26);
            gc27.Caption = string.Concat((new DateTime(Anio, Mes, 27).ToString("dddd")), " \n", 27);
            gc28.Caption = string.Concat((new DateTime(Anio, Mes, 28).ToString("dddd")), " \n", 28);

            gvReporte.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcIdTienda,
                 gcDescTienda,
                 gcHora,
                 gcHoraFin,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                });
        }

        private void ConfigurarGrilla29dias()
        {
            gcReporte.ForceInitialize();
            gvReporte.PopulateColumns();

            gvReporte.Columns.Clear();
            gvReporte.SelectAll();
            gvReporte.DeleteSelectedRows();

            gvReporte.OptionsBehavior.Editable = true;
            gvReporte.OptionsCustomization.AllowColumnMoving = true;
            gvReporte.OptionsCustomization.AllowGroup = false;
            gvReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvReporte.OptionsSelection.MultiSelect = true;
            gvReporte.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvReporte.OptionsView.ShowGroupPanel = false;
            gvReporte.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gvReporte.OptionsView.ColumnAutoWidth = false;

            DevExpress.XtraGrid.Columns.GridColumn gcIdTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHora = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHoraFin = new DevExpress.XtraGrid.Columns.GridColumn();

            for (int i = 0; i <= 10; i++)
            {

                DevExpress.XtraGrid.Columns.GridColumn asddsa = new DevExpress.XtraGrid.Columns.GridColumn();

            }
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc29 = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdTienda.Caption = "IdTienda";
            gcIdTienda.FieldName = "IdTienda";
            gcIdTienda.Name = "gcIdTienda";
            gcIdTienda.OptionsColumn.AllowEdit = false;
            gcIdTienda.Visible = false;
            gcIdTienda.VisibleIndex = -1;
            gcIdTienda.Width = 100;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 1;
            gcDescTienda.Width = 200;

            gcHora.Caption = "Cuota Mensual";
            gcHora.FieldName = "CuotaMensual";
            gcHora.Name = "gcCuotaMensual";
            gcHora.OptionsColumn.AllowEdit = false;
            gcHora.Visible = true;
            gcHora.VisibleIndex = 2;
            gcHora.Width = 80;

            gcHoraFin.Caption = "Cuota Diaria";
            gcHoraFin.FieldName = "CuotaDiaria";
            gcHoraFin.Name = "gcCuotaDiaria";
            gcHoraFin.OptionsColumn.AllowEdit = false;
            gcHoraFin.Visible = true;
            gcHoraFin.VisibleIndex = 2;
            gcHoraFin.Width = 80;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 3;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 4;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 5;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 6;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 7;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 8;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 9;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 10;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 11;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 12;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 13;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 14;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 15;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 16;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 17;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 18;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 19;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 20;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 21;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 22;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 23;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 24;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 25;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 26;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 27;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 28;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 29;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 30;
            gc28.Width = 25;

            gc29.Caption = "29";
            gc29.FieldName = "29";
            gc29.Name = "gc29";
            gc29.OptionsColumn.AllowEdit = false;
            gc29.Visible = true;
            gc29.VisibleIndex = 31;
            gc29.Width = 25;

            //Formato para Valor venta
                #region "Formato Valor Venta"
                gc1.DisplayFormat.FormatString = "#,0.00";
                gc1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc2.DisplayFormat.FormatString = "#,0.00";
                gc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc3.DisplayFormat.FormatString = "#,0.00";
                gc3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc4.DisplayFormat.FormatString = "#,0.00";
                gc4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc5.DisplayFormat.FormatString = "#,0.00";
                gc5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc6.DisplayFormat.FormatString = "#,0.00";
                gc6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc7.DisplayFormat.FormatString = "#,0.00";
                gc7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc8.DisplayFormat.FormatString = "#,0.00";
                gc8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc9.DisplayFormat.FormatString = "#,0.00";
                gc9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc10.DisplayFormat.FormatString = "#,0.00";
                gc10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc11.DisplayFormat.FormatString = "#,0.00";
                gc11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc12.DisplayFormat.FormatString = "#,0.00";
                gc12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc13.DisplayFormat.FormatString = "#,0.00";
                gc13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc14.DisplayFormat.FormatString = "#,0.00";
                gc14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc15.DisplayFormat.FormatString = "#,0.00";
                gc15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc16.DisplayFormat.FormatString = "#,0.00";
                gc16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc17.DisplayFormat.FormatString = "#,0.00";
                gc17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc18.DisplayFormat.FormatString = "#,0.00";
                gc18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc19.DisplayFormat.FormatString = "#,0.00";
                gc19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc20.DisplayFormat.FormatString = "#,0.00";
                gc20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc21.DisplayFormat.FormatString = "#,0.00";
                gc21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc22.DisplayFormat.FormatString = "#,0.00";
                gc22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc23.DisplayFormat.FormatString = "#,0.00";
                gc23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc24.DisplayFormat.FormatString = "#,0.00";
                gc24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc25.DisplayFormat.FormatString = "#,0.00";
                gc25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc26.DisplayFormat.FormatString = "#,0.00";
                gc26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc27.DisplayFormat.FormatString = "#,0.00";
                gc27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc28.DisplayFormat.FormatString = "#,0.00";
                gc28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc29.DisplayFormat.FormatString = "#,0.00";
                gc29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc1.Width = 60;
                gc2.Width = 60;
                gc3.Width = 60;
                gc4.Width = 60;
                gc5.Width = 60;
                gc6.Width = 60;
                gc7.Width = 60;
                gc8.Width = 60;
                gc9.Width = 60;
                gc10.Width = 60;
                gc11.Width = 60;
                gc12.Width = 60;
                gc13.Width = 60;
                gc14.Width = 60;
                gc15.Width = 60;
                gc16.Width = 60;
                gc17.Width = 60;
                gc18.Width = 60;
                gc19.Width = 60;
                gc20.Width = 60;
                gc21.Width = 60;
                gc22.Width = 60;
                gc23.Width = 60;
                gc24.Width = 60;
                gc25.Width = 60;
                gc26.Width = 60;
                gc27.Width = 60;
                gc28.Width = 60;
                gc29.Width = 60;
                #endregion

            //Formatear cabecera
            int Anio = Convert.ToInt32(txtPeriodo.EditValue);
            int Mes = Convert.ToInt32(cboMes.EditValue);

            gc1.Caption = string.Concat((new DateTime(Anio, Mes, 1).ToString("dddd")), " \n", 1);
            gc2.Caption = string.Concat((new DateTime(Anio, Mes, 2).ToString("dddd")), " \n", 2);
            gc3.Caption = string.Concat((new DateTime(Anio, Mes, 3).ToString("dddd")), " \n", 3);
            gc4.Caption = string.Concat((new DateTime(Anio, Mes, 4).ToString("dddd")), " \n", 4);
            gc5.Caption = string.Concat((new DateTime(Anio, Mes, 5).ToString("dddd")), " \n", 5);
            gc6.Caption = string.Concat((new DateTime(Anio, Mes, 6).ToString("dddd")), " \n", 6);
            gc7.Caption = string.Concat((new DateTime(Anio, Mes, 7).ToString("dddd")), " \n", 7);
            gc8.Caption = string.Concat((new DateTime(Anio, Mes, 8).ToString("dddd")), " \n", 8);
            gc9.Caption = string.Concat((new DateTime(Anio, Mes, 9).ToString("dddd")), " \n", 9);
            gc10.Caption = string.Concat((new DateTime(Anio, Mes, 10).ToString("dddd")), " \n", 10);
            gc11.Caption = string.Concat((new DateTime(Anio, Mes, 11).ToString("dddd")), " \n", 11);
            gc12.Caption = string.Concat((new DateTime(Anio, Mes, 12).ToString("dddd")), " \n", 12);
            gc13.Caption = string.Concat((new DateTime(Anio, Mes, 13).ToString("dddd")), " \n", 13);
            gc14.Caption = string.Concat((new DateTime(Anio, Mes, 14).ToString("dddd")), " \n", 14);
            gc15.Caption = string.Concat((new DateTime(Anio, Mes, 15).ToString("dddd")), " \n", 15);
            gc16.Caption = string.Concat((new DateTime(Anio, Mes, 16).ToString("dddd")), " \n", 16);
            gc17.Caption = string.Concat((new DateTime(Anio, Mes, 17).ToString("dddd")), " \n", 17);
            gc18.Caption = string.Concat((new DateTime(Anio, Mes, 18).ToString("dddd")), " \n", 18);
            gc19.Caption = string.Concat((new DateTime(Anio, Mes, 19).ToString("dddd")), " \n", 19);
            gc20.Caption = string.Concat((new DateTime(Anio, Mes, 20).ToString("dddd")), " \n", 20);
            gc21.Caption = string.Concat((new DateTime(Anio, Mes, 21).ToString("dddd")), " \n", 21);
            gc22.Caption = string.Concat((new DateTime(Anio, Mes, 22).ToString("dddd")), " \n", 22);
            gc23.Caption = string.Concat((new DateTime(Anio, Mes, 23).ToString("dddd")), " \n", 23);
            gc24.Caption = string.Concat((new DateTime(Anio, Mes, 24).ToString("dddd")), " \n", 24);
            gc25.Caption = string.Concat((new DateTime(Anio, Mes, 25).ToString("dddd")), " \n", 25);
            gc26.Caption = string.Concat((new DateTime(Anio, Mes, 26).ToString("dddd")), " \n", 26);
            gc27.Caption = string.Concat((new DateTime(Anio, Mes, 27).ToString("dddd")), " \n", 27);
            gc28.Caption = string.Concat((new DateTime(Anio, Mes, 28).ToString("dddd")), " \n", 28);
            gc29.Caption = string.Concat((new DateTime(Anio, Mes, 29).ToString("dddd")), " \n", 29);
            
            gvReporte.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcIdTienda,
                 gcDescTienda,
                 gcHora,
                 gcHoraFin,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gc29,
                });
        }

        private void ConfigurarGrilla30dias()
        {
            gcReporte.ForceInitialize();
            gvReporte.PopulateColumns();

            gvReporte.Columns.Clear();
            gvReporte.SelectAll();
            gvReporte.DeleteSelectedRows();

            gvReporte.OptionsBehavior.Editable = true;
            gvReporte.OptionsCustomization.AllowColumnMoving = true;
            gvReporte.OptionsCustomization.AllowGroup = false;
            gvReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvReporte.OptionsSelection.MultiSelect = true;
            gvReporte.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvReporte.OptionsView.ShowGroupPanel = false;
            gvReporte.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gvReporte.OptionsView.ColumnAutoWidth = false;

            DevExpress.XtraGrid.Columns.GridColumn gcIdTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHora = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHoraFin = new DevExpress.XtraGrid.Columns.GridColumn();

            for (int i = 0; i <= 10; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn asddsa = new DevExpress.XtraGrid.Columns.GridColumn();
            }
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc29 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc30 = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdTienda.Caption = "IdTienda";
            gcIdTienda.FieldName = "IdTienda";
            gcIdTienda.Name = "gcIdTienda";
            gcIdTienda.OptionsColumn.AllowEdit = false;
            gcIdTienda.Visible = false;
            gcIdTienda.VisibleIndex = -1;
            gcIdTienda.Width = 100;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 1;
            gcDescTienda.Width = 200;


            gcHora.Caption = "Cuota Mensual";
            gcHora.FieldName = "CuotaMensual";
            gcHora.Name = "gcCuotaMensual";
            gcHora.OptionsColumn.AllowEdit = false;
            gcHora.Visible = true;
            gcHora.VisibleIndex = 2;
            gcHora.Width = 80;            
            
            gcHoraFin.Caption = "Cuota Diaria";
            gcHoraFin.FieldName = "CuotaDiaria";
            gcHoraFin.Name = "gcCuotaDiaria";
            gcHoraFin.OptionsColumn.AllowEdit = false;
            gcHoraFin.Visible = true;
            gcHoraFin.VisibleIndex = 2;
            gcHoraFin.Width = 80;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 3;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 4;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 5;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 6;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 7;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 8;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 9;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 10;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 11;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 12;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 13;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 14;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 15;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 16;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 17;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 18;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 19;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 20;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 21;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 22;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 23;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 24;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 25;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 26;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 27;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 28;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 29;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 30;
            gc28.Width = 25;

            gc29.Caption = "29";
            gc29.FieldName = "29";
            gc29.Name = "gc29";
            gc29.OptionsColumn.AllowEdit = false;
            gc29.Visible = true;
            gc29.VisibleIndex = 31;
            gc29.Width = 25;

            gc30.Caption = "30";
            gc30.FieldName = "30";
            gc30.Name = "gc30";
            gc30.OptionsColumn.AllowEdit = false;
            gc30.Visible = true;
            gc30.VisibleIndex = 32;
            gc30.Width = 25;

            //Formato para Valor venta
            //if (Convert.ToInt32(cboTipoReporte.EditValue) == 2)
            //{
                #region "Formato Valor Venta"
                gc1.DisplayFormat.FormatString = "#,0.00";
                gc1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gc2.DisplayFormat.FormatString = "#,0.00";
                gc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                gc3.DisplayFormat.FormatString = "#,0.00";
                gc3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gc4.DisplayFormat.FormatString = "#,0.00";
                gc4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gc5.DisplayFormat.FormatString = "#,0.00";
                gc5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc6.DisplayFormat.FormatString = "#,0.00";
                gc6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc7.DisplayFormat.FormatString = "#,0.00";
                gc7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc8.DisplayFormat.FormatString = "#,0.00";
                gc8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc9.DisplayFormat.FormatString = "#,0.00";
                gc9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc10.DisplayFormat.FormatString = "#,0.00";
                gc10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc11.DisplayFormat.FormatString = "#,0.00";
                gc11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc12.DisplayFormat.FormatString = "#,0.00";
                gc12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc13.DisplayFormat.FormatString = "#,0.00";
                gc13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc14.DisplayFormat.FormatString = "#,0.00";
                gc14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc15.DisplayFormat.FormatString = "#,0.00";
                gc15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc16.DisplayFormat.FormatString = "#,0.00";
                gc16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc17.DisplayFormat.FormatString = "#,0.00";
                gc17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc18.DisplayFormat.FormatString = "#,0.00";
                gc18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc19.DisplayFormat.FormatString = "#,0.00";
                gc19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc20.DisplayFormat.FormatString = "#,0.00";
                gc20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc21.DisplayFormat.FormatString = "#,0.00";
                gc21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc22.DisplayFormat.FormatString = "#,0.00";
                gc22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc23.DisplayFormat.FormatString = "#,0.00";
                gc23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc24.DisplayFormat.FormatString = "#,0.00";
                gc24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc25.DisplayFormat.FormatString = "#,0.00";
                gc25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc26.DisplayFormat.FormatString = "#,0.00";
                gc26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc27.DisplayFormat.FormatString = "#,0.00";
                gc27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc28.DisplayFormat.FormatString = "#,0.00";
                gc28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc29.DisplayFormat.FormatString = "#,0.00";
                gc29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc30.DisplayFormat.FormatString = "#,0.00";
                gc30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc1.Width = 60;
                gc2.Width = 60;
                gc3.Width = 60;
                gc4.Width = 60;
                gc5.Width = 60;
                gc6.Width = 60;
                gc7.Width = 60;
                gc8.Width = 60;
                gc9.Width = 60;
                gc10.Width = 60;
                gc11.Width = 60;
                gc12.Width = 60;
                gc13.Width = 60;
                gc14.Width = 60;
                gc15.Width = 60;
                gc16.Width = 60;
                gc17.Width = 60;
                gc18.Width = 60;
                gc19.Width = 60;
                gc20.Width = 60;
                gc21.Width = 60;
                gc22.Width = 60;
                gc23.Width = 60;
                gc24.Width = 60;
                gc25.Width = 60;
                gc26.Width = 60;
                gc27.Width = 60;
                gc28.Width = 60;
                gc29.Width = 60;
                gc30.Width = 60;
                #endregion
            //}
            //else
            //{
            //    #region "Sin formato"
            //    gc1.DisplayFormat.FormatString = "";
            //    gc1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc2.DisplayFormat.FormatString = "";
            //    gc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc3.DisplayFormat.FormatString = "";
            //    gc3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc4.DisplayFormat.FormatString = "";
            //    gc4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc5.DisplayFormat.FormatString = "";
            //    gc5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc6.DisplayFormat.FormatString = "";
            //    gc6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc7.DisplayFormat.FormatString = "";
            //    gc7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc8.DisplayFormat.FormatString = "";
            //    gc8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc9.DisplayFormat.FormatString = "";
            //    gc9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc10.DisplayFormat.FormatString = "";
            //    gc10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc11.DisplayFormat.FormatString = "";
            //    gc11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc12.DisplayFormat.FormatString = "";
            //    gc12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc13.DisplayFormat.FormatString = "";
            //    gc13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc14.DisplayFormat.FormatString = "";
            //    gc14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc15.DisplayFormat.FormatString = "";
            //    gc15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc16.DisplayFormat.FormatString = "";
            //    gc16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc17.DisplayFormat.FormatString = "";
            //    gc17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc18.DisplayFormat.FormatString = "";
            //    gc18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc19.DisplayFormat.FormatString = "";
            //    gc19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc20.DisplayFormat.FormatString = "";
            //    gc20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc21.DisplayFormat.FormatString = "";
            //    gc21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc22.DisplayFormat.FormatString = "";
            //    gc22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc23.DisplayFormat.FormatString = "";
            //    gc23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc24.DisplayFormat.FormatString = "";
            //    gc24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc25.DisplayFormat.FormatString = "";
            //    gc25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc26.DisplayFormat.FormatString = "";
            //    gc26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc27.DisplayFormat.FormatString = "";
            //    gc27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc28.DisplayFormat.FormatString = "";
            //    gc28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc29.DisplayFormat.FormatString = "";
            //    gc29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc30.DisplayFormat.FormatString = "";
            //    gc30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    gc1.Width = 30;
            //    gc2.Width = 30;
            //    gc3.Width = 30;
            //    gc4.Width = 30;
            //    gc5.Width = 30;
            //    gc6.Width = 30;
            //    gc7.Width = 30;
            //    gc8.Width = 30;
            //    gc9.Width = 30;
            //    gc10.Width = 30;
            //    gc11.Width = 30;
            //    gc12.Width = 30;
            //    gc13.Width = 30;
            //    gc14.Width = 30;
            //    gc15.Width = 30;
            //    gc16.Width = 30;
            //    gc17.Width = 30;
            //    gc18.Width = 30;
            //    gc19.Width = 30;
            //    gc20.Width = 30;
            //    gc21.Width = 30;
            //    gc22.Width = 30;
            //    gc23.Width = 30;
            //    gc24.Width = 30;
            //    gc25.Width = 30;
            //    gc26.Width = 30;
            //    gc27.Width = 30;
            //    gc28.Width = 30;
            //    gc29.Width = 30;
            //    gc30.Width = 30;

            //    #endregion
            //}

            //Formatear cabecera
            int Anio = Convert.ToInt32(txtPeriodo.EditValue);
            int Mes = Convert.ToInt32(cboMes.EditValue);

            gc1.Caption = string.Concat((new DateTime(Anio, Mes, 1).ToString("dddd")), " \n", 1);
            gc2.Caption = string.Concat((new DateTime(Anio, Mes, 2).ToString("dddd")), " \n", 2);
            gc3.Caption = string.Concat((new DateTime(Anio, Mes, 3).ToString("dddd")), " \n", 3);
            gc4.Caption = string.Concat((new DateTime(Anio, Mes, 4).ToString("dddd")), " \n", 4);
            gc5.Caption = string.Concat((new DateTime(Anio, Mes, 5).ToString("dddd")), " \n", 5);
            gc6.Caption = string.Concat((new DateTime(Anio, Mes, 6).ToString("dddd")), " \n", 6);
            gc7.Caption = string.Concat((new DateTime(Anio, Mes, 7).ToString("dddd")), " \n", 7);
            gc8.Caption = string.Concat((new DateTime(Anio, Mes, 8).ToString("dddd")), " \n", 8);
            gc9.Caption = string.Concat((new DateTime(Anio, Mes, 9).ToString("dddd")), " \n", 9);
            gc10.Caption = string.Concat((new DateTime(Anio, Mes, 10).ToString("dddd")), " \n", 10);
            gc11.Caption = string.Concat((new DateTime(Anio, Mes, 11).ToString("dddd")), " \n", 11);
            gc12.Caption = string.Concat((new DateTime(Anio, Mes, 12).ToString("dddd")), " \n", 12);
            gc13.Caption = string.Concat((new DateTime(Anio, Mes, 13).ToString("dddd")), " \n", 13);
            gc14.Caption = string.Concat((new DateTime(Anio, Mes, 14).ToString("dddd")), " \n", 14);
            gc15.Caption = string.Concat((new DateTime(Anio, Mes, 15).ToString("dddd")), " \n", 15);
            gc16.Caption = string.Concat((new DateTime(Anio, Mes, 16).ToString("dddd")), " \n", 16);
            gc17.Caption = string.Concat((new DateTime(Anio, Mes, 17).ToString("dddd")), " \n", 17);
            gc18.Caption = string.Concat((new DateTime(Anio, Mes, 18).ToString("dddd")), " \n", 18);
            gc19.Caption = string.Concat((new DateTime(Anio, Mes, 19).ToString("dddd")), " \n", 19);
            gc20.Caption = string.Concat((new DateTime(Anio, Mes, 20).ToString("dddd")), " \n", 20);
            gc21.Caption = string.Concat((new DateTime(Anio, Mes, 21).ToString("dddd")), " \n", 21);
            gc22.Caption = string.Concat((new DateTime(Anio, Mes, 22).ToString("dddd")), " \n", 22);
            gc23.Caption = string.Concat((new DateTime(Anio, Mes, 23).ToString("dddd")), " \n", 23);
            gc24.Caption = string.Concat((new DateTime(Anio, Mes, 24).ToString("dddd")), " \n", 24);
            gc25.Caption = string.Concat((new DateTime(Anio, Mes, 25).ToString("dddd")), " \n", 25);
            gc26.Caption = string.Concat((new DateTime(Anio, Mes, 26).ToString("dddd")), " \n", 26);
            gc27.Caption = string.Concat((new DateTime(Anio, Mes, 27).ToString("dddd")), " \n", 27);
            gc28.Caption = string.Concat((new DateTime(Anio, Mes, 28).ToString("dddd")), " \n", 28);
            gc29.Caption = string.Concat((new DateTime(Anio, Mes, 29).ToString("dddd")), " \n", 29);
            gc30.Caption = string.Concat((new DateTime(Anio, Mes, 30).ToString("dddd")), " \n", 30);

            gvReporte.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcIdTienda,
                 gcDescTienda,
                 gcHora,
                 gcHoraFin,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gc29,
                 gc30,
                });
        }

        private void ConfigurarGrilla31dias()
        {
            gcReporte.ForceInitialize();
            gvReporte.PopulateColumns();

            gvReporte.Columns.Clear();
            gvReporte.SelectAll();
            gvReporte.DeleteSelectedRows();

            gvReporte.OptionsBehavior.Editable = true;
            gvReporte.OptionsCustomization.AllowColumnMoving = true;
            gvReporte.OptionsCustomization.AllowGroup = false;
            gvReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvReporte.OptionsSelection.MultiSelect = true;
            gvReporte.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvReporte.OptionsView.ShowGroupPanel = false;
            gvReporte.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gvReporte.OptionsView.ColumnAutoWidth = false;

            DevExpress.XtraGrid.Columns.GridColumn gcIdTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHora = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHoraFin = new DevExpress.XtraGrid.Columns.GridColumn();

            for (int i = 0; i <= 10; i++)
            {

                DevExpress.XtraGrid.Columns.GridColumn asddsa = new DevExpress.XtraGrid.Columns.GridColumn();

            }
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc29 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc30 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc31 = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdTienda.Caption = "IdTienda";
            gcIdTienda.FieldName = "IdTienda";
            gcIdTienda.Name = "gcIdTienda";
            gcIdTienda.OptionsColumn.AllowEdit = false;
            gcIdTienda.Visible = false;
            gcIdTienda.VisibleIndex = -1;
            gcIdTienda.Width = 100;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 1;
            gcDescTienda.Width = 200;

            gcHora.Caption = "Cuota Mensual";
            gcHora.FieldName = "CuotaMensual";
            gcHora.Name = "gcCuotaMensual";
            gcHora.OptionsColumn.AllowEdit = false;
            gcHora.Visible = true;
            gcHora.VisibleIndex = 2;
            gcHora.Width = 80;

            gcHoraFin.Caption = "Cuota Diaria";
            gcHoraFin.FieldName = "CuotaDiaria";
            gcHoraFin.Name = "gcCuotaDiaria";
            gcHoraFin.OptionsColumn.AllowEdit = false;
            gcHoraFin.Visible = true;
            gcHoraFin.VisibleIndex = 2;
            gcHoraFin.Width = 80;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 3;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 4;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 5;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 6;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 7;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 8;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 9;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 10;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 11;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 12;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 13;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 14;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 15;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 16;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 17;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 18;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 19;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 20;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 21;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 22;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 23;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 24;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 25;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 26;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 27;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 28;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 29;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 30;
            gc28.Width = 25;

            gc29.Caption = "29";
            gc29.FieldName = "29";
            gc29.Name = "gc29";
            gc29.OptionsColumn.AllowEdit = false;
            gc29.Visible = true;
            gc29.VisibleIndex = 31;
            gc29.Width = 25;

            gc30.Caption = "30";
            gc30.FieldName = "30";
            gc30.Name = "gc30";
            gc30.OptionsColumn.AllowEdit = false;
            gc30.Visible = true;
            gc30.VisibleIndex = 32;
            gc30.Width = 25;

            gc31.Caption = "31";
            gc31.FieldName = "31";
            gc31.Name = "gc31";
            gc31.OptionsColumn.AllowEdit = false;
            gc31.Visible = true;
            gc31.VisibleIndex = 33;
            gc31.Width = 25;

            //Formato para Valor venta
                #region "Formato Valor Venta"
                gc1.DisplayFormat.FormatString = "#,0.00";
                gc1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc2.DisplayFormat.FormatString = "#,0.00";
                gc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc3.DisplayFormat.FormatString = "#,0.00";
                gc3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc4.DisplayFormat.FormatString = "#,0.00";
                gc4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc5.DisplayFormat.FormatString = "#,0.00";
                gc5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc6.DisplayFormat.FormatString = "#,0.00";
                gc6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc7.DisplayFormat.FormatString = "#,0.00";
                gc7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc8.DisplayFormat.FormatString = "#,0.00";
                gc8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc9.DisplayFormat.FormatString = "#,0.00";
                gc9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc10.DisplayFormat.FormatString = "#,0.00";
                gc10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc11.DisplayFormat.FormatString = "#,0.00";
                gc11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc12.DisplayFormat.FormatString = "#,0.00";
                gc12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc13.DisplayFormat.FormatString = "#,0.00";
                gc13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc14.DisplayFormat.FormatString = "#,0.00";
                gc14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc15.DisplayFormat.FormatString = "#,0.00";
                gc15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc16.DisplayFormat.FormatString = "#,0.00";
                gc16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc17.DisplayFormat.FormatString = "#,0.00";
                gc17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc18.DisplayFormat.FormatString = "#,0.00";
                gc18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc19.DisplayFormat.FormatString = "#,0.00";
                gc19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc20.DisplayFormat.FormatString = "#,0.00";
                gc20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc21.DisplayFormat.FormatString = "#,0.00";
                gc21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc22.DisplayFormat.FormatString = "#,0.00";
                gc22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc23.DisplayFormat.FormatString = "#,0.00";
                gc23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc24.DisplayFormat.FormatString = "#,0.00";
                gc24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc25.DisplayFormat.FormatString = "#,0.00";
                gc25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc26.DisplayFormat.FormatString = "#,0.00";
                gc26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc27.DisplayFormat.FormatString = "#,0.00";
                gc27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc28.DisplayFormat.FormatString = "#,0.00";
                gc28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc29.DisplayFormat.FormatString = "#,0.00";
                gc29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc30.DisplayFormat.FormatString = "#,0.00";
                gc30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc31.DisplayFormat.FormatString = "#,0.00";
                gc31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc1.Width = 60;
                gc2.Width = 60;
                gc3.Width = 60;
                gc4.Width = 60;
                gc5.Width = 60;
                gc6.Width = 60;
                gc7.Width = 60;
                gc8.Width = 60;
                gc9.Width = 60;
                gc10.Width = 60;
                gc11.Width = 60;
                gc12.Width = 60;
                gc13.Width = 60;
                gc14.Width = 60;
                gc15.Width = 60;
                gc16.Width = 60;
                gc17.Width = 60;
                gc18.Width = 60;
                gc19.Width = 60;
                gc20.Width = 60;
                gc21.Width = 60;
                gc22.Width = 60;
                gc23.Width = 60;
                gc24.Width = 60;
                gc25.Width = 60;
                gc26.Width = 60;
                gc27.Width = 60;
                gc28.Width = 60;
                gc29.Width = 60;
                gc30.Width = 60;
                gc31.Width = 60;
                #endregion


            //Formatear cabecera
            int Anio = Convert.ToInt32(txtPeriodo.EditValue);
            int Mes = Convert.ToInt32(cboMes.EditValue);

            gc1.Caption = string.Concat((new DateTime(Anio, Mes, 1).ToString("dddd")), " \n", 1);
            gc2.Caption = string.Concat((new DateTime(Anio, Mes, 2).ToString("dddd")), " \n", 2);
            gc3.Caption = string.Concat((new DateTime(Anio, Mes, 3).ToString("dddd")), " \n", 3);
            gc4.Caption = string.Concat((new DateTime(Anio, Mes, 4).ToString("dddd")), " \n", 4);
            gc5.Caption = string.Concat((new DateTime(Anio, Mes, 5).ToString("dddd")), " \n", 5);
            gc6.Caption = string.Concat((new DateTime(Anio, Mes, 6).ToString("dddd")), " \n", 6);
            gc7.Caption = string.Concat((new DateTime(Anio, Mes, 7).ToString("dddd")), " \n", 7);
            gc8.Caption = string.Concat((new DateTime(Anio, Mes, 8).ToString("dddd")), " \n", 8);
            gc9.Caption = string.Concat((new DateTime(Anio, Mes, 9).ToString("dddd")), " \n", 9);
            gc10.Caption = string.Concat((new DateTime(Anio, Mes, 10).ToString("dddd")), " \n", 10);
            gc11.Caption = string.Concat((new DateTime(Anio, Mes, 11).ToString("dddd")), " \n", 11);
            gc12.Caption = string.Concat((new DateTime(Anio, Mes, 12).ToString("dddd")), " \n", 12);
            gc13.Caption = string.Concat((new DateTime(Anio, Mes, 13).ToString("dddd")), " \n", 13);
            gc14.Caption = string.Concat((new DateTime(Anio, Mes, 14).ToString("dddd")), " \n", 14);
            gc15.Caption = string.Concat((new DateTime(Anio, Mes, 15).ToString("dddd")), " \n", 15);
            gc16.Caption = string.Concat((new DateTime(Anio, Mes, 16).ToString("dddd")), " \n", 16);
            gc17.Caption = string.Concat((new DateTime(Anio, Mes, 17).ToString("dddd")), " \n", 17);
            gc18.Caption = string.Concat((new DateTime(Anio, Mes, 18).ToString("dddd")), " \n", 18);
            gc19.Caption = string.Concat((new DateTime(Anio, Mes, 19).ToString("dddd")), " \n", 19);
            gc20.Caption = string.Concat((new DateTime(Anio, Mes, 20).ToString("dddd")), " \n", 20);
            gc21.Caption = string.Concat((new DateTime(Anio, Mes, 21).ToString("dddd")), " \n", 21);
            gc22.Caption = string.Concat((new DateTime(Anio, Mes, 22).ToString("dddd")), " \n", 22);
            gc23.Caption = string.Concat((new DateTime(Anio, Mes, 23).ToString("dddd")), " \n", 23);
            gc24.Caption = string.Concat((new DateTime(Anio, Mes, 24).ToString("dddd")), " \n", 24);
            gc25.Caption = string.Concat((new DateTime(Anio, Mes, 25).ToString("dddd")), " \n", 25);
            gc26.Caption = string.Concat((new DateTime(Anio, Mes, 26).ToString("dddd")), " \n", 26);
            gc27.Caption = string.Concat((new DateTime(Anio, Mes, 27).ToString("dddd")), " \n", 27);
            gc28.Caption = string.Concat((new DateTime(Anio, Mes, 28).ToString("dddd")), " \n", 28);
            gc29.Caption = string.Concat((new DateTime(Anio, Mes, 29).ToString("dddd")), " \n", 29);
            gc30.Caption = string.Concat((new DateTime(Anio, Mes, 30).ToString("dddd")), " \n", 30);
            gc31.Caption = string.Concat((new DateTime(Anio, Mes, 31).ToString("dddd")), " \n", 31);

            gvReporte.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcIdTienda,
                 gcDescTienda,
                 gcHora,
                 gcHoraFin,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gc29,
                 gc30,
                 gc31
                });
        }

        private void ConfigurarGrillaResumen()
        {
            gcReporte.ForceInitialize();
            gvReporte.PopulateColumns();

            gvReporte.Columns.Clear();
            gvReporte.SelectAll();
            gvReporte.DeleteSelectedRows();

            gvReporte.OptionsBehavior.Editable = true;
            gvReporte.OptionsCustomization.AllowColumnMoving = true;
            gvReporte.OptionsCustomization.AllowGroup = false;
            gvReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvReporte.OptionsSelection.MultiSelect = true;
            gvReporte.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvReporte.OptionsView.ShowGroupPanel = false;
            gvReporte.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gvReporte.OptionsView.ColumnAutoWidth = false;

            DevExpress.XtraGrid.Columns.GridColumn gcIdTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHora = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcHoraFin = new DevExpress.XtraGrid.Columns.GridColumn();

            for (int i = 0; i <= 10; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn asddsa = new DevExpress.XtraGrid.Columns.GridColumn();
            }
            DevExpress.XtraGrid.Columns.GridColumn gcLunes = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcMartes = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcMiercoles = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcJueves = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcViernes = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcSabado = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDomingo = new DevExpress.XtraGrid.Columns.GridColumn();

            gcIdTienda.Caption = "IdTienda";
            gcIdTienda.FieldName = "IdTienda";
            gcIdTienda.Name = "gcIdTienda";
            gcIdTienda.OptionsColumn.AllowEdit = false;
            gcIdTienda.Visible = false;
            gcIdTienda.VisibleIndex = -1;
            gcIdTienda.Width = 100;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 1;
            gcDescTienda.Width = 100;

            gcHora.Caption = "Hora Inicio";
            gcHora.FieldName = "Hora";
            gcHora.Name = "gcHora";
            gcHora.OptionsColumn.AllowEdit = false;
            gcHora.Visible = true;
            gcHora.VisibleIndex = 2;
            gcHora.Width = 60;

            gcHoraFin.Caption = "Hora Fin";
            gcHoraFin.FieldName = "HoraFin";
            gcHoraFin.Name = "gcHoraFin";
            gcHoraFin.OptionsColumn.AllowEdit = false;
            gcHoraFin.Visible = true;
            gcHoraFin.VisibleIndex = 2;
            gcHoraFin.Width = 60;

            gcLunes.Caption = "Lunes";
            gcLunes.FieldName = "Lunes";
            gcLunes.Name = "gcLunes";
            gcLunes.OptionsColumn.AllowEdit = false;
            gcLunes.Visible = true;
            gcLunes.VisibleIndex = 3;
            gcLunes.Width = 80;

            gcMartes.Caption = "Martes";
            gcMartes.FieldName = "Martes";
            gcMartes.Name = "gcMartes";
            gcMartes.OptionsColumn.AllowEdit = false;
            gcMartes.Visible = true;
            gcMartes.VisibleIndex = 4;
            gcMartes.Width = 80;

            gcMiercoles.Caption = "Miercoles";
            gcMiercoles.FieldName = "Miercoles";
            gcMiercoles.Name = "gcMiercoles";
            gcMiercoles.OptionsColumn.AllowEdit = false;
            gcMiercoles.Visible = true;
            gcMiercoles.VisibleIndex = 5;
            gcMiercoles.Width = 80;

            gcJueves.Caption = "Jueves";
            gcJueves.FieldName = "Jueves";
            gcJueves.Name = "gcJueves";
            gcJueves.OptionsColumn.AllowEdit = false;
            gcJueves.Visible = true;
            gcJueves.VisibleIndex = 6;
            gcJueves.Width = 80;

            gcViernes.Caption = "Viernes";
            gcViernes.FieldName = "Viernes";
            gcViernes.Name = "gcViernes";
            gcViernes.OptionsColumn.AllowEdit = false;
            gcViernes.Visible = true;
            gcViernes.VisibleIndex = 7;
            gcViernes.Width = 80;

            gcSabado.Caption = "Sabado";
            gcSabado.FieldName = "Sabado";
            gcSabado.Name = "gcSabado";
            gcSabado.OptionsColumn.AllowEdit = false;
            gcSabado.Visible = true;
            gcSabado.VisibleIndex = 8;
            gcSabado.Width = 80;

            gcDomingo.Caption = "Domingo";
            gcDomingo.FieldName = "Domingo";
            gcDomingo.Name = "gcDomingo";
            gcDomingo.OptionsColumn.AllowEdit = false;
            gcDomingo.Visible = true;
            gcDomingo.VisibleIndex = 9;
            gcDomingo.Width = 80;

            //Formato para Valor venta
            if (Convert.ToInt32(cboTipoReporte.EditValue) == 2)
            {
                #region "Formato Valor Venta"
                gcLunes.DisplayFormat.FormatString = "#,0.00";
                gcLunes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcMartes.DisplayFormat.FormatString = "#,0.00";
                gcMartes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcMiercoles.DisplayFormat.FormatString = "#,0.00";
                gcMiercoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcJueves.DisplayFormat.FormatString = "#,0.00";
                gcJueves.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcViernes.DisplayFormat.FormatString = "#,0.00";
                gcViernes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcSabado.DisplayFormat.FormatString = "#,0.00";
                gcSabado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcDomingo.DisplayFormat.FormatString = "#,0.00";
                gcDomingo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                #endregion
            }
            else
            {
                #region "Sin formato"
                gcLunes.DisplayFormat.FormatString = "";
                gcLunes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                gcMartes.DisplayFormat.FormatString = "";
                gcMartes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                gcMiercoles.DisplayFormat.FormatString = "";
                gcMiercoles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                gcJueves.DisplayFormat.FormatString = "";
                gcJueves.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                gcViernes.DisplayFormat.FormatString = "";
                gcViernes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                gcSabado.DisplayFormat.FormatString = "";
                gcSabado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                gcDomingo.DisplayFormat.FormatString = "";
                gcDomingo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                #endregion
            }

            gvReporte.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcIdTienda,
                 gcDescTienda,
                 gcHora,
                 gcHoraFin,
                 gcLunes,
                 gcMartes,
                 gcMiercoles,
                 gcJueves,
                 gcViernes,
                 gcSabado,
                 gcDomingo,
                });
        }

        private DataTable CargarTipoReporte()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "Cantidad de Tickets por Hora";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "Valor de Venta por Hora";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "Cantidad de Ingreso de Clientes por Hora";
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable CargarTipoResumen()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "PROMEDIO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "SUMA";
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable CargarTienda()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "UCAYALI";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "ANDAHUAYLAS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "PRESCOTT";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 17;
            dr["Descripcion"] = "AVIACION2";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "MEGAPLAZA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 19;
            dr["Descripcion"] = "SAN MIGUEL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "<TODAS>";
            dt.Rows.Add(dr);

            return dt;
        }

        private void CargarGrilla()
        {
            if (chkResumen.Checked)
                ConfigurarGrillaResumen();
            else
            {
                switch (Convert.ToInt32(cboMes.EditValue))
                {
                    case 2:
                        if (Convert.ToInt32(txtPeriodo.EditValue) % 4 == 0 && Convert.ToInt32(txtPeriodo.EditValue) % 100 != 0 || Convert.ToInt32(txtPeriodo.EditValue) % 400 == 0) //Bisiesto
                            ConfigurarGrilla29dias();
                        else
                            ConfigurarGrilla28dias();
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        ConfigurarGrilla30dias();
                        break;
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        ConfigurarGrilla31dias();
                        break;
                }
            }
                
        }

        #endregion

        private void chkResumen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResumen.Checked)
                cboTipoOperacion.Visible = true;
            else
                cboTipoOperacion.Visible = false;

            CargarGrilla();
        }

        private void gvReporte_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvReporte.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["DescTienda"]);
                    if (objDocRetiro != null)
                    {
                        string Glosa = (objDocRetiro.ToString());
                        if (Glosa == "TOTAL GENERAL S/")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            e.Appearance.BackColor = Color.Yellow; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightYellow; //Aprobado
                            e.Appearance.ForeColor = Color.Black;
                            //  e.Appearance.Font =  Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.Red; //Aprobado
                        }
                        if (Glosa == "TOTAL MAYORISTA S/" || Glosa == "TOTAL ECOMMERCE S/" || Glosa == "TOTAL RETAIL S/")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.ForeColor = Color.Red;
                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightGreen; //Aprobado
                            //  e.Appearance.Font =  Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.Red; //Aprobado
                        }

                        

                        if (Glosa == "UTILIDAD BRUTA")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;                            
                            e.Appearance.BackColor = Color.Yellow; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightYellow; //Aprobado
                            e.Appearance.ForeColor = Color.Black;
                        }

                        //if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}

                        //if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Promoción 2x1 o 3x2
            List<Promocion2x1BE> lst_Promocion = new List<Promocion2x1BE>();
            lst_Promocion = new Promocion2x1BL().ListaVigente(Parametros.intEmpresaId);

            foreach (var item in lst_Promocion)
            {
                string FormaPago = "";
                string TipoCliente = "";
                if (item.FlagContado) FormaPago += "Contado ";
                if (item.FlagContraentrega) FormaPago += "Contraentrega ";
                if (item.FlagCopagan) FormaPago += "Copagan ";
                if (item.FlagSeparacion) FormaPago += "Separación ";
                if (item.FlagCredito) FormaPago += "Crédito ";
                if (item.FlagClienteFinal) TipoCliente += "C.Final ";
                if (item.FlagClienteMayorista) TipoCliente += "C.Mayorista ";

                alertControl1.Show(this, "PROMOCIÓN " + item.Tipo, "Del " + item.FechaInicio.ToShortDateString().ToString() + " Al " + item.FechaFin.ToShortDateString().ToString() + " para " + TipoCliente + " " + FormaPago + ".");

                //Promociones activas
                if (item.Tipo == "2x1") Parametros.bPromocion2x1 = true;
                if (item.Tipo == "3x2") Parametros.bPromocion3x2 = true;
                if (item.Tipo == "3x1") Parametros.bPromocion3x1 = true;
                if (item.Tipo == "4x1") Parametros.bPromocion4x1 = true;

            }
        }
    }
}