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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.ws_integrens;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegMovimientoCaja : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        ws_integrensSoapClient WS = new ws_integrensSoapClient();
        FacturacionElectronica FacturaE = new FacturacionElectronica();

        private List<MovimientoCajaBE> mLista = new List<MovimientoCajaBE>();

        DataTable dt = new DataTable();
        byte[] Imagen = null;

        #endregion

        #region "Eventos"

        public frmRegMovimientoCaja()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoCaja_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            cboTienda.EditValue = Parametros.intTiendaId;
            cboCaja.EditValue = Parametros.intCajaId;
            deFecha.EditValue = DateTime.Now;
            Cargar();

            if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad
                || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion || Parametros.intPerfilId == Parametros.intPerHelpDesk
                || Parametros.intPerfilId == Parametros.intPerAsistenteCreditos || Parametros.intPerfilId == Parametros.intPerTesoreria
                || Parametros.intPerfilId == Parametros.intPerFacturacion || Parametros.intPerfilId == Parametros.intPerJefeCanalMayorista)
            {
                //cboEmpresa.Enabled = true;
                cboTienda.Enabled = true;
                cboCaja.Enabled = true;
            }

            if (Parametros.intTiendaId != Parametros.intTiendaUcayali)
            {
                toolStripSeparator3.Visible = false;
                despachartoolStripMenuItem.Visible = false;
            }

            txtAnio.EditValue = Parametros.intPeriodo;
            cboMes.EditValue = DateTime.Now.Month;                                                                                                                                                                                 //deFechaHasta.EditValue = DateTime.Now;
            cboMes.Focus();

            if (Parametros.strUsuarioLogin == "master"
                    || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad )
            {
                labelControl3.Visible = true;
                labelControl4.Visible = true;
                txtAnio.Visible = true;
                cboMes.Visible = true;
                btnVer.Visible = true;
            }


        }

        private void tlbMenu_NewClick()
        {
            try
            {
                //if (Parametros.strUsuarioLogin == "bsilva")
                //{
                //    return;
                //}

                frmRegMovimientoCajaEdit objManMovimientoCaja = new frmRegMovimientoCajaEdit();
                objManMovimientoCaja.lstMovimientoCaja = new MovimientoCajaBL().ListaTodosActivo(Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));
                objManMovimientoCaja.pOperacion = frmRegMovimientoCajaEdit.Operacion.Nuevo;
                objManMovimientoCaja.IdMovimientoCaja = 0;
                objManMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManMovimientoCaja.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                objManMovimientoCaja.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objManMovimientoCaja.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoCaja.ShowDialog();
                Cargar();

                //if (objManMovimientoCaja.ShowDialog() == DialogResult.OK)
                //{
                //    Cargar();
                //}

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
            try
            {
                if (Parametros.strUsuarioLogin == "bsilva")
                {
                    return;
                }

                //int TipoDocumento = Convert.ToInt32(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                //if (TipoDocumento == Parametros.intTipoDocRetiroCaja || TipoDocumento == Parametros.intTipoDocReciboEgreso)
                //{
                //    if (XtraMessageBox.Show("Está seguro de eliminar este documento?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //    {
                //        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();

                //        objE_MovimientoCaja.IdMovimientoCaja = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMovimientoCaja").ToString());
                //        objE_MovimientoCaja.IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                //        objE_MovimientoCaja.IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                //        objE_MovimientoCaja.NumeroDocumento = gvMovimientoCaja.GetFocusedRowCellValue("NumeroDocumento").ToString();
                //        //objE_MovimientoCaja.IdMotivoAnulacion = frm.IdMotivoAnulacion;
                //        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                //        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                //        objE_MovimientoCaja.IdEmpresa = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdEmpresa").ToString());

                //        MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                //        objBL_MovimientoCaja.Elimina(objE_MovimientoCaja);
                //        //XtraMessageBox.Show("El registro se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        Cargar();
                //    }
                //}
                //else
                //{
                Cursor = Cursors.WaitCursor;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita == false || frmAutoriza.FlagAutorizaEliminaDocumentoVenta == false)
                {
                    XtraMessageBox.Show("No tiene acceso para eliminar el documento de venta \n Comuniquese con el Supervisor de Tienda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    frmMessageDeleteDocument frm = new frmMessageDeleteDocument();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        if (!ValidarIngreso())
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();

                            objE_MovimientoCaja.IdMovimientoCaja = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMovimientoCaja").ToString());
                            objE_MovimientoCaja.IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                            objE_MovimientoCaja.IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                            objE_MovimientoCaja.NumeroDocumento = gvMovimientoCaja.GetFocusedRowCellValue("NumeroDocumento").ToString();
                            objE_MovimientoCaja.Fecha = DateTime.Parse(gvMovimientoCaja.GetFocusedRowCellValue("Fecha").ToString());
                            objE_MovimientoCaja.IdMotivoAnulacion = frm.IdMotivoAnulacion;
                            objE_MovimientoCaja.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
                            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoCaja.IdEmpresa = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdEmpresa").ToString());

                            if (objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocReciboPago)
                            {
                                XtraMessageBox.Show("No se puede anular por esta opción.\nDebe anular desde Recibo de Pago.", this.Text);
                                return;
                            }

                            MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                            objBL_MovimientoCaja.Elimina(objE_MovimientoCaja);


                            if (objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                            {
                                if (objE_MovimientoCaja.Fecha <= Convert.ToDateTime(DateTime.Now.AddDays(-4).ToShortDateString()))
                                {
                                    //XtraMessageBox.Show("No se puede Eliminar, El máximo permitido para dar de baja un comprobante es de 4 días.\nConsultar con el área de Contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //return;
                                }

                                //FacturaE.AnulaVentaIntegrens(Convert.ToInt32(objE_MovimientoCaja.IdDocumentoVenta));
                            }

                            //////////////////////////
                            TalonBE objTalon = null;
                            //  objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, 1, IdTipoDocumento);
                            objTalon = new TalonBL().SeleccionaCajaDocumento(int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdEmpresa").ToString()), Parametros.intTiendaId, Parametros.intCajaId, int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString()));//
                            ImpresionElectronicaLocalAnula(int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString()), objTalon.IdTamanoHoja, objTalon.Impresora, int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdEmpresa").ToString()), frm.DescMotivo);

                            //else
                            //{
                            //    XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Comprobante electrónico.\nSin embargo UD. Puede descargar el PDF y XML desde la página web.\nConsultar con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //}
                            /////////////////////////
                            //XtraMessageBox.Show("El registro se anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();

                            if (objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocNotaCredito || objE_MovimientoCaja.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                XtraMessageBox.Show("Se eliminó del movimiento de caja correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                #region "Eliminar pedido y EECC"

                                //Anula Con Pedido
                                DocumentoVentaBE objBE_Documento = new DocumentoVentaBE();
                                objBE_Documento = new DocumentoVentaBL().Selecciona(Convert.ToInt32(objE_MovimientoCaja.IdDocumentoVenta));
                                if (objBE_Documento != null)
                                {
                                    //Verificamos si tiene Pedido 
                                    if (objBE_Documento.IdPedido != null)
                                    {
                                        if (XtraMessageBox.Show("El documento está asociado a un pedido, Desea Anular el Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            PedidoBE objE_Pedido = null;
                                            PedidoBL objBL_Pedido = new PedidoBL();
                                            objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(objBE_Documento.IdPedido));

                                            if (objE_Pedido != null)
                                            {
                                                objE_Pedido.IdPedido = objE_Pedido.IdPedido;
                                                objE_Pedido.IdTienda = objE_Pedido.IdTienda;
                                                objE_Pedido.IdFormaPago = objE_Pedido.IdFormaPago;
                                                objE_Pedido.Numero = objE_Pedido.Numero;
                                                objE_Pedido.FlagPreVenta = objE_Pedido.FlagPreVenta;
                                                objE_Pedido.Usuario = Parametros.strUsuarioLogin;
                                                objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                                objE_Pedido.IdEmpresa = objE_Pedido.IdEmpresa;

                                                objBL_Pedido.Elimina(objE_Pedido);

                                                XtraMessageBox.Show("El Pedido se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Cargar();
                                            }
                                        }

                                        //Insertamos en la auditoria - Estado de cuenta
                                        #region "Eliminar Abono Club Design"

                                        //EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                        //List<EstadoCuentaBE> lstEstadoCuenta = new List<EstadoCuentaBE>();

                                        List<SeparacionBE> lstSeparacion = new List<SeparacionBE>();
                                        //SeparacionBE objE_EstadoCuenta = new SeparacionBE();
                                        SeparacionBL objBL_Separacion = new SeparacionBL();

                                        lstSeparacion = new SeparacionBL().ListaPedido(Parametros.intEmpresaId, Convert.ToInt32(objBE_Documento.IdPedido), "A");
                                        if (lstSeparacion.Count > 0)
                                        {
                                            //objE_EstadoCuenta = lstSeparacion[0];
                                            foreach (SeparacionBE objE_EstadoCuenta in lstSeparacion)
                                            {
                                                if (objE_EstadoCuenta.NumeroDocumento == "COMCD")
                                                {
                                                    EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                                                    objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                                                    objE_EstadoCuentaHistorial.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                                    objE_EstadoCuentaHistorial.Periodo = objE_EstadoCuenta.Periodo;
                                                    objE_EstadoCuentaHistorial.IdCliente = objE_EstadoCuenta.IdCliente;
                                                    objE_EstadoCuentaHistorial.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                                    objE_EstadoCuentaHistorial.FechaCredito = objE_EstadoCuenta.FechaSeparacion;
                                                    objE_EstadoCuentaHistorial.FechaDeposito = objE_EstadoCuenta.FechaPago;
                                                    objE_EstadoCuentaHistorial.Concepto = objE_EstadoCuenta.Concepto;
                                                    objE_EstadoCuentaHistorial.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                                    objE_EstadoCuentaHistorial.Importe = objE_EstadoCuenta.Importe;
                                                    objE_EstadoCuentaHistorial.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                                                    objE_EstadoCuentaHistorial.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                                    objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                                    objE_EstadoCuentaHistorial.IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                                                    objE_EstadoCuentaHistorial.IdPedido = objE_EstadoCuenta.IdPedido;
                                                    objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                                    objE_EstadoCuentaHistorial.Observacion = objE_EstadoCuenta.Observacion;
                                                    objE_EstadoCuentaHistorial.ObservacionElimina = "MOV CAJA:" + Parametros.strUsuarioLogin + " " + WindowsIdentity.GetCurrent().Name.ToString() + "";
                                                    objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. SOLES";
                                                    objE_EstadoCuentaHistorial.TipoRegistro = "E";
                                                    objE_EstadoCuentaHistorial.FlagEstado = objE_EstadoCuenta.FlagEstado;
                                                    objE_EstadoCuentaHistorial.Usuario = Parametros.strUsuarioLogin;
                                                    objE_EstadoCuentaHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                                    EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                                                    objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaHistorial);

                                                    objBL_Separacion.Elimina(objE_EstadoCuenta);
                                                    XtraMessageBox.Show("Abono Club Design eliminado del estado de cuenta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda" || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho
                    || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion
                    || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad || Parametros.intPerfilId == Parametros.intPerAdministradorTienda)
                {
                    List<ReporteMovimientoCajaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoCajaBL().ListadoDocumento(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));
                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            List<ReporteMovimientoCajaBE> lstReporteTarjeta = null;
                            lstReporteTarjeta = new ReporteMovimientoCajaBL().ListadoTarjeta(0, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));

                            RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
                            objRptMovimientoCaja.VerRptMovimientoCajaTarjetaDocumento(lstReporte, lstReporteTarjeta);
                            objRptMovimientoCaja.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    List<ReporteMovimientoCajaBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoCajaBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
                            objRptMovimientoCaja.VerRptMovimientoCaja_Cajeros(lstReporte);
                            objRptMovimientoCaja.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMovimientoCaja";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoCaja.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMovimientoCaja_DoubleClick(object sender, EventArgs e)
        {
            if (Parametros.intPerfilId == Parametros.intPerTesoreria)
            {
                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvMovimientoCaja_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoCaja.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdTipoDocumento"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == Parametros.intTipoDocRetiroCaja || IdTipoDocumento == Parametros.intTipoDocReciboEgreso)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == Parametros.intTipoDocCambiosDevoluciones || IdTipoDocumento == Parametros.intTipoDocNotaCredito || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        {
                            e.Appearance.BackColor = Color.Green;
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

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdEmpresa = 0;
                int IdTipoDocumento = 0;
                int IdDocumentoVenta = 0;
                string TipoDoc = "";
                string NumeroDocumento = "";
                string Serie = "";
                string Numero = "";

                if (mLista.Count > 0)
                {
                    IdEmpresa = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                    TipoDoc = gvMovimientoCaja.GetFocusedRowCellValue("CodTipoDocumento").ToString();
                    NumeroDocumento = gvMovimientoCaja.GetFocusedRowCellValue("NumeroDocumento").ToString();
                    Serie = NumeroDocumento.Substring(0, 3);
                    Numero = NumeroDocumento.Substring(4, 6);
                }

                string dirFacturacion = "<No Especificado>";

                if (IdEmpresa == 13 && Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
                {
                    dirFacturacion = Parametros.strDireccionUcayali2;
                }
                else if (IdEmpresa == 19 && Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
                {
                    dirFacturacion = Parametros.strDireccionUcayali;
                }
                else
                {
                    dirFacturacion = Parametros.strDireccionUcayali;
                }
                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
                {
                    dirFacturacion = Parametros.strDireccionAndahuaylas;
                }
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
                {
                    dirFacturacion = Parametros.strDireccionMegaplaza;
                }
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott)
                {
                    dirFacturacion = Parametros.strDireccionPrescott;
                }
                if (Parametros.intTiendaId == Parametros.intTiendaAviacion2)
                {
                    dirFacturacion = Parametros.strDireccionAviacion2;
                }

                if (TipoDoc == "TKV")
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerHelpDesk)
                        {
                            #region "Ticket TKV"
                            DocumentoVentaBE objDocumento = null;
                            objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

                            TalonBE objTalon = null;
                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);


                            if (objDocumento != null)
                            {
                                CreaTicket ticket = new CreaTicket();

                                #region "Busca Impresora"
                                bool found = false;
                                PrinterSettings prtSetting = new PrinterSettings();
                                foreach (string prtName in PrinterSettings.InstalledPrinters)
                                {
                                    string printer = "";
                                    if (prtName.StartsWith("\\\\"))
                                    {
                                        printer = prtName.Substring(3);
                                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                                    }
                                    else
                                        printer = prtName;

                                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                                    {
                                        found = true;
                                        ticket.impresora = @printer;
                                    }
                                }

                                if (!found)
                                {
                                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                                }
                                #endregion

                                //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                                //ticket.TextoCentro(dirFacturacion);
                                //ticket.TextoCentro("RUC: 20330676826");
                                ticket.TextoCentro(objTalon.NombreComercial);
                                ticket.TextoCentro(Parametros.strEmpresaNombre);
                                ticket.TextoCentro(objTalon.DireccionFiscal);
                                //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                                if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                                ticket.TextoCentro(Parametros.strEmpresaRuc);
                                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                                ticket.TextoIzquierda(TipoDoc + Serie + "-" + Numero + "  " + objDocumento.Fecha.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
                                ticket.TextoIzquierda("CLIENTE:" + objDocumento.DescCliente);
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                List<DocumentoVentaDetalleBE> lstReporte = null;
                                lstReporte = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

                                foreach (var item in lstReporte)
                                {
                                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                    //ticket.AgregaArticuloDetalle(item.NombreProducto.PadRight(, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                }
                                ticket.LineasTotales();
                                if (objDocumento.TotalBruto > objDocumento.Total) //add 20 may 15
                                {
                                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.TotalBruto), 2));
                                    ticket.AgregaTotales("Descuento", Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2));
                                }
                                ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(objDocumento.Total), 2)); // imprime linea con total
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("Ven:" + objDocumento.DescVendedor);
                                ticket.TextoIzquierda("Ped:" + objDocumento.NumeroPedido);
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro(objTalon.PaginaWeb);
                                if (objDocumento.IdPromocionProxima > 0)
                                {
                                    ticket.CortaTicket();
                                    ticket.TextoCentro("=========================================");
                                    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                    ojbPromocion = new PromocionProximaBL().Selecciona(objDocumento.IdPromocionProxima);
                                    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                    ticket.TextoCentro("=========================================");
                                }
                                //ticket.TextoCentro("=========================================");
                                //ticket.TextoCentro("¡FELICIDADES!");
                                //ticket.TextoCentro("Ganaste 10% dscto.");
                                //ticket.TextoCentro("en LÍNEA NAVIDEÑA 2016 en las marcas:");
                                //ticket.TextoCentro("SANTINI – MIRO – MONTEFIORI – MARANELO");
                                //ticket.TextoCentro("valido del 14 al 28 de Octubre del 2016");
                                //ticket.TextoCentro("Dscto no acumulable con otras promociones");
                                //ticket.TextoCentro("=========================================");
                                ticket.CortaTicket();

                                #region "Ticket Formato 1"

                                //------------------------------------------------------------------------
                                /*                     
                                Ticket ticket = new Ticket();
                                 ticket.AddHeaderLine("               PANORAMA DISTRIBUIDORES");
                                                       ticket.AddHeaderLine("                  " + dirFacturacion);
                                                       ticket.AddHeaderLine("                     RUC: 20330676826");
                                                       ticket.AddHeaderLine("                    AUT: " + objTalon.NumeroAutoriza);
                                                       ticket.AddHeaderLine("                    SERIE: " + objTalon.SerieImpresora);

                                                       ticket.AddSubHeaderLine(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                                       ticket.AddSubHeaderLine("VENDEDOR: " + objDocumento.DescVendedor);
                                                       ticket.AddSubHeaderLine("CLIENTE: " + objDocumento.DescCliente);

                                                       List<DocumentoVentaDetalleBE> lstListaDetalle = null;
                                                       lstListaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

                                                       foreach (var item in lstListaDetalle)
                                                       {
                                                           ticket.AddItem(Convert.ToString(item.Cantidad), Convert.ToString(item.Abreviatura) + "  " + Convert.ToString(item.CodigoProveedor), Convert.ToString(Math.Round(item.PrecioVenta, 2)) + "  " + Convert.ToString(Math.Round(item.ValorVenta, 2)));
                                                           ticket.AddItem("", item.NombreProducto, "");
                                                       }

                                                       ticket.AddTotal("                    TOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal(objDocumento.Total), 2)));

                                                       ticket.AddFooterLine("                  ped: " + objDocumento.NumeroPedido);
                                                       ticket.AddFooterLine("                  caja: " + Parametros.strUsuarioLogin);

                                                       ticket.AddFooterLine("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                                       ticket.AddFooterLine("             CAMBIOS NI DEVOLUCIONES");

                                                       ticket.AddFooterLine("               GRACIAS ÑÑÑ PERÚ POR SU COMPRA");
                                                       ticket.AddFooterLine("      WWW.PANORAMADISTRIBUIDORES.COM");

                                                       bool found = false;
                                                       PrinterSettings prtSetting = new PrinterSettings();
                                                       foreach (string prtName in PrinterSettings.InstalledPrinters)
                                                       {
                                                           string printer = "";
                                                           if (prtName.StartsWith("\\\\"))
                                                           {
                                                               printer = prtName.Substring(3);
                                                               printer = printer.Substring(printer.IndexOf("\\") + 1);
                                                           }
                                                           else
                                                               printer = prtName;

                                                           if (printer.ToUpper().StartsWith("(T)"))
                                                           {
                                                               found = true;
                                                               ticket.PrintTicket(@printer);
                                                           }
                                                       }*/
                                #endregion
                            }

                            #endregion
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Ticket.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (TipoDoc == "TKF")
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerHelpDesk)
                        {
                            #region "Ticket TKF"


                            DocumentoVentaBE objDocumento = null;
                            objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

                            TalonBE objTalon = null;
                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);

                            if (objDocumento != null)
                            {

                                CreaTicket ticket = new CreaTicket();

                                #region "Busca Impresora"
                                bool found = false;
                                PrinterSettings prtSetting = new PrinterSettings();
                                foreach (string prtName in PrinterSettings.InstalledPrinters)
                                {
                                    string printer = "";
                                    if (prtName.StartsWith("\\\\"))
                                    {
                                        printer = prtName.Substring(3);
                                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                                    }
                                    else
                                        printer = prtName;

                                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                                    {
                                        found = true;
                                        ticket.impresora = @printer;
                                    }
                                }

                                if (!found)
                                {
                                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                                }
                                #endregion

                                //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                                //ticket.TextoCentro(dirFacturacion);
                                //ticket.TextoCentro("RUC: 20330676826");
                                ticket.TextoCentro(objTalon.NombreComercial);
                                ticket.TextoCentro(Parametros.strEmpresaNombre);
                                ticket.TextoCentro(objTalon.DireccionFiscal);
                                //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                                if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                                ticket.TextoCentro(Parametros.strEmpresaRuc);
                                ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                                ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                                //ticket.TextoIzquierda(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda(TipoDoc + Serie + "-" + Numero + "  " + objDocumento.Fecha.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                                ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
                                ticket.TextoIzquierdaNLineas("CLIENTE: " + objDocumento.DescCliente);
                                ticket.TextoIzquierda("RUC: " + objDocumento.NumeroDocumento);
                                ticket.TextoIzquierdaNLineas("DIR: " + objDocumento.Direccion);
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();

                                List<DocumentoVentaDetalleBE> lstReporte = null;
                                lstReporte = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

                                foreach (var item in lstReporte)
                                {
                                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                    //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                }
                                ticket.LineasTotales();
                                if (objDocumento.TotalBruto > objDocumento.Total) //add 20 may 15
                                {
                                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.TotalBruto), 2));
                                    ticket.AgregaTotales("Descuento", Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2));
                                }
                                ticket.AgregaTotales("SubTotal", Math.Round(Convert.ToDouble(objDocumento.SubTotal), 2));
                                ticket.AgregaTotales("IGV", Math.Round(Convert.ToDouble(objDocumento.Igv), 2));
                                ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.Total), 2));
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(objDocumento.Total), 2).ToString()) + " Soles");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("Ven:" + objDocumento.DescVendedor);
                                ticket.TextoIzquierda("Ped:" + objDocumento.NumeroPedido);
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                //ticket.TextoCentro("www.panoramadistribuidores.com");
                                ticket.TextoCentro(objTalon.PaginaWeb);
                                if (objDocumento.IdPromocionProxima > 0)
                                {
                                    ticket.CortaTicket();
                                    ticket.TextoCentro("=========================================");
                                    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                    ojbPromocion = new PromocionProximaBL().Selecciona(objDocumento.IdPromocionProxima);
                                    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                    ticket.TextoCentro("=========================================");
                                }
                                ticket.CortaTicket();


                                #region "Ticket Factura Formato 1"
                                /*                            Ticket ticket = new Ticket();

                            ticket.AddHeaderLine("               PANORAMA DISTRIBUIDORES");
                            ticket.AddHeaderLine("                  " + dirFacturacion);
                            ticket.AddHeaderLine("                     RUC: 20330676826");
                            ticket.AddHeaderLine("                    AUT: " + objTalon.NumeroAutoriza);
                            ticket.AddHeaderLine("                    SERIE: " + objTalon.SerieImpresora);

                            //ticket.AddSubHeaderLine(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.AddSubHeaderLine(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + "14/04/2013" + " " + DateTime.Now.ToShortTimeString());

                            ticket.AddSubHeaderLine("VENDEDOR: " + objDocumento.DescVendedor);
                            ticket.AddSubHeaderLine("CLIENTE: " + objDocumento.DescCliente);
                            ticket.AddSubHeaderLine("RUC: " + objDocumento.NumeroDocumento);
                            ticket.AddSubHeaderLine("DIRECCION : " + objDocumento.Direccion);

                            List<DocumentoVentaDetalleBE> lstListaDetalle = null;
                            lstListaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

                            foreach (var item in lstListaDetalle)
                            {
                                ticket.AddItem(Convert.ToString(item.Cantidad), Convert.ToString(item.Abreviatura) + "  " + Convert.ToString(item.CodigoProveedor), Convert.ToString(Math.Round(item.PrecioVenta, 2)) + "  " + Convert.ToString(Math.Round(item.ValorVenta, 2)));
                                ticket.AddItem("", item.NombreProducto, "");
                            }


                            ticket.AddTotal("                    SUBTOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal(objDocumento.SubTotal), 2)));
                            ticket.AddTotal("                    IGV", Convert.ToString(Math.Round(Convert.ToDecimal(objDocumento.Igv), 2)));
                            ticket.AddTotal("                    TOTAL S/", Convert.ToString(Math.Round(Convert.ToDecimal(objDocumento.Total), 2)));

                            ticket.AddFooterLine("                  ped: " + objDocumento.NumeroPedido);
                            ticket.AddFooterLine("                  caja: " + Parametros.strUsuarioLogin);

                            ticket.AddFooterLine("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                            ticket.AddFooterLine("             CAMBIOS NI DEVOLUCIONES");

                            ticket.AddFooterLine("         GRACIAS POR SU COMPRA");
                            ticket.AddFooterLine("    WWW.PANORAMADISTRIBUIDORES.COM");

                            bool found = false;
                            PrinterSettings prtSetting = new PrinterSettings();
                            foreach (string prtName in PrinterSettings.InstalledPrinters)
                            {
                                string printer = "";
                                if (prtName.StartsWith("\\\\"))
                                {
                                    printer = prtName.Substring(3);
                                    printer = printer.Substring(printer.IndexOf("\\") + 1);
                                }
                                else
                                    printer = prtName;

                                if (printer.ToUpper().StartsWith("(T)"))
                                {
                                    found = true;
                                    ticket.PrintTicket(@printer);
                                }
                            }*/
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Ticket.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                #region "BOLETA VENTA FISICA"
                else
                if (TipoDoc == "BOV")
                {
                    DocumentoVentaBE objDocumento = null;
                    objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    //lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objDocumento.IdPedido));
                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(objDocumento.IdDocumentoVenta);

                    if (objDocumento.IdEmpresa == 8)
                    {
                        rptBoletaPanoramaAviacion2 objReporteGuia = new rptBoletaPanoramaAviacion2();
                        objReporteGuia.SetDataSource(lstReporte);

                        bool found = false;
                        PrinterSettings prtSetting = new PrinterSettings();
                        foreach (string prtName in PrinterSettings.InstalledPrinters)
                        {
                            string printer = "";
                            if (prtName.StartsWith("\\\\"))
                            {
                                printer = prtName.Substring(3);
                                printer = printer.Substring(printer.IndexOf("\\") + 1);
                            }
                            else
                                printer = prtName;

                            if (printer.ToUpper().StartsWith("(B)"))
                            {
                                found = true;
                                PrintOptions bufPO = objReporteGuia.PrintOptions;
                                prtSetting.PrinterName = prtName;
                                objReporteGuia.PrintOptions.PrinterName = prtName;

                                int rawKind = -1;
                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                                {
                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                    {
                                        rawKind = prtSetting.PaperSizes[i].RawKind;
                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                        break;
                                    }
                                }
                                if (rawKind == -1)
                                {
                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                            }
                        }

                        if (!found)
                        {
                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    }
                    else
                    {
                        rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
                        objReporteGuia.SetDataSource(lstReporte);

                        bool found = false;
                        PrinterSettings prtSetting = new PrinterSettings();
                        foreach (string prtName in PrinterSettings.InstalledPrinters)
                        {
                            string printer = "";
                            if (prtName.StartsWith("\\\\"))
                            {
                                printer = prtName.Substring(3);
                                printer = printer.Substring(printer.IndexOf("\\") + 1);
                            }
                            else
                                printer = prtName;

                            if (printer.ToUpper().StartsWith("(B)"))
                            {
                                found = true;
                                PrintOptions bufPO = objReporteGuia.PrintOptions;
                                prtSetting.PrinterName = prtName;
                                objReporteGuia.PrintOptions.PrinterName = prtName;

                                int rawKind = -1;
                                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                                {
                                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                    {
                                        rawKind = prtSetting.PaperSizes[i].RawKind;
                                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                        break;
                                    }
                                }
                                if (rawKind == -1)
                                {
                                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                            }
                        }

                        if (!found)
                        {
                            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

                        }
                        objReporteGuia.PrintToPrinter(1, false, 0, 0);

                    }
                }
                #endregion

                #region "FACTURA VENTA FISICA"
                else
                if (TipoDoc == "FAV")
                {
                    DocumentoVentaBE objDocumento = null;
                    objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

                    List<ReporteDocumentoVentaBE> lstReporte = null;
                    //lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objDocumento.IdPedido));
                    lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(objDocumento.IdDocumentoVenta);

                    rptFacturaPanorama objReporteGuia = new rptFacturaPanorama();
                    objReporteGuia.SetDataSource(lstReporte);

                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith("(F)"))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            int rawKind = -1;
                            CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                            for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                            {
                                if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                                {
                                    rawKind = prtSetting.PaperSizes[i].RawKind;
                                    objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                    break;
                                }
                            }
                            if (rawKind == -1)
                            {
                                MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");
                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                }
                #endregion

                else
                if (IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerHelpDesk)
                        {
                            TalonBE objTalon = null;
                            //  objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, 1, IdTipoDocumento);
                            objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);//
                            ImpresionElectronicaLocal(IdDocumentoVenta, objTalon.IdTamanoHoja, objTalon.Impresora, IdEmpresa);

                            //string impresora = "(T)EPSON TM-T20II Receipt";
                            //string Texto = "415-650998  VELA CON TAPA DECOR\n427-1601086  ALFOMBRA\n427-2001292  MANTEL\n437-022196  CANDELERO DECORATIVO\n437-042089  FIG ELEFANTE DECOR\n085-761596  CANASTA CON TAPA\n411-334160  CARACOLES\nQD1506-2365  PICK NAVIDEÑO\nSZ1550-16  PUNTAS DE ARBOL\n046-306016  JG SANTA/HOMBRE-BOTA  IMAN 3PZ 6.5 C\n046-555167  RAMO PONSETIA DECOR 22X35CM     22\n046-555170  RAMO PONSETIA DECOR 22X35CM  \n046-566856  VELA DECOR                      6.7*6.7*12.5\n046-777192  ESTACA SANTA DECOR 25.5X91X2CM  \n046-816534A  COLGADOR P/PUERTA SANTA 31CMH   31\n046-816541B  ADORNO HNIEVE\n046-966818  VELA 7.5X7.5CM                  7.5*7.5\n065-080617  CANDELERO\n";
                            ////RawPrinterHelper.SendStringToPrinter(impresora, "SERIE"+"\n"); // avanza
                            //RawPrinterHelper.SendStringToPrinter(impresora, Texto); // avanza

                            //string corte = "\x1B" + "m";                  // caracteres de corte
                            //string avance = "\x1B" + "d" + "\x09";        // avanza 9 renglones
                            ////RawPrinterHelper.SendStringToPrinter(impresora, avance); // avanza
                            //RawPrinterHelper.SendStringToPrinter(impresora, corte); // corta

                            #region "Imprimir"
                            //DocumentoVentaBE mDocumentoVentaE = new DocumentoVentaBE();
                            //mDocumentoVentaE = new DocumentoVentaBL().SeleccionaFE(IdDocumentoVenta);

                            //string sNombreArchivo = mDocumentoVentaE.Ruc + "_" + mDocumentoVentaE.IdConTipoComprobantePago + "_" + mDocumentoVentaE.Serie + "_" + mDocumentoVentaE.Numero;
                            ////PDF
                            //byte[] datap = WS.uf_facele_cn_documento_fisico(mDocumentoVentaE.Ruc, mDocumentoVentaE.IdConTipoComprobantePago, mDocumentoVentaE.Serie, mDocumentoVentaE.Numero, "PDF", "C");
                            //File.WriteAllBytes(sNombreArchivo + ".pdf", datap);

                            //#region "Imprimir"
                            //ProcessStartInfo info = new ProcessStartInfo();
                            //info.Verb = "print";
                            //info.FileName = @"" + sNombreArchivo + ".pdf";
                            //info.CreateNoWindow = true;
                            //info.WindowStyle = ProcessWindowStyle.Hidden;

                            //Process p = new Process();
                            //p.StartInfo = info;
                            //p.Start();

                            //p.WaitForInputIdle();
                            //System.Threading.Thread.Sleep(3000);
                            //if (false == p.CloseMainWindow())
                            //    p.Kill();
                            //#endregion
                            #endregion
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Comprobante electrónico.\nSin embargo UD. Puede descargar el PDF y XML desde la página web.\nConsultar con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }



                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }

        private void cboCaja_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }

        private void recuperardocumentotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvMovimientoCaja.RowCount > 0 && bool.Parse(gvMovimientoCaja.GetFocusedRowCellValue("FlagEstado").ToString()) == false)
            {
                int IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());

                if (IdDocumentoVenta > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                    objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);

                    if (objE_DocumentoVenta.IdSituacionPSE == Parametros.intSitAnuladoPSE)
                    {
                        XtraMessageBox.Show("No se puede recuperar, El comprobante ya fue enviado a la SUNAT.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "rvega")
                        {
                            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                            objE_MovimientoCaja.IdMovimientoCaja = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMovimientoCaja").ToString());
                            objE_MovimientoCaja.Fecha = DateTime.Parse(gvMovimientoCaja.GetFocusedRowCellValue("Fecha").ToString());
                            objE_MovimientoCaja.IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                            objE_MovimientoCaja.IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                            objE_MovimientoCaja.NumeroDocumento = gvMovimientoCaja.GetFocusedRowCellValue("NumeroDocumento").ToString();
                            objE_MovimientoCaja.IdEmpresa = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdEmpresa").ToString());

                            MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                            objBL_MovimientoCaja.RecuperaDocumentoVenta(objE_MovimientoCaja);

                            XtraMessageBox.Show("El registro se recuperó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();


                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    InicializarModificar();
                }

            }

        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad
                || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion || Parametros.intPerfilId == Parametros.intPerHelpDesk
                || Parametros.intPerfilId == Parametros.intPerAsistenteCreditos || Parametros.intPerfilId == Parametros.intPerTesoreria)
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivoAuditoria(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
            }
            else
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
            }
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);

        }

        private void verdocumentoventatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvMovimientoCaja.RowCount > 0)
            {
                int IdDocumentoVenta = 0;
                IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());

                if (IdDocumentoVenta > 0)
                {
                    frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                    objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                    objRegFacturacionEdit.IdDocumentoVenta = IdDocumentoVenta;
                    objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                    objRegFacturacionEdit.btnGrabar.Enabled = false;
                    objRegFacturacionEdit.mnuContextual.Enabled = false;
                    objRegFacturacionEdit.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("No existe documentos asociados para este movimiento.");
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void verpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMovimientoCaja.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdPedido").ToString());
                    if (IdPedido > 0)
                    {
                        frmRegPedidoEdit frm = new frmRegPedidoEdit();
                        frm.IdPedido = IdPedido;
                        frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Este documento no tiene pedido, desea abrir el comprobante?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int IdDocumentoVenta = 0;
                            IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());

                            if (IdDocumentoVenta > 0)
                            {
                                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                                objRegFacturacionEdit.IdDocumentoVenta = IdDocumentoVenta;
                                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                                objRegFacturacionEdit.btnGrabar.Enabled = false;
                                objRegFacturacionEdit.mnuContextual.Enabled = false;
                                objRegFacturacionEdit.ShowDialog();
                            }
                            else
                            {
                                XtraMessageBox.Show("No existe documentos asociados para este movimiento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarvueltotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvMovimientoCaja.RowCount > 0)
            {

                MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                objMovimientoCaja.IdMovimientoCaja = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMovimientoCaja").ToString());
                objMovimientoCaja.Fecha = DateTime.Parse(gvMovimientoCaja.GetFocusedRowCellValue("Fecha").ToString());
                objMovimientoCaja.IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                objMovimientoCaja.NumeroCondicion = gvMovimientoCaja.GetFocusedRowCellValue("NumeroCondicion").ToString();

                int IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                if (IdTipoDocumento == Parametros.intTipoDocRecibPorHonorario || IdTipoDocumento == Parametros.intTipoDocFacturaCompra || IdTipoDocumento == Parametros.intTipoDocReciboEgreso || IdTipoDocumento == Parametros.intTipoDocRetiroCaja || IdTipoDocumento == 0)
                {
                    frmRegMovimientoCajaSalidaEdit objManMovimientoCaja = new frmRegMovimientoCajaSalidaEdit();
                    objManMovimientoCaja.pOperacion = frmRegMovimientoCajaSalidaEdit.Operacion.Nuevo;
                    objManMovimientoCaja.IdMovimientoCaja = 0;
                    objManMovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objManMovimientoCaja.IdTienda = Parametros.intTiendaId;
                    objManMovimientoCaja.IdCaja = Parametros.intCajaId;
                    objManMovimientoCaja.FechaD = DateTime.Now;
                    objManMovimientoCaja.Origen = 1;
                    objManMovimientoCaja.strTipoMovimiento = "I";
                    objManMovimientoCaja.IdMovimientoCajaOrigen = objMovimientoCaja.IdMovimientoCaja;
                    objManMovimientoCaja.StartPosition = FormStartPosition.CenterParent;
                    if (objManMovimientoCaja.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vuelto no disponible para este tipo de documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void despachartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidoBL objBL_Pedido = new PedidoBL();
            PedidoBE objE_Pedido = new PedidoBE();

            MovimientoPedidoBE objMovimientoPedido = new MovimientoPedidoBE();
            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            int IdPedido = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdPedido").ToString());


            if (IdPedido > 0)
            {
                objE_Pedido = objBL_Pedido.Selecciona(IdPedido);
                if (objE_Pedido.IdSituacion == Parametros.intFacturado)
                {
                    objMovimientoPedido.IdPedido = IdPedido;
                    objMovimientoPedido.CantidadBulto = 0;
                    objMovimientoPedido.IdDespachador = Parametros.intPersonaId;

                    objBL_MovimientoPedido.ActualizaOrigenDespacho(IdPedido, Parametros.strDescCaja);
                    objBL_MovimientoPedido.ActualizaDespachador(objMovimientoPedido);
                    objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnAlmacenDespacho, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                    XtraMessageBox.Show("El Pedido se despacho correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                {
                    if (XtraMessageBox.Show("El pedido ya está despachado en " + objE_Pedido.Despachar + ", Desea modificar al despacho por esta caja?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objMovimientoPedido.IdPedido = IdPedido;
                        objMovimientoPedido.CantidadBulto = 0;
                        objMovimientoPedido.IdDespachador = Parametros.intPersonaId;

                        objBL_MovimientoPedido.ActualizaOrigenDespacho(IdPedido, Parametros.strDescCaja);
                        objBL_MovimientoPedido.ActualizaDespachador(objMovimientoPedido);
                        objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnAlmacenDespacho, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

                    }
                }
                else
                {
                    XtraMessageBox.Show("No se puede despachar un autoservicio, opción válida sólo para pedidos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("No se puede despachar un autoservicio, opción válida sólo para pedidos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoCajaBL().ListaTodosActivo(Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));
            dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoCaja.DataSource = dt;
            gvMovimientoCaja.Columns[3].Visible = false;
            gvMovimientoCaja.Columns[4].Visible = false;
        }

        public void InicializarModificar()
        {
            if (gvMovimientoCaja.RowCount > 0)
            {
                MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                objMovimientoCaja.IdMovimientoCaja = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMovimientoCaja").ToString());
                objMovimientoCaja.IdPago = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdPago").ToString());
                objMovimientoCaja.Fecha = DateTime.Parse(gvMovimientoCaja.GetFocusedRowCellValue("Fecha").ToString());
                objMovimientoCaja.IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                objMovimientoCaja.NumeroCondicion = gvMovimientoCaja.GetFocusedRowCellValue("NumeroCondicion").ToString();

                int IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                if (IdTipoDocumento == Parametros.intTipoDocRecibPorHonorario || IdTipoDocumento == Parametros.intTipoDocFacturaCompra || IdTipoDocumento == Parametros.intTipoDocReciboEgreso || IdTipoDocumento == Parametros.intTipoDocRetiroCaja || IdTipoDocumento == Parametros.intTipoDocIngresoCaja || IdTipoDocumento == 0)
                {
                    bool FlagRetiroCliente = bool.Parse(gvMovimientoCaja.GetFocusedRowCellValue("FlagRetiroCliente").ToString());
                    if (FlagRetiroCliente)
                    {
                        objMovimientoCaja.TipoTarjeta = gvMovimientoCaja.GetFocusedRowCellValue("TipoTarjeta").ToString();

                        frmRegReciboEgresoEdit objRegReciboEgresoEdit = new frmRegReciboEgresoEdit();
                        objRegReciboEgresoEdit.pOperacion = frmRegReciboEgresoEdit.Operacion.Modificar;
                        //objRegReciboEgresoEdit.IdPago = objMovimientoCaja.IdPago == null? 0: objMovimientoCaja.IdPago;
                        objRegReciboEgresoEdit.IdPago = objMovimientoCaja.IdPago.GetValueOrDefault();
                        objRegReciboEgresoEdit.sTipoTarjeta = objMovimientoCaja.TipoTarjeta;
                        objRegReciboEgresoEdit.FechaD = objMovimientoCaja.Fecha;
                        objRegReciboEgresoEdit.StartPosition = FormStartPosition.CenterParent;
                        if (objRegReciboEgresoEdit.ShowDialog() == DialogResult.OK)
                        {
                            Cargar();
                        }
                    }
                    else
                    {
                        frmRegMovimientoCajaSalidaEdit objRegMovimientoCajaEdit = new frmRegMovimientoCajaSalidaEdit();
                        objRegMovimientoCajaEdit.pOperacion = frmRegMovimientoCajaSalidaEdit.Operacion.Modificar;
                        objRegMovimientoCajaEdit.IdMovimientoCaja = objMovimientoCaja.IdMovimientoCaja;
                        objRegMovimientoCajaEdit.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        objRegMovimientoCajaEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                        objRegMovimientoCajaEdit.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objRegMovimientoCajaEdit.FechaD = objMovimientoCaja.Fecha;
                        //objRegMovimientoCajaEdit.IdDocumentoVenta = 0;// objMovimientoCaja.IdDocumentoVenta;
                        objRegMovimientoCajaEdit.StartPosition = FormStartPosition.CenterParent;
                        if (objRegMovimientoCajaEdit.ShowDialog() == DialogResult.OK)
                        {
                            Cargar();
                        }
                    }
                }
                else
                {
                    frmRegMovimientoCajaEdit objRegMovimientoCajaEdit = new frmRegMovimientoCajaEdit();
                    objRegMovimientoCajaEdit.pOperacion = frmRegMovimientoCajaEdit.Operacion.Modificar;
                    objRegMovimientoCajaEdit.IdMovimientoCaja = objMovimientoCaja.IdMovimientoCaja;
                    objRegMovimientoCajaEdit.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objRegMovimientoCajaEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objRegMovimientoCajaEdit.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objRegMovimientoCajaEdit.FechaD = objMovimientoCaja.Fecha;
                    objRegMovimientoCajaEdit.IdDocumentoVenta = objMovimientoCaja.IdDocumentoVenta;
                    objRegMovimientoCajaEdit.StartPosition = FormStartPosition.CenterParent;
                    if (objRegMovimientoCajaEdit.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }

                //frmRegMovimientoCajaEdit objRegMovimientoCajaEdit = new frmRegMovimientoCajaEdit();
                //objRegMovimientoCajaEdit.pOperacion = frmRegMovimientoCajaEdit.Operacion.Modificar;
                //objRegMovimientoCajaEdit.IdMovimientoCaja = objMovimientoCaja.IdMovimientoCaja;
                //objRegMovimientoCajaEdit.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                //objRegMovimientoCajaEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                //objRegMovimientoCajaEdit.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                //objRegMovimientoCajaEdit.FechaD = objMovimientoCaja.Fecha;
                //objRegMovimientoCajaEdit.IdDocumentoVenta = objMovimientoCaja.IdDocumentoVenta;
                //objRegMovimientoCajaEdit.StartPosition = FormStartPosition.CenterParent;
                //if (objRegMovimientoCajaEdit.ShowDialog() == DialogResult.OK)
                //{
                //    Cargar();
                //}


            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvMovimientoCaja.GetFocusedRowCellValue("IdMovimientoCaja").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void ValidarCierre()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho 
                    || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion
                    || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad
                    || Parametros.strUsuarioLogin == "bsilva")
                {
                    //permitido master y Auditoria
                }
                else
                {
                    if (deFecha.DateTime < Convert.ToDateTime(DateTime.Now.AddDays(-3)))
                    {
                        XtraMessageBox.Show("Fecha no Permitida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        deFecha.EditValue = DateTime.Now;
                        return;
                    }
                }

                List<CajaCierreBE> Obj_CajaCierre = new List<CajaCierreBE>();
                Obj_CajaCierre = new CajaCierreBL().ListaFechaCaja(Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToInt32(cboCaja.EditValue));

                if (Obj_CajaCierre.Count > 0)
                {
                    XtraMessageBox.Show("La Caja está Cerrada!, no se puede modificar, Consulte con su administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DesHabilitarBotones();

                    if (XtraMessageBox.Show("Desea abrir para modificar?, Sólo los usuarios de nivel administrador tienen esta opción \n ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AbrirCajaCerrada();
                    }
                }
                else
                {
                    HabilitarBotones();
                    Cargar();
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarBotones()
        {
            tlbMenu.Enabled = true;
            //gcMovimientoCaja.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            tlbMenu.Enabled = false;
            //gcMovimientoCaja.Enabled = false;

        }

        private void AbrirCajaCerrada()
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master")
                {
                    CajaCierreBL objBL_CajaCierre = new CajaCierreBL();
                    CajaCierreBE objE_CajaCierre = new CajaCierreBE();
                    objE_CajaCierre.IdCajaCierre = 0;
                    objE_CajaCierre.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objE_CajaCierre.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_CajaCierre.FlagEstado = false;
                    objE_CajaCierre.Usuario = Parametros.strUsuarioLogin;
                    objE_CajaCierre.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_CajaCierre.EliminaFecha(objE_CajaCierre);
                    XtraMessageBox.Show("Caja Abierta!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarBotones();
                    Cargar();
                }
                else
                {
                    XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void GrabarAnulaVentaIntegrens(int IdDocumentoVenta)
        {
            //#region "Cabecera"

            //DocumentoVentaBE objE_DocumentoVenta = null;
            //objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdDocumentoVenta);
            ////mDocumentoVentaE = objE_DocumentoVenta;

            //List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            //lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdDocumentoVenta);


            //DataTable facelecab = new DataTable();
            //facelecab.Columns.Add("ipserver", Type.GetType("System.String"));
            //facelecab.Columns.Add("instance", Type.GetType("System.String"));
            //facelecab.Columns.Add("dbname", Type.GetType("System.String"));
            //facelecab.Columns.Add("numruc", Type.GetType("System.String"));
            //facelecab.Columns.Add("altido", Type.GetType("System.String"));
            //facelecab.Columns.Add("sersun", Type.GetType("System.String"));
            //facelecab.Columns.Add("numsun", Type.GetType("System.String"));
            //facelecab.Columns.Add("fecemi", Type.GetType("System.String"));
            //facelecab.Columns.Add("codmnd", Type.GetType("System.String"));
            //facelecab.Columns.Add("tidoid", Type.GetType("System.String"));
            //facelecab.Columns.Add("numidn", Type.GetType("System.String"));
            //facelecab.Columns.Add("nomcli", Type.GetType("System.String"));
            //facelecab.Columns.Add("tidore", Type.GetType("System.String"));
            //facelecab.Columns.Add("nudore", Type.GetType("System.String"));
            //facelecab.Columns.Add("basafe", Type.GetType("System.String"));
            //facelecab.Columns.Add("basina", Type.GetType("System.String"));
            //facelecab.Columns.Add("basexo", Type.GetType("System.String"));
            //facelecab.Columns.Add("mongra", Type.GetType("System.String"));
            //facelecab.Columns.Add("mondsc", Type.GetType("System.String"));
            //facelecab.Columns.Add("monigv", Type.GetType("System.String"));
            //facelecab.Columns.Add("monisc", Type.GetType("System.String"));
            //facelecab.Columns.Add("monotr", Type.GetType("System.String"));
            //facelecab.Columns.Add("dscglo", Type.GetType("System.String"));
            //facelecab.Columns.Add("monoca", Type.GetType("System.String"));
            //facelecab.Columns.Add("mondoc", Type.GetType("System.String"));
            //facelecab.Columns.Add("basper", Type.GetType("System.String"));
            //facelecab.Columns.Add("monper", Type.GetType("System.String"));
            //facelecab.Columns.Add("totdoc", Type.GetType("System.String"));
            //facelecab.Columns.Add("mopedo", Type.GetType("System.String"));
            //facelecab.Columns.Add("todope", Type.GetType("System.String"));
            //facelecab.Columns.Add("totant", Type.GetType("System.String"));
            //facelecab.Columns.Add("cobide", Type.GetType("System.String"));
            //facelecab.Columns.Add("ctadet", Type.GetType("System.String"));
            //facelecab.Columns.Add("prcdet", Type.GetType("System.String"));
            //facelecab.Columns.Add("mondet", Type.GetType("System.String"));
            //facelecab.Columns.Add("codmot", Type.GetType("System.String"));
            //facelecab.Columns.Add("tidomd", Type.GetType("System.String"));
            //facelecab.Columns.Add("nudomd", Type.GetType("System.String"));
            //facelecab.Columns.Add("fedomd", Type.GetType("System.String"));
            //facelecab.Columns.Add("tidove", Type.GetType("System.String"));
            //facelecab.Columns.Add("nudove", Type.GetType("System.String"));
            //facelecab.Columns.Add("tipcam", Type.GetType("System.String"));
            //facelecab.Columns.Add("codcli", Type.GetType("System.String"));
            //facelecab.Columns.Add("ubifis", Type.GetType("System.String"));
            //facelecab.Columns.Add("dirfis", Type.GetType("System.String"));
            //facelecab.Columns.Add("tiodre", Type.GetType("System.String"));
            //facelecab.Columns.Add("nuodre", Type.GetType("System.String"));
            //facelecab.Columns.Add("coddoc", Type.GetType("System.String"));
            //facelecab.Columns.Add("numdoc", Type.GetType("System.String"));
            //facelecab.Columns.Add("tipped", Type.GetType("System.String"));
            //facelecab.Columns.Add("numped", Type.GetType("System.String"));
            //facelecab.Columns.Add("dester", Type.GetType("System.String"));
            //facelecab.Columns.Add("ordcom", Type.GetType("System.String"));
            //facelecab.Columns.Add("fecvct", Type.GetType("System.String"));
            //facelecab.Columns.Add("observ", Type.GetType("System.String"));
            //facelecab.Columns.Add("estreg", Type.GetType("System.String"));
            //facelecab.Columns.Add("defopa", Type.GetType("System.String"));
            //facelecab.Columns.Add("texglo", Type.GetType("System.String"));
            //facelecab.Columns.Add("corepe", Type.GetType("System.String"));
            //facelecab.Columns.Add("prcper", Type.GetType("System.String"));
            //facelecab.Columns.Add("fecped", Type.GetType("System.String"));

            //DataRow dr;
            //dr = facelecab.NewRow();
            //dr["ipserver"] = "panorama_interface";
            //dr["instance"] = "postgres";
            //dr["dbname"] = "ifac_panorama";
            //dr["numruc"] = Parametros.strEmpresaRuc;
            //dr["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;//"01";
            //dr["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            //dr["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            //dr["fecemi"] = objE_DocumentoVenta.Fecha;// "27/11/2017 10:00:00 a.m.";
            //dr["codmnd"] = objE_DocumentoVenta.CodMoneda;//"USD";
            //dr["tidoid"] = objE_DocumentoVenta.TipoIdentidad;// "6";
            //dr["numidn"] = objE_DocumentoVenta.NumeroDocumento;// "20330676826"; //****ACTIVO Y HABIDO
            //dr["nomcli"] = objE_DocumentoVenta.DescCliente;// "PANORAMA DISTRIB";
            //dr["tidore"] = "";
            //dr["nudore"] = "";
            //dr["basafe"] = objE_DocumentoVenta.SubTotal;// "19226.86000"; ??
            //dr["basina"] = "0.00000";
            //dr["basexo"] = "0.00000";
            //dr["mongra"] = "0.00000"; //SÓLO SIN SON GRATUITAS
            //dr["mondsc"] = "0.00000";
            //dr["monigv"] = objE_DocumentoVenta.Igv;//"3460.83000";
            //dr["monisc"] = "0.00000";
            //dr["monotr"] = "0.00000";
            //dr["dscglo"] = "0.00000";//Descuentos globales
            //dr["monoca"] = "0.00000";
            //dr["mondoc"] = objE_DocumentoVenta.Total; //"22687.69000";
            //dr["basper"] = "0.00000";
            //dr["monper"] = "0.00000";
            //dr["totdoc"] = "0.00000";
            //dr["mopedo"] = "0.00000";
            //dr["todope"] = objE_DocumentoVenta.Total;// "22687.69000";
            //dr["totant"] = objE_DocumentoVenta.Total;//"22687.69000"; ANTICIPOS
            //dr["cobide"] = "";
            //dr["ctadet"] = "";
            //dr["prcdet"] = "0.00000";
            //dr["mondet"] = "0.00000";
            //dr["codmot"] = "";
            //dr["tidomd"] = "";
            //dr["nudomd"] = "";
            //dr["fedomd"] = "";
            //dr["tidove"] = "1";//Ver caso Carnet de Extranjería
            //dr["nudove"] = objE_DocumentoVenta.DniVendedor;//"42309349";
            //dr["tipcam"] = objE_DocumentoVenta.TipoCambio;// "3.42100";
            //dr["codcli"] = objE_DocumentoVenta.IdCliente;// "80-00-5089";
            //dr["ubifis"] = objE_DocumentoVenta.IdUbigeoDom;// "110108";
            //dr["dirfis"] = objE_DocumentoVenta.Direccion;//"AV.EL ZINC 271 URB.INSDUSTRIAL INFENTAS";
            //dr["tiodre"] = "";
            //dr["nuodre"] = "";
            //dr["coddoc"] = "";
            //dr["numdoc"] = "";
            //dr["tipped"] = "NRO";
            //dr["numped"] = objE_DocumentoVenta.NumeroPedido;// "000001";
            //dr["dester"] = objE_DocumentoVenta.DescFormaPago;// "CONTADO CONTRA ENTREGA";
            //dr["ordcom"] = objE_DocumentoVenta.Periodo.ToString() + "-" + objE_DocumentoVenta.NumeroPedido;// "GG-0034-2016";
            //dr["fecvct"] = ""; //Consultar
            //dr["observ"] = "";//"CONTROL: 22216 MERCADERIA ENTREGADA EN: T.C: 3.42100 VENDEDOR: EMMA GARCIA FECHA PEDIDO: 2017 - 06 - 19 FECHA ORD: 2017 - 06 - 19 - INCORPORADO AL REGIMEN DE AGENTES DE RETENCION DEL IGV SEGUN RS Nchar(176) 378 - 2013 SUNAT";
            //dr["estreg"] = "AN";//CO = Correcto; AN= Anulado
            //dr["defopa"] = "";
            //dr["texglo"] = "";
            //dr["corepe"] = "";
            //dr["prcper"] = "0";
            //dr["fecped"] = objE_DocumentoVenta.Fecha;// "27/11/2017 09:00:00 a.m.";

            //facelecab.Rows.Add(dr);
            //facelecab.TableName = "facelecab";

            //DataSet dsCabecera = new DataSet();
            //dsCabecera.Tables.Add(facelecab);

            //#endregion

            //#region "Detalle"

            //DataTable faceledet = new DataTable();
            //faceledet.Columns.Add("numruc");
            //faceledet.Columns.Add("altido");
            //faceledet.Columns.Add("sersun");
            //faceledet.Columns.Add("numsun");
            //faceledet.Columns.Add("nroitm");
            //faceledet.Columns.Add("coduni");
            //faceledet.Columns.Add("canped");
            //faceledet.Columns.Add("codpro");
            //faceledet.Columns.Add("nompro");
            //faceledet.Columns.Add("valbas");
            //faceledet.Columns.Add("mondsc");
            //faceledet.Columns.Add("preuni");
            //faceledet.Columns.Add("monigv");
            //faceledet.Columns.Add("codafe");
            //faceledet.Columns.Add("monisc");
            //faceledet.Columns.Add("tipisc");
            //faceledet.Columns.Add("prelis");
            //faceledet.Columns.Add("valref");
            //faceledet.Columns.Add("totuni");
            //faceledet.Columns.Add("montot");
            //faceledet.Columns.Add("monper");
            //faceledet.Columns.Add("nomabr");
            //faceledet.Columns.Add("eanbar");
            //faceledet.Columns.Add("desdet");

            //foreach (var item in lstTmpDocumentoVentaDetalle)
            //{
            //    DataRow dr2;
            //    dr2 = faceledet.NewRow();
            //    dr2["numruc"] = Parametros.strEmpresaRuc;//"20330676826";
            //    dr2["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            //    dr2["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            //    dr2["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            //    dr2["nroitm"] = item.Item; //"1";
            //    dr2["coduni"] = item.Abreviatura;//"UND";
            //    dr2["canped"] = item.Cantidad;// "1.00000";
            //    dr2["codpro"] = item.IdProducto;// "PB000001";
            //    dr2["nompro"] = item.NombreProducto;// "ANTICIPO DE ORDEN DE COMPRA GG-0034-2016";
            //    dr2["valbas"] = item.PrecioUnitario;// "19226.86000";
            //    dr2["mondsc"] = item.Descuento; //"0.00000";
            //    dr2["preuni"] = item.PrecioVenta;// "19226.86000";
            //    dr2["monigv"] = (Convert.ToDouble(item.Cantidad) * (Convert.ToDouble(item.PrecioVenta) - ((Convert.ToDouble(item.PrecioVenta) / Parametros.dblIGV)))).ToString(); //"3460.83000";
            //    dr2["codafe"] = "10"; //Tipo de Afectación del IGV
            //    dr2["monisc"] = "0.00000";
            //    dr2["tipisc"] = "0";
            //    dr2["prelis"] = item.PrecioVenta;//"22687.69000";
            //    dr2["valref"] = "0.00000"; //Sólo si es gratuito
            //    dr2["totuni"] = item.PrecioUnitario * item.Cantidad;// "19226.86000";
            //    dr2["montot"] = item.ValorVenta; //"22687.69000";
            //    dr2["monper"] = "0.00000";
            //    dr2["nomabr"] = "ANTICIPO DE ORDEN DE COMP";//??? DACTA
            //    dr2["eanbar"] = "";
            //    dr2["desdet"] = "";

            //    faceledet.Rows.Add(dr2);
            //}

            //faceledet.TableName = "faceledet";

            //DataSet dsDetalle = new DataSet();
            //dsDetalle.Tables.Add(faceledet);

            //#endregion

            //#region "Adicional"

            //DataTable faceleant = new DataTable();
            //faceleant.Columns.Add("numruc");
            //faceleant.Columns.Add("altido");
            //faceleant.Columns.Add("sersun");
            //faceleant.Columns.Add("numsun");
            //faceleant.Columns.Add("nroitm");
            //faceleant.Columns.Add("tidoan");
            //faceleant.Columns.Add("docant");
            //faceleant.Columns.Add("tidoem");
            //faceleant.Columns.Add("nudoem");
            //faceleant.Columns.Add("monant");

            //DataRow dr3;
            //dr3 = faceleant.NewRow();
            //dr3["numruc"] = Parametros.strEmpresaRuc;//"20330676826";
            //dr3["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            //dr3["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            //dr3["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            //dr3["nroitm"] = "1";
            //dr3["tidoan"] = "01";
            //dr3["docant"] = objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;//  "F001-00000001";
            //dr3["tidoem"] = "6";//Ruc de Panorama
            //dr3["nudoem"] = Parametros.strEmpresaRuc;//"20330676826";
            //dr3["monant"] = objE_DocumentoVenta.Total;//"22687.69000";

            //faceleant.Rows.Add(dr3);
            //faceleant.TableName = "faceleant";

            //DataSet dsAdicional = new DataSet();
            //dsAdicional.Tables.Add(faceleant);

            //#endregion

            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N");

            //if (MensajeService.ToUpper() != "OK")
            //{
            //    XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //    objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);

            //    XtraMessageBox.Show("Documento dado de baja correctamente. " + MensajeService.ToUpper(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        private void ImpresionElectronicaLocal(int IdDocumentoVenta, int IdTamanoHoja, string Impresora, int IdEmpresa)
        {
            //frmListaPrinters frmPrinter = new frmListaPrinters();
            //if (frmPrinter.ShowDialog() == DialogResult.OK)
            //{

            if (IdTamanoHoja == Parametros.intTamanoA4)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    #region "Codigo QR"
                    int Regs = lstReporte.Count() - 1;
                    //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(ValorQR, out qrCode);

                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();

                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                    //imagen.Save("imagen.png", ImageFormat.Png);
                    #endregion
                    rptFacturaElectronicaPanoramaA4 objReporteGuia = new rptFacturaElectronicaPanoramaA4();
                    objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                    #region "Buscar Impresora ..."

                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith(Impresora))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            break;
                        }
                    }

                    if (!found)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                        return;
                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                    #endregion

                }
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmTermico)
            {
                #region "Impresión Matricial"
                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali2;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                    dirFacturacion = Parametros.strDireccionUcayali3;
                else
                    dirFacturacion = Parametros.strDireccionUcayali;
                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott) dirFacturacion = Parametros.strDireccionPrescott;


                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                TalonBE objTalon = null;
                objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, lstReporte[0].IdTipoDocumento);// Convert.ToInt32(cboDocumento.EditValue));

                #region "Codigo QR"
                int Regs = lstReporte.Count() - 1;
                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrCode = new QrCode();
                qrEncoder.TryEncode(ValorQR, out qrCode);

                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                MemoryStream ms = new MemoryStream();

                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                var imageTemporal = new Bitmap(ms);
                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                //imagen.Save("imagen.png", ImageFormat.Png);
                #endregion


                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
                bool found = false;
                PrinterSettings prtSetting = new PrinterSettings();
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    string printer = "";
                    if (prtName.StartsWith("\\\\"))
                    {
                        printer = prtName.Substring(3);
                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                    }
                    else
                        printer = prtName;

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                ticket.AbreCajon();
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                ticket.TextoCentro(objTalon.DireccionFiscal);
                if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoCentro(Parametros.strEmpresaRuc);
                ticket.TextoIzquierda("");
                ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                ticket.TextoIzquierda("N° " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                ///ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                ticket.LineasGuion();
                ticket.EncabezadoVenta();

                foreach (var item in lstReporte)
                {
                    ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                }
                ticket.LineasTotales();
                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                {
                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].TotalBruto.ToString());
                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + " " + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                }
                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + " " + lstReporte[0].SubTotal.ToString());
                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + " " + lstReporte[0].Igv.ToString());
                ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + " " + lstReporte[0].Total.ToString());
                ticket.TextoIzquierda("");
                ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                ticket.TextoIzquierda("");

                //Ticket Tk = new Ticket();
                Imagen = lstReporte[Regs].CodigoQR;
                //Tk.HeaderImage = imagen;
                //Tk.PrintTicket(ticket.impresora);
                //PrintDocument pd = new PrintDocument();
                //pd.PrinterSettings.PrinterName = "EPSON TM-T20II Receipt";
                //pd.PrintPage += (sender, args) =>
                //{
                //    //Image i = Image.FromFile("C://tesimage.PNG");
                //    System.Drawing.Image i = (Bitmap)((new ImageConverter()).ConvertFrom(Imagen));// System.Drawing.Image.FromFile("D:\\Foto.jpg");
                //    Point p = new Point(100, 100);
                //    args.Graphics.DrawImage(i, 4, 4, 100, 100);// i.Width, i.Height);
                //};
                //pd.Print();


                //RawPrinterHelper.SendStringToPrinter("EPSON TM-T20II Receipt", Imagen);
                //RawPrinterHelper.SendBytesToPrinter("EPSON TM-T20II Receipt", (IntPtr) Imagen, 1);




                ticket.TextoIzquierda("");
                ticket.TextoCentro("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant());
                ticket.TextoCentro("de Venta Electrónica.");
                ticket.TextoCentro("Consulte su documento en");
                ticket.TextoCentro("https://www.nubefact.com/consulta");
                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                ticket.TextoIzquierda("");
                ticket.TextoCentro("www.panoramahogar.com");
                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                //if (lstReporte[0].IdPromocionProxima > 0)
                //{
                //    ticket.CortaTicket();
                //    ticket.TextoCentro("=========================================");
                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                //    ticket.TextoCentro("=========================================");
                //}
                ticket.CortaTicket();
                #endregion


                #region "Impresión con Crystal Reports"
                //List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                //lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                //if (lstReporte.Count > 0)
                //{

                //    #region "Codigo QR"
                //    int Regs = lstReporte.Count() - 1;
                //    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                //    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                //    QrCode qrCode = new QrCode();
                //    qrEncoder.TryEncode(ValorQR, out qrCode);

                //    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                //    MemoryStream ms = new MemoryStream();

                //    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                //    var imageTemporal = new Bitmap(ms);
                //    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                //    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                //    //imagen.Save("imagen.png", ImageFormat.Png);
                //    #endregion

                //    rptFacturaElectronicaPanorama80mm objReporteGuia = new rptFacturaElectronicaPanorama80mm();
                //    objReporteGuia.SetDataSource(lstReporte);
                //    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                //    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                //    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                //    #region "Buscar Impresora ..."

                //    bool found = false;
                //    PrinterSettings prtSetting = new PrinterSettings();
                //    foreach (string prtName in PrinterSettings.InstalledPrinters)
                //    {
                //        string printer = "";
                //        if (prtName.StartsWith("\\\\"))
                //        {
                //            printer = prtName.Substring(3);
                //            printer = printer.Substring(printer.IndexOf("\\") + 1);
                //        }
                //        else
                //            printer = prtName;

                //        if (printer.ToUpper().StartsWith(Impresora))
                //        {
                //            found = true;
                //            PrintOptions bufPO = objReporteGuia.PrintOptions;
                //            prtSetting.PrinterName = prtName;
                //            objReporteGuia.PrintOptions.PrinterName = prtName;

                //            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                //            break;
                //        }
                //    }

                //    if (!found)
                //    {
                //        Cursor = Cursors.Default;
                //        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                //        return;
                //    }
                //    //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                //    //MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                //    #endregion

                //}

                #endregion
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmMatricial)
            {
                #region "Impresión Matricial"

                string dirFacturacion = "<No Especificado>";

                if (IdEmpresa == 19)
                    dirFacturacion = Parametros.strDireccionUcayali;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali2;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                    dirFacturacion = Parametros.strDireccionUcayali3;
                else
                    dirFacturacion = Parametros.strDireccionUcayali;

                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott) dirFacturacion = Parametros.strDireccionPrescott;

                //if (Parametros.intTiendaId == Parametros.intTiendaUcayali) dirFacturacion = Parametros.strDireccionUcayali;


                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                List<MovimientoCajaBE> lstPagosCaja = new List<MovimientoCajaBE>();
                lstPagosCaja = new MovimientoCajaBL().ListaFormaPago(IdDocumentoVenta);

                TalonBE objTalon = null;
                // objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, 1, lstReporte[0].IdTipoDocumento);
                objTalon = new TalonBL().SeleccionaCajaDocumento(lstReporte[0].IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, lstReporte[0].IdTipoDocumento);
                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
                bool found = false;
                PrinterSettings prtSetting = new PrinterSettings();
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    string printer = "";
                    if (prtName.StartsWith("\\\\"))
                    {
                        printer = prtName.Substring(3);
                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                    }
                    else
                        printer = prtName;

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                        break;// verificar antes de publicar
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion


                //List<DocumentoVentaDetalleBE> mListaPromocion2x1 = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);
                //bool bPromocion2x1 = false;
                //var var_ExistePromocion = mListaPromocion2x1.Find(x => x.DescPromocion.Length > 0);
                //if (var_ExistePromocion != null)
                //{
                //    bPromocion2x1 = true;
                //}


                ticket.AbreCajon();

                if (objTalon.NumeroAutoriza == "TERMICA")
                {
                    if (objTalon.IdEmpresa == 3)
                    {
                        #region "2 Copias"
                        string vDeliveryFree19C = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("CORONA IMPORTADORES E.I.R.L.");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            // ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("AV. GUILLERMO PRESCOTT NRO. 329 INT. 101");
                            ticket.TextoCentro("LIMA-LIMA-SAN ISIDRO");
                            //if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            ticket.TextoCentro("20506249601");


                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree19C = Convert.ToString(item.CodigoProveedor);
                                //    //}

                                //}

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.grupoaymservicios.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");
                                //if (vDeliveryFree19C == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}



                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (objTalon.IdEmpresa == 19)
                    {
                        #region "2 Copias"
                        string vDeliveryFree19C = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN NELLY BETHSABE");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10727472873");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree19C = Convert.ToString(item.CodigoProveedor);
                                //    //}

                                //}

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.grupoaymservicios.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");
                                //if (vDeliveryFree19C == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}



                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (objTalon.IdEmpresa == 21)
                    {
                        #region "2 Copias"
                        string vDeliveryFree21C = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN SILVIA LILIANA");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10435468140");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");  // + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasTotalesIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree21C = Convert.ToString(item.CodigoProveedor);
                                //    //}
                                //}

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 279-2019/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.grupoaymservicios.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");

                                //if (vDeliveryFree21C == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}

                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (objTalon.IdEmpresa == 23)
                    {
                        #region "2 Copias Eleazar"
                        string vDeliveryFree21C = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA TARRILLO ELEAZAR");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10068611143");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");  // + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree21C = Convert.ToString(item.CodigoProveedor);
                                //    //}
                                //}

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");

                                //if (vDeliveryFree21C == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}

                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (objTalon.IdEmpresa == 8)
                    {
                        #region "2 Copias Amalia"
                        string vDeliveryFree21C = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("HUAMAN BRAMON TEODORA AMALIA");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10068692968");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");  // + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasTotalesIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree21C = Convert.ToString(item.CodigoProveedor);
                                //    //}
                                //}

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");

                                //if (vDeliveryFree21C == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}

                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else if (objTalon.IdEmpresa == 20)
                    {
                        #region "2 Copias Roxana"
                        string vDeliveryFree21C = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            //ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("TAPIA HUAMAN ROXANA INES");
                            ticket.TextoCentro("VENTA DE ADORNOS PARA EL HOGAR,");
                            ticket.TextoCentro("CRISTALERIA, LAMPARAS Y MANTELERIA");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            ticket.TextoCentro("10426485287");
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");  // + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                //ticket.LineasTotalesIgual();
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree21C = Convert.ToString(item.CodigoProveedor);
                                //    //}
                                //}

                                ticket.LineasTotalesIgual();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica.");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");

                                //if (vDeliveryFree21C == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}

                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }
                        #endregion
                    }
                    else
                    {
                        //Caso autoservicio....?
                        #region "2 Copias"

                        string vDeliveryFree13 = "";
                        for (int i = 1; i <= 3; i++)
                        {
                            ticket.TextoCentro(Parametros.strEmpresaNombre);
                            ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                            ticket.TextoCentro(objTalon.DireccionFiscal);
                            if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                            ticket.TextoCentro(Parametros.strEmpresaRuc);
                            ticket.TextoIzquierda("");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                            //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                            ticket.TextoIzquierda("N° " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                            if (i == 1 || i == 2)
                            {
                                ticket.LineasGuion();
                                ticket.EncabezadoVenta();
                                ticket.LineasIgual();
                                this.Imprimir_Detalle(ticket, lstReporte, IdDocumentoVenta, i); //// 2x1Enmanuel
                                #region "IMPRESION 2x1"
                                //if (bPromocion2x1)
                                //{
                                //    #region "ECM 2022"
                                //    List<DocumentoVentaDetalleBE> mListaSinPromo = mListaPromocion2x1.Where(x => x.DescPromocion.Length == 0).ToList();
                                //    List<DocumentoVentaDetalleBE> nLista2x1 = mListaPromocion2x1.Where(x => x.DescPromocion == "2x1").ToList();
                                //    nLista2x1 = nLista2x1.OrderByDescending(x => x.PrecioUnitario).ToList();

                                //    int SumaCant = 0;
                                //    int l2x1SumaCant = nLista2x1.Sum(x => x.Cantidad);
                                //    // SOLO PRODUCTOS 2x1
                                //    foreach (var item in nLista2x1)
                                //    {
                                //        string Abrev = item.Abreviatura;
                                //        string CodigoPro = item.CodigoProveedor;
                                //        string DescPro = item.DescPromocion;
                                //        string NombreProducto = item.NombreProducto;
                                //        string DescPro_NombrePro = DescPro + " " + NombreProducto;

                                //        int Cantidad = item.Cantidad;
                                //        double PrecioUnitario = Convert.ToDouble(item.PrecioUnitario);
                                //        decimal PrecioVentaPrincpal = item.PrecioVenta;
                                //        decimal ValorVentaPrincpal = item.ValorVenta;

                                //        // Variables UNITARIO
                                //        double PrecioUnitario2 = PrecioUnitario;
                                //        double PrecioUnitarioVenta = Math.Round(Convert.ToDouble(PrecioUnitario) * Convert.ToDouble(Cantidad), 2);
                                //        //Variables PROMO
                                //        double PromoPrecioVenta = Convert.ToDouble(PrecioVentaPrincpal);
                                //        double PromoValorVenta = Convert.ToDouble(ValorVentaPrincpal);
                                //        //Variables IMPAR
                                //        double PorcentajeDescuentoImpar = Convert.ToDouble(item.PorcentajePromocionDetalle);
                                //        double impar_PrecioVenta = PrecioUnitario;
                                //        double impar_ValorVenta = PrecioUnitario;
                                //        //OTROS
                                //        double PorcentajeDescuento = Convert.ToDouble(item.PorcentajeDescuento);
                                //        decimal ValorAcomprobar = Math.Round(Convert.ToDecimal(PrecioUnitario) * ((100 - Convert.ToDecimal(PorcentajeDescuento)) / 100), 2);

                                //        if (item.DescPromocion == "2x1")
                                //        {
                                //            SumaCant += Cantidad;

                                //            if (nLista2x1.Count == 1 && Cantidad == 1)
                                //            {
                                //                ticket.AgregaArticuloCodigo(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(CodigoPro));
                                //                ticket.AgregaArticuloDetalle(DescPro_NombrePro + new string(' ', 20), Convert.ToDouble(Math.Round(PrecioVentaPrincpal, 2)), Convert.ToDouble(Math.Round(ValorVentaPrincpal, 2)));
                                //                continue;
                                //            }

                                //            if (ValorAcomprobar == PrecioVentaPrincpal)
                                //            {
                                //                ticket.AgregaArticuloCodigo(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(CodigoPro));
                                //                ticket.AgregaArticuloDetalle(DescPro_NombrePro + new string(' ', 20), Convert.ToDouble(Math.Round(PrecioVentaPrincpal, 2)), Convert.ToDouble(Math.Round(ValorVentaPrincpal, 2)));
                                //                continue;
                                //            }

                                //            if (Convert.ToInt32(PrecioVentaPrincpal) == 0)
                                //            {
                                //                PrecioVentaPrincpal = Convert.ToDecimal(PrecioUnitario);
                                //                ValorVentaPrincpal = Convert.ToDecimal((PrecioUnitario * Cantidad));

                                //                ticket.AgregaArticuloCodigo2x1(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(CodigoPro), Convert.ToDouble(Math.Round(PrecioUnitario, 2)), Convert.ToDouble(Math.Round((PrecioUnitario * Cantidad), 2)));
                                //                ticket.AgregaArticuloDetalle(DescPro_NombrePro + new string(' ', 20), Convert.ToDouble(Math.Round(PrecioVentaPrincpal, 2)), Convert.ToDouble(Math.Round(ValorVentaPrincpal * (-1), 2)));
                                //                continue;
                                //            }

                                //            #region "Todo ok"
                                //            if (Cantidad % 2 != 0)
                                //            {
                                //                decimal posi = Convert.ToDecimal((PrecioUnitario * Cantidad) - Convert.ToDouble(ValorVentaPrincpal));

                                //                PrecioVentaPrincpal = (posi / Cantidad);
                                //                ValorVentaPrincpal = posi;
                                //            }

                                //            ticket.AgregaArticuloCodigo2x1(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(CodigoPro), Convert.ToDouble(Math.Round(PrecioUnitario, 2)), Convert.ToDouble(Math.Round((PrecioUnitario * Cantidad), 2)));
                                //            ticket.AgregaArticuloDetalle(DescPro_NombrePro + new string(' ', 20), Convert.ToDouble(Math.Round(PrecioVentaPrincpal, 2)), Convert.ToDouble(Math.Round(ValorVentaPrincpal * (-1), 2)));
                                //            #endregion

                                //            #region "En pruebas"
                                //            //    // Dos Productos , cada uno con cantidad 7,5
                                //            //    double precio1 = PrecioUnitario;
                                //            //double precio2 = (PrecioUnitario * Cantidad);

                                //            //bool Impar = false;
                                //            //if (Cantidad % 2 != 0)
                                //            //{
                                //            //    Impar = true;
                                //            //    Cantidad -= 1;

                                //            //    PrecioUnitarioVenta -= impar_PrecioVenta;
                                //            //    PromoPrecioVenta = (impar_ValorVenta / 2);
                                //            //    PromoValorVenta = (PromoPrecioVenta * Cantidad);

                                //            //    precio1 = Convert.ToDouble(ValorVentaPrincpal) / Cantidad;
                                //            //    precio2 = Convert.ToDouble(ValorVentaPrincpal);
                                //            //}

                                //            //ticket.AgregaArticuloCodigo2x1(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(CodigoPro), Convert.ToDouble(Math.Round(precio1, 2)), Convert.ToDouble(Math.Round((precio2), 2)));
                                //            //ticket.AgregaArticuloDetalle(DescPro_NombrePro + new string(' ', 20), Convert.ToDouble(Math.Round(PromoPrecioVenta, 2)), Convert.ToDouble(Math.Round(PromoValorVenta * (-1), 2)));

                                //            //if (Impar)
                                //            //{
                                //            //    if (SumaCant == l2x1SumaCant)
                                //            //    {
                                //            //        if (PorcentajeDescuentoImpar != 0)
                                //            //        {
                                //            //            double PrecioVentaDescuentoImpar = Math.Round(Convert.ToDouble(PrecioUnitario2) * ((100 - Convert.ToDouble(PorcentajeDescuentoImpar)) / 100), 2);
                                //            //            impar_PrecioVenta = PrecioVentaDescuentoImpar;
                                //            //            impar_ValorVenta = PrecioVentaDescuentoImpar;
                                //            //        }
                                //            //    }
                                //            //    ticket.AgregaArticuloCodigo2x1(Convert.ToInt32(1), Convert.ToString(Abrev), Convert.ToString(CodigoPro), impar_PrecioVenta, impar_ValorVenta);
                                //            //}
                                //            #endregion

                                //        }
                                //    }
                                //    // SOLO PRODUCTOS
                                //    foreach (var item in mListaSinPromo)
                                //    {
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    }
                                //    #endregion
                                //}
                                //else
                                //{
                                //foreach (var item in lstReporte)
                                //{
                                //    //if (item.PrecioVenta != 0)
                                //    //{
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    //}
                                //    //else
                                //    //{
                                //    //    vDeliveryFree13 = Convert.ToString(item.CodigoProveedor);
                                //    //}
                                //}
                                //}
                                #endregion
                                // Comentado
                                //foreach (var item in lstReporte)
                                //{
                                //    if (item.PrecioVenta != 0)
                                //    {
                                //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                                //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                                //    }
                                //    else
                                //    {
                                //        vDeliveryFree13 = Convert.ToString(item.CodigoProveedor);
                                //    }
                                //}

                                ticket.LineasTotales();
                                if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                                {
                                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                                    ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                    //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                                    //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                                }
                                if (lstReporte[0].TotalDscCumpleanios > 0)
                                {
                                    ticket.TextoExtremos("Total Dscto", lstReporte[0].CodMoneda + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                                }
                                ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                                ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                            }
                            ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                            foreach (var item in lstPagosCaja)
                            {
                                if (item.IdMoneda == Parametros.intSoles)
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                                else
                                    ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                            }
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("");

                            if (i == 1)
                            {
                                //ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                                ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 155-2017/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en https://www.nubefact.com/consulta");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                                ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                                ticket.TextoCentro("GRACIAS POR SU COMPRA");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("www.panoramahogar.com");
                                ticket.TextoCentro("***** COPIA CLIENTE*****");
                                ticket.TextoIzquierda("");

                                //if (vDeliveryFree13 == "SERV-009")
                                //{
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //    ticket.TextoIzquierdaNLineas("Felicidades!!! tu compra es mayor a S/ 250.00 ");
                                //    ticket.TextoIzquierda("");
                                //    ticket.TextoCentro(" DELIVERY GRATIS ");
                                //    ticket.TextoIzquierdaNLineas("**********************************************");
                                //}




                                //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                                //if (lstReporte[0].IdPromocionProxima > 0)
                                //{
                                //    ticket.CortaTicket();
                                //    ticket.TextoCentro("=========================================");
                                //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                                //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                                //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                                //    ticket.TextoCentro("=========================================");
                                //}
                            }
                            if (i == 2)
                            {
                                ticket.TextoCentro("***** DESPACHO *****");
                            }
                            ticket.TextoCentro("Generado por Mov. Caja");
                            ticket.CortaTicket();
                        }

                        if (lstReporte[0].TotalDscCumpleanios > 0)
                        {
                            ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A.");
                            ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("NRO.: " + objTalon.NumeroSerie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                            ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                            ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                            ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                            ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                            ticket.TextoIzquierda("");
                            ticket.TextoIzquierda("");

                            ticket.TextoExtremos("TOTAL DESCUENTO ", lstReporte[0].CodMoneda.Trim() + " " + (lstReporte[0].TotalDscCumpleanios * -1).ToString());
                            ticket.TextoExtremos("CUMPLEAÑOS: ", "");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoCentro("");
                            ticket.TextoIzquierda("_________________________________________");
                            ticket.TextoIzquierda("           Firma del Cliente");
                            ticket.CortaTicket();
                        }

                        #endregion
                    }
                }
                else
                {
                    #region "Impresión 1 Copia"

                    ticket.TextoCentro(Parametros.strEmpresaNombre);
                    ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                    ticket.TextoCentro(objTalon.DireccionFiscal);
                    if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                    ticket.TextoCentro(Parametros.strEmpresaRuc);
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");
                    //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                    //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                    ticket.TextoIzquierda("N° " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    ticket.TextoIzquierda("CAJA: " + Parametros.strUsuarioLogin);
                    ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                    ticket.TextoIzquierdaNLineas("CLIENTE: " + lstReporte[0].DescCliente);
                    if (lstReporte[0].IdTipoDocumento == Parametros.intTipoDocFacturaElectronica) ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                    //ticket.TextoIzquierdaNLineas("DIR: " + lstReporte[0].Direccion);
                    ticket.LineasGuion();
                    ticket.EncabezadoVenta();

                    foreach (var item in lstReporte)
                    {
                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    }
                    ticket.LineasTotales();
                    if (lstReporte[0].TotalBruto > lstReporte[0].Total) //add 20 may 15
                    {
                        ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].TotalBruto.ToString());
                        ticket.TextoExtremos("Descuento", lstReporte[0].CodMoneda + "" + Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                        //ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto), 2));
                        //ticket.AgregaTotales("Descuento ", Math.Round(Convert.ToDouble(lstReporte[0].TotalBruto - lstReporte[0].Total) * -1, 2));
                    }
                    ticket.TextoExtremos("SubTotal", lstReporte[0].CodMoneda + "" + lstReporte[0].SubTotal.ToString());
                    ticket.TextoExtremos("IGV", lstReporte[0].CodMoneda + "" + lstReporte[0].Igv.ToString());
                    ticket.TextoExtremos("Total", lstReporte[0].CodMoneda + "" + lstReporte[0].Total.ToString());
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(lstReporte[0].Total), 2).ToString()) + " Soles");
                    foreach (var item in lstPagosCaja)
                    {
                        if (item.IdMoneda == Parametros.intSoles)
                            ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteSoles);
                        else
                            ticket.TextoIzquierda(item.DescCondicionPago + " " + item.TipoTarjeta + " " + item.CodMoneda + item.ImporteDolares);
                    }
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("Ven:" + lstReporte[0].DescVendedor);
                    ticket.TextoIzquierda("Ped:" + lstReporte[0].NumeroPedido);
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("Autorizado mediante resolución N° 034-005-0005037/SUNAT. Representación impresa de la " + lstReporte[0].TipoDocumento.ToLowerInvariant() + " electrónica. Consulte su documento en http://www.intelfac.com");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
                    ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("www.panoramahogar.com");
                    ticket.TextoCentro("***** COPIA CLIENTE - MOV CAJA*****");
                    //ticket.TextoIzquierda(lstReporte[0].PagoNotaCredito);
                    //if (lstReporte[0].IdPromocionProxima > 0)
                    //{
                    //    ticket.CortaTicket();
                    //    ticket.TextoCentro("=========================================");
                    //    PromocionProximaBE ojbPromocion = new PromocionProximaBE();
                    //    ojbPromocion = new PromocionProximaBL().Selecciona(lstReporte[0].IdPromocionProxima);
                    //    ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
                    //    ticket.TextoCentro("=========================================");
                    //}

                    ticket.CortaTicket();
                    #endregion
                }
                #endregion
            }

            #region "Nota de crédito"

            if ("NOTA CREDITO" == "NC")
            {
                //rptNotaCreditoElectronicaPanoramaA4 objReporteGuia = new rptNotaCreditoElectronicaPanoramaA4();
                //objReporteGuia.SetDataSource(lstReporte);
                ////objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                ////objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                ////Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd

                #region "Buscar Impresora ..."

                //bool found = false;
                //PrinterSettings prtSetting = new PrinterSettings();
                //foreach (string prtName in PrinterSettings.InstalledPrinters)
                //{
                //    string printer = "";
                //    if (prtName.StartsWith("\\\\"))
                //    {
                //        printer = prtName.Substring(3);
                //        printer = printer.Substring(printer.IndexOf("\\") + 1);
                //    }
                //    else
                //        printer = prtName;

                //    if (printer.ToUpper().StartsWith(Impresora))
                //    {
                //        found = true;
                //        PrintOptions bufPO = objReporteGuia.PrintOptions;
                //        prtSetting.PrinterName = prtName;
                //        objReporteGuia.PrintOptions.PrinterName = prtName;

                //        Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                //        break;
                //    }
                //}

                //if (!found)
                //{
                //    Cursor = Cursors.Default;
                //    MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                //    return;
                //}
                //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                //MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                #endregion

            }
            #endregion
        }
        private void Imprimir_Detalle(CreaTicket ticket, List<ReporteDocumentoVentaElectronicaBE> lstReporte, int IdDocumentoVenta, int I_Parametro)
        {
            //// SI SE MODIFICA, TAMBIEN MODIFICAR
            ///  frmRegMovimientoCaja   // frmRegVentaContado   //  frmRegAutoServicio

            #region "IMPRESION 2x1"
            List<DocumentoVentaDetalleBE> mListaPromocion2x1 = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);
            List<DocumentoVentaDetalleBE> mListaSinPromo = mListaPromocion2x1.Where(x => x.DescPromocion.Length == 0).ToList();
            List<DocumentoVentaDetalleBE> nLista2x1 = mListaPromocion2x1.Where(x => x.DescPromocion.Length > 0).ToList();
            //List<DocumentoVentaDetalleBE> mListaSinPromo = mListaPromocion2x1.Where(x => x.DescPromocion.Length == 0).ToList();
            //List<DocumentoVentaDetalleBE> nLista2x1 = mListaPromocion2x1.Where(x => x.DescPromocion.Length > 0).OrderByDescending(x => x.PrecioUnitario).ToList();
            // SOLO PRODUCTOS 2x1
            foreach (var item in nLista2x1)
            {
                string IdProducto = item.IdProducto.ToString();
                string CodigoProveedor = item.CodigoProveedor.PadRight(100).Substring(0, 16);
                string COD = "";
                COD = CodigoProveedor.Trim();  // I_Parametro == 1 ? IdProducto : CodigoProveedor;
                string Abrev = item.Abreviatura;
                string DescPro = item.DescPromocion;
                string NombreProducto = item.NombreProducto;
                string DescPro_NombrePro = DescPro + " " + NombreProducto.PadRight(100).Substring(0, 20);
                int Cantidad = item.Cantidad;
                double PrecioUnitario = Convert.ToDouble(item.PrecioUnitario);
                decimal PrecioVentaPrincpal = item.PrecioVenta;
                decimal ValorVentaPrincpal = item.ValorVenta;

                if (item.DescPromocion.Length > 0)
                {
                    double Valor2x1 = Convert.ToDouble(ValorVentaPrincpal) - (Cantidad * PrecioUnitario);
                    ticket.AgregaArticuloCodigo2x1(Convert.ToInt32(Cantidad), Convert.ToString(Abrev), Convert.ToString(COD), Math.Round(PrecioUnitario, 2).ToString("0.00"), Math.Round((PrecioUnitario * Cantidad), 2).ToString("0.00"));
                    ticket.AgregaArticuloDetalle2x1(DescPro_NombrePro, "", Math.Round(Valor2x1, 2).ToString("0.00"));
                }
            }
            // SOLO PRODUCTOS
            foreach (var item in mListaSinPromo)
            {
                string IdProducto = item.IdProducto.ToString();
                string CodigoProveedor = item.CodigoProveedor.PadRight(100).Substring(0, 16);
                string COD = "";
                COD = CodigoProveedor.Trim();    /// I_Parametro == 1 ? IdProducto : CodigoProveedor;

                ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(COD));
                ticket.AgregaArticuloDetalleCeros(item.NombreProducto + new string(' ', 20), Math.Round(item.PrecioVenta, 2).ToString("0.00"), Math.Round(item.ValorVenta, 2).ToString("0.00"));
            }
            #endregion
            //foreach (var item in lstReporte)
            //{
            //    if (item.PrecioVenta != 0)
            //    {
            //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
            //        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
            //    }
            //}
        }
        private void ImpresionElectronicaLocalAnula(int IdDocumentoVenta, int IdTamanoHoja, string Impresora, int IdEmpresa, string MotivoAnulacion)
        {
            if (IdTamanoHoja == Parametros.intTamanoA4)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);
                if (lstReporte.Count > 0)
                {
                    #region "Codigo QR"
                    int Regs = lstReporte.Count() - 1;
                    //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                    string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                    Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(ValorQR, out qrCode);

                    GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();

                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                    var imageTemporal = new Bitmap(ms);
                    var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                    lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                    //imagen.Save("imagen.png", ImageFormat.Png);
                    #endregion
                    rptFacturaElectronicaPanoramaA4 objReporteGuia = new rptFacturaElectronicaPanoramaA4();
                    objReporteGuia.SetDataSource(lstReporte);
                    #region "Buscar Impresora ..."
                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith(Impresora))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            break;
                        }
                    }

                    if (!found)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("La impresora " + Impresora + " Nombre para Pedido de Venta no ha sido encontrada.");
                        return;
                    }
                    objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    MessageBox.Show("El documento se imprimió a la impresora por Default ");// se envió a  + prtName);
                    #endregion
                }
            }
            else if (IdTamanoHoja == Parametros.intTamano80mmMatricial)
            {
                #region "Impresión Matricial"

                string dirFacturacion = "<No Especificado>";

                if (IdEmpresa == 19)
                    dirFacturacion = Parametros.strDireccionUcayali;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo1)
                    dirFacturacion = Parametros.strDireccionUcayali2;
                else if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                    dirFacturacion = Parametros.strDireccionUcayali3;
                else
                    dirFacturacion = Parametros.strDireccionUcayali;

                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas) dirFacturacion = Parametros.strDireccionAndahuaylas;
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos) dirFacturacion = Parametros.strDireccionMegaplaza;
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott) dirFacturacion = Parametros.strDireccionPrescott;

                //if (Parametros.intTiendaId == Parametros.intTiendaUcayali) dirFacturacion = Parametros.strDireccionUcayali;


                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(IdDocumentoVenta);

                List<MovimientoCajaBE> lstPagosCaja = new List<MovimientoCajaBE>();
                lstPagosCaja = new MovimientoCajaBL().ListaFormaPago(IdDocumentoVenta);

                TalonBE objTalon = null;
                // objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, 1, lstReporte[0].IdTipoDocumento);
                objTalon = new TalonBL().SeleccionaCajaDocumento(lstReporte[0].IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, lstReporte[0].IdTipoDocumento);
                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
                bool found = false;
                PrinterSettings prtSetting = new PrinterSettings();
                foreach (string prtName in PrinterSettings.InstalledPrinters)
                {
                    string printer = "";
                    if (prtName.StartsWith("\\\\"))
                    {
                        printer = prtName.Substring(3);
                        printer = printer.Substring(printer.IndexOf("\\") + 1);
                    }
                    else
                        printer = prtName;

                    if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                ticket.AbreCajon();

                if (objTalon.NumeroAutoriza == "TERMICA")
                {
                    if (objTalon.IdEmpresa == 3)
                    {
                        ticket.TextoCentro("CORONA IMPORTADORES E.I.R.L.");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                    else if (objTalon.IdEmpresa == 19)
                    {
                        ticket.TextoCentro("TAPIA HUAMAN NELLY BETHSABE");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                    else if (objTalon.IdEmpresa == 21)
                    {
                        ticket.TextoCentro("TAPIA HUAMAN SILVIA LILIANA");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                    else if (objTalon.IdEmpresa == 23)
                    {
                        ticket.TextoCentro("TAPIA TARRILLO ELEAZAR");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                    else if (objTalon.IdEmpresa == 8)
                    {
                        ticket.TextoCentro("HUAMAN BRAMON TEODORA AMALIA");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                    else if (objTalon.IdEmpresa == 20)
                    {
                        ticket.TextoCentro("TAPIA HUAMAN ROXANA INES");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                    else
                    {
                        ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                        ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                        ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                        ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                        ticket.TextoIzquierda("");

                        ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                        ticket.TextoIzquierda("CELULAR: ");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("");
                        ticket.TextoIzquierda("FIRMA: -------------------------------------");
                        ticket.CortaTicket();
                    }
                }
                else
                {
                    ticket.TextoCentro("PANORAMA HOGAR & DECORACION");
                    ticket.TextoCentro(lstReporte[0].TipoDocumento.ToUpper() + " ELECTRONICA");

                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierdaNLineas("NRO.: " + lstReporte[0].Serie + "-" + lstReporte[0].Numero + "   FECHA: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja + " (" + Parametros.strUsuarioLogin + ")");
                    ticket.TextoIzquierdaNLineas("MOTIVO ANULACION: " + MotivoAnulacion.Trim());

                    ticket.TextoIzquierda("");

                    ticket.TextoIzquierda("DNI/RUC: " + lstReporte[0].NumeroDocumento);
                    ticket.TextoIzquierda("CELULAR: ");
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("FIRMA: -------------------------------------");
                    ticket.CortaTicket();
                }
                #endregion
            }
        }


        private void enviarPSEtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Enviar desde facturación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //if (gvMovimientoCaja.RowCount > 0)
            //{
            //    //DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvMovimientoCaja.GetRow(gvMovimientoCaja.FocusedRowHandle);
            //    //if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
            //    //    FacturaE.GrabarVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
            //    //else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
            //    //    FacturaE.GrabarNotaCreditoIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
            //    //else
            //    //    XtraMessageBox.Show("No se puede enviar, verificar que sea comprobante electrónico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

            //    //MovimientoCajaBE objE_DocumentoVenta = (MovimientoCajaBE)gvMovimientoCaja.GetRow(gvMovimientoCaja.FocusedRowHandle);

            //    int IdTipoDocumento = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoDocumento").ToString());

            //    #region "Envío e Impresión de Comprobante electrónico"
            //    if (IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
            //    {
            //        int IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
            //        #region "Grabar"
            //        string MensajeService = FacturaE.GrabarVentaIntegrens(Convert.ToInt32(IdDocumentoVenta));
            //        if (MensajeService.ToUpper() != "OK")
            //            XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        else
            //            XtraMessageBox.Show("Comprobante enviado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        #endregion
            //    }
            //    else if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
            //    {
            //        int IdDocumentoVenta = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdDocumentoVenta").ToString());

            //        #region "Grabar"
            //        string MensajeService = FacturaE.GrabarNotaCreditoIntegrens(Convert.ToInt32(IdDocumentoVenta));
            //        if (MensajeService.ToUpper() != "OK")
            //            XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        else
            //            XtraMessageBox.Show("Comprobante enviado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        #endregion
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("No se puede enviar, verificar que sea comprobante electrónico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    }

            //    #endregion

            //}
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnVer_Click(object sender, EventArgs e)
        {
            mLista = new MovimientoCajaBL().ListaTodasCajas(Convert.ToInt32(txtAnio.EditValue), Convert.ToInt32(cboMes.EditValue));
            dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoCaja.DataSource = dt;
            gvMovimientoCaja.Columns[3].Visible = true;
            gvMovimientoCaja.Columns[3].VisibleIndex = 1;

            gvMovimientoCaja.Columns[4].Visible = true;
            gvMovimientoCaja.Columns[4].VisibleIndex =2;

        }
    }
}