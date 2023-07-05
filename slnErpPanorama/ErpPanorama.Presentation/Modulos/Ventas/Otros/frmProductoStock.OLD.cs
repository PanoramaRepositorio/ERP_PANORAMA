using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmProductoStock : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StockBE> mLista = new List<StockBE>();
        public Int32 IdProducto { get; set; }

        #endregion

        #region "Eventos"

        public frmProductoStock()
        {
            InitializeComponent();
        }

        private void frmProductoStock_Load(object sender, EventArgs e)
        {
            Cargar();
        }


        private void Cargar()
        {
            mLista = new StockBL().ListaProductoTienda(Parametros.intEmpresaId, Parametros.intTiendaId, 0, Convert.ToInt32(IdProducto));
            gcProducto.DataSource = mLista;

            if (mLista.Count > 0)
            { 
                decimal Total = 0;
                foreach(var item in mLista)
                {
                    Total =Total  + item.Cantidad;
                }
                txtTotal.EditValue = Total;
            }

        }
        #endregion

        #region "Metodos"

        #endregion
    }
}