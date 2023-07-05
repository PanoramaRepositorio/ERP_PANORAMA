using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using System.Drawing.Printing;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmMsgPrintDocFE : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        public int IdDocumentoVenta = 0;
        public string sFormato = "";
        public string sImpresora = "";
        public bool bGuiaRemision = false;
        public bool bHojaDespacho = false;

        #endregion

        #region "Eventos"
        public frmMsgPrintDocFE()
        {
            InitializeComponent();
        }

        private void frmMsgPrintDocFE_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoFormato, CargarTipoFormato(), "Descripcion", "Id", false);
            cboTipoFormato.EditValue = "A4";
            CargarImpresora();

            cboImpresora.Select();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            sFormato = cboTipoFormato.EditValue.ToString();
            sImpresora = cboImpresora.EditValue.ToString();
            bGuiaRemision = chkGuiaRemision.Checked;
            bHojaDespacho = chkHojaDespacho.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboImpresora_EditValueChanged(object sender, EventArgs e)
        {
            if (cboImpresora.Text.ToString().Contains("("))
            {
                cboTipoFormato.EditValue = "TK";
            }
            else
            {
                cboTipoFormato.EditValue = "A4";
            }
        }

        private void cboImpresora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)Keys.Enter)
            {
                btnImprimir.Focus();
            }
        }

        private void cboTipoFormato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnImprimir.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Métodos"
        private DataTable CargarTipoFormato()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "A4";
            dr["Descripcion"] = "A4";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "TK";
            dr["Descripcion"] = "Ticket - Roll Paper 80 mm";
            dt.Rows.Add(dr);
            return dt;
        }

        private void CargarImpresora()
        {
            try
            {
                List<ListViewItem> lstImpresora = new List<ListViewItem>();

                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    ListViewItem listItem = new ListViewItem(strPrinter);
                    listItem.ImageIndex = 0;
                    lstImpresora.Add(listItem);
                }

                BSUtils.LoaderLook(cboImpresora, lstImpresora, "Text", "Text", false);
                cboImpresora.EditValue = strDefaultPrinter;
                btnImprimir.Focus();

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