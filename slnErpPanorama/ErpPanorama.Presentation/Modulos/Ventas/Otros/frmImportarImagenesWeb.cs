using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmImportarImagenesWeb : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        string[] files;
        string[] filesRaiz;

        public bool HangTag { get; set; }
        private string NombreImagen = "";

        #endregion

        #region "Eventos"

        public frmImportarImagenesWeb()
        {
            InitializeComponent();
        }

        private void frmImportarImagenesWeb_Load(object sender, EventArgs e)
        {

        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.Description = "Seleccionar una carpeta: ";
            d.ShowNewFolderButton = false;
            if (d.ShowDialog() == DialogResult.OK)
            {
                dgImg.Rows.Clear();
                string[] directories = Directory.GetDirectories(d.SelectedPath);
                foreach (string d2 in directories)
                {
                    files = Directory.GetFiles(d2, "*.jpg");
                    foreach (string s in files)
                    {

                        #region "Ruta Corta"
                            string RutaCarpeta = "";
                            string NombreArchivo = "";
                        
                            if (chkRutaCorta.Checked == true)
                            {
                                NombreArchivo = FileName(s);
                                if(NombreArchivo.Contains("_"))
                                {
                                    RutaCarpeta = NombreArchivo.Replace(NombreArchivo.Substring(NombreArchivo.LastIndexOf('.') - 2), "") + "/" + NombreArchivo;
                                }
                            }
                            else
                            {
                                RutaCarpeta = s;
                            }
                        #endregion

                        dgImg.Rows.Add(Properties.Resources.noImage, FileName(s), RutaCarpeta);
                        //dgImg.Rows.Add(Properties.Resources.noImage, FileName(s), s);
                        
                    }
                    txtDirectorio.Text = d2;
                }

                //Raiz
                filesRaiz = Directory.GetFiles(d.SelectedPath, "*.jpg");
                foreach (string s in filesRaiz)
                { 
                    #region "Ruta Corta"
                    string RutaCarpeta = "";
                    string NombreArchivo = "";

                    if (chkRutaCorta.Checked == true)
                    {
                        NombreArchivo = FileName(s);
                        if (NombreArchivo.Contains("_"))
                        {
                            RutaCarpeta = NombreArchivo.Replace(NombreArchivo.Substring(NombreArchivo.LastIndexOf('.') - 2), "") + "/" + NombreArchivo;
                        }
                    }
                    else
                    {
                        RutaCarpeta = s;
                    }
                    #endregion

                    dgImg.Rows.Add(Properties.Resources.noImage, FileName(s), RutaCarpeta); 
                    //dgImg.Rows.Add(Properties.Resources.noImage, FileName(s), s); 

                }
                txtDirectorio.Text = d.SelectedPath;
            }



        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (dgImg.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se han Seleccionado Imágenes. Verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //string max = "260";
            //if (dgImg.SelectedRows.Count > Convert.ToInt32(max))
            //{
            //    MessageBox.Show("El Máximo de Imágenes Actualizables es " + max + ". Verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            if (MessageBox.Show("¿ Desea Actualizar las Imágenes Seleccionadas? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FileInfo fi;
                Decimal mxKb = Convert.ToDecimal(16000);
                Decimal acKb;
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    string fileName;
                    string fileRuta;
                    foreach (DataGridViewRow r in dgImg.SelectedRows)
                    {
                        fileName = r.Cells[1].Value.ToString();
                        fileRuta = r.Cells[2].Value.ToString();
                        //fi = new FileInfo(txtDirectorio.Text + "\\" + fileName);
                        //acKb = Convert.ToDecimal(fi.Length) / 1024;
                        //if (fi.Length > (mxKb * 1024))
                        //{
                        //    XtraMessageBox.Show(fileName + " Tamaño Máximo: " + mxKb.ToString() + " Kb. Tamaño Actual: " + acKb.ToString("###,##0.00") + " Kb.", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //}
                        //else
                        //{
                            //imgFot.Image = Image.FromFile(txtDirectorio.Text + "\\" + fileName);
                            ProductoFotoBE objE_ProductoFoto = new ProductoFotoBE();
                            NombreImagen = fileRuta;
                            objE_ProductoFoto.IdProducto = Convert.ToInt32(fileName.Replace(fileName.Substring(fileName.LastIndexOf('.') - 2), ""));

                                if (fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "").Substring(Convert.ToInt32(fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "").Length -1), 1).ToUpper() == "F") //Frontal
                                {
                                    objE_ProductoFoto.Frontal = fileRuta;
                                }
                                if (fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "").Substring(Convert.ToInt32(fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "").Length - 1), 1).ToUpper() == "L") //Lateral
                                {
                                    objE_ProductoFoto.Lateral = fileRuta;
                                }
                                if (fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "").Substring(Convert.ToInt32(fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "").Length - 1), 1).ToUpper() == "T") //Trasera
                                {
                                    objE_ProductoFoto.Trasera = fileRuta;
                                }
                                objE_ProductoFoto.FlagEstado = true;


                                ProductoFotoBL objBL_ProductoFoto = new ProductoFotoBL();
                                objBL_ProductoFoto.ActualizaVarios(objE_ProductoFoto);

                        //}
                    }

                    XtraMessageBox.Show("La importación se generó correctamente", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message + " " + NombreImagen, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "Metodos"

        public static string FileName(string fullPath)
        {
            if (fullPath != null)
            {
                int pos = fullPath.LastIndexOf(@"\");

                if (pos > 0)
                {
                    return fullPath.Substring(pos + 1);
                }
            }
            return fullPath;
        }



        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}