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

namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    public partial class frmRepCreditoTotal : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepCreditoTotal()
        {
            InitializeComponent();
        }

        private void frmRepCreditoTotal_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                Int32 Orden = 1;
                if (optRazonSocial.Checked == true)
                    Orden = 3;
                else
                    Orden = 4;

                string OrdenTipo = "ASC";
                if (optAscendente.Checked == true)
                    OrdenTipo = "ASC";
                else
                    OrdenTipo = "DESC";


                List<ReporteCreditoTotalBE> lstReporte = null;
                lstReporte = new ReporteCreditoTotalBL().Listado(Convert.ToInt32(txtPeriodo.EditValue), Orden, OrdenTipo);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCreditoTotal = new RptVistaReportes();
                        objRptCreditoTotal.VerRptCreditoTotal(lstReporte);
                        objRptCreditoTotal.Show();
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