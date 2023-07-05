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

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManChequeBancoEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmManChequeBancoEdit()
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

        public ChequeBancoBE pChequeBanco { get; set; }

        int IdChequeBanco_ = 0;
        public int IdChequeBanco
        {
            get { return IdChequeBanco_; }
            set { IdChequeBanco_ = value; }
        }

        private int NumeroCorrelativo = 0;
        private int IdEmpresa = Parametros.intEmpresaId;
        private int IdBanco = 0;
        private int IdMoneda = 0;
        private int IdPersona = Parametros.intUsuarioId;
        private DateTime FechaRegistro = Parametros.dtFechaHoraServidor;

        decimal dmlTipoCambio = 0;

        #endregion

        #region "Eventos"

        private void frmManChequeBancoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, CargarEmpresa(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            cboBanco.EditValue = IdBanco;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = IdMoneda;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nueva Numeracion de Cheque";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text    = "Editar Numeracion de Cheque";
                pChequeBanco = new ChequeBancoBL().Consulta(IdChequeBanco);

                cboEmpresa.EditValue = pChequeBanco.IdEmpresa;
                cboBanco.EditValue   = pChequeBanco.IdBanco;
                cboMoneda.EditValue  = pChequeBanco.IdMoneda;

                FechaRegistro = pChequeBanco.FechaRegistro;
                IdEmpresa = pChequeBanco.IdEmpresa;
                IdBanco = pChequeBanco.IdBanco;
                IdMoneda = pChequeBanco.IdMoneda;
                IdPersona = pChequeBanco.IdPersona;
            }
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text    = "Consultar Numeracion de Cheque";
                pChequeBanco = new ChequeBancoBL().Consulta(IdChequeBanco);

                cboEmpresa.EditValue = pChequeBanco.IdEmpresa;
                cboBanco.EditValue   = pChequeBanco.IdBanco;
                cboMoneda.EditValue  = pChequeBanco.IdMoneda;

                FechaRegistro = pChequeBanco.FechaRegistro;
                IdEmpresa = pChequeBanco.IdEmpresa;
                IdBanco = pChequeBanco.IdBanco;
                IdMoneda = pChequeBanco.IdMoneda;
                IdPersona = pChequeBanco.IdPersona;

                cboEmpresa.Enabled = false;
                cboBanco.Enabled = false;
                cboMoneda.Enabled = false;
            }
        }

        private void frmManChequeBancoEdit_Shown(object sender, EventArgs e)
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
                    ChequeBancoBE objChequeBanco    = new ChequeBancoBE();
                    ChequeBancoBL objBL_chequeBanco = new ChequeBancoBL();

                    objChequeBanco.IdChequeBanco = IdChequeBanco;
                    objChequeBanco.IdEmpresa     = Convert.ToInt32(cboEmpresa.EditValue);
                    objChequeBanco.IdBanco       = Convert.ToInt32(cboBanco.EditValue);
                    objChequeBanco.IdMoneda      = Convert.ToInt32(cboMoneda.EditValue);
                    objChequeBanco.IdPersona     = IdPersona;
                    objChequeBanco.TCambio       = dmlTipoCambio;
                    objChequeBanco.NumeroCheque  = NumeroCorrelativo.ToString();
                    objChequeBanco.FechaRegistro = FechaRegistro;
                    objChequeBanco.FlagEstado    = true;
                    objChequeBanco.Usuario       = Parametros.strUsuarioLogin;
                    objChequeBanco.Maquina       = WindowsIdentity.GetCurrent().Name.ToString();

                    int cant = objBL_chequeBanco.Valida(objChequeBanco);
                    if (cant > 0)
                    {
                        XtraMessageBox.Show("El Talonario de Cheque existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_chequeBanco.Inserta(objChequeBanco);
                    else
                        objBL_chequeBanco.Actualiza(objChequeBanco);

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

        private void cboBanco_KeyPress(object sender, KeyPressEventArgs e)
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

            if (cboBanco.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione el banco. \n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje += strMensaje + "- Seleccione la moneda. \n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return flag;
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