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
    public partial class frmManArea : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<AreaBE> mLista = new List<AreaBE>();

        #endregion

        #region "Eventos"

        public frmManArea()
        {
            InitializeComponent();
        }

        private void frmManArea_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManAreaEdit objManArea = new frmManAreaEdit();
                objManArea.lstArea = mLista;
                objManArea.pOperacion = frmManAreaEdit.Operacion.Nuevo;
                objManArea.IdArea = 0;
                objManArea.StartPosition = FormStartPosition.CenterParent;
                objManArea.ShowDialog();
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
                        AreaBE objE_Area = new AreaBE();
                        objE_Area.IdArea = int.Parse(gvArea.GetFocusedRowCellValue("IdArea").ToString());
                        objE_Area.Usuario = Parametros.strUsuarioLogin;
                        objE_Area.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Area.IdEmpresa = Parametros.intEmpresaId;

                        AreaBL objBL_Area = new AreaBL();
                        objBL_Area.Elimina(objE_Area);
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

                List<ReporteAreaBE> lstReporte = null;
                lstReporte = new ReporteAreaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptArea = new RptVistaReportes();
                        objRptArea.VerRptArea(lstReporte);
                        objRptArea.ShowDialog();
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
            string _fileName = "ListadoArea";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvArea.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvArea_DoubleClick(object sender, EventArgs e)
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
            mLista = new AreaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcArea.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcArea.DataSource = mLista.Where(obj =>
                                                   obj.DescArea.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvArea.RowCount > 0)
            {
                AreaBE objArea = new AreaBE();
                objArea.IdEmpresa = int.Parse(gvArea.GetFocusedRowCellValue("IdEmpresa").ToString());
                objArea.IdArea = int.Parse(gvArea.GetFocusedRowCellValue("IdArea").ToString());
                objArea.DescArea = gvArea.GetFocusedRowCellValue("DescArea").ToString();
                objArea.FlagEstado = Convert.ToBoolean(gvArea.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManAreaEdit objManAreaEdit = new frmManAreaEdit();
                objManAreaEdit.pOperacion = frmManAreaEdit.Operacion.Modificar;
                objManAreaEdit.IdArea = objArea.IdArea;
                objManAreaEdit.pAreaBE = objArea;
                objManAreaEdit.StartPosition = FormStartPosition.CenterParent;
                objManAreaEdit.ShowDialog();

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

            if (gvArea.GetFocusedRowCellValue("IdArea").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Area", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}