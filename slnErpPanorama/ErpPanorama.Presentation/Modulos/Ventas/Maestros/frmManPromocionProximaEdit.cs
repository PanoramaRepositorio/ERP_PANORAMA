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
    public partial class frmManPromocionProximaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PromocionProximaBE> lstPromocionProxima;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PromocionProximaBE pPromocionProximaBE { get; set; }

        int _IdPromocionProxima = 0;

        public int IdPromocionProxima
        {
            get { return _IdPromocionProxima; }
            set { _IdPromocionProxima = value; }
        }

        #endregion

        #region "Eventos"
        public frmManPromocionProximaEdit()
        {
            InitializeComponent();
        }

        private void frmManPromocionProximaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Promoción Próxima Compra - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Promoción Próxima Compra - Modificar";
                txtDescripcion.Text = pPromocionProximaBE.Descripcion;
                cboEmpresa.EditValue = pPromocionProximaBE.IdEmpresa;
                cboFormaPago.EditValue = pPromocionProximaBE.IdFormaPago;
                cboTipoCliente.EditValue = pPromocionProximaBE.IdTipoCliente;
                cboTienda.EditValue = pPromocionProximaBE.IdTienda;
                deDesde.EditValue = pPromocionProximaBE.FechaInicio;
                deHasta.EditValue = pPromocionProximaBE.FechaFin;
                txtMontoMin.EditValue = pPromocionProximaBE.MontoMin;
                txtMontoMax.EditValue = pPromocionProximaBE.MontoMax;
                deFechaDesde.EditValue = pPromocionProximaBE.FechaDesde;
                deFechaHasta.EditValue = pPromocionProximaBE.FechaHasta;
                txtDescuento.EditValue = pPromocionProximaBE.Descuento;
                txtMensaje.EditValue = pPromocionProximaBE.Mensaje;
                txtObservacion.Text = pPromocionProximaBE.Observacion;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PromocionProximaBL objBL_PromocionProxima = new PromocionProximaBL();
                    PromocionProximaBE objPromocionProxima = new PromocionProximaBE();
                    objPromocionProxima.IdPromocionProxima = IdPromocionProxima;
                    objPromocionProxima.Descripcion = txtDescripcion.Text;
                    objPromocionProxima.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPromocionProxima.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objPromocionProxima.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objPromocionProxima.FechaInicio = Convert.ToDateTime(deDesde.DateTime.ToShortDateString());
                    objPromocionProxima.FechaFin = Convert.ToDateTime(deHasta.DateTime.ToShortDateString());
                    objPromocionProxima.MontoMin = Convert.ToDecimal(txtMontoMin.EditValue);
                    objPromocionProxima.MontoMax = Convert.ToDecimal(txtMontoMax.EditValue);
                    objPromocionProxima.FechaDesde = Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString());
                    objPromocionProxima.FechaHasta = Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString());
                    objPromocionProxima.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objPromocionProxima.Mensaje = txtMensaje.Text;
                    objPromocionProxima.Observacion = txtObservacion.Text.Trim();
                    objPromocionProxima.FlagEstado = true;
                    objPromocionProxima.Usuario = Parametros.strUsuarioLogin;
                    objPromocionProxima.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocionProxima.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_PromocionProxima.Inserta(objPromocionProxima);
                    else
                        objBL_PromocionProxima.Actualiza(objPromocionProxima);

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

            if (txtDescuento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Descuento.\n";
                flag = true;
            }

            if (deDesde.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha.\n";
                flag = true;
            }

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstPromocionProxima.Where(oB => oB.IdTienda == Convert.ToInt32(cboTienda.EditValue) && oB.DescPromocionProxima == Convert.ToString(txtPromocionProxima.EditValue)).ToList();
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