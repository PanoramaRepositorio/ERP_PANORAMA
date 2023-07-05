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

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManCuentaBancoEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<CuentaBancoBE> lstCuentaBanco;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdBanco = 0;

        int _IdCuentaBanco = 0;

        public int IdCuentaBanco
        {
            get { return _IdCuentaBanco; }
            set { _IdCuentaBanco = value; }
        }

        #endregion

        #region "Eventos"

        public frmManCuentaBancoEdit()
        {
            InitializeComponent();
        }

        private void frmManCuentaBancoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoCuenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCuentaBanco), "DescTablaElemento", "IdTablaElemento", true);

            cboMoneda.EditValue = Parametros.intSoles;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "CuentaBanco - Nuevo";
                cboBanco.EditValue = IdBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "CuentaBanco - Modificar";

                CuentaBancoBE objE_CuentaBanco = null;
                objE_CuentaBanco = new CuentaBancoBL().Selecciona(IdCuentaBanco);

                cboBanco.EditValue = objE_CuentaBanco.IdBanco;
                txtNumeroCuenta.EditValue = objE_CuentaBanco.NumeroCuenta;
                cboMoneda.EditValue = objE_CuentaBanco.IdMoneda;
                cboTipoCuenta.EditValue = objE_CuentaBanco.IdTipoCuenta;
                txtTitular.EditValue = objE_CuentaBanco.Titular;
                txtOficina.EditValue = objE_CuentaBanco.Oficina;
                txtCCI.EditValue = objE_CuentaBanco.CCI;
                txtSaldo.EditValue = objE_CuentaBanco.SaldoDisponible;
                txtLineaCredito.EditValue = objE_CuentaBanco.LineaCredito;
            }

            cboBanco.Focus();
            //txtNumeroCuenta.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CuentaBancoBL objBL_CuentaBanco = new CuentaBancoBL();
                    CuentaBancoBE objCuentaBanco = new CuentaBancoBE();

                    objCuentaBanco.IdCuentaBanco = IdCuentaBanco;
                    objCuentaBanco.IdBanco = Convert.ToInt32(cboBanco.EditValue);
                    objCuentaBanco.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objCuentaBanco.NumeroCuenta = txtNumeroCuenta.Text.Trim();
                    objCuentaBanco.IdTipoCuenta = Convert.ToInt32(cboTipoCuenta.EditValue);
                    objCuentaBanco.Titular = txtTitular.Text.Trim();
                    objCuentaBanco.Oficina = txtOficina.Text.Trim();
                    objCuentaBanco.CCI = txtCCI.Text.Trim();
                    objCuentaBanco.SaldoDisponible = Convert.ToDecimal(txtSaldo.EditValue);
                    objCuentaBanco.LineaCredito = Convert.ToDecimal(txtLineaCredito.EditValue);
                    objCuentaBanco.FlagEstado = true;
                    objCuentaBanco.Usuario = Parametros.strUsuarioLogin;
                    objCuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCuentaBanco.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CuentaBanco.Inserta(objCuentaBanco);
                    else
                        objBL_CuentaBanco.Actualiza(objCuentaBanco);

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

            if (txtNumeroCuenta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese numero de cuenta.\n";
                flag = true;
            }

            if (txtNumeroCuenta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Nombre del Titular de cuenta.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de moneda.\n";
                flag = true;
            }

            if (cboTipoCuenta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de cuenta.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstCuentaBanco.Where(oB => oB.IdMoneda == Convert.ToInt32(cboMoneda.EditValue) && oB.NumeroCuenta == txtNumeroCuenta.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El número de cuenta ya existe.\n";
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


   