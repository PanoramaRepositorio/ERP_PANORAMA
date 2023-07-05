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
    public partial class frmManForma : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<Dis_FormaBE> mLista = new List<Dis_FormaBE>();

        #endregion

        #region "Eventos"

        public frmManForma()
        {
            InitializeComponent();
        }

        private void frmManForma_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManFormaEdit objManDis_Forma = new frmManFormaEdit();
                objManDis_Forma.lstDis_Forma = mLista;
                objManDis_Forma.pOperacion = frmManFormaEdit.Operacion.Nuevo;
                objManDis_Forma.IdDis_Forma = 0;
                objManDis_Forma.StartPosition = FormStartPosition.CenterParent;
                objManDis_Forma.ShowDialog();
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
                        Dis_FormaBE objE_Dis_Forma = new Dis_FormaBE();
                        objE_Dis_Forma.IdDis_Forma = int.Parse(gvDis_Forma.GetFocusedRowCellValue("IdDis_Forma").ToString());
                        objE_Dis_Forma.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_Forma.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_Forma.IdEmpresa = Parametros.intEmpresaId;

                        Dis_FormaBL objBL_Dis_Forma = new Dis_FormaBL();
                        objBL_Dis_Forma.Elimina(objE_Dis_Forma);
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

                //    List<ReporteDis_FormaBE> lstReporte = null;
                //    lstReporte = new ReporteDis_FormaBL().Listado(Parametros.intEmpresaId);

                //    if (lstReporte != null)
                //    {
                //        if (lstReporte.Count > 0)
                //        {
                //            RptVistaReportes objRptDis_Forma = new RptVistaReportes();
                //            objRptDis_Forma.VerRptDis_Forma(lstReporte);
                //            objRptDis_Forma.ShowDialog();
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
            string _fileName = "ListadoFormaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_Forma.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvForma_DoubleClick(object sender, EventArgs e)
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
            mLista = new Dis_FormaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDis_Forma.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDis_Forma.DataSource = mLista.Where(obj =>
                                                   obj.DescDis_Forma.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDis_Forma.RowCount > 0)
            {
                Dis_FormaBE objDis_Forma = new Dis_FormaBE();
                objDis_Forma.IdDis_Forma = int.Parse(gvDis_Forma.GetFocusedRowCellValue("IdDis_Forma").ToString());
                objDis_Forma.DescDis_Forma = gvDis_Forma.GetFocusedRowCellValue("DescDis_Forma").ToString();
                objDis_Forma.FlagEstado = Convert.ToBoolean(gvDis_Forma.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManFormaEdit objManDis_FormaEdit = new frmManFormaEdit();
                objManDis_FormaEdit.pOperacion = frmManFormaEdit.Operacion.Modificar;
                objManDis_FormaEdit.IdDis_Forma = objDis_Forma.IdDis_Forma;
                objManDis_FormaEdit.pDis_FormaBE = objDis_Forma;
                objManDis_FormaEdit.StartPosition = FormStartPosition.CenterParent;
                objManDis_FormaEdit.ShowDialog();

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

            if (gvDis_Forma.GetFocusedRowCellValue("IdDis_Forma").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Forma", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}