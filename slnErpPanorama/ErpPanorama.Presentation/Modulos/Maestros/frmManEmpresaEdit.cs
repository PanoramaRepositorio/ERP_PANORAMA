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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManEmpresaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        public List<EmpresaBE> lstEmpresa;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManEmpresaEdit()
        {
            InitializeComponent();
        }

        private void frmManEmpresaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboRegimenTributario, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblRegimenTributario), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboNivel, new NivelBL().SeleccionaTodos(), "DescNivel", "IdNivel", false);
            cboNivel.EditValue = Parametros.intNinguno;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Empresa - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Empresa - Modificar";

                EmpresaBE objE_Empresa = new EmpresaBE();

                objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);

                IdEmpresa = objE_Empresa.IdEmpresa;
                txtCodigo.Text = objE_Empresa.CodEmpresa;
                txtRuc.Text = objE_Empresa.Ruc;
                cboRegimenTributario.EditValue = objE_Empresa.IdRegimenTributario;
                cboNivel.EditValue = objE_Empresa.IdNivel;
                txtRazonSocial.Text = objE_Empresa.RazonSocial;
                txtDireccion.Text = objE_Empresa.Direccion;
                txtTelefono.Text = objE_Empresa.Telefono;
                txtDireccion.EditValue = objE_Empresa.Direccion;
                txtTelefono.EditValue = objE_Empresa.Telefono;
                txtAbreviatura.EditValue = objE_Empresa.Abreviatura;
                txtDniGerente.EditValue = objE_Empresa.DniGerente;
                txtNombreGerente.EditValue = objE_Empresa.NombreGerente;
                txtCodigoCompania.EditValue = objE_Empresa.CodigoCompania;
            }

            txtCodigo.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    EmpresaBL objBL_Empresa = new EmpresaBL();
                    EmpresaBE objE_Empresa = new EmpresaBE();

                    objE_Empresa.IdEmpresa = IdEmpresa;
                    objE_Empresa.CodEmpresa = txtCodigo.Text;
                    objE_Empresa.IdNivel = Convert.ToInt32(cboNivel.EditValue);
                    objE_Empresa.IdRegimenTributario = Convert.ToInt32(cboRegimenTributario.EditValue);
                    objE_Empresa.Ruc = txtRuc.Text;
                    objE_Empresa.RazonSocial = txtRazonSocial.Text;
                    objE_Empresa.Direccion = txtDireccion.Text;
                    objE_Empresa.Telefono = txtTelefono.Text;
                    objE_Empresa.Abreviatura = txtAbreviatura.Text;
                    objE_Empresa.DniGerente = txtDniGerente.Text;
                    objE_Empresa.NombreGerente = txtNombreGerente.Text;
                    objE_Empresa.CodigoCompania = txtCodigoCompania.Text;
                    objE_Empresa.FlagEstado = true;
                    objE_Empresa.Usuario = Parametros.strUsuarioLogin;
                    objE_Empresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Empresa.Inserta(objE_Empresa);
                    else
                        objBL_Empresa.Actualiza(objE_Empresa);

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

            if (txtRuc.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el RUC.\n";
                flag = true;
            }

            if (txtRazonSocial.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la razón social.\n";
                flag = true;
            }

            if (cboRegimenTributario.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione el regimen tributario.\n";
                flag = true;
            }


            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstEmpresa.Where(oB => oB.Ruc.ToUpper() == txtRuc.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Ruc ya existe.\n";
                    flag = true;
                }

                var BuscarRazonSocial = lstEmpresa.Where(oB => oB.RazonSocial.ToUpper() == txtRazonSocial.Text.ToUpper()).ToList();
                if (BuscarRazonSocial.Count > 0)
                {
                    strMensaje = strMensaje + "- La Razón social ya existe.\n";
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