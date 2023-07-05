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

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManTipoColorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_TipoColorBE> lstDis_TipoColor;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public Dis_TipoColorBE pDis_TipoColorBE { get; set; }

        int _IdDis_TipoColor = 0;

        public int IdDis_TipoColor
        {
            get { return _IdDis_TipoColor; }
            set { _IdDis_TipoColor = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipoColorEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoColorEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "TipoColor - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "TipoColor - Modificar";
                txtDis_TipoColor.Text = pDis_TipoColorBE.DescDis_TipoColor.Trim();
            }

            txtDis_TipoColor.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_TipoColorBL objBL_Dis_TipoColor = new Dis_TipoColorBL();

                    Dis_TipoColorBE objDis_TipoColor = new Dis_TipoColorBE();
                    objDis_TipoColor.IdDis_TipoColor = IdDis_TipoColor;
                    objDis_TipoColor.DescDis_TipoColor = txtDis_TipoColor.Text;
                    objDis_TipoColor.FlagEstado = true;
                    objDis_TipoColor.Usuario = Parametros.strUsuarioLogin;
                    objDis_TipoColor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_TipoColor.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Dis_TipoColor.Inserta(objDis_TipoColor);
                    else
                        objBL_Dis_TipoColor.Actualiza(objDis_TipoColor);

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

            if (txtDis_TipoColor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese TipoColor.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDis_TipoColor.Where(oB => oB.DescDis_TipoColor.ToUpper() == txtDis_TipoColor.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El TipoColor ya existe.\n";
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