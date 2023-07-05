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

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Maestros
{
    public partial class frmManTopeEmpresa : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"


        private List<TopeEmpresaBE> mLista = new List<TopeEmpresaBE>();

        #endregion

        #region "Eventos"

        public frmManTopeEmpresa()
        {
            InitializeComponent();
        }

        private void frmManTopeEmpresa_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTopeEmpresaEdit objManTopeEmpresa = new frmManTopeEmpresaEdit();
                objManTopeEmpresa.lstTopeEmpresa = mLista;
                objManTopeEmpresa.pOperacion = frmManTopeEmpresaEdit.Operacion.Nuevo;
                objManTopeEmpresa.IdEmpresa = 0;
                objManTopeEmpresa.StartPosition = FormStartPosition.CenterParent;
                objManTopeEmpresa.ShowDialog();
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
                        TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                        objE_TopeEmpresa.IdEmpresa = int.Parse(gvTopeEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString());
                        objE_TopeEmpresa.Usuario = Parametros.strUsuarioLogin;
                        objE_TopeEmpresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        TopeEmpresaBL objBL_TopeEmpresa = new TopeEmpresaBL();
                        objBL_TopeEmpresa.Elimina(objE_TopeEmpresa);
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

                List<TopeEmpresaBE> lstReporte = null;
                lstReporte = new TopeEmpresaBL().ListaTodosActivo();

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTopeEmpresa = new RptVistaReportes();
                        objRptTopeEmpresa.VerRptTopeEmpresa(lstReporte);
                        objRptTopeEmpresa.ShowDialog();
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
            string _fileName = "ListadoTopeEmpresaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTopeEmpresa.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTopeEmpresa_DoubleClick(object sender, EventArgs e)
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
            mLista = new TopeEmpresaBL().ListaTodosActivo();
            gcTopeEmpresa.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTopeEmpresa.DataSource = mLista.Where(obj => obj.RazonSocial.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTopeEmpresa.RowCount > 0)
            {
                TopeEmpresaBE objTopeEmpresa = new TopeEmpresaBE();
                objTopeEmpresa.IdEmpresa = int.Parse(gvTopeEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString());
                objTopeEmpresa.Tope = decimal.Parse(gvTopeEmpresa.GetFocusedRowCellValue("Tope").ToString());
                objTopeEmpresa.TopeDiario = decimal.Parse(gvTopeEmpresa.GetFocusedRowCellValue("TopeDiario").ToString());
                objTopeEmpresa.FlagEstado = Convert.ToBoolean(gvTopeEmpresa.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTopeEmpresaEdit objManTopeEmpresaEdit = new frmManTopeEmpresaEdit();
                objManTopeEmpresaEdit.pOperacion = frmManTopeEmpresaEdit.Operacion.Modificar;
                objManTopeEmpresaEdit.IdEmpresa = objTopeEmpresa.IdEmpresa;
                objManTopeEmpresaEdit.pTopeEmpresaBE = objTopeEmpresa;
                objManTopeEmpresaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTopeEmpresaEdit.ShowDialog();

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

            if (gvTopeEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}