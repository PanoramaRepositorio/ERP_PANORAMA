using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManPersonaCuentaBancariaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public PersonaCuentaBancariaBE oBE;

        public int IdPersona = 0;
        public int IdPersonaCuentaBancaria = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        #endregion

        #region "Eventos"

        public frmManPersonaCuentaBancariaEdit()
        {
            InitializeComponent();
        }

        private void frmManPersonaCuentaBancaria_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboTipoCuenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCuentaBanco), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCuenta.EditValue = 286;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cuenta Banco - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cuenta Banco - Modificar";

                PersonaCuentaBancariaBE objE_PersonaCuentaBancaria = null;
                objE_PersonaCuentaBancaria = new PersonaCuentaBancariaBL().Selecciona(IdPersonaCuentaBancaria);

                cboBanco.EditValue = objE_PersonaCuentaBancaria.IdBanco;
                cboMoneda.EditValue = objE_PersonaCuentaBancaria.IdMoneda;
                cboTipoCuenta.EditValue = objE_PersonaCuentaBancaria.IdTipoCuenta;
                txtNumeroCuenta.Text = objE_PersonaCuentaBancaria.NumeroCuenta;
                txtObservacion.Text = objE_PersonaCuentaBancaria.Observacion;
                chkdefault.Checked = objE_PersonaCuentaBancaria.FlagEstado;


            }

            txtNumeroCuenta.Select();
            //cboBanco.Select();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroCuenta.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el numero de Cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumeroCuenta.SelectAll();
                    txtNumeroCuenta.Focus();
                    return;
                }

                oBE = new PersonaCuentaBancariaBE();
                oBE.IdPersona = IdPersona;
                oBE.IdPersonaCuentaBancaria = IdPersonaCuentaBancaria;
                oBE.IdBanco = Convert.ToInt32(cboBanco.EditValue);
                oBE.DescBanco = cboBanco.Text;
                oBE.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                oBE.DescMoneda = cboMoneda.Text;
                oBE.NumeroCuenta = txtNumeroCuenta.Text.Trim();
                oBE.IdTipoCuenta = Convert.ToInt32(cboTipoCuenta.EditValue);
                oBE.DescTipoCuenta = cboTipoCuenta.Text;
                oBE.Observacion = txtObservacion.Text.Trim();
                oBE.FlagEstado = chkdefault.Checked;
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion

        private void cboBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboMoneda.Focus();
            }
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboTipoCuenta.Focus();
            }
        }

        private void cboTipoCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtNumeroCuenta.Focus();
            }
        }

        private void txtNumeroCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtObservacion.Focus();
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnAceptar.Focus();
            }
        }


        #region "Propiedades"

        #endregion


    }
}