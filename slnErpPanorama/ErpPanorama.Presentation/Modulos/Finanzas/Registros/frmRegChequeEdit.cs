using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegChequeEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmRegChequeEdit()
        {
            InitializeComponent();
        }

        #region "Propiedades"

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public Operacion pOperacion;

        public ChequeBE pCheque { get; set; }

        int IdCheque_ = 0;
        public int IdCheque
        {
            get { return IdCheque_; }
            set { IdCheque_ = value; }
        }

        private int NumeroCorrelativo = 0;
        private int Empresa = 0, Banco = 0, Moneda = 0;
        private int IdEmpresa = 0;
        private int IdBanco = 0;
        private int IdMoneda = 0;
        private int IdMotivo = 0;
        private int IdSituacion = 0;
        private int IdPersona = Parametros.intUsuarioId;
        //private int IdChequeBanco = 0;
        private DateTime FechaRegistro = Parametros.dtFechaHoraServidor;

        decimal dmlTipoCambio = 0;

        #endregion

        #region "Eventos"

        private void frmRegChequeEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, CargarEmpresa(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            Empresa = Convert.ToInt32(cboEmpresa.EditValue);
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            cboBanco.EditValue = IdBanco;
            Banco = Convert.ToInt32(cboBanco.EditValue);

            //BSUtils.LoaderLook(cboMoneda, new ChequeBL().GetMoneda(Empresa, Banco), "DesMoneda", "IdMoneda", true);
            //cboMoneda.EditValue = IdMoneda;

            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;


            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMotivoCheque), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = IdMotivo;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nuevo Cheque";
                IdSituacion = Parametros.intChequeVigente;
                deFecEmision.EditValue = Parametros.dtFechaHoraServidor;
                // txtMonto.Text = pCheque.Monto.ToString();
                txtMonto.EditValue = String.Format("{0:#,##0.00}", 0);

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Editar Cheque";
                pCheque   = new ChequeBL().Consulta(IdCheque);

                IdCheque               = pCheque.IdCheque;
                txtCheque.Text         = pCheque.NumeroCheque;
                cboEmpresa.EditValue   = pCheque.IdEmpresa;
                cboBanco.EditValue     = pCheque.IdBanco;
                txtCheque.Text         = pCheque.NumeroCheque;
                deFecEmision.EditValue = pCheque.FechaEmision;
                txtPortador.Text       = pCheque.Portador;
                cboMoneda.EditValue    = pCheque.IdMoneda;
                txtMonto.Text          = String.Format("{0:#,##0.00}", pCheque.Monto);  //pCheque.Monto.ToString();
                cboMotivo.EditValue    = pCheque.IdMotivo;
                txtDestino.Text        = pCheque.Destino;
                txtObservacion.Text    = pCheque.Observacion;

                dmlTipoCambio = pCheque.TCambio;
                IdMoneda = pCheque.IdMoneda;
                IdSituacion = pCheque.IdSituacion;
                FechaRegistro = pCheque.FechaRegistro;
                IdPersona = pCheque.IdPersona;

                txtNroRecibo.EditValue = pCheque.NumRecibo;
                txtCajaChica.EditValue = pCheque.NumCajaChica;

                cboEmpresa.ReadOnly = true;
                cboBanco.ReadOnly = true;
                cboMoneda.ReadOnly = true;

                //IdChequeBanco = pCheque.IdChequeBanco;    
            }
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Consultar Cheque";
                pCheque   = new ChequeBL().Consulta(IdCheque);

                cboEmpresa.EditValue   = pCheque.IdEmpresa;
                cboBanco.EditValue     = pCheque.IdBanco;
                txtCheque.Text         = pCheque.NumeroCheque;
                deFecEmision.EditValue = pCheque.FechaEmision;
                txtPortador.Text       = pCheque.Portador;
                cboMoneda.EditValue    = pCheque.IdMoneda;
                txtMonto.Text          = String.Format("{0:#,##0.00}", pCheque.Monto);
                cboMotivo.EditValue    = pCheque.IdMotivo;
                txtDestino.Text        = pCheque.Destino;
                txtObservacion.Text    = pCheque.Observacion;

                dmlTipoCambio = pCheque.TCambio;
                IdMoneda      = pCheque.IdMoneda;
                IdSituacion   = pCheque.IdSituacion;
                FechaRegistro = pCheque.FechaRegistro;
                IdPersona     = pCheque.IdPersona;
                txtNroRecibo.EditValue = pCheque.NumRecibo;
                txtCajaChica.EditValue = pCheque.NumCajaChica;
                //IdChequeBanco = pCheque.IdChequeBanco;

                cboEmpresa.Enabled = false;
                cboBanco.Enabled = false;
                txtCheque.Enabled = false;
                deFecEmision.Enabled = false;
                txtPortador.Enabled = false;
                cboMoneda.Enabled = false;
                txtMonto.Enabled = false;
                cboMotivo.Enabled = false;
                txtDestino.Enabled = false;
                txtObservacion.Enabled = false;

                cboEmpresa.ReadOnly = true;
                cboBanco.ReadOnly = true;
                cboMoneda.ReadOnly = true;
            }
            cboEmpresa_EditValueChanged(null,null);
        }

        private void frmRegChequeEdit_Shown(object sender, EventArgs e)
        {
            bool boolFlag = false;

            TipoCambioBE objTipoCambio = null;
            objTipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);

            if (objTipoCambio == null)
            {
                XtraMessageBox.Show("Falta ingresar Tipo de Cambio del Día", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                boolFlag = true;
            }
            else
            {
                if (pOperacion == Operacion.Nuevo)
                {
                    dmlTipoCambio = decimal.Parse(objTipoCambio.Venta.ToString());
                }
            }

            if (boolFlag)
            {
                this.Close();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarIngreso())
                {
                    ChequeBE objCheque    = new ChequeBE();
                    ChequeBL objBL_Cheque = new ChequeBL();

                    objCheque.IdCheque      = IdCheque;
                    objCheque.IdEmpresa     = Convert.ToInt32(cboEmpresa.EditValue);
                    objCheque.IdBanco       = Convert.ToInt32(cboBanco.EditValue);
                    objCheque.IdMoneda      = Convert.ToInt32(cboMoneda.EditValue);
                    objCheque.IdMotivo      = Convert.ToInt32(cboMotivo.EditValue);
                    objCheque.IdSituacion   = IdSituacion;
                    objCheque.IdPersona     = IdPersona;
                    objCheque.TCambio       = dmlTipoCambio;
                    objCheque.Monto         = Convert.ToDecimal(txtMonto.Text);
                    objCheque.MontoSoles    = Convert.ToInt32(cboMoneda.EditValue) == 6 ? Math.Round(Convert.ToDecimal(txtMonto.Text) * dmlTipoCambio, 2) : Convert.ToDecimal(txtMonto.Text);
                    objCheque.RazonSocial   = cboEmpresa.Text;
                    objCheque.Portador      = txtPortador.Text;
                    objCheque.Destino       = txtDestino.Text;
                    objCheque.Observacion   = txtObservacion.Text;
                    objCheque.NumeroCheque  = txtCheque.Text;
                    objCheque.FechaEmision  = Convert.ToDateTime(deFecEmision.EditValue);
                    //objCheque.FechaRegistro = FechaRegistro;
                    objCheque.FlagEstado    = true;
                    objCheque.Usuario       = Parametros.strUsuarioLogin;
                    objCheque.Maquina       = WindowsIdentity.GetCurrent().Name.ToString();
                    objCheque.NumRecibo = txtNroRecibo.Text.Trim();
                    objCheque.NumCajaChica = txtCajaChica.Text.Trim();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cheque.Inserta(objCheque);
                    else
                        objBL_Cheque.Actualiza(objCheque);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFecEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPortador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                Empresa = Convert.ToInt32(cboEmpresa.EditValue);
                Banco = Convert.ToInt32(cboBanco.EditValue);

                BSUtils.LoaderLook(cboMoneda, new ChequeBL().GetMoneda(Empresa, Banco), "DesMoneda", "IdMoneda", true);


                Moneda = Convert.ToInt32(cboMoneda.EditValue);
                NumeroCorrelativo = Convert.ToInt32(GetCheque(Empresa, Banco, Moneda).NumeroCheque) + 1;



                if (GetCheque(Empresa, Banco, Moneda).NumeroCheque == null || GetCheque(Empresa, Banco, Moneda).NumeroCheque == "")
                    txtCheque.Text = "";
                else
                    txtCheque.Text = NumeroCorrelativo.ToString();

                BSUtils.LoaderLook(cboBanco, new BancoBL().ListaFiltro(Convert.ToInt32(cboEmpresa.EditValue)), "DescBanco", "IdBanco", true);
            }
        }

        private void cboBanco_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                Empresa = Convert.ToInt32(cboEmpresa.EditValue);
                Banco = Convert.ToInt32(cboBanco.EditValue);
                BSUtils.LoaderLook(cboMoneda, new ChequeBL().GetMoneda(Empresa, Banco), "DesMoneda", "IdMoneda", true);
                Moneda = Convert.ToInt32(cboMoneda.EditValue);
                NumeroCorrelativo = Convert.ToInt32(GetCheque(Empresa, Banco, Moneda).NumeroCheque) + 1;
                if (GetCheque(Empresa, Banco, Moneda).NumeroCheque == null || GetCheque(Empresa, Banco, Moneda).NumeroCheque == "")
                    txtCheque.Text = "";
                else
                    txtCheque.Text = NumeroCorrelativo.ToString();
            }
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                Empresa = Convert.ToInt32(cboEmpresa.EditValue);
                Banco = Convert.ToInt32(cboBanco.EditValue);
                Moneda = Convert.ToInt32(cboMoneda.EditValue);
                NumeroCorrelativo = Convert.ToInt32(GetCheque(Empresa, Banco, Moneda).NumeroCheque) + 1;
                if (GetCheque(Empresa, Banco, Moneda).NumeroCheque == null || GetCheque(Empresa, Banco, Moneda).NumeroCheque == "")
                    txtCheque.Text = "";
                else
                    txtCheque.Text = NumeroCorrelativo.ToString();
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtMonto1.Text))
            //{
            //    txtMonto1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //    txtMonto1.Properties.Mask.EditMask = "#,##0.00";
            //    txtMonto1.Properties.Mask.UseMaskAsDisplayFormat = true;
            //}
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboEmpresa.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione la empresa. \n";
                flag = true;
            }

            if (txtCheque.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Ingrese el numero de cheque. \n";
                flag = true;
            }

            if (cboBanco.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione el banco. \n";
                flag = true;
            }

            if (deFecEmision.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione la fecha. \n";
                flag = true;
            }

            if (txtPortador.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Ingrese el portador. \n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione la moneda. \n";
                flag = true;
            }

            if (cboMotivo.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione el motivo. \n";
                flag = true;
            }

            if (txtDestino.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Ingrese el destino. \n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return flag;
        }

        private void txtMonto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        public ChequeBancoBE GetCheque(int IdEmpresa, int IdBanco, int IdMoneda)
        {
            ChequeBancoBE Cheque = new ChequeBL().NumeroCheque(IdEmpresa, IdBanco, IdMoneda);
            return Cheque;
        }

        private DataTable CargarEmpresa()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdEmpresa", Type.GetType("System.Int32"));
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            DataRow dr;

            dr = dt.NewRow();
            dr["IdEmpresa"] = 13;
            dr["RazonSocial"] = "PANORAMA DISTRIBUIDORES S.A.";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["IdEmpresa"] = 27;
            dr["RazonSocial"] = "DECORATEX E.I.R.L.";
            dt.Rows.Add(dr);

            return dt;
        }

        #endregion
    }
}