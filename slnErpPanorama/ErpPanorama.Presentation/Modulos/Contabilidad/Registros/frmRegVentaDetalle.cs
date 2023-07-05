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

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    public partial class frmRegVentaDetalle : DevExpress.XtraEditors.XtraForm
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
        public int IdPedido = 0;
        public int IdPedidoDetalle = 0;
        

        public int IdProducto = 0;
        public int IdLineaProducto = 0;
        public int Stock = 0;
        public decimal PorcentajeDescuentoInicial = 0;
        public int IdMoneda = 0;

        public int IdEmpresa { get; set; }

        public bool bNuevo = true;
        
        #endregion

        #region "Eventos"

        public frmRegVentaDetalle()
        {
            InitializeComponent();
        }

        private void frmRegVentaDetalle_Load(object sender, EventArgs e)
        {
            if (IdMoneda == Parametros.intSoles)
            {
                lblMoneda.Text = "Nuevos Soles S/";
            }
            else
            {
                lblMoneda.Text = "Dolares Americanos US$.";
            }

            //CargarDescuentoClienteFinal();

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
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtCodigo.Text.Trim());
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                if (IdMoneda == Parametros.intSoles)
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioCDSoles; ;
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

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
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioCD;
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }

                                Stock = pProductoBE.Cantidad;
                            }
                            else
                            {
                                frmBusProductoStock objBusProducto = new frmBusProductoStock();
                                objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                                objBusProducto.IdTienda = Parametros.intTiendaId;
                                objBusProducto.IdAlmacen = Parametros.intAlmCentralUcayali;
                                objBusProducto.ShowDialog();
                                if (objBusProducto.pProductoBE != null)
                                {
                                    IdProducto = objBusProducto.pProductoBE.IdProducto;
                                    IdLineaProducto = objBusProducto.pProductoBE.IdLineaProducto;
                                    txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                    txtCantidad.EditValue = 1;
                                    if (IdMoneda == Parametros.intSoles)
                                    {
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioABSoles;
                                            if (IdEmpresa == Parametros.intCoronaImportadores)
                                                txtDescuento.EditValue = 0;
                                            else

                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                        else
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCDSoles;
                                            if (IdEmpresa == Parametros.intCoronaImportadores)
                                                txtDescuento.EditValue = 0;
                                            else

                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                    }
                                    else
                                    {
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioAB;
                                            if (IdEmpresa == Parametros.intCoronaImportadores)
                                                txtDescuento.EditValue = 0;
                                            else

                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                        else
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCD;
                                            if (IdEmpresa == Parametros.intCoronaImportadores)
                                                txtDescuento.EditValue = 0;
                                            else

                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                    }

                                    Stock = objBusProducto.pProductoBE.Cantidad;
                                }
                            }
                        }

                        if (optHangTag.Checked)
                        {
                            StockBE pProductoBE = null;
                            pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTiendaUcayali, Convert.ToInt32(txtCodigo.Text.Trim()));
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                if (IdMoneda == Parametros.intSoles)
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioCDSoles; ;
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

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
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioCD;
                                        if (IdEmpresa == Parametros.intCoronaImportadores)
                                            txtDescuento.EditValue = 0;
                                        else

                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }
                            }

                            Stock = pProductoBE.Cantidad;
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

        private void btnEditaPrecio_Click(object sender, EventArgs e)
        {
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
        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0)
            {
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void txtPrecioUnitario_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtPrecioUnitario.EditValue) > 0)
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtPrecioUnitario.Focus();
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //txtValorVenta.Focus();
                btnAceptar.Focus();
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //txtValorVenta.Focus();
            }
        }

        private void txtValorVenta_KeyPress(object sender, KeyPressEventArgs e)
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

                if (IdTipoCliente == Parametros.intTipClienteFinal)
                {
                    if (bNuevo)
                    {
                        CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text));
                    }
                }

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
                oBE.FlagMuestra = chkMuestra.Checked;
                if(chkMuestra.Checked)
                    oBE.IdAlmacen = 2;
                oBE.PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.EditValue);

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

        //private void CargarDescuentoClienteFinal()
        //{
        //    mListaDescuentoClienteFinal = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);
        //}

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
                objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTiendaUcayali, IdProducto);
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
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
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
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtDescuento.EditValue = decDescuento;
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
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtDescuento.EditValue = decDescuento;
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
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtDescuento.EditValue = decDescuento;
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
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtDescuento.EditValue = decDescuento;
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

        private void CalcularPrecio()
        {
            if (Convert.ToDecimal(txtPrecioUnitario.EditValue) > 0)
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

        private void btnCostoProducto_Click(object sender, EventArgs e)
        {
            FacturaCompraBE pProductoBE = null;
            pProductoBE = new FacturaCompraBL().SeleccionaProductoUltimaCompra(IdProducto);

            if (pProductoBE != null)
            {
                txtPrecioVenta.EditValue = pProductoBE.CostoUnitario;
                txtValorVenta.EditValue = pProductoBE.CostoUnitario * Convert.ToDecimal(txtCantidad.EditValue);
            }
            else { 
                XtraMessageBox.Show("El código no tiene factura de compra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarNombre_Click(object sender, EventArgs e)
        {
            txtProducto.Properties.ReadOnly = false;
        }

        private void txtDescuento_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPrecio();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtPrecioUnitario.Focus();
            }
        }
    }
}