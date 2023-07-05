using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmVerCitas : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<AgendaVisitaBE> mLista = new List<AgendaVisitaBE>();
        private List<AgendaVisitaDetalleBE> mListaDetalle = new List<AgendaVisitaDetalleBE>();

        private int IdSolicitudEgreso = 0;
        private int IdBanco = 0;
        private int IdTipoCuenta = 0;
        private int IdMoneda = 0;
        private string AbreviaturaMoneda = "";
        private string DescBanco = "";
        private string AbreviaturaBanco = "";

        int _IdAsesor = 0;
        public int IdAsesor
        {
            get { return _IdAsesor; }
            set { _IdAsesor = value; }
        }

        string _NombresAsesor = "";
        public string NombresAsesor
        {
            get { return _NombresAsesor; }
            set { _NombresAsesor = value; }
        }
        #endregion

        #region "Eventos"

        public frmVerCitas()
        {
            InitializeComponent();
        }

        private void frmVerCitas_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now.Date;  // DateTime.Now.AddMonths(-1);
            deHasta.EditValue = DateTime.Now.Date.AddDays(30);

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (gvVisitas.RowCount > 0)
                {
                    if (IdSolicitudEgreso > 0)
                    {
                        //frmRegCuentaBancoEdit objManCuentaBanco = new frmRegCuentaBancoEdit();
                        //objManCuentaBanco.lstCuentaBancoDetalle = mListaDetalle;
                        //objManCuentaBanco.pOperacion = frmRegCuentaBancoEdit.Operacion.Nuevo;
                        //objManCuentaBanco.IdCuentaBanco = IdCuentaBanco;
                        //objManCuentaBanco.IdMoneda = IdMoneda;
                        //objManCuentaBanco.IdTipoCuenta = IdTipoCuenta;
                        //objManCuentaBanco.IdBanco = IdBanco;
                        //objManCuentaBanco.IdCuentaBancoDetalle = 0;

                        //objManCuentaBanco.StartPosition = FormStartPosition.CenterParent;
                        //objManCuentaBanco.ShowDialog();

                        //CargarDetalles(IdCuentaBanco);
                    }
                    else {
                        XtraMessageBox.Show("No se puede registrar el detalle si seleccionar el Numero de Cuenta destino.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("¿Esta seguro de eliminar el registro? \n NOTA: Se eliminara todo movimiento generado por este registro.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            CuentaBancoDetalleBE objE_CuentaBancoDetalle = new CuentaBancoDetalleBE();
            //            objE_CuentaBancoDetalle.IdCuentaBancoDetalle = int.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("IdCuentaBancoDetalle").ToString());
            //            objE_CuentaBancoDetalle.Usuario = Parametros.strUsuarioLogin;
            //            objE_CuentaBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_CuentaBancoDetalle.IdEmpresa = Parametros.intEmpresaId;

            //            CuentaBancoDetalleBL objBL_CuentaBancoDetalle = new CuentaBancoDetalleBL();
            //            objBL_CuentaBancoDetalle.Elimina(objE_CuentaBancoDetalle);

            //            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Cargar();
            //        }
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_RefreshClick()
        {
            CargarDetalles(IdSolicitudEgreso);
        }

        private void tblMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteCuentaBancoBE> lstReporte = null;
                lstReporte = new ReporteCuentaBancoBL().Listado(Parametros.intEmpresaId, 0);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCuentaBanco = new RptVistaReportes();
                        objRptCuentaBanco.VerRptCuentaBanco(lstReporte);
                        objRptCuentaBanco.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            //string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoCuentaBancosDetalle";
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //f.ShowDialog(this);
            //if (f.SelectedPath != "")
            //{
            //    Cursor = Cursors.AppStarting;
            //    gvCuentaBancoDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    Cursor = Cursors.Default;
            //}
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCuentaBancoDetalle_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnImprimirCabecera_Click(object sender, EventArgs e)
        {

        }

        private void bntExportarCabecera_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoSolicitudEgreso";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvVisitas.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void btnActualizarCabecera_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void bntSalirCabecera_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvCuentaBanco_RowClick(object sender, RowClickEventArgs e)
        {
            //////if (gvCuentaBanco.RowCount > 0)
            //////{
            //////    IdSolicitudEgreso = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdSolicitudEgreso").ToString());
            //////    //IdMoneda = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdMoneda").ToString());
            //////    //AbreviaturaMoneda = gvCuentaBanco.GetFocusedRowCellValue("CodMoneda").ToString();
            //////    //IdBanco = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdBanco").ToString());
            //////    //IdTipoCuenta = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdTipoCuenta").ToString());
            //////    //DescBanco = gvCuentaBanco.GetFocusedRowCellValue("DescBanco").ToString();
            //////    //AbreviaturaBanco = gvCuentaBanco.GetFocusedRowCellValue("Abreviatura").ToString();

            //////    CargarDetalles(IdSolicitudEgreso);
            //////}
        }

        private void asignarclientetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (mListaDetalle.Count > 0)
            //    {
            //        int IdCliente = 0;
            //        DateTime FechaDeposito;
            //        decimal Total;
            //        decimal TipoCambio = 0;
            //        string TipoMovimiento = "";
            //        string MonedaEstadoCuenta = "US$";
            //        int TipoCausal = 0;
            //        int TipoConcepto = 0;
            //        int Motivo = 0;

            //        CuentaBancoDetalleBE objE_DocumentoVenta = (CuentaBancoDetalleBE)gvCuentaBancoDetalle.GetRow(gvCuentaBancoDetalle.FocusedRowHandle);
            //        frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
            //        objDescuento.IdCuentaBancoDetalle = objE_DocumentoVenta.IdCuentaBancoDetalle;
            //        objDescuento.Origen = 1;
            //        FechaDeposito = objE_DocumentoVenta.Fecha;
            //        TipoMovimiento = objE_DocumentoVenta.TipoMovimiento;
            //        TipoCausal = objE_DocumentoVenta.IdCuentaBancoDetalleCausal;
            //        TipoConcepto = objE_DocumentoVenta.IdCuentaBancoDetalleConcepto;
            //        IdCliente = Convert.ToInt32(objE_DocumentoVenta.IdCliente);

            //        if (TipoConcepto == 24 || TipoConcepto == 38)
            //        {
            //            if (IdCliente > 0)
            //            {
            //                XtraMessageBox.Show("El documento ya está ingreso al estado de cuenta, Por Favor Verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                return;
            //            }

            //            if (TipoMovimiento == "C")
            //            {
            //                Total = objE_DocumentoVenta.CuentaCargo;
            //            }
            //            else
            //            {
            //                Total = objE_DocumentoVenta.PagoAbono;
            //            }

            //            objDescuento.StartPosition = FormStartPosition.CenterParent;
            //            if (objDescuento.ShowDialog() == DialogResult.OK)
            //            {
            //                IdCliente = objDescuento.IdCliente;
            //                TipoCambio = Convert.ToDecimal(objDescuento.txtTipoCambio.EditValue);
            //                Motivo = Convert.ToInt32(objDescuento.cboMotivo.EditValue);
            //                CargarDetalles(IdSolicitudEgreso);
            //            }
            //            else
            //            {
            //                return;
            //            }

            //            #region "Estado Cuenta"

            //            ClienteBE objE_Cliente = new ClienteBE();
            //            objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

            //            string Numero = "";

            //            List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            //            mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPagoBancoCuenta, Parametros.intPeriodo);
            //            if (mListaNumero.Count > 0)
            //            {
            //                Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            //            }

            //            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
            //            {
            //                MonedaEstadoCuenta = "US$";
            //                if (IdMoneda == Parametros.intSoles)
            //                {
            //                    Total = Total / TipoCambio;
            //                }

            //                //Datos del estado de cuenta
            //                EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
            //                EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

            //                objE_EstadoCuenta.IdEstadoCuenta = 0;
            //                objE_EstadoCuenta.IdEmpresa = Parametros.intEmpresaId;
            //                objE_EstadoCuenta.Periodo = Parametros.intPeriodo;
            //                objE_EstadoCuenta.IdCliente = objE_Cliente.IdCliente;
            //                objE_EstadoCuenta.NumeroDocumento = "B" + Numero;
            //                objE_EstadoCuenta.FechaCredito = FechaDeposito;
            //                if (TipoMovimiento == "C") objE_EstadoCuenta.FechaDeposito = null;
            //                else
            //                    objE_EstadoCuenta.FechaDeposito = FechaDeposito;
            //                objE_EstadoCuenta.Concepto = ("PAGO " + AbreviaturaBanco + " " + AbreviaturaMoneda + " " +  objDescuento.FormaPago + " " + objDescuento.NumeroPedido).ToString().Trim();
            //                objE_EstadoCuenta.FechaVencimiento = null;
            //                objE_EstadoCuenta.Importe = Total;
            //                objE_EstadoCuenta.ImporteAnt = 0;
            //                objE_EstadoCuenta.TipoMovimiento = TipoMovimiento;
            //                objE_EstadoCuenta.IdMotivo = Motivo;  //Parametros.intMotivoVenta;//Verificar para NAVIDAD
            //                objE_EstadoCuenta.IdDocumentoVenta = null;
            //                objE_EstadoCuenta.IdPedido = objDescuento.IdPedido;
            //                objE_EstadoCuenta.IdCuentaBancoDetalle = objE_DocumentoVenta.IdCuentaBancoDetalle;
            //                objE_EstadoCuenta.IdUsuario = Parametros.intUsuarioId;
            //                objE_EstadoCuenta.Observacion = "";
            //                objE_EstadoCuenta.FlagEstado = true;
            //                objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
            //                objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            //                objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);


            //                #region "EstadoCuentaCliente"
            //                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
            //                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

            //                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
            //                objE_EstadoCuentaCliente.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
            //                objE_EstadoCuentaCliente.Periodo = objE_EstadoCuenta.Periodo;
            //                objE_EstadoCuentaCliente.IdCliente = objE_EstadoCuenta.IdCliente;
            //                objE_EstadoCuentaCliente.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
            //                objE_EstadoCuentaCliente.Fecha = objE_EstadoCuenta.FechaCredito;
            //                objE_EstadoCuentaCliente.Concepto = objE_EstadoCuenta.Concepto;
            //                objE_EstadoCuentaCliente.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
            //                objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
            //                objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
            //                objE_EstadoCuentaCliente.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
            //                objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
            //                //objE_EstadoCuentaCliente.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
            //                objE_EstadoCuentaCliente.IdPedido = objE_EstadoCuenta.IdPedido;
            //                objE_EstadoCuentaCliente.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
            //                objE_EstadoCuentaCliente.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
            //                objE_EstadoCuentaCliente.IdPersona = objE_EstadoCuenta.IdUsuario;
            //                objE_EstadoCuentaCliente.UsuarioRegistro = objE_EstadoCuenta.Usuario;
            //                objE_EstadoCuentaCliente.FechaRegistro = objE_EstadoCuenta.FechaCredito;
            //                objE_EstadoCuentaCliente.Observacion = objE_EstadoCuenta.Observacion;
            //                objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
            //                objE_EstadoCuentaCliente.FlagEstado = true;
            //                objE_EstadoCuentaCliente.Usuario = objE_EstadoCuenta.Usuario;
            //                objE_EstadoCuentaCliente.Maquina = objE_EstadoCuenta.Maquina;

            //                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
            //                #endregion
            //            }
            //            else
            //            {
            //                MonedaEstadoCuenta = "S/";
            //                if (IdMoneda == Parametros.intDolares)
            //                {
            //                    Total = Total * Convert.ToDecimal(Parametros.dmlTCMayorista);
            //                }

            //                //Datos del estado de cuenta
            //                SeparacionBE objE_Separacion = new SeparacionBE();
            //                SeparacionBL objBL_Separacion = new SeparacionBL();

            //                objE_Separacion.IdSeparacion = 0;
            //                objE_Separacion.IdEmpresa = Parametros.intEmpresaId;
            //                objE_Separacion.Periodo = Parametros.intPeriodo;
            //                objE_Separacion.IdCliente = objE_Cliente.IdCliente;
            //                objE_Separacion.NumeroDocumento = "B" + Numero;
            //                objE_Separacion.FechaSeparacion = FechaDeposito;
            //                //objE_Separacion.FechaPago = null;
            //                if (TipoMovimiento == "C") objE_Separacion.FechaPago = null;
            //                else
            //                    objE_Separacion.FechaPago = FechaDeposito;
            //                objE_Separacion.Concepto = ("PAGO " + AbreviaturaBanco + " " + MonedaEstadoCuenta + " " + objDescuento.FormaPago + " " + objDescuento.NumeroPedido).ToString().Trim();
            //                objE_Separacion.FechaVencimiento = null;
            //                objE_Separacion.Importe = Total;
            //                objE_Separacion.ImporteAnt = 0;
            //                objE_Separacion.TipoMovimiento = TipoMovimiento;
            //                objE_Separacion.IdMotivo = Parametros.intMotivoVenta;//Verificar para NAVIDAD
            //                objE_Separacion.IdCuentaBancoDetalle = objE_DocumentoVenta.IdCuentaBancoDetalle;
            //                objE_Separacion.IdDocumentoVenta = null;
            //                objE_Separacion.IdUsuario = Parametros.intUsuarioId;
            //                objE_Separacion.FlagEstado = true;
            //                objE_Separacion.Usuario = Parametros.strUsuarioLogin;
            //                objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            //                // Actualiza la linea de credito
            //                objBL_Separacion.Inserta(objE_Separacion);


            //                #region "EstadoCuentaCliente"
            //                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
            //                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

            //                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
            //                objE_EstadoCuentaCliente.IdEmpresa = objE_Separacion.IdEmpresa;
            //                objE_EstadoCuentaCliente.Periodo = objE_Separacion.Periodo;
            //                objE_EstadoCuentaCliente.IdCliente = objE_Separacion.IdCliente;
            //                objE_EstadoCuentaCliente.NumeroDocumento = objE_Separacion.NumeroDocumento;
            //                objE_EstadoCuentaCliente.Fecha = objE_Separacion.FechaSeparacion;
            //                objE_EstadoCuentaCliente.Concepto = objE_Separacion.Concepto;
            //                objE_EstadoCuentaCliente.FechaVencimiento = objE_Separacion.FechaVencimiento;
            //                objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
            //                objE_EstadoCuentaCliente.Importe = objE_Separacion.Importe;
            //                objE_EstadoCuentaCliente.TipoMovimiento = objE_Separacion.TipoMovimiento;
            //                objE_EstadoCuentaCliente.IdMotivo = objE_Separacion.IdMotivo;
            //                //objE_EstadoCuentaCliente.IdDocumentoVenta = objE_Separacion.IdDocumentoVenta;
            //                objE_EstadoCuentaCliente.IdPedido = objE_Separacion.IdPedido;
            //                objE_EstadoCuentaCliente.IdMovimientoCaja = objE_Separacion.IdMovimientoCaja;
            //                objE_EstadoCuentaCliente.IdCuentaBancoDetalle = objE_Separacion.IdCuentaBancoDetalle;
            //                objE_EstadoCuentaCliente.IdPersona = objE_Separacion.IdUsuario;
            //                objE_EstadoCuentaCliente.UsuarioRegistro = objE_Separacion.Usuario;
            //                objE_EstadoCuentaCliente.FechaRegistro = objE_Separacion.FechaSeparacion;
            //                objE_EstadoCuentaCliente.Observacion = objE_Separacion.Observacion;
            //                objE_EstadoCuentaCliente.Saldo = objE_Separacion.Importe;
            //                objE_EstadoCuentaCliente.FlagEstado = true;
            //                objE_EstadoCuentaCliente.Usuario = objE_Separacion.Usuario;
            //                objE_EstadoCuentaCliente.Maquina = objE_Separacion.Maquina;

            //                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
            //                #endregion

            //            }

            //            //Actualizamos el correlativo del estado de cuenta
            //            NumeracionDocumentoBL objDL_NumeracionDocumento = new NumeracionDocumentoBL();
            //            objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPagoBancoCuenta, Parametros.intPeriodo);

            //            #endregion

            //            XtraMessageBox.Show("Se registro " + MonedaEstadoCuenta + " " + Total + " al Estado de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("Sólo se puede Asingar el ingreso en efectivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return;
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void asignardiseñadortoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (mListaDetalle.Count > 0)
            //    {
            //        int IdCliente = 0;
            //        DateTime FechaDeposito;
            //        decimal Total;
            //        decimal TipoCambio = 0;
            //        string TipoMovimiento = "";
            //        int TipoCausal = 0;
            //        int TipoConcepto = 0;
            //        int Motivo = 0;

            //        CuentaBancoDetalleBE objE_DocumentoVenta = (CuentaBancoDetalleBE)gvCuentaBancoDetalle.GetRow(gvCuentaBancoDetalle.FocusedRowHandle);
            //        frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
            //        objDescuento.IdCuentaBancoDetalle = objE_DocumentoVenta.IdCuentaBancoDetalle;
            //        objDescuento.Origen = 1;
            //        FechaDeposito = objE_DocumentoVenta.Fecha;
            //        TipoMovimiento = objE_DocumentoVenta.TipoMovimiento;
            //        TipoCausal = objE_DocumentoVenta.IdCuentaBancoDetalleCausal;
            //        TipoConcepto = objE_DocumentoVenta.IdCuentaBancoDetalleConcepto;
            //        IdCliente = Convert.ToInt32(objE_DocumentoVenta.IdCliente);

            //        if (TipoMovimiento == "C") TipoMovimiento = "A"; //CAMBIO
            //        if (TipoMovimiento == "A") TipoMovimiento = "C";

            //        if (TipoConcepto == 43)
            //        {
            //            if (IdCliente > 0)
            //            {
            //                XtraMessageBox.Show("El documento ya está ingreso al estado de cuenta, Por Favor Verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                return;
            //            }

            //            if (TipoMovimiento == "C")
            //            {
            //                Total = objE_DocumentoVenta.CuentaCargo;
            //            }
            //            else
            //            {
            //                Total = objE_DocumentoVenta.PagoAbono;
            //            }

            //            objDescuento.StartPosition = FormStartPosition.CenterParent;
            //            if (objDescuento.ShowDialog() == DialogResult.OK)
            //            {
            //                IdCliente = objDescuento.IdCliente;
            //                TipoCambio = Convert.ToDecimal(objDescuento.txtTipoCambio.EditValue);
            //                Motivo = Parametros.intMotivoVenta; //Convert.ToInt32(objDescuento.cboMotivo.EditValue);
            //                CargarDetalles(IdSolicitudEgreso);
            //            }
            //            else
            //            {
            //                return;
            //            }

            //            #region "Estado Cuenta"

            //            ClienteBE objE_Cliente = new ClienteBE();
            //            objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

            //            string Numero = "";

            //            List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            //            mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPagoBancoCuenta, Parametros.intPeriodo);
            //            if (mListaNumero.Count > 0)
            //            {
            //                Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            //            }

            //            if (IdMoneda == Parametros.intDolares)
            //            {
            //                Total = Total * Convert.ToDecimal(Parametros.dmlTCMayorista);
            //            }

            //            //Datos del estado de cuenta
            //            EstadoCuentaComisionBE objE_EstadoCuentaComision = new EstadoCuentaComisionBE();
            //            EstadoCuentaComisionBL objBL_EstadoCuentaComision = new EstadoCuentaComisionBL();

            //            objE_EstadoCuentaComision.IdEstadoCuentaComision = 0;
            //            objE_EstadoCuentaComision.IdEmpresa = Parametros.intEmpresaId;
            //            objE_EstadoCuentaComision.Periodo = Parametros.intPeriodo;
            //            objE_EstadoCuentaComision.IdCliente = objE_Cliente.IdCliente;
            //            objE_EstadoCuentaComision.NumeroDocumento = "B" + Numero;
            //            objE_EstadoCuentaComision.Fecha = FechaDeposito;
            //            //objE_EstadoCuentaComision.FechaPago = null;
            //            if (TipoMovimiento == "C") objE_EstadoCuentaComision.FechaDeposito = null;
            //            else
            //                objE_EstadoCuentaComision.FechaDeposito = FechaDeposito;
            //            objE_EstadoCuentaComision.Concepto = ("PAGO " + DescBanco + " " + objDescuento.FormaPago + " " + objDescuento.NumeroPedido).ToString().Trim();
            //            objE_EstadoCuentaComision.FechaVencimiento = null;
            //            objE_EstadoCuentaComision.Importe = Total;
            //            objE_EstadoCuentaComision.ImporteAnt = 0;
            //            objE_EstadoCuentaComision.TipoMovimiento = TipoMovimiento;
            //            objE_EstadoCuentaComision.IdMotivo = Parametros.intMotivoVenta;//Verificar para NAVIDAD
            //            objE_EstadoCuentaComision.IdCuentaBancoDetalle = objE_DocumentoVenta.IdCuentaBancoDetalle;
            //            objE_EstadoCuentaComision.IdDocumentoVenta = null;
            //            objE_EstadoCuentaComision.FlagEstado = true;
            //            objE_EstadoCuentaComision.Usuario = Parametros.strUsuarioLogin;
            //            objE_EstadoCuentaComision.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            //            objBL_EstadoCuentaComision.Inserta(objE_EstadoCuentaComision);


            //            //Actualizamos el correlativo del estado de cuenta

            //            NumeracionDocumentoBL objDL_NumeracionDocumento = new NumeracionDocumentoBL();
            //            objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPagoBancoCuenta, Parametros.intPeriodo);

            //            #endregion

            //            XtraMessageBox.Show("Se registro S/" + Total + " al Estado de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("Sólo se puede Asignar el pago por Gerencia ->PAGO ASESORIA EXTERNA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return;
            //        }

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                mLista = new AgendaVisitaBL().ListaFechaVisitas(IdAsesor, Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue)); // <- 170323
                gcVisitas.DataSource = mLista;
             }
            else
            {
                mLista = new AgendaVisitaBL().ListaFechaVisitas(IdAsesor, Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue));
                gcVisitas.DataSource = mLista;
            }
            //if (Parametros.intPerfilId == Parametros.intPerAdministrador ||
            //    Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad ||
            //    Parametros.intPerfilId == Parametros.intPerTesoreria)
            //{
            //    //groupControl3.Visible = true;
            //    CargarTotalPagar();
            //}
        }

        private void CargarTotalPagar()
        {
            ////SolicitudEgresoBE objE_SolicitudTotalPagar = null;
            ////objE_SolicitudTotalPagar = new SolicitudEgresoBL().TotalPagosPendientes(Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue));

            //SolicitudEgresoBE objE_Solicitud = null;
            //objE_Solicitud = new SolicitudEgresoBL().TotalPagosPendientes(Convert.ToDateTime(deDesde.EditValue), Convert.ToDateTime(deHasta.EditValue));
            //lblPanorama.Text = String.Format("{0:n}", objE_Solicitud.Panorama);  // String.Format("{0:#,##0.00}",  objE_Solicitud.Panorama.ToString());

            //lblDecoratex.Text =  String.Format("{0:n}", objE_Solicitud.Decoratex);
            ////txtDecoratex.Text = objE_Solicitud.Decoratex.ToString();
            ////txtDecoratex.Properties.DisplayFormat.FormatString = "n2";
            ////txtDecoratex.Properties.Mask.EditMask = "n2";
        }

        private void CargarBusqueda()
        {
            //gcCuentaBanco.DataSource = mLista.Where(obj =>
            //                                       obj.DescBanco.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void CargarDetalles(int IdCuentaBanco)
        {
            //mListaDetalle = new SolicitudEgresoDetalleBL().ListaSolicitudEgresoDetalle(IdCuentaBanco); //   .ListaSolicitudEgresoDetalle(IdCuentaBanco);
            //gcCuentaBancoDetalle.DataSource = mListaDetalle;

            //lblTotalRegistros.Text = gvCuentaBancoDetalle.RowCount.ToString() + " Registros";
            //CalcularTotales();
        }

        public void InicializarModificar()
        {
            //if (gvCuentaBanco.RowCount > 0)
            //{
            //    CuentaBancoDetalleBE objCuentaBanco = new CuentaBancoDetalleBE();
            //    objCuentaBanco.IdCuentaBancoDetalle = int.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("IdCuentaBancoDetalle").ToString());
            //    objCuentaBanco.IdCuentaBanco = int.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("IdCuentaBanco").ToString());

            //    //frmRegCuentaBancoEdit objManCuentaBancoEdit = new frmRegCuentaBancoEdit();
            //    //objManCuentaBancoEdit.pOperacion = frmRegCuentaBancoEdit.Operacion.Modificar;
            //    //objManCuentaBancoEdit.IdCuentaBancoDetalle = objCuentaBanco.IdCuentaBancoDetalle;
            //    //objManCuentaBancoEdit.IdCuentaBanco = objCuentaBanco.IdCuentaBanco;
            //    //objManCuentaBancoEdit.IdCuentaBanco = IdCuentaBanco;
            //    //objManCuentaBancoEdit.IdBanco = IdBanco;
            //    //objManCuentaBancoEdit.IdMoneda = IdMoneda;
            //    //objManCuentaBancoEdit.IdTipoCuenta = IdTipoCuenta;
            //    //objManCuentaBancoEdit.StartPosition = FormStartPosition.CenterParent;
            //    //objManCuentaBancoEdit.ShowDialog();

            //    //CargarDetalles(IdCuentaBanco);
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        //private bool ValidarIngreso()
        //{
        //    //bool flag = false;

        //    //if (gvCuentaBancoDetalle.GetFocusedRowCellValue("IdCuentaBancoDetalle").ToString() == "")
        //    //{
        //    //    XtraMessageBox.Show("Seleccione un registro para eliminar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    //    flag = true;
        //    //}

        //    //Cursor = Cursors.Default;
        //    //return flag;
        //}

        private void CalcularTotales()
        {
            //if (mListaDetalle.Count > 0)
            //{
            //    decimal decTotalCargo = 0;
            //    decimal decTotalAbono = 0;
            //    decimal decTotalAbonar = 0;
            //    decimal decSaldo = 0;

            //    foreach (var item in mListaDetalle)
            //    {
            //        decTotalAbono = decTotalAbono + item.MontoAbono;
            //        decTotalAbonar = decTotalAbonar + item.MontoFactura;
            //    }
            //    txtTotalAbonar.EditValue = decTotalAbono ;
            //    txtTotal.EditValue = decTotalAbonar;
            //}
            //else
            //{
            //    txtTotal.EditValue = 0;            
            //}
        }

        #endregion

        private void asignarProveedortoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (mListaDetalle.Count > 0)
            //    {
            //        int IdProveedor = 0;
            //        DateTime FechaDeposito;
            //        decimal Total;

            //        //string MonedaEstadoCuenta = "US$";
            //        string TipoMovimiento = "";
            //        int TipoCausal = 0;
            //        int TipoConcepto = 0;


            //        CuentaBancoDetalleBE objE_DocumentoVenta = (CuentaBancoDetalleBE)gvCuentaBancoDetalle.GetRow(gvCuentaBancoDetalle.FocusedRowHandle);

            //        frmAsignarProveedorEC objDescuento = new frmAsignarProveedorEC();
            //        objDescuento.IdCuentaBancoDetalle = objE_DocumentoVenta.IdCuentaBancoDetalle;
            //        objDescuento.Origen = 1;
            //        objDescuento.Importe = decimal.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("CuentaCargo").ToString());
            //        objDescuento.AbreviaturaBanco = AbreviaturaBanco;

            //        FechaDeposito = objE_DocumentoVenta.Fecha;
            //        TipoMovimiento = objE_DocumentoVenta.TipoMovimiento;
            //        TipoCausal = objE_DocumentoVenta.IdCuentaBancoDetalleCausal;
            //        TipoConcepto = objE_DocumentoVenta.IdCuentaBancoDetalleConcepto;
            //        IdProveedor = Convert.ToInt32(objE_DocumentoVenta.IdProveedor);

            //        if (TipoConcepto == 15)
            //        {
            //            if (IdProveedor > 0)
            //            {
            //                XtraMessageBox.Show("El documento ya está ingreso al estado de cuenta, Por Favor Verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                return;
            //            }

            //            Total = objE_DocumentoVenta.CuentaCargo;

            //            objDescuento.StartPosition = FormStartPosition.CenterParent;
            //            if (objDescuento.ShowDialog() == DialogResult.OK)
            //            {
            //                IdProveedor = objDescuento.IdProveedor;
            //                CargarDetalles(IdSolicitudEgreso);
            //            }
            //            else
            //            {
            //                return;
            //            }

            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("Sólo se puede Asingar el ingreso en efectivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return;
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmRegAgendaVisitas_Add objAgendaVisita = new frmRegAgendaVisitas_Add();
            //objSolicitudEgreso.lstCuentaBancoDetalle = mListaDetalle;
            objAgendaVisita.pOperacion = frmRegAgendaVisitas_Add.Operacion.Nuevo;
            objAgendaVisita.StartPosition = FormStartPosition.CenterParent;
            objAgendaVisita.ShowDialog();
            Cargar();
            //CargarDetalles(IdSolicitudEgreso);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        if (gvCuentaBanco.GetFocusedRowCellValue("Situacion").ToString()=="ANULADO")
        //            {
        //            XtraMessageBox.Show("La solicitud se encuentra Anulada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerTesoreria)
        //        {
        //            frmRegActualizarPagos objSolicitudEgreso = new frmRegActualizarPagos();
        //            //objSolicitudEgreso.lstCuentaBancoDetalle = mListaDetalle;
        //            objSolicitudEgreso.pOperacion = frmRegActualizarPagos.Operacion.Modificar;

        //            objSolicitudEgreso.IdSolicitudEgreso = int.Parse(gvCuentaBancoDetalle.GetFocusedRowCellValue("IdSolicitudEgreso").ToString());
        //            //objSolicitudEgreso.NumSolicitudEgreso =  gvCuentaBancoDetalle.GetFocusedRowCellValue("NumSolicitudEgreso").ToString();
        //            //objSolicitudEgreso.IdMoneda = IdMoneda;
        //            //objSolicitudEgreso.IdTipoCuenta = IdTipoCuenta;
        //            //objSolicitudEgreso.IdBanco = IdBanco;
        //            //objSolicitudEgreso.IdCuentaBancoDetalle = 0;

        //            objSolicitudEgreso.StartPosition = FormStartPosition.CenterParent;
        //            objSolicitudEgreso.ShowDialog();
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show("Su perfil no tiene acceso a la opción.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        Cargar();
        //    }
                  
        //    catch (Exception ex)
        //    {
        //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
    }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmCerrarVisita FrmCambioVisita = new frmCerrarVisita();
            FrmCambioVisita.IdAgenda = int.Parse(gvVisitas.GetFocusedRowCellValue("IdAgendaVisita").ToString());
            FrmCambioVisita.pOperacion = frmCerrarVisita.Operacion.Consultar;
            FrmCambioVisita.ShowDialog();
            Cargar();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (gvVisitas.GetFocusedRowCellValue("Situacion").ToString() == "VISITADO" || gvVisitas.GetFocusedRowCellValue("Situacion").ToString() == "CANCELADO")
            {
                XtraMessageBox.Show("Solo cierra visitas en situación programada o reprogramada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCerrarVisita FrmCambioVisita = new frmCerrarVisita();
            FrmCambioVisita.IdAgenda = int.Parse(gvVisitas.GetFocusedRowCellValue("IdAgendaVisita").ToString());
            FrmCambioVisita.pOperacion = frmCerrarVisita.Operacion.Modificar;
            FrmCambioVisita.ShowDialog();
            Cargar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (gvVisitas.GetFocusedRowCellValue("Situacion").ToString() ==  "VISITADO" || gvVisitas.GetFocusedRowCellValue("Situacion").ToString() == "CANCELADO")
            {
                XtraMessageBox.Show("Solo se cancela con visitas programadas o reprogramadas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCancelaVisita FrmCambioVisita = new frmCancelaVisita();
            FrmCambioVisita.IdAgenda = int.Parse(gvVisitas.GetFocusedRowCellValue("IdAgendaVisita").ToString());
            FrmCambioVisita.ShowDialog();
            Cargar();
        }

        private void gvCuentaBanco_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvVisitas.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Situacion"]);
                    if (objDocRetiro != null)
                    {
                        string IdSituacion = (objDocRetiro.ToString());
                        if (IdSituacion == "CANCELADO")
                        {
                            e.Appearance.ForeColor = Color.Red;
                            e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Regular | FontStyle.Strikeout);
                            //e.Appearance.ForeColor = Color.Gray;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        //else if (IdSituacion == "PROGRAMADO")
                        //{
                        //    e.Appearance.BackColor = Color.Yellow;
                        //}
                        //else if (IdSituacion == "VISITADO")
                        //{
                        //    e.Appearance.BackColor = Color.LightGreen;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gvCuentaBancoDetalle.GetFocusedRowCellValue("RutaArchivo").ToString() != string.Empty)
            //    {
            //        System.Diagnostics.Process.Start(gvCuentaBancoDetalle.GetFocusedRowCellValue("RutaArchivo").ToString());

            //    }
            //}
            //catch (Exception ex)
            //{
            //  //  XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtPeriodo_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
  
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void txtNumero_Validating(object sender, CancelEventArgs e)
        {
       
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero2_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //string nume = txtNumero2.Text.ToString().PadLeft(8, '0');
                //txtNumero2.Text = nume;
                //mLista = new SolicitudEgresoBL().BuscarSolicitud(txtNumero2.Text);
                //gcRegistrosAgenda.DataSource = mLista;
            }

            CargarTotalPagar();
        }

        private void gcCuentaBanco_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gvCuentaBancoDetalle.GetFocusedRowCellValue("RutaArchivo").ToString() != string.Empty)
            //    {
            //        System.Diagnostics.Process.Start(gvCuentaBancoDetalle.GetFocusedRowCellValue("RutaArchivo").ToString());

            //    }
            //}
            //catch (Exception ex)
            //{
            XtraMessageBox.Show("mensaje", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void repositoryItemImageEdit1_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("mensaje", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            Cargar();
        }

        private void repositoryItemButtonEdit1_Click_2(object sender, EventArgs e)
        {
            frmRegAgendaVisitas_Add FrmVisita = new frmRegAgendaVisitas_Add();

            FrmVisita.IdAsesor = int.Parse(gvVisitas.GetFocusedRowCellValue("IdPersona").ToString());
            FrmVisita.NombresAsesor= gvVisitas.GetFocusedRowCellValue("Nombres").ToString();
            FrmVisita.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (gvVisitas.GetFocusedRowCellValue("Situacion").ToString()=="CANCELADO" || gvVisitas.GetFocusedRowCellValue("Situacion").ToString() == "VISITADO")
            {
                XtraMessageBox.Show("No se puede reprogramar con la situación actual de la visita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReprogramarVisita FrmCambioVisita = new frmReprogramarVisita();
            FrmCambioVisita.IdAgenda = int.Parse(gvVisitas.GetFocusedRowCellValue("IdAgendaVisita").ToString());
            FrmCambioVisita.IdAsesor = IdAsesor;
            FrmCambioVisita.ShowDialog();
            Cargar();
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (gvVisitas.GetFocusedRowCellValue("RutaArchivo").ToString() != string.Empty)
                {
                    System.Diagnostics.Process.Start(gvVisitas.GetFocusedRowCellValue("RutaArchivo").ToString());

                }
            }
            catch (Exception ex)
            {
                //  XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/





        }

        private void gvVisitas_Click(object sender, EventArgs e)
        {

        }

        private void gvVisitas_DoubleClick(object sender, EventArgs e)
        {
            frmCerrarVisita FrmCambioVisita = new frmCerrarVisita();
            FrmCambioVisita.IdAgenda = int.Parse(gvVisitas.GetFocusedRowCellValue("IdAgendaVisita").ToString());
            FrmCambioVisita.pOperacion = frmCerrarVisita.Operacion.Consultar;
            FrmCambioVisita.ShowDialog();
            Cargar();
        }
    }
}