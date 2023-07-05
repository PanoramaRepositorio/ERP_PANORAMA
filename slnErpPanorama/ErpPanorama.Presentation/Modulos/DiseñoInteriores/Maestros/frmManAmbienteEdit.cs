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
    public partial class frmManAmbienteEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_AmbienteBE> lstDis_Ambiente;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public Dis_AmbienteBE pDis_AmbienteBE { get; set; }

        int _IdDis_Ambiente = 0;

        public int IdDis_Ambiente
        {
            get { return _IdDis_Ambiente; }
            set { _IdDis_Ambiente = value; }
        }

        #endregion

        #region "Eventos"
        public frmManAmbienteEdit()
        {
            InitializeComponent();
        }

        private void frmManAmbienteEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ambiente - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Ambiente - Modificar";
                txtDis_Ambiente.Text = pDis_AmbienteBE.DescDis_Ambiente.Trim();
            }

            txtDis_Ambiente.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_AmbienteBL objBL_Dis_Ambiente = new Dis_AmbienteBL();

                    Dis_AmbienteBE objDis_Ambiente = new Dis_AmbienteBE();
                    objDis_Ambiente.IdDis_Ambiente = IdDis_Ambiente;
                    objDis_Ambiente.DescDis_Ambiente = txtDis_Ambiente.Text;
                    objDis_Ambiente.FlagEstado = true;
                    objDis_Ambiente.Usuario = Parametros.strUsuarioLogin;
                    objDis_Ambiente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_Ambiente.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Dis_Ambiente.Inserta(objDis_Ambiente);
                    else
                        objBL_Dis_Ambiente.Actualiza(objDis_Ambiente);

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

            if (txtDis_Ambiente.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Ambiente.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDis_Ambiente.Where(oB => oB.DescDis_Ambiente.ToUpper() == txtDis_Ambiente.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Ambiente ya existe.\n";
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