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
    public partial class frmRepVentaProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        
        #endregion

        #region "Eventos"

        public frmRepVentaProducto()
        {
            InitializeComponent();
        }

        private void frmRepVentaProducto_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboLinea.EditValue = Parametros.intNinguno;

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

                int IdTienda = 0;
                int IdLineaProducto = 0;
                IdLineaProducto = Convert.ToInt32(cboLinea.EditValue);
                if (chkTienda.Checked == false) IdTienda = Convert.ToInt32(cboTienda.EditValue);


                if (optResumen.Checked)// chkResumen.Checked == true && chkGrafico.Checked == false)
                {

                    List<ReporteVentaProductoBE> lstReporte = null;
                    lstReporte = new ReporteVentaProductoBL().ListadoResumen(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdTienda, IdLineaProducto, Convert.ToInt32(cboTipoCliente.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptVentaProductoResumen(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else if (optGrafico.Checked)//chkResumen.Checked == true && chkGrafico.Checked == true)
                {

                    List<ReporteVentaProductoBE> lstReporte = null;
                    lstReporte = new ReporteVentaProductoBL().ListadoResumen(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdTienda, IdLineaProducto, Convert.ToInt32(cboTipoCliente.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptVentaProductoResumen(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),0);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optDetalle.Checked)//chkResumen.Checked == false)
                {
                    List<ReporteVentaProductoBE> lstReporte = null;
                    lstReporte = new ReporteVentaProductoBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdTienda, IdLineaProducto, Convert.ToInt32(cboTipoCliente.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptVentaProducto(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else if(optRentabilidad.Checked)
                {
                    List<ReporteVentaProductoBE> lstReporte = null;
                    lstReporte = new ReporteVentaProductoBL().ListadoRentabilidad(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdTienda, IdLineaProducto, Convert.ToInt32(cboTipoCliente.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptVentaProductoRentabilidad(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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

        private void chkTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTienda.Checked == true)
            {
                cboTienda.Enabled = false;
                cboTienda.ForeColor = Color.Black;
            }
            else
            {
                cboTienda.Enabled = true;
                cboTienda.ForeColor = Color.Blue;
            }
        }



        #region "Metodos"

        #endregion


    }
}