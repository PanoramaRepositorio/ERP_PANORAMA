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
    public partial class frmManClienteCorreoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClienteCorreoBE> lstClienteCorreo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ClienteCorreoBE pClienteCorreoBE { get; set; }

        int _IdClienteCorreo = 0;

        public int IdClienteCorreo
        {
            get { return _IdClienteCorreo; }
            set { _IdClienteCorreo = value; }
        }

        #endregion

        #region "Eventos"

        public frmManClienteCorreoEdit()
        {
            InitializeComponent();
        }

        private void frmManClienteCorreoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Linea de Producto - Nuevo";
                txtClienteCorreo.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Linea de Producto - Modificar";
           
                txtClienteCorreo.Text = pClienteCorreoBE.Email.Trim();
            }

            txtClienteCorreo.Select();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClienteCorreoBL objBL_ClienteCorreo = new ClienteCorreoBL();

                    ClienteCorreoBE objClienteCorreo = new ClienteCorreoBE();
                    objClienteCorreo.IdClienteCorreo = IdClienteCorreo;
                    objClienteCorreo.IdCliente = 147586;// 0;  panorama Distribuidores
                    objClienteCorreo.Email = txtClienteCorreo.Text;
                    objClienteCorreo.FlagEstado = true;
                    objClienteCorreo.Usuario = Parametros.strUsuarioLogin;
                    objClienteCorreo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objClienteCorreo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ClienteCorreo.Inserta(objClienteCorreo);
                    else
                        objBL_ClienteCorreo.Actualiza(objClienteCorreo);

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

            if (txtClienteCorreo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese linea de producto.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstClienteCorreo.Where(oB => oB.Email.ToUpper() == txtClienteCorreo.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La linea de producto ya existe.\n";
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