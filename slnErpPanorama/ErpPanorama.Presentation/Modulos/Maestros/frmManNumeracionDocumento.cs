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
    public partial class frmManNumeracionDocumento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<NumeracionDocumentoBE> mLista = new List<NumeracionDocumentoBE>();

        #endregion

        #region "Eventos"

        public frmManNumeracionDocumento()
        {
            InitializeComponent();
        }

        private void frmManNumeracionDocumento_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManNumeracionDocumentoEdit objManNumeracionDocumento = new frmManNumeracionDocumentoEdit();
                objManNumeracionDocumento.lstNumeracionDocumento = mLista;
                objManNumeracionDocumento.pOperacion = frmManNumeracionDocumentoEdit.Operacion.Nuevo;
                objManNumeracionDocumento.IdNumeracionDocumento = 0;
                objManNumeracionDocumento.StartPosition = FormStartPosition.CenterParent;
                objManNumeracionDocumento.ShowDialog();
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
                        NumeracionDocumentoBE objE_NumeracionDocumento = new NumeracionDocumentoBE();
                        objE_NumeracionDocumento.IdNumeracionDocumento = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("IdNumeracionDocumento").ToString());
                        objE_NumeracionDocumento.Usuario = Parametros.strUsuarioLogin;
                        objE_NumeracionDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_NumeracionDocumento.IdEmpresa = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("IdEmpresa").ToString());

                        NumeracionDocumentoBL objBL_NumeracionDocumento = new NumeracionDocumentoBL();
                        objBL_NumeracionDocumento.Elimina(objE_NumeracionDocumento);
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

                List<ReporteNumeracionDocumentoBE> lstReporte = null;
                lstReporte = new ReporteNumeracionDocumentoBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptNumeracionDocumento = new RptVistaReportes();
                        objRptNumeracionDocumento.VerRptNumeracionDocumento(lstReporte);
                        objRptNumeracionDocumento.ShowDialog();
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
            string _fileName = "ListadoNumeracionDocumentoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvNumeracionDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvNumeracionDocumento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new NumeracionDocumentoBL().ListaTodosActivo();
            gcNumeracionDocumento.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvNumeracionDocumento.RowCount > 0)
            {
                NumeracionDocumentoBE objNumeracionDocumento = new NumeracionDocumentoBE();
                objNumeracionDocumento.IdEmpresa = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("IdEmpresa").ToString());
                objNumeracionDocumento.IdTienda = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("IdTienda").ToString());
                objNumeracionDocumento.IdNumeracionDocumento = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("IdNumeracionDocumento").ToString());
                objNumeracionDocumento.Periodo = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("Periodo").ToString());
                objNumeracionDocumento.IdTipoDocumento = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                objNumeracionDocumento.Serie = gvNumeracionDocumento.GetFocusedRowCellValue("Serie").ToString();
                objNumeracionDocumento.Numero = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("Numero").ToString());
                objNumeracionDocumento.NumeroCaracter = int.Parse(gvNumeracionDocumento.GetFocusedRowCellValue("NumeroCaracter").ToString());
                objNumeracionDocumento.FlagFacturacion = Convert.ToBoolean(gvNumeracionDocumento.GetFocusedRowCellValue("FlagFacturacion").ToString());
                objNumeracionDocumento.FlagEstado = Convert.ToBoolean(gvNumeracionDocumento.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManNumeracionDocumentoEdit objManNumeracionDocumentoEdit = new frmManNumeracionDocumentoEdit();
                objManNumeracionDocumentoEdit.pOperacion = frmManNumeracionDocumentoEdit.Operacion.Modificar;
                objManNumeracionDocumentoEdit.IdNumeracionDocumento = objNumeracionDocumento.IdNumeracionDocumento;
                objManNumeracionDocumentoEdit.pNumeracionDocumentoBE = objNumeracionDocumento;
                objManNumeracionDocumentoEdit.StartPosition = FormStartPosition.CenterParent;
                objManNumeracionDocumentoEdit.ShowDialog();

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

            if (gvNumeracionDocumento.GetFocusedRowCellValue("IdNumeracionDocumento").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una NumeracionDocumento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}