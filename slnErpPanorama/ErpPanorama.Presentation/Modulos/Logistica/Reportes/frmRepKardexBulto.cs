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
    public partial class frmRepKardexBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

         
        
        #endregion

        #region "Eventos"

        public frmRepKardexBulto()
        {
            InitializeComponent();
        }

        private void frmRepKardexBulto_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (chkBloque.Checked)
                {
                    List<ReporteInventarioBultoBE> lstReporte = null;
                    lstReporte = new ReporteInventarioBultoBL().ListadoBloque(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.DateTime.ToShortDateString())); //Exacto

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptInventarioBultoBloque(lstReporte);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    List<ReporteInventarioBultoBE> lstReporte = null;
                    lstReporte = new ReporteInventarioBultoBL().Listado(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.DateTime.ToShortDateString())); //Exacto

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptInventarioBulto(lstReporte);
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

        #endregion
      
        #region "Metodos"

        #endregion


        
    }
}