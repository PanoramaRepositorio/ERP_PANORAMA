using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Reportes
{
    public partial class frmRepListadoCompras : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<KardexBE> mLista = new List<KardexBE>();

        private int IdProducto = 0;

        #endregion

        #region "Eventos"

        public frmRepListadoCompras()
        {
            InitializeComponent();
        }

        private void frmRepListadoCompras_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                if (objE_Producto != null)
                {
                    IdProducto = objE_Producto.IdProducto;
                    txtCodigo.Text = objE_Producto.CodigoProveedor;
                    txtNombreProducto.Text = objE_Producto.NombreProducto;
                    deFechaDesde.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;
                }

                deFechaDesde.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (txtCodigo.Text.ToString().Trim() == "")
                    IdProducto = 0;

                List<ReporteListadoCompraBE> lstReporte = null;
                lstReporte = new ReporteListadoCompraBL().Listado(Parametros.intEmpresaId, IdProducto, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCompras = new RptVistaReportes();
                        objRptCompras.VerRptListadoCompra(lstReporte, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                        objRptCompras.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el filtro seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #endregion

        #region "Metodos"

        #endregion


        
    }
}