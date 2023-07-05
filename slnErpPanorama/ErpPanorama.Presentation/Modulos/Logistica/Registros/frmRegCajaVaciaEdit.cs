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

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegCajaVaciaEdit : DevExpress.XtraEditors.XtraForm
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

        private int IdProducto = 0;

        int _IdCajaVacia = 0;

        public int IdCajaVacia
        {
            get { return _IdCajaVacia; }
            set { _IdCajaVacia = value; }
        }

        int _IdPiso = 0;

        public int IdPiso
        {
            get { return _IdPiso; }
            set { _IdPiso = value; }
        }

        int _IdUbicacion = 0;

        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegCajaVaciaEdit()
        {
            InitializeComponent();
        }

        private void frmRegCajaVaciaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUbicacion, new UbicacionBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescUbicacion", "IdUbicacion", true);
            cboUbicacion.EditValue = IdUbicacion;
            deFechaIngreso.EditValue = DateTime.Now;
            cboPiso.EditValue = IdPiso;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Caja Vacia - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Caja Vacia - Modificar";

                CajaVaciaBE objE_CajaVacia = null;
                objE_CajaVacia = new CajaVaciaBL().Selecciona(Parametros.intEmpresaId, IdCajaVacia);

                cboUbicacion.EditValue = objE_CajaVacia.IdUbicacion;
                cboPiso.EditValue = objE_CajaVacia.IdPiso;
                IdProducto = objE_CajaVacia.IdProducto;
                txtCodigo.Text = objE_CajaVacia.CodigoProveedor;
                txtNombreProducto.Text = objE_CajaVacia.NombreProducto;
                deFechaIngreso.EditValue = objE_CajaVacia.FechaIngreso;
                deFechaSalida.EditValue = objE_CajaVacia.FechaSalida;
                txtObservacion.Text = objE_CajaVacia.Observacion;
            }

            txtCodigo.Select();
        }

        private void cboUbicacion_EditValueChanged(object sender, EventArgs e)
        {
            if (cboUbicacion.EditValue != null)
            {
                BSUtils.LoaderLook(cboPiso, new PisoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboUbicacion.EditValue)), "DescPiso", "IdPiso", true);
            }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                if (objE_Producto != null)
                {
                    IdProducto = objE_Producto.IdProducto;
                    txtCodigo.Text = objE_Producto.CodigoProveedor;
                    txtNombreProducto.Text = objE_Producto.NombreProducto;

                    deFechaIngreso.Focus();
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

                deFechaIngreso.Focus();
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
                    CajaVaciaBL objBL_CajaVacia = new CajaVaciaBL();
                    CajaVaciaBE objCajaVacia = new CajaVaciaBE();

                    objCajaVacia.IdCajaVacia = IdCajaVacia;
                    objCajaVacia.IdTienda = Parametros.intTiendaId;
                    objCajaVacia.IdUbicacion = Convert.ToInt32(cboUbicacion.EditValue);
                    objCajaVacia.IdPiso = Convert.ToInt32(cboPiso.EditValue);
                    objCajaVacia.IdProducto = IdProducto;
                    objCajaVacia.FechaIngreso = Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString()); 
                    objCajaVacia.FechaSalida = deFechaSalida.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaSalida.DateTime.ToShortDateString()); 
                    objCajaVacia.Observacion = txtObservacion.Text;
                    objCajaVacia.FlagEstado = true;
                    objCajaVacia.Usuario = Parametros.strUsuarioLogin;
                    objCajaVacia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCajaVacia.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CajaVacia.Inserta(objCajaVacia);
                    else
                        objBL_CajaVacia.Actualiza(objCajaVacia);

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

            if (string.IsNullOrEmpty(cboUbicacion.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una ubicación.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboPiso.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un piso.\n";
                flag = true;
            }

            if (IdProducto == 0)
            {
                strMensaje = strMensaje + "- Seleccione un producto.\n";
                flag = true;
            }

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstPiso.Where(oB => oB.DescPiso.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- La descripción ya existe.\n";
            //        flag = true;
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

    }
}