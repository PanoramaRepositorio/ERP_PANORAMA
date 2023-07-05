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
    public partial class frmRepRotacionProductos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRepRotacionProductos()
        {
            InitializeComponent();
        }

        private void frmRepRotacionProductos_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);            

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

                int IdTienda = 0;
                if (!chkTiendaTodo.Checked)
                    IdTienda = Convert.ToInt32(cboTienda.EditValue);

                if (optMayor.Checked)
                {
                    if (chkResumen.Checked == false)
                    {
                        List<ReporteRotacionProductosBE> lstReporte = null;
                        lstReporte = new ReporteRotacionProductosBL().ListadoPorTienda(Parametros.intEmpresaId, IdTienda, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptRotacionProductosPorTienda2(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),0);
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (chkResumen.Checked)
                    {
                        List<ReporteRotacionProductosBE> lstReporte = null;
                        lstReporte = new ReporteRotacionProductosBL().Listado(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),0);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptRotacionProductos(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),0);
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else //Menor rotación
                {
                    if (chkResumen.Checked == false)
                    {
                        List<ReporteRotacionProductosBE> lstReporte = null;
                        lstReporte = new ReporteRotacionProductosBL().ListadoPorTienda(Parametros.intEmpresaId, IdTienda, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),1);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptRotacionProductosPorTienda(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(),1);
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (chkResumen.Checked)
                    {
                        List<ReporteRotacionProductosBE> lstReporte = null;
                        lstReporte = new ReporteRotacionProductosBL().Listado(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()),1);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                                objRptKardexBulto.VerRptRotacionProductos(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 1);
                                objRptKardexBulto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #endregion

        private void chkTiendaTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTiendaTodo.Checked == true)
            {
                cboTienda.Enabled = false;
                //chkResumen.Checked = false;
            }
            else
            {
                cboTienda.Enabled = true;
                //chkResumen.Checked = false;
            }
        }

        private void chkResumen_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkResumen.Checked == true)
            //{
            //    chkTiendaTodo.Checked = false;
            //    cboTienda.Enabled = false;
            //}
        }



        #region "Metodos"

        #endregion

        private void deFechaDesde_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void deFechaHasta_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void optMenor_CheckedChanged(object sender, EventArgs e)
        {
            //if(optMenor.Checked)
            //{
            //    deFechaHasta.EditValue = DateTime.Now;
            //    deFechaHasta.Properties.ReadOnly = true;
            //}else
            //{
            //    deFechaHasta.Properties.ReadOnly = false;
            //}
        }
    }
}