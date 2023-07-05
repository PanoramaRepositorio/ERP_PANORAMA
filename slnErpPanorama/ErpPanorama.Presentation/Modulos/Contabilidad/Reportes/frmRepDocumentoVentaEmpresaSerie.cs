using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Reportes
{
    public partial class frmRepDocumentoVentaEmpresaSerie : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private int IdCliente = 0;
        private int IdTipoDocumento = 0;
        private string Serie = "0";
        private int IdEmpresa = 0;
        private string TipoDocumento = string.Empty;
        private string Simbolo = ">";
        private decimal Valor = 0;

        #endregion

        #region "Eventos"

        public frmRepDocumentoVentaEmpresaSerie()
        {
            InitializeComponent();
        }

        private void frmRepDocumentoVentaEmpresaSerie_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            cboDocumento.EditValue = Parametros.intTipoDocBoletaVenta;
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
        }

        private void deFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                ValidarCheckTipoDocumento();

                if (rdbSerie.Checked == true)
                {
                    List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaEmpresaSerieBL().ListadoSerieResumen(IdEmpresa, IdTipoDocumento,Serie, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptDocumentoVentaEmpresaSerie(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (rdbEmpresa.Checked == true)
                {
                    List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte = null;
                    lstReporte = new ReporteDocumentoVentaEmpresaSerieBL().ListadoTipoDocumento(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptDocumentoVentaEmpresaSerie(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 2);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                }
                else if (rdbFecha.Checked == true)
                {
                        List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte = null;
                        lstReporte = new ReporteDocumentoVentaEmpresaSerieBL().Listado(IdEmpresa, IdTipoDocumento, Serie, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptDocumentoVentaEmpresaSerie(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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


        #endregion

        #region "Metodos"

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


        #endregion


    }
}