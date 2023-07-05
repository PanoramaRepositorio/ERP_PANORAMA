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
    public partial class frmRepPedidoVendedorAsesoria : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReportePedidoVendedorAsesoriaBE> mLista = new List<ReportePedidoVendedorAsesoriaBE>();

        #endregion

        #region "Eventos"

        public frmRepPedidoVendedorAsesoria()
        {
            InitializeComponent();
        }

        private void frmRepPedidoVendedorAsesoria_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            deFechaDesde.Focus();
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

                if (optDetalle.Checked == true)
                {
                    List<ReportePedidoVendedorAsesoriaBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorAsesoriaBL().Listado(Parametros.intPersonaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorAsesoria(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optResumen.Checked == true)
                {
                    List<ReportePedidoVendedorAsesoriaBE> lstReporte = null;
                    lstReporte = new ReportePedidoVendedorAsesoriaBL().Listado(Parametros.intPersonaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoVendedorAsesoria(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optSueldo.Checked == true)
                {
                    int IdVendedor = 0;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerSupervisorVentasPiso || Parametros.intPerfilId == Parametros.intSupervisoraVentaPisoDiseno || Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno || Parametros.intPerfilId == Parametros.intPerGerenteComercial)
                            IdVendedor = 0;
                        else
                            IdVendedor = frmAutoriza.IdPersona;

                        List<ReportePedidoVendedorAsesoriaBE> lstReporte = null;
                        lstReporte = new ReportePedidoVendedorAsesoriaBL().Listado(IdVendedor, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptPedidoVendedorAsesoria(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 2);
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
            int IdVendedor = 0;
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" ||Parametros.intPerfilId == Parametros.intPerJefeRRHH)
                    IdVendedor = 0;
                else
                    IdVendedor = frmAutoriza.IdPersona;

                Cargar();

                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoReporteVentaSueldoAsesoria";
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ReportePedidoVendedorAsesoriaBL().Listado(0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcReporteVenta.DataSource = mLista;
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



                //if (Convert.ToInt32(cboMes.EditValue) == 3)
                //    deFechaDesde.EditValue = Convert.ToDateTime("28/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);

                //if (Convert.ToInt32(cboMes.EditValue) == 1)
                //    deFechaDesde.EditValue = Convert.ToDateTime("29/12/" + (Parametros.intPeriodo - 1));
                //else
                //    deFechaDesde.EditValue = Convert.ToDateTime("29/" + Convert.ToString(Convert.ToInt32(cboMes.EditValue) - 1) + "/" + Parametros.intPeriodo);
            }

            deFechaHasta.EditValue = Convert.ToDateTime("28/" + Convert.ToInt32(cboMes.EditValue) + "/" + Parametros.intPeriodo);
        }

    }
}