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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Consultas
{
    public partial class frmPrestamoBancoPagos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<PrestamoBancoBE> mLista = new List<PrestamoBancoBE>();
        List<PrestamoBancoDetalleBE> mListaDetalle = new List<PrestamoBancoDetalleBE>();

        #endregion


        #region "Eventos"
        public frmPrestamoBancoPagos()
        {
            InitializeComponent();
        }

        private void frmPrestamoBancoPagos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            //tlbMenu.Ensamblado = this.Tag.ToString();

            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = 0;

            Cargar();
        }


        #endregion

        #region "Métodos"
        private void Cargar()
        {

            mLista = new PrestamoBancoBL().ListaTodosActivoPagos(Convert.ToInt32(cboMoneda.EditValue));
            gcPrestamoBanco.DataSource = mLista;
        }


        #endregion

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            cboMoneda.EditValue = 0;
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPrestamoBancosPagos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPrestamoBanco.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }
    }
}