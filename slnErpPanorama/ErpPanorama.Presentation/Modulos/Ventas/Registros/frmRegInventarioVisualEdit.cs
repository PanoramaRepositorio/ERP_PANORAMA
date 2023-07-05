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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegInventarioVisualEdit : DevExpress.XtraEditors.XtraForm
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
        public int IdBloque { get; set; }
        public int IdModulo { get; set; }
        public bool HangTag { get; set; }
        public bool RegistroRapido { get; set; }


        int IdProducto = 0;

        int _IdInventarioVisual = 0;

        public int IdInventarioVisual
        {
            get { return _IdInventarioVisual; }
            set { _IdInventarioVisual = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegInventarioVisualEdit()
        {
            InitializeComponent();
        }

        private void frmRegInventarioVisualEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            cboTienda.EditValue = IdTienda;
            //BSUtils.LoaderLook(cboModulo, new InventarioVisualBloqueBL().ListaTodosActivo(Convert.ToInt32(cboTienda.EditValue)), "DescModulo", "IdInventarioVisualModulo", true);
            //BSUtils.LoaderLook(cboModulo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblModuloInventario), "DescTablaElemento", "IdTablaElemento", true);
            cboBloque.EditValue = IdBloque;
            cboModulo.EditValue = IdModulo;

            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Registro de Inventario - Nuevo";
                //chkRegistroRapido.Checked = true;
                if (HangTag == true)
                    optHangTag.Checked = true;
                else
                    optCodigo.Checked = true;

                if (RegistroRapido == true)
                    chkRegistroRapido.Checked = true;
                else
                    chkRegistroRapido.Checked = false;

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Registro de Inventario - Modificar";

                InventarioVisualBE objE_Inventario = new InventarioVisualBE();

                objE_Inventario = new InventarioVisualBL().Selecciona(IdInventarioVisual);
                IdInventarioVisual = objE_Inventario.IdInventarioVisual;
                cboTienda.EditValue = objE_Inventario.IdTienda;
                cboModulo.EditValue = objE_Inventario.IdModulo;
                IdProducto = objE_Inventario.IdProducto;
                txtCodigo.Text = objE_Inventario.CodigoProveedor;
                txtProducto.Text = objE_Inventario.NombreProducto;
                txtUM.Text = objE_Inventario.Abreviatura;
                txtCantidad.EditValue = objE_Inventario.Cantidad;
                deFecha.EditValue = objE_Inventario.FechaRegistro;
                txtNuevoDescuento.EditValue = objE_Inventario.DescuentoSugerido;
                txtDescuentoActual.EditValue = objE_Inventario.DescuentoActual;
                txtObservacion.Text = objE_Inventario.Observacion;
            }

            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboBloque, new InventarioVisualBloqueBL().ListaTodosActivoTienda(Convert.ToInt32(cboTienda.EditValue)), "DescBloque", "IdInventarioVisualBloque", true);
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtNuevoDescuento.Focus();
                txtNuevoDescuento.SelectAll();
            }
        }

        private void txtNuevoDescuento_KeyPress(object sender, KeyPressEventArgs e)
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
                            StockBE pProductoBE = null;
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, txtCodigo.Text.Trim());
                            if (pProductoBE != null)
                            {
                                IdProducto = pProductoBE.IdProducto;
                                txtCodigo.Text = pProductoBE.CodigoProveedor;
                                txtProducto.Text = pProductoBE.NombreProducto;
                                txtUM.Text = pProductoBE.Abreviatura;
                                txtDescuentoActual.EditValue = pProductoBE.Descuento;
                                txtCantidad.EditValue = 1;
                            }
                            else
                            {
                                frmBusProductoStock objBusProducto = new frmBusProductoStock();
                                objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                                objBusProducto.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                                //objBusProducto.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                                objBusProducto.IdAlmacen = Convert.ToInt32(Parametros.intAlmTiendaUcayali);
                                objBusProducto.ShowDialog();
                                if (objBusProducto.pProductoBE != null)
                                {
                                    IdProducto = objBusProducto.pProductoBE.IdProducto;

                                    txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                    txtDescuentoActual.EditValue = objBusProducto.pProductoBE.Descuento;
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
                                txtDescuentoActual.EditValue = pProductoBE.Descuento;
                                txtCantidad.EditValue = 1;
                            }
                            if (chkRegistroRapido.Checked == true)
                            {
                                btnGrabar_Click(sender, e);
                                return;
                            }
                        }

                        //Busca Códigos repetidos
                        List<InventarioVisualBE> pInventarioVisualListaBE = null;
                        pInventarioVisualListaBE = new InventarioVisualBL().ListaBuscaProducto(IdProducto);
                        if (pInventarioVisualListaBE.Count() > 0)
                        {
                            frmBusInventarioVisual frmBuscaVisual = new frmBusInventarioVisual();
                            frmBuscaVisual.IdProducto = IdProducto;
                            frmBuscaVisual.StartPosition = FormStartPosition.CenterParent;
                            frmBuscaVisual.ShowDialog();
                        }

                        //Actualiza Descuento en funcion a la linea
                            DescuentoFechaCompraBE pDescuentoFechaCompraBE = null;
                            pDescuentoFechaCompraBE = new DescuentoFechaCompraBL().SeleccionaCodigo(Parametros.intEmpresaId,IdProducto );
                            if (pDescuentoFechaCompraBE != null)
                            {
                                txtNuevoDescuento.EditValue = pDescuentoFechaCompraBE.Descuento;
                                deFechaRecepcion.EditValue = pDescuentoFechaCompraBE.FechaRecepcion;
                            }
                            else {
                                txtNuevoDescuento.EditValue = 0;
                                deFechaRecepcion.EditValue = "";
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
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                    InventarioVisualBE objInventarioVisual = new InventarioVisualBE();

                    objInventarioVisual.IdInventarioVisual = IdInventarioVisual;
                    objInventarioVisual.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objInventarioVisual.IdBloque = Convert.ToInt32(cboBloque.EditValue);
                    objInventarioVisual.IdModulo = Convert.ToInt32(cboModulo.EditValue);
                    objInventarioVisual.IdProducto = IdProducto;
                    objInventarioVisual.CodigoProveedor = txtCodigo.Text;
                    objInventarioVisual.NombreProducto = txtProducto.Text;
                    objInventarioVisual.Abreviatura = txtUM.Text;
                    objInventarioVisual.FechaRegistro = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objInventarioVisual.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                    objInventarioVisual.DescuentoActual = Convert.ToDecimal(txtDescuentoActual.EditValue);
                    objInventarioVisual.DescuentoSugerido = Convert.ToDecimal(txtNuevoDescuento.EditValue);
                    objInventarioVisual.Observacion = txtObservacion.Text;
                    objInventarioVisual.FechaCompra =  Convert.ToDateTime("01/01/2000");
                    objInventarioVisual.CantidadCompra = 0;
                    objInventarioVisual.FlagEstado = true;
                    objInventarioVisual.Usuario = Parametros.strUsuarioLogin;
                    objInventarioVisual.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    

                    //Busca Códigos repetidos
                    List<InventarioVisualBE> pInventarioVisualListaBE = null;
                    pInventarioVisualListaBE = new InventarioVisualBL().ListaBuscaProducto(IdProducto);
                    if (pInventarioVisualListaBE.Count() > 0)
                    {
                        if (XtraMessageBox.Show("Se encontraron " + pInventarioVisualListaBE.Count().ToString() + " items de este código desea actualizar el descuento sugerido a todos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            objBL_InventarioVisual.ActualizaDescuentoPorCodigo(Convert.ToInt32(cboTienda.EditValue), IdProducto, Convert.ToDecimal(txtNuevoDescuento.EditValue));
                        }
                    }


                    if (pOperacion == Operacion.Nuevo)
                        objBL_InventarioVisual.Inserta(objInventarioVisual);
                    else
                        objBL_InventarioVisual.Actualiza(objInventarioVisual);

                    this.DialogResult = DialogResult.OK;
                    //this.Close();
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

        private void chkRegistroRapido_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void cboBloque_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboModulo, new InventarioVisualModuloBL().ListaTodosActivo(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboBloque.EditValue)), "DescModulo", "IdInventarioVisualModulo", true);
        }


        #endregion

        #region "Metodos"


        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboTienda.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una tienda.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboBloque.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un Bloque.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboModulo.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un Modulo.\n";
                flag = true;
            }

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