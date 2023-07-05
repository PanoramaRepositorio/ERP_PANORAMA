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
    public partial class frmRepPedidoVendedorJuniorSenior : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReportePedidoVendedorJuniorSeniorBE> mLista = new List<ReportePedidoVendedorJuniorSeniorBE>();
        private List<ReportePedidoVendedorPisoSueldoBE> mListaPiso = new List<ReportePedidoVendedorPisoSueldoBE>();

        #endregion

        #region "Eventos"
        public frmRepPedidoVendedorJuniorSenior()
        {
            InitializeComponent();
        }

        private void frmRepPedidoVendedorJuniorSenior_Load(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin !=  "Master")
            {
                return;
            }
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            //if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH)
            //{
            //    deFechaDesde.Properties.ReadOnly = true;
            //    deFechaHasta.Properties.ReadOnly = true;
            //}
            cboMes.Focus();

        }

        private void deFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void deFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if(optDetalle.Checked == true) // 1
                {
                    List<ReportePedidoVendedorJuniorSeniorBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorJuniorSeniorBL().Listado(Parametros.intPersonaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorJuniorSenior(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if(optDiario.Checked == true) // 2
                {
                    List<ReportePedidoVentaTiendaTipoClientePorCargoBE> lstReporte = null;
                    lstReporte = new ReportePedidoVentaTiendaTipoClientePorCargoBL().Listado(Parametros.intPersonaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objReporte = new RptVistaReportes();
                            objReporte.VerRptPedidoVentaTiendaTipoClientePorCargo(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objReporte.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optAvance.Checked == true) // 3
                {
                    int IdVendedor = 0;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "mtapia" || frmAutoriza.Usuario == "pmoscaiza" || frmAutoriza.Usuario == "liliana" || frmAutoriza.Usuario == "epadilla" || Parametros.intPerfilId == Parametros.intPerJefeRRHH || frmAutoriza.IdPerfil == Parametros.intPerSupervisorVentasPiso || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerAsistenteRRHH || frmAutoriza.IdPerfil == Parametros.intPerGerenteComercial)
                            IdVendedor = 0;
                        else
                            IdVendedor = frmAutoriza.IdPersona;

                        List<ReportePedidoVendedorJuniorSeniorBE> lstReporte = null;
                        lstReporte = new ReportePedidoVendedorJuniorSeniorBL().Listado(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 2);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoVendedorJuniorSenior(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 3);
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
                }
                else if (optSueldo.Checked == true)   // 4
                {
                    int IdVendedor = 0;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || Parametros.intPerfilId == Parametros.intPerJefeRRHH || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerGerenteComercial)
                            IdVendedor = 0;
                        else
                            IdVendedor = frmAutoriza.IdPersona;

                        List<ReportePedidoVendedorPisoSueldoBE> lstReporte = null;
                        lstReporte = new ReportePedidoVendedorPisoSueldoBL().Listado(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptlistado = new RptVistaReportes();
                                objRptlistado.VerRptPedidoVendedorPisoSueldo(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                                objRptlistado.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //Cargar();

            //string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoReporteVentaSueldo";
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //f.ShowDialog(this);
            //if (f.SelectedPath != "")
            //{
            //    Cursor = Cursors.AppStarting;
            //    gvReporteVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    Cursor = Cursors.Default;
            //}


            //-------------

            int IdVendedor = 0;
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "mtapia" || frmAutoriza.Usuario == "pmoscaiza" || frmAutoriza.Usuario == "liliana" || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
                    IdVendedor = 0;
                else
                    IdVendedor = frmAutoriza.IdPersona;

                Cargar(IdVendedor);

                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoReporteVentaSueldoPiso";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    gvReporteVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                }

            }   
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Parametros.intPeriodo % 4 == 0 && Parametros.intPeriodo % 100 != 0 || Parametros.intPeriodo % 400 == 0) //Bisiesto
            {
                if (Convert.ToInt32(cboMes.EditValue) == 1)
                    deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
                else
                    deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);
            }
            else
            {
                if (Convert.ToInt32(cboMes.EditValue) == 1)
                    deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
                else if (Convert.ToInt32(cboMes.EditValue) == 3)
                    deFechaDesde.EditValue = Convert.ToDateTime("01/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue)) + "/" + Parametros.intPeriodo);
                else
                    deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);



                //if (Convert.ToInt32(cboMes.EditValue) == 3)
                //    deFechaDesde.EditValue = Convert.ToDateTime("28/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);

                //if (Convert.ToInt32(cboMes.EditValue) == 1)
                //    deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
                //else
                //    deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);
            }

            deFechaHasta.EditValue = Convert.ToDateTime("30/" + Convert.ToInt32(cboMes.EditValue) + "/" + Parametros.intPeriodo);
        }
        #endregion

        #region "Metodos"

        private void Cargar(int IdVendedor)
        {
            //mLista = new ReportePedidoVendedorJuniorSeniorBL().Listado(0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0);
            //gcReporteVenta.DataSource = mLista;

            mListaPiso = new ReportePedidoVendedorPisoSueldoBL().Listado(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0);
            gcReporteVenta.DataSource = mListaPiso;
        }

        #endregion
 
    }
}