using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Otros
{
    public partial class frmCerrarProyecto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public Dis_ProyectoServicioBE oBE;
        public int IdProyecto= 0;
        public string Usuario = "";
        #endregion

        #region "Eventos"
        public frmCerrarProyecto()
        {
            InitializeComponent();
        }

        private void frmCerrarProyecto_Load(object sender, EventArgs e)
        {
            btnCancelar.Focus();
            optPlanoSI.Checked = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(!ValidarIngreso())
            {
                oBE = new Dis_ProyectoServicioBE();
                oBE.IdDis_ProyectoServicio = IdProyecto;
                oBE.FlagCerrado = true;
                oBE.FlagPlano = optPlanoSI.Checked == true? true : false;
                oBE.FlagVisita = optVisitaSI.Checked == true ? true : false;
                oBE.FlagInstalaTermina = optTerminadoSI.Checked == true ? true : false;
                oBE.FlagEncuestaPostVenta = optPostVentaSI.Checked == true ? true : false;
                oBE.FlagConforme = optConformeSI.Checked == true ? true : false;
                oBE.Usuario = Usuario;// Parametros.strUsuarioLogin;
                oBE.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                oBE.IdEmpresa = Parametros.intEmpresaId;

                this.DialogResult = DialogResult.OK;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Métodos"
        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (!optPlanoSI.Checked && !optPlanoNO.Checked)
            {
                strMensaje = strMensaje + "- Seleccionar Si tiene Plano.\n";
                flag = true;
            }

            if (!optVisitaSI .Checked && !optVisitaNO.Checked)
            {
                strMensaje = strMensaje + "- Seleccionar Si tiene Visita.\n";
                flag = true;
            }

            if (!optTerminadoSI.Checked && !optTerminadoNO.Checked)
            {
                strMensaje = strMensaje + "- Seleccionar Si La Instalación fue terminada.\n";
                flag = true;
            }

            if (!optPostVentaSI.Checked && !optPostVentaNO.Checked)
            {
                strMensaje = strMensaje + "- Seleccionar Si Realizó Encuesta Post-Venta.\n";
                flag = true;
            }

            if (!optConformeSI.Checked && !optConformeNO.Checked)
            {
                strMensaje = strMensaje + "- Seleccionar Si El Cliente quedó conforme.\n";
                flag = true;
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