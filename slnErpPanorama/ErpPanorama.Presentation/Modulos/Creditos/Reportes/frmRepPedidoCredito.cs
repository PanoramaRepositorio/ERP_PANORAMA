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
    public partial class frmRepPedidoCredito : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepPedidoCredito()
        {
            InitializeComponent();
        }

        private void frmRepPedidoCredito_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReportePedidoCreditoBE> lstReporte = null;
                lstReporte = new ReportePedidoCreditoBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCredito = new RptVistaReportes();
                        objRptCredito.VerRptPedidoCredito(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                        objRptCredito.Show();
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