using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Ventas.Reportes;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepClienteMayoristaVendedor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        #endregion

        #region "Eventos"

        public frmRepClienteMayoristaVendedor()
        {
            InitializeComponent();
        }

        private void frmRepClienteMayoristaVendedor_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = DateTime.Now.Year;
            deFechaDesde.EditValue = Convert.ToDateTime("01/01/" + DateTime.Now.Year.ToString());
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionCliente), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdVendedor = 0;
                if (chkVendedorTodos.Checked == false)
                {
                    IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                }

                if (chkAsociado.Checked == true && chkFormato2.Checked == false)
                {
                    List<ReporteClienteMayoristaVendedorBE> lstReporte = null;
                    lstReporte = new ReporteClienteMayoristaVendedorBL().ListadoAsociado(Parametros.intEmpresaId, IdVendedor,Convert.ToInt32(cboSituacion.EditValue) , Convert.ToInt32(txtPeriodo.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptClienteMayorista = new RptVistaReportes();
                            objRptClienteMayorista.VerRptClienteMayoristaVendedorAsociado(lstReporte, cboVendedor.Text);
                            objRptClienteMayorista.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (chkAsociado.Checked == false && chkFormato2.Checked == false)
                {
                    List<ReporteClienteMayoristaVendedorBE> lstReporte = null;
                    lstReporte = new ReporteClienteMayoristaVendedorBL().Listado(Parametros.intEmpresaId, IdVendedor, Convert.ToInt32(cboSituacion.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptClienteMayorista = new RptVistaReportes();
                            objRptClienteMayorista.VerRptClienteMayoristaVendedor(lstReporte, cboVendedor.Text);
                            objRptClienteMayorista.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (chkFormato2.Checked == true)
                {
                    List<ReporteClienteMayoristaVendedorBE> lstReporte = null;
                    lstReporte = new ReporteClienteMayoristaVendedorBL().ListadoCompra(Parametros.intEmpresaId, IdVendedor, Convert.ToInt32(cboSituacion.EditValue), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptClienteMayorista = new RptVistaReportes();
                            objRptClienteMayorista.VerRptClienteMayoristaVendedorCompra(lstReporte, cboVendedor.Text);
                            objRptClienteMayorista.ShowDialog();
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

        #endregion

        private void chkFormato2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFormato2.Checked == true)
            {
                deFechaDesde.Enabled = true;
                deFechaHasta.Enabled = true;
            }
            else
            {
                deFechaDesde.Enabled = false;
                deFechaHasta.Enabled = false;            
            }
        }

        private void chkVendedorTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVendedorTodos.Checked == true)
            {
                cboVendedor.Enabled = false;
            }else
            {
                cboVendedor.Enabled = true;
            }
        }


        #region "Metodos"

        #endregion

        
    }
}