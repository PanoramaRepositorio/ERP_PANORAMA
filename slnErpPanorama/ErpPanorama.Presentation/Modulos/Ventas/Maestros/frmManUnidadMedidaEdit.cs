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
    public partial class frmManUnidadMedidaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<UnidadMedidaBE> lstUnidadMedida;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public UnidadMedidaBE pUnidadMedidaBE { get; set; }

        int _IdUnidadMedida = 0;

        public int IdUnidadMedida
        {
            get { return _IdUnidadMedida; }
            set { _IdUnidadMedida = value; }
        }

        #endregion

        #region "Eventos"

        public frmManUnidadMedidaEdit()
        {
            InitializeComponent();
        }

        private void frmManUnidadMedidaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Unidad de Medida - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Unidad de Medida - Modificar";
                txtAbreviatura.EditValue = pUnidadMedidaBE.Abreviatura;
                txtUnidadMedida.EditValue = pUnidadMedidaBE.DescUnidadMedida;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    UnidadMedidaBL objBL_UnidadMedida = new UnidadMedidaBL();
                    UnidadMedidaBE objUnidadMedida = new UnidadMedidaBE();
                    objUnidadMedida.IdUnidadMedida = IdUnidadMedida;
                    objUnidadMedida.DescUnidadMedida = txtUnidadMedida.Text;
                    objUnidadMedida.Abreviatura = txtAbreviatura.Text;
                    objUnidadMedida.FlagEstado = true;
                    objUnidadMedida.Usuario = Parametros.strUsuarioLogin;
                    objUnidadMedida.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objUnidadMedida.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_UnidadMedida.Inserta(objUnidadMedida);
                    else
                        objBL_UnidadMedida.Actualiza(objUnidadMedida);

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

            if (txtAbreviatura.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Abreviatura.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstUnidadMedida.Where(oB => oB.Abreviatura == Convert.ToString(txtAbreviatura.EditValue) && oB.DescUnidadMedida == Convert.ToString(txtUnidadMedida.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La Abreviatura ya existe.\n";
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