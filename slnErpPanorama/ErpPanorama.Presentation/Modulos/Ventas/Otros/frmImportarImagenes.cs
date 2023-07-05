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
    public partial class frmImportarImagenes : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        string[] files;

        public bool HangTag { get; set; }

        #endregion

        #region "Eventos"

        public frmImportarImagenes()
        {
            InitializeComponent();
        }

        private void frmImportarImagenes_Load(object sender, EventArgs e)
        {
            if(HangTag == true )
            this.Text = this.Text + " por HANGTAG";
        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.Description = "Seleccionar una carpeta: ";
            d.ShowNewFolderButton = false;
            if (d.ShowDialog() == DialogResult.OK)
            {
                dgImg.Rows.Clear();
                files = Directory.GetFiles(d.SelectedPath, "*.jpg");
                foreach (string s in files)
                { 
                    dgImg.Rows.Add(Properties.Resources.noImage, FileName(s)); 
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

            string max = "100";//Cantidad de Imagenes selecionadas
            if (dgImg.SelectedRows.Count > Convert.ToInt32(max))
            {
                MessageBox.Show("El Máximo de Imágenes Actualizables es " + max + ". Verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (MessageBox.Show("¿ Desea Actualizar las Imágenes Seleccionadas ? ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FileInfo fi;
                Decimal mxKb = Convert.ToDecimal(Parametros.dmlTamanioImagen);//(110);
                Decimal acKb;
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    
                    string fileName;
                    foreach (DataGridViewRow r in dgImg.SelectedRows)
                    {
                        fileName = r.Cells[1].Value.ToString();
                        fi = new FileInfo(txtDirectorio.Text + "\\" + fileName);
                        acKb = Convert.ToDecimal(fi.Length) / 1024;
                        if (fi.Length > (mxKb * 1024))
                        {
                            XtraMessageBox.Show(fileName + " Tamaño Máximo: " + mxKb.ToString() + " Kb. Tamaño Actual: " + acKb.ToString("###,##0.00") + " Kb.", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);                            
                        }
                        else
                        {
                            imgFot.Image = Image.FromFile(txtDirectorio.Text + "\\" + fileName);
                            ProductoBE objE_Producto = new ProductoBE();

                            if (HangTag == false)// por CodigoProveedor
                            {
                                objE_Producto.CodigoProveedor = fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), "");
                                objE_Producto.Imagen = new FuncionBase().Image2Bytes(this.imgFot.Image);

                                ProductoBL objBL_Producto = new ProductoBL();
                                objBL_Producto.ActualizaImagen(objE_Producto);
                            }
                            else 
                            {
                                if (fileName.Contains("_"))
                                {
                                    objE_Producto.IdProducto = Convert.ToInt32(fileName.Replace(fileName.Substring(fileName.LastIndexOf('.') - 2), ""));
                                }
                                else
                                {
                                    objE_Producto.IdProducto = Convert.ToInt32(fileName.Replace(fileName.Substring(fileName.LastIndexOf('.')), ""));
                                }
                                
                                objE_Producto.Imagen = new FuncionBase().Image2Bytes(this.imgFot.Image);

                                ProductoBL objBL_Producto = new ProductoBL();
                                objBL_Producto.ActualizaImagenIdProducto(objE_Producto);                            
                            }
                            
                        }
                    }

                    XtraMessageBox.Show("La importación se generó correctamente\n" + dgImg.SelectedRows.Count.ToString() +" Imágenes Importadas", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    
                }
                catch (Exception ex)
                {
                     Cursor = Cursors.Default;
                     XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        
    }
}