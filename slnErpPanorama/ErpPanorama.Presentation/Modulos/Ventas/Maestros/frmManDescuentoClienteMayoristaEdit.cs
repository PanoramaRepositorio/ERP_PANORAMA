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
    public partial class frmManDescuentoClienteMayoristaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<DescuentoClienteMayoristaBE> lstDescuentoClienteMayorista;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DescuentoClienteMayoristaBE pDescuentoClienteMayoristaBE { get; set; }

        int _IdDescuentoClienteMayorista = 0;

        public int IdDescuentoClienteMayorista
        {
            get { return _IdDescuentoClienteMayorista; }
            set { _IdDescuentoClienteMayorista = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManDescuentoClienteMayoristaEdit()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClienteMayoristaEdit_Load(object sender, EventArgs e)
        {

            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Descuento Cliente Mayorista (Por Escalas) - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Descuento Cliente Mayorista (Por Escalas) - Modificar";
                cboFormaPago.EditValue = pDescuentoClienteMayoristaBE.IdFormaPago;
                cboLineaProducto.EditValue = pDescuentoClienteMayoristaBE.IdLineaProducto;
                txtMontoMin.EditValue = pDescuentoClienteMayoristaBE.MontoMin;
                txtMontoMax.EditValue = pDescuentoClienteMayoristaBE.MontoMax;
                txtDescuento.EditValue = pDescuentoClienteMayoristaBE.PorDescuento;
                chkPreventa.Checked = pDescuentoClienteMayoristaBE.FlagPreVenta;
                chkVenta.Checked = pDescuentoClienteMayoristaBE.FlagVenta;
            }

            cboFormaPago.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    DescuentoClienteMayoristaBE objDescuentoClienteMayorista = new DescuentoClienteMayoristaBE();
                    DescuentoClienteMayoristaBL objBL_DescuentoClienteMayorista = new DescuentoClienteMayoristaBL();

                    objDescuentoClienteMayorista.IdDescuentoClienteMayorista = IdDescuentoClienteMayorista;
                    objDescuentoClienteMayorista.IdLineaProducto = Convert.ToInt32(cboLineaProducto.EditValue);
                    objDescuentoClienteMayorista.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDescuentoClienteMayorista.MontoMin = Convert.ToDecimal(txtMontoMin.EditValue);
                    objDescuentoClienteMayorista.MontoMax = Convert.ToDecimal(txtMontoMax.EditValue);
                    objDescuentoClienteMayorista.PorDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objDescuentoClienteMayorista.FlagPreVenta = chkPreventa.Checked;
                    objDescuentoClienteMayorista.FlagVenta = chkVenta.Checked;
                    objDescuentoClienteMayorista.FlagEstado = true;
                    objDescuentoClienteMayorista.Usuario = Parametros.strUsuarioLogin;
                    objDescuentoClienteMayorista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDescuentoClienteMayorista.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_DescuentoClienteMayorista.Inserta(objDescuentoClienteMayorista);
                    else
                        objBL_DescuentoClienteMayorista.Actualiza(objDescuentoClienteMayorista);

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

            if (cboFormaPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar forma de pago.\n";
                flag = true;
            }

            if (cboLineaProducto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar Linea de Producto.\n";
                flag = true;
            }

            if (txtMontoMin.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el monto mínimo.\n";
                flag = true;
            }

            if (txtMontoMax.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el monto máximo.\n";
                flag = true;
            }


            if (txtDescuento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese porcentaje descuento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDescuentoClienteMayorista.Where(oB => oB.IdFormaPago == Convert.ToInt32(cboFormaPago.EditValue) && oB.IdLineaProducto == Convert.ToInt32(cboLineaProducto.EditValue) && oB.MontoMin == Convert.ToDecimal(txtMontoMin.EditValue) && oB.MontoMax == Convert.ToDecimal(txtMontoMax.EditValue) && oB.PorDescuento == Convert.ToDecimal(txtDescuento.EditValue) &&
                    oB.FlagPreVenta == chkPreventa.Checked && oB.FlagVenta == chkVenta.Checked).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Criterio de descuento ya existe.\n";
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