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

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegPagoServicioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPagoServicioDetalle> mListaPagoServicioDetalleOrigen = new List<CPagoServicioDetalle>();
        private List<PreventaDetalleBE> lst_PagoServicioDetalleMsg = new List<PreventaDetalleBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPagoServicio = 0;

        public int IdPagoServicio
        {
            get { return _IdPagoServicio; }
            set { _IdPagoServicio = value; }
        }

        public PagoServicioBE pPagoServicioBE { get; set; }

        public Operacion pOperacion;

        private int? IdProveedor = 0;
        private int? IdBanco = 0;

        #endregion

        #region "Eventos"

        public frmRegPagoServicioEdit()
        {
            InitializeComponent();
        }

        private void frmRegPagoServicioEdit_Load(object sender, EventArgs e)
        {
            //deFecha.EditValue = DateTime.Now;
            //deFechaInicio.EditValue = DateTime.Now.AddDays(15);
            ////deFechaInicio.EditValue = Convert.ToDateTime("01/10/2015");

            //BSUtils.LoaderLook(cboFormaPago, CargarFormaPago(), "Descripcion", "Id", true);
            //cboFormaPago.EditValue = 24;
            //BSUtils.LoaderLook(cboTipoServicio, CargarMetodo(), "Descripcion", "Id", true);
            //cboTipoServicio.EditValue = 1;


            //if (pOperacion == Operacion.Nuevo)
            //{
            //    this.Text = "Solicitud de Préstamo - Nuevo";

            //    gvPagoServicioDetalle.Columns[6].OptionsColumn.AllowEdit = true;
            //    gvPagoServicioDetalle.Columns[6].OptionsColumn.AllowFocus = true;
            //    gvPagoServicioDetalle.Columns[7].OptionsColumn.AllowEdit = true;
            //    gvPagoServicioDetalle.Columns[7].OptionsColumn.AllowFocus = true;

            //    ObtenerCorrelativo();
            //}
            //else if (pOperacion == Operacion.Modificar)
            //{
            //    this.Text = "Solicitud de Préstamo - Modificar";

            //    //PagoServicioBE objE_PagoServicio = new PagoServicioBE();
            //    //objE_PagoServicio = new PagoServicioBL().Selecciona(IdPagoServicio);
            //    //txtNumero.EditValue = objE_PagoServicio.Numero;
            //    //deFecha.EditValue = objE_PagoServicio.Fecha;
            //    //IdProveedor = objE_PagoServicio.IdProveedor;
            //    //IdBanco = objE_PagoServicio.IdBanco;
            //    ////txtProveedor.EditValue = objE_PagoServicio.DescPersona;
            //    //txtImporte.EditValue = objE_PagoServicio.Importe;
            //    //txtInteres.EditValue = objE_PagoServicio.Interes;
            //    //txtTotalPagar.EditValue = objE_PagoServicio.TotalPago;
            //    //txtNumeroCuotas.EditValue = objE_PagoServicio.NumeroCuotas;
            //    //txtCuota.EditValue = objE_PagoServicio.Cuota;
            //    //cboTipoServicio.EditValue = objE_PagoServicio.Metodo;
            //    //cboFormaPago.EditValue = objE_PagoServicio.TipoCuota;
            //    //txtObservacion.EditValue = objE_PagoServicio.Observacion;
            //    //txtSaldoAnterior.EditValue = objE_PagoServicio.SaldoAnterior;

            //    //cboFormaPago.Properties.ReadOnly = true;
            //    //cboTipoServicio.Properties.ReadOnly = true;
            //    //txtImporte.Properties.ReadOnly = true;
            //    //txtCuota.Properties.ReadOnly = true;
            //    //txtInteres.Properties.ReadOnly = true;
            //    //txtNumeroCuotas.Properties.ReadOnly = true;
            //    //btnBuscar.Enabled = false;
            //    //deFecha.Properties.ReadOnly = true;
            //    //deFechaInicio.Properties.ReadOnly = true;
            //    //txtObservacion.Properties.ReadOnly = true;
            //    //txtMotivo.Properties.ReadOnly = true;
            //    //btnGrabar.Enabled = false;
            //}

            //CargaPagoServicioDetalle();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (!ValidarIngreso())
            //    {
            //        PagoServicioBL objBL_PagoServicio = new PagoServicioBL();
            //        PagoServicioBE objPagoServicio = new PagoServicioBE();
            //        objPagoServicio.IdPagoServicio = IdPagoServicio;
            //        objPagoServicio.IdTipoDocumento = Parametros.intTipoDocPrestamo;
            //        objPagoServicio.Periodo = Parametros.intPeriodo;
            //        objPagoServicio.Numero = txtNumero.Text;
            //        objPagoServicio.FechaSolicitud = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());//Convert.ToDateTime(deFecha.EditValue);
            //        objPagoServicio.IdProveedor = IdProveedor;
            //        objPagoServicio.Importe = Convert.ToDecimal(txtImporte.EditValue);
            //        objPagoServicio.Interes = Convert.ToDecimal(txtInteres.EditValue);
            //        objPagoServicio.TotalPago = Convert.ToDecimal(txtTotalPagar.EditValue);
            //        objPagoServicio.SaldoAnterior = Convert.ToDecimal(txtSaldoAnterior.EditValue);
            //        objPagoServicio.NumeroCuotas = Convert.ToInt32(txtNumeroCuotas.EditValue);
            //        objPagoServicio.TipoCuota = Convert.ToInt32(cboFormaPago.EditValue);
            //        objPagoServicio.Cuota = Convert.ToDecimal(txtCuota.EditValue);
            //        objPagoServicio.Metodo = Convert.ToInt32(cboTipoServicio.EditValue);
            //        objPagoServicio.Observacion = txtObservacion.Text;
            //        objPagoServicio.IdProveedorAprueba = Parametros.intPersonaId;
            //        objPagoServicio.FlagAprobado = true;
            //        objPagoServicio.IdSituacion = 0;
            //        objPagoServicio.Motivo = txtMotivo.Text;
            //        objPagoServicio.FlagEstado = true;
            //        objPagoServicio.Usuario = Parametros.strUsuarioLogin;
            //        objPagoServicio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //        objPagoServicio.IdEmpresa = Parametros.intEmpresaId;

            //        //PagoServicio Detalle
            //        List<PagoServicioDetalleBE> lstPagoServicioDetalle = new List<PagoServicioDetalleBE>();

            //        foreach (var item in mListaPagoServicioDetalleOrigen)
            //        {
            //            PagoServicioDetalleBE objE_PagoServicioDetalle = new PagoServicioDetalleBE();
            //            objE_PagoServicioDetalle.IdPagoServicio = item.IdPagoServicio;
            //            objE_PagoServicioDetalle.IdPagoServicioDetalle = item.IdPagoServicioDetalle;
            //            objE_PagoServicioDetalle.NumeroCuota = item.NumeroCuota;
            //            objE_PagoServicioDetalle.Fecha = item.Fecha;
            //            objE_PagoServicioDetalle.Concepto = item.Concepto;
            //            objE_PagoServicioDetalle.FechaPago = item.FechaPago;
            //            //objE_PagoServicioDetalle.FechaPago = item.FechaPago == Convert.ToDateTime("01/01/2000") ? (DateTime?)null : item.FechaPago;
            //            objE_PagoServicioDetalle.FechaVencimiento = item.FechaVencimiento; ;
            //            objE_PagoServicioDetalle.Capital = item.Capital;
            //            objE_PagoServicioDetalle.Interes = item.Interes;
            //            objE_PagoServicioDetalle.Importe = item.Importe;
            //            objE_PagoServicioDetalle.TipoMovimiento = item.TipoMovimiento;
            //            objE_PagoServicioDetalle.IdProveedor = IdProveedor;
            //            objE_PagoServicioDetalle.FlagEstado = true;
            //            objE_PagoServicioDetalle.TipoOper = item.TipoOper;
            //            objE_PagoServicioDetalle.Usuario = Parametros.strUsuarioLogin;
            //            objE_PagoServicioDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            lstPagoServicioDetalle.Add(objE_PagoServicioDetalle);
            //        }

            //        if (pOperacion == Operacion.Nuevo)
            //        {
            //            objBL_PagoServicio.Inserta(objPagoServicio, lstPagoServicioDetalle);
            //        }
            //        else
            //        {
            //            objBL_PagoServicio.Actualiza(objPagoServicio, lstPagoServicioDetalle);
            //        }

            //        Cursor = Cursors.Default;

            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvPagoServicioDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void gvPagoServicioDetalle_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmBuscaPersona frm = new frmBuscaPersona();
            //    frm.TipoBusqueda = 0;
            //    //frm.Title = "Búsqueda de Persona sin Usuario";
            //    frm.ShowDialog();
            //    if (frm._Be != null)
            //    {
            //        IdProveedor = frm._Be.IdProveedor;
            //        txtProveedor.Text = frm._Be.ApeNom;

            //        //Buscar Saldo anterior
            //        List<PagoServicioBE> lst_Solicitud = null;
            //        lst_Solicitud = new PagoServicioBL().ListaPersona(IdProveedor);
            //        if (lst_Solicitud.Count > 0)
            //        {
            //            txtSaldoAnterior.EditValue = lst_Solicitud[0].Saldo;
            //        }
            //        else
            //        {
            //            txtSaldoAnterior.EditValue = 0;
            //        }


            //    }
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void gvPagoServicioDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPagoServicioDetalle.GetRow(e.RowHandle);

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
            //try
            //{
            //    if (Convert.ToDecimal(txtImporte.EditValue) > 0)
            //    {
            //        txtTotalPagar.EditValue = Convert.ToDecimal(txtImporte.EditValue) * (1 + (Convert.ToDecimal(txtInteres.EditValue) / 100));
            //    }

            //    if (Convert.ToDecimal(txtNumeroCuotas.EditValue) == 0) txtNumeroCuotas.EditValue = 1;

            //    if (Convert.ToDecimal(txtTotalPagar.EditValue) > 0 && Convert.ToDecimal(txtNumeroCuotas.EditValue) > 0)
            //    {
            //        txtCuota.EditValue = Convert.ToDecimal(txtTotalPagar.EditValue) / Convert.ToInt32(txtNumeroCuotas.EditValue);
            //    }

            //    if (Convert.ToDecimal(txtImporte.EditValue) > 0 && Convert.ToDecimal(txtInteres.EditValue) > 0)
            //    {
            //        txtTotalPagar.EditValue = Convert.ToDecimal(txtImporte.EditValue) * (1 + (Convert.ToDecimal(txtInteres.EditValue) / 100));
            //    }
            //    else
            //    {
            //        txtTotalPagar.EditValue = txtImporte.EditValue;
            //    }

            //    if (Convert.ToDecimal(txtImporte.EditValue) > 0)
            //    {
            //        AgregaCalculoCuota();
            //    }


            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            ////try
            ////{

            ////    //decimal deValorVenta = 0;
            ////    //decimal deTotal = 0;

            ////    decimal CantidadTotal = 0;
            ////    decimal CantidadVentaTotal = 0;

            ////    if (mListaPagoServicioDetalleOrigen.Count > 0)
            ////    {
            ////        foreach (var item in mListaPagoServicioDetalleOrigen)
            ////        {
            ////            //deValorVenta = item.Precio;
            ////            //deTotal = deTotal + deValorVenta;

            ////            CantidadTotal = CantidadTotal + item.Cantidad;
            ////            CantidadVentaTotal += item.CantidadVenta;

            ////        }

            ////        //txtTotalVenta.EditValue = Math.Round(deTotal, 2);
            ////        txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
            ////        txtTotalVenta.EditValue = Math.Round(CantidadVentaTotal, 2);

            ////    }
            ////    else
            ////    {
            ////        txtTotalCantidad.EditValue = 0;
            ////        txtTotalVenta.EditValue = 0;
            ////    }

            ////    lblTotalRegistros.Text = mListaPagoServicioDetalleOrigen.Count.ToString() + " Registros encontrados";

            ////}
            ////catch (Exception ex)
            ////{
            ////    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////}
        }

        private void CargaPagoServicioDetalle()
        {
            //decimal TotalSaldo = 0;
            //List<PagoServicioDetalleBE> lstTmpPagoServicioDetalle = null;
            //lstTmpPagoServicioDetalle = new PagoServicioDetalleBL().ListaTodosActivo(IdPagoServicio);

            //foreach (PagoServicioDetalleBE item in lstTmpPagoServicioDetalle)
            //{
            //    CPagoServicioDetalle objE_PagoServicioDetalle = new CPagoServicioDetalle();
            //    objE_PagoServicioDetalle.IdPagoServicio = item.IdPagoServicio;
            //    objE_PagoServicioDetalle.IdPagoServicioDetalle = item.IdPagoServicioDetalle;
            //    objE_PagoServicioDetalle.NumeroCuota = item.NumeroCuota;
            //    objE_PagoServicioDetalle.Fecha = item.Fecha;
            //    objE_PagoServicioDetalle.Concepto = item.Concepto;
            //    objE_PagoServicioDetalle.FechaPago = item.FechaPago;
            //    //objE_PagoServicioDetalle.FechaPago = item.FechaPago == 0 ? (DateTime?)null : item.FechaPago;
            //    objE_PagoServicioDetalle.FechaVencimiento = item.FechaVencimiento;
            //    objE_PagoServicioDetalle.Capital = item.Capital;
            //    objE_PagoServicioDetalle.Interes = item.Interes;
            //    objE_PagoServicioDetalle.Importe = item.Importe;
            //    objE_PagoServicioDetalle.TipoMovimiento = item.TipoMovimiento;
            //    objE_PagoServicioDetalle.TipoOper = item.TipoOper;
            //    mListaPagoServicioDetalleOrigen.Add(objE_PagoServicioDetalle);

        //    //    TotalSaldo = TotalSaldo + item.Importe;
        //}

        //bsListado.DataSource = mListaPagoServicioDetalleOrigen;
        //    gcPagoServicioDetalle.DataSource = bsListado;
        //    gcPagoServicioDetalle.RefreshDataSource();

        //    lblTotalRegistros.Text = mListaPagoServicioDetalleOrigen.Count.ToString() + " Registros encontrados";
        //    txtSaldo.EditValue = TotalSaldo;
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

        if (IdProveedor == 0)
        {
            strMensaje = strMensaje + "- Seleccionar personal.\n";
            flag = true;
        }

        if (mListaPagoServicioDetalleOrigen.Count == 0)
        {
            strMensaje = strMensaje + "- Nos se puede generar el PagoServicio, mientra no haya productos.\n";
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

    //private DataTable CargarMetodo()
    //{
    //    //DataTable dt = new DataTable();
    //    //dt.Columns.Add("Id", Type.GetType("System.Int32"));
    //    //dt.Columns.Add("Descripcion", Type.GetType("System.String"));
    //    //DataRow dr;
    //    //dr = dt.NewRow();
    //    //dr["Id"] = 1;
    //    //dr["Descripcion"] = "PRESTAMO";
    //    //dt.Rows.Add(dr);
    //    //dr = dt.NewRow();
    //    //dr["Id"] = 2;
    //    //dr["Descripcion"] = "ADELANTO DE SUELDO";//AMORTIZADO
    //    //dt.Rows.Add(dr);
    //    //dr = dt.NewRow();
    //    //dr["Id"] = 3;
    //    //dr["Descripcion"] = "FALTANTE DE CAJA";
    //    //dt.Rows.Add(dr);
    //    //return dt;
    //}

    private void ObtenerCorrelativo()
    {
        //try
        //{
        //    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
        //    string sNumero = "";
        //    string sSerie = "";
        //    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPrestamo, Parametros.intPeriodo);
        //    if (mListaNumero.Count > 0)
        //    {
        //        sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
        //        sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
        //    }
        //    txtNumero.Text = sNumero;
        //}

        //catch (Exception ex)
        //{
        //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
    }

    private void AgregaCalculoCuota()
    {
        //try
        //{
        //    if (Convert.ToInt32(txtNumeroCuotas.EditValue) == 0)
        //    {
        //        XtraMessageBox.Show("Ingresar el número de cuotas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        mListaPagoServicioDetalleOrigen.Clear();
        //        return;
        //    }

        //    if (Convert.ToDecimal(txtTotalPagar.EditValue) == 0)
        //    {
        //        XtraMessageBox.Show("Ingresar el Importe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        mListaPagoServicioDetalleOrigen.Clear();
        //        return;
        //    }

        //    if (deFechaInicio.Text == "")
        //    {
        //        XtraMessageBox.Show("Ingresar la fecha de Inicio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        mListaPagoServicioDetalleOrigen.Clear();
        //        return;
        //    }

        //    int Cuotas = 1;
        //    Cuotas = Convert.ToInt32(txtNumeroCuotas.EditValue);

        //    mListaPagoServicioDetalleOrigen.Clear();

        //    #region "Fecha Vencimiento"

        //    //valores de fecha Vencimiento
        //    int Dias = 0;
        //    switch (Convert.ToInt32(cboFormaPago.EditValue))
        //    {
        //        case 1:
        //            Dias = 360;
        //            break;
        //        case 2:
        //            Dias = 180;
        //            break;
        //        case 3:
        //            Dias = 120;
        //            break;
        //        case 4:
        //            Dias = 90;
        //            break;
        //        case 6:
        //            Dias = 60;
        //            break;
        //        case 12:
        //            Dias = 30;
        //            break;
        //        case 24:
        //            Dias = 15;
        //            break;
        //        default:
        //            Dias = 15;
        //            break;
        //    }
        //    #endregion

        //    int TotalDias = Dias;
        //    DateTime FechaInicio = deFechaInicio.DateTime.AddDays(-Dias);

        //    if (mListaPagoServicioDetalleOrigen.Count == 0)
        //    {
        //        for (int i = 1; i <= Cuotas; i++)
        //        {
        //            gvPagoServicioDetalle.AddNewRow();
        //            //gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "IdEmpresa", );
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "IdPagoServicio", 0);
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "IdPagoServicioDetalle", 0);
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "NumeroCuota", i);
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "Fecha", DateTime.Now.ToShortDateString());
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "FechaPago", null);
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "Concepto", cboTipoServicio.Text);
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "FechaVencimiento", FechaInicio.AddDays(TotalDias).ToShortDateString());//FechaInicio.DateTime.AddDays(TotalDias));
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "Capital", Convert.ToDecimal(txtCuota.EditValue));
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "Interes", 0);
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "Importe", Convert.ToDecimal(txtCuota.EditValue));
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "TipoMovimiento", "C");
        //            gvPagoServicioDetalle.SetRowCellValue(gvPagoServicioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
        //            gvPagoServicioDetalle.UpdateCurrentRow();

        //            TotalDias = TotalDias + Dias;
        //        }

        //        ///CalculaTotales();

        //        return;
        //    }





        //}
        //catch (Exception ex)
        //{
        //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
    }

    #endregion

    public class CPagoServicioDetalle
    {
        public Int32 IdPagoServicio { get; set; }
        public Int32 IdPagoServicioDetalle { get; set; }
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

        public CPagoServicioDetalle()
        {

        }
    }



    private void cboMetodo_EditValueChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(cboTipoServicio.EditValue) == 2)
        //{
        //    txtNumeroCuotas.EditValue = 1;
        //    txtInteres.EditValue = 0;
        //    cboFormaPago.EditValue = 24;
        //    txtNumeroCuotas.Properties.ReadOnly = true;
        //    txtInteres.Properties.ReadOnly = true;
        //    cboFormaPago.Properties.ReadOnly = true;
        //}
        //else
        //{
        //    txtNumeroCuotas.Properties.ReadOnly = false;
        //    txtInteres.Properties.ReadOnly = false;
        //    cboFormaPago.Properties.ReadOnly = false;
        //}
    }

    private void cboFechaInicio_EditValueChanged(object sender, EventArgs e)
    {

        CalculaTotales();
    }


}
}