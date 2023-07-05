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

namespace ErpPanorama.Presentation.Modulos.Finanzas.Maestros
{
    public partial class frmManProductoBancoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<BancoProductoBE> lstBancoProducto;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdBanco = 0;

        int _IdBancoProducto = 0;

        public int IdBancoProducto
        {
            get { return _IdBancoProducto; }
            set { _IdBancoProducto = value; }
        }

        #endregion

        #region "Eventos"

        public frmManProductoBancoEdit()
        {
            InitializeComponent();
        }

        private void frmManProductoBancoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoProducto, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPrestamo), "DescTablaElemento", "IdTablaElemento", true);

            cboMoneda.EditValue = Parametros.intSoles;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Banco Producto - Nuevo";
                cboBanco.EditValue = IdBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Banco Producto - Modificar";

                BancoProductoBE objE_BancoProducto = null;
                objE_BancoProducto = new BancoProductoBL().Selecciona(IdBancoProducto);

                cboBanco.EditValue = objE_BancoProducto.IdBanco;
                cboTipoProducto.EditValue = objE_BancoProducto.IdTipoProducto;
                cboMoneda.EditValue = objE_BancoProducto.IdMoneda;
                txtLineaCredito.EditValue = objE_BancoProducto.LineaCredito;
                txtMontoUtilizado.EditValue = objE_BancoProducto.MontoUtilizado;
                txtMontoDisponible.EditValue = objE_BancoProducto.Disponible;
            }

            cboBanco.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    BancoProductoBL objBL_BancoProducto = new BancoProductoBL();
                    BancoProductoBE objBancoProducto = new BancoProductoBE();

                    objBancoProducto.IdBancoProducto = IdBancoProducto;
                    objBancoProducto.IdBanco = Convert.ToInt32(cboBanco.EditValue);
                    objBancoProducto.IdTipoProducto = Convert.ToInt32(cboTipoProducto.EditValue);
                    objBancoProducto.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objBancoProducto.LineaCredito = Convert.ToDecimal(txtLineaCredito.EditValue);
                    objBancoProducto.MontoUtilizado = Convert.ToDecimal(txtMontoUtilizado.EditValue);
                    objBancoProducto.Disponible = Convert.ToDecimal(txtMontoDisponible.EditValue);
                    objBancoProducto.FlagEstado = true;
                    objBancoProducto.Usuario = Parametros.strUsuarioLogin;
                    objBancoProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objBancoProducto.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_BancoProducto.Inserta(objBancoProducto);
                    else
                        objBL_BancoProducto.Actualiza(objBancoProducto);

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

            if (cboBanco.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el banco.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de moneda.\n";
                flag = true;
            }

            if (cboTipoProducto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de cuenta.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstBancoProducto.Where(oB => oB.IdBanco == Convert.ToInt32(cboBanco.EditValue) && oB.IdMoneda == Convert.ToInt32(cboMoneda.EditValue) && oB.IdTipoProducto == Convert.ToInt32(cboTipoProducto.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La línea de crédito ya existe.\n";
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