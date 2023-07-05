using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepTarjetaCaja : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReporteTarjetaCajaBE> mLista = new List<ReporteTarjetaCajaBE>();

        #endregion

        #region "Eventos"
        public frmRepTarjetaCaja()
        {
            InitializeComponent();
        }

        private void frmRepTarjetaCaja_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFecha.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    frmRegMuestraEdit objManMuestra = new frmRegMuestraEdit();
            //    objManMuestra.pOperacion = frmRegMuestraEdit.Operacion.Nuevo;
            //    objManMuestra.IdMuestra = 0;
            //    objManMuestra.StartPosition = FormStartPosition.CenterParent;
            //    objManMuestra.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
                        MuestraBE objE_Muestra = new MuestraBE();

                        objE_Muestra.IdMuestra = int.Parse(gvMuestra.GetFocusedRowCellValue("IdMuestra").ToString());
                        objE_Muestra.Usuario = Parametros.strUsuarioLogin;
                        objE_Muestra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Muestra.IdEmpresa = int.Parse(gvMuestra.GetFocusedRowCellValue("IdEmpresa").ToString());

                        MuestraBL objBL_Muestra = new MuestraBL();
                        objBL_Muestra.Elimina(objE_Muestra);
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

                //List<ReporteMuestraBE> lstReporte = null;
                //lstReporte = new ReporteMuestraBL().Listado(Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));

                //if (lstReporte != null)
                //{
                //    if (lstReporte.Count > 0)
                //    {
                //        RptVistaReportes objRptMuestra = new RptVistaReportes();
                //        objRptMuestra.VerRptMuestra(lstReporte);
                //        objRptMuestra.ShowDialog();
                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
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
            string _fileName = "ListadoMuestra";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMuestra.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMuestra_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            //mLista = new MuestraBL().ListaTodosActivo(Convert.ToDateTime(deFecha.EditValue));
            //gcMuestra.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            //if (gvMuestra.RowCount > 0)
            //{
            //    MuestraBE objMuestra = new MuestraBE();
            //    objMuestra.IdMuestra = int.Parse(gvMuestra.GetFocusedRowCellValue("IdMuestra").ToString());

            //    frmRegMuestraEdit objRegMuestraEdit = new frmRegMuestraEdit();
            //    objRegMuestraEdit.pOperacion = frmRegMuestraEdit.Operacion.Modificar;
            //    objRegMuestraEdit.IdMuestra = objMuestra.IdMuestra;
            //    objRegMuestraEdit.StartPosition = FormStartPosition.CenterParent;
            //    objRegMuestraEdit.ShowDialog();

            //    Cargar();
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
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

            if (gvMuestra.GetFocusedRowCellValue("IdMuestra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}