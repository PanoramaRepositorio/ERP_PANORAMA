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
using ErpPanorama.Presentation.Modulos.Creditos.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegGestionPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();
        
        #endregion

        #region "Eventos"

        public frmRegGestionPedido()
        {
            InitializeComponent();
        }

        private void frmRegGestionPedido_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPedidoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intFacturado;

            txtPeriodo.EditValue = DateTime.Now.Year;
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

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void aprobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    frmRegAprobacionPedidoEdit objManBanco = new frmRegAprobacionPedidoEdit();
                    objManBanco.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    objManBanco.StartPosition = FormStartPosition.CenterParent;
                    objManBanco.ShowDialog();
                    Cargar();
                    CargarDetalles(0);
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
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaSituacion(deDesde.DateTime, deHasta.DateTime, Convert.ToInt32(cboSituacion.EditValue));
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
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
                //InicializarModificar();
            }
        }

        #endregion

        private void despachadortoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}