using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegMuestraEdit : DevExpress.XtraEditors.XtraForm
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

        public MuestraBE pMuestraBE { get; set; }

        int _IdMuestra = 0;

        public int IdMuestra
        {
            get { return _IdMuestra; }
            set { _IdMuestra = value; }
        }

        int IdProducto = 0;
        
        #endregion

        #region "Eventos"

        public frmRegMuestraEdit()
        {
            InitializeComponent();
        }

        private void frmRegMuestraEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Muestra - Nuevo";
                
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Muestra - Modificar";
                MuestraBE objE_Muestra = null;
                objE_Muestra = new MuestraBL().Selecciona(IdMuestra);
                if (objE_Muestra != null)
                {
                    IdMuestra = objE_Muestra.IdMuestra;
                    IdProducto = objE_Muestra.IdProducto;
                    txtCodigo.Text = objE_Muestra.CodigoProveedor;
                    txtProducto.Text = objE_Muestra.NombreProducto;
                    txtUM.Text = objE_Muestra.Abreviatura;
                    txtCantidad.EditValue = objE_Muestra.Cantidad;
                    txtPrecioVenta.EditValue = objE_Muestra.PrecioVenta;
                    txtValorVenta.EditValue = objE_Muestra.ValorVenta;
                }
            }

            txtCodigo.Select();
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
                                txtCantidad.EditValue = 1;
                                txtPrecioVenta.EditValue = Convert.ToDecimal(pProductoBE.PrecioABSoles) * ((100 - Convert.ToDecimal(pProductoBE.Descuento)) / 100);
                                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                            }
                            else
                            {
                                frmBusProductoStock objBusProducto = new frmBusProductoStock();
                                objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                                objBusProducto.IdTienda = Parametros.intTiendaId;
                                objBusProducto.IdAlmacen = Parametros.intAlmTiendaUcayali;
                                objBusProducto.ShowDialog();
                                if (objBusProducto.pProductoBE != null)
                                {
                                    IdProducto = objBusProducto.pProductoBE.IdProducto;
                                    txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                                    txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                                    txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                                    txtCantidad.EditValue = 1;
                                    txtPrecioVenta.EditValue = objBusProducto.pProductoBE.PrecioABSoles * ((100 - objBusProducto.pProductoBE.Descuento) / 100);
                                    txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                        
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
                                txtPrecioVenta.EditValue = pProductoBE.PrecioABSoles * ((100 - pProductoBE.Descuento) / 100);
                                txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);

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
                btnGrabar.Focus();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MuestraBL objBL_Muestra = new MuestraBL();
                    MuestraBE objMuestra = new MuestraBE();

                    objMuestra.IdMuestra = IdMuestra;
                    objMuestra.IdEmpresa = Parametros.intEmpresaId;
                    objMuestra.IdTienda = Parametros.intTiendaId;
                    objMuestra.Fecha = Parametros.dtFechaHoraServidor;
                    objMuestra.IdProducto = IdProducto;
                    objMuestra.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                    objMuestra.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.EditValue);
                    objMuestra.ValorVenta = Convert.ToDecimal(txtValorVenta.EditValue);
                    objMuestra.FlagEstado = true;
                    objMuestra.Usuario = Parametros.strUsuarioLogin;
                    objMuestra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Muestra.Inserta(objMuestra);
                    else
                        objBL_Muestra.Actualiza(objMuestra);

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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdProducto == 0)
            {
                strMensaje = strMensaje + "- Seleccionar producto.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtCantidad.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingresar cantidad.\n";
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