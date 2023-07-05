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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    public partial class frmConVentasEmpresaFecha : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        #endregion

        #region "Eventos"
        public frmConVentasEmpresaFecha()
        {
            InitializeComponent();
        }

        private void frmConVentasEmpresaFecha_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            txtTopeDiario.EditValue = Parametros.dmlTopeEmpresaDiarioRUS;
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListVentasEmpresaFecha";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            gcDocumento.DataSource = new DocumentoVentaBL().ListaEmpresaFecha(Parametros.intRegimenTributarioRUS, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()));
            gcDocumento.RefreshDataSource();
        }


        #endregion

    }
}