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
    public partial class frmRegNovioRegaloDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public NovioRegaloDetalleBE oBE;
        public int IdTipoCliente { get; set; }
        public int IdClasificacionCliente { get; set; }
        public int intCorrelativo = 0;

        public int IdNovioRegalo = 0;
        public int IdNovioRegaloDetalle = 0;
        public int IdKardex = 0;

        public int IdProducto = 0;
        public int IdLineaProducto = 0;
        public int Stock = 0;
        public decimal PorcentajeDescuentoInicial = 0;
        public int IdMoneda = 0;
        public bool bFlagEscala = false;
        public bool bNuevo = true;

        #endregion

        #region "Eventos"
        public frmRegNovioRegaloDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmRegNovioRegaloDetalleEdit_Load(object sender, EventArgs e)
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

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    if (optCodigo.Checked)
                    {
                        frmBusProductoStock objBusProducto = new frmBusProductoStock();
                        objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                        objBusProducto.IdTienda = Parametros.intTiendaUcayali;
                        objBusProducto.IdAlmacen = 1;//Parametros.intAlmCentralUcayali;
                        objBusProducto.ShowDialog();
                        if (objBusProducto.pProductoBE != null)
                        {
                            IdProducto = objBusProducto.pProductoBE.IdProducto;
                            IdLineaProducto = objBusProducto.pProductoBE.IdLineaProducto;
                            bFlagEscala = objBusProducto.pProductoBE.FlagEscala;
                            txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                            txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                            txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                            txtCantidad.EditValue = 1;
                            if (IdMoneda == Parametros.intSoles)
                            {
                                if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                {
                                    txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioABSoles;
                                    if (objBusProducto.pProductoBE.FlagDescuentoAB)
                                        txtDescuento.EditValue = objBusProducto.pProductoBE.DescuentoAB;
                                    else
                                        //txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                        txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento + Parametros.dmlDescuentoMayoristaExtra;//add  apr 4, 2015
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCDSoles;
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
                                    if (objBusProducto.pProductoBE.FlagDescuentoAB)
                                        txtDescuento.EditValue = objBusProducto.pProductoBE.DescuentoAB;
                                    else
                                        //txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                        txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento + Parametros.dmlDescuentoMayoristaExtra;//add  apr 4, 2015
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
                            }

                            Stock = objBusProducto.pProductoBE.Cantidad;
                            txtCantidad.SelectAll();
                            txtCantidad.Focus();

                        }
                    }
                    else
                    {
                        StockBE pProductoBE = null;

                        if (txtCodigo.Text.Trim().Count() > 6)
                        {
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaUcayali, 1, txtCodigo.Text.Trim());
                        }
                        else
                        {
                            pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaUcayali, 1, Convert.ToInt32(txtCodigo.Text.Trim()));
                        }
                        if (pProductoBE != null)
                        {
                            IdProducto = pProductoBE.IdProducto;
                            IdLineaProducto = pProductoBE.IdLineaProducto;
                            bFlagEscala = pProductoBE.FlagEscala;
                            txtCodigo.Text = pProductoBE.CodigoProveedor;
                            txtProducto.Text = pProductoBE.NombreProducto;
                            txtUM.Text = pProductoBE.Abreviatura;
                            txtCantidad.EditValue = 1;
                            if (IdMoneda == Parametros.intSoles)
                            {
                                if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                {
                                    txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                    if (pProductoBE.FlagDescuentoAB)
                                        txtDescuento.EditValue = pProductoBE.DescuentoAB;
                                    else
                                        //txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtDescuento.EditValue = pProductoBE.Descuento + Parametros.dmlDescuentoMayoristaExtra;//add  apr 4, 2015
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
                                    if (pProductoBE.FlagDescuentoAB)
                                        txtDescuento.EditValue = pProductoBE.DescuentoAB;
                                    else
                                        //txtDescuento.EditValue = pProductoBE.Descuento;
                                        txtDescuento.EditValue = pProductoBE.Descuento + Parametros.dmlDescuentoMayoristaExtra;//add  apr 4, 2015
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

                            Stock = pProductoBE.Cantidad;
                            txtCantidad.SelectAll();
                            txtCantidad.Focus();

                        }


                    }

                }


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
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtObservacion.Focus();
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //e.Handled = true;
                //SendKeys.Send("{TAB}");
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

                //if (IdTipoCliente == Parametros.intTipClienteFinal)
                if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack && IdProducto != Parametros.intIdProductoReparacion) //Add
                {
                    if (bNuevo)
                    {
                        CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text));
                    }
                }

                oBE = new NovioRegaloDetalleBE();
                oBE.IdProducto = IdProducto;
                oBE.IdLineaProducto = IdLineaProducto;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.IdNovioRegalo = IdNovioRegalo;
                oBE.IdNovioRegaloDetalle = IdNovioRegaloDetalle;
                oBE.Item = intCorrelativo;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.Text);
                oBE.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                oBE.Descuento = 0;
                oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                oBE.Observacion = txtObservacion.Text;
                oBE.FlagComprado = chkComprado.Checked;


                #region 2022
                if (IdTipoCliente == Parametros.intTipClienteFinal)
                {
                    decimal Descuento = 0;
                    int Cantidad = Convert.ToInt32(txtCantidad.Text);
                    PromocionTemporalDetalleBE objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Parametros.intContado, Parametros.intTiendaId, 0, IdProducto);
                    if (objE_PromocionTemporal != null)
                    {
                        Descuento = objE_PromocionTemporal.Descuento;
                    }
                    else
                    {
                        if (bFlagEscala)
                        {
                            var var_DescFinalMin = mListaDescuentoClienteFinal.Where(x =>
                            x.IdClasificacionCliente == IdClasificacionCliente &&
                            x.CantidadMaxima >= Cantidad).ToList().Min(x => x.PorDescuento);

                            if (var_DescFinalMin != null)
                            {
                                Descuento = var_DescFinalMin;
                            }
                        }
                    }

                    txtDescuento.EditValue = Descuento;
                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                    oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                    oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                }
                
                #endregion


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

        private void btnCalcula_Click(object sender, EventArgs e)
        {
            //if (IdClasificacionCliente != Parametros.intPublicitario)
            //{
            //    XtraMessageBox.Show("Esta opción es aplicable para clientes publicitarios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            frmModificaPrecioPublicitario objModificaPrecio = new frmModificaPrecioPublicitario();
            objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            objModificaPrecio.ShowDialog();

            bNuevo = false;
            txtPrecioUnitario.EditValue = objModificaPrecio.PrecioUnitario;
            txtDescuento.EditValue = 0;
            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

            btnAceptar.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) optCodigo.Checked = true;
            if (keyData == Keys.F6) optHangTag.Checked = true;

            return base.ProcessCmdKey(ref msg, keyData);
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }





        #endregion

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

    }
}