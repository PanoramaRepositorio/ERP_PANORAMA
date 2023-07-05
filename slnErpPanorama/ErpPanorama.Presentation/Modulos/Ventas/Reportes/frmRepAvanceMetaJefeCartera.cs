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

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepAvanceMetaJefeCartera : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        
        #endregion

        #region "Eventos"

        public frmRepAvanceMetaJefeCartera()
        {
            InitializeComponent();
        }

        private void frmRepAvanceMetaJefeCartera_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            //cboVendedor.EditValue = Convert.ToInt32(Parametros.intPersonaId);

            //frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //frmAutoriza.ShowDialog();
            //if (frmAutoriza.Edita)
            //{
            //if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerGerenteComercial)
            //{
            //    cboVendedor.Enabled = true;
            //    radioButton1.Enabled = true;
            //    radioButton2.Enabled = true;
            //}
            //else
            //{
            //    cboVendedor.Enabled = false;
            //    radioButton1.Enabled = false;
            //    radioButton2.Enabled = false;
            //}
            //}
            txtAnio.EditValue = Parametros.intPeriodo;

            deFechaDesde.EditValue = new DateTime(Convert.ToInt32(txtAnio.EditValue), DateTime.Now.Month, 1);
            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(txtAnio.EditValue), DateTime.Now.Month) + "/" + Convert.ToInt32(DateTime.Now.Month) + "/" + Convert.ToInt32(txtAnio.EditValue));

            cboMes.EditValue =  DateTime.Now.Month;                                                                                                                                                                                 //deFechaHasta.EditValue = DateTime.Now;
            cboMes.Focus();
        }

        private void cboVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            //splashScreenManager1.ShowWaitForm();
            try
            {
                Cursor = Cursors.WaitCursor;
                    List<ReporteAvanceMeta> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorTipoClienteBL().ListadoAvanceMetaJefeCartera(   0
                                                                                                    , 0
                                                                                                    , Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString())
                                                                                                    , Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoAvanceMetaCartera(lstReporte, "dddd", deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            //splashScreenManager1.CloseWaitForm();
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

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            deFechaDesde.EditValue = new DateTime(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue), 1);

            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + (Convert.ToInt32(txtAnio.EditValue)).ToString());


        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            //if (radioButton1.Checked)
            //{
            //    cboVendedor.Enabled = true;
            //    cboVendedor.Focus();
            //}
            //else if (radioButton2.Checked)
            //{
            //    cboVendedor.Enabled = false;
            //    radioButton2.Focus();
            //}
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            //if (radioButton1.Checked)
            //{
            //    cboVendedor.Enabled = true;
            //    cboVendedor.Focus();
            //}
            //else if (radioButton2.Checked)
            //{
            //    cboVendedor.Enabled = false;
            //    radioButton2.Focus();
            //}
        }

        private void txtAnio_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                deFechaDesde.EditValue = new DateTime(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue), 1);

                deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + Convert.ToInt32(txtAnio.EditValue));   //(Parametros.intPeriodo)
            }
            catch
            {
            }
        }
    }
}