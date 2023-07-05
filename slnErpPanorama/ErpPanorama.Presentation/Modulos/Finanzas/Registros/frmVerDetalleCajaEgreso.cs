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

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmVerDetalleCajaEgreso : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<CajaEgresoDetalleDocumentosBE> mLista = new List<CajaEgresoDetalleDocumentosBE>();
        public int vIdCajaEgresos = 0;
        public string vEmpresa = "";
        public string vCaja = "";
        #endregion

        #region "Eventos"

        public frmVerDetalleCajaEgreso()
        {
            InitializeComponent();
        }

        private void frmVerDetalleCajaEgreso_Load(object sender, EventArgs e)
        {
            //deDesde.EditValue = DateTime.Now;
            //deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = vEmpresa + "_" +vCaja;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDetalleDocsCaja.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
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
            mLista = new CajaEgresoDetalleDocumentosBL().ListaTodosActivoDocumentos(vIdCajaEgresos);
            gcDetalleDocsCaja.DataSource = mLista;
        }
        #endregion


    }
}