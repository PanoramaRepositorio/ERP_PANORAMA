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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManInsumo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<InsumoBE> mLista = new List<InsumoBE>();
        private List<InsumoBE> mListaInactivo = new List<InsumoBE>();

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;

        #endregion

        #region "Eventos"

        public frmManInsumo()
        {
            InitializeComponent();
        }

        private void frmManInsumo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();

            //intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            //CalcularPaginas();
            //CargarBusqueda(intPagina, intRegistrosPorPagina);
            //HabilitarBotones(false, false, true, true);

            //CargarBusqueda();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManInsumoEdit objManInsumo = new frmManInsumoEdit();
                objManInsumo.lstInsumo = mLista;
                objManInsumo.pOperacion = frmManInsumoEdit.Operacion.Nuevo;
                objManInsumo.IdInsumo = 0;
                objManInsumo.StartPosition = FormStartPosition.CenterParent;
                if (objManInsumo.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
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
                        InsumoBE objE_Insumol = new InsumoBE();
                        objE_Insumol.IdInsumo = int.Parse(gvInsumo.GetFocusedRowCellValue("IdInsumo").ToString());
                        objE_Insumol.Usuario = Parametros.strUsuarioLogin;
                        objE_Insumol.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Insumol.IdEmpresa = Parametros.intEmpresaId;

                        InsumoBL objBL_Insumo = new InsumoBL();
                        objBL_Insumo.Elimina(objE_Insumol);
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
            Cargar();
            //CargarBusqueda();
        }

        private void tlbMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteInsumoBE> lstReporte = null;
            //    lstReporte = new ReporteInsumoBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptInsumo = new RptVistaReportes();
            //            objRptInsumo.VerRptInsumo(lstReporte);
            //            objRptInsumo.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoInsumos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInsumo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInsumo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtInsumo_EditValueChanged(object sender, EventArgs e)
        {
            if ( txtDescripcion.Text.ToString().Length > 2)
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

        #endregion

        #region "Metodos"
        private void Cargar()
        {
            mLista = new InsumoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcInsumo.DataSource = mLista;
        }

        private void CargarInactivo()
        {
            mListaInactivo = new InsumoBL().ListaTodosInActivo(Parametros.intEmpresaId);
            gcInsumoInactivo.DataSource = mListaInactivo;
        }

        private void CargarBusqueda(int pagina, int registros)
        {
            //gcInsumo.DataSource = new InsumoBL().ListaBusqueda(Parametros.intEmpresaId, Parametros.intTiendaId, txtDescripcion.Text, pagina, registros);
        }

        private void CargarBusqueda()
        {
            gcInsumo.DataSource = mLista.Where(obj =>
                                       obj.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();


            ////gcInsumo.DataSource = new InsumoBL().ListaBusqueda(Parametros.intEmpresaId, Parametros.intTiendaId, txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina);
            //CalcularPaginas();
            //if (intPagina > intPaginaPrimero)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina < intPaginaUltima)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaPrimero)
            //    HabilitarBotones(false, false, true, true);
            //if (intPagina == intPaginaUltima)
            //    HabilitarBotones(true, true, false, false);
            //if (intPaginaPrimero == intPaginaUltima)
            //    HabilitarBotones(false, false, false, false);

        }
        private void CargarBusquedaCodigo()
        {
            gcInsumo.DataSource = mLista.Where(obj =>
                                       obj.IdInsumo.ToString().ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();


            ////gcInsumo.DataSource = new InsumoBL().ListaBusqueda(Parametros.intEmpresaId, Parametros.intTiendaId, txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina);
            //CalcularPaginas();
            //if (intPagina > intPaginaPrimero)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina < intPaginaUltima)
            //    HabilitarBotones(true, true, true, true);
            //if (intPagina == intPaginaPrimero)
            //    HabilitarBotones(false, false, true, true);
            //if (intPagina == intPaginaUltima)
            //    HabilitarBotones(true, true, false, false);
            //if (intPaginaPrimero == intPaginaUltima)
            //    HabilitarBotones(false, false, false, false);

        }


        public void InicializarModificar()
        {
            if (gvInsumo.RowCount > 0)
            {
                InsumoBE objInsumo = new InsumoBE();
                objInsumo.IdInsumo = int.Parse(gvInsumo.GetFocusedRowCellValue("IdInsumo").ToString());

                frmManInsumoEdit objManInsumoEdit = new frmManInsumoEdit();
                objManInsumoEdit.pOperacion = frmManInsumoEdit.Operacion.Modificar;
                objManInsumoEdit.IdInsumo = objInsumo.IdInsumo;
                objManInsumoEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManInsumoEdit.ShowDialog() == DialogResult.OK)
                {
                    int intFoco = gvInsumo.FocusedRowHandle;
                    Cargar();
                    gvInsumo.FocusedRowHandle = intFoco;
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        public void InicializarModificarInactivo()
        {
            if (gvInsumoInactivo.RowCount > 0)
            {
                InsumoBE objInsumo = new InsumoBE();
                objInsumo.IdInsumo = int.Parse(gvInsumoInactivo.GetFocusedRowCellValue("IdInsumo").ToString());

                frmManInsumoEdit objManInsumoEdit = new frmManInsumoEdit();
                objManInsumoEdit.pOperacion = frmManInsumoEdit.Operacion.Modificar;
                objManInsumoEdit.IdInsumo = objInsumo.IdInsumo;
                objManInsumoEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManInsumoEdit.ShowDialog() == DialogResult.OK)
                {
                    CargarInactivo();
                }
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
            //intRowCount = new InsumoBL().ListaBusquedaCount(Parametros.intEmpresaId, txtDescripcion.Text);
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

            if (gvInsumo.GetFocusedRowCellValue("IdInsumo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Insumo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarInactivos()
        {
            mListaInactivo = new InsumoBL().ListaTodosInActivo(Parametros.intEmpresaId);
            gcInsumoInactivo.DataSource = mListaInactivo;
            lblTotalRegistrosInactivos.Text = gvInsumoInactivo.RowCount.ToString() + " Registros encontrados";
        }

        #endregion

        private void importarimageneswebtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarImagenesWeb objImportar = new frmImportarImagenesWeb();
            objImportar.HangTag = true;
            objImportar.StartPosition = FormStartPosition.CenterParent;
            objImportar.Show();
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarInactivos();
        }

        private void gvInsumoInactivo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaInactivoDoubleClick(view, pt);
        }

        private void txtInsumoInactivo_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusquedaInactivo();
        }

        private void CargarBusquedaInactivo()
        {
            gcInsumoInactivo.DataSource = mListaInactivo.Where(obj =>
                                                   obj.Descripcion.ToUpper().Contains(txtInsumoInactivo.Text.ToUpper())).ToList();

            lblTotalRegistrosInactivos.Text = gvInsumo.RowCount.ToString();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaCodigo();
            }
        }
    }
}