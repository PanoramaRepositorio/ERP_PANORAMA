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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    public partial class frmRepProductividadOperador : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"


        public frmRepProductividadOperador()
        {
            InitializeComponent();
        }

        private void frmRepProductividadOperador_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (optResumen.Checked)
                {
                    List<ReporteProductividadOperadorResumenBE> lstReporte = null;
                    lstReporte = new ReporteProductividadOperadorResumenBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            List<ReporteBultoTranferidoOperadorBE> lstReporteBulto = null;
                            lstReporteBulto = new ReporteBultoTranferidoOperadorBL().Listado(Parametros.intEmpresaId,0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptProductividadOperadorResumen(lstReporte, lstReporteBulto, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if(optDetalleH.Checked)
                {
                    List<ReporteProductividadOperadorBE> lstReporte = null;
                    lstReporte = new ReporteProductividadOperadorBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptProductividadOperador(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    List<ReporteProductividadOperadorVBE> lstReporte = null;
                    lstReporte = new ReporteProductividadOperadorVBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptProductividadOperadorV(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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


        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        #endregion

        #region "Metodos"

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}