using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    public partial class frmProveedorCuenta : DevExpress.XtraEditors.XtraForm
    {
        public DetalleProveedorCuenta oBE;

        public int IdProveedor = 0;
        public int IdCuentaBancoProveedor = 0;
        public int IdBanco = 0;
        public int IdMoneda = 0;
        public int IdTipoCuenta = 0;
        public int Boton = 0;
        public frmProveedorCuenta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProveedorCuenta_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            cboBanco.EditValue = IdBanco;

            BSUtils.LoaderLook(cboTipoCuenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCuentaBanco), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCuenta.EditValue = IdTipoCuenta;

            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = IdMoneda;

            if (Boton == 1)
            {
                cboMoneda.EditValue = Parametros.intSoles;
            }
            else
            {
                cboMoneda.EditValue = IdMoneda;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCuenta.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingrese el numero de cuenta!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCuenta.SelectAll();
                    txtCuenta.Focus();
                    return;
                }

                oBE = new DetalleProveedorCuenta();

                oBE.IdCuentaBancoProveedor = IdCuentaBancoProveedor;
                oBE.IdProveedor = IdProveedor;
                oBE.IdBanco = Convert.ToInt32(cboBanco.EditValue);
                oBE.DescBanco =  cboBanco.Text.Trim();
                oBE.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                oBE.DescMoneda = cboMoneda.Text.Trim();
                oBE.Cuenta = txtCuenta.Text;
                oBE.cci = txtCCI.Text;
                oBE.IdTipoCuenta = Convert.ToInt32(cboTipoCuenta.EditValue);
                oBE.DescTipoCuenta = cboTipoCuenta.Text.Trim();

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == '-' || e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == '-' || e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}