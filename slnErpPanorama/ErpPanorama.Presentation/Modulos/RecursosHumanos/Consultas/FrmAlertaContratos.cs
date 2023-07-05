using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class FrmAlertaContratos : DevExpress.XtraEditors.XtraForm
    {

        public FrmAlertaContratos()
        {
            InitializeComponent();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Alerta de Contratos Vencidos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                this.gridControl1 .ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }

        private void FrmAlertaContratos_Load(object sender, EventArgs e)
        {
            AlertaContratoBE obj = new AlertaContratoBE();
            AlertaContratoBL obj1 = new AlertaContratoBL();
            this.gridControl1.DataSource = obj1.ListaContratos();
            lblTotalRegistros.Text = gridView1.RowCount.ToString() + " Registros";
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}