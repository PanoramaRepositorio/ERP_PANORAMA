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
    public partial class frmRepPedidoVendedorCaja : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReportePedidoTiendaSupervisorBE> mLista = new List<ReportePedidoTiendaSupervisorBE>();

        #endregion

        #region "Eventos"

        public frmRepPedidoVendedorCaja()
        {
            InitializeComponent();
        }

        private void frmRepPedidoVendedorCaja_Load(object sender, EventArgs e)
        {
            //deFechaDesde.EditValue = DateTime.Now;
            //deFechaHasta.EditValue = DateTime.Now;

            //cboMes.EditValue = DateTime.Now.Month;

            //if (Parametros.intPerfilId != Parametros.intPerAdministrador)
            //{
            //    deFechaDesde.Properties.ReadOnly = true;
            //    deFechaHasta.Properties.ReadOnly = true;
            //}

            //cboMes.Focus();
            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + Convert.ToInt32(DateTime.Now.Month) + "/" + Parametros.intPeriodo);

            cboMes.EditValue = DateTime.Now.Month;                                                                                                                                                                                 //deFechaHasta.EditValue = DateTime.Now;
            cboMes.Focus();
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

                int IdVendedor = 0;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    if (frmAutoriza.Usuario.ToLower() == "master" || frmAutoriza.Usuario.ToLower() == "ltapia" || frmAutoriza.Usuario.ToLower() == "liliana"|| frmAutoriza.IdPerfil == Parametros.intPerJefeRRHH || frmAutoriza.IdPerfil == Parametros.intPerAsistenteRRHH || frmAutoriza.IdPerfil == Parametros.intPerGerenteComercial)
                        IdVendedor = 0;
                    else
                        IdVendedor = frmAutoriza.IdPersona;

                    List<ReportePedidoVendedorCajaBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorCajaBL().Listado(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorCaja(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
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

        private void Cargar()
        {
            //mLista = new ReportePedidoVendedorJuniorSeniorBL().Listado(0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0);
            //gcReporteVenta.DataSource = mLista;
        }

        #endregion

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////    if (Parametros.intPeriodo % 4 == 0 && Parametros.intPeriodo % 100 != 0 || Parametros.intPeriodo % 400 == 0) //Bisiesto
            ////    {
            ////        if (Convert.ToInt32(cboMes.EditValue) == 1)
            ////            deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
            ////        else
            ////            deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);
            ////    }
            ////    else
            ////    {
            ////        if (Convert.ToInt32(cboMes.EditValue) == 1)
            ////            deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
            ////        else if (Convert.ToInt32(cboMes.EditValue) == 3)
            ////            deFechaDesde.EditValue = Convert.ToDateTime("01/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue)) + "/" + Parametros.intPeriodo);
            ////        else
            ////            deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);



            ////        //if (Convert.ToInt32(cboMes.EditValue) == 3)
            ////        //    deFechaDesde.EditValue = Convert.ToDateTime("28/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);

            ////        //if (Convert.ToInt32(cboMes.EditValue) == 1)
            ////        //    deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
            ////        //else
            ////        //    deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);

            ////    }

            ////    deFechaHasta.EditValue = Convert.ToDateTime("28/" + Convert.ToInt32(cboMes.EditValue) + "/" + Parametros.intPeriodo);
            ///            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, Convert.ToInt32(cboMes.EditValue), 1);

            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year-1, Convert.ToInt32(cboMes.EditValue), 1);

            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + (Parametros.intPeriodo - new decimal(1)).ToString());
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

    }
}