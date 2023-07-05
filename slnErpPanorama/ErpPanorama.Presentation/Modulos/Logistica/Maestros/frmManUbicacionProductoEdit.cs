using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManUbicacionProductoEdit : DevExpress.XtraEditors.XtraForm
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

        public UbicacionProductoBE pUbicacionProductoBE { get; set; }

        private int IdProducto = 0;

        int _IdUbicacionProducto = 0;

        public int IdUbicacionProducto
        {
            get { return _IdUbicacionProducto; }
            set { _IdUbicacionProducto = value; }
        }

        #endregion

        #region "Eventos"

        public frmManUbicacionProductoEdit()
        {
            InitializeComponent();
        }

        private void frmManUbicacionProductoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ubicación Producto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Ubicación Producto - Modificar";
                IdProducto = pUbicacionProductoBE.IdProducto;
                cboTienda.EditValue = pUbicacionProductoBE.IdTienda;
                cboAlmacen.EditValue = pUbicacionProductoBE.IdAlmacen;
                txtCodigo.Text = pUbicacionProductoBE.CodigoProveedor;
                txtNombreProducto.Text = pUbicacionProductoBE.NombreProducto;
                txtUbicacion.Text = pUbicacionProductoBE.DescUbicacion;
            }

            txtCodigo.Select();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                if (objE_Producto != null)
                {
                    IdProducto = objE_Producto.IdProducto;
                    txtCodigo.Text = objE_Producto.CodigoProveedor;
                    txtNombreProducto.Text = objE_Producto.NombreProducto;
                    txtUbicacion.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;
                }

                txtUbicacion.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                //cboAlmacen.EditValue = Parametros.intAlmCentralUcayali;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    if (pOperacion == Operacion.Nuevo)
                    {
                        List<UbicacionProductoBE> lstUbicacion = null;
                        lstUbicacion = new UbicacionProductoBL().ListaCodigo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboAlmacen.EditValue), IdProducto);
                        if (lstUbicacion.Count > 0)
                        {
                            if (XtraMessageBox.Show("El producto ya tiene ubicación en: " + lstUbicacion[0].DescUbicacion + ", desea Actualizar a la nueva ubicación: " + txtUbicacion.Text.Trim(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                IdUbicacionProducto = lstUbicacion[0].IdUbicacionProducto;
                                IdProducto = lstUbicacion[0].IdProducto;
                                cboTienda.EditValue = lstUbicacion[0].IdTienda;
                                cboAlmacen.EditValue = lstUbicacion[0].IdAlmacen;
                                txtCodigo.Text = lstUbicacion[0].CodigoProveedor;
                                txtNombreProducto.Text = lstUbicacion[0].NombreProducto;
                                pOperacion = Operacion.Modificar;
                            }

                            //txtUbicacion.Text = pUbicacionProductoBE.DescUbicacion;

                            //objBL_UbicacionProducto.Actualiza(objUbicacionProducto);

                        }
                    }



                    UbicacionProductoBL objBL_UbicacionProducto = new UbicacionProductoBL();
                    UbicacionProductoBE objUbicacionProducto = new UbicacionProductoBE();

                    objUbicacionProducto.IdUbicacionProducto = IdUbicacionProducto;
                    objUbicacionProducto.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                    objUbicacionProducto.IdProducto = IdProducto;
                    objUbicacionProducto.DescUbicacion = txtUbicacion.Text.Trim();
                    objUbicacionProducto.FlagEstado = true;
                    objUbicacionProducto.Usuario = Parametros.strUsuarioLogin;
                    objUbicacionProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUbicacionProducto.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_UbicacionProducto.Inserta(objUbicacionProducto);
                    else
                        objBL_UbicacionProducto.Actualiza(objUbicacionProducto);

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

            if (cboAlmacen.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione el Almacén.\n";
                flag = true;
            }

            if (IdProducto == 0)
            {
                strMensaje = strMensaje + "- Seleccione el Producto.\n";
                flag = true;
            }

            if (txtUbicacion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Ubicación.\n";
                flag = true;
            }

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    List<UbicacionProductoBE> lstUbicacion = null;
            //    lstUbicacion = new UbicacionProductoBL().ListaCodigo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboAlmacen.EditValue), IdProducto);
            //    if (lstUbicacion.Count > 0)
            //    {
            //        IdProducto = pUbicacionProductoBE.IdProducto;
            //        cboTienda.EditValue = pUbicacionProductoBE.IdTienda;
            //        cboAlmacen.EditValue = pUbicacionProductoBE.IdAlmacen;
            //        txtCodigo.Text = pUbicacionProductoBE.CodigoProveedor;
            //        txtNombreProducto.Text = pUbicacionProductoBE.NombreProducto;
            //        txtUbicacion.Text = pUbicacionProductoBE.DescUbicacion;

            //        strMensaje = strMensaje + "- El producto ya tiene ubicación.\n";
            //    flag = true;
            //    }
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        private void txtUbicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnGrabar.Focus();
            }
        }

        
    }
}