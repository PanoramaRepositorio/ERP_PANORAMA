using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.Threading;
using System.Globalization;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmAsistenciaImportacionManual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        

        ////Instancia de la clase Leer
        //Leer l = new Leer();
        public string Archivo = "";

        #endregion

        #region "Eventos"
        public frmAsistenciaImportacionManual()
        {
            InitializeComponent();
        }

        private void frmAsistenciaImportacionManual_Load(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                    {
                        Archivo = this.openFileDialog1.FileName;
                        lecturaArchivo(dgMarcacion, '	', Archivo);
                        dgMarcacion.Columns[7].Width = 150;
                        lblTotalRegistros.Text = dgMarcacion.RowCount.ToString() + " Registros";
                        txtRuta.Text = Archivo;
                        //l.lecturaArchivo(dataGridView1, '	', ARCHIVO);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            

            List<CheckinoutBE> mListaCheckinout = new List<CheckinoutBE>();



            foreach (DataGridViewRow row in dgMarcacion.Rows)
            {
                // Sets the CurrentCulture property to U.S. English. by Date Format
                string FechaMarca = "";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                FechaMarca = Convert.ToDateTime(row.Cells[7].Value.ToString()).ToString("dd/MM/yyyy HH:mm:ss");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                CheckinoutBE objMarca = new CheckinoutBE();
                objMarca.IdCheckinout = 0;
                objMarca.IdEmpresa = Parametros.intEmpresaId;
                objMarca.Dni = row.Cells[2].Value.ToString();
                objMarca.Fecha = Convert.ToDateTime(FechaMarca);
                objMarca.Tipo = "I";
                objMarca.FlagEstado = true;
                mListaCheckinout.Add(objMarca);
            }

            CheckinoutBL objBL_Checkinout = new CheckinoutBL();
            objBL_Checkinout.Inserta(mListaCheckinout);

            XtraMessageBox.Show("La sincronización se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Crear Clase
        public void lecturaArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            string sLine = "";
            int fila = 0;
            tabla.Rows.Clear();
            tabla.AllowUserToAddRows = false;

            do
            {
                sLine = objReader.ReadLine();
                if ((sLine != null))
                {
                    if (fila == 0)
                    {
                        tabla.ColumnCount = sLine.Split(caracter).Length;
                        nombrarTitulo(tabla, sLine.Split(caracter));
                        fila += 1;
                    }
                    else
                    {
                        agregarFilaDatagridview(tabla, sLine, caracter);
                        fila += 1;
                    }

                }
            }

            while (!(sLine == null));
            objReader.Close();
        }

        //Agregar el HeaderText al datagridview(SON LOS TITULOS)'
        public static void nombrarTitulo(DataGridView tabla, string[] titulos)
        {
            int x = 0;
            for (x = 0; x <= tabla.ColumnCount - 1; x++)
            {
                tabla.Columns[x].HeaderText = titulos[x];
            }
        }

        //Agrega una fila por cada linea de Bloc de notas :D'
        public static void agregarFilaDatagridview(DataGridView tabla, string linea, char caracter)
        {
            string[] arreglo = linea.Split(caracter);
            tabla.Rows.Add(arreglo);
        }
        #endregion

    }
}