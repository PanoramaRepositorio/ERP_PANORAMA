using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegControlDiseno : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //private List<PedidoBE> mLista = new List<PedidoBE>();
        private List<AsesoriaBE> mLista = new List<AsesoriaBE>();

        #endregion

        #region "Eventos"

        public frmRegControlDiseno()
        {
            InitializeComponent();
        }

        private void frmRegControlDiseno_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
        }

        private void tlbMenu_NewClick()
        {

            //XtraMessageBox.Show("Favor de consultar los pedidos de asesoria por Rango de Fecha", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                frmRegControlDisenoEdit objManPedidol = new frmRegControlDisenoEdit();
                objManPedidol.pOperacion = frmRegControlDisenoEdit.Operacion.Nuevo;
                //objManPedidol.IdPedido = 0;
                objManPedidol.StartPosition = FormStartPosition.CenterParent;
                objManPedidol.ShowDialog();
                Cargar();
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
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Está seguro de eliminar el registro de Asesoria?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        AsesoriaBE objE_Asesoria = new AsesoriaBE();
                        AsesoriaBL objBL_Asesoria = new AsesoriaBL();

                        objE_Asesoria.IdAsesoria = int.Parse(gvPedido.GetFocusedRowCellValue("IdAsesoria").ToString());
                        objBL_Asesoria.Elimina(objE_Asesoria);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
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
            //try
            //{
            //    if (gvPedido.RowCount > 0)
            //    {
            //        frmListaPrinters frmPrinter = new frmListaPrinters();
            //        if (frmPrinter.ShowDialog() == DialogResult.OK)
            //        {
            //            List<ReportePedidoContadoBE> lstReporte = null;
            //            lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));
            //            if (lstReporte.Count > 0)
            //            {
            //                rptPedidoContado objReporteGuia = new rptPedidoContado();
            //                objReporteGuia.SetDataSource(lstReporte);
            //                objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
            //                objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
            //                objReporteGuia.SetParameterValue("Modificado", "()");

            //                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedidoDiseño";
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
            Cargar();
        }

        private void gvPedido_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                DataRow dr;
                int IdPedido = 0;
                string sIdPedido = "";
                dr = gvPedido.GetDataRow(e.RowHandle);
                sIdPedido = dr["IdPedido"].ToString();
                if (sIdPedido != "") {
                    IdPedido = int.Parse(dr["IdPedido"].ToString());
                    CargarDetalles(IdPedido);              
                }
                
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
                    int IdTipoCliente = 0;
                    int IdClasificacionCliente = 0;
                    string CodMoneda = "";

                    IdPedido = int.Parse(gvPedido.GetRowCellValue(gvPedido.FocusedRowHandle, "IdPedido").ToString());
                    Periodo = 2020; //int.Parse(gvPedido.GetRowCellValue(gvPedido.FocusedRowHandle, "Periodo").ToString());
                    IdTipoCliente = int.Parse(gvPedido.GetRowCellValue(gvPedido.FocusedRowHandle, "IdTipoCliente").ToString());
                    IdClasificacionCliente = int.Parse(gvPedido.GetRowCellValue(gvPedido.FocusedRowHandle, "IdClasificacionCliente").ToString());
                    CodMoneda = gvPedido.GetRowCellValue(gvPedido.FocusedRowHandle, "CodMoneda").ToString();

                    //IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    //Periodo = int.Parse(gvPedido.GetFocusedRowCellValue("Periodo").ToString());
                    //IdTipoCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoCliente").ToString());
                    //IdClasificacionCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdClasificacionCliente").ToString());
                    //CodMoneda = gvPedido.GetFocusedRowCellValue("CodMoneda").ToString();

                    if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)
                    {
                        List<ReportePedidoSolesBE> lstReporte = null;
                        lstReporte = new ReportePedidoSolesBL().Listado(Periodo, IdPedido);

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
                        if (CodMoneda == "US$")
                        {
                            List<ReportePedidoDolaresBE> lstReporte = null;
                            lstReporte = new ReportePedidoDolaresBL().Listado(Periodo, IdPedido);

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
                        else
                        {
                            List<ReportePedidoSolesBE> lstReporte = null;
                            lstReporte = new ReportePedidoSolesBL().Listado(Periodo, IdPedido);

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
                    lstReporte = new ReporteProductoCatalogoPedidoBL().Listado(Parametros.intEmpresaId, IdPedido);

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
            dtPedido = FuncionBase.ToDataTable(new AsesoriaBL().ListaTodosActivo(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime));

            gcPedido.DataSource = dtPedido;

            txtTotal.Text = dtPedido.Rows.Count.ToString();

            decimal decTotalSoles = 0;
            decimal decTotalDolares = 0;

            foreach (DataRow row in dtPedido.Rows)
            {
                if (int.Parse(row["IdSituacion"].ToString()) == Parametros.intFacturado || int.Parse(row["IdSituacion"].ToString()) == Parametros.intPVDespachado)
                {
                    //Suma Contado Cancelados o Despachado
                    if (row["CodMoneda"].ToString() == "US$")
                    {
                        decTotalDolares = decTotalDolares + Convert.ToDecimal(row["Total"].ToString());
                    }
                    else
                    {
                        decTotalSoles = decTotalSoles + Convert.ToDecimal(row["Total"].ToString());
                    }
                }

            }

            txtTotalSoles.EditValue = decTotalSoles;
            txtTotalDolares.EditValue = decTotalDolares;
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

        public void InicializarModificar()
        {
            if (gvPedido.RowCount > 0)
            {
                AsesoriaBE objAsesoria = new AsesoriaBE();
                objAsesoria.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                objAsesoria.FechaContrato = (gvPedido.GetFocusedRowCellValue("FechaContrato").ToString() == "") ? (DateTime?)null : DateTime.Parse(gvPedido.GetFocusedRowCellValue("FechaContrato").ToString());
                objAsesoria.FechaVenta = (gvPedido.GetFocusedRowCellValue("FechaVenta").ToString() == "") ? (DateTime?)null : DateTime.Parse(gvPedido.GetFocusedRowCellValue("FechaVenta").ToString()); ;
                objAsesoria.FechaVisita = (gvPedido.GetFocusedRowCellValue("FechaVisita").ToString() == "") ? (DateTime?)null : DateTime.Parse(gvPedido.GetFocusedRowCellValue("FechaVisita").ToString()); ;
                objAsesoria.FechaEntrega = (gvPedido.GetFocusedRowCellValue("FechaEntrega").ToString() == "") ? (DateTime?)null : DateTime.Parse(gvPedido.GetFocusedRowCellValue("FechaEntrega").ToString()); ;
                objAsesoria.Observacion = gvPedido.GetFocusedRowCellValue("Observacion").ToString();
                objAsesoria.IdAsesor = int.Parse(gvPedido.GetFocusedRowCellValue("IdAsesor").ToString());
                objAsesoria.IdCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdCliente").ToString());
                objAsesoria.DescCliente = gvPedido.GetFocusedRowCellValue("DescCliente").ToString();
                objAsesoria.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

                frmRegControlDisenoEdit objRegPedidoEdit = new frmRegControlDisenoEdit();
                objRegPedidoEdit.pOperacion = frmRegControlDisenoEdit.Operacion.Modificar;
                objRegPedidoEdit.pAsesoriaBE = objAsesoria;
                objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                //objRegPedidoEdit.btnGrabar.Enabled = true;
                objRegPedidoEdit.ShowDialog();

                Cargar();
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

            if (gvPedido.GetFocusedRowCellValue("IdPedido").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void asociarapedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (mLista.Count > 0)
                if (Convert.ToInt32(txtTotal.EditValue) > 0)
                {
                    int IdAsesoria = 0;
                    IdAsesoria = int.Parse(gvPedido.GetFocusedRowCellValue("IdAsesoria").ToString());

                    frmBusPedido objDescuento = new frmBusPedido();
                    objDescuento.StartPosition = FormStartPosition.CenterParent;
                    if (objDescuento.ShowDialog() == DialogResult.OK)
                    {
                        if (objDescuento.pPedidoBE != null)
                        {
                            AsesoriaBL objBL_Asesoria = new AsesoriaBL();
                            objBL_Asesoria.ActualizaVinculoPedido(IdAsesoria, objDescuento.pPedidoBE.IdPedido);
                            XtraMessageBox.Show("Documento vinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("El Número de pedido no existe y/o anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    Cargar();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}