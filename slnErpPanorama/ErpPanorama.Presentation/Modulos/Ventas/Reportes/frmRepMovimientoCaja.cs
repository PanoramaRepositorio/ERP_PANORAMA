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
    public partial class frmRepMovimientoCaja : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        #endregion

        #region "Eventos"
        public frmRepMovimientoCaja()
        {
            InitializeComponent();
        }

        private void frmRepMovimientoCaja_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
            cboCaja.EditValue = Parametros.intCajaId;
            deFecha.EditValue = DateTime.Now;
            cboTienda.Select();

            BloquearAccesoPorPerfil();
        }

        #endregion

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue) , Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
            cboCaja.EditValue = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                #region "Resumen"
                    if (chkResumenDiferencia.Checked == true)
                    {
                        int IdTienda = 0;
                        int IdCajaRe = 0;
                        if (chkTodoTienda.Checked == true)
                        { 
                            IdTienda = Convert.ToInt32(cboTienda.EditValue);
                            IdCajaRe = Convert.ToInt32(cboCaja.EditValue);
                        } 

 
                        List<ReporteMovimientoCajaBE> lstReporte = null;
                        lstReporte = new ReporteMovimientoCajaBL().ListadoDiferenciaDiario(Convert.ToInt32(cboEmpresa.EditValue), IdTienda, IdCajaRe, 0, Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptDiferenciaMovimientoCaja(lstReporte);
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        Cursor = Cursors.Default;
                        return;
                    }
                #endregion

                #region "Formato 1"
                if (chkCaja.Checked == true && chkFormato.Checked == false)
                {
                    List<ReporteMovimientoCajaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoCajaBL().Listado(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptMovimientoCaja(lstReporte);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else  if (chkCaja.Checked == false && chkFormato.Checked == false)
                {
                    List<ReporteMovimientoCajaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoCajaBL().ListadoTienda(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboTienda.EditValue), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptMovimientoCajaTienda(lstReporte);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                #endregion

                #region "Formato 2"
                if (chkCaja.Checked == true && chkFormato.Checked == true)//por caja
                {
                    List<ReporteMovimientoCajaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoCajaBL().ListadoDocumento(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            List<ReporteMovimientoCajaBE> lstReporteTarjeta = null;
                            lstReporteTarjeta = new ReporteMovimientoCajaBL().ListadoTarjeta(0, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));

                            RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
                            objRptMovimientoCaja.VerRptMovimientoCajaTarjetaDocumento(lstReporte, lstReporteTarjeta);
                            objRptMovimientoCaja.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (chkCaja.Checked == false && chkFormato.Checked == true) //Por Tienda
                {
                    List<ReporteMovimientoCajaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoCajaBL().ListadoDocumentoTienda(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(cboTienda.EditValue), Convert.ToDateTime(deFecha.EditValue));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            List<ReporteMovimientoCajaBE> lstReporteTarjeta = null;
                            lstReporteTarjeta = new ReporteMovimientoCajaBL().ListadoTarjeta(Convert.ToInt32(cboTienda.EditValue), 0, Convert.ToDateTime(deFecha.EditValue));

                            RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
                            objRptMovimientoCaja.VerRptMovimientoCajaTarjetaDocumentoTienda(lstReporte, lstReporteTarjeta);
                            objRptMovimientoCaja.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void chkCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCaja.Checked == true)
            {
                cboCaja.Enabled = true;
            }
            else {
                cboCaja.Enabled = false;
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
        }

        private void chkResumenDiferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResumenDiferencia.Checked == true)
            {
                deFechaHasta.Visible = true;
                lblHasta.Visible = true;
                deFechaHasta.EditValue = DateTime.Now;
            }
            else
            {
                deFechaHasta.Visible = false;
                lblHasta.Visible = false;
            }
        }

        private void chkTodoTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodoTienda.Checked == true)
            {
                cboTienda.Enabled = true;
            }
            else
            {
                cboTienda.Enabled = false;
            }
        }


        #region "Metodos"

        private void BloquearAccesoPorPerfil()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion || Parametros.intPerfilId == Parametros.intPerAsistenteCompras)
            {
                chkResumenDiferencia.Visible = true;
                chkTodoTienda.Enabled = true;
                cboTienda.Enabled = true;
                cboEmpresa.Enabled = true;
                
            }
            else
            {
                chkResumenDiferencia.Visible = false;
                chkTodoTienda.Enabled = false;
                cboTienda.Enabled = false;
                cboEmpresa.Enabled = false;
            }
        }

        #endregion
    }
}