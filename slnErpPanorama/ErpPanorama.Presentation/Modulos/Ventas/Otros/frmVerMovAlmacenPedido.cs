using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmVerMovAlmacenPedido : DevExpress.XtraEditors.XtraForm
    {
        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();
        public int IdPedido= 0;


        public frmVerMovAlmacenPedido()
        {
            InitializeComponent();
        }

        private void frmVerMovAlmacenPedido_Load(object sender, EventArgs e)
        {
            CargarPedido();
        }

        private void CargarPedido()
        {
            mLista = new MovimientoAlmacenBL().ListaNotaSalidaPedido(IdPedido);
            gcMovimientoAlmacen.DataSource = mLista;
        }
    }
}