using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using System.Transactions;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegEstadoCuentaCliente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaClienteBE> mLista = new List<EstadoCuentaClienteBE>();
        private List<EstadoCuentaClientePagoBE> mListaPago = new List<EstadoCuentaClientePagoBE>();

        public int IdCliente = 0;
        public int Origen = 0;
        public string NumeroDocumento="";
        public string DescCliente = "";

        #endregion

        #region "Eventos"
        public frmRegEstadoCuentaCliente()
        {
            InitializeComponent();
        }

        private void frmRegEstadoCuentaCliente_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            //BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionDocContable), "DescTablaElemento", "IdTablaElemento", true);
            //cboSituacion.EditValue = 350;
            BSUtils.LoaderLook(cboSituacion, CargarSituacion(), "Descripcion", "Id", false);
            cboSituacion.EditValue = 350;

            if (Origen == 1) //Desde Consulta de saldos
            {
                txtNumeroDocumento.Text = NumeroDocumento;
                txtDescCliente.Text = DescCliente;
                btnConsultar_Click(sender, e);
            }else
            {
                tlbMenu.Ensamblado = this.Tag.ToString();
            }

            //if(Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteCreditos|| Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas|| Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion)
            //{
            //    //Permitido
            //}else
            //{
            //    gcEstadoCuentaCliente.ContextMenuStrip = null;
            //}


        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    if (IdCliente == 0)
            //    {
            //        XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }

            //    frmRegEstadoCuentaClienteEdit objManEstadoCuentaCliente = new frmRegEstadoCuentaClienteEdit();
            //    objManEstadoCuentaCliente.IdCliente = IdCliente;
            //    objManEstadoCuentaCliente.Numero = txtNumeroDocumento.Text;
            //    objManEstadoCuentaCliente.DescCliente = txtDescCliente.Text;
            //    objManEstadoCuentaCliente.TipoCliente = txtTipoCliente.Text;
            //    objManEstadoCuentaCliente.pOperacion = frmRegEstadoCuentaClienteEdit.Operacion.Nuevo;
            //    objManEstadoCuentaCliente.IdEstadoCuentaCliente = 0;
            //    objManEstadoCuentaCliente.StartPosition = FormStartPosition.CenterParent;
            //    objManEstadoCuentaCliente.ShowDialog();
            //    Cargar();

            //    btnBuscar.Focus();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            InicializarModificar();

            txtDescCliente.Focus();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if(Convert.ToInt32(cboSituacion.EditValue)==Parametros.intSitPagadoCon)
                {
                    XtraMessageBox.Show("No se puede eliminar un documento compensado\nPrimero debe eliminar la compensación.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        #region "Pedido Compensado"
                        var Pedido = gvEstadoCuentaCliente.GetFocusedRowCellValue("IdPedido");

                        if (Pedido != null)
                        {
                            int IdPedido = 0;
                            IdPedido = int.Parse(gvEstadoCuentaCliente.GetFocusedRowCellValue("IdPedido").ToString());
                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(IdPedido));

                            if (objE_Pedido != null)
                            {
                                if (objE_Pedido.FlagAuditado)
                                {
                                    XtraMessageBox.Show("No se puede eliminar, el pedido está auditado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                            }
                        }
                        #endregion

                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "kganoza" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                            {
                                string Observacion = "";
                                frmObservacion frmObserva = new frmObservacion();
                                if (frmObserva.ShowDialog() == DialogResult.OK)
                                {
                                    Observacion = frmObserva.strObservacion;
                                }

                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                objE_EstadoCuentaCliente = new EstadoCuentaClienteBL().Selecciona(int.Parse(gvEstadoCuentaCliente.GetFocusedRowCellValue("IdEstadoCuentaCliente").ToString()));

                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                //Insertamos en la auditoria - Estado de cuenta
                                #region "auditoria Eliminacion"

                                EstadoCuentaHistorialBE objE_EstadoCuentaClienteHistorial = new EstadoCuentaHistorialBE();
                                objE_EstadoCuentaClienteHistorial.IdEstadoCuentaHistorial = 0;
                                objE_EstadoCuentaClienteHistorial.IdEmpresa = objE_EstadoCuentaCliente.IdEmpresa;
                                objE_EstadoCuentaClienteHistorial.Periodo = objE_EstadoCuentaCliente.Periodo;
                                objE_EstadoCuentaClienteHistorial.IdCliente = objE_EstadoCuentaCliente.IdCliente;
                                objE_EstadoCuentaClienteHistorial.NumeroDocumento = objE_EstadoCuentaCliente.NumeroDocumento;
                                objE_EstadoCuentaClienteHistorial.FechaCredito = objE_EstadoCuentaCliente.Fecha;
                                objE_EstadoCuentaClienteHistorial.FechaDeposito = objE_EstadoCuentaCliente.Fecha;
                                objE_EstadoCuentaClienteHistorial.Concepto = objE_EstadoCuentaCliente.Concepto;
                                objE_EstadoCuentaClienteHistorial.FechaVencimiento = objE_EstadoCuentaCliente.FechaVencimiento;
                                objE_EstadoCuentaClienteHistorial.Importe = objE_EstadoCuentaCliente.Importe;
                                objE_EstadoCuentaClienteHistorial.TipoMovimiento = objE_EstadoCuentaCliente.TipoMovimiento;
                                objE_EstadoCuentaClienteHistorial.IdMotivo = objE_EstadoCuentaCliente.IdMotivo;
                                objE_EstadoCuentaClienteHistorial.IdDocumentoVenta = objE_EstadoCuentaCliente.IdDocumentoVenta;
                                objE_EstadoCuentaClienteHistorial.IdCotizacion = 0;
                                objE_EstadoCuentaClienteHistorial.IdPedido = objE_EstadoCuentaCliente.IdPedido;
                                objE_EstadoCuentaClienteHistorial.IdMovimientoCaja = objE_EstadoCuentaCliente.IdMovimientoCaja;
                                objE_EstadoCuentaClienteHistorial.Observacion = objE_EstadoCuentaCliente.Observacion;
                                objE_EstadoCuentaClienteHistorial.ObservacionElimina = Observacion;
                                objE_EstadoCuentaClienteHistorial.ObservacionOrigen = "E.C. Bimoneda";
                                objE_EstadoCuentaClienteHistorial.TipoRegistro = "E";
                                objE_EstadoCuentaClienteHistorial.FlagEstado = objE_EstadoCuentaCliente.FlagEstado;
                                objE_EstadoCuentaClienteHistorial.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaClienteHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                                objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaClienteHistorial);
                                #endregion

                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();
                                objBL_EstadoCuentaCliente.Elimina(objE_EstadoCuentaCliente);

                                XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (gvEstadoCuentaCliente.RowCount > 0)
                {
                    List<ReporteEstadoCuentaClienteCabBE> lstReporte = null;
                    lstReporte = new ReporteEstadoCuentaClienteCabBL().Listado(Parametros.intEmpresaId, IdCliente, "", Parametros.intSitPendienteCon);

                    if (lstReporte != null)
                    {
                        //Listar el datalle del reporte
                        List<ReporteEstadoCuentaClienteDetBE> lstReporteEstadoCuentaDetalle = null;
                        lstReporteEstadoCuentaDetalle = new ReporteEstadoCuentaClienteDetBL().Listado(Parametros.intEmpresaId, IdCliente, "", Parametros.intSitPendienteCon);
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptAccUsu = new RptVistaReportes();
                            objRptAccUsu.VerRptEstadoCuentaCliente(lstReporte, lstReporteEstadoCuentaDetalle);
                            objRptAccUsu.ShowDialog();
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
            string _fileName = "ListadoEstadoCuentaCliente";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEstadoCuentaCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    Cargar();

                    //if (frm.pClienteBE.IdTipoCliente == Parametros.intTipClienteFinal && frm.pClienteBE.IdClasificacionCliente != Parametros.intBlack)
                    //{
                    //    XtraMessageBox.Show("Atención! El cliente es MINORISTA se recomienda registrar en el estado de cuenta Soles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void asignarpagostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (gvEstadoCuentaCliente.RowCount > 0)
                    {
                        if(Convert.ToInt32(cboSituacion.EditValue)==Parametros.intSitPendienteCon)
                        {
                            Cursor = Cursors.WaitCursor;
                            string GrupoCompensado = DateTime.Now.ToString("yyMMddHHmmss");

                            List<EstadoCuentaClienteBE> lst_EstadoCuentaCargo = new List<EstadoCuentaClienteBE>();
                            List<EstadoCuentaClienteBE> lst_EstadoCuentaAbono = new List<EstadoCuentaClienteBE>();
                            EstadoCuentaClientePagoBE objBE_EstadoCuentaPago = new EstadoCuentaClientePagoBE();
                            EstadoCuentaClientePagoBL objBL_EstadoCuentaPago = new EstadoCuentaClientePagoBL();

                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            EstadoCuentaClienteBE objE_Estado = new EstadoCuentaClienteBE();
                            EstadoCuentaClienteBL objBL_EstadoCuenta = new EstadoCuentaClienteBL();
                            DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL();

                            string Mensaje = "";
                            for (int i = 0; i < gvEstadoCuentaCliente.SelectedRowsCount; i++)//Pagos
                            {
                                int row = gvEstadoCuentaCliente.GetSelectedRows()[i];
                                EstadoCuentaClienteBE objE_EstadoCuenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(row);

                                //DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                                //objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

                                gvEstadoCuentaCliente.SetRowCellValue(row, "DescMotivo", "PROCESANDO...");
                                gcEstadoCuentaCliente.Refresh();

                                //Agregar a EECC Pago
                                #region "Estado de cuenta Pago"
                                objBE_EstadoCuentaPago.IdEstadoCuentaClientePago = 0;
                                objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
                                objBE_EstadoCuentaPago.IdCliente = objE_EstadoCuenta.IdCliente;
                                objBE_EstadoCuentaPago.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                objBE_EstadoCuentaPago.Fecha = objE_EstadoCuenta.Fecha;
                                objBE_EstadoCuentaPago.Concepto = objE_EstadoCuenta.Concepto.Replace("SALDO ", "");
                                objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                objBE_EstadoCuentaPago.IdMoneda = objE_EstadoCuenta.IdMoneda;
                                objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
                                objBE_EstadoCuentaPago.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                                objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                objBE_EstadoCuentaPago.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                objBE_EstadoCuentaPago.IdPedido = objE_EstadoCuenta.IdPedido;
                                objBE_EstadoCuentaPago.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
                                objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
                                objBE_EstadoCuentaPago.UsuarioRegistro = Parametros.strUsuarioLogin;//objE_EstadoCuenta.UsuarioRegistro;
                                objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
                                objBE_EstadoCuentaPago.Observacion = objE_EstadoCuenta.Observacion;
                                objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
                                objBE_EstadoCuentaPago.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
                                objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
                                objBE_EstadoCuentaPago.FlagEstado = true;

                                objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
                                #endregion

                                //Mensaje = Mensaje +" "+ objE_EstadoCuenta.IdEstadoCuentaCliente.ToString()+"\n";
                                if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "C")
                                {
                                    #region "Cargo"
                                    objE_Estado = new EstadoCuentaClienteBE();
                                    objE_Estado.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
                                    objE_Estado.Importe = objE_EstadoCuenta.Importe;
                                    objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
                                    objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
                                    objE_Estado.IdMoneda = objE_EstadoCuenta.IdMoneda;
                                    objE_Estado.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                    objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                    lst_EstadoCuentaCargo.Add(objE_Estado);
                                    #endregion
                                }
                                else if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "A")
                                {
                                    #region "Abono"
                                    objE_Estado = new EstadoCuentaClienteBE();
                                    objE_Estado.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
                                    objE_Estado.Importe = objE_EstadoCuenta.Importe;
                                    objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
                                    objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
                                    objE_Estado.IdMoneda = objE_EstadoCuenta.IdMoneda;
                                    objE_Estado.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                    objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                    lst_EstadoCuentaAbono.Add(objE_Estado);
                                    #endregion
                                }
                            }

                            if (lst_EstadoCuentaCargo.Count == 0)
                            {
                                XtraMessageBox.Show("No existe ningún Cargo para hacer MATCH, por favor verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (lst_EstadoCuentaAbono.Count == 0)
                            {
                                XtraMessageBox.Show("No existe ningún pago para hacer MATCH, por favor verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                            int IndexA = 0;
                            decimal Saldo = 0;

                            //int IndexC = 0;
                            foreach (var item in lst_EstadoCuentaAbono)//cargo
                            {
                                int IndexC = 0;
                                foreach (var item2 in lst_EstadoCuentaCargo)
                                {
                                    Saldo = item.Saldo;
                                    if (item.Saldo > 0)
                                    {
                                        decimal Valor = item.Saldo - item2.Saldo;
                                        if (Valor <= 0)
                                        {
                                            //ACTUALIZA SALDO 
                                            lst_EstadoCuentaAbono[IndexA].Saldo = 0;
                                            lst_EstadoCuentaCargo[IndexC].Saldo = (Valor) * -1;

                                            #region "Documento Pago"
                                            if (Saldo > 0)
                                            {
                                                DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                                                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                                                objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdDocumentoVenta);
                                                objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
                                                objE_DocumentoVentaPago.Fecha = item.Fecha;
                                                objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
                                                objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
                                                objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
                                                objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
                                                objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
                                                objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                                                objE_DocumentoVentaPago.CodMoneda = "USD";
                                                objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                                                objE_DocumentoVentaPago.Importe = Saldo;
                                                objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaCliente;
                                                objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
                                                objE_DocumentoVentaPago.FlagEstado = true;
                                                objE_DocumentoVentaPago.TipoOper = 1;
                                                //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

                                                objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago);
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            Saldo = item2.Saldo;
                                            lst_EstadoCuentaAbono[IndexA].Saldo = Valor;
                                            lst_EstadoCuentaCargo[IndexC].Saldo = 0;

                                            #region "Documento Pago"
                                            if (Saldo > 0)
                                            {
                                                DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                                                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                                                objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdDocumentoVenta);
                                                objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
                                                objE_DocumentoVentaPago.Fecha = item.Fecha;
                                                objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
                                                objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
                                                objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
                                                objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
                                                objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
                                                objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                                                objE_DocumentoVentaPago.CodMoneda = "USD";
                                                objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                                                objE_DocumentoVentaPago.Importe = Saldo;
                                                objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaCliente;
                                                objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
                                                objE_DocumentoVentaPago.FlagEstado = true;
                                                objE_DocumentoVentaPago.TipoOper = 1;
                                                //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

                                                objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago);
                                            }
                                            #endregion
                                        }
                                        IndexC = IndexC + 1;
                                    }
                                }
                                IndexA = IndexA + 1;
                            }

                            foreach (var item in lst_EstadoCuentaAbono)
                            {
                                Mensaje = Mensaje + item.IdEstadoCuentaCliente + " " + item.Saldo + "\n";
                                objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaCliente, item.Saldo);
                            }

                            foreach (var item in lst_EstadoCuentaCargo)
                            {
                                Mensaje = Mensaje + item.IdEstadoCuentaCliente + " " + item.Saldo + "\n";
                                if (item.Saldo == 0)
                                {
                                    objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaCliente, 0);
                                    objBL_DocumentoVenta.ActualizaSituacionContable(Parametros.intEmpresaId, Convert.ToInt32(item.IdDocumentoVenta), Parametros.intSitPagadoCon);
                                }
                                else
                                {
                                    objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaCliente, item.Saldo);
                                }
                            }

                            //XtraMessageBox.Show(Mensaje, this.Text);
                            //XtraInputBox.Show("", "", "");
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            ts.Complete();
                            XtraMessageBox.Show("Ud. sólo puede hacer match a documentos pendientes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    ts.Complete();
                    XtraMessageBox.Show("Match procesado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buscarmatchtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("No seas vago!, busca manualmente hasta dominar el match.", this.Text);
        }

        private void gvEstadoCuentaCliente_RowStyle(object sender, RowStyleEventArgs e)
        {
            //try
            //{
            //    object obj = gvEstadoCuentaCliente.GetRow(e.RowHandle);

            //    GridView View = sender as GridView;
            //    if (e.RowHandle >= 0)
            //    {
            //        object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["TipoMovimiento"]);
            //        if (objDocRetiro.ToString() == "A")
            //        {
            //            e.Appearance.BackColor = Color.LightGreen;
            //            e.Appearance.BackColor2 = Color.SeaShell;
            //        }

            //        //object objDocRetiro2 = View.GetRowCellValue(e.RowHandle, View.Columns["IdCuentaBancoDetalle"]);
            //        //if (objDocRetiro2 != null)
            //        //{
            //        //    e.Appearance.BackColor = Color.SkyBlue;
            //        //    e.Appearance.BackColor2 = Color.SeaShell;
            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            if (IdCliente > 0)
            {
                Cargar();

                if(Convert.ToInt32(cboSituacion.EditValue)==Parametros.intSitPendienteCon)
                {
                    asignarpagostoolStripMenuItem.Enabled = true;
                    forzarmarchtoolStripMenuItem.Enabled = true;
                    eliminarcompensadotoolStripMenuItem.Enabled = false;
                }
                else if(Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    asignarpagostoolStripMenuItem.Enabled = false;
                    forzarmarchtoolStripMenuItem.Enabled = false;
                    eliminarcompensadotoolStripMenuItem.Enabled = true;
                }
                else
                {
                    asignarpagostoolStripMenuItem.Enabled = false;
                    forzarmarchtoolStripMenuItem.Enabled = false;
                    eliminarcompensadotoolStripMenuItem.Enabled = false;
                }
            }
        }

        private void gvEstadoCuentaCliente_DoubleClick(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                if (objE_DocumentoVenta.TipoMovimiento == "C")
                {
                    if (objE_DocumentoVenta.IdDocumentoVenta != null)
                    {
                        frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                        frm.IdDocumentoVenta = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                        frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                        frm.mnuContextual.Enabled = false;
                        frm.btnGrabar.Enabled = false;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("El documento actual no tiene asociado un comprobante de venta, por favor consultar con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void verdocumentoventatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    //if (objE_DocumentoVenta.TipoMovimiento == "C")
                    //{
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                            frm.IdDocumentoVenta = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                            frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                            frm.mnuContextual.Enabled = false;
                            frm.btnGrabar.Enabled = false;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    //}
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    //if (objE_DocumentoVenta.TipoMovimiento == "C")
                    //{
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                            frm.IdDocumentoVenta = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                            frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                            frm.mnuContextual.Enabled = false;
                            frm.btnGrabar.Enabled = false;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    //}
                }
            }
        }

        private void verpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            frmRegPedidoEdit frm = new frmRegPedidoEdit();
                            frm.IdPedido = Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                            frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        if (objE_DocumentoVenta.IdPedido != null)
                        {
                            frmRegPedidoEdit frm = new frmRegPedidoEdit();
                            frm.IdPedido = Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                            frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnBuscar_Click(sender, e);

                //numero o cadena
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                        Cargar();
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void vistapreviatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvEstadoCuentaCliente.RowCount > 0)
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    EstadoCuentaClientePagoBE objE_DocumentoVenta = (EstadoCuentaClientePagoBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        #region "Documentos Cargo"
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                            if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocFacturaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocBoletaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocFacturaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocBoletaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El documento no tiene asociado un comprobante. Por favor consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }
                    else
                    {
                        #region "Documentos Abono"
                        string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                        if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                        {
                            List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            #region "Codigo QR"
                            //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                            string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(ValorQR, out qrCode);

                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();

                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                            lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                            //imagen.Save("imagen.png", ImageFormat.Png);
                            #endregion

                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptDocumento = new RptVistaReportes();
                                objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                objRptDocumento.ShowDialog();
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    EstadoCuentaClienteBE objE_DocumentoVenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(gvEstadoCuentaCliente.FocusedRowHandle);
                    if (objE_DocumentoVenta.TipoMovimiento == "C")
                    {
                        #region "Documentos Cargo"
                        if (objE_DocumentoVenta.IdDocumentoVenta != null)
                        {
                            string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                            if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoReferenciaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoReferenciaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoReferencia(lstReporte, Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta)); //IdDocumentoReferencia
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocFacturaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocFacturaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length < 16)
                            {
                                List<ReporteDocumentoVentaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaBL().ListaPedidoDocumento(Parametros.intPeriodo, Convert.ToInt32(objE_DocumentoVenta.IdPedido), Parametros.intTipoDocBoletaVenta);
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVenta(lstReporte, Parametros.intTipoDocBoletaVenta);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "01" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocFacturaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "03" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocBoletaElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                            else if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                            {
                                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                                lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                                #region "Codigo QR"
                                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                                string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                                QrCode qrCode = new QrCode();
                                qrEncoder.TryEncode(ValorQR, out qrCode);

                                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                                MemoryStream ms = new MemoryStream();

                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                                var imageTemporal = new Bitmap(ms);
                                var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                                lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                                //imagen.Save("imagen.png", ImageFormat.Png);
                                #endregion

                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptDocumento = new RptVistaReportes();
                                    objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                    objRptDocumento.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El documento no tiene asociado un comprobante. Por favor consultar con sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }else
                    {
                        #region "Documentos Abono"
                        string CodDoc = objE_DocumentoVenta.NumeroDocumento.Substring(0, 2);
                        if (CodDoc == "07" && objE_DocumentoVenta.NumeroDocumento.Length == 16)
                        {
                            List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                            lstReporte = new ReporteDocumentoVentaElectronicaBL().Listado(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta));

                            #region "Codigo QR"
                            //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + lstReporte[0].Fecha.ToShortDateString() + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;
                            string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].IdTipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                            QrCode qrCode = new QrCode();
                            qrEncoder.TryEncode(ValorQR, out qrCode);

                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            MemoryStream ms = new MemoryStream();

                            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                            var imageTemporal = new Bitmap(ms);
                            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                            lstReporte[0].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                            //imagen.Save("imagen.png", ImageFormat.Png);
                            #endregion

                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptDocumento = new RptVistaReportes();
                                objRptDocumento.VerRptDocumentoVentaElectronica(lstReporte, Parametros.intTipoDocNotaCreditoElectronica);
                                objRptDocumento.ShowDialog();
                            }
                        }
                        #endregion
                    }
                }

            }
        }

        private void eliminarcompensadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    if (gvEstadoCuentaCliente.RowCount > 0)
                    {
                        if(XtraMessageBox.Show("Está seguro de eliminar este movimiento de compensados?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                        {
                            string GrupoPago = gvEstadoCuentaCliente.GetFocusedRowCellValue("GrupoPago").ToString();

                            EstadoCuentaClientePagoBE objBE_EstadoCuentaPago = new EstadoCuentaClientePagoBE();
                            objBE_EstadoCuentaPago.IdEstadoCuentaCliente = 0;
                            objBE_EstadoCuentaPago.GrupoPago = GrupoPago;
                            objBE_EstadoCuentaPago.Usuario = Parametros.strUsuarioLogin;
                            objBE_EstadoCuentaPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objBE_EstadoCuentaPago.IdEmpresa = Parametros.intEmpresaId;

                            int IdMensaje = new EstadoCuentaClientePagoBL().EliminaCompensado(objBE_EstadoCuentaPago);
                            if (IdMensaje == 1)
                            {
                                XtraMessageBox.Show("Operación completada con éxito!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                            else
                            {
                                XtraMessageBox.Show("No se puede eliminar, Por favor eliminar el documento compensado más reciente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region "Metodos"
        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            if(Convert.ToInt32(cboSituacion.EditValue)==Parametros.intSitPagadoCon)
            {
                mListaPago = new EstadoCuentaClientePagoBL().ListaPagado(Parametros.intEmpresaId, IdCliente);
                gcEstadoCuentaCliente.DataSource = mListaPago;

                gcGrupoPago.Visible = true;
                gcGrupoPago.GroupIndex = 1;
                gvEstadoCuentaCliente.OptionsView.ShowGroupPanel = false;
                gvEstadoCuentaCliente.ExpandAllGroups();

                gridColumn8.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                gridColumn8.DisplayFormat.FormatString = "";
                gridColumn24.Visible = false;
            }
            else
            {
                mLista = new EstadoCuentaClienteBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente, "", Convert.ToInt32(cboSituacion.EditValue));
                gcEstadoCuentaCliente.DataSource = mLista;

                gcGrupoPago.Visible = false;
                gcGrupoPago.GroupIndex = -1;
                gvEstadoCuentaCliente.OptionsView.ShowGroupPanel = false;
                //gvEstadoCuentaCliente.ExpandAllGroups();

                gridColumn8.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridColumn8.DisplayFormat.FormatString = "{0:#,0.00}";
                gridColumn24.Visible = true;
            }
            Cursor = Cursors.Default;
        }

        private void CargarLineaCredito()
        {
            ClienteCreditoBE objE_ClienteCredito = null;
            objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
            if (objE_ClienteCredito != null)
            {
                txtLineaCredito.EditValue = objE_ClienteCredito.LineaCredito;
                txtLineaCreditoUtilizada.EditValue = objE_ClienteCredito.LineaCreditoUtilizada;
                txtLineaCreditoDisponible.EditValue = objE_ClienteCredito.LineaCreditoDisponible;
            }
            else
            {
                txtLineaCredito.EditValue = 0;
                txtLineaCreditoUtilizada.EditValue = 0;
                txtLineaCreditoDisponible.EditValue = 0;
            }
        }

        public void InicializarModificar()
        {
            //if (gvEstadoCuentaCliente.RowCount > 0)
            //{
            //    EstadoCuentaClienteBE objEstadoCuentaCliente = new EstadoCuentaClienteBE();

            //    objEstadoCuentaCliente.IdEstadoCuentaCliente = int.Parse(gvEstadoCuentaCliente.GetFocusedRowCellValue("IdEstadoCuentaCliente").ToString());

            //    frmRegEstadoCuentaClienteEdit objManEstadoCuentaClienteEdit = new frmRegEstadoCuentaClienteEdit();
            //    objManEstadoCuentaClienteEdit.IdCliente = IdCliente;
            //    objManEstadoCuentaClienteEdit.Numero = txtNumeroDocumento.Text;
            //    objManEstadoCuentaClienteEdit.DescCliente = txtDescCliente.Text;
            //    objManEstadoCuentaClienteEdit.TipoCliente = txtTipoCliente.Text;
            //    objManEstadoCuentaClienteEdit.pOperacion = frmRegEstadoCuentaClienteEdit.Operacion.Modificar;
            //    objManEstadoCuentaClienteEdit.IdEstadoCuentaCliente = objEstadoCuentaCliente.IdEstadoCuentaCliente;
            //    objManEstadoCuentaClienteEdit.StartPosition = FormStartPosition.CenterParent;
            //    objManEstadoCuentaClienteEdit.ShowDialog();

            //    Cargar();
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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvEstadoCuentaCliente.GetFocusedRowCellValue("IdEstadoCuentaCliente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        private DataTable CargarSituacion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "TODOS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 350;
            dr["Descripcion"] = "PENDIENTES";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 351;
            dr["Descripcion"] = "COMPENSADOS";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

        private void verdocumentocompensadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IdEstadoCuentaCliente =  int.Parse(gvEstadoCuentaCliente.GetFocusedRowCellValue("IdEstadoCuentaCliente").ToString());

            List<EstadoCuentaClientePagoBE> mListaPago2 = new List<EstadoCuentaClientePagoBE>();
            mListaPago2 = new EstadoCuentaClientePagoBL().ListaHistorial(Parametros.intEmpresaId, IdEstadoCuentaCliente);

            if(mListaPago2.Count>0)
            {
                frmBuscarCompensado frm = new frmBuscarCompensado();
                frm.IdCliente = IdCliente;
                frm.IdEstadoCuentaCliente = IdEstadoCuentaCliente;
                frm.mListaPago = mListaPago2;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }else
            {
                XtraMessageBox.Show("No existen compensados para este documento",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void forzarmarchtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (gvEstadoCuentaCliente.RowCount > 0)
                    {
                        if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPendienteCon)
                        {
                            Cursor = Cursors.WaitCursor;
                            string GrupoCompensado = DateTime.Now.ToString("yyMMddHHmmss");

                            List<EstadoCuentaClienteBE> lst_EstadoCuentaCargo = new List<EstadoCuentaClienteBE>();
                            List<EstadoCuentaClienteBE> lst_EstadoCuentaAbono = new List<EstadoCuentaClienteBE>();
                            EstadoCuentaClientePagoBE objBE_EstadoCuentaPago = new EstadoCuentaClientePagoBE();
                            EstadoCuentaClientePagoBL objBL_EstadoCuentaPago = new EstadoCuentaClientePagoBL();

                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            EstadoCuentaClienteBE objE_Estado = new EstadoCuentaClienteBE();
                            EstadoCuentaClienteBL objBL_EstadoCuenta = new EstadoCuentaClienteBL();
                            DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL();

                            string Mensaje = "";
                            
                            int row = gvEstadoCuentaCliente.FocusedRowHandle;
                            EstadoCuentaClienteBE objE_EstadoCuenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(row);

                            if(Parametros.intPerfilId != Parametros.intPerAdministrador)
                            {
                                if (objE_EstadoCuenta.Saldo > 1)
                                {
                                    XtraMessageBox.Show("El valor máximo para forzar el Match es de $1.00", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Cursor = Cursors.Default;
                                    return;
                                }

                            }

                            gvEstadoCuentaCliente.SetRowCellValue(row, "DescMotivo", "PROCESANDO...");
                            gcEstadoCuentaCliente.Refresh();

                            

                            //Agregar a EECC Pago
                            #region "Estado de cuenta Pago"
                            objBE_EstadoCuentaPago.IdEstadoCuentaClientePago = 0;
                            objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                            objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
                            objBE_EstadoCuentaPago.IdCliente = objE_EstadoCuenta.IdCliente;
                            objBE_EstadoCuentaPago.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                            objBE_EstadoCuentaPago.Fecha = objE_EstadoCuenta.Fecha;
                            objBE_EstadoCuentaPago.Concepto = objE_EstadoCuenta.Concepto.Replace("SALDO ", "");
                            objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                            objBE_EstadoCuentaPago.IdMoneda = objE_EstadoCuenta.IdMoneda;
                            objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
                            objBE_EstadoCuentaPago.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                            objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
                            objBE_EstadoCuentaPago.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                            objBE_EstadoCuentaPago.IdPedido = objE_EstadoCuenta.IdPedido;
                            objBE_EstadoCuentaPago.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                            objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
                            objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
                            objBE_EstadoCuentaPago.UsuarioRegistro = Parametros.strUsuarioLogin;//objE_EstadoCuenta.UsuarioRegistro;
                            objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
                            objBE_EstadoCuentaPago.Observacion = "MATCH FORZOSO";
                            objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
                            objBE_EstadoCuentaPago.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
                            objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
                            objBE_EstadoCuentaPago.FlagEstado = true;

                            objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
                            #endregion

                            objBL_EstadoCuenta.ActualizaSaldo(objE_EstadoCuenta.IdEstadoCuentaCliente, 0);

                            if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "C")
                            {
                                #region "Estado de cuenta Pago"
                                objBE_EstadoCuentaPago.IdEstadoCuentaClientePago = 0;
                                objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
                                objBE_EstadoCuentaPago.IdCliente = objE_EstadoCuenta.IdCliente;
                                objBE_EstadoCuentaPago.NumeroDocumento = "R00000";
                                objBE_EstadoCuentaPago.Fecha = objE_EstadoCuenta.Fecha;
                                objBE_EstadoCuentaPago.Concepto = "ABONO VIRTUAL";
                                objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                objBE_EstadoCuentaPago.IdMoneda = objE_EstadoCuenta.IdMoneda;
                                objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
                                objBE_EstadoCuentaPago.TipoMovimiento = "A";
                                objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                objBE_EstadoCuentaPago.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                objBE_EstadoCuentaPago.IdPedido = objE_EstadoCuenta.IdPedido;
                                objBE_EstadoCuentaPago.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
                                objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
                                objBE_EstadoCuentaPago.UsuarioRegistro = Parametros.strUsuarioLogin;//objE_EstadoCuenta.UsuarioRegistro;
                                objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
                                objBE_EstadoCuentaPago.Observacion = "MATCH FORZOSO";
                                objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
                                objBE_EstadoCuentaPago.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
                                objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
                                objBE_EstadoCuentaPago.FlagEstado = true;

                                objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
                                #endregion

                                objBL_DocumentoVenta.ActualizaSituacionContable(Parametros.intEmpresaId, Convert.ToInt32(objE_EstadoCuenta.IdDocumentoVenta), Parametros.intSitPagadoCon);
                            }
                            else if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "A")
                            {
                                #region "Estado de cuenta Pago"
                                objBE_EstadoCuentaPago.IdEstadoCuentaClientePago = 0;
                                objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
                                objBE_EstadoCuentaPago.IdCliente = objE_EstadoCuenta.IdCliente;
                                objBE_EstadoCuentaPago.NumeroDocumento = "00-0000-00000000";
                                objBE_EstadoCuentaPago.Fecha = objE_EstadoCuenta.Fecha;
                                objBE_EstadoCuentaPago.Concepto = "DOCUMENTO VIRTUAL";
                                objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                objBE_EstadoCuentaPago.IdMoneda = objE_EstadoCuenta.IdMoneda;
                                objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
                                objBE_EstadoCuentaPago.TipoMovimiento = "C";
                                objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                objBE_EstadoCuentaPago.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                objBE_EstadoCuentaPago.IdPedido = objE_EstadoCuenta.IdPedido;
                                objBE_EstadoCuentaPago.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
                                objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
                                objBE_EstadoCuentaPago.UsuarioRegistro = Parametros.strUsuarioLogin;//objE_EstadoCuenta.UsuarioRegistro;
                                objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
                                objBE_EstadoCuentaPago.Observacion = "MATCH FORZOSO";
                                objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
                                objBE_EstadoCuentaPago.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
                                objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
                                objBE_EstadoCuentaPago.FlagEstado = true;

                                objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
                                #endregion
                            }

                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            ts.Complete();
                            XtraMessageBox.Show("Ud. sólo puede hacer match a documentos pendientes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    ts.Complete();
                    //XtraMessageBox.Show("Match procesado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MatchIA()
        {
            //if (gvEstadoCuentaCliente.RowCount > 0)
            //{
            //    if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPendienteCon)
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        string GrupoCompensado = DateTime.Now.ToString("yyMMddHHmmss");

            //        List<EstadoCuentaClienteBE> lst_EstadoCuentaCargo = new List<EstadoCuentaClienteBE>();
            //        List<EstadoCuentaClienteBE> lst_EstadoCuentaAbono = new List<EstadoCuentaClienteBE>();
            //        EstadoCuentaClientePagoBE objBE_EstadoCuentaPago = new EstadoCuentaClientePagoBE();
            //        EstadoCuentaClientePagoBL objBL_EstadoCuentaPago = new EstadoCuentaClientePagoBL();

            //        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //        EstadoCuentaClienteBE objE_Estado = new EstadoCuentaClienteBE();
            //        EstadoCuentaClienteBL objBL_EstadoCuenta = new EstadoCuentaClienteBL();
            //        DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL();

            //        string Mensaje = "";
            //        for (int i = 0; i < gvEstadoCuentaCliente.SelectedRowsCount; i++)//Pagos
            //        {
            //            int row = gvEstadoCuentaCliente.GetSelectedRows()[i];
            //            EstadoCuentaClienteBE objE_EstadoCuenta = (EstadoCuentaClienteBE)gvEstadoCuentaCliente.GetRow(row);

            //            //DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //            //objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

            //            gvEstadoCuentaCliente.SetRowCellValue(row, "DescMotivo", "PROCESANDO...");
            //            gcEstadoCuentaCliente.Refresh();

            //            //Agregar a EECC Pago
                        
                        
            //            #region "Estado de cuenta Pago"
            //            objBE_EstadoCuentaPago.IdEstadoCuentaClientePago = 0;
            //            objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
            //            objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
            //            objBE_EstadoCuentaPago.IdCliente = objE_EstadoCuenta.IdCliente;
            //            objBE_EstadoCuentaPago.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
            //            objBE_EstadoCuentaPago.Fecha = objE_EstadoCuenta.Fecha;
            //            objBE_EstadoCuentaPago.Concepto = objE_EstadoCuenta.Concepto.Replace("SALDO ", "");
            //            objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
            //            objBE_EstadoCuentaPago.IdMoneda = objE_EstadoCuenta.IdMoneda;
            //            objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
            //            objBE_EstadoCuentaPago.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
            //            objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
            //            objBE_EstadoCuentaPago.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
            //            objBE_EstadoCuentaPago.IdPedido = objE_EstadoCuenta.IdPedido;
            //            objBE_EstadoCuentaPago.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
            //            objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
            //            objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
            //            objBE_EstadoCuentaPago.UsuarioRegistro = Parametros.strUsuarioLogin;//objE_EstadoCuenta.UsuarioRegistro;
            //            objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
            //            objBE_EstadoCuentaPago.Observacion = objE_EstadoCuenta.Observacion;
            //            objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
            //            objBE_EstadoCuentaPago.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
            //            objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
            //            objBE_EstadoCuentaPago.FlagEstado = true;

            //            objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
            //            #endregion

            //            if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "C")
            //            {
            //                #region "Cargo"
            //                objE_Estado = new EstadoCuentaClienteBE();
            //                objE_Estado.IdEstadoCuentaCliente = objE_EstadoCuenta.IdEstadoCuentaCliente;
            //                objE_Estado.Importe = objE_EstadoCuenta.Importe;
            //                objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
            //                objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
            //                objE_Estado.IdMoneda = objE_EstadoCuenta.IdMoneda;
            //                objE_Estado.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
            //                objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
            //                lst_EstadoCuentaCargo.Add(objE_Estado);
            //                #endregion
            //            }
            //        }

            //        if (lst_EstadoCuentaCargo.Count == 0)
            //        {
            //            XtraMessageBox.Show("No existe ningún Cargo para hacer MATCH, por favor verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        decimal Saldo = 500;

            //        int IndexC = 0;
            //        foreach (var item2 in lst_EstadoCuentaCargo)
            //        {
            //            Saldo = item.Saldo;
            //            if (Saldo > 0)
            //            {
            //                decimal Valor = item.Saldo - item2.Saldo;
            //                if (Valor <= 0)
            //                {
            //                    //ACTUALIZA SALDO 
            //                    lst_EstadoCuentaAbono[IndexA].Saldo = 0;
            //                    lst_EstadoCuentaCargo[IndexC].Saldo = (Valor) * -1;


            //                    #region "Documento Pago"
            //                    if (Saldo > 0)
            //                    {
            //                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
            //                        objE_DocumentoVentaPago.IdEmpresa = Parametros.intEmpresaId;
            //                        objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdDocumentoVenta);
            //                        objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
            //                        objE_DocumentoVentaPago.Fecha = item.Fecha;
            //                        objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
            //                        objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
            //                        objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
            //                        objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
            //                        objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
            //                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
            //                        objE_DocumentoVentaPago.CodMoneda = "USD";
            //                        objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
            //                        objE_DocumentoVentaPago.Importe = Saldo;
            //                        objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaCliente;
            //                        objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
            //                        objE_DocumentoVentaPago.FlagEstado = true;
            //                        objE_DocumentoVentaPago.TipoOper = 1;
            //                        //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

            //                        objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago);
            //                    }
            //                    #endregion
            //                }
            //                else
            //                {
            //                    Saldo = item2.Saldo;
            //                    lst_EstadoCuentaAbono[IndexA].Saldo = Valor;
            //                    lst_EstadoCuentaCargo[IndexC].Saldo = 0;

            //                    #region "Documento Pago"
            //                    if (Saldo > 0)
            //                    {
            //                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
            //                        objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
            //                        objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdDocumentoVenta);
            //                        objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
            //                        objE_DocumentoVentaPago.Fecha = item.Fecha;
            //                        objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
            //                        objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
            //                        objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
            //                        objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
            //                        objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
            //                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
            //                        objE_DocumentoVentaPago.CodMoneda = "USD";
            //                        objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
            //                        objE_DocumentoVentaPago.Importe = Saldo;
            //                        objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaCliente;
            //                        objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
            //                        objE_DocumentoVentaPago.FlagEstado = true;
            //                        objE_DocumentoVentaPago.TipoOper = 1;
            //                        //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

            //                        objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago);
            //                    }
            //                    #endregion
            //                }
            //                IndexC = IndexC + 1;
            //            }
            //        }


            //        foreach (var item in lst_EstadoCuentaAbono)
            //        {
            //            Mensaje = Mensaje + item.IdEstadoCuentaCliente + " " + item.Saldo + "\n";
            //            objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaCliente, item.Saldo);
            //        }

            //        foreach (var item in lst_EstadoCuentaCargo)
            //        {
            //            Mensaje = Mensaje + item.IdEstadoCuentaCliente + " " + item.Saldo + "\n";
            //            if (item.Saldo == 0)
            //            {
            //                objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaCliente, 0);
            //                objBL_DocumentoVenta.ActualizaSituacionContable(Parametros.intEmpresaId, Convert.ToInt32(item.IdDocumentoVenta), Parametros.intSitPagadoCon);
            //            }
            //            else
            //            {
            //                objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaCliente, item.Saldo);
            //            }
            //        }

       
            //        Cursor = Cursors.Default;
            //    }
            //    else
            //    {

            //        XtraMessageBox.Show("Ud. sólo puede hacer match a documentos pendientes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}



        }




    }
}