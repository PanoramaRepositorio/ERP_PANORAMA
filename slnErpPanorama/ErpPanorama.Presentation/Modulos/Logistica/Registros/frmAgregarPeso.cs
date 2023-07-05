using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmAgregarPeso : Form
    {
        public int vIdPedido;
        public string vNumeroPedido;
        public decimal vTotalPeso;
        public int vBtn;
        public int vIndiceGrid = 0;

        public frmAgregarPeso()
        {
            InitializeComponent();
        }

        private void frmAgregarPeso_Load(object sender, EventArgs e)
        {
            txtNumPedido.Text = vNumeroPedido;
            txtTotalPeso.Text = String.Format("{0:###0.00}", vTotalPeso);
            txtTotalPeso.Focus();
            txtTotalPeso.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vBtn = 0;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            objBL_MovimientoPedido.ActualizaTotalPesoPedido(vIdPedido, Convert.ToDecimal(txtTotalPeso.Text));
            XtraMessageBox.Show("Se actualizo el pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            vBtn = 1;
            this.Close();
        }

        private void txtTotalPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }
    
}
