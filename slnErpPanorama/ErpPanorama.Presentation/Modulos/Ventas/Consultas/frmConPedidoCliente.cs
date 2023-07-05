using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConPedidoCliente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PedidoBE> mLista = new List<PedidoBE>();

        int IdCliente = 0;
        
        #endregion

        #region "Eventos"

        public frmConPedidoCliente()
        {
            InitializeComponent();
        }

        private void frmConPedidoCliente_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            txtPeriodo.EditValue = DateTime.Now.Year;

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.strUsuarioLogin =="liliana")
            {
                compraperfectatoolStripMenuItem.Visible = true;
            }
            else
            {
                compraperfectatoolStripMenuItem.Visible = false;
            }

        }


        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    if (int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString()) == Parametros.intContado)
                    {
                        int IdPedido = 0;
                        IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                        //Actualiza Estado Impresion
                        PedidoBL objBL_Pedido = new PedidoBL();
                        PedidoBE objE_Pedido = new PedidoBE();
                        objE_Pedido = new PedidoBL().SeleccionaImpresion(IdPedido);

                        if (objE_Pedido.FlagImpresion == true)
                        {
                            XtraMessageBox.Show("El pedido ya ha sido impreso, por favor Consultar con la Recepcionista de pedido contado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //PedidoBL objBL_Pedido = new PedidoBL();
                        objBL_Pedido.ActualizaImpresion(IdPedido, true);
                    }

                    //Carga Reporte

                    frmListaPrinters frmPrinter = new frmListaPrinters();
                    if (frmPrinter.ShowDialog() == DialogResult.OK)
                    {
                        List<ReportePedidoContadoBE> lstReporte = null;
                        lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()), Parametros.intTiendaId);
                        if (lstReporte.Count > 0)
                        {
                            rptPedidoContado objReporteGuia = new rptPedidoContado();
                            objReporteGuia.SetDataSource(lstReporte);
                            objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                            objReporteGuia.SetParameterValue("Modificado", "()");

                            Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.PaperA4);  // .DefaultPaperSize

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedidoCliente_" + txtNumeroDocumento.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPedido.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Debe seleccionar una situación del pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroDocumento.Focus();
                return;
            }

            Cargar();
        }

        private void gvPedido_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                DataRow dr;
                int IdPedido = 0;
                dr = gvPedido.GetDataRow(e.RowHandle);
                IdPedido = int.Parse(dr["IdPedido"].ToString());
                //CargarDetalles(IdPedido);

                int IdTipoDocumento = int.Parse(dr["IdTipoDocumento"].ToString()); //add
                if (IdTipoDocumento == Parametros.intTipoDocPedidoVenta)
                {
                    CargarDetalles(IdPedido);
                }
                else //Autoservicio y Ncv
                {
                    DataTable dtDetalle = new DataTable();
                    dtDetalle = FuncionBase.ToDataTable(new DocumentoVentaDetalleBL().ListaTodosActivo(IdPedido));
                    gcPedidoDetalle.DataSource = dtDetalle;
                }

                
            }

        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                if (objE_Cliente != null)
                {
                    IdCliente = objE_Cliente.IdCliente;
                    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = objE_Cliente.DescCliente;
                }
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    int Periodo = 0;
                    int IdClasificacionCliente = 0;
                    int IdTipoCliente = 0;
                    string CodMoneda = "";

                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    Periodo = int.Parse(gvPedido.GetFocusedRowCellValue("Periodo").ToString());
                    IdTipoCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoCliente").ToString());
                    IdClasificacionCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdClasificacionCliente").ToString());
                    CodMoneda = gvPedido.GetFocusedRowCellValue("CodMoneda").ToString();

                    if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)
                    {
                        List<ReportePedidoSolesBE> lstReporte = null;
                        lstReporte = new ReportePedidoSolesBL().Listado(Periodo, IdPedido);

                        #region "Codigo Barras"

                        iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                        bc.TextAlignment = Element.ALIGN_LEFT;
                        bc.Code = lstReporte[0].Numero;
                        bc.StartStopText = false;
                        bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                        bc.Extended = true;
                        bc.BarHeight = 27;
                        lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                        #endregion

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                objRptSolicitudProducto.VerRptPedidoSoles(lstReporte, Parametros.strUsuarioLogin);
                                objRptSolicitudProducto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }

                    if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)
                    {
                        List<ReportePedidoDolaresBE> lstReporte = null;
                        lstReporte = new ReportePedidoDolaresBL().Listado(Periodo, IdPedido);

                        #region "Codigo Barras"

                        iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                        bc.TextAlignment = Element.ALIGN_LEFT;
                        bc.Code = lstReporte[0].Numero;
                        bc.StartStopText = false;
                        bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                        bc.Extended = true;
                        bc.BarHeight = 27;
                        lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                        #endregion

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {

                                RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                objRptSolicitudProducto.VerRptPedidoDolares(lstReporte, Parametros.strUsuarioLogin);
                                objRptSolicitudProducto.ShowDialog();


                            }
                            else
                                XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }


                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                    {
                        if (CodMoneda == "S/")
                        {
                            List<ReportePedidoSolesBE> lstReporte = null;
                            lstReporte = new ReportePedidoSolesBL().Listado(Periodo, IdPedido);

                            #region "Codigo Barras"

                            iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                            bc.TextAlignment = Element.ALIGN_LEFT;
                            bc.Code = lstReporte[0].Numero;
                            bc.StartStopText = false;
                            bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                            bc.Extended = true;
                            bc.BarHeight = 27;
                            lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                            #endregion


                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                    objRptSolicitudProducto.VerRptPedidoSolesMayorista(lstReporte, Parametros.strUsuarioLogin);
                                    objRptSolicitudProducto.ShowDialog();
                                }
                                else
                                    XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            List<ReportePedidoDolaresBE> lstReporte = null;
                            lstReporte = new ReportePedidoDolaresBL().Listado(Periodo, IdPedido);

                            #region "Codigo Barras"

                            iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                            bc.TextAlignment = Element.ALIGN_LEFT;
                            bc.Code = lstReporte[0].Numero;
                            bc.StartStopText = false;
                            bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                            bc.Extended = true;
                            bc.BarHeight = 27;
                            lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                            #endregion

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {

                                    RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                    objRptSolicitudProducto.VerRptPedidoDolares(lstReporte, Parametros.strUsuarioLogin);
                                    objRptSolicitudProducto.ShowDialog();


                                }
                                else
                                    XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void VerCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                    List<ReporteProductoCatalogoPedidoBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoPedidoBL().Listado(13, IdPedido);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoPedido = new RptVistaReportes();
                            objRptProductoCatalogoPedido.VerRptProductoCatalogoPedido(lstReporte);
                            objRptProductoCatalogoPedido.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerDocumentoVentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    int IdSituacion = 0;
                    string Numero = "";

                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                    Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

                    if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    {
                        frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                        objVentaPedido.IdPedido = IdPedido;
                        objVentaPedido.NumeroPedido = Numero;
                        objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                        objVentaPedido.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaCliente(deDesde.DateTime, deHasta.DateTime, IdCliente);
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
        }

        //private void CargarBusqueda()
        //{
        //    DataTable dtPedidoBus = new DataTable();
        //    dtPedidoBus = FuncionBase.ToDataTable(mLista.Where(obj => obj.Numero.ToUpper().Contains(txtNumero.Text.ToUpper())).ToList());
        //    gcPedido.DataSource = dtPedidoBus;
        //}

        private void CargarNumero()
        {
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim());
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivo(IdPedido));
                gcPedidoDetalle.DataSource = dtDetalle;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void InicializarModificar()
        {
            if (gvPedido.RowCount > 0)
            {
                int IdTipoDocumento = 0;
                int IdSituacion = 0;

                IdTipoDocumento = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());

                if (IdTipoDocumento == Parametros.intTipoDocPedidoVenta)
                { 
                    //Pedido
                    PedidoBE objPedido = new PedidoBE();
                    objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    frmRegPedidoEdit objRegPedidoEdit = new frmRegPedidoEdit();
                    objRegPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
                    objRegPedidoEdit.IdPedido = objPedido.IdPedido;
                    objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                    objRegPedidoEdit.btnGrabar.Enabled = true;
                    if (objRegPedidoEdit.ShowDialog() == DialogResult.OK)
                    {
                        if (txtNumero.Text.Trim().Length > 2)
                        {
                            CargarNumero();
                        }
                        else
                        {
                            Cargar();
                        }
                    }

                    //if (IdSituacion == Parametros.intPVGenerado || IdSituacion == Parametros.intPVAprobado)
                    //{
                    //    Cargar();
                    //    if (txtNumero.Text.Trim().Length > 2)
                    //    {
                    //        CargarNumero();
                    //    }
                    //    else
                    //    {
                    //        Cargar();
                    //    }
                    //}

                    //Cargar();
                    //CargarNumero();
                }
                else if (IdTipoDocumento != Parametros.intTipoDocPedidoVenta)
                {
                    int IdDocumentoVenta = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                    frm.IdDocumentoVenta = IdDocumentoVenta;
                    frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                    frm.mnuContextual.Enabled = false;
                    frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        #endregion

        private void imprimirdespachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                int IdSituacion = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
                {
                    if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    {
                        List<ReporteMovimientoPedidoBE> lstReporte = null;
                        lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
                                objRptMovimientoPedido.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho,\n1. Verificar que el pedido esté embalado ó se encuentre en condición de embalaje.\n2. Verificar si tiene comprobantes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    List<ReporteMovimientoPedidoBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                            objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
                            objRptMovimientoPedido.ShowDialog();
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

        private void cambiardespachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                int IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                {
                    MessageBox.Show("No se puede modificar la hoja de despacho, después de facturado o despachado!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
                    frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void gvPedido_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedido.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdTipoDocumento"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento != Parametros.intTipoDocPedidoVenta)
                        {
                            e.Appearance.BackColor = Color.LightGreen;
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

        private void asignarcomprapefectatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoBE objBE_Pedido = new PedidoBE();
                PedidoBL objBL_Pedido = new PedidoBL();
                int IdPedido = 0;
                int IdVendedor = 0;
                int IdAsesor = 0;
                IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                objBE_Pedido = new PedidoBL().Selecciona(IdPedido);
                IdVendedor = objBE_Pedido.IdVendedor;
                IdAsesor = objBE_Pedido.IdAsesor;

                objBL_Pedido.ActualizaCompraPerfecta(IdPedido, IdVendedor, IdAsesor, true);
                XtraMessageBox.Show("Se agregó el pedido a compra perfecta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "FlagCompraPerfecta", true);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se puede asignar compra perfecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarcompraperfectatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoBL objBL_Pedido = new PedidoBL();
                int IdPedido = 0;
                IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                objBL_Pedido.ActualizaCompraPerfecta(IdPedido,0,0, false);
                XtraMessageBox.Show("Se eliminó el pedido de compra perfecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se puede asignar compra perfecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void diseñadortoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoBE objBE_Pedido = new PedidoBE();
                PedidoBL objBL_Pedido = new PedidoBL();
                int IdPedido = 0;
                int IdVendedor = 0;
                int IdAsesor = 0;
                IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                objBE_Pedido = new PedidoBL().Selecciona(IdPedido);
                IdVendedor = objBE_Pedido.IdVendedor;
                IdAsesor = objBE_Pedido.IdAsesor;

                objBL_Pedido.ActualizaCompraPerfecta(IdPedido, IdAsesor, IdVendedor, true);
                XtraMessageBox.Show("Se agregó el pedido a compra perfecta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "FlagCompraPerfecta", true);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se puede asignar compra perfecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogosinpreciotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                    List<ReporteProductoCatalogoPedidoBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoPedidoBL().Listado(13, IdPedido);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoPedido = new RptVistaReportes();
                            objRptProductoCatalogoPedido.VerRptProductoCatalogoPedidoSinPrecio(lstReporte);
                            objRptProductoCatalogoPedido.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}