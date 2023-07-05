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
    public partial class frmRepPedidoVendedorFormaPago : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"



        #endregion

        #region "Eventos"
        public frmRepPedidoVendedorFormaPago()
        {
            InitializeComponent();
        }

        private void frmRepPedidoVendedorFormaPago_Load(object sender, EventArgs e)
        {
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

                if (chkResumen.Checked == true)
                {
                    List<ReportePedidoVendedorBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedor(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else { 
                #region "Periodo"
                if (optAnio.Checked == true)
                {
                    XtraMessageBox.Show("En Construcción...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (optMes.Checked == true)
                {
                    XtraMessageBox.Show("En Construcción...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (optSemana.Checked == true)
                {
                    XtraMessageBox.Show("En Construcción...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (optDia.Checked == true)
                {
                    XtraMessageBox.Show("En Construcción...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (optRango.Checked == true)
                {
                    List<ReportePedidoVendedorFormaPagoBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorFormaPagoBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorFormaPago(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                #endregion
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