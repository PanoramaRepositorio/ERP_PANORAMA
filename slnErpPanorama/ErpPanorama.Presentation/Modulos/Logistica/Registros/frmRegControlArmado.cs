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
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegControlArmado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();

        #endregion

        #region "Eventos"

        public frmRegControlArmado()
        {
            InitializeComponent();
        }

        private void frmRegControlArmado_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            //txtNumero.Focus();
            
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    frmRegAuditoriaPedidoEdit objManPedidol = new frmRegAuditoriaPedidoEdit();
            //    objManPedidol.pOperacion = frmRegAuditoriaPedidoEdit.Operacion.Nuevo;
            //    objManPedidol.IdPedido = 0;
            //    objManPedidol.StartPosition = FormStartPosition.CenterParent;
            //    objManPedidol.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("Esta seguro de anular el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            PedidoBL objBL_Pedido = new PedidoBL();
            //            PedidoBE objE_Pedido = new PedidoBE();

            //            objE_Pedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //            objE_Pedido.IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());
            //            objE_Pedido.IdFormaPago = int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
            //            objE_Pedido.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();
            //            objE_Pedido.FlagPreVenta = bool.Parse(gvPedido.GetFocusedRowCellValue("FlagPreVenta").ToString());
            //            objE_Pedido.Usuario = Parametros.strUsuarioLogin;
            //            objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_Pedido.IdEmpresa = int.Parse(gvPedido.GetFocusedRowCellValue("IdEmpresa").ToString());
            //            objBL_Pedido.Elimina(objE_Pedido);
            //            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Cargar();
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


                    //Carga Informe

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

                            Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

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
            string _fileName = "ListadoPedido";
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int TipoConsulta = 0;
            //if (optFechaPedido.Checked == true)
            //{
            //    TipoConsulta = 1;
            //}
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaArmado(deDesde.DateTime, deHasta.DateTime, TipoConsulta);
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;

            CalcularTotalDocumentos();

            //txtTotal.EditValue = mLista.Count; //aadd
        }

        private void CargarNumero()
        {
            //DataTable dtPedido = new DataTable();
            //mLista = new PedidoBL().ListaNumero(Parametros.intPeriodo, txtNumero.Text.Trim());
            //dtPedido = FuncionBase.ToDataTable(mLista);
            //gcPedido.DataSource = dtPedido;
            ////txtTotal.EditValue = mLista.Count; //aadd
        }

        private void CargarDetalles(int IdPedido)
        {
            //try
            //{
            //    DataTable dtDetalle = new DataTable();
            //    dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivo(IdPedido));
            //    gcPedidoDetalle.DataSource = dtDetalle;


            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        public void InicializarModificar()
        {
            //if (gvPedido.RowCount > 0)
            //{
            //    PedidoBE objPedido = new PedidoBE();
            //    objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //    frmRegAuditoriaPedidoEdit objRegPedidoEdit = new frmRegAuditoriaPedidoEdit();
            //    objRegPedidoEdit.pOperacion = frmRegAuditoriaPedidoEdit.Operacion.Modificar;
            //    objRegPedidoEdit.IdPedido = objPedido.IdPedido;
            //    objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
            //    objRegPedidoEdit.btnGrabar.Enabled = true;
            //    objRegPedidoEdit.ShowDialog();

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

            if (gvPedido.GetFocusedRowCellValue("IdPedido").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoControlServicios";
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

        private void armadoterminadotoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gvPedido_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvPedido.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvPedido.GetRowCellValue(i, (gvPedido.Columns["ValorVenta"])));
                }
                txtTotal.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}