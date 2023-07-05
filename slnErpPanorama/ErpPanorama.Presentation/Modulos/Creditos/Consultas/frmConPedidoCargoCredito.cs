using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;


namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConPedidoCargoCredito : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();

        #endregion

        #region "Eventos"

        public frmConPedidoCargoCredito()
        {
            InitializeComponent();
        }

        private void frmConPedidoCargoCredito_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            //Cargar();
        }

        //private void tlbMenu_NewClick()
        //{
        //    try
        //    {
        //        frmRegCotizacionEdit objManCotizacion = new frmRegCotizacionEdit();
        //        objManCotizacion.pOperacion = frmRegCotizacionEdit.Operacion.Nuevo;
        //        //objManCotizacion.lstCotizacion = mLista;
        //        objManCotizacion.IdCotizacion = 0;
        //        objManCotizacion.StartPosition = FormStartPosition.CenterParent;
        //        objManCotizacion.ShowDialog();
        //        Cargar();
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        //private void tlbMenu_DeleteClick()
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            if (!ValidarIngreso())
        //            {
        //                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
        //                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
        //                frmAutoriza.ShowDialog();

        //                if (frmAutoriza.Edita)
        //                {
        //                    if (frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "master")
        //                    {
        //                        CotizacionBE objE_Cotizacion = new CotizacionBE();
        //                        objE_Cotizacion.IdCotizacion = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdCotizacion").ToString());
        //                        objE_Cotizacion.IdPedido = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdPedido").ToString());
        //                        objE_Cotizacion.Usuario = Parametros.strUsuarioLogin;
        //                        objE_Cotizacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //                        objE_Cotizacion.IdEmpresa = Parametros.intEmpresaId;

        //                        CotizacionBL objBL_Cotizacion = new CotizacionBL();
        //                        objBL_Cotizacion.Elimina(objE_Cotizacion);
        //                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        Cargar();
        //                    }
        //                    else
        //                    {
        //                        XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    }
        //                }
        //            }
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor = Cursors.Default;
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void tlbMenu_RefreshClick()
        //{
        //    Cargar();
        //}

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (gvCotizacion.RowCount > 0)
                {
                    int IdEstadoCuenta = 0;
                    IdEstadoCuenta = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdEstadoCuenta").ToString());

                    List<ReportePedidoCargoCreditoBE> lstReporte = null;
                    lstReporte = new ReportePedidoCargoCreditoBL().Listado(Parametros.intEmpresaId, IdEstadoCuenta);

                    if (lstReporte != null)
                    {
                        //Listar el datalle del reporte
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptAccUsu = new RptVistaReportes();
                            objRptAccUsu.VerRptPedidoCargoCredito(lstReporte, lstReporte);
                            objRptAccUsu.ShowDialog();
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedidoCargoCredito";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCotizacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCotizacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaPedido();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PedidoBL().ListaFechaEstadoCuenta(Parametros.intEmpresaId, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcCotizacion.DataSource = mLista;
        }

        //private void CargarBusqueda()
        //{
        //    mLista = new PedidoBL().ListaNumero(deDesde.DateTime.Year, txtNumeroCotizacion.Text);
        //    gcCotizacion.DataSource = mLista;
        //}

        private void CargarBusquedaPedido()
        {
            mLista = new PedidoBL().ListaFechaEstadoCuentaPedido(deDesde.DateTime.Year, txtNumeroPedido.Text);
            gcCotizacion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCotizacion.RowCount > 0)
            {
                frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
                frm.IdPedido = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdPedido").ToString());
                frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
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

            if (gvCotizacion.GetFocusedRowCellValue("IdEstadoCuenta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void ImprimirDespachoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteMovimientoPedidoBE> lstReporte = null;
                lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvCotizacion.GetFocusedRowCellValue("IdPedido").ToString()));



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
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void despachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }


    }
}