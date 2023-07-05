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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManComboPromocionalDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public ComboDetalleBE oBE;
        //public DocumentoVentaDetalleBE oBE;

        public int IdCombo = 0;
        public int IdComboDetalle = 0;
        
        public int IdProducto = 0;
        public int IdMoneda = Parametros.intSoles;
        
        #endregion

        #region "Eventos"

        public frmManComboPromocionalDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmManComboPromocionalDetalleEdit_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            txtDescuento.Text = String.Format("{0:n4}", txtDescuento.Text);
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCodigo.Text.Length > 0)
                    {
                        if (optCodigo.Checked)
                        {
                            StockBE pProductoBE = null;
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmTienda, txtCodigo.Text.Trim());
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                if (IdMoneda == Parametros.intSoles)
                                {
                                    txtPrecioUnitario.EditValue = pProductoBE.PrecioCDSoles; ;
                                    txtDescuento.EditValue = pProductoBE.Descuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }
                            else
                            {
                                frmBusProductoStock objBusProducto = new frmBusProductoStock();
                                objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                                objBusProducto.IdTienda = Parametros.intTiendaId;
                                objBusProducto.IdAlmacen = Parametros.intAlmTienda;
                                objBusProducto.ShowDialog();
                                if (objBusProducto.pProductoBE != null)
                                {
                                    IdProducto = objBusProducto.pProductoBE.IdProducto;
                                    txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                    txtCantidad.EditValue = 1;
                                    if (IdMoneda == Parametros.intSoles)
                                    {
                                        txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCDSoles; ;
                                        txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }
                            }
                        }

                        if (optHangTag.Checked)
                        {
                            StockBE pProductoBE = null;

                            if (txtCodigo.Text.Trim().Count() > 6)
                            {
                                pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmTienda, txtCodigo.Text.Trim());
                            }
                            else
                            {
                                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, Convert.ToInt32(txtCodigo.Text.Trim()));
                            }
                            #region "HangTag"

                            //StockBE pProductoBE = null;
                            //pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, Convert.ToInt32(txtCodigo.Text.Trim()));
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                if (IdMoneda == Parametros.intSoles)
                                {
                                    txtPrecioUnitario.EditValue = pProductoBE.PrecioCDSoles; ;
                                    txtDescuento.EditValue = pProductoBE.Descuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtPrecioUnitario.EditValue = pProductoBE.PrecioCD;
                                    txtDescuento.EditValue = pProductoBE.Descuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }

                            #endregion

                        }

                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtPrecioUnitario.Focus();
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnAceptar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdProducto == 0)
                {
                    XtraMessageBox.Show("Seleccionar el código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.SelectAll();
                    txtCodigo.Focus();
                    return;
                }

                if (txtCodigo.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar el código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.SelectAll();
                    txtCodigo.Focus();
                    return;
                }

                if (Convert.ToInt32(txtCantidad.EditValue) == 0)
                {
                    XtraMessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }



                oBE = new ComboDetalleBE();
                oBE.IdCombo = IdCombo;
                oBE.IdComboDetalle = IdComboDetalle;
                oBE.IdProducto = IdProducto;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                oBE.Precio = Convert.ToInt32(txtPrecioUnitario.EditValue);
                oBE.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.EditValue);
                oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.EditValue);

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtDescuento_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtPrecioUnitario_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDescuento.Focus();
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }

        #endregion

        #region "Metodos"

        private void CalcularTotal()
        {
            if (Convert.ToDecimal(txtPrecioUnitario.EditValue) > 0 && Convert.ToInt32(txtCantidad.EditValue) > 0)
            {
                txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
            else
            {
                txtPrecioVenta.EditValue = 0;
                txtValorVenta.EditValue = 0;
            }

        }

        #endregion

        private void txtValorVenta_EditValueChanged(object sender, EventArgs e)
        {
            //decimal TotalOriginal = 0;
            //decimal TotalConDescuento = 0;

            //decimal Descuento = 0;

            //TotalOriginal = Convert.ToDecimal(txtPrecioUnitario.Text) * Convert.ToDecimal(txtCantidad.Text);
            //TotalConDescuento = Convert.ToDecimal(txtValorVenta.Text);

            //if (TotalOriginal==0)
            //{
            //    Descuento = 0;
            //}
            //else
            //{ 
            //    Descuento =  100 - ( (TotalConDescuento * 100) / TotalOriginal) ;
            //}
            //txtPrecioVenta.Text = ((Convert.ToDecimal(Descuento) / 100) * Convert.ToDecimal(txtPrecioUnitario.Text)).ToString();

            //txtDescuento.Text = Descuento.ToString();  /// String.Format("{0:n6}", Descuento) ;
            //txtPrecioVenta.Text = String.Format("{0:n2}", Convert.ToDecimal(txtPrecioUnitario.Text)  - ( Convert.ToDecimal(txtPrecioUnitario.Text) * (Convert.ToDecimal(txtDescuento.Text)/ 100)));
        }
    }
}