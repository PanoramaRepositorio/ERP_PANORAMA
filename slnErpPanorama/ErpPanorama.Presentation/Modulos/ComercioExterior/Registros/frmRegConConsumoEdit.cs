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
using ErpPanorama.Presentation.Modulos.Contabilidad.Consultas;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmRegConConsumoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ConConsumoBE> lstConConsumo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ConConsumoBE pConConsumoBE { get; set; }

        int _IdConConsumo = 0;

        public int IdConConsumo
        {
            get { return _IdConConsumo; }
            set { _IdConConsumo = value; }
        }

        private int IdProveedor = 0;
        private int? IdConsumoReferencia;
        #endregion

        #region "Eventos"

        public frmRegConConsumoEdit()
        {
            InitializeComponent();
        }

        private void frmRegConConsumoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTipoDocumento, new ConTipoComprobantePagoBL().ListaTodosActivo(), "DescTipoComprobantePago", "IdConTipoComprobantePago", true);
            BSUtils.LoaderLook(cboTipoDocumentoReferencia, new ConTipoComprobantePagoBL().ListaTodosActivo(), "DescTipoComprobantePago", "IdConTipoComprobantePago", true);
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescArea", "IdArea", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Gastos - Nuevo";
                //txtConConsumo.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Gastos - Modificar";

                ConConsumoBE objE_Consumo = new ConConsumoBE();
                objE_Consumo = new ConConsumoBL().Selecciona(IdConConsumo);


                cboEmpresa.EditValue = objE_Consumo.IdEmpresa;
                cboTienda.EditValue = objE_Consumo.IdTienda;
                txtPeriodo.EditValue = objE_Consumo.Periodo;
                cboArea.EditValue = objE_Consumo.IdArea;
                
                deFecha.EditValue = objE_Consumo.Fecha;
                deFechaVencimiento.EditValue = objE_Consumo.FechaVencimiento;
                cboTipoDocumento.EditValue = objE_Consumo.IdConTipoComprobantePago;
                txtCodigoTipoDocumento.EditValue = objE_Consumo.IdConTipoComprobantePago;
                txtSerie.Text = objE_Consumo.Serie;
                txtNumero.Text = objE_Consumo.Numero;
                txtPeriodoDua.EditValue = objE_Consumo.PeriodoDua;
                txtNumeroInicial.Text = objE_Consumo.NumeroInicial;
                IdProveedor = objE_Consumo.IdProveedor;
                txtNumeroDocumento.Text = objE_Consumo.NumeroDocumento;
                txtDescProveedor.Text = objE_Consumo.DescProveedor;
                txtNumeroCuenta.EditValue = objE_Consumo.IdConPlanContable;
                txtDescPlanContable.Text = objE_Consumo.DescConPlanContable;
                txtBaseImponible.EditValue = objE_Consumo.BaseImponible;
                txtIgv.EditValue = objE_Consumo.Igv;
                txtBaseImponible2.EditValue = objE_Consumo.BaseImponible2;
                txtIgv2.EditValue = objE_Consumo.Igv2;
                txtBaseImponibleSCF.EditValue = objE_Consumo.BaseImponibleSCF;
                txtIgvSCF.EditValue = objE_Consumo.IgvSCF;
                txtImporteANG.EditValue = objE_Consumo.ImporteANG;
                txtISC.EditValue = objE_Consumo.Isc;
                txtOtroCargo.EditValue = objE_Consumo.OtroCargo;
                txtTotal.EditValue = objE_Consumo.Importe;
                txtTipoCambio.EditValue = objE_Consumo.TipoCambio;
                txtTotalDolares.EditValue = objE_Consumo.ImporteDolares;
                if (objE_Consumo.IdConsumoReferencia != null) IdConsumoReferencia = objE_Consumo.IdConsumoReferencia;
                txtCda.Text = objE_Consumo.Cda;
                deFechaDeposito.EditValue = objE_Consumo.FechaDeposito;
                txtNumeroDeposito.Text = objE_Consumo.NumeroDeposito;
                chkRetencion.Checked = objE_Consumo.FlagRetencion;
                txtEstado.EditValue = objE_Consumo.IdEstado;

                txtNumeroReferencia.Text = objE_Consumo.NumeroReferencia;
                cboTipoDocumentoReferencia.EditValue = objE_Consumo.IdConTipoComprobantePagoReferencia;
                txtSerieReferencia.EditValue = objE_Consumo.SerieReferencia;
            }

            cboTienda.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ConConsumoBL objBL_ConConsumo = new ConConsumoBL();
                    ConConsumoBE objConConsumo = new ConConsumoBE();

                    objConConsumo.IdConConsumo = IdConConsumo;
                    objConConsumo.IdEmpresa = Parametros.intEmpresaId;
                    objConConsumo.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objConConsumo.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objConConsumo.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objConConsumo.Cuo = "";
                    objConConsumo.NumeroCuo = "";
                    objConConsumo.Fecha = deFecha.DateTime;
                    if (deFechaVencimiento.Text == "") objConConsumo.FechaVencimiento = null; else objConConsumo.FechaVencimiento = deFechaVencimiento.DateTime;

                    objConConsumo.IdConTipoComprobantePago = cboTipoDocumento.EditValue.ToString();
                    objConConsumo.Serie = txtSerie.Text;
                    //objConConsumo.PeriodoDua = Convert.ToInt32(txtPeriodoDua.EditValue);
                    if (txtPeriodoDua.Text == "") objConConsumo.PeriodoDua = null; else objConConsumo.PeriodoDua = Convert.ToInt32(txtPeriodoDua.EditValue);
                    objConConsumo.Numero = txtNumero.Text;
                    objConConsumo.NumeroInicial = txtNumeroInicial.Text;
                    objConConsumo.IdProveedor = IdProveedor;
                    objConConsumo.NumeroDocumento = txtNumeroDocumento.Text;
                    objConConsumo.DescProveedor = txtDescProveedor.Text;
                    objConConsumo.IdConPlanContable = Convert.ToInt32(txtNumeroCuenta.EditValue);
                    objConConsumo.BaseImponible = Convert.ToDecimal(txtBaseImponible.EditValue);
                    objConConsumo.Igv = Convert.ToDecimal(txtIgv.EditValue);
                    objConConsumo.BaseImponible2 = Convert.ToDecimal(txtBaseImponible2.EditValue);
                    objConConsumo.Igv2 = Convert.ToDecimal(txtIgv2.EditValue);
                    objConConsumo.BaseImponibleSCF = Convert.ToDecimal(txtBaseImponibleSCF.EditValue);
                    objConConsumo.IgvSCF = Convert.ToDecimal(txtIgvSCF.EditValue);
                    objConConsumo.ImporteANG = Convert.ToDecimal(txtImporteANG.EditValue);
                    objConConsumo.Isc = Convert.ToDecimal(txtISC.EditValue);
                    objConConsumo.OtroCargo = Convert.ToDecimal(txtOtroCargo.EditValue);
                    objConConsumo.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objConConsumo.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objConConsumo.ImporteDolares = Convert.ToDecimal(txtTotalDolares.EditValue);
                    objConConsumo.IdConsumoReferencia = IdConsumoReferencia;
                    objConConsumo.Cda = txtCda.Text;
                    if (deFechaDeposito.Text == "") objConConsumo.FechaDeposito = null; else objConConsumo.FechaDeposito = deFechaDeposito.DateTime;
                    //objConConsumo.FechaDeposito = Convert.ToDateTime(deFechaDeposito.EditValue);
                    objConConsumo.NumeroDeposito = txtNumeroDeposito.Text;
                    objConConsumo.FlagRetencion = chkRetencion.Checked;
                    objConConsumo.IdEstado = Convert.ToInt32(txtEstado.EditValue);
                    objConConsumo.FlagEstado = true;
                    objConConsumo.Usuario = Parametros.strUsuarioLogin;
                    objConConsumo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    //objConConsumo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ConConsumo.Inserta(objConConsumo);
                    else
                        objBL_ConConsumo.Actualiza(objConConsumo);

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

        private void btnBuscarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                frmConPlanContable frm = new frmConPlanContable();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    txtNumeroCuenta.EditValue = frm._Be.IdConPlanContable;
                    txtDescPlanContable.EditValue = frm._Be.Descripcion;
                    txtBaseImponible.Select();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConProveedor frm = new frmConProveedor();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    txtNumeroDocumento.Text = frm._Be.NumeroDocumento;
                    txtDescProveedor.Text = frm._Be.DescProveedor;
                    IdProveedor = frm._Be.IdProveedor;
                    txtNumeroCuenta.Select();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumeroCuenta.Text.Trim().Length > 0)
                {
                    ConPlanContableBE objE_PlanContable = new ConPlanContableBE();
                    objE_PlanContable = new ConPlanContableBL().Selecciona(Convert.ToInt32(txtNumeroCuenta.EditValue));
                    if (objE_PlanContable != null)
                    {
                        txtNumeroCuenta.EditValue = objE_PlanContable.IdConPlanContable;
                        txtDescPlanContable.EditValue = objE_PlanContable.Descripcion;
                        txtBaseImponible.Select();
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de cuenta no existe, por favor verifique!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cboTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                cboEmpresa.Focus();
                //e.Handled = true;
                //SendKeys.Send("{TAB}");
            }
        }

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void deFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCodigoTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                cboTipoDocumento.EditValue = txtCodigoTipoDocumento.Text;

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtCodigoTipoDocumento.Text = cboTipoDocumento.EditValue.ToString();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPeriodoDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void txtDescProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnNuevoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTipoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDescPlanContable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBaseImponible2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtIgv2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBaseImponibleSCF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtIgvSCF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporteANG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtISC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtOtroCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTotalDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void chkRetencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCodigoTipoDocumentoReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                cboTipoDocumentoReferencia.EditValue = txtCodigoTipoDocumentoReferencia.Text;

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoDocumentoReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtCodigoTipoDocumentoReferencia.Text = cboTipoDocumentoReferencia.EditValue.ToString();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSerieReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {

                ConConsumoBE objE_Consumo = new ConConsumoBE();
                objE_Consumo = new ConConsumoBL().SeleccionaNumero(cboTipoDocumentoReferencia.EditValue.ToString(), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());


                cboEmpresa.EditValue = objE_Consumo.IdEmpresa;
                cboTienda.EditValue = objE_Consumo.IdTienda;
                txtPeriodo.EditValue = objE_Consumo.Periodo;
                cboArea.EditValue = objE_Consumo.IdArea;

                deFecha.EditValue = objE_Consumo.Fecha;
                deFechaVencimiento.EditValue = objE_Consumo.FechaVencimiento;
                cboTipoDocumento.EditValue = objE_Consumo.IdConTipoComprobantePago;
                txtCodigoTipoDocumento.EditValue = objE_Consumo.IdConTipoComprobantePago;
                txtSerie.Text = objE_Consumo.Serie;
                txtNumero.Text = objE_Consumo.Numero;
                txtPeriodoDua.EditValue = objE_Consumo.PeriodoDua;
                txtNumeroInicial.Text = objE_Consumo.NumeroInicial;
                IdProveedor = objE_Consumo.IdProveedor;
                txtNumeroDocumento.Text = objE_Consumo.NumeroDocumento;
                txtDescProveedor.Text = objE_Consumo.DescProveedor;
                txtNumeroCuenta.EditValue = objE_Consumo.IdConPlanContable;
                txtDescPlanContable.Text = objE_Consumo.DescConPlanContable;
                txtBaseImponible.EditValue = objE_Consumo.BaseImponible;
                txtIgv.EditValue = objE_Consumo.Igv;
                txtBaseImponible2.EditValue = objE_Consumo.BaseImponible2;
                txtIgv2.EditValue = objE_Consumo.Igv2;
                txtBaseImponibleSCF.EditValue = objE_Consumo.BaseImponibleSCF;
                txtIgvSCF.EditValue = objE_Consumo.IgvSCF;
                txtImporteANG.EditValue = objE_Consumo.ImporteANG;
                txtISC.EditValue = objE_Consumo.Isc;
                txtOtroCargo.EditValue = objE_Consumo.OtroCargo;
                txtTotal.EditValue = objE_Consumo.Importe;
                txtTipoCambio.EditValue = objE_Consumo.TipoCambio;
                txtTotalDolares.EditValue = objE_Consumo.ImporteDolares;
                IdConsumoReferencia = objE_Consumo.IdConConsumo;
                txtCda.Text = objE_Consumo.Cda;
                deFechaDeposito.EditValue = objE_Consumo.FechaDeposito;
                txtNumeroDeposito.Text = objE_Consumo.NumeroDeposito;
                chkRetencion.Checked = objE_Consumo.FlagRetencion;
                txtEstado.EditValue = objE_Consumo.IdEstado;

                deFecha.Select();
                //e.Handled = true;
                //SendKeys.Send("{TAB}");
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            //frmManProveedorEdit objManProveedor = new frmManProveedorEdit();
            //objManProveedor.lstProveedor = Parametros.pListaProveedores;
            //objManProveedor.pOperacion = frmManProveedorEdit.Operacion.Nuevo;
            //objManProveedor.IdProveedor = 0;
            //objManProveedor.StartPosition = FormStartPosition.CenterParent;
            //objManProveedor.ShowDialog();

            //BSUtils.LoaderLook(cboProveedor, new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId), "DescProveedor", "IdProveedor", false);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumeroDocumento.Text.Trim().Length > 5)
                {
                    ProveedorBE objE_Proveedor = new ProveedorBE();
                    objE_Proveedor = new ProveedorBL().SeleccionaNumero(txtNumeroDocumento.Text.Trim());
                    if (objE_Proveedor != null)
                    {
                        txtNumeroDocumento.Text = objE_Proveedor.NumeroDocumento;
                        txtDescProveedor.Text = objE_Proveedor.DescProveedor;
                        IdProveedor = objE_Proveedor.IdProveedor;
                        txtNumeroCuenta.Select();
                    }
                    else
                    {
                        XtraMessageBox.Show("El RUC no existe en la Base de Datos, Desea agregar como Nuevo Proveedor?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            //string strMensaje = "No se pudo registrar:\n";

            //if (txtConConsumo.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese linea de producto.\n";
            //    flag = true;
            //}

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstConConsumo.Where(oB => oB.DescConConsumo.ToUpper() == txtConConsumo.Text.ToUpper()).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- El ConConsumo ya existe.\n";
            //        flag = true;
            //    }
            //}

            //if (flag)
            //{
            //    XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Cursor = Cursors.Default;
            //}
            return flag;
        }

        #endregion
    }
}