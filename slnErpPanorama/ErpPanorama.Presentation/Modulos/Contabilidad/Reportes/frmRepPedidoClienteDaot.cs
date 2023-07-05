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

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Reportes
{
    public partial class frmRepPedidoClienteDaot : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdEmpresa = 0;
        private string TipoDocumento = string.Empty;
        private string Simbolo = ">";
        private decimal Valor = 0;

        #endregion

        #region "Eventos"
        
        public frmRepPedidoClienteDaot()
        {
            InitializeComponent();
        }

        private void frmRepPedidoClienteDaot_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;

            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optTodos_CheckedChanged(object sender, EventArgs e)
        {
                txtValor.Enabled = false;
                Valor = Convert.ToDecimal("0.00");
                Simbolo = ">";
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

                ValidarCheckTipoDocumento();

                if (chkDetalle.Checked == true)
                {
                    List<ReportePedidoClienteDaotDetalleBE> lstReporte = null;
                    lstReporte = new ReportePedidoClienteDaotDetalleBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdEmpresa, IdCliente, "(" + TipoDocumento.Substring(0, TipoDocumento.Length - 1) + ")", Simbolo, Convert.ToDecimal(Valor));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoClienteDaotDetalle(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else {
                    List<ReportePedidoClienteDaotBE> lstReporte = null;
                    lstReporte = new ReportePedidoClienteDaotBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdEmpresa, IdCliente, "(" + TipoDocumento.Substring(0, TipoDocumento.Length - 1) + ")", Simbolo, Convert.ToDecimal(Valor));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoClienteDaot(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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

        private void optMayor_CheckedChanged(object sender, EventArgs e)
        {
                txtValor.Enabled = true;
                Simbolo = ">";
        }

        private void optMenor_CheckedChanged(object sender, EventArgs e)
        {
                txtValor.Enabled = true;
                Simbolo = "<";
        }

        private void chkFav_CheckedChanged(object sender, EventArgs e)
        {
            TipoDocumento = TipoDocumento +  Parametros.intTipoDocFacturaVenta + ",";
            //TipoDocumento = TipoDocumento + Parametros.intTipoDocFacturaVentaTraslado + ",";
        }

        private void chkBov_CheckedChanged(object sender, EventArgs e)
        {
            TipoDocumento = TipoDocumento + Parametros.intTipoDocBoletaVenta + ",";
        }

        private void chkTkf_CheckedChanged(object sender, EventArgs e)
        {
            TipoDocumento = TipoDocumento + Parametros.intTipoDocTicketFactura + ",";
        }

        private void chkTkv_CheckedChanged(object sender, EventArgs e)
        {
               TipoDocumento = TipoDocumento + Parametros.intTipoDocTicketBoleta + ",";
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

        private void chkClienteTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClienteTodo.Checked == true)
            {
                btnBuscar.Enabled = false;
                txtNumeroDocumento.Text = string.Empty;
                txtDescCliente.Text = string.Empty;
                txtTipoCliente.Text = string.Empty;
                IdCliente = 0;
            }
            else
            {
                btnBuscar.Enabled = true;
                //IdCliente = 0;
                //txtNumeroDocumento.Text = string.Empty;
                //txtDescCliente.Text = string.Empty;
                //txtTipoCliente.Text = string.Empty;
            }

        }

        private void ValidarCheckTipoDocumento() 
        {
            TipoDocumento = string.Empty;
            if (chkFav.Checked == true) {
                TipoDocumento = TipoDocumento + Parametros.intTipoDocFacturaVenta + "," + Parametros.intTipoDocFacturaVentaTraslado + ",";
            }
            if (chkBov.Checked == true)
            {
                TipoDocumento = TipoDocumento + Parametros.intTipoDocBoletaVenta + "," + Parametros.intTipoDocBoletaVentaTraslado + ",";
            }
            if (chkTkf.Checked == true)
            {
                TipoDocumento = TipoDocumento + Parametros.intTipoDocTicketFactura + ",";
            }
            if (chkTkv.Checked == true)
            {
                TipoDocumento = TipoDocumento + Parametros.intTipoDocTicketBoleta + ",";
            }
            if (TipoDocumento ==""){
                TipoDocumento = "0,";
            }
            //Valor
            if (chkDetalle.Checked == true && optTodos.Checked == true)
            {
                Valor = Convert.ToDecimal("-100000");
            }
            else if (chkDetalle.Checked == false && optTodos.Checked == true)
            {
                Valor = Convert.ToDecimal("-100000"); //0;
            }
            else {
                Valor = Convert.ToDecimal(txtValor.Text);
            }
            //empresa
            if (chkEmpresaTodo.Checked == true)
            {
                cboEmpresa.Enabled = false;
                IdEmpresa = 0;
            }
            else
            {
                cboEmpresa.Enabled = true;
                IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            }
        }

        #region "Metodos"

        #endregion


    }
}