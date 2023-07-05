using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromocionValeDescuentoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PromocionValeDescuentoBE> lstPromocionValeDescuento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PromocionValeDescuentoBE pPromocionValeDescuentoBE { get; set; }

        int _IdPromocionValeDescuento = 0;

        public int IdPromocionValeDescuento
        {
            get { return _IdPromocionValeDescuento; }
            set { _IdPromocionValeDescuento = value; }
        }

        #endregion

        #region "Eventos"

        public frmManPromocionValeDescuentoEdit()
        {
            InitializeComponent();
        }

        private void frmManPromocionValeDescuentoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboTipoPromocion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPromocion), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Vale de Descuento - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Vale de Descuento - Modificar";
                txtDescripcion.Text = pPromocionValeDescuentoBE.Descripcion;
                cboEmpresa.EditValue = pPromocionValeDescuentoBE.IdEmpresa;
                cboFormaPago.EditValue = pPromocionValeDescuentoBE.IdFormaPago;
                cboTipoCliente.EditValue = pPromocionValeDescuentoBE.IdTipoCliente;
                cboTienda.EditValue = pPromocionValeDescuentoBE.IdTienda;
                deDesde.EditValue = pPromocionValeDescuentoBE.FechaInicio;
                deHasta.EditValue = pPromocionValeDescuentoBE.FechaFin;
                txtMontoMin.EditValue = pPromocionValeDescuentoBE.MontoMin;
                txtMontoMax.EditValue = pPromocionValeDescuentoBE.MontoMax;
                txtDescuentoDesde.EditValue = pPromocionValeDescuentoBE.DescuentoDesde;
                txtDescuentoHasta.EditValue = pPromocionValeDescuentoBE.DescuentoHasta;
                txtDescuentoAdicional.EditValue = pPromocionValeDescuentoBE.DescuentoAdicional;
                txtImporte.EditValue = pPromocionValeDescuentoBE.Importe;
                txtObservacion.Text = pPromocionValeDescuentoBE.Observacion;
                cboTipoPromocion.EditValue = pPromocionValeDescuentoBE.IdTipoPromocion;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PromocionValeDescuentoBL objBL_PromocionValeDescuento = new PromocionValeDescuentoBL();
                    PromocionValeDescuentoBE objPromocionValeDescuento = new PromocionValeDescuentoBE();
                    objPromocionValeDescuento.IdPromocionValeDescuento = IdPromocionValeDescuento;
                    objPromocionValeDescuento.Descripcion = txtDescripcion.Text;
                    objPromocionValeDescuento.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPromocionValeDescuento.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objPromocionValeDescuento.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objPromocionValeDescuento.FechaInicio = Convert.ToDateTime(deDesde.DateTime.ToShortDateString());
                    objPromocionValeDescuento.FechaFin = Convert.ToDateTime(deHasta.DateTime.ToShortDateString());
                    objPromocionValeDescuento.MontoMin = Convert.ToDecimal(txtMontoMin.EditValue);
                    objPromocionValeDescuento.MontoMax = Convert.ToDecimal(txtMontoMax.EditValue);
                    objPromocionValeDescuento.DescuentoDesde = Convert.ToDecimal(txtDescuentoDesde.EditValue);
                    objPromocionValeDescuento.DescuentoHasta = Convert.ToDecimal(txtDescuentoHasta.EditValue);
                    objPromocionValeDescuento.DescuentoAdicional = Convert.ToDecimal(txtDescuentoAdicional.EditValue);
                    objPromocionValeDescuento.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objPromocionValeDescuento.Observacion = txtObservacion.Text.Trim();
                    objPromocionValeDescuento.IdTipoPromocion = Convert.ToInt32(cboTipoPromocion.EditValue);
                    objPromocionValeDescuento.FlagEstado = true;
                    objPromocionValeDescuento.Usuario = Parametros.strUsuarioLogin;
                    objPromocionValeDescuento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocionValeDescuento.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_PromocionValeDescuento.Inserta(objPromocionValeDescuento);
                    else
                        objBL_PromocionValeDescuento.Actualiza(objPromocionValeDescuento);

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
                strMensaje = strMensaje + "- Ingrese Descripción.\n";
                flag = true;
            }

            if (txtImporte.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Importe de Vale.\n";
                flag = true;
            }

            //if (Convert.ToDecimal(txtImporte.Text.Trim().ToString()) == 0)
            //{
            //    strMensaje = strMensaje + "- Ingrese Importe de Vale.\n";
            //    flag = true;
            //}

            if(Convert.ToDecimal(txtImporte.EditValue)>0 && Convert.ToDecimal(txtDescuentoAdicional.EditValue)>0)
            {
                strMensaje = strMensaje + "- Debe ingresar Descuento Adicional o Importe(No se acepta ambos).\n";
                flag = true;
            }


            if (deDesde.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha.\n";
                flag = true;
            }

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstPromocionValeDescuento.Where(oB => oB.IdTienda == Convert.ToInt32(cboTienda.EditValue) && oB.DescPromocionValeDescuento == Convert.ToString(txtPromocionValeDescuento.EditValue)).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- El vale ya existe.\n";
            //        flag = true;
            //    }
            //}

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