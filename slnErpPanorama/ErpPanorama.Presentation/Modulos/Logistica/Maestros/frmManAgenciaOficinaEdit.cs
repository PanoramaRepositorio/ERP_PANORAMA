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
using ErpPanorama.Presentation.Utils;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManAgenciaOficinaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public AgenciaOficinaBE oBE;

        public int IdAgencia = 0;
        public int IdAgenciaOficina = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        #endregion

        #region "Eventos"
        public frmManAgenciaOficinaEdit()
        {
            InitializeComponent();
        }

        private void frmManAgenciaOficinaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Agencia Oficina - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Agencia Oficina - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                AgenciaOficinaBE objE_AgenciaOficina = new AgenciaOficinaBE();
                objE_AgenciaOficina = new AgenciaOficinaBL().Selecciona(IdAgenciaOficina);

                txtDescAgencia.EditValue = objE_AgenciaOficina.DescAgencia;
                txtDireccion.EditValue = objE_AgenciaOficina.Direccion;
                txtTelefono.EditValue = objE_AgenciaOficina.Telefono;
                txtObservacion.EditValue = objE_AgenciaOficina.Observacion;
                IdAgencia = objE_AgenciaOficina.IdAgencia;

                if (objE_AgenciaOficina.IdUbigeo.Trim() != "")
                    IdDepartamento = objE_AgenciaOficina.IdUbigeo.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (objE_AgenciaOficina.IdUbigeo.Trim() != "")
                    IdProvincia = objE_AgenciaOficina.IdUbigeo.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (objE_AgenciaOficina.IdUbigeo.Trim() != "")
                    IdDistrito = objE_AgenciaOficina.IdUbigeo.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;
            }

            txtDescAgencia.Focus();

        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDescAgencia.Text.Length > 0)
                {
                    frmBusProductoStock objBusProducto = new frmBusProductoStock();
                    objBusProducto.pDescripcion = txtDescAgencia.Text.Trim();
                    objBusProducto.IdTienda = Parametros.intTiendaId;
                    objBusProducto.IdAlmacen = Parametros.intAlmCentralUcayali;
                    objBusProducto.ShowDialog();
                    if (objBusProducto.pProductoBE != null)
                    {
                        //IdProducto = objBusProducto.pProductoBE.IdProducto;
                        //txtCodigo.Text = objBusProducto.pProductoBE.CodigoProveedor;
                        //txtProducto.Text = objBusProducto.pProductoBE.NombreProducto;
                        //txtUM.Text = objBusProducto.pProductoBE.Abreviatura;
                        //txtCantidad.EditValue = 1;
                        //txtPrecioVenta.EditValue = objBusProducto.pProductoBE.PrecioABSoles;
                        //txtCantidad.SelectAll();
                        //txtCantidad.Focus();

                    }
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //txtPrecioVenta.Focus();
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
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AgenciaOficinaBL objBL_AgenciaOficina = new AgenciaOficinaBL();

                    AgenciaOficinaBE objE_AgenciaOficina = new AgenciaOficinaBE();
                    objE_AgenciaOficina.IdAgenciaOficina = IdAgenciaOficina;
                    objE_AgenciaOficina.IdAgencia = IdAgencia;
                    objE_AgenciaOficina.DescAgencia = txtDescAgencia.Text.Trim();
                    objE_AgenciaOficina.Direccion = txtDireccion.Text;
                    objE_AgenciaOficina.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_AgenciaOficina.Telefono = txtTelefono.Text;
                    objE_AgenciaOficina.Observacion = txtObservacion.Text;
                    objE_AgenciaOficina.FlagEstado = true;
                    objE_AgenciaOficina.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_AgenciaOficina.Usuario = Parametros.strUsuarioLogin;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_AgenciaOficina.Inserta(objE_AgenciaOficina);
                    else
                        objBL_AgenciaOficina.Actualiza(objE_AgenciaOficina);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //try
            //{


            //    if (txtDescAgencia.Text.Trim() == "")
            //    {
            //        XtraMessageBox.Show("Seleccionar el código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtDescAgencia.SelectAll();
            //        txtDescAgencia.Focus();
            //        return;
            //    }


            //    oBE = new AgenciaOficinaBE();
            //    oBE.IdAgenciaOficina = IdAgenciaOficina;
            //    oBE.IdAgencia = IdAgencia;
            //    oBE.DescAgencia = txtDescAgencia.Text.Trim();
            //    oBE.Direccion = txtDireccion.Text.Trim();
            //    oBE.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
            //    oBE.Telefono = txtTelefono.Text.Trim();
            //    oBE.Observacion = txtObservacion.Text;

            //    this.DialogResult = DialogResult.OK;

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescAgencia.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingrese Agencia .\n";
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