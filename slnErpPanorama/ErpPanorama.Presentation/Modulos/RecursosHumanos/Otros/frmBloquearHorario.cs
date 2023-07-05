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
using DevExpress.XtraEditors.Filtering.Templates;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmBloquearHorario : DevExpress.XtraEditors.XtraForm
    {

        public string sMensaje = "Bloquear";
        public string sApeNom = "Ninguno";
        public bool bTodos = false;
        public DateTime dDesde = DateTime.Now;
        public DateTime dHasta = DateTime.Now;
        public frmBloquearHorario()
        {
            InitializeComponent();
        }

        private void frmBloquearHorario_Load(object sender, EventArgs e)
        {
            this.Text = sMensaje + " Horario del Personal";
            deDesde.DateTime = dDesde;
            deHasta.DateTime = dHasta;

            gbRango.Text = sMensaje + " a:";
            optUno.Text = sApeNom;
            
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

                dDesde = deDesde.DateTime;
                dHasta = deHasta.DateTime;
                if (optTodos.Checked) bTodos = true;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}