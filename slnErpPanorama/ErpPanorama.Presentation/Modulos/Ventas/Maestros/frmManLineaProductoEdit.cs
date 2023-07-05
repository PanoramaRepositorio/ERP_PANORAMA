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
    public partial class frmManLineaProductoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<LineaProductoBE> lstLineaProducto;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public LineaProductoBE pLineaProductoBE { get; set; }

        int _IdLineaProducto = 0;

        public int IdLineaProducto
        {
            get { return _IdLineaProducto; }
            set { _IdLineaProducto = value; }
        }

        #endregion

        #region "Eventos"

        public frmManLineaProductoEdit()
        {
            InitializeComponent();
        }

        private void frmManLineaProductoEdit_Load(object sender, EventArgs e)
        {

            BSUtils.LoaderLook(cboFamilia, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Linea de Producto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Linea de Producto - Modificar";
                cboFamilia.EditValue = pLineaProductoBE.IdFamiliaProducto;
                txtNumero.EditValue = pLineaProductoBE.Numero;
                txtLineaProducto.Text = pLineaProductoBE.DescLineaProducto.Trim();
            }

            txtNumero.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    LineaProductoBL objBL_LineaProducto = new LineaProductoBL();

                    LineaProductoBE objLineaProducto = new LineaProductoBE();
                    objLineaProducto.IdFamiliaProducto = Convert.ToInt32(cboFamilia.EditValue);
                    objLineaProducto.IdLineaProducto = IdLineaProducto;
                    objLineaProducto.Numero = Convert.ToInt32(txtNumero.EditValue);
                    objLineaProducto.DescLineaProducto = txtLineaProducto.Text;
                    objLineaProducto.FlagEstado = true;
                    objLineaProducto.Usuario = Parametros.strUsuarioLogin;
                    objLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objLineaProducto.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_LineaProducto.Inserta(objLineaProducto);
                    else
                        objBL_LineaProducto.Actualiza(objLineaProducto);

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

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el numero de la linea de producto.\n";
                flag = true;
            }

            if (txtLineaProducto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese linea de producto.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstLineaProducto.Where(oB => oB.DescLineaProducto.ToUpper() == txtLineaProducto.Text.ToUpper()).ToList();
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