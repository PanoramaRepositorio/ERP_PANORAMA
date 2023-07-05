using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Reportes
{
    public partial class frmRepComisionJProduccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"
        public frmRepComisionJProduccion()
        {
            InitializeComponent();
        }

        private void frmRepComisionJProduccion_Load(object sender, EventArgs e)
        {
            //deFechaDesde.EditValue = DateTime.Now;
            //deFechaHasta.EditValue = DateTime.Now;

            //BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPago), "DescTablaElemento", "IdTablaElemento", true);
            txtAnio.EditValue = DateTime.Now.Date.Year;
            deFechaHasta.Focus();



            deFechaDesde.EditValue = new DateTime(Convert.ToInt32(txtAnio.EditValue), DateTime.Now.Month, 1);
            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(txtAnio.EditValue), DateTime.Now.Month) + "/" + Convert.ToInt32(DateTime.Now.Month) + "/" + (Convert.ToInt32(txtAnio.EditValue)) );

            cboMes.EditValue = DateTime.Now.Month;                                                                                                                                                                                 //deFechaHasta.EditValue = DateTime.Now;
            cboMes.Focus();
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

                if (chkResumen.Checked)
                {
                    List<ReporteHoraExtraBE> lstReporte = null;
                    lstReporte = new ReporteHoraExtraBL().ListadoResumen(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0, 1);
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptHoraExtra = new RptVistaReportes();
                            objRptHoraExtra.VerRptHoraExtraFecha(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 1);
                            objRptHoraExtra.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.WaitCursor;

                    List<ReporteComisionJefeProduccionBE> lstReporte = null;
                    lstReporte = new ReporteComisionJefeProduccionBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptComisionJP = new RptVistaReportes();
                            objRptComisionJP.VerRptComisionFecha(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
                            objRptComisionJP.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
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


        #endregion

        #region "Metodos"

        #endregion

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {


            deFechaDesde.EditValue = new DateTime(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue), 1);

            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + (Convert.ToInt32(txtAnio.EditValue)));

        }

        private void txtAnio_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                deFechaDesde.EditValue = new DateTime(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue), 1);

                deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + Convert.ToInt32(txtAnio.EditValue));   //(Parametros.intPeriodo)
            }
            catch
            {
            }
        }
    }
}