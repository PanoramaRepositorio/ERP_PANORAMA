using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    public partial class frmConFacturaCompraVSVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();
        //List<ReporteListadoCompraBE> mListaFactura = new List<ReporteListadoCompraBE>();
        private int IdProducto = 0;

        #endregion

        #region "Eventos"

        public frmConFacturaCompraVSVenta()
        {
            InitializeComponent();
        }

        private void frmConFacturaCompraVSVenta_Load(object sender, EventArgs e)
        {
            //deDesde.EditValue = DateTime.Now;
            deDesde.EditValue = "01/01/"+ Parametros.intPeriodo;
            deHasta.EditValue = DateTime.Now;

            if(Parametros.intPerfilId != Parametros.intPerAdministrador)
            {
                gridColumn6.Visible = false;
            }
        }


        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtCodigo.Text.Length > 0)
            //    {
            //        frmBusProducto objBusProducto = new frmBusProducto();
            //        objBusProducto.pDescripcion = txtCodigo.Text.Trim();
            //        objBusProducto.ShowDialog();
            //        if (objBusProducto.pProductoBE != null)
            //        {
            //            IdProducto = objBusProducto.pProductoBE.IdProducto;
            //            txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
            //            txtNombreProducto.Text = objBusProducto.pProductoBE.NombreProducto;
            //            txtUnidadMedida.Text = objBusProducto.pProductoBE.Abreviatura;
            //            txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
            //        }
            //        btnConsultar.Focus();
            //    }
            //}
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
                    txtUnidadMedida.Text = frm.pProductoBE.Abreviatura;
                    txtDescuento.EditValue = frm.pProductoBE.Descuento;
                }

                btnConsultar.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdProducto == 0)
            {
                XtraMessageBox.Show("Debe ingresar un código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cargar();
            CargarFacturaCompra();

            

        }

        private void btnVerFoto_Click(object sender, EventArgs e)
        {
            if (IdProducto > 0)
            {
                frmVerFotoProducto objfrmVerfoto = new frmVerFotoProducto();
                objfrmVerfoto.IdProducto = IdProducto;
                objfrmVerfoto.Show();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                optCodigo.Checked = true;
                txtCodigo.Select();
            }
            if (keyData == Keys.F6)
            {
                optHangTag.Checked = true;
                txtCodigo.Select();
                //txtCodigo.SelectAll();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gcFacturaCompra_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    if (optCodigo.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        int Resultado = 0; //add 240616
                        Resultado = new ProductoBL().SeleccionaBusquedaCount(txtCodigo.Text.Trim());

                        if (Resultado == 0)
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigo.SelectAll();
                            return;
                        }
                        if (Resultado == 1)
                        {
                            
                            ProductoBE objE_Producto2 = null;
                            objE_Producto2 = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                            objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objE_Producto2.CodigoProveedor);
                        }
                        else
                        {
                            frmBusProducto objBusProducto = new frmBusProducto();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                            }
                            else
                            {
                                txtCodigo.Select();
                                return;
                            }

                        }

                        //ProductoBE objE_Producto = null;
                        //objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtNombreProducto.Text = objE_Producto.NombreProducto;
                            txtUnidadMedida.Text = objE_Producto.Abreviatura;
                            txtDescuento.EditValue = objE_Producto.Descuento;

                            //btnConsultar.Focus();
                            txtCodigo.SelectAll();

                            
                            Cargar();
                            CargarFacturaCompra();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    //Hang Tag

                    if (optHangTag.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        if (txtCodigo.Text.Trim().Length > 6)
                            //objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            objE_Producto = new ProductoBL().SeleccionaCodigoBarra(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                        else
                            objE_Producto = new ProductoBL().SeleccionaID(Parametros.intEmpresaId, Parametros.intTiendaId, Convert.ToInt32(txtCodigo.Text.Trim()));
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtNombreProducto.Text = objE_Producto.NombreProducto;
                            txtUnidadMedida.Text = objE_Producto.Abreviatura;
                            txtDescuento.EditValue = objE_Producto.Descuento;

                            //btnConsultar.Focus();
                            txtCodigo.SelectAll();
                            Cargar();
                            CargarFacturaCompra();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Select();
                txtCodigo.SelectAll();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Select();
                txtCodigo.SelectAll();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DocumentoVentaBL().ListaProducto(IdProducto, deDesde.DateTime, deHasta.DateTime,0);
            gcDocumentoVenta.DataSource = mLista;

            CalcularTotalDocumentoVenta();
        }

        private void CargarFacturaCompra()
        {
            List<ReporteListadoCompraBE> lstReporteFactura = null;
            lstReporteFactura = new ReporteListadoCompraBL().Listado(Parametros.intEmpresaId, IdProducto, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcFacturaCompra.DataSource = lstReporteFactura;
            CalcularTotalDocumentoCompra();
            txtDiferencia.EditValue = Convert.ToDecimal(txtCantidadCompra.EditValue) - Convert.ToDecimal(txtTotalCantidad.EditValue);
        }


        private void CalcularTotalDocumentoVenta()
        {
            try
            {
                decimal decTotal = 0;
                int decCantidad = 0;

                for (int i = 0; i < gvDocumentoVenta.RowCount; i++)
                {
                    decCantidad = decCantidad + Convert.ToInt32(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Cantidad"])));
                    decTotal = decTotal + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Total"])));
                }
                txtTotalCantidad.EditValue = decCantidad;
                txtTotalVenta.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalcularTotalDocumentoCompra()
        {
            try
            {
                decimal decTotal = 0;
                int decCantidad = 0;

                for (int i = 0; i < gvFacturaCompra.RowCount; i++)
                {
                    decCantidad = decCantidad + Convert.ToInt32(gvFacturaCompra.GetRowCellValue(i, (gvFacturaCompra.Columns["Cantidad"])));
                    decTotal = decTotal + Convert.ToDecimal(gvFacturaCompra.GetRowCellValue(i, (gvFacturaCompra.Columns["SubTotal"])));
                }
                txtCantidadCompra.EditValue = decCantidad;
                txtTotalCompra.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}