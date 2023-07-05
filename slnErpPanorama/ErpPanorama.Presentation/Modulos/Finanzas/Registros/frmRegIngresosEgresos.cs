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

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegIngresosEgresos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<IngresoEgresoBE> mLista = new List<IngresoEgresoBE>();
        
        #endregion

        #region "Eventos"

        public frmRegIngresosEgresos()
        {
            InitializeComponent();
        }

        private void frmRegIngresosEgresos_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
 
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {

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

                //frmManTablasElemento objManTablaElemento = new frmManTablasElemento();
                //objManTablaElemento.IdTabla = IdTabla;
                //objManTablaElemento.StartPosition = FormStartPosition.CenterParent;
                //objManTablaElemento.ShowDialog();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new IngresoEgresoBL().Listar(txtDescripcion.Text);
            gcTabla.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTabla.DataSource = mLista.Where(obj =>
                                                   obj.DescTipificacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTabla.RowCount > 0)
            {
                SubTipificacionesBE objTabla = new SubTipificacionesBE();
                objTabla.IdTipificacion = int.Parse(gvTabla.GetFocusedRowCellValue("IdTipificacion").ToString());
                objTabla.IdSubTipificacion = int.Parse(gvTabla.GetFocusedRowCellValue("IdSubTipificacion").ToString());
                objTabla.DescSubTipificacion = gvTabla.GetFocusedRowCellValue("DescSubTipificacion").ToString();
                objTabla.IdArea = int.Parse(gvTabla.GetFocusedRowCellValue("IdArea").ToString());

                //frmManSubTipificacionesEdit objManTablaEdit = new frmManSubTipificacionesEdit();
                //objManTablaEdit.pOperacion = frmManSubTipificacionesEdit.Operacion.Modificar;
                //objManTablaEdit.IdTabla = objTabla.IdSubTipificacion;
                //objManTablaEdit.pSubTipificacionesBE = objTabla;
                //objManTablaEdit.StartPosition = FormStartPosition.CenterParent;
                //objManTablaEdit.ShowDialog();

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

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoTipificaciones";
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegIngresosEgresosEdit objManTabla = new frmRegIngresosEgresosEdit();
                objManTabla.lstIngresoEgreso = mLista;
                objManTabla.pOperacion = frmRegIngresosEgresosEdit.Operacion.Nuevo;
                objManTabla.StartPosition = FormStartPosition.CenterParent;
                objManTabla.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }
    }
}