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
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegClienteCreditoEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        
        public List<ClienteCreditoBE> lstClienteCredito;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdClienteCredito = 0;

        public int IdClienteCredito
        {
            get { return _IdClienteCredito; }
            set { _IdClienteCredito = value; }
        }

        private int IdCliente = 0;

        #endregion

        #region "Eventos"

        public frmRegClienteCreditoEdit()
        {
            InitializeComponent();
        }

        private void frmRegClienteCreditoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboDocumento.EditValue = Parametros.intTipoDocumentoRUC;
            BSUtils.LoaderLook(cboClasifica, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboClasifica.EditValue = Parametros.intRegular;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;

            BSUtils.LoaderLook(cboTipoLetra, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTipoLetra), "DescTablaElemento", "IdTablaElemento", true);

          //  cboTipoLetra.EditValue = Parametros.intMotivoVenta;


            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cliente Credito - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cliente Credito - Modificar";

                ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                objE_ClienteCredito = new ClienteCreditoBL().Selecciona(Parametros.intEmpresaId, IdClienteCredito);

                cboDocumento.EditValue = objE_ClienteCredito.IdTipoDocumento;
                txtNumeroDocumento.Text = objE_ClienteCredito.NumeroDocumento;
                txtDescCliente.EditValue = objE_ClienteCredito.DescCliente;
                cboClasifica.EditValue = objE_ClienteCredito.IdClasificacionCliente;
                txtDireccion.EditValue = objE_ClienteCredito.Direccion;
                cboMotivo.EditValue = objE_ClienteCredito.IdMotivo;
                deFecha.EditValue = objE_ClienteCredito.FechaAprobacion;
                txtNumeroDias.EditValue = objE_ClienteCredito.NumeroDias;
                txtLineaCredito.EditValue = objE_ClienteCredito.LineaCredito;
                txtLineaCreditoUtilizada.EditValue = objE_ClienteCredito.LineaCreditoUtilizada;
                txtLineaCreditoDisponible.EditValue = objE_ClienteCredito.LineaCreditoDisponible;
                txtGarantia.EditValue = objE_ClienteCredito.Garantia;
                txtObservacion.EditValue = objE_ClienteCredito.Observacion;

            }

            txtNumeroDocumento.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClienteCreditoBL objBL_ClienteCredito = new ClienteCreditoBL();
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();

                    objE_ClienteCredito.IdClienteCredito = IdClienteCredito;
                    objE_ClienteCredito.IdEmpresa = Parametros.intEmpresaId;
                    objE_ClienteCredito.IdCliente = IdCliente;
                    objE_ClienteCredito.IdClasificacionCliente = Convert.ToInt32(cboClasifica.EditValue);
                    objE_ClienteCredito.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objE_ClienteCredito.FechaAprobacion = Convert.ToDateTime(deFecha.Text);
                    objE_ClienteCredito.LineaCredito = Convert.ToDecimal(txtLineaCredito.Text);
                    objE_ClienteCredito.LineaCreditoUtilizada = Convert.ToDecimal(txtLineaCreditoUtilizada.Text);
                    objE_ClienteCredito.LineaCreditoDisponible = Convert.ToDecimal(txtLineaCreditoDisponible.Text);
                    objE_ClienteCredito.Garantia = Convert.ToDecimal(txtGarantia.Text);
                    objE_ClienteCredito.NumeroDias = Convert.ToSByte(txtNumeroDias.Text);
                    objE_ClienteCredito.Observacion = txtObservacion.Text;
                    objE_ClienteCredito.FlagEstado = true;
                    objE_ClienteCredito.Usuario = Parametros.strUsuarioLogin;
                    objE_ClienteCredito.Maquina = WindowsIdentity.GetCurrent().Name.ToString();


                    if (pOperacion == Operacion.Nuevo)
                        objBL_ClienteCredito.Inserta(objE_ClienteCredito);
                    else
                        objBL_ClienteCredito.Actualiza(objE_ClienteCredito);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDocumento.EditValue != null)
            {
                BSUtils.LoaderLook(cboDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente), "DescTablaElemento", "IdTablaElemento", true);
                cboDocumento.EditValue = Parametros.intTipoDocumentoDNI;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();

                    IdCliente= frm.pClienteBE.IdCliente;
                    cboDocumento.EditValue = frm.pClienteBE.IdTipoDocumento;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion + " " + frm.pClienteBE.NumDireccion;
                    deFecha.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                if (objE_Cliente != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();

                    IdCliente = objE_Cliente.IdCliente;
                    objE_ClienteCredito.IdCliente = objE_Cliente.IdCliente;
                    cboDocumento.EditValue = objE_Cliente.IdTipoDocumento;
                    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = objE_Cliente.DescCliente;
                    txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion + " " + objE_Cliente.NumDireccion;
                    deFecha.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtLineaCredito_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtLineaCredito.EditValue) > -1)
            {
                CalculaLineaDisponible(Convert.ToDecimal(txtLineaCredito.EditValue), (Convert.ToDecimal(txtLineaCreditoUtilizada.EditValue)));
            }
        }

        private void txtLineaCreditoUtilizada_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtLineaCreditoUtilizada.EditValue) > -1)
            {
                CalculaLineaDisponible(Convert.ToDecimal(txtLineaCredito.EditValue), (Convert.ToDecimal(txtLineaCreditoUtilizada.EditValue)));
            }
        }

       
        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese N° Documento.\n";
                flag = true;
            }

            if (deFecha.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Aprobacion.\n";
                flag = true;
            }

            if (txtNumeroDias.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Numero de Dias.\n";
                flag = true;
            }

            if (txtLineaCredito.Text.Trim().ToString() == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese Linea de Credito.\n";
                flag = true;
            }

            ClienteCreditoBE objE_ClienteCredito = null;
            objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));

            if (objE_ClienteCredito != null)
            {
                strMensaje = strMensaje + "- Ya existe línea de crédito en "+ cboMotivo.Text +".\n";
                flag = true;
            }


            if (pOperacion == Operacion.Nuevo)
            {
                var BuscarDocumento = lstClienteCredito.Where(oB => oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper() && oB.IdMotivo == Convert.ToInt32(cboMotivo.EditValue)).ToList();
                if (BuscarDocumento.Count > 0)
                {
                    strMensaje = strMensaje + "- El número de documento ya existe.\n";
                    flag = true;
                }

                var BuscarDescripcion = lstClienteCredito.Where(oB => oB.DescCliente.ToUpper() == txtDescCliente.Text.ToUpper() && oB.IdMotivo == Convert.ToInt32(cboMotivo.EditValue)).ToList();
                if (BuscarDescripcion.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción ya existe.\n";
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

        private void CalculaLineaDisponible(decimal LineaCredito, decimal LineaUtilizada)
        {
            txtLineaCreditoDisponible.EditValue = LineaCredito - LineaUtilizada;
        }

        #endregion

        

    }
}