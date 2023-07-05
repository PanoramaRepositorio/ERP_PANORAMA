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
    public partial class frmManTablaElementoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<TablaElementoBE> lstTablaElemento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TablaElementoBE pTablaElementoBE { get; set; }

        int _IdTabla = 0;

        public int IdTabla
        {
            get { return _IdTabla; }
            set { _IdTabla = value; }
        }

        int _IdTablaElemento = 0;

        public int IdTablaElemento
        {
            get { return _IdTablaElemento; }
            set { _IdTablaElemento = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTablaElementoEdit()
        {
            InitializeComponent();
        }

        private void frmManTablaElementoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTabla, new TablaBL().ListaTodosActivo(Parametros.intEmpresaId) , "DescTabla", "IdTabla", true);
            cboTabla.EditValue = IdTabla;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tabla - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tabla - Modificar";
                txtAbreviatura.Text = pTablaElementoBE.Abreviatura;
                txtDescripcion.Text = pTablaElementoBE.DescTablaElemento;
            }

            txtAbreviatura.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TablaElementoBL objBL_TablaElemento = new TablaElementoBL();

                    TablaElementoBE objTablaElemento = new TablaElementoBE();
                    objTablaElemento.IdTabla = IdTabla;
                    objTablaElemento.IdTablaElemento = IdTablaElemento;
                    objTablaElemento.Abreviatura = txtAbreviatura.Text;
                    objTablaElemento.DescTablaElemento = txtDescripcion.Text;
                    objTablaElemento.FlagEstado = true;
                    objTablaElemento.Usuario = Parametros.strUsuarioLogin;
                    objTablaElemento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTablaElemento.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TablaElemento.Inserta(objTablaElemento);
                    else
                        objBL_TablaElemento.Actualiza(objTablaElemento);

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

            if (string.IsNullOrEmpty(cboTabla.Text))
            {
                strMensaje = strMensaje + "- Seleccionar la tabla.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTablaElemento.Where(oB => oB.DescTablaElemento.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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