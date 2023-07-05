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
    public partial class frmManCampana : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<CampanaBE> mLista = new List<CampanaBE>();

        #endregion

        #region "Eventos"

        public frmManCampana()
        {
            InitializeComponent();
        }

        private void frmManCampana_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCampanaEdit objManCampana = new frmManCampanaEdit();
                objManCampana.lstCampana = mLista;
                objManCampana.pOperacion = frmManCampanaEdit.Operacion.Nuevo;
                objManCampana.IdCampana = 0;
                objManCampana.StartPosition = FormStartPosition.CenterParent;
                objManCampana.ShowDialog();
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
                        CampanaBE objE_Campana = new CampanaBE();
                        objE_Campana.IdCampana = int.Parse(gvCampana.GetFocusedRowCellValue("IdCampana").ToString());
                        objE_Campana.Usuario = Parametros.strUsuarioLogin;
                        objE_Campana.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Campana.IdEmpresa = Parametros.intEmpresaId;

                        CampanaBL objBL_Campana = new CampanaBL();
                        objBL_Campana.Elimina(objE_Campana);
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

                List<ReporteCampanaBE> lstReporte = null;
                lstReporte = new ReporteCampanaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCampana = new RptVistaReportes();
                        objRptCampana.VerRptCampana(lstReporte);
                        objRptCampana.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string _fileName = "ListadoCampanas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCampana.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCampana_DoubleClick(object sender, EventArgs e)
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
            mLista = new CampanaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCampana.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCampana.DataSource = mLista.Where(obj =>
                                                   obj.DescCampana.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCampana.RowCount > 0)
            {
                CampanaBE objCampana = new CampanaBE();
                objCampana.IdCampana = int.Parse(gvCampana.GetFocusedRowCellValue("IdCampana").ToString());
                objCampana.DescCampana = gvCampana.GetFocusedRowCellValue("DescCampana").ToString();
                objCampana.FlagEstado = Convert.ToBoolean(gvCampana.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCampanaEdit objManCampanaEdit = new frmManCampanaEdit();
                objManCampanaEdit.pOperacion = frmManCampanaEdit.Operacion.Modificar;
                objManCampanaEdit.IdCampana = objCampana.IdCampana;
                objManCampanaEdit.pCampanaBE = objCampana;
                objManCampanaEdit.StartPosition = FormStartPosition.CenterParent;
                objManCampanaEdit.ShowDialog();

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

            if (gvCampana.GetFocusedRowCellValue("IdCampana").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Campana", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}