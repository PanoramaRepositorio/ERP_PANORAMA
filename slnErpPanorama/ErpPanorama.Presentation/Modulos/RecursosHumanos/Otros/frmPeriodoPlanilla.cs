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
using DevExpress.XtraPrinting.Native;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmPeriodoPlanilla : DevExpress.XtraEditors.XtraForm
    {
        public int intPeriodo { get; set; }
        public int intMes { get; set; }
        public frmPeriodoPlanilla()
        {
            InitializeComponent();
        }

        private void frmPeriodoPlanilla_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = intPeriodo;
            cboMes.EditValue = intMes;
            cboMes.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if(txtPeriodo.Text != string.Empty)
                {
                    intPeriodo = Convert.ToInt32(txtPeriodo.EditValue);
                    intMes = Convert.ToInt32(cboMes.EditValue);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("Por favor, ingresar el periodo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            }

        }
    }
}