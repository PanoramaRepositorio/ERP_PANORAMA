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
using ErpPanorama.Presentation.Modulos.Ventas.Registros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmconStockTransitov2 : DevExpress.XtraEditors.XtraForm
    {
        #region Propiedades
        private List<StockBE> mLista = new List<StockBE>();
        int _IdProdcuto = 0;

        public int IdProdcuto
        {
            get { return _IdProdcuto; }
            set { _IdProdcuto = value; }
        }

        #endregion
        public frmconStockTransitov2()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #region Metodos

        private void Cargar()
        {
           

            if (rdbResumen.Checked == true)
            {
                
                mLista = new StockBL().ListaProductoTransitov2(Parametros.intEmpresaId, IdProdcuto);
                gcStockTransito.DataSource = mLista;
            }
            else
            {
              
                mLista = new StockBL().ListaProductoTransitoDetallev2(Parametros.intEmpresaId, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcStockTransito.DataSource = mLista;

            }
            CalcularCantidadTotal();
        }

        private void CalcularCantidadTotal()
        {
            try
            {
                int decTotal = 0;
                int decTotalCantidad = 0;

                for (int i = 0; i < gvStockTransito.RowCount; i++)
                {
                    decTotalCantidad = decTotalCantidad + Convert.ToInt32(gvStockTransito.GetRowCellValue(i, (gvStockTransito.Columns["Cantidad"])));
                    decTotal = decTotal + Convert.ToInt32(gvStockTransito.GetRowCellValue(i, (gvStockTransito.Columns["Importe"])));
                    lblRegistros.Text = gvStockTransito.RowCount.ToString() + " Registros encontrados";
                }
                txtTotal.EditValue = decTotal;
                txtTotalCantidad.EditValue = decTotalCantidad;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void frmconStockTransitov2_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = Convert.ToDateTime("28/07/2018");
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void VerPedidotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //int IdPedido = 0;
            string Numero = "";
            int Periodo = 0;
            string TipoDocumento = "";
            Numero = (gvStockTransito.GetFocusedRowCellValue("Numero").ToString());
            Periodo = int.Parse(gvStockTransito.GetFocusedRowCellValue("Periodo").ToString());
            TipoDocumento= (gvStockTransito.GetFocusedRowCellValue("DescTipoDocumento").ToString());

            PedidoBE objPedidoBe = new PedidoBE();
            PedidoBL objPedidoBL = new PedidoBL();
            objPedidoBe = objPedidoBL.SeleccionaNumero(Periodo, Numero);


            if (TipoDocumento =="PED")
            {

                frmRegPedidoEdit frm = new frmRegPedidoEdit();
                frm.IdPedido = objPedidoBe.IdPedido;
                frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Este documento no es pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
