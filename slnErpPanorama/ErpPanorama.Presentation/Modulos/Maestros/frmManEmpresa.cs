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
    public partial class frmManEmpresa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<EmpresaBE> mLista = new List<EmpresaBE>();
        
        #endregion

        #region "Eventos"

        public frmManEmpresa()
        {
            InitializeComponent();
        }

        private void frmManEmpresa_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManEmpresaEdit objManEmpresa = new frmManEmpresaEdit();
                objManEmpresa.lstEmpresa = mLista;
                objManEmpresa.pOperacion = frmManEmpresaEdit.Operacion.Nuevo;
                objManEmpresa.IdEmpresa = 0;
                objManEmpresa.StartPosition = FormStartPosition.CenterParent;
                objManEmpresa.ShowDialog();
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
                        EmpresaBE objE_Empresa = new EmpresaBE();
                        objE_Empresa.IdEmpresa = int.Parse(gvEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString());
                        objE_Empresa.Usuario = Parametros.strUsuarioLogin;
                        objE_Empresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Empresa.IdEmpresa = Parametros.intEmpresaId;

                        EmpresaBL objBL_Empresa = new EmpresaBL();
                        objBL_Empresa.Elimina(objE_Empresa);
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

                List<ReporteEmpresaBE> lstReporte = null;
                lstReporte = new ReporteEmpresaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptEmpresa = new RptVistaReportes();
                        objRptEmpresa.VerRptEmpresa(lstReporte);
                        objRptEmpresa.ShowDialog();
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
            string _fileName = "ListadoEmpresaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEmpresa.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvEmpresa_DoubleClick(object sender, EventArgs e)
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
            mLista = new EmpresaBL().ListaTodosActivo(0);
            gcEmpresa.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcEmpresa.DataSource = mLista.Where(obj =>
                                                   obj.RazonSocial.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvEmpresa.RowCount > 0)
            {
                EmpresaBE objEmpresa = new EmpresaBE();
                objEmpresa.IdEmpresa = int.Parse(gvEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString());

                frmManEmpresaEdit objManEmpresaEdit = new frmManEmpresaEdit();
                objManEmpresaEdit.pOperacion = frmManEmpresaEdit.Operacion.Modificar;
                objManEmpresaEdit.IdEmpresa = objEmpresa.IdEmpresa;
                objManEmpresaEdit.StartPosition = FormStartPosition.CenterParent;
                objManEmpresaEdit.ShowDialog();

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

            if (gvEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}