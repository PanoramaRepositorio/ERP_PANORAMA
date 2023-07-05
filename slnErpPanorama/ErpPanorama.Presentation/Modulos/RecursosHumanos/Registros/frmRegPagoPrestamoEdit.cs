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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPagoPrestamoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public List<CSolicitudPrestamoDetalle> mListaSolicitudPrestamoDetalleOrigen = new List<CSolicitudPrestamoDetalle>();//
        private List<PreventaDetalleBE> lst_SolicitudPrestamoDetalleMsg = new List<PreventaDetalleBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdSolicitudPrestamo = 0;

        public int IdSolicitudPrestamo
        {
            get { return _IdSolicitudPrestamo; }
            set { _IdSolicitudPrestamo = value; }
        }

        public SolicitudPrestamoBE pSolicitudPrestamoBE { get; set; }

        public Operacion pOperacion;

        private int IdPersona = 0;
        private int IdSolicitudPrestamoDetalle = 0;

        #endregion

        #region "Eventos"

        public frmRegPagoPrestamoEdit()
        {
            InitializeComponent();
        }

        private void frmRegPagoPrestamoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboFormaPago, CargarFormaPago(), "Descripcion", "Id", true);
            cboFormaPago.EditValue = 24;
            BSUtils.LoaderLook(cboMetodo, CargarMetodo(), "Descripcion", "Id", true);
            cboMetodo.EditValue = 1;


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Pago de Préstamo - Nuevo";

                ObtenerCorrelativo();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Pago de Préstamo - Modificar";

                SolicitudPrestamoBE objE_SolicitudPrestamo = new SolicitudPrestamoBE();
                objE_SolicitudPrestamo = new SolicitudPrestamoBL().Selecciona(Parametros.intEmpresaId, IdSolicitudPrestamo);
                txtNumero.EditValue = objE_SolicitudPrestamo.Numero;
                deFecha.EditValue = objE_SolicitudPrestamo.FechaSolicitud;
                IdPersona = objE_SolicitudPrestamo.IdPersona;
                txtPersona.EditValue = objE_SolicitudPrestamo.DescPersona;
                txtImporte.EditValue = objE_SolicitudPrestamo.Importe;
                txtInteres.EditValue = objE_SolicitudPrestamo.Interes;
                txtTotalPagar.EditValue = objE_SolicitudPrestamo.TotalPago;
                txtNumeroCuotas.EditValue = objE_SolicitudPrestamo.NumeroCuotas;
                txtCuota.EditValue = objE_SolicitudPrestamo.Cuota;
                cboMetodo.EditValue = objE_SolicitudPrestamo.Metodo;
                cboFormaPago.EditValue = objE_SolicitudPrestamo.TipoCuota;
                txtMotivo.EditValue = objE_SolicitudPrestamo.Motivo;
                txtObservacion.EditValue = objE_SolicitudPrestamo.Observacion;
                txtSaldoAnterior.EditValue = objE_SolicitudPrestamo.SaldoAnterior;

                cboFormaPago.Properties.ReadOnly = true;
                cboMetodo.Properties.ReadOnly = true;
                txtImporte.Properties.ReadOnly = true;
                txtCuota.Properties.ReadOnly = true;
                txtInteres.Properties.ReadOnly = true;
                txtNumeroCuotas.Properties.ReadOnly = true;
                btnBuscar.Enabled = false;
                deFecha.Properties.ReadOnly = true;
                //txtObservacion.Properties.ReadOnly = true;
                txtMotivo.Properties.ReadOnly = true;
                //btnGrabar.Enabled = false;

                CargaSolicitudPrestamoDetalle();
            }

            txtImporte.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SolicitudPrestamoBL objBL_SolicitudPrestamo = new SolicitudPrestamoBL();
                    SolicitudPrestamoBE objSolicitudPrestamo = new SolicitudPrestamoBE();
                    objSolicitudPrestamo.IdSolicitudPrestamo = IdSolicitudPrestamo;
                    objSolicitudPrestamo.IdTipoDocumento = Parametros.intTipoDocReciboDescuentoPlanilla;
                    objSolicitudPrestamo.Periodo = Parametros.intPeriodo;
                    objSolicitudPrestamo.Numero = txtNumero.Text;
                    objSolicitudPrestamo.FechaSolicitud = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());//Convert.ToDateTime(deFecha.EditValue);
                    objSolicitudPrestamo.IdPersona = IdPersona;
                    objSolicitudPrestamo.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objSolicitudPrestamo.Interes = Convert.ToDecimal(txtInteres.EditValue);
                    objSolicitudPrestamo.TotalPago = Convert.ToDecimal(txtTotalPagar.EditValue);
                    objSolicitudPrestamo.SaldoAnterior = Convert.ToDecimal(txtSaldoAnterior.EditValue);
                    objSolicitudPrestamo.NumeroCuotas = Convert.ToInt32(txtNumeroCuotas.EditValue);
                    objSolicitudPrestamo.TipoCuota = Convert.ToInt32(cboFormaPago.EditValue);
                    objSolicitudPrestamo.Cuota = Convert.ToDecimal(txtCuota.EditValue);
                    objSolicitudPrestamo.Metodo = Convert.ToInt32(cboMetodo.EditValue);
                    objSolicitudPrestamo.Observacion = txtObservacion.Text;
                    objSolicitudPrestamo.IdPersonaAprueba = Parametros.intPersonaId;
                    objSolicitudPrestamo.FlagAprobado = true;
                    objSolicitudPrestamo.IdSituacion = 0;
                    objSolicitudPrestamo.Motivo = txtMotivo.Text;
                    objSolicitudPrestamo.FlagEstado = true;
                    objSolicitudPrestamo.Usuario = Parametros.strUsuarioLogin;
                    objSolicitudPrestamo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSolicitudPrestamo.IdEmpresa = Parametros.intEmpresaId;

                    //SolicitudPrestamo Detalle
                    List<SolicitudPrestamoDetalleBE> lstSolicitudPrestamoDetalle = new List<SolicitudPrestamoDetalleBE>();

                    //foreach (var item in mListaSolicitudPrestamoDetalleOrigen)
                    //{
                        SolicitudPrestamoDetalleBE objE_SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBE();
                        objE_SolicitudPrestamoDetalle.IdSolicitudPrestamo = IdSolicitudPrestamo;
                        objE_SolicitudPrestamoDetalle.IdSolicitudPrestamoDetalle = IdSolicitudPrestamoDetalle;
                        objE_SolicitudPrestamoDetalle.NumeroCuota = 1;// item.NumeroCuota;
                        objE_SolicitudPrestamoDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_SolicitudPrestamoDetalle.Concepto = txtConcepto.Text.Trim(); //"AMORTIZACION DE DEUDA";
                        objE_SolicitudPrestamoDetalle.FechaPago = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        //objE_SolicitudPrestamoDetalle.FechaPago = item.FechaPago == Convert.ToDateTime("01/01/2000") ? (DateTime?)null : item.FechaPago;
                        objE_SolicitudPrestamoDetalle.FechaVencimiento = null;
                        objE_SolicitudPrestamoDetalle.Capital = Convert.ToDecimal(txtImporte.EditValue);
                        objE_SolicitudPrestamoDetalle.Interes = 0;
                        objE_SolicitudPrestamoDetalle.Importe = Convert.ToDecimal(txtTotalPagar.EditValue);
                        objE_SolicitudPrestamoDetalle.TipoMovimiento = "A";
                        objE_SolicitudPrestamoDetalle.IdPersona = IdPersona;
                        objE_SolicitudPrestamoDetalle.FlagEstado = true;
                        objE_SolicitudPrestamoDetalle.TipoOper = 1;
                        objE_SolicitudPrestamoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudPrestamoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstSolicitudPrestamoDetalle.Add(objE_SolicitudPrestamoDetalle);
                    //}

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_SolicitudPrestamo.Inserta(objSolicitudPrestamo, lstSolicitudPrestamoDetalle);
                    }
                    else
                    {
                        objBL_SolicitudPrestamo.Actualiza(objSolicitudPrestamo, lstSolicitudPrestamoDetalle);
                    }

                    Cursor = Cursors.Default;

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


        private void btnBuscar_Click(object sender, EventArgs e)
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

                    txtImporte.Select();
                    ////Buscar Saldo anterior
                    //List<SolicitudPrestamoBE> lst_Solicitud = null;
                    //lst_Solicitud = new SolicitudPrestamoBL().ListaPersona(IdPersona);
                    //if (lst_Solicitud.Count > 0)
                    //{
                    //    txtSaldoAnterior.EditValue = lst_Solicitud[0].Saldo;
                    //}
                    //else
                    //{
                    //    txtSaldoAnterior.EditValue = 0;
                    //}


                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporte_EditValueChanged(object sender, EventArgs e)
        {
            txtTotalPagar.EditValue = txtImporte.EditValue;
        }


        #endregion

        #region "Metodos"


        private void CargaSolicitudPrestamoDetalle()
        {
            List<SolicitudPrestamoDetalleBE> lstTmpSolicitudPrestamoDetalle = null;
            lstTmpSolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBL().ListaTodosActivo(IdSolicitudPrestamo);

            foreach (SolicitudPrestamoDetalleBE item in lstTmpSolicitudPrestamoDetalle)
            {
                IdSolicitudPrestamoDetalle = item.IdSolicitudPrestamoDetalle;
                txtConcepto.Text = item.Concepto;
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (Convert.ToDecimal(txtImporte.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingresar Importe válido.\n";
                flag = true;
            }

            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "- Seleccionar personal.\n";
                flag = true;
            }

            if (txtConcepto.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingresar concepto.\n";
                flag = true;
            }

            //if (mListaSolicitudPrestamoDetalleOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Nos se puede generar el pago de Préstamo, mientras.\n";
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        private DataTable CargarFormaPago()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "ANUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "SEMESTRAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "CUATRIMESTRAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "TRIMESTRAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "BIMESTRAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "MENSUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 24;
            dr["Descripcion"] = "QUINCENAL";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarMetodo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "PAGO PRESTAMO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "PAGO ADELANTO DE SUELDO";//AMORTIZADO
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "FALTANTE DE CAJA";
            dt.Rows.Add(dr);
            return dt;
        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocReciboDescuentoPlanilla, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void deFecha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void cboMetodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.Select();
                //SendKeys.Send("{TAB}");
            }

        }

        private void txtImporte_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtConcepto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGrabar.Focus();
            }

        }







    }
}