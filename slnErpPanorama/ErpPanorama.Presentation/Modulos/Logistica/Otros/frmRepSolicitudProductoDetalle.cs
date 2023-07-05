using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic.Reportes;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRepSolicitudProductoDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteSolicitudProductoDetalleBE> mLista = new List<ReporteSolicitudProductoDetalleBE>();

        #endregion

        #region "Eventos"
        public frmRepSolicitudProductoDetalle()
        {
            InitializeComponent();
        }

        private void frmRepSolicitudProductoDetalle_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoSolicitudDetalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvReporte.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
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
        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new ReporteSolicitudProductoDetalleBL().Listado(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime);
            gcReporte.DataSource = mLista;
        }
        #endregion


    }
}