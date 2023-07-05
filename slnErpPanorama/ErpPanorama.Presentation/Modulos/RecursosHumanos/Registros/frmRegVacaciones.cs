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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegVacaciones : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<VacacionesBE> mLista = new List<VacacionesBE>();

        #endregion

        #region "Eventos"

        public frmRegVacaciones()
        {
            InitializeComponent();
        }

        private void frmRegVacaciones_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegVacacionesEdit objManVacaciones = new frmRegVacacionesEdit();
                objManVacaciones.lstVacaciones = mLista;
                objManVacaciones.pOperacion = frmRegVacacionesEdit.Operacion.Nuevo;
                objManVacaciones.IdVacaciones = 0;
                objManVacaciones.StartPosition = FormStartPosition.CenterParent;
                objManVacaciones.ShowDialog();
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
                        VacacionesBE objE_Vacaciones = new VacacionesBE();
                        objE_Vacaciones.IdVacaciones = int.Parse(gvVacaciones.GetFocusedRowCellValue("IdVacaciones").ToString());
                        objE_Vacaciones.Usuario = Parametros.strUsuarioLogin;
                        objE_Vacaciones.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Vacaciones.IdEmpresa = Parametros.intEmpresaId;

                        VacacionesBL objBL_Vacaciones = new VacacionesBL();
                        objBL_Vacaciones.Elimina(objE_Vacaciones);
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
                 
                string sEstado = (gvVacaciones.GetFocusedRowCellValue("DescSituacion").ToString());

                if (sEstado == "PENDIENTE")
                {
                    MessageBox.Show("No se puede realizar el reporte con la situación Pendiente");
                }
                else {
                    List<ReporteVacacionesVendidasBE> lstReporte = null;
                    lstReporte = new ReporteVacacionesVendidasBL().Listado(int.Parse(gvVacaciones.GetFocusedRowCellValue("IdVacaciones").ToString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptVacaciones = new RptVistaReportes();
                            objRptVacaciones.VerRptVacaciones2(lstReporte);
                            objRptVacaciones.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoVacaciones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvVacaciones.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvVacaciones_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }
       

        #endregion

        

        #region "Metodos"

        private void Cargar()
        {
            mLista = new VacacionesBL().ListaTodosActivo(Convert.ToInt32(txtPeriodo.EditValue));
            gcVacaciones.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcVacaciones.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvVacaciones.RowCount > 0)
            {
                VacacionesBE objVacaciones = new VacacionesBE();
                objVacaciones.IdVacaciones = int.Parse(gvVacaciones.GetFocusedRowCellValue("IdVacaciones").ToString());

                frmRegVacacionesEdit objManVacacionesEdit = new frmRegVacacionesEdit();
                objManVacacionesEdit.pOperacion = frmRegVacacionesEdit.Operacion.Modificar;
                objManVacacionesEdit.IdVacaciones = objVacaciones.IdVacaciones;
                objManVacacionesEdit.StartPosition = FormStartPosition.CenterParent;
                objManVacacionesEdit.ShowDialog();

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

            if (gvVacaciones.GetFocusedRowCellValue("IdVacaciones").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Vacaciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void gvVacaciones_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvVacaciones.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdSituacion"]);
                    if (objDocRetiro != null)
                    {
                        int IdSituacion = int.Parse(objDocRetiro.ToString());
                        if (IdSituacion == Parametros.intSITVacacionesCurso)
                        {
                            e.Appearance.BackColor = Color.YellowGreen;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void declaradoPLEtoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}