using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmVerValeDisponible : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<PromocionValeDescuentoBE> mLista = new List<PromocionValeDescuentoBE>();
        public int IdPromocionValeDescuento = 0;
        public decimal DescuentoVale = 0;
        public decimal ImporteVale = 0;
        public int TipoVale = 0; //0=Todo, 1=Descuento, 2=Efectivo
        public int IdTipoPromocion = 0;
        #endregion

        #region "Eventos"

        public frmVerValeDisponible()
        {
            InitializeComponent();
        }

        private void frmVerValeDisponible_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gvPromocionValeDescuento.RowCount > 0)
            {
                IdPromocionValeDescuento = Int32.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdPromocionValeDescuento").ToString());
                DescuentoVale = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("DescuentoAdicional").ToString());
                ImporteVale = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("Importe").ToString());
                IdTipoPromocion = Int32.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdTipoPromocion").ToString());
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvPromocionValeDescuento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                SeleccionarRegistro();
            }
        }

        private void SeleccionarRegistro()
        {
            if (gvPromocionValeDescuento.RowCount > 0)
            {
                PromocionValeDescuentoBE objVale = new PromocionValeDescuentoBE();
                int index = gvPromocionValeDescuento.FocusedRowHandle;
                objVale = (PromocionValeDescuentoBE)gvPromocionValeDescuento.GetRow(index);
                IdPromocionValeDescuento = objVale.IdPromocionValeDescuento;
                DescuentoVale = objVale.DescuentoAdicional;
                IdTipoPromocion = objVale.IdTipoPromocion;
                ImporteVale = objVale.Importe;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Producto");
            }
        }

        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new PromocionValeDescuentoBL().ListaFecha(Parametros.intEmpresaId,Parametros.intTiendaId, TipoVale);
            gcPromocionValeDescuento.DataSource = mLista;
        }

        #endregion

    }
}