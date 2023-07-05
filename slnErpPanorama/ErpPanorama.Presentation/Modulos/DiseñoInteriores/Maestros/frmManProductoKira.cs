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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Consultas;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManProductoKira : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<ProductoBE> mLista = new List<ProductoBE>();
        private List<ProductoBE> mListaInactivo = new List<ProductoBE>();

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        
        #endregion

        #region "Eventos"

        public frmManProductoKira()
        {
            InitializeComponent();
        }

        private void frmManProductoKira_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProductoEditKira objManProducto = new frmManProductoEditKira();
                objManProducto.lstProducto = mLista;
                objManProducto.pOperacion = frmManProductoEditKira.Operacion.Nuevo;
                objManProducto.IdProducto = 0;
                objManProducto.StartPosition = FormStartPosition.CenterParent;
                objManProducto.ShowDialog();
                CargarBusqueda();
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
                        ProductoBE objE_Productol = new ProductoBE();
                        objE_Productol.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                        objE_Productol.Usuario = Parametros.strUsuarioLogin;
                        objE_Productol.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Productol.IdEmpresa = Parametros.intEmpresaId;

                        ProductoBL objBL_Producto = new ProductoBL();
                        objBL_Producto.Elimina(objE_Productol);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarBusqueda();
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
            CargarBusqueda();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteProductoBE> lstReporte = null;
                lstReporte = new ReporteProductoBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptProducto = new RptVistaReportes();
                        objRptProducto.VerRptProducto(lstReporte);
                        objRptProducto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProductoles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString().Length > 2)
            {
                CargarBusqueda();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        private void ImportarImagenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarImagenes objImportar = new frmImportarImagenes();
            objImportar.HangTag = false;
            objImportar.StartPosition = FormStartPosition.CenterParent;
            objImportar.Show();
        }

        private void ImportarImageneshangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarImagenes objImportar = new frmImportarImagenes();
            objImportar.HangTag = true;
            objImportar.StartPosition = FormStartPosition.CenterParent;
            objImportar.Show();
        }

        private void importarclasificaciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarClasificacionProducto objImportar = new frmImportarClasificacionProducto();
            objImportar.WindowState = FormWindowState.Maximized;
            objImportar.StartPosition = FormStartPosition.CenterScreen;
            objImportar.Show();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gcProducto.DataSource = new ProductoBL().ListaID(Convert.ToInt32(txtCodigo.Text), Parametros.intTiendaId);
            }
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            gcProducto.DataSource = new ProductoBL().ListaBusquedaKIRA(Parametros.intEmpresaId, Parametros.intTiendaId, txtProducto.Text, pagina, registros);
        }

        private void CargarBusqueda()
        {
            gcProducto.DataSource = new ProductoBL().ListaBusquedaKIRA(Parametros.intEmpresaId, Parametros.intTiendaId, txtProducto.Text.Trim(), intPaginaPrimero, intRegistrosPorPagina);
            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        public void InicializarModificar()
        {
            if (gvProducto.RowCount > 0)
            {
                ProductoBE objProducto = new ProductoBE();
                objProducto.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                objProducto.CodigoProveedor = gvProducto.GetFocusedRowCellValue("CodigoProveedor").ToString();

                frmManProductoEditKira objManProductoEdit = new frmManProductoEditKira();
                objManProductoEdit.pOperacion = frmManProductoEditKira.Operacion.Modificar;
                objManProductoEdit.IdProducto = objProducto.IdProducto;
                objManProductoEdit.CodigoProveedor = objProducto.CodigoProveedor;
                objManProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManProductoEdit.ShowDialog();

                CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        public void InicializarModificarInactivo()
        {
            if (gvProductoInactivo.RowCount > 0)
            {
                ProductoBE objProducto = new ProductoBE();
                objProducto.IdProducto = int.Parse(gvProductoInactivo.GetFocusedRowCellValue("IdProducto").ToString());
                objProducto.CodigoProveedor = gvProductoInactivo.GetFocusedRowCellValue("CodigoProveedor").ToString();

                frmManProductoEditKira objManProductoEdit = new frmManProductoEditKira();
                objManProductoEdit.pOperacion = frmManProductoEditKira.Operacion.Modificar;
                objManProductoEdit.IdProducto = objProducto.IdProducto;
                objManProductoEdit.CodigoProveedor = objProducto.CodigoProveedor;
                objManProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManProductoEdit.ShowDialog();

                CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            intRowCount = new ProductoBL().ListaBusquedaCount(Parametros.intEmpresaId, txtProducto.Text);
            return intRowCount;
        }


        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }


        private void FilaInactivoDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificarInactivo();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvProducto.GetFocusedRowCellValue("IdProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarInactivos()
        {
            mListaInactivo = new ProductoBL().ListaTodosInActivo(Parametros.intEmpresaId);
            gcProductoInactivo.DataSource = mListaInactivo;
            lblTotalRegistrosInactivos.Text = gvProductoInactivo.RowCount.ToString() +" Registros encontrados";
        }

        #endregion

        private void importarimageneswebtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarImagenesWeb objImportar = new frmImportarImagenesWeb();
            objImportar.HangTag = true;
            objImportar.StartPosition = FormStartPosition.CenterParent;
            objImportar.Show();
        }

        private void productoPreventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProductoFoto frm = new frmListaProductoFoto();
            frm.Show();
        }

        private void productorecomendadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProductoFoto frm = new frmListaProductoFoto();
            frm.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarInactivos();
        }

        private void gvProductoInactivo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaInactivoDoubleClick(view, pt);
        }

        private void txtProductoInactivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaInactivo();
            }
        }

        private void CargarBusquedaInactivo()
        {
            gcProductoInactivo.DataSource = mListaInactivo.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtProductoInactivo.Text.ToUpper())).ToList();

            lblTotalRegistrosInactivos.Text = gvProducto.RowCount.ToString();
        }

        private void productodestacadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProductoFoto frm = new frmListaProductoFoto();
            frm.Show();
        }

        private void unificarcodigostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Parametros.strUsuarioLogin =="master"|| Parametros.strUsuarioLogin.ToLower() == "almacen1" || Parametros.strUsuarioLogin == "mmurrugarra" || Parametros.strUsuarioLogin == "ygomez")
            {
                frmAsociarCodigo frm = new frmAsociarCodigo();
                frm.ShowDialog();
            }else
            {
                XtraMessageBox.Show("Ud. no tiene permisos para realizar esta operación.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtProductoInactivo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusquedaInactivo();
        }

        private void mnuContextual_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void importarMedidasYPesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarMedidasPesosProducto objImportar = new frmImportarMedidasPesosProducto();
            objImportar.WindowState = FormWindowState.Maximized;
            objImportar.StartPosition = FormStartPosition.CenterScreen;
            objImportar.Show();
        }
    }
}