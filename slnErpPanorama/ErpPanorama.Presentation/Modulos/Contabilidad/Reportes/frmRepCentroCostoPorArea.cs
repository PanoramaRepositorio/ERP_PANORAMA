using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Reportes
{
    public partial class frmRepCentroCostoPorArea : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<ReporteCentroCostoPorAreaBE> mLista = new List<ReporteCentroCostoPorAreaBE>();
        List<ReporteCentroCostoPorAreaBE> mListaGrafico = new List<ReporteCentroCostoPorAreaBE>();
        public int intValorInicial = 0;

        #endregion

        #region "Eventos"

        public frmRepCentroCostoPorArea()
        {
            InitializeComponent();
        }

        private void frmRepCentroCostoPorArea_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            BSUtils.LoaderLook(cboPeriodo, CargarPeriodo(), "Descripcion", "Id", false);
            cboPeriodo.EditValue = DateTime.Now.Year;
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = DateTime.Now.Month; ;
            BSUtils.LoaderLook(cboTipoReporte, CargarTipoReporte(), "Descripcion", "Id", false);
            cboTipoReporte.EditValue = 2;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;

            intValorInicial = 1;
            btnConsultar_Click(sender, e);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
            if (gvReporte.RowCount > 0)
            {
                CargarGrafico();
            }
            else
            {
                pieChart.DataSource = null;
                pieChart.Series.Clear();
                pieChart.Titles.Clear();
            }
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (gvReporte.RowCount > 0)
            {
                CargarGrafico();
            }
        }

        private void cboMes_EditValueChanged(object sender, EventArgs e)
        {
            if (intValorInicial > 0)
                btnConsultar_Click(sender, e);
        }

        private void cboPeriodo_EditValueChanged(object sender, EventArgs e)
        {
            if (intValorInicial > 0)
                btnConsultar_Click(sender, e);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            pieChart.ShowRibbonPrintPreview();
        }

        private void imprimirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvReporte.ShowRibbonPrintPreview();
        }

        private void cboTipoReporte_EditValueChanged(object sender, EventArgs e)
        {
            if (intValorInicial > 0)
                btnConsultar_Click(sender, e);
        }

        #endregion

        #region "Metodos"

        private void CargarGrafico()
        {
            pieChart.DataSource = null;
            pieChart.Series.Clear();
            pieChart.Titles.Clear();

            string DescMes = mLista[0].NombreMes + " " + mLista[0].Periodo;
            pieChart.Titles.Add(new ChartTitle() { Text = "Gastos por Area - " + DescMes });

            // Create a pie series.
            Series series1 = new Series("Gastos por Area - " + DescMes, ViewType.Pie);

            // Bind the series to data.
            //series1.DataSource = DataPoint.GetDataPoints();
            series1.DataSource = mListaGrafico;
            series1.ArgumentDataMember = "DescGrupo";
            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                series1.ValueDataMembers.AddRange(new string[] { "DebeMN" });
            else
                series1.ValueDataMembers.AddRange(new string[] { "DebeUS" });

            // Add the series to the chart.
            pieChart.Series.Add(series1);

            // Format the the series labels.
            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                series1.Label.TextPattern = "{VP:p0} (S/ {V:##,##.##})";
            else
                series1.Label.TextPattern = "{VP:p0} ($ {V:##,##.##})";
            // Format the series legend items.
            series1.LegendTextPattern = "{A}";

            // Adjust the position of series labels. 
            ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels.
            ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)series1.View;

            // Specify a data filter to explode points.
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;

            // Customize the legend.
            pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            //// Add the chart to the form.
            //pieChart.Dock = DockStyle.Fill;
            //this.Controls.Add(pieChart);
        }

        private void Cargar()
        {
            int TipoReporte = Convert.ToInt32(cboTipoReporte.EditValue);
            mLista = new ReporteCentroCostoPorAreaBL().Listado(Convert.ToInt32(cboPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), TipoReporte);
            gcReporte.DataSource = mLista;

            if (TipoReporte == 2)
                mListaGrafico = mLista;
            else
                mListaGrafico = new ReporteCentroCostoPorAreaBL().Listado(Convert.ToInt32(cboPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), 2);

            if (TipoReporte == 0)
            {
                gcCodGrupo.Visible = true;
                gcCodCuenta.Visible = true;
                gcDescCuenta.Visible = true;

                gcMes.VisibleIndex = 1;
                gcCodGrupo.VisibleIndex = 2;
                gcDescGrupo.VisibleIndex = 3;
                gcDebeUS.VisibleIndex = 4;
                gcDebeMN.VisibleIndex = 5;
                gcCodCuenta.VisibleIndex = 6;
                gcDescCuenta.VisibleIndex = 7;

                splitContainerControl1.SplitterPosition = 770;
            }
            else if (TipoReporte == 1)
            {
                gcCodGrupo.Visible = true;
                gcCodCuenta.Visible = false;
                gcDescCuenta.Visible = false;

                gcMes.VisibleIndex = 1;
                gcCodGrupo.VisibleIndex = 2;
                gcDescGrupo.VisibleIndex = 3;
                gcDebeUS.VisibleIndex = 4;
                gcDebeMN.VisibleIndex = 5;
                //gcCodCuenta.VisibleIndex = 6;
                //gcDescCuenta.VisibleIndex = 7;

                splitContainerControl1.SplitterPosition = 465;
            }
            else if (TipoReporte == 2)
            {
                gcCodGrupo.Visible = false;
                gcCodCuenta.Visible = false;
                gcDescCuenta.Visible = false;

                gcMes.VisibleIndex = 1;
                //gcCodGrupo.VisibleIndex = 2;
                gcDescGrupo.VisibleIndex = 3;
                gcDebeUS.VisibleIndex = 4;
                gcDebeMN.VisibleIndex = 5;
                //gcCodCuenta.VisibleIndex = 6;
                //gcDescCuenta.VisibleIndex = 7;

                splitContainerControl1.SplitterPosition = 395;
            }

        }

        private DataTable CargarPeriodo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            for (int i=2016; i<=DateTime.Now.Year; i++)
            {
                dr = dt.NewRow();
                dr["Id"] = i;
                dr["Descripcion"] = i;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "1";
            dr["Descripcion"] = "enero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "2";
            dr["Descripcion"] = "febrero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "3";
            dr["Descripcion"] = "marzo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "4";
            dr["Descripcion"] = "abril";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "5";
            dr["Descripcion"] = "mayo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "6";
            dr["Descripcion"] = "junio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "7";
            dr["Descripcion"] = "julio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "8";
            dr["Descripcion"] = "agosto";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "9";
            dr["Descripcion"] = "septiembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "10";
            dr["Descripcion"] = "octubre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "11";
            dr["Descripcion"] = "noviembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "12";
            dr["Descripcion"] = "diciembre";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarTipoReporte()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "0";
            dr["Descripcion"] = "Cuenta-C.Costo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "1";
            dr["Descripcion"] = "C.Costo Detalle";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "2";
            dr["Descripcion"] = "C.Costo Resumen";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            return dt;
        }
        #endregion


    }
}