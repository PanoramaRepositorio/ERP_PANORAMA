using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmAsociarCodigo : DevExpress.XtraEditors.XtraForm
    {
        public int IdProducto = 0;
        public int IdProducto2 = 0;

        public frmAsociarCodigo()
        {
            InitializeComponent();
        }

        private void frmAsociarCodigo_Load(object sender, EventArgs e)
        {
            txtCodigo.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (IdProducto == 0)
            {
                XtraMessageBox.Show("Falta ingresar el código que permanecerá", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IdProducto2 == 0)
            {
                XtraMessageBox.Show("Falta ingresar el código que se eliminará", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show("Está seguro de reemplazar todo los movimientos de los códigos " + txtCodigo2.Text + " por " + txtCodigo.Text + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductoBL objBL_Producto = new ProductoBL();
                objBL_Producto.UnificaCodigo(IdProducto, IdProducto2);

                XtraMessageBox.Show("Código actualizado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            frmBusProductoInventario objBusProducto = new frmBusProductoInventario();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                IdProducto = objBusProducto.pProductoBE.IdProducto;
                                txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                txtUM.Text = objBusProducto.pProductoBE.Abreviatura;

                                txtCodigo.Properties.ReadOnly = true;
                            }
                        }
                        if (optHangTag.Checked)
                        {
                            ProductoBE objE_Producto = null; //ADD
                            if (txtCodigo.Text.Trim().Count() > 6)
                                objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            else
                                objE_Producto = new ProductoBL().SeleccionaIDTodos(Convert.ToInt32(txtCodigo.Text.Trim()));

                            if (objE_Producto != null)
                            {
                                IdProducto = objE_Producto.IdProducto;
                                txtCodigo.Text = objE_Producto.CodigoProveedor;
                                txtProducto.Text = objE_Producto.NombreProducto;
                                txtUM.Text = objE_Producto.Abreviatura;
                                txtCodigo.Properties.ReadOnly = true;
                            }
                            else
                            {
                                XtraMessageBox.Show("El código de producto no existe o está deshabilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtCodigo2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCodigo2.Text.Length > 0)
                    {
                        if (optCodigo2.Checked)
                        {
                            frmBusProductoInventario objBusProducto = new frmBusProductoInventario();
                            objBusProducto.pDescripcion = txtCodigo2.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                IdProducto2 = objBusProducto.pProductoBE.IdProducto;
                                txtCodigo2.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                txtProducto2.Text = objBusProducto.pProductoBE.NombreProducto;
                                txtUM2.Text = objBusProducto.pProductoBE.Abreviatura;
                                txtCodigo2.Properties.ReadOnly = true;
                            }
                        }
                        if (optHangTag2.Checked)
                        {
                            ProductoBE objE_Producto = null; //ADD
                            if (txtCodigo2.Text.Trim().Count() > 6)
                                objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo2.Text.Trim()); //Codigo de Barras de Importación
                            else
                                objE_Producto = new ProductoBL().SeleccionaIDTodos(Convert.ToInt32(txtCodigo2.Text.Trim()));

                            if (objE_Producto != null)
                            {
                                IdProducto2 = objE_Producto.IdProducto;
                                txtCodigo2.Text = objE_Producto.CodigoProveedor;
                                txtProducto2.Text = objE_Producto.NombreProducto;
                                txtUM2.Text = objE_Producto.Abreviatura;
                                txtCodigo2.Properties.ReadOnly = true;
                            }
                            else
                            {
                                XtraMessageBox.Show("El código de producto no existe o está deshabilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}