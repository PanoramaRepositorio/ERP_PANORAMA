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
using ErpPanorama.Presentation.Utils;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTiendaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<TiendaBE> lstTienda;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TiendaBE pTiendaBE { get; set; }

        int _IdTienda = 0;

        public int IdTienda
        {
            get { return _IdTienda; }
            set { _IdTienda = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTiendaEdit()
        {
            InitializeComponent();
        }

        private void frmManTiendaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tienda - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tienda - Modificar";
                cboEmpresa.EditValue = pTiendaBE.IdEmpresa;
                txtDescripcion.Text = pTiendaBE.DescTienda.Trim();
                txtDireccion.Text = pTiendaBE.Direccion.Trim();
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
                    TiendaBL objBL_Tienda = new TiendaBL();
                    TiendaBE objTienda = new TiendaBE();
                    objTienda.IdTienda = IdTienda;
                    objTienda.DescTienda = txtDescripcion.Text;
                    objTienda.Direccion = txtDireccion.Text;
                    objTienda.FlagEstado = true;
                    objTienda.Usuario = Parametros.strUsuarioLogin;
                    objTienda.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTienda.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tienda.Inserta(objTienda);
                    else
                        objBL_Tienda.Actualiza(objTienda);

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
                var Buscar = lstTienda.Where(oB => oB.DescTienda.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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