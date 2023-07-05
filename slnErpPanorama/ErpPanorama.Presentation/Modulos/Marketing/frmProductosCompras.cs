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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Marketing.Consultas
{
    public partial class frmProductosCompras : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<ConsultasMarketingBE> mLista = new List<ConsultasMarketingBE>();
        #endregion
        #region "Eventos"
        public frmProductosCompras()
        {
            InitializeComponent();
        }

        private void frmProductosCompras_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ProductosCompras";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProductosCompras.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        #endregion

        #region "Metodos"
        private void Cargar()
        {
            mLista = new ConsultasMarketingBL().ProductosCompras(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcPorductosCompras.DataSource = mLista;
            lblTotalRegistros.Text = gvProductosCompras.RowCount.ToString() + " Registros";
        }


        #endregion
    }
}