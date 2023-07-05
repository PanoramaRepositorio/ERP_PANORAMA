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
    public partial class frmBusReservaStock : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<KardexBE> mLista = new List<KardexBE>();

        public int IdAlmacen;
        public int IdProducto;
        public int IdTienda;

        #endregion

        #region "Eventos"
        public frmBusReservaStock()
        {
            InitializeComponent();
        }

        private void frmBusReservaStock_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        #endregion

        #region "Metodos"
        private void Cargar()
        {
            mLista = new KardexBL().ListaTransito(Parametros.intEmpresaId, Parametros.intTiendaId, IdAlmacen, IdProducto);
            gcStockReservado.DataSource = mLista;
        }

        #endregion
    }
}