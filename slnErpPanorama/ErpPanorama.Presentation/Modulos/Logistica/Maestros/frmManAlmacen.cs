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
    public partial class frmManAlmacen : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        
        private List<AlmacenBE> mLista = new List<AlmacenBE>();

        #endregion

        #region "Eventos"

        public frmManAlmacen()
        {
            InitializeComponent();
        }

        private void frmManAlmacen_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManAlmacenEdit objManAlmacen = new frmManAlmacenEdit();
                objManAlmacen.lstAlmacen = mLista;
                objManAlmacen.pOperacion = frmManAlmacenEdit.Operacion.Nuevo;
                objManAlmacen.IdAlmacen = 0;
                objManAlmacen.StartPosition = FormStartPosition.CenterParent;
                objManAlmacen.ShowDialog();
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
                        AlmacenBE objE_Almacen = new AlmacenBE();
                        objE_Almacen.IdAlmacen = int.Parse(gvAlmacen.GetFocusedRowCellValue("IdAlmacen").ToString());
                        objE_Almacen.Usuario = Parametros.strUsuarioLogin;
                        objE_Almacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Almacen.IdEmpresa = Parametros.intEmpresaId;

                        AlmacenBL objBL_Almacen = new AlmacenBL();
                        objBL_Almacen.Elimina(objE_Almacen);
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

                List<ReporteAlmacenBE> lstReporte = null;
                lstReporte = new ReporteAlmacenBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptAlmacen = new RptVistaReportes();
                        objRptAlmacen.VerRptAlmacen(lstReporte);
                        objRptAlmacen.ShowDialog();
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
            string _fileName = "ListadoAlmacen";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAlmacen.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAlmacen_DoubleClick(object sender, EventArgs e)
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
            mLista = new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId,0);
            gcAlmacen.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcAlmacen.DataSource = mLista.Where(obj =>
                                                   obj.DescAlmacen.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvAlmacen.RowCount > 0)
            {
                AlmacenBE objAlmacen = new AlmacenBE();
                objAlmacen.IdEmpresa = int.Parse(gvAlmacen.GetFocusedRowCellValue("IdEmpresa").ToString());
                objAlmacen.IdTienda = int.Parse(gvAlmacen.GetFocusedRowCellValue("IdTienda").ToString());
                objAlmacen.IdAlmacen = int.Parse(gvAlmacen.GetFocusedRowCellValue("IdAlmacen").ToString());
                objAlmacen.DescAlmacen = gvAlmacen.GetFocusedRowCellValue("DescAlmacen").ToString();
                objAlmacen.FlagEstado = Convert.ToBoolean(gvAlmacen.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManAlmacenEdit objManAlmacenEdit = new frmManAlmacenEdit();
                objManAlmacenEdit.pOperacion = frmManAlmacenEdit.Operacion.Modificar;
                objManAlmacenEdit.IdAlmacen = objAlmacen.IdAlmacen;
                objManAlmacenEdit.pAlmacenBE = objAlmacen;
                objManAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                objManAlmacenEdit.ShowDialog();

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

            if (gvAlmacen.GetFocusedRowCellValue("IdAlmacen").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Almacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}