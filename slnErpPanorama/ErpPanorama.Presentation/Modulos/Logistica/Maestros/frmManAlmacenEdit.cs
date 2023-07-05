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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManAlmacenEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<AlmacenBE> lstAlmacen;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public AlmacenBE pAlmacenBE { get; set; }

        int _IdAlmacen = 0;

        public int IdAlmacen
        {
            get { return _IdAlmacen; }
            set { _IdAlmacen = value; }
        }

        #endregion

        #region "Eventos"

        public frmManAlmacenEdit()
        {
            InitializeComponent();
        }

        private void frmManAlmacenEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Almacen - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Almacen - Modificar";
                cboEmpresa.EditValue = pAlmacenBE.IdEmpresa;
                cboTienda.EditValue = pAlmacenBE.IdTienda;
                txtDescripcion.Text = pAlmacenBE.DescAlmacen.Trim();
            }

            txtDescripcion.Select();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AlmacenBL objBL_Almacen = new AlmacenBL();
                    AlmacenBE objAlmacen = new AlmacenBE();
                    objAlmacen.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objAlmacen.IdAlmacen = IdAlmacen;
                    objAlmacen.DescAlmacen = txtDescripcion.Text.Trim();
                    objAlmacen.FlagEstado = true;
                    objAlmacen.Usuario = Parametros.strUsuarioLogin;
                    objAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objAlmacen.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Almacen.Inserta(objAlmacen);
                    else
                        objBL_Almacen.Actualiza(objAlmacen);

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
                strMensaje = strMensaje + "- Ingrese el Almacén.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstAlmacen.Where(oB => oB.DescAlmacen.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Almacén ya existe.\n";
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