using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;
using ErpPanorama.BusinessEntity;
using Microsoft.VisualBasic.Devices;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmAdjuntarArchivo : XtraForm
    {
        public SolicitudEgresoDetalleBE oBE = new SolicitudEgresoDetalleBE();
        Computer mycomputer = new Computer(); // Así accederemos al "FileSystem".
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4,
            Renovar = 5
        }
        public int IdSolicitudEgreso = 0;

        int _IdSolicitudEgresoDetalle = 0;

        public int IdSolicitudEgresoDetalle
        {
            get { return _IdSolicitudEgresoDetalle; }
            set { _IdSolicitudEgresoDetalle = value; }
        }
        public Operacion pOperacion { get; set; }
        public frmAdjuntarArchivo()
        {
            InitializeComponent();

            //gridControl.DataSource = GetDataSource();
        }
        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            //if (e.Button.Properties.Caption == "Print") gridControl.ShowRibbonPrintPreview();
        }
        public BindingList<Customer> GetDataSource()
        {
            BindingList<Customer> result = new BindingList<Customer>();
            result.Add(new Customer()
            {
                ID = 1,
                Name = "ACME",
                Address = "2525 E El Segundo Blvd",
                City = "El Segundo",
                State = "CA",
                ZipCode = "90245",
                Phone = "(310) 536-0611"
            });
            result.Add(new Customer()
            {
                ID = 2,
                Name = "Electronics Depot",
                Address = "2455 Paces Ferry Road NW",
                City = "Atlanta",
                State = "GA",
                ZipCode = "30339",
                Phone = "(800) 595-3232"
            });
            return result;
        }
        public class Customer
        {
            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Required]
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            public string Phone { get; set; }
        }

        private void windowsUIButtonPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog1 = new OpenFileDialog();
            Dialog1.Filter = "PDF Documents|*.pdf|JPG Images |*.jpg|All Files (*.*)|*.*";
            if (Dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.AppStarting;
                txtRutaArchivo.Text = Dialog1.FileName;
                Cursor = Cursors.Default;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (txtRutaArchivo.Text != string.Empty)
            {
                System.Diagnostics.Process.Start(txtRutaArchivo.Text);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdjuntarArchivo_Load(object sender, EventArgs e)
        {
            txtRutaArchivo.EditValue = oBE.RutaArchivo;
            txtNuevaRuta.EditValue = "\\\\172.16.0.155\\Varios";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que el texto del textbox2 sea igual a la ruta seleccionada + desde el último índice de "\", para copiar el nombre de la carpeta.
       //     if (resultado == DialogResult.OK) { txtNuevaRuta.Text = txtNuevaRuta.Text.Trim() + txtNuevaRuta.Text.Substring(txtNuevaRuta.Text.LastIndexOf(@"\")); }

            //if (tipo == "carpeta") { mycomputer.FileSystem.CopyDirectory(textBox1.Text, textBox2.Text); } // Copiamos la carpeta.
            mycomputer.FileSystem.CopyFile(txtRutaArchivo.Text.Trim(), txtNuevaRuta.Text.Trim() + txtRutaArchivo.Text.Substring(txtRutaArchivo.Text.LastIndexOf(@"\")),true);   // Copiamos el archivo.
            

            oBE.IdSolicitudEgreso = IdSolicitudEgreso;
            oBE.IdSolicitudEgresoDetalle = IdSolicitudEgresoDetalle;
            oBE.RutaArchivo = txtNuevaRuta.Text.Trim() + txtRutaArchivo.Text.Substring(txtRutaArchivo.Text.LastIndexOf(@"\"));  //   txtRutaArchivo.Text;

            oBE.fname = txtRutaArchivo.Text;
            oBE.tipo = ".pdf";
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog1 = new OpenFileDialog();
            Dialog1.Filter = "PDF Documents|*.pdf|JPG Images |*.jpg|All Files (*.*)|*.*";
            if (Dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.AppStarting;
                txtRutaArchivo.Text = Dialog1.FileName;
                Cursor = Cursors.Default;
            }
        }
    }
}
