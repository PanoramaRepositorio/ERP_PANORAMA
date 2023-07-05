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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManMaterialEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<MaterialBE> lstMaterial;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public MaterialBE pMaterialBE { get; set; }

        int _IdMaterial = 0;

        public int IdMaterial
        {
            get { return _IdMaterial; }
            set { _IdMaterial = value; }
        }

        #endregion

        #region "Eventos"

        public frmManMaterialEdit()
        {
            InitializeComponent();
        }

        private void frmManMaterialEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Material - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Material - Modificar";
                txtMaterial.Text = pMaterialBE.DescMaterial.Trim();
            }

            txtMaterial.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MaterialBL objBL_Material = new MaterialBL();
                    MaterialBE objMaterial = new MaterialBE();



                    objMaterial.IdMaterial = IdMaterial;
                    objMaterial.DescMaterial = txtMaterial.Text;
                    objMaterial.FlagEstado = true;
                    objMaterial.Usuario = Parametros.strUsuarioLogin;
                    objMaterial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMaterial.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Material.Inserta(objMaterial);
                    else
                        objBL_Material.Actualiza(objMaterial);

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

            if (txtMaterial.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese material.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstMaterial.Where(oB => oB.DescMaterial.ToUpper() == txtMaterial.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- El Material ya existe.\n";
                //    flag = true;
                //}
                
                MaterialBE objMaterial = null;

                objMaterial = new MaterialBL().SeleccionaMaterial(txtMaterial.Text.Trim());
                if (objMaterial != null)
                {
                    strMensaje = strMensaje + "- El Material ya existe.\n";
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