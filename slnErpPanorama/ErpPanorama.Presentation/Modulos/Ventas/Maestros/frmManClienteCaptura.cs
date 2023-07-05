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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteCaptura : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ClienteEncuestaBE> mLista = new List<ClienteEncuestaBE>();

        #endregion

        #region "Eventos"
        public frmManClienteCaptura()
        {
            InitializeComponent();
        }

        private void frmManClienteCaptura_Load(object sender, EventArgs e)
        {
            deDesde.DateTime = DateTime.Now;
            deHasta.DateTime = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteEncuesta";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCliente.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ClienteEncuestaBL().ListaFecha(0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcCliente.DataSource = mLista;
            lblTotalRegistros.Text = gvCliente.RowCount.ToString() + " Registros";
        }

        #endregion


    }
}