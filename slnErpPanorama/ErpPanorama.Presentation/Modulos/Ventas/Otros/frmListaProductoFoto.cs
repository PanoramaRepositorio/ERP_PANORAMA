using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using DevExpress.Export;
using DevExpress.XtraPrinting;


namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmListaProductoFoto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProductoBE> mLista = new List<ProductoBE>();
        public int IdFacturaCompra = 0;
        public int IdPedido = 0;
        public int IdProforma = 0;
        public int IdSolicitudCompra = 0;
        public bool FlagDestacado = false;
        public bool FlagRecomendado = false;


        #endregion

        #region "Eventos"

        public frmListaProductoFoto()
        {
            InitializeComponent();
        }

        private void frmListaProductoFoto_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gcProducto_DoubleClick(object sender, EventArgs e)
        {
            frmVerFotoProducto frm = new frmVerFotoProducto();
            frm.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
            frm.Show();
        }

        private void descargarfotostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;

                    foreach (ProductoBE item in mLista)
                    {
                        pictureBox1.Image = new FuncionBase().Bytes2Image((byte[])item.Imagen);
                        pictureBox1.Image.Save(f.SelectedPath + @"\" + item.IdProducto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        //pictureBox1.Image.Save(@"C:\Temp\" + item.IdProducto + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    XtraMessageBox.Show("Se descargó las imágenes en " + f.SelectedPath, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProductoFoto" ;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcProducto.DefaultView.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls", new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                if (XtraMessageBox.Show("Desea abrir este archivo", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(f.SelectedPath + @"\" + _fileName + ".xls");
                }

                Cursor = Cursors.Default;
            }


        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ProductoBL().ListaImagen(IdFacturaCompra, IdPedido, IdProforma, IdSolicitudCompra,FlagRecomendado,FlagDestacado);
            gcProducto.DataSource = mLista;
        }

        #endregion

    }
}