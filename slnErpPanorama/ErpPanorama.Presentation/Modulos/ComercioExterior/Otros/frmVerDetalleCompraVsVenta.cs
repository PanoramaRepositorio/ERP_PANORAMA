using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Otros
{
    public partial class frmVerDetalleCompraVsVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        List<FacturaCompraDetalleBE> mListaFacturaDetalle = new List<FacturaCompraDetalleBE>();

        #endregion

        #region "Eventos"


        public frmVerDetalleCompraVsVenta()
        {
            InitializeComponent();
        }

        private void frmVerDetalleCompraVsVenta_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region "Metodos"
        private void Cargar()
        {
            //Se agrega con clic derecho mostra ventas desde detalle de factura
        }
        #endregion
    }
}