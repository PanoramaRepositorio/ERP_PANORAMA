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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTablaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        public List<TablaBE> lstTabla;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TablaBE pTablaBE { get; set; }

        int _IdTabla = 0;

        public int IdTabla
        {
            get { return _IdTabla; }
            set { _IdTabla = value; }
        }
        
        
        #endregion

        #region "Eventos"

        public frmManTablaEdit()
        {
            InitializeComponent();
        }

        private void frmManTablaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tabla - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tabla - Modificar";
                txtDescripcion.Text = pTablaBE.DescTabla.Trim();

            }

            txtDescripcion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TablaBL objBL_Tabla = new TablaBL();
                    TablaBE objTabla = new TablaBE();
                    objTabla.IdTabla = IdTabla;
                    objTabla.DescTabla = txtDescripcion.Text;
                    objTabla.FlagEstado = true;
                    objTabla.Usuario = Parametros.strUsuarioLogin;
                    objTabla.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTabla.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tabla.Inserta(objTabla);
                    else
                        objBL_Tabla.Actualiza(objTabla);

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
            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTabla.Where(oB => oB.DescTabla.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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