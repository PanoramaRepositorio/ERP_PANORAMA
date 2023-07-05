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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegInmuebleAlquilerEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InmuebleAlquilerBE> lstInmuebleAlquiler;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdCliente = 0;
        private int IdInmueble = 0;
        private int IdEmpresa = 0;

        int _IdInmuebleAlquiler = 0;

        public int IdInmuebleAlquiler
        {
            get { return _IdInmuebleAlquiler; }
            set { _IdInmuebleAlquiler = value; }
        }
        


        #endregion

        #region "Eventos"

        public frmRegInmuebleAlquilerEdit()
        {
            InitializeComponent();
        }

        private void frmRegInmuebleAlquilerEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "InmuebleAlquiler - Nuevo";
                //cboBanco.EditValue = IdBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "InmuebleAlquiler - Modificar";

                InmuebleAlquilerBE objE_InmuebleAlquiler = null;
                objE_InmuebleAlquiler = new InmuebleAlquilerBL().Selecciona(IdInmuebleAlquiler);

                IdInmuebleAlquiler = objE_InmuebleAlquiler.IdInmuebleAlquiler;
                IdInmueble = objE_InmuebleAlquiler.IdInmueble;
                IdEmpresa = objE_InmuebleAlquiler.IdEmpresa;
                IdCliente = objE_InmuebleAlquiler.IdCliente;
                txtInmuebleAlquiler.Text = objE_InmuebleAlquiler.DescInmueble;
                txtNumeroDocumento.Text = objE_InmuebleAlquiler.NumeroDocumento;
                txtDescCliente.Text = objE_InmuebleAlquiler.DescCliente;
                txtDireccion.Text = objE_InmuebleAlquiler.Direccion;
                cboMoneda.EditValue = objE_InmuebleAlquiler.IdMoneda;
                txtPrecioAlquiler.EditValue = objE_InmuebleAlquiler.PrecioAlquiler;
                txtAdelanto.EditValue = objE_InmuebleAlquiler.Adelanto;
                txtGarantia.EditValue = objE_InmuebleAlquiler.Garantia;
                txtDiaPago.EditValue = objE_InmuebleAlquiler.DiaPago;
                txtMora.EditValue = objE_InmuebleAlquiler.Mora;
                deFechaInicio.EditValue = objE_InmuebleAlquiler.FechaInicio;
                deFechaFin.EditValue = objE_InmuebleAlquiler.FechaFin;
                //deFechaRegistro.EditValue = objE_InmuebleAlquiler.FechaRegistro;
                txtObservacion.EditValue = objE_InmuebleAlquiler.Observacion;

            }
            txtInmuebleAlquiler.Focus();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InmuebleAlquilerBL objBL_InmuebleAlquiler = new InmuebleAlquilerBL();
                    InmuebleAlquilerBE objInmuebleAlquiler = new InmuebleAlquilerBE();

                    objInmuebleAlquiler.IdInmuebleAlquiler = IdInmuebleAlquiler;
                    objInmuebleAlquiler.IdInmueble = IdInmueble;
                    objInmuebleAlquiler.IdEmpresa = IdEmpresa;
                    objInmuebleAlquiler.IdCliente = IdCliente;
                    objInmuebleAlquiler.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    objInmuebleAlquiler.DescCliente = txtDescCliente.Text.Trim();
                    objInmuebleAlquiler.Direccion = txtDireccion.Text.Trim();
                    objInmuebleAlquiler.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objInmuebleAlquiler.PrecioAlquiler = Convert.ToDecimal(txtPrecioAlquiler.EditValue);
                    objInmuebleAlquiler.Adelanto = Convert.ToDecimal(txtAdelanto.EditValue);
                    objInmuebleAlquiler.Garantia = Convert.ToDecimal(txtGarantia.EditValue);
                    objInmuebleAlquiler.DiaPago = Convert.ToInt32(txtDiaPago.EditValue);
                    objInmuebleAlquiler.Mora = Convert.ToDecimal(txtMora.EditValue);
                    objInmuebleAlquiler.FechaInicio = Convert.ToDateTime(deFechaInicio.EditValue);
                    objInmuebleAlquiler.FechaFin = Convert.ToDateTime(deFechaFin.EditValue);
                    objInmuebleAlquiler.FechaRegistro = DateTime.Today;//fechaActual
                    objInmuebleAlquiler.Observacion = txtObservacion.Text.Trim();
                    objInmuebleAlquiler.FlagEstado = true;
                    objInmuebleAlquiler.Usuario = Parametros.strUsuarioLogin;
                    objInmuebleAlquiler.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_InmuebleAlquiler.Inserta(objInmuebleAlquiler);
                    else
                        objBL_InmuebleAlquiler.Actualiza(objInmuebleAlquiler);

                    this.Close();
                }
            }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }

        private void btnInmueble_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaInmueble frm = new frmBuscaInmueble();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    //cboEmpresa.EditValue = frm._Be.IdEmpresa;
                    IdInmueble = frm._Be.IdInmueble;
                    txtInmuebleAlquiler.Text = frm._Be.DescInmueble;
                    txtPrecioAlquiler.EditValue = frm._Be.PrecioAlquiler;
                    IdEmpresa = frm._Be.IdEmpresa;
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
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

            if (txtInmuebleAlquiler.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Selecione el Inmueble.\n";
                flag = true;
            }

            if (txtDescCliente.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Cliente.\n";
                flag = true;
            }

            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese dirección.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstInmuebleAlquiler.Where(oB => oB.DescInmueble == txtInmuebleAlquiler.Text.Trim() && oB.Direccion == txtDireccion.Text.Trim()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Inmueble ya existe.\n";
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