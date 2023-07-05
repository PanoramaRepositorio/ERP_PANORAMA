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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManFeriado : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades

        private List<FeriadoBE> mLista = new List<FeriadoBE>();
        #endregion
        #region "Eventos"

        public frmManFeriado()
        {
            InitializeComponent();
        }

        private void frmManFeriado_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = DateTime.Now.Year;
            Cargar();

        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManFeriadoEdit objManFeriado = new frmManFeriadoEdit();
                objManFeriado.lstFeriado = mLista;
                objManFeriado.pOperacion = frmManFeriadoEdit.Operacion.Nuevo;
                objManFeriado.IdFeriado = 0;
                objManFeriado.StartPosition = FormStartPosition.CenterParent;
                objManFeriado.ShowDialog();
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
                        FeriadoBE objE_Feriado = new FeriadoBE();
                        objE_Feriado.IdFeriado = int.Parse(gvFeriado.GetFocusedRowCellValue("IdFeriado").ToString());
                        objE_Feriado.Usuario = Parametros.strUsuarioLogin;
                        objE_Feriado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Feriado.IdEmpresa = Parametros.intEmpresaId;

                        FeriadoBL objBL_Feriado = new FeriadoBL();
                        objBL_Feriado.Elimina(objE_Feriado);
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

            //   List<ReporteFeriadoBE> lstReporte = null;
            //   lstReporte = new ReporteFeriadoBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptFeriado = new RptVistaReportes();
            //            objRptFeriado.VerRptFeriado(lstReporte);
            //            objRptFeriado.ShowDialog();
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
            string _fileName = "ListadoFeriado";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFeriado.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFeriado_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new FeriadoBL().ListaTodosActivo(Convert.ToInt32(txtPeriodo.EditValue));
            gcFeriado.DataSource = mLista;
        }

        //private void CargarBusqueda()
        //{
        //    gcFeriado.DataSource = mLista.Where(obj =>
        //                                           obj.DescFeriado.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        //}

        public void InicializarModificar()
        {
            if (gvFeriado.RowCount > 0)
            {
                FeriadoBE objFeriado = new FeriadoBE();
                objFeriado.IdFeriado = int.Parse(gvFeriado.GetFocusedRowCellValue("IdFeriado").ToString());
                objFeriado.Fecha = DateTime.Parse(gvFeriado.GetFocusedRowCellValue("Fecha").ToString());
                objFeriado.DescFeriado = gvFeriado.GetFocusedRowCellValue("DescFeriado").ToString();

                frmManFeriadoEdit objManFeriadoEdit = new frmManFeriadoEdit();
                objManFeriadoEdit.pOperacion = frmManFeriadoEdit.Operacion.Modificar;
                objManFeriadoEdit.IdFeriado = objFeriado.IdFeriado;
                objManFeriadoEdit.pFeriadoBE = objFeriado;
                objManFeriadoEdit.StartPosition = FormStartPosition.CenterParent;
                objManFeriadoEdit.ShowDialog();

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

            if (gvFeriado.GetFocusedRowCellValue("IdFeriado").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Feriado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void txtPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPeriodo.Text.Length > 3)
                {
                    Cargar();
                }
                else
                {
                    XtraMessageBox.Show("Ingrese un año válido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}