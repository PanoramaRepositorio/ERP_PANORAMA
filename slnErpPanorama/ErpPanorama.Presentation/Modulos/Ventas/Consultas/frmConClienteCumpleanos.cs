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
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConClienteCumpleanos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteClienteCumpleanosBE> mListaClienteCumpleanos = new List<ReporteClienteCumpleanosBE>();
        int IdCliente = 0;

        #endregion

        #region "Eventos"
        public frmConClienteCumpleanos()
        {
            InitializeComponent();
        }

        private void frmConClienteCumpleanos_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("No disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void gvClienteCumpleanos_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvClienteCumpleanos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvClienteCumpleanos.RowCount > 0)
            {
                DataRow dr;
                int IdCliente = 0;
                dr = gvClienteCumpleanos.GetDataRow(e.RowHandle);
                IdCliente = int.Parse(dr["IdCliente"].ToString());
            }
        }

        private void VerDatostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarConsultar();
            {
                if (gvClienteCumpleanos.RowCount > 0)
                {
                    ClienteBE objClientel = new ClienteBE();
                    objClientel.IdCliente = int.Parse(gvClienteCumpleanos.GetFocusedRowCellValue("IdCliente").ToString());

                    frmManClienteMayoristaEdit objManClientelEdit = new frmManClienteMayoristaEdit();
                    objManClientelEdit.pOperacion = frmManClienteMayoristaEdit.Operacion.Modificar;
                    objManClientelEdit.IdCliente = objClientel.IdCliente;
                    objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                    objManClientelEdit.btnGrabar.Enabled = false;
                    objManClientelEdit.ShowDialog();

                    CargarBusqueda();
                }

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mListaClienteCumpleanos = new ReporteClienteCumpleanosBL().Listado(deDesde.DateTime, deHasta.DateTime,87);
            gcClienteCumpleanos.DataSource = mListaClienteCumpleanos;
        }

        private void CargarBusqueda()
        {
            DataTable dtClienteBus = new DataTable();
            dtClienteBus = FuncionBase.ToDataTable(mListaClienteCumpleanos.Where(obj => obj.DescCliente.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList());
            gcClienteCumpleanos.DataSource = dtClienteBus;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarConsultar();
            }
        }

        public void InicializarConsultar()
        {
            if (gvClienteCumpleanos.RowCount > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = int.Parse(gvClienteCumpleanos.GetFocusedRowCellValue("IdCliente").ToString());

                frmManClienteMayoristaEdit objManClientelEdit = new frmManClienteMayoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMayoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientelEdit.btnGrabar.Enabled = false;
                objManClientelEdit.ShowDialog();

                CargarBusqueda();
            }

        }

        #endregion

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteCumpleanos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvClienteCumpleanos.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }



    }
}