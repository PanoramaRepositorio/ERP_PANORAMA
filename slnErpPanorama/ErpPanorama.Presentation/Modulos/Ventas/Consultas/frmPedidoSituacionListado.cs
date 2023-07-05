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
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmPedidoSituacionListado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PedidoBE> mLista = new List<PedidoBE>();


        #endregion

        #region "Eventos"

        public frmPedidoSituacionListado()
        {
            InitializeComponent();
        }

        private void frmPedidoSituacionListado_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPedidoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intFacturado;

            txtPeriodo.EditValue = DateTime.Now.Year;
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //FilaDoubleClick(view, pt);

            asignapersonatoolStripMenuItem1_Click(sender, e);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboSituacion.Text.Trim() == "")
            {
                XtraMessageBox.Show("Debe seleccionar una situación del pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSituacion.Focus();
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
                CargarDetalles(IdPedido);
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void asignapersonatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerCoordinadorDespacho|| Parametros.strUsuarioLogin=="aguiller" || Parametros.strUsuarioLogin == "avilchez")
            {
                int IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intPVAnulado)
                {
                    XtraMessageBox.Show("No se puede despachar el pedido está anulado.");
                    return;
                }

                frmRegAsignarDespachadorPedido frm = new frmRegAsignarDespachadorPedido();
                frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                Cargar();
            }
            else
            {
                XtraMessageBox.Show("UD. no cuenta con permisos para realizar esta operación \nSólo puede ser asignado por el usuario de Despacho.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "vvillano" || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen /*|| Parametros.intPerfilId == Parametros.intPerSupervisorAlmacen*/)
            {
                Imprimir();
            }
            else
            {
                XtraMessageBox.Show("UD. no cuenta con permisos para realizar esta operación \nSólo puede ser asignado por el usuario de Despacho.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaSituacion2(deDesde.DateTime, deHasta.DateTime, Convert.ToInt32(cboSituacion.EditValue));
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
            lblTotalRegistros.Text = gvPedido.RowCount.ToString() + " Registros";
        }

        private void CargarBusqueda()
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
                //gcPedidoDetalle.DataSource = dtDetalle;


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
                //InicializarModificar();
            }
        }

        private void Imprimir()
        {
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







        #endregion

        private void gvPedidoDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            
        }

        private void gvPedido_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvPedido.RowCount.ToString() +  " Registros";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}