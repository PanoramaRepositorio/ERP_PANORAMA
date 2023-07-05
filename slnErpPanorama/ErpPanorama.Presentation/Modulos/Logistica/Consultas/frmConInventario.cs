using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConInventario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<KardexBE> mLista = new List<KardexBE>();
        private int IdProducto = 0;
        
        #endregion

        #region "Eventos"

        public frmConInventario()
        {
            InitializeComponent();
        }

        private void frmConInventario_Load(object sender, EventArgs e)
        {
            deHasta.EditValue = DateTime.Now;

            //BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            //cboTienda.EditValue = Parametros.intTiendaId;

            //BSUtils.LoaderLook(cboTiendaCruce, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            //cboTiendaCruce.EditValue = Parametros.intTiendaId;

            BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            BSUtils.LoaderLook(cboAlmacenCruce, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);

            ValidarAccesoPerfil();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaInventario_" + cboAlmacen.Text +"_"+ DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventario.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                //cboAlmacen.EditValue = Parametros.intAlmCentralUcayali;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                if (objE_Producto != null)
                {
                    IdProducto = objE_Producto.IdProducto;
                    txtCodigo.Text = objE_Producto.CodigoProveedor;
                    txtNombreProducto.Text = objE_Producto.NombreProducto;
                    btnConsultar.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;
                }

                btnConsultar.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvInventario.RowCount > 0)
            {
                frmConInventarioDetalle objConInevenBulDet = new frmConInventarioDetalle();
                objConInevenBulDet.IdTienda = int.Parse(gvInventario.GetFocusedRowCellValue("IdTienda").ToString());
                objConInevenBulDet.IdAlmacen = int.Parse(gvInventario.GetFocusedRowCellValue("IdAlmacen").ToString());
                objConInevenBulDet.IdProducto = int.Parse(gvInventario.GetFocusedRowCellValue("IdProducto").ToString());
                objConInevenBulDet.CodigoProveedor = gvInventario.GetFocusedRowCellValue("CodigoProveedor").ToString();
                objConInevenBulDet.NombreProducto = gvInventario.GetFocusedRowCellValue("NombreProducto").ToString();
                objConInevenBulDet.Abreviatura = gvInventario.GetFocusedRowCellValue("Abreviatura").ToString();
                objConInevenBulDet.FechaDesde = Convert.ToDateTime("01/01/2010");
                objConInevenBulDet.FechaHasta = deHasta.DateTime;
                objConInevenBulDet.StartPosition = FormStartPosition.CenterParent;
                objConInevenBulDet.ShowDialog();

                Cargar();

                //frmConInventarioBulto frm = new frmConInventarioBulto();
                //deDesde.EditValue = Convert.ToDateTime("01/01/" + Parametros.intPeriodo); //DateTime.Now;
                //deHasta.EditValue = DateTime.Now;
                //frm.CargarCodigo(Convert.ToInt32(cboAlmacen.EditValue), int.Parse(gvInventario.GetFocusedRowCellValue("IdProducto").ToString()));
                //frm.Show();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int Almacen2 = 0;
            if (chkCruce.Checked == true)
                Almacen2 = Convert.ToInt32(cboAlmacenCruce.EditValue);


            Cursor = Cursors.WaitCursor;
            mLista = new KardexBL().ListaInventario(Parametros.intEmpresaId, Convert.ToInt32(cboAlmacen.EditValue), IdProducto, Almacen2, deHasta.DateTime);
            gcInventario.DataSource = mLista;
            //lblTotalRegistros.Text = mLista.Count.ToString() + " Registros Encontrados";
            CalcularTotalDocumentos();
            Cursor = Cursors.Default;
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotal2 = 0;

                for (int i = 0; i < gvInventario.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvInventario.GetRowCellValue(i, (gvInventario.Columns["Stock"])));
                    decTotal2 = decTotal2 + Convert.ToDecimal(gvInventario.GetRowCellValue(i, (gvInventario.Columns["Stock2"])));
                }
                txtTotal.EditValue = decTotal;
                txtTotalAlmacen2.EditValue = decTotal2;
                lblTotalRegistros.Text = gvInventario.RowCount.ToString() + " Registros Encontrados";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarAccesoPerfil()
        {
            if(Parametros.intPerfilId ==Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeAlmacen)
            {
                gridColumn14.Visible = true;
                gridColumn15.Visible = true;
                gridColumn16.Visible = true;
                gridColumn17.Visible = true;
                gridColumn18.Visible = true;
            }
        }

        #endregion

        private void cboTiendaCruce_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTiendaCruce.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacenCruce, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTiendaCruce.EditValue)), "DescAlmacen", "IdAlmacen", true);
            }
        }

        private void chkCruce_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCruce.Checked == true)
            {
                cboAlmacenCruce.Enabled = true;
            }
            else
            {
                cboAlmacenCruce.Enabled = false;
            }
        }

        private void gvInventario_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }

        private void verStockTransitotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gvInventario.GetFocusedRowCellValue("IdProducto").ToString();

            frmconStockTransitov2 objfrmconStockTransitov2 = new frmconStockTransitov2();
            objfrmconStockTransitov2.IdProdcuto = Int32.Parse(gvInventario.GetFocusedRowCellValue("IdProducto").ToString());
            objfrmconStockTransitov2.ShowDialog();
        }
    }
}