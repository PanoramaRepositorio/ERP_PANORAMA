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
    public partial class frmManCampanaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CampanaBE> lstCampana;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CampanaBE pCampanaBE { get; set; }

        int _IdCampana = 0;

        public int IdCampana
        {
            get { return _IdCampana; }
            set { _IdCampana = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCampanaEdit()
        {
            InitializeComponent();
        }

        private void frmManCampanaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Campana - Nuevo";
                txtCampana.Text = pCampanaBE.DescCampana.Trim();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Campana - Modificar";
                txtCampana.Text = pCampanaBE.DescCampana.Trim();
            }

            txtCampana.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CampanaBL objBL_Campana = new CampanaBL();
                    CampanaBE objCampana = new CampanaBE();

                    objCampana.IdCampana = IdCampana;
                    objCampana.DescCampana = txtCampana.Text;
                    objCampana.FlagEstado = true;
                    objCampana.Usuario = Parametros.strUsuarioLogin;
                    objCampana.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCampana.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Campana.Inserta(objCampana);
                    else
                        objBL_Campana.Actualiza(objCampana);

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

            if (txtCampana.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese campaña.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstCampana.Where(oB => oB.DescCampana.ToUpper() == txtCampana.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La campaña ya existe.\n";
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