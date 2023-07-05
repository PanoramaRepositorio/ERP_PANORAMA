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
    public partial class frmRepPedidoTiendaMesTipoCliente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private int IdTienda = 0;
        private int IdLinea = 0;

        #endregion

        #region "Eventos"

        public frmRepPedidoTiendaMesTipoCliente()
        {
            InitializeComponent();
        }

        private void frmRepPedidoTiendaMesTipoCliente_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            txtPeriodo.EditValue = DateTime.Now.Year;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            cboLinea.EditValue = Parametros.intNinguno;
            
            deFechaDesde.Focus();
            if(Parametros.intPerfilId !=Parametros.intPerAdministrador)
            {
                gcOpciones.Enabled = false;
            }
            if(Parametros.strUsuarioLogin.ToLower() == "amorales"|| Parametros.strUsuarioLogin.ToLower() == "rcastaneda" 
                || Parametros.strUsuarioLogin.ToLower() == "narizmendi" || Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad
                || Parametros.intPerfilId == Parametros.intPerGerenteComercial || Parametros.strUsuarioLogin.ToLower() == "pdiaz" || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad)
            {
                gcOpciones.Enabled = true;
            }

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
                int IdTienda = 0;
                int IdEmpresa = 0;
                if (chkTiendaTodo.Checked == false) IdTienda = Convert.ToInt32(cboTienda.EditValue);
                if (chkEmpresaTodo.Checked == false) IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
             

                Cursor = Cursors.WaitCursor;

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
                    if (optDetalle.Checked == true)
                    {
                        List<ReportePedidoTiendaMesTipoClienteBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaMesTipoClienteBL().ListadoPorLinea(IdEmpresa, IdTienda, Convert.ToInt32(cboLinea.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptPedidoTiendaMesTipoCliente = new RptVistaReportes();
                                objRptPedidoTiendaMesTipoCliente.VerRptPedidoTiendaMesTipoClienteLineaProducto(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptPedidoTiendaMesTipoCliente.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else  if(optGeneral.Checked == true)
                    {
                        if (Parametros.intPerfilId != Parametros.intPerAdministrador )
                            IdTienda = Parametros.intTiendaId;

                        List<ReportePedidoTiendaMesTipoClienteBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaMesTipoClienteBL().Listado(IdEmpresa, Parametros.intPersonaId , IdTienda, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptPedidoTiendaMesTipoCliente = new RptVistaReportes();
                                objRptPedidoTiendaMesTipoCliente.VerRptPedidoTiendaMesTipoCliente(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptPedidoTiendaMesTipoCliente.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                        
                    }
                    else if (optCanalVenta.Checked == true)
                    {
                        List<ReportePedidoTiendaMesTipoClienteBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaMesTipoClienteBL().ListadoPorCanalVenta(IdEmpresa, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptPedidoTiendaMesTipoCliente = new RptVistaReportes();
                                objRptPedidoTiendaMesTipoCliente.VerRptPedidoTiendaMesTipoClienteCanalVenta(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptPedidoTiendaMesTipoCliente.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (optResumen.Checked == true)
                    {
                        List<ReportePedidoTiendaBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaBL().Listado(IdEmpresa, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoTienda(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (optComparativo.Checked == true)
                    {
                        List<ReportePedidoTiendaMesTipoClienteBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaMesTipoClienteBL().ListadoComparativo(IdEmpresa, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptPedidoTiendaMesTipoCliente = new RptVistaReportes();
                                objRptPedidoTiendaMesTipoCliente.VerRptPedidoTiendaComparativo(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptPedidoTiendaMesTipoCliente.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (optVaracion.Checked == true)
                    {
                        List<ReportePedidoTiendaMesTipoClienteVariacionBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaMesTipoClienteVariacionBL().Listado(IdEmpresa, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoTiendaMesTipoClienteVariacion(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else if (optComparativo.Checked == true)
                    {
                        List<ReportePedidoTiendaMesTipoClienteVariacionBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaMesTipoClienteVariacionBL().Listado(IdEmpresa, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoTiendaMesTipoClienteVariacion(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                #endregion
     

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
            if (chkTiendaTodo.Checked == true) {
                cboTienda.Enabled = false;
                //cboLinea.Enabled = true;
            }else{
                cboTienda.Enabled = true;
                //cboLinea.Enabled = true;
            }
            
        }



        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);            
        }

        private void ChkLineaProductoTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLineaProductoTodo.Checked == true)
            {
                cboLinea.EditValue = 0;
                cboLinea.Enabled = false;
            }
            else
            {
                cboLinea.Enabled = true;
            }
        }

        private void chkEmpresaTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmpresaTodo.Checked == true)
            {
                cboEmpresa.Enabled = false;
            }
            else
            {
                cboEmpresa.Enabled = true;
            }
        }

        private void optDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (optDetalle.Checked == true)
            {
                grdDetalle.Enabled = true;
            }
            else
            {
                grdDetalle.Enabled = false;
            }
        }

        #region "Metodos"

        #endregion

        private void optVaracion_CheckedChanged(object sender, EventArgs e)
        {
            //if (optVaracion.Checked)
            //    deFechaDesde.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            //else
            //    deFechaDesde.EditValue = DateTime.Now;
        }

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}