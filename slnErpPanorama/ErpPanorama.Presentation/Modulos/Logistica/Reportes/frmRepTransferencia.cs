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

namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    public partial class frmRepTransferencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"
            
        public frmRepTransferencia()
        {
            InitializeComponent();
        }

        private void frmRepTransferencia_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaAlmacenSalida(Parametros.intEmpresaId), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMovTransferencia;
            BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            deFechaDesde.Focus();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdMotivo = 0;
                int IdAlmacenOrigen = 0;
                int IdAlmacenDestino = 0;
                bool Recibido = true;

                if (chkRecibido.Checked == true) 
                    Recibido = false;


                if (chkMotivo.Checked == true) IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                if (chkAlmacenOrigen.Checked == true) IdAlmacenOrigen = Convert.ToInt32(cboAlmacen.EditValue);
                if (chkAlmacenDestino.Checked == true) IdAlmacenDestino = Convert.ToInt32(cboAlmacenDestino.EditValue);

                if (chkResumen.Checked == true)
                {
                    List<ReporteMovimientoAlmacenTransferenciaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoAlmacenTransferenciaBL().ListadoResumen(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdAlmacenOrigen, IdAlmacenDestino, Recibido, IdMotivo, 1);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptMovimientoAlmacenTransferencia(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    List<ReporteMovimientoAlmacenTransferenciaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoAlmacenTransferenciaBL().Listado(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), IdAlmacenOrigen, IdAlmacenDestino, Recibido, IdMotivo, 0);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptMovimientoAlmacenTransferencia(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),0);
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

        private void cboAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboAlmacenDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void chkAlmacenOrigen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlmacenOrigen.Checked == false)
            {
                cboAlmacen.Enabled = false;
            }
            else
            {
                cboAlmacen.Enabled = true;
            }
        }

        private void chkAlmacenDestino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlmacenDestino.Checked == false)
            {
                cboAlmacenDestino.Enabled = false;
                //cboAlmacenDestino.Properties.ReadOnly = true;
            }
            else
            {
                cboAlmacenDestino.Enabled = true;
                //cboAlmacenDestino.Properties.ReadOnly = false;
            }
        }

        private void chkMotivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMotivo.Checked == false)
            {
                cboMotivo.Enabled = false;
                //cboMotivo.Properties.ReadOnly = true;
            }
            else
            {
                cboMotivo.Enabled = true;
                //cboMotivo.Properties.ReadOnly = false;
            }
        }

        #endregion

        #region "Metodos"

        #endregion

    }
}