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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManProductoTransformacionalDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        //public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public ProductoTransformacionDetalleBE oBE;

        public int IdProductoTransformacion = 0;
        public int IdProductoTransformacionDetalle = 0;

        public int IdProducto = 0;
        public int IdMoneda = 0;

        #endregion

        #region "Eventos"

        public frmManProductoTransformacionalDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmManProductoTransformacionalDetalleEdit_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    frmBusProductoStock objBusProducto = new frmBusProductoStock();
                    objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                    objBusProducto.IdTienda = Parametros.intTiendaId;
                    objBusProducto.IdAlmacen = Parametros.intAlmCentralUcayali;
                    objBusProducto.ShowDialog();
                    if (objBusProducto.pProductoBE != null)
                    {
                        IdProducto = objBusProducto.pProductoBE.IdProducto;
                        txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                        txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                        txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                        txtCantidad.EditValue = 1;
                        txtPrecioVenta.EditValue = objBusProducto.pProductoBE.PrecioABSoles;
                        txtCantidad.SelectAll();
                        txtCantidad.Focus();

                    }
                }
            }
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

                oBE = new ProductoTransformacionDetalleBE();
                oBE.IdProducto = IdProducto;
                oBE.IdProductoTransformacion = IdProductoTransformacion;
                oBE.IdProductoTransformacionDetalle = IdProductoTransformacionDetalle;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                oBE.Costo = Convert.ToDecimal(txtPrecioVenta.EditValue);

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

        #endregion

 
    }
}