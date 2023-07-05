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
    public partial class frmConstultaHistorial : DevExpress.XtraEditors.XtraForm
    {

        public int IdPersona = 0;
        public int valor=0;
        public frmConstultaHistorial()
        {
            InitializeComponent();
        }

        private void frmConstultaHistorial_Load(object sender, EventArgs e)
        {
            ConsultaHistorialBE obj1 = new ConsultaHistorialBE();
            valor = IdPersona;

            ConsultaHistorialBE obj2 = new ConsultaHistorialBE();
            ConsultaHistorialBL obj3 = new ConsultaHistorialBL();
            obj2.IdPersona = valor;

            this.gcConsulta2.DataSource = obj3.ListaTodosActivo(obj2.IdPersona);
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Historial Fechas de Trabajo";
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

        }

        private void aprobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = IdPersona;
           String fecha_ini = this.gvConsulta.GetFocusedRowCellValue("FechaIngreso").ToString();
           String fecha_fin = this.gvConsulta.GetFocusedRowCellValue("FechaCese").ToString();


           EliminaHistorialBL objbl = new EliminaHistorialBL();
           EliminarHistorialBE objbe = new EliminarHistorialBE();
           objbe.Id = id;
           objbe.FechaInicio = fecha_ini.Substring (0,10);
           objbe.FechaFin = fecha_fin.Substring(0,10);
           objbl.Elimina(objbe);

           ConsultaHistorialBE obj1 = new ConsultaHistorialBE();
           valor = IdPersona;

           ConsultaHistorialBE obj2 = new ConsultaHistorialBE();
           ConsultaHistorialBL obj3 = new ConsultaHistorialBL();
           obj2.IdPersona = valor;

           this.gcConsulta2.DataSource = obj3.ListaTodosActivo(obj2.IdPersona);

        }

        private void mnuContextual_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolstpExportarExcel_Click_1(object sender, EventArgs e)
        {

        }
    }
}