using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
	public partial class frmRepProductoCatalogo: DevExpress.XtraEditors.XtraForm
	{
        #region "Propiedades"

        
        #endregion

        #region "Eventos"

        public frmRepProductoCatalogo()
		{
            InitializeComponent();
		}

        private void frmRepProductoCatalogo_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboVendedor, objServicio.Persona_SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            //cboVendedor.EditValue = Parametros.intPersonaId;
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ErpPanoramaServicios.ReporteProductoCatalogoBE> lstReporte = null;
            //    //lstReporte = objServicio.ReporteProductoCatalogo_Listado(Parametros.intEmpresaId);
            //    lstReporte = objServicio.ReporteProductoCatalogo_Listado(13);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptProductoCatalogo = new RptVistaReportes();
            //            objRptProductoCatalogo.VerRptProductoCatalogo(lstReporte);
            //            objRptProductoCatalogo.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnxPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteProductoCatalogoPedidoBE> lstReporte = null;
                lstReporte = new ReporteProductoCatalogoPedidoBL().Listado(13, 1008);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptProductoCatalogoPedido = new RptVistaReportes();
                        objRptProductoCatalogoPedido.VerRptProductoCatalogoPedido(lstReporte);
                        objRptProductoCatalogoPedido.ShowDialog();
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


        #region "Metodos"

        #endregion


	}
}