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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManNumeracionDocumentoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<NumeracionDocumentoBE> lstNumeracionDocumento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4,
            ConsultarEditar = 5
        }

        public Operacion pOperacion { get; set; }

        public NumeracionDocumentoBE pNumeracionDocumentoBE { get; set; }

        int _IdNumeracionDocumento = 0;

        public int IdNumeracionDocumento
        {
            get { return _IdNumeracionDocumento; }
            set { _IdNumeracionDocumento = value; }
        }

        public int intNumero = 0;

        #endregion

        #region "Eventos"

        public frmManNumeracionDocumentoEdit()
        {
            InitializeComponent();
        }

        private void frmManNumeracionDocumentoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;//Parametros.intIdPanoramaDistribuidores;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            BSUtils.LoaderLook(cboDocumento, new TipoDocumentoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTipoDocumento", "IdTipoDocumento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Numeración de Documento - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Numeración de Documento - Modificar";
                cboEmpresa.EditValue = pNumeracionDocumentoBE.IdEmpresa;
                cboTienda.EditValue = pNumeracionDocumentoBE.IdTienda;
                cboDocumento.EditValue = pNumeracionDocumentoBE.IdTipoDocumento;
                txtPeriodo.EditValue = pNumeracionDocumentoBE.Periodo;
                txtSerie.Text = pNumeracionDocumentoBE.Serie;
                txtNumero.EditValue = pNumeracionDocumentoBE.Numero;
                txtNumeroCaracter.EditValue = pNumeracionDocumentoBE.NumeroCaracter;
                cboEmpresa.Properties.ReadOnly = true;
                cboDocumento.Properties.ReadOnly = true;
                txtNumeroCaracter.Properties.ReadOnly = true;
                chkFacturacion.Checked = pNumeracionDocumentoBE.FlagFacturacion;

                if (Parametros.intUsuarioId == Parametros.intPerAdministrador)
                    txtNumeroCaracter.Properties.ReadOnly = false;
                
            }
            else if (pOperacion == Operacion.ConsultarEditar)
            {
                this.Text = "Numeración de Documento - Modificar";
                cboEmpresa.EditValue = pNumeracionDocumentoBE.IdEmpresa;
                cboTienda.EditValue = pNumeracionDocumentoBE.IdTienda;
                cboDocumento.EditValue = pNumeracionDocumentoBE.IdTipoDocumento;
                txtPeriodo.EditValue = pNumeracionDocumentoBE.Periodo;
                txtSerie.Text = pNumeracionDocumentoBE.Serie;
                txtNumero.EditValue = pNumeracionDocumentoBE.Numero;
                txtNumeroCaracter.EditValue = pNumeracionDocumentoBE.NumeroCaracter;
                txtSerie.Properties.ReadOnly = true;
                txtPeriodo.Properties.ReadOnly = true;
                chkFacturacion.Checked = pNumeracionDocumentoBE.FlagFacturacion;

                cboEmpresa.Properties.ReadOnly = true;
                cboTienda.Properties.ReadOnly = true;
                cboDocumento.Properties.ReadOnly = true;
                txtNumeroCaracter.Properties.ReadOnly = true;
                chkFacturacion.Properties.ReadOnly = true;
            }


            txtNumero.Select();
            //txtPeriodo.Select();
        }

        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    NumeracionDocumentoBL objBL_NumeracionDocumento = new NumeracionDocumentoBL();
                    NumeracionDocumentoBE objNumeracionDocumento = new NumeracionDocumentoBE();

                    objNumeracionDocumento.IdNumeracionDocumento = IdNumeracionDocumento;
                    objNumeracionDocumento.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objNumeracionDocumento.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objNumeracionDocumento.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objNumeracionDocumento.Serie = txtSerie.Text;
                    objNumeracionDocumento.Numero = Convert.ToInt32(txtNumero.EditValue);
                    objNumeracionDocumento.NumeroCaracter = Convert.ToInt32(txtNumeroCaracter.EditValue);
                    objNumeracionDocumento.FlagFacturacion = chkFacturacion.Checked;
                    objNumeracionDocumento.FlagEstado = true;
                    objNumeracionDocumento.Usuario = Parametros.strUsuarioLogin;
                    objNumeracionDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objNumeracionDocumento.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_NumeracionDocumento.Inserta(objNumeracionDocumento);
                    else
                        objBL_NumeracionDocumento.Actualiza(objNumeracionDocumento);

                    intNumero = Convert.ToInt32(txtNumero.EditValue); //add
                    this.DialogResult = DialogResult.OK;
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

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtNumeroCaracter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de documento.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtNumeroCaracter.EditValue) > 8)
            {
                strMensaje = strMensaje + "- El límite máximo de caracteres es 8.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtNumeroCaracter.EditValue) < 0)
            {
                strMensaje = strMensaje + "- El límite Mínimo de caracteres es 1.\n";
                flag = true;
            }


            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstNumeracionDocumento.Where(oB => oB.IdEmpresa == Convert.ToInt32(cboEmpresa.EditValue) && oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.Periodo == Convert.ToInt32(txtPeriodo.EditValue) && oB.Serie == cboSerie.Text).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- El documento ya existe.\n";
                //    flag = true;
                //}

                NumeracionDocumentoBE ObjE_Numeracion = null;
                ObjE_Numeracion = new NumeracionDocumentoBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Convert.ToInt32(txtPeriodo.EditValue), txtSerie.Text);

                if (ObjE_Numeracion != null)
                {
                    strMensaje = strMensaje + "- El documento ya existe.\n";
                    flag = true;
                }
            }

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
            {
                if (Parametros.strUsuarioLogin != "master")
                {
                    strMensaje = strMensaje + "- No se puede alterar la numeración de un Ticket de Venta.\nConsulte con su administrador.";
                    flag = true;
                }
                else
                {
                    if (XtraMessageBox.Show("El documento es un TICKET, este cambio podría generar graves problemas con la SUNAT\nEstá seguro de cambiar la numeración?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    {
                        flag = true;
                    }
                }
            }

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocGuiaElectronica)
            {
                if (Parametros.strUsuarioLogin != "master")
                {
                    strMensaje = strMensaje + "- No se puede alterar la numeración de un comprobante ELECTRONICO.\nConsulte con su administrador.";
                    flag = true;
                }
                else
                {
                    if (XtraMessageBox.Show("El documento es un comprobante ELECTRONICO, este cambio podría generar graves problemas con la SUNAT\nEstá seguro de cambiar la numeración?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    {
                        flag = true;
                    }
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