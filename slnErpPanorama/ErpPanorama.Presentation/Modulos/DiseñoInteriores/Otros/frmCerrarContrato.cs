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
    public partial class frmCerrarContrato : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public Dis_ContratoFabricacionBE oBE;
        public int IdDis_ContratoFabricacion = 0;
        public string Usuario = "";

        #endregion

        #region "Eventos"

        public frmCerrarContrato()
        {
            InitializeComponent();
        }

        private void frmCerrarContrato_Load(object sender, EventArgs e)
        {
            oBE = new Dis_ContratoFabricacionBL().Selecciona(IdDis_ContratoFabricacion);
            if (oBE.FlagInstalaTermina == true) optTerminadoSI.Checked = true; else optTerminadoNO.Checked = true;
            if (oBE.FlagEncuestaPostVenta == true) optPostVentaSI.Checked = true; else optPostVentaNO.Checked = true;
            if (oBE.FlagConforme == true) optConformeSI.Checked = true; else optConformeNO.Checked = true;
            chkCerrarEncuesta.Checked = oBE.FlagEncuestaCerrada;

            if (chkCerrarEncuesta.Checked)
                btnGrabar.Enabled = false;

            btnCancelar.Focus();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIngreso())
            {
                oBE = new Dis_ContratoFabricacionBE();
                oBE.IdDis_ContratoFabricacion = IdDis_ContratoFabricacion;
                oBE.FlagInstalaTermina = optTerminadoSI.Checked == true ? true : false;
                oBE.FlagEncuestaPostVenta = optPostVentaSI.Checked == true ? true : false;
                oBE.FlagConforme = optConformeSI.Checked == true ? true : false;
                oBE.FlagEncuestaCerrada = chkCerrarEncuesta.Checked;
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