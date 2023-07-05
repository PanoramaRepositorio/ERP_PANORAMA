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
    public partial class frmRegInventarioAnaquelesEdit : DevExpress.XtraEditors.XtraForm
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

        int IdProducto = 0;

        int _IdInventarioAnaqueles = 0;

        public int IdInventarioAnaqueles
        {
            get { return _IdInventarioAnaqueles; }
            set { _IdInventarioAnaqueles = value; }
        }

        public int IdPersonaApoyo = 0;

        #endregion

        #region "Eventos"

        public frmRegInventarioAnaquelesEdit()
        {
            InitializeComponent();
        }

        private void frmRegInventarioAnaquelesEdit_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            //cboTienda.EditValue = IdTienda;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro de InventarioAnaqueles - Nuevo";
                if (HangTag == true)
                {
                    optHangTag.Checked = true;
                }
                else
                {
                    optCodigo.Checked = true;
                }
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro de InventarioAnaqueles - Modificar";

                InventarioAnaquelesBE objE_InventarioAnaqueles = new InventarioAnaquelesBE();

                objE_InventarioAnaqueles = new InventarioAnaquelesBL().Selecciona(Parametros.intEmpresaId, IdInventarioAnaqueles);
                IdInventarioAnaqueles = objE_InventarioAnaqueles.IdInventarioAnaqueles;
                cboTienda.EditValue = objE_InventarioAnaqueles.IdTienda;
                cboAlmacen.EditValue = objE_InventarioAnaqueles.IdAlmacen;
                IdProducto = objE_InventarioAnaqueles.IdProducto;
                txtCodigo.Text = objE_InventarioAnaqueles.CodigoProveedor;
                txtProducto.Text = objE_InventarioAnaqueles.NombreProducto;
                txtUM.Text = objE_InventarioAnaqueles.Abreviatura;
                txtCantidad.EditValue = objE_InventarioAnaqueles.Cantidad;
                txtUbicacion.Text = objE_InventarioAnaqueles.Ubicacion;
                txtObservacion.Text = objE_InventarioAnaqueles.Observacion;
            }

            txtCodigo.Focus();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboTienda.EditValue != null)
            //{
            //    BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
            //    cboAlmacen.EditValue = IdAlmacen;
            //}
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
                txtUbicacion.Focus();
            }
        }

        private void txtUbicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnGrabar.Focus();
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
                            }
                            else
                            {
                                if (txtCodigo.Text.Trim().Count() > 6) // CodigoBarra de Importación 
                                {
                                    frmRegCodigoBarra frm = new frmRegCodigoBarra();
                                    frm.strCodigoBarra = txtCodigo.Text;
                                    if (frm.ShowDialog() == DialogResult.OK)
                                    {
                                        txtCodigo_KeyUp(sender, e);
                                        return;
                                    }
                                }
                                XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }


                        #region "anterior"
                        /*if (optCodigo.Checked)
                        {
                            StockBE pProductoBE = null;
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtCodigo.Text.Trim());
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                
                            }
                            else
                            {
                                frmBusProductoStock objBusProducto = new frmBusProductoStock();
                                objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                                objBusProducto.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                                objBusProducto.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
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
                        }

                        if (optHangTag.Checked)
                        {
                            StockBE pProductoBE = null;
                            pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, Convert.ToInt32(txtCodigo.Text.Trim()));
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtCantidad.EditValue = 1;
                                
                            }

                        }*/
                        #endregion


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
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InventarioAnaquelesBL objBL_InventarioAnaqueles = new InventarioAnaquelesBL();
                    InventarioAnaquelesBE objInventarioAnaqueles = new InventarioAnaquelesBE();

                    objInventarioAnaqueles.IdInventarioAnaqueles = IdInventarioAnaqueles;
                    objInventarioAnaqueles.IdTienda = IdTienda; //Convert.ToInt32(cboTienda.EditValue);
                    objInventarioAnaqueles.IdAlmacen = IdAlmacen;//Convert.ToInt32(cboAlmacen.EditValue);
                    objInventarioAnaqueles.IdProducto = IdProducto;
                    objInventarioAnaqueles.CodigoProveedor = txtCodigo.Text;
                    objInventarioAnaqueles.NombreProducto = txtProducto.Text;
                    objInventarioAnaqueles.Abreviatura = txtUM.Text;
                    objInventarioAnaqueles.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                    objInventarioAnaqueles.Ubicacion = txtUbicacion.Text;
                    objInventarioAnaqueles.IdPersona = Parametros.intPersonaId;
                    objInventarioAnaqueles.IdPersona2 = IdPersonaApoyo;
                    objInventarioAnaqueles.Observacion = txtObservacion.Text;
                    objInventarioAnaqueles.FlagEstado = true;
                    objInventarioAnaqueles.Usuario = Parametros.strUsuarioLogin;
                    objInventarioAnaqueles.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objInventarioAnaqueles.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_InventarioAnaqueles.Inserta(objInventarioAnaqueles);
                    else
                        objBL_InventarioAnaqueles.Actualiza(objInventarioAnaqueles);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarBarras_Click(object sender, EventArgs e)
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "gcuba" || frmAutoriza.Usuario == "lvicente" || frmAutoriza.Usuario == "daguedo")
                {
                    //if (txtCodigo.Text.Trim().Count() > 6) // CodigoBarra de Importación 
                    //{
                    frmRegCodigoBarra frm = new frmRegCodigoBarra();
                    frm.strCodigoBarra = txtCodigo.Text;
                    frm.bCodigoBarras = true;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        //return;
                    }
                    //}

                    txtCodigo.Select();

                }

            }



        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) optCodigo.Checked = true;
            //if (keyData == Keys.F6) optHangTag.Checked = true;

            return base.ProcessCmdKey(ref msg, keyData);
        }



        #endregion

        #region "Metodos"



        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            //if (string.IsNullOrEmpty(cboTienda.Text))
            //{
            //    strMensaje = strMensaje + "- Seleccionar una tienda.\n";
            //    flag = true;
            //}

            //if (string.IsNullOrEmpty(cboAlmacen.Text))
            //{
            //    strMensaje = strMensaje + "- Seleccionar un almacen.\n";
            //    flag = true;
            //}

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

            if (pOperacion == Operacion.Nuevo)
            {
                InventarioAnaquelesBE objE_Inventario = null;
                objE_Inventario = new InventarioAnaquelesBL().SeleccionaProducto(Parametros.intEmpresaId, IdProducto);

                if (objE_Inventario != null)
                {
                    string Ubicacion = "";
                    if (objE_Inventario.Ubicacion.Trim().Length > 0)
                    {
                        Ubicacion = " Ubicación: " + objE_Inventario.Ubicacion;
                    }

                    strMensaje = strMensaje + "- El producto ya existe en: " + objE_Inventario.DescAlmacen + "  " + Ubicacion + "\nIngresado por " + objE_Inventario.DescVendedor + "\n";
                    flag = true;
                }            
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