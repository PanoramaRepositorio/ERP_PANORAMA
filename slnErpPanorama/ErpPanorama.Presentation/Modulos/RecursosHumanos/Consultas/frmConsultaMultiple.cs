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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas  ;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConsultaMultiple : DevExpress.XtraEditors.XtraForm
    {

        public int conta = 0;
        private List<RecursosBE> mLista = new List<RecursosBE>();

        public frmConsultaMultiple()
        {
            InitializeComponent();
        }

        private void frmConsultaMultiple_Load(object sender, EventArgs e)
        {
           // Cargar();

        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {


            TempoBE obj3=new TempoBE(); 
            TempoBL obj4=new TempoBL();
            RecursosBE obj = new RecursosBE();
            RecursosBL obj1 = new RecursosBL();
           // List<ListaBE> Lista2 = new List<ListaBE>();

            obj4.Elimina();

            obj.Dni = txDni.Text.ToString();
            obj.FechaDesde = Convert.ToDateTime(TxFechaDesde.Text);
            obj.FechaHasta = Convert.ToDateTime(TxFechaHasta.Text);

            //this.gridControl1.DataSource   = obj1.Listado(obj.FechaIngreso,obj.FechaSalida,obj.Dni);
            DateTime oldDate = Convert.ToDateTime(TxFechaDesde.Text);
            DateTime newDate = Convert.ToDateTime(TxFechaHasta.Text);

            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;


            // Difference in days.
            int differenceInDays = ts.Days;
            int numero = 0;

            try
            {
                List<RecursosBE> lista = new List<RecursosBE>();

                if (this.listBox1.Items.Count > 0)
                {
                   
                    for (int i = 0; i < this.listBox1.Items.Count; i++)
                    {

                        lista = obj1.Listado(Convert.ToDateTime(TxFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(TxFechaHasta.DateTime.ToShortDateString()), this.listBox1.Items[i].ToString().Trim());

                        ListtoDataTableConverter converter = new ListtoDataTableConverter();

                        DataTable dt = converter.ToDataTable(lista);
                        numero = dt.Rows.Count ; 
                        for (int j = 0; j < numero; j++)
                        {

                            obj3.Dni = dt.Rows[j][0].ToString();
                            obj3.ApeNom   = dt.Rows[j][1].ToString();
                            obj3.Fecha = Convert.ToDateTime(dt.Rows[j][2].ToString());
                            obj3.FechaDesde  = Convert.ToString(dt.Rows[j][3]);
                            obj3.FechaHasta = Convert.ToString(dt.Rows[j][4]);
                            obj3.TiempoTrabajado = Convert.ToString(dt.Rows[j][5]);
                          
                            obj4.Inserta(obj3);
                        }
                    }


                    this.gcConsulta.DataSource = obj4.Listar();



                }
                else
                {
                    this.gcConsulta.DataSource = obj1.Listado(Convert.ToDateTime(TxFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(TxFechaHasta.DateTime.ToShortDateString()), txDni.Text);
                }
                listBox1.Items.Clear();
            }

            catch (Exception ex1)
            {
                MessageBox.Show(Convert.ToString (ex1));
            }
        }

        public class ListtoDataTableConverter
        {

            public DataTable ToDataTable<T>(List<T> items)
            {

                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties

                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in Props)
                {

                    //Setting column names as Property names

                    dataTable.Columns.Add(prop.Name);

                }

                foreach (T item in items)
                {

                    var values = new object[Props.Length];

                    for (int i = 0; i < Props.Length; i++)
                    {

                        //inserting property values to datatable rows

                        values[i] = Props[i].GetValue(item, null);

                    }

                    dataTable.Rows.Add(values);

                }

                //put a breakpoint here and check datatable

                return dataTable;

            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           
         

      
        }



        private void simpleButton3_Click_1(object sender, EventArgs e)
        {

        }

   

        private void Cargar()
        {
            bsListado.DataSource = mLista;
            gcConsulta.DataSource = bsListado;
            gcConsulta.RefreshDataSource();        
        }

        private void txDni_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                this.listBox1.Items.Add(this.txDni.Text.ToString());
                this.txDni.Text = "";
                this.txDni.Focus();
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMarcacion";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvConsulta .ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {

        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
    
    }
