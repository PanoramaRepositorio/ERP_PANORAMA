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

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegAutoServicioDetalleOutlet : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public DocumentoVentaDetalleBE oBE;
        public int IdTipoCliente { get; set; }
        public int IdClasificacionCliente { get; set; }

        public int intCorrelativo = 0;

        public int IdDocumentoVenta = 0;
        public int IdDocumentoVentaDetalle = 0;
        public int IdKardex = 0;

        public int IdProducto = 0;
        public int IdProductoArmado = 0;
        public int IdLineaProducto = 0;
        public int Stock = 0;
        public decimal PorcentajeDescuentoInicial = 0;
        public int IdMoneda = 0;

        public bool bNuevo = true;
        public bool bDescuentoCumpleanio = false;

        #endregion

        #region "Eventos"

        public frmRegAutoServicioDetalleOutlet()
        {
            InitializeComponent();
        }

        private void frmRegAutoServicioDetalleOutlet_Load(object sender, EventArgs e)
        {
            if (IdMoneda == Parametros.intSoles)
            {
                lblMoneda.Text = "Nuevos Soles S/";
            }
            else
            {
                lblMoneda.Text = "Dolares Americanos US$.";
            }

            CargarDescuentoClienteFinal();

            txtCodigo.Focus();
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Focus();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Focus();
            }
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
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmOutlet, txtCodigo.Text.Trim());
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                IdProductoArmado = pProductoBE.IdProductoArmado;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                pProductoBE.Descuento = pProductoBE.DescuentoOutlet; //Conversion a Outlet

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

                                Stock = pProductoBE.Cantidad;
                            }
                            else
                            {
                                frmBusProductoStockOutlet objBusProducto = new frmBusProductoStockOutlet();
                                objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                                objBusProducto.IdTienda = Parametros.intTiendaId;
                                objBusProducto.IdAlmacen = Parametros.intAlmOutlet;
                                objBusProducto.ShowDialog();
                                if (objBusProducto.pProductoBE != null)
                                {
                                    IdProducto = objBusProducto.pProductoBE.IdProducto;
                                    IdProductoArmado = objBusProducto.pProductoBE.IdProductoArmado;
                                    IdLineaProducto = objBusProducto.pProductoBE.IdLineaProducto;
                                    txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                    txtCantidad.EditValue = 1;
                                    objBusProducto.pProductoBE.Descuento = objBusProducto.pProductoBE.DescuentoOutlet; //Conversion a Outlet

                                    if (IdMoneda == Parametros.intSoles)
                                    {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCDSoles; ;
                                            txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCD;
                                            txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }

                                    Stock = objBusProducto.pProductoBE.Cantidad;
                                }
                            }
                        }

                        if (optHangTag.Checked)
                        {
                            StockBE pProductoBE = null;

                            if (txtCodigo.Text.Trim().Count() > 5)
                            {
                                pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmOutlet, txtCodigo.Text.Trim());
                            }
                            else
                            {
                                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmOutlet, Convert.ToInt32(txtCodigo.Text.Trim()));
                            }
                            #region "HangTag"

                            //StockBE pProductoBE = null;
                            //pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmOutlet, Convert.ToInt32(txtCodigo.Text.Trim()));
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                IdProductoArmado = pProductoBE.IdProductoArmado;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                pProductoBE.Descuento = pProductoBE.DescuentoOutlet; //Conversion a Outlet

                                if (IdMoneda == Parametros.intSoles)
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    {

                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                        txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioCDSoles; ;
                                        txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }
                                else
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioAB;
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
                            }

                            Stock = pProductoBE.Cantidad;

                            #endregion

                        }

                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("El producto no está disponible en OUTLET, Verificar Stock", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditaPrecio_Click(object sender, EventArgs e)
        {
            //if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "mtapia" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "pmoscaiza")
            //{
            frmModificaPrecio objModificaPrecio = new frmModificaPrecio();
            objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            objModificaPrecio.Descuento = Convert.ToDecimal(txtDescuento.Text);
            objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            objModificaPrecio.ShowDialog();

            bNuevo = false;
            txtPrecioUnitario.EditValue = objModificaPrecio.PrecioUnitario;
            txtDescuento.EditValue = objModificaPrecio.Descuento;
            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            //}
            //else
            //{
            //    XtraMessageBox.Show("Ud. no tiene los permisos para esta operación..consulte con su supervisora de ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0)
            {
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //btnAceptar.Focus();
                txtCantidad.Select();
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

                //if (IdTipoCliente == Parametros.intTipClienteFinal)
                //{
                //    if (bNuevo)
                //    {
                //        CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text));
                //    }
                //}

                oBE = new DocumentoVentaDetalleBE();
                oBE.IdProducto = IdProducto;
                oBE.IdLineaProducto = IdLineaProducto;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.IdDocumentoVenta = IdDocumentoVenta;
                oBE.IdDocumentoVentaDetalle = IdDocumentoVentaDetalle;
                oBE.Item = intCorrelativo;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                oBE.CantidadAnt = Convert.ToInt32(txtCantidad.EditValue);
                oBE.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.EditValue);
                oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                oBE.Descuento = 0;
                oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.EditValue);
                oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.EditValue);
                oBE.IdKardex = IdKardex;
                oBE.FlagRegalo = false;
                oBE.PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.EditValue);
                oBE.IdProductoArmado = IdProductoArmado;

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

        #endregion

        #region "Metodos"

        private void CargarDescuentoClienteFinal()
        {
            mListaDescuentoClienteFinal = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);
        }

        private void CalculaDescuentoClienteFinal(int IdProducto, int Cantidad)
        {
            try
            {
                decimal decDescuento = 0;
                decimal decPrecioAB = 0;
                decimal decPrecioCD = 0;
                decimal decDescuentoOrigen = 0;

                //Traemos el precio AB del producto seleccionado
                StockBE objE_Stock = null;
                objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                if (objE_Stock != null)
                {
                    decDescuentoOrigen = objE_Stock.Descuento;
                    //if (decDescuentoOrigen == 0)
                    //{
                    foreach (var item in mListaDescuentoClienteFinal)
                    {
                        if (Cantidad >= item.CantidadMinima && Cantidad <= item.CantidadMaxima)
                        {
                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD)
                            {
                                if (IdMoneda == Parametros.intSoles)

                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                txtPrecioUnitario.EditValue = decPrecioCD;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    else
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = item.PorDescuento + 10;
                                    else
                                        txtDescuento.EditValue = item.PorDescuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)

                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                txtPrecioUnitario.EditValue = decPrecioCD;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    else
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = item.PorDescuento + 10;
                                    else
                                        txtDescuento.EditValue = item.PorDescuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioAB && item.PorDescuento == 0)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioAB = objE_Stock.PrecioABSoles;
                                else
                                    decPrecioAB = objE_Stock.PrecioAB;

                                txtPrecioUnitario.EditValue = decPrecioAB;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    else
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = item.PorDescuento + 10;
                                    else
                                        txtDescuento.EditValue = item.PorDescuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }

                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioAB && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioAB = objE_Stock.PrecioABSoles;
                                else
                                    decPrecioAB = objE_Stock.PrecioAB;

                                txtPrecioUnitario.EditValue = decPrecioAB;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    else
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = item.PorDescuento + 10;
                                    else
                                        txtDescuento.EditValue = item.PorDescuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }

                            }

                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)

                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                txtPrecioUnitario.EditValue = decPrecioCD;
                                decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    else
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    if (bDescuentoCumpleanio)
                                        txtDescuento.EditValue = item.PorDescuento + 10;
                                    else
                                        txtDescuento.EditValue = item.PorDescuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }

                            }
                        }
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtPrecioVenta_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0 )
            {
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnAceptar.Focus();
            }
        }


    }
}