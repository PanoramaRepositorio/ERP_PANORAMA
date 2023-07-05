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
    public partial class frmRepPedidoPreventa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReportePedidoPreventaBE> mLista = new List<ReportePedidoPreventaBE>();

        #endregion

        #region "Eventos"
        public frmRepPedidoPreventa()
        {
            InitializeComponent();
        }

        private void frmRepPedidoPreventa_Load(object sender, EventArgs e)
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

                if (optCodigo.Checked == true)
                {

                    List<ReportePedidoPreventaDetalleBE> lstReporte = null;
                    lstReporte = new ReportePedidoPreventaDetalleBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptConsolidadoPedidoPreventa(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optPedido.Checked == true)
                { 
                    List<ReportePedidoPreventaBE> lstReporte = null;
                    lstReporte = new ReportePedidoPreventaBL().Listado(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptPedidoPreventa(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),0);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (optPedidoCodigo.Checked == true)
                {
                    XtraMessageBox.Show("Opción No disponible, Solo exportar a excel", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //List<ReportePedidoPreventaBE> lstReporte = null;
                    //lstReporte = new ReportePedidoPreventaBL().ListadoPedidoCodigo(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    //if (lstReporte != null)
                    //{
                    //    if (lstReporte.Count > 0)
                    //    {
                    //        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                    //        objRptKardexBulto.VerRptPedidoPreventa(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),1);
                    //        objRptKardexBulto.ShowDialog();
                    //    }
                    //    else
                    //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
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
            if (optPedidoCodigo.Checked == true)
            {
                Cargar();
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoPedidoCodigoPreventa";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    gvReportePedidoCodigo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                }
            }
            else
            {
                XtraMessageBox.Show("No hay formato de Excel para este reporte", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ReportePedidoPreventaBL().ListadoPedidoCodigo(Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcReportePedidoCodigo.DataSource = mLista;
        }

        #endregion

    }
}