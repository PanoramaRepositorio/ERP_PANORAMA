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

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManBancoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<BancoBE> lstBanco;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public BancoBE pBancoBE { get; set; }

        int _IdBanco = 0;

        public int IdBanco
        {
            get { return _IdBanco; }
            set { _IdBanco = value; }
        }

        #endregion

        #region "Eventos"

        public frmManBancoEdit()
        {
            InitializeComponent();
        }
        private void frmManBancoEdit_Load(object sender, EventArgs e)
        {
           if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Banco - Nuevo";
                //txtBanco.Text = pBancoBE.DescBanco.Trim();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Banco - Modificar";
                txtBanco.Text = pBancoBE.DescBanco.Trim();
                txtAbreviatura.Text = pBancoBE.Abreviatura;
            }

            txtBanco.Select();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    BancoBL objBL_Banco = new BancoBL();
                    BancoBE objBanco = new BancoBE();
                    objBanco.IdBanco = IdBanco;
                    objBanco.DescBanco = txtBanco.Text;
                    objBanco.Abreviatura = txtAbreviatura.Text.Trim();
                    objBanco.FlagEstado = true;
                    objBanco.Usuario = Parametros.strUsuarioLogin;
                    objBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objBanco.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Banco.Inserta(objBanco);
                    else
                        objBL_Banco.Actualiza(objBanco);

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

            if (txtBanco.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese banco.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstBanco.Where(oB => oB.DescBanco.ToUpper() == txtBanco.Text.ToUpper()).ToList();
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