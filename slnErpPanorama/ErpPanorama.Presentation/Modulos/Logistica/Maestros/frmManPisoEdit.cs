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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManPisoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<PisoBE> lstPiso;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PisoBE pPisoBE { get; set; }

        int _IdPiso = 0;

        public int IdPiso
        {
            get { return _IdPiso; }
            set { _IdPiso = value; }
        }

        int _IdUbicacion = 0;

        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManPisoEdit()
        {
            InitializeComponent();
        }

        private void frmManPisoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUbicacion, new UbicacionBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescUbicacion", "IdUbicacion", true);
            cboUbicacion.EditValue = IdUbicacion;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Piso - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Piso - Modificar";
                cboUbicacion.EditValue = pPisoBE.IdUbicacion;
                txtDescripcion.Text = pPisoBE.DescPiso;
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
                    PisoBL objBL_Piso = new PisoBL();
                    PisoBE objPiso = new PisoBE();

                    objPiso.IdUbicacion = Convert.ToInt32(cboUbicacion.EditValue);
                    objPiso.IdPiso = IdPiso;
                    objPiso.DescPiso = txtDescripcion.Text;
                    objPiso.FlagEstado = true;
                    objPiso.Usuario = Parametros.strUsuarioLogin;
                    objPiso.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPiso.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Piso.Inserta(objPiso);
                    else
                        objBL_Piso.Actualiza(objPiso);

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

            if (string.IsNullOrEmpty(cboUbicacion.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un Ubicacion.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPiso.Where(oB => oB.DescPiso.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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