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

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegMovimientoCajaSalidaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<MovimientoCajaChicaBE> lstMovimientoCajaChica;
        public List<HoraExtraBE> lstHoraExtra;
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public DateTime FechaD { get; set; }

        int _IdMovimientoCaja = 0;

        public int IdMovimientoCaja
        {
            get { return _IdMovimientoCaja; }
            set { _IdMovimientoCaja = value; }
        }

        string _strTipoMovimiento = "S";
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
        private int IdDis_ProyectoServicio = 0;

        public int IdEmpresa { get; set; }//= 0;
        public int IdTienda { get; set; }//= 0;
        public int Origen = 0;
        public int IdMovimientoCajaOrigen = 0;

        #endregion

        #region "Eventos"

        public frmRegMovimientoCajaSalidaEdit()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoCajaSalidaEdit_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = DateTime.Now.Date.Year;
            deFecha.EditValue = FechaD;
            TipoCambioBE objE_TipoCambio = null;
            cboCaja.Properties.ReadOnly = true;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.EditValue));
            if (objE_TipoCambio != null)
            {
                txtTipoCambio.EditValue = objE_TipoCambio.Compra;
            }

            BSUtils.LoaderLook(cboDocumento2, CargarTipoDocumento(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumentoEgreso(), "Descripcion", "Id", false);
            //cboDocumento.EditValue = 0;
            cboDocumento.EditValue = Parametros.intTipoDocRetiroCaja;
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(IdEmpresa, IdTienda /*Parametros.intEmpresaId, Parametros.intTiendaId*/), "DescCaja", "IdCaja", true);
            cboCaja.EditValue = IdCaja; 
            BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
            cboCondicionPago.EditValue = Parametros.intEfectivo;
            BSUtils.LoaderLook(cboPersonaAutoriza, new PersonaBL().SeleccionaGerencia(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            deFecha.EditValue = FechaD;
            BSUtils.LoaderLook(cboTipoTarjeta, CargarTipoTarjeta(), "Descripcion", "Id", false);
            cboTipoTarjeta.EditValue = "";

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Movimiento Caja - Nuevo";

                if (strTipoMovimiento == "S")
                    optRetiro.Checked = true;
                else
                    optPago.Checked = true;


                if (Origen == 1)//Vuelto
                {
                    if (IdMovimientoCajaOrigen > 0)
                    {
                        MovimientoCajaBE objE_MovCaja = new MovimientoCajaBE();
                        objE_MovCaja = new MovimientoCajaBL().Selecciona(IdMovimientoCajaOrigen);
                        txtObservacion.Text ="Fact. N°"+ objE_MovCaja.NumeroDocumento2 + " del " +  objE_MovCaja.Fecha.ToShortDateString().ToString() + " S/" + objE_MovCaja.ImporteSoles;
                        txtNumeroDocumento.Text = "VUELTO";
                        txtConcepto.Text = "VUELTO";
                        cboPersonaAutoriza.EditValue = 151;
                        cboDocumento.EditValue = Parametros.intTipoDocIngresoCaja;
                        cboDocumento.Properties.ReadOnly = true;
                    }

                    gcExtra.Enabled = false;
                    optPago.Checked = true;
                    optRetiro.Enabled = false;
                }

                btnBuscarPersona.Focus();

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Movimiento Caja - Modificar";
                BSUtils.LoaderLook(cboPersonaAutoriza, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

                MovimientoCajaBE objE_MovimientoCaja = null;
                objE_MovimientoCaja = new MovimientoCajaBL().Selecciona(IdMovimientoCaja);

                IdMovimientoCaja = objE_MovimientoCaja.IdMovimientoCaja;
                //IdPedido = objE_MovimientoCaja.IdPedido == null ? 0 : IdPedido;
                cboCaja.EditValue = objE_MovimientoCaja.IdCaja;
                deFecha.EditValue = objE_MovimientoCaja.Fecha;
                cboDocumento.EditValue = objE_MovimientoCaja.IdTipoDocumento;
                cboCondicionPago.EditValue = objE_MovimientoCaja.IdCondicionPago;
                txtNumeroDocumento.Text = objE_MovimientoCaja.NumeroDocumento;
                txtConcepto.Text = objE_MovimientoCaja.Concepto;
                cboMoneda.EditValue = objE_MovimientoCaja.IdMoneda;
                txtTipoCambio.EditValue = objE_MovimientoCaja.TipoCambio;
                txtImporteSoles.EditValue = objE_MovimientoCaja.ImporteSoles;
                txtImporteDolares.EditValue = objE_MovimientoCaja.ImporteDolares;
                IdPersona = objE_MovimientoCaja.IdPersona;
                txtPersona.Text = objE_MovimientoCaja.DescPersona;
                cboPersonaAutoriza.EditValue = objE_MovimientoCaja.IdPersonaAutoriza;
                txtObservacion.Text = objE_MovimientoCaja.Observacion;
                cboCaja.EditValue = objE_MovimientoCaja.IdCaja;
                cboDocumento2.EditValue = objE_MovimientoCaja.IdTipoDocumento2;
                txtNumeroDocumento2.Text = objE_MovimientoCaja.NumeroDocumento2;
                txtPlaca.Text = objE_MovimientoCaja.Placa;
                cboTipoTarjeta.EditValue = objE_MovimientoCaja.TipoTarjeta; // ECM
                IdDis_ProyectoServicio = objE_MovimientoCaja.IdDis_ProyectoServicio;

                //tipo de Movimiento
                if (objE_MovimientoCaja.TipoMovimiento == "S")
                    optRetiro.Checked = true;
                else
                    optPago.Checked = true;

                cboPersonaAutoriza.Properties.ReadOnly = true;
                gcExtra.Enabled = false;

                txtNumeroDocumento2.Select();
            }

            BloquearEdicionImporte();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ////Hora Extra
                    //HoraExtraBE ojbHoraExtra = new HoraExtraBE();
                    //HoraExtraBL objBL_HoraExtra = new HoraExtraBL();

                    //MovimientoCaja
                    MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                    MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();

                    objMovimientoCaja.IdMovimientoCaja = IdMovimientoCaja;
                    objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objMovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
                    objMovimientoCaja.IdPersona = IdPersona;
                    objMovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objMovimientoCaja.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objMovimientoCaja.Concepto = txtConcepto.Text.Trim();
                    objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objMovimientoCaja.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);
                    objMovimientoCaja.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);
                    objMovimientoCaja.IdFormaPago = Parametros.intContado;
                    objMovimientoCaja.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);

                    if (optRetiro.Checked == true)
                        objMovimientoCaja.TipoMovimiento = "S";
                    else
                        objMovimientoCaja.TipoMovimiento = "I";
                    objMovimientoCaja.TipoTarjeta = cboTipoTarjeta.EditValue.ToString(); // ECM
                    objMovimientoCaja.Observacion = txtObservacion.Text;
                    objMovimientoCaja.IdDocumentoVenta = null;
                    objMovimientoCaja.IdPersonaAutoriza = Convert.ToInt32(cboPersonaAutoriza.EditValue);
                    objMovimientoCaja.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                    objMovimientoCaja.IdTipoDocumento2 = Convert.ToInt32(cboDocumento2.EditValue);
                    objMovimientoCaja.NumeroDocumento2 = txtNumeroDocumento2.Text.Trim();
                    objMovimientoCaja.Placa = txtPlaca.Text;
                    objMovimientoCaja.IdSolicitudPrestamo = IdSolicitudPrestamo;
                    objMovimientoCaja.UsuarioRegistro = Parametros.strUsuarioLogin;
                    objMovimientoCaja.FechaRegistro = DateTime.Now;
                    objMovimientoCaja.UsuarioModifica = Parametros.strUsuarioLogin;
                    objMovimientoCaja.FechaModifica = DateTime.Now;
                    objMovimientoCaja.FlagEstado = true;
                    objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;


                    if (pOperacion == Operacion.Nuevo)
                    {
                        PersonaBE objPersona = new PersonaBE();
                        objPersona = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(cboPersonaAutoriza.EditValue));
                        if (objPersona.IdCargo == Parametros.intSupervisoraVentaPiso)
                        {
                            //string Usuario = Parametros.strUsuarioLogin;
                            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                            frmAutoriza.ShowDialog();
                            if (frmAutoriza.Edita)
                            {
                                if (objPersona.IdPersona == frmAutoriza.IdPersona || frmAutoriza.Usuario == "master")
                                {
                                    int IdMovimientoCaja = 0;
                                    IdMovimientoCaja = objBL_MovimientoCaja.Inserta(objMovimientoCaja);
                                    if (lstHoraExtra != null)
                                    {
                                        foreach (var item in lstHoraExtra)
                                        {
                                            HoraExtraBL ojbBL_HoraExtra = new HoraExtraBL();
                                            ojbBL_HoraExtra.ActualizaMovimientoCaja(item.IdHoraExtra, IdMovimientoCaja);
                                        }
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Cursor = Cursors.Default;
                                    return;
                                }
                            }
                            else
                            {
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            int IdMovimientoCaja = 0;
                            IdMovimientoCaja = objBL_MovimientoCaja.Inserta(objMovimientoCaja);
                            if (lstHoraExtra != null)
                            {
                                foreach (var item in lstHoraExtra)
                                {
                                    HoraExtraBL ojbBL_HoraExtra = new HoraExtraBL();
                                    ojbBL_HoraExtra.ActualizaMovimientoCaja(item.IdHoraExtra, IdMovimientoCaja);
                                }
                            }
                        }
                    }
                    else
                    {
                        objBL_MovimientoCaja.Actualiza(objMovimientoCaja);
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
                txtNumeroDocumento2.Select();
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
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.TipoBusqueda = 0;
                //frm.Title = "Búsqueda de Persona sin Usuario";
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;
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

            if (cboCaja.Visible == true)
            {
                if (cboCaja.Text.Trim().ToString() == "")
                {
                    strMensaje = strMensaje + "- Seleccione la caja.\n";
                    flag = true;
                }
            }

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

            //Validar préstamo
            if (IdSolicitudPrestamo > 0 || IdHoraExtra>0)
            {
                if (txtNumeroDocumento.Text.Trim().Length == 0)
                {
                    strMensaje = strMensaje + "- Ingrese el N° de Recibo de Egreso.\n";
                    flag = true;
                }
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
        private DataTable CargarTipoDocumentoEgreso()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 93;
            dr["Descripcion"] = "RDC";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 60;
            dr["Descripcion"] = "RDE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 105;
            dr["Descripcion"] = "ICA";
            dt.Rows.Add(dr);
            return dt;
        }

        private void BloquearEdicionImporte()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
            {
                txtImporteSoles.Properties.ReadOnly = false;
                txtImporteDolares.Properties.ReadOnly = false;
            }
            else
            {
                if (Convert.ToDateTime(deFecha.EditValue) < DateTime.Now.Date)
                {
                    txtImporteSoles.Properties.ReadOnly = true;
                    txtImporteDolares.Properties.ReadOnly = true;
                }
            }
        }
        private DataTable CargarTipoTarjeta()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "";
            dr["Descripcion"] = "NINGUNO";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "C";
            dr["Descripcion"] = "CREDITO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "D";
            dr["Descripcion"] = "DEBITO";
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroPrestamo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SolicitudPrestamoBE objE_Solicitud = new SolicitudPrestamoBE(); 
                objE_Solicitud = new SolicitudPrestamoBL().SeleccionaNumero(Parametros.intEmpresaId,Convert.ToInt32(txtPeriodo.EditValue), Parametros.intTipoDocPrestamo, txtNumeroPrestamo.Text.Trim());
                if (objE_Solicitud != null)
                {
                    if (objE_Solicitud.FechaSolicitud <= Convert.ToDateTime("28/11/2016"))
                    {
                        XtraMessageBox.Show("El préstamo ya fue cobrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (objE_Solicitud.Metodo == 3)
                    {
                        XtraMessageBox.Show("No se puede cobrar FALTANTE DE CAJA", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    MovimientoCajaBE objE_MovimientoCaja = null;
                    objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaSolicitudPrestamo(objE_Solicitud.IdSolicitudPrestamo);
                    if (objE_MovimientoCaja != null)
                    {
                        XtraMessageBox.Show("El préstamo ya fue cobrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    IdSolicitudPrestamo = objE_Solicitud.IdSolicitudPrestamo;
                    IdPersona = objE_Solicitud.IdPersona;
                    txtPersona.Text = objE_Solicitud.DescPersona;
                    txtImporteSoles.EditValue = objE_Solicitud.TotalPago;
                    if (objE_Solicitud.Metodo == 1)
                    {
                        txtConcepto.Text = "PRESTAMO N°" + txtNumeroPrestamo.Text;
                    }
                    else
                    {
                        txtConcepto.Text = "ADELANTO DE SUELDO N°" + txtNumeroPrestamo.Text;
                    }

                    txtConcepto.Properties.ReadOnly = true;

                    //cboMotivoEgreso.Properties.ReadOnly = true;
                    //btnBuscar.Enabled = true;

                    //Conversion
                    if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
                    {
                        decimal ImporteDolares = 0;
                        ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                        txtImporteDolares.EditValue = ImporteDolares;
                    }

                    //grdDatos.Enabled = false;
                    cboDocumento2.EditValue = Parametros.intTipoDocReciboEgreso;
                    cboDocumento.EditValue = Parametros.intTipoDocReciboEgreso;
                    txtNumeroDocumento2.Text = "";
                    

                    cboDocumento2.Properties.ReadOnly = true;
                    //txtNumeroDocumento.Properties.ReadOnly = true;
                    btnBuscarPersona.Enabled = false;
                    txtConcepto.Properties.ReadOnly = true;
                    cboMoneda.Properties.ReadOnly = true;
                    optPago.Enabled = false;
                    optRetiro.Checked = true;
                    txtTipoCambio.ReadOnly = true;
                    txtImporteSoles.Properties.ReadOnly = true;
                    txtImporteDolares.Properties.ReadOnly = true;
                    txtIdHoraExtra.Properties.ReadOnly = true;
                    txtNumeroPrestamo.Properties.ReadOnly = true;
                    txtNumeroDocumento.Select();
                }
            }
        }

        private void txtImporteSoles_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
            {
                decimal ImporteDolares = 0;
                ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteDolares.EditValue = ImporteDolares;
            }
        }

        private void txtImporteDolares_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtImporteDolares.EditValue) > 0)
            {
                decimal ImporteSoles = 0;
                ImporteSoles = Convert.ToDecimal(txtImporteDolares.EditValue) * Convert.ToDecimal(txtTipoCambio.EditValue);
                txtImporteSoles.EditValue = ImporteSoles;
            }
        }

        private void txtNumeroProyecto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información de la Dis_ProyectoServicio
                    Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = null;
                    objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProyecto.Text.Trim());
                    if (objE_Dis_ProyectoServicio != null)
                    {
                        IdDis_ProyectoServicio = objE_Dis_ProyectoServicio.IdDis_ProyectoServicio;
                        txtNumeroProyecto.Text = objE_Dis_ProyectoServicio.Numero;
                        IdPersona = objE_Dis_ProyectoServicio.IdAsesor;
                        txtPersona.Text = objE_Dis_ProyectoServicio.DescAsesor;
                        cboMoneda.EditValue = objE_Dis_ProyectoServicio.IdMoneda;
                        txtTipoCambio.EditValue = objE_Dis_ProyectoServicio.TipoCambio;
                        txtObservacion.Text = "Proy. N° " + objE_Dis_ProyectoServicio.Numero;

                        txtNumeroDocumento.Text = "";

                        txtConcepto.Focus();


                    }
                    else
                    {
                        XtraMessageBox.Show("El número de proyecto no existe, Verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIdHoraExtra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Verificar Cobro
                if (txtIdHoraExtra.Text.ToString().Length == 0)
                {
                    return;
                }
                PagosBE objE_Pago = null;
                objE_Pago = new PagosBL().SeleccionaHoraExtra(Parametros.intEmpresaId, Convert.ToInt32(txtIdHoraExtra.EditValue));
                if (objE_Pago != null)
                {
                    XtraMessageBox.Show("La hora extra fue cobrada por Concepto: " + objE_Pago.Concepto + " en " + objE_Pago.DescTienda + " el día " + objE_Pago.Fecha.ToShortDateString() + " en la Caja " + objE_Pago.DescCaja, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                HoraExtraBE objE_HoraExtra = null;
                objE_HoraExtra = new HoraExtraBL().Selecciona(Convert.ToInt32(txtIdHoraExtra.EditValue));
                if (objE_HoraExtra != null)
                {
                    if (objE_HoraExtra.FlagAprobado)
                    {
                        IdHoraExtra = objE_HoraExtra.IdHoraExtra;
                        IdPersona = objE_HoraExtra.IdPersona;
                        txtPersona.Text = objE_HoraExtra.ApeNom;
                        txtImporteSoles.EditValue = objE_HoraExtra.Importe;
                        txtConcepto.Text = "PAGO HHEE N° " + txtIdHoraExtra.Text + " - " + txtPersona.Text;
                        txtConcepto.Properties.ReadOnly = true;
                        btnBuscarPersona.Enabled = true;

                        //Conversion
                        if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
                        {
                            decimal ImporteDolares = 0;
                            ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                            txtImporteDolares.EditValue = ImporteDolares;
                        }
                        //cboMotivoEgreso.EditValue = 2;
                        txtIdHoraExtra.Properties.ReadOnly = true;
                        txtNumeroPrestamo.Properties.ReadOnly = true;
                        txtImporteSoles.Properties.ReadOnly = true;
                        txtImporteDolares.Properties.ReadOnly = true;
                        txtNumeroDocumento.Select();
                    }
                    else
                    {
                        XtraMessageBox.Show("La hora extra no está aprobada por Recursos Humanos, Favor de consultar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }

        private void btnBuscarHoraExtra_Click(object sender, EventArgs e)
        {
            if (IdPersona == 0)
            {
                XtraMessageBox.Show("No se puede mostrar las horas, Ud. Debe seleccionar la persona a la que desea pagar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //List<HoraExtraBE> lstHoraExtra = null;
            lstHoraExtra = new HoraExtraBL().ListaPersonaPendientePago(IdPersona);
            if (lstHoraExtra != null)
            {
                decimal Total = 0;
                string NumeroExtra = "";
                foreach (var item in lstHoraExtra)
                {
                    Total = Total + item.Importe;
                    NumeroExtra = NumeroExtra + " N°" + item.IdHoraExtra ;
                }

                txtImporteSoles.EditValue = Total;
                txtConcepto.Text = "PAGO HHEE N° " + txtIdHoraExtra.Text + " - " + txtPersona.Text;
                txtObservacion.Text = NumeroExtra;
                txtConcepto.Properties.ReadOnly = true;
                btnBuscarPersona.Enabled = true;

                //Conversion
                if (Convert.ToDecimal(txtImporteSoles.EditValue) > 0)
                {
                    decimal ImporteDolares = 0;
                    ImporteDolares = Convert.ToDecimal(txtImporteSoles.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                    txtImporteDolares.EditValue = ImporteDolares;
                }
                //cboMotivoEgreso.EditValue = 2;
                txtIdHoraExtra.Properties.ReadOnly = true;
                txtNumeroPrestamo.Properties.ReadOnly = true;
                txtImporteSoles.Properties.ReadOnly = true;
                txtImporteDolares.Properties.ReadOnly = true;
                txtNumeroDocumento.Select();

            }
        }


    }
}