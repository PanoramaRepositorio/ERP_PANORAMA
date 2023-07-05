using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepTarjetaIziPay : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"
        public frmRepTarjetaIziPay()
        {
            InitializeComponent();
        }

        private void frmRepTarjetaIziPay_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            deFechaDesde.Focus();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdTienda = Convert.ToInt32(cboTienda.EditValue);
                int IdCaja = Convert.ToInt32(cboCaja.EditValue);
                if (chkTodasTienda.Checked)
                {
                    IdTienda = 0;
                    chkTodasCaja.Checked = true;
                }
                else
                {
                    IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    IdCaja = Convert.ToInt32(cboCaja.EditValue);
                }


                if (chkTodasCaja.Checked) IdCaja = 0;

                List<ReporteTarjetaIziPayBE> lstReporte = null;
                lstReporte = new ReporteTarjetaIziPayBL().Listado(IdTienda, IdCaja, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptTarjetaIziPay(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
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
        
        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);

        }

        private void chkCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodasCaja.Checked)
            {
                cboCaja.Enabled = false;
            }
            else
            {
                cboCaja.Enabled = true;
            }
        }

        private void chkTodasTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodasTienda.Checked)
            {
                cboCaja.Enabled = false;
                chkTodasCaja.Checked = true;
                chkTodasCaja.Enabled = false;
                cboTienda.Enabled = false;
            }
            else
            {
                cboCaja.Enabled = true;
                chkTodasCaja.Checked = false;
                chkTodasCaja.Enabled = true;
                cboTienda.Enabled = true;
            }
        }
        #endregion
        #region "Metodos"

        #endregion
    }
}