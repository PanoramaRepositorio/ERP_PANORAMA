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

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    public partial class frmManPreventa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<PreventaBE> mLista = new List<PreventaBE>();

        #endregion

        #region "Eventos"

        public frmManPreventa()
        {
            InitializeComponent();
        }

        private void frmManPreventa_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPreventaEdit objManPreventa = new frmManPreventaEdit();
                objManPreventa.pOperacion = frmManPreventaEdit.Operacion.Nuevo;
                objManPreventa.IdPreventa = 0;
                objManPreventa.StartPosition = FormStartPosition.CenterParent;
                objManPreventa.ShowDialog();
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
                        PreventaBE objE_Preventa = new PreventaBE();
                        objE_Preventa.IdPreventa = int.Parse(gvPreventa.GetFocusedRowCellValue("IdPreventa").ToString());
                        objE_Preventa.Usuario = Parametros.strUsuarioLogin;
                        objE_Preventa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Preventa.IdEmpresa = Parametros.intEmpresaId;

                        PreventaBL objBL_Preventa = new PreventaBL();
                        objBL_Preventa.Elimina(objE_Preventa);
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

            //    List<ErpPanoramaServicios.ReportePreventaBE> lstReporte = null;
            //    lstReporte = objServicio.ReportePreventa_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPreventa = new RptVistaReportes();
            //            objRptPreventa.VerRptPreventa(lstReporte);
            //            objRptPreventa.ShowDialog();
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
            string _fileName = "ListadoPreventa";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPreventa.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPreventa_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PreventaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcPreventa.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvPreventa.RowCount > 0)
            {
                PreventaBE objPreventa = new PreventaBE();
                objPreventa.IdPreventa = int.Parse(gvPreventa.GetFocusedRowCellValue("IdPreventa").ToString());
                objPreventa.DescPreventa = gvPreventa.GetFocusedRowCellValue("DescPreventa").ToString();
                objPreventa.FechaInicio = DateTime.Parse(gvPreventa.GetFocusedRowCellValue("FechaInicio").ToString());
                objPreventa.FechaFin = DateTime.Parse(gvPreventa.GetFocusedRowCellValue("FechaFin").ToString());
                objPreventa.Observacion = gvPreventa.GetFocusedRowCellValue("Observacion").ToString();

                frmManPreventaEdit objManPreventaEdit = new frmManPreventaEdit();
                objManPreventaEdit.pOperacion = frmManPreventaEdit.Operacion.Modificar;
                objManPreventaEdit.IdPreventa = objPreventa.IdPreventa;
                objManPreventaEdit.pPreventaBE = objPreventa;
                objManPreventaEdit.StartPosition = FormStartPosition.CenterParent;
                objManPreventaEdit.ShowDialog();

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

            if (gvPreventa.GetFocusedRowCellValue("IdPreventa").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Preventa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



    }
}