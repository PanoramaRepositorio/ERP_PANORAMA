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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManInventarioVisualBloque : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioVisualBloqueBE> mLista = new List<InventarioVisualBloqueBE>();

        #endregion

        #region "Eventos"

        public frmManInventarioVisualBloque()
        {
            InitializeComponent();
        }

        private void frmManInventarioVisualBloque_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManInventarioVisualBloqueEdit objManInventarioVisualBloque = new frmManInventarioVisualBloqueEdit();
                objManInventarioVisualBloque.lstInventarioVisualBloque = mLista;
                objManInventarioVisualBloque.pOperacion = frmManInventarioVisualBloqueEdit.Operacion.Nuevo;
                objManInventarioVisualBloque.IdInventarioVisualBloque = 0;
                objManInventarioVisualBloque.StartPosition = FormStartPosition.CenterParent;
                objManInventarioVisualBloque.ShowDialog();
                Cargar();
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
                        InventarioVisualBloqueBE objE_InventarioVisualBloque = new InventarioVisualBloqueBE();
                        objE_InventarioVisualBloque.IdInventarioVisualBloque = int.Parse(gvInventarioVisualBloque.GetFocusedRowCellValue("IdInventarioVisualBloque").ToString());

                        InventarioVisualBloqueBL objBL_InventarioVisualBloque = new InventarioVisualBloqueBL();
                        objBL_InventarioVisualBloque.Elimina(objE_InventarioVisualBloque);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteInventarioVisualBloqueBE> lstReporte = null;
            //    lstReporte = new ReporteInventarioVisualBloqueBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptInventarioVisualBloque = new RptVistaReportes();
            //            objRptInventarioVisualBloque.VerRptInventarioVisualBloque(lstReporte);
            //            objRptInventarioVisualBloque.ShowDialog();
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
            string _fileName = "ListadoInventarioVisualBloque";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventarioVisualBloque.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInventarioVisualBloque_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InventarioVisualBloqueBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcInventarioVisualBloque.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcInventarioVisualBloque.DataSource = mLista.Where(obj => obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.DescBloque.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvInventarioVisualBloque.RowCount > 0)
            {
                InventarioVisualBloqueBE objInventarioVisualBloque = new InventarioVisualBloqueBE();
                objInventarioVisualBloque.IdInventarioVisualBloque = int.Parse(gvInventarioVisualBloque.GetFocusedRowCellValue("IdInventarioVisualBloque").ToString());
                objInventarioVisualBloque.IdTienda = int.Parse(gvInventarioVisualBloque.GetFocusedRowCellValue("IdTienda").ToString());
                objInventarioVisualBloque.DescBloque = gvInventarioVisualBloque.GetFocusedRowCellValue("DescBloque").ToString();
                objInventarioVisualBloque.FlagEstado = Convert.ToBoolean(gvInventarioVisualBloque.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManInventarioVisualBloqueEdit objManInventarioVisualBloqueEdit = new frmManInventarioVisualBloqueEdit();
                objManInventarioVisualBloqueEdit.pOperacion = frmManInventarioVisualBloqueEdit.Operacion.Modificar;
                objManInventarioVisualBloqueEdit.IdInventarioVisualBloque = objInventarioVisualBloque.IdInventarioVisualBloque;
                objManInventarioVisualBloqueEdit.pInventarioVisualBloqueBE = objInventarioVisualBloque;
                objManInventarioVisualBloqueEdit.StartPosition = FormStartPosition.CenterParent;
                objManInventarioVisualBloqueEdit.ShowDialog();

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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvInventarioVisualBloque.GetFocusedRowCellValue("IdInventarioVisualBloque").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Bloque", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}