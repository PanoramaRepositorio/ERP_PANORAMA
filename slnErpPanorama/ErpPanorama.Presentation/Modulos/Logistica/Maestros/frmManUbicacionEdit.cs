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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManUbicacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<UbicacionBE> lstUbicacion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public UbicacionBE pUbicacionBE { get; set; }

        int _IdUbicacion = 0;

        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }

        #endregion

        #region "Eventos"

        public frmManUbicacionEdit()
        {
            InitializeComponent();
        }

        private void frmManUbicacionEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ubicacion - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Ubicacion - Modificar";
                txtDescripcion.Text = pUbicacionBE.DescUbicacion.Trim();
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
                    UbicacionBL objBL_Ubicacion = new UbicacionBL();
                    UbicacionBE objUbicacion = new UbicacionBE();
                    objUbicacion.IdUbicacion = IdUbicacion;
                    objUbicacion.IdTienda = Parametros.intTiendaId;
                    objUbicacion.DescUbicacion = txtDescripcion.Text;
                    objUbicacion.FlagEstado = true;
                    objUbicacion.Usuario = Parametros.strUsuarioLogin;
                    objUbicacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUbicacion.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Ubicacion.Inserta(objUbicacion);
                    else
                        objBL_Ubicacion.Actualiza(objUbicacion);

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
                var Buscar = lstUbicacion.Where(oB => oB.DescUbicacion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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