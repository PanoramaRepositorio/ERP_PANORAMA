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
    public partial class frmRegPedidoDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();
        public List<StockBE> mListaStock = new List<StockBE>();

        public PedidoDetalleBE oBE;
        public int IdTipoCliente { get; set; }
        public int IdClasificacionCliente { get; set; }

        public int intCorrelativo = 0;

        public int IdPedido = 0;
        public int IdPedidoDetalle = 0;
        public int IdKardex = 0;
        public int IdAlmacen = 0;
        public int IdFormaPago = 0;
        public int IdTipoVenta = 0;
        public string Medida = "";

        public int IdProducto = 0;
        public int IdProductoArmado = 0;
        public int IdFamiliaProducto = 0;
        public int IdLineaProducto = 0;
        public int IdMarca = 0;
        public string DescFamiliaProducto = "";
        // public Boolean FlagEscala = true;
        public Boolean FlagRamoPersonalizado = false;

        public int Stock = 0;
        public decimal PorcentajeDescuentoInicial = 0;
        public decimal PorcentajeDescuentoClientePromocion = 0;
        public int IdDescuentoClientePromocion = 0;
        public int ItemsDescuentoPromocion = 0;
        //public decimal PorcentajeDescuentoBase = 0;
        public int IdMoneda = 0;
        public int CantidadModificada = 0;

        public bool bPreVenta = false;
        public bool bNuevo = true;
        private bool bAutoservicio = false;
        public bool bDescuentoCumpleanio = false;
        public bool bDescuentoEncuesta = false;
        public bool bDescuentoBulto = false;
        public bool FlagCompuesto = false;
        private bool FlagPresionado = false;
        private bool bFlagNacional = false;
        public bool bFlagEscala = false;
        public int OrigenNuevo = 0; //1: Producto Transformado
        public decimal DescuentoVale = 0; //Vale
        public decimal ImporteVale = 0;
        public decimal DescuentoOutlet = 0; //Vale
        public bool FlagPromocion2x1 = false;
        public string DescPromocion2x1 = "";
        public bool FlagAumentarCantidad = true;
        public decimal DescAdicional = 0; // ecm 20220610
        public bool FlagFijarDescuento = false;// ecm2
        public int IdPromocion2 = 0;// ecm2
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmRegPedidoDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmRegPedidoDetalleEdit_Load(object sender, EventArgs e)
        {
            if (IdMoneda == Parametros.intSoles)
            {
                lblMoneda.Text = "Nuevos Soles S/";
            }
            else
            {
                lblMoneda.Text = "Dolares Americanos US$.";
            }

            if (Parametros.intTiendaId != Parametros.intTiendaUcayali)
            {
                chkMuestra.Visible = false;
            }
            else
            {
                chkMuestra.Visible = true;
            }

            if (bPreVenta)
            {
                chkMuestra.Enabled = false;
            }
            //else
            //{
            //    chkMuestra.Enabled = true;
            //}
            lblDescPromocion.Text = DescPromocion2x1;
            CargarDescuentoClienteFinal();

            //chkMuestra.Enabled = true;

            txtCodigo.Focus();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    Decimal DescuentoExtra = 0; // Cliente Mayorista y Producto Nacional
                    bDescuentoBulto = false;

                    //add 23 agosto 13
                    #region "Preventa"
                    if (bPreVenta)
                    {
                        #region "Codigo"
                        if (optCodigo.Checked)
                        {
                            frmBusProductoStockPreVenta objBusProductoPreVenta = new frmBusProductoStockPreVenta();
                            objBusProductoPreVenta.pDescripcion = txtCodigo.Text.Trim();
                            objBusProductoPreVenta.IdTienda = Parametros.intTiendaId;
                            objBusProductoPreVenta.IdAlmacen = Parametros.intAlmCentralUcayali;
                            objBusProductoPreVenta.ShowDialog();
                            if (objBusProductoPreVenta.pProductoBE != null)
                            {
                                Stock = objBusProductoPreVenta.pProductoBE.Cantidad; //Add 13 jun
                                IdProducto = objBusProductoPreVenta.pProductoBE.IdProducto;
                                DescFamiliaProducto = objBusProductoPreVenta.pProductoBE.DescFamiliaProducto;
                                IdFamiliaProducto = objBusProductoPreVenta.pProductoBE.IdFamiliaProducto;
                                IdLineaProducto = objBusProductoPreVenta.pProductoBE.IdLineaProducto;
                                IdMarca = objBusProductoPreVenta.pProductoBE.IdMarca;
                                txtCodigo.Text = objBusProductoPreVenta.pProductoBE.CodigoProveedor;
                                txtProducto.Text = objBusProductoPreVenta.pProductoBE.NombreProducto;
                                txtUM.Text = objBusProductoPreVenta.pProductoBE.Abreviatura;
                                bFlagNacional = objBusProductoPreVenta.pProductoBE.FlagNacional;
                                bFlagEscala = objBusProductoPreVenta.pProductoBE.FlagEscala;
                                txtCantidad.EditValue = 1;

                                if (IdMoneda == Parametros.intSoles)
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    {
                                        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioABSoles;
                                        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioCDSoles; ;
                                        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }
                                else
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                    {
                                        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioAB;
                                        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioCD;
                                        txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }

                                Stock = objBusProductoPreVenta.pProductoBE.Cantidad;
                                IdAlmacen = objBusProductoPreVenta.IdAlmacen;
                                txtCantidad.SelectAll();
                                txtCantidad.Focus();
                            }
                        }


                        #endregion

                        #region "HangTag"
                        if (optHangTag.Checked)
                        {
                            StockBE pProductoBE = null;

                            if (txtCodigo.Text.Trim().Count() > 6)
                            {
                                pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtCodigo.Text.Trim());
                            }
                            else
                            {
                                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, Convert.ToInt32(txtCodigo.Text.Trim()));
                            }
                            if (pProductoBE != null)
                            {
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                optCodigo.Checked = true;
                                frmBusProductoStockPreVenta objBusProductoPreVenta = new frmBusProductoStockPreVenta();
                                objBusProductoPreVenta.pDescripcion = txtCodigo.Text.Trim();
                                objBusProductoPreVenta.IdTienda = Parametros.intTiendaId;
                                objBusProductoPreVenta.IdAlmacen = Parametros.intAlmCentralUcayali;
                                objBusProductoPreVenta.ShowDialog();
                                if (objBusProductoPreVenta.pProductoBE != null)
                                {
                                    Stock = objBusProductoPreVenta.pProductoBE.Cantidad; //Add 13 jun
                                    IdProducto = objBusProductoPreVenta.pProductoBE.IdProducto;
                                    DescFamiliaProducto = objBusProductoPreVenta.pProductoBE.DescFamiliaProducto;
                                    IdFamiliaProducto = objBusProductoPreVenta.pProductoBE.IdFamiliaProducto;
                                    IdLineaProducto = objBusProductoPreVenta.pProductoBE.IdLineaProducto;
                                    IdMarca = objBusProductoPreVenta.pProductoBE.IdMarca;
                                    txtCodigo.Text = objBusProductoPreVenta.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProductoPreVenta.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProductoPreVenta.pProductoBE.Abreviatura;
                                    bFlagNacional = objBusProductoPreVenta.pProductoBE.FlagNacional;
                                    bFlagEscala = objBusProductoPreVenta.pProductoBE.FlagEscala;
                                    txtCantidad.EditValue = 1;
                                    if (IdMoneda == Parametros.intSoles)
                                    {
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                        {
                                            txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioABSoles;
                                            txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                        else
                                        {
                                            txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioCDSoles; ;
                                            txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                    }
                                    else
                                    {
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                        {
                                            txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioAB;
                                            txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                        else
                                        {
                                            txtPrecioUnitario.EditValue = objBusProductoPreVenta.pProductoBE.PrecioCD;
                                            txtDescuento.EditValue = objBusProductoPreVenta.pProductoBE.Descuento;
                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        }
                                    }

                                    Stock = objBusProductoPreVenta.pProductoBE.Cantidad;
                                    IdAlmacen = objBusProductoPreVenta.IdAlmacen;
                                    txtCantidad.SelectAll();
                                    txtCantidad.Focus();
                                }
                            }
                        }



                        #endregion
                    }
                    #endregion

                    #region "venta"
                    else
                    {
                        #region "Por Codigo"
                        if (optCodigo.Checked)
                        {
                            frmBusProductoStock objBusProducto = new frmBusProductoStock();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.IdTienda = Parametros.intTiendaId;
                            //if(bAutoservicio)//add 291015
                            //    objBusProducto.IdAlmacen = Parametros.intAlmTiendaUcayali;//add
                            //else
                            objBusProducto.IdAlmacen = Parametros.intAlmCentralUcayali;

                            objBusProducto.ShowDialog();

                            if (objBusProducto.pProductoBE != null)
                            {
                                Stock = objBusProducto.pProductoBE.Cantidad; //Add 13 jun

                                #region "Validar Stock Negativo"
                                /*if (objBusProducto.pProductoBE.Cantidad <= 0  && Parametros.bStockNegativo == false)
                                {
                                    if (objBusProducto.pProductoBE.Cantidad <= 0 & Parametros.intTiendaId == Parametros.intTiendaUcayali)
                                    {
                                        //if (objBusProducto.pProductoBE.IdLineaProducto == 10 || objBusProducto.pProductoBE.IdLineaProducto == 15 || objBusProducto.pProductoBE.IdLineaProducto == 16 || objBusProducto.pProductoBE.IdLineaProducto == 17 || objBusProducto.pProductoBE.IdLineaProducto == 18 || objBusProducto.pProductoBE.IdLineaProducto == 19 || objBusProducto.pProductoBE.IdLineaProducto == 20)//Delete
                                        //{
                                            IdProducto = 0;
                                            txtCodigo.Text = "";
                                            //XtraMessageBox.Show("Producto agotado - STOCK 0, Verificar con Almacén", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            XtraMessageBox.Show("Producto agotado en Almacén Central- STOCK 0, Puede Vender la muestra.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        //}
                                    }
                                }*/
                                #endregion

                                IdProducto = objBusProducto.pProductoBE.IdProducto;
                                IdProductoArmado = objBusProducto.pProductoBE.IdProductoArmado;
                                IdFamiliaProducto = objBusProducto.pProductoBE.IdFamiliaProducto;
                                IdLineaProducto = objBusProducto.pProductoBE.IdLineaProducto;
                                IdMarca = objBusProducto.pProductoBE.IdMarca;
                                DescFamiliaProducto = objBusProducto.pProductoBE.DescFamiliaProducto;
                                txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                Medida = objBusProducto.pProductoBE.Medida;
                                txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                bFlagNacional = objBusProducto.pProductoBE.FlagNacional;
                                bFlagEscala = objBusProducto.pProductoBE.FlagEscala;
                                txtCantidad.EditValue = 1;

                                //Temporal Hasta Predeterminar en Lista de precio 
                                #region "Promocion 2x1, 3x2 ...." 
                                Promocion2x1DetalleBE objE_PromocionDetalle2x1 = null;
                                Promocion2x1DetalleBL objBL_PromocionDetalle2x1 = new Promocion2x1DetalleBL();

                                lblDescPromocion.Text = "";
                                DescPromocion2x1 = "";
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

                                //Descuento extra condicion por linea de producto religioso add 06/02/2020
                                if (objBusProducto.pProductoBE.FlagNacional == false && objBusProducto.pProductoBE.Descuento <= 80)//add 251019
                                    if (IdLineaProducto == Parametros.intLineaReligioso)
                                    {
                                        DescuentoExtra = Parametros.dmlDescuentoMayoristaExtraReligioso;
                                    }
                                    else
                                    {
                                        DescuentoExtra = Parametros.dmlDescuentoMayoristaExtraReligioso;
                                    }

                                if (FlagPromocion2x1) //Elimina Descuentos
                                {
                                    objBusProducto.pProductoBE.Descuento = 0;
                                    objBusProducto.pProductoBE.DescuentoAB = 0;
                                    objBusProducto.pProductoBE.DescuentoOutlet = 0;
                                    objBusProducto.pProductoBE.FlagDescuentoAB = false;
                                    objBusProducto.pProductoBE.FlagEscala = false;
                                    DescuentoExtra = 0;
                                }

                                if (IdMoneda == Parametros.intSoles)
                                {
                                    if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioABSoles;
                                        if (objBusProducto.pProductoBE.FlagDescuentoAB)
                                            txtDescuento.EditValue = objBusProducto.pProductoBE.DescuentoAB;
                                        else
                                            txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento + DescuentoExtra;//add  apr 4, 2015
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

                                    //Descuento Temporal - Test de velociad por Hora
                                    #region "Descuento Promocion Temporal"
                                    if (!FlagPromocion2x1)
                                    {
                                        PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                        objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
                                        if (objE_PromocionTemporal != null)
                                        {
                                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
                                            {

                                                if (Convert.ToDecimal(txtDescuento.Text) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                                {
                                                    if (objE_PromocionTemporal.Descuento >= 80) DescuentoExtra = 0;//add 251019
                                                    txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioABSoles;

                                                    if (IdFormaPago == Parametros.intContado)
                                                    {
                                                        if (objE_PromocionTemporal.Descuento < 21 && Parametros.intLineaReligioso == IdLineaProducto)
                                                        {
                                                            txtDescuento.EditValue = 25;
                                                        }
                                                        else if (objE_PromocionTemporal.Descuento < 21 && Parametros.intLineaReligioso != IdLineaProducto)
                                                        {
                                                            txtDescuento.EditValue = 25;
                                                        }
                                                        else
                                                        {
                                                            txtDescuento.EditValue = objE_PromocionTemporal.Descuento + DescuentoExtra;
                                                        }
                                                    }

                                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                                }
                                            }
                                            //Se agrego el descuento temporal
                                            else
                                            {
                                                txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioCDSoles;
                                                txtDescuento.EditValue = objE_PromocionTemporal.Descuento;
                                                txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                            }
                                        }
                                    }
                                    #endregion

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
                                            txtDescuento.EditValue = objBusProducto.pProductoBE.Descuento;//+ DescuentoExtra;//add  apr 4, 2015
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

                                    //Descuento Temporal - Test de velociad por Hora
                                    #region "Descuento Promocion Temporal"
                                    if (!FlagPromocion2x1)
                                    {
                                        PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                        objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
                                        if (objE_PromocionTemporal != null)
                                        {
                                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
                                            {
                                                if (Convert.ToDecimal(txtDescuento.Text) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                                {

                                                    txtPrecioUnitario.EditValue = objBusProducto.pProductoBE.PrecioAB;

                                                    if (IdFormaPago == Parametros.intCredito)
                                                    {
                                                        if (objE_PromocionTemporal.Descuento < 21 && Parametros.intLineaReligioso == IdLineaProducto)
                                                        {
                                                            txtDescuento.EditValue = 25;

                                                        }
                                                        else if (objE_PromocionTemporal.Descuento < 21 && Parametros.intLineaReligioso != IdLineaProducto)
                                                        {
                                                            txtDescuento.EditValue = 25;
                                                        }
                                                        else
                                                        {
                                                            txtDescuento.EditValue = objE_PromocionTemporal.Descuento + DescuentoExtra;
                                                        }

                                                    }
                                                    else if (IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan)
                                                    {
                                                        if (objE_PromocionTemporal.Descuento < 21 && Parametros.intLineaReligioso == IdLineaProducto)
                                                        {
                                                            txtDescuento.EditValue = 25;
                                                        }
                                                        else if (objE_PromocionTemporal.Descuento < 21 && Parametros.intLineaReligioso != IdLineaProducto)
                                                        {
                                                            txtDescuento.EditValue = 25;
                                                        }
                                                        else
                                                        {
                                                            txtDescuento.EditValue = objE_PromocionTemporal.Descuento + DescuentoExtra;
                                                        }
                                                    }

                                                    if (objE_PromocionTemporal.Descuento > 80) DescuentoExtra = 0;//add 251019
                                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                                }
                                            }

                                        }
                                    }

                                    #endregion
                                }
                                #region "Descuento por Fecha de Recepción - Load in Memory"
                                if (DateTime.Now <= Convert.ToDateTime("28/02/2019"))
                                {
                                    if (IdFormaPago == Parametros.intContraEntrega && IdTipoVenta == Parametros.intPorVisitaCampo)
                                    {
                                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                        {
                                            List<DescuentoTipoVentaBE> lst_DescuentoTipoVenta = null;
                                            lst_DescuentoTipoVenta = new DescuentoTipoVentaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
                                            if (lst_DescuentoTipoVenta != null)
                                            {
                                                foreach (var item in lst_DescuentoTipoVenta)
                                                {
                                                    if (objBusProducto.pProductoBE.Fecha >= item.FechaInicio && objBusProducto.pProductoBE.Fecha <= item.FechaFin)
                                                    {
                                                        if (Convert.ToDecimal(txtDescuento.Text) < item.PorDescuento)//Regular y Descuento Promocion
                                                        {
                                                            txtDescuento.EditValue = item.PorDescuento;
                                                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                #endregion

                                //chkAuto.Checked = bAutoservicio;//add borrar
                                bAutoservicio = objBusProducto.pProductoBE.FlagAutoservicio;
                                if (bAutoservicio && Parametros.intTiendaId == Parametros.intAlmTiendaUcayali) lblMensaje.Visible = true; else lblMensaje.Visible = false;

                                FlagCompuesto = objBusProducto.pProductoBE.FlagCompuesto;
                                IdAlmacen = objBusProducto.pProductoBE.IdAlmacen;

                                if (IdAlmacen == Parametros.intAlmTiendaUcayali)
                                    chkMuestra.Checked = true;
                                else
                                    chkMuestra.Checked = false;

                                txtCantidad.SelectAll();
                                txtCantidad.Focus();

                                //PorcentajeDescuentoBase = Convert.ToDecimal(txtDescuento.EditValue);

                                //Codigo libre para Modificar

                                #region "Codigo de libre Modificacion"
                                if (IdProducto == Parametros.intIdProductoReparacion || IdProducto == 91018 || IdProducto == 73940)
                                {
                                    txtPrecioUnitario.Properties.ReadOnly = false;
                                    txtPrecioVenta.Properties.ReadOnly = false;
                                    txtDescuento.EditValue = 0;
                                    labelControl5.Text = "CODIGO:";
                                }
                                else
                                {
                                    txtPrecioUnitario.Properties.ReadOnly = true;
                                    txtPrecioVenta.Properties.ReadOnly = true;
                                    labelControl5.Text = "Observación:";
                                }
                                #endregion

                                PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.Text);

                            }
                        }
                        #endregion

                        #region "Por HangTag"
                        if (optHangTag.Checked)
                        {
                            StockBE pProductoBE = null;

                            if (txtCodigo.Text.Trim().Count() > 6)
                            {
                                //pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmTienda, txtCodigo.Text.Trim());
                                pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtCodigo.Text.Trim());
                            }
                            else
                            {
                                //pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, Convert.ToInt32(txtCodigo.Text.Trim()));
                                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, Convert.ToInt32(txtCodigo.Text.Trim()));
                            }

                            //frmBusProductoStock objBusProducto = new frmBusProductoStock();
                            //objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            //objBusProducto.IdTienda = Parametros.intTiendaId;
                            //objBusProducto.IdAlmacen = Parametros.intAlmCentralUcayali;
                            //objBusProducto.ShowDialog();
                            if (pProductoBE != null)
                            {
                                Stock = pProductoBE.Cantidad; //Add 13 jun



                                /*if (pProductoBE.Cantidad <= 0 && Parametros.bStockNegativo == false)
                                {
                                    if (pProductoBE.Cantidad <= 0 && Parametros.intTiendaId == Parametros.intTiendaUcayali) //CANT 0
                                    {
                                    //    if (pProductoBE.IdLineaProducto == 10 || pProductoBE.IdLineaProducto == 15 || pProductoBE.IdLineaProducto == 16 || pProductoBE.IdLineaProducto == 17 || pProductoBE.IdLineaProducto == 18 || pProductoBE.IdLineaProducto == 19 || pProductoBE.IdLineaProducto == 20)//Delete
                                    //    {
                                            IdProducto = 0;
                                            txtCodigo.Text = "";
                                            //XtraMessageBox.Show("No se puede vender un producto con STOCK 0 , Verificar con Almacén", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            XtraMessageBox.Show("Producto agotado en Almacén Central- STOCK 0, Puede Vender la muestra.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        //}
                                    }
                                }*/

                                IdProducto = pProductoBE.IdProducto;
                                IdProductoArmado = pProductoBE.IdProductoArmado;
                                IdFamiliaProducto = pProductoBE.IdFamiliaProducto;
                                IdLineaProducto = pProductoBE.IdLineaProducto;
                                DescFamiliaProducto = pProductoBE.DescFamiliaProducto;
                                bFlagEscala = pProductoBE.FlagEscala;
                                IdMarca = pProductoBE.IdMarca;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                bFlagNacional = pProductoBE.FlagNacional;
                                txtCantidad.EditValue = 1;

                                //Temporal Hasta Predeterminar en Lista de precio 
                                #region "Promocion 2x1, 3x2 ...." 
                                Promocion2x1DetalleBE objE_PromocionDetalle2x1 = null;
                                Promocion2x1DetalleBL objBL_PromocionDetalle2x1 = new Promocion2x1DetalleBL();

                                lblDescPromocion.Text = "";
                                DescPromocion2x1 = "";
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


                                if (pProductoBE.FlagNacional == false && pProductoBE.Descuento <= 50)
                                    DescuentoExtra = Parametros.dmlDescuentoMayoristaExtra;

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



                                    //Descuento Temporal - Test de velociad por Hora
                                    #region "Descuento Promocion Temporal"
                                    if (!FlagPromocion2x1)
                                    {
                                        PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                        objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
                                        if (objE_PromocionTemporal != null)
                                        {
                                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
                                            {
                                                if (Convert.ToDecimal(txtDescuento.Text) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                                {
                                                    if (objE_PromocionTemporal.Descuento > 50) DescuentoExtra = 0;//add 251019
                                                    txtPrecioUnitario.EditValue = pProductoBE.PrecioABSoles;
                                                    txtDescuento.EditValue = objE_PromocionTemporal.Descuento + DescuentoExtra;//add  apr 4, 2015
                                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                                }
                                            }
                                        }
                                    }
                                    #endregion

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

                                    //Descuento Temporal - Test de velociad por Hora
                                    #region "Descuento Promocion Temporal"
                                    if (!FlagPromocion2x1)
                                    {
                                        PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                                        objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
                                        if (objE_PromocionTemporal != null)
                                        {
                                            if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
                                            {
                                                if (Convert.ToDecimal(txtDescuento.Text) < objE_PromocionTemporal.Descuento)//Regular y Descuento Promocion
                                                {
                                                    //if (objE_PromocionTemporal.Descuento > 50) DescuentoExtra = 0;//add 251019
                                                    txtPrecioUnitario.EditValue = pProductoBE.PrecioAB;
                                                    txtDescuento.EditValue = objE_PromocionTemporal.Descuento + DescuentoExtra;//add  apr 4, 2015
                                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                                }
                                            }
                                        }
                                    }
                                    #endregion

                                }


                                #region "Descuento por Fecha de Recepción - Load in Memory"
                                //if(DateTime.Now <= Convert.ToDateTime("28/02/2019"))
                                //{
                                //    if (IdFormaPago == Parametros.intContraEntrega && IdTipoVenta == Parametros.intPorVisitaCampo)
                                //    {
                                //        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)
                                //        {
                                //            List<DescuentoTipoVentaBE> lst_DescuentoTipoVenta = null;
                                //            lst_DescuentoTipoVenta = new DescuentoTipoVentaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
                                //            if (lst_DescuentoTipoVenta != null)
                                //            {
                                //                foreach (var item in lst_DescuentoTipoVenta)
                                //                {
                                //                    if (pProductoBE.Fecha >= item.FechaInicio && pProductoBE.Fecha <= item.FechaFin)
                                //                    {
                                //                        if (Convert.ToDecimal(txtDescuento.Text) < item.PorDescuento)//Regular y Descuento Promocion
                                //                        {
                                //                            txtDescuento.EditValue = item.PorDescuento;
                                //                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                //                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                //                        }
                                //                    }
                                //                }
                                //            }
                                //        }
                                //    }
                                //}

                                #endregion


                                //Stock = pProductoBE.Cantidad;
                                bAutoservicio = pProductoBE.FlagAutoservicio;

                                //if (bAutoservicio) lblMensaje.Visible = true; else lblMensaje.Visible = false;
                                if (bAutoservicio && Parametros.intTiendaId == Parametros.intAlmTiendaUcayali) lblMensaje.Visible = true; else lblMensaje.Visible = false;
                                //chkAuto.Checked = bAutoservicio;//add borrar
                                FlagCompuesto = pProductoBE.FlagCompuesto;
                                IdAlmacen = Parametros.intAlmCentralUcayali;//pProductoBE.IdAlmacen;
                                txtCantidad.SelectAll();
                                txtCantidad.Focus();

                                //PorcentajeDescuentoBase = Convert.ToDecimal(txtDescuento.EditValue);

                                //Codigo libre para Modificar
                                #region "Codigo de libre Modificacion"
                                if (IdProducto == Parametros.intIdProductoReparacion || IdProducto == 91018 || IdProducto == 73940)
                                {
                                    txtPrecioUnitario.Properties.ReadOnly = false;
                                    txtPrecioVenta.Properties.ReadOnly = false;
                                    txtDescuento.EditValue = 0;
                                    labelControl5.Text = "CODIGO:";
                                }
                                else
                                {
                                    txtPrecioUnitario.Properties.ReadOnly = true;
                                    txtPrecioVenta.Properties.ReadOnly = true;
                                    labelControl5.Text = "Observación:";
                                }
                                #endregion
                                PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.Text);
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
            }

        }

        private void btnEditaPrecio_Click(object sender, EventArgs e)
        {
            frmModificaPrecioDescuento objModificaPrecio = new frmModificaPrecioDescuento();
            objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            //objModificaPrecio.Descuento = Convert.ToDecimal(txtDescuento.Text); //PorcentajeDescuentoInicial; //Convert.ToDecimal(txtDescuento.Text); //ANTES
            //objModificaPrecio.Descuento = Convert.ToDecimal(txtDescuento.Text); //add 04-11-19
            objModificaPrecio.Descuento = Decuento_Cliente_Final(Convert.ToInt32(txtCantidad.Text));// ecm 20220610

            if (FlagFijarDescuento)
            {
                objModificaPrecio.Descuento = Convert.ToDecimal(txtDescuento.Text); //add 04-11-19
            }
            objModificaPrecio.IdProducto = IdProducto;
            objModificaPrecio.IdLineaProducto = IdLineaProducto;
            objModificaPrecio.IdPedido = IdPedido;
            if (pOperacion == Operacion.Nuevo) objModificaPrecio.Nuevo = true;

            objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            objModificaPrecio.ShowDialog();

            DescAdicional = objModificaPrecio.Descuento; // ecm 20220610
            bNuevo = false;
            txtPrecioUnitario.EditValue = objModificaPrecio.PrecioUnitario;
            txtDescuento.EditValue = objModificaPrecio.Descuento; //Modified 41119
            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            btnAceptar.Focus();

            // *******  Descuento y Precio MANUAL *********
            /*frmModificaPrecio objModificaPrecio = new frmModificaPrecio();
            objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            objModificaPrecio.Descuento = Convert.ToDecimal(txtDescuento.Text);
            objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            objModificaPrecio.ShowDialog();

            bNuevo = false;
            txtPrecioUnitario.EditValue = objModificaPrecio.PrecioUnitario;
            txtDescuento.EditValue = objModificaPrecio.Descuento;
            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);*/




        }

        private void btnCalcula_Click(object sender, EventArgs e)
        {
            if (IdClasificacionCliente != Parametros.intPublicitario)
            {
                XtraMessageBox.Show("Esta opción es aplicable para clientes publicitarios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0)
            {
                ////if (Convert.ToDecimal(txtCantidad.EditValue) > Stock)
                //if (Parametros.bStockNegativo == false)
                //{ 
                //    if (Convert.ToDecimal(txtCantidad.EditValue) > Stock  & Parametros.intTiendaId == Parametros.intTiendaUcayali)
                //    {
                //        XtraMessageBox.Show("Stock insuficiente en Almacén. Cantidad:" +   Stock +" , Puede vender la muestra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtCantidad.EditValue = Stock;
                //        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Stock;
                //        return;
                //    }
                //}

                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                FlagPresionado = true;
                VerificarStockVariosALmacen();
                txtObservacion.Focus();
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void chkMuestra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
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
                    XtraMessageBox.Show("La cantidad no puede ser 0 ó Menor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }


                // Realiza una validación especial cuando la observación es "muestra",
                // el checkbox de muestra no está marcado,
                // el identificador de la tienda coincide con el de Ucayali
                // y la variable booleana bPreVenta es falsa.

                if (txtObservacion.Text.Trim().ToLower() == "muestra" && chkMuestra.Checked == false && Parametros.intTiendaId == Parametros.intTiendaUcayali && bPreVenta == false)
                {
                    XtraMessageBox.Show("Ud esta descargando mal el código, esto afectará al stock. En consecuencia se emitirá un reporte con estas falencias. Consultar con Sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }

                var desc = txtDescuento.EditValue;

                /// <summary>
                /// Realiza una serie de cálculos y validaciones relacionados con la preventa de productos.
                /// </summary>

                if (bPreVenta)
                {
                    int CantidadComprada = 0;
                    int CantidadVendida = 0;
                    int Saldo = 0;
                    int StockComprado = 0;
                    // Obtiene los detalles de preventa del producto basado en el IdProducto
                    PreventaDetalleBE objE_ProductoNavidad = new PreventaDetalleBE();
                    objE_ProductoNavidad = new PreventaDetalleBL().Selecciona(IdProducto);
                    if (objE_ProductoNavidad != null)
                        CantidadComprada = objE_ProductoNavidad.Cantidad;
                    // Obtiene los detalles de pedido relacionados con la preventa de Navidad del producto basado en el IdProducto
                    PedidoDetalleBE objE_ProductoVendido = new PedidoDetalleBE();
                    objE_ProductoVendido = new PedidoDetalleBL().SeleccionaPreVentaNavidad(IdProducto);
                    if (objE_ProductoVendido != null)
                        CantidadVendida = objE_ProductoVendido.Cantidad;
                    // Calcula el stock disponible para la preventa del producto
                    StockComprado = CantidadComprada - CantidadVendida;
                    Saldo = CantidadComprada - (CantidadVendida + Convert.ToInt32(txtCantidad.Text));
                    // Realiza una validación para evitar el stock negativo en la preventa si está configurado
                    if (!Parametros.bStockNegativoPreventa)
                    {
                        if (Saldo < 0)
                        {
                            XtraMessageBox.Show("No se puede vender más del tope permisible\nSu StockActual es :" + StockComprado.ToString() + "\nPara mayor infomación consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                //add 030815
                VerificarStockVariosALmacen();

                //if (IdTipoCliente == Parametros.intTipClienteFinal )
                if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack && IdProducto != Parametros.intIdProductoReparacion) //Add 
                {
                    if (!FlagAumentarCantidad)//add 13-12-2019
                    {
                        if (IdFormaPago == Parametros.intContado)
                        {
                            if (Convert.ToInt32(txtCantidad.EditValue) > CantidadModificada)
                            {
                                XtraMessageBox.Show("No se puede aumentar la cantidad, Ud tiene que hacer un nuevo pedido.\nConsulte con su adminsitrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }

                    if (bNuevo)
                    {
                        CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text), IdLineaProducto);
                    }
                    else
                    {
                        int Cantidad = Convert.ToInt32(txtCantidad.EditValue); //add 240217
                        if (Cantidad != CantidadModificada)
                        {
                            // if (!FlagPromocion2x1) //add211017
                            //     CalculaDescuentoClienteFinal(IdProducto, Convert.ToInt32(txtCantidad.Text), IdLineaProducto);
                        }
                    }
                }



                //bloquear Cantidad

                //Si es Muestra
                if (chkMuestra.Checked == true)
                {
                    IdAlmacen = Parametros.intAlmTiendaUcayali;
                }

                oBE = new PedidoDetalleBE();
                oBE.IdProducto = IdProducto;
                oBE.IdFamiliaProducto = IdFamiliaProducto;
                oBE.IdLineaProducto = IdLineaProducto;
                oBE.IdMarca = IdMarca;
                oBE.DescFamiliaProducto = DescFamiliaProducto;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.IdPedido = IdPedido;
                oBE.IdPedidoDetalle = IdPedidoDetalle;
                oBE.Item = intCorrelativo;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                // El id 73940 se refiera al  GIFTCARD
                oBE.NombreProducto = IdProducto == 73940 ? txtProducto.Text.Trim() + " " + txtObservacion.Text.Trim() : txtProducto.Text.Trim();
                //  oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Medida = Medida;
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.Text);
                oBE.CantidadAnt = Convert.ToInt32(txtCantidad.Text);
                oBE.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                oBE.Descuento = 0;///
                oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                oBE.Observacion = txtObservacion.Text;
                oBE.ObsEscala = "";
                oBE.IdKardex = IdKardex;
                oBE.FlagMuestra = chkMuestra.Checked;
                oBE.FlagRegalo = false;
                oBE.FlagBultoCerrado = bDescuentoBulto;
                oBE.FlagNacional = bFlagNacional;
                oBE.FlagEscala = bFlagEscala;
                oBE.DescPromocion = DescPromocion2x1;
                oBE.IdPromocion2 = IdPromocion2;
                //oBE.PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.Text);
                oBE.IdProductoArmado = IdProductoArmado;
                oBE.FlagCompuesto = FlagCompuesto;
                oBE.IdAlmacen = IdAlmacen;

                if (OrigenNuevo == 1)
                {
                    txtDescuento.EditValue = 50;
                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                    oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                    oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                }
                if (IdFormaPago == Parametros.intObsequio)
                    oBE.CodAfeIGV = Parametros.strGravadoBonificaciones;  //15
                else
                    oBE.CodAfeIGV = Parametros.strGravadoOnerosa;  //10



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
                            
                            if (FlagRamoPersonalizado)
                            {
                                if (IdLineaProducto == 4)
                                    Descuento = 0;
                            }

                            if (FlagFijarDescuento)
                            {
                                Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                            }

                            if (DescAdicional > 0) // ecm 20220610
                            {
                                Descuento = DescAdicional;
                            }
                        }

                        oBE.IdPromocion2 = IdPromocion2;
                        txtDescuento.EditValue = Descuento;
                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                        oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                        oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                        oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                    }
                }
                //if (IdTipoCliente == Parametros.intTipClienteFinal)
                //{
                //    if (FlagRamoPersonalizado)
                //    {
                //        if (IdLineaProducto == 4)
                //        {
                //            txtDescuento.EditValue = 0;

                //            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                //            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                //            oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                //            oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                //            oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                //        }
                //    }
                //}
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
            //int Cantidad = Convert.ToInt32(txtCantidad.Text);
            PromocionTemporalDetalleBE objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto, true);
            if (objE_PromocionTemporal != null)
            {
                Descuento = objE_PromocionTemporal.Descuento;
                IdPromocion2 = objE_PromocionTemporal.IdPromocionTemporalDetalle;
            }
            else
            {
                if (IdMarca != Parametros.intIdMarcaKira)
                {
                    //if (bFlagEscala)
                    //{
                    if (IdProducto == 83617 || IdProducto == 83618)
                    {

                    }      
                    else
                    {
                        // var  var_DescFinalMin = mListaDescuentoClienteFinal.Where(x =>x.CantidadMaxima >= Cantidad).ToList().Min(x => x.PorDescuento);
                        var var_DescFinalMin = mListaDescuentoClienteFinal.Where(x => x.IdClasificacionCliente == IdClasificacionCliente && x.CantidadMaxima >= Cantidad).ToList().Min(x => x.PorDescuento);

                        if (var_DescFinalMin != null)
                        {
                            Descuento = var_DescFinalMin;
                        }
                    }
                }

                //}

            }

            return Descuento;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicarPrecioAB_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaPrecio(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text);
                if (objE_Producto != null)
                {
                    txtPrecioUnitario.EditValue = objE_Producto.PrecioCDSoles;
                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioUnitario_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtPrecioUnitario.EditValue) > 0)
            {
                txtValorVenta.EditValue = Convert.ToDecimal(txtCantidad.EditValue) * Convert.ToDecimal(txtPrecioUnitario.EditValue);
                txtPrecioVenta.EditValue = txtValorVenta.EditValue;
            }
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) optCodigo.Checked = true;
            if (keyData == Keys.F6) optHangTag.Checked = true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
           

        }

        private void VerificarStockVariosALmacen()
        {
            if (!bPreVenta)
            {
                if (Parametros.bStockNegativo == false)
                {
                

                    if (Convert.ToInt32(txtCantidad.EditValue) <= 0)
                    {
                        XtraMessageBox.Show("La cantidad no puede ser 0 ó Menor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                        return;
                    }

                    if (pOperacion == Operacion.Nuevo) //add 1808
                    {
                        bool bFiltro = false;
                        //Add 03/11/2015 ---------------------------
                        if (bAutoservicio && Parametros.intTiendaId == Parametros.intTiendaUcayali && IdTipoCliente == Parametros.intTipClienteFinal && IdFormaPago == Parametros.intContado)
                        {
                            bFiltro = true;
                           
                        }
                       

                        int Cantidad = Convert.ToInt32(txtCantidad.EditValue);

                        StockBE objE_Stock = null;
                        objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);

                        if (objE_Stock != null)
                        {
                            if (Cantidad > objE_Stock.Cantidad)
                            {
                                //(XtraMessageBox.Show("Stock insuficiente, Desea vender de otro Almacén?.\nStock Actual : " + objE_Stock.Cantidad, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                if (XtraMessageBox.Show("Stock insuficiente, Desea ver la cantidad en almacen : " + objE_Stock.Cantidad, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    #region "Mostrar Almacenes"

                                    frmProductoStockVenta frm = new frmProductoStockVenta();
                                    frm.IdProducto = IdProducto;
                                    frm.IdFormaPago = IdFormaPago;
                                    frm.IdPedido = IdPedido;
                                    frm.FiltroAuto = bFiltro;
                                    //frm.Location = new Point(txtCantidad.Right,txtCantidad.Top);
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    if (frm.ShowDialog() == DialogResult.OK)
                                    {
                                        if (frm.TotalAlmacen > 0)
                                        {
                                            mListaStock = frm.mListaStock;
                                            // Actualizamos la lista de Stock
                                            StockBE pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                                            if (pProductoBE != null)
                                            {
                                                mListaStock.Where(w => w.IdProducto == IdProducto).ToList().ForEach(s =>
                                                {
                                                    s.IdFamiliaProducto = pProductoBE.IdFamiliaProducto;
                                                    s.IdMarca = pProductoBE.IdMarca;
                                                    s.FlagNacional = pProductoBE.FlagNacional;
                                                    s.FlagEscala = pProductoBE.FlagEscala;
                                                    s.DescFamiliaProducto = pProductoBE.DescFamiliaProducto;
                                                }
                                                );
                                            }


                                            //txtCantidad.EditValue = frm.TotalCantidad;
                                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * frm.TotalCantidad;

                                            mListaStock = frm.mListaStock;
                                            //foreach (var item in frm.mListaStock)
                                            //{
                                            if (Convert.ToInt32(txtCantidad.EditValue) <= 0)
                                            {
                                                XtraMessageBox.Show("La cantidad no puede ser 0 ó Menor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                txtCantidad.SelectAll();
                                                txtCantidad.Focus();
                                                return;
                                            }

                                            //if (bAutoservicio && Parametros.intTiendaId == Parametros.intTiendaUcayali && IdTipoCliente == Parametros.intTipClienteFinal)
                                            //{
                                            //    XtraMessageBox.Show("Este código esta activado solamente para AUTOSERVICIO", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            //    txtCantidad.SelectAll();
                                            //    txtCantidad.Focus();
                                            //    return;
                                            //}


                                            //if (IdTipoCliente == Parametros.intTipClienteFinal )
                                            if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack && IdProducto != Parametros.intIdProductoReparacion) //Add
                                            {
                                                if (bNuevo)
                                                {
                                                    CalculaDescuentoClienteFinal(IdProducto, frm.TotalCantidad, IdLineaProducto);//Convert.ToInt32(txtCantidad.Text));
                                                }
                                            }

                                            txtDescuento.EditValue = Decuento_Cliente_Final(frm.TotalCantidad);
                                            //Descuento Outlet
                                            DescuentoOutlet = frm.DescuentoOutlet;

                                            //Si es Muestra
                                            if (chkMuestra.Checked == true)
                                            {
                                                IdAlmacen = Parametros.intAlmTiendaUcayali;
                                            }

                                            oBE = new PedidoDetalleBE();
                                            oBE.IdProducto = IdProducto;
                                            oBE.IdLineaProducto = IdLineaProducto;
                                            oBE.IdEmpresa = Parametros.intEmpresaId;
                                            oBE.IdPedido = IdPedido;
                                            oBE.IdPedidoDetalle = IdPedidoDetalle;
                                            oBE.Item = intCorrelativo;
                                            oBE.CodigoProveedor = txtCodigo.Text.Trim();
                                            oBE.NombreProducto = txtProducto.Text.Trim();
                                            oBE.Abreviatura = txtUM.Text.Trim();
                                            oBE.Cantidad = frm.TotalCantidad;//Convert.ToInt32(txtCantidad.Text);
                                            oBE.CantidadAnt = Convert.ToInt32(txtCantidad.Text);
                                            oBE.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                                            oBE.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.Text);
                                            oBE.Descuento = 0;
                                            oBE.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                                            oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.Text);
                                            oBE.Observacion = txtObservacion.Text;
                                            oBE.IdKardex = IdKardex;
                                            oBE.FlagMuestra = chkMuestra.Checked;
                                            oBE.FlagRegalo = false;
                                            oBE.DescPromocion = DescPromocion2x1;
                                            //oBE.PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.Text);
                                            oBE.IdProductoArmado = IdProductoArmado;
                                            oBE.FlagCompuesto = FlagCompuesto;
                                            oBE.IdAlmacen = IdAlmacen;

                                            if (pProductoBE != null)
                                            {
                                                oBE.IdFamiliaProducto = pProductoBE.IdFamiliaProducto;
                                                oBE.IdMarca = pProductoBE.IdMarca;
                                                oBE.FlagNacional = pProductoBE.FlagNacional;
                                                oBE.FlagEscala = pProductoBE.FlagEscala;
                                                oBE.DescFamiliaProducto = pProductoBE.DescFamiliaProducto;
                                                oBE.ObsEscala = "";
                                            }

                                            if (IdFormaPago == Parametros.intObsequio)
                                                oBE.CodAfeIGV = Parametros.strGravadoEntregaTrabajadores;
                                            else
                                                oBE.CodAfeIGV = Parametros.strGravadoOnerosa;

                                            this.DialogResult = DialogResult.OK;

                                        }
                                    }
                                    else
                                    {
                                        if (!bFiltro)
                                            txtCantidad.EditValue = objE_Stock.Cantidad;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    if (!bFiltro)
                                        txtCantidad.EditValue = objE_Stock.Cantidad;
                                }
                            }
                        }
                    }
                    else
                    {
                        int Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                        if (Cantidad > CantidadModificada)
                        {
                            Cantidad = Cantidad - CantidadModificada;
                            StockBE objE_Stock = null;
                            objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, IdAlmacen, IdProducto);

                            if (objE_Stock != null)
                            {
                                if (Cantidad > objE_Stock.Cantidad)
                                {
                                    if (XtraMessageBox.Show("Stock Insuficiente, Disponible : " + (Convert.ToInt32(objE_Stock.Cantidad) + Convert.ToInt32(CantidadModificada)) + " " + objE_Stock.Abreviatura + " Incluyendo la cantidad reservada.\nEn Modo edición sólo se puede vender del almacén origen.\nDesea vender todo de este almacén?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        txtCantidad.EditValue = (Convert.ToInt32(objE_Stock.Cantidad) + Convert.ToInt32(CantidadModificada));
                                    }
                                    else
                                    {
                                        txtCantidad.EditValue = CantidadModificada;
                                    }
                                    //XtraMessageBox.Show("Stock Insuficiente, Disponible : " +  (Convert.ToInt32(objE_Stock.Cantidad) + Convert.ToInt32(CantidadModificada)) + " " + objE_Stock.Abreviatura + " Incluyendo la cantidad reservada.\nEn Modo edición sólo se puede vender del almacén origen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }

                            }
                        }

                    }  //Modficar la cantidad del producto

                }
            }

            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
        }

        private void btnCantidadBulto_Click(object sender, EventArgs e)
        {
            if (bPreVenta)
            {
                return;
            }

            frmProductoStockBulto frm = new frmProductoStockBulto();
            frm.IdProducto = IdProducto;
            frm.IdFormaPago = IdFormaPago;
            frm.IdTipoCliente = IdTipoCliente;
            //frm.Location = new Point(txtCantidad.Right,txtCantidad.Top);
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCantidad.EditValue = frm.TotalCantidad;
                bDescuentoBulto = true;
                txtObservacion.Text = "BULTO CERRADO";
                txtObservacion.Enabled = false;

                txtCodigo.Text = frm.IdProducto.ToString();

                //------------------------

                Decimal DescuentoExtra = 0;


                #region "Por HangTag"


                StockBE pProductoBE = null;

                if (txtCodigo.Text.Trim().Count() > 6)
                {
                    //pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmTienda, txtCodigo.Text.Trim());
                    pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtCodigo.Text.Trim());
                }
                else
                {
                    //pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmTienda, Convert.ToInt32(txtCodigo.Text.Trim()));
                    pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, Convert.ToInt32(txtCodigo.Text.Trim()));
                }

                if (pProductoBE != null)
                {
                    Stock = pProductoBE.Cantidad; //Add 13 jun



                    IdProducto = pProductoBE.IdProducto;
                    IdProductoArmado = pProductoBE.IdProductoArmado;
                    IdLineaProducto = pProductoBE.IdLineaProducto;
                    txtCodigo.Text = pProductoBE.CodigoProveedor;
                    txtProducto.Text = pProductoBE.NombreProducto;
                    txtUM.Text = pProductoBE.Abreviatura;
                    //txtCantidad.EditValue = 1;

                    if (pProductoBE.FlagNacional == false)
                        DescuentoExtra = Parametros.dmlDescuentoMayoristaExtra;

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

                    //Stock = pProductoBE.Cantidad;
                    bAutoservicio = pProductoBE.FlagAutoservicio;
                    FlagCompuesto = pProductoBE.FlagCompuesto;
                    IdAlmacen = Parametros.intAlmCentralUcayali;//pProductoBE.IdAlmacen;
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();

                    //PorcentajeDescuentoBase = Convert.ToDecimal(txtDescuento.EditValue);

                    //Codigo libre para Modificar

                    #region "Codigo de libre Modificacion"
                    if (IdProducto == Parametros.intIdProductoReparacion || IdProducto == 91018)
                    {
                        txtPrecioUnitario.Properties.ReadOnly = false;
                        txtPrecioVenta.Properties.ReadOnly = false;
                        txtDescuento.EditValue = 0;
                    }
                    else
                    {
                        txtPrecioUnitario.Properties.ReadOnly = true;
                        txtPrecioVenta.Properties.ReadOnly = true;
                    }
                    #endregion

                    PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.Text);

                    #endregion


                    //txtCodigo.Enabled = false;
                    txtCodigo.Properties.ReadOnly = true;
                    ////txtDescuento.EditValue = objModificaPrecio.Descuento;
                    //txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                    //txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                }
            }
        }

        private void BloquearEditar()
        {
            btnCantidadBulto.Enabled = false;
            txtCodigo.Properties.ReadOnly = true;

        }

        private void MostrarDescuentoOriginal()
        {
            if (!bPreVenta)
            {
                StockBE pProductoBE = null;
                Decimal DescuentoExtra = 0; // Cliente Mayorista y Producto Nacional

                pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, IdAlmacen, IdProducto);

                if (pProductoBE != null)
                {
                    IdProducto = pProductoBE.IdProducto;
                    IdProductoArmado = pProductoBE.IdProductoArmado;
                    IdLineaProducto = pProductoBE.IdLineaProducto;
                    txtCodigo.Text = pProductoBE.CodigoProveedor;
                    txtProducto.Text = pProductoBE.NombreProducto;
                    txtUM.Text = pProductoBE.Abreviatura;

                    if (pProductoBE.FlagNacional == false)
                        DescuentoExtra = Parametros.dmlDescuentoMayoristaExtra;

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


                    //Codigo libre para Modificar

                    #region "Codigo de libre Modificacion"
                    if (IdProducto == Parametros.intIdProductoReparacion || IdProducto == 91018)
                    {
                        txtPrecioUnitario.Properties.ReadOnly = false;
                        txtPrecioVenta.Properties.ReadOnly = false;
                        txtDescuento.EditValue = 0;
                    }
                    else
                    {
                        txtPrecioUnitario.Properties.ReadOnly = true;
                        txtPrecioVenta.Properties.ReadOnly = true;
                    }
                    #endregion

                    PorcentajeDescuentoInicial = Convert.ToDecimal(txtDescuento.Text);
                }
            }


        }

        private void btnAutorizarAutoservicio_Click(object sender, EventArgs e)
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita && frmAutoriza.FlagMaster)
            {
                if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerSupervisorVentasPiso)
                {
                    bAutoservicio = false;
                    XtraMessageBox.Show("Producto libre de autoservicio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId ==  || Parametros.strUsuarioLogin == "rtapia" || Parametros.strUsuarioLogin == "dhuaman" || Parametros.strUsuarioLogin == "rovega" )
                //{ 

                //}
            }
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
                    decDescuentoOrigen = objE_Stock.Descuento;  // Trae el descuento de la lista de precios (Actualmente ya no se sube descuento mediante la lista de precios, ahora se realiza por la promociones temporales)

                    #region "Sin escala de descuento - check marcado en el producto si va aceptar descuentos" 
                    if (objE_Stock.FlagEscala == false) // 
                    {
                        txtDescuento.EditValue = decDescuentoOrigen;
                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                        return;
                    }
                    #endregion

                    // normal
                    /*                  -----------------------------------------------------------------------
                                        - Clasificación Cantidad Min Cantidad Max T. Precio % Dscto Opcional  -
                    *                   -----------------------------------------------------------------------
                                              CLASICO         0           2       CD          0   FALSE
                                              CLASICO         3           5       CD          5   FALSE
                                              CLASICO         6           12      CD          10  FALSE
                                              CLASICO         13          1000    CD          15  FALSE
                                              GOLD            1           12      CD          10  FALSE
                                              GOLD            13          1000    CD          15  FALSE
                                              BLACK           1           000     AB          12  FALSE
                                              EMPRESA - INTERNO 0         9999    AB          50  FALSE  
                                       -----------------------------------------------------------------------        */
                    #region "Descuento x Cantidad"
                    foreach (var item in mListaDescuentoClienteFinal)
                    {
                        if (Cantidad >= item.CantidadMinima && Cantidad <= item.CantidadMaxima)
                        {
                            ///1
                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                txtPrecioUnitario.EditValue = decPrecioCD;

                                if (IdLineaProducto != 4)
                                {
                                    decDescuento = item.PorDescuento;
                                }

                                if (decDescuentoOrigen > decDescuento)
                                {
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtDescuento.EditValue = item.PorDescuento;
                                    if (IdLineaProducto != 4)
                                    { txtDescuento.EditValue = item.PorDescuento; }
                                    else
                                    { txtDescuento.EditValue = 0; }//validacion Flores--> 2022
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }

                            ///2
                            if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD && item.PorDescuento > 0)
                            {
                                if (IdMoneda == Parametros.intSoles)
                                    decPrecioCD = objE_Stock.PrecioCDSoles;
                                else
                                    decPrecioCD = objE_Stock.PrecioCD;

                                txtPrecioUnitario.EditValue = decPrecioCD;
                                if (IdLineaProducto != 4)
                                { decDescuento = item.PorDescuento; }

                                if (decDescuentoOrigen > decDescuento)
                                {
                                    txtDescuento.EditValue = decDescuentoOrigen;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    if (IdLineaProducto != 4)
                                    { txtDescuento.EditValue = item.PorDescuento; }
                                    else
                                    { txtDescuento.EditValue = 0; }
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                //}

                                ///3
                                if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioAB && item.PorDescuento == 0)
                                {
                                    if (IdMoneda == Parametros.intSoles)
                                        decPrecioAB = objE_Stock.PrecioABSoles;
                                    else
                                        decPrecioAB = objE_Stock.PrecioAB;

                                    txtPrecioUnitario.EditValue = decPrecioAB;
                                    if (IdLineaProducto != 4)
                                    { decDescuento = item.PorDescuento; }
                                    if (decDescuentoOrigen > decDescuento)
                                    {
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        if (IdLineaProducto != 4)
                                        { txtDescuento.EditValue = item.PorDescuento; }
                                        else
                                        { txtDescuento.EditValue = 0; }
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }

                                ///4
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
                                        txtDescuento.EditValue = item.PorDescuento;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                }

                                ///5
                                if (IdClasificacionCliente == item.IdClasificacionCliente && item.IdTipoPrecio == Parametros.intTipoPrecioCD && item.PorDescuento > 0)
                                {
                                    if (IdMoneda == Parametros.intSoles)

                                        decPrecioCD = objE_Stock.PrecioCDSoles;
                                    else
                                        decPrecioCD = objE_Stock.PrecioCD;

                                    txtPrecioUnitario.EditValue = decPrecioCD;
                                    if (IdLineaProducto != 4)
                                    { decDescuento = item.PorDescuento; }
                                    //decDescuento = item.PorDescuento; 
                                    //     decDescuento = item.PorDescuento;
                                    if (decDescuentoOrigen > decDescuento)
                                    {
                                        txtDescuento.EditValue = decDescuentoOrigen;
                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        if (IdLineaProducto != 4)
                                        { txtDescuento.EditValue = item.PorDescuento; }
                                        else
                                        { txtDescuento.EditValue = 0; }

                                        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }

                                }
                            }
                        }
                        #endregion

                        #region "Descuento Encuesta"
                        if (objE_Stock.IdLineaProducto < Parametros.intLineaNavidad && Convert.ToDecimal(txtDescuento.EditValue) == 0 && bDescuentoEncuesta == true)//Regular
                        {
                            txtDescuento.EditValue = Parametros.dmlDescuentoEncuesta;
                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                        }
                        #endregion

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
                                        decDescuentoClubDesign = Convert.ToDecimal(25.00);
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

                        #region "Descuento Promocion Detalle"
                        if (ItemsDescuentoPromocion > 0)
                        {
                            DescuentoClientePromocionDetalleBE objE_DescuentoPromocionD = null;
                            objE_DescuentoPromocionD = new DescuentoClientePromocionDetalleBL().SeleccionaProducto(IdDescuentoClientePromocion, IdProducto);

                            if (objE_DescuentoPromocionD != null)//Detalle promoción add2502
                            {
                                if (Convert.ToDecimal(txtDescuento.EditValue) < objE_DescuentoPromocionD.Descuento)//Regular y Descuento Promocion
                                {
                                    txtDescuento.EditValue = objE_DescuentoPromocionD.Descuento;
                                    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToDecimal(txtDescuento.EditValue) < PorcentajeDescuentoClientePromocion)//Regular y Descuento Promocion
                            {
                                txtDescuento.EditValue = PorcentajeDescuentoClientePromocion;
                                txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                            }
                        }
                        #endregion

                        //Test de velocidad por Hora
                        #region "Descuento Promocion Temporal"
                        PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                        objE_PromocionTemporal = new PromocionTemporalDetalleBL().Selecciona(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, Parametros.intTiendaId, IdTipoVenta, IdProducto);
                        if (objE_PromocionTemporal != null)
                        {
                            if (Convert.ToDecimal(txtDescuento.EditValue) < objE_PromocionTemporal.Descuento) //Regular y Descuento Promocion
                            {
                                txtDescuento.EditValue = objE_PromocionTemporal.Descuento;
                                txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                //txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100), 2);
                                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                            }
                        }
                        #endregion

                        #region "Descuento de Cumpleaños - DESABILITADO 24/02/2022" 
                        //if (bDescuentoCumpleanio)
                        //{
                        //    if (Convert.ToDecimal(txtDescuento.EditValue) <= 50 /*&& !bFlagNacional*/)
                        //    {
                        //        txtDescuento.EditValue = Convert.ToDecimal(txtDescuento.EditValue) + 10;
                        //        txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                        //        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                        //    }
                        //}
                        #endregion


                        #region "Descuento Vale"
                        if (DescuentoVale > 0)
                        {
                            if (Convert.ToDecimal(txtDescuento.EditValue) < 80)//Regular y Descuento Promocion
                            {
                                txtDescuento.EditValue = Convert.ToDecimal(txtDescuento.EditValue) + DescuentoVale;
                                txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                            }
                        }
                        #endregion

                        //#region "Descuento Promocion"
                        //if ( Convert.ToDecimal(txtDescuento.EditValue) < PorcentajeDescuentoClientePromocion)//Regular y Descuento Promocion
                        //{
                        //    txtDescuento.EditValue = PorcentajeDescuentoClientePromocion;
                        //    txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                        //    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                        //}
                        //#endregion

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
    }
}