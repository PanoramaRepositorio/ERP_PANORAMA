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
    public partial class frmRepPedidoTiendaSupervisor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReportePedidoTiendaSupervisorBE> mLista = new List<ReportePedidoTiendaSupervisorBE>();

        #endregion

        #region "Eventos"

        public frmRepPedidoTiendaSupervisor()
        {
            InitializeComponent();
        }

        private void frmRepPedidoTiendaSupervisor_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            if (Parametros.intPerfilId != Parametros.intPerAdministrador)
            {
                deFechaDesde.Properties.ReadOnly = true;
                deFechaHasta.Properties.ReadOnly = true;
            }

            cboMes.Focus();
            //deFechaDesde.Focus();
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
                        //if (frmAutoriza.IdPerfil == Parametros.intPerSupervisorVentasPiso)
                            IdVendedor = frmAutoriza.IdPersona;
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador|| frmAutoriza.IdPerfil == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerGerenteComercial)
                            IdVendedor = 0;

                        List<ReportePedidoTiendaSupervisorBE> lstReporte = null;
                        lstReporte = new ReportePedidoTiendaSupervisorBL().Listado(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 2);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoTiendaSupervisor(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
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

            //int IdVendedor = 0;
            //frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //frmAutoriza.ShowDialog();

            //if (frmAutoriza.Edita)
            //{
            //    if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "mtapia" || frmAutoriza.Usuario == "pmoscaiza" || frmAutoriza.Usuario == "liliana" || frmAutoriza.Usuario == "lestrada")
            //        IdVendedor = 0;
            //    else
            //        IdVendedor = frmAutoriza.IdPersona;

            //    Cargar();

            //    string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //    string _fileName = "ListadoReporteVentaSueldoPiso";
            //    FolderBrowserDialog f = new FolderBrowserDialog();
            //    f.ShowDialog(this);
            //    if (f.SelectedPath != "")
            //    {
            //        Cursor = Cursors.AppStarting;
            //        gvReporteVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //        string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //        XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        Cursor = Cursors.Default;
            //    }

            //}


        }




        #region "Metodos"

        private void Cargar()
        {
            //mLista = new ReportePedidoVendedorJuniorSeniorBL().Listado(0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), 0);
            //gcReporteVenta.DataSource = mLista;
        }

        #endregion

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
            }

            deFechaHasta.EditValue = Convert.ToDateTime("30/" + Convert.ToInt32(cboMes.EditValue) + "/" + Parametros.intPeriodo);
        }




    }
}