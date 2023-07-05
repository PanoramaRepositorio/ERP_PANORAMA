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
    public partial class frmManTipoDocumento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<TipoDocumentoBE> mLista = new List<TipoDocumentoBE>();
        
        #endregion

        #region "Eventos"

        public frmManTipoDocumento()
        {
            InitializeComponent();
        }

        private void frmManTipoDocumento_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoDocumentoEdit objManTipoDocumento = new frmManTipoDocumentoEdit();
                objManTipoDocumento.lstTipoDocumento = mLista;
                objManTipoDocumento.pOperacion = frmManTipoDocumentoEdit.Operacion.Nuevo;
                objManTipoDocumento.IdTipoDocumento = 0;
                objManTipoDocumento.StartPosition = FormStartPosition.CenterParent;
                objManTipoDocumento.ShowDialog();
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
                        TipoDocumentoBE objE_TipoDocumento = new TipoDocumentoBE();
                        objE_TipoDocumento.IdTipoDocumento = int.Parse(gvTipoDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                        objE_TipoDocumento.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoDocumento.IdEmpresa = Parametros.intEmpresaId;

                        TipoDocumentoBL objBL_TipoDocumento = new TipoDocumentoBL();
                        objBL_TipoDocumento.Elimina(objE_TipoDocumento);
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

                List<ReporteTipoDocumentoBE> lstReporte = null;
                lstReporte = new ReporteTipoDocumentoBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTipoDocumento = new RptVistaReportes();
                        objRptTipoDocumento.VerRptTipoDocumento(lstReporte);
                        objRptTipoDocumento.ShowDialog();
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
            string _fileName = "ListadoTipoDocumento";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoDocumento_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoDocumentoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTipoDocumento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTipoDocumento.DataSource = mLista.Where(obj =>
                                                   obj.DescTipoDocumento.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTipoDocumento.RowCount > 0)
            {
                TipoDocumentoBE objTipoDocumento = new TipoDocumentoBE();
                objTipoDocumento.IdTipoDocumento = int.Parse(gvTipoDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                objTipoDocumento.CodTipoDocumento = gvTipoDocumento.GetFocusedRowCellValue("CodTipoDocumento").ToString();
                objTipoDocumento.DescTipoDocumento = gvTipoDocumento.GetFocusedRowCellValue("DescTipoDocumento").ToString();
                objTipoDocumento.FlagEstado = Convert.ToBoolean(gvTipoDocumento.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTipoDocumentoEdit objManTipoDocumentoEdit = new frmManTipoDocumentoEdit();
                objManTipoDocumentoEdit.pOperacion = frmManTipoDocumentoEdit.Operacion.Modificar;
                objManTipoDocumentoEdit.IdTipoDocumento = objTipoDocumento.IdTipoDocumento;
                objManTipoDocumentoEdit.pTipoDocumentoBE = objTipoDocumento;
                objManTipoDocumentoEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoDocumentoEdit.ShowDialog();

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

            if (gvTipoDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoDocumento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}