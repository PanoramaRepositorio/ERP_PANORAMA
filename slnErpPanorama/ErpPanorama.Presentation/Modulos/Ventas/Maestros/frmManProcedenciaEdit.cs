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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManProcedenciaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Procedimientos"

        public List<ProcedenciaBE> lstProcedencia;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ProcedenciaBE pProcedenciaBE { get; set; }

        int _IdProcedencia = 0;

        public int IdProcedencia
        {
            get { return _IdProcedencia; }
            set { _IdProcedencia = value; }
        }

        #endregion

        #region "Eventos"

        public frmManProcedenciaEdit()
        {
            InitializeComponent();
        }

        private void frmManProcedenciaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Procedencia - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Procedencia - Modificar";
                txtProcedencia.Text = pProcedenciaBE.DescProcedencia.Trim();
            }

            txtProcedencia.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProcedenciaBL objBL_Procedencia = new ProcedenciaBL();
                    ProcedenciaBE objProcedencia = new ProcedenciaBE();
                    objProcedencia.IdProcedencia = IdProcedencia;
                    objProcedencia.DescProcedencia = txtProcedencia.Text;
                    objProcedencia.FlagEstado = true;
                    objProcedencia.Usuario = Parametros.strUsuarioLogin;
                    objProcedencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProcedencia.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Procedencia.Inserta(objProcedencia);
                    else
                        objBL_Procedencia.Actualiza(objProcedencia);

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

            if (txtProcedencia.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Procedencia.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstProcedencia.Where(oB => oB.DescProcedencia.ToUpper() == txtProcedencia.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La procedencia ya existe.\n";
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