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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManSector : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<SectorBE> mLista = new List<SectorBE>();
        
        #endregion

        #region "Eventos"

        public frmManSector()
        {
            InitializeComponent();
        }

        private void frmManSector_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManSectorEdit objManSector = new frmManSectorEdit();
                objManSector.lstSector = mLista;
                objManSector.pOperacion = frmManSectorEdit.Operacion.Nuevo;
                objManSector.IdSector = 0;
                objManSector.StartPosition = FormStartPosition.CenterParent;
                objManSector.ShowDialog();
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
                        SectorBE objE_Sector = new SectorBE();
                        objE_Sector.IdSector = int.Parse(gvSector.GetFocusedRowCellValue("IdSector").ToString());
                        objE_Sector.Usuario = Parametros.strUsuarioLogin;
                        objE_Sector.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Sector.IdEmpresa = Parametros.intEmpresaId;

                        SectorBL objBL_Sector = new SectorBL();
                        objBL_Sector.Elimina(objE_Sector);
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

                List<ReporteSectorBE> lstReporte = null;
                lstReporte = new ReporteSectorBL().Listado(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptSector = new RptVistaReportes();
                        objRptSector.VerRptSector(lstReporte);
                        objRptSector.ShowDialog();
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
            string _fileName = "ListadoSectores";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSector.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSector_DoubleClick(object sender, EventArgs e)
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
            mLista = new SectorBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos);
            gcSector.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSector.DataSource = mLista.Where(obj =>
                                                   obj.DescSector.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSector.RowCount > 0)
            {
                SectorBE objSector = new SectorBE();
                objSector.IdTienda = int.Parse(gvSector.GetFocusedRowCellValue("IdTienda").ToString());
                objSector.IdAlmacen = int.Parse(gvSector.GetFocusedRowCellValue("IdAlmacen").ToString());
                objSector.IdSector = int.Parse(gvSector.GetFocusedRowCellValue("IdSector").ToString());
                objSector.DescSector = gvSector.GetFocusedRowCellValue("DescSector").ToString();
                objSector.FlagEstado = Convert.ToBoolean(gvSector.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManSectorEdit objManSectorEdit = new frmManSectorEdit();
                objManSectorEdit.pOperacion = frmManSectorEdit.Operacion.Modificar;
                objManSectorEdit.IdSector = objSector.IdSector;
                objManSectorEdit.pSectorBE = objSector;
                objManSectorEdit.StartPosition = FormStartPosition.CenterParent;
                objManSectorEdit.ShowDialog();

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

            if (gvSector.GetFocusedRowCellValue("IdSector").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Sector", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}