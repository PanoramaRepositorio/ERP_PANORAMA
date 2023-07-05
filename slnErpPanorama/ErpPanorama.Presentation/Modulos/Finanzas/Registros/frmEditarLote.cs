using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraGrid.Columns;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmEditarLote : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<CuentaPorPagarBE> mLista1 = new List<CuentaPorPagarBE>();
        private List<CuentaPorPagarBE> mLista2 = new List<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList1 = new BindingList<CuentaPorPagarBE>();
        BindingList<CuentaPorPagarBE> supList2 = new BindingList<CuentaPorPagarBE>();

        private String Bloque = "";
        public DateTime FechaBloque = default(DateTime);
        public string IndiceBloque = "";
        #endregion

        #region "Eventos"
        public frmEditarLote()
        {
            InitializeComponent();
        }

        private void frmEditarLote_Load(object sender, EventArgs e)
        {
            Cargar1();
            AplicarSumatoria1();
            AplicarSumatoria2();
        }

        private void frmEditarLote_Shown(object sender, EventArgs e)
        {
            //Bloque = txtLote.Text.Replace("0", "").Substring(2);
        }

        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            #region codigo comentado
            //Int32 intTempBloque = 0; String strTempBloque = "";
            //if (txtLote.Text.Length < 2)
            //{
            //    return;
            //}
            //else
            //{
            //    strTempBloque = txtLote.Text.Remove(0, 2) == "" ? "0" : txtLote.Text.Remove(0, 2);
            //    intTempBloque = Convert.ToInt32(strTempBloque);
            //    tempBloque = intTempBloque.ToString();
            //    Bloque = tempBloque;
            //    IndiceBloque = DateTime.Now.ToString("yy") + FuncionBase.AgregarCaracter((tempBloque).ToString(), "0", 4); ;
            //}
            #endregion
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            IndiceBloque = txtLote.Text;
            Bloque = GetBloque(IndiceBloque);

            if (IndiceBloque == "" || IndiceBloque == null)
            {
                XtraMessageBox.Show("Ingrese lote de detraccion correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLote.Focus();
                gridControl2.DataSource = null;
            }
            else
            {
                CargarLote(IndiceBloque);
                AplicarSumatoria1();
                AplicarSumatoria2();
            }
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
            //supList3.AllowNew = true;

            supList1.Remove(supList1.Single(r => r.IdCuentaPagar == id1));
            supList2.Add(objCuentaPorPagar);
            //supList3.Add(objCuentaPorPagar);

            gridControl1.DataSource = supList1;
            gridControl2.DataSource = supList2;
            //gridControl3.DataSource = supList3;

            AplicarSumatoria1();
            AplicarSumatoria2();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            int id2 = gridView2.GetFocusedRowCellValue("IdCuentaPagar") == null ? 0 : int.Parse(gridView2.GetFocusedRowCellValue("IdCuentaPagar").ToString());

            if (id2 == 0) return;

            CuentaPorPagarBL objBL_CuentaPorPagar = new CuentaPorPagarBL();
            CuentaPorPagarBE objCuentaPorPagar = objBL_CuentaPorPagar.Buscar_CuentaPorPagar(id2);

            if (objCuentaPorPagar.IdSituacion == Parametros.intSitPagadoCon)
            {
                XtraMessageBox.Show("La detraccion esta PAGADA", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            supList2.AllowRemove = true;
            //supList3.AllowRemove = true;
            supList1.AllowNew = true;

            supList2.Remove(supList2.Single(r => r.IdCuentaPagar == id2));
            //supList3.Remove(supList3.Single(r => r.IdCuentaPagar == id2));
            supList1.Add(objCuentaPorPagar);

            gridControl2.DataSource = supList2;
            //gridControl3.DataSource = supList3;
            gridControl1.DataSource = supList1;

            AplicarSumatoria1();
            AplicarSumatoria2();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = XtraMessageBox.Show("¿Esta seguro de editar el Lote N° " + txtLote.Text + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    CuentaPorPagarBL objBL_CuentaPorPagar = new CuentaPorPagarBL();
                    int i2 = 0;
                    supList2 = (BindingList<CuentaPorPagarBE>)gridControl2.DataSource;

                    foreach (var c in supList2)
                    {
                        //bloque_ = DateTime.Now.ToString("yy") + FuncionBase.AgregarCaracter((Bloque).ToString(), "0", 4);
                        //c.IdSituacion = 404;
                        c.IdSituacion = Parametros.intSitAplicadoCon;
                        c.fechaBloque = DateTime.Now;
                        c.NumeroBloque = Bloque;
                        c.IndiceBloque = IndiceBloque;
                        c.IdCuentaPagar = int.Parse(gridView2.GetRowCellValue(i2, "IdCuentaPagar").ToString());
                        objBL_CuentaPorPagar.CambiaSituacion(c);
                        i2++;
                    }

                    CargarLote(IndiceBloque);

                    int i1 = 0 /*supList2.Count() + 1*/;
                    supList1 = (BindingList<CuentaPorPagarBE>)gridControl1.DataSource;

                    foreach (var c in supList1)
                    {
                        //c.IdSituacion = 403;
                        String idCuentaPagar = gridView1.GetRowCellValue(i1, "IdCuentaPagar").ToString();
                        
                        //if (idCuentaPagar == c.IdCuentaPagar.ToString())
                        //{
                        c.IdSituacion = Parametros.intSitPendienteCon;
                        c.fechaBloque = Convert.ToDateTime("1900-01-01");
                        c.NumeroBloque = String.Empty /*Convert.ToString(DBNull.Value)*/;
                        c.IndiceBloque = String.Empty /*Convert.ToString(DBNull.Value)*/;
                        c.IdCuentaPagar = Convert.ToInt32(idCuentaPagar);
                        objBL_CuentaPorPagar.VolveraSituacion2(c);
                        i1++;
                        //}
                    }

                    Cargar1();
                }
                else if (res == DialogResult.No)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                // _ = ex.Message;
                XtraMessageBox.Show("Error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Close();
            }
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConsultar.Focus();
            }
        }
        #endregion

        #region "Metodos"
        private void Cargar1()
        {
            //mLista1 = new CuentaPorPagarBL().ListaPorSituacion(403);
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

        private void CargarLote(String pIndiceBloque)
        {
            //mLista2 = new CuentaPorPagarBL().ListaPorSituacionBloque(404, pIndiceBloque);
            mLista2 = new CuentaPorPagarBL().ListaPorBloque(pIndiceBloque);
            supList2 = new BindingList<CuentaPorPagarBE>(mLista2);

            if (supList2.Count == 0)
            {
                XtraMessageBox.Show("No hay detracciones en el lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (var c in supList2)
                {
                    if (c.IdSituacion == Parametros.intSitPagadoCon)
                    {
                        XtraMessageBox.Show("El Lote N° " + IndiceBloque + " esta PAGADO. No se puede modificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gridControl2.DataSource = null;
                        return;
                    }
                }

                gridControl2.DataSource = supList2;
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
            gridView1.Columns[4].Summary.Add(item1);
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

        public String GetBloque(String str)
        {
            String strTempBloque = str.Remove(0, 2) == "" ? "0" : str.Remove(0, 2);
            Int32 intTempBloque = Convert.ToInt32(strTempBloque);
            String tempBloque = intTempBloque.ToString();
            return tempBloque;
        }
        #endregion
    }
}