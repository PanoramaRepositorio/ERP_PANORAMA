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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConsultaMarcacionGeneral : DevExpress.XtraEditors.XtraForm
    {
        public int tipo = 0;
        public int op = 0;
        public string dni, nombre, fechaini, fechafin;

        MarcacionesGeneralBE obj = new MarcacionesGeneralBE();
        MarcacionesGeneralBL obj1 = new MarcacionesGeneralBL();

        public frmConsultaMarcacionGeneral()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 1;
            //this.textEdit1.Text = "";
            //this.TxFechaDesde.Text = "";
            //this.TxFechaHasta.Text = "";
            //this.comboBox1.Text = "";
            //this.dateEdit1.Text = "";
            //this.dateEdit2.Text = "";
            //this.textEdit1.Text = "";
            //this.textEdit2.Text = "";
            //this.radioButton4.Checked = false;
            //this.radioButton5.Checked = false; 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 3;
           
            //this.TxFechaDesde.Text = "";
            //this.TxFechaHasta.Text = "";
            //this.comboBox1.Text = "";
            //this.dateEdit1.Text = "";
            //this.dateEdit2.Text = "";
            //this.textEdit1.Text = "";
            //this.textEdit2.Text = "";
            //this.radioButton1.Checked = false;
            //this.radioButton4.Checked = false;
            //this.radioButton5.Checked = false;
            //valor();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 2;
        //    this.radioButton3.Checked = false;;
           
        //    this.textEdit1.Text = "";
        //    this.comboBox1.Text = "";
        //    this.dateEdit1.Text = "";
        //    this.dateEdit2.Text = "";
        //    this.textEdit1.Text = "";
        //this.textEdit2.Text = "";
        //    this.radioButton4.Checked = false;
        //    this.radioButton5.Checked = false;
        //    valor();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (tipo == 2)
                {
                    op = 2;
                

                    String fecha3;
                    fecha3 = this.TxFechaDesde.Text;
                    fecha3 = fecha3.Substring(0, 10);
                  


                    String fecha4;
                    fecha4 = this.TxFechaHasta.Text;
                    fecha4 = fecha4.Substring(0, 10);
                  
                   // obj.Fecha2 = this.TxFechaHasta.Text;

                    this.gcConsulta.DataSource = obj1.ListaTodos(op, "", "", fecha3, fecha4, 0);
                }


                if (tipo == 3)
                {
                    op = 3;

                    String nom = this.textEdit1.Text;


                    String fecha1;
                    fecha1 = this.dateEdit3 .Text;
                    fecha1 = fecha1.Substring(0, 10);
                 


                    String fecha2;
                    fecha2 = this.dateEdit4 .Text;
                    fecha2 = fecha2.Substring(0, 10);
                  

                    this.gcConsulta.DataSource = obj1.ListaTodos(op, "", nom, fecha1, fecha2,0);
                }


                if (tipo == 4)
                {
                    op = 4;
                    int codigo;
                    codigo=Convert.ToInt32(this.comboBox1.SelectedValue.ToString())  ;

                    String fecha1;
                    fecha1 = this.dateEdit5.Text;
                    fecha1 = fecha1.Substring(0, 10);



                    String fecha2;
                    fecha2 = this.dateEdit6.Text;
                    fecha2 = fecha2.Substring(0, 10);

                    this.gcConsulta.DataSource = obj1.ListaTodos(op, "", "", fecha1 ,fecha2, codigo);

                }


                if (tipo == 5)
                {
                    op = 5;

                    String fecha1;
                    fecha1 = this.dateEdit1 .Text;
                    fecha1 = fecha1.Substring(0, 10);
                    obj.Fecha1 = fecha1;


                    String fecha2;
                    fecha2 = this.dateEdit2.Text;
                    fecha2 = fecha2.Substring(0, 10);
                    obj.Fecha2 = fecha2;
                    

                    obj.dni = textEdit2.Text;

                    this.gcConsulta.DataSource = obj1.ListaTodos(op, obj.dni , "", fecha2, fecha1, 0);

                }



            }
            catch (Exception e77)
            {
                MessageBox.Show(e77.ToString());
            }

        }



        private void toolstpExportarExcel_Click_1(object sender, EventArgs e)
        {

            try
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoMarcacionesGeneral";
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
            catch (Exception e10) {
                MessageBox.Show(e10.ToString()); 
            }

        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void frmConsultaMarcacionGeneral_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = obj1.Listacombo();
            this.comboBox1.DisplayMember = "DescArea";
            this.comboBox1.ValueMember = "idarea";

            TxFechaDesde.EditValue = DateTime.Now;
            TxFechaHasta.EditValue = DateTime.Now;
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            tipo = 4;
            //this.radioButton1.Checked = false;
            
            //this.radioButton3.Checked = false;
            //this.radioButton5.Checked = false; 
           
            //this.textEdit1.Text = "";
            //this.TxFechaDesde.Text = "";
            //this.TxFechaHasta.Text = "";
            //this.dateEdit1.Text = "";
            //this.dateEdit2.Text = "";
            //this.textEdit1.Text = "";
            //this.textEdit2.Text = "";
            //valor();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            tipo = 5;
            //this.radioButton1.Checked = false;
          
            //this.radioButton3.Checked = false;
            //this.radioButton4.Checked = false;
           
            //this.textEdit1.Text = "";
            //this.TxFechaDesde.Text = "";
            //this.TxFechaHasta.Text = "";
            //valor();
          
        }

        private void valor()
        {
            //this.TxFechaDesde.Text = "";
            //this.TxFechaHasta.Text = "";
            //this.dateEdit3.Text = "";
            //this.dateEdit2.Text = "";
            //this.dateEdit4.Text = "";
            //this.dateEdit5.Text = "";
            //this.dateEdit6.Text = "";
            //this.comboBox1.Text = "";
            //this.dateEdit1.Text = "";

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH)
            {
                if (Convert.ToInt32(keyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.NumPad5))// + Convert.ToInt32(Keys.O))
                {
                    frmRegAsistenciaFecha frm = new frmRegAsistenciaFecha();
                    frm.Show();
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}