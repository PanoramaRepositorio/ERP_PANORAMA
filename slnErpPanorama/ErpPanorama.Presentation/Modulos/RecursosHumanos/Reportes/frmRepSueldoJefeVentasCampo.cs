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

namespace  ErpPanorama.Presentation.Modulos.RecursosHumanos.Reportes
{
    public partial class frmRepSueldoJefeVentasCampo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        
        #endregion

        #region "Eventos"

        public frmRepSueldoJefeVentasCampo()
        {
            InitializeComponent();
        }

        private void frmRepSueldoJefeVentasCampo_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + Convert.ToInt32(DateTime.Now.Month) + "/" + (Parametros.intPeriodo - new decimal(1)).ToString());  // DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);  //     Convert.ToDateTime("30/" + Convert.ToInt32(DateTime.Now.Month) + "/" + Parametros.intPeriodo);
            cboMes.EditValue = DateTime.Now.Month;                                                                                                                                                                                 //deFechaHasta.EditValue = DateTime.Now;

            //cboVendedor.Focus();
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
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
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
                ///
                int IdVendedor = 0;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();
                if (frmAutoriza.Edita)
                {
                    if (frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda || frmAutoriza.IdPerfil == Parametros.intPerJefeCanalMayorista  
                        ||  frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerGerenteComercial || Parametros.intPerfilId == Parametros.intPerJefeRRHH)

                        Cursor = Cursors.WaitCursor;
                            List<ReporteSueldoAdmUcayali> lstReporte = null;
                            lstReporte = new ReportePedidoVendedorTipoClienteBL().SueldoJefeCampo(0 
                                                                                                    , 1
                                                                                                    , Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString())
                                                                                                    , Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                                if (lstReporte != null)
                                {
                                    if (lstReporte.Count > 0)
                                    {
                                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                        objRptKardexBulto.VerRptSueldoJefeCampo(lstReporte, Parametros.strDescTienda, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                        objRptKardexBulto.ShowDialog();
                                    }
                                    else
                                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            //}
                      
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                }
                ////

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
            //if (Parametros.intPeriodo % 4 == 0 && Parametros.intPeriodo % 100 != 0 || Parametros.intPeriodo % 400 == 0) //Bisiesto
            //{
            //    if (Convert.ToInt32(cboMes.EditValue) == 1)
            //        deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
            //    else
            //        deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);
            //}
            //else
            //{
            //    if (Convert.ToInt32(cboMes.EditValue) == 1)
            //        deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
            //    else if (Convert.ToInt32(cboMes.EditValue) == 3)
            //        deFechaDesde.EditValue = Convert.ToDateTime("01/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue)) + "/" + Parametros.intPeriodo);
            //    else
            //        deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);
            //}

            //deFechaHasta.EditValue = Convert.ToDateTime("30/" + Convert.ToInt32(cboMes.EditValue) + "/" + Parametros.intPeriodo);

            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, Convert.ToInt32(cboMes.EditValue), 1);

            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + Parametros.intPeriodo); 


        }
    }
}