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
    public partial class frmManComboPromocional : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        private List<ComboBE> mLista = new List<ComboBE>();
        
        #endregion

        #region "Eventos"

        public frmManComboPromocional()
        {
            InitializeComponent();
        }

        private void frmManComboPromocional_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManComboPromocionalEdit objManCombo = new frmManComboPromocionalEdit();
                objManCombo.pOperacion = frmManComboPromocionalEdit.Operacion.Nuevo;
                objManCombo.IdCombo = 0;
                objManCombo.StartPosition = FormStartPosition.CenterParent;
                objManCombo.ShowDialog();
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
                        ComboBE objE_Combo = new ComboBE();
                        objE_Combo.IdCombo = int.Parse(gvCombo.GetFocusedRowCellValue("IdCombo").ToString());
                        objE_Combo.Usuario = Parametros.strUsuarioLogin;
                        objE_Combo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Combo.IdEmpresa = Parametros.intEmpresaId;

                        ComboBL objBL_Combo = new ComboBL();
                        objBL_Combo.Elimina(objE_Combo);
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

            //    List<ErpPanoramaServicios.ReporteComboBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteCombo_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptCombo = new RptVistaReportes();
            //            objRptCombo.VerRptCombo(lstReporte);
            //            objRptCombo.ShowDialog();
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
            string _fileName = "ListadoCombo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCombo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCombo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ComboBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCombo.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCombo.RowCount > 0)
            {
                ComboBE objCombo = new ComboBE();
                objCombo.IdCombo = int.Parse(gvCombo.GetFocusedRowCellValue("IdCombo").ToString());
                objCombo.DescCombo = gvCombo.GetFocusedRowCellValue("DescCombo").ToString();
                objCombo.Total = decimal.Parse(gvCombo.GetFocusedRowCellValue("Total").ToString());

                frmManComboPromocionalEdit objManComboEdit = new frmManComboPromocionalEdit();
                objManComboEdit.pOperacion = frmManComboPromocionalEdit.Operacion.Modificar;
                objManComboEdit.IdCombo = objCombo.IdCombo;
                objManComboEdit.pComboBE = objCombo;
                objManComboEdit.StartPosition = FormStartPosition.CenterParent;
                objManComboEdit.ShowDialog();

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

            if (gvCombo.GetFocusedRowCellValue("IdCombo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Combo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion
    }
}