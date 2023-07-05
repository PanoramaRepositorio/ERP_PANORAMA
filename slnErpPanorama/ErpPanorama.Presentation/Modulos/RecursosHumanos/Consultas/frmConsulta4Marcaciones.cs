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
    public partial class frmConsulta4Marcaciones : DevExpress.XtraEditors.XtraForm
    {
        public frmConsulta4Marcaciones()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            try
            {
                Marcaciones4BE obj = new Marcaciones4BE();
                Marcaciones4BL obj1 = new Marcaciones4BL();
                obj.Fecha1 = this.TxFechaDesde.Text;



                String fecha1;
                fecha1 = this.TxFechaDesde.Text;
                fecha1 = fecha1.Substring(0, 10);
                obj.Fecha1 = fecha1;





                this.gcConsulta.DataSource = obj1.ListaTodos(obj.Fecha1);
            }
            catch (Exception t78) { MessageBox.Show(t78.ToString()); }
        }
        private void frmConsulta4Marcaciones_Load(object sender, EventArgs e)
        {
          

        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoMarcacionTotalPersonal";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    gvConsulta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                }
            }catch(Exception e34){
                MessageBox.Show(e34.ToString()); 
            }
        }
    }
}