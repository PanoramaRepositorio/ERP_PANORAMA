using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    public partial class frmConRegistroVentas : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        FacturacionElectronica FacturaE = new FacturacionElectronica();
        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        #endregion

        #region "Eventos"

        public frmConRegistroVentas()
        {
            InitializeComponent();
        }

        private void frmConRegistroVentas_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", false);
            txtPeriodo.EditValue = Parametros.intPeriodo;
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaRegistroVentasContabilidad";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (chkAnulado.Checked == true)
            {
                Cargar();
                //ConvertirAnulado();
            }
            else
            {
                Cargar();
            }
            
            //Cargar();
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }

        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaDocumento();
            }
        }

        private void gvDocumento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        #endregion


        #region "Metodos"

        private void Cargar()
        {
            mLista = new DocumentoVentaBL().ListaGeneral(0, deDesde.DateTime, deHasta.DateTime);
            gcDocumento.DataSource = mLista;

            CalcularTotalDocumentos();
            //lblTotalRegistros.Text = gvDocumento.RowCount.ToString() + " Registros";
        }

        private void CargarBusqueda()
        {
            //Traemos la información del Pedido
            PedidoBE objE_Pedido = null;
            objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumeroPedido.Text.Trim());
            if (objE_Pedido != null)
            {
                mLista = new DocumentoVentaBL().ListadoPedidoConta(objE_Pedido.IdPedido);
                gcDocumento.DataSource = mLista;
            }
        }

        private void CargarBusquedaDocumento()
        {
            //Traemos la información del documento
            mLista = new DocumentoVentaBL().ListaSerieNumero(Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text, txtNumero.Text);
            gcDocumento.DataSource = mLista;

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
            if (gvDocumento.RowCount > 0)
            {
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
                objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                //frmRegFacturacionEmpresaRegistroEdit objRegFacturacionEdit = new frmRegFacturacionEmpresaRegistroEdit();
                //objRegFacturacionEdit.pOperacion = frmRegFacturacionEmpresaRegistroEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                if (objRegFacturacionEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvDocumento.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvDocumento.GetRowCellValue(i, (gvDocumento.Columns["Total"])));
                }
                txtTotal.EditValue = decTotal;
                lblTotalRegistros.Text = gvDocumento.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void toolStripAnular_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int TipoDoc = int.Parse(gvDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                if (TipoDoc == Parametros.intTipoDocBoletaElectronica || TipoDoc == Parametros.intTipoDocFacturaElectronica || TipoDoc == Parametros.intTipoDocNotaCreditoElectronica)
                {
                    #region "Baja de comprobante Electrónico"
                    if (XtraMessageBox.Show("Está seguro de dar de BAJA el Comprobante electrónico?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {
                            DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));

                            ////GrabarAnulaVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);
                            //FacturaE.AnulaVentaIntegrens(objE_DocumentoVenta.IdDocumentoVenta);

                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                            //XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();


                            if (objE_DocumentoVenta.IdTipoDocumento != Parametros.intTipoDocNotaCredito)
                            {
                                //Anula Con Pedido
                                int? IdPedido = objE_DocumentoVenta.IdPedido;
                                if (IdPedido != null)
                                {
                                    if (XtraMessageBox.Show("El documento está asociado a un pedido, Desea Anular el Pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        PedidoBE objE_Pedido = null;
                                        PedidoBL objBL_Pedido = new PedidoBL();
                                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(IdPedido));

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

                                    lstSeparacion = new SeparacionBL().ListaPedido(Parametros.intEmpresaId, Convert.ToInt32(objE_DocumentoVenta.IdPedido), "A");
                                    if (lstSeparacion.Count > 0)
                                    {
                                        foreach (SeparacionBE objE_EstadoCuenta in lstSeparacion)
                                        {
                                            if (objE_EstadoCuenta.NumeroDocumento == "COMCD")
                                            {
                                                //objE_EstadoCuenta = lstSeparacion[0];

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
                                                objE_EstadoCuentaHistorial.ObservacionElimina = "FACT:" + Parametros.strUsuarioLogin + " " + WindowsIdentity.GetCurrent().Name.ToString() + "";
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


                        }
                    }
                    #endregion
                }else
                {
                    #region "Eliminar comprobante físico"

                    if (XtraMessageBox.Show("Esta seguro de Anular el documento?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {

                            //Validar Periodo
                            DateTime Fecha;
                            Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Fecha").ToString());

                            PeriodoBE objBE_Periodo = new PeriodoBE();
                            objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                            if (objBE_Periodo != null)
                            {
                                if (objBE_Periodo.FlagEstado == false)
                                {
                                    XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));
                            objE_DocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                            objE_DocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                            XtraMessageBox.Show("El registro se Anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                    }

                    #endregion
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void eliminafisicotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("No se puede eliminar, el proceso ha sido bloquedo, consulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                if (XtraMessageBox.Show("Esta seguro de Eliminar el Documento de venta - Fisicamente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    int IdDocumentoVenta = 0;
                    int IdTipoDocumento = 0;
                    int IdEmpresaElimina = 13;
                    IdEmpresaElimina = int.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "IdTipoDocumento").ToString());

                    //Validar Periodo
                    DateTime Fecha;
                    Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Fecha").ToString());

                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    if (IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        XtraMessageBox.Show("No se Eliminar un Ticket, Bloqueado por la SUNAT.\nConsulte con el área de Contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //Documento
                    DocumentoVentaBE objBE_DocumentoVenta = new DocumentoVentaBE();
                    objBE_DocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                    objBE_DocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objBE_DocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objBE_DocumentoVenta.IdEmpresa = IdEmpresaElimina;

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objBL_DocumentoVenta.EliminaFisico(objBE_DocumentoVenta);

                    //DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    //objBL_DocumentoVenta.EliminaFisico(int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString()));
                    gvDocumento.DeleteRow(gvDocumento.FocusedRowHandle);
                    gvDocumento.RefreshData();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cambiarfechatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstablecerFecha objDescuento = new frmEstablecerFecha();
            objDescuento.StartPosition = FormStartPosition.CenterParent;
            if (objDescuento.ShowDialog() == DialogResult.OK)
            {
                int Num = 0;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int IdEmpresa = 0;
                    int IdDocumentoVenta = 0;
                    int IdTipoDocumento = 0;
                    DateTime Fecha;

                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetRowCellValue(row, "IdTipoDocumento").ToString());
                    Fecha = objDescuento.Fecha;


                    if (IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        XtraMessageBox.Show("No se cambiar la fecha de un Ticket, Bloqueado por la SUNAT.\nConsulte con el área de Contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //Validar Periodo
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    //Documento
                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    DocumentoVentaBE objE_Documento = new DocumentoVentaBE();

                    objBL_Documento.ActualizaFecha(IdEmpresa, IdDocumentoVenta, Fecha);

                    Num++;
                }
            }

            CargarBusqueda();
        }

        private void cambiarrazonsocialtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    //Validar Periodo
                    DateTime Fecha;
                    Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Fecha").ToString());
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    //doc
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
                    frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
                    objDescuento.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                    objDescuento.StartPosition = FormStartPosition.CenterParent;
                    if (objDescuento.ShowDialog() == DialogResult.OK)
                    {
                        CargarBusqueda();
                    }

                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void renumerartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstablecerNumero objDescuento = new frmEstablecerNumero();
            objDescuento.Serie = gvDocumento.GetRowCellValue(gvDocumento.FocusedRowHandle, "Serie").ToString();
            objDescuento.StartPosition = FormStartPosition.CenterParent;

            if (objDescuento.ShowDialog() == DialogResult.OK)
            {
                int Num = 0;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int IdEmpresa = 0;
                    int IdDocumentoVenta = 0;
                    int IdTipoDocumento = 0;

                    string Serie = "";
                    string Numero = "";

                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    IdTipoDocumento = int.Parse(gvDocumento.GetRowCellValue(row, "IdTipoDocumento").ToString());

                    if (IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        XtraMessageBox.Show("No se puede renumerar un Ticket y/o documento Electrónico.\nConsultar con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //Validar Periodo
                    DateTime Fecha;
                    Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    //Documento
                    Serie = objDescuento.Serie;
                    if (i == 0)
                    {
                        Num = objDescuento.Numero;
                    }

                    

                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    DocumentoVentaBE objE_Documento = new DocumentoVentaBE();

                    objE_Documento.IdEmpresa = IdEmpresa;
                    objE_Documento.IdDocumentoVenta = IdDocumentoVenta;
                    objE_Documento.Serie = Serie;
                    Numero = FuncionBase.AgregarCaracter(Num.ToString(), "0", 6);
                    objE_Documento.Numero = Numero;
                    objBL_Documento.ActualizaNumeroSerie(objE_Documento);

                    Num++;
                }
            }

            CargarBusqueda();

            //frmEstablecerNumero objDescuento = new frmEstablecerNumero();
            //objDescuento.StartPosition = FormStartPosition.CenterParent;
            //if (objDescuento.ShowDialog() == DialogResult.OK)
            //{
            //    int Num = 0;
            //    for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
            //    {
            //        int IdEmpresa = 0;
            //        int IdDocumentoVenta = 0;
            //        string Serie = "";
            //        string Numero = "";

            //        int row = gvDocumento.GetSelectedRows()[i];
            //        IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
            //        IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
            //        Serie = gvDocumento.GetRowCellValue(row, "Serie").ToString();

            //        //Validar Periodo
            //        DateTime Fecha;
            //        Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());
            //        PeriodoBE objBE_Periodo = new PeriodoBE();
            //        objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
            //        if (objBE_Periodo != null)
            //        {
            //            if (objBE_Periodo.FlagEstado == false)
            //            {
            //                XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }

            //        //Documento
            //        if (i == 0)
            //        {
            //            Num = objDescuento.Numero;
            //        }

            //        DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
            //        DocumentoVentaBE objE_Documento = new DocumentoVentaBE();

            //        objE_Documento.IdEmpresa = IdEmpresa;
            //        objE_Documento.IdDocumentoVenta = IdDocumentoVenta;
            //        objE_Documento.Serie = Serie;
            //        Numero = FuncionBase.AgregarCaracter(Num.ToString(), "0", 6);
            //        objE_Documento.Numero = Numero;
            //        objBL_Documento.ActualizaNumeroSerie(objE_Documento);

            //        Num++;
            //    }
            //}

            //CargarBusqueda();
        }

        private void chkAnulado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnulado.Checked == true)
            {
                ConvertirAnulado();
                CalcularTotalDocumentos();
            }
            else {
                Cargar();
            }
           
        }
        private void ConvertirAnulado()
        {
            //int posicion = 0;
            
            //foreach (var item in  gvDocumento.RowCount())//mLista
            //{
            //    decimal decTotal = 0;
            //    string strDescCliente = "";
            //    string strNumeroDocumento = "";
            //    string strSituacion = "";
            //    string strCodTipoDocumento = "";

            //    //decTotal = decimal.Parse(gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["Total"]).ToString());
            //    strSituacion = gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["DescSituacion"]).ToString();
            //    strCodTipoDocumento = gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["CodTipoDocumento"]).ToString();

            //    if (strSituacion == "ANULADO")
            //    {
            //        decTotal = 0;
            //        strDescCliente = "ANULADO";
            //        strNumeroDocumento = "";
            //    }
            //    else
            //    {
            //        decTotal = decimal.Parse(gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["Total"]).ToString());
            //        strDescCliente = gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["DescCliente"]).ToString();
            //        strNumeroDocumento = gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["NumeroDocumento"]).ToString();
            //        if (strCodTipoDocumento == "NCV")
            //        {
            //            decTotal = decimal.Parse(gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["Total"]).ToString()) * -1;
            //        }
            //    }

            //    gvDocumento.SetRowCellValue(posicion, gvDocumento.Columns["Total"], decTotal);
            //    gvDocumento.SetRowCellValue(posicion, gvDocumento.Columns["DescCliente"], strDescCliente);
            //    gvDocumento.SetRowCellValue(posicion, gvDocumento.Columns["NumeroDocumento"], strNumeroDocumento);
            //    posicion++;
            //}

//----------------------------
            int Num = 0;
            for (int i = 0; i < gvDocumento.RowCount; i++)
            {
                decimal decSubTotal = 0;
                decimal decIGV = 0;
                decimal decTotal = 0;
                string strDescCliente = "";
                string strNumeroDocumento = "";
                string strSituacion = "";
                string strCodTipoDocumento = "";

                //decTotal = decimal.Parse(gvDocumento.GetRowCellValue(posicion, gvDocumento.Columns["Total"]).ToString());
                strSituacion = gvDocumento.GetRowCellValue(i, gvDocumento.Columns["DescSituacion"]).ToString();
                strCodTipoDocumento = gvDocumento.GetRowCellValue(i, gvDocumento.Columns["CodTipoDocumento"]).ToString();

                if (strSituacion == "ANULADO")
                {
                    decSubTotal = 0;
                    decIGV = 0;
                    decTotal = 0;
                    strDescCliente = "ANULADO";
                    strNumeroDocumento = "0";
                }
                else
                {
                    decSubTotal = decimal.Parse(gvDocumento.GetRowCellValue(i, gvDocumento.Columns["SubTotal"]).ToString());
                    decIGV = decimal.Parse(gvDocumento.GetRowCellValue(i, gvDocumento.Columns["Igv"]).ToString());
                    decTotal = decimal.Parse(gvDocumento.GetRowCellValue(i, gvDocumento.Columns["Total"]).ToString());

                    strDescCliente = gvDocumento.GetRowCellValue(i, gvDocumento.Columns["DescCliente"]).ToString();
                    strNumeroDocumento = gvDocumento.GetRowCellValue(i, gvDocumento.Columns["NumeroDocumento"]).ToString();
                    if (strCodTipoDocumento == "NCV"|| strCodTipoDocumento=="NCE")
                    {
                        decSubTotal = decimal.Parse(gvDocumento.GetRowCellValue(i, gvDocumento.Columns["SubTotal"]).ToString()) * -1;
                        decIGV = decimal.Parse(gvDocumento.GetRowCellValue(i, gvDocumento.Columns["Igv"]).ToString()) * -1;
                        decTotal = decimal.Parse(gvDocumento.GetRowCellValue(i, gvDocumento.Columns["Total"]).ToString()) * -1;
                    }
                }

                gvDocumento.SetRowCellValue(i, gvDocumento.Columns["SubTotal"], decSubTotal);
                gvDocumento.SetRowCellValue(i, gvDocumento.Columns["Igv"], decIGV);
                gvDocumento.SetRowCellValue(i, gvDocumento.Columns["Total"], decTotal);
                gvDocumento.SetRowCellValue(i, gvDocumento.Columns["DescCliente"], strDescCliente);
                gvDocumento.SetRowCellValue(i, gvDocumento.Columns["NumeroDocumento"], strNumeroDocumento);

                Num++;
            }


        }

        private void btnConsultarDiferencia_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegCabeceraDetalle objVentaPedido = new frmRegCabeceraDetalle();
                objVentaPedido.FechaInicio = Convert.ToDateTime(deDesde.DateTime.ToShortDateString());
                objVentaPedido.FechaFin = Convert.ToDateTime(deHasta.DateTime.ToShortDateString());
                objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                objVentaPedido.ShowDialog();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvDocumento_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }

        private void recuperardocumentotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de recuperar los documentos Anulados? \nEsta acción actualizará el total de las ventas diarias", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Num = 0;
                for (int i = 0; i < gvDocumento.SelectedRowsCount; i++)
                {
                    int IdEmpresa = 0;
                    int IdDocumentoVenta = 0;

                    int row = gvDocumento.GetSelectedRows()[i];
                    IdEmpresa = int.Parse(gvDocumento.GetRowCellValue(row, "IdEmpresa").ToString());
                    IdDocumentoVenta = int.Parse(gvDocumento.GetRowCellValue(row, "IdDocumentoVenta").ToString());
                    //Serie = gvDocumento.GetRowCellValue(row, "Serie").ToString();

                    //Validar Periodo
                    DateTime Fecha;
                    Fecha = DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());
                    PeriodoBE objBE_Periodo = new PeriodoBE();
                    objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                    if (objBE_Periodo != null)
                    {
                        if (objBE_Periodo.FlagEstado == false)
                        {
                            XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    objBL_Documento.ActualizaSituacion(IdEmpresa, IdDocumentoVenta, Parametros.intDVCancelado);

                    Num++;
                }
            }

            XtraMessageBox.Show("Los datos se actualizaron correctamente, ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cargar();
        }

        private void pedidoasociartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
                    frmBusPedido objDescuento = new frmBusPedido();
                    //objDescuento.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                    objDescuento.StartPosition = FormStartPosition.CenterParent;
                    if (objDescuento.ShowDialog() == DialogResult.OK)
                    {
                        if (objDescuento.pPedidoBE != null)
                        {
                            DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                            objBL_DocumentoVenta.ActualizaVinculoPedido(Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta), objDescuento.pPedidoBE.IdPedido);
                            XtraMessageBox.Show("Documento vinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("El Número de pedido no existe y/o anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //XtraMessageBox.Show("Documento Vinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Cargar();
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pedidodesasociartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    DocumentoVentaBE objE_DocumentoVenta = (DocumentoVentaBE)gvDocumento.GetRow(gvDocumento.FocusedRowHandle);
                    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    objBL_Documento.ActualizaVinculoPedido(objE_DocumentoVenta.IdDocumentoVenta, 0);
                    XtraMessageBox.Show("Documento Desvinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obsequiocostotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Un momento olguita, los monto deben ser cero, olvida la versión anterior.\nPara más información consultar con sistemas.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //if (XtraMessageBox.Show("Esta operación realizará cambios en el detalle de los documentos obsequiados\nDesde el " + deDesde.DateTime.ToString("dd/MM/yyyy") + " Hasta " + deHasta.DateTime.ToString("dd/MM/yyyy") + " , Se actualizará el precio de costo.\nEsta seguro de realizar esta operación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
            //    objBL_Documento.ActualizaObsequioCosto(deDesde.DateTime, deHasta.DateTime);
            //    XtraMessageBox.Show("Documentos actualizados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSerie.Focus();
            }
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumero.Focus();
            }
        }

        private void gvDocumento_RowStyle(object sender, RowStyleEventArgs e)
        {

        }
    }
}
