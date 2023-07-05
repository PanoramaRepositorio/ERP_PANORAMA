using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmModificarDireccionGuia : DevExpress.XtraEditors.XtraForm
    {
        public String DireccionGuiaPrint ;
        public int IdPedido = 0;

        public frmModificarDireccionGuia()
        {
            InitializeComponent();
        }
        private void frmModificarDireccionGuia_Load(object sender, EventArgs e)
        {
            if (IdPedido > 0)
            {
                MovimientoPedidoBE objE_Pedido = null;
                objE_Pedido = new MovimientoPedidoBL().SeleccionaDireccionEnvio(IdPedido);
                if(objE_Pedido!= null)
                txtDireccion.Text = objE_Pedido.Direccion;
            }

        }

        private void txtDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DireccionGuiaPrint = txtDireccion.Text.Trim();
                Close();
            }
        }




    }
}