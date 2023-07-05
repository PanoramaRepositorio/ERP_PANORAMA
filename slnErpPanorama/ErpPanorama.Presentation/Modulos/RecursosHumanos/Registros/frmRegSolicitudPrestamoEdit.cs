using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegSolicitudPrestamoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CSolicitudPrestamoDetalle> mListaSolicitudPrestamoDetalleOrigen = new List<CSolicitudPrestamoDetalle>();
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

        #endregion

        #region "Eventos"

        public frmRegSolicitudPrestamoEdit()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudPrestamoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            deFechaInicio.EditValue = DateTime.Now.AddDays(15);
            //deFechaInicio.EditValue = Convert.ToDateTime("01/10/2015");
            
            BSUtils.LoaderLook(cboFormaPago, CargarFormaPago(), "Descripcion", "Id", true);
            cboFormaPago.EditValue = 24;
            BSUtils.LoaderLook(cboMetodo, CargarMetodo(), "Descripcion", "Id", true);
            cboMetodo.EditValue = 1;

            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;
            //BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
            


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Solicitud de Préstamo - Nuevo";

                gvSolicitudPrestamoDetalle.Columns[6].OptionsColumn.AllowEdit = true;
                gvSolicitudPrestamoDetalle.Columns[6].OptionsColumn.AllowFocus = true;
                gvSolicitudPrestamoDetalle.Columns[7].OptionsColumn.AllowEdit = true;
                gvSolicitudPrestamoDetalle.Columns[7].OptionsColumn.AllowFocus = true;

                ObtenerCorrelativo();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Solicitud de Préstamo - Modificar";

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
                deFechaInicio.Properties.ReadOnly = true;
                txtObservacion.Properties.ReadOnly = true;
                txtMotivo.Properties.ReadOnly = true;
                btnGrabar.Enabled = false;
            }

            CargaSolicitudPrestamoDetalle();
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
                    objSolicitudPrestamo.IdTipoDocumento = Parametros.intTipoDocPrestamo;
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

                    if (Convert.ToInt32(cboMetodo.EditValue) == 3)
                    {
                        objSolicitudPrestamo.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMinorista);
                        objSolicitudPrestamo.FechaCaja = Convert.ToDateTime(deFechaCaja.DateTime.ToShortDateString());
                        objSolicitudPrestamo.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    }

                    //SolicitudPrestamo Detalle
                    List<SolicitudPrestamoDetalleBE> lstSolicitudPrestamoDetalle = new List<SolicitudPrestamoDetalleBE>();

                    foreach (var item in mListaSolicitudPrestamoDetalleOrigen)
                    {
                        SolicitudPrestamoDetalleBE objE_SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBE();
                        objE_SolicitudPrestamoDetalle.IdSolicitudPrestamo = item.IdSolicitudPrestamo;
                        objE_SolicitudPrestamoDetalle.IdSolicitudPrestamoDetalle = item.IdSolicitudPrestamoDetalle;
                        objE_SolicitudPrestamoDetalle.NumeroCuota = item.NumeroCuota;
                        objE_SolicitudPrestamoDetalle.Fecha = item.Fecha;
                        objE_SolicitudPrestamoDetalle.Concepto = item.Concepto;
                        objE_SolicitudPrestamoDetalle.FechaPago = item.FechaPago;
                        //objE_SolicitudPrestamoDetalle.FechaPago = item.FechaPago == Convert.ToDateTime("01/01/2000") ? (DateTime?)null : item.FechaPago;
                        objE_SolicitudPrestamoDetalle.FechaVencimiento = item.FechaVencimiento; ;
                        objE_SolicitudPrestamoDetalle.Capital = item.Capital;
                        objE_SolicitudPrestamoDetalle.Interes = item.Interes;
                        objE_SolicitudPrestamoDetalle.Importe = item.Importe;
                        objE_SolicitudPrestamoDetalle.TipoMovimiento = item.TipoMovimiento;
                        objE_SolicitudPrestamoDetalle.IdPersona = IdPersona;
                        objE_SolicitudPrestamoDetalle.FlagEstado = true;
                        objE_SolicitudPrestamoDetalle.TipoOper = item.TipoOper;
                        objE_SolicitudPrestamoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudPrestamoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstSolicitudPrestamoDetalle.Add(objE_SolicitudPrestamoDetalle);
                    }

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

        private void gvSolicitudPrestamoDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void gvSolicitudPrestamoDetalle_RowClick(object sender, RowClickEventArgs e)
        {

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

                    //Buscar Saldo anterior
                    List<SolicitudPrestamoBE> lst_Solicitud = null;
                    lst_Solicitud = new SolicitudPrestamoBL().ListaPersona(IdPersona);
                    if (lst_Solicitud.Count > 0)
                    {
                        txtSaldoAnterior.EditValue = lst_Solicitud[0].Saldo;
                    }
                    else
                    {
                        txtSaldoAnterior.EditValue = 0;
                    }
                    

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvSolicitudPrestamoDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvSolicitudPrestamoDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["TipoMovimiento"]);
                    if (objDocRetiro != null)
                    {
                        string TipoMovimiento = objDocRetiro.ToString();
                        if (TipoMovimiento == "A")
                        {
                            e.Appearance.BackColor = Color.GreenYellow;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroCuotas_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotales();

            //if (Convert.ToDecimal(txtTotalPagar.EditValue) > 0 && Convert.ToDecimal(txtNumeroCuotas.EditValue) > 0)
            //{
            //    txtCuota.EditValue = Convert.ToDecimal(txtTotalPagar.EditValue) / Convert.ToInt32(txtNumeroCuotas.EditValue);

            //    AgregaCalculoCuota();
            //}
            ////if (Convert.ToDecimal(txtNumeroCuotas.EditValue) == 0)
            ////{
            ////    txtNumeroCuotas.EditValue = 1;
            ////}
        }

        private void txtImporte_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotales();
            //if (Convert.ToDecimal(txtImporte.EditValue) > 0)
            //{
            //    txtTotalPagar.EditValue = Convert.ToDecimal(txtImporte.EditValue) * (1 + (Convert.ToDecimal(txtInteres.EditValue) / 100));
            //}
        }

        private void txtInteres_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotales();
            //if (Convert.ToDecimal(txtImporte.EditValue) > 0 && Convert.ToDecimal(txtInteres.EditValue) > 0)
            //{
            //    txtTotalPagar.EditValue = Convert.ToDecimal(txtImporte.EditValue) * (1 + (Convert.ToDecimal(txtInteres.EditValue) / 100));
            //}
            //else
            //{
            //    txtTotalPagar.EditValue = txtImporte.EditValue;
            //}

        }

        private void txtImporte_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtInteres_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
                txtNumeroCuotas.Select();
            }
        }

        private void txtNumeroCuotas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
                cboFormaPago.Select();
            }
        }

        private void cboFormaPago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //calcular()
            }
        }

        private void cboFormaPago_EditValueChanged(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            try
            {
                if (Convert.ToDecimal(txtImporte.EditValue) > 0)
                {
                    txtTotalPagar.EditValue = Convert.ToDecimal(txtImporte.EditValue) * (1 + (Convert.ToDecimal(txtInteres.EditValue) / 100));
                }

                if (Convert.ToDecimal(txtNumeroCuotas.EditValue) == 0) txtNumeroCuotas.EditValue = 1;

                if (Convert.ToDecimal(txtTotalPagar.EditValue) > 0 && Convert.ToDecimal(txtNumeroCuotas.EditValue) > 0)
                {
                    txtCuota.EditValue = Convert.ToDecimal(txtTotalPagar.EditValue) / Convert.ToInt32(txtNumeroCuotas.EditValue);
                }

                if (Convert.ToDecimal(txtImporte.EditValue) > 0 && Convert.ToDecimal(txtInteres.EditValue) > 0)
                {
                    txtTotalPagar.EditValue = Convert.ToDecimal(txtImporte.EditValue) * (1 + (Convert.ToDecimal(txtInteres.EditValue) / 100));
                }
                else
                {
                    txtTotalPagar.EditValue = txtImporte.EditValue;
                }

                if (Convert.ToDecimal(txtImporte.EditValue) > 0)
                {
                    AgregaCalculoCuota(); 
                }
               

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //try
            //{

            //    //decimal deValorVenta = 0;
            //    //decimal deTotal = 0;

            //    decimal CantidadTotal = 0;
            //    decimal CantidadVentaTotal = 0;

            //    if (mListaSolicitudPrestamoDetalleOrigen.Count > 0)
            //    {
            //        foreach (var item in mListaSolicitudPrestamoDetalleOrigen)
            //        {
            //            //deValorVenta = item.Precio;
            //            //deTotal = deTotal + deValorVenta;

            //            CantidadTotal = CantidadTotal + item.Cantidad;
            //            CantidadVentaTotal += item.CantidadVenta;

            //        }

            //        //txtTotalVenta.EditValue = Math.Round(deTotal, 2);
            //        txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
            //        txtTotalVenta.EditValue = Math.Round(CantidadVentaTotal, 2);

            //    }
            //    else
            //    {
            //        txtTotalCantidad.EditValue = 0;
            //        txtTotalVenta.EditValue = 0;
            //    }

            //    lblTotalRegistros.Text = mListaSolicitudPrestamoDetalleOrigen.Count.ToString() + " Registros encontrados";

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaSolicitudPrestamoDetalle()
        {
            decimal TotalSaldo = 0;
            List<SolicitudPrestamoDetalleBE> lstTmpSolicitudPrestamoDetalle = null;
            lstTmpSolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBL().ListaTodosActivo(IdSolicitudPrestamo);

            foreach (SolicitudPrestamoDetalleBE item in lstTmpSolicitudPrestamoDetalle)
            {
                CSolicitudPrestamoDetalle objE_SolicitudPrestamoDetalle = new CSolicitudPrestamoDetalle();
                objE_SolicitudPrestamoDetalle.IdSolicitudPrestamo = item.IdSolicitudPrestamo;
                objE_SolicitudPrestamoDetalle.IdSolicitudPrestamoDetalle = item.IdSolicitudPrestamoDetalle;
                objE_SolicitudPrestamoDetalle.NumeroCuota = item.NumeroCuota;
                objE_SolicitudPrestamoDetalle.Fecha = item.Fecha;
                objE_SolicitudPrestamoDetalle.Concepto = item.Concepto;
                objE_SolicitudPrestamoDetalle.FechaPago = item.FechaPago;
                //objE_SolicitudPrestamoDetalle.FechaPago = item.FechaPago == 0 ? (DateTime?)null : item.FechaPago;
                objE_SolicitudPrestamoDetalle.FechaVencimiento = item.FechaVencimiento;
                objE_SolicitudPrestamoDetalle.Capital = item.Capital;
                objE_SolicitudPrestamoDetalle.Interes = item.Interes;
                objE_SolicitudPrestamoDetalle.Importe = item.Importe;
                objE_SolicitudPrestamoDetalle.TipoMovimiento = item.TipoMovimiento;
                objE_SolicitudPrestamoDetalle.TipoOper = item.TipoOper;
                mListaSolicitudPrestamoDetalleOrigen.Add(objE_SolicitudPrestamoDetalle);

                TotalSaldo = TotalSaldo + item.Importe;
            }

            bsListado.DataSource = mListaSolicitudPrestamoDetalleOrigen;
            gcSolicitudPrestamoDetalle.DataSource = bsListado;
            gcSolicitudPrestamoDetalle.RefreshDataSource();

            lblTotalRegistros.Text = mListaSolicitudPrestamoDetalleOrigen.Count.ToString() + " Registros encontrados";
            txtSaldo.EditValue = TotalSaldo;
            //CalculaTotales();
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

            if (Convert.ToInt32(cboMetodo.EditValue) == 3)
            {
                if (deFechaCaja.Text == "")
                {
                    strMensaje = strMensaje + "- Ingresar la fecha de Caja.\n";
                    flag = true;
                }
            }

            if (mListaSolicitudPrestamoDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el SolicitudPrestamo, mientra no haya productos.\n";
                flag = true;
            }

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
            dr["Descripcion"] = "PRESTAMO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "ADELANTO DE SUELDO";//AMORTIZADO
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
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPrestamo, Parametros.intPeriodo);
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

        private void AgregaCalculoCuota()
        {
            try
            {
                if (Convert.ToInt32(txtNumeroCuotas.EditValue) == 0)
                {
                    XtraMessageBox.Show("Ingresar el número de cuotas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mListaSolicitudPrestamoDetalleOrigen.Clear();
                    return;
                }

                if (Convert.ToDecimal(txtTotalPagar.EditValue) == 0)
                {
                    XtraMessageBox.Show("Ingresar el Importe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mListaSolicitudPrestamoDetalleOrigen.Clear();
                    return;
                }

                if (deFechaInicio.Text == "")
                {
                    XtraMessageBox.Show("Ingresar la fecha de Inicio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mListaSolicitudPrestamoDetalleOrigen.Clear();
                    return;
                }

                int Cuotas = 1;
                Cuotas = Convert.ToInt32(txtNumeroCuotas.EditValue);

                mListaSolicitudPrestamoDetalleOrigen.Clear();

                #region "Fecha Vencimiento"

                //valores de fecha Vencimiento
                int Dias = 0;
                switch (Convert.ToInt32(cboFormaPago.EditValue))
                {
                    case 1:
                        Dias = 360;
                        break;
                    case 2:
                        Dias = 180;
                        break;
                    case 3:
                        Dias = 120;
                        break;
                    case 4:
                        Dias = 90;
                        break;
                    case 6:
                        Dias = 60;
                        break;
                    case 12:
                        Dias = 30;
                        break;
                    case 24:
                        Dias = 15;
                        break;
                    default:
                        Dias = 15;
                        break;
                }
                #endregion

                int TotalDias = Dias;
                DateTime FechaInicio = deFechaInicio.DateTime.AddDays(-Dias);

                if (mListaSolicitudPrestamoDetalleOrigen.Count == 0)
                {
                    for (int i = 1; i <= Cuotas; i++)
                    {
                        gvSolicitudPrestamoDetalle.AddNewRow();
                        //gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "IdEmpresa", );
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "IdSolicitudPrestamo", 0);
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "IdSolicitudPrestamoDetalle", 0);
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "NumeroCuota", i);
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "Fecha", DateTime.Now.ToShortDateString());
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "FechaPago", null);
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "Concepto", cboMetodo.Text);
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "FechaVencimiento", FechaInicio.AddDays(TotalDias).ToShortDateString());//FechaInicio.DateTime.AddDays(TotalDias));
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "Capital", Convert.ToDecimal(txtCuota.EditValue));
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "Interes", 0);
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "Importe", Convert.ToDecimal(txtCuota.EditValue));
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "TipoMovimiento", "C");
                        gvSolicitudPrestamoDetalle.SetRowCellValue(gvSolicitudPrestamoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        gvSolicitudPrestamoDetalle.UpdateCurrentRow();

                        TotalDias = TotalDias + Dias;
                    }

                    ///CalculaTotales();

                    return;
                }





            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public class CSolicitudPrestamoDetalle
        {
            public Int32 IdSolicitudPrestamo { get; set; }
            public Int32 IdSolicitudPrestamoDetalle { get; set; }
            public Int32 NumeroCuota { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime? FechaPago { get; set; }
            public String Concepto { get; set; }
            public DateTime? FechaVencimiento { get; set; }
            public Decimal Capital { get; set; }
            public Decimal Interes { get; set; }
            public Decimal Importe { get; set; }
            public String TipoMovimiento { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Int32 TipoOper { get; set; }

            public CSolicitudPrestamoDetalle()
            {

            }
        }



        private void cboMetodo_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMetodo.EditValue) == 2)
            {
                txtNumeroCuotas.EditValue = 1;
                txtInteres.EditValue = 0;
                cboFormaPago.EditValue = 24;
                txtNumeroCuotas.Properties.ReadOnly = true;
                txtInteres.Properties.ReadOnly = true;
                cboFormaPago.Properties.ReadOnly = true;
            }
            else
            {
                txtNumeroCuotas.Properties.ReadOnly = false;
                txtInteres.Properties.ReadOnly = false;
                cboFormaPago.Properties.ReadOnly = false;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                if (Convert.ToInt32(cboMetodo.EditValue) == 3)
                    gcCaja.Visible = true;
                else
                    gcCaja.Visible = false;
            }
        }

        private void cboFechaInicio_EditValueChanged(object sender, EventArgs e)
        {

            CalculaTotales();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
        }
    }
}