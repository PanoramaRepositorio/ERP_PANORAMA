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

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepPedidoTipoVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"
        public frmRepPedidoTipoVenta()
        {
            InitializeComponent();
        }

        private void frmRepPedidoTipoVenta_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboTipoVenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoVenta), "DescTablaElemento", "IdTablaElemento", true);

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

                if (chkResumen.Checked == true)
                {
                    List<ReportePedidoTipoVentaBE> lstReporte = null;
                    lstReporte = new ReportePedidoTipoVentaBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(cboTipoVenta.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoTipoVenta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), cboTipoVenta.Text.ToString() , 1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    List<ReportePedidoTipoVentaBE> lstReporte = null;
                    lstReporte = new ReportePedidoTipoVentaBL().ListadoDetalle(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(cboTipoVenta.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoTipoVenta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), cboTipoVenta.Text.ToString(), 0);
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

        #endregion

        #region "Metodos"

        #endregion

    }
}