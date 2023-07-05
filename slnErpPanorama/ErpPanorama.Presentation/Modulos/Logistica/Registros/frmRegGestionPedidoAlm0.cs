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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegGestionPedidoAlm0 : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoPedidoBE> mLista = new List<MovimientoPedidoBE>();

        #endregion

        #region "Eventos"

        public frmRegGestionPedidoAlm0()
        {
            InitializeComponent();
        }

        private void frmRegGestionPedidoAlm0_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            txtPeriodo.EditValue = DateTime.Now.Year;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
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
                CargarDetalles(IdPedido);
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaGestionPedido";
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

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void aprobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gvPedido.RowCount > 0)
            //    {
            //        frmRegCambiarSituacionPedidoAlmacen objManSituacion = new frmRegCambiarSituacionPedidoAlmacen();
            //        objManSituacion.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //        objManSituacion.StartPosition = FormStartPosition.CenterParent;
            //        objManSituacion.ShowDialog();
            //        Cargar();
            //        CargarDetalles(0);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void asignarchofertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                frmRegAsignarConductorPedido frm = new frmRegAsignarConductorPedido();
                frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    despacharpedidotoolStripMenuItem_Click(sender, e);

                    Cargar();
                    CargarDetalles(0);
                }
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtPedido = new DataTable();
                dtPedido = FuncionBase.ToDataTable(new MovimientoPedidoBL().ListaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim()));
                if (dtPedido.Rows.Count > 0)
                {
                    gcPedido.DataSource = dtPedido;
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de Actualizar los datos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    prgFactura.Visible = true;
                    for (int i = 0; i < gvPedido.SelectedRowsCount; i++)
                    //for (int i = 0; i < gvPedido.RowCount -1; i++)
                    {
                        int IdPedido = 0;
                        string Observacion = "";

                        int row = gvPedido.GetSelectedRows()[i];
                        int TotRow = gvPedido.SelectedRowsCount;
                        TotRow = TotRow - row + 1;
                        prgFactura.Properties.Step = 1;
                        prgFactura.Properties.Maximum = TotRow;
                        prgFactura.Properties.Minimum = 0;

                        IdPedido = int.Parse(gvPedido.GetRowCellValue(row, "IdPedido").ToString());
                        Observacion = gvPedido.GetRowCellValue(row, "Observacion").ToString();
                        //List<MovimientoPedidoBE> lstPedidoDetalle = new List<MovimientoPedidoBE>();

                        MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        ////objBL_MovimientoPedido.Selecciona(IdPedido); 

                        //objBE_MovimientoPedido.IdPedido = IdPedido;
                        //objBE_MovimientoPedido.Recibido = Boolean.Parse(gvPedido.GetRowCellValue(row, "Recibido").ToString());
                        //objBE_MovimientoPedido.FechaRecibido = DateTime.Now;
                        //objBE_MovimientoPedido.EnPT = Boolean.Parse(gvPedido.GetRowCellValue(row, "EnPT").ToString());
                        //objBE_MovimientoPedido.FechaPT = DateTime.Now;
                        //objBE_MovimientoPedido.RecepcionDocumento = Boolean.Parse(gvPedido.GetRowCellValue(row, "RecepcionDocumento").ToString());
                        //objBE_MovimientoPedido.FechaRD = DateTime.Now;
                        //objBE_MovimientoPedido.Despachado = Boolean.Parse(gvPedido.GetRowCellValue(row, "Despachado").ToString());
                        //objBE_MovimientoPedido.FechaDespachado = DateTime.Now;
                        //objBE_MovimientoPedido.Observacion = gvPedido.GetRowCellValue(row, "Observacion").ToString();
                        ////lstPedidoDetalle.Add(objBE_MovimientoPedido);

                        //objBL_MovimientoPedido.ActualizaEstado(objBE_MovimientoPedido);

                        objBL_MovimientoPedido.ActualizaObservacion(IdPedido, Observacion);

                        prgFactura.PerformStep();
                        prgFactura.Update();

                    }
                    //gvPedido.DeleteRow(gvDocumento.FocusedRowHandle);
                    //gvPedido.RefreshData();
                    XtraMessageBox.Show("El actualizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prgFactura.Visible = false;
                    Cargar();

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void despachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                InicializarModificar();
            }
            //Cargar();
            //CargarDetalles(0);
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
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
                        XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho, Verificar si tiene comprobantes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteMovimientoPedidoBE> lstReporte = null;
            //    lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));



            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //            objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //            objRptMovimientoPedido.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void habilitapedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (Parametros.strUsuarioLogin == "master"|| Parametros.strUsuarioLogin == "aflores" || Parametros.strUsuarioLogin == "jtapia" || Parametros.strUsuarioLogin == "adavila" || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    if (XtraMessageBox.Show("Está seguro de habilitar el pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Chequeador
                        int IdPedido = 0;
                        string DescFormaPago = "";

                        IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                        DescFormaPago = gvPedido.GetFocusedRowCellValue("FormaPago").ToString();
                        MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                        objE_MovimientoPedido.IdPedido = IdPedido;
                        objE_MovimientoPedido.IdAuxiliar = 0;
                        objE_MovimientoPedido.IdChequeador = 0;
                        if (DescFormaPago == "CONTADO")
                            objBL_MovimientoPedido.ActualizaAuxiliar(objE_MovimientoPedido);
                        else
                            objBL_MovimientoPedido.ActualizaChequeador(objE_MovimientoPedido);
                        XtraMessageBox.Show("El Pedido quedo libre para ser modificado,\nEsto aplica sólo a pedidos con Situación: Generado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void asignarpersonalpickingtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegAsignarAuxiliarPedido frm = new frmRegAsignarAuxiliarPedido();
            frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            Cargar();
        }

        private void txtNumerotoolStripTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "jvasquez" || Parametros.strUsuarioLogin == "lvicente" || Parametros.strUsuarioLogin == "aflores")
                {
                    if (XtraMessageBox.Show("Está seguro de habilitar el pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Chequeador
                        int IdPedido = 0;
                        int IdFormaPago = 0;

                        PedidoBE objE_Pedido = new PedidoBE();
                        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumerotoolStripTextBox.Text.Trim());

                        if (objE_Pedido != null)
                        {
                            IdPedido = objE_Pedido.IdPedido;
                            IdFormaPago = objE_Pedido.IdFormaPago;
                            MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
                            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                            objE_MovimientoPedido.IdPedido = IdPedido;
                            objE_MovimientoPedido.IdAuxiliar = 0;
                            objE_MovimientoPedido.IdChequeador = 0;
                            if (IdFormaPago == Parametros.intContado)
                                objBL_MovimientoPedido.ActualizaAuxiliar(objE_MovimientoPedido);
                            else
                                objBL_MovimientoPedido.ActualizaChequeador(objE_MovimientoPedido);
                            XtraMessageBox.Show("El Pedido quedo libre para ser modificado,\nEsto aplica sólo a pedidos con Situación: Generado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El Pedido no existe, Verificar número", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                }
                else
                {
                    XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void imprimirhojaubicaciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmListaPrinters frmPrinter = new frmListaPrinters();
                if (frmPrinter.ShowDialog() == DialogResult.OK)
                {
                    int IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                    List<ReportePedidoContadoBE> lstReporte = null;
                    lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, IdPedido, Parametros.intTiendaId);
                    if (lstReporte.Count > 0)
                    {
                        rptPedidoContado objReporteGuia = new rptPedidoContado();
                        //rptPedidoContado objReporteGuia = new rptPedidoContado();
                        objReporteGuia.SetDataSource(lstReporte);
                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");

                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recibirpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    //PedidoBE ObjE_Pedido = null;
                    //ObjE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intRecibidoPedido, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                    gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "Recibido", true);
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void despacharpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    int IdTipoDocumento = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoDocumento").ToString());

                    if (IdTipoDocumento == Parametros.intTipoDocPedidoVenta)
                    {
                        PedidoBE ObjE_Pedido = null;
                        ObjE_Pedido = new PedidoBL().Selecciona(IdPedido);

                        if (ObjE_Pedido.IdSituacion == Parametros.intFacturado)
                        {
                            PedidoBL objBL_Pedido = new PedidoBL();
                            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                            objBL_MovimientoPedido.ActualizaOrigenDespacho(IdPedido, "Almacen");
                            objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnAlmacenDespacho, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                            gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "Despachado", true);
                            //this.Close();
                        }
                        else if (ObjE_Pedido.IdSituacion == Parametros.intPVDespachado)
                        {
                            XtraMessageBox.Show("El pedido ya se despachó!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            XtraMessageBox.Show("El pedido no se puede despachar, Verificar situación\nSólo se puede despachar un pedido Facturado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                        objBL_MovimientoAlmacen.ActualizaDespachado(IdPedido, true);
                        XtraMessageBox.Show("La Nota de Salida se despachó Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int TipoConsulta = 0;
            if (optFechaAprobado.Checked == true) TipoConsulta = 1;
            if (optFechaDespacho.Checked == true) TipoConsulta = 2;

            DataTable dtPedido = new DataTable();
            mLista = new MovimientoPedidoBL().ListaTodosActivo(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime, TipoConsulta);
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
            lblTotalRegistros.Text = mLista.Count.ToString() + " Pedidos";
        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivo(IdPedido));
                gcPedidoDetalle.DataSource = dtDetalle;
                lblTotalRegistrosDetalle.Text = dtDetalle.Rows.Count.ToString() + " Items";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InicializarModificar()
        {
            frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
            frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
            frm.Origen = 1;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        #endregion

        private void recibirdocumentotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    //PedidoBE ObjE_Pedido = null;
                    //ObjE_Pedido = new PedidoBL().Selecciona(IdPedido);

                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intRecepcionDocumento, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                    gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "RecepcionDocumento", true);
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void entregadoclientetiendatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    string Conductor = gvPedido.GetFocusedRowCellValue("Conductor").ToString();

                    if (Conductor.Length > 1)
                    {
                        if (XtraMessageBox.Show("Desea actualizar el conductor " + Conductor + ", por el cliente se llevó su mercadería?", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.Yes)
                        {
                            MovimientoPedidoBL objBL_Pedido = new MovimientoPedidoBL();
                            MovimientoPedidoBE objBE_Pedido = new MovimientoPedidoBE();
                            objBE_Pedido.IdPedido = IdPedido;
                            objBE_Pedido.IdConductor = 0;

                            objBL_Pedido.ActualizaConductorDespacho(objBE_Pedido);
                            gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "Conductor", "CLIENTE SE LLEVÓ");
                        }
                    }
                    else
                    {
                        MovimientoPedidoBL objBL_Pedido = new MovimientoPedidoBL();
                        MovimientoPedidoBE objBE_Pedido = new MovimientoPedidoBE();
                        objBE_Pedido.IdPedido = IdPedido;
                        objBE_Pedido.IdConductor = 0;

                        objBL_Pedido.ActualizaConductorDespacho(objBE_Pedido);
                        gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "Conductor", "CLIENTE SE LLEVÓ");
                    }

                    

                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["CambioFechaDelivery"]);
                    if (objDocRetiro != null)
                    {
                        Boolean IdTipoDocumento = Boolean.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento)
                        {
                            e.Appearance.BackColor = Color.RosyBrown;
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
    }
}