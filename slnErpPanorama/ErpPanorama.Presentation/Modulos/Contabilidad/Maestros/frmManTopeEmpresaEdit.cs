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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Maestros
{
    public partial class frmManTopeEmpresaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TopeEmpresaBE> lstTopeEmpresa;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TopeEmpresaBE pTopeEmpresaBE { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }
        

        #endregion

        #region "Eventos"
        public frmManTopeEmpresaEdit()
        {
            InitializeComponent();
        }

        private void frmManTopeEmpresaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "TopeEmpresa - Nuevo";
                //txtTopeEmpresa.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "TopeEmpresa - Modificar";
                txtTopeEmpresa.Text = pTopeEmpresaBE.Tope.ToString();
                txtTopeEmpresaDiario.Text = pTopeEmpresaBE.TopeDiario.ToString();
                cboEmpresa.EditValue = pTopeEmpresaBE.IdEmpresa;
            }

            txtTopeEmpresa.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TopeEmpresaBL objBL_TopeEmpresa = new TopeEmpresaBL();

                    TopeEmpresaBE objTopeEmpresa = new TopeEmpresaBE();
                    objTopeEmpresa.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objTopeEmpresa.Tope = Convert.ToDecimal(txtTopeEmpresa.Text);
                    objTopeEmpresa.TopeDiario = Convert.ToDecimal(txtTopeEmpresaDiario.Text);
                    objTopeEmpresa.FlagEstado = true;
                    objTopeEmpresa.Usuario = Parametros.strUsuarioLogin;
                    objTopeEmpresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TopeEmpresa.Inserta(objTopeEmpresa);
                    else
                        objBL_TopeEmpresa.Actualiza(objTopeEmpresa);

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

            if (txtTopeEmpresa.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese TopeEmpresa.\n";
                flag = true;
            }

            if (txtTopeEmpresaDiario.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese TopeEmpresa Diario.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTopeEmpresa.Where(oB => oB.IdEmpresa == Convert.ToInt32(cboEmpresa.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Tope de la Empresa ya existe.\n";
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