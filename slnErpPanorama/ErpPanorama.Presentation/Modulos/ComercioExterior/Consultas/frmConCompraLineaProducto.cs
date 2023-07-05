using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    public partial class frmConCompraLineaProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<FacturaCompraBE> mLista = new List<FacturaCompraBE>();
        List<ReportePedidoTiendaMesTipoClienteBE> mListaVenta = new List<ReportePedidoTiendaMesTipoClienteBE>();
        List<ReportePedidoTiendaMesTipoClienteBE> mListaVentaCosto = new List<ReportePedidoTiendaMesTipoClienteBE>();

        #endregion

        #region "Eventos"
        public frmConCompraLineaProducto()
        {
            InitializeComponent();
        }

        private void frmConCompraLineaProducto_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarCompras();
            CargarVentas();
            //CargarVentasCosto();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Metodos"

        private void CargarCompras()
        {
            if(optLinea.Checked)
            {
                mLista = new FacturaCompraBL().ListaLineaProductoFecha(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime,0);
                gcCompras.DataSource = mLista;

                gcSubLineaProducto.Visible = false;
            }
            else
            {
                mLista = new FacturaCompraBL().ListaLineaProductoFecha(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime,1);
                gcCompras.DataSource = mLista;

                gcSubLineaProducto.Visible = true;
                gcSubLineaProducto.VisibleIndex = 1;
            }
            
        }

        private void CargarVentas()
        {
            if (optLinea.Checked)
            {
                mListaVenta = new ReportePedidoTiendaMesTipoClienteBL().ListadoPorLineaHorizontal(0, 0, 0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()), 1);
                gcVentas.DataSource = mListaVenta;
                gcSubLineaVenta.Visible = false;
            }
            else
            {
                mListaVenta = new ReportePedidoTiendaMesTipoClienteBL().ListadoPorLineaHorizontal(0, 0, 0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()), 2);
                gcVentas.DataSource = mListaVenta;
                gcSubLineaVenta.Visible = true;
                gcSubLineaVenta.VisibleIndex = 3;
                
            }
            
        }

        private void CargarVentasCosto()
        {
            mListaVentaCosto = new ReportePedidoTiendaMesTipoClienteBL().ListadoPorLineaCostoHorizontal(0, 0, 0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()), 1);
            gcVentasCosto.DataSource = mListaVentaCosto;
        }

        #endregion


    }
}