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
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Creditos.Consultas;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConPedidoFecha : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();
        
        #endregion

        #region "Eventos"

        public frmConPedidoFecha()
        {
            InitializeComponent();
        }

        private void frmConPedidoFecha_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            txtPeriodo.EditValue = DateTime.Now.Year;
            gcTotalVentaRep.Visible = false;
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.strUsuarioLogin =="liliana")
            {
                compraperfectatoolStripMenuItem.Visible = true;
                pedidoauditadotoolStripMenuItem.Visible = true;
            }
            else
            {
                compraperfectatoolStripMenuItem.Visible = false;
                pedidoauditadotoolStripMenuItem.Visible = false;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
            CargarResumen();
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

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero();
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedidoFecha";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPedido.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
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

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            //if (gvPedido.RowCount > 0)
            //{
            //    frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
            //    frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //    frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
            //    frm.StartPosition = FormStartPosition.CenterParent;
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
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
                XtraMessageBox.Show("Se Eliminó el pedido de compra perfecta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "FlagCompraPerfecta", false);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se puede asignar compra perfecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vermovimientocajatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                    frmVerMovimientoCaja frm = new frmVerMovimientoCaja();
                    frm.IdPedido = IdPedido;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void verestadocuentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdCliente = 0;
                    int IdMotivo = 0;
                    IdCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdCliente").ToString());
                    IdMotivo = int.Parse(gvPedido.GetFocusedRowCellValue("IdMotivo").ToString());

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    if (IdCliente.ToString() != "")
                    {
                        //if (objE_Cliente.IdTipoCliente  == Parametros.intTipClienteMayorista)
                        if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                        {
                            ////var objE_EstadoCuenta;
                            //EstadoCuentaBE objE_EstadoCuenta = null;
                            //objE_EstadoCuenta = (EstadoCuentaBE)gvPedido.GetFocusedRow();

                            ////XtraMessageBox.Show(objE_EstadoCuenta.DescCliente +"   "+ objE_EstadoCuenta.Concepto, this.Text);

                            frmConEstadoCuenta frm = new frmConEstadoCuenta();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                            frm.DescCliente = objE_Cliente.DescCliente;
                            frm.IdMotivoVenta = IdMotivo;
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                        else
                        {
                            //SeparacionBE objE_Separacion = null;
                            //objE_Separacion = (SeparacionBE)gvPedido.GetFocusedRow();

                            frmConSeparacion frm = new frmConSeparacion();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_Cliente.NumeroDocumento;//  gvPedido.GetFocusedRowCellValue("NumeroDocumento").ToString();
                            frm.DescCliente = objE_Cliente.DescCliente;// gvPedido.GetFocusedRowCellValue("DescCliente").ToString();
                            frm.IdMotivoVenta = IdMotivo;
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Seleccionar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        Cargar();
                    }
                }
                else
                {
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

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
                }

            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int TipoConsulta = 0;
            if (chkAutoservicio.Checked)TipoConsulta = 1;

            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFecha(deDesde.DateTime, deHasta.DateTime, TipoConsulta);
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
        }

        private void CargarResumen()
        {
            int TipoConsulta = 0;
            if (chkAutoservicio.Checked) TipoConsulta = 1;

            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaResumen(deDesde.DateTime, deHasta.DateTime, TipoConsulta);
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcReporte.DataSource = dtPedido;

            CalcularTotalResumen();
        }
        private void CalcularTotalResumen()
        {
            try
            {
                decimal decTotalAutoservicio = 0;
                decimal decTotalPedido = 0;
                decimal decTotalVendedor = 0;
                decimal decTotalVenta = 0;
   
                for (int i = 0; i < gvReporte.RowCount; i++)
                {
                    decTotalAutoservicio = decTotalAutoservicio + Convert.ToDecimal(gvReporte.GetRowCellValue(i, (gvReporte.Columns["TotalBruto"])));
                    decTotalPedido = decTotalPedido + Convert.ToDecimal(gvReporte.GetRowCellValue(i, (gvReporte.Columns["TotalCantidad"])));
                    decTotalVendedor = decTotalVendedor + Convert.ToDecimal(gvReporte.GetRowCellValue(i, (gvReporte.Columns["Cantidad"])));
                    decTotalVenta = decTotalVenta + Convert.ToDecimal(gvReporte.GetRowCellValue(i, (gvReporte.Columns["Total"])));
                }
                txtTotalAutoservicio.EditValue = decTotalAutoservicio;
                txtTotalPedido.EditValue = decTotalPedido;
                txtTotalVendedor.EditValue = decTotalVendedor;
                txtTotalVenta.EditValue = decTotalVenta;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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

        #endregion

        private void agregartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.ActualizaFlagAuditado(IdPedido, true);
                    gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "FlagAuditado", true);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    if (XtraMessageBox.Show("Desea eliminar la auditoria al pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int IdPedido = 0;
                        IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                        PedidoBL objBL_Pedido = new PedidoBL();
                        objBL_Pedido.ActualizaFlagAuditado(IdPedido, false);
                        gvPedido.SetRowCellValue(gvPedido.FocusedRowHandle, "FlagAuditado", false);
                    }


                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verfechauditadotoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asignardiseñadortoolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}