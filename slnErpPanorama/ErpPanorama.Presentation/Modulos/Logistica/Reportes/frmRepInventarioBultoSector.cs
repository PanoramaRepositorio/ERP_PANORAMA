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
    public partial class frmRepInventarioBultoSector : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRepInventarioBultoSector()
        {
            InitializeComponent();
        }

        private void frmRepInventarioBultoSector_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos), "DescSector", "IdSector", true);
            rdgSector.EditValue = 1;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            

            try
            {
                Cursor = Cursors.WaitCursor;

                int TipoReporte = 1;
                TipoReporte = Convert.ToInt32(rdgSector.EditValue);

                if (TipoReporte ==1)
                {
                    List<ReporteInventarioBultoSectorBE> lstReporte = null;
                    lstReporte = new ReporteInventarioBultoSectorBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboSector.EditValue)); //Exacto

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptInventarioBultoSector(lstReporte);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (TipoReporte == 2)
                {
                    List<ReporteInventarioBultoSectorStockBE> lstReporte = null;
                    lstReporte = new ReporteInventarioBultoSectorStockBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboSector.EditValue)); //Exacto

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptInventarioBultoSectorStock(lstReporte);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (TipoReporte == 3)
                {
                    List<ReporteInventarioBultoSectorBE> lstReporte = null;
                    lstReporte = new ReporteInventarioBultoSectorBL().ListadoRecibido(Parametros.intEmpresaId, Convert.ToInt32(cboSector.EditValue)); //Exacto

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptInventarioBultoSectorRecibido(lstReporte);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                { 
                    //vs Bultos vs Anaqueles
                    List<ReporteInventarioBultoSectorBE> lstReporte = null;
                    lstReporte = new ReporteInventarioBultoSectorBL().ListadoBultoAnaqueles(Parametros.intEmpresaId);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptInventarioBultoAnaqueles(lstReporte);
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