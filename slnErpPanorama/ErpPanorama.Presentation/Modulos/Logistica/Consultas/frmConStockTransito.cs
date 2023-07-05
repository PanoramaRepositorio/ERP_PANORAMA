using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using System.Linq;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConStockTransito : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<StockBE> mLista = new List<StockBE>();

        private int IdProducto = 0;

        #endregion

        #region "Eventos"

        public frmConStockTransito()
        {
            InitializeComponent();
        }

        private void frmConStockTransito_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboDocumento,CargarTipoDocumento(),"Descripcion","Id",true);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvStockTransito_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularCantidadTotal();
        }


        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoStockTransito";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvStockTransito.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            //mLista = new StockBL().ListaProductoTransitoDetalle(Parametros.intEmpresaId, 0, 0, 0,Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            //gcStockTransito.DataSource = mLista;

            //gvStockTransito.Columns["DescTipoDocumento"].VisibleIndex = 0; //Asignar
            //gvStockTransito.Columns["Numero"].VisibleIndex = 1;
            ////gvStockTransito.Columns["Fecha"].VisibleIndex = 2;
            ////gvStockTransito.Columns["DescFormaPago"].VisibleIndex = 3;
            //gvStockTransito.Columns["DescVendedor"].VisibleIndex = 2;
            //gvStockTransito.Columns["DescCliente"].VisibleIndex = 3;

            if (rdbResumen.Checked == true)
            {
                mLista = new StockBL().ListaProductoTransito(Parametros.intEmpresaId, 0, 0, 0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcStockTransito.DataSource = mLista;
                //gvStockTransito.Columns[0].Visible = false;
                //gvStockTransito.Columns[1].Visible = false;
                //gvStockTransito.Columns[2].Visible = false;
                //gvStockTransito.Columns[3].Visible = false;
                gvStockTransito.Columns["DescTipoDocumento"].Visible = false;
                gvStockTransito.Columns["Numero"].Visible = false;
                gvStockTransito.Columns["Fecha"].Visible = false;
                gvStockTransito.Columns["DescFormaPago"].Visible = false;
                gvStockTransito.Columns["DescVendedor"].Visible = false;
                gvStockTransito.Columns["DescCliente"].Visible = false;
                gvStockTransito.Columns["DescSituacion"].Visible = false;

                //gvStockTransito.Columns[2].Visible = true;
                //gvStockTransito.Columns[3].Visible = false;
                ////gvStockTransito.Columns[4].Visible = true;
                ////gvStockTransito.Columns[5].Visible = true;
            }
            else 
            {
                mLista = new StockBL().ListaProductoTransitoDetalle(Parametros.intEmpresaId, 0, 0, 0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcStockTransito.DataSource = mLista;

                gvStockTransito.Columns["DescTipoDocumento"].Visible = true;
                gvStockTransito.Columns["Numero"].Visible = true;
                gvStockTransito.Columns["Fecha"].Visible = true;
                gvStockTransito.Columns["DescFormaPago"].Visible = true;
                gvStockTransito.Columns["DescVendedor"].Visible = true;
                gvStockTransito.Columns["DescCliente"].Visible = true;
                gvStockTransito.Columns["DescSituacion"].Visible = true;

                //gvStockTransito.Columns[0].Visible = true;
                //gvStockTransito.Columns[1].Visible = true;
                //gvStockTransito.Columns[2].Visible = true;
                //gvStockTransito.Columns[3].Visible = true;
                //////gvStockTransito.Columns[4].Visible = false;
                //////gvStockTransito.Columns[5].Visible = false;
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

        private void CargarBusqueda()
        {
            gcStockTransito.DataSource = mLista.Where(obj =>
                                                 obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "PEDIDO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "N/S Y N/I";
            dt.Rows.Add(dr);
            return dt;
        }

        #endregion

        private void rdbDetallado_CheckedChanged(object sender, EventArgs e)
        {
            //Cargar();
        }

        private void rdbResumen_CheckedChanged(object sender, EventArgs e)
        {
            //Cargar();
        }

        private void gvStockTransito_DoubleClick(object sender, EventArgs e)
        {

        }



    }
}