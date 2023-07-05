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
    public partial class frmRegAutoServicioDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public DocumentoVentaDetalleBE oBE;
        public int IdTipoCliente { get; set; }
        public int IdClasificacionCliente { get; set; }
        public int IdTipoVenta = 0;
        public int intCorrelativo = 0;

        public int IdDocumentoVenta = 0;
        public int IdDocumentoVentaDetalle = 0;
        public int IdKardex = 0;

        public int IdProducto = 0;
        public int IdProductoArmado = 0;
        public int IdFamiliaProducto = 0;
        public int IdLineaProducto = 0;
        public int IdMarca = 0;
        public string DescFamiliaProducto = "";

        public int Stock = 0;
        public decimal PorcentajeDescuentoInicial = 0;
        public int IdMoneda = 0;
        public int CantidadModificada = 0;
        public int IdFormaPago = 0;

        public bool bNuevo = true;
        public bool bDescuentoCumpleanio = false;
        public bool FlagCompuesto = false;
        public bool FlagPromocion2x1 = false;
        public string DescPromocion2x1 = "";
        public bool bFlagNacional = false;
        public bool bFlagEscala = false;
        public bool bCantidadAutomatica = false;
        public int IdPromocion2 = 0;// ecm2
        public decimal DescAdicional = 0; // ecm 20220610

        #endregion

        #region "Eventos"

        public frmRegAutoServicioDetalle()
        {
            InitializeComponent();
        }

        private void frmRegAutoServicioDetalle_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            if (IdMoneda == Parametros.intSoles)
            {
                lblMoneda.Text = "Nuevos Soles S/";
            }
            else
            {
                lblMoneda.Text = "Dolares Americanos US$.";
            }

            lblDescPromocion.Text = DescPromocion2x1;

            CargarDescuentoClienteFinal();
            chkCantidadAutomatica.Checked = bCantidadAutomatica;

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

        }

        private void btnEditaPrecio_Click(object sender, EventArgs e)
        {
            frmModificaPrecioDescuento objModificaPrecio = new frmModificaPrecioDescuento();
            objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            objModificaPrecio.Descuento = Decuento_Cliente_Final(Convert.ToInt32(txtCantidad.Text)); // Convert.ToDecimal(txtDescuento.Text);
            objModificaPrecio.IdProducto = IdProducto;
            objModificaPrecio.IdLineaProducto = IdLineaProducto;
            objModificaPrecio.Origen = " - Autoservicio";
            objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            objModificaPrecio.ShowDialog();

            DescAdicional = objModificaPrecio.Descuento; // ecm 20220610
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

                if (Convert.ToInt32(txtCantidad.EditValue) <= 0)
                {
                    XtraMessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }
                ///if (IdTipoCliente == Parametros.intTipClienteFinal )
                if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack && IdProducto != Parametros.intIdProductoReparacion) //Add
                {
                    if (bNuevo)
                    {
                        CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text), IdLineaProducto);
                    }
                    else
                    {
                        int Cantidad = Convert.ToInt32(txtCantidad.EditValue); //add 240217
                        if (Cantidad != CantidadModificada)
                        {
                            if (!FlagPromocion2x1) // add 211017
                                CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text), IdLineaProducto);
                        }
                    }

                }

                //Validar Stock
                if (!Parametros.bStockNegativo)
                {
                    StockBE objE_Stock = null;
                    objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, IdProducto);

                    if (objE_Stock != null)
                    {
                        if (Convert.ToInt32(txtCantidad.EditValue) > objE_Stock.Cantidad)
                        {
                            XtraMessageBox.Show("Su Stock Actual es :" + objE_Stock.Cantidad + "\nVerificar si se abasteció correctamente.\nPara mayor infomación consultar con Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                //---------------------------------



                oBE = new DocumentoVentaDetalleBE();
                oBE.IdProducto = IdProducto;
                oBE.IdFamiliaProducto = IdFamiliaProducto;
                oBE.IdLineaProducto = IdLineaProducto;
                oBE.IdMarca = IdMarca;
                oBE.DescFamiliaProducto = DescFamiliaProducto;
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
                oBE.FlagCompuesto = FlagCompuesto;
                oBE.Descuento = 0;
                oBE.ObsEscala = "";
                oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.EditValue);
                oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.EditValue);
                oBE.IdKardex = IdKardex;
                oBE.FlagRegalo = false;
                oBE.FlagNacional = bFlagNacional;
                oBE.FlagEscala = bFlagEscala;
                oBE.DescPromocion = DescPromocion2x1;
                oBE.PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.EditValue);
                oBE.IdProductoArmado = IdProductoArmado;

                if (IdFormaPago == Parametros.intObsequio)
                    oBE.CodAfeIGV = Parametros.strGravadoEntregaTrabajadores;
                else
                    oBE.CodAfeIGV = Parametros.strGravadoOnerosa;



                #region 2022
                if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                {
                    oBE.DescPromocion = "";
                }
                else
                {
                    if (IdTipoCliente == Parametros.intTipClienteFinal)
                    {
                        decimal Descuento = 0;
                        if (DescPromocion2x1 != "")
                        {
                            Decuento_Cliente_Final(Convert.ToInt32(txtCantidad.Text));
                            Descuento = 0;
                        }
                        else
                        {
                            Descuento = Decuento_Cliente_Final(Convert.ToInt32(txtCantidad.Text));
                            if (DescAdicional > 0) // ecm 20220610
                            {
                                Descuento = DescAdicional;
                            }
                        }

                        oBE.IdPromocion2 = IdPromocion2;
                        if (IdProducto==83617 || IdProducto == 83618)
                        {
                            txtDescuento.EditValue = 0;
                        }
                        else
                        { 
                            txtDescuento.EditValue = Descuento; 
                        }

                        
                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                        oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                        oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                        oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                    }
                }
                #endregion




                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal Decuento_Cliente_Final(int Cantidad)
        {
            decimal Descuento = 0;
            PromocionTemporalDetalleBE objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto, true);
            if (objE_PromocionTemporal != null)
            {
                Descuento = objE_PromocionTemporal.Descuento;
                IdPromocion2 = objE_PromocionTemporal.IdPromocionTemporalDetalle;
            }
            else
            {
                if (IdMarca != Parametros.intIdMarcaKira)
                //if (bFlagEscala)
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
            return Descuento;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) optCodigo.Checked = true;
            if (keyData == Keys.F6) optHangTag.Checked = true;
            if (keyData == Keys.Escape) this.Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCodigo.Text.Length > 0)
                    {
                        if (optCodigo.Checked)
                        {
                            decimal DescuentoExtra = Parametros.dmlDescuentoMayoristaExtra;
                            #region "Código"
                            StockBE pProductoBE = null;

                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmTienda, txtCodigo.Text.Trim());
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                IdProductoArmado = pProductoBE.IdProductoArmado;
                                IdFamiliaProducto = pProductoBE.IdFamiliaProducto;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                IdMarca = pProductoBE.IdMarca;//2022
                                DescFamiliaProducto = pProductoBE.DescFamiliaProducto;//2022
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                bFlagNacional = pProductoBE.FlagNacional;//2022
                                bFlagEscala = pProductoBE.FlagEscala;//2022
                                txtCantidad.EditValue = 1;

                                //Temporal Hasta Predeterminar en Lista de precio 
                                #region "Promocion 2x1, 3x2 ...." 
                                Promocion2x1DetalleBE objE_PromocionDetalle2x1 = null;
                                Promocion2x1DetalleBL objBL_PromocionDetalle2x1 = new Promocion2x1DetalleBL();

                                lblDescPromocion.Text = "";
                                DescPromocion2x1 = DescPromocion2x1 = "";
                                FlagPromocion2x1 = false;

                                if ((IdTipoCliente == Parametros.intTipClienteFinal) && (IdClasificacionCliente != Parametros.intBlack))
                                {
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "2x1", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "2x1";
                                        DescPromocion2x1 = "2x1";
                                        FlagPromocion2x1 = true;
                                    }
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "3x2", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "3x2";
                                        DescPromocion2x1 = "3x2";
                                        FlagPromocion2x1 = true;
                                    }
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "3x1", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "3x1";
                                        DescPromocion2x1 = "3x1";
                                        FlagPromocion2x1 = true;
                                    }
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "4x1", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "4x1";
                                        DescPromocion2x1 = "4x1";
                                        FlagPromocion2x1 = true;
                                    }
                                }
                                #endregion

                                if (FlagPromocion2x1) //Elimina Descuentos
                                {
                                    pProductoBE.Descuento = 0;
                                    pProductoBE.DescuentoAB = 0;
                                    pProductoBE.DescuentoOutlet = 0;
                                    pProductoBE.FlagDescuentoAB = false;
                                    pProductoBE.FlagEscala = false;
                                    DescuentoExtra = 0;
                                }

                                if (IdMoneda == Parametros.intSoles)
                                {
                                    //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                        if (pProductoBE.FlagDescuentoAB)
                                            txtDescuento.EditValue = pProductoBE.DescuentoAB;
                                        else
                                            //txtDescuento.EditValue = pProductoBE.Descuento;
                                            txtDescuento.EditValue = pProductoBE.Descuento + DescuentoExtra;//add  apr 4, 2015
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
                                    //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioAB;
                                        if (pProductoBE.FlagDescuentoAB)
                                            txtDescuento.EditValue = pProductoBE.DescuentoAB;
                                        else
                                            //txtDescuento.EditValue = pProductoBE.Descuento;
                                            txtDescuento.EditValue = pProductoBE.Descuento + DescuentoExtra;//add  apr 4, 2015
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
                                FlagCompuesto = pProductoBE.FlagCompuesto;
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
                                    IdProductoArmado = objBusProducto.pProductoBE.IdProductoArmado;
                                    IdFamiliaProducto = objBusProducto.pProductoBE.IdFamiliaProducto;
                                    IdLineaProducto = objBusProducto.pProductoBE.IdLineaProducto;
                                    IdMarca = objBusProducto.pProductoBE.IdMarca;//2022
                                    DescFamiliaProducto = objBusProducto.pProductoBE.DescFamiliaProducto;//2022
                                    txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                    bFlagNacional = objBusProducto.pProductoBE.FlagNacional;//2022
                                    bFlagEscala = objBusProducto.pProductoBE.FlagEscala;//2022
                                    txtCantidad.EditValue = 1;
                                    //Temporal Hasta Predeterminar en Lista de precio 
                                    #region "Promocion 2x1, 3x2 ...." 
                                    Promocion2x1DetalleBE objE_PromocionDetalle2x1 = null;
                                    Promocion2x1DetalleBL objBL_PromocionDetalle2x1 = new Promocion2x1DetalleBL();

                                    lblDescPromocion.Text = "";
                                    DescPromocion2x1 = DescPromocion2x1 = "";
                                    FlagPromocion2x1 = false;

                                    if ((IdTipoCliente == Parametros.intTipClienteFinal) && (IdClasificacionCliente != Parametros.intBlack))
                                    {
                                        objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "2x1", DateTime.Now);
                                        if (objE_PromocionDetalle2x1 != null)
                                        {
                                            lblDescPromocion.Text = "2x1";
                                            DescPromocion2x1 = "2x1";
                                            FlagPromocion2x1 = true;
                                        }
                                        objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "3x2", DateTime.Now);
                                        if (objE_PromocionDetalle2x1 != null)
                                        {
                                            lblDescPromocion.Text = "3x2";
                                            DescPromocion2x1 = "3x2";
                                            FlagPromocion2x1 = true;
                                        }
                                        objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "3x1", DateTime.Now);
                                        if (objE_PromocionDetalle2x1 != null)
                                        {
                                            lblDescPromocion.Text = "3x1";
                                            DescPromocion2x1 = "3x1";
                                            FlagPromocion2x1 = true;
                                        }
                                        objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "4x1", DateTime.Now);
                                        if (objE_PromocionDetalle2x1 != null)
                                        {
                                            lblDescPromocion.Text = "4x1";
                                            DescPromocion2x1 = "4x1";
                                            FlagPromocion2x1 = true;
                                        }
                                    }
                                    #endregion

                                    if (FlagPromocion2x1) //Elimina Descuentos
                                    {
                                        objBusProducto.pProductoBE.Descuento = 0;
                                        objBusProducto.pProductoBE.DescuentoAB = 0;
                                        objBusProducto.pProductoBE.DescuentoOutlet = 0;
                                        objBusProducto.pProductoBE.FlagDescuentoAB = false;
                                        objBusProducto.pProductoBE.FlagEscala = false;
                                    }

                                    if (IdMoneda == Parametros.intSoles)
                                    {
                                        //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioABSoles;
                                            if (objBusProducto.pProductoBE.FlagDescuentoAB)
                                                txtDescuento.EditValue = objBusProducto.pProductoBE.DescuentoAB;
                                            else
                                                //txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                                if(IdProducto==83617 || IdProducto == 83618)
                                            {
                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento; 
                                            }
                                            else
                                            {
                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento + DescuentoExtra;//add  apr 4, 2015
                                            }
                                               
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                        else
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCDSoles; ;
                                            txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                    }
                                    else
                                    {
                                        //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                        {
                                            txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioAB;
                                            if (objBusProducto.pProductoBE.FlagDescuentoAB)
                                                txtDescuento.EditValue = objBusProducto.pProductoBE.DescuentoAB;
                                            else
                                                //txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;                                             

                                            if (IdProducto == 83617 || IdProducto == 83618)
                                            {
                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;
                                            }
                                            else
                                            {
                                                txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento + DescuentoExtra;//add  apr 4, 2015
                                            }
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
                                    FlagCompuesto = objBusProducto.pProductoBE.FlagCompuesto;
                                }
                            }
                            #endregion
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
                                IdProductoArmado = pProductoBE.IdProductoArmado;
                                IdFamiliaProducto = pProductoBE.IdFamiliaProducto;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                IdMarca = pProductoBE.IdMarca;//2022
                                DescFamiliaProducto = pProductoBE.DescFamiliaProducto;//2022
                                bFlagEscala = pProductoBE.FlagEscala;//2022
                                bFlagNacional = pProductoBE.FlagNacional;//2022
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;


                                //Temporal Hasta Predeterminar en Lista de precio 
                                #region "Promocion 2x1, 3x2 ...." 
                                Promocion2x1DetalleBE objE_PromocionDetalle2x1 = null;
                                Promocion2x1DetalleBL objBL_PromocionDetalle2x1 = new Promocion2x1DetalleBL();

                                lblDescPromocion.Text = "";
                                DescPromocion2x1 = DescPromocion2x1 = "";
                                FlagPromocion2x1 = false;

                                if ((IdTipoCliente == Parametros.intTipClienteFinal) && (IdClasificacionCliente != Parametros.intBlack))
                                {
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "2x1", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "2x1";
                                        DescPromocion2x1 = "2x1";
                                        FlagPromocion2x1 = true;
                                    }
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "3x2", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "3x2";
                                        DescPromocion2x1 = "3x2";
                                        FlagPromocion2x1 = true;
                                    }
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "3x1", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "3x1";
                                        DescPromocion2x1 = "3x1";
                                        FlagPromocion2x1 = true;
                                    }
                                    objE_PromocionDetalle2x1 = objBL_PromocionDetalle2x1.SeleccionaProducto(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdProducto, "4x1", DateTime.Now);
                                    if (objE_PromocionDetalle2x1 != null)
                                    {
                                        lblDescPromocion.Text = "4x1";
                                        DescPromocion2x1 = "4x1";
                                        FlagPromocion2x1 = true;
                                    }
                                }
                                #endregion

                                if (FlagPromocion2x1) //Elimina Descuentos
                                {
                                    pProductoBE.Descuento = 0;
                                    pProductoBE.DescuentoAB = 0;
                                    pProductoBE.DescuentoOutlet = 0;
                                    pProductoBE.FlagDescuentoAB = false;
                                    pProductoBE.FlagEscala = false;
                                }

                                if (IdMoneda == Parametros.intSoles)
                                {
                                    //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                    {

                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                        if (pProductoBE.FlagDescuentoAB)
                                            txtDescuento.EditValue = pProductoBE.DescuentoAB;
                                        else
                                         //txtDescuento.EditValue = pProductoBE.Descuento;
                                         if (IdProducto == 83617 || IdProducto == 83618)
                                        {
                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        }
                                        else
                                        {
                                            txtDescuento.EditValue = pProductoBE.Descuento + Parametros.dmlDescuentoMayoristaExtra;//add  apr 4, 2015
                                        }
                                            
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
                                    //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        txtPrecioUnitario.EditValue = pProductoBE.PrecioAB;
                                        if (pProductoBE.FlagDescuentoAB)
                                            txtDescuento.EditValue = pProductoBE.DescuentoAB;
                                        else
                                         if (IdProducto == 83617 || IdProducto == 83618)
                                        {
                                            txtDescuento.EditValue = pProductoBE.Descuento;
                                        }
                                        else
                                        {
                                            //txtDescuento.EditValue = pProductoBE.Descuento;
                                            txtDescuento.EditValue = pProductoBE.Descuento + Parametros.dmlDescuentoMayoristaExtra;//add  apr 4, 2015
                                        }

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
                            FlagCompuesto = pProductoBE.FlagCompuesto;

                            #endregion
                        }

                        if (bCantidadAutomatica)
                        {
                            btnAceptar_Click(sender, e);
                            //this.DialogResult = DialogResult.OK;
                            //this.Close();
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

        private void chkCantidadAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCantidadAutomatica.Checked)
                bCantidadAutomatica = true;
            else
                bCantidadAutomatica = false;
        }

        #endregion

        #region "Metodos"

        private void CargarDescuentoClienteFinal()
        {
            mListaDescuentoClienteFinal = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);
        }

        private void CalculaDescuentoClienteFinal(int IdProducto, int Cantidad, int IdLineaProducto)
        {
            try
            {
                if (FlagPromocion2x1) return; //add 15-12-2019

                decimal decDescuento = 0;
                decimal decPrecioAB = 0;
                decimal decPrecioCD = 0;
                decimal decDescuentoOrigen = 0;
                decimal decDescuentoClubDesign = 0;

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
                                if (IdLineaProducto != 4 )
                                {
                                    if (IdProducto == 83617 || IdProducto == 83618)
                                    {
                                        decDescuento = 0;
                                    }
                                    else
                                    {
                                        decDescuento = item.PorDescuento;
                                    }
                                    
                                }

                                if (decDescuentoOrigen > decDescuento)
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    //else
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = item.PorDescuento + 10;
                                    //else
                                    if (IdLineaProducto != 4 )
                                    {
                                        if(IdProducto == 83617 || IdProducto == 83618)
                                        {
                                            txtDescuento.EditValue = 0;
                                        }
                                        else
                                        {
                                                txtDescuento.EditValue = item.PorDescuento;
                                        }
                                        
                                    }
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
                                if (IdLineaProducto != 4)
                                {
                                    if (IdProducto == 83617 || IdProducto == 83618)
                                    {
                                        decDescuento = 0;
                                    }
                                    else
                                    {
                                        decDescuento = item.PorDescuento;
                                    }
                                }
                                //  decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    //else
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = item.PorDescuento + 10;
                                    //else
                                    if (IdLineaProducto != 4)
                                    {
                                       
                                        if (IdProducto == 83617 || IdProducto == 83618)
                                        {
                                            txtDescuento.EditValue = 0;
                                        }
                                        else
                                        {
                                            txtDescuento.EditValue = item.PorDescuento;
                                        }
                                    }
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
                                if (IdLineaProducto != 4)
                                {
                                    if (IdProducto == 83617 || IdProducto == 83618)
                                    {
                                        decDescuento =  0;
                                    }
                                    else
                                    {
                                        decDescuento = item.PorDescuento;
                                    }
                                 
                                }
                                // decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    //else
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = item.PorDescuento + 10;
                                    //else
                                    if (IdLineaProducto != 4 )
                                    {
                                       
                                        if (IdProducto == 83617 || IdProducto == 83618)
                                        {
                                            txtDescuento.EditValue = 0;
                                        }
                                        else
                                        {
                                            txtDescuento.EditValue = item.PorDescuento;
                                        }
                                    }
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
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    //else
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = item.PorDescuento + 10;
                                    //else
                                    if (IdProducto == 83617 || IdProducto == 83618)
                                    {
                                        txtDescuento.EditValue = 0;
                                    }
                                    else
                                    {
                                        txtDescuento.EditValue = item.PorDescuento;
                                    }

                                    //txtDescuento.EditValue = item.PorDescuento;
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
                                if (IdLineaProducto != 4)
                                {
                                    if (IdProducto == 83617 || IdProducto == 83618)
                                    {
                                        decDescuento = 0;
                                    }
                                    else
                                    {
                                        decDescuento = item.PorDescuento;
                                    }
                                   
                                }
                                //decDescuento = item.PorDescuento;
                                //  decDescuento = item.PorDescuento;
                                if (decDescuentoOrigen > decDescuento)
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = decDescuentoOrigen + 10;
                                    //else
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    //if (bDescuentoCumpleanio)
                                    //    txtDescuento.EditValue = item.PorDescuento + 10;
                                    //else
                                    if (IdLineaProducto != 4 )
                                    {
                                       
                                        if (IdProducto == 83617 || IdProducto == 83618)
                                        {
                                            txtDescuento.EditValue = 0;
                                        }
                                        else
                                        {
                                            txtDescuento.EditValue = item.PorDescuento;
                                        }
                                    }
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }
                        }
                    }

                    #region "Descuento por Club Design"
                    if (IdClasificacionCliente == Parametros.intClubDesign)
                    {
                        if (bFlagNacional)
                            decDescuentoClubDesign = Convert.ToDecimal(5.00);
                        else
                        {
                            if (IdFamiliaProducto == Parametros.intFamiliaNavidad)
                                decDescuentoClubDesign = Convert.ToDecimal(5.00);
                            else //regular
                            {
                                if (IdLineaProducto == Parametros.intLineaReligioso)
                                    decDescuentoClubDesign = Convert.ToDecimal(5.00);
                                else //Todas las lineas Regulares
                                {
                                    decDescuentoClubDesign = Convert.ToDecimal(20.00);
                                }
                            }
                        }
                    }
                    if (Convert.ToDecimal(txtDescuento.EditValue) < decDescuentoClubDesign)
                    {
                        txtDescuento.EditValue = decDescuentoClubDesign;
                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                    }



                    #endregion

                    //Test de velociad por Hora
                    #region "Descuento Promocion Temporal"
                    PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                    objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, Parametros.intContado, Parametros.intTiendaId, 0, IdProducto);
                    if (objE_PromocionTemporal != null)
                    {
                        if (Convert.ToDecimal(txtDescuento.EditValue) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                        {
                            txtDescuento.EditValue = objE_PromocionTemporal.Descuento;
                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                        }
                    }
                    #endregion

                    #region "Descuento de Cumpleaños"

                    if (bDescuentoCumpleanio)
                    {
                        if (Convert.ToDecimal(txtDescuento.EditValue) <= 50 && objE_Stock.FlagEscala)
                        {
                            txtDescuento.EditValue = Convert.ToDecimal(txtDescuento.EditValue) + 10;
                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                        }
                    }
                    #endregion


                }
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}