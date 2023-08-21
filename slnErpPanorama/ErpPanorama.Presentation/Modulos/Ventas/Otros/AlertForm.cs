using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class AlertForm : DevExpress.XtraEditors.XtraForm
    {
        public AlertForm(string mensaje)
        {
            InitializeComponent();

            // Calcula el tamaño del formulario para ocupar el 70% de la pantalla.
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = (int)(screenWidth * 0.3);
            int formHeight = (int)(screenHeight * 0.3);

            // Establece el tamaño del formulario.
            Size = new Size(formWidth, formHeight);
            // Calcula las dimensiones del txtMensaje y del pictureBoxCandado.
            Size txtMensajeSize = new Size(formWidth - 40, int.MaxValue);
            Size pictureBoxSize = pictureBoxCandado.Size;

            // Establece el mensaje de alerta en el control de texto del formulario.
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = Color.Red;
            lblMensaje.Size = lblMensaje.GetPreferredSize(txtMensajeSize);
            // Centra el txtMensaje verticalmente en el formulario.
            int txtMensajeTop = (formHeight - lblMensaje.Height - pictureBoxSize.Height - 20) / 2; // 20 es un margen
            lblMensaje.Location = new Point((formWidth - lblMensaje.Width) / 2, txtMensajeTop);
            // Configura la imagen del PictureBox con la imagen del candado.
            pictureBoxCandado.Image = Properties.Resources.Lock_32x32;
            // Centra el pictureBoxCandado debajo del txtMensaje.
            int pictureBoxTop = lblMensaje.Bottom + 20;
            int pictureBoxLeft = (formWidth - pictureBoxSize.Width) / 2;
            pictureBoxCandado.Location = new Point(pictureBoxLeft, pictureBoxTop);
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxCandado_Click(object sender, EventArgs e)
        {

        }
    }
}
