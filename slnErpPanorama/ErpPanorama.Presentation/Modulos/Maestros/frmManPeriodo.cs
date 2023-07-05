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
    public partial class frmManPeriodo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<PeriodoBE> mLista = new List<PeriodoBE>();

        #endregion

        #region "Eventos"
        public frmManPeriodo()
        {
            InitializeComponent();
        }

        private void frmManPeriodo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPeriodoEdit objManPeriodo = new frmManPeriodoEdit();
                objManPeriodo.lstPeriodo = mLista;
                objManPeriodo.pOperacion = frmManPeriodoEdit.Operacion.Nuevo;
                objManPeriodo.IdPeriodo = 0;
                objManPeriodo.StartPosition = FormStartPosition.CenterParent;
                objManPeriodo.ShowDialog();
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
                if (XtraMessageBox.Show("Esta seguro de cerrar el periodo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        PeriodoBE objE_Periodo = new PeriodoBE();
                        objE_Periodo.IdPeriodo = int.Parse(gvPeriodo.GetFocusedRowCellValue("IdPeriodo").ToString());
                        objE_Periodo.Usuario = Parametros.strUsuarioLogin;
                        objE_Periodo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PeriodoBL objBL_Elimina = new PeriodoBL();
                        objBL_Elimina.Elimina(objE_Periodo);
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

            //    List<ReportePeriodoBE> lstReporte = null;
            //    lstReporte = new ReportePeriodoBL().Listado(Parametros.intEmpresaId, 0);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPeriodo = new RptVistaReportes();
            //            objRptPeriodo.VerRptPeriodo(lstReporte);
            //            objRptPeriodo.ShowDialog();
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
            string _fileName = "ListadoPeriodoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPeriodo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPeriodo_DoubleClick(object sender, EventArgs e)
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

        private void gvPeriodo_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPeriodo.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objEstatus = View.GetRowCellValue(e.RowHandle, View.Columns["Estatus"]);
                    if (objEstatus != null)
                    {
                        string Estatus = objEstatus.ToString();
                        if (Estatus == "CERRADO")
                        {
                            e.Appearance.BackColor = Color.Red;
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


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PeriodoBL().ListaTodosActivo();
            gcPeriodo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPeriodo.DataSource = mLista.Where(obj =>
                                                   obj.NombreMes.Contains(txtDescripcion.Text) || obj.Estatus.Contains(txtDescripcion.Text)).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPeriodo.RowCount > 0)
            {
                PeriodoBE objPeriodo = new PeriodoBE();
                objPeriodo.IdPeriodo = int.Parse(gvPeriodo.GetFocusedRowCellValue("IdPeriodo").ToString());
                objPeriodo.Periodo = int.Parse(gvPeriodo.GetFocusedRowCellValue("Periodo").ToString());
                objPeriodo.Mes = int.Parse(gvPeriodo.GetFocusedRowCellValue("Mes").ToString());
                objPeriodo.FlagEstado = Convert.ToBoolean(gvPeriodo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPeriodoEdit objManPeriodoEdit = new frmManPeriodoEdit();
                objManPeriodoEdit.pOperacion = frmManPeriodoEdit.Operacion.Modificar;
                objManPeriodoEdit.IdPeriodo = objPeriodo.IdPeriodo;
                objManPeriodoEdit.pPeriodoBE = objPeriodo;
                objManPeriodoEdit.StartPosition = FormStartPosition.CenterParent;
                objManPeriodoEdit.ShowDialog();

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

            if (gvPeriodo.GetFocusedRowCellValue("IdPeriodo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Periodo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void abrirperiodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (XtraMessageBox.Show("Esta seguro de abrir el periodo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PeriodoBE objE_Periodo = (PeriodoBE)gvPeriodo.GetRow(gvPeriodo.FocusedRowHandle);
                        objE_Periodo.FlagEstado = true;
                        PeriodoBL objBL_Periodo = new PeriodoBL();
                        objBL_Periodo.Actualiza(objE_Periodo);
                        XtraMessageBox.Show("Periodo Abierto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();                    
                    }
                    
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cerrarperiodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (XtraMessageBox.Show("Esta seguro de cerrar el periodo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PeriodoBE objE_Periodo = (PeriodoBE)gvPeriodo.GetRow(gvPeriodo.FocusedRowHandle);
                        objE_Periodo.FlagEstado = false;
                        PeriodoBL objBL_Periodo = new PeriodoBL();
                        objBL_Periodo.Actualiza(objE_Periodo);
                        XtraMessageBox.Show("Periodo Cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();                    
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}