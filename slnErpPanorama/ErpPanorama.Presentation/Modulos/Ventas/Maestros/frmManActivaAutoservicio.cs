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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManActivaAutoservicio : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<ListaPrecioDetalleBE> mLista = new List<ListaPrecioDetalleBE>();

        int IdModeloProducto = 0;

        #endregion

        #region "Eventos"

        public frmManActivaAutoservicio()
        {
            InitializeComponent();
        }

        private void frmManActivaAutoservicio_Load(object sender, EventArgs e)
        {
            Cargar();
            //BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (XtraMessageBox.Show("Esta seguro de Actualizar los datos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    prgFactura.Visible = true;
                    for (int i = 0; i < gvListaPrecioDetalle.RowCount; i++)
                    //for (int i = 0; i < gvPedido.RowCount -1; i++)
                    {
                        //int IdProducto = 0;

                        int row = i;// gvListaPrecioDetalle.GetSelectedRows()[i];
                        int TotRow = gvListaPrecioDetalle.RowCount; //SelectedRowsCount;
                        TotRow = TotRow - row + 1;
                        prgFactura.Properties.Step = 1;
                        prgFactura.Properties.Maximum = TotRow;
                        prgFactura.Properties.Minimum = 0;

                        //IdProducto = int.Parse(gvListaPrecioDetalle.GetRowCellValue(row, "IdProducto").ToString());

                        ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                        ListaPrecioDetalleBE objE_ListaPrecioDetalle = new ListaPrecioDetalleBE();

                        objE_ListaPrecioDetalle.IdListaPrecioDetalle = int.Parse(gvListaPrecioDetalle.GetRowCellValue(row, "IdListaPrecioDetalle").ToString()); 
                        objE_ListaPrecioDetalle.IdListaPrecio = 1;
                        objE_ListaPrecioDetalle.IdProducto = int.Parse(gvListaPrecioDetalle.GetRowCellValue(row, "IdProducto").ToString());
                        objE_ListaPrecioDetalle.FlagAutoservicio = Boolean.Parse(gvListaPrecioDetalle.GetRowCellValue(row, "FlagAutoservicio").ToString());

                        objBL_ListaPrecioDetalle.ActualizaAutoservicio(objE_ListaPrecioDetalle);

                        prgFactura.PerformStep();
                        prgFactura.Update();

                    }
                    //gvPedido.DeleteRow(gvDocumento.FocusedRowHandle);
                    //gvPedido.RefreshData();
                    XtraMessageBox.Show("El actualizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prgFactura.Visible = false;
                    Cargar();

                }


                ////ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                ////List<ListaPrecioDetalleBE> lstListaPrecioDetalle = new List<ListaPrecioDetalleBE>();

                //foreach (var item in mLista)
                //{
                //    if (item.FlagAutoservicio == true)
                //    {
                //        ListaPrecioDetalleBE objE_ListaPrecioDetalle = new ListaPrecioDetalleBE();
                //        objE_ListaPrecioDetalle.IdListaPrecioDetalle = item.IdListaPrecioDetalle;
                //        objE_ListaPrecioDetalle.IdListaPrecio = item.IdListaPrecio;
                //        objE_ListaPrecioDetalle.IdProducto = item.IdProducto;
                //        objE_ListaPrecioDetalle.FlagAutoservicio = item.FlagAutoservicio;
                //        //objE_ListaPrecioDetalle.FlagEstado = item.FlagEstado;
                //        lstListaPrecioDetalle.Add(objE_ListaPrecioDetalle);
                //    }
                //}
                //objBL_ListaPrecioDetalle.ActualizaAutoservicio(lstListaPrecioDetalle);

                //XtraMessageBox.Show("Datos Actualizados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Cargar();//add

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoAutoservicio";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvListaPrecioDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
            //CargarModeloProducto();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }


        private void btnTodos_Click(object sender, EventArgs e)
        {
            CargarTodo();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ListaPrecioDetalleBL().ListaAutoservicio(Parametros.intEmpresaId, 1, 1);
            gcListaPrecioDetalle.DataSource = mLista;
            lblTotalRegistros.Text = gvListaPrecioDetalle.RowCount.ToString() + " Registros encontrados";
        }

        private void CargarTodo()
        {
            mLista = new ListaPrecioDetalleBL().ListaTodosActivo(Parametros.intEmpresaId,1,1);
            gcListaPrecioDetalle.DataSource = mLista;
            lblTotalRegistros.Text = gvListaPrecioDetalle.RowCount.ToString() + " Registros encontrados";
        }

        private void CargarBusqueda()
        {
            if (txtDescripcion.Text.Trim().Length > 2)
                //gcListaPrecioDetalle.DataSource = mLista.Where(obj => obj.CodigoProveedor.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.NombreProducto.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
                gcListaPrecioDetalle.DataSource = mLista.Where(obj => obj.CodigoProveedor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
            lblTotalRegistros.Text = gvListaPrecioDetalle.RowCount.ToString() + " Registros encontrados";
        }

        #endregion

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarAutoservicioEdit objManDescuento = new frmManImportarAutoservicioEdit();
                objManDescuento.IdListaPrecio = 1;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.bHantag = false;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();
                if (objManDescuento.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importarporhangtagtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarAutoservicioEdit objManDescuento = new frmManImportarAutoservicioEdit();
                objManDescuento.IdListaPrecio = 1;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.bHantag = true;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();
                if (objManDescuento.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activarselecciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvListaPrecioDetalle.SelectedRowsCount; i++)
                {
                    int row = gvListaPrecioDetalle.GetSelectedRows()[i];
                    gvListaPrecioDetalle.SetRowCellValue(row, "FlagAutoservicio", true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desactivarselecciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvListaPrecioDetalle.SelectedRowsCount; i++)
                {
                    int row = gvListaPrecioDetalle.GetSelectedRows()[i];
                    gvListaPrecioDetalle.SetRowCellValue(row, "FlagAutoservicio", false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activarselecciontodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvListaPrecioDetalle.RowCount; i++)
                {
                    gvListaPrecioDetalle.SetRowCellValue(i, "FlagAutoservicio", true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desactivarselecciontodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvListaPrecioDetalle.RowCount; i++)
                {
                    gvListaPrecioDetalle.SetRowCellValue(i, "FlagAutoservicio", false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvListaPrecioDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvListaPrecioDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvProductoIncentivadoDetalle.GetDataRow(e.FocusedRowHandle);
                int IdProducto = 0;
                IdProducto = int.Parse(gvListaPrecioDetalle.GetFocusedRowCellValue("IdProducto").ToString());

                //IdProducto = int.Parse(dr["IdProducto"].ToString());

                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }
        }

        private void gvListaPrecioDetalle_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvListaPrecioDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvProductoIncentivadoDetalle.GetDataRow(e.RowHandle);
                int IdProducto = 0;

                IdProducto = int.Parse(gvListaPrecioDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                //IdProducto = int.Parse(dr["IdProducto"].ToString());


                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }
        }


    }
}