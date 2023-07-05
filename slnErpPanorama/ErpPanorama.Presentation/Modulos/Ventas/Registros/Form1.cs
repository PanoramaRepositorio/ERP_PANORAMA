using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    textBox5.Focus();
            //}
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dtPadron = new DataTable();
            dtPadron = FuncionBase.ToDataTable(new MovimientoPedidoBL().ListaPadron(textBox1.Text.Trim()));

            if (dtPadron.Rows.Count > 0)
            {
                DataRow row5 = dtPadron.Rows[0];
                textBox5.Text = Convert.ToString(row5["RazonSocialp"]);
                textBox4.Text = Convert.ToString(row5["EstadoContribuyentep"]);
                textBox6.Text = Convert.ToString(row5["CondicionDomiciliop"]);
            }
            else
            {
                XtraMessageBox.Show("El Ruc no Existe en el Padron de clientes, registralo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
   
                //DataTable dtPadron = new DataTable();
                //dtPadron = FuncionBase.ToDataTable(new MovimientoPedidoBL().ListaPadron(textBox1.Text.Trim()));

                //if (dtPadron.Rows.Count > 0)
                //{
                //    DataRow row5 = dtPadron.Rows[0];
                //    textBox5.Text= Convert.ToString(row5["RazonSocialp"]);
                //    textBox4.Text = Convert.ToString(row5["EstadoContribuyentep"]);
                //    textBox6.Text = Convert.ToString(row5["CondicionDomiciliop"]);
                //}
                //else
                //{
                //    XtraMessageBox.Show("El Ruc no Existe en el Padron de clientes, registralo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBL objBL_Cliente = new ClienteBL();
                ClienteBE objE_Cliente = new ClienteBE();

                objE_Cliente.NumeroDocumento = textBox1.Text.ToString().Trim();
                objE_Cliente.DescCliente = textBox5.Text.ToString().Trim();
                objE_Cliente.EstadoContribuyente = textBox4.Text.ToString().Trim();
                objE_Cliente.CondicionDomicilio = textBox6.Text.ToString().Trim();

                objBL_Cliente.ActualizaPadron(objE_Cliente);

                XtraMessageBox.Show("Se actualizo el padron.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
