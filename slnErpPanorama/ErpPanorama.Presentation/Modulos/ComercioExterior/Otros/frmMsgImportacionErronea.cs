using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Otros
{
    public partial class frmMsgImportacionErronea : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PreventaDetalleBE> mLista = new List<PreventaDetalleBE>();

        #endregion

        #region "Eventos"

        public frmMsgImportacionErronea()
        {
            InitializeComponent();
        }

        private void frmMsgImportacionErronea_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se generó el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoErroresPreventa_" + Parametros.strUsuarioLogin;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            //mLista = new AgenciaBL().ListaTodosActivo();
            gcProducto.DataSource = mLista;
            lblRegistros.Text = mLista.Count.ToString() + " Registros";
        }

        #endregion


    }
}