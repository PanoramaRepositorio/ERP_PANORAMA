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
    public partial class frmProductoStockVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<StockBE> mListaStock = new List<StockBE>();
        public Int32 IdProducto { get; set; }
        public Int32 TotalAlmacen = 0;
        public Int32 TotalCantidad = 0;
        public Int32 IdFormaPago = 0;
        public int IdPedido = 0;
        public Boolean FiltroAuto = false;
        public decimal DescuentoOutlet = 0;

        #endregion

        #region "Eventos"

        public frmProductoStockVenta()
        {
            InitializeComponent();
        }

        private void frmProductoStockVenta_Load(object sender, EventArgs e)
        {
            CargarTodo();
            if (FiltroAuto)
                CargarAutoservicio();
            else
                Cargar();
            //gvProducto.Focus();

            //if (IdFormaPago != Parametros.intContado)
            //{
            //    this.Size = new Size(711, 301);
            //    gcStockAlmacenes.Visible = false;
            //}
            //else
            //{
            //    this.Size = new Size(711, 503);
            //    CargarTodo();
            //}

            gcProducto.Select();
            gvProducto.Focus();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (var item in mListaStock)
            {
                if (item.CantidadPedida > 0)
                {
                    if (item.CantidadPedida > item.Cantidad)
                    {
                        XtraMessageBox.Show("La cantidad solicitada no debe ser mayor al stock.", this.Text);
                        return;
                    }
                    TotalAlmacen = TotalAlmacen + 1;
                    TotalCantidad = TotalCantidad + item.CantidadPedida;

                    if (item.IdAlmacen == Parametros.intAlmTiendaUcayali && chkAutoservicio.Checked)//add 28102015
                    {
                        item.FlagAutoservicio = true;
                    }
                    if (item.IdAlmacen == Parametros.intAlmOutlet) //Add 030517
                    {
                        StockBE pProductoBE = null;
                        pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmOutlet, IdProducto);
                        DescuentoOutlet = pProductoBE.DescuentoOutlet;
                    }

                }
            }
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            MovimientoPedidoBE objE_MovimientoPedido = null;
            objE_MovimientoPedido = new MovimientoPedidoBL().Selecciona(IdPedido);
            if (objE_MovimientoPedido != null)
            {
                if (objE_MovimientoPedido.Aprobado)
                    IdFormaPago = Parametros.intContado;
            }

            mListaStock = new StockBL().ListaProductoTiendaVenta(Parametros.intEmpresaId, Parametros.intTiendaId, 0, IdProducto, IdFormaPago, Parametros.intAlmCentralUcayali);
            gcProducto.DataSource = mListaStock;
        }

        private void CargarAutoservicio()
        {
            mListaStock = new StockBL().ListaProductoTiendaAutoservicio(Parametros.intEmpresaId, Parametros.intTiendaId, 0, IdProducto, IdFormaPago);
            gcProducto.DataSource = mListaStock;
        }

        private void CargarTodo()
        {
            mListaStock = new StockBL().ListaProductoTienda(Parametros.intEmpresaId, Parametros.intTiendaId, 0, Convert.ToInt32(IdProducto));
            gcProducto2.DataSource = mListaStock;
        }

        #endregion

        private void verreservadostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvProducto.RowCount > 0)
                {
                    int IdAlmacen = int.Parse(gvProducto.GetFocusedRowCellValue("IdAlmacen").ToString());

                    frmBusReservaStock frm = new frmBusReservaStock();
                    frm.IdAlmacen = IdAlmacen;
                    frm.IdProducto = IdProducto;
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}