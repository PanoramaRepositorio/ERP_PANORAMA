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
    public partial class frmManEstiloEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_EstiloBE> lstDis_Estilo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public Dis_EstiloBE pDis_EstiloBE { get; set; }

        int _IdDis_Estilo = 0;

        public int IdDis_Estilo
        {
            get { return _IdDis_Estilo; }
            set { _IdDis_Estilo = value; }
        }

        #endregion

        #region "Eventos"

        public frmManEstiloEdit()
        {
            InitializeComponent();
        }

        private void frmManEstiloEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Estilo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Estilo - Modificar";
                txtDis_Estilo.Text = pDis_EstiloBE.DescDis_Estilo.Trim();
            }

            txtDis_Estilo.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_EstiloBL objBL_Dis_Estilo = new Dis_EstiloBL();

                    Dis_EstiloBE objDis_Estilo = new Dis_EstiloBE();
                    objDis_Estilo.IdDis_Estilo = IdDis_Estilo;
                    objDis_Estilo.DescDis_Estilo = txtDis_Estilo.Text;
                    objDis_Estilo.FlagEstado = true;
                    objDis_Estilo.Usuario = Parametros.strUsuarioLogin;
                    objDis_Estilo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_Estilo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Dis_Estilo.Inserta(objDis_Estilo);
                    else
                        objBL_Dis_Estilo.Actualiza(objDis_Estilo);

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

            if (txtDis_Estilo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Estilo.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDis_Estilo.Where(oB => oB.DescDis_Estilo.ToUpper() == txtDis_Estilo.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Estilo ya existe.\n";
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