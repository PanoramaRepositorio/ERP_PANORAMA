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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManAreaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<AreaBE> lstArea;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public AreaBE pAreaBE { get; set; }

        int _IdArea = 0;

        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }

        #endregion

        #region "Eventos"

        public frmManAreaEdit()
        {
            InitializeComponent();
        }

        private void frmManAreaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Area - Nuevo";
                
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Area - Modificar";
                txtArea.Text = pAreaBE.DescArea.Trim();
            }

            txtArea.Select();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AreaBL objBL_Area = new AreaBL();
                    AreaBE objArea = new AreaBE();
                    objArea.IdArea = IdArea;
                    objArea.DescArea = txtArea.Text;
                    objArea.FlagEstado = true;
                    objArea.Usuario = Parametros.strUsuarioLogin;
                    objArea.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objArea.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Area.Inserta(objArea);
                    else
                        objBL_Area.Actualiza(objArea);

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

            if (txtArea.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Area.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstArea.Where(oB => oB.DescArea.ToUpper() == txtArea.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción ya existe.\n";
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