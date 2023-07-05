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

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManTipoColor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<Dis_TipoColorBE> mLista = new List<Dis_TipoColorBE>();

        #endregion

        #region "Eventos"

        public frmManTipoColor()
        {
            InitializeComponent();
        }

        private void frmManTipoColor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoColorEdit objManDis_TipoColor = new frmManTipoColorEdit();
                objManDis_TipoColor.lstDis_TipoColor = mLista;
                objManDis_TipoColor.pOperacion = frmManTipoColorEdit.Operacion.Nuevo;
                objManDis_TipoColor.IdDis_TipoColor = 0;
                objManDis_TipoColor.StartPosition = FormStartPosition.CenterParent;
                objManDis_TipoColor.ShowDialog();
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
                        Dis_TipoColorBE objE_Dis_TipoColor = new Dis_TipoColorBE();
                        objE_Dis_TipoColor.IdDis_TipoColor = int.Parse(gvDis_TipoColor.GetFocusedRowCellValue("IdDis_TipoColor").ToString());
                        objE_Dis_TipoColor.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_TipoColor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_TipoColor.IdEmpresa = Parametros.intEmpresaId;

                        Dis_TipoColorBL objBL_Dis_TipoColor = new Dis_TipoColorBL();
                        objBL_Dis_TipoColor.Elimina(objE_Dis_TipoColor);
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

                //    List<ReporteDis_TipoColorBE> lstReporte = null;
                //    lstReporte = new ReporteDis_TipoColorBL().Listado(Parametros.intEmpresaId);

                //    if (lstReporte != null)
                //    {
                //        if (lstReporte.Count > 0)
                //        {
                //            RptVistaReportes objRptDis_TipoColor = new RptVistaReportes();
                //            objRptDis_TipoColor.VerRptDis_TipoColor(lstReporte);
                //            objRptDis_TipoColor.ShowDialog();
                //        }
                //        else
                //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //    Cursor = Cursors.Default;
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
            string _fileName = "ListadoTipoColores";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_TipoColor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoColor_DoubleClick(object sender, EventArgs e)
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
            mLista = new Dis_TipoColorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDis_TipoColor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDis_TipoColor.DataSource = mLista.Where(obj =>
                                                   obj.DescDis_TipoColor.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDis_TipoColor.RowCount > 0)
            {
                Dis_TipoColorBE objDis_TipoColor = new Dis_TipoColorBE();
                objDis_TipoColor.IdDis_TipoColor = int.Parse(gvDis_TipoColor.GetFocusedRowCellValue("IdDis_TipoColor").ToString());
                objDis_TipoColor.DescDis_TipoColor = gvDis_TipoColor.GetFocusedRowCellValue("DescDis_TipoColor").ToString();
                objDis_TipoColor.FlagEstado = Convert.ToBoolean(gvDis_TipoColor.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoColorEdit objManDis_TipoColorEdit = new frmManTipoColorEdit();
                objManDis_TipoColorEdit.pOperacion = frmManTipoColorEdit.Operacion.Modificar;
                objManDis_TipoColorEdit.IdDis_TipoColor = objDis_TipoColor.IdDis_TipoColor;
                objManDis_TipoColorEdit.pDis_TipoColorBE = objDis_TipoColor;
                objManDis_TipoColorEdit.StartPosition = FormStartPosition.CenterParent;
                objManDis_TipoColorEdit.ShowDialog();

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

            if (gvDis_TipoColor.GetFocusedRowCellValue("IdDis_TipoColor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione TipoColor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}