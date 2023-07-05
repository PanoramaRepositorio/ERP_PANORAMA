using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmListaPrinters : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public string strNamePrinter { get; set; }
        public int intCopias { get; set; }

        public bool bEstadoCopias = false;

        #endregion

        #region "Eventos"

        public frmListaPrinters()
        {
            InitializeComponent();
        }

        private void frmListaPrinters_Load(object sender, EventArgs e)
        {
            lblCopias.Visible = bEstadoCopias;
            nudCopias.Visible = bEstadoCopias;
            CargarImpresora();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            strNamePrinter = lstImpresora.SelectedItems[0].Text;
            intCopias = Convert.ToInt32(nudCopias.Value);

       }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void CargarImpresora()
        {
            try
            {
                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    ListViewItem listItem = new ListViewItem(strPrinter);
                    listItem.ImageIndex = 0;
                    listItem.SubItems.Add(strPrinter);
                    lstImpresora.Items.Add(listItem);
                }

                //Buscamos la impresora por defecto
                foreach (ListViewItem item in lstImpresora.Items)  
                {  
                    if (item.Text.Contains(strDefaultPrinter))  
                    {  
                        item.Selected = true;  
                    }
                    if (item.SubItems[1].Text.Contains(strDefaultPrinter))  
                    {                    
                        item.Selected = true;  
                    }  
                }

                btnAceptar.Focus();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        

       
    }
}