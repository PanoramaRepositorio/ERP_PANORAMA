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
    public partial class frmManSubLineaProductoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<SubLineaProductoBE> lstSubLineaProducto;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SubLineaProductoBE pSubLineaProductoBE { get; set; }

        int _IdSubLineaProducto = 0;

        public int IdSubLineaProducto
        {
            get { return _IdSubLineaProducto; }
            set { _IdSubLineaProducto = value; }
        }

        int _IdLineaProducto = 0;

        public int IdLineaProducto
        {
            get { return _IdLineaProducto; }
            set { _IdLineaProducto = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManSubLineaProductoEdit()
        {
            InitializeComponent();
        }

        private void frmManSubLineaProductoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            cboLineaProducto.EditValue = IdLineaProducto;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Sub Linea - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Sub Linea - Modificar";
                cboLineaProducto.EditValue = pSubLineaProductoBE.IdLineaProducto;
                txtDescripcion.Text = pSubLineaProductoBE.DescSubLineaProducto;
            }

            txtDescripcion.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SubLineaProductoBL objBL_SubLineaProducto = new SubLineaProductoBL();
                    SubLineaProductoBE objSubLineaProducto = new SubLineaProductoBE();

                    objSubLineaProducto.IdSubLineaProducto = IdSubLineaProducto;
                    objSubLineaProducto.IdLineaProducto = Convert.ToInt32(cboLineaProducto.EditValue);
                    objSubLineaProducto.DescSubLineaProducto = txtDescripcion.Text;
                    objSubLineaProducto.FlagEstado = true;
                    objSubLineaProducto.Usuario = Parametros.strUsuarioLogin;
                    objSubLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSubLineaProducto.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_SubLineaProducto.Inserta(objSubLineaProducto);
                    else
                        objBL_SubLineaProducto.Actualiza(objSubLineaProducto);

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

            if (cboLineaProducto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione Linea de producto.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstSubLineaProducto.Where(oB => oB.DescLineaProducto == txtDescripcion.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El modelo del producto ya existe.\n";
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