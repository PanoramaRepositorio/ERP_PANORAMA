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

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegCuentaBancoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CuentaBancoDetalleBE> lstCuentaBancoDetalle;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdCuentaBanco = 0;
        public int IdBanco = 0;
        public int IdTipoCuenta = 0;
        public int IdMoneda = 0;
        public int? IdTienda = 0;
        public int? IdCliente = 0;

        int _IdCuentaBancoDetalle = 0;

        public int IdCuentaBancoDetalle
        {
            get { return _IdCuentaBancoDetalle; }
            set { _IdCuentaBancoDetalle = value; }
        }

        public CuentaBancoBE obE_Banco;
        private bool bCambiar = true;

        #endregion

        #region "Eventos"

        public frmRegCuentaBancoEdit()
        {
            InitializeComponent();
        }

        private void frmRegCuentaBancoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoCuenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCuentaBanco), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboCuentaCausal, new CuentaBancoDetalleCausalBL().ListaTodosActivo("C"), "Descripcion", "IdCuentaBancoDetalleCausal", true);
            cboCuentaCausal.EditValue = 0;

            cboBanco.EditValue = IdBanco;
            cboTipoCuenta.EditValue = IdTipoCuenta;
            cboMoneda.EditValue = IdMoneda;
            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cuenta Banco - Nuevo";
                //cboBanco.EditValue = IdCuentaBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cuenta Banco - Modificar";

                CuentaBancoDetalleBE objE_CuentaBanco = null;
                objE_CuentaBanco = new CuentaBancoDetalleBL().Selecciona(IdCuentaBancoDetalle);

                if (objE_CuentaBanco.TipoMovimiento == "C")
                    optCargo.Checked = true;
                else
                    optAbono.Checked = true;

                //cboBanco.EditValue = objE_CuentaBanco.IdBanco;
                //cboMoneda.EditValue = objE_CuentaBanco.IdMoneda;
                //cboTipoCuenta.EditValue = objE_CuentaBanco.TIPO;
                txtNumeroMovimiento.EditValue = objE_CuentaBanco.NumeroMovimiento;
                deFecha.EditValue = objE_CuentaBanco.Fecha;
                txtConcepto.EditValue = objE_CuentaBanco.Concepto;
                txtImporte.EditValue = objE_CuentaBanco.Importe;
                txtITF.EditValue = objE_CuentaBanco.ITF;
                cboCuentaCausal.EditValue = objE_CuentaBanco.IdCuentaBancoDetalleCausal;
                cboCuentaConcepto.EditValue = objE_CuentaBanco.IdCuentaBancoDetalleConcepto;
                IdCliente = objE_CuentaBanco.IdCliente;
                IdTienda = objE_CuentaBanco.IdTienda;
                txtObservacion.EditValue = objE_CuentaBanco.Observacion;
                deFechaCuadre.EditValue = objE_CuentaBanco.FechaCuadre;

                //Bloqueos
                if (objE_CuentaBanco.IdCuentaBancoDetalleCausal == 4 || objE_CuentaBanco.IdCuentaBancoDetalleCausal == 5 || objE_CuentaBanco.IdCuentaBancoDetalleCausal == 6 || objE_CuentaBanco.IdCuentaBancoDetalleCausal == 7 || objE_CuentaBanco.IdCuentaBancoDetalleCausal == 8)
                {
                    Deshabilitar();
                }

                if (IdCliente > 0)
                {
                    Deshabilitar();
                }
  
            }

            txtNumeroMovimiento.Select();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CuentaBancoDetalleBL objBL_CuentaBancoDetalle = new CuentaBancoDetalleBL();
                    CuentaBancoDetalleBE objCuentaBancoDetalle = new CuentaBancoDetalleBE();

                    objCuentaBancoDetalle.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
                    objCuentaBancoDetalle.IdCuentaBanco = IdCuentaBanco;
                    //objCuentaBancoDetalle.IdBanco = Convert.ToInt32(cboBanco.EditValue);
                    //objCuentaBancoDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objCuentaBancoDetalle.NumeroMovimiento = txtNumeroMovimiento.Text;
                    objCuentaBancoDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCuentaBancoDetalle.Concepto = txtConcepto.Text.Trim();
                    objCuentaBancoDetalle.ITF = Convert.ToDecimal(txtITF.EditValue);
                    objCuentaBancoDetalle.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objCuentaBancoDetalle.IdCuentaBancoDetalleConcepto = Convert.ToInt32(cboCuentaConcepto.EditValue);
                    objCuentaBancoDetalle.IdCuentaBancoDetalleCausal = Convert.ToInt32(cboCuentaCausal.EditValue);
                    objCuentaBancoDetalle.IdCliente = IdCliente;
                    objCuentaBancoDetalle.IdTienda = IdTienda;
                    objCuentaBancoDetalle.FechaCuadre = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCuentaBancoDetalle.Observacion = txtObservacion.Text.Trim();
                    if (optCargo.Checked)
                        objCuentaBancoDetalle.TipoMovimiento = "C";
                    else
                        objCuentaBancoDetalle.TipoMovimiento = "A";
                    objCuentaBancoDetalle.FlagEstado = true;
                    objCuentaBancoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objCuentaBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCuentaBancoDetalle.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CuentaBancoDetalle.Inserta(objCuentaBancoDetalle);
                    else
                        objBL_CuentaBancoDetalle.Actualiza(objCuentaBancoDetalle);

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

        private void txtNumeroMovimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtITF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void optCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtObservacion.Select();
            }
        }

        private void optAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtObservacion.Select();
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnGrabar.Select();
            }
        }

        private void optCargo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCargo.Checked)
            {
                BSUtils.LoaderLook(cboCuentaCausal, new CuentaBancoDetalleCausalBL().ListaTodosActivo("C"), "Descripcion", "IdCuentaBancoDetalleCausal", true);
            }
        }

        private void optAbono_CheckedChanged(object sender, EventArgs e)
        {
            if (optAbono.Checked)
            {
                BSUtils.LoaderLook(cboCuentaCausal, new CuentaBancoDetalleCausalBL().ListaTodosActivo("A"), "Descripcion", "IdCuentaBancoDetalleCausal", true);
            }
        }

        private void cboCuentaCausal_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCuentaCausal.Text != "")
            {
                BSUtils.LoaderLook(cboCuentaConcepto, new CuentaBancoDetalleConceptoBL().ListaTodosActivo(Convert.ToInt32(cboCuentaCausal.EditValue)), "Descripcion", "IdCuentaBancoDetalleConcepto", true);
            }
            else
            {
                cboCuentaConcepto.EditValue = 0;
            }
        }

        private void cboCuentaConcepto_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (Convert.ToInt32(cboCuentaCausal.EditValue) == 4)
                {
                    deFechaCuadre.EditValue = DateTime.Now;
                    deFechaCuadre.Visible = true;
                    lblCuadre.Visible = true;
                    this.Size = new Size(583, 345);

                    CuentaBancoDetalleConceptoBE objCuenta = new CuentaBancoDetalleConceptoBE();
                    objCuenta = new CuentaBancoDetalleConceptoBL().Selecciona(Convert.ToInt32(cboCuentaConcepto.EditValue));
                    txtConcepto.Text = cboCuentaCausal.Text + " - " + cboCuentaConcepto.Text + " - " + deFechaCuadre.Text;
                    IdTienda = objCuenta.IdTienda;
                }
                else if (Convert.ToInt32(cboCuentaCausal.EditValue) == 8)
                {
                    deFechaCuadre.Visible = false;
                    lblCuadre.Visible = false;
                    deFechaCuadre.Text = "";
                    this.Size = new Size(518, 345);

                    CuentaBancoDetalleConceptoBE objCuenta = new CuentaBancoDetalleConceptoBE();
                    objCuenta = new CuentaBancoDetalleConceptoBL().Selecciona(Convert.ToInt32(cboCuentaConcepto.EditValue));
                    IdTienda = objCuenta.IdTienda;
                    txtConcepto.Text = cboCuentaCausal.Text + " - " + cboCuentaConcepto.Text + " - " + objCuenta.DescTienda;

                }
                else
                {

                    deFechaCuadre.Text = "";
                    lblCuadre.Visible = false;
                    deFechaCuadre.EditValue = null;
                    txtConcepto.Text = cboCuentaCausal.Text + " - " + cboCuentaConcepto.Text;
                    this.Size = new Size(518, 345);
                    IdTienda = 0;
                }


                txtConcepto.Focus();
            }
        }

        private void deFechaCuadre_EditValueChanged(object sender, EventArgs e)
        {
            if (bCambiar)
            {
                txtConcepto.Text = cboCuentaCausal.Text + " - " + cboCuentaConcepto.Text + " - " + deFechaCuadre.Text;
            }
            
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

            //if (txtNumeroMovimiento.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese numero de cuenta.\n";
            //    flag = true;
            //}

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

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstCuentaBancoDetalle.Where(oB => oB.NumeroMovimiento == txtNumeroMovimiento.Text.Trim()&& oB.IdCuentaBanco == IdCuentaBanco).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- El número de Movimiento ya existe.\n";
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


        private void Deshabilitar()
        {
            //if (/*Parametros.intPerfilId != Parametros.intPerAdministrador*/ Parametros.strUsuarioLogin!="master")
            //{
                deFecha.Properties.ReadOnly = true;
                optCargo.Enabled = false;
                optAbono.Enabled = false;
                cboCuentaCausal.Properties.ReadOnly = true;
                cboCuentaConcepto.Properties.ReadOnly = true;
                deFecha.Properties.ReadOnly = true;
                txtConcepto.Properties.ReadOnly = true;
                txtNumeroMovimiento.Properties.ReadOnly = true;
                txtImporte.Properties.ReadOnly = true;
                bCambiar = false;
            //}

        }
        #endregion



    }
}