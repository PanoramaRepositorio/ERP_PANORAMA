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
    public partial class frmManUbicacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<UbicacionBE> mLista = new List<UbicacionBE>();
        
        #endregion

        #region "Eventos"

        public frmManUbicacion()
        {
            InitializeComponent();
        }

        private void frmManUbicacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManUbicacionEdit objManUbicacion = new frmManUbicacionEdit();
                objManUbicacion.lstUbicacion = mLista;
                objManUbicacion.pOperacion = frmManUbicacionEdit.Operacion.Nuevo;
                objManUbicacion.IdUbicacion = 0;
                objManUbicacion.StartPosition = FormStartPosition.CenterParent;
                objManUbicacion.ShowDialog();
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
                        UbicacionBE objE_Ubicacion = new UbicacionBE();
                        objE_Ubicacion.IdUbicacion = int.Parse(gvUbicacion.GetFocusedRowCellValue("IdUbicacion").ToString());
                        objE_Ubicacion.Usuario = Parametros.strUsuarioLogin;
                        objE_Ubicacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Ubicacion.IdEmpresa = Parametros.intEmpresaId;

                        UbicacionBL objBL_Ubicacion = new UbicacionBL();
                        objBL_Ubicacion.Elimina(objE_Ubicacion);
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

                List<ReporteUbicacionBE> lstReporte = null;
                lstReporte = new ReporteUbicacionBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptUbicacion = new RptVistaReportes();
                        objRptUbicacion.VerRptUbicacion(lstReporte);
                        objRptUbicacion.ShowDialog();
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
            string _fileName = "ListadoUbicaciones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvUbicacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvUbicacion_DoubleClick(object sender, EventArgs e)
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
            mLista = new UbicacionBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId);
            gcUbicacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcUbicacion.DataSource = mLista.Where(obj =>
                                                   obj.DescUbicacion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvUbicacion.RowCount > 0)
            {
                UbicacionBE objUbicacion = new UbicacionBE();
                objUbicacion.IdUbicacion = int.Parse(gvUbicacion.GetFocusedRowCellValue("IdUbicacion").ToString());
                objUbicacion.DescUbicacion = gvUbicacion.GetFocusedRowCellValue("DescUbicacion").ToString();
                objUbicacion.FlagEstado = Convert.ToBoolean(gvUbicacion.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManUbicacionEdit objManUbicacionEdit = new frmManUbicacionEdit();
                objManUbicacionEdit.pOperacion = frmManUbicacionEdit.Operacion.Modificar;
                objManUbicacionEdit.IdUbicacion = objUbicacion.IdUbicacion;
                objManUbicacionEdit.pUbicacionBE = objUbicacion;
                objManUbicacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManUbicacionEdit.ShowDialog();

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

            if (gvUbicacion.GetFocusedRowCellValue("IdUbicacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Ubicacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}