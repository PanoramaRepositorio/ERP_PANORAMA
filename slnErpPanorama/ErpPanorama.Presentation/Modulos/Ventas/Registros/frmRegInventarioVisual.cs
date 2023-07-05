using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegInventarioVisual : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioVisualBE> mLista = new List<InventarioVisualBE>();
       // private bool RegistroRapidoCheck;
        private bool bHangTag;
        private bool bRegistroRapido;

        #endregion

        #region "Eventos"

        public frmRegInventarioVisual()
        {
            InitializeComponent();
        }

        private void frmRegInventarioVisual_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            //BSUtils.LoaderLook(cboBloque, new InventarioVisualBloqueBL().ListaTodosActivo(Convert.ToInt32(cboTienda.EditValue)), "DescBloque", "IdInventarioVisualBloque", true);

            //btnNuevo.Focus();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBloque, new InventarioVisualBloqueBL().ListaTodosActivoTienda(Convert.ToInt32(cboTienda.EditValue)), "DescBloque", "IdInventarioVisualBloque", true);
        }

        private void gvInventarioVisual_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarTienda();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegInventarioVisualEdit objManDocumentoVenta = new frmRegInventarioVisualEdit();
                objManDocumentoVenta.pOperacion = frmRegInventarioVisualEdit.Operacion.Nuevo;
                objManDocumentoVenta.IdInventarioVisual = 0;
                objManDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManDocumentoVenta.IdBloque = Convert.ToInt32(cboBloque.EditValue);
                objManDocumentoVenta.IdModulo = Convert.ToInt32(cboModulo.EditValue);
                objManDocumentoVenta.HangTag = bHangTag;
                objManDocumentoVenta.RegistroRapido = bRegistroRapido;
                objManDocumentoVenta.StartPosition = FormStartPosition.CenterParent;
                //objManDocumentoVenta.ShowDialog();
                if (objManDocumentoVenta.ShowDialog() == DialogResult.OK)
                {
                    //if (mLista.Count > 0)
                    //{
                    //    var Buscar = mLista.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                    //    if (Buscar.Count > 0)
                    //    {
                    //        XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}
                    
                    //if (objManDocumentoVenta.RegistroRapido == true) RegistroRapido = true;
                    Cargar();
                    tlbMenu_NewClick();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        InventarioVisualBE objE_InventarioVisual = new InventarioVisualBE();
                        objE_InventarioVisual = new InventarioVisualBL().Selecciona(int.Parse(gvInventarioVisual.GetFocusedRowCellValue("IdInventarioVisual").ToString()));

                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.Elimina(objE_InventarioVisual);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {

        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoInventarioVisuals";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventarioVisual.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void ActualizaNuevoDescuentotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (XtraMessageBox.Show("Esta seguro de Actualizar descuentos sugeridos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.ActualizaDescuentoListaPrecio(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboModulo.EditValue), Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));

                        XtraMessageBox.Show("Se actualizó el descuento correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            try
            {
                if (XtraMessageBox.Show("Esta seguro de Actualizar descuentos sugeridos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    prgFactura.Visible = true;
                    for (int i = 0; i < gvInventarioVisual.SelectedRowsCount; i++)
                    {
                        int IdInventarioVisual = 0;
                        //decimal decDescuento = 0;

                        int row = gvInventarioVisual.GetSelectedRows()[i];
                        int TotRow = gvInventarioVisual.SelectedRowsCount;
                        TotRow = TotRow - row + 1;
                        prgFactura.Properties.Step = 1;
                        prgFactura.Properties.Maximum = TotRow;
                        prgFactura.Properties.Minimum = 0;

                        //decDescuento = decimal.Parse(objDescuento.Descuento.ToString());
                        IdInventarioVisual = int.Parse(gvInventarioVisual.GetRowCellValue(row, "IdInventarioVisual").ToString());

                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.ActualizaDescuentoListaPrecio(IdInventarioVisual);

                        prgFactura.PerformStep();
                        prgFactura.Update();
                    }
                    XtraMessageBox.Show("Se actualizó el descuento correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                prgFactura.Visible = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CambiarAnteriorDescuentotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (XtraMessageBox.Show("Esta seguro de actualizar el descuentos anterior?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.RestableceDescuentoListaPrecio(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboModulo.EditValue), Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                        XtraMessageBox.Show("Se actualizó el descuento anterior correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            try
            {
                if (XtraMessageBox.Show("Esta seguro de actualizar el descuentos anterior?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    prgFactura.Visible = true;
                    for (int i = 0; i < gvInventarioVisual.SelectedRowsCount; i++)
                    {
                        int IdInventarioVisual = 0;
                        //decimal decDescuento = 0;

                        int row = gvInventarioVisual.GetSelectedRows()[i];
                        int TotRow = gvInventarioVisual.SelectedRowsCount;
                        TotRow = TotRow - row + 1;
                        prgFactura.Properties.Step = 1;
                        prgFactura.Properties.Maximum = TotRow;
                        prgFactura.Properties.Minimum = 0;

                        //decDescuento = decimal.Parse(objDescuento.Descuento.ToString());
                        IdInventarioVisual = int.Parse(gvInventarioVisual.GetRowCellValue(row, "IdInventarioVisual").ToString());

                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.RestableceDescuentoListaPrecio(IdInventarioVisual);

                        prgFactura.PerformStep();
                        prgFactura.Update();
                    }
                    XtraMessageBox.Show("Se actualizó el descuento correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                prgFactura.Visible = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnActualizaCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de actualizar Fecha de Compra y Stock?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.ActualizaCompra(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboModulo.EditValue), Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                        XtraMessageBox.Show("Se actualizó los datos correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editardescuentotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEstablecerDescuento objDescuento = new frmEstablecerDescuento();
                objDescuento.StartPosition = FormStartPosition.CenterParent;
                if (objDescuento.ShowDialog() == DialogResult.OK)
                {
                    prgFactura.Visible = true;
                    for (int i = 0; i < gvInventarioVisual.SelectedRowsCount; i++)
                    {
                        int IdInventarioVisual = 0;
                        decimal decDescuento = 0;

                        int row = gvInventarioVisual.GetSelectedRows()[i];
                        int TotRow = gvInventarioVisual.SelectedRowsCount;
                        TotRow = TotRow - row + 1;
                        prgFactura.Properties.Step = 1;
                        prgFactura.Properties.Maximum = TotRow;
                        prgFactura.Properties.Minimum = 0;

                        //int row = gvInventarioVisual.GetSelectedRows()[i];
                        decDescuento = decimal.Parse(objDescuento.Descuento.ToString());
                        gvInventarioVisual.SetRowCellValue(row, "DescuentoSugerido", decDescuento);

                        IdInventarioVisual = int.Parse(gvInventarioVisual.GetRowCellValue(row, "IdInventarioVisual").ToString());

                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.ActualizaDescuento(IdInventarioVisual, decDescuento);

                        prgFactura.PerformStep();
                        prgFactura.Update();
                    }
                }
                gvInventarioVisual.RefreshData();
                prgFactura.Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboBloque_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboModulo, new InventarioVisualModuloBL().ListaTodosActivo(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboBloque.EditValue)), "DescModulo", "IdInventarioVisualModulo", true);
        }

        private void cboModulo_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnDescuentoPorLinea_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Está seguro de actualizar la columna Nuevo Dscto con el descuento de la lista descuento por fechas y lineas?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        InventarioVisualBL objBL_InventarioVisual = new InventarioVisualBL();
                        objBL_InventarioVisual.ActualizaDescuentoPorLinea(Convert.ToInt32(cboTienda.EditValue));
                        XtraMessageBox.Show("Se actualizó los datos correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHangTag.Checked == true)
            {
                bHangTag = true;
            }
            else
            {
                bHangTag = false;
            }
        }

        private void chkRegistroRapido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegistroRapido.Checked == true)
            {
                bRegistroRapido = true;
            }
            else
            {
                bRegistroRapido = false;
            }
        }

        private void importarcodigotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportarInventarioVisual objManDescuento = new frmImportarInventarioVisual();
                objManDescuento.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManDescuento.IdBloque = Convert.ToInt32(cboBloque.EditValue);
                objManDescuento.IdModulo = Convert.ToInt32(cboModulo.EditValue);
                objManDescuento.DescListaPrecio = "ListaPrecio";//txtDescripcion.Text;
                objManDescuento.bHantag = false;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();
                Cargar();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importarcodigohangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportarInventarioVisual objManDescuento = new frmImportarInventarioVisual();
                objManDescuento.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManDescuento.IdBloque = Convert.ToInt32(cboBloque.EditValue);
                objManDescuento.IdModulo = Convert.ToInt32(cboModulo.EditValue);
                objManDescuento.DescListaPrecio = "ListaPrecio";//txtDescripcion.Text;
                objManDescuento.bHantag = true;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InventarioVisualBL().Lista( Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboModulo.EditValue),Convert.ToDateTime(deDesde.DateTime.ToShortDateString()),Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcInventarioVisual.DataSource = mLista;
        }

        private void CargarTienda()
        {
            mLista = new InventarioVisualBL().Lista(Convert.ToInt32(cboTienda.EditValue), 0, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcInventarioVisual.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcInventarioVisual.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvInventarioVisual.GetFocusedRowCellValue("IdInventarioVisual").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un InventarioVisual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        public void InicializarModificar()
        {
            if (gvInventarioVisual.RowCount > 0)
            {
                InventarioVisualBE objInventarioVisual = new InventarioVisualBE();
                objInventarioVisual.IdInventarioVisual = int.Parse(gvInventarioVisual.GetFocusedRowCellValue("IdInventarioVisual").ToString());

                frmRegInventarioVisualEdit objManInventarioVisualEdit = new frmRegInventarioVisualEdit();
                objManInventarioVisualEdit.pOperacion = frmRegInventarioVisualEdit.Operacion.Modificar;
                objManInventarioVisualEdit.IdTienda = objInventarioVisual.IdTienda;//Convert.ToInt32(cboTienda.EditValue);
                objManInventarioVisualEdit.IdBloque = objInventarioVisual.IdBloque;
                objManInventarioVisualEdit.IdModulo = objInventarioVisual.IdModulo;
                objManInventarioVisualEdit.IdInventarioVisual = objInventarioVisual.IdInventarioVisual;
                objManInventarioVisualEdit.StartPosition = FormStartPosition.CenterParent;
                objManInventarioVisualEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        #endregion

    }
}

       