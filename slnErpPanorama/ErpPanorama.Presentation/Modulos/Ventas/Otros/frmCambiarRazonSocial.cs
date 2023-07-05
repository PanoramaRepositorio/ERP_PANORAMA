using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmCambiarRazonSocial : DevExpress.XtraEditors.XtraForm
    {
        #region "Propieadades"

        public int IdEmpresa { get; set; }
        public int IdDocumentoVenta { get; set; }

        public int Origen = 0; //0=DocumentoVenta; 1=CuentaBanco; 2=Cambio
        public int IdCuentaBancoDetalle = 0;

        public int IdCliente = 0;
        public int IdCambio = 0;



        #endregion

        #region "Eventos"


        public frmCambiarRazonSocial()
        {
            InitializeComponent();
        }

        private void frmCambiarRazonSocial_Load(object sender, EventArgs e)
        {
            DocumentoVentaBE objDocumento = null;
            objDocumento = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
            if (objDocumento != null)
            {
                IdCliente = objDocumento.IdCliente;
                txtNumeroDocumento.Text = objDocumento.NumeroDocumento;
                txtDescCliente.Text = objDocumento.DescCliente;
                txtDireccion.Text = objDocumento.Direccion;
            }
        }

        private void btnClienteAsociado_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar un cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumeroDocumento.Focus();
                    return;
                }

                frmBusClienteAsociado frm = new frmBusClienteAsociado();
                frm.IdCliente = IdCliente;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteAsociadoBE != null)
                {
                    txtNumeroDocumento.Text = frm.pClienteAsociadoBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteAsociadoBE.DescCliente;
                    txtDireccion.Text = frm.pClienteAsociadoBE.Direccion;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Origen == 0)
            {
                DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                objBL_Documento.ActualizaCliente(IdDocumentoVenta, IdCliente, txtNumeroDocumento.Text, txtDescCliente.Text, txtDireccion.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if(Origen == 1)
            {
                CuentaBancoDetalleBE objE_CuentaBanco = new CuentaBancoDetalleBE();
                CuentaBancoDetalleBL objBL_Documento = new CuentaBancoDetalleBL();
                objE_CuentaBanco.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
                objE_CuentaBanco.IdCliente = IdCliente;
                objE_CuentaBanco.DescCliente = txtDescCliente.Text.Trim();
                objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
                objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_Documento.ActualizaCliente(objE_CuentaBanco);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (Origen == 2)
            {
                CambioBE objE_Cambio = new CambioBE();
                CambioBL objBL_Documento = new CambioBL();
                objE_Cambio.IdCambio = IdCambio;
                objE_Cambio.IdCliente = IdCliente;
                objE_Cambio.NumeroCliente = txtNumeroDocumento.Text;
                objE_Cambio.DescCliente = txtDescCliente.Text.Trim();
                objE_Cambio.Usuario = Parametros.strUsuarioLogin;
                objE_Cambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_Documento.ActualizaCliente(objE_Cambio.IdCambio, objE_Cambio.IdCliente, objE_Cambio.NumeroCliente, objE_Cambio.DescCliente);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    txtDescCliente.Focus();
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

        #endregion


        
        #region "Metodos"

        #endregion

    }
}