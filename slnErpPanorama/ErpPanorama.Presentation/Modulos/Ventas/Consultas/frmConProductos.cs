using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConProductos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private int IdProducto = 0;

        #endregion

        #region "Eventos"

        public frmConProductos()
        {
            InitializeComponent();
        }

        private void frmConProductos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {

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

        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    picImage.Image.Save(saveFileDialog1.FileName);
                    XtraMessageBox.Show("La imagen se grabó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion

        private void btnVerStock_Click(object sender, EventArgs e)
        {
            frmProductoStock frm = new frmProductoStock();
            frm.IdProducto = IdProducto;
            frm.ShowDialog();
        }

        private void btnAuditoriaDescuento_Click(object sender, EventArgs e)
        {
            frmBusAuditoriaDescuento frm = new frmBusAuditoriaDescuento();
            frm.IdProducto = IdProducto;
            frm.ShowDialog();
        }

        #region "Metodos"

        #endregion

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
                            txtCodigoProveedor.Text = objE_Producto.CodigoProveedor;
                            txtUnidadMedida.Text = objE_Producto.Abreviatura;
                            //txtAño.Text = objE_Producto.Fecha.Year.ToString();
                            txtAño.Text = objE_Producto.Fecha.ToString("MMM, yyyy");
                            txtNombreProducto.Text = objE_Producto.NombreProducto;
                            txtNombre.Text = objE_Producto.NombreProducto;
                            txtDescripcion.Text = objE_Producto.Descripcion;
                            txtMedida.Text = objE_Producto.Medida;
                            txtPeso.Text = objE_Producto.Peso.ToString();
                            txtMarca.Text = objE_Producto.DescMarca;
                            txtProcedencia.Text = objE_Producto.DescProcedencia;
                            txtCodigoBarra.Text = objE_Producto.CodigoBarra;
                            txtCodigoHangTag.Text = objE_Producto.IdProducto.ToString();
                            txtLinea.Text = objE_Producto.DescLineaProducto;
                            txtSubLinea.Text = objE_Producto.DescSubLineaProducto;
                            txtModelo.Text = objE_Producto.DescModeloProducto;
                            txtMaterial.Text = objE_Producto.DescMaterial;
                            txtCodigoPanorama.Text = objE_Producto.CodigoPanorama;

                            txtMedidaIh.EditValue = objE_Producto.MedidaInternaAltura;
                            txtMedidaIw.EditValue = objE_Producto.MedidaInternaAncho;
                            txtMedidaIp.EditValue = objE_Producto.MedidaInternaProfundidad;
                            txtMedidaEh.EditValue = objE_Producto.MedidaExternaAltura;
                            txtMedidaEw.EditValue = objE_Producto.MedidaExternaAncho;
                            txtMedidaEp.EditValue = objE_Producto.MedidaExternaProfundidad;
                            txtPesoNeto.EditValue = objE_Producto.PesoNeto;
                            txtPesoBruto.EditValue = objE_Producto.PesoBruto;

                            txtPrecioAB.EditValue = objE_Producto.PrecioAB;
                            txtPrecioCD.EditValue = objE_Producto.PrecioCD;
                            //txtTCMinorista.EditValue = Parametros.dmlTCMinorista;
                            txtTCMayorista.EditValue = Parametros.dmlTCMayoristaInterna;
                            txtTCMinoristaNacional.EditValue = Parametros.dmlTCMinoristaNacional;
                            txtPrecioABMayorista.EditValue = objE_Producto.PrecioAB * Convert.ToDecimal(Parametros.dmlTCMayoristaInterna);

                            txtTCMinorista.EditValue = objE_Producto.TipoCambioCD;
                            txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;

                            txtColeccion.EditValue = objE_Producto.Coleccion;

                            if (objE_Producto.FlagNacional)
                            {
                                //txtTCMinorista.EditValue = Parametros.dmlTCMinoristaNacional;
                                //txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinoristaNacional);
                                picOrigen.Visible = true;
                            }
                            else
                            {
                                //txtTCMinorista.EditValue = Parametros.dmlTCMinorista;
                                //txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                                picOrigen.Visible = false;
                            }


                            ////txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                            ///*if (objE_Producto.FlagNacional == true)
                            //{
                            //    if (Parametros.intEmpresaId == Parametros.intCoronaImportadores)
                            //    {
                            //        txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                            //    }
                            //    else
                            //    {
                            //        txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMayorista);
                            //    }
                            //}
                            //else*/
                            //txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);

                            txtDescuento.EditValue = objE_Producto.Descuento;
                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioCDMinorista.EditValue) * ((100 - Convert.ToDecimal(txtDescuento.EditValue)) / 100);
                            if (objE_Producto.Imagen != null)
                            {
                                this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                            }
                            else
                            { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

                            //pictureBox1.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);

                            #region "Descuento Temporal"
                            PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                            objE_PromocionTemporal = new PromocionTemporalDetalleBL().SeleccionaUltimo(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto);

                            if (objE_PromocionTemporal != null)
                            {
                                txtDescuentoTemporal.EditValue = objE_PromocionTemporal.Descuento;
                                txtPrecioVentaTemporal.EditValue = Convert.ToDecimal(txtPrecioCDMinorista.EditValue) * ((100 - Convert.ToDecimal(txtDescuentoTemporal.EditValue)) / 100);
                                // Ecommerce
                                txtDescuentoEcommerce.EditValue = objE_PromocionTemporal.DsctoEcommerce;
                                txtPrecioVentaEcommerce.EditValue = Convert.ToDecimal(txtPrecioCDMinorista.EditValue) * ((100 - Convert.ToDecimal(txtDescuentoEcommerce.EditValue)) / 100);
                            }
                            else
                            {
                                txtDescuentoTemporal.EditValue = 0;
                                txtPrecioVentaTemporal.EditValue = 0;

                                txtDescuentoEcommerce.EditValue = 0;
                                txtPrecioVentaEcommerce.EditValue = 0;
                            }
                            #endregion

                            #region "Descuento 2x1"

                            lblMensajePromocion.Text = "";
                            Promocion2x1DetalleBE objE_Promocion2x1 = null;
                            objE_Promocion2x1 = new Promocion2x1DetalleBL().SeleccionaProducto(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto, "2x1", DateTime.Now);

                            if (objE_Promocion2x1 != null)
                            {
                                lblMensajePromocion.Text = "2x1";
                            }

                            Promocion2x1DetalleBE objE_Promocion3x2 = null;
                            objE_Promocion3x2 = new Promocion2x1DetalleBL().SeleccionaProducto(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto, "3x2", DateTime.Now);
                            if (objE_Promocion3x2 != null)
                            {
                                lblMensajePromocion.Text = (lblMensajePromocion.Text + "    3x2").Trim();
                            }

                            Promocion2x1DetalleBE objE_Promocion6x3 = null;
                            objE_Promocion6x3 = new Promocion2x1DetalleBL().SeleccionaProducto(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto, "6x3", DateTime.Now);
                            if (objE_Promocion6x3 != null)
                            {
                                lblMensajePromocion.Text = (lblMensajePromocion.Text + "    6x3").Trim();
                            }

                            #endregion

                            //Eliminado
                            if (!objE_Producto.FlagEstado)
                                lblMensajeEliminado.Visible = true;
                            else
                                lblMensajeEliminado.Visible = false;

                            //txtDescuento.Focus();
                            txtCodigo.SelectAll();

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
                            txtCodigoProveedor.Text = objE_Producto.CodigoProveedor;
                            txtUnidadMedida.Text = objE_Producto.Abreviatura;
                            //txtAño.Text = objE_Producto.Fecha.Year.ToString();
                            txtAño.Text = objE_Producto.Fecha.ToString("MMM, yyyy");
                            txtNombreProducto.Text = objE_Producto.NombreProducto;
                            txtNombre.Text = objE_Producto.NombreProducto;
                            txtDescripcion.Text = objE_Producto.Descripcion;
                            txtMedida.Text = objE_Producto.Medida;
                            txtPeso.Text = objE_Producto.Peso.ToString();
                            txtMarca.Text = objE_Producto.DescMarca;
                            txtProcedencia.Text = objE_Producto.DescProcedencia;
                            txtCodigoBarra.Text = objE_Producto.CodigoBarra;
                            txtCodigoHangTag.Text = objE_Producto.IdProducto.ToString();
                            txtLinea.Text = objE_Producto.DescLineaProducto;
                            txtSubLinea.Text = objE_Producto.DescSubLineaProducto;
                            txtModelo.Text = objE_Producto.DescModeloProducto;
                            txtMaterial.Text = objE_Producto.DescMaterial;
                            txtMedidaIh.EditValue = objE_Producto.MedidaInternaAltura;
                            txtMedidaIw.EditValue = objE_Producto.MedidaInternaAncho;
                            txtMedidaIp.EditValue = objE_Producto.MedidaInternaProfundidad;
                            txtMedidaEh.EditValue = objE_Producto.MedidaExternaAltura;
                            txtMedidaEw.EditValue = objE_Producto.MedidaExternaAncho;
                            txtMedidaEp.EditValue = objE_Producto.MedidaExternaProfundidad;
                            txtPesoNeto.EditValue = objE_Producto.PesoNeto;
                            txtPesoBruto.EditValue = objE_Producto.PesoBruto;
                            txtCodigoPanorama.Text = objE_Producto.CodigoPanorama;
                            txtPrecioAB.EditValue = objE_Producto.PrecioAB;
                            txtPrecioCD.EditValue = objE_Producto.PrecioCD;
                            txtTCMinorista.EditValue = Parametros.dmlTCMinorista;
                            txtTCMayorista.EditValue = Parametros.dmlTCMayoristaInterna;
                            txtPrecioABMayorista.EditValue = objE_Producto.PrecioAB * Convert.ToDecimal(Parametros.dmlTCMayoristaInterna);

                            txtTCMinorista.EditValue = objE_Producto.TipoCambioCD;
                            txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;

                            txtColeccion.EditValue = objE_Producto.Coleccion;

                            if (objE_Producto.FlagNacional) //add 0308
                            {
                                //txtTCMinorista.EditValue = Parametros.dmlTCMinoristaNacional;
                                //txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinoristaNacional);
                                picOrigen.Visible = true;
                            }
                            else
                            {
                                //txtTCMinorista.EditValue = Parametros.dmlTCMinorista;
                                //txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                                picOrigen.Visible = false;
                            }


                            /////txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);

                            ///*if (objE_Producto.FlagNacional == true)
                            //{
                            //    if (Parametros.intEmpresaId == Parametros.intCoronaImportadores)
                            //    {
                            //        txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                            //    }
                            //    else
                            //    {
                            //        txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMayorista);
                            //    }
                            //}
                            //else*/
                            //txtPrecioCDMinorista.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);                            

                            txtDescuento.EditValue = objE_Producto.Descuento;
                            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioCDMinorista.EditValue) * ((100 - Convert.ToDecimal(txtDescuento.EditValue)) / 100);

                            if (objE_Producto.Imagen != null)
                            {
                                this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                            }
                            else
                            { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }


                            //pictureBox1.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);


                            #region "Descuento Temporal"

                            PromocionTemporalDetalleBE objE_PromocionTemporal = null;
                            objE_PromocionTemporal = new PromocionTemporalDetalleBL().SeleccionaUltimo(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto);

                            if (objE_PromocionTemporal != null)
                            {
                                txtDescuentoTemporal.EditValue = objE_PromocionTemporal.Descuento;
                                txtPrecioVentaTemporal.EditValue = Convert.ToDecimal(txtPrecioCDMinorista.EditValue) * ((100 - Convert.ToDecimal(txtDescuentoTemporal.EditValue)) / 100);
                                // Ecommerce
                                txtDescuentoEcommerce.EditValue = objE_PromocionTemporal.DsctoEcommerce;
                                txtPrecioVentaEcommerce.EditValue = Convert.ToDecimal(txtPrecioCDMinorista.EditValue) * ((100 - Convert.ToDecimal(txtDescuentoEcommerce.EditValue)) / 100);
                            }
                            else
                            {
                                txtDescuentoTemporal.EditValue = 0;
                                txtPrecioVentaTemporal.EditValue = 0;

                                txtDescuentoEcommerce.EditValue = 0;
                                txtPrecioVentaEcommerce.EditValue = 0;
                            }

                            #endregion

                            #region "Descuento 2x1"

                            lblMensajePromocion.Text = "";
                            Promocion2x1DetalleBE objE_Promocion2x1 = null;
                            objE_Promocion2x1 = new Promocion2x1DetalleBL().SeleccionaProducto(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto, "2x1", DateTime.Now);

                            if (objE_Promocion2x1 != null)
                            {
                                lblMensajePromocion.Text = "2x1";
                            }

                            Promocion2x1DetalleBE objE_Promocion3x2 = null;
                            objE_Promocion3x2 = new Promocion2x1DetalleBL().SeleccionaProducto(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto, "3x2", DateTime.Now);
                            if (objE_Promocion3x2 != null)
                            {
                                lblMensajePromocion.Text = (lblMensajePromocion.Text + "    3x2").Trim();
                            }

                            Promocion2x1DetalleBE objE_Promocion6x3 = null;
                            objE_Promocion6x3 = new Promocion2x1DetalleBL().SeleccionaProducto(Parametros.intEmpresaId, Parametros.intTipClienteFinal, Parametros.intContado, Parametros.intTiendaId, IdProducto, "6x3", DateTime.Now);
                            if (objE_Promocion6x3 != null)
                            {
                                lblMensajePromocion.Text = (lblMensajePromocion.Text + "    6x3").Trim();
                            }

                            #endregion

                            //Eliminado
                            if (!objE_Producto.FlagEstado)
                                lblMensajeEliminado.Visible = true;
                            else
                                lblMensajeEliminado.Visible = false;


                            //txtDescuento.Focus();
                            txtCodigo.SelectAll();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}