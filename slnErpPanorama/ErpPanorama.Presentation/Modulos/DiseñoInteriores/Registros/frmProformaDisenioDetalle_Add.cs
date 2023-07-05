using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmProformaDisenioDetalle_Add : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();
        public ProformaDisenioDetalleBE oBE;

        public int IdProformaDisenio = 0;
        public int IdProformaDisenioDetalle = 0;
        public int IdSituacionProducto = 0;
        public int IdProducto = 0;
        public int IdMoneda = 0;
        public bool bFlagModificado = false;
        public bool bFlagObsequio = false;
        public string sObservacion = "";
        public Image Imagen;

        private List<ProductoBE> mLista = new List<ProductoBE>();

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

        public frmProformaDisenioDetalle_Add()
        {
            InitializeComponent();
        }

        private void frmProformaDisenioDetalle_Add_Load(object sender, EventArgs e)
        {
            txtObservaciones.Text = sObservacion;
            chkModificar.Checked = bFlagModificado;
            chkObsequio.Checked = bFlagObsequio;

            if (Imagen != null)
            {
                this.picImage.Image = Imagen;
            }
            else
            { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;}

            BloquearPorPefil();
            txtCodigo.Focus();            
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtPrecioVenta.Focus();
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
                //if (IdProducto == 0)
                //{
                //    XtraMessageBox.Show("Seleccionar el código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtCodigo.SelectAll();
                //    txtCodigo.Focus();
                //    return;
                //}

                //if (txtCodigo.Text.Trim() == "")
                //{
                //    XtraMessageBox.Show("Seleccionar el código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtCodigo.SelectAll();
                //    txtCodigo.Focus();
                //    return;
                //}

                if (Convert.ToInt32(txtCantidad.EditValue) == 0)
                {
                    XtraMessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }

                int vIdsituacionProducto = 0;
                if(rbSituacion1.Checked)
                {
                    vIdsituacionProducto = 1;
                }
                else if (rbSituacion2.Checked)
                {
                    vIdsituacionProducto = 2;
                }

                oBE = new ProformaDisenioDetalleBE();
                //oBE.IdDis_ContratoFabricacion = IdDis_ContratoFabricacion;
                //oBE.IdDis_ContratoFabricacionDetalle = IdDis_ContratoFabricacionDetalle;
                oBE.IdSituacionProducto = vIdsituacionProducto;
                oBE.IdProducto = IdProducto;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Modelo = txtModelo.Text.Trim();
                oBE.Medida = txtMedida.Text.Trim();
                oBE.Material = txtMaterial.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                oBE.Precio = Convert.ToDecimal(txtPrecioVenta.EditValue);
                oBE.ValorVenta = Convert.ToDecimal(txtValorVenta.EditValue);
                oBE.Observacion = txtObservaciones.Text;
                oBE.FlagModificado = chkModificar.Checked;
                oBE.FlagObsequio = chkObsequio.Checked;
                oBE.Imagen = new FuncionBase().Image2Bytes(picImage.Image);

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

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno || Parametros.intPerfilId == Parametros.intPerSupervisorDiseno)
            {
                frmManProductoProforma objManProducto = new frmManProductoProforma();
                objManProducto.lstProducto = mLista;
                objManProducto.pOperacion = frmManProductoProforma.Operacion.Nuevo;
                objManProducto.IdProducto = 0;
                objManProducto.StartPosition = FormStartPosition.CenterParent;
                objManProducto.ShowDialog();

                IdProducto = objManProducto.IdProducto;
                txtCodigo.Text = objManProducto.CodigoProveedor;
                txtProducto.Text = objManProducto.NombreProducto;
                txtModelo.Text = objManProducto.ModeloProducto;
                txtMaterial.Text = objManProducto.MaterialProducto;
                txtMedida.Text = objManProducto.MedidaProducto;
                txtPrecioUnitario.ReadOnly = false;
            }
            else
            {
                txtCodigo.Text = "";
                txtCodigo.Properties.ReadOnly = true;
                txtProducto.Properties.ReadOnly = false;
                txtModelo.Properties.ReadOnly = false;
                txtMedida.Properties.ReadOnly = false;
                txtMaterial.Properties.ReadOnly = false;
                //chkModificar.Checked = false;
                //chkModificar.Enabled = false;
            }
        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0)
            {
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void chkModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModificar.Checked)
            {
                txtCodigo.Properties.ReadOnly = true;
                txtProducto.Properties.ReadOnly = false;
                txtModelo.Properties.ReadOnly = false;
                txtMedida.Properties.ReadOnly = false;
                txtMaterial.Properties.ReadOnly = false;
                txtPrecioVenta.EditValue = 0;

            }
            else
            {

                if (txtCodigo.Text.Length > 0)
                {
                    ProductoBE objE_Producto = null;
                    //objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, txtCodigo.Text);
                    objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text);

                    if (objE_Producto != null)
                    {
                        IdProducto = objE_Producto.IdProducto;
                        txtCodigo.Text = objE_Producto.CodigoProveedor;
                        txtProducto.Text = objE_Producto.NombreProducto;
                        txtUM.Text = objE_Producto.Abreviatura;
                        txtModelo.Text = objE_Producto.DescModeloProducto;
                        txtMedida.Text = objE_Producto.Medida;
                        txtMaterial.Text = objE_Producto.DescMaterial;
                        txtCantidad.EditValue = 1;
                        //txtPrecioVenta.EditValue = objE_Producto.PrecioCDSoles;//objBusProducto.pProductoBE.PrecioABSoles;


                        if (objE_Producto.FlagNacional)
                        {
                            //txtTCMinorista.EditValue = Parametros.dmlTCMinoristaNacional;
                            txtPrecioVenta.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinoristaNacional);
                        }
                        else
                        {
                            txtPrecioVenta.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                        }

                        if (objE_Producto.Imagen != null)
                        {
                            this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                        }
                        else
                        { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }


                        //txtCodigo.Properties.ReadOnly = true;
                        txtProducto.Properties.ReadOnly = true;
                        txtModelo.Properties.ReadOnly = true;
                        txtMedida.Properties.ReadOnly = true;
                        txtMaterial.Properties.ReadOnly = true;
                        txtPrecioVenta.Properties.ReadOnly = true;



                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("El producto no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) optCodigo.Checked = true;
            if (keyData == Keys.F6) optHangTag.Checked = true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"

        #endregion


        private void CalcularTotales()
        {
            if (Convert.ToDecimal(txtCantidad.EditValue) > 0 )
            {
                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
            }
        }

        private void txtPrecioVenta_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void picImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmProductoFoto frm = new frmProductoFoto();
            frm.Imagen = picImage.Image;
            frm.Show();
        }

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditaPrecio_Click(object sender, EventArgs e)
        {
            frmModificaPrecioDescuento objModificaPrecio = new frmModificaPrecioDescuento();
            objModificaPrecio.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            objModificaPrecio.Descuento = Convert.ToDecimal(txtDescuento.Text);
            objModificaPrecio.IdProducto = IdProducto;
            objModificaPrecio.IdPedido = 0;
            objModificaPrecio.Origen = " - Fabricación";
            objModificaPrecio.Nuevo = true;

            objModificaPrecio.StartPosition = FormStartPosition.CenterParent;
            objModificaPrecio.ShowDialog();

            txtPrecioUnitario.EditValue = objModificaPrecio.PrecioUnitario;
            txtDescuento.EditValue = objModificaPrecio.Descuento;
            txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
            txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);


        }

        private void BloquearPorPefil()
        {
            if (pOperacion == Operacion.Nuevo)
            {
                txtCodigo.Properties.ReadOnly = false;
            }
            else
            {
                //Nuevo
                if (IdProducto == 0)
                {
                    txtCodigo.Properties.ReadOnly = true;
                    txtProducto.Properties.ReadOnly = false;
                    txtPrecioVenta.Properties.ReadOnly = false;
                    txtModelo.Properties.ReadOnly = false;
                    txtMedida.Properties.ReadOnly = false;
                    txtMaterial.Properties.ReadOnly = false;
                    chkModificar.Enabled = false;
                    btnNuevoProducto.Enabled = false;

                    if (Parametros.intPerfilId == Parametros.intPerAdministrador||Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno || Parametros.intPerfilId == Parametros.intPerSupervisorDiseno)
                    {
                        btnNuevoProducto.Enabled = true;
                    }
                }
                //Modificado
                if (bFlagModificado)
                {
                    txtCodigo.Properties.ReadOnly = true;
                    txtProducto.Properties.ReadOnly = false;
                    txtPrecioVenta.Properties.ReadOnly = false;
                    txtModelo.Properties.ReadOnly = false;
                    txtMedida.Properties.ReadOnly = false;
                    txtMaterial.Properties.ReadOnly = false;
                    chkModificar.Enabled = false;
                    btnNuevoProducto.Enabled = false;
                }
                //Original
                //SIN CAMBIOS

                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno || Parametros.intPerfilId == Parametros.intPerSupervisorDiseno || Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin.ToLower() == "ksoria")
                {
                    txtPrecioVenta.Properties.ReadOnly = false;
                    txtCodigo.Properties.ReadOnly = false;
                    txtProducto.Properties.ReadOnly = false;
                    //txtDiasProduccion.Properties.ReadOnly = false;
                }
                else
                {
                    txtPrecioVenta.Properties.ReadOnly = true;
                    //txtDiasProduccion.Properties.ReadOnly = true;
                    //chkModificar.Checked = bFlagModificado;
                }
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

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    #region "Nuevo"
                    if (pOperacion == Operacion.Nuevo)
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
                                    txtProducto.Text = objE_Producto.NombreProducto;
                                    txtUM.Text = objE_Producto.Abreviatura;
                                    txtModelo.Text = objE_Producto.DescModeloProducto;
                                    txtMedida.Text = objE_Producto.Medida;
                                    txtMaterial.Text = objE_Producto.DescMaterial;
                                    txtCantidad.EditValue = 1;
                                    //txtPrecioVenta.EditValue = objE_Producto.PrecioCD;//objBusProducto.pProductoBE.PrecioABSoles;

                                    if (objE_Producto.FlagNacional)
                                    {
                                        //txtTCMinorista.EditValue = Parametros.dmlTCMinoristaNacional;
                                        //txtPrecioVenta.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinoristaNacional);
                                        chkModificar.Enabled = true;

                                        txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD; //Convert.ToDecimal(Parametros.dmlTCMinoristaNacional);
                                        txtDescuento.EditValue = objE_Producto.Descuento;
                                        txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100),2);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        //txtPrecioVenta.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);

                                        txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                        txtDescuento.EditValue = objE_Producto.Descuento;
                                        txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100),2);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                                        chkModificar.Checked = false;
                                        chkModificar.Enabled = false;
                                    }


                                    if (objE_Producto.Imagen != null)
                                    {
                                        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                                    }
                                    else
                                    { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }


                                    txtCantidad.SelectAll();
                                    txtCantidad.Focus();
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
                                    txtProducto.Text = objE_Producto.NombreProducto;
                                    txtUM.Text = objE_Producto.Abreviatura;
                                    txtModelo.Text = objE_Producto.DescModeloProducto;
                                    txtMedida.Text = objE_Producto.Medida;
                                    txtMaterial.Text = objE_Producto.DescMaterial;
                                    txtCantidad.EditValue = 1;
                                    //txtPrecioVenta.EditValue = objE_Producto.PrecioCD;//objBusProducto.pProductoBE.PrecioABSoles;

                                    if (objE_Producto.FlagNacional)
                                    {
                                        //txtTCMinorista.EditValue = Parametros.dmlTCMinoristaNacional;
                                        //txtPrecioVenta.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinoristaNacional);
                                        chkModificar.Enabled = true;

                                        txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                        txtDescuento.EditValue = objE_Producto.Descuento;
                                        txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100),2);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                    }
                                    else
                                    {
                                        //txtPrecioVenta.EditValue = objE_Producto.PrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);

                                        txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                        txtDescuento.EditValue = objE_Producto.Descuento;
                                        txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100),2);
                                        txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                                        chkModificar.Checked = false;
                                        chkModificar.Enabled = false;
                                    }


                                    if (objE_Producto.Imagen != null)
                                    {
                                        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                                    }
                                    else
                                    { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }


                                    txtCantidad.SelectAll();
                                    txtCantidad.Focus();
                                }
                                else
                                {
                                    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    #endregion

                    #region "Modificar"
                    else
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
                            if (objE_Producto != null)
                            {
                                IdProducto = objE_Producto.IdProducto;
                                txtCodigo.Text = objE_Producto.CodigoProveedor;
                                txtProducto.Text = objE_Producto.NombreProducto;
                                txtUM.Text = objE_Producto.Abreviatura;

                                if (objE_Producto.FlagNacional)
                                {
                                    chkModificar.Enabled = true;

                                    txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                    txtDescuento.EditValue = objE_Producto.Descuento;
                                    txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100),2);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                    txtDescuento.EditValue = objE_Producto.Descuento;
                                    txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100),2);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                                    chkModificar.Checked = false;
                                    chkModificar.Enabled = false;
                                }
                                txtCantidad.SelectAll();
                                txtCantidad.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show("El producto no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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
                                txtProducto.Text = objE_Producto.NombreProducto;
                                txtUM.Text = objE_Producto.Abreviatura;

                                if (objE_Producto.FlagNacional)
                                {
                                    chkModificar.Enabled = true;

                                    txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                    txtDescuento.EditValue = objE_Producto.Descuento;
                                    txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100), 2);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    txtPrecioUnitario.EditValue = objE_Producto.PrecioCD * objE_Producto.TipoCambioCD;
                                    txtDescuento.EditValue = objE_Producto.Descuento;
                                    txtPrecioVenta.EditValue = Math.Round(Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100), 2);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

                                    chkModificar.Checked = false;
                                    chkModificar.Enabled = false;
                                }

                                txtCantidad.SelectAll();
                                txtCantidad.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show("El producto no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Select();
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Select();
        }

        private void chkObsequio_Click(object sender, EventArgs e)
        {
            if (!chkObsequio.Checked)
            {
                if (XtraMessageBox.Show("Desea Obsequiar este producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador|| frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno)
                        {
                            txtPrecioUnitario.EditValue = 0;
                            txtDescuento.EditValue = 100;
                            txtPrecioVenta.EditValue = 0;
                            txtValorVenta.EditValue = 0;
                            txtObservaciones.Text = "Obsequio";
                            chkObsequio.Checked = true;
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta acción.", this.Text);
                        }
                    }
                }
            }
            else
            {
                if (XtraMessageBox.Show("Desea eliminar el obsequio de este producto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador|| frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno)
                        {
                            txtPrecioUnitario.EditValue = 0;
                            txtDescuento.EditValue = 0;
                            txtPrecioVenta.EditValue = 0;
                            txtValorVenta.EditValue = 0;
                            txtObservaciones.Text = "";
                            chkObsequio.Checked = false;
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta acción.", this.Text);
                        }
                    }
                }
            }
        }

        private void rbSituacion2_Click(object sender, EventArgs e)
        {
            if (rbSituacion2.Checked)
            {
                btnNuevoProducto.Enabled = true;
                optCodigo.Enabled = false;
                optHangTag.Enabled = false;
                txtUM.Text = "";
                txtCodigo.Text = "";
                txtProducto.Text = "";
                txtModelo.Text = "";
                txtMaterial.Text = "";
                txtMedida.Text = "";
                txtObservaciones.Text = "";
                txtObservaciones.Text = "";
                optCodigo.Enabled = true;
                optHangTag.Enabled = true;
                optCodigo.Checked = true;
                txtUM.Text = "";
                txtPrecioUnitario.Text = new decimal(0).ToString();
                txtPrecioVenta.Text = new decimal(0).ToString();
                txtValorVenta.Text = new decimal(0).ToString();
                txtDescuento.Text = new decimal(0).ToString();
                btnNuevoProducto.Select();
            }
        }

        private void rbSituacion1_Click(object sender, EventArgs e)
        {
            if (rbSituacion1.Checked)
            {
                btnNuevoProducto.Enabled = false;
                txtCodigo.Text = "";
                txtProducto.Text = "";
                txtModelo.Text = "";
                txtMaterial.Text = "";
                txtMedida.Text = "";
                txtObservaciones.Text = "";
                txtObservaciones.Text = "";
                optCodigo.Enabled = true;
                optHangTag.Enabled = true;
                optCodigo.Checked = true;
                txtUM.Text = "";
                txtPrecioUnitario.Text = new decimal(0).ToString();
                txtPrecioVenta.Text = new decimal(0).ToString();
                txtValorVenta.Text = new decimal(0).ToString();
                txtDescuento.Text = new decimal(0).ToString();
                txtCodigo.Select();
            }
        }

        private void rbSituacion1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}