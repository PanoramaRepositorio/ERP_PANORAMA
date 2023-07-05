using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraGrid.Columns;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmProcesarDetraccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<CuentaPorPagarBE> mLista1 = new List<CuentaPorPagarBE>();
        private List<CuentaPorPagarBE> mLista2 = new List<CuentaPorPagarBE>();
        private List<CuentaPorPagarBE> mLista3 = new List<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList1 = new BindingList<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList2 = new BindingList<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList3 = new BindingList<CuentaPorPagarBE>();

        private String Bloque = "";
        #endregion "Propiedades"

        #region "Eventos"
        public frmProcesarDetraccion()
        {
            InitializeComponent();
        }

        private void frmProcesarDetraccion_Load(object sender, EventArgs e)
        {
            Cargar1();
            AplicarSumatoria1();
            AplicarSumatoria2();
            Bloque = ObtenerNumeroCorrelativo();
            labelControl3.Text = DateTime.Now.ToString("yy") + FuncionBase.AgregarCaracter((Bloque).ToString(), "0", 4);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            int id1 = gridView1.GetFocusedRowCellValue("IdCuentaPagar") == null ? 0 : int.Parse(gridView1.GetFocusedRowCellValue("IdCuentaPagar").ToString());

            if (id1 == 0) return;

            CuentaPorPagarBL objBL_CuentaPorPagar = new CuentaPorPagarBL();
            CuentaPorPagarBE objCuentaPorPagar = objBL_CuentaPorPagar.Buscar_CuentaPorPagar(id1);

            if (objCuentaPorPagar.MontoAbono == 0)
            {
                XtraMessageBox.Show("No hay detraccion en el documento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            supList1.AllowRemove = true;
            supList2.AllowNew = true;
            supList3.AllowNew = true;

            supList1.Remove(supList1.Single(r => r.IdCuentaPagar == id1));
            supList2.Add(objCuentaPorPagar);
            supList3.Add(objCuentaPorPagar);

            gridControl1.DataSource = supList1;
            gridControl2.DataSource = supList2;
            gridControl3.DataSource = supList3;

            AplicarSumatoria1();
            AplicarSumatoria2();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            int id2 = gridView2.GetFocusedRowCellValue("IdCuentaPagar") == null ? 0 : int.Parse(gridView2.GetFocusedRowCellValue("IdCuentaPagar").ToString());

            if (id2 == 0) return;

            CuentaPorPagarBL objBL_CuentaPorPagar = new CuentaPorPagarBL();
            CuentaPorPagarBE objCuentaPorPagar = objBL_CuentaPorPagar.Buscar_CuentaPorPagar(id2);

            supList2.AllowRemove = true;
            supList3.AllowRemove = true;
            supList1.AllowNew = true;

            supList2.Remove(supList2.Single(r => r.IdCuentaPagar == id2));
            supList3.Remove(supList3.Single(r => r.IdCuentaPagar == id2));
            supList1.Add(objCuentaPorPagar);

            gridControl2.DataSource = supList2;
            gridControl3.DataSource = supList3;
            gridControl1.DataSource = supList1;

            AplicarSumatoria1();
            AplicarSumatoria2();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CuentaPorPagarBL objBL_CuentaPorPagar = new CuentaPorPagarBL();
                int i2 = 0, i1 = 0;
                String bloque = "";

                supList2 = (BindingList<CuentaPorPagarBE>)gridControl2.DataSource;

                foreach (var c in supList2)
                {
                    bloque = DateTime.Now.ToString("yy") + FuncionBase.AgregarCaracter((Bloque).ToString(), "0", 4);
                    //c.IdSituacion = 404;
                    c.IdSituacion = Parametros.intSitAplicadoCon;
                    c.fechaBloque = DateTime.Now;
                    c.NumeroBloque = Bloque;
                    c.IndiceBloque = DateTime.Now.ToString("yy") + FuncionBase.AgregarCaracter((Bloque).ToString(), "0", 4);
                    c.IdCuentaPagar = int.Parse(gridView2.GetRowCellValue(i2, "IdCuentaPagar").ToString());
                    objBL_CuentaPorPagar.CambiaSituacion(c);
                    i2++;
                }

                //Cargar2(404, bloque);
                Cargar2(Parametros.intSitAplicadoCon, bloque);
                //Cargar3(404, bloque);
                Cargar3(Parametros.intSitAplicadoCon, bloque);

                supList1 = (BindingList<CuentaPorPagarBE>)gridControl1.DataSource;

                foreach (var c in supList1)
                {
                    //c.IdSituacion = 403;
                    c.IdSituacion = Parametros.intSitPendienteCon;
                    c.IdCuentaPagar = int.Parse(gridView1.GetRowCellValue(i1, "IdCuentaPagar").ToString());
                    objBL_CuentaPorPagar.VolveraSituacion(c);
                    i1++;
                }

                ExportarExcel();

            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
            finally
            {
                Close();
            }
        }
        #endregion "Eventos"

        #region "Metodos"
        private void Cargar1()
        {
            // EDGAR 260123: AGREGAR LISTADO DE CUENTAS POR PAGAR SEGUN SITUACION
            // mLista1 = new CuentaPorPagarBL().ListaPorSituacion(403);
            mLista1 = new CuentaPorPagarBL().ListaPorSituacion(Parametros.intSitPendienteCon);
            if (mLista1 != null)
            {
                foreach (CuentaPorPagarBE x in mLista1.Where(x => x.MontoAbono == 0).ToList())
                {
                    mLista1.Remove(x);
                }
            }
            supList1 = new BindingList<CuentaPorPagarBE>(mLista1);
            gridControl1.DataSource = supList1;
        }

        private void Cargar2(Int32 pIdSituacion, String pIndiceBloque)
        {
            // EDGAR 260123: AGREGAR LISTADO DE CUENTAS POR PAGAR SEGUN SITUACION
            mLista2 = new CuentaPorPagarBL().ListaPorSituacionBloque(pIdSituacion,pIndiceBloque);
            supList2 = new BindingList<CuentaPorPagarBE>(mLista2);
            gridControl2.DataSource = supList2;
        }

        private void Cargar3(Int32 pIdSituacion, String pIndiceBloque)
        {
            // EDGAR 260123: AGREGAR LISTADO DE CUENTAS POR PAGAR SEGUN SITUACION
            mLista3 = new CuentaPorPagarBL().ListaPorSituacionBloque(pIdSituacion, pIndiceBloque);
            supList3 = new BindingList<CuentaPorPagarBE>(mLista3);
            gridControl3.DataSource = supList3;
        }

        private String ObtenerNumeroCorrelativo()
        {
            String strNumeroBloque = "";
            int intNumeroBloque = 0;

            CuentaPorPagarBE NumeroBloque = null;

            NumeroBloque = new CuentaPorPagarBL().GetCorrelativo();


            if (NumeroBloque.NumeroBloque == "0" || NumeroBloque.NumeroBloque == "")
            {
                strNumeroBloque = "1";
            }
            else
            {
                intNumeroBloque = Int32.Parse(NumeroBloque.NumeroBloque);
                intNumeroBloque += 1;
                strNumeroBloque = intNumeroBloque.ToString();
            }

            return strNumeroBloque;
        }

        private void ExportarExcel()
        {
            DevExpress.XtraGrid.Columns.GridColumn col = gridView3.Columns.ColumnByFieldName("indexcpp");
            if (col == null) return;

            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "DetraccionesPagadas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    gridView3.SetRowCellValue(i, col, (i + 1));
                }
                gridView3.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void AplicarSumatoria1()
        {
            foreach (GridColumn column in gridView1.Columns)
            {
                DevExpress.XtraGrid.GridSummaryItem item = column.SummaryItem;
                if (item != null)
                    column.Summary.Remove(item);
            }

            DevExpress.XtraGrid.GridColumnSummaryItem item1 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoAbono", "{0}");
            gridView1.Columns[6].Summary.Add(item1);
        }

        private void AplicarSumatoria2()
        {
            foreach (GridColumn column in gridView2.Columns)
            {
                DevExpress.XtraGrid.GridSummaryItem item = column.SummaryItem;
                if (item != null)
                    column.Summary.Remove(item);
            }

            DevExpress.XtraGrid.GridColumnSummaryItem item1 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoAbono", "{0}");
            gridView2.Columns[4].Summary.Add(item1);
        }

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, 109, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 4);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                Bloque = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion "Metodos"
    }
}