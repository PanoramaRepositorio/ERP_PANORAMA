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
    public partial class frmManDsctoMayoristaFamiliaFormaPagoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<DsctoMayoristaFamiliaFormaPagoBE> lstDsctoMayoristaFamiliaFormaPagoBE;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DsctoMayoristaFamiliaFormaPagoBE pDescuentoClienteMayoristaBE { get; set; }

        int _IdDescuentoClienteMayorista = 0;

        public int IdDescuentoClienteMayorista
        {
            get { return _IdDescuentoClienteMayorista; }
            set { _IdDescuentoClienteMayorista = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManDsctoMayoristaFamiliaFormaPagoEdit()
        {
            InitializeComponent();
        }

        private void frmManDescuentoMayoristaLineaPagoEdit_Load(object sender, EventArgs e)
        {

            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboFamiliaProducto, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            //cboFormaPago.EditValue = Parametros.intContado;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Descuento Cliente Mayorista Familia Forma Pago - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Descuento Cliente Mayorista Familia Forma Pago - Modificar";
                cboFamiliaProducto.EditValue = pDescuentoClienteMayoristaBE.IdFamiliaProducto;
                cboFormaPago.EditValue = pDescuentoClienteMayoristaBE.IdFormaPago;
                txtDsctoMayorista.EditValue = pDescuentoClienteMayoristaBE.DsctoTiendaMayorista;
                txtPrecio_Del.EditValue = pDescuentoClienteMayoristaBE.Precio_Del;
                txtPrecio_Al.EditValue = pDescuentoClienteMayoristaBE.Precio_Al;
                chkAdicional.Checked = pDescuentoClienteMayoristaBE.Adicional;
                cboFamiliaProducto.Enabled = false;
                cboFormaPago.Enabled = false;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    DsctoMayoristaFamiliaFormaPagoBE objDsctoClienteMayorista = new DsctoMayoristaFamiliaFormaPagoBE();
                    DsctoMayoristaFamiliaFormaPagoBL objBL_DsctoClienteMayorista = new DsctoMayoristaFamiliaFormaPagoBL();

                    objDsctoClienteMayorista.IdDsctoMayoristaFamiliaFormaPago = IdDescuentoClienteMayorista;
                    objDsctoClienteMayorista.IdFamiliaProducto = Convert.ToInt32(cboFamiliaProducto.EditValue);
                    objDsctoClienteMayorista.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDsctoClienteMayorista.Adicional = chkAdicional.Checked;
                    objDsctoClienteMayorista.Precio_Del = Convert.ToDecimal(txtPrecio_Del.EditValue);
                    objDsctoClienteMayorista.Precio_Al = Convert.ToDecimal(txtPrecio_Al.EditValue);
                    objDsctoClienteMayorista.DsctoTiendaMayorista = Convert.ToDecimal(txtDsctoMayorista.EditValue);
                    objDsctoClienteMayorista.IdUsuario = Parametros.intUsuarioId;
                    objDsctoClienteMayorista.FlagEstado = true;
                    objDsctoClienteMayorista.Usuario = Parametros.strUsuarioLogin;
                    objDsctoClienteMayorista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDsctoClienteMayorista.IdEmpresa = Parametros.intEmpresaId;
                    
                    if (pOperacion == Operacion.Nuevo)
                        objBL_DsctoClienteMayorista.Inserta(objDsctoClienteMayorista);
                    else
                        objBL_DsctoClienteMayorista.Actualiza(objDsctoClienteMayorista);

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

            if (cboFamiliaProducto.EditValue.ToString() == "0")
            {
                strMensaje = strMensaje + "- Seleccionar Familia de Producto.\n";
                flag = true;
            }

            if (cboFormaPago.EditValue.ToString() == "0")
            {
                strMensaje = strMensaje + "- Seleccionar forma de pago.\n";
                flag = true;
            }

            string sDsctoMayorista = txtDsctoMayorista.Text.Trim().ToString();
            
            if (sDsctoMayorista == "" || sDsctoMayorista == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el Descuento Mayorista.\n";
                flag = true;
            }
            if (Convert.ToDecimal( sDsctoMayorista )>= 90)
            {
                strMensaje = strMensaje + "- El Descuento no puede ser mayor a 90.00\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDsctoMayoristaFamiliaFormaPagoBE.Where(
                    oB => oB.IdFormaPago == Convert.ToInt32(cboFormaPago.EditValue) && 
                    oB.IdFamiliaProducto == Convert.ToInt32(cboFamiliaProducto.EditValue) && 
                    oB.Precio_Del == Convert.ToDecimal(txtPrecio_Del.EditValue) &&
                    oB.Precio_Al == Convert.ToDecimal(txtPrecio_Al.EditValue)
                   //oB.DsctoTiendaMayorista == Convert.ToDecimal(txtDsctoMayorista.EditValue) && 

                   ).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El descuento Tienda ya existe.\n";
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