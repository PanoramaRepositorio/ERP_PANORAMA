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

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmMsgImportacionErronea : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InventarioBE> mLista = new List<InventarioBE>();

        public string Titulo = "Codigo Erróneos (VERIFICAR)";
        public string NombreArchivoExcel = "ListadoErroresInventario_";

        #endregion

        #region "Eventos"

        public frmMsgImportacionErronea()
        {
            InitializeComponent();
        }

        private void frmMsgImportacionErronea_Load(object sender, EventArgs e)
        {
            this.Text = Titulo;
            Cargar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se generó el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName ="ListadoErroresInventario_" + Parametros.strUsuarioLogin;;
            if(NombreArchivoExcel == "ListadoErroresInventario_")
                _fileName = "ListadoErroresInventario_" + Parametros.strUsuarioLogin;
            else
                _fileName = NombreArchivoExcel +"_"+ Parametros.strUsuarioLogin;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventario.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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
            gcInventario.DataSource = mLista;
            lblRegistros.Text = mLista.Count.ToString() + " Registros";
        }

        #endregion


    }
}