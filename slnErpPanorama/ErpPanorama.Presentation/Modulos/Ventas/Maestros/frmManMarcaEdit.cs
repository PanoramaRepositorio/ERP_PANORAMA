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
    public partial class frmManMarcaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Procedimientos"

        
        public List<MarcaBE> lstMarca;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public MarcaBE pMarcaBE { get; set; }

        int _IdMarca = 0;

        public int IdMarca
        {
            get { return _IdMarca; }
            set { _IdMarca = value; }
        }

        #endregion

        #region "Eventos"

        public frmManMarcaEdit()
        {
            InitializeComponent();
        }

        private void frmManMarcaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Marca - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Marca - Modificar";
                txtMarca.Text = pMarcaBE.DescMarca.Trim();
            }

            txtMarca.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MarcaBL objBL_Marca = new MarcaBL();
                    MarcaBE objMarca = new MarcaBE();

                    objMarca.IdMarca = IdMarca;
                    objMarca.DescMarca = txtMarca.Text;
                    objMarca.FlagEstado = true;
                    objMarca.Usuario = Parametros.strUsuarioLogin;
                    objMarca.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMarca.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Marca.Inserta(objMarca);
                    else
                        objBL_Marca.Actualiza(objMarca);

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

            if (txtMarca.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese marca.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstMarca.Where(oB => oB.DescMarca.ToUpper() == txtMarca.Text.ToUpper()).ToList();
                 if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La marca ya existe.\n";
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