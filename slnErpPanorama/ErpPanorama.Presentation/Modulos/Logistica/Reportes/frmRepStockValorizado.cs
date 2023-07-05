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

namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    public partial class frmRepStockValorizado : DevExpress.XtraEditors.XtraForm
    {
        public frmRepStockValorizado()
        {
            InitializeComponent();
        }

        private void frmReporteStockValorizado_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteStockValorizadoBE> lstReporte = null;
                lstReporte = new ReporteStockValorizadoBL().Listado(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptStockValorizado(lstReporte, deFecha.DateTime.ToShortDateString());
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
    }
}