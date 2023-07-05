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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManInmuebleEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<InmuebleBE> lstInmueble;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdBanco = 0;

        int _IdInmueble = 0;

        public int IdInmueble
        {
            get { return _IdInmueble; }
            set { _IdInmueble = value; }
        }

        #endregion

        #region "Eventos"

        public frmManInmuebleEdit()
        {
            InitializeComponent();
        }

        private void frmManInmuebleEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTipoInmueble, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoInmueble), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Inmueble - Nuevo";
                //cboBanco.EditValue = IdBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Inmueble - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                InmuebleBE objE_Inmueble = null;
                objE_Inmueble = new InmuebleBL().Selecciona(IdInmueble);

                cboEmpresa.EditValue = objE_Inmueble.IdEmpresa;
                cboTipoInmueble.EditValue = objE_Inmueble.IdTipoInmueble;
                txtDescripcion.EditValue = objE_Inmueble.DescInmueble;
                txtDireccion.EditValue = objE_Inmueble.Direccion;
                txtPrecioVenta.EditValue = objE_Inmueble.PrecioVenta;
                txtPrecioAlquiler.EditValue = objE_Inmueble.PrecioAlquiler;
                txtObservacion.EditValue = objE_Inmueble.Observacion;

                if (objE_Inmueble.IdUbigeo.Trim() != "")
                    IdDepartamento = objE_Inmueble.IdUbigeo.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (objE_Inmueble.IdUbigeo.Trim() != "")
                    IdProvincia = objE_Inmueble.IdUbigeo.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (objE_Inmueble.IdUbigeo.Trim() != "")
                    IdDistrito = objE_Inmueble.IdUbigeo.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;

                if (objE_Inmueble.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Inmueble.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

            }
            txtDescripcion.Focus();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InmuebleBL objBL_Inmueble = new InmuebleBL();
                    InmuebleBE objInmueble = new InmuebleBE();

                    objInmueble.IdInmueble = IdInmueble;
                    objInmueble.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objInmueble.IdTipoInmueble = Convert.ToInt32(cboTipoInmueble.EditValue);
                    objInmueble.Direccion = txtDireccion.Text.Trim();
                    objInmueble.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objInmueble.DescInmueble = txtDescripcion.Text.Trim();
                    objInmueble.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.EditValue);
                    objInmueble.PrecioAlquiler = Convert.ToDecimal(txtPrecioAlquiler.EditValue);
                    objInmueble.Imagen = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objInmueble.Observacion = txtObservacion.Text.Trim();
                    objInmueble.FlagEstado = true;
                    objInmueble.Usuario = Parametros.strUsuarioLogin;
                    objInmueble.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Inmueble.Inserta(objInmueble);
                    else
                        objBL_Inmueble.Actualiza(objInmueble);

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                this.picImage.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
        }
        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

            if (cboTipoInmueble.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el Tipo de Inmueble.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese descripción.\n";
                flag = true;
            }

            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese dirección.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstInmueble.Where(oB => oB.DescInmueble == txtDescripcion.Text.Trim() && oB.Direccion == txtDireccion.Text.Trim()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Inmueble ya existe.\n";
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