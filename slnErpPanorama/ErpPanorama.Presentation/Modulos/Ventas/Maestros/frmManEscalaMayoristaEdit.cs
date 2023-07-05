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
    public partial class frmManEscalaMayoristaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<EscalaMayoristaBE> lstEscalaMayoristaBE;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public EscalaMayoristaBE pDescuentoClienteMayoristaBE { get; set; }

        int _IdDescuentoClienteMayorista = 0;

        public int IdDescuentoClienteMayorista
        {
            get { return _IdDescuentoClienteMayorista; }
            set { _IdDescuentoClienteMayorista = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManEscalaMayoristaEdit()
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
                this.Text = "Escala Cliente Mayorista - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Escala Cliente Mayorista- Modificar";
                cboFamiliaProducto.EditValue = pDescuentoClienteMayoristaBE.IdFamiliaProducto;
                cboFormaPago.EditValue = pDescuentoClienteMayoristaBE.IdFormaPago;
                txtPrecio_Del.EditValue = pDescuentoClienteMayoristaBE.Precio_Del;
                txtPrecio_Al.EditValue = pDescuentoClienteMayoristaBE.Precio_Al;
                txtDescuento.EditValue = pDescuentoClienteMayoristaBE.Descuento;
                chkGeneral.Checked = pDescuentoClienteMayoristaBE.General;
                if (pDescuentoClienteMayoristaBE.General)
                {
                    txtPrecio_Del.Enabled = false;
                    txtPrecio_Al.Enabled = false;
                }
                cboFamiliaProducto.Enabled = false;
                cboFormaPago.Enabled = false;
                chkGeneral.Enabled = false;
            }
            lstEscalaMayoristaBE = new EscalaMayoristaBL().ListaTodosActivo(0, 0);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    if (!ValidarGeneral())  return;
                   
                    
                    EscalaMayoristaBE objDsctoClienteMayorista = new EscalaMayoristaBE();
                    EscalaMayoristaBL objBL_DsctoClienteMayorista = new EscalaMayoristaBL();

                    objDsctoClienteMayorista.IdEscalaMayorista = IdDescuentoClienteMayorista;
                    objDsctoClienteMayorista.IdFamiliaProducto = Convert.ToInt32(cboFamiliaProducto.EditValue);
                    objDsctoClienteMayorista.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDsctoClienteMayorista.General = chkGeneral.Checked;
                    objDsctoClienteMayorista.Precio_Del = Convert.ToDecimal(txtPrecio_Del.EditValue);
                    objDsctoClienteMayorista.Precio_Al = Convert.ToDecimal(txtPrecio_Al.EditValue);
                    objDsctoClienteMayorista.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
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

            string sDescuento = txtDescuento.Text.Trim().ToString();

            if (sDescuento == "" || sDescuento == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el Descuento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstEscalaMayoristaBE.Where(
                    oB => oB.IdFormaPago == Convert.ToInt32(cboFormaPago.EditValue) && 
                    oB.IdFamiliaProducto == Convert.ToInt32(cboFamiliaProducto.EditValue) && 
                    oB.Precio_Del == Convert.ToDecimal(txtPrecio_Del.EditValue) &&
                    oB.Precio_Al == Convert.ToDecimal(txtPrecio_Al.EditValue) &&
                    oB.Descuento == Convert.ToDecimal(txtDescuento.EditValue) 
                    //oB.Descuento == Convert.ToDecimal(txtDsctoMayorista.EditValue) && 
                   ).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El descuento ya existe.\n";
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

        private bool ValidarGeneral()
        {
            bool flag = true;

            if (chkGeneral.Checked)
            {
                var BuscarGeneral = lstEscalaMayoristaBE.Where(
                  oB =>  oB.IdFamiliaProducto == Convert.ToInt32(cboFamiliaProducto.EditValue) &&

oB.IdFormaPago == Convert.ToInt32(cboFormaPago.EditValue) &&
                  oB.General == false
                 ).ToList();
                if (BuscarGeneral.Count > 0)
                {
                    if (XtraMessageBox.Show("¿Esta seguro de Poner el descuento General?, Se eliminaran todos los registros de la linea.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (var item in BuscarGeneral)
                        {
                            int id = item.IdEscalaMayorista;
                            EscalaMayoristaBE objE_Mayorista = new EscalaMayoristaBE();
                            objE_Mayorista.IdEscalaMayorista = id;
                            objE_Mayorista.Usuario = Parametros.strUsuarioLogin;
                            objE_Mayorista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_Mayorista.IdEmpresa = Parametros.intEmpresaId;

                            EscalaMayoristaBL objBL_Mayorista = new EscalaMayoristaBL();
                            objBL_Mayorista.Elimina(objE_Mayorista);
                        }
                    }
                    else
                    {
                        flag = false;
                        Cursor = Cursors.Default;
                    }
                }
            }

            return flag;
        }

        #endregion

        private void chkGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGeneral.Checked)
            {
                txtPrecio_Del.Enabled = false;
                txtPrecio_Al.Enabled = false;
                txtPrecio_Del.Text = "0.00";
                txtPrecio_Al.Text = "0.00";
            }
            else
            {
                txtPrecio_Del.Enabled = true;
                txtPrecio_Al.Enabled = true;
            }
        }
    }
}