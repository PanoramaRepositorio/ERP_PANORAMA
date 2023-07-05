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
    public partial class frmManDescuentoFechaCompraEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<DescuentoFechaCompraBE> lstDescuentoFechaCompra;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DescuentoFechaCompraBE pDescuentoFechaCompraBE { get; set; }

        int _IdDescuentoFechaCompra = 0;

        public int IdDescuentoFechaCompra
        {
            get { return _IdDescuentoFechaCompra; }
            set { _IdDescuentoFechaCompra = value; }
        }

        #endregion

        #region "Eventos"

        public frmManDescuentoFechaCompraEdit()
        {
            InitializeComponent();
        }

        private void frmManDescuentoFechaCompraEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Descuento Fecha Compra - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Descuento Fecha Compra - Modificar";
                cboLineaProducto.EditValue = pDescuentoFechaCompraBE.IdLineaProducto;
                deFechaDesde.EditValue = pDescuentoFechaCompraBE.FechaInicio;
                deFechaHasta.EditValue = pDescuentoFechaCompraBE.FechaFin;
                txtDescuento.EditValue = pDescuentoFechaCompraBE.Descuento;
            }

            cboLineaProducto.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    DescuentoFechaCompraBE objDescuentoFechaCompra = new DescuentoFechaCompraBE();
                    DescuentoFechaCompraBL objBL_DescuentoFechaCompra = new DescuentoFechaCompraBL();

                    objDescuentoFechaCompra.IdDescuentoFechaCompra = IdDescuentoFechaCompra;
                    objDescuentoFechaCompra.IdEmpresa = Parametros.intEmpresaId;
                    objDescuentoFechaCompra.IdLineaProducto = Convert.ToInt32(cboLineaProducto.EditValue);
                    objDescuentoFechaCompra.FechaInicio = Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString());
                    objDescuentoFechaCompra.FechaFin = Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString());
                    objDescuentoFechaCompra.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objDescuentoFechaCompra.FlagEstado = true;
                    objDescuentoFechaCompra.Usuario = Parametros.strUsuarioLogin;
                    objDescuentoFechaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDescuentoFechaCompra.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_DescuentoFechaCompra.Inserta(objDescuentoFechaCompra);
                    else
                        objBL_DescuentoFechaCompra.Actualiza(objDescuentoFechaCompra);

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
                strMensaje = strMensaje + "- Seleccionar Linea de Producto.\n";
                flag = true;
            }

            if (deFechaDesde.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha Inicio.\n";
                flag = true;
            }

            if (deFechaHasta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha Fin.\n";
                flag = true;
            }


            if (txtDescuento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese porcentaje descuento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDescuentoFechaCompra.Where(oB => oB.IdLineaProducto == Convert.ToInt32(cboLineaProducto.EditValue) && oB.FechaInicio == Convert.ToDateTime(deFechaDesde.EditValue) && oB.FechaFin == Convert.ToDateTime(deFechaHasta.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- Descuento ya existe en este periodo.\n";
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

        private void cboLineaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


    }
}