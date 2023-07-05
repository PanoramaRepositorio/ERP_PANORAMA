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
    public partial class frmRepSueldoSubAdmTienda : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        
        #endregion

        #region "Eventos"

        public frmRepSueldoSubAdmTienda()
        {
            InitializeComponent();
        }

        private void frmRepSueldoSubAdmTienda_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            //BSUtils.LoaderLook(cboTienda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
           
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosTiendasActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            if (Parametros.intPerfilId == 14) //Adm Tiendas
            {
                cboTienda.Enabled = false;
                cboTienda.EditValue = Parametros.intTiendaId;
            } else if (Parametros.intPerfilId == 1 )
             {
                cboTienda.Enabled = true;
                cboTienda.EditValue = Parametros.intTiendaId;
            }

            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + Convert.ToInt32(DateTime.Now.Month) + "/" + Parametros.intPeriodo);

            cboMes.EditValue = DateTime.Now.Month;                                                                                                                                                                                 //deFechaHasta.EditValue = DateTime.Now;
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
                    if (frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerGerenteComercial
                        || frmAutoriza.IdPerfil == Parametros.intPerJefeRRHH || frmAutoriza.IdPerfil == Parametros.intPerAsistenteRRHH)

                        if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerJefeRRHH || frmAutoriza.IdPerfil == Parametros.intPerAsistenteRRHH)
                        {
                            Cursor = Cursors.WaitCursor;
                            List<ReporteSueldoAdmUcayali> lstReporte = null;
                            //if (Parametros.intTiendaId == 1)  //Ucayali
                            //{
                            lstReporte = new ReportePedidoVendedorTipoClienteBL().SueldoSubAdm(0 
                                                                                                    , Convert.ToInt32(cboTienda.EditValue)
                                                                                                    , Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString())
                                                                                                    , Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                            if (Convert.ToInt32(cboTienda.EditValue) == 1)
                            {
                                if (lstReporte != null)
                                {
                                    if (lstReporte.Count > 0)
                                    {
                                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                        objRptKardexBulto.VerRptSueldoSubAdmUcayali(lstReporte, Parametros.strDescTienda, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                        objRptKardexBulto.ShowDialog();
                                    }
                                    else
                                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                if (lstReporte != null)
                                {
                                    if (lstReporte.Count > 0)
                                    {
                                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                        objRptKardexBulto.VerRptSueldoSubAdmUcayali(lstReporte, Parametros.strDescTienda, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                        objRptKardexBulto.ShowDialog();
                                    }
                                    else
                                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else if (Parametros.intTiendaId == Convert.ToInt32(cboTienda.EditValue) )
                        {
                            Cursor = Cursors.WaitCursor;
                            List<ReporteSueldoAdmUcayali> lstReporte = null;
                            //if (Parametros.intTiendaId == 1)  //Ucayali
                            //{
                                lstReporte = new ReportePedidoVendedorTipoClienteBL().SueldoSubAdm(Parametros.intTiendaId
                                                                                                        , Convert.ToInt32(cboTienda.EditValue)
                                                                                                        , Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString())
                                                                                                        , Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                            if (Convert.ToInt32(cboTienda.EditValue) == 1)
                            {
                                if (lstReporte != null)
                                {
                                    if (lstReporte.Count > 0)
                                    {
                                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                        objRptKardexBulto.VerRptSueldoAdmUcayali(lstReporte, Parametros.strDescTienda, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                        objRptKardexBulto.ShowDialog();
                                    }
                                    else
                                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                if (lstReporte != null)
                                {
                                    if (lstReporte.Count > 0)
                                    {
                                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                        objRptKardexBulto.VerRptSueldoAdmOtrasTiendas(lstReporte, Parametros.strDescTienda, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                        objRptKardexBulto.ShowDialog();
                                    }
                                    else
                                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            //}
                            //else   //Otras tiendas
                            //{
                            //    lstReporte = new ReportePedidoVendedorTipoClienteBL().SueldoAdmUcayali(0
                            //                                                                            , Convert.ToInt32(cboTienda.EditValue)
                            //                                                                            , Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString())
                            //                                                                            , Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                            //    if (lstReporte != null)
                            //    {
                            //        if (lstReporte.Count > 0)
                            //        {
                            //            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            //            objRptKardexBulto.VerRptSueldoAdmUcayali(lstReporte, "dddd", deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            //            objRptKardexBulto.ShowDialog();
                            //        }
                            //        else
                            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    }
                            //}
                        }
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

            deFechaDesde.EditValue = new DateTime(DateTime.Now.Year, Convert.ToInt32(cboMes.EditValue), 1);

            deFechaHasta.EditValue = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(cboMes.EditValue)) + "/" + Convert.ToInt32(cboMes.EditValue) + "/" + (Parametros.intPeriodo));

        }
    }
}