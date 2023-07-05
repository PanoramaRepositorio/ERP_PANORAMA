using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegMovimientoCajaChicaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<MovimientoCajaChicaBE> lstMovimientoCajaChica;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DateTime FechaD { get; set; }

        int _IdMovimientoCajaChica = 0;

        public int IdMovimientoCajaChica
        {
            get { return _IdMovimientoCajaChica; }
            set { _IdMovimientoCajaChica = value; }
        }

        string _strTipoMovimiento = "R";
        public string strTipoMovimiento
        {
            get { return _strTipoMovimiento; }
            set { _strTipoMovimiento = value; }
        }

        private int IdPedido = 0;
        public int IdCaja = 0;
        private int IdPersona = 0;
        private int IdSolicitudPrestamo;
        private int? IdHoraExtra;


        #endregion

        #region "Eventos"

        public frmRegMovimientoCajaChicaEdit()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoCajaChicaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoAnexo, CargarTipoAnexo(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
            cboCondicionPago.EditValue = Parametros.intEfectivo;
            BSUtils.LoaderLook(cboPersonaAutoriza, new PersonaBL().SeleccionaGerencia(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            deFecha.EditValue = FechaD;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Movimiento Caja Chica - Nuevo";
                cboTipoAnexo.Focus();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Movimiento Caja Chica - Modificar";

                MovimientoCajaChicaBE objE_MovimientoCajaChica = null;
                objE_MovimientoCajaChica = new MovimientoCajaChicaBL().Selecciona(IdMovimientoCajaChica);

                IdMovimientoCajaChica = objE_MovimientoCajaChica.IdMovimientoCajaChica;
                deFecha.EditValue = objE_MovimientoCajaChica.Fecha;
                cboDocumento.EditValue = objE_MovimientoCajaChica.IdTipoDocumento;
                txtNumeroDocumento.Text = objE_MovimientoCajaChica.NumeroDocumento;
                txtConcepto.Text = objE_MovimientoCajaChica.Concepto;
                cboMoneda.EditValue = objE_MovimientoCajaChica.IdMoneda;
                txtImporteSoles.EditValue = objE_MovimientoCajaChica.Importe;
                IdPersona = objE_MovimientoCajaChica.IdAnexo;
                txtDescAnexo.Text = objE_MovimientoCajaChica.DescAnexo;
                cboPersonaAutoriza.EditValue = objE_MovimientoCajaChica.IdPersonaAutoriza;
                txtObservacion.Text = objE_MovimientoCajaChica.Observacion;

                //tipo de Movimiento
                if (objE_MovimientoCajaChica.TipoMovimiento == "S")
                    optRetiro.Checked = true;
                else
                    optPago.Checked = true;

                txtNumeroDocumento.Select();
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MovimientoCajaChicaBE objCajaChica = new MovimientoCajaChicaBE();
                    MovimientoCajaChicaBL objBL_CajaChica = new MovimientoCajaChicaBL();

                    objCajaChica.IdMovimientoCajaChica = IdMovimientoCajaChica;
                    objCajaChica.IdEmpresa = Parametros.intEmpresaId;
                    objCajaChica.Periodo = Parametros.intPeriodo;
                    objCajaChica.IdTipoAnexo = Convert.ToInt32(cboTipoAnexo.EditValue);
                    objCajaChica.IdAnexo = 0;
                    objCajaChica.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objCajaChica.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    objCajaChica.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCajaChica.Concepto = txtConcepto.Text.Trim();
                    objCajaChica.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    objCajaChica.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objCajaChica.Importe = Convert.ToDecimal(txtImporteSoles.EditValue);
                    if (optRetiro.Checked == true)
                        objCajaChica.TipoMovimiento = "S";
                    else
                        objCajaChica.TipoMovimiento = "I";
                    objCajaChica.Observacion = txtObservacion.Text;
                    objCajaChica.IdPersonaAutoriza = Convert.ToInt32(cboPersonaAutoriza.EditValue);

                    objCajaChica.UsuarioRegistro = Parametros.strUsuarioLogin;
                    objCajaChica.FechaRegistro = DateTime.Now;
                    objCajaChica.UsuarioModifica = Parametros.strUsuarioLogin;
                    objCajaChica.FechaModifica = DateTime.Now;
                    objCajaChica.FlagEstado = true;


                    PagosBL objBL_Pagos = new PagosBL();

                    ////Datos del Recibo de Pago
                    //PagosBE objPago = new PagosBE();
                    //objPago.IdPago = 0;// IdPago;
                    //objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                    //objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    //objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    //objPago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    //objPago.NumeroDocumento = txtNumeroDocumento.Text;
                    //objPago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                    //objPago.Concepto = txtConcepto.Text;
                    //objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    //objPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista); //Convert.ToDecimal(txtTipoCambio.EditValue);
                    //objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                    //objPago.ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(Parametros.dmlTCMayorista);//Convert.ToDecimal(txtImporteDolares.EditValue);
                    ////objPago.TipoMovimiento = "R"; // Abono - R -RETIRO
                    //if (optRetiro.Checked == true)
                    //    objPago.TipoMovimiento = "S";
                    //else
                    //    objPago.TipoMovimiento = "I";

                    //objPago.FlagEstado = true;
                    //objPago.Usuario = Parametros.strUsuarioLogin;
                    //objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    //objPago.IdEmpresa = Parametros.intEmpresaId;

                    //Datos del Movimiento de Caja
                    List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();


                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_CajaChica.Inserta(objCajaChica);
                    }
                    else
                    {
                        objBL_CajaChica.Actualiza(objCajaChica);
                    }

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


        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtImporteSoles.Select();
                txtImporteSoles.SelectAll();
                //optCreditoCargo.Focus();
            }
        }
        private void txtImporteSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                cboPersonaAutoriza.Select();

            }
        }
        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtNumeroDocumento.Select();
            }
        }
        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtConcepto.Select();
            }
        }
        private void cboPersonaAutoriza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnGrabar.Focus();
            }
        }

        private void optPago_CheckedChanged(object sender, EventArgs e)
        {
            txtImporteSoles.Select();
            txtImporteSoles.SelectAll();
        }
        private void optRetiro_CheckedChanged(object sender, EventArgs e)
        {
            txtImporteSoles.Select();
            txtImporteSoles.SelectAll();
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(cboTipoAnexo.EditValue)==1)
                {
                    frmBusCliente frm = new frmBusCliente();
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm.pClienteBE != null)
                    {
                        IdPersona = frm.pClienteBE.IdCliente;
                        txtDescAnexo.Text = frm.pClienteBE.DescCliente;
                    }
                }
                else if (Convert.ToInt32(cboTipoAnexo.EditValue) == 2)
                {
                    frmConProveedor frm = new frmConProveedor();
                    //frm.pFlagMultiSelect = false;
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        IdPersona = frm._Be.IdProveedor;
                        txtDescAnexo.Text = frm._Be.DescProveedor;
                    }
                }
                else if (Convert.ToInt32(cboTipoAnexo.EditValue) == 3)
                {
                    frmBuscaPersona frm = new frmBuscaPersona();
                    frm.TipoBusqueda = 0;
                    //frm.Title = "Búsqueda de Persona sin Usuario";
                    frm.ShowDialog();
                    if (frm._Be != null)
                    {
                        IdPersona = frm._Be.IdPersona;
                        txtDescAnexo.Text = frm._Be.ApeNom;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Seleccionar el tipo de anexo a buscar",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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


            if (Convert.ToDecimal(txtImporteSoles.EditValue) == 0)
            {
                strMensaje = strMensaje + "- El importe no puede ser cero.\n";
                flag = true;
            }

            //if (cboDocumento.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Seleccione el documento.\n";
            //    flag = true;
            //}

            //if (txtNumeroDocumento.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese el número de documento.\n";
            //    flag = true;
            //}

            if (cboCondicionPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la condición de pago.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la moneda.\n";
                flag = true;
            }

            if (txtConcepto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el concepto del recibo de pago.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstPago.Where(oB => oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- El documento ya existe.\n";
                //    flag = true;
                //}
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "SIN DOCUMENTO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = Parametros.intTipoDocFacturaCompra;
            dr["Descripcion"] = "FACTURA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = Parametros.intTipoDocRecibPorHonorario;
            dr["Descripcion"] = "RECIBO POR HONORARIOS";
            dt.Rows.Add(dr);
            return dt;
        }
        private DataTable CargarTipoAnexo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] ="NINGUNO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "CLIENTE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "PROVEEDOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "PERSONAL";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroPrestamo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SolicitudPrestamoBE objE_Solicitud = new SolicitudPrestamoBE();
            //    objE_Solicitud = new SolicitudPrestamoBL().SeleccionaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipoDocPrestamo, txtNumeroPrestamo.Text.Trim());
            //    if (objE_Solicitud != null)
            //    {
            //        IdSolicitudPrestamo = objE_Solicitud.IdSolicitudPrestamo;
            //        IdPersona = objE_Solicitud.IdPersona;
            //        txtPersona.Text = objE_Solicitud.DescPersona;
            //        txtImporteSoles.EditValue = objE_Solicitud.TotalPago;
            //        if (objE_Solicitud.Metodo == 1)
            //        {
            //            txtConcepto.Text = "PRESTAMO N°" + txtNumeroPrestamo.Text;
            //        }
            //        else
            //        {
            //            txtConcepto.Text = "ADELANTO DE SUELDO N°" + txtNumeroPrestamo.Text;
            //        }

            //        txtConcepto.Properties.ReadOnly = true;

            //        //cboMotivoEgreso.Properties.ReadOnly = true;
            //        //btnBuscar.Enabled = true;

            //        //Conversion
            //        if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
            //        {
            //            decimal ImporteDolares = 0;
            //            ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            //            txtImporteDolares.EditValue = ImporteDolares;
            //        }

            //        txtIdHoraExtra.Properties.ReadOnly = true;
            //        txtNumeroPrestamo.Properties.ReadOnly = true;
            //        txtNumeroDocumento.Select();
            //    }
            //}
        }
    }
}