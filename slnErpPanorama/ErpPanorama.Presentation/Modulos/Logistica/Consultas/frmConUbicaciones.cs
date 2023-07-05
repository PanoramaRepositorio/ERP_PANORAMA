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
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConUbicaciones : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<UbicacionesBE> mLista = new List<UbicacionesBE>();

        #endregion

        #region "Eventos"

        public frmConUbicaciones()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaUbicaciones";
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

        private void despachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }
       

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        #endregion

        #region "Eventos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            mLista = new UbicacionesBL().ListaUbicaciones();

            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivo(IdPedido));
                //gcPedidoDetalle.DataSource = dtDetalle;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region "No necesario para este formulario"

        private void asignarchofertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmRegAsignarConductorPedido frm = new frmRegAsignarConductorPedido();
            //frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
        }
        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //FilaDoubleClick(view, pt);
        }
        private void frmConUbicaciones_Load(object sender, EventArgs e)
        {
            //deDesde.EditValue = DateTime.Now;
            //deHasta.EditValue = DateTime.Now;
        }
        private void gvPedido_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                //DataRow dr;
                //int IdPedido = 0;
                //dr = gvPedido.GetDataRow(e.RowHandle);
                //IdPedido = int.Parse(dr["IdPedido"].ToString());
                //CargarDetalles(IdPedido);
            }
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


        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    DataTable dtPedido = new DataTable();
            //    dtPedido = FuncionBase.ToDataTable(new MovimientoPedidoBL().ListaNumero(Parametros.intPeriodo, ""));
            //    if (dtPedido.Rows.Count > 0)
            //    {
            //        gcPedido.DataSource = dtPedido;
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("El N° Pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        public void InicializarModificar()
        {
            //frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
            //frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
            //    int IdSituacion = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
            //    if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
            //    {
            //        if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
            //        {
            //            List<ReporteMovimientoPedidoBE> lstReporte = null;
            //            lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

            //            if (lstReporte != null)
            //            {
            //                if (lstReporte.Count > 0)
            //                {
            //                    RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                    objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                    objRptMovimientoPedido.ShowDialog();
            //                }
            //                else
            //                    XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho, Verificar si tiene comprobantes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        List<ReporteMovimientoPedidoBE> lstReporte = null;
            //        lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                objRptMovimientoPedido.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }

            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteMovimientoPedidoBE> lstReporte = null;
            //    lstReporte = new  ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));
                


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

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imprimirDespachoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
            //    int IdSituacion = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());

            //    if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
            //    {
            //        if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
            //        {
            //            List<ReporteMovimientoPedidoBE> lstReporte = null;
            //            lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

            //            if (lstReporte != null)
            //            {
            //                if (lstReporte.Count > 0)
            //                {
            //                    RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                    objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                    objRptMovimientoPedido.ShowDialog();
            //                }
            //                else
            //                    XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho,\n1. Verificar que el pedido esté embalado ó se encuentre en condición de embalaje.\n2. Verificar si tiene comprobantes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        List<ReporteMovimientoPedidoBE> lstReporte = null;
            //        lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                objRptMovimientoPedido.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void imprimirDespachoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
            //    int IdSituacion = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
            //    if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
            //    {
            //        if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
            //        {
            //            List<ReporteMovimientoPedidoBE> lstReporte = null;
            //            lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

            //            if (lstReporte != null)
            //            {
            //                if (lstReporte.Count > 0)
            //                {
            //                    RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                    objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                    objRptMovimientoPedido.ShowDialog();
            //                }
            //                else
            //                    XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho,\n1. Verificar que el pedido esté embalado ó se encuentre en condición de embalaje.\n2. Verificar si tiene comprobantes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        List<ReporteMovimientoPedidoBE> lstReporte = null;
            //        lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                objRptMovimientoPedido.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #endregion

    }
}