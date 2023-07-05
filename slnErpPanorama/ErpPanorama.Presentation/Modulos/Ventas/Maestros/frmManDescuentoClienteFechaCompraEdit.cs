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
    public partial class frmManDescuentoClienteFechaCompraEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<DescuentoClienteFechaCompraBE> lstDescuentoClienteFechaCompra;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DescuentoClienteFechaCompraBE pDescuentoClienteFechaCompraBE { get; set; }

        int _IdDescuentoClienteFechaCompra = 0;

        public int IdDescuentoClienteFechaCompra
        {
            get { return _IdDescuentoClienteFechaCompra; }
            set { _IdDescuentoClienteFechaCompra = value; }
        }

        #endregion

        #region "Eventos"

        public frmManDescuentoClienteFechaCompraEdit()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClienteFechaCompraEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteMayorista;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Descuento Cliente (Por Periodo) - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Descuento Cliente (Por Periodo) - Modificar";
                cboTipoCliente.EditValue = pDescuentoClienteFechaCompraBE.IdTipoCliente;
                cboFormaPago.EditValue = pDescuentoClienteFechaCompraBE.IdFormaPago;
                cboLineaProducto.EditValue = pDescuentoClienteFechaCompraBE.IdLineaProducto;
                deFechaDesde.EditValue = pDescuentoClienteFechaCompraBE.FechaInicio;
                deFechaHasta.EditValue = pDescuentoClienteFechaCompraBE.FechaFin;
                txtDescuento.EditValue = pDescuentoClienteFechaCompraBE.Descuento;
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
                    DescuentoClienteFechaCompraBE objDescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBE();
                    DescuentoClienteFechaCompraBL objBL_DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBL();

                    objDescuentoClienteFechaCompra.IdDescuentoClienteFechaCompra = IdDescuentoClienteFechaCompra;
                    objDescuentoClienteFechaCompra.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objDescuentoClienteFechaCompra.IdLineaProducto = Convert.ToInt32(cboLineaProducto.EditValue);
                    objDescuentoClienteFechaCompra.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDescuentoClienteFechaCompra.FechaInicio = Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString());
                    objDescuentoClienteFechaCompra.FechaFin = Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString());
                    objDescuentoClienteFechaCompra.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objDescuentoClienteFechaCompra.FlagEstado = true;
                    objDescuentoClienteFechaCompra.Usuario = Parametros.strUsuarioLogin;
                    objDescuentoClienteFechaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDescuentoClienteFechaCompra.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_DescuentoClienteFechaCompra.Inserta(objDescuentoClienteFechaCompra);
                    else
                        objBL_DescuentoClienteFechaCompra.Actualiza(objDescuentoClienteFechaCompra);

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
            if (deFechaDesde.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese fecha mínimo.\n";
                flag = true;
            }

            if (deFechaHasta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese fecha máximo.\n";
                flag = true;
            }


            if (txtDescuento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese porcentaje descuento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDescuentoClienteFechaCompra.Where(oB => oB.IdFormaPago == Convert.ToInt32(cboFormaPago.EditValue) && oB.IdLineaProducto == Convert.ToInt32(cboLineaProducto.EditValue) && oB.FechaInicio == Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()) && oB.FechaFin == Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()) && oB.Descuento == Convert.ToDecimal(txtDescuento.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Rango de Periodo ya existe.\n";
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