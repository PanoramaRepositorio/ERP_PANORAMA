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
    public partial class frmRepVentaProductoDias : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<ProductoBE> mLista = new List<ProductoBE>();
        private string  IdProducto = "";
        #endregion

        #region "Eventos"

        public frmRepVentaProductoDias()
        {
            InitializeComponent();
        }

        private void frmRepVentaProductoDias_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboFamilia, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            cboLinea.EditValue = Parametros.intNinguno;

            Cargar();
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
            IdProducto = "";


            if (optCodigo.Checked == true)
            {
                cboLinea.EditValue = Parametros.intNinguno;
                CargarActivos();
                if (!ValidarIngreso())
                {
                    for (int i = 0; i < gvProducto.RowCount; i++)
                    {
                        IdProducto = IdProducto + "," + gvProducto.GetRowCellValue(i, "IdProducto").ToString();
                    }
                }
                else {
                    return;
                }
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                //if (chkResumen.Checked == true)
                //{
                    int IdFamilia = 0;
                    int IdLinea = 0;
                    //if (optFamilia.Checked == true) IdFamilia = Convert.ToInt32(cboFamilia.EditValue);
                    //if (optLinea.Checked == true) IdLinea = Convert.ToInt32(cboLinea.EditValue);

                    List<ReporteVentaProductoBE> lstReporte = null;
                    lstReporte = new ReporteVentaProductoBL().ListadoDiasResumen(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(txtDiasVendidos.EditValue), IdLinea, IdFamilia);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                            objRptKardexBulto.VerRptVentaProductoDias(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 1);
                            objRptKardexBulto.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                //}
                //else
                //{
                //    List<ReporteVentaProductoBE> lstReporte = null;
                //    lstReporte = new ReporteVentaProductoBL().ListadoDias(Parametros.intEmpresaId,Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(txtDiasVendidos.EditValue), Convert.ToInt32(cboLinea.EditValue), IdProducto);

                //    if (lstReporte != null)
                //    {
                //        if (lstReporte.Count > 0)
                //        {
                //            RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                //            objRptKardexBulto.VerRptVentaProductoDias(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString(), 0);
                //            objRptKardexBulto.ShowDialog();
                //        }
                //        else
                //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }               
                //}



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

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

    #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ProductoBL().ListaTodosBusqueda();
            gcProducto.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcProducto.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        //Cargar activos
        private void CargarActivos()
        {
            gcProducto.DataSource = mLista.Where(obj =>
                                                   obj.FlagEstado.Equals(true)).ToList();
        }

        private void CargarReporte(int Num)
        {
            int IdFamilia = 0;
            int IdLinea = 0;
            if (optFamilia.Checked == true) IdFamilia = Convert.ToInt32(cboFamilia.EditValue);
            if (optLinea.Checked == true) IdLinea = Convert.ToInt32(cboLinea.EditValue);

            if (Num == 0)
            {
                List<ReporteVentaProductoBE> lstReporte = null;
                lstReporte = new ReporteVentaProductoBL().ListadoDias(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(txtDiasVendidos.EditValue), Convert.ToInt32(cboLinea.EditValue), IdProducto);
                gcReporte.DataSource = lstReporte;
            }
            else if (Num == 1)
            {
                List<ReporteVentaProductoBE> lstReporte = null;
                lstReporte = new ReporteVentaProductoBL().ListadoDiasResumen(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToInt32(txtDiasVendidos.EditValue), IdLinea ,IdFamilia);
                gcReporteResumen.DataSource = lstReporte;
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvProducto.RowCount == 0)
            {
                XtraMessageBox.Show("Seleccione un Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }
        
        #endregion

        private void chkLinea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLinea.Checked == true)
            {
                cboLinea.Enabled = true;
                txtDescripcion.Enabled = false;
                gcProducto.Enabled = false;
                chkResumen.Enabled = true;
                chkResumen.Checked = false;
            }
            else {
                cboLinea.Enabled = false;
                txtDescripcion.Enabled = true;
                gcProducto.Enabled = true;

                chkResumen.Enabled = false;
                chkResumen.Checked = false;
            }

        }

        private void chkResumen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (chkResumen.Checked == true)
            {
                CargarReporte(1);
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoVentaProductoResumen";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    gvReporteResumen.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                }
            }
            else
            {
                CargarReporte(0);

                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoVentaProducto";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    gvReporte.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                }
            }
            
            

        }



    }
}