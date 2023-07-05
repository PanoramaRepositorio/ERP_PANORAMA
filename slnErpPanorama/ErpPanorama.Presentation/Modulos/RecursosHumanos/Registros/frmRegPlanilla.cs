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
using ErpPanorama.Presentation.Utils;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPlanilla : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PlanillaBE> mLista = new List<PlanillaBE>();
       
        
        #endregion

        #region "Eventos"

        public frmRegPlanilla()
        {
            InitializeComponent();
        }

        private void frmRegPlanilla_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = DateTime.Now.Year;
            cboMes.EditValue = DateTime.Now.Month;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegPlanillaEdit objManPlanilla = new frmRegPlanillaEdit();
                objManPlanilla.lstPlanilla = mLista;
                objManPlanilla.pOperacion = frmRegPlanillaEdit.Operacion.Nuevo;
                objManPlanilla.IdPlanilla = 0;
                objManPlanilla.StartPosition = FormStartPosition.CenterParent;
                objManPlanilla.ShowDialog();
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
                        PlanillaBE objE_Planilla = new PlanillaBE();
                        objE_Planilla.IdPlanilla = int.Parse(gvPlanilla.GetFocusedRowCellValue("IdPlanilla").ToString());
                        objE_Planilla.IdEmpresa = int.Parse(gvPlanilla.GetFocusedRowCellValue("IdEmpresa").ToString());
                        objE_Planilla.Usuario = Parametros.strUsuarioLogin;
                        objE_Planilla.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        //objE_Planilla.IdEmpresa = Parametros.intEmpresaId;

                        PlanillaBL objBL_Planilla = new PlanillaBL();
                        objBL_Planilla.Elimina(objE_Planilla);
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

            //   List<ReportePlanillaBE> lstReporte = null;
            //   lstReporte = new ReportePlanillaBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPlanilla = new RptVistaReportes();
            //            objRptPlanilla.VerRptPlanilla(lstReporte);
            //            objRptPlanilla.ShowDialog();
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
            string _fileName = "ListadoPlanilla";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPlanilla.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPlanilla_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        
        #region "Metodos"

        private void Cargar()
        {
            mLista = new PlanillaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), 0);
            gcPlanilla.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            mLista = new PlanillaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));
            gcPlanilla.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvPlanilla.RowCount > 0)
            {
                PlanillaBE objPlanilla = new PlanillaBE();
                objPlanilla.IdPlanilla = int.Parse(gvPlanilla.GetFocusedRowCellValue("IdPlanilla").ToString());

                frmRegPlanillaEdit objManPlanillaEdit = new frmRegPlanillaEdit();
                objManPlanillaEdit.pOperacion = frmRegPlanillaEdit.Operacion.Modificar;
                objManPlanillaEdit.IdPlanilla = objPlanilla.IdPlanilla;
                objManPlanillaEdit.StartPosition = FormStartPosition.CenterParent;
                objManPlanillaEdit.ShowDialog();

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

            if (gvPlanilla.GetFocusedRowCellValue("IdPlanilla").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Planilla", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}