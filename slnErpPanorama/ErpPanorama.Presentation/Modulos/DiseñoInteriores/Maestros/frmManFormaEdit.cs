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
    public partial class frmManFormaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_FormaBE> lstDis_Forma;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public Dis_FormaBE pDis_FormaBE { get; set; }

        int _IdDis_Forma = 0;

        public int IdDis_Forma
        {
            get { return _IdDis_Forma; }
            set { _IdDis_Forma = value; }
        }

        #endregion

        #region "Eventos"
        public frmManFormaEdit()
        {
            InitializeComponent();
        }

        private void frmManFormaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Forma - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Forma - Modificar";
                txtDis_Forma.Text = pDis_FormaBE.DescDis_Forma.Trim();
            }

            txtDis_Forma.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_FormaBL objBL_Dis_Forma = new Dis_FormaBL();

                    Dis_FormaBE objDis_Forma = new Dis_FormaBE();
                    objDis_Forma.IdDis_Forma = IdDis_Forma;
                    objDis_Forma.DescDis_Forma = txtDis_Forma.Text;
                    objDis_Forma.FlagEstado = true;
                    objDis_Forma.Usuario = Parametros.strUsuarioLogin;
                    objDis_Forma.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_Forma.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Dis_Forma.Inserta(objDis_Forma);
                    else
                        objBL_Dis_Forma.Actualiza(objDis_Forma);

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

            if (txtDis_Forma.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Forma.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDis_Forma.Where(oB => oB.DescDis_Forma.ToUpper() == txtDis_Forma.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Forma ya existe.\n";
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