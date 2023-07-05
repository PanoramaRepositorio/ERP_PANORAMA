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
    public partial class frmManLineaProducto : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        
        private List<LineaProductoBE> mLista = new List<LineaProductoBE>();

        #endregion

        #region "Eventos"

        public frmManLineaProducto()
        {
            InitializeComponent();
        }

        private void frmManLineaProducto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManLineaProductoEdit objManLineaProducto = new frmManLineaProductoEdit();
                objManLineaProducto.lstLineaProducto = mLista;
                objManLineaProducto.pOperacion = frmManLineaProductoEdit.Operacion.Nuevo;
                objManLineaProducto.IdLineaProducto = 0;
                objManLineaProducto.StartPosition = FormStartPosition.CenterParent;
                objManLineaProducto.ShowDialog();
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
                        LineaProductoBE objE_LineaProducto = new LineaProductoBE();
                        objE_LineaProducto.IdLineaProducto = int.Parse(gvLineaProducto.GetFocusedRowCellValue("IdLineaProducto").ToString());
                        objE_LineaProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_LineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_LineaProducto.IdEmpresa = Parametros.intEmpresaId;

                        LineaProductoBL objBL_LineaProducto = new LineaProductoBL();
                        objBL_LineaProducto.Elimina(objE_LineaProducto);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteLineaProductoBE> lstReporte = null;
                lstReporte = new ReporteLineaProductoBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptLineaProducto = new RptVistaReportes();
                        objRptLineaProducto.VerRptLineaProducto(lstReporte);
                        objRptLineaProducto.ShowDialog();
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
            string _fileName = "ListadoLineaProductoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvLineaProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvLineaProducto_DoubleClick(object sender, EventArgs e)
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
            mLista = new LineaProductoBL().ListaTodosActivoFamilia(Parametros.intEmpresaId,0);
            gcLineaProducto.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcLineaProducto.DataSource = mLista.Where(obj =>
                                                   obj.DescLineaProducto.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvLineaProducto.RowCount > 0)
            {
                LineaProductoBE objLineaProducto = new LineaProductoBE();

                objLineaProducto.IdFamiliaProducto = int.Parse(gvLineaProducto.GetFocusedRowCellValue("IdFamiliaProducto").ToString());
                objLineaProducto.IdLineaProducto = int.Parse(gvLineaProducto.GetFocusedRowCellValue("IdLineaProducto").ToString());
                objLineaProducto.Numero = int.Parse(gvLineaProducto.GetFocusedRowCellValue("Numero").ToString());
                objLineaProducto.DescLineaProducto = gvLineaProducto.GetFocusedRowCellValue("DescLineaProducto").ToString();
                objLineaProducto.FlagEstado = Convert.ToBoolean(gvLineaProducto.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManLineaProductoEdit objManLineaProductoEdit = new frmManLineaProductoEdit();
                objManLineaProductoEdit.pOperacion = frmManLineaProductoEdit.Operacion.Modificar;
                objManLineaProductoEdit.IdLineaProducto = objLineaProducto.IdLineaProducto;
                objManLineaProductoEdit.pLineaProductoBE = objLineaProducto;
                objManLineaProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManLineaProductoEdit.ShowDialog();

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

            if (gvLineaProducto.GetFocusedRowCellValue("IdLineaProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Linea Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}