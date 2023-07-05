using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    public partial class frmConVentasEmpresaSerie : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteDocumentoVentaEmpresaSerieBE> mLista = new List<ReporteDocumentoVentaEmpresaSerieBE>();

        private int IdCliente = 0;
        private int IdTipoDocumento = 0;
        private string Serie = "0";
        private int IdEmpresa = 0;
        private string TipoDocumento = string.Empty;
        private string Simbolo = ">";
        private decimal Valor = 0;

        #endregion

        #region "Eventos"
        public frmConVentasEmpresaSerie()
        {
            InitializeComponent();
        }

        private void frmConVentasEmpresaSerie_Load(object sender, EventArgs e)
        {
            //Cargar();
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            cboDocumento.EditValue = Parametros.intTipoDocBoletaVenta;
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaRegistroVentasSerie";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumentoVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolStripImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                ValidarCheckTipoDocumento();

                if (rdbSerie.Checked == true)
                {
                    List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaEmpresaSerieBL().ListadoSerieResumen(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptDocumentoVentaEmpresaSerie(lstReporte, deDesde.DateTime.ToShortDateString(), deHasta.DateTime.ToShortDateString(), 1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (rdbEmpresa.Checked == true)
                {
                    List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaEmpresaSerieBL().ListadoTipoDocumento(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptDocumentoVentaEmpresaSerie(lstReporte, deDesde.DateTime.ToShortDateString(), deHasta.DateTime.ToShortDateString(), 2);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (rdbFecha.Checked == true)
                {
                    List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaEmpresaSerieBL().Listado(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptDocumentoVentaEmpresaSerie(lstReporte, deDesde.DateTime.ToShortDateString(), deHasta.DateTime.ToShortDateString(), 0);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkEmpresaTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmpresaTodo.Checked == true)
            {
                cboEmpresa.Enabled = false;
            }
            else
            {
                cboEmpresa.Enabled = true;
            }
        }

        private void chkDocummentoTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDocumentoTodo.Checked == true)
            {
                cboDocumento.Enabled = false;
            }
            else
            {
                cboDocumento.Enabled = true;
            }
        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo), "Serie", "Serie", true);
        }

        private void chkSerieTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSerieTodo.Checked == true)
            {
                cboSerie.Enabled = false;
            }
            else
            {
                cboSerie.Enabled = true;
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo), "Serie", "Serie", true);
        }

        private void gvDocumentoVenta_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                ValidarCheckTipoDocumento();

                gvDocumentoVenta.Columns["Fecha"].VisibleIndex = 1;
                gvDocumentoVenta.Columns["Serie"].VisibleIndex = 3;
                gvDocumentoVenta.Columns["Inicio"].VisibleIndex = 4;
                gvDocumentoVenta.Columns["Fin"].VisibleIndex = 5;

                if (rdbSerie.Checked == true)
                {
                    mLista = new ReporteDocumentoVentaEmpresaSerieBL().ListadoSerieResumen(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                    gcDocumentoVenta.DataSource = mLista;
                    gvDocumentoVenta.Columns[1].Visible = false;
                    gvDocumentoVenta.Columns[3].Visible = true;
                    gvDocumentoVenta.Columns[4].Visible = true;
                    gvDocumentoVenta.Columns[5].Visible = true;
                }
                else if (rdbEmpresa.Checked == true)
                {
                    mLista = new ReporteDocumentoVentaEmpresaSerieBL().ListadoTipoDocumento(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                    gcDocumentoVenta.DataSource = mLista;
                    gvDocumentoVenta.Columns[1].Visible = false;
                    gvDocumentoVenta.Columns[3].Visible = false;
                    gvDocumentoVenta.Columns[4].Visible = false;
                    gvDocumentoVenta.Columns[5].Visible = false;
                }
                else if (rdbFecha.Checked == true)
                {
                    mLista = new ReporteDocumentoVentaEmpresaSerieBL().Listado(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                    gcDocumentoVenta.DataSource = mLista;
                    gvDocumentoVenta.Columns[1].Visible = true;
                    gvDocumentoVenta.Columns[3].Visible = true;
                    gvDocumentoVenta.Columns[4].Visible = true;
                    gvDocumentoVenta.Columns[5].Visible = true;


                }

                CalcularTotalDocumentos();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "BOV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 26;
            dr["Descripcion"] = "FAV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 90;
            dr["Descripcion"] = "TKV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 91;
            dr["Descripcion"] = "TKF";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 36;
            dr["Descripcion"] = "NCV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 97;
            dr["Descripcion"] = "FAT";
            dt.Rows.Add(dr);
            return dt;
        }

        private void ValidarCheckTipoDocumento()
        {
            //empresa
            if (chkEmpresaTodo.Checked == true)
            {
                cboEmpresa.Enabled = false;
                IdEmpresa = 0;
            }
            else
            {
                cboEmpresa.Enabled = true;
                IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            }

            //Documento
            if (chkDocumentoTodo.Checked == true)
            {
                cboDocumento.Enabled = false;
                IdTipoDocumento = 0;
            }
            else
            {
                cboDocumento.Enabled = true;
                IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
            }


            //Serie
            if (chkSerieTodo.Checked == true)
            {
                cboSerie.Enabled = false;
                Serie = "0";
            }
            else
            {
                cboSerie.Enabled = true;
                //Serie = cboSerie.Text;
                Serie = FuncionBase.AgregarCaracter(cboSerie.Text, "0", 3);
            }

            //


        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                decimal decIGV = 0;
                decimal decBaseImponible = 0;

                for (int i = 0; i < gvDocumentoVenta.RowCount; i++)
                {
                    decBaseImponible = decBaseImponible + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["BaseImponible"])));
                    decIGV = decIGV + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["IGV"])));
                    decTotal = decTotal + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["TotalSoles"])));
                }
                txtBaseImponible.EditValue = decBaseImponible;
                txtIGV.EditValue = decIGV;
                txtTotal.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       #endregion


    }
}