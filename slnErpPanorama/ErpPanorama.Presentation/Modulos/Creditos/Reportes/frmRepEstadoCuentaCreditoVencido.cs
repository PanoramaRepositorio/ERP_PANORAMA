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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    public partial class frmRepEstadoCuentaCreditoVencido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private int IdCliente = 0;
        private int IdTipoCliente = 0;

        #endregion

        #region "Eventos"

        public frmRepEstadoCuentaCreditoVencido()
        {
            InitializeComponent();
        }

        private void frmRepEstadoCuentaCreditoVencido_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = "01/01/2013";//+ Parametros.intPeriodo;
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboClasifica, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionCliente), "DescTablaElemento", "IdTablaElemento", true);
            //cboClasifica.EditValue = Parametros.intNinguno;
            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionClienteFinal), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;

            deFechaDesde.Focus();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdClasificacion = 0;
                int IdTipoCliente = 0;
                int Moroso = 0;



                /*if (this.cboClasifica.Text == "MOROSO")
                {
                    List<ReporteCreditoBE> lstReporte = null;
                    lstReporte = new ReporteCreditoBL().ListadoMorosos(13, 170, "d");


                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptCredito = new RptVistaReportes();
                            objRptCredito.VerRptListadoMorosos(lstReporte);
                            objRptCredito.Show();
                        }
                        else { }
                        //      XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);




                    }
                    Cursor = Cursors.Default;

                }*/

                    //------------------------------------------------------------------------------------------------------------------------//
                //else
                //{



                    if (chkClasifica.Checked == true)
                    {
                        IdClasificacion = Convert.ToInt32(cboClasificacion.EditValue);
                        IdTipoCliente = Parametros.intTipClienteFinal;
                    }
                    else
                    {
                        IdClasificacion = 0;
                        IdTipoCliente = Parametros.intTipClienteMayorista;
                    }

                    //cuando moroso esta en 1 no incluye listado con moroso
                    if (chkMoroso.Checked == true)
                    {
                        Moroso = 0;
                    }
                    else
                    {
                        Moroso = 1;
                    }





                    List<ReporteCreditoBE> lstReporte = null;
                    lstReporte = new ReporteCreditoBL().ListadoCreditoVencido(Parametros.intEmpresaId, IdCliente, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdTipoCliente, IdClasificacion, Convert.ToInt32(cboMotivo.EditValue), Convert.ToInt32(cboClasifica.EditValue), Moroso);




                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptCredito = new RptVistaReportes();
                            objRptCredito.VerRptEstadoCuentaCreditoVencido(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptCredito.Show();
                        }
                        else { }
                        //      XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);




                    }

                    Cursor = Cursors.Default;
                //}
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                    btnVer.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtNumeroDocumento.Properties.ReadOnly = true;

            }
            else
            {
                txtNumeroDocumento.Properties.ReadOnly = false;
                btnBuscar.Enabled = true;
                txtNumeroDocumento.Focus();
                //IdCliente = 0;
                //txtNumeroDocumento.Text = string.Empty;
                //txtDescCliente.Text = string.Empty;
                //txtTipoCliente.Text = string.Empty;
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        #endregion

        private void chkClasifica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClasifica.Checked == true)
                cboClasificacion.Enabled = true;
            else cboClasificacion.Enabled = false;
        }

        private void chkMoroso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoroso.Checked == true)
            {
                cboClasifica.EditValue = Parametros.intNinguno;
                //cboClasifica.Enabled = false;
            }
            else
            {
                //  cboClasifica.Enabled = true;            
            }
        }

        #region "Metodos"

        #endregion


    }
}