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
    public partial class frmManContratoAsesoria : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<Dis_ContratoAsesoriaBE> mLista = new List<Dis_ContratoAsesoriaBE>();

        #endregion

        #region "Eventos"

        public frmManContratoAsesoria()
        {
            InitializeComponent();
        }

        private void frmManContratoAsesoria_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManContratoAsesoriaEdit objManDis_ContratoAsesoria = new frmManContratoAsesoriaEdit();
                objManDis_ContratoAsesoria.lstDis_ContratoAsesoria = mLista;
                objManDis_ContratoAsesoria.pOperacion = frmManContratoAsesoriaEdit.Operacion.Nuevo;
                objManDis_ContratoAsesoria.IdDis_ContratoAsesoria = 0;
                objManDis_ContratoAsesoria.StartPosition = FormStartPosition.CenterParent;
                objManDis_ContratoAsesoria.ShowDialog();
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
                        Dis_ContratoAsesoriaBE objE_Dis_ContratoAsesoria = new Dis_ContratoAsesoriaBE();
                        objE_Dis_ContratoAsesoria.IdDis_ContratoAsesoria = int.Parse(gvDis_ContratoAsesoria.GetFocusedRowCellValue("IdDis_ContratoAsesoria").ToString());
                        objE_Dis_ContratoAsesoria.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_ContratoAsesoria.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_ContratoAsesoria.IdEmpresa = Parametros.intEmpresaId;

                        Dis_ContratoAsesoriaBL objBL_Dis_ContratoAsesoria = new Dis_ContratoAsesoriaBL();
                        objBL_Dis_ContratoAsesoria.Elimina(objE_Dis_ContratoAsesoria);
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

            //    List<ReporteDis_ContratoAsesoriaBE> lstReporte = null;
            //    lstReporte = new ReporteDis_ContratoAsesoriaBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDis_ContratoAsesoria = new RptVistaReportes();
            //            objRptDis_ContratoAsesoria.VerRptDis_ContratoAsesoria(lstReporte);
            //            objRptDis_ContratoAsesoria.ShowDialog();
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
            string _fileName = "Listado_ContratoAsesorias";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_ContratoAsesoria.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDis_ContratoAsesoria_DoubleClick(object sender, EventArgs e)
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
            mLista = new Dis_ContratoAsesoriaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDis_ContratoAsesoria.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDis_ContratoAsesoria.DataSource = mLista.Where(obj =>
                                                   obj.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDis_ContratoAsesoria.RowCount > 0)
            {
                Dis_ContratoAsesoriaBE objDis_ContratoAsesoria = new Dis_ContratoAsesoriaBE();
                objDis_ContratoAsesoria.IdDis_ContratoAsesoria = int.Parse(gvDis_ContratoAsesoria.GetFocusedRowCellValue("IdDis_ContratoAsesoria").ToString());
                objDis_ContratoAsesoria.Descripcion = gvDis_ContratoAsesoria.GetFocusedRowCellValue("Descripcion").ToString();
                objDis_ContratoAsesoria.FlagEstado = Convert.ToBoolean(gvDis_ContratoAsesoria.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManContratoAsesoriaEdit objManDis_ContratoAsesoriaEdit = new frmManContratoAsesoriaEdit();
                objManDis_ContratoAsesoriaEdit.pOperacion = frmManContratoAsesoriaEdit.Operacion.Modificar;
                objManDis_ContratoAsesoriaEdit.IdDis_ContratoAsesoria = objDis_ContratoAsesoria.IdDis_ContratoAsesoria;
                //objManDis_ContratoAsesoriaEdit.pDis_ContratoAsesoriaBE = objDis_ContratoAsesoria;
                objManDis_ContratoAsesoriaEdit.StartPosition = FormStartPosition.CenterParent;
                objManDis_ContratoAsesoriaEdit.ShowDialog();

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

            if (gvDis_ContratoAsesoria.GetFocusedRowCellValue("IdDis_ContratoAsesoria").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Dis_ContratoAsesoria", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
 

    }
}