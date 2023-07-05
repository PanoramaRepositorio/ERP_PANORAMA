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

namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    public partial class frmRepEstadoCuentaNumeroDias : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        #endregion

        #region "Eventos"

        public frmRepEstadoCuentaNumeroDias()
        {
            InitializeComponent();
        }

        private void frmRepEstadoCuentaNumeroDias_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            cboDias.SelectedIndex = 0;
            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionClienteFinal), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            //cboClasificacion.EditValue = Parametros.in;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int Dias = 0;
                int IdClasificacion = 0;
                int IdTipoCliente = 0;

                //-----------------------------------------------------------------------------
                DateTime fecha;
                fecha = Convert.ToDateTime((this.dateTimePicker1.Value.ToShortDateString()));

                //   MessageBox.Show("dato  " + fecha); 
                //-----------------------------------------------------------------------------

                if (cboDias.Text == "Todo")
                    Dias = 0;
                else
                    Dias = Convert.ToInt32(cboDias.Text);

                if (chkClasifica.Checked == true)
                {
                    IdClasificacion = Convert.ToInt32(cboClasificacion.EditValue);
                    IdTipoCliente = Parametros.intTipClienteFinal;
                }
                else
                {
                    IdClasificacion = 0;
                    IdTipoCliente = Parametros.intTipClienteMayorista;
                }

                List<ReporteEstadoCuentaNumeroDiasBE> lstReporte = null;
                lstReporte = new ReporteEstadoCuentaNumeroDiasBL().Listado(Parametros.intEmpresaId, Dias, IdTipoCliente, IdClasificacion, Convert.ToInt32(cboMotivo.EditValue), fecha);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptClienteCredito = new RptVistaReportes();
                        objRptClienteCredito.VerRptEstadoCuentaNumeroDias(lstReporte);
                        objRptClienteCredito.Show();
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

        private void chkClasifica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClasifica.Checked == true)
                cboClasificacion.Enabled = true;
            else cboClasificacion.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        #region "Metodos"

        #endregion


    }
}