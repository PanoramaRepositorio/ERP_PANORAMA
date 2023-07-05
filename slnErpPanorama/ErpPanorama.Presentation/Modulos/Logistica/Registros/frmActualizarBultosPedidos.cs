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
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmActualizarBultosPedidos : DevExpress.XtraEditors.XtraForm
    {
        public int qIdPedido = 0;
        public string qNumPedido = "";
        public int qBultos = 0;

        public frmActualizarBultosPedidos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmActualizarBultosPedidos_Load(object sender, EventArgs e)
        {
            txtNumero.Text = qNumPedido;
            txtBultos.Text =Convert.ToString(qBultos);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string UsuarioUpd = "";

                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    UsuarioUpd = frmAutoriza.Usuario;
                }
                else
                { return;  }

                //if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                //{
                //    Cursor = Cursors.Default;
                //    XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                //    return;
                //}
                
                //////////////////////////////////////////////////////////////////////////
                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();

                objBL_MovimientoAlmacen.ActualizarBultos(qIdPedido, Convert.ToInt32(txtBultos.Text), UsuarioUpd, frmAutoriza.IdPersona);

                XtraMessageBox.Show("Se realizo satisfactoriamente la actualización de bultos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}