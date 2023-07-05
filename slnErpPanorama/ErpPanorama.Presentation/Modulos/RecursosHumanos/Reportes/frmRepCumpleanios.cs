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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Reportes
{
    public partial class frmRepCumpleanios : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRepCumpleanios()
        {
            InitializeComponent();
        }

        private void frmRepCumpleanios_Load(object sender, EventArgs e)
        {
            cboMes.EditValue = DateTime.Now.Month;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteCumpleaniosBE> lstReporte = null;
                lstReporte = new ReporteCumpleaniosBL().Listado(Convert.ToInt32(cboMes.EditValue), chkApoyo.Checked);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptCumpleanos(lstReporte, cboMes.Text);
                        objRptKardexBulto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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