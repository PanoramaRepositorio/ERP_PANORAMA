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

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmVerMovimientoCaja : DevExpress.XtraEditors.XtraForm
    {
        public int IdPedido = 0;
        private List<MovimientoCajaBE> mLista = new List<MovimientoCajaBE>();


        public frmVerMovimientoCaja()
        {
            InitializeComponent();
        }

        private void frmVerMovimientoCaja_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            mLista = new MovimientoCajaBL().ListaPedido(IdPedido);
            gcMovimientoCaja.DataSource = mLista;

            lblTotalRegistros.Text = gvMovimientoCaja.RowCount.ToString() + " Registros";
            CalcularTotalDocumentos();
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalDolares = 0;

                for (int i = 0; i < gvMovimientoCaja.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(i, (gvMovimientoCaja.Columns["ImporteSoles"])));
                    decTotalDolares = decTotalDolares + Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(i, (gvMovimientoCaja.Columns["ImporteDolares"])));
                }
                txtTotal.EditValue = decTotal;
                txtTotalDolares.EditValue = decTotalDolares;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}