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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepPedidoVendedorCarteraMeta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"
        public frmRepPedidoVendedorCarteraMeta()
        {
            InitializeComponent();
        }

        private void frmRepPedidoVendedorCarteraMeta_Load(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin  !="Master")
            {

                return;
            }


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
                
                //if (chkResumen.Checked == true)
                if (optDetalle.Checked == true)
                {
                    List<ReportePedidoVendedorCarteraMetaBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorCarteraMetaBL().ListadoDetalle(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorCarteraMeta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optResumen.Checked == true)
                {
                    List<ReportePedidoVendedorCarteraMetaBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorCarteraMetaBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorCarteraMeta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optSueldo.Checked == true)
                {
                    int IdVendedor = 0;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    //PersonaBL objPersona = new PersonaBL();
                    //objPersona.Selecciona(Parametros.intEmpresaId, IdPersona)

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerGerenteComercial)
                            IdVendedor = 0;
                        else 
                            IdVendedor = frmAutoriza.IdPersona;


                        List<ReportePedidoVendedorCarteraMetaBE> lstReporte = null;
                        lstReporte = new ReportePedidoVendedorCarteraMetaBL().ListadoSueldo(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoVendedorCarteraMeta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 2);
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    //-----------------------
                    //List<ReportePedidoVendedorCarteraMetaBE> lstReporte = null;
                    //lstReporte = new ReportePedidoVendedorCarteraMetaBL().ListadoSueldo(68, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    //if (lstReporte != null)
                    //{
                    //    if (lstReporte.Count > 0)
                    //    {
                    //        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                    //        objRptKardexBulto.VerRptPedidoVendedorCarteraMeta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 2);
                    //        objRptKardexBulto.ShowDialog();
                    //    }
                    //    else
                    //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
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

        private void deFechaHasta_EditValueChanged(object sender, EventArgs e)
        {
            lblMeta.Text = "Se realizará el cálculo con la meta referente a: " + Convert.ToDateTime(deFechaHasta.EditValue).ToString("MMMM");
        }

        #endregion

        private void deFechaDesde_EditValueChanged(object sender, EventArgs e)
        {

        }



        #region "Metodos"

        #endregion

    }
}