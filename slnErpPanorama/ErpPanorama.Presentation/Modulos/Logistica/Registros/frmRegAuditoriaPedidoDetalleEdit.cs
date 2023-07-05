using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegAuditoriaPedidoDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdTienda { get; set; }
        public int IdAlmacen { get; set; }
        public bool HangTag { get; set; }

        public int IdProducto = 0;

        int _IdInventario = 0;

        public int IdInventario
        {
            get { return _IdInventario; }
            set { _IdInventario = value; }
        }


        public InventarioBE oBE;


        #endregion

        #region "Eventos"
        public frmRegAuditoriaPedidoDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmRegAuditoriaPedidoDetalleEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro de Auditoria - Nuevo";
                if (HangTag == true)
                {
                    optHangTag.Checked = true;
                }
                else
                {
                    optCodigo.Checked = true;
                }
            }
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnAceptar.Focus();
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
                            //frmBusProducto objBusProducto = new frmBusProducto();
                            frmBusProductoInventario objBusProducto = new frmBusProductoInventario();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                IdProducto = objBusProducto.pProductoBE.IdProducto;
                                txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                            }
                        }

                        //Hang Tag

                        if (optHangTag.Checked)
                        {

                            ProductoBE objE_Producto = null; //ADD
                            if (txtCodigo.Text.Trim().Count() > 6)
                                objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            else
                                objE_Producto = new ProductoBL().SeleccionaIDTodos(Convert.ToInt32(txtCodigo.Text.Trim()));

                            //ProductoBE objE_Producto = null;
                            //objE_Producto = new ProductoBL().SeleccionaIDTodos(Convert.ToInt32(txtCodigo.Text.Trim()));
                            if (objE_Producto != null)
                            {
                                IdProducto = objE_Producto.IdProducto;
                                txtCodigo.Text = objE_Producto.CodigoProveedor;
                                txtProducto.Text = objE_Producto.NombreProducto;
                                txtUM.Text = objE_Producto.Abreviatura;
                                txtCantidad.EditValue = 1;
                                btnGrabar_Click(sender, e);
                            }
                            else
                            {
                                if (txtCodigo.Text.Trim().Count() > 6) // CodigoBarra de Importación 
                                {
                                    frmRegCodigoBarra frm = new frmRegCodigoBarra();
                                    frm.strCodigoBarra = txtCodigo.Text;
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    if (frm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtCodigo_KeyUp(sender, e);
                                        return;
                                    }
                                }
                                XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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

        private void btnGrabar_Click(object sender, EventArgs e)
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


                oBE = new InventarioBE();
                oBE.IdProducto = IdProducto;
                oBE.IdEmpresa = Parametros.intEmpresaId;
                oBE.CodigoProveedor = txtCodigo.Text.Trim();
                oBE.NombreProducto = txtProducto.Text.Trim();
                oBE.Abreviatura = txtUM.Text.Trim();
                oBE.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                oBE.Fecha = DateTime.Now;
                oBE.FlagEstado = true;

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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) optCodigo.Checked = true;
            if (keyData == Keys.F6) optHangTag.Checked = true;
            if (keyData == Keys.Escape) this.Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"



        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";


            if (IdProducto == 0)
            {
                strMensaje = strMensaje + "- Seleccione un producto.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                strMensaje = strMensaje + "- Ingresar una cantidad.\n";
                flag = true;
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion


    }
}