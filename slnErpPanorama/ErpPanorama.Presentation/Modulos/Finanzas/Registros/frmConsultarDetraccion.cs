using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraGrid.Columns;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmConsultarDetraccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<CuentaPorPagarBE> mLista2 = new List<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList2 = new BindingList<CuentaPorPagarBE>();
        #endregion

        #region "Eventos"
        public frmConsultarDetraccion()
        {
            InitializeComponent();
        }

        private void frmConsultarDetraccion_Load(object sender, EventArgs e)
        {
            this.Text = "Consultar Lote de Detracciones";
            txtLote.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String pIndiceBloque = txtLote.Text; 

            if (pIndiceBloque == "" || pIndiceBloque == null)
            {
                XtraMessageBox.Show("Ingrese lote de detraccion correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLote.Focus();
                gridControl1.DataSource = null;
            }
            else
            {
                CargarLote(pIndiceBloque);
                AplicarSumatoria();
            }
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConsultar.Focus();
            }
        }
        #endregion

        #region "Metodos"
        private void CargarLote(String pIndiceBloque)
        {
            //mLista2 = new CuentaPorPagarBL().ListaPorSituacionBloque(404, pIndiceBloque);
            mLista2 = new CuentaPorPagarBL().ListaPorBloque(pIndiceBloque);
            supList2 = new BindingList<CuentaPorPagarBE>(mLista2);

            if (supList2.Count == 0)
            {
                XtraMessageBox.Show("No hay detracciones en el lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                gridControl1.DataSource = supList2;
            }
        }

        private void AplicarSumatoria()
        {
            foreach (GridColumn column in gridView1.Columns)
            {
                DevExpress.XtraGrid.GridSummaryItem item = column.SummaryItem;
                if (item != null)
                    column.Summary.Remove(item);
            }

            DevExpress.XtraGrid.GridColumnSummaryItem item1 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoAbono", "{0}");
            gridView1.Columns[8].Summary.Add(item1);
        }
        #endregion
    }
}