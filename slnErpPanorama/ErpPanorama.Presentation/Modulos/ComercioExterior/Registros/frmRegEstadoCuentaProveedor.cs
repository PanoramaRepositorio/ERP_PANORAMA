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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using System.Security.Principal;
using System.Transactions;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmRegEstadoCuentaProveedor : DevExpress.XtraEditors.XtraForm
    {

        #region Propiedades
        private List<EstadoCuentaProveedorBE> mLista = new List<EstadoCuentaProveedorBE>();

        public int  IdProveedor =0;
        #endregion

        #region Eventos
        public frmRegEstadoCuentaProveedor()
        {
            InitializeComponent();
        }

        private void frmRegEstadoCuentaProveedor_Load(object sender, EventArgs e)
        {
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);
            tlbMenu.Ensamblado = this.Tag.ToString();
        }
      
        private void btnCredito_Click(object sender, EventArgs e)
        {
            IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
            try
            {
                if (IdProveedor == 0)
                {
                    XtraMessageBox.Show("Seleccione un Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frmRegEstadoCuentaProveedorPago objManEstadoCuentaProveedor = new frmRegEstadoCuentaProveedorPago();
                objManEstadoCuentaProveedor.lstEstadoCuenta = mLista;
                objManEstadoCuentaProveedor.IdProveedor = IdProveedor;
                objManEstadoCuentaProveedor.DescProveedor = (cboProveedor.Text);
                objManEstadoCuentaProveedor.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                objManEstadoCuentaProveedor.pOperacion = frmRegEstadoCuentaProveedorPago.Operacion.Nuevo;
                objManEstadoCuentaProveedor.IdEstadoCuentaProveedor = 0;
                objManEstadoCuentaProveedor.TipoMovimiento = "C";
                objManEstadoCuentaProveedor.StartPosition = FormStartPosition.CenterParent;
                objManEstadoCuentaProveedor.ShowDialog();
                Cargar();

                //                btnBuscar.Focus();
                btnCredito.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
            try
            {
                if (IdProveedor == 0)
                {
                    XtraMessageBox.Show("Seleccione un Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //txtNumeroDocumento.Focus();
                    return;
                }

                frmRegEstadoCuentaProveedorPago objManEstadoCuentaProveedor = new frmRegEstadoCuentaProveedorPago();
                objManEstadoCuentaProveedor.IdProveedor = IdProveedor;
                // objManEstadoCuentaPRoveedor.Numero = txtNumeroDocumento.Text;
                objManEstadoCuentaProveedor.DescProveedor = (cboProveedor.Text);
                objManEstadoCuentaProveedor.pOperacion = frmRegEstadoCuentaProveedorPago.Operacion.Nuevo;
                objManEstadoCuentaProveedor.IdEstadoCuentaProveedor = 0;
                objManEstadoCuentaProveedor.TipoMovimiento = "A";
                objManEstadoCuentaProveedor.StartPosition = FormStartPosition.CenterParent;
                objManEstadoCuentaProveedor.ShowDialog();
                Cargar();

                btnPago.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvEstadoCuentaProveedor_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void tlbMenu_EditClick()
        {
            if (IdProveedor == 0)
            {
                XtraMessageBox.Show("Seleccione un Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                            {
                                string Observacion = "";
                                frmObservacion frmObserva = new frmObservacion();
                                if (frmObserva.ShowDialog() == DialogResult.OK)
                                {
                                    Observacion = frmObserva.strObservacion;
                                }


                                EstadoCuentaProveedorBE objE_EstadoCuentaProveedor = new EstadoCuentaProveedorBE();
                                objE_EstadoCuentaProveedor = new EstadoCuentaProveedorBL().Selecciona(Parametros.intEmpresaId, int.Parse(gvEstadoCuentaProveedor.GetFocusedRowCellValue("IdEstadoCuentaProveedor").ToString()));
                              //  objE_EstadoCuentaProveedor.IdEstadoCuentaProveedor=
                                objE_EstadoCuentaProveedor.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                

                                //Insertamos en la auditoria - Estado de cuenta
                                #region "auditoria Eliminacion"

                                //EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                                //objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                                //objE_EstadoCuentaHistorial.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                                //objE_EstadoCuentaHistorial.Periodo = objE_EstadoCuenta.Periodo;
                                //objE_EstadoCuentaHistorial.IdCliente = objE_EstadoCuenta.IdCliente;
                                //objE_EstadoCuentaHistorial.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                //objE_EstadoCuentaHistorial.FechaCredito = objE_EstadoCuenta.FechaCredito;
                                //objE_EstadoCuentaHistorial.FechaDeposito = objE_EstadoCuenta.FechaDeposito;
                                //objE_EstadoCuentaHistorial.Concepto = objE_EstadoCuenta.Concepto;
                                //objE_EstadoCuentaHistorial.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                                //objE_EstadoCuentaHistorial.Importe = objE_EstadoCuenta.Importe;
                                //objE_EstadoCuentaHistorial.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                                //objE_EstadoCuentaHistorial.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                //objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_EstadoCuenta.IdDocumentoVenta;
                                //objE_EstadoCuentaHistorial.IdCotizacion = objE_EstadoCuenta.IdCotizacion;
                                //objE_EstadoCuentaHistorial.IdPedido = objE_EstadoCuenta.IdPedido;
                                //objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_EstadoCuenta.IdMovimientoCaja;
                                //objE_EstadoCuentaHistorial.Observacion = objE_EstadoCuenta.Observacion;
                                //objE_EstadoCuentaHistorial.ObservacionElimina = Observacion;
                                //objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. DOLARES";
                                //objE_EstadoCuentaHistorial.TipoRegistro = "E";
                                //objE_EstadoCuentaHistorial.FlagEstado = objE_EstadoCuenta.FlagEstado;
                                //objE_EstadoCuentaHistorial.Usuario = Parametros.strUsuarioLogin;
                                //objE_EstadoCuentaHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                //EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                                //objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaHistorial);
                                #endregion

                                EstadoCuentaProveedorBL objBL_EstadoCuentaProveedor = new EstadoCuentaProveedorBL();
                                objBL_EstadoCuentaProveedor.Elimina(objE_EstadoCuentaProveedor);

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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadoCuentales";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEstadoCuentaProveedor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        #endregion

        #region Metodos
        private void Cargar()
        {
            IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
            mLista = new EstadoCuentaProveedorBL().ListaTodosActivo(Parametros.intEmpresaId, IdProveedor,"", 0);//Convert.ToInt32(cboSituacion.EditValue));
            gcEstadoCuentaProveedor.DataSource = mLista;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        public void InicializarModificar()
        {
            if (gvEstadoCuentaProveedor.RowCount > 0)
            {
                EstadoCuentaProveedorBE objEstadoCuentaProveedor = new EstadoCuentaProveedorBE();

                objEstadoCuentaProveedor.IdEstadoCuentaProveedor = int.Parse(gvEstadoCuentaProveedor.GetFocusedRowCellValue("IdEstadoCuentaProveedor").ToString());
                frmRegEstadoCuentaProveedorPago objManEstadoCuentaProveedor = new frmRegEstadoCuentaProveedorPago();

                objManEstadoCuentaProveedor.IdProveedor = IdProveedor;
                //objManEstadoCuentaProveedor.Numero = txtNumeroDocumento.Text;
                objManEstadoCuentaProveedor.DescProveedor = (cboProveedor.Text);
                //objManEstadoCuentaPRoveedor.tipo = txtTipoCliente.Text;
                //objManEstadoCuentaPRoveedor.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                objManEstadoCuentaProveedor.pOperacion = frmRegEstadoCuentaProveedorPago.Operacion.Modificar;
                objManEstadoCuentaProveedor.IdEstadoCuentaProveedor = objEstadoCuentaProveedor.IdEstadoCuentaProveedor;
                objManEstadoCuentaProveedor.IdFacturaCompra =Convert.ToInt32(objEstadoCuentaProveedor.IdFacturaCompra);
                objManEstadoCuentaProveedor.TipoMovimiento = (gvEstadoCuentaProveedor.GetFocusedRowCellValue("TipoMovimiento").ToString()); ;
                objManEstadoCuentaProveedor.StartPosition = FormStartPosition.CenterParent;
                objManEstadoCuentaProveedor.ShowDialog();


                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvEstadoCuentaProveedor.GetFocusedRowCellValue("IdEstadoCuentaProveedor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Proveedor ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void asignarpagostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (TransactionScope ts = new TransactionScope())
            //    {
            //        if (gvEstadoCuentaProveedor.RowCount > 0)
            //        {
            //            Cursor = Cursors.WaitCursor;
            //            string GrupoCompensado = DateTime.Now.ToString("yyMMddHHmmss");

            //            List<EstadoCuentaProveedorBE> lst_EstadoCuentaCargo = new List<EstadoCuentaProveedorBE>();
            //            List<EstadoCuentaProveedorBE> lst_EstadoCuentaAbono = new List<EstadoCuentaProveedorBE>();
            //            EstadoCuentaProveedorPagoBE objBE_EstadoCuentaPago = new EstadoCuentaProveedorPagoBE();
            //            EstadoCuentaProveedorPagoBL objBL_EstadoCuentaPago = new EstadoCuentaProveedorPagoBL();

            //            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL(); //Pendiente

            //            EstadoCuentaProveedorBE objE_Estado = new EstadoCuentaProveedorBE();
            //            EstadoCuentaProveedorBL objBL_EstadoCuenta = new EstadoCuentaProveedorBL();


            //            DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL(); //Pendiente

            //            string Mensaje = "";
            //            for (int i = 0; i < gvEstadoCuentaProveedor.SelectedRowsCount; i++)//Pagos
            //            {
            //                int row = gvEstadoCuentaProveedor.GetSelectedRows()[i];
            //                EstadoCuentaProveedorBE objE_EstadoCuenta = (EstadoCuentaProveedorBE)gvEstadoCuentaProveedor.GetRow(row);

            //                //DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //                //objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

            //                gvEstadoCuentaProveedor.SetRowCellValue(row, "DescMotivo", "PROCESANDO...");
            //                gcEstadoCuentaProveedor.Refresh();

            //                //Agregar a EECC Pago
            //                #region "Estado de cuenta Pago"
            //                objBE_EstadoCuentaPago.IdEstadoCuentaProveedorPago = 0;
            //                objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
            //                objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
            //                objBE_EstadoCuentaPago.IdProveedor = objE_EstadoCuenta.IdProveedor;
            //                objBE_EstadoCuentaPago.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
            //                objBE_EstadoCuentaPago.Fecha = Convert.ToDateTime(objE_EstadoCuenta.Fecha);
            //                objBE_EstadoCuentaPago.Concepto = objE_EstadoCuenta.Concepto.Replace("SALDO ", "");
            //                objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
            //                objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
            //                objBE_EstadoCuentaPago.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
            //                objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
            //                objBE_EstadoCuentaPago.IdFacturaCompra = objE_EstadoCuenta.IdFacturaCompra;
            //                objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
            //                objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
            //                objBE_EstadoCuentaPago.UsuarioRegistro = objE_EstadoCuenta.UsuarioRegistro;
            //                objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
            //                objBE_EstadoCuentaPago.Observacion = objE_EstadoCuenta.Observacion;
            //                objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
            //                objBE_EstadoCuentaPago.IdEstadoCuentaProveedor = objE_EstadoCuenta.IdEstadoCuentaProveedor;
            //                objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
            //                objBE_EstadoCuentaPago.FlagEstado = true;

            //                objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
            //                #endregion

            //                //Mensaje = Mensaje +" "+ objE_EstadoCuenta.IdEstadoCuentaCliente.ToString()+"\n";
            //                if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "C")
            //                {
            //                    #region "Cargo"
            //                    objE_Estado = new EstadoCuentaProveedorBE();
            //                    objE_Estado.IdEstadoCuentaProveedor = objE_EstadoCuenta.IdEstadoCuentaProveedor;
            //                    objE_Estado.Importe = objE_EstadoCuenta.Importe;
            //                    objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
            //                    objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
            //                    objE_Estado.IdFacturaCompra = objE_EstadoCuenta.IdEstadoCuentaProveedor;
            //                    objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
            //                    lst_EstadoCuentaCargo.Add(objE_Estado);
            //                    #endregion
            //                }
            //                else if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "A")
            //                {
            //                    #region "Abono"
            //                    objE_Estado = new EstadoCuentaProveedorBE();
            //                    objE_Estado.IdEstadoCuentaProveedor = objE_EstadoCuenta.IdEstadoCuentaProveedor;
            //                    objE_Estado.Importe = objE_EstadoCuenta.Importe;
            //                    objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
            //                    objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
            //                    objE_Estado.IdFacturaCompra = objE_EstadoCuenta.IdFacturaCompra;
            //                    objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
            //                    lst_EstadoCuentaAbono.Add(objE_Estado);
            //                    #endregion
            //                }
            //            }

            //            if (lst_EstadoCuentaAbono.Count == 0)
            //            {
            //                XtraMessageBox.Show("No existe ningún pago para hacer MATCH, por favor verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }

            //            int IndexA = 0;
            //            decimal Saldo = 0;

            //            //int IndexC = 0;
            //            foreach (var item in lst_EstadoCuentaAbono)//cargo
            //            {
            //                int IndexC = 0;
            //                foreach (var item2 in lst_EstadoCuentaCargo)
            //                {
            //                    Saldo = item.Saldo;
            //                    if (item.Saldo > 0)
            //                    {
            //                        decimal Valor = item.Saldo - item2.Saldo;
            //                        if (Valor <= 0)
            //                        {
            //                            //ACTUALIZA SALDO 
            //                            lst_EstadoCuentaAbono[IndexA].Saldo = 0;
            //                            lst_EstadoCuentaCargo[IndexC].Saldo = (Valor) * -1;

            //                            #region "Documento Pago" 
            //                            if (Saldo > 0) //pendiente  **--
            //                            {
            //                                DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
            //                                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
            //                                objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdFacturaCompra);
            //                                objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
            //                                objE_DocumentoVentaPago.Fecha = item.Fecha;
            //                                objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
            //                                objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
            //                                objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
            //                                objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
            //                                objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
            //                                objE_DocumentoVentaPago.CodMoneda = "USD";
            //                                objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
            //                                objE_DocumentoVentaPago.Importe = Saldo;
            //                                objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaProveedor;
            //                                objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
            //                                objE_DocumentoVentaPago.FlagEstado = true;
            //                                objE_DocumentoVentaPago.TipoOper = 1;
            //                                //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

            //                                objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago);//pendiente **--
            //                            }
            //                            #endregion
            //                        }
            //                        else
            //                        {
            //                            Saldo = item2.Saldo;
            //                            lst_EstadoCuentaAbono[IndexA].Saldo = Valor;
            //                            lst_EstadoCuentaCargo[IndexC].Saldo = 0;

            //                            #region "Documento Pago"
            //                            if (Saldo > 0) // **---
            //                            {
            //                                DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
            //                                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
            //                                objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdFacturaCompra);
            //                                objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
            //                                objE_DocumentoVentaPago.Fecha = item.Fecha;
            //                                objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
            //                                objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
            //                                objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
            //                                objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
            //                                objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
            //                                objE_DocumentoVentaPago.CodMoneda = "USD";
            //                                objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
            //                                objE_DocumentoVentaPago.Importe = Saldo;
            //                                objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaProveedor;
            //                                objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
            //                                objE_DocumentoVentaPago.FlagEstado = true;
            //                                objE_DocumentoVentaPago.TipoOper = 1;
            //                                //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

            //                                objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago); //**---
            //                            }
            //                            #endregion
            //                        }
            //                        IndexC = IndexC + 1;
            //                    }
            //                }
            //                IndexA = IndexA + 1;
            //            }

            //            foreach (var item in lst_EstadoCuentaAbono)
            //            {
            //                Mensaje = Mensaje + item.IdEstadoCuentaProveedor + " " + item.Saldo + "\n";
            //                objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaProveedor, item.Saldo);
            //            }

            //            foreach (var item in lst_EstadoCuentaCargo)
            //            {
            //                Mensaje = Mensaje + item.IdEstadoCuentaProveedor + " " + item.Saldo + "\n";
            //                if (item.Saldo == 0)
            //                {
            //                    objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaProveedor, 0);
            //                    objBL_DocumentoVenta.ActualizaSituacionContable(Parametros.intEmpresaId, Convert.ToInt32(item.IdFacturaCompra), Parametros.intSitPagadoCon);
            //                }
            //                else
            //                {
            //                    objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaProveedor, item.Saldo);
            //                }
            //            }

            //            //XtraMessageBox.Show(Mensaje, this.Text);
            //            //XtraInputBox.Show("", "", "");
            //            Cursor = Cursors.Default;
            //        }

            //        ts.Complete();
            //        XtraMessageBox.Show("Match procesado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //    Cargar();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        #endregion



        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            if (IdProveedor > 0)
            {
                Cargar();

            }
        }

        private void cboProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnConsultar.Focus();
                //SendKeys.Send("{TAB}");
            }
        }

        private void btnConsultar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                //btnGrabar.Focus();
                SendKeys.Send("{TAB}");
            }
        }
    }
}