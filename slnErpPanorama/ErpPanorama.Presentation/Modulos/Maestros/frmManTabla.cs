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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTabla : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<TablaBE> mLista = new List<TablaBE>();
        
        #endregion

        #region "Eventos"

        public frmManTabla()
        {
            InitializeComponent();
        }

        private void frmManTabla_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTablaEdit objManTabla = new frmManTablaEdit();
                objManTabla.lstTabla = mLista;
                objManTabla.pOperacion = frmManTablaEdit.Operacion.Nuevo;
                objManTabla.IdTabla = 0;
                objManTabla.StartPosition = FormStartPosition.CenterParent;
                objManTabla.ShowDialog();
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
                        TablaBE objE_Tabla = new TablaBE();
                        objE_Tabla.IdTabla = int.Parse(gvTabla.GetFocusedRowCellValue("IdTabla").ToString());
                        objE_Tabla.Usuario = Parametros.strUsuarioLogin;
                        objE_Tabla.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Tabla.IdEmpresa = Parametros.intEmpresaId;

                        TablaBL objBL_Tabla = new TablaBL();
                        objBL_Tabla.Elimina(objE_Tabla);
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

                List<ReporteTablaElementoBE> lstReporte = null;
                lstReporte = new ReporteTablaElementoBL().Listado();

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTablaElemento = new RptVistaReportes();
                        objRptTablaElemento.VerRptTablaElemento(lstReporte);
                        objRptTablaElemento.ShowDialog();
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
            string _fileName = "ListadoTablaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTabla.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTabla_DoubleClick(object sender, EventArgs e)
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

        private void elementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTabla.RowCount > 0)
            {
                int IdTabla = int.Parse(gvTabla.GetFocusedRowCellValue("IdTabla").ToString());

                frmManTablaElemento objManTablaElemento = new frmManTablaElemento();
                objManTablaElemento.IdTabla = IdTabla;
                objManTablaElemento.StartPosition = FormStartPosition.CenterParent;
                objManTablaElemento.ShowDialog();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new TablaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTabla.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTabla.DataSource = mLista.Where(obj =>
                                                   obj.DescTabla.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTabla.RowCount > 0)
            {
                TablaBE objTabla = new TablaBE();
                objTabla.IdTabla = int.Parse(gvTabla.GetFocusedRowCellValue("IdTabla").ToString());
                objTabla.DescTabla = gvTabla.GetFocusedRowCellValue("DescTabla").ToString();
                objTabla.FlagEstado = Convert.ToBoolean(gvTabla.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTablaEdit objManTablaEdit = new frmManTablaEdit();
                objManTablaEdit.pOperacion = frmManTablaEdit.Operacion.Modificar;
                objManTablaEdit.IdTabla = objTabla.IdTabla;
                objManTablaEdit.pTablaBE = objTabla;
                objManTablaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTablaEdit.ShowDialog();

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

            if (gvTabla.GetFocusedRowCellValue("IdTabla").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Tabla", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
        
    }
}