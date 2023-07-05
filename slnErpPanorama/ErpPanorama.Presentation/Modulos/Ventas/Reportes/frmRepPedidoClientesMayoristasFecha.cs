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
    public partial class frmRepPedidoClientesMayoristasFecha : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRepPedidoClientesMayoristasFecha()
        {
            InitializeComponent();
        }

        private void frmRepPedidoClientesMayoristasFecha_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboRuta, new RutaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescRuta", "IdRuta", true);
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

                int IdTipoCliente = Parametros.intTipClienteMayorista;
                if (chkClienteFinal.Checked) IdTipoCliente = Parametros.intTipClienteFinal;


                List<ReportePedidoClientesMayoristasFechaBE> lstReporte = null;
                lstReporte = new ReportePedidoClientesMayoristasFechaBL().ListaPedidoClientesMayoristasFecha(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(cboRuta.EditValue),IdTipoCliente);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptPedidoClientesMayoristasFecha(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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