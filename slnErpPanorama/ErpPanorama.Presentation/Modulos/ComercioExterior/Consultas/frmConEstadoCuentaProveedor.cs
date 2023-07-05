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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Registros;
using System.Transactions;
using System.Security.Principal;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas 
{
    public partial class frmConEstadoCuentaProveedor : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<EstadoCuentaProveedorBE> mLista = new List<EstadoCuentaProveedorBE>();
        private List<EstadoCuentaProveedorPagoBE> mListaPago = new List<EstadoCuentaProveedorPagoBE>();

        public int IdProveedor = 0;

        public string NumeroDocumento = "";
        public string DescCliente = "";
        public int IdMotivoVenta = 0;
        public int Origen = 0;

        #endregion
        public frmConEstadoCuentaProveedor()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmConEstadoCuentaProveedor_Load(object sender, EventArgs e)
        {
            //Obtenemos la lista de proveedores
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);
            BSUtils.LoaderLook(cboSituacion, CargarSituacion(), "Descripcion", "Id", false);
            cboSituacion.EditValue = Parametros.intSitPendienteCon;
            deDesde.EditValue = Convert.ToDateTime("01/01/2013");
            deHasta.EditValue = DateTime.Now;
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
            //dr["Id"] = 283;
            dr["Id"] = 350;
            dr["Descripcion"] = "PENDIENTES";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            //dr["Id"] = 284;
            dr["Id"] = 351;
            dr["Descripcion"] = "COMPENSADOS";
            dt.Rows.Add(dr);
            return dt;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdProveedor == 0)
            {
                XtraMessageBox.Show("Seleccione un Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void toolstpExportarExcel_Click_1(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadocuentaProvedor";
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

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            if (IdProveedor == 0)
            {
                XtraMessageBox.Show("Seleccione un Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    if (IdProveedor == 0)
            //    {
            //        XtraMessageBox.Show("Seleccionar un Proveedor.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (gvEstadoCuenta.RowCount > 0)
            //    {
            //        List<ReporteEstadoCuentaCabeceraBE> lstReporte = null;
            //        lstReporte = new ReporteEstadoCuentaCabeceraBL().Listado(Parametros.intEmpresaId, IdProveedor, Convert.ToInt32(cboMotivo.EditValue));

            //        if (lstReporte != null)
            //        {
            //            //Listar el datalle del reporte

            //            List<ReporteEstadoCuentaDetalleBE> lstReporteEstadoCuentaDetalle = null;
            //            lstReporteEstadoCuentaDetalle = new ReporteEstadoCuentaDetalleBL().Listado(deDesde.DateTime, deHasta.DateTime, IdProveedor, Convert.ToInt32(cboMotivo.EditValue));
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptAccUsu = new RptVistaReportes();
            //                objRptAccUsu.VerRptEstadoCuenta(lstReporte, lstReporteEstadoCuentaDetalle, cboMotivo.Text);
            //                objRptAccUsu.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        Cursor = Cursors.Default;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void asignarpagostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (gvEstadoCuentaProveedor.RowCount > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        string GrupoCompensado = DateTime.Now.ToString("yyMMddHHmmss");

                        List<EstadoCuentaProveedorBE> lst_EstadoCuentaCargo = new List<EstadoCuentaProveedorBE>();
                        List<EstadoCuentaProveedorBE> lst_EstadoCuentaAbono = new List<EstadoCuentaProveedorBE>();
                        EstadoCuentaProveedorPagoBE objBE_EstadoCuentaPago = new EstadoCuentaProveedorPagoBE();
                        EstadoCuentaProveedorPagoBL objBL_EstadoCuentaPago = new EstadoCuentaProveedorPagoBL();
                        FacturaCompraBE objBE_FacturaCompra = new FacturaCompraBE();
                        FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();

                        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL(); //Pendiente

                        EstadoCuentaProveedorBE objE_Estado = new EstadoCuentaProveedorBE();
                        EstadoCuentaProveedorBL objBL_EstadoCuenta = new EstadoCuentaProveedorBL();


                        DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL(); //Pendiente

                        string Mensaje = "";
                        for (int i = 0; i < gvEstadoCuentaProveedor.SelectedRowsCount; i++)//Pagos
                        {
                            int row = gvEstadoCuentaProveedor.GetSelectedRows()[i];
                            EstadoCuentaProveedorBE objE_EstadoCuenta = (EstadoCuentaProveedorBE)gvEstadoCuentaProveedor.GetRow(row);

                            //DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            //objE_DocumentoVenta = objBL_DocumentoVenta.SeleccionaEnvioValido(objE_DocumentoVenta.IdDocumentoVenta);

                            gvEstadoCuentaProveedor.SetRowCellValue(row, "DescMotivo", "PROCESANDO...");
                            gcEstadoCuentaProveedor.Refresh();

                            //Agregar a EECC Pago
                            #region "Estado de cuenta Pago"
                            objBE_EstadoCuentaPago.IdEstadoCuentaProveedorPago = 0;
                            objBE_EstadoCuentaPago.IdEmpresa = objE_EstadoCuenta.IdEmpresa;
                            objBE_EstadoCuentaPago.Periodo = objE_EstadoCuenta.Periodo;
                            objBE_EstadoCuentaPago.IdProveedor = objE_EstadoCuenta.IdProveedor;
                            objBE_EstadoCuentaPago.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                            objBE_EstadoCuentaPago.Fecha = Convert.ToDateTime(objE_EstadoCuenta.Fecha);
                            objBE_EstadoCuentaPago.Concepto = objE_EstadoCuenta.Concepto.Replace("SALDO ", "");
                            objBE_EstadoCuentaPago.FechaVencimiento = objE_EstadoCuenta.FechaVencimiento;
                            objBE_EstadoCuentaPago.IdMoneda = objE_EstadoCuenta.IdMoneda;
                            objBE_EstadoCuentaPago.Importe = objE_EstadoCuenta.Saldo;
                            objBE_EstadoCuentaPago.TipoMovimiento = objE_EstadoCuenta.TipoMovimiento;
                            objBE_EstadoCuentaPago.IdMotivo = objE_EstadoCuenta.IdMotivo;
                            objBE_EstadoCuentaPago.IdFacturaCompra = objE_EstadoCuenta.IdFacturaCompra;
                            objBE_EstadoCuentaPago.IdCuentaBancoDetalle = objE_EstadoCuenta.IdCuentaBancoDetalle;
                            objBE_EstadoCuentaPago.IdPersona = objE_EstadoCuenta.IdPersona;
                            objBE_EstadoCuentaPago.UsuarioRegistro = objE_EstadoCuenta.UsuarioRegistro;
                            objBE_EstadoCuentaPago.FechaRegistro = objE_EstadoCuenta.FechaRegistro;
                            objBE_EstadoCuentaPago.Observacion = objE_EstadoCuenta.Observacion;
                            objBE_EstadoCuentaPago.Saldo = objE_EstadoCuenta.Saldo;
                            objBE_EstadoCuentaPago.IdEstadoCuentaProveedor = objE_EstadoCuenta.IdEstadoCuentaProveedor;
                            objBE_EstadoCuentaPago.GrupoPago = GrupoCompensado;
                            objBE_EstadoCuentaPago.FlagEstado = true;

                            objBL_EstadoCuentaPago.Inserta(objBE_EstadoCuentaPago);
                            #endregion

                            //Mensaje = Mensaje +" "+ objE_EstadoCuenta.IdEstadoCuentaCliente.ToString()+"\n";
                            if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "C")
                            {
                                #region "Cargo"
                                objE_Estado = new EstadoCuentaProveedorBE();
                                objE_Estado.IdEstadoCuentaProveedor = objE_EstadoCuenta.IdEstadoCuentaProveedor;
                                objE_Estado.Importe = objE_EstadoCuenta.Importe;
                                objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
                                objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
                                objE_Estado.IdFacturaCompra = objE_EstadoCuenta.IdFacturaCompra;
                                objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                lst_EstadoCuentaCargo.Add(objE_Estado);
                                #endregion
                            }
                            else if (objE_EstadoCuenta.TipoMovimiento.ToUpper() == "A")
                            {
                                #region "Abono"
                                objE_Estado = new EstadoCuentaProveedorBE();
                                objE_Estado.IdEstadoCuentaProveedor = objE_EstadoCuenta.IdEstadoCuentaProveedor;
                                objE_Estado.Importe = objE_EstadoCuenta.Importe;
                                objE_Estado.Saldo = objE_EstadoCuenta.Saldo;
                                objE_Estado.Fecha = objE_EstadoCuenta.Fecha;
                                objE_Estado.IdFacturaCompra = objE_EstadoCuenta.IdFacturaCompra;
                                objE_Estado.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                                lst_EstadoCuentaAbono.Add(objE_Estado);
                                #endregion
                            }
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
                                        if (Saldo > 0) //pendiente  **--
                                        {
                                            //DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                                            //objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                                            //objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdFacturaCompra);
                                            //objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
                                            //objE_DocumentoVentaPago.Fecha = item.Fecha;
                                            //objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
                                            //objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
                                            //objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
                                            //objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
                                            //objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
                                            //objE_DocumentoVentaPago.CodMoneda = "USD";
                                            //objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                                            //objE_DocumentoVentaPago.Importe = Saldo;
                                            //objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaProveedor;
                                            //objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
                                            //objE_DocumentoVentaPago.FlagEstado = true;
                                            //objE_DocumentoVentaPago.TipoOper = 1;
                                            //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

                                            /* objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago);*///pendiente **--
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        Saldo = item2.Saldo;
                                        lst_EstadoCuentaAbono[IndexA].Saldo = Valor;
                                        lst_EstadoCuentaCargo[IndexC].Saldo = 0;

                                        #region "Documento Pago"
                                        if (Saldo > 0) // **---
                                        {
                                            //DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                                            //objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                                            //objE_DocumentoVentaPago.IdDocumentoVenta = Convert.ToInt32(item2.IdFacturaCompra);
                                            //objE_DocumentoVentaPago.IdDocumentoVentaPago = 0;
                                            //objE_DocumentoVentaPago.Fecha = item.Fecha;
                                            //objE_DocumentoVentaPago.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
                                            //objE_DocumentoVentaPago.CodTipoDocumento = "BEE";
                                            //objE_DocumentoVentaPago.NumeroDocumento = item2.NumeroDocumento;
                                            //objE_DocumentoVentaPago.IdCondicionPago = Parametros.intEfectivo;
                                            //objE_DocumentoVentaPago.DescCondicionPago = "EFECTIVO";
                                            //objE_DocumentoVentaPago.CodMoneda = "USD";
                                            //objE_DocumentoVentaPago.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                                            //objE_DocumentoVentaPago.Importe = Saldo;
                                            //objE_DocumentoVentaPago.IdEstadoCuentaCliente = item.IdEstadoCuentaProveedor;
                                            //objE_DocumentoVentaPago.GrupoPago = GrupoCompensado;
                                            //objE_DocumentoVentaPago.FlagEstado = true;
                                            //objE_DocumentoVentaPago.TipoOper = 1;
                                            //lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);

                                            //objBL_DocumentoVentaPago.Inserta(objE_DocumentoVentaPago); //**---
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
                            Mensaje = Mensaje + item.IdEstadoCuentaProveedor + " " + item.Saldo + "\n";
                            objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaProveedor, item.Saldo);
                        }

                        foreach (var item in lst_EstadoCuentaCargo)
                        {
                            Mensaje = Mensaje + item.IdEstadoCuentaProveedor + " " + item.Saldo + "\n";
                            if (item.Saldo == 0)
                            {
                                objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaProveedor, 0);
                                //objBL_DocumentoVenta.ActualizaSituacionContable(Parametros.intEmpresaId, Convert.ToInt32(item.IdFacturaCompra), Parametros.intSitPagadoCon);
                                objBL_FacturaCompra.ActualizaSituacionPago(Convert.ToInt32(item.IdFacturaCompra), Parametros.intSitPagadoCon, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                            }
                            else
                            {
                                objBL_EstadoCuenta.ActualizaSaldo(item.IdEstadoCuentaProveedor, item.Saldo);
                            }
                        }

                        //XtraMessageBox.Show(Mensaje, this.Text);
                        //XtraInputBox.Show("", "", "");
                        Cursor = Cursors.Default;
                    }

                    ts.Complete();
                    XtraMessageBox.Show("Match procesado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Cargar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            if (IdProveedor > 0)
            {
                Cargar();
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPendienteCon)
                {
                    asignarpagostoolStripMenuItem.Enabled = true;
                    eliminarcompensadotoolStripMenuItem.Enabled = false;
                }
                else if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    asignarpagostoolStripMenuItem.Enabled = false;
                    eliminarcompensadotoolStripMenuItem.Enabled = true;
                }
                else
                {
                    asignarpagostoolStripMenuItem.Enabled = false;
                    eliminarcompensadotoolStripMenuItem.Enabled = false;
                }
            }
        }

        private void cboProveedor_EditValueChanged(object sender, EventArgs e)
        {
            IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
        }

        private void verFacturaCompratoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEstadoCuentaProveedor.RowCount > 0)
                {
                    var FacturaCompra = gvEstadoCuentaProveedor.GetFocusedRowCellValue("IdFacturaCompra");
                    if (FacturaCompra != null)
                    {
                        //int IdFacturaCompra = 0;
                        

                        //IdFacturaCompra = int.Parse(gvEstadoCuentaProveedor.GetFocusedRowCellValue("IdFacturaCompra").ToString());

                        frmManFacturaCompraEdit frmFacturaCompra = new frmManFacturaCompraEdit();
                        frmFacturaCompra.IdFacturaCompra = Convert.ToInt32(FacturaCompra);
                        frmFacturaCompra.pOperacion = frmManFacturaCompraEdit.Operacion.Modificar;
                        frmFacturaCompra.FlagEnviado = true;
                        frmFacturaCompra.btnGrabar.Enabled = false;
                        frmFacturaCompra.StartPosition = FormStartPosition.CenterParent;
                        frmFacturaCompra.Show();
                    }
                    else
                    {
                        XtraMessageBox.Show("No existe documentos asociados para este movimiento.");

                    }


                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\nNo tiene asociado un pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarcompensadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
                {
                    if (gvEstadoCuentaProveedor.RowCount > 0)
                    {
                        string GrupoPago = gvEstadoCuentaProveedor.GetFocusedRowCellValue("GrupoPago").ToString();

                        EstadoCuentaProveedorPagoBE objBE_EstadoCuentaPago = new EstadoCuentaProveedorPagoBE();
                        objBE_EstadoCuentaPago.IdEstadoCuentaProveedor = 0;
                        objBE_EstadoCuentaPago.GrupoPago = GrupoPago;
                        objBE_EstadoCuentaPago.Usuario = Parametros.strUsuarioLogin;
                        objBE_EstadoCuentaPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objBE_EstadoCuentaPago.IdEmpresa = Parametros.intEmpresaId;

                        int IdMensaje = new EstadoCuentaProveedorPagoBL().EliminaCompensado(objBE_EstadoCuentaPago);
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
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void verfacturacompensadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IdEstadoCuentaCliente = int.Parse(gvEstadoCuentaProveedor.GetFocusedRowCellValue("IdEstadoCuentaProveedor").ToString());

            List<EstadoCuentaProveedorPagoBE> mListaPago2 = new List<EstadoCuentaProveedorPagoBE>();
            mListaPago2 = new EstadoCuentaProveedorPagoBL().ListaHistorial(Parametros.intEmpresaId, IdEstadoCuentaCliente);

            if (mListaPago2.Count > 0)
            {
                frmBuscarCompeansadosFC frm = new frmBuscarCompeansadosFC();
                frm.IdProveedor = IdProveedor;
                frm.IdEstadoCuentaProveedor = IdEstadoCuentaCliente;
                frm.mListaPago = mListaPago2;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No existen compensados para este documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.Default;

            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSitPagadoCon)
            {
                mListaPago = new EstadoCuentaProveedorPagoBL().ListaPagado(Parametros.intEmpresaId, IdProveedor);
                gcEstadoCuentaProveedor.DataSource = mListaPago;

                ////Formato
                gcGrupoPago.Visible = true;
                gcGrupoPago.GroupIndex = 1;
                gvEstadoCuentaProveedor.OptionsView.ShowGroupPanel = false;
                gvEstadoCuentaProveedor.ExpandAllGroups();
            }
            else
            {

                IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                mLista = new EstadoCuentaProveedorBL().ListaTodosActivo(Parametros.intEmpresaId, IdProveedor, "", Convert.ToInt32(cboSituacion.EditValue));
                gcEstadoCuentaProveedor.DataSource = mLista;

                gcGrupoPago.Visible = false;
                gcGrupoPago.GroupIndex = 1;
                gvEstadoCuentaProveedor.OptionsView.ShowGroupPanel = false;
                //gvEstadoCuentaCliente.ExpandAllGroups();
            }

        }

        #endregion

    }
}