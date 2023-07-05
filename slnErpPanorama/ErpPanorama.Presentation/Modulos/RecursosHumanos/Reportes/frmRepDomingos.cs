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
    public partial class frmRepDomingos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepDomingos()
        {
            InitializeComponent();
        }

        private void frmRepDomingos_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            //BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPago), "DescTablaElemento", "IdTablaElemento", true);

            deFechaHasta.Focus();
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
                    List<ReportePersonaTrabajoBE> lstReporte = null;
                    lstReporte = new ReportePersonaTrabajoBL().ListadoFecha(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0, 1);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptPersonaTrabajo = new RptVistaReportes();
                            objRptPersonaTrabajo.VerRptPersonaTrabajoFecha(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),1);
                            objRptPersonaTrabajo.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.WaitCursor;

                    List<ReportePersonaTrabajoBE> lstReporte = null;
                    lstReporte = new ReportePersonaTrabajoBL().ListadoFecha( Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0,0);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptPersonaTrabajo = new RptVistaReportes();
                            objRptPersonaTrabajo.VerRptPersonaTrabajoFecha(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),0);
                            objRptPersonaTrabajo.ShowDialog();
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
    }
}