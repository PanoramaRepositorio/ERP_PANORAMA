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
    public partial class frmManDescuentoClienteFinalEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<DescuentoClienteFinalBE> lstDescuentoClienteFinal;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DescuentoClienteFinalBE pDescuentoClienteFinalBE { get; set; }

        int _IdDescuentoClienteFinal = 0;

        public int IdDescuentoClienteFinal
        {
            get { return _IdDescuentoClienteFinal; }
            set { _IdDescuentoClienteFinal = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManDescuentoClienteFinalEdit()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClienteFinalEdit_Load(object sender, EventArgs e)
        {
            txtPorDesc.Properties.Mask.EditMask = "(\\d{1,2}|100)?";
            txtPorDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            BSUtils.LoaderLook(cboTipoPrecio, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPrecio), "DescTablaElemento", "IdTablaElemento", true);

            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionClienteFinal), "DescTablaElemento", "IdTablaElemento", true);
            cboClasificacion.EditValue = Parametros.intClasico;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Descuento Cliente Final (Por Cantidades) - Nuevo";
                
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Descuento Cliente Final (Por Cantidades) - Modificar";
                cboClasificacion.EditValue = pDescuentoClienteFinalBE.IdClasificacionCliente;
                txtCantidadMin.EditValue = pDescuentoClienteFinalBE.CantidadMinima;
                txtCantidadMax.EditValue = pDescuentoClienteFinalBE.CantidadMaxima;
                cboTipoPrecio.EditValue = pDescuentoClienteFinalBE.IdTipoPrecio;
                txtPorDesc.EditValue = pDescuentoClienteFinalBE.PorDescuento;
                chkOpcional.Checked = pDescuentoClienteFinalBE.FlagOpcional;
            }

            txtCantidadMin.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    DescuentoClienteFinalBL objBL_DescuentoClienteFinal = new DescuentoClienteFinalBL();
                    DescuentoClienteFinalBE objDescuentoClienteFinal = new DescuentoClienteFinalBE();
                    objDescuentoClienteFinal.IdDescuentoClienteFinal = IdDescuentoClienteFinal;
                    objDescuentoClienteFinal.IdClasificacionCliente = Convert.ToInt32(cboClasificacion.EditValue);
                    objDescuentoClienteFinal.CantidadMinima = Convert.ToInt32(txtCantidadMin.EditValue);
                    objDescuentoClienteFinal.CantidadMaxima = Convert.ToInt32(txtCantidadMax.EditValue);
                    objDescuentoClienteFinal.IdTipoPrecio = Convert.ToInt32(cboTipoPrecio.EditValue);
                    objDescuentoClienteFinal.PorDescuento = Convert.ToInt32(txtPorDesc.EditValue);
                    objDescuentoClienteFinal.FlagOpcional = chkOpcional.Checked;
                    objDescuentoClienteFinal.FlagEstado = true;
                    objDescuentoClienteFinal.Usuario = Parametros.strUsuarioLogin;
                    objDescuentoClienteFinal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDescuentoClienteFinal.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_DescuentoClienteFinal.Inserta(objDescuentoClienteFinal);
                    else
                        objBL_DescuentoClienteFinal.Actualiza(objDescuentoClienteFinal);

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

            if (txtCantidadMin.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese DescuentoClienteFinal.\n";
                flag = true;
            }

            if (txtCantidadMax.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese DescuentoClienteFinal.\n";
                flag = true;
            }

            if (cboTipoPrecio.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar tipo de precio.\n";
                flag = true;
            }

            if (txtPorDesc.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese porcentaje descuento.\n";
                flag = true;
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